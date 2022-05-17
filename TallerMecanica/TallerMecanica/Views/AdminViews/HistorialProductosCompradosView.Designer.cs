
namespace TallerMecanica.Views.AdminViews
{
    partial class HistorialProductosCompradosView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFactura = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ProductosComprados = new System.Windows.Forms.DataGridView();
            this.dataGridView_MateriaPrimas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.lblCostoEnsamblado = new System.Windows.Forms.Label();
            this.numCostoEnsamblado = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbConfirmados = new System.Windows.Forms.RadioButton();
            this.rdbSinConfirmar = new System.Windows.Forms.RadioButton();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoConfirmado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ensamblado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosteEnsamblado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxRequiereEnsamblado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosComprados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoEnsamblado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(811, 397);
            this.btnFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(131, 73);
            this.btnFactura.TabIndex = 12;
            this.btnFactura.Text = "Generar Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 294);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Materiales de la compra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Productos compras";
            // 
            // dataGridView_ProductosComprados
            // 
            this.dataGridView_ProductosComprados.AllowUserToAddRows = false;
            this.dataGridView_ProductosComprados.AllowUserToDeleteRows = false;
            this.dataGridView_ProductosComprados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_ProductosComprados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ProductosComprados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProductosComprados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCompra,
            this.PedidoConfirmado,
            this.Ensamblado,
            this.Descripcion,
            this.FechaCompra,
            this.Fecha_entrega,
            this.CosteEnsamblado,
            this.PrecioTotal});
            this.dataGridView_ProductosComprados.Location = new System.Drawing.Point(17, 115);
            this.dataGridView_ProductosComprados.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_ProductosComprados.MultiSelect = false;
            this.dataGridView_ProductosComprados.Name = "dataGridView_ProductosComprados";
            this.dataGridView_ProductosComprados.ReadOnly = true;
            this.dataGridView_ProductosComprados.RowHeadersWidth = 51;
            this.dataGridView_ProductosComprados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProductosComprados.Size = new System.Drawing.Size(925, 167);
            this.dataGridView_ProductosComprados.TabIndex = 9;
            this.dataGridView_ProductosComprados.SelectionChanged += new System.EventHandler(this.dataGridView_ProductosComprados_SelectionChanged);
            // 
            // dataGridView_MateriaPrimas
            // 
            this.dataGridView_MateriaPrimas.AllowUserToAddRows = false;
            this.dataGridView_MateriaPrimas.AllowUserToDeleteRows = false;
            this.dataGridView_MateriaPrimas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MateriaPrimas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nombre,
            this.Material,
            this.Categoria,
            this.Cantidad,
            this.Precio,
            this.Subtototal});
            this.dataGridView_MateriaPrimas.Location = new System.Drawing.Point(17, 321);
            this.dataGridView_MateriaPrimas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_MateriaPrimas.MultiSelect = false;
            this.dataGridView_MateriaPrimas.Name = "dataGridView_MateriaPrimas";
            this.dataGridView_MateriaPrimas.ReadOnly = true;
            this.dataGridView_MateriaPrimas.RowHeadersWidth = 51;
            this.dataGridView_MateriaPrimas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MateriaPrimas.Size = new System.Drawing.Size(790, 149);
            this.dataGridView_MateriaPrimas.TabIndex = 8;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Width = 69;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 77;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 62;
            // 
            // Subtototal
            // 
            this.Subtototal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Subtototal.HeaderText = "Subtototal";
            this.Subtototal.Name = "Subtototal";
            this.Subtototal.ReadOnly = true;
            this.Subtototal.Width = 80;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(477, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(245, 20);
            this.dateTimePicker1.TabIndex = 49;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(374, 42);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(79, 13);
            this.lblFechaEntrega.TabIndex = 48;
            this.lblFechaEntrega.Text = "Fecha entrega:";
            // 
            // lblCostoEnsamblado
            // 
            this.lblCostoEnsamblado.AutoSize = true;
            this.lblCostoEnsamblado.Location = new System.Drawing.Point(374, 13);
            this.lblCostoEnsamblado.Name = "lblCostoEnsamblado";
            this.lblCostoEnsamblado.Size = new System.Drawing.Size(97, 13);
            this.lblCostoEnsamblado.TabIndex = 47;
            this.lblCostoEnsamblado.Text = "Costo ensamblado:";
            // 
            // numCostoEnsamblado
            // 
            this.numCostoEnsamblado.DecimalPlaces = 2;
            this.numCostoEnsamblado.Location = new System.Drawing.Point(477, 11);
            this.numCostoEnsamblado.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCostoEnsamblado.Name = "numCostoEnsamblado";
            this.numCostoEnsamblado.Size = new System.Drawing.Size(245, 20);
            this.numCostoEnsamblado.TabIndex = 46;
            this.numCostoEnsamblado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Filtrar";
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(62, 9);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(114, 17);
            this.rdbTodos.TabIndex = 52;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos las compras";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbConfirmados
            // 
            this.rdbConfirmados.AutoSize = true;
            this.rdbConfirmados.Location = new System.Drawing.Point(62, 32);
            this.rdbConfirmados.Name = "rdbConfirmados";
            this.rdbConfirmados.Size = new System.Drawing.Size(106, 17);
            this.rdbConfirmados.TabIndex = 54;
            this.rdbConfirmados.TabStop = true;
            this.rdbConfirmados.Text = "Solo confirmadas";
            this.rdbConfirmados.UseVisualStyleBackColor = true;
            this.rdbConfirmados.CheckedChanged += new System.EventHandler(this.rdbConfirmados_CheckedChanged);
            // 
            // rdbSinConfirmar
            // 
            this.rdbSinConfirmar.AutoSize = true;
            this.rdbSinConfirmar.Location = new System.Drawing.Point(62, 55);
            this.rdbSinConfirmar.Name = "rdbSinConfirmar";
            this.rdbSinConfirmar.Size = new System.Drawing.Size(86, 17);
            this.rdbSinConfirmar.TabIndex = 55;
            this.rdbSinConfirmar.TabStop = true;
            this.rdbSinConfirmar.Text = "Sin confirmar";
            this.rdbSinConfirmar.UseVisualStyleBackColor = true;
            this.rdbSinConfirmar.CheckedChanged += new System.EventHandler(this.rdbSinConfirmar_CheckedChanged);
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.Location = new System.Drawing.Point(811, 320);
            this.btnConfirmarPedido.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Size = new System.Drawing.Size(131, 73);
            this.btnConfirmarPedido.TabIndex = 56;
            this.btnConfirmarPedido.Text = "Confirmar Pedido";
            this.btnConfirmarPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(477, 62);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(425, 20);
            this.txtDescripcion.TabIndex = 58;
            // 
            // idCompra
            // 
            this.idCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCompra.HeaderText = "id";
            this.idCompra.MinimumWidth = 6;
            this.idCompra.Name = "idCompra";
            this.idCompra.ReadOnly = true;
            this.idCompra.Width = 40;
            // 
            // PedidoConfirmado
            // 
            this.PedidoConfirmado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PedidoConfirmado.HeaderText = "Confirmado";
            this.PedidoConfirmado.MinimumWidth = 6;
            this.PedidoConfirmado.Name = "PedidoConfirmado";
            this.PedidoConfirmado.ReadOnly = true;
            this.PedidoConfirmado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PedidoConfirmado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PedidoConfirmado.Width = 85;
            // 
            // Ensamblado
            // 
            this.Ensamblado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ensamblado.HeaderText = "Ensamblado";
            this.Ensamblado.Name = "Ensamblado";
            this.Ensamblado.ReadOnly = true;
            this.Ensamblado.Width = 71;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // FechaCompra
            // 
            this.FechaCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCompra.HeaderText = "Fecha Compra";
            this.FechaCompra.MinimumWidth = 6;
            this.FechaCompra.Name = "FechaCompra";
            this.FechaCompra.ReadOnly = true;
            this.FechaCompra.Width = 101;
            // 
            // Fecha_entrega
            // 
            this.Fecha_entrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha_entrega.HeaderText = "Fecha entrega";
            this.Fecha_entrega.Name = "Fecha_entrega";
            this.Fecha_entrega.ReadOnly = true;
            this.Fecha_entrega.Width = 101;
            // 
            // CosteEnsamblado
            // 
            this.CosteEnsamblado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CosteEnsamblado.HeaderText = "Coste Ensamblado";
            this.CosteEnsamblado.MinimumWidth = 6;
            this.CosteEnsamblado.Name = "CosteEnsamblado";
            this.CosteEnsamblado.ReadOnly = true;
            this.CosteEnsamblado.Width = 110;
            // 
            // PrecioTotal
            // 
            this.PrecioTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrecioTotal.HeaderText = "Precio Total";
            this.PrecioTotal.MinimumWidth = 6;
            this.PrecioTotal.Name = "PrecioTotal";
            this.PrecioTotal.ReadOnly = true;
            this.PrecioTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrecioTotal.Width = 82;
            // 
            // checkBoxRequiereEnsamblado
            // 
            this.checkBoxRequiereEnsamblado.AutoSize = true;
            this.checkBoxRequiereEnsamblado.Location = new System.Drawing.Point(743, 13);
            this.checkBoxRequiereEnsamblado.Name = "checkBoxRequiereEnsamblado";
            this.checkBoxRequiereEnsamblado.Size = new System.Drawing.Size(129, 17);
            this.checkBoxRequiereEnsamblado.TabIndex = 59;
            this.checkBoxRequiereEnsamblado.Text = "Requiere ensamblado";
            this.checkBoxRequiereEnsamblado.UseVisualStyleBackColor = true;
            this.checkBoxRequiereEnsamblado.CheckedChanged += new System.EventHandler(this.checkBoxRequiereEnsamblado_CheckedChanged);
            // 
            // HistorialProductosCompradosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 481);
            this.Controls.Add(this.checkBoxRequiereEnsamblado);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConfirmarPedido);
            this.Controls.Add(this.rdbSinConfirmar);
            this.Controls.Add(this.rdbConfirmados);
            this.Controls.Add(this.rdbTodos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.lblCostoEnsamblado);
            this.Controls.Add(this.numCostoEnsamblado);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ProductosComprados);
            this.Controls.Add(this.dataGridView_MateriaPrimas);
            this.Name = "HistorialProductosCompradosView";
            this.Text = "Historial de ventas a clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosComprados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoEnsamblado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_ProductosComprados;
        private System.Windows.Forms.DataGridView dataGridView_MateriaPrimas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtototal;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Label lblCostoEnsamblado;
        private System.Windows.Forms.NumericUpDown numCostoEnsamblado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbConfirmados;
        private System.Windows.Forms.RadioButton rdbSinConfirmar;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PedidoConfirmado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ensamblado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosteEnsamblado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.CheckBox checkBoxRequiereEnsamblado;
    }
}