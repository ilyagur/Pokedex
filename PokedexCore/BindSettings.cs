using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokedexCore.Models.Settings;

namespace PokedexCore {
    public static class BindSettings
    {
        public static void AddAppSettings( this IServiceCollection services, IConfiguration configuration ) {
            services.Configure<HttpClientAdapterSettings>( configuration.GetSection( "HttpClientAdapterSettings" ) );
            services.Configure<CacheSettings>( configuration.GetSection( "CacheSettings" ) );
        }
    }
}
