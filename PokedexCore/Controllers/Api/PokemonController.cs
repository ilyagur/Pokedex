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
    [Route( "api/Pokemon" )]
    public class PokemonController : BaseApiController {
        private IPokemonProvider _pokemonProvider;

        public PokemonController( IPokemonProvider provider, UserManager<ApplicationUser> userManager )
            : base( userManager ) 
        {
            _pokemonProvider = provider;
        }

        [AllowAnonymous]
        [Route( "GetPokemons/{limit}/{offset}" )]
        public async Task<JsonResult> GetPokemons( int limit, int offset ) {
            if ( limit < 0 || offset < 0 ) {
                //logger
                return Json(null);
            }

            PokemonList list;
            try {
                list = await _pokemonProvider.GetPokemonList();
            } catch ( Exception ) {
                //logger;
                return Json(null);
            }

            if ( list == null ) {
                return Json(null);
            }

            IList<PokemonBio> selectedPokemons = list.results.Skip( offset ).Take( limit ).ToList();

            Pokemon pokemon;
            IList<Pokemon> listOfFullPokemonInfo = new List<Pokemon>();

            foreach ( PokemonBio result in selectedPokemons ) {
                try {
                    pokemon = await _pokemonProvider.GetPokemonByName( result.name );
                } catch ( Exception ) {
                    //logger
                    continue;
                }

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