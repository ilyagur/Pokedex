using Pokedex.ServerApp.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
    public interface IPokemonHttpClientAdapter
    {
        Task<PokemonList> GetPokemonList();

        Task<Pokemon> GetPokemonByName(string pokemonName);
    }
}
