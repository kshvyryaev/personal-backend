namespace PersonalBackend.Domain.Database.Values
{
    public interface IValuesRepository
    {
        bool Set(Value value);

        Value Get(int id);

        void Clear();
    }
}
