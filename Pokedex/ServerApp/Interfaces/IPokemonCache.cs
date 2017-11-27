using Pokedex.ServerApp.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
    public interface IPokemonCache
    {
        bool TryGetPokemonList( out PokemonList pokemonList );
        bool TryGetPokemonByName( string pokemonName, out Pokemon pokemon );
        void SavePokemonList( PokemonList pokemonList );
        void SavePokemon(Pokemon pokemon);
    }
}
