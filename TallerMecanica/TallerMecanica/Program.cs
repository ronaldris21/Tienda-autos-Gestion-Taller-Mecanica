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

            themeColor.PrimaryColor = themeColor.defaultColor;
            themeColor.SecondaryColor = themeColor.ChangeColorBrightness(themeColor.defaultColor, 0.3);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.LoginView());
        }
    }
}

