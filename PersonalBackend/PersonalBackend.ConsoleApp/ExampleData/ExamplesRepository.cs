using System.Collections.Generic;
using System.Threading;

namespace PersonalBackend.ConsoleApp.ExampleData
{
    public class ExamplesRepository : IExamplesRepository
    {
        public Example GetOne(int id)
        {
            Thread.Sleep(1000 * 10);

            return new Example
            {
                Id = 0,
                Name = "name",
                Description = "description"
            };
        }

        public IEnumerable<Example> GetAll()
        {
            Thread.Sleep(1000 * 10);

            return new List<Example>
            {
                new Example
                {
                    Id = 0,
                    Name = "name 0",
                    Description = "description 0"
                },
                new Example
                {
                    Id = 1,
                    Name = "name 1",
                    Description = "description 1"
                },
                new Example
                {
                    Id = 2,
                    Name = "name 2",
                    Description = "description 2"
                }
            };
        }
    }
}
