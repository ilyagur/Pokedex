using PokedexCore.Models.Json;
using System.Threading.Tasks;

namespace PokedexCore.Services.Interfaces {
    public interface IPokemonProvider
    {
        Task<PokemonList> GetPokemonList();
        Task<Pokemon> GetPokemonByName( string name );
    }
}
