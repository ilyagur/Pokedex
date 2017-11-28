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
            if ( limit < 0 || offset < 0 ) {
                return Json( "{\"error\": \"limit and offset can't be less then 0\"}" );
            }

            IList<Pokemon> listOfFullPokemonInfo = new List<Pokemon>();
            PokemonList list =  await _pokemonProvider.GetPokemonList();

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
    }
}