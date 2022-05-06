namespace TallerMecanica.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using TallerMecanica.Models;
    public class RMateriaPrima : BaseRepository, IRepository<MateriaPrima>
    {
        //Methods
        public bool Insert(MateriaPrima item)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "insert into MateriaPrima (nombre, marca, precioCompra, precioVenta, cantidadStock, idCategoria )" +
                                            "values (@nombre, @marca, @precioCompra, @precioVenta, @cantidadStock, @idCategoria)";
                    command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = item.nombre; //SQL INJECTIONS
                    command.Parameters.Add("@marca", SqlDbType.NVarChar).Value = item.marca;
                    command.Parameters.Add("@precioCompra", SqlDbType.Float).Value = item.precioCompra;
                    command.Parameters.Add("@precioVenta", SqlDbType.Float).Value = item.precioVenta;
                    command.Parameters.Add("@cantidadStock", SqlDbType.Int).Value = item.cantidadStock;
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
        public bool Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "delete from MateriaPrima where idMateriaPrima=@id";
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

        public bool Update(MateriaPrima item)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"update MateriaPrima 
                                        set nombre=@nombre, marca=@marca, 
                                        precioCompra=@precioCompra, precioVenta=@precioVenta, 
                                        cantidadStock=@cantidadStock, idCategoria=@idCategoria 
                                        where idMateriaPrima=@idMateriaPrima";
                    command.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = item.nombre;
                    command.Parameters.Add("@marca", SqlDbType.NVarChar).Value = item.marca;
                    command.Parameters.Add("@precioCompra", SqlDbType.Float).Value = item.precioCompra;
                    command.Parameters.Add("@precioVenta", SqlDbType.Float).Value = item.precioVenta;
                    command.Parameters.Add("@cantidadStock", SqlDbType.Int).Value = item.cantidadStock;
                    command.Parameters.Add("@idCategoria", SqlDbType.Int).Value = item.idCategoria;
                    command.Parameters.Add("@idMateriaPrima", SqlDbType.Int).Value = item.idMateriaPrima;
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

        public IEnumerable<MateriaPrima> GetAll()
        {
            try
            {
                var list = new List<MateriaPrima>();
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "Select * from MateriaPrima order by idMateriaPrima asc";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new MateriaPrima();
                            item.idMateriaPrima = (int)reader["idMateriaPrima"];
                            item.idCategoria = (int)reader["idCategoria"];
                            item.cantidadStock = (int)reader["cantidadStock"];
                            item.nombre = reader["nombre"].ToString().Trim();
                            item.marca = reader["marca"].ToString().Trim();
                            item.precioCompra = (double)reader["precioCompra"];
                            item.precioVenta = (double)reader["precioVenta"];
                            list.Add(item);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return new List<MateriaPrima>();
            }
        }

        public IEnumerable<MateriaPrima> GetByValue(string value)
        {
            var list = new List<MateriaPrima>();
            try
            {
                int idParametro = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"Select * from MateriaPrima
                                        where idMateriaPrima=@id or nombre like @name+'%' or marca like @name+'%'
                                        order by idMateriaPrima asc";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = idParametro;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = value;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new MateriaPrima();
                            item.idMateriaPrima = (int)reader["idMateriaPrima"];
                            item.idCategoria = (int)reader["idCategoria"];
                            item.cantidadStock = (int)reader["cantidadStock"];
                            item.nombre = reader["nombre"].ToString().Trim();
                            item.marca = reader["marca"].ToString().Trim();
                            item.precioCompra = (double)reader["precioCompra"];
                            item.precioVenta = (double)reader["precioVenta"];
                            list.Add(item);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t----ERROR: " + ex.Message);
                return new List<MateriaPrima>();
            }
        }
    }
}
