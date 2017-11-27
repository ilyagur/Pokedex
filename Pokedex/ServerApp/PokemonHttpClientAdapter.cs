using Pokedex.ServerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.ServerApp.JsonModels;
using Microsoft.Extensions.Options;
using Pokedex.ServerApp.Settings;
using Newtonsoft.Json;

namespace Pokedex.ServerApp
{
    public class PokemonHttpClientAdapter : IPokemonHttpClientAdapter {
        private readonly IHttpClientAdapter _httpClientAdapter;
        private readonly IOptions<PokemonHttpClientAdapterSettings> _settings;
        public PokemonHttpClientAdapter( IHttpClientAdapter httpClientAdapter, IOptions<PokemonHttpClientAdapterSettings> settings ) {
            _httpClientAdapter = httpClientAdapter;
            _settings = settings;
        }
        public async Task<Pokemon> GetPokemonByName( string pokemonName ) {
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}/{pokemonName}";

            string pokemonJson = await _httpClientAdapter.GetStringAsync( requestUri );

            return JsonConvert.DeserializeObject<Pokemon>( pokemonJson );
        }

        public async Task<PokemonList> GetPokemonList() {
            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}";

            //TODO: совсем не самое красивое решение, тут бы строку из appsettings с плейсхолдерами
            string requestUriForFirst20Pokemons = requestUri + "?limit=20$offset=0";

            string pokemonListJson = await _httpClientAdapter.GetStringAsync( requestUriForFirst20Pokemons );

            PokemonList pokemonList = JsonConvert.DeserializeObject<PokemonList>(pokemonListJson);

            string requestUriForAllPokemons = requestUri + $"?limit={pokemonList.count}$offset=0";

            pokemonListJson = await _httpClientAdapter.GetStringAsync( requestUriForAllPokemons );

            return JsonConvert.DeserializeObject<PokemonList>( pokemonListJson );
        }
    }
}
