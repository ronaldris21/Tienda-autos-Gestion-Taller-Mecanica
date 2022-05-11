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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.ClientViews
{
    public partial class HistorialComprasCliente : Form
    {
        public HistorialComprasCliente()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);

            Singleton.cliente_login.idCliente = 2;

            TallerMecanicoEntities1 dbContext = new TallerMecanicoEntities1(); ///ONSULTAR LA BASE DE DATOS
            List<ProductoComprado> productos = dbContext.ProductoComprado
                                                .Where(c => c.idCliente == Singleton.cliente_login.idCliente)
                                                .ToList(); //LINQ

            foreach (ProductoComprado item in productos)
            {
                double precio = 0;
                foreach (var materiaCompra in item.MateriaPrima_ProductoComprado)
                {
                    precio += materiaCompra.cantidad * materiaCompra.MateriaPrima.precioVenta;
                }

                this.dataGridView_ProductosComprados.Rows.Add(
                    new object[] {
                        item.idProductoComprado.ToString(),
                        item.descripcion,
                        item.fechaCompra.ToString("yyyy/MM/dd"),
                        item.pedidoConfirmado,
                        item.costoEnsamblado.ToString(),
                        precio
                    }) ;
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_ProductosComprados.SelectedRows.Count < 1)
                return;


            int idProductoComprado = int.Parse(dataGridView_ProductosComprados.SelectedRows[0].Cells[0].Value.ToString());

            dataGridView_MateriaPrimas.Rows.Clear();

            TallerMecanicoEntities1 dbContext = new TallerMecanicoEntities1(); ///ONSULTAR LA BASE DE DATOS

            List<MateriaPrima_ProductoComprado> materiasPrimas = dbContext.MateriaPrima_ProductoComprado
                                            .Where(o => o.idProductoComprado == idProductoComprado)
                                            .ToList();

            ///Llenar la otra tabla con las materias primas!
            /////Leo las piezas
            foreach (MateriaPrima_ProductoComprado item in materiasPrimas)
            {
                this.dataGridView_MateriaPrimas.Rows.Add(
                    new object[] {
                        item.idMateriaPrima.ToString(), 
                        item.MateriaPrima.nombre,
                        item.MateriaPrima.marca,
                        item.cantidad,
                        item.MateriaPrima.Categoria.nombreCategoria,
                        item.MateriaPrima.precioVenta
                    });
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            //Exporta el DataGridView de la materia Prima al Excel
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView_MateriaPrimas);
        }
    }
}
