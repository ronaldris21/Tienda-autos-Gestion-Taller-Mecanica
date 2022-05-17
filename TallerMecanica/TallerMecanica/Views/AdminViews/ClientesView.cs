using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.AdminViews
{
    public partial class ClientesView : Form
    {
        private List<Cliente> clientesRegistrados;
        private dbClientes repo;
        public ClientesView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            repo = new dbClientes();
            InitDataAsync();
        }
        public async Task InitDataAsync()
        {
            using (TallerMecanica.Models.TallerMecanicoEntities dbContext = new Models.TallerMecanicoEntities())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                clientesRegistrados = await dbContext.Cliente.ToListAsync();

                dataGridView1.Rows.Clear();
                foreach (Cliente client in clientesRegistrados)
                {
                    this.dataGridView1.Rows.Add(
                        new object[] {
                        client.idCliente,
                        client.nombreCompleto,
                        client.email,
                        client.telefono1,
                        client.telefono2,
                        client.contrasena,
                        client.isAdmin
                        });
                }
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            InitDataAsync();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            bool didInsert = false;
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Cliente client = new Cliente();
                //Validar datos
                try
                {
                    client.nombreCompleto = row.Cells[1].Value.ToString();
                    client.email = row.Cells[2].Value.ToString();
                    client.telefono1 = row.Cells[3].Value.ToString();
                    try
                    {
                        client.telefono2 = row.Cells[4].Value.ToString(); ///Este puede ir vacio
                    }
                    catch (Exception) { }
                    client.contrasena = row.Cells[5].Value.ToString();
                    client.isAdmin = Convert.ToBoolean(row.Cells[6].Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t----ERROR: " + ex.Message);
                    MessageBox.Show("Asegurese de ingresar todos los datos y que sean válidos\nTodos los campos son obligatorios excepto id y Telefono 2.", "Error");
                    continue; ///Ignora la fila actual y pasa a la siguiente
                }
                //Update or Insert
                if (row.Cells[0].Value != null) //Tiene id
                {
                    client.idCliente = int.Parse(row.Cells[0].Value.ToString());
                    repo.Update(client);
                    MessageBox.Show("Datos actualizados con exito", "Confirmación");
                }
                else
                {
                    didInsert = repo.Insert(client);
                    if (didInsert)
                        
                        MessageBox.Show("Datos Guardados con exito", "Confirmación");
                    else
                        MessageBox.Show("Todos los campos son obligatorios excepto id y Telefono 2. ", "Error");
                }
            }
            if (didInsert)
                InitDataAsync(); //Actualiza toda la tabla para que aparezcan los id
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {

            bool didDelete = false;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                try
                {
                    Cliente client = new Cliente();
                    client.idCliente = int.Parse(row.Cells[0].Value.ToString());
                    client.nombreCompleto = row.Cells[1].Value.ToString();
                    if (MessageBox.Show("Seguro que deseas eliminar: " + client.nombreCompleto, "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        didDelete = repo.Delete(client.idCliente);
                        if (didDelete)
                            MessageBox.Show("Cliente eliminado con exito", "Confirmación");
                        else
                            MessageBox.Show("No es posible eliminar el cliente, no es posible eliminar clientes con compras ", "Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t----ERROR: " + ex.Message);
                }
            }

            if (didDelete)
                InitDataAsync();
        }
    }
}
