using Microsoft.Extensions.Options;
using Pokedex.ServerApp.Interfaces;
using Pokedex.ServerApp.Settings;
using System;
using System.IO;

namespace Pokedex.ServerApp {
    public class FileCache : IFileCache {
        private readonly IOptions<PokemonCacheSettings> _settings;
        private readonly string _cacheFolderPath;
        public FileCache( IOptions<PokemonCacheSettings> settings ) {
            _settings = settings;

            _cacheFolderPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.Value.PokemonCacheFolder);
        }

        public void Remove( string key ) {
            throw new NotImplementedException();
        }

        public void Set( string key, string value ) {
            string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );
            File.WriteAllText( filePath, value);
        }

        public bool TryGetValue( string key, out string value ) {
            value = string.Empty;

            string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );

            if ( !File.Exists( filePath ) ) {
                return false;
            }

            value = File.ReadAllText(filePath);

            return true;
        }
    }
}
