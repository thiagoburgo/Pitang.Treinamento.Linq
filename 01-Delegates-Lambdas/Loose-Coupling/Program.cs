using System;
using System.Collections.Generic;

namespace Loose_Coupling
{
    class Program
    {
        private delegate bool TestDel(string s); // Poderiamos usar a versão nativa: Func<string, bool>

        static void Main(string[] args)
        {
            string[] items = { "João", "Maria", "José", "Pedro" };

            int max = 3;

             /*(1)*/ string[] result = Where(items, TestForLength);
 
            // /*(2)*/ Func<string, bool> test = delegate(string s) { return s.Length > max; };
            // /*(2)*/ string[] result = Where(items, test); 
            
            // /*(3)*/ string[] result = Where(items, delegate(string s) { return s.Length > max; }); 
            // /*(4)*/ string[] result = Where(items, s => s.Length > max);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static bool TestForLength(string s)
        {
            return s.Length > 3;
        }

        //v2 
        //static string[] Where(string[] items, Func<string, bool> test)
        //v1
        static string[] Where(string[] items, TestDel test)
        {
            var result = new List<string>();
            foreach (var item in items)
            {
                if (test(item))
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
    }
}
