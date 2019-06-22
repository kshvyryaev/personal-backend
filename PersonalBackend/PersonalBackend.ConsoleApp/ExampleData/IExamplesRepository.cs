using System.Collections.Generic;

namespace PersonalBackend.ConsoleApp.ExampleData
{
    public interface IExamplesRepository
    {
        Example GetOne(int id);

        IEnumerable<Example> GetAll();
    }
}
