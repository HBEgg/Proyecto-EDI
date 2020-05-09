using Proyecto_EDI.Models;
using Estructuras;
using System.Collections.Generic;

namespace Proyecto_EDI
{
    public interface ISingleton
    {
        Cola Cola { get; set; }
        Cola[] Arreglo { get; set; }
        List<Enfermosinfo> EnFi { get; set; }
    }
}