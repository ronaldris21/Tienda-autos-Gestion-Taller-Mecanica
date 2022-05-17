namespace TallerMecanica.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using TallerMecanica.Models;
    public class RCategoria : BaseRepository, IRepository<Categoria>
    {
        //Methods
        public bool Insert(Categoria item)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "insert into Categoria values (@Nombre, @cantidad)";
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = item.nombreCategoria;
                    command.Parameters.Add("@cantidad", SqlDbType.NVarChar).Value = item.cantidadCocheCompleto;
                    command.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return false;
            }
            
        }

        public bool Update(Categoria item)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"update Categoria 
                                        set nombreCategoria=@name
                                        where idCategoria=@idCategoria";
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = item.nombreCategoria;
                    command.Parameters.Add("@idCategoria", SqlDbType.Int).Value = item.idCategoria;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return false;
            }
            
        }

        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                var list = new List<Categoria>();
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from Categoria order by idCategoria asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Categoria();
                            item.idCategoria = (int)reader["idCategoria"];
                            item.nombreCategoria = reader["nombreCategoria"].ToString().Trim();
                            item.cantidadCocheCompleto = (int)reader["cantidadCocheCompleto"];
                            list.Add(item);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return new List<Categoria>();
            }
        }

        public IEnumerable<Categoria> GetByValue(string value)
        {
                var list = new List<Categoria>();
            try
            {
                int idParametro = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"Select *from Categoria
                                        where idCategoria=@id or nombreCategoria like @name+'%' 
                                        order by Pet_Id asc";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = idParametro;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = value;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Categoria();
                            item.idCategoria = (int)reader["idCategoria"];
                            item.nombreCategoria = reader["nombreCategoria"].ToString().Trim();
                            item.cantidadCocheCompleto = (int)reader["cantidadCocheCompleto"];
                            list.Add(item);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return new List<Categoria>();
            }

            
        }
    }
}
