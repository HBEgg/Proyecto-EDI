using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_EDI.Models;
using Estructuras; 

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
        public List<Enfermosinfo> Listainformacion = new List<Enfermosinfo>();
        public int CantidadSospechosos = 0;
        public int CantidadRecuperados = 0;
        public int CantidadContagiados = 0;
        public Dictionary<string, Enfermos> InfoEnfermosNombre = new Dictionary<string, Enfermos>();
        public Dictionary<string, Enfermos> InfoEnfermosApellido = new Dictionary<string, Enfermos>();
        public Dictionary<string, Enfermos> InfoEnfermosDPI = new Dictionary<string, Enfermos>();
    }
}