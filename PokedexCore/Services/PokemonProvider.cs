using PokedexCore.Models.Json;
using PokedexCore.Services.Interfaces;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class PokemonProvider : IPokemonProvider {

        private readonly IPokemonHttpClientAdapter _pokemonHttpClientAdapter;
        private readonly IPokemonCache _pokemonCache;

        public PokemonProvider( IPokemonHttpClientAdapter pokemonHttpClientAdapter, IPokemonCache pokemonCache ) {
            _pokemonHttpClientAdapter = pokemonHttpClientAdapter;
            _pokemonCache = pokemonCache;
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

            _pokemonCache.SavePokemon(pokemon);

            return pokemon;
        }
    }
}
