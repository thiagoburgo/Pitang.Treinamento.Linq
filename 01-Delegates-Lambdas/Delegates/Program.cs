using System;

namespace Delegates
{
    // Define um delegate que aceita 2 ints e retorna 1 int
    public delegate int IntDel(int a, int b);
    
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialização e chamada (invoke) do delegate
            //IntDel del = new IntDel(Add); // Explicitamente como qualquer objeto
            IntDel del = Add; // implicitamente

            //int result = del.Invoke(1, 2); // chamada explicita
            int result = del(1, 2); //implicita
            Console.WriteLine("Resultado: {0}", result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
