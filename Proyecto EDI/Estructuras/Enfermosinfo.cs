using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class Enfermos
    {
        internal object enfermos;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int Dpi { get; set; }
        public string Contagiado { get; set; }
        public string CContagio { get; set; }
        public int PartidaN { get; set; }
        public int Edad { get; set; }

        internal bool SEHoja()
        {
            throw new NotImplementedException();
        }
    }
}
