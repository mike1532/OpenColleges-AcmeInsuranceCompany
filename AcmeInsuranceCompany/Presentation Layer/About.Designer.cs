namespace AcmeInsuranceCompany.Presentation_Layer
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblACME = new System.Windows.Forms.Label();
            this.lblDatabaseManagementProgram = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUnleasedBusinessSolutions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblACME
            // 
            this.lblACME.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblACME.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACME.Location = new System.Drawing.Point(12, 33);
            this.lblACME.Name = "lblACME";
            this.lblACME.Size = new System.Drawing.Size(758, 87);
            this.lblACME.TabIndex = 0;
            this.lblACME.Text = "ACME Insurance Company";
            this.lblACME.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDatabaseManagementProgram
            // 
            this.lblDatabaseManagementProgram.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseManagementProgram.Location = new System.Drawing.Point(14, 89);
            this.lblDatabaseManagementProgram.Name = "lblDatabaseManagementProgram";
            this.lblDatabaseManagementProgram.Size = new System.Drawing.Size(758, 53);
            this.lblDatabaseManagementProgram.TabIndex = 1;
            this.lblDatabaseManagementProgram.Text = "Database Management Program";
            this.lblDatabaseManagementProgram.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUnleasedBusinessSolutions
            // 
            this.lblUnleasedBusinessSolutions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUnleasedBusinessSolutions.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnleasedBusinessSolutions.Location = new System.Drawing.Point(0, 424);
            this.lblUnleasedBusinessSolutions.Name = "lblUnleasedBusinessSolutions";
            this.lblUnleasedBusinessSolutions.Size = new System.Drawing.Size(782, 29);
            this.lblUnleasedBusinessSolutions.TabIndex = 3;
            this.lblUnleasedBusinessSolutions.Text = "Version 1.0.0    © Unleased Business Solutions 2019 ";
            this.lblUnleasedBusinessSolutions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.lblUnleasedBusinessSolutions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDatabaseManagementProgram);
            this.Controls.Add(this.lblACME);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblACME;
        private System.Windows.Forms.Label lblDatabaseManagementProgram;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUnleasedBusinessSolutions;
    }
}