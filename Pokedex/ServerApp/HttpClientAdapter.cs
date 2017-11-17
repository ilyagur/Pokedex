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
        public Task<string> GetStringAsync( string requestUri ) {
            return _client.GetStringAsync( requestUri );
        }
    }
}
