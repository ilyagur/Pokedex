using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PokedexCore.Manual.Auth;
using PokedexCore.Manual.Services;
using PokedexCore.Manual.Services.Interfaces;
using PokedexCore.Services;

namespace PokedexCore.Manual.Helpers {
    public static class InjectedDependencies {
        public static void AddDependencies( this IServiceCollection services ) {
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IFileCache, FileCache>();
            services.AddSingleton<IPokemonCache, PokemonCache>();
            services.AddScoped<IPokemonDbAdapter, PokemonDbAdapter>();
            services.AddScoped<IPokemonHttpClientAdapter, PokemonHttpClientAdapter>();
            services.AddScoped<IPokemonProvider, PokemonProvider>();
        }
    }
}
