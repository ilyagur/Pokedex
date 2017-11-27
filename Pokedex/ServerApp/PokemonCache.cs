using Pokedex.ServerApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.ServerApp.JsonModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Pokedex.ServerApp.Settings;
using Newtonsoft.Json;

namespace Pokedex.ServerApp
{
    public class PokemonCache : IPokemonCache {
        private readonly IMemoryCache _memoryCache;
        private readonly IFileCache _fileCache;
        private readonly string _pokemonListCacheKey;
        public PokemonCache( IMemoryCache memoryCache, IFileCache fileCache, IOptions<PokemonCacheSettings> settings ) {
            _memoryCache = memoryCache;
            _fileCache = fileCache;

            _pokemonListCacheKey = settings.Value.PokemonListCacheKey;
        }
        public void SavePokemon( Pokemon pokemon ) {
            _memoryCache.Set( pokemon.name, pokemon );
            _fileCache.Set( pokemon.name, JsonConvert.SerializeObject( pokemon ) );
        }

        public void SavePokemonList( PokemonList pokemonList ) {
            _memoryCache.Set(_pokemonListCacheKey, pokemonList);
            _fileCache.Set(_pokemonListCacheKey, JsonConvert.SerializeObject(pokemonList));
        }

        public bool TryGetPokemonByName( string pokemonName, out Pokemon pokemon ) {
            pokemon = new Pokemon();

            if ( _memoryCache.TryGetValue( pokemonName, out pokemon ) ) {
                return true;
            }

            string pokemonJson;
            if ( _fileCache.TryGetValue( pokemonName, out pokemonJson ) ) {
                pokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonJson);

                _memoryCache.Set(pokemonName, pokemon);

                return true;
            }

            return false;
        }

        public bool TryGetPokemonList( out PokemonList pokemonList ) {
            pokemonList = new PokemonList();

            if ( _memoryCache.TryGetValue( _pokemonListCacheKey, out pokemonList ) ) {
                return true; 
            }

            string pokemonListJson;
            if ( _fileCache.TryGetValue( _pokemonListCacheKey, out pokemonListJson ) ) {
                pokemonList = JsonConvert.DeserializeObject<PokemonList>( pokemonListJson );

                _memoryCache.Set(_pokemonListCacheKey, pokemonList);

                return true;
            }

            return false;
        }
    }
}
