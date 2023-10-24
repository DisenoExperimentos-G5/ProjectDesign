using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Database
    {
        private SqlConnection con;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadenaconexion = "Data Source=LAPTOP-254UCORC\\SQLEXPRESS1;Initial Catalog=dbTrabaFinal;Integrated Security=True";
                con = new SqlConnection(cadenaconexion);
                con.Open();
                return con;
            }
            catch (SqlException e)
            {
                if(con != null )
                {
                    DesconectaDb();
                }
                return null;
            }
        }
        public void DesconectaDb()
        {
            con.Close();
        }
    }
}
