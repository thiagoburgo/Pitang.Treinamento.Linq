using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    // Bring Where into scope
    using MyLinq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Métodos de extensão podem ser chamados como métodos static comuns
            IEnumerable<int> evens = MeuEnumerable.Where(ints, i => i % 2 == 0);

            // ou com uma sintaxe idêntica a métodos de instância
            //IEnumerable<int> evens = ints.Where(i => i % 2 == 0);
            foreach (var i in evens)
            {
                Console.WriteLine(i);
            }

            string[] strings = { "Thiago;33", "Denis;25", "Robson;23" };

            // Call Select to return anonymous types
            var folks = strings.Select(s => new {
                Nome = s,
                Idade = int.Parse(s.Split(';')[1])
            });

            foreach (var f in folks)
            {
                Console.WriteLine(f);
            }
        }
    }
}
