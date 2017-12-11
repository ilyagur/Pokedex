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
        private readonly Dictionary<string, ReaderWriterLockSlim> _fileLockCollection = new Dictionary<string, ReaderWriterLockSlim>();
        private readonly ReaderWriterLockSlim _fileLockCollectionLock = new ReaderWriterLockSlim();
        public FileCache( IOptions<CacheSettings> settings ) {
            _settings = settings;

            if ( _settings == null || _settings.Value == null ) {
                throw new Exception( "AppSetting object is null" );
            }

            if ( string.IsNullOrEmpty( _settings.Value.CacheFolder ) ) {
                throw new Exception( "PokemonCacheFolder cannot be an empty string" );
            }

            _cacheFolderPath = Path.Combine(Directory.GetCurrentDirectory(), _settings.Value.CacheFolder);
        }

        public string Set( string key, string value ) {

            if ( string.IsNullOrEmpty( key ) || string.IsNullOrEmpty( value ) ) {
                return null;
            }

            ReaderWriterLockSlim lockSlim = GetLockSlim(key);

            lockSlim.EnterWriteLock();

            try {
                File.WriteAllText( Path.Combine( _cacheFolderPath, $"{key}.json" ), value );
                return value;
            } catch ( Exception ) {
                //logger
            } finally {
                lockSlim.ExitWriteLock();
            }

            return null;
        }

        public bool TryGetValue( string key, out string value ) {
            value = string.Empty;

            if ( string.IsNullOrEmpty( key ) ) {
                return false;
            }

            ReaderWriterLockSlim lockSlim = GetLockSlim(key);

            lockSlim.EnterReadLock();

            try {
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
            _fileLockCollectionLock.EnterUpgradeableReadLock();

            try {
                if ( _fileLockCollection.ContainsKey( key ) ) {
                    return _fileLockCollection[key];
                }

                _fileLockCollectionLock.EnterWriteLock();
                try {
                    ReaderWriterLockSlim fileLock = new ReaderWriterLockSlim();
                    _fileLockCollection.Add(key, fileLock);
                    return fileLock;
                } finally {
                    _fileLockCollectionLock.ExitWriteLock();
                }
                
            } finally {
                _fileLockCollectionLock.ExitUpgradeableReadLock();
            }
        }

        ~FileCache() {
            foreach ( KeyValuePair<string, ReaderWriterLockSlim> kvPair in _fileLockCollection ) {
                if ( kvPair.Value != null ) {
                    kvPair.Value.Dispose();
                }
            }
        }
    }
}
