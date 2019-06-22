using System;
using Newtonsoft.Json;
using PersonalBackend.Domain.Database.Values;
using PersonalBackend.Domain.Database.KeyIdPairs;

namespace PersonalBackend.Domain
{
    public abstract class PersonalBackendBase
    {
        #region Fields

        private readonly IValuesRepository _values;
        private readonly IKeyIdPairsRepository _keyIdPairs;

        #endregion Fields

        #region Constructors

        public PersonalBackendBase()
        {
            _values = new ValuesRepository();
            _keyIdPairs = new KeyIdPairsRepository();
        }

        public PersonalBackendBase(
            IValuesRepository valuesRepository,
            IKeyIdPairsRepository keyIdRepository)
        {
            if (valuesRepository == null)
            {
                throw new ArgumentNullException(nameof(valuesRepository));
            }

            if (keyIdRepository == null)
            {
                throw new ArgumentNullException(nameof(keyIdRepository));
            }

            _values = valuesRepository;
            _keyIdPairs = keyIdRepository;
        }

        #endregion Constructors

        #region Methods

        protected bool Set<TObject>(string uniqueKey, TObject @object)
            where TObject : class
        {
            if (string.IsNullOrWhiteSpace(uniqueKey))
            {
                return false;
            }

            var value = new Value
            {
                JsonValue = JsonConvert.SerializeObject(@object)
            };

            bool result = _values.Set(value);

            if (result)
            {
                result = _keyIdPairs.Set(uniqueKey, value.Id);
            }

            return result;
        }

        protected TObject Get<TObject>(string uniqueKey)
            where TObject : class
        {
            if (string.IsNullOrWhiteSpace(uniqueKey))
            {
                return null;
            }

            int id;
            if (!_keyIdPairs.TryGet(uniqueKey, out id))
            {
                return null;
            }

            var result = default(TObject);

            Value value = _values.Get(id);

            if (value != null && !string.IsNullOrWhiteSpace(value.JsonValue))
            {
                result = JsonConvert.DeserializeObject<TObject>(value.JsonValue);
            }

            return result;
        }

        protected void Clear()
        {
            _values.Clear();
            _keyIdPairs.Clear();
        }

        #endregion Methods
    }
}
