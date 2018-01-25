using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexCore.Manual.Models
{
    public class Customer {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; } 
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
        public string FavoritePokemons { get; set; }
    }
}
