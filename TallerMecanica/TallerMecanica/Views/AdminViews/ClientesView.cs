using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica.Views.AdminViews
{
    public partial class ClientesView : Form
    {
        public ClientesView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
        }
    }
}
