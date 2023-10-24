using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eSector
    {
        public int Id_Sector { get; set; }
        public string Nombre_Sector { get; set; }
        public int Numero_Ausencias { get; set; }
        public string Ublicacion_Planta { get; set; }
        public override string ToString()
        {
            return Nombre_Sector;
        }
    }
}
