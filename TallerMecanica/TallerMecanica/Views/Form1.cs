using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbncorreo_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();


            msg.To.Add(txtcorreo.Text);
            msg.Subject = "correo de contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add(txtcorreo.Text);

            msg.Body = tbnewpass.Text;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new System.Net.Mail.MailAddress("pepitodelospalotes1223@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("pepitodelospalotes1223@gmail.com", "trabajoPVA");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "sntp.gmail.com";

            try
            {
                cliente.Send(msg);
                MessageBox.Show("Mensaje enviado");

            }
            catch (Exception)
            {
                MessageBox.Show("error al enviar");


            }
        }
    }
}
