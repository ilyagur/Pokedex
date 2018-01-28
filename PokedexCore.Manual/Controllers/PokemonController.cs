using Microsoft.AspNetCore.Mvc;
using PokedexCore.Manual.Services.Interfaces;
using System.Threading.Tasks;

namespace PokedexCore.Manual.Controllers {
    [Produces( "application/json" )]
    [Route( "api" )]
    public class PokemonController : Controller
    {
        private IPokemonProvider _pokemonProvider;
        public PokemonController( IPokemonProvider provider ) {
            _pokemonProvider = provider;
        }

        [HttpGet]
        [Route( "Pokemons/Count" )]
        public int DownloadedPokemonCount() {
            return _pokemonProvider.DownloadedPokemonCount();
        }

        [HttpGet]
        [Route( "Pokemons/{limit}/{offset}/{typeFilter?}" )]
        public async Task<JsonResult> GetPokemons( int limit = 20, int offset = 0, string typeFilter = "ALL" ) {
            if ( limit < 0 || offset < 0 ) {
                //logger
                return Json( null );
            }

            return Json( await _pokemonProvider.GetPokemons( limit, offset, typeFilter ) );
        }

        [HttpGet]
        [Route( "SuggestPokemons/{limit}" )]
        public async Task<JsonResult> GetSuggestedPokemons( int limit ) {
            if ( limit < 0 ) {
                //logger
                return Json( null );
            }

            return Json( await _pokemonProvider.GetSuggestedPokemons( limit ) );
        }

        [HttpGet]
        [Route( "Pokemon/{name}" )]
        public async Task<JsonResult> GetPokemonByName( string name ) {
            if ( string.IsNullOrEmpty( name ) ) {
                //logger;
                return Json( null );
            }

            return Json( await _pokemonProvider.GetPokemonByName( name ) );
        }

        //[HttpGet]
        //[Route( "FavoritePokemons/{limit}" )]
        //public async Task<JsonResult> GetFavoritePokemons() {
        //    IList<Pokemon> listOfFullPokemonInfo = await _pokemonProvider.GetFavoritePokemons( UserName );

        //    return Json( listOfFullPokemonInfo );
        //}

        //[HttpPost]
        //[Route( "FavoritePokemons" )]
        //public ActionResult SaveFavoritePokemons( [FromBody] string[ ] pokemons ) {
        //    if ( pokemons == null || pokemons.Length == 0 ) {
        //        return NoContent();
        //    }

        //    try {
        //        _pokemonProvider.SaveFavoritePokemons( UserName, pokemons );
        //    } catch ( Exception e ) {
        //        return BadRequest( e.Message );
        //    }

        //    return Ok();
        //}
    }
}