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

        public async Task<string> GetPokemons( int limit, int offset ) {
            IList<Pokemon> pokemonList = new List<Pokemon>();
            PokemonList list = JsonConvert.DeserializeObject<PokemonList>( await _dataProvider.GetPokemonList( limit, offset ) );

            foreach ( PokemonBio result in list.results ) {
                pokemonList.Add( JsonConvert.DeserializeObject<Pokemon>( await _dataProvider.GetPokemonByName( result.name ) ) );
            }

            return null;
        }

        //public async Task<Pokemon> GetPokemonList( int limit, int offset ) {
        //    IList<Pokemon> resultList = new List<Pokemon>();

        //    string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}?limit={limit}$offset={offset}";

        //    string resultString; 
            
        //    if ( !_cache.TryGetValue( requestUri, out resultString ) ) {
        //        resultString = await _httpClientAdapter.GetStringAsync( requestUri );
        //        _cache.Set( requestUri, resultString );
        //    }

        //    PokemonList list = JsonConvert.DeserializeObject<PokemonList>(resultString);

        //    foreach ( var result in list.results ) {
        //        resultList.Add();
        //    }

        //    return resultString;
        //}
        //private void CachePokemonList() {
        //    ExpandoObject pokemonList = _cachProvider.GetPokemonList();

        //    if ( pokemonList == null ) {
        //        ExpandoObject downloadedPokemonList = _onlineProvider.DownloadPokemonList();
        //    }

        //}
    }
}
