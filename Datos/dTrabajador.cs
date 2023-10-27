using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dTrabajador
    {
        Database db = new Database();

        public string Insertar_Trabajador(eTrabajador obj)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string insert = string.Format("insert into tbTrabajador ( Nombres, Apellido_paterno, Apellido_materno, DNI, Fecha_nacimiento, Salario, Telefono, Direcion, Años_en_la_empresa, id_cargo, id_sector) " +
                                                "values ('{0}', '{1}', '{2}', {3}, '{4}', {5}, {6}, '{7}', {8}, {9}, {10})", obj.Nombres, obj.Apellido_Paterno, obj.Apellido_Materno, obj.DNI, obj.Fecha_Nacimiento,
                                                obj.Salario, obj.Telefono, obj.Direccion, obj.AnhoIngreso, obj.cargo.Id_Cargo, obj.sector.Id_Sector);
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

        public string Eliminar_Trabajador(int id)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("delete from tbTrabajador where id_trabajador={0}", id);
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
        public List<eTrabajador> TrabajadoresxSector(int idSector)      //retorna la lista de trabajadores que pertenecen a un sector determinado
        {
            try
            {
                eTrabajador trabajador = null;
                eSector sector = null;
                List<eTrabajador> trabajadores_x_sector = new List<eTrabajador>();
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select tra.id_empleado,tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI," +
                    " tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, sec.Nombre_sector ,sec.id_sector," +
                    " sec.Numero_trabajadores, sec.Ubicacion_planta from Sector as sec,Trabajador as tr  where sec.id_sector=tra.id_sector and sec.id_sector={0}", idSector);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    sector = new eSector();
                    trabajador.Id_Trabajador = (int)reader["id_empleado"];
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno= (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento= (DateTime)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion= (string)reader["Direccion"];
                    trabajador.AnhoIngreso = (int)reader["Anio_de_ingreso"];
                    trabajador.cargo.Id_Cargo = (int)reader["Cargo"];
                    sector.Nombre_Sector = (string)reader["Nombre_sector"];
                    sector.Ublicacion_Planta= (string)reader["Ubicacion_planta"];
                    trabajador.sector = sector;
                    trabajadores_x_sector.Add(trabajador);
                }
                reader.Close();
                return trabajadores_x_sector;
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

        public List<eTrabajador> TrabajadoresxCargo(int idCargo)    //retornar la lista de trabajadores de un cargo
        {
            try
            {
                eTrabajador trabajador = null;
                eCargo cargo = null;
                List<eTrabajador> trabajadores_x_cargo = new List<eTrabajador>();
                SqlConnection con = db.ConectaDb();

                string select = string.Format("select tra.id_empleado,tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, car.nombre_cargo ,car.id_cargo from Cargo as car,Trabajador as tr  where car.id_cargo=tra.id_cargo and car.id_cargo={0}", idCargo);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    cargo = new eCargo();
                    trabajador.Id_Trabajador = (int)reader["id_empleado"];
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento = (DateTime)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion = (string)reader["Direccion"];
                    trabajador.AnhoIngreso = (int)reader["Anio_de_ingreso"];
                    trabajador.sector.Id_Sector = (int)reader["Sector"];
                    cargo.Nombre_Cargo= (string)reader["nombre_cargo"];
                    trabajador.cargo = cargo;
                    trabajadores_x_cargo.Add(trabajador);
                }
                reader.Close();
                return trabajadores_x_cargo;
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

        public List<eControlHoras> Lista_Control_HorasxTrabajador(int idTrabajador) //retornar la lista de control de horarios por trabajador 
        {
             try
             {
                 eControlHoras ch = null;
                 eTrabajador trabajador = null;
                 List<eControlHoras> controlhoras_x_trabajador = new List<eControlHoras>();
                 SqlConnection con = db.ConectaDb();
                 string select = string.Format("select tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo, ch.id_controlHoras ,ch.Hora_ingreso, ch.Hora_salida, ch.Fecha_registro from Control_Horas as ch,Trabajador as tr  where tra.id_empleado=ch.id_trabajador and tra.id_empleado={0}", idTrabajador);
                 SqlCommand cmd = new SqlCommand(select, con);
                 SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    ch = new eControlHoras();
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento = (DateTime)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion = (string)reader["Direccion"];
                    trabajador.AnhoIngreso = (int)reader["Anio_de_ingreso"];
                    trabajador.cargo.Id_Cargo = (int)reader["Cargo"];
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.Hora_Ingreso = (DateTime)reader["Hora_ingreso"];
                    ch.Hora_Salida = (DateTime)reader["Hora_salida"];
                     ch.Fecha_Registro = (DateTime)reader["Fecha_registro"];
                     ch.id_trabajador = (int)trabajador.Id_Trabajador;
                     controlhoras_x_trabajador.Add(ch);
                 }
                 reader.Close();
                 return controlhoras_x_trabajador;
             }
             catch (Exception ex) when (idTrabajador == ' ')
             {
                    return null;
             }
             finally
             {
                 db.DesconectaDb();
             }
        }
        public List<eControlHoras> Lista_Control_HorasxTrabajadorxSector(int idTrabajador, int idSector) //retornar la lista de control de horarios por trabajador 
        {
            try
            {
                eControlHoras ch = null;
                eTrabajador trabajador = null;
                eSector st = null;
                List<eControlHoras> controlhoras_x_trabajador_x_sector = new List<eControlHoras>();
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select tra.Nombres, tra.Apellido_paterno, tra.Apellido_materno, tra.DNI, tra.Fecha_nacimiento, tra.Salario, tra.Telefono, tra.Direccion, tra.Anio_de_ingreso, tra.id_cargo,tra.id_sector, ch.id_controlHoras ,ch.Hora_ingreso, ch.Hora_salida, ch.Fecha_registro,as.id_sector from Control_Horas as ch,Trabajador as tr,Sector as sc where tra.id_empleado=ch.id_trabajador and sc.id_sector = tra.id_sector and tra.id_empleado={0} and sc.id_sector = {1}", idTrabajador,idSector);
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trabajador = new eTrabajador();
                    ch = new eControlHoras();
                    trabajador.Nombres = (string)reader["Nombres"];
                    trabajador.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    trabajador.Apellido_Materno = (string)reader["Apellido_materno"];
                    trabajador.DNI = (int)reader["DNI"];
                    trabajador.Fecha_Nacimiento = (DateTime)reader["Fecha_nacimiento"];
                    trabajador.Salario = (decimal)reader["Salario"];
                    trabajador.Telefono = (int)reader["Telefono"];
                    trabajador.Direccion = (string)reader["Direccion"];
                    trabajador.AnhoIngreso = (int)reader["Anio_de_ingreso"];
                    trabajador.cargo.Id_Cargo = (int)reader["Cargo"];
                    trabajador.sector.Id_Sector = (int)reader["Sector"];
                    ch.Id_ControlHoras = (int)reader["id_controlHoras"];
                    ch.Hora_Ingreso = (DateTime)reader["Hora_ingreso"];
                    ch.Hora_Salida = (DateTime)reader["Hora_salida"];
                    ch.Fecha_Registro = (DateTime)reader["Fecha_registro"];
                    ch.id_trabajador = trabajador.Id_Trabajador;
                    controlhoras_x_trabajador_x_sector.Add(ch);
                }
                reader.Close();
                return controlhoras_x_trabajador_x_sector;
            }
            catch (Exception ex) when (idTrabajador == ' ')
            {
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<eTrabajador> no_Cumpliero_Con_Horas_Trabajo()
        {
            try
            {
                eControlHoras ch = null;
                eTrabajador trabajador = null;
                List<eTrabajador> horastrabajo = new List<eTrabajador>();
                SqlConnection con = db.ConectaDb();
                string select = string.Format("select (Hora_ingreso - Hora_salida) from Control_Horas where Hora_ingreso and Hora_salida IS NOT NULL ORDER BY id_trabajador ");
                SqlCommand cmd = new SqlCommand(select, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    horastrabajo.Add(trabajador);
                }
                reader.Close();
                return horastrabajo;
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
        public List<eTrabajador> ListarTodoTrabajador()
        {
            try
            {
                List<eTrabajador> lsSector = new List<eTrabajador>();
                eTrabajador sector = null;
                eSector secto = null;
                eCargo carg = null;
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("select id_trabajador,Nombres, Apellido_paterno,Apellido_materno,DNI,Fecha_nacimiento, Salario,Telefono,Direcion,Años_en_la_empresa,id_cargo,id_sector from tbTrabajador", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    secto = new eSector();
                    carg = new eCargo();
                    sector = new eTrabajador();
                    sector.Id_Trabajador = (int)reader["id_trabajador"];
                    sector.Nombres = (string)reader["Nombres"];
                    sector.Apellido_Paterno = (string)reader["Apellido_paterno"];
                    sector.Apellido_Materno = (string)reader["Apellido_materno"];
                    sector.Nombre_Completo = (string)reader["Nombres"] + " " + (string)reader["Apellido_paterno"];
                    sector.DNI = (int)reader["DNI"];
                    sector.Fecha_Nacimiento = (DateTime)reader["Fecha_nacimiento"];
                    sector.Salario = (decimal)reader["Salario"];
                    sector.Telefono = (int)reader["Telefono"];
                    sector.Direccion = (string)reader["Direcion"];
                    sector.AnhoIngreso = (int)reader["Años_en_la_empresa"];
                    secto.Id_Sector = (int)reader["id_sector"];
                    sector.sector = secto;
                    carg.Id_Cargo = (int)reader["id_cargo"];
                    sector.cargo = carg;

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
        public List<eTrabajador> Listar_Salario_Sector_de_trabajador(int id_sector)
        {
            try
            {
                List<eTrabajador> lsCh = new List<eTrabajador>();
                eSector sector = new eSector();
                eCargo cargo = new eCargo();
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_sel_salarioporsector", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_sector", System.Data.SqlDbType.Int).Value = id_sector;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eTrabajador tr = new eTrabajador();
                    tr.Id_Trabajador = (int)reader["Trabajador"];
                    tr.Nombres = (string)reader["Nombre"];
                    tr.Salario = (decimal)reader["salario"];
                    tr.Apellido_Paterno = (string)reader["apellido_paterno"];
                    tr.Apellido_Materno = (string)reader["apellido_materno"];
                    tr.Nombre_Completo = (string)reader["Nombre"] + " " + (string)reader["apellido_paterno"];
                    tr.DNI = (int)reader["Dni"];
                    tr.Fecha_Nacimiento = (DateTime)reader["Fecha_Nacimiento"];
                    tr.Telefono = (int)reader["Telefono"];
                    tr.Direccion = (string)reader["Direccion"];
                    tr.AnhoIngreso = (int)reader["Tiempo_en_la_empresa"];
                    sector.Nombre_Sector = (string)reader["Sector"];
                    tr.sector = sector;
                    cargo.Nombre_Cargo = (string)reader["Cargo"];
                    tr.cargo = cargo;
                    lsCh.Add(tr);
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
        public List<eTrabajador> Listar_Trabajadores_Mayores_ausecias()
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                SqlCommand cmd = new SqlCommand("sp_sel_trabajadorMayorAusencias", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<eTrabajador> lsTrabajadores = new List<eTrabajador>();
                while (reader.Read())
                {

                    eTrabajador trabajador = new eTrabajador();
                    trabajador.Nombres = (string)reader["Nombre"];
                    trabajador.numeroausencias = (int)reader["numeroAusencias"];
                    lsTrabajadores.Add(trabajador);
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
