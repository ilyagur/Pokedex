using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexCore.Models.Json {
    public class PokemonList
    {
        public int count { get; set; }
        public string previous { get; set; }
        public IList<PokemonBio> results { get; set; }
        public string next { get; set; }

    }

    public class PokemonBio {
        public string url { get; set; }
        public string name { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
