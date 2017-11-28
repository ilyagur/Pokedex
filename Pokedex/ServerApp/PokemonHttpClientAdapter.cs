using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pokedex.ServerApp.Interfaces;
using Pokedex.ServerApp.JsonModels;
using Pokedex.ServerApp.Settings;
using System.Threading.Tasks;

namespace Pokedex.ServerApp {
    public class PokemonHttpClientAdapter : IPokemonHttpClientAdapter {
        private readonly IHttpClientAdapter _httpClientAdapter;
        private readonly IOptions<PokemonHttpClientAdapterSettings> _settings;
        public PokemonHttpClientAdapter( IHttpClientAdapter httpClientAdapter, IOptions<PokemonHttpClientAdapterSettings> settings ) {
            _httpClientAdapter = httpClientAdapter;
            _settings = settings;
        }
        public async Task<Pokemon> GetPokemonByName( string pokemonName ) {
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}/{pokemonName}", pokemonJson = string.Empty;
            Pokemon pokemon = new Pokemon();
         
            pokemonJson = await _httpClientAdapter.GetStringAsync( requestUri );
         
            if ( string.IsNullOrEmpty( pokemonJson ) ) {
                return null;
            }

            try {
                pokemon = JsonConvert.DeserializeObject<Pokemon>( pokemonJson );
            } catch(JsonException) {
                //logger
                return null;
            }

            return pokemon;
        }

        public async Task<PokemonList> GetPokemonList() {
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}{_settings.Value.PokemonListOptions}";
            PokemonList pokemonList;

            //get first portion of pokemons to find out mount of them
            string requestUriForFirstPortion = string.Format( requestUri, 1, 0);

            pokemonList = await DownloadPokemonList( requestUriForFirstPortion );

            if ( pokemonList == null ) {
                return null;
            }

            //get whole pokemons list
            string requestUriForAllPokemons = string.Format( requestUri, pokemonList.count, 0 );

            pokemonList = await DownloadPokemonList(requestUriForAllPokemons);

            if ( pokemonList == null ) {
                return null;
            }

            return pokemonList;
        }

        private async Task<PokemonList> DownloadPokemonList(string requestUri) {
            string pokemonListJson = await _httpClientAdapter.GetStringAsync( requestUri );

            if ( string.IsNullOrEmpty( pokemonListJson ) ) {
                return null;
            }

            PokemonList pokemonList;
            try {
                pokemonList = JsonConvert.DeserializeObject<PokemonList>( pokemonListJson );
            } catch ( JsonException ) {
                //logger
                return null;
            }

            return pokemonList;
        }
    }
}
