using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
    public interface IFileCache {
        void Set( string key, string value );
        void Remove( string key );
        bool TryGetValue( string key, out string value );
    }
}
