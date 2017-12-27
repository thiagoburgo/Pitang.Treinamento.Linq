using System;
using System.Collections.Generic;
using System.Linq;

namespace Conversion_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtendo um e somente um cliente de Oakland
            var c1 = Data.Customers.Single(c => c.City == "Oakland");
            Console.WriteLine(c1);


            // Obtendo um e somente um ou zero clientes de Los Angeles
            var c5 = Data.Customers.SingleOrDefault(c => c.City == "Los Angeles");
            Console.WriteLine("\nCliente de Los Angeles: {0}", c5?.ToString() ?? "-");

            // Processo de materialização IMPORTANTE!
            Console.WriteLine("\nProcesso de materialização:");
            var q1 = from c in Data.Customers
                where c.City == "Oakland" // breakpoint Aqui!
                select c;
            q1.Print(); // F11 Aqui!

            Console.WriteLine("\nClientes de Oakland (List):");
            var customersList = q1.ToList(); // Materializa 'q1' aqui, se não tiver Print!
            customersList.Print(); // aqui não materializa mais (resultado em cache)

            // Converter para dicionario com FirstName + " " + LastName como chave
            var q2 = Data.Customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
            var customersDict = q2.ToDictionary(c => c.FirstName + " " + c.LastName);
            var c6 = customersDict["Johnson Smith"]; //Cuidado com chaves repetidas
            Console.WriteLine("\nDo nosso dicionario de clientes: {0}", c6);

            //Agrupar em Lookup
            Console.WriteLine("\nCliente agrupados por cidade em uma estrutura de Lookup:");
            var lookup = Data.Customers.ToLookup(c => c.City);
            foreach (var cityGroup in lookup)
            {
                Console.WriteLine(cityGroup.Key);
                foreach (var c in cityGroup)
                    Console.WriteLine("\t{0}", c);
            }

            // Contagem de clientes em Oakland
            var count = Data.Customers.Count(c => c.City == "Oakland");
            Console.WriteLine("\nContagem de clientes em Oakland: {0}", count);

            // Clientes com os menores pedidos
            var c7 = (from c in Data.Customers
                where c.Orders == Data.Customers.Min(cli => cli.Orders)
                select c).Single();
            Console.WriteLine("\nClientes com os menores pedidos: {0}", c7);

            // Média dos pedidos de clientes em Oakland
            var average = (from c in Data.Customers
                where c.City == "Oakland"
                select c).Average(c => c.Orders);
            Console.WriteLine("\nMédia dos pedidos em Oakland: {0}", average);
            
            //Verificar se existe algum cliente com menos que 5000 pedidos
            var result = Data.Customers.Any(c => c.Orders < 5000);
            Console.WriteLine("\nAlguem com menos que 5000? {0}", result);
        }
    }

    static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            Console.WriteLine("======================================");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("======================================");
        }
    }
}
