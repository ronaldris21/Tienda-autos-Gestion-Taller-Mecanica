using System;
using System.Drawing;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;
using System.Net.Mail;

using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
using System.Linq;

namespace TallerMecanica.Views
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);

            this.btnCliente.Visible = false;
            this.btnAdmin.Visible = false;
            this.btnCliente.Enabled = false;
            this.btnAdmin.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = true;
            new AdminMainView().Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = false;
            new ClientMainView().Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignupView().Show();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente c = new dbClientes().Login(txtuser.Text, txtpassword.Text);
            if(c == null)
            {
                MessageBox.Show("Datos no válidos, pruebe de nuevo");
            }
            else
            {
                Singleton.cliente_login = c;
                if(c.isAdmin == true){

                    this.Hide();
                    var form = new AdminMainView();
                    form.Closed += (s, args) => this.Show();
                    form.Show();

                }
                else
                {
                    this.Hide();
                    var form = new ClientMainView();
                    form.Closed += (s, args) => this.Show();
                    form.Show();
                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cliente cli = null;
            using (Models.TallerMecanicoEntities dbContext = new Models.TallerMecanicoEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                cli = dbContext.Cliente.FirstOrDefault(c => c.email == txtuser.Text);
            }
            if (cli == null)
            {
                MessageBox.Show("No existe ningún usuario con este correo");
                return;
            }

            string error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append("Recuperacion de cuenta: ");
            MensajeBuilder.Append(cli.contrasena.Trim());
            Singleton.EnviarCorreo(MensajeBuilder, DateTime.Now, txtuser.Text.Trim(), "Contraseña del Taller Mecánico", out error);
            this.Close();
        }

    }
}
