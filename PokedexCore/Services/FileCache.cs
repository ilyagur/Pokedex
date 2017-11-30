using Microsoft.Extensions.Options;
using PokedexCore.Models.Settings;
using PokedexCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PokedexCore.Services {
    public class FileCache : IFileCache {
        private readonly IOptions<CacheSettings> _settings;
        private readonly string _cacheFolderPath;
        private Dictionary<string, ReaderWriterLockSlim> _lockSlimCollection = new Dictionary<string, ReaderWriterLockSlim>();
        public FileCache( IOptions<CacheSettings> settings ) {
            _settings = settings;

            if ( string.IsNullOrEmpty( _settings.Value.CacheFolder ) ) {
                throw new Exception( "Cache folder cannot be null or empty. Check PokemonCacheFolder." );
            }

            _cacheFolderPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.Value.CacheFolder);
        }

        public void Set( string key, string value ) {

            ReaderWriterLockSlim lockSlim = GetLockSlim(key);

            lockSlim.EnterWriteLock();

            try {
                if ( String.IsNullOrEmpty( key ) ) {
                    return;
                }

                string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );

                File.WriteAllText( filePath, value );
            } catch ( Exception ) {
                //logger
            } finally {
                lockSlim.ExitWriteLock();
            }
        }

        public bool TryGetValue( string key, out string value ) {
            value = string.Empty;

            ReaderWriterLockSlim lockSlim = GetLockSlim(key);

            lockSlim.EnterReadLock();

            try {
                if ( String.IsNullOrEmpty( key ) ) {
                    return false;
                }

                string filePath = Path.Combine( _cacheFolderPath, $"{key}.json" );

                if ( !File.Exists( filePath ) ) {
                    return false;
                }

                value = File.ReadAllText( filePath );
            } catch ( Exception ) {
                //logger
            } finally {
                lockSlim.ExitReadLock();
            }

            return true;
        }

        private ReaderWriterLockSlim GetLockSlim( string key ) {
            if ( _lockSlimCollection.ContainsKey( key ) ) {
                return _lockSlimCollection[key];
            }

            ReaderWriterLockSlim lockSlim  = new ReaderWriterLockSlim();
            _lockSlimCollection.Add(key, lockSlim);

            return lockSlim;
        }

        ~FileCache() {
            foreach ( KeyValuePair<string, ReaderWriterLockSlim> kvPair in _lockSlimCollection ) {
                if ( kvPair.Value != null ) {
                    kvPair.Value.Dispose();
                }
            }
        }
    }
}
