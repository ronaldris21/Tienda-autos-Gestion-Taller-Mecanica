using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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





        }
    }
}
