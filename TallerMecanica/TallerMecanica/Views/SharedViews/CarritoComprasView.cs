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
            initData();
        }

        private void initData()
        {
            dataGridView1.Rows.Clear();
            ///Leo las categorias
            //categorias = new RCategoria().GetAll().ToList();


            ////Create ComboBox Source - Put item categorie first
            //var categoryNames = new List<String>(
            //                from c in categorias
            //                select c.nombreCategoria);
            //(dataGridView1.Columns[6] as DataGridViewComboBoxColumn).DataSource = categoryNames;

            ////Leo las piezas
            //var datos = repo.GetAll();
            //foreach (MateriaPrima item in datos)
            //{
            //    this.dataGridView1.Rows.Add(
            //        new object[] {
            //            item.idMateriaPrima.ToString(), item.nombre , item.marca, item.precioCompra, item.precioVenta, item.cantidadStock, categorias.Where(c => c.idCategoria == item.idCategoria).Select(c => c.nombreCategoria).FirstOrDefault()
            //        });
            //}
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
