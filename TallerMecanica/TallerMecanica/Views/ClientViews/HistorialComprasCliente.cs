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
using System.Data.Entity;

namespace TallerMecanica.Views.ClientViews
{
    public partial class HistorialComprasCliente : Form
    {
        Cliente cli;
        public HistorialComprasCliente(Cliente c = null)
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            
            if (c == null) //Por defecto muestra las compras del cliente que ha iniciado sesión
                cli = Singleton.cliente_login;
            initDataAsync();

        }

        private async Task initDataAsync()
        {
            ///Performance GOT IT!
            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;
            var productos = await dbContext.ProductoComprado
                                                .Where(c => c.idCliente == cli.idCliente)
                                                .Select(p =>
                                               new 
                                               {
                                                   p = p,
                                                   precioFinal = p.costoEnsamblado + p.MateriaPrima_ProductoComprado.Sum(m=>m.cantidad*m.MateriaPrima.precioVenta)
                                               }
                                                ).ToListAsync();

            foreach (var item in productos)
            {

                this.dataGridView_ProductosComprados.Rows.Add(
                    new object[] {
                        item.p.idProductoComprado.ToString(),
                        item.p.descripcion,
                        item.p.fechaCompra.ToString("yyyy/MM/dd"),
                        item.p.pedidoConfirmado,
                        item.p.costoEnsamblado.ToString() + " €",
                        item.precioFinal.ToString() + " €"
                    });
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_ProductosComprados.SelectedRows.Count < 1)
                return;

            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;
            int idProductoComprado = int.Parse(dataGridView_ProductosComprados.SelectedRows[0].Cells[0].Value.ToString());
            ProductoComprado productoSeleccionado =  dbContext.ProductoComprado.First(p => p.idProductoComprado == idProductoComprado);
            //Exporta el DataGridView de la materia Prima al Excel
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView_MateriaPrimas, productoSeleccionado, dataGridView_ProductosComprados.SelectedRows[0].Cells[5].Value.ToString());
        }

        private void dataGridView_ProductosComprados_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_ProductosComprados.SelectedRows.Count < 1)
                return;

            ReloadSecondaryTable();
        }
        private async Task ReloadSecondaryTable()
        {
            int idProductoComprado = int.Parse(dataGridView_ProductosComprados.SelectedRows[0].Cells[0].Value.ToString());

            dataGridView_MateriaPrimas.Rows.Clear();

            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///CONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;

            var materiasPrimas = await dbContext.MateriaPrima_ProductoComprado.Where(p => p.idProductoComprado == idProductoComprado)
                                                                        .Include(m => m.MateriaPrima)
                                                                        .Include(m => m.MateriaPrima.Categoria).ToListAsync();

            ///Llenar la otra tabla con las materias primas!
            /////Leo las piezas
            foreach (var item in materiasPrimas)
            {
                this.dataGridView_MateriaPrimas.Rows.Add(
                    new object[] {
                        item.MateriaPrima.idMateriaPrima.ToString(),
                        item.MateriaPrima.nombre.Trim(),
                        item.MateriaPrima.material.Trim(),
                        item.MateriaPrima.Categoria.nombreCategoria,
                        item.cantidad,
                        item.precio.ToString() + " €",
                        (item.precio*item.cantidad).ToString() + " €",
                    });
            }
        }

        
    }
}
