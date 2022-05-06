using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanica.Models;

namespace TallerMecanica.Repositories
{
    public class dbProductoComprado
    {

        /// <summary>
        /// Insertando en Multiples tablas
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="items"></param>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public bool Insert(ProductoComprado prod, List<MateriaPrima_ProductoComprado> items, int idCliente)
        {
            using (TallerMecanicoEntities1 dbContext = new TallerMecanicoEntities1()) //DISPOSABLE
            {
                try
                {
                    prod.MateriaPrima_ProductoComprado = new List<MateriaPrima_ProductoComprado>(items);
                    prod.idCliente = idCliente;

                    dbContext.ProductoComprado.Add(prod);
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
