using PersonalBackend.Domain;
using PersonalBackend.Domain.Database.Values;
using PersonalBackend.Domain.Database.KeyIdPairs;

namespace PersonalBackend.Tests
{
    internal class PersonalBackendModel : PersonalBackendBase
    {
        public PersonalBackendModel(
            IValuesRepository valuesRepository,
            IKeyIdPairsRepository keyIdRepository)
            : base(valuesRepository, keyIdRepository)
        {
        }

        internal bool TestSetMethod<TObject>(string uniqueKey, TObject @object)
            where TObject : class
        {
            return Set(uniqueKey, @object);
        }

        internal TObject TestGetMethod<TObject>(string uniqueKey)
            where TObject : class
        {
            return Get<TObject>(uniqueKey);
        }
    }
}
