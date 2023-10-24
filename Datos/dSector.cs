using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Entidades;
using System.Collections;

namespace Datos
{
    public class dSector
    {
        Database db = new Database();

        public string Insertar_Sector(eSector obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("INSERT INTO tbSector ( Nombre_sector, Ubicacion_planta) values ('{0}','{1}')",obj.Nombre_Sector,obj.Ublicacion_Planta);
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch(Exception e)
            {
                return e.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }

        public string Modificar_Sector(eSector obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string update = string.Format("UPDATE tbSector SET Nombre_sector='{0}', Ubicacion_planta='{1}'Where id_sector={2}", obj.Nombre_Sector, obj.Ublicacion_Planta, obj.Id_Sector);
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

        public string Eliminar_Sector(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from tbSector where id_sector={0}", id);
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

        public eSector BuscarSectorPorId(int id)
        {
            try
            {
                eSector sector = null;
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select id_sector, Nombre_sector, Ubicacion_planta from tbSector where id_sector={0}", id);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sector = new eSector();
                    sector.Id_Sector = (int)reader["id_sector"];
                    sector.Nombre_Sector = (string)reader["Nombre_sector"];
                    sector.Ublicacion_Planta = (string)reader["Ubicacion_planta"];
                }
                reader.Close();
                return sector;
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

        public List<eSector> ListarTodoSector()
        {
            try
            {
                List<eSector> lsSector = new List<eSector>();
                eSector sector = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select id_sector,Nombre_sector, Ubicacion_planta from tbSector", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sector = new eSector();
                    sector.Id_Sector = (int)reader["id_sector"];
                    sector.Nombre_Sector = (string)reader["Nombre_sector"];
                    sector.Ublicacion_Planta = (string)reader["Ubicacion_planta"];
                    lsSector.Add(sector);
                }
                reader.Close();
                return lsSector;
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
        public List<eSector>Listar_Sectores_Mayores_ausecias()
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_sel_sectormayorausencias", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<eSector> lsSector = new List<eSector>();
                while (reader.Read())
                {

                    eSector sector = new eSector();
                    sector.Nombre_Sector = (string)reader["Sector"];
                    sector.Numero_Ausencias = (int)reader["NumeroAusencias"];
                    lsSector.Add(sector);
                }
                reader.Close();
                return lsSector;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally { db.DesconectaDb(); }
        }
    }
}
