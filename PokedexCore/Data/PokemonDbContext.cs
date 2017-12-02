using Microsoft.EntityFrameworkCore;
using PokedexCore.Models;

namespace PokedexCore.Data {
    public class PokemonDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<FavoritePokemons> FavoritePokemons { get; set; }

        public PokemonDbContext( DbContextOptions<PokemonDbContext> opt ): base(opt) {
        }

        protected override void OnModelCreating( ModelBuilder builder ) {
            base.OnModelCreating( builder );
        }
    }
}
