using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class NodoAVL
    {
        public Enfermos enfermos { get; set; }
        public int indice { get; set; }
        public NodoAVL Izquierdo { get; set; }
        public NodoAVL Derecho { get; set; }
        public NodoAVL Padre { get; set; }
        public NodoAVL() //constructores
        {

        }
        public NodoAVL(Enfermos enfermosinfo)
        {
            this.enfermos = enfermosinfo;
        }
        public NodoAVL(Enfermos enfermosinfo, NodoAVL padre, NodoAVL izquierdo, NodoAVL derecho)
        {
            this.enfermos = enfermosinfo;
            this.Derecho = derecho;
            this.Izquierdo = izquierdo;
            this.Padre = padre; 
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
