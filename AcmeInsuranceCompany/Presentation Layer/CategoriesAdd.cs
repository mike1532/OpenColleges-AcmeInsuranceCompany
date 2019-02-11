using System;
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
    public partial class frmCategoriesAdd : Form
    {
        public frmCategoriesAdd()
        {
            InitializeComponent();
        }

        private void frmCategoriesAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmCategoriesView categoriesView = new frmCategoriesView();
            categoriesView.Show();
            Hide();
        }

        //buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO code to add category
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //TODO code to clear
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ChangeAddToEdit(string form, string title, string button)
        {
            this.Text = form;
            lblTitle.Text = title;
            btnAdd.Text = button;
            lblCategory.Text = "Category:";
            btnClear.Visible = false;
            btnCancel.Top = btnClear.Top;
            btnCancel.Left = btnClear.Left;
        }
    }
}
