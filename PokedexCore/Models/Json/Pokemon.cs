using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexCore.Models.Json
{
    public class Pokemon
    {
        public string name { get; set; }
        public int weight { get; set; }
        public Sprites sprites { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public IList<Slot> types { get; set; }
       
    }

    public class Sprites {
        public string front_default { get; set; }
    }

    public class Slot {
        public int slot { get; set; }
        public Type type { get; set; }
    }

    public class Type {
        public string url { get; set; }
        public string name { get; set; }
    }
}
