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

        public Task<string> GetPokemonList( int limit, int offset ) {
            return Task.Run( () => File.ReadAllText( Directory.GetCurrentDirectory() + "/PokemonCache/pokemonList.json" ) );
            //return GetStringAsync( $"{_settings.Value.BaseApiUrl}/{_settings.Value.PokemonListEndpoint}?limit={limit}$offset={offset}" );
        }

        public async Task<string> GetPokemonByName( string name ) {
            //грязненько кешируем всеми возможными способами
            string pokemon;
            string cacheKey = name + "_fullInfo";

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

        private async Task<string> GetStringAsync( string requestUri ) {
            string resultString;

            if ( !_cache.TryGetValue( requestUri, out resultString ) ) {
                resultString = await _httpClientAdapter.GetStringAsync( requestUri );
                _cache.Set( requestUri, resultString );
            }

            return resultString;
        }
    }
}
