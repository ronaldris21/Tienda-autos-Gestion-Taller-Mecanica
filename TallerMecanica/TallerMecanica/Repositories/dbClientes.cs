

namespace TallerMecanica.Repositories
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TallerMecanica.Models;
    public class dbClientes
    {
        public Cliente Login(string email, string pass)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                try
                {
                    var cliente = dbContext.Cliente.Where(c => c.email == email && c.contrasena == pass)
                                                    .FirstOrDefault();
                    return cliente;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validations in ex.EntityValidationErrors)
                    {
                        foreach (var error in validations.ValidationErrors)
                        {
                            Console.WriteLine("ERROR - ENTITY ----" + error.ErrorMessage);
                        }
                    }
                    return null;
                }
            }
        }
        public bool Update(Cliente client)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var cliente = dbContext.Cliente.Where(c => c.idCliente == client.idCliente).FirstOrDefault();
                    if (cliente == null)
                        return false;

                    cliente.nombreCompleto = client.nombreCompleto;
                    cliente.email = client.email;
                    cliente.telefono1 = client.telefono1;
                    cliente.telefono2 = client.telefono2;
                    cliente.contrasena = client.contrasena;
                    cliente.isAdmin = client.isAdmin;

                    dbContext.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validations in ex.EntityValidationErrors)
                    {
                        foreach (var error in validations.ValidationErrors)
                        {
                            Console.WriteLine("ERROR - ENTITY ----" + error.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }   

        public bool Insert(Cliente client)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var cliente = dbContext.Cliente.Add(client);
                    dbContext.SaveChanges();

                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validations in ex.EntityValidationErrors)
                    {
                        foreach (var error in validations.ValidationErrors)
                        {
                            Console.WriteLine("ERROR - ENTITY ----" + error.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var cliente = dbContext.Cliente.Where(c => c.idCliente == id).FirstOrDefault();
                    if (cliente == null)
                        return false;

                    dbContext.Cliente.Remove(cliente);
                    dbContext.SaveChanges();

                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validations in ex.EntityValidationErrors)
                    {
                        foreach (var error in validations.ValidationErrors)
                        {
                            Console.WriteLine("ERROR - ENTITY ----" + error.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }

    }
}
