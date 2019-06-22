using System.Collections.Generic;
using PersonalBackend.ConsoleApp.ExampleData;
using PersonalBackend.Domain;

namespace PersonalBackend.ConsoleApp
{
    public class ExamplesPersonalBackend : PersonalBackendBase, IExamplesRepository
    {
        private readonly IExamplesRepository _examplesRepository;

        public ExamplesPersonalBackend()
        {
            _examplesRepository = new ExamplesRepository();
        }

        public Example GetOne(int id)
        {
            string key = $"{nameof(ExamplesPersonalBackend)}{nameof(GetOne)}{id}";

            var example = Get<Example>(key);

            if (example == null)
            {
                example = _examplesRepository.GetOne(id);
                Set(key, example);
            }

            return example;
        }

        public IEnumerable<Example> GetAll()
        {
            string key = $"{nameof(ExamplesPersonalBackend)}{nameof(GetAll)}";

            var examples = Get<IEnumerable<Example>>(key);

            if (examples == null)
            {
                examples = _examplesRepository.GetAll();
                Set(key, examples);
            }

            return examples;
        }

        public void ClearAll()
        {
            Clear();
        }
    }
}
