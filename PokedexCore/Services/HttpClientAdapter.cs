using PokedexCore.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokedexCore.Services {
    public class HttpClientAdapter : IHttpClientAdapter {

        private readonly HttpClient _client;
        public HttpClientAdapter() {
            _client = new HttpClient();
        }
        public async Task<string> GetStringAsync( string requestUri ) {
            string result = string.Empty;

            try {
                result = await _client.GetStringAsync( requestUri );
            } catch ( Exception ) {
                //logger
                return null;
            }

            return result;
        }
    }
}
