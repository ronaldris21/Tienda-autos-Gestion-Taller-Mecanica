using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica.Views.SharedViews
{
    public partial class ProductosPreEnsamblados : Form
    {

        List<ProductoPreEnsamblado> productos;

        public ProductosPreEnsamblados()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);

            TallerMecanicoEntities1 dbContext = new TallerMecanicoEntities1(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;
            productos = dbContext.ProductoPreEnsamblado.ToList(); //LINQ

            //dbContext.Configuration.LazyLoadingEnabled = false;
            //productos = dbContext.ProductoPreEnsamblado
            //    .Select(p=>
            //        new ProductoPreEnsamblado()
            //        {
            //            costoEnsamblado = p.costoEnsamblado,
            //            descripcion = p.descripcion,
            //            idProductoPreEnsamblado = p.idProductoPreEnsamblado
            //        }
            //    ).ToList(); //LINQ

            foreach (ProductoPreEnsamblado item in productos)
            {
                double precio = 0;
                foreach (var materiaCompra in item.MateriaPrima_ProductoPreEnsamblado)
                {
                    precio += materiaCompra.cantidad * materiaCompra.MateriaPrima.precioVenta;
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
                        item.MateriaPrima.marca,
                        item.MateriaPrima.Categoria.nombreCategoria,
                        item.cantidad,
                        item.MateriaPrima.precioCompra,
                        item.MateriaPrima.precioCompra*item.cantidad
                    });
            }
        }
    }
}
