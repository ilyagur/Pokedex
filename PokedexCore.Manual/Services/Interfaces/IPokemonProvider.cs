using PokedexCore.Manual.Models.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokedexCore.Manual.Services.Interfaces {
    public interface IPokemonProvider
    {
        Task<IList<Pokemon>> GetPokemons( int limit, int offset, string typeFilter );
        Task<IList<Pokemon>> GetFavoritePokemons( string userName );
        Task<IList<Pokemon>> GetSuggestedPokemons( int limit );
        Task<Pokemon> GetPokemonByName( string name );
        void SaveFavoritePokemons( string userName, string[ ] favoritePokemons);
        int DownloadedPokemonCount();
    }
}
