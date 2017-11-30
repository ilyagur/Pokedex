using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PokedexCore.Models.Json;
using PokedexCore.Models.Settings;
using PokedexCore.Services.Interfaces;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class PokemonHttpClientAdapter : IPokemonHttpClientAdapter {
        private readonly IHttpClientAdapter _httpClientAdapter;
        private readonly IOptions<HttpClientAdapterSettings> _settings;
        public PokemonHttpClientAdapter( IHttpClientAdapter httpClientAdapter, IOptions<HttpClientAdapterSettings> settings ) {
            _httpClientAdapter = httpClientAdapter;
            _settings = settings;
        }
        public async Task<Pokemon> GetPokemonByName( string pokemonName ) {
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.ListEndpoint}/{pokemonName}", pokemonJson = string.Empty;
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
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.ListEndpoint}{_settings.Value.ListOptions}";
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
