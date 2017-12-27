using System;

namespace NullableValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Explicitamente
            //var today = new Nullable<DateTime>(DateTime.Today);

            // Usando o atalho e conversão implicita
            DateTime? hoje = DateTime.Today;
            Console.WriteLine("Value: {0}", hoje.Value);
            //Console.WriteLine("Value: {0}", (DateTime)hoje);
            Console.WriteLine("Has Value: {0}", hoje.HasValue);

            
            Console.WriteLine("\nDateTime?.GetType: {0}", hoje?.GetType());

            // Boxing
            Console.WriteLine("\nBoxing:");
            object boxed = hoje;
            DateTime date = (DateTime)boxed;
            Console.WriteLine(date);

            // Null e comparação
            Console.WriteLine("\nPressione qualquer tecla para setar 'null'");
            Console.ReadLine();
            hoje = null;
            Console.WriteLine("Has Value: {0}", hoje != null);
            Console.WriteLine("Is Today: {0}", hoje == DateTime.Today);

            // operador 'as'
            object data = hoje;
            var id = data as Guid?;
            Console.WriteLine("\nHoje é um 'Guid': {0}", id != null);
        }
    }
}
