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
    public partial class HistorialProductosCompradosView : Form
    {
        //TODO: Historial por cliente, filtrar por un combobox asi como filtro los objectos por categoria, mostrar todas
        public HistorialProductosCompradosView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
        }
    }
}
