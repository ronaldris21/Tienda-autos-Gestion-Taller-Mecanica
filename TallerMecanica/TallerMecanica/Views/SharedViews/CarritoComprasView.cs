using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;

namespace TallerMecanica.Views.SharedViews
{
    public partial class CarritoComprasView : Form
    {
        List<MateriaPrima_ProductoComprado> items;
        public CarritoComprasView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Cuando deja de editar una vista
            MateriaPrima_ProductoComprado newItem = new MateriaPrima_ProductoComprado();
            newItem.idMateriaPrima = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            try
            {
                newItem.cantidad = int.Parse(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            }
            catch (Exception)
            {
                //not a number
                MessageBox.Show("Solo se aceptan números", "Error");
                return;
            }

            var material = Singleton.itemsCompra.Select(i => i.idMateriaPrima == newItem.idMateriaPrima).FirstOrDefault();
            if(material == null)
            {
                Singleton.itemsCompra.Add(newItem);
            }
            else
            {

            }

        }
    }
}
