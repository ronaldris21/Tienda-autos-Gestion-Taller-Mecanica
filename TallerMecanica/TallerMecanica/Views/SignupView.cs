using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Repositories;
using TallerMecanica.Models;

namespace TallerMecanica.Views
{
    public partial class SignupView : Form
    {
        public SignupView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
        }
        //Comentario
        private void SignupView_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbnombre.Text) || String.IsNullOrEmpty(tbemail.Text) || String.IsNullOrEmpty(tbcontraseña.Text) || String.IsNullOrEmpty(tbtelefono.Text) )
            {
                MessageBox.Show("te falta un dato por meter");
            }
            else
            {
                Cliente c = new Cliente();
                c.nombreCompleto = tbnombre.Text;
                c.contrasena = tbcontraseña.Text;
                c.email = tbemail.Text;
                c.telefono1 = tbtelefono.Text;
                c.isAdmin = false;

                dbClientes conexion = new dbClientes();
                conexion.Insert(c);

                MessageBox.Show("cliente creado!!");
            }
        }
    }
}
