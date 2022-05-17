using System;
using System.Collections.Generic;
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
            //new InitFakeData().InitDataOnServerAsync();

            Singleton.cliente_login = new Models.Cliente();
            Singleton.cliente_login.isAdmin = false;
            Singleton.cliente_login.nombreCompleto = "Ronaldd ris0";
            Singleton.cliente_login.email = "retejada@alu.ucam.edu";
            Singleton.cliente_login.contrasena = "1234";
            Singleton.cliente_login.idCliente = 2;
            Singleton.cliente_login.telefono1 = "747654894";


            ///INIT DATA
            themeColor.PrimaryColor = themeColor.defaultColor;
            themeColor.SecondaryColor = themeColor.ChangeColorBrightness(themeColor.defaultColor, 0.3);
            Singleton.MaterialesComprados = new List<Models.MateriaPrima_ProductoComprado>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.LoginView());
        }
    }
}

