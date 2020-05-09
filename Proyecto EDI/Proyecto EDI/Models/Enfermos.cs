using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_EDI.Helpers;
using System.ComponentModel.DataAnnotations;
using Estructuras;

namespace Proyecto_EDI.Models
{
    public class Enfermos : IComparable
    {
        [Required]
        public string Nombre { get; set; }
        public int id { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Dpi { get; set; }
        public string  PartidaN { get; set; }
        public string Sintoma { get; set; }
        public string Estado { get; set; }
        public string CContagio { get; set; }  //causa de contagio
        //public int Fecha { get; set; }
        public int Hora { get; set; }
        public int Edad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public System.DateTime Fecha { get; set; }
        public object enfermosinfo { get; private set; }

        public Enfermos()
        {

        }
        public bool Save()
        {
            try
            {
                Helpers.Storage.Instancia.ListaContagiado.Add(this);
                
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public int CompareTo(object obj)
        {
            return Nombre.CompareTo(((Enfermos)obj).Nombre);
        }

        public static Comparison<Enfermos> CompararPorNombre = delegate (Enfermos enfermo1, Enfermos enfermo2)
        {
            return enfermo1.Nombre.CompareTo(enfermo2.Nombre);
        };

        public static Comparison<Enfermos> CompararPorApellido = delegate (Enfermos enfermo1, Enfermos enfermo2)
        {
            return enfermo1.Apellido.CompareTo(enfermo2.Apellido);
        };

        public static Comparison<Enfermos> CompararPorDPI = delegate (Enfermos enfermo1, Enfermos enfermo2)
        {
            return enfermo1.Dpi.CompareTo(enfermo2.Dpi);
        };
    }
}