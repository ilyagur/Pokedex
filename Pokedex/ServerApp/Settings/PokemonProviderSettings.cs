using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Settings
{
    public class PokemonProviderSettings
    {
        public string BaseApiUrl { get; set; }
        public string PokemonListEndpoint { get; set; }
    }
}
