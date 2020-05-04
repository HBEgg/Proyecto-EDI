using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_EDI
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int Dpi { get; set; }
        public int PartidaN { get; set; }
        public string Sintoma { get; set; }
        public string CContagio { get; set; }  //causa de contagio
        public int Fecha { get; set; }
        public int Hora { get; set; }
        public int Edad { get; set; }
    }
}