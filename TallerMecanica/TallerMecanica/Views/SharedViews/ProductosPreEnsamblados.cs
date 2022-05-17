using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica.Views.SharedViews
{
    public partial class ProductosPreEnsamblados : Form
    {
        List<MateriaPrima_ProductoPreEnsamblado> datos;
        List<ProductoPreEnsamblado> productos;

        public ProductosPreEnsamblados()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);

            initDataAsyn();

        }

        private async Task initDataAsyn()
        {
            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;

            try
            {
                List<MateriaPrima_ProductoPreEnsamblado> items = await dbContext.MateriaPrima_ProductoPreEnsamblado
                                .Include(m => m.MateriaPrima)
                                .Include(m => m.MateriaPrima.Categoria)
                                .ToListAsync();

                productos = await dbContext.ProductoPreEnsamblado
                                    .Include(p => p.MateriaPrima_ProductoPreEnsamblado)
                                    .ToListAsync();

                foreach (var item in productos)
                {
                    double precio = 0;
                    foreach (var materiaCompra in item.MateriaPrima_ProductoPreEnsamblado)
                    {
                        var dato = items.Where(m => materiaCompra.idMateriaPrima == m.idMateriaPrima).First();
                        precio += dato.cantidad * dato.MateriaPrima.precioVenta;
                    }

                    precio += item.costoEnsamblado;



                    this.dataGridView_ProductosPreensamblados.Rows.Add(
                        new object[] {
                        item.idProductoPreEnsamblado.ToString(),
                        item.descripcion,
                        item.costoEnsamblado.ToString(),
                        precio
                        });
                }

                ///Lleno datos del primero

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView_ProductosPreensamblados_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_ProductosPreensamblados.SelectedRows.Count < 1)
                return;

            ProductoPreEnsamblado prodSelected = productos[dataGridView_ProductosPreensamblados.SelectedRows[0].Index];

            int idProductoComprado = int.Parse(dataGridView_ProductosPreensamblados.SelectedRows[0].Cells[0].Value.ToString());

            dataGridView_MateriaPrimas.Rows.Clear();

            ///Llenar la otra tabla con las materias primas!
            /////Leo las piezas
            foreach (MateriaPrima_ProductoPreEnsamblado item in prodSelected.MateriaPrima_ProductoPreEnsamblado)
            {
                this.dataGridView_MateriaPrimas.Rows.Add(
                    new object[] {
                        item.idMateriaPrima.ToString(),
                        item.MateriaPrima.nombre,
                        item.MateriaPrima.material,
                        item.MateriaPrima.Categoria.nombreCategoria,
                        item.cantidad,
                        item.MateriaPrima.precioCompra,
                        item.MateriaPrima.precioCompra*item.cantidad
                    });
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_MateriaPrimas.SelectedRows.Count < 1)
                return;

            string descripcion = this.dataGridView_ProductosPreensamblados.SelectedRows[0].Cells[1].Value.ToString().Trim();
            string precio = this.dataGridView_ProductosPreensamblados.SelectedRows[0].Cells[3].Value.ToString().Trim() + " €";
            string message = "Está a punto de comprar:\n\n" + descripcion + "\nPrecio: " + precio +"\n\nConfirmar";

            if (MessageBox.Show(message, "Compra", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            int IdProductoPreensamblado = int.Parse(this.dataGridView_ProductosPreensamblados.SelectedRows[0].Cells[0].Value.ToString());

            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                try
                {
                    var productoSeleccionado = dbContext.ProductoPreEnsamblado
                                                .Where(m => m.idProductoPreEnsamblado == IdProductoPreensamblado)
                                                .First();
                    List<MateriaPrima_ProductoPreEnsamblado> items = dbContext.MateriaPrima_ProductoPreEnsamblado
                                                .Where(m => m.idProductoPreEnsamblado == IdProductoPreensamblado)
                                                .Include(m => m.MateriaPrima)
                                                .ToList();

                    ProductoComprado compra = new ProductoComprado();

                    compra.descripcion = productoSeleccionado.descripcion;
                    compra.costoEnsamblado = productoSeleccionado.costoEnsamblado;
                    compra.fechaEntregaPrevista = DateTime.Now;
                    compra.pedidoConfirmado = true;
                    compra.fechaCompra = DateTime.Now;

                    foreach (MateriaPrima_ProductoPreEnsamblado item in items)
                    {
                        compra.MateriaPrima_ProductoComprado
                            .Add(
                                new MateriaPrima_ProductoComprado()
                                {
                                    cantidad = item.cantidad,
                                    idMateriaPrima = item.idMateriaPrima,
                                    precio = item.MateriaPrima.precioVenta
                                }
                            );
                    }



                    //Finalmente asignamos el cliente que ha hecho la compra:
                    compra.idCliente = Singleton.cliente_login.idCliente;

                    bool wasAdded = new Repositories.dbProducto().InsertProductoComprado(compra);
                    if (wasAdded)
                        MessageBox.Show("Compra realizada con exito", "Compra");
                    else
                        MessageBox.Show("No fue posible guardar la compra, revisa tu conexión a internet o intenta nuevamente", "Error");

                    ///Lleno datos del primero

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            ///Compra para el mismo como cliente!!!



        }
    }
}
