using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class ArbolAVL<T> : ICollection<T>, IEnumerable<T>
    {
        public NodoAVL Raiz { get; set; }
        public bool Vacio { get { return Raiz == null; } }
        private void Add(Enfermos item, NodoAVL raiz)
        {
            if (Raiz != null)
            {
                if (string.Compare(item.Nombre, raiz.enfermos.Nombre)==1)
                {
                    if (raiz.Izquierdo != null)
                    {
                        this.Add(item, raiz.Izquierdo);
                    }
                    else
                    {
                        raiz.Izquierdo = new NodoAVL(item);
                    }
                }
                else
                {
                    if (raiz.Derecho !=null)
                    {
                        this.Add(item, raiz.Derecho);
                    }
                    else
                    {
                        raiz.Derecho = new NodoAVL(item);
                    }
                }
            }
        }
        public void CreaArbol(List<Enfermos> listaenfermos)
        {
            foreach (var item in listaenfermos)
            {
                this.Add(item); 
            }
        }

        private void Add(Enfermos item)
        {
            throw new NotImplementedException();
        }

        public int Buscar(string personas, NodoAVL raiz)
        {
            if (Raiz != null)
            {
                if (Raiz.enfermos.Nombre == personas)
                {
                    return Raiz.indice;
                }
                else
                {
                    return Buscar(personas, Raiz);
                }
            }
            else
            {
                return -1;
            }
        }
        private int Buscar(string personas, Enfermos raizn)
        {
            if (raizn.SEHoja())
            {
                return -1;
            }
            else if (string.Compare(personas, raizn.enfermos.Nombre)==1)
            {

            }
           
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
