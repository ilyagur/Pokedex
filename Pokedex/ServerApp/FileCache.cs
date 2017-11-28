using Microsoft.Extensions.Options;
using Pokedex.ServerApp.Interfaces;
using Pokedex.ServerApp.Settings;
using System;
using System.IO;
using System.Threading;

namespace Pokedex.ServerApp {
    public class FileCache : IFileCache {
        private readonly IOptions<PokemonCacheSettings> _settings;
        private readonly string _cacheFolderPath;
        private ReaderWriterLockSlim _lockSlim = new ReaderWriterLockSlim();
        public FileCache( IOptions<PokemonCacheSettings> settings ) {
            _settings = settings;

            if ( string.IsNullOrEmpty( _settings.Value.PokemonCacheFolder ) ) {
                throw new Exception( "Cache folder cannot be null or empty. Check PokemonCacheFolder." );
            }

            _cacheFolderPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.Value.PokemonCacheFolder);
        }

        public void Set( string key, string value ) {

            if ( String.IsNullOrEmpty( key ) ) {
                return;
            }

            string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );

            _lockSlim.EnterWriteLock();
            try {
                File.WriteAllText( filePath, value );
            } catch ( Exception ) {
                //logger
            } finally {
                _lockSlim.ExitWriteLock();
            }
        }

        public bool TryGetValue( string key, out string value ) {
            value = string.Empty;

            if ( String.IsNullOrEmpty( key ) ) {
                return false;
            }

            string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );

            if ( !File.Exists( filePath ) ) {
                return false;
            }

            _lockSlim.EnterReadLock();
            try {
                value = File.ReadAllText( filePath );
            } catch ( Exception ) {
                //logger
            } finally {
                _lockSlim.ExitReadLock();
            }

            return true;
        }
    }
}
