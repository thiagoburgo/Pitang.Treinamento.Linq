using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Syntax
{
    class Program
    {
        /****
         * 
         * Procurar por https://www.google.com.br/search?q=101+linq
         * 
         * ***/
        static void Main(string[] args)
        {
            // Clientes em Oakland ordenados pelo ultimo nome (operadores)
            Console.WriteLine("Clientes em Oakland (LINQ operators):");
            var q1 = Data.Customers.Where(c => c.City == "Oakland")
                .OrderBy(c => c.LastName);
            q1.Print();

            // Clientes em Oakland ordenados pelo ultimo nome (keywords)
            Console.WriteLine("\nCustomers in Oakland (LINQ keywords):");
            var q2 = from c in Data.Customers
                where c.City == "Oakland"   
                orderby c.LastName
                select c;
            q2.Print();

            // Lista única de cidades, ordenadas(operators)
            Console.WriteLine("\nCidades dos clientes (LINQ operators):");
            var q3 = Data.Customers.Select(c => c.City).Distinct().OrderBy(s => s);
            q3.Print();

            // Lista única de cidades, ordenadas(keywords com Distinct)
            Console.WriteLine("\nCidades dos clientes (LINQ keywords com Distinct):");
            var q4 = (from c in Data.Customers
                orderby c.City
                select c.City).Distinct();
            q4.Print();

            // Clientes em uma lista de cidades (keywords com Contains)
            Console.WriteLine("\nClientes em uma lista de cidades (LINQ keywords com Contains:):");
            string[] cities = { "Berkeley", "Palo Alto", "Walnut Creek" };
            var q5 = from c in Data.Customers
                where cities.Contains(c.City)
                select c;
            q5.Print();

            // Algum cliente com mais de  100.000 pedidos?
            bool any = Data.Customers.Any(c => c.Orders > 100000);
            Console.WriteLine("\nExiste algum cliente com mais de 100.000 pedidos? (Any): {0}", any);

            // Obtenha os primeiros 3 clientes
            Console.WriteLine("\nPrimeiros 3 clientes:");
            var q6 = Data.Customers.Take(3);
            q6.Print();

            // Reverse them
            Console.WriteLine("\nPrimeiros 3 clientes em ordem reversa:");
            var reverse = q6.Reverse();
            reverse.Print();

            // Sequencia vazia de clientes
            var empty = Enumerable.Empty<Customer>();
            Console.WriteLine("\nSequência vazia: {0}", empty.Count());
        }
    }

    static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            Console.WriteLine("======================================");
            foreach (var item in items) {
                Console.WriteLine(item);
            }
            Console.WriteLine("======================================");

        }
    }
}
