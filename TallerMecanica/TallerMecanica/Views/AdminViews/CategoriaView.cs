using System;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.AdminViews
{
    public partial class CategoriaView : Form
    {
        private RCategoria repo;
        public CategoriaView()
        {
            InitializeComponent();
            repo = new RCategoria();
            themeColor.Loadtheme(this);
            initData();
        }

        private void initData()
        {
            var datos = repo.GetAll();
            dataGridView1.Rows.Clear();

            foreach (Categoria cate in datos)
            {
                this.dataGridView1.Rows.Add(
                    new object[] {
                        cate.idCategoria.ToString(), cate.cantidadCocheCompleto.ToString(), cate.nombreCategoria
                    });
            }
        }
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            bool didInsert = false;
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Categoria cate = new Categoria();
                //Validar datos
                try
                {
                    cate.nombreCategoria = row.Cells[2].Value.ToString();
                    cate.cantidadCocheCompleto = int.Parse(row.Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t----ERROR: " + ex.Message);
                    MessageBox.Show("Asegurese de ingresar todos los datos y que sean válidos", "Error");
                    continue; ///Ignora la fila actual y pasa a la siguiente
                }
                //Update or Insert
                if (row.Cells[0].Value != null) //Tiene id
                {
                    cate.idCategoria = int.Parse(row.Cells[0].Value.ToString());
                    repo.Update(cate);
                    MessageBox.Show("Datos actualizados con exito", "Confirmación");
                }
                else
                {
                    didInsert = true;
                    repo.Insert(cate);
                    MessageBox.Show("Datos Guardados con exito", "Confirmación");
                }
            }
            if (didInsert)
                initData(); //Actualiza toda la tabla para que aparezcan los id
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            bool didDelete = false;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    Categoria cate = new Categoria();
                    cate.idCategoria = int.Parse(row.Cells[0].Value.ToString());
                    cate.cantidadCocheCompleto = int.Parse(row.Cells[1].Value.ToString());
                    cate.nombreCategoria = row.Cells[2].Value.ToString();
                    if (MessageBox.Show("Seguro que deseas eliminar: " + cate.nombreCategoria, "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        repo.Delete(cate.idCategoria);
                        didDelete = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t----ERROR: " + ex.Message);
                }
            }

            if (didDelete)
                initData();
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            initData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
