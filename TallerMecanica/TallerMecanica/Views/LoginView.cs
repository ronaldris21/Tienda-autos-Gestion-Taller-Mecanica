﻿using System;
using System.Drawing;
using System.Windows.Forms;
using TallerMecanica.Models;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views
{
    public partial class LoginView : Form
    {
        private Form admin;
        private Form client;
        public LoginView()
        {
            InitializeComponent();
            Singleton.cliente_login = new Models.Cliente();
            themeColor.Loadtheme(this);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = true;
            admin = new Views.AdminMainView();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Singleton.cliente_login.isAdmin = false;
            client = new Views.ClientMainView();
            client.Show();

        }

        private void btnSingup_Click(object sender, EventArgs e)
        {
            new SignupView().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tbemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void titlebar_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new AdminMainView().Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new ClientMainView().Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignupView().Show();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente c = new dbClientes().Login(txtuser.Text, txtpassword.Text);
            if(c == null)
            {
                MessageBox.Show("no existe el usuario, pruebe de nuevo");
                
            }
            else
            {
                if(c.isAdmin == true){

                    new AdminMainView().Show();
                    this.Close();

                }
                else
                {
                    new ClientMainView().Show();
                    this.Close();
                }

            }
        }
    }
}
