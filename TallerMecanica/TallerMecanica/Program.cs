using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new InitFakeData();
            Singleton.cliente_login = new Models.Cliente()
            {
                isAdmin = true,
                nombreCompleto = "Ronaldd ris0",
                email = "retejada@alu.ucam.edu",
                contrasena = "1234",
                idCliente = 1,
                telefono1 = "747654894"
            };
            Singleton.cliente_login.nombreCompleto = "Ronald";
            themeColor.PrimaryColor = themeColor.defaultColor;
            themeColor.SecondaryColor = themeColor.ChangeColorBrightness(themeColor.defaultColor, 0.3);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.LoginView());
        }
    }
}

