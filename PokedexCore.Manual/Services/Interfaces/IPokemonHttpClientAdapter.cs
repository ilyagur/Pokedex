using PokedexCore.Manual.Models.Json;
using System.Threading.Tasks;

namespace PokedexCore.Manual.Services.Interfaces {
    public interface IPokemonHttpClientAdapter
    {
        Task<PokemonList> GetPokemonList();

        Task<Pokemon> GetPokemonByName(string pokemonName);
    }
}
