using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nAusencias
    {
        dAusencias ausenciadatos;
        public nAusencias()
        {
            ausenciadatos = new dAusencias();
        }
        public string Registrarausencia(DateTime fecharegistro, int idtrabajador)
        {
            eAusencias Ausencia = new eAusencias();
            {
                Ausencia.fecha_registro = fecharegistro;
                Ausencia.id_trabajador = idtrabajador;
            };
            return ausenciadatos.insertarAusencia(Ausencia);
        }
        public List<eAusencias> Lista_trabajador_con_mas_ausencias()
        {
            return ausenciadatos.Listar_Trabajadores_Mayores_ausecias();
        }
    }
}
