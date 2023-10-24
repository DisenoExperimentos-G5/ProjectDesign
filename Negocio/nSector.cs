using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nSector
    {
        dSector sectorDatos;
        public nSector()
        {
            sectorDatos = new dSector();
        }
        public string RegistraSector(string nombre, string ubicacionplanta)
        {
            eSector Sector = new eSector()
            {
                Nombre_Sector = nombre,
                Ublicacion_Planta = ubicacionplanta,
            };
            return sectorDatos.Insertar_Sector(Sector);
        }
        public List<eSector> listarsectores()
        {
            return sectorDatos.ListarTodoSector();
        }
        //public List<eSector> listarSalarioXSector(int id_sector)
        //{
        //    
        //    return sectorDatos.Listar_Salario_Sector(id_sector);
        //}
        public List<eSector> listarsectormayoresausencias()
        {
              List<eSector> t = sectorDatos.Listar_Sectores_Mayores_ausecias();
            return t;
        }
    }
}
