using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanica.Models;

namespace TallerMecanica.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using TallerMecanica.Models;
    public class CategoriaRepository : BaseRepository, IRepository<Categoria>
    {
        //Constructor
        public CategoriaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(Categoria item)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Categoria values (@Nombre, @cantidad)";
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = item.Nombre;
                command.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = item.cantidad;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Categoria where idCategoria=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public void Edit(Categoria item)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Categoria 
                                        set Nombre=@name, cantidad=@cantidad 
                                        where idCategoria=@idCategoria";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = item.Nombre;
                command.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = item.cantidad;
                command.Parameters.Add("@idCategoria", SqlDbType.Int).Value = item.idCategoria;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            var list = new List<Categoria>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Categoria order by idCategoria desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new Categoria();
                        item.idCategoria = (int)reader["idCategoria"];
                        item.Nombre = reader["Nombre"].ToString();
                        item.cantidad = (int)reader["cantidad"];
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public IEnumerable<Categoria> GetByValue(string value)
        {
            var list = new List<Categoria>();
            int idParametro = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Categoria
                                        where idCategoria=@id or Nombre like @name+'%' 
                                        order by Pet_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = idParametro;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = value;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new Categoria();
                        item.idCategoria = (int)reader["idCategoria"];
                        item.Nombre = reader["Nombre"].ToString();
                        item.cantidad = (int)reader["cantidad"];
                        list.Add(item);
                    }
                }
            }
            return list;
        }
    }
}
