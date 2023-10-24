using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eControlHoras
    {
        public int id_trabajador { get; set; }
        public int NumeroHoras { get; set; }
        public int Id_ControlHoras { get; set; }
        public DateTime Hora_Ingreso { get; set; }
        public DateTime Hora_Salida { get; set; }
        public DateTime Fecha_Registro { get; set; }

       
    }
}  
