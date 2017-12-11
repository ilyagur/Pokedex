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
        private readonly IOptions<CacheSettings> _settings;
        public PokemonCache( IMemoryCache memoryCache, IFileCache fileCache, IOptions<CacheSettings> settings ) {
            _memoryCache = memoryCache;
            _fileCache = fileCache;
            _settings = settings;

            if ( string.IsNullOrEmpty( _settings.Value.ListCacheKey ) ) {
                throw new Exception( "ListCacheKey cannot be empty string." );
            }
        }
        public Pokemon SavePokemon( Pokemon pokemon ) {
            if ( pokemon == null || string.IsNullOrEmpty(pokemon.name) || _fileCache == null || _memoryCache == null ) {
                return null;
            }

            _memoryCache.Set( pokemon.name, pokemon );
            _fileCache.Set( pokemon.name, JsonConvert.SerializeObject( pokemon ));

            return pokemon;
        }

        public PokemonList SavePokemonList( PokemonList pokemonList ) {
            if ( pokemonList == null || string.IsNullOrEmpty( _settings.Value.ListCacheKey ) ) {
                return null;
            }

            _memoryCache.Set( _settings.Value.ListCacheKey, pokemonList );
            _fileCache.Set( _settings.Value.ListCacheKey, JsonConvert.SerializeObject( pokemonList ));

            return pokemonList;
        }

        public bool TryGetPokemonByName( string pokemonName, out Pokemon pokemon ) {

            if ( string.IsNullOrEmpty( pokemonName ) ) {
                pokemon = null;
                return false;
            }

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
            if ( _memoryCache.TryGetValue( _settings.Value.ListCacheKey, out pokemonList ) ) {
                return true; 
            }

            string pokemonListJson;
            if ( _fileCache.TryGetValue( _settings.Value.ListCacheKey, out pokemonListJson ) ) {
                if ( string.IsNullOrEmpty( pokemonListJson ) ) {
                    return false;
                }

                try {
                    pokemonList = JsonConvert.DeserializeObject<PokemonList>( pokemonListJson );
                } catch ( JsonException ) {
                    return false;
                }

                _memoryCache.Set( _settings.Value.ListCacheKey, pokemonList );

                return true;
            }

            return false;
        }
    }
}
