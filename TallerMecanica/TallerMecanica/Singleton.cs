using System;
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

        public static string emailUsuarioSistema = "pepitodelospalotes1223@gmail.com";
        public static string passwordSistema = "trabajoPVA";
        public static Cliente cliente_login { get; set; }
        public static List<MateriaPrima_ProductoComprado> MaterialesComprados { get; set; }
        public  static void EnviarCorreo(StringBuilder Mensaje, DateTime fechaenvio, string para, string asunto, out string error)
        {
            error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(string.Format("\nEste correo ha sido enviado el dia {0:dd/MM/yyyy} a las {0:HH:mm:ss}", fechaenvio));
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailUsuarioSistema);
                mail.To.Add(para);
                mail.Subject = asunto;
                mail.Body = Mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(emailUsuarioSistema, passwordSistema);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                error = "Correo de recuperación de contraseña enviado";
                //MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                error = "error: " + ex.Message;
                //MessageBox.Show(error);
            }

        }

        internal static void EnviarCorreo(StringBuilder mensajeBuilder, DateTime now, object p, string v, out string error)
        {
            throw new NotImplementedException();
        }
    }

    public enum FiltrarPedidos
    {
        todos,
        confirmados,
        sinConfirmar
    }

    public class consultaProductoComprado
    {
        public ProductoComprado p { get; set; }
        public double precioFinal { get; set; }
    }
}
