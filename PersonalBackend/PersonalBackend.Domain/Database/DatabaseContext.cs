using System.Data.Entity;
using PersonalBackend.Domain.Database.Values;
using PersonalBackend.Domain.Database.KeyIdPairs;

namespace PersonalBackend.Domain.Database
{
    internal class DatabaseContext : DbContext
    {
        private const string DatabaseConnectionName = "PersonalBackendDatabase";

        public DatabaseContext() : base(DatabaseConnectionName)
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Value> Values { get; set; }

        public DbSet<KeyIdPair> KeyIdPairs { get; set; }
    }
}
