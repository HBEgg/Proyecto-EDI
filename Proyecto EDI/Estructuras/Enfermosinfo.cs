using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Estructuras
{
    public class Enfermosinfo
    {
        
        internal object enfermos;
        private int elementos;

        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Dpi { get; set; }
        public string Contagiado { get; set; }
        public string CContagio { get; set; }
        public string PartidaN { get; set; }
        public int Edad { get; set; }
        public int Fecha { get; set; }
        public int Hora { get; set; }

        internal bool SEHoja()
        {
            throw new NotImplementedException();
        }
        public bool Existe()
        {
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Enfermosinfo()
        {

        }
        public Enfermosinfo(int id,string nombre, string apellido, string dpi, string partidan, string departamento, string municipio)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dpi = dpi;
            this.PartidaN = partidan;
            this.Departamento = departamento;
            this.Municipio = municipio;
        }

        public bool Save()
        {
            try
            {
                Storage.Instancia.Listainformacion.Add(this);

                return true;
            }
            catch
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
