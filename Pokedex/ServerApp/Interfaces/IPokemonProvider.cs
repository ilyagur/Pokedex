using Pokedex.ServerApp.JsonModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.ServerApp {
    public interface IPokemonProvider
    {
        Task<IList<Pokemon>> GetPokemons( int limit, int offset );
    }
}
