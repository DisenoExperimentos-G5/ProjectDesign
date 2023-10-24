using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eTrabajador
    {
        public int Id_Trabajador { get; set; }
        public string Nombres { get; set; }
        public decimal Salario { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int DNI { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int AnhoIngreso{ get; set; }
        public int numeroausencias { get; set; }
        public eSector sector { get; set; }
        public eCargo cargo { get; set; }
        public eControlHoras controlHoras { get; set; }
    }
}
