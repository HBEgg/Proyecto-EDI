using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_EDI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EDI.Models
{
    public class Enfermos
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
        public string CContagio { get; set; }  //causa de contagio
        //public int Fecha { get; set; }
        public int Hora { get; set; }
        public int Edad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public System.DateTime Fecha { get; set; }
        public bool Save()
        {
            try
            {
                Storage.Instancia.ListaContagiado.Add(this);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public Enfermos()
        {

        }
        public Enfermos(int id, string nombre, string apellido, string dpi, string partidan, string departamento, string municipio)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dpi = dpi;
            this.PartidaN = partidan;
            this.Departamento = departamento;
            this.Municipio = municipio;
        }
    }
}