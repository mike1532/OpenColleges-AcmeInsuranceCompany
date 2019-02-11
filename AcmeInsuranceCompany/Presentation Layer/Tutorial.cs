using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AcmeInsuranceCompany.Presentation_Layer
{
    public partial class frmTutorialScreen : Form
    {
        public frmTutorialScreen()
        {
            InitializeComponent();
        }
        //button
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //events
        private void frmTutorialScreen_Load(object sender, EventArgs e)
        {
            //loads tutorial PDF
            string fileName = "Tutorial Ver2.0.pdf"; //file has been placed in bin/debug folder
            string filePath = Path.GetFullPath(fileName);

            axAcroPDF1.LoadFile(filePath);
           
        }
        private void frmTutorialScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closes PDF on exit
            axAcroPDF1.Dispose();                       
        }        

    }
}
