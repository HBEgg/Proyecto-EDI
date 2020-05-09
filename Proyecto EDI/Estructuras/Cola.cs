using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    public class Cola
    {
        public NodoCola primero;
        public NodoCola Ultimo;

        public Cola()
        {
            primero = null;
            Ultimo = null;
        }
        public NodoCola Pop()
        {
            NodoCola auxiliar = new NodoCola
            {
                Edad = primero.Edad,
                Municipio = primero.Municipio,
                Departamento = primero.Departamento,
                Hora = primero.Hora,
                Fecha = primero.Fecha
            };
            primero = primero.Sgte;
            return auxiliar;
        }
        public void Push(int edad, string municipio, string departamento, string hora, string fecha)
        {
            NodoCola auxiliar2 = new NodoCola
            {
                Edad = edad,
                Municipio = municipio,
                Departamento = departamento,
                Hora = hora,
                Fecha = fecha,
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
            return primero == null ? true : false; //para verificar si el primero de la cola existe o no  o si tiene un valor verdadero o falso
        }

        public NodoCola Heap(int edad, string departamento, string municipio, string hora, string fecha, Cola nueva)
        {
            Push(edad, departamento, municipio, hora, fecha);
            Cola nvacola = new Cola();
            // NodoCola ultimo;
            while (nueva.primero.Sgte != null)
            {
                if (nueva.primero.Sgte != null)
                {
                    NodoCola auxiliares;
                    auxiliares = nueva.Pop();
                    nvacola.Push(auxiliares.Edad, auxiliares.Municipio, auxiliares.Departamento, auxiliares.Hora, auxiliares.Fecha);
                }
            }
            return new NodoCola();
        }
        public static NodoCola MaxHeap(int[] t, int n, int posicion)   //verificando hacia que lado del arbol se ira el indice de el paciente
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
            for (int i = (tam - 1) / 2; i >= 0; i--)
            {
                MaxHeap(arreglo, tam, i);
            }
            for (int j = arreglo.Length - 1; j > 0; j--)
            {
                int temporal = arreglo[j];
                arreglo[j] = arreglo[0];
                arreglo[0] = temporal;
                tam--;
                MaxHeap(arreglo, tam, 0);
            }
        }

        //public static NodoCola HeapSort(List<Enfermosinfo>[] enfermos)
        //{
        //    int tam = enfermos.Length;
        //    for (int i = (tam - 1) / 2; i >= 0; i--)
        //    {
        //        MaxHeap(enfermos, tam, i);
        //    }
        //    for (int j = enfermos.Length - 1; j > 0; j--)
        //    {
        //        int temporal = enfermos[j];
        //        enfermos[j] = enfermos[0];
        //        enfermos[0] = temporal;
        //        tam--;
        //        MaxHeap(enfermos, tam, 0);
        //    }
        //   // return MaxHeap(enfermos)
        //}
    }
}
