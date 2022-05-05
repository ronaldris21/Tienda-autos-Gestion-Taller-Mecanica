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
    }
}
