using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PokedexCore.Manual.Data;
using PokedexCore.Manual.Models;
using PokedexCore.Manual.Services.Interfaces;
using System.Linq;

namespace PokedexCore.Services {
    public class PokemonDbAdapter: IPokemonDbAdapter
    {
        private readonly ApplicationDbContext _dbContext;

        public PokemonDbAdapter(ApplicationDbContext dbContext ) {
            _dbContext = dbContext;
        }

        public string GetFavoritePokemons( string userName ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return null;
            }

            Customer customer = GetApplicationUserByUserName(userName);

            if ( customer == null ) {
                return null;
            }

            return customer.FavoritePokemons;
        }

        public void SaveFavoritePokemons( string userName, string favoritePokemonsJson ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return;
            }

            Customer customer = GetApplicationUserByUserName( userName );

            if ( customer == null ) {
                return;
            }

            _dbContext.Add(customer.FavoritePokemons = favoritePokemonsJson);
            _dbContext.SaveChanges();
        }

        private Customer GetApplicationUserByUserName( string userName ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return null;
            }

            var user = _dbContext.Users.Where( u => u.UserName == userName ).FirstOrDefault();
            if ( user == null ) {
                return null;
            }

            return _dbContext.Customers.Where( c => c.IdentityId == user.Id ).FirstOrDefault();
        }
    }
}
