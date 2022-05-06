
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
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrimas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProductosComprados)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
<<<<<<< Updated upstream
            this.button1.Location = new System.Drawing.Point(658, 415);
=======
            this.button1.Location = new System.Drawing.Point(400, 306);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
>>>>>>> Stashed changes
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
            this.Categoria});
            this.dataGridView_MateriaPrimas.Location = new System.Drawing.Point(28, 226);
            this.dataGridView_MateriaPrimas.MultiSelect = false;
            this.dataGridView_MateriaPrimas.Name = "dataGridView_MateriaPrimas";
            this.dataGridView_MateriaPrimas.ReadOnly = true;
            this.dataGridView_MateriaPrimas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MateriaPrimas.Size = new System.Drawing.Size(708, 130);
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
            this.FechaCompra});
            this.dataGridView_ProductosComprados.Location = new System.Drawing.Point(28, 41);
            this.dataGridView_ProductosComprados.MultiSelect = false;
            this.dataGridView_ProductosComprados.Name = "dataGridView_ProductosComprados";
            this.dataGridView_ProductosComprados.ReadOnly = true;
            this.dataGridView_ProductosComprados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProductosComprados.Size = new System.Drawing.Size(708, 130);
            this.dataGridView_ProductosComprados.TabIndex = 3;
            this.dataGridView_ProductosComprados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Productos compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Materiales de la compra";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // idCompra
            // 
            this.idCompra.HeaderText = "id";
            this.idCompra.Name = "idCompra";
            this.idCompra.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // FechaCompra
            // 
            this.FechaCompra.HeaderText = "Fecha Compra";
            this.FechaCompra.Name = "FechaCompra";
            this.FechaCompra.ReadOnly = true;
            // 
            // HistorialComprasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< Updated upstream
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ProductosComprados);
            this.Controls.Add(this.dataGridView_MateriaPrimas);
=======
            this.ClientSize = new System.Drawing.Size(1067, 554);
>>>>>>> Stashed changes
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
    }
}