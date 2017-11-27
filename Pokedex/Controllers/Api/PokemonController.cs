using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pokedex.ServerApp;
using Pokedex.ServerApp.JsonModels;
using System.Collections.Generic;
using System.Linq;
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
            IList<Pokemon> pokemonList = new List<Pokemon>();
            PokemonList list =  await _pokemonProvider.GetPokemonList();

            IList<PokemonBio> selectedPokemons = list.results.Skip( offset ).Take( limit ).ToList();

            foreach ( PokemonBio result in selectedPokemons ) {
                pokemonList.Add( await _pokemonProvider.GetPokemonByName( result.name ));
            }

            return Json( pokemonList );
        }
    }
}