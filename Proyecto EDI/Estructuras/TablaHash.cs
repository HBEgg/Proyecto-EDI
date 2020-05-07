using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estructuras
{
    class TablaHash
    {
        Dictionary<string, Enfermosinfo> keyValues = new Dictionary<string, Enfermosinfo>();
        Dictionary<string, string> Valores = new Dictionary<string, string>(); 
        Enfermosinfo Contagiado = null;
        Enfermosinfo Sospechosos = null;
        string llave = " ";
        private object posibles;

        public string funcionRand()
        {
            Random objeto = new Random();
            string CadenaH = "12345678910PACIENTEHOSPITALCAB";
            int longitud = CadenaH.Length;
            char letra;
            int hlongitud = 5;
            string Nvacadena = string.Empty;

            for (int i = 0; i < hlongitud; i++)
            {
                letra = CadenaH[objeto.Next(hlongitud)];
                Nvacadena += letra.ToString();
            }
            return Nvacadena;
        }
        
        

    }
}
