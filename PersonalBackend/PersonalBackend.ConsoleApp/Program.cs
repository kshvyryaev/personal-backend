using System;

namespace PersonalBackend.ConsoleApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var examplesPersonalBackend = new ExamplesPersonalBackend();

            var example = examplesPersonalBackend.GetOne(0);
            var examples = examplesPersonalBackend.GetAll();
            Console.ReadKey();
        }
    }
}
