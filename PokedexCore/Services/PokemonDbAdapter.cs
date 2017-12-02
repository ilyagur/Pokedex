using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PokedexCore.Data;
using PokedexCore.Models;
using PokedexCore.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;

namespace PokedexCore.Services {
    public class PokemonDbAdapter: IPokemonDbAdapter
    {
        private IdentityDbContext _identityDbContext;
        private PokemonDbContext _pokemonDbContext;

        public PokemonDbAdapter( IdentityDbContext identityDbContext, PokemonDbContext pokemonDbContext) {
            _identityDbContext = identityDbContext;
            _pokemonDbContext = pokemonDbContext;
        }

        public string GetFavoritePokemons( string userName ) {
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
            ApplicationUser appUser = GetApplicationUserByUserName( userName );

            if ( appUser == null ) {
                throw new Exception($"No user found for {userName}"); 
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
