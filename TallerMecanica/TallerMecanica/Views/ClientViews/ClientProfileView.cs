using System;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que deseas actualizar tus datos y contraseña?", "Cuidado", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            Singleton.cliente_login.nombreCompleto = txtnombre.Text;
            Singleton.cliente_login.email = txtcorreo.Text;
            Singleton.cliente_login.telefono1 = txtlf.Text;
            Singleton.cliente_login.contrasena = txtcontraseña.Text;

            bool actualizados = new Repositories.dbClientes().Update(Singleton.cliente_login);
            if (actualizados)
                MessageBox.Show("Datos actualizados!");
            else
                MessageBox.Show("Datos no actualizados. Revisa tu conexión a internet o intenta de nuevo llenando todos los datos");


        }
    }
}
