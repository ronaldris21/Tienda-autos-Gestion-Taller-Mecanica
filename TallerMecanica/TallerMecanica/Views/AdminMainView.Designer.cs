 
namespace TallerMecanica.Views
{
    partial class AdminMainView
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnajustes = new System.Windows.Forms.Button();
            this.btnnoti = new System.Windows.Forms.Button();
            this.btnproductos = new System.Windows.Forms.Button();
            this.btnclientes = new System.Windows.Forms.Button();
            this.btnpedidos = new System.Windows.Forms.Button();
            this.btnproduct = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnajustes);
            this.panelMenu.Controls.Add(this.btnnoti);
            this.panelMenu.Controls.Add(this.btnproductos);
            this.panelMenu.Controls.Add(this.btnclientes);
            this.panelMenu.Controls.Add(this.btnpedidos);
            this.panelMenu.Controls.Add(this.btnproduct);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 521);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnajustes
            // 
            this.btnajustes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnajustes.FlatAppearance.BorderSize = 0;
            this.btnajustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnajustes.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnajustes.Image = global::TallerMecanica.Properties.Resources.settings;
            this.btnajustes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnajustes.Location = new System.Drawing.Point(0, 380);
            this.btnajustes.Name = "btnajustes";
            this.btnajustes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnajustes.Size = new System.Drawing.Size(220, 60);
            this.btnajustes.TabIndex = 6;
            this.btnajustes.Text = " Ajustes";
            this.btnajustes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnajustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnajustes.UseVisualStyleBackColor = true;
            this.btnajustes.Click += new System.EventHandler(this.btnajustes_Click);
            // 
            // btnnoti
            // 
            this.btnnoti.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnnoti.FlatAppearance.BorderSize = 0;
            this.btnnoti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnoti.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnnoti.Image = global::TallerMecanica.Properties.Resources.alarm__1_1;
            this.btnnoti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnoti.Location = new System.Drawing.Point(0, 320);
            this.btnnoti.Name = "btnnoti";
            this.btnnoti.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnnoti.Size = new System.Drawing.Size(220, 60);
            this.btnnoti.TabIndex = 5;
            this.btnnoti.Text = "   Notificaciones";
            this.btnnoti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnoti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnnoti.UseVisualStyleBackColor = true;
            this.btnnoti.Click += new System.EventHandler(this.btnnoti_Click);
            // 
            // btnproductos
            // 
            this.btnproductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnproductos.FlatAppearance.BorderSize = 0;
            this.btnproductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproductos.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnproductos.Image = global::TallerMecanica.Properties.Resources.bar_chart1;
            this.btnproductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproductos.Location = new System.Drawing.Point(0, 260);
            this.btnproductos.Name = "btnproductos";
            this.btnproductos.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnproductos.Size = new System.Drawing.Size(220, 60);
            this.btnproductos.TabIndex = 4;
            this.btnproductos.Text = "Productos";
            this.btnproductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproductos.UseVisualStyleBackColor = true;
            this.btnproductos.Click += new System.EventHandler(this.btnproductos_Click);
            // 
            // btnclientes
            // 
            this.btnclientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnclientes.FlatAppearance.BorderSize = 0;
            this.btnclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclientes.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnclientes.Image = global::TallerMecanica.Properties.Resources.value__1_;
            this.btnclientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclientes.Location = new System.Drawing.Point(0, 200);
            this.btnclientes.Name = "btnclientes";
            this.btnclientes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnclientes.Size = new System.Drawing.Size(220, 60);
            this.btnclientes.TabIndex = 3;
            this.btnclientes.Text = "Clientes";
            this.btnclientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnclientes.UseVisualStyleBackColor = true;
            this.btnclientes.Click += new System.EventHandler(this.btnclientes_Click);
            // 
            // btnpedidos
            // 
            this.btnpedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnpedidos.FlatAppearance.BorderSize = 0;
            this.btnpedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpedidos.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnpedidos.Image = global::TallerMecanica.Properties.Resources.shopping_list;
            this.btnpedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpedidos.Location = new System.Drawing.Point(0, 140);
            this.btnpedidos.Name = "btnpedidos";
            this.btnpedidos.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnpedidos.Size = new System.Drawing.Size(220, 60);
            this.btnpedidos.TabIndex = 2;
            this.btnpedidos.Text = "Pedidos";
            this.btnpedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnpedidos.UseVisualStyleBackColor = true;
            this.btnpedidos.Click += new System.EventHandler(this.btnpedidos_Click);
            // 
            // btnproduct
            // 
            this.btnproduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnproduct.FlatAppearance.BorderSize = 0;
            this.btnproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproduct.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnproduct.Image = global::TallerMecanica.Properties.Resources.shopping_cart__1_;
            this.btnproduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduct.Location = new System.Drawing.Point(0, 80);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnproduct.Size = new System.Drawing.Size(220, 60);
            this.btnproduct.TabIndex = 1;
            this.btnproduct.Text = "  Productos";
            this.btnproduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproduct.UseVisualStyleBackColor = true;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // AdminMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 521);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdminMainView";
            this.Text = "AdminMainView";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnproduct;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnnoti;
        private System.Windows.Forms.Button btnproductos;
        private System.Windows.Forms.Button btnclientes;
        private System.Windows.Forms.Button btnpedidos;
        private System.Windows.Forms.Button btnajustes;
    }
}