using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PokedexCore.Models.Json;
using PokedexCore.Models.Settings;
using PokedexCore.Services.Interfaces;
using System;

namespace PokedexCore.Services {
    public class PokemonCache : IPokemonCache {
        private readonly IMemoryCache _memoryCache;
        private readonly IFileCache _fileCache;
        private readonly string _pokemonListCacheKey;
        public PokemonCache( IMemoryCache memoryCache, IFileCache fileCache, IOptions<CacheSettings> settings ) {
            _memoryCache = memoryCache;
            _fileCache = fileCache;

            _pokemonListCacheKey = settings.Value.ListCacheKey;

            if ( string.IsNullOrEmpty( _pokemonListCacheKey ) ) {
                throw new Exception( "Cache key cannot be null or empty. Check PokemonListCacheKey." );
            }
        }
        public void SavePokemon( Pokemon pokemon ) {
            if ( pokemon == null || string.IsNullOrEmpty(pokemon.name)) {
                return;
            }

            _memoryCache.Set( pokemon.name, pokemon );

            string pokemonJson;
            try {
                pokemonJson = JsonConvert.SerializeObject( pokemon );
            } catch ( Exception ) {
                //logger;
                return;
            }


            _fileCache.Set( pokemon.name, pokemonJson );
        }

        public void SavePokemonList( PokemonList pokemonList ) {
            if ( pokemonList == null ) {
                return;
            }

            _memoryCache.Set( _pokemonListCacheKey, pokemonList );

            string pokemonListJson;
            try {
                pokemonListJson = JsonConvert.SerializeObject( pokemonList );
            } catch ( JsonException ) {
                //logger
                return;
            }

            _fileCache.Set(_pokemonListCacheKey, pokemonListJson);
        }

        public bool TryGetPokemonByName( string pokemonName, out Pokemon pokemon ) {
            if ( _memoryCache.TryGetValue( pokemonName, out pokemon ) ) {
                return true;
            }

            string pokemonJson;
            if ( _fileCache.TryGetValue( pokemonName, out pokemonJson ) ) {

                if ( string.IsNullOrEmpty( pokemonJson ) ) {
                    return false;
                }

                try {
                    pokemon = JsonConvert.DeserializeObject<Pokemon>( pokemonJson );
                } catch ( JsonException ) {
                    return false;
                }

                _memoryCache.Set(pokemonName, pokemon);

                return true;
            }

            return false;
        }

        public bool TryGetPokemonList( out PokemonList pokemonList ) {
            if ( _memoryCache.TryGetValue( _pokemonListCacheKey, out pokemonList ) ) {
                return true; 
            }

            string pokemonListJson;
            if ( _fileCache.TryGetValue( _pokemonListCacheKey, out pokemonListJson ) ) {
                if ( string.IsNullOrEmpty( pokemonListJson ) ) {
                    return false;
                }

                try {
                    pokemonList = JsonConvert.DeserializeObject<PokemonList>( pokemonListJson );
                } catch ( JsonException ) {
                    return false;
                }

                _memoryCache.Set(_pokemonListCacheKey, pokemonList);

                return true;
            }

            return false;
        }
    }
}
