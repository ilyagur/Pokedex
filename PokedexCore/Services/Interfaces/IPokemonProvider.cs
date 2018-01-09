using PokedexCore.Models.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokedexCore.Services.Interfaces {
    public interface IPokemonProvider
    {
        Task<IList<Pokemon>> GetPokemons( int limit, int offset, string typeFilter );
        Task<Pokemon> GetPokemonByName( string name );
        Task<IList<Pokemon>> GetFavoritePokemons( string userName );
        void SaveFavoritePokemons( string userName, string[ ] favoritePokemons);
    }
}
