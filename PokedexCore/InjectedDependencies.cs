using Microsoft.Extensions.DependencyInjection;
using PokedexCore.Services.Interfaces;
using PokedexCore.Services;

namespace PokedexCore {
    public static class InjectedDependencies
    {
        public static void AddDependencies( this IServiceCollection services ) {
            services.AddSingleton<IFileCache, FileCache>();
            services.AddSingleton<IPokemonCache, PokemonCache>();
            services.AddScoped<IPokemonDbAdapter, PokemonDbAdapter>();
            services.AddScoped<IPokemonHttpClientAdapter, PokemonHttpClientAdapter>();
            services.AddScoped<IPokemonProvider, PokemonProvider>();
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
