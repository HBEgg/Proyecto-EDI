using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estructuras
{
    public class Simulacion
    {
        public static NodoCola nodo = new NodoCola(); 
        public static List<Enfermosinfo> listaenfermos = new List<Enfermosinfo>();
        public static List<Enfermosinfo>.Enumerator listaenf = new List<Enfermosinfo>.Enumerator();
        int ViajeE = 0; int ReuSosp = 0; int ConocidoC = 0; int Famcont = 0;
        public int obtenerinfo()
        {
            listaenfermos.GetEnumerator();
            listaenfermos.Add(enfermos);
            if (enfermos.CContagio == "Viaje a Europa" )
            {
                ViajeE += 10; 
            }
            if (enfermos.CContagio == "Reunion con sospechosos")
            {
                ReuSosp += 10;
            }
            if (enfermos.CContagio == "Conocido contagiado")
            {
                ConocidoC += 15;
            }
            if (enfermos.CContagio == "Familiar contagiado")
            {
                Famcont += 30; 
            }
            return obtenerinfo();
        }
        public int ObtenEdad()
        {
            listaenfermos.Add(enfermos);
            if (enfermos.Edad >60)
            {
                Console.WriteLine("Es mayor de edad");
            }
            if (enfermos.Edad >= 30 && enfermos.Edad <=59)
            {
                Console.WriteLine("Es adulto"); 
            }
            if (enfermos.Edad >=1 && enfermos.Edad <=29)
            {
                Console.WriteLine("Es niño o es joven");
            }
            if (enfermos.Edad ==0)
            {
                Console.WriteLine("Es recien nacido");
            }
            return ObtenEdad();
        }
        public bool Contagiado()
        {
            int contador=0; 
            bool viajeE = false, ConocidoR = false, Familiarcont = false, reunionsosp = false;
            int probabilidadb = 5;
            int viaje = 10;
            int conocido = 15;
            int familiar = 30;
            int reunion = 5;
            
            bool Contagiado = false;
            if (Contagiado == false)
            {
                contador++;
                //NodoCola contagiado = new NodoCola
                //{
                //    Departamento = this.Departamento
                //};
                //NodoCola nvonodo = new NodoCola
                //{

                //    Edad = primero.Edad,
                //    Municipio = primero.Municipio,
                //    Departamento = primero.Departamento,
                //    Hora = primero.Hora,
                //    Fecha = primero.Fecha
                //};
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
        public Enfermosinfo enfermos { get; private set; }
    }
}
