using Microsoft.AspNetCore.Authorization;
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
    [Route( "api" )]
    public class PokemonController : BaseApiController {
        private IPokemonProvider _pokemonProvider;

        public PokemonController( IPokemonProvider provider, UserManager<ApplicationUser> userManager )
            : base( userManager ) 
        {
            _pokemonProvider = provider;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route( "Pokemons/{limit}/{offset}/{typeFilter?}" )]
        public async Task<JsonResult> GetPokemons( int limit = 20, int offset = 0, string typeFilter = "ALL" ) {
            if ( limit < 0 || offset < 0 ) {
                //logger
                return Json(null);
            }

            return Json( await _pokemonProvider.GetPokemons( limit, offset, typeFilter ) );
        }

        [HttpGet]
        [AllowAnonymous]
        [Route( "SuggestPokemons/{limit}" )]
        public async Task<JsonResult> GetSuggestedPokemons( int limit ) {
            if ( limit < 0 ) {
                //logger
                return Json( null );
            }

            return Json( await _pokemonProvider.GetSuggestedPokemons( limit ) );
        }

        [HttpGet]
        [AllowAnonymous]
        [Route( "Pokemon/{name}" )]
        public async Task<JsonResult> GetPokemonByName( string name ) {
            if ( string.IsNullOrEmpty( name ) ) {
                //logger;
                return Json( null );
            }

            return Json(await _pokemonProvider.GetPokemonByName( name ) );
        }

        [HttpGet]
        [Route( "FavoritePokemons/{limit}" )]
        public async Task<JsonResult> GetFavoritePokemons() {
            IList<Pokemon> listOfFullPokemonInfo = await _pokemonProvider.GetFavoritePokemons( UserName );

            return Json( listOfFullPokemonInfo );
        }

        [HttpPost]
        [Route( "FavoritePokemons" )]
        public ActionResult SaveFavoritePokemons( [FromBody] string [] pokemons ) {
            if ( pokemons == null || pokemons.Length == 0 ) {
                return NoContent();
            }

            try {
                _pokemonProvider.SaveFavoritePokemons( UserName, pokemons );
            } catch ( Exception e) {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}