using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica.Views
{
    public partial class Form1 : Form
    {
        const string usuario = "pepitodelospalotes1223@gmail.com";
        const string password = "trabajoPVA";
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbncorreo_Click(object sender, EventArgs e)
        {
            string error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append(tbnewpass.Text.Trim());
            EnviarCorreo(MensajeBuilder, DateTime.Now, txtcorreo.Text.Trim(), txtcorreo.Text.Trim(), "Nueva contraseña", out error);
        }

        private static void EnviarCorreo(StringBuilder Mensaje, DateTime fechaenvio, string de, string para, string asunto, out string error)
        {
             error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(string.Format("este correo ha sido enviado el dia {0:dd/MM/yyyy} a las {0:HH:mm:ss hrs}", fechaenvio));
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(de);
                mail.To.Add(para);
                mail.Subject = asunto;
                mail.Body = Mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(usuario, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                error = "exito";
                MessageBox.Show(error);

            }
            catch(Exception ex)
            {
                error = "error: " + ex.Message;
                MessageBox.Show(error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
