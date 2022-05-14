
namespace TallerMecanica.Views.SharedViews
{
    partial class ProductosPreEnsamblados
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ProductosPreensamblados = new System.Windows.Forms.DataGridView();
            this.dataGridView_MateriaPrimas = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosteEnsamblado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosPreensamblados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Prpductoaisjn";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Materiales del producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Productos preensamblados";
            // 
            // dataGridView_ProductosPreensamblados
            // 
            this.dataGridView_ProductosPreensamblados.AllowUserToAddRows = false;
            this.dataGridView_ProductosPreensamblados.AllowUserToDeleteRows = false;
            this.dataGridView_ProductosPreensamblados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProductosPreensamblados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCompra,
            this.Descripcion,
            this.CosteEnsamblado,
            this.PrecioTotal});
            this.dataGridView_ProductosPreensamblados.Location = new System.Drawing.Point(13, 35);
            this.dataGridView_ProductosPreensamblados.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_ProductosPreensamblados.MultiSelect = false;
            this.dataGridView_ProductosPreensamblados.Name = "dataGridView_ProductosPreensamblados";
            this.dataGridView_ProductosPreensamblados.ReadOnly = true;
            this.dataGridView_ProductosPreensamblados.RowHeadersWidth = 51;
            this.dataGridView_ProductosPreensamblados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProductosPreensamblados.Size = new System.Drawing.Size(736, 106);
            this.dataGridView_ProductosPreensamblados.TabIndex = 8;
            this.dataGridView_ProductosPreensamblados.SelectionChanged += new System.EventHandler(this.dataGridView_ProductosPreensamblados_SelectionChanged);
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
            this.Categoria,
            this.Cantidad,
            this.Precio,
            this.Subtotal});
            this.dataGridView_MateriaPrimas.Location = new System.Drawing.Point(13, 183);
            this.dataGridView_MateriaPrimas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_MateriaPrimas.MultiSelect = false;
            this.dataGridView_MateriaPrimas.Name = "dataGridView_MateriaPrimas";
            this.dataGridView_MateriaPrimas.ReadOnly = true;
            this.dataGridView_MateriaPrimas.RowHeadersWidth = 51;
            this.dataGridView_MateriaPrimas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MateriaPrimas.Size = new System.Drawing.Size(736, 171);
            this.dataGridView_MateriaPrimas.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Historial";
            this.button2.UseVisualStyleBackColor = true;
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
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
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
            // Marca
            // 
            this.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 6;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 62;
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
            // Subtotal
            // 
            this.Subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 71;
            // 
            // ProductosPreEnsamblados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ProductosPreensamblados);
            this.Controls.Add(this.dataGridView_MateriaPrimas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ProductosPreEnsamblados";
            this.Text = "Vehiculos Ensamblados - LLevátelo YA";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosPreensamblados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_ProductosPreensamblados;
        private System.Windows.Forms.DataGridView dataGridView_MateriaPrimas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosteEnsamblado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}