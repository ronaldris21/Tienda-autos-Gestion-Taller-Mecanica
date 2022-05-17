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
    public partial class CarritoComprasView : Form
    {
        double precioFinal = 0;
        List<Categoria> categorias;
        String todasLasCategorias = "Todas";
        string lastKeyWord = "";
        public CarritoComprasView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            initDataAsync();

            ///Activa/ desactiva funciones especificas solo del admin
            checkBoxConsumidorFinal.Visible = Singleton.cliente_login.isAdmin;
            checkBoxConsumidorFinal.Enabled = Singleton.cliente_login.isAdmin;
            btnCrearProductoPreEnsamblado.Visible = Singleton.cliente_login.isAdmin;
            btnCrearProductoPreEnsamblado.Enabled = Singleton.cliente_login.isAdmin;
            comboBoxClientes.Enabled = Singleton.cliente_login.isAdmin;
            comboBoxClientes.Visible = Singleton.cliente_login.isAdmin;


            lblCostoEnsamblado.Visible = Singleton.cliente_login.isAdmin;
            lblClienteCompra.Visible = Singleton.cliente_login.isAdmin;
            lblFechaEntrega.Visible = Singleton.cliente_login.isAdmin;
            dateTimePicker1.Visible = Singleton.cliente_login.isAdmin;
            dateTimePicker1.Enabled = Singleton.cliente_login.isAdmin;
            numCostoEnsamblado.Visible = Singleton.cliente_login.isAdmin;
            numCostoEnsamblado.Enabled = Singleton.cliente_login.isAdmin;

            this.checkBoxEnsamblado.Checked = true;
            this.checkBoxEnsamblado.Checked = false;



        }
        private void UpdatePrecioFinal()
        {
            double precioF = precioFinal +(double) this.numCostoEnsamblado.Value;
            this.lblTotal.Text = "Precio total: " + precioF.ToString() + " €";
        }
        private void LoadMateriasPrimasSeleccionadas()
        {
            this.dataGridView2.Rows.Clear();
            precioFinal = 0;
            foreach (var item in Singleton.MaterialesComprados)
            {



                this.dataGridView2.Rows.Add(
                    new object[] {
                            item.idMateriaPrima.ToString(),
                            item.MateriaPrima.nombre.Trim(),
                            item.MateriaPrima.material.Trim(),
                            item.MateriaPrima.Categoria.nombreCategoria.Trim(),
                            item.precio,
                            item.cantidad,
                            "  -  ",
                            "  +  ",
                            item.precio*item.cantidad
                    });
                precioFinal += item.precio * item.cantidad;
            }
            UpdatePrecioFinal();
        }

        private async Task initDataAsync()
        {
            TallerMecanicoEntities dbContext = new TallerMecanicoEntities();
            dbContext.Configuration.LazyLoadingEnabled = false;

            categorias = await dbContext.Categoria.ToListAsync(); ///Load data async without stopping main thread
                                                                  ///Agreggo las categorias al comboBox
            cbxCategorias.Items.Add(todasLasCategorias); ///Identificador de llamadar todas las categorias
            cbxCategorias.Items.AddRange(categorias.Select(C => C.nombreCategoria).ToArray());
            cbxCategorias.SelectedItem = todasLasCategorias;

            var clientes = await dbContext.Cliente.ToListAsync();
            comboBoxClientes.Items.AddRange(clientes.Select(c => c.nombreCompleto).OrderBy(c => c).ToArray());


            var Materias = await dbContext.MateriaPrima.ToListAsync();

            Materias.ForEach(m =>
            {
                categorias.First(c => c.idCategoria == m.idCategoria).MateriaPrima.Add(m);
            });

            dataGridView1.Rows.Clear();
            foreach (Categoria cate in categorias)
            {
                foreach (var item in cate.MateriaPrima)
                {

                    this.dataGridView1.Rows.Add(
                        new object[] {
                            item.idMateriaPrima.ToString(),
                            item.nombre.Trim() ,
                            item.material.Trim(),
                            item.Categoria.nombreCategoria.Trim(),
                            item.precioVenta,
                            "Comprar"
                        });
                }
            }

            LoadMateriasPrimasSeleccionadas();

        }

        public void FilterDataByKeyWord(String KeyWord = "")
        {

            String SelectedCate = cbxCategorias.SelectedItem.ToString();
            KeyWord = txtPieza.Text.ToLower();
            dataGridView1.Rows.Clear();

            foreach (Categoria cate in categorias)
            {
                if (todasLasCategorias == SelectedCate || cate.nombreCategoria == SelectedCate) //Valido ComboBox
                {
                    foreach (var item in cate.MateriaPrima)
                    {
                        if (String.IsNullOrEmpty(KeyWord) || item.nombre.ToLower().Contains(KeyWord)) //Valido texto en Busca
                        {

                            this.dataGridView1.Rows.Add(
                            new object[] {
                                item.idMateriaPrima.ToString(),
                                item.nombre.Trim() ,
                                item.material.Trim(),
                                item.Categoria.nombreCategoria.Trim(),
                                item.precioVenta,
                                "Comprar"
                            });
                        }
                    }
                }
            }
        }

        private void cbxCategorias_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterDataByKeyWord(txtPieza.Text);
        }

        private void txtPieza_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPieza.Text != lastKeyWord)
            {
                lastKeyWord = txtPieza.Text;
                FilterDataByKeyWord(txtPieza.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) //Invalid Row
                return;

            if (e.ColumnIndex != 5) //Button Clicked
                return;

            int idSelected = int.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //Revisar si ya esta en el array de abajo
            MateriaPrima_ProductoComprado itemSelected = Singleton.MaterialesComprados
                                                                    .FirstOrDefault(p => p.idMateriaPrima == idSelected);
            if (itemSelected == null)
            {
                itemSelected = new MateriaPrima_ProductoComprado();
                itemSelected.cantidad = 1;
                itemSelected.idMateriaPrima = idSelected;
                foreach (var cate in categorias)
                {
                    foreach (var mate in cate.MateriaPrima)
                    {
                        if (idSelected == mate.idMateriaPrima)
                        {
                            itemSelected.precio = mate.precioVenta;
                            itemSelected.MateriaPrima = new MateriaPrima();
                            itemSelected.MateriaPrima.nombre = mate.nombre;
                            itemSelected.MateriaPrima.material = mate.material;
                            itemSelected.MateriaPrima.Categoria = new Categoria();
                            itemSelected.MateriaPrima.Categoria.nombreCategoria = mate.Categoria.nombreCategoria;
                            Singleton.MaterialesComprados.Insert(0, itemSelected);
                            LoadMateriasPrimasSeleccionadas();
                            return;
                        }

                    }
                }


            }
            else
            {
                itemSelected.cantidad++;
                LoadMateriasPrimasSeleccionadas();
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) //Invalid Row
                return;

            if (!(e.ColumnIndex == 6 || e.ColumnIndex == 7)) //Button Clicked
                return;

            int idSelected = int.Parse(this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            var item = Singleton.MaterialesComprados.Where(m => m.idMateriaPrima == idSelected).FirstOrDefault();

            if (e.ColumnIndex == 6)// MINUS
            {
                if (item.cantidad > 1)
                {
                    item.cantidad--;
                    precioFinal -= item.precio;

                    ///Actualizo las filas
                    this.dataGridView2.Rows[e.RowIndex].Cells[5].Value = item.cantidad;
                    this.dataGridView2.Rows[e.RowIndex].Cells[8].Value = item.cantidad * item.precio;

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("¿Desea quitar el material del carrito de compras?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        precioFinal -= item.precio;

                        Singleton.MaterialesComprados.Remove(item);
                        this.dataGridView2.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            if (e.ColumnIndex == 7)
            {
                item.cantidad++;
                precioFinal += item.precio;

                ///Actualizo las filas
                this.dataGridView2.Rows[e.RowIndex].Cells[5].Value = item.cantidad;
                this.dataGridView2.Rows[e.RowIndex].Cells[8].Value = item.cantidad * item.precio;
            }
            UpdatePrecioFinal();

        }

        private void btnCrearProductoPreEnsamblado_Click(object sender, EventArgs e)
        {
            if (Singleton.MaterialesComprados.Count == 0)
            {
                MessageBox.Show("Elija los materiales primero");
                return;
            }

            ProductoPreEnsamblado producto = new ProductoPreEnsamblado();
            producto.costoEnsamblado = (double)numCostoEnsamblado.Value;
            producto.descripcion = txtDescripcion.Text;

            if (MessageBox.Show(lblTotal.Text +
                                "\nCosto de emsamblado: " + producto.costoEnsamblado.ToString() + " €"+
                                "\n\n¿Aceptar?", "Guardar como Producto Preensamblado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var item in Singleton.MaterialesComprados)
                {
                    producto.MateriaPrima_ProductoPreEnsamblado
                        .Add(
                            new MateriaPrima_ProductoPreEnsamblado()
                            {
                                cantidad = item.cantidad,
                                idMateriaPrima = item.idMateriaPrima
                            });
                }

                

                bool succed = new Repositories.dbProducto().InsertProductoEnsamblado(producto);
                if (succed)
                {
                    MessageBox.Show("Producto Pre Ensamblado almacenado realizada con exito", "Confirmación de producto pre ensamblado");
                    Singleton.MaterialesComprados = new List<MateriaPrima_ProductoComprado>();
                }
            }
        }

        //TODO: COPY ON Productos PreEnsamblados
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (Singleton.MaterialesComprados.Count == 0)
            {
                MessageBox.Show("Elija los materiales primero");
                return;
            }


            if (MessageBox.Show(lblTotal.Text + "\n¿Aceptar?", "Confirmación de pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Hacer Compra
                ProductoComprado compra = new ProductoComprado();
                if (Singleton.cliente_login.isAdmin)
                {
                    if (checkBoxConsumidorFinal.Checked)
                    {
                        compra.idCliente = 1; //Consumidor Final
                    }
                    else if (Singleton.cliente_login.isAdmin)
                    {
                        ///Sacar del combobox el id
                        using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities())
                        {
                            dbContext.Configuration.LazyLoadingEnabled = false;
                            if (this.comboBoxClientes.SelectedItem == null)
                            {
                                MessageBox.Show("Elige el cliente al que le asignaras la compra", "Elige un cliente");
                                return;
                            }
                            String nombreCompleto = this.comboBoxClientes.SelectedItem.ToString();
                            compra.idCliente = dbContext.Cliente.Where(c => c.nombreCompleto == nombreCompleto)
                                                                .First().idCliente;
                        }
                    }
                }
                else //Cliente normal
                {
                    compra.idCliente = Singleton.cliente_login.idCliente;
                }

                if (this.checkBoxEnsamblado.Checked)///Con emsamblado
                    MessageBox.Show("Has seleccionado pedido con ensamblado \n\nPosteriormente recibiras un correo con la fecha prevista de entrega y el costo de ensamblado por parte del mecánico", "Con Ensamblado");


                compra.fechaCompra = DateTime.Now;
                compra.fechaEntregaPrevista = dateTimePicker1.Value;

                compra.requiereEnsamblado = this.checkBoxEnsamblado.Checked;
                compra.pedidoConfirmado = !this.checkBoxEnsamblado.Checked;
                compra.costoEnsamblado = (double)numCostoEnsamblado.Value;

                String stadoPedido = this.checkBoxEnsamblado.Checked ? "Esperando Confirmacion del mecánico" : "Pedido entregado al instante";
                compra.pedidoConfirmado = !this.checkBoxEnsamblado.Checked;
                if (this.checkBoxEnsamblado.Checked && numCostoEnsamblado.Value > 0)
                {
                    stadoPedido = "Pedido Confirmado";
                    compra.pedidoConfirmado = true;
                }

                compra.descripcion = txtDescripcion.Text + " - "+ stadoPedido;

                foreach (var item in Singleton.MaterialesComprados)
                {
                    item.MateriaPrima = null;
                    compra.MateriaPrima_ProductoComprado.Add(item);
                }

                bool succed = new Repositories.dbProducto().InsertProductoComprado(compra);
                if (succed)
                    MessageBox.Show("Compra realizada con exito", "Confirmación de compra");

                Singleton.MaterialesComprados = new List<MateriaPrima_ProductoComprado>();
            }

        }

        private void checkBoxConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxClientes.Enabled = !this.checkBoxConsumidorFinal.Checked;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxEnsamblado_CheckedChanged(object sender, EventArgs e)
        {
            numCostoEnsamblado.Enabled = this.checkBoxEnsamblado.Checked;
            numCostoEnsamblado.Value = this.checkBoxEnsamblado.Checked ? 25 : 0;
        }

        private void numCostoEnsamblado_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrecioFinal();
        }
    }
}
