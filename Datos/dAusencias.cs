﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
    public class dAusencias
    {
        Database db = new Database();
        public string insertarAusencia(eAusencias obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into tbausencias (fecha_registro, id_trabajador) values ('{0}',{1})", obj.fecha_registro, obj.id_trabajador);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<eAusencias> Listar_Trabajadores_Mayores_ausecias()
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                eTrabajador trabajador = new eTrabajador();
                SqlCommand cmd = new SqlCommand("sp_sel_trabajadorMayorAusencias", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<eAusencias> lsTrabajadores = new List<eAusencias>();
                while (reader.Read())
                {

                    eAusencias ausencia = new eAusencias();
                    ausencia.id_trabajador = (int)reader["id_Trabajador"];
                    trabajador.Nombres = (string)reader["Nombre"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Id_Trabajador = ausencia.id_trabajador;
                    ausencia.numero_de_ausencias = (int)reader["numeroAusencias"];
                    lsTrabajadores.Add(ausencia);
                }
                reader.Close();
                return lsTrabajadores;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { db.DesconectaDb(); }
        }
    }
}
