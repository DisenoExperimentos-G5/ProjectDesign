using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dControlHoras
    {
        Database db = new Database();

        public string Insertar_ControlHoras(eControlHoras obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO tbControlHoras ( id_trabajador, Hora_ingreso, Hora_salida, Fecha_registro) values ({0},'{1}','{2}','{3}')", obj.id_trabajador, obj.Hora_Ingreso, obj.Hora_Salida, obj.Fecha_Registro);
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

        public string Modificar_ControlHoras(eControlHoras obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("UPDATE tbControlHoras SET id_trabajador={0}, Hora_ingreso='{1}', Hora_salida='{2}', Fecha_registro='{3}' Where id_controlHoras={4}", obj.id_trabajador, obj.Hora_Ingreso, obj.Hora_Salida, obj.Fecha_Registro, obj.Id_ControlHoras);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modifico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Eliminar_ControlHoras(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from tbControlHoras where id_cargo={0}", id);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public eControlHoras BuscarControlHorasPorId(int id)
        {
            try
            {
                eControlHoras ch = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select id_controlHoras, id_trabajador, Hora_ingreso, Hora_salida, Fecha_ingreso from tbControlHoras where id_controlHoras={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ch = new eControlHoras();
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.id_trabajador= (int)reader["id_trabajador"];
                    ch.Hora_Ingreso = (DateTime)reader["Hora_ingreso"];
                    ch.Hora_Salida = (DateTime)reader["Hora_salida"];
                    ch.Fecha_Registro = (DateTime)reader["Fecha_registro"];
                }
                reader.Close();
                return ch;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public List<eControlHoras> ListarTodoControlHoras()
        {
            try
            {
                List<eControlHoras> lsCh = new List<eControlHoras>();
                eControlHoras ch = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select id_controlHoras, id_trabajador, Hora_ingreso, Hora_salida, Fecha_registro from tbControlHoras", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ch = new eControlHoras();
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.id_trabajador = (int)reader["id_trabajador"];
                    ch.Hora_Ingreso = (DateTime)reader["Hora_ingreso"];
                    ch.Hora_Salida = (DateTime)reader["Hora_salida"];
                    ch.Fecha_Registro = (DateTime)reader["Fecha_registro"];
                    lsCh.Add(ch);
                }
                reader.Close();
                return lsCh;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<eControlHoras> Listar_Trabajadores_Mas_horas_trabajadas()
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_sel_trabajadoresconMayorHorasTrabajadas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<eControlHoras> lsTrabajadores = new List<eControlHoras>();
                while (reader.Read())
                {

                    eControlHoras controlhoras = new eControlHoras();
                    controlhoras.id_trabajador = (int)reader["id_trabajador"];
                    controlhoras.NumeroHoras = (int)reader["NumeroHoras"];
                    lsTrabajadores.Add(controlhoras);
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
        public List<eControlHoras> Listar_Trabajadores_Menos_horas_trabajadas()
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_sel_trabajadoresconmenoshorastrabajadas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<eControlHoras> lsTrabajadores = new List<eControlHoras>();
                while (reader.Read())
                {

                    eControlHoras controlhoras = new eControlHoras();
                    controlhoras.id_trabajador = (int)reader["id_trabajador"];
                    controlhoras.NumeroHoras = (int)reader["numeroTrabajoresmenosHoras"];
                    lsTrabajadores.Add(controlhoras);
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
