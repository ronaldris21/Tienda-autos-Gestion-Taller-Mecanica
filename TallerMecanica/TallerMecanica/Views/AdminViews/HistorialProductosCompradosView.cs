using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.AdminViews
{

    public partial class HistorialProductosCompradosView : Form
    {
        //TODO: Historial por cliente, filtrar por un combobox asi como filtro los objectos por categoria, mostrar todas
        FiltrarPedidos ultimoFiltro;
        ProductoComprado prodSeleccionado;
        public HistorialProductosCompradosView()
        {
            prodSeleccionado = new ProductoComprado();
            InitializeComponent();
            themeColor.Loadtheme(this);
            ultimoFiltro = FiltrarPedidos.sinConfirmar; //Ninguno
            rdbTodos.Checked = true;
        }

        private async Task InitDataAsync(FiltrarPedidos filtro = FiltrarPedidos.todos)
        {
            if (filtro == ultimoFiltro)
            {
                return;
            }
            ///Performance GOT IT!
            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;
            List<consultaProductoComprado> productos;

            switch (filtro)
            {
                case FiltrarPedidos.todos:
                    productos = await dbContext.ProductoComprado
                        .Select(p =>
                        new consultaProductoComprado
                        {
                            p = p,
                            precioFinal = p.costoEnsamblado + p.MateriaPrima_ProductoComprado.Sum(m => m.cantidad * m.MateriaPrima.precioVenta)
                        }
                        ).ToListAsync();
                    break;
                case FiltrarPedidos.confirmados:
                    productos = await dbContext.ProductoComprado
                        .Where(p => p.pedidoConfirmado)
                        .Select(p =>
                        new consultaProductoComprado
                        {
                            p = p,
                            precioFinal = p.costoEnsamblado + p.MateriaPrima_ProductoComprado.Sum(m => m.cantidad * m.MateriaPrima.precioVenta)
                        }
                        ).ToListAsync();
                    break;
                case FiltrarPedidos.sinConfirmar:
                    productos = await dbContext.ProductoComprado
                        .Where(p => !p.pedidoConfirmado)
                        .Select(p =>
                        new consultaProductoComprado
                        {
                            p = p,
                            precioFinal = p.costoEnsamblado + p.MateriaPrima_ProductoComprado.Sum(m => m.cantidad * m.MateriaPrima.precioVenta)
                        }
                        ).ToListAsync();
                    break;
                default:
                    return;
            }

            this.dataGridView_ProductosComprados.Rows.Clear();
            foreach (var item in productos)
            {
                var fechaprevista = item.p.fechaEntregaPrevista != null ? item.p.fechaEntregaPrevista?.ToString("dd/MM/yyyy") : null;
                this.dataGridView_ProductosComprados.Rows.Add(
                    new object[] {
                        item.p.idProductoComprado.ToString(),
                        item.p.pedidoConfirmado,
                        item.p.requiereEnsamblado,
                        item.p.descripcion,
                        item.p.fechaCompra.ToString("dd/MM/yyyy"),
                        fechaprevista,
                        item.p.costoEnsamblado.ToString("N2") + " €",
                        item.precioFinal.ToString("N2") + " €"
                    });
            }
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

            prodSeleccionado = await dbContext.ProductoComprado.FindAsync(idProductoComprado);
            if (prodSeleccionado.fechaEntregaPrevista != null)
            {
                this.dateTimePicker1.Value = (DateTime)prodSeleccionado.fechaEntregaPrevista;
            }
            this.numCostoEnsamblado.Value = (decimal)prodSeleccionado.costoEnsamblado;
            this.txtDescripcion.Text = prodSeleccionado.descripcion.Trim();
            this.checkBoxRequiereEnsamblado.Checked = prodSeleccionado.requiereEnsamblado;



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
                        item.precio.ToString("N2") + " €",
                        (item.precio*item.cantidad).ToString("N2") + " €",
                    });
            }
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            InitDataAsync(FiltrarPedidos.todos);
            ultimoFiltro = FiltrarPedidos.todos;
        }

        private void rdbConfirmados_CheckedChanged(object sender, EventArgs e)
        {
            InitDataAsync(FiltrarPedidos.confirmados);
            ultimoFiltro = FiltrarPedidos.confirmados;
        }

        private void rdbSinConfirmar_CheckedChanged(object sender, EventArgs e)
        {
            InitDataAsync(FiltrarPedidos.sinConfirmar);
            ultimoFiltro = FiltrarPedidos.sinConfirmar;
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
                
            prodSeleccionado.pedidoConfirmado = true;
            prodSeleccionado.descripcion = txtDescripcion.Text.Trim()+ " - Pedido confirmado";
            prodSeleccionado.costoEnsamblado = (double)numCostoEnsamblado.Value;
            prodSeleccionado.fechaEntregaPrevista = dateTimePicker1.Value;
            prodSeleccionado.requiereEnsamblado = checkBoxRequiereEnsamblado.Checked;

            String message = String
                .Format("Confirmar pedido:\n" +
                "Descripción: {0}\n" +
                "Costo Ensamblado: {1} €\n" +
                "Fecha de entrega: {2}",
                prodSeleccionado.descripcion,
                prodSeleccionado.costoEnsamblado,
                prodSeleccionado.fechaCompra.ToString("dd/MMMM/yyyy")
                );

            if (MessageBox.Show(message, "Confirmar pedido", MessageBoxButtons.OKCancel) == DialogResult.No)
                return;


            bool actualizado = new Repositories.dbProducto().UpdateProductoComprado(prodSeleccionado);
            if (actualizado)
            {
                dataGridView_ProductosComprados.SelectedRows[0].Cells[1].Value = prodSeleccionado.pedidoConfirmado;
                dataGridView_ProductosComprados.SelectedRows[0].Cells[2].Value = prodSeleccionado.requiereEnsamblado;
                dataGridView_ProductosComprados.SelectedRows[0].Cells[3].Value = prodSeleccionado.descripcion;
                dataGridView_ProductosComprados.SelectedRows[0].Cells[5].Value = prodSeleccionado.fechaEntregaPrevista;
                dataGridView_ProductosComprados.SelectedRows[0].Cells[6].Value = prodSeleccionado.costoEnsamblado + " €";

                ///Actualizar Precio Total
                string text = dataGridView_ProductosComprados.SelectedRows[0].Cells[7].Value.ToString().Replace("€", "");
                double precioTotalOriginal = double.Parse(text);
                text = dataGridView_ProductosComprados.SelectedRows[0].Cells[6].Value.ToString().Replace("€", "");
                double costoEnsambladoOriginal = double.Parse(text);
                precioTotalOriginal = precioTotalOriginal - costoEnsambladoOriginal + prodSeleccionado.costoEnsamblado;
                dataGridView_ProductosComprados.SelectedRows[0].Cells[7].Value = precioTotalOriginal + " €";

                MessageBox.Show("Se han actualizado los datos del pedido correctamente. También se ha notificado al cliente los cambios", "Pedido actualizado");
            }

        }

        private void checkBoxRequiereEnsamblado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxRequiereEnsamblado.Checked)
            {
                this.numCostoEnsamblado.Enabled = true;
                this.numCostoEnsamblado.Value = (decimal)prodSeleccionado.costoEnsamblado;
            }
            else
            {
                this.numCostoEnsamblado.Enabled = false;
                this.numCostoEnsamblado.Value = 0;
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (this.dataGridView_ProductosComprados.SelectedRows.Count < 1)
                return;

            TallerMecanicoEntities dbContext = new TallerMecanicoEntities(); ///ONSULTAR LA BASE DE DATOS
            dbContext.Configuration.LazyLoadingEnabled = false;
            int idProductoComprado = int.Parse(dataGridView_ProductosComprados.SelectedRows[0].Cells[0].Value.ToString());
            ProductoComprado productoSeleccionado = dbContext.ProductoComprado
                .Where(p => p.idProductoComprado == idProductoComprado)
                .Include(p => p.Cliente)
                .First();
            //Exporta el DataGridView de la materia Prima al Excel
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView_MateriaPrimas, productoSeleccionado, dataGridView_ProductosComprados.SelectedRows[0].Cells["PrecioTotal"].Value.ToString());
        }
    }
}
