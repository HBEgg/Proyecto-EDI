using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    public class NodoAVL<T>
    {
        public T Enfermo { get; set; }
        public int indice { get; set; }
        public NodoAVL<T> Izquierdo { get; set; }
        public NodoAVL<T> Derecho { get; set; }
        public NodoAVL<T> Padre { get; set; }
        public int altura { get; set; }

        /// <summary>
        /// Constructores
        /// </summary>
        /// <param name="enfermo"></param>
        public NodoAVL(T enfermo)
        {
            this.Enfermo = enfermo;
        }
        //public NodoAVL(Enfermosinfo enfermos, NodoAVL anterior)
        //{
        //    this.Enfermo = enfermos;
        //    this.indice = enfermos.id;
        //    this.Padre = anterior; 

        //}
        //public NodoAVL(Enfermosinfo enfermos, NodoAVL padre, NodoAVL izquierdo, NodoAVL derecho)
        //{
        //    this.Enfermo = enfermos;
        //    this.Derecho = derecho;
        //    this.Izquierdo = izquierdo;
        //    this.Padre = padre;
        //    this.indice = enfermos.id;
        //}

        //Verificando las condiciones de un arbol 
        public bool Raiz()
        {
            if (Padre != null)
            {
                return false; 
            }
            else
            {
                return true;
            }
        }
        public bool SEHoja() //si es hoja 
        {
            if (Derecho == null)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }
        public bool SEDerecho()  //si es derecho
        {
            if (Derecho != null)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }
        public bool SEIzquierdo()
        {
            if (Izquierdo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SHPacientes()
        {
            if (Enfermo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
