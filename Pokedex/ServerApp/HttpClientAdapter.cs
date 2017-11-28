using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.ServerApp.Interfaces
{
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
