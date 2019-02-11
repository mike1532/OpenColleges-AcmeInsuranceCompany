namespace AcmeInsuranceCompany.Presentation_Layer
{
    partial class frmProductTypesAdd
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbProductTypeDetails = new System.Windows.Forms.GroupBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtProductTypeID = new System.Windows.Forms.TextBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProductTypeID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbProductTypeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(782, 85);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = " New Product Type Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // gbProductTypeDetails
            // 
            this.gbProductTypeDetails.Controls.Add(this.txtProductType);
            this.gbProductTypeDetails.Controls.Add(this.txtProductTypeID);
            this.gbProductTypeDetails.Controls.Add(this.lblProductType);
            this.gbProductTypeDetails.Controls.Add(this.lblProductTypeID);
            this.gbProductTypeDetails.Location = new System.Drawing.Point(13, 125);
            this.gbProductTypeDetails.Name = "gbProductTypeDetails";
            this.gbProductTypeDetails.Size = new System.Drawing.Size(757, 192);
            this.gbProductTypeDetails.TabIndex = 8;
            this.gbProductTypeDetails.TabStop = false;
            this.gbProductTypeDetails.Text = "Product Type Details";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(169, 108);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(244, 26);
            this.txtProductType.TabIndex = 3;
            // 
            // txtProductTypeID
            // 
            this.txtProductTypeID.Enabled = false;
            this.txtProductTypeID.Location = new System.Drawing.Point(169, 54);
            this.txtProductTypeID.Name = "txtProductTypeID";
            this.txtProductTypeID.Size = new System.Drawing.Size(244, 26);
            this.txtProductTypeID.TabIndex = 2;
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(19, 111);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(108, 20);
            this.lblProductType.TabIndex = 1;
            this.lblProductType.Text = "Product Type:";
            // 
            // lblProductTypeID
            // 
            this.lblProductTypeID.AutoSize = true;
            this.lblProductTypeID.Location = new System.Drawing.Point(19, 57);
            this.lblProductTypeID.Name = "lblProductTypeID";
            this.lblProductTypeID.Size = new System.Drawing.Size(128, 20);
            this.lblProductTypeID.TabIndex = 0;
            this.lblProductTypeID.Text = "Product Type ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(350, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(186, 378);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 40);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(13, 378);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmProductTypesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbProductTypeDetails);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductTypesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Product Type";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductTypesAdd_FormClosing);
            this.gbProductTypeDetails.ResumeLayout(false);
            this.gbProductTypeDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbProductTypeDetails;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProductTypeID;
        private System.Windows.Forms.TextBox txtProductTypeID;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
    }
}