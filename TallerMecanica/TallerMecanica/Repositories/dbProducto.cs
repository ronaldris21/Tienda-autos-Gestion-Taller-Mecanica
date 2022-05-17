using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanica.Models;

namespace TallerMecanica.Repositories
{
    public class dbProducto
    {


        public bool InsertProductoComprado(ProductoComprado prod)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
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

        public bool InsertProductoEnsamblado(ProductoPreEnsamblado prod)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    dbContext.ProductoPreEnsamblado.Add(prod);
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

        public bool UpdateProductoComprado(ProductoComprado prodNuevo)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                try
                {
                    var prod = dbContext.ProductoComprado.Find(prodNuevo.idProductoComprado);
                    if (prod == null)
                        return false;

                    prod.descripcion = prodNuevo.descripcion;
                    prod.fechaEntregaPrevista = prodNuevo.fechaEntregaPrevista;
                    prod.requiereEnsamblado = prodNuevo.requiereEnsamblado;
                    prod.pedidoConfirmado = prodNuevo.pedidoConfirmado;
                    prod.costoEnsamblado = prodNuevo.costoEnsamblado;

                    dbContext.Entry(prod).State = System.Data.Entity.EntityState.Modified;
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
