using System;
using System.Drawing;
using System.Windows.Forms;

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
    }
}
