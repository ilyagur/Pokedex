using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PokedexCore.Manual.Models.Json;
using PokedexCore.Manual.Models.Settings;
using PokedexCore.Manual.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class PokemonHttpClientAdapter : IPokemonHttpClientAdapter {
        private readonly IOptions<HttpClientAdapterSettings> _settings;
        private readonly HttpClient _httpClient;
        public PokemonHttpClientAdapter(IOptions<HttpClientAdapterSettings> settings ) {
            _settings = settings;
            _httpClient = new HttpClient();

            if ( string.IsNullOrEmpty( _settings.Value.PokemonByNameEndpoint ) ) {
                throw new Exception( "PokemonByNameEndpoint cannot be empty string" );
            }

            if ( string.IsNullOrEmpty( _settings.Value.PokemonListEndpoint ) ) {
                throw new Exception( "ListEndpoint cannot be empty string" );
            }
        }
        public async Task<Pokemon> GetPokemonByName( string pokemonName ) {
            if ( string.IsNullOrEmpty( pokemonName ) ) {
                return null;
            }
         
            string pokemonJson = await GetStringAsync(string.Format(_settings.Value.PokemonByNameEndpoint, pokemonName));
         
            if ( string.IsNullOrEmpty( pokemonJson ) ) {
                return null;
            }

            Pokemon pokemon = new Pokemon();

            try {
                pokemon = JsonConvert.DeserializeObject<Pokemon>( pokemonJson );
            } catch(JsonException) {
                //logger
                return null;
            }

            return pokemon;
        }

        public async Task<PokemonList> GetPokemonList() {
            //get first portion of pokemons to find out mount of them
            PokemonList pokemonList = await DownloadPokemonList(string.Format( _settings.Value.PokemonListEndpoint, 1, 0 ));

            if ( pokemonList == null || pokemonList.count <= 0 ) {
                return null;
            }

            //get whole pokemons list
            pokemonList = await DownloadPokemonList( string.Format( _settings.Value.PokemonListEndpoint, pokemonList.count, 0 ));

            if ( pokemonList == null ) {
                return null;
            }

            return pokemonList;
        }

        private async Task<PokemonList> DownloadPokemonList(string requestUri) {
            if ( string.IsNullOrEmpty( requestUri ) ) {
                return null;
            }

            string pokemonListJson = await GetStringAsync( requestUri );

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
        private async Task<string> GetStringAsync( string requestUri ) {
            if ( string.IsNullOrEmpty( requestUri ) ) {
                return null;
            }
            string result = string.Empty;

            try {
                result = await _httpClient.GetStringAsync( requestUri );
            } catch ( Exception ) {
                //logger
                return null;
            }

            return result;
        }
    }
}
