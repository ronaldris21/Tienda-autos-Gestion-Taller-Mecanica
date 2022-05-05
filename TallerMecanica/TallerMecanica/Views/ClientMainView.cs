using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Views.AdminViews;
using TallerMecanica.Views.SharedViews;
namespace TallerMecanica.Views
{
    public partial class ClientMainView : Form
    {
        private Button currentButton;
        private Random random;
        private Form activeForm;

        public ClientMainView()
        {
            InitializeComponent();
            random = new Random();
            btncerrar.Visible = false;
            DisableButton();
        }

        // metodos
        private Color SelectThemeColor(object Sender)
        {
            try
            {
                //Generar un color fijo para cada vista
                int index = this.panelMenu.Controls.GetChildIndex((Control)Sender);
                string color = themeColor.ColorList[index];
                return ColorTranslator.FromHtml(color);
            }
            catch (Exception)
            {
                Reset();
                return Color.FromArgb(0, 150, 136);
            }
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitlebar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btncerrar.Visible = false;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor(btnSender);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitlebar.BackColor = color;
                    panelLogo.BackColor = themeColor.ChangeColorBrightness(color, -0.3);
                    themeColor.PrimaryColor = color;
                    themeColor.SecondaryColor = themeColor.ChangeColorBrightness(color, -0.3);
                    btncerrar.Visible = true;
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

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            { 
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void btncerrar_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
                Reset();
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new CarritoComprasView(), sender);
        }


        private void btnproductosPreEnsamblados_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ProductosPreEnsamblados(), sender);
        }

        private void btnHistorialPedidos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Views.ClientViews.HistorialComprasCliente(), sender);
        }
        private void btnAdmins_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new ClientViews.ClientProfileView(), sender);
        }
    }
}
