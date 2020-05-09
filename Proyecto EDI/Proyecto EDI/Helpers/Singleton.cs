using Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_EDI.Helpers
{
    public class Singleton: ISingleton
    {
        private static Singleton _instancia = null; 
        private Singleton()
        {

        }
        public static Singleton Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Singleton(); 
                }
                return _instancia;
            }
        }

        public Cola Cola { get; set; }
        public Cola[] Arreglo { get; set; }
        public List<Enfermosinfo> EnFi { get; set; }
        
    }
}