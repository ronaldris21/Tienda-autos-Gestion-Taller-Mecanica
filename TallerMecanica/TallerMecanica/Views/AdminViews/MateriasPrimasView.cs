using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.AdminViews
{
    public partial class MateriasPrimasView : Form
    {
        private List<Categoria> categorias;
        private dbMateriaPrima repo;

        public MateriasPrimasView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            initDataAsync();
            repo = new dbMateriaPrima();
        }
        private async Task initDataAsync()
        {
            dataGridView1.Rows.Clear();
            ///Leo las categorias

            using (TallerMecanicoEntities dbContext = new TallerMecanicoEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                categorias = await dbContext.Categoria.ToListAsync();


                //Create ComboBox Source - Put item categorie first
                var categoryNames = new List<String>(
                                from c in categorias
                                select c.nombreCategoria);
                (dataGridView1.Columns[6] as DataGridViewComboBoxColumn).DataSource = categoryNames;


                var datos = await dbContext.MateriaPrima.ToListAsync();
                foreach (MateriaPrima item in datos)
                {
                    this.dataGridView1.Rows.Add(
                        new object[] {
                        item.idMateriaPrima.ToString(), item.nombre , item.material, item.precioCompra, item.precioVenta, item.cantidadStock, categorias.Where(c => c.idCategoria == item.idCategoria).Select(c => c.nombreCategoria).FirstOrDefault()
                        });
                }
            }
        }


        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            bool didInsert = false;
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                MateriaPrima item = new MateriaPrima();
                //Validar datos
                try
                {
                    item.nombre = row.Cells[1].Value.ToString();
                    item.material = row.Cells[2].Value.ToString();
                    item.precioCompra = double.Parse(row.Cells[3].Value.ToString());
                    item.precioVenta = double.Parse(row.Cells[4].Value.ToString());
                    item.cantidadStock = int.Parse(row.Cells[5].Value.ToString());
                    item.idCategoria = categorias.Where(c => c.nombreCategoria == row.Cells[6].Value.ToString())
                                                .Select(c => c.idCategoria)
                                                .FirstOrDefault();
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
                    item.idMateriaPrima = int.Parse(row.Cells[0].Value.ToString());
                    if (repo.Update(item))
                        MessageBox.Show("Datos actualizados con exito", "Confirmación");
                    else
                        MessageBox.Show("No fue posible actualizar los datos, revisa tu conexión a internet", "Error");
                }
                else
                {
                    didInsert = true;
                    if (repo.Insert(item))
                        MessageBox.Show("Datos Guardados con exito", "Confirmación");
                    else
                        MessageBox.Show("No fue posible guardar los datos, revisa tu conexión a internet", "Error");
                }
            }
            if (didInsert)
                initDataAsync(); //Actualiza toda la tabla para que aparezcan los id
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            bool didDelete = false;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    MateriaPrima item = new MateriaPrima();
                    item.idMateriaPrima = int.Parse(row.Cells[0].Value.ToString());
                    item.nombre = row.Cells[1].Value.ToString();
                    item.material = row.Cells[2].Value.ToString();
                    if (MessageBox.Show("Seguro que deseas eliminar: " + item.nombre + "-" + item.material, "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        repo.Delete(item.idMateriaPrima);
                        didDelete = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t----ERROR: " + ex.Message);
                }

            }
            if (didDelete)
                initDataAsync();

        }



        private void btnReload_Click(object sender, EventArgs e)
        {
            initDataAsync();
        }
    }
}
