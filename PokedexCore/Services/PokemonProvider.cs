using Newtonsoft.Json;
using PokedexCore.Models.Json;
using PokedexCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class PokemonProvider : IPokemonProvider {

        private readonly IPokemonHttpClientAdapter _pokemonHttpClientAdapter;
        private readonly IPokemonCache _pokemonCache;
        private readonly IPokemonDbAdapter _pokemonDbAdapter;
        private readonly Random _random = new Random();
        private PokemonList _pokemonList;

        public PokemonProvider( IPokemonHttpClientAdapter pokemonHttpClientAdapter, IPokemonCache pokemonCache, IPokemonDbAdapter pokemonDbAdapter ) {
            _pokemonHttpClientAdapter = pokemonHttpClientAdapter;
            _pokemonCache = pokemonCache;
            _pokemonDbAdapter = pokemonDbAdapter;
        }

        ~PokemonProvider() {

        }

        private PokemonList PokemonList {
            get {
                if(_pokemonList == null ) {
                    _pokemonList = GetPokemonList().Result;
                }
                return _pokemonList;
            }
        }

        public async Task<IList<Pokemon>> GetPokemons( int limit, int offset, string typeFilter ) {

            PokemonList pokemonList = await GetPokemonList();

            if ( pokemonList == null ) {
                return null;
            }

            IList<PokemonBio> selectedPokemons = new List<PokemonBio>();
            int i = 0;

            while ( i < pokemonList.count && selectedPokemons.Count < limit + offset ) {
                PokemonBio pokemonBio = pokemonList.results[i];

                if ( pokemonBio.Pokemon == null ) {
                    pokemonBio.Pokemon = await GetPokemonByName( pokemonBio.name );
                }

                if ( IsPokemonApplicable(pokemonBio, typeFilter) ) {
                    selectedPokemons.Add( pokemonBio );
                }

                pokemonList.results[i] = pokemonBio;

                i++;
            }

            _pokemonCache.SavePokemonList( pokemonList );

            return selectedPokemons.Select(p => p.Pokemon).Skip( offset ).Take( limit ).ToList(); ;
        }

        public async Task<Pokemon> GetPokemonByName( string name ) {
            if ( string.IsNullOrEmpty( name ) ) {
                return null;
            }

            PokemonList pokemonList = await GetPokemonList();

            if ( pokemonList == null ) {
                return null;
            }

            PokemonBio pokemonBio = pokemonList.results.FirstOrDefault( p => p.name == name.ToLowerInvariant().Trim() );

            if ( pokemonBio == null ) {
                return null;
            }

            if ( pokemonBio.Pokemon != null ) {
                return pokemonBio.Pokemon;
            }

            pokemonBio.Pokemon = await GetPokemonByNameAsync(name);

            _pokemonCache.SavePokemonList( pokemonList );

            return pokemonBio.Pokemon;
        }

        public async Task<IList<Pokemon>> GetFavoritePokemons( string userName ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return null;
            }

            IList<Pokemon> listOfFullPokemonInfo = new List<Pokemon>();

            string pokemonsNamesJson = _pokemonDbAdapter.GetFavoritePokemons( userName );
            if ( string.IsNullOrEmpty( pokemonsNamesJson ) ) {
                return null;
            }

            string[ ] pokemonsNames;

            try {
                pokemonsNames = JsonConvert.DeserializeObject<string[ ]>( pokemonsNamesJson );
            } catch ( Exception ) {
                //logger;
                return null;
            }

            Pokemon pokemon;
            foreach ( string pokemonName in pokemonsNames ) {
                pokemon = await GetPokemonByName( pokemonName );

                if ( pokemon == null ) {
                    continue;
                }

                listOfFullPokemonInfo.Add( pokemon );
            }

            return listOfFullPokemonInfo;
        }

        public void SaveFavoritePokemons( string userName, string[ ] favoritePokemons ) {
            if ( string.IsNullOrEmpty( userName ) || favoritePokemons == null || favoritePokemons.Length == 0) {
                return;
            }

            string favoritePokemonsJson = JsonConvert.SerializeObject(favoritePokemons);
            _pokemonDbAdapter.SaveFavoritePokemons(userName, favoritePokemonsJson );
        }

        public async Task<IList<Pokemon>> GetSuggestedPokemons( int limit ) {

            List<Pokemon> result = new List<Pokemon>();

            for ( int i = 0; i < limit; i++ ) {
                Pokemon pokemon = await GetRandomPokemon();

                if ( pokemon == null ) {
                    continue;
                }

                result.Add( pokemon );
            }

            return result;
        }

        private async Task<Pokemon> GetPokemonByNameAsync( string name ) {
            Pokemon pokemon;

            if ( _pokemonCache.TryGetPokemonByName( name, out pokemon ) ) {
                return pokemon;
            }

            pokemon = await _pokemonHttpClientAdapter.GetPokemonByName( name );

            if ( pokemon == null ) {
                return null;
            }

            return pokemon;
        }
        private async Task<Pokemon> GetRandomPokemon() {
            PokemonList pokemonList = await GetPokemonList();

            if ( pokemonList == null ) {
                return null;
            }

            PokemonBio pokemonBio = pokemonList.results[GetRandomNumber( 1, pokemonList.count - 1 )];
            return pokemonBio.Pokemon ?? await GetPokemonByName( pokemonBio.name );
        }

        private int GetRandomNumber( int begin, int end ) {
            return _random.Next(begin, end);
        }

        private bool IsPokemonApplicable( PokemonBio pokemonBio, string typeFilter ) {
            return pokemonBio.Pokemon.types.Any( t => ( t.type.name.Trim().ToUpper() == typeFilter.Trim().ToUpper() || typeFilter.Trim().ToUpper() == "ALL" ) );
        }

        private async Task<PokemonList> GetPokemonList() {
            PokemonList pokemonList;

            if ( !_pokemonCache.TryGetPokemonList( out pokemonList ) ) {
                pokemonList = await _pokemonHttpClientAdapter.GetPokemonList();
            }

            return pokemonList;
        }
    }
}
