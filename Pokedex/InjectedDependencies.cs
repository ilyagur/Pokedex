using Microsoft.Extensions.DependencyInjection;
using Pokedex.ServerApp;
using Pokedex.ServerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex
{
    public static class InjectedDependencies
    {
        public static void AddDependencies( this IServiceCollection services ) {
            services.AddSingleton<IFileCache, FileCache>();
            services.AddScoped<IHttpClientAdapter, HttpClientAdapter>();
            services.AddScoped<IPokemonCache, PokemonCache>();
            services.AddScoped<IPokemonHttpClientAdapter, PokemonHttpClientAdapter>();
            services.AddScoped<IPokemonProvider, PokemonProvider>();
        }
    }
}
