using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nCargo
    {
        dCargo cargoDatos;
        public nCargo()
        {
            cargoDatos = new dCargo();
        }
        public string RegistrarCargo(string nombre)
        {
            eCargo cargo = new eCargo()
            {
                Nombre_Cargo = nombre,
            };
            return cargoDatos.Insertar_Cargo(cargo);
        }
        public List<eCargo> listarCargos()
        {
            return cargoDatos.ListarTodoCargo();
        }
    }
}
