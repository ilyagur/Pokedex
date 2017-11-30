using System.Threading.Tasks;

namespace PokedexCore.Services.Interfaces {
    public interface IHttpClientAdapter
    {
        Task<string> GetStringAsync( string requestUri );
    }
}
