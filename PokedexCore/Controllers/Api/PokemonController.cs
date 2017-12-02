﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexCore.Models;
using PokedexCore.Models.Json;
using PokedexCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexCore.Controllers.Api {
    [Authorize]
    [Produces( "application/json" )]
    [Route( "api/Pokemon" )]
    public class PokemonController : Controller {
        private IPokemonProvider _pokemonProvider;
        private UserManager<ApplicationUser> _userManager;

        private string UserName {
            get {
                return _userManager.GetUserName( HttpContext.User );
            }
        }

        public PokemonController( IPokemonProvider provider, UserManager<ApplicationUser> userManager ) {
            _pokemonProvider = provider;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route( "GetPokemons/{limit}/{offset}" )]
        public async Task<JsonResult> GetPokemons( int limit, int offset ) {
            if ( limit < 0 || offset < 0 ) {
                return Json( "{\"error\": \"limit and offset can't be less then 0\"}" );
            }

            IList<Pokemon> listOfFullPokemonInfo = new List<Pokemon>();
            PokemonList list = await _pokemonProvider.GetPokemonList();

            if ( listOfFullPokemonInfo == null ) {
                return Json( "{\"error\": \"can't get list of pokemons\"}" ); ;
            }

            IList<PokemonBio> selectedPokemons = list.results.Skip( offset ).Take( limit ).ToList();

            Pokemon pokemon;
            foreach ( PokemonBio result in selectedPokemons ) {
                pokemon = await _pokemonProvider.GetPokemonByName( result.name );

                if ( pokemon == null ) {
                    continue;
                }

                listOfFullPokemonInfo.Add( pokemon );
            }

            return Json( listOfFullPokemonInfo );
        }

        [Route( "GetFavoritePokemons" )]
        public async Task<JsonResult> GetFavoritePokemons() {
            IList<Pokemon> listOfFullPokemonInfo = await _pokemonProvider.GetFavoritePokemons( UserName );

            return Json( listOfFullPokemonInfo );
        }

        [HttpPost]
        [AllowAnonymous]
        [Route( "SaveFavoritePokemons" )]
        public ActionResult SaveFavoritePokemons( [FromBody] string [] pokemons ) {
            if ( pokemons == null || pokemons.Length == 0 ) {
                return NoContent();
            }

            try {
                _pokemonProvider.SaveFavoritePokemons( UserName, pokemons );
            } catch ( Exception e) {
                return BadRequest(e.Message);
            }

            return Ok(); ;
        }
    }
}