using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_EDI.Models;

namespace Proyecto_EDI.Helpers
{
    public class Storage
    {
        private static Storage _instancia = null;
        public static Storage Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Storage();
                }
                return _instancia;
            }
        }
        public List<Enfermos> ListaContagiado = new List<Enfermos>();
    }
}