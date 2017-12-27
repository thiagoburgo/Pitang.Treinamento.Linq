using System;
using System.Collections;

namespace Iterators
{
    public class EmpresaIteratorAntigo : IEnumerable
    {
        private readonly ArrayList trabalhadores = new ArrayList();

        public EmpresaIteratorAntigo(params string[] workers)
        {
            foreach (var worker in workers)
            {
                trabalhadores.Add(worker);
            }
        }

        public IEnumerator GetEnumerator()
        {
            var enumerator = new EmpresaEnumerator {Trabalhadores = trabalhadores};
            return enumerator;
        }

        private class EmpresaEnumerator : IEnumerator
        {
            int _index = -1;
            public ArrayList Trabalhadores { get; set; }

            public object Current
            {
                get { return Trabalhadores[_index]; }
            }

            public bool MoveNext()
            {
                _index++;
                return (_index < Trabalhadores.Count);
            }

            public void Reset()
            {
                _index = -1;
            }
        }
}
}
