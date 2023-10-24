using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eAusencias
    {
        public string nombre { get; set; }
        public int numero_de_ausencias { get; set; }    
        public DateTime fecha_registro { get; set; }
        public int id_trabajador { get; set; }  
    }
}
