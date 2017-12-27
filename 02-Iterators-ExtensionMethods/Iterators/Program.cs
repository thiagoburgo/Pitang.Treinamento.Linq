using System;
using System.Collections.Generic;

namespace Iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            var empresa = new EmpresaIteratorAntigo("Josefa", "Maria", "Florisvalda");
            foreach (var trabalhador in empresa)
            {
                Console.WriteLine(trabalhador);
            }

            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> pares = ObterNumerosPares(ints);
            foreach (var i in pares)
            {
                Console.WriteLine(i);
            }
        }

        static IEnumerable<int> ObterNumerosPares(IEnumerable<int> ints)
        {
            foreach (var i in ints)
            {
                if (i % 2 == 0)
                    yield return i;
            }
        }
    }
}
