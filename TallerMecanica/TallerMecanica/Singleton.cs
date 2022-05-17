﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica
{
    public class Singleton
    {

        const string usuario = "pepitodelospalotes1223@gmail.com";
        const string password = "trabajoPVA";
        public static Cliente cliente_login { get; set; }
        public static List<MateriaPrima_ProductoComprado> MaterialesComprados { get; set; }
        private static void EnviarCorreo(StringBuilder Mensaje, DateTime fechaenvio, string de, string para, string asunto, out string error)
        {
            error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(string.Format("\nEste correo ha sido enviado el dia {0:dd/MM/yyyy} a las {0:HH:mm:ss}", fechaenvio));
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
                error = "Correo de recuperación de contraseña enviado";
                MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                error = "error: " + ex.Message;
                MessageBox.Show(error);
            }

        }
    }
}
