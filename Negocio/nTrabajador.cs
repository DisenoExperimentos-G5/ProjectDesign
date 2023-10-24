using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class nTrabajador
    {
        dTrabajador trabajadordatos;
        public nTrabajador()
        {
            trabajadordatos = new dTrabajador();
        }
        public string RegistrarTrabajador(string Nombres, string ApellidoPaterno, string ApellidoM, int dni, DateTime Fechanacimiento, int salario, int telefono, string direccion, int anhoempresa, int idcargo, int idsector)
        {

            eSector sector = new eSector()
            {
                Id_Sector = idsector,
            };
            eCargo cargo = new eCargo()
            {
                Id_Cargo = idcargo,
            };
            eTrabajador trabajador = new eTrabajador()
            {
                Nombres = Nombres,
                Apellido_Paterno = ApellidoPaterno,
                Apellido_Materno = ApellidoM,
                DNI = dni,
                Fecha_Nacimiento = Fechanacimiento,
                Salario = salario,
                Telefono = telefono,
                Direccion = direccion,
                AnhoIngreso = anhoempresa,
                cargo = cargo,
                sector = sector,
            };
            return trabajadordatos.Insertar_Trabajador(trabajador);
        }
        public string EliminarTrabajador(int id)
        {
            return trabajadordatos.Eliminar_Trabajador(id);

        }

        public List<eTrabajador>listarTrabajadores()
        {
            return trabajadordatos.ListarTodoTrabajador();
        }
        public List<eTrabajador> Listar_salario_sector_trabajador(int idsector)
        {
            
            return trabajadordatos.Listar_Salario_Sector_de_trabajador(idsector);
        }
        public List<eTrabajador>Listar_Trabajador_con_mas_ausencias()
        {
            return trabajadordatos.Listar_Trabajadores_Mayores_ausecias();
        }
        
    }
}
