using Microsoft.AspNetCore.Mvc;
using Pokedex.ServerApp;
using System.Threading.Tasks;

namespace Pokedex.Controllers.Api {
    [Produces("application/json")]
    [Route("api/Pokemon")]
    public class PokemonController : Controller
    {
        private IPokemonProvider _pokemonProvider;

        public PokemonController(IPokemonProvider provider) {
            _pokemonProvider = provider;
        }

        [Route( "GetPokemons/{limit}/{offset}" )]
        public async Task<JsonResult> GetPokemons(int limit, int offset) {
            var result = Json( await _pokemonProvider.GetPokemons( limit, offset ) );
            return result;
        }
    }
}