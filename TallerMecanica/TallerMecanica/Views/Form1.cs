using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica.Views
{
    public partial class Form1 : Form
    {
        public Form1(string Text)
        {
            InitializeComponent();
            txtcorreo.Text = Text;
            this.Text = "Recuperación de contraseña";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbncorreo_Click(object sender, EventArgs e)
        {
            Cliente cli = null;
            using (Models.TallerMecanicoEntities dbContext = new Models.TallerMecanicoEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                cli = dbContext.Cliente.FirstOrDefault(c => c.email == txtcorreo.Text);
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
            Singleton.EnviarCorreo(MensajeBuilder, DateTime.Now, txtcorreo.Text.Trim(), "Contraseña del Taller Mecánico", out error);
            this.Close();
        }

        
    }
}
