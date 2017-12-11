namespace PokedexCore.Services.Interfaces {
    public interface IFileCache {
        string Set( string key, string value );
        bool TryGetValue( string key, out string value );
    }
}
