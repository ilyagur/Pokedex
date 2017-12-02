using Moq;
using PokedexCore.Services.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace PokedexCore.Tests.UnitTests {
    public class PokemonProvider {
        [Fact]
        public async Task GetFavoritePokemons_Invalid_Input() {
            var pokemonHttpClientAdapterMock = new Mock<IPokemonHttpClientAdapter>();
            var pokemonCacheMock = new Mock<IPokemonCache>();
            var pokemonDbAdapterMock = new Mock<IPokemonDbAdapter>();

            var pokemonProvider = new PokedexCore.Services.PokemonProvider( pokemonHttpClientAdapterMock.Object, pokemonCacheMock.Object, pokemonDbAdapterMock.Object );

            var result = await pokemonProvider.GetFavoritePokemons( null );

            Assert.Null( result );
        }
    }
}
