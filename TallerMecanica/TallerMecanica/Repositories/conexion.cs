using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanica.Models;

namespace TallerMecanica.Repositories
{
    class conexion
    {
        private SqlConnection conectarse;
        public SqlConnection conectar()
        {
            conectarse = new SqlConnection("server=(local)\\SQLEXPRESS;database=nombreBBDD; Integrated Security = SSPI");//Seguridad Windows.
           
            conectarse.Open();
            return conectarse;
        }
        public SqlDataReader leerbasedatos(string campos, string tablas, string condicion)
        {
            conectarse = conectar();
            SqlCommand comandosql = new SqlCommand();
            comandosql.Connection = conectarse;
            comandosql.CommandText = "SELECT " + campos + " FROM " + tablas + " " + condicion + ";";
            SqlDataReader midatareader = comandosql.ExecuteReader();
            return midatareader;
        }
        public bool insertarbasedatos(string tablas, string condicion)
        {
            try
            {
                conectarse = conectar();
                SqlCommand comandosql = new SqlCommand();
                comandosql.Connection = conectarse;
                comandosql.CommandText = "INSERT INTO " + tablas + "VALUES (" + condicion + ");";
                comandosql.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static void Insert(Cliente c)
        {
            throw new NotImplementedException();
        }

        public bool modificarbasedatos(string value, string tablas, string condicion)
        {
            try
            {
                conectarse = conectar();
                SqlCommand comandosql = new SqlCommand();
                comandosql.Connection = conectarse;
                comandosql.CommandText = "UPDATE " + tablas + " SET " + value + " " + condicion + ";";
                comandosql.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool eliminarbasedatos(string tablas, string condicion)
        {
            try
            {
                conectarse = conectar();
                SqlCommand comandosql = new SqlCommand();
                comandosql.Connection = conectarse;
                comandosql.CommandText = "DELETE FROM " + tablas + " " + condicion + ";";
                comandosql.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void cerrarconexion()
        {
            conectarse.Close();
        }
    }

}
