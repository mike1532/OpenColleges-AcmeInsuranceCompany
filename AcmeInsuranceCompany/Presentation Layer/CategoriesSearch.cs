﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmCategoriesSearch : Form
    {
        public frmCategoriesSearch()
        {
            InitializeComponent();
        }

        private void frmCategoriesSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
        }

        private void rbListAll_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //TODO code to search categories
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
