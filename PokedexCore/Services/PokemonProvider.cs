using Newtonsoft.Json;
using PokedexCore.Models.Json;
using PokedexCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class PokemonProvider : IPokemonProvider {

        private IPokemonHttpClientAdapter _pokemonHttpClientAdapter;
        private IPokemonCache _pokemonCache;
        private IPokemonDbAdapter _pokemonDbAdapter;

        public PokemonProvider( IPokemonHttpClientAdapter pokemonHttpClientAdapter, IPokemonCache pokemonCache, IPokemonDbAdapter pokemonDbAdapter ) {
            _pokemonHttpClientAdapter = pokemonHttpClientAdapter;
            _pokemonCache = pokemonCache;
            _pokemonDbAdapter = pokemonDbAdapter;
        }

        public async Task<PokemonList> GetPokemonList() {
            PokemonList pokemonList;

            if ( _pokemonCache.TryGetPokemonList( out pokemonList ) ) {
                return pokemonList;
            }

            pokemonList = await _pokemonHttpClientAdapter.GetPokemonList();

            if ( pokemonList == null ) {
                return null;
            }

            _pokemonCache.SavePokemonList( pokemonList );

            return pokemonList;
        }

        public async Task<Pokemon> GetPokemonByName( string name ) {
            Pokemon pokemon;

            if ( _pokemonCache.TryGetPokemonByName( name, out pokemon ) ) {
                return pokemon;
            }

            pokemon = await _pokemonHttpClientAdapter.GetPokemonByName(name);

            if ( pokemon == null ) {
                return null;
            }

            _pokemonCache.SavePokemon(pokemon);

            return pokemon;
        }

        public async Task<IList<Pokemon>> GetFavoritePokemons( string UserName ) {
            IList<Pokemon> listOfFullPokemonInfo = new List<Pokemon>();

            string pokemonsNamesJson = _pokemonDbAdapter.GetFavoritePokemons( UserName );
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

            if ( favoritePokemons.Length == 0 ) {
                return;
            }

            string favoritePokemonsJson = JsonConvert.SerializeObject(favoritePokemons);
            _pokemonDbAdapter.SaveFavoritePokemons(userName, favoritePokemonsJson );
        }
    }
}
