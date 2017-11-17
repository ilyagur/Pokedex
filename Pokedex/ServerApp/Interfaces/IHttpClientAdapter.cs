using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
    public interface IHttpClientAdapter
    {
        Task<string> GetStringAsync( string requestUri );
    }
}
