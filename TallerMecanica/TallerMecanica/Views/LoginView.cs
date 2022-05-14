using System;
using System.Drawing;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;
using System.Net.Mail;
using System.Configuration;

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
            Singleton.cliente_login = new Models.Cliente();
            themeColor.Loadtheme(this);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = true;
            admin = new Views.AdminMainView();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = false;
            client = new Views.ClientMainView();
            client.Show();

        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            new SignupView().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tbemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new AdminMainView().Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new ClientMainView().Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignupView().Show();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente c = new dbClientes().Login(txtuser.Text, txtpassword.Text);
            if(c == null)
            {
                MessageBox.Show("no existe el usuario, pruebe de nuevo");
                
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
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("pepitodelospalotes1223@gmail.com", "Kyocode", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(txtuser.Text); //Correo destino?
            correo.Subject = "Correo de prueba"; //Asunto
            correo.Body = "Este es un correo de prueba desde c#"; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("pepitodelospalotes1223@gmail.com", "trabajoPVA");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }
    }
}
