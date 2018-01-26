namespace PokedexCore.Manual.Services.Interfaces {
    public interface IPokemonDbAdapter
    {
        string GetFavoritePokemons( string userName );
        void SaveFavoritePokemons( string userName, string favoritePokemonsJson );
    }
}
