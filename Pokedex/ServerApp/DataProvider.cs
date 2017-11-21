using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Pokedex.ServerApp.Interfaces;
using Pokedex.ServerApp.Settings;
using System.IO;
using System.Threading.Tasks;

namespace Pokedex.ServerApp {
    public class DataProvider: IDataProvider {

        private IOptions<PokemonProviderSettings> _settings;
        private IHttpClientAdapter _httpClientAdapter;
        private IMemoryCache _cache;

        public DataProvider( IHttpClientAdapter httpClientAdapter, IOptions<PokemonProviderSettings> settings, IMemoryCache cache ) {
            _httpClientAdapter = httpClientAdapter;
            _settings = settings;
            _cache = cache;
        }

        public async Task<string> GetPokemonList() {
            //TODO: все это безобразие надо переписать: вынести общий код в отдельный метод + threadSafe

            string pokemonList, cacheKey = "pokemonList";

            if ( _cache.TryGetValue<string>( cacheKey, out pokemonList ) ) {
                return pokemonList;
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "PokemonCache", $"{cacheKey}.json" );
            if ( File.Exists( filePath ) ) {
                pokemonList = File.ReadAllText(filePath);
                _cache.Set(cacheKey, pokemonList);
                return pokemonList;
            }

            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}?limit={int.MaxValue}$offset=0";

            pokemonList = await _httpClientAdapter.GetStringAsync(requestUri);

            _cache.Set( cacheKey, pokemonList );
            File.WriteAllText(filePath, pokemonList);

            return pokemonList;
        }

        public async Task<string> GetPokemonByName( string name ) {
            //грязненько кешируем всеми возможными способами
            string pokemon, cacheKey = name + "_fullInfo";

            if ( _cache.TryGetValue( cacheKey, out pokemon ) ) {
                return pokemon;
            }

            string filePath = Path.Combine( Directory.GetCurrentDirectory(), "PokemonCache", $"{cacheKey}.json" );

            if ( File.Exists( filePath ) ) {
                pokemon = File.ReadAllText( filePath );
                _cache.Set( cacheKey, pokemon );
                return pokemon;
            }

            string requestUri = $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}/{name}";

            pokemon = await _httpClientAdapter.GetStringAsync( requestUri );

            _cache.Set( cacheKey, pokemon );
            File.WriteAllText( filePath, pokemon );

            return pokemon;
        }
    }
}
