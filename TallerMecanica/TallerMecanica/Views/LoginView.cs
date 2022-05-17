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

namespace TallerMecanica.Views
{
    public partial class LoginView : Form
    {
        private Form admin;
        private Form client;
        public LoginView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
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
            new Form1(txtuser.Text).Show();
        }

    }
}
