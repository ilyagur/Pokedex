using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
    public interface IDataProvider
    {
        Task<string> GetPokemonList( int limit, int offset );
        Task<string> GetPokemonByName( string name );
    }
}
