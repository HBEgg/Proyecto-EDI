using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class Cola
    {
        public NodoCola primero;
        public NodoCola Ultimo; 
        
        public Cola()
        {
            primero = null;
            Ultimo = null; 
        }
        public NodoCola pop()
        {
            NodoCola auxiliar = new NodoCola
            {
                Nombre = primero.Nombre,
                Apellido = primero.Apellido,
                Dpi = primero.Dpi,
                PartidaN = primero.PartidaN,
                Departamento = primero.Departamento
            };
            primero = primero.Sgte;
            return auxiliar;
        }
        public void Push(string nombre, string apellido, string dpi, string partidan, string departamento)
        {
            NodoCola auxiliar2 = new NodoCola
            {
                Nombre = nombre,
                Apellido = apellido,
                Dpi = dpi,
                PartidaN = partidan,
                Departamento = departamento,
                Sgte = null
            };
            if (Vacio(primero))
            {
                primero = auxiliar2;
            }
            else
            {
                Ultimo.Sgte = auxiliar2;
            }
            Ultimo = auxiliar2;
        }

        private bool Vacio(NodoCola primero)
        {
            return (primero == null) ? true : false; //para verificar si el primero de la cola existe o no  o si tiene un valor verdadero o falso
            throw new NotImplementedException();
        }
        public void Heap(string nombre, string apellido, string dpi, string partidan, string departamento, Cola nueva)
        {
            Push(nombre, apellido, dpi, partidan, departamento);
            Cola nvacola = new Cola();
           // NodoCola ultimo;
            while (nueva.primero.Sgte !=null)
            {
                if (nueva.primero.Sgte !=null)
                {
                    NodoCola auxiliares;
                    auxiliares = nueva.pop();
                    nvacola.Push(auxiliares.Nombre, auxiliares.Apellido, auxiliares.Dpi, auxiliares.PartidaN, auxiliares.Departamento);

                }
            }
        }
       public NodoCola MaxHeap(int [] t, int n, int posicion)   //verificando hacia que lado del arbol se ira el indice de el paciente
       {
            int izquierda = ((posicion + 1) * 2) - 1;
            int derecha = ((posicion + 1) * 2);
            int mayor = 0;
            int tamaño = 0;
            if (izquierda < tamaño && t[izquierda] > t[posicion])
            {
                mayor = izquierda;
            }
            else
            {
                mayor = posicion;
            }
            if (derecha < tamaño && t[derecha] > t[mayor])
            {
                mayor = derecha; 
            }
            if (mayor != posicion)
            {
                int mientras = t[posicion];
                t[posicion] = t[mayor];
                t[mayor] = mientras;
                MaxHeap(t, n, posicion); 
            }
            return MaxHeap(t, n, posicion);

       }
        public void Heapsort(int[] arreglo)
        {
            int tam = arreglo.Length;
            for (int i = (tam -1)/2; i >=0; i--)
            {
                MaxHeap(arreglo, tam, i); 
            }
            for (int j = arreglo.Length -1; j >0; j--)
            {
                int temporal = arreglo[j];
                arreglo[j] = arreglo[0];
                arreglo[0] = temporal;
                tam--;
                MaxHeap(arreglo, tam, 0);
            }
        }
    }
}
