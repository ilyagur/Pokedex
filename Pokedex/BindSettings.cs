using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.ServerApp.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex
{
    public static class BindSettings
    {
        public static void AddAppSettings(this IServiceCollection services, IConfigurationRoot configuration) {
            services.Configure<PokemonProviderSettings>( configuration.GetSection( "PokemonProviderSettings" ) );
        }
    }
}
