using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class NodoAVL
    {
        public Enfermosinfo enfermos { get; set; }
        public int indice { get; set; }
        public NodoAVL Izquierdo { get; set; }
        public NodoAVL Derecho { get; set; }
        public NodoAVL Padre { get; set; }
        public int altura { get; set; }

        public NodoAVL() //constructores
        {

        }
        public NodoAVL(Enfermosinfo enfermos)
        {
            this.enfermos = enfermos;
            this.indice = enfermos.id; 
        }
        public NodoAVL(Enfermosinfo enfermos, NodoAVL anterior)
        {
            this.enfermos = enfermos;
            this.indice = enfermos.id;
            this.Padre = anterior; 

        }
        public NodoAVL(Enfermosinfo enfermos, NodoAVL padre, NodoAVL izquierdo, NodoAVL derecho)
        {
            this.enfermos = enfermos;
            this.Derecho = derecho;
            this.Izquierdo = izquierdo;
            this.Padre = padre;
            this.indice = enfermos.id;
        }
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
            if (enfermos != null)
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
