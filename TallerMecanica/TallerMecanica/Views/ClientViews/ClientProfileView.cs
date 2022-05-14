using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica.Views.ClientViews
{
    public partial class ClientProfileView : Form
    {
        public ClientProfileView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            actualizardatos();
        }

        private void actualizardatos()
        {
            txtnombre.Text = Singleton.cliente_login.nombreCompleto;
            txtcorreo.Text = Singleton.cliente_login.email;
            txtlf.Text = Singleton.cliente_login.telefono1;
            txtcontraseña.Text = Singleton.cliente_login.contrasena;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            actualizardatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Singleton.cliente_login.nombreCompleto = txtnombre.Text;
           Singleton.cliente_login.email = txtcorreo.Text;
            Singleton.cliente_login.telefono1 = txtlf.Text;
             Singleton.cliente_login.contrasena =txtcontraseña.Text ;
            MessageBox.Show("Datos actualizados!");

        }
    }
}
