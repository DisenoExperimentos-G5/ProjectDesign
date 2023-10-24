using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nControlHoras
    {
        dControlHoras controlHorasdatos;
        public nControlHoras()
        {
            controlHorasdatos= new dControlHoras();
        }
        public string InsertarControlhoras(int idTrabajador, DateTime Horaingreso, DateTime Horasalida,DateTime Horaregistro)
        {
            
            eControlHoras controlhoras = new eControlHoras()
            {
                Hora_Ingreso = Horaingreso,
                Hora_Salida = Horasalida,
                Fecha_Registro = Horaregistro,
                id_trabajador = idTrabajador,

            };
            return controlHorasdatos.Insertar_ControlHoras(controlhoras);
        }
        public List<eControlHoras> ListarTrabajadoresConMashorasTrabajadas()
        {
            return controlHorasdatos.Listar_Trabajadores_Mas_horas_trabajadas();
        }
        public List<eControlHoras> ListarTrabajadoresConMenoshorasTrabajadas()
        {
            return controlHorasdatos.Listar_Trabajadores_Menos_horas_trabajadas();
        }


    }
}
