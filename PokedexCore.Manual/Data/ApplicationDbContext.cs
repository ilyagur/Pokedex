using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokedexCore.Manual.Models;

namespace PokedexCore.Manual.Data {
    public class ApplicationDbContext: IdentityDbContext {
        public ApplicationDbContext( DbContextOptions options )
        : base( options ) {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
