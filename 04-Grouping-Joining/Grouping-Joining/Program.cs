using System;
using System.Collections.Generic;
using System.Linq;
using SampleData;

namespace Grouping_Joining
{
    class Program
    {
        static void Main(string[] args)
        {
            // Consultar livros, use o 'let' para calcular impostos e preço total
            // Use imposto e total no where e select (projeção)
            Console.WriteLine("Use 'let' para declarar variáveis inline:");
            var q1 = from b in LinqBooks.Books
                let tax = b.Price*.0825M
                let total = b.Price + tax
                where total > 20
                select new {b.Title, b.Price, Tax = tax, Total = total};
            q1.Print();

            
            // Use multiplos 'from' para listar objetos filhos relacionados (podia usar o SelectMany)
            Console.WriteLine("\nMultiplos 'from' para listar objetos filhos relacionados ");
            var q2 = (from b in LinqBooks.Books
                from a in b.Authors
                select a).Distinct().OrderBy(a => a.LastName);
            q2.Print();

            // Agrupar livros por preço
            Console.WriteLine("\nAgrupar livros por preço:");
            var q3 = from b in LinqBooks.Books
                group b by b.Price;
            foreach (var g in q3)
            {
                Console.WriteLine(g.Key);
                foreach (var b in g)
                    Console.WriteLine("\t{0}", b.Title);
            }

            // Agrupar livros por preço, e ordena os grupos (palavra-chave 'into')
            Console.WriteLine("\nUse 'into' para manipular os grupos:");
            var q4 = from b in LinqBooks.Books
                     orderby b.Title
                     group b by b.Price into g
                     orderby g.Key descending 
                     select g;
            foreach (var g in q4)
            {
                Console.WriteLine(g.Key);
                foreach (var b in g)
                    Console.WriteLine("\t{0}", b.Title);
            }

            // Join autores com coleção de nomes (pelo 1º nome)
            Console.WriteLine("\nJoin autores com coleção de nomes (pelo 1º nome):");
            var q5 = from a in LinqBooks.Authors
                join n in Data.Names 
                     on a.FirstName equals n
                select a;
            q5.Print();

            // Cria um grupo de junção entre autores e hobbies usando 'into'
            Console.WriteLine("\nJoin autores com Hobbies (Group Join):");
            var q6 = from a in LinqBooks.Authors
                join ah in Data.AuthorHobbies
                    on a.FirstName equals ah.Name into hobbies
                select new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Hobbies = hobbies
                };
            foreach (var a in q6)
            {
                Console.WriteLine(a.Name);
                foreach (var h in a.Hobbies)
                {
                    Console.WriteLine("\t{0}", h.Hobby);
                }
            }
            /**********
             * 
             * Para dúvidas sobre os JOINs
             * https://www.google.com.br/search?q=sql+joins&source=lnms&tbm=isch
             * 
             * ************/
            // Join autor com hobbies (Left Join) usando 'DefaultIfEmpty'
            Console.WriteLine("\nJoin autor com hobbies (Left Join):");
            var q7 = from author in LinqBooks.Authors
                join authorHobby in Data.AuthorHobbies
                    on author.FirstName equals authorHobby.Name into hobbies
                from authorHobby in hobbies.DefaultIfEmpty()
                select new
                {
                    Name = $"{author.FirstName} {author.LastName}",
                    Hobby = authorHobby != null ? authorHobby.Hobby : string.Empty
                };
            q7.Print();
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
