using System;
using System.Data.Entity.Validation;
using System.Text;
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

                    if (prod.pedidoConfirmado == false )
                        AvisarAdmin(prod); ///Enviar Email de que se ha creado un pedido sin confirmar!!!

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

                    AvisarCliente(prodNuevo); ///Enviar Email de que se ha actualizado su pedido!!!

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

        private string ObtenerEmailCliente(int idCliente)
        {
            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities()) //DISPOSABLE
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                return dbContext.Cliente.Find(idCliente).email;
            }
        }
        private void AvisarAdmin(ProductoComprado prod)
        {
            string error=null;
            String email = ObtenerEmailCliente(prod.idCliente);
            String message = String.Format(
                "Calcular costo del ensamblado del pedido:\n" +
                "Descripción: {0}\n" +
                "Costo Ensamblado: {1} €\n" +
                "Fecha de entrega: {2}",
                prod.descripcion,
                prod.costoEnsamblado,
                prod.fechaCompra.ToString("dd/MMMM/yyyy")
                ); 

            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append(message);
            Singleton.EnviarCorreo(MensajeBuilder, DateTime.Now, Singleton.emailUsuarioSistema, "Pedido nuevo - Revisar y confirmar", out error);
            
        }

        private void AvisarCliente(ProductoComprado prod)
        {
            string error = null;
            String email = ObtenerEmailCliente(prod.idCliente);
            String message = String.Format(
                "Detalles del pedido solicitado:\n" +
                "Descripción: {0}\n" +
                "Costo Ensamblado: {1} €\n" +
                "Fecha de entrega: {2}",
                prod.descripcion,
                prod.costoEnsamblado,
                prod.fechaCompra.ToString("dd/MMMM/yyyy")
                );

            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append(message);
            Singleton.EnviarCorreo(MensajeBuilder, DateTime.Now, email, "Confirmación del pedido - presupuesto y fecha de entrega", out error);

        }
    }
}
