using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanica.Models;

namespace TallerMecanica.Repositories
{
    public class dbMateriaPrima
    {
        public bool Update(MateriaPrima item)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var MateriaPrima = dbContext.MateriaPrima.Where(c => c.idMateriaPrima == item.idMateriaPrima).FirstOrDefault();
                    if (MateriaPrima == null)
                        return false;

                    MateriaPrima.nombre = item.nombre;
                    MateriaPrima.material = item.material;
                    MateriaPrima.precioCompra = item.precioCompra;
                    MateriaPrima.precioVenta = item.precioVenta;
                    MateriaPrima.cantidadStock = item.cantidadStock;
                    MateriaPrima.idCategoria = item.idCategoria;

                    dbContext.Entry(MateriaPrima).State = System.Data.Entity.EntityState.Modified;
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

        public bool Insert(MateriaPrima item)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var MateriaPrima = dbContext.MateriaPrima.Add(item);
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
                    var MateriaPrima = dbContext.MateriaPrima.Where(c => c.idMateriaPrima == id).FirstOrDefault();
                    if (MateriaPrima == null)
                        return true; //Porque ya lo elimino xD

                    dbContext.MateriaPrima.Remove(MateriaPrima);
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
