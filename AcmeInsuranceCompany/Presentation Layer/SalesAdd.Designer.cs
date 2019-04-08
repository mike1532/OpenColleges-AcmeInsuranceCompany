namespace AcmeInsuranceCompany.Presentation_Layer
{
    partial class frmSalesAdd
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
            this.gbPolicyDetails = new System.Windows.Forms.GroupBox();
            this.txtYearlyPremium = new System.Windows.Forms.TextBox();
            this.lblYearlyPremium = new System.Windows.Forms.Label();
            this.lbPremiumPaid = new System.Windows.Forms.ListBox();
            this.dateTimePickerPremiumStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbPremiumPaid = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblPremiumPayable = new System.Windows.Forms.Label();
            this.gbOfficeUseOnly = new System.Windows.Forms.GroupBox();
            this.txtSaleID = new System.Windows.Forms.TextBox();
            this.lblSaleID = new System.Windows.Forms.Label();
            this.gbSaleDetails = new System.Windows.Forms.GroupBox();
            this.lbProduct = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lbCustomer = new System.Windows.Forms.ListBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.gbPolicyDetails.SuspendLayout();
            this.gbOfficeUseOnly.SuspendLayout();
            this.gbSaleDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(982, 85);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = " New Sale Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // gbPolicyDetails
            // 
            this.gbPolicyDetails.Controls.Add(this.txtYearlyPremium);
            this.gbPolicyDetails.Controls.Add(this.lblYearlyPremium);
            this.gbPolicyDetails.Controls.Add(this.lbPremiumPaid);
            this.gbPolicyDetails.Controls.Add(this.dateTimePickerPremiumStartDate);
            this.gbPolicyDetails.Controls.Add(this.cbPremiumPaid);
            this.gbPolicyDetails.Controls.Add(this.lblStartDate);
            this.gbPolicyDetails.Controls.Add(this.lblPremiumPayable);
            this.gbPolicyDetails.Location = new System.Drawing.Point(539, 137);
            this.gbPolicyDetails.Name = "gbPolicyDetails";
            this.gbPolicyDetails.Size = new System.Drawing.Size(431, 220);
            this.gbPolicyDetails.TabIndex = 1;
            this.gbPolicyDetails.TabStop = false;
            this.gbPolicyDetails.Text = "Policy Details";
            // 
            // txtYearlyPremium
            // 
            this.txtYearlyPremium.Location = new System.Drawing.Point(168, 44);
            this.txtYearlyPremium.Name = "txtYearlyPremium";
            this.txtYearlyPremium.Size = new System.Drawing.Size(232, 26);
            this.txtYearlyPremium.TabIndex = 0;
            // 
            // lblYearlyPremium
            // 
            this.lblYearlyPremium.AutoSize = true;
            this.lblYearlyPremium.Location = new System.Drawing.Point(28, 47);
            this.lblYearlyPremium.Name = "lblYearlyPremium";
            this.lblYearlyPremium.Size = new System.Drawing.Size(122, 20);
            this.lblYearlyPremium.TabIndex = 9;
            this.lblYearlyPremium.Text = "Yearly Premium:";
            // 
            // lbPremiumPaid
            // 
            this.lbPremiumPaid.FormattingEnabled = true;
            this.lbPremiumPaid.ItemHeight = 20;
            this.lbPremiumPaid.Location = new System.Drawing.Point(405, 100);
            this.lbPremiumPaid.Name = "lbPremiumPaid";
            this.lbPremiumPaid.Size = new System.Drawing.Size(20, 24);
            this.lbPremiumPaid.TabIndex = 8;
            this.lbPremiumPaid.Visible = false;
            // 
            // dateTimePickerPremiumStartDate
            // 
            this.dateTimePickerPremiumStartDate.CustomFormat = "dd MMMM yyyy";
            this.dateTimePickerPremiumStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPremiumStartDate.Location = new System.Drawing.Point(168, 150);
            this.dateTimePickerPremiumStartDate.Name = "dateTimePickerPremiumStartDate";
            this.dateTimePickerPremiumStartDate.Size = new System.Drawing.Size(232, 26);
            this.dateTimePickerPremiumStartDate.TabIndex = 2;
            // 
            // cbPremiumPaid
            // 
            this.cbPremiumPaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPremiumPaid.FormattingEnabled = true;
            this.cbPremiumPaid.Items.AddRange(new object[] {
            "Fortnightly",
            "Monthly",
            "Yearly"});
            this.cbPremiumPaid.Location = new System.Drawing.Point(168, 96);
            this.cbPremiumPaid.Name = "cbPremiumPaid";
            this.cbPremiumPaid.Size = new System.Drawing.Size(232, 28);
            this.cbPremiumPaid.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(28, 153);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(85, 20);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblPremiumPayable
            // 
            this.lblPremiumPayable.AutoSize = true;
            this.lblPremiumPayable.Location = new System.Drawing.Point(28, 100);
            this.lblPremiumPayable.Name = "lblPremiumPayable";
            this.lblPremiumPayable.Size = new System.Drawing.Size(111, 20);
            this.lblPremiumPayable.TabIndex = 0;
            this.lblPremiumPayable.Text = "Premium Paid:";
            // 
            // gbOfficeUseOnly
            // 
            this.gbOfficeUseOnly.Controls.Add(this.txtSaleID);
            this.gbOfficeUseOnly.Controls.Add(this.lblSaleID);
            this.gbOfficeUseOnly.Location = new System.Drawing.Point(12, 137);
            this.gbOfficeUseOnly.Name = "gbOfficeUseOnly";
            this.gbOfficeUseOnly.Size = new System.Drawing.Size(419, 85);
            this.gbOfficeUseOnly.TabIndex = 6;
            this.gbOfficeUseOnly.TabStop = false;
            this.gbOfficeUseOnly.Text = "Office Use Only";
            // 
            // txtSaleID
            // 
            this.txtSaleID.Enabled = false;
            this.txtSaleID.Location = new System.Drawing.Point(144, 44);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.Size = new System.Drawing.Size(228, 26);
            this.txtSaleID.TabIndex = 1;
            // 
            // lblSaleID
            // 
            this.lblSaleID.AutoSize = true;
            this.lblSaleID.Location = new System.Drawing.Point(24, 47);
            this.lblSaleID.Name = "lblSaleID";
            this.lblSaleID.Size = new System.Drawing.Size(63, 20);
            this.lblSaleID.TabIndex = 0;
            this.lblSaleID.Text = "Sale ID:";
            // 
            // gbSaleDetails
            // 
            this.gbSaleDetails.Controls.Add(this.lbProduct);
            this.gbSaleDetails.Controls.Add(this.label1);
            this.gbSaleDetails.Controls.Add(this.cbProduct);
            this.gbSaleDetails.Controls.Add(this.lblProduct);
            this.gbSaleDetails.Controls.Add(this.lbCustomer);
            this.gbSaleDetails.Controls.Add(this.cbCustomer);
            this.gbSaleDetails.Controls.Add(this.lblCustomer);
            this.gbSaleDetails.Location = new System.Drawing.Point(12, 261);
            this.gbSaleDetails.Name = "gbSaleDetails";
            this.gbSaleDetails.Size = new System.Drawing.Size(415, 164);
            this.gbSaleDetails.TabIndex = 0;
            this.gbSaleDetails.TabStop = false;
            this.gbSaleDetails.Text = "Sale Details";
            // 
            // lbProduct
            // 
            this.lbProduct.FormattingEnabled = true;
            this.lbProduct.ItemHeight = 20;
            this.lbProduct.Location = new System.Drawing.Point(375, 98);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(20, 24);
            this.lbProduct.TabIndex = 5;
            this.lbProduct.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, -80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale ID:";
            // 
            // cbProduct
            // 
            this.cbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(144, 98);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(228, 28);
            this.cbProduct.TabIndex = 2;
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(24, 104);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(71, 20);
            this.lblProduct.TabIndex = 3;
            this.lblProduct.Text = "Product:";
            // 
            // lbCustomer
            // 
            this.lbCustomer.FormattingEnabled = true;
            this.lbCustomer.ItemHeight = 20;
            this.lbCustomer.Location = new System.Drawing.Point(375, 45);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(20, 24);
            this.lbCustomer.TabIndex = 2;
            this.lbCustomer.Visible = false;
            // 
            // cbCustomer
            // 
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(144, 43);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(228, 28);
            this.cbCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(24, 47);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(83, 20);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(340, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(176, 480);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 40);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 480);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.Location = new System.Drawing.Point(819, 459);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(151, 61);
            this.btnNewCustomer.TabIndex = 7;
            this.btnNewCustomer.Text = "click here to create a new customer";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProduct.Location = new System.Drawing.Point(648, 459);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(151, 61);
            this.btnNewProduct.TabIndex = 8;
            this.btnNewProduct.Text = "click here to create a new product";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // frmSalesAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbSaleDetails);
            this.Controls.Add(this.gbPolicyDetails);
            this.Controls.Add(this.gbOfficeUseOnly);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSalesAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Sale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesAdd_Load);
            this.gbPolicyDetails.ResumeLayout(false);
            this.gbPolicyDetails.PerformLayout();
            this.gbOfficeUseOnly.ResumeLayout(false);
            this.gbOfficeUseOnly.PerformLayout();
            this.gbSaleDetails.ResumeLayout(false);
            this.gbSaleDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPolicyDetails;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblPremiumPayable;
        private System.Windows.Forms.GroupBox gbOfficeUseOnly;
        private System.Windows.Forms.TextBox txtSaleID;
        private System.Windows.Forms.Label lblSaleID;
        private System.Windows.Forms.ComboBox cbPremiumPaid;
        private System.Windows.Forms.DateTimePicker dateTimePickerPremiumStartDate;
        private System.Windows.Forms.Label lblYearlyPremium;
        private System.Windows.Forms.ListBox lbPremiumPaid;
        private System.Windows.Forms.GroupBox gbSaleDetails;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ListBox lbCustomer;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtYearlyPremium;
        private System.Windows.Forms.ListBox lbProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnNewProduct;
    }
}