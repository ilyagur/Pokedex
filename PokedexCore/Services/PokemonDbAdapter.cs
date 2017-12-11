using PokedexCore.Data;
using PokedexCore.Models;
using PokedexCore.Services.Interfaces;
using System;
using System.Linq;

namespace PokedexCore.Services {
    public class PokemonDbAdapter: IPokemonDbAdapter
    {
        private readonly IdentityDbContext _identityDbContext;
        private readonly PokemonDbContext _pokemonDbContext;

        public PokemonDbAdapter( IdentityDbContext identityDbContext, PokemonDbContext pokemonDbContext) {
            _identityDbContext = identityDbContext;
            _pokemonDbContext = pokemonDbContext;
        }

        public string GetFavoritePokemons( string userName ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return null;
            }

            ApplicationUser appUser = GetApplicationUserByUserName(userName);

            if ( appUser == null ) {
                return null;
            }

            FavoritePokemons favoritePokemons = _pokemonDbContext.FavoritePokemons.FirstOrDefault( p => p.AspNetUserId == appUser.Id );
            if ( favoritePokemons == null ) {
                return null;
            }

            return favoritePokemons.SelectedPokemons;
        }

        public void SaveFavoritePokemons( string userName, string favoritePokemonsJson ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return;
            }

            ApplicationUser appUser = GetApplicationUserByUserName( userName );

            if ( appUser == null ) {
                return;
            }

            _pokemonDbContext.Add(new FavoritePokemons() { AspNetUserId = appUser.Id, SelectedPokemons = favoritePokemonsJson } );
            _pokemonDbContext.SaveChanges();
        }

        private ApplicationUser GetApplicationUserByUserName( string userName ) {
            if ( string.IsNullOrEmpty( userName ) ) {
                return null;
            }

            return _identityDbContext.Users.FirstOrDefault( u => u.UserName == userName );
        }
    }
}
