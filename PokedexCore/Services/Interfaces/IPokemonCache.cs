using PokedexCore.Models.Json;

namespace PokedexCore.Services.Interfaces {
    public interface IPokemonCache
    {
        bool TryGetPokemonList( out PokemonList pokemonList );
        bool TryGetPokemonByName( string pokemonName, out Pokemon pokemon );
        PokemonList SavePokemonList( PokemonList pokemonList );
        Pokemon SavePokemon(Pokemon pokemon);
    }
}
