﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanica.Repositories;

namespace TallerMecanica.Views.AdminViews
{
    public partial class CategoriaView : Form
    {
        CategoriaRepository repo;
        public CategoriaView()
        {
            InitializeComponent();
            repo = new CategoriaRepository("db=(local)\\SQLExpress");
        }
    }
}
