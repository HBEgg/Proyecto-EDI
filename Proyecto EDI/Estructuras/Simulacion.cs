using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estructuras
{
    public class Simulacion
    {
        
        public bool Contagiado()
        {
            bool viajeE = false, ConocidoR = false, Familiarcont = false, reunionsosp = false;
            int probabilidadb = 5;
            int viaje = 10;
            int conocido = 15;
            int familiar = 30;
            int reunion = 5;
            bool Contagiado = false;
            if (Contagiado == false)
            {
                return false;
            }
            else
            {
                if (viajeE == false)
                {
                    Console.WriteLine("No afecta en el porcentaje de su examen");
                }
                else
                {
                    
                }
                return true; 
            }
        }
           
        public bool Sospechoso = false;

        public bool Examen { get; private set; }
    }
}
