namespace PersonalBackend.Domain.Database.KeyIdPairs
{
    public interface IKeyIdPairsRepository
    {
        bool Set(string key, int id);

        bool TryGet(string key, out int id);

        void Clear();
    }
}
