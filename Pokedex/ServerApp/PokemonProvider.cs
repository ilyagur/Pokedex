using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pokedex.ServerApp.Interfaces;
using Pokedex.ServerApp.JsonModels;
using Pokedex.ServerApp.Settings;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.ServerApp
{
    public class PokemonProvider : IPokemonProvider {

        private IDataProvider _dataProvider;
        public PokemonProvider( IDataProvider dataProvider) {
            _dataProvider = dataProvider;
        }

        public async Task<IList<Pokemon>> GetPokemons( int limit, int offset ) {
            IList<Pokemon> pokemonList = new List<Pokemon>();
            PokemonList list = JsonConvert.DeserializeObject<PokemonList>( await _dataProvider.GetPokemonList() );

            IList<PokemonBio> selectedPokemons = list.results.Skip( offset ).Take( limit ).ToList();

            foreach ( PokemonBio result in selectedPokemons ) {
                pokemonList.Add( JsonConvert.DeserializeObject<Pokemon>( await _dataProvider.GetPokemonByName( result.name ) ) );
            }

            return pokemonList;
        }
    }
}
