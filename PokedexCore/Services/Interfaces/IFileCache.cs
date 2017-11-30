namespace PokedexCore.Services.Interfaces {
    public interface IFileCache {
        void Set( string key, string value );
        bool TryGetValue( string key, out string value );
    }
}
