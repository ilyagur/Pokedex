using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp
{
    public interface IPokemonProvider
    {
        Task<string> GetPokemons( int limit, int offset );
    }
}
