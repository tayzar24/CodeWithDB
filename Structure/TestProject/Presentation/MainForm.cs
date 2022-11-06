﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Mid;

namespace TestProject.Presentation
{
    public partial class MainForm : Form
    {
        CustomerExecutor customerExecutor = new CustomerExecutor();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Person Count : " + customerExecutor.GetCustomerCount(); 
        }
    }
}
