using System.Data.Entity;
using System.Linq;

namespace PersonalBackend.Domain.Database.Values
{
    internal class ValuesRepository : IValuesRepository
    {
        private readonly DatabaseContext _context;

        public ValuesRepository()
        {
            _context = new DatabaseContext();
        }

        public bool Set(Value value)
        {
            if (value == null)
            {
                return false;
            }

            Value foundValue = Get(value.Id);

            if (foundValue == null)
            {
                _context.Values.Add(value);
            }
            else
            {
                _context.Entry(value).State = EntityState.Modified;
            }

            return _context.SaveChanges() > 0;
        }

        public Value Get(int id)
        {
            return _context.Values.FirstOrDefault(x => x.Id == id);
        }

        public void Clear()
        {
            _context.Values.RemoveRange(_context.Values);
            _context.SaveChanges();
        }
    }
}
