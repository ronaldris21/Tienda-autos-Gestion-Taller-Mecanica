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

namespace TallerMecanica.Views.AdminViews
{
    public partial class ClientesView : Form
    {
        public ClientesView()
        {
            InitializeComponent();
            themeColor.Loadtheme(this);
            InitData();
        }
        public void InitData()
        {
            TallerMecanica.Models.TallerMecanicoEntities dbContext = new Models.TallerMecanicoEntities();
            dataGridView1.Rows.Clear();
            var clientesRegistrados = dbContext.Cliente.ToList();
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
        private void button1_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
