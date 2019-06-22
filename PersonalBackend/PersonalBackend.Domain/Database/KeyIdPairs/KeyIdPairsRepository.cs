using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBackend.Domain.Database.KeyIdPairs
{
    internal class KeyIdPairsRepository : IKeyIdPairsRepository
    {
        #region Fields

        private readonly DatabaseContext _context;
        private readonly Dictionary<string, int> _keyIdPairs;

        #endregion Fields

        #region Constructors

        public KeyIdPairsRepository()
        {
            _context = new DatabaseContext();
            _keyIdPairs = new Dictionary<string, int>();
            UploadKeyIdPairsFromDatabase();
        }

        #endregion Constructors

        #region Public methods

        public bool Set(string key, int id)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return false;
            }

            if (_keyIdPairs.ContainsKey(key))
            {
                _keyIdPairs.Remove(key);
            }

            _keyIdPairs.Add(key, id);
            StartKeyIdUploadingTask(key, id);

            return true;
        }

        public bool TryGet(string key, out int id)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                id = default(int);
                return false;
            }

            return _keyIdPairs.TryGetValue(key, out id);
        }

        public void Clear()
        {
            _keyIdPairs.Clear();
            _context.KeyIdPairs.RemoveRange(_context.KeyIdPairs);
            _context.SaveChanges();
        }

        #endregion Public methods

        #region Private methods

        private void UploadKeyIdPairsFromDatabase()
        {
            _context.KeyIdPairs.ToList().ForEach(x => 
            {
                _keyIdPairs.Add(x.Key, x.Id);
            });
        }

        private void StartKeyIdUploadingTask(string key, int id)
        {
            Task.Factory.StartNew(() =>
            {
                var keyIdPair = new KeyIdPair { Key = key, Id = id };

                var foundKeyIdPair = _context.KeyIdPairs.FirstOrDefault(x => x.Key == key);

                if (foundKeyIdPair == null)
                {
                    _context.KeyIdPairs.Add(keyIdPair);
                }
                else
                {
                    _context.Entry(keyIdPair).State = EntityState.Modified;
                }

                _context.SaveChanges();
            });
        }

        #endregion Private methods
    }
}
