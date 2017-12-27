using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    internal class EmpresaComIterator : IEnumerable<string>
    {
        private readonly List<string> trabalhadores = new List<string>();

        public EmpresaComIterator(params string[] workers)
        {
            foreach (var worker in workers)
            {
                trabalhadores.Add(worker);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var worker in trabalhadores)
            {
                yield return worker;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
