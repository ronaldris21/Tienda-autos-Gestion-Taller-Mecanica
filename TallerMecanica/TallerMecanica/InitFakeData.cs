using Bogus;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica
{
    class InitFakeData
    {

        public InitFakeData() { }
        //Fin del constructor

        public async Task InitDataOnServerAsync()
        {
            Models.TallerMecanicoEntities dbContext = new TallerMecanicoEntities();

            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            //var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            //var orderIds = 0;
            //var testOrders = new Faker<ProductoComprado>()
            //    //Ensure all properties have rules. By default, StrictMode is false
            //    //Set a global policy by using Faker.DefaultStrictMode
            //    .StrictMode(true)
            //    //OrderId is deterministic
            //    .RuleFor(o => o.idProductoComprado, f => orderIds++)
            //    //Pick some fruit from a basket
            //    .RuleFor(o => o.Item, f => f.PickRandom(fruit))
            //    //A random quantity from 1 to 10
            //    .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
            //    //A nullable int? with 80% probability of being null.
            //    //The .OrNull extension is in the Bogus.Extensions namespace.
            //    .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));


            var FakerUsers = new Faker<Cliente>()
            .RuleFor(u => u.profilePic, f => f.Internet.Avatar())
            .RuleFor(u => u.nombreCompleto, (f, u) => f.Name.FullName())
            .RuleFor(u => u.email, (f, u) => f.Internet.Email(u.nombreCompleto))
            .RuleFor(u => u.telefono1, f => f.Random.Number(50000000, 500000000).ToString())
            .RuleFor(u => u.telefono2, f => f.Random.Number(50000000, 500000000).ToString())
            .RuleFor(u => u.contrasena, (f, u) => f.Internet.Password(length: 8, memorable: true))
            .RuleFor(u => u.isAdmin, f => false);

            var FakerMateriales = new Faker<MateriaPrima>()
                .RuleFor(o => o.cantidadStock, f => f.Random.Number(1, 150))
                .RuleFor(o => o.idCategoria, f => f.Random.ArrayElement<int>(dbContext.Categoria.Select(c => c.idCategoria).ToArray()))
                .RuleFor(o => o.material, f => f.Commerce.ProductMaterial())
                .RuleFor(o => o.nombre, f => f.Commerce.ProductName())
                .RuleFor(o => o.precioVenta, (f, o) => o.precioVenta + Math.Round(f.Random.Double(25, 500), 2))
                .RuleFor(o => o.precioCompra, (f, o) => o.precioCompra + Math.Round(f.Random.Double(25, 500), 2))
                ;

            var FakerProductosCompra = new Faker<ProductoComprado>()
                .RuleFor(o => o.descripcion, f => f.Commerce.ProductDescription().Substring(0, 50))
                .RuleFor(o => o.idCliente, f => f.Random.ArrayElement<int>(dbContext.Cliente.Select(c => c.idCliente).ToArray()))
                .RuleFor(o => o.fechaCompra, f => f.Date.Past())
                .RuleFor(o => o.fechaEntregaPrevista, f => f.Date.Past())
                .RuleFor(o => o.costoEnsamblado, f => Math.Round(f.Random.Double(25, 500), 2))
                .RuleFor(o => o.requiereEnsamblado, f => true)
                .RuleFor(o => o.pedidoConfirmado, f => f.Random.Bool())
                ;

            var FakerProductosEnsamblados = new Faker<ProductoPreEnsamblado>()
                .RuleFor(o => o.descripcion, f => f.Commerce.ProductDescription().Substring(0, 50))
                .RuleFor(o => o.costoEnsamblado, f => Math.Round(f.Random.Double(25, 500), 2))
            ;

            var FakerItemProductoComprado = new Faker<MateriaPrima_ProductoComprado>()
                .RuleFor(o => o.idMateriaPrima, f => f.Random.ArrayElement<int>(dbContext.MateriaPrima.Select(c => c.idMateriaPrima).ToArray()))
                .RuleFor(o => o.idProductoComprado, f => f.Random.ArrayElement<int>(dbContext.ProductoComprado.Select(c => c.idProductoComprado).ToArray()))
                .RuleFor(o => o.cantidad, f => f.Random.Number(1, 5))
                .RuleFor(o => o.precio, f => Math.Round(f.Random.Double(25, 500), 2))
                ;

            var FakerItemProductoPreEnsamblados = new Faker<MateriaPrima_ProductoPreEnsamblado>()
                .RuleFor(o => o.idMateriaPrima, f => f.Random.ArrayElement<int>(dbContext.MateriaPrima.Select(c => c.idMateriaPrima).ToArray()))
                .RuleFor(o => o.idProductoPreEnsamblado, f => f.Random.ArrayElement<int>(dbContext.ProductoPreEnsamblado.Select(c => c.idProductoPreEnsamblado).ToArray()))
                .RuleFor(o => o.cantidad, f => f.Random.Number(1, 5))
                ;

            var FakerCategorias = new Faker<Categoria>()
                .RuleFor(o => o.cantidadCocheCompleto, f => f.Random.Number(1, 5))
                .RuleFor(o => o.nombreCategoria, f => f.Commerce.Categories(1)[0])
                ;

            foreach (var user in FakerUsers.Generate(5))
            {

                try
                {
                    Console.WriteLine(user);
                    dbContext.Cliente.Add(user);
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
                }
            }
            await dbContext.SaveChangesAsync();

            foreach (var item in FakerProductosCompra.Generate(20))
            {

                try ///Add, Update, Remove
                {
                    Console.WriteLine(item);
                    dbContext.ProductoComprado.Add(item);
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
                }
            }
            dbContext.SaveChanges();

            foreach (var item in FakerProductosEnsamblados.Generate(12))
            {
                try
                {
                    Console.WriteLine(item);
                    dbContext.ProductoPreEnsamblado.Add(item);

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
                }
            }
            try
            {
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //foreach (var item in FakerCategorias.Generate(10))
            //{

            //    try
            //    {
            //        Console.WriteLine(item);
            //        dbContext.Categoria.Add(item);
            //    }
            //    catch (DbEntityValidationException ex)
            //    {
            //        foreach (var validations in ex.EntityValidationErrors)
            //        {
            //            foreach (var error in validations.ValidationErrors)
            //            {
            //                Console.WriteLine("ERROR - ENTITY ----" + error.ErrorMessage);
            //            }
            //        }
            //    }
            //}
            //await dbContext.SaveChangesAsync();

            foreach (var item in FakerMateriales.Generate(100))
            {
                try
                {
                    Console.WriteLine(item);
                    dbContext.MateriaPrima.Add(item);
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
                }
            }
            await dbContext.SaveChangesAsync();

            foreach (var item in FakerItemProductoComprado.Generate(100))
            {

                try
                {
                    Console.WriteLine(item);
                    dbContext.MateriaPrima_ProductoComprado.Add(item);
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
                }
            }
            await dbContext.SaveChangesAsync();

            foreach (var item in FakerItemProductoPreEnsamblados.Generate(100))
            {

                try
                {
                    Console.WriteLine(item);
                    dbContext.MateriaPrima_ProductoPreEnsamblado.Add(item);
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
                }
            }
            await dbContext.SaveChangesAsync();

            MessageBox.Show("Datos cargados correctamente a la base de datos");

        }
    }
}
