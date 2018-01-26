using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PokedexCore.Manual.Auth;

namespace PokedexCore.Manual.Helpers {
    public static class InjectedDependencies {
        public static void AddDependencies( this IServiceCollection services ) {
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
