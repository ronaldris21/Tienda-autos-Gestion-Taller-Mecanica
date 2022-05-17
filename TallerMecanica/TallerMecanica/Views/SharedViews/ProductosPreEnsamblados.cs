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
            productos = dbContext.ProductoPreEnsamblado.ToList(); //LINQ

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



        }
    }
}
