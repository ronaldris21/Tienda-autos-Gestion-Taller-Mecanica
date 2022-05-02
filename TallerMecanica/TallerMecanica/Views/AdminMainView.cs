using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerMecanica.Views
{
    public partial class AdminMainView : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;

        public AdminMainView()
        {
            InitializeComponent();
            random = new Random();
        }

        // metodos
        private Color SelectThemeColor()
        {
            var dato = themeColor.ColorList;
            int index = random.Next(themeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(themeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = themeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }





        private void btnproduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Repositories.CategoriaRepository repo = new Repositories.CategoriaRepository();
            var datos  = repo.GetAll();
            foreach(var dato in datos)
            {
                int i = 0;
            }
        }

        private void btnpedidos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnnoti_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnajustes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
    }
}
