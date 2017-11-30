using PokedexCore.Models.Json;
using System.Threading.Tasks;

namespace PokedexCore.Services.Interfaces {
    public interface IPokemonHttpClientAdapter
    {
        Task<PokemonList> GetPokemonList();

        Task<Pokemon> GetPokemonByName(string pokemonName);
    }
}
