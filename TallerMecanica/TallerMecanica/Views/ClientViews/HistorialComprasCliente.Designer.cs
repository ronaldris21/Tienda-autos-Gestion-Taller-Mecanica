
namespace TallerMecanica.Views.ClientViews
{
    partial class HistorialComprasCliente
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_MateriaPrimas = new System.Windows.Forms.DataGridView();
            this.dataGridView_ProductosComprados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoConfirmado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosteEnsamblado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosComprados)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 306);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Historial";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView_MateriaPrimas
            // 
            this.dataGridView_MateriaPrimas.AllowUserToAddRows = false;
            this.dataGridView_MateriaPrimas.AllowUserToDeleteRows = false;
            this.dataGridView_MateriaPrimas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MateriaPrimas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nombre,
            this.Marca,
            this.Cantidad,
            this.Categoria,
            this.Precio});
            this.dataGridView_MateriaPrimas.Location = new System.Drawing.Point(28, 228);
            this.dataGridView_MateriaPrimas.MultiSelect = false;
            this.dataGridView_MateriaPrimas.Name = "dataGridView_MateriaPrimas";
            this.dataGridView_MateriaPrimas.ReadOnly = true;
            this.dataGridView_MateriaPrimas.RowHeadersWidth = 51;
            this.dataGridView_MateriaPrimas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MateriaPrimas.Size = new System.Drawing.Size(982, 210);
            this.dataGridView_MateriaPrimas.TabIndex = 2;
            // 
            // dataGridView_ProductosComprados
            // 
            this.dataGridView_ProductosComprados.AllowUserToAddRows = false;
            this.dataGridView_ProductosComprados.AllowUserToDeleteRows = false;
            this.dataGridView_ProductosComprados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProductosComprados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCompra,
            this.Descripcion,
            this.FechaCompra,
            this.PedidoConfirmado,
            this.PrecioTotal,
            this.CosteEnsamblado});
            this.dataGridView_ProductosComprados.Location = new System.Drawing.Point(28, 45);
            this.dataGridView_ProductosComprados.MultiSelect = false;
            this.dataGridView_ProductosComprados.Name = "dataGridView_ProductosComprados";
            this.dataGridView_ProductosComprados.ReadOnly = true;
            this.dataGridView_ProductosComprados.RowHeadersWidth = 51;
            this.dataGridView_ProductosComprados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProductosComprados.Size = new System.Drawing.Size(982, 130);
            this.dataGridView_ProductosComprados.TabIndex = 3;
            this.dataGridView_ProductosComprados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Productos compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Materiales de la compra";
            // 
            // idCompra
            // 
            this.idCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCompra.HeaderText = "id";
            this.idCompra.MinimumWidth = 6;
            this.idCompra.Name = "idCompra";
            this.idCompra.ReadOnly = true;
            this.idCompra.Width = 48;
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
            this.FechaCompra.Width = 129;
            // 
            // PedidoConfirmado
            // 
            this.PedidoConfirmado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PedidoConfirmado.HeaderText = "Pedido Confirmado";
            this.PedidoConfirmado.MinimumWidth = 6;
            this.PedidoConfirmado.Name = "PedidoConfirmado";
            this.PedidoConfirmado.ReadOnly = true;
            this.PedidoConfirmado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PedidoConfirmado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PedidoConfirmado.Width = 144;
            // 
            // PrecioTotal
            // 
            this.PrecioTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrecioTotal.HeaderText = "Precio Total";
            this.PrecioTotal.MinimumWidth = 6;
            this.PrecioTotal.Name = "PrecioTotal";
            this.PrecioTotal.ReadOnly = true;
            this.PrecioTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrecioTotal.Width = 104;
            // 
            // CosteEnsamblado
            // 
            this.CosteEnsamblado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CosteEnsamblado.HeaderText = "Coste Ensamblado";
            this.CosteEnsamblado.MinimumWidth = 6;
            this.CosteEnsamblado.Name = "CosteEnsamblado";
            this.CosteEnsamblado.ReadOnly = true;
            this.CosteEnsamblado.Width = 142;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 48;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Marca
            // 
            this.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 6;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 76;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 93;
            // 
            // Categoria
            // 
            this.Categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 6;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.Width = 98;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 77;
            // 
            // HistorialComprasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 495);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ProductosComprados);
            this.Controls.Add(this.dataGridView_MateriaPrimas);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistorialComprasCliente";
            this.Text = "Mis compras - Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosComprados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_MateriaPrimas;
        private System.Windows.Forms.DataGridView dataGridView_ProductosComprados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PedidoConfirmado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosteEnsamblado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}