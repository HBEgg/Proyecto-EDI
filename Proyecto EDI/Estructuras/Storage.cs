using System.Collections.Generic;

namespace Estructuras
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
        public List<Enfermosinfo> Listainformacion = new List<Enfermosinfo>();
    }
}