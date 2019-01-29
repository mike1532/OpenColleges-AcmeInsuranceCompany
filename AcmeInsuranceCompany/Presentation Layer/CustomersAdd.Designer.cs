namespace AcmeInsuranceCompany.Presentation_Layer
{
    partial class frmCustomersAdd
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
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDOB = new System.Windows.Forms.DateTimePicker();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.gbOfficeUseOnly = new System.Windows.Forms.GroupBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbContactDetails = new System.Windows.Forms.GroupBox();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblSuburb = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.gbCustomerDetails.SuspendLayout();
            this.gbOfficeUseOnly.SuspendLayout();
            this.gbContactDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(982, 85);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = " New Customer Details";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Controls.Add(this.lbCategory);
            this.gbCustomerDetails.Controls.Add(this.cbCategory);
            this.gbCustomerDetails.Controls.Add(this.dateTimePickerDOB);
            this.gbCustomerDetails.Controls.Add(this.rbFemale);
            this.gbCustomerDetails.Controls.Add(this.rbMale);
            this.gbCustomerDetails.Controls.Add(this.txtLastName);
            this.gbCustomerDetails.Controls.Add(this.txtFirstName);
            this.gbCustomerDetails.Controls.Add(this.lblCategory);
            this.gbCustomerDetails.Controls.Add(this.lblDateOfBirth);
            this.gbCustomerDetails.Controls.Add(this.lblGender);
            this.gbCustomerDetails.Controls.Add(this.lblLastName);
            this.gbCustomerDetails.Controls.Add(this.lblFirstName);
            this.gbCustomerDetails.Location = new System.Drawing.Point(12, 137);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(466, 284);
            this.gbCustomerDetails.TabIndex = 0;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Customer Details";
            // 
            // lbCategory
            // 
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.ItemHeight = 20;
            this.lbCategory.Location = new System.Drawing.Point(393, 231);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(20, 24);
            this.lbCategory.TabIndex = 6;
            this.lbCategory.Visible = false;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(178, 231);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(209, 28);
            this.cbCategory.TabIndex = 6;
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.CustomFormat = "dd/MMM/yyyy";
            this.dateTimePickerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDOB.Location = new System.Drawing.Point(178, 185);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerDOB.Size = new System.Drawing.Size(209, 26);
            this.dateTimePickerDOB.TabIndex = 5;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(304, 139);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(83, 24);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(178, 139);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(68, 24);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(178, 91);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(209, 26);
            this.txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(178, 44);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(209, 26);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(13, 235);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(83, 20);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category:";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(13, 188);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(46, 20);
            this.lblDateOfBirth.TabIndex = 3;
            this.lblDateOfBirth.Text = "DOB:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(13, 141);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(70, 20);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(13, 94);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(89, 20);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 47);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(87, 20);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // gbOfficeUseOnly
            // 
            this.gbOfficeUseOnly.Controls.Add(this.txtCustomerID);
            this.gbOfficeUseOnly.Controls.Add(this.lblCustomerID);
            this.gbOfficeUseOnly.Location = new System.Drawing.Point(551, 137);
            this.gbOfficeUseOnly.Name = "gbOfficeUseOnly";
            this.gbOfficeUseOnly.Size = new System.Drawing.Size(419, 85);
            this.gbOfficeUseOnly.TabIndex = 1;
            this.gbOfficeUseOnly.TabStop = false;
            this.gbOfficeUseOnly.Text = "Office Use Only";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Location = new System.Drawing.Point(190, 44);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(209, 26);
            this.txtCustomerID.TabIndex = 1;
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(24, 47);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(103, 20);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "Customer ID:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 485);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 40);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(176, 485);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(340, 485);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbContactDetails
            // 
            this.gbContactDetails.Controls.Add(this.txtSuburb);
            this.gbContactDetails.Controls.Add(this.txtAddress);
            this.gbContactDetails.Controls.Add(this.txtPostcode);
            this.gbContactDetails.Controls.Add(this.cbState);
            this.gbContactDetails.Controls.Add(this.lblPostcode);
            this.gbContactDetails.Controls.Add(this.lblState);
            this.gbContactDetails.Controls.Add(this.lblSuburb);
            this.gbContactDetails.Controls.Add(this.lblAddress);
            this.gbContactDetails.Location = new System.Drawing.Point(551, 241);
            this.gbContactDetails.Name = "gbContactDetails";
            this.gbContactDetails.Size = new System.Drawing.Size(419, 180);
            this.gbContactDetails.TabIndex = 2;
            this.gbContactDetails.TabStop = false;
            this.gbContactDetails.Text = "Contact Details";
            // 
            // txtSuburb
            // 
            this.txtSuburb.Location = new System.Drawing.Point(104, 83);
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.Size = new System.Drawing.Size(295, 26);
            this.txtSuburb.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 34);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(295, 26);
            this.txtAddress.TabIndex = 0;
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(309, 130);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(98, 26);
            this.txtPostcode.TabIndex = 3;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(104, 129);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(98, 28);
            this.cbState.TabIndex = 2;
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(214, 133);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(83, 20);
            this.lblPostcode.TabIndex = 3;
            this.lblPostcode.Text = "Postcode:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(24, 133);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(50, 20);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "State:";
            // 
            // lblSuburb
            // 
            this.lblSuburb.AutoSize = true;
            this.lblSuburb.Location = new System.Drawing.Point(24, 86);
            this.lblSuburb.Name = "lblSuburb";
            this.lblSuburb.Size = new System.Drawing.Size(63, 20);
            this.lblSuburb.TabIndex = 1;
            this.lblSuburb.Text = "Suburb:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(24, 37);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(71, 20);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address:";
            // 
            // frmCustomersAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.gbContactDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbOfficeUseOnly);
            this.Controls.Add(this.gbCustomerDetails);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCustomersAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Customer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomersAdd_FormClosed);
            this.Load += new System.EventHandler(this.frmCustomersAdd_Load);
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.gbOfficeUseOnly.ResumeLayout(false);
            this.gbOfficeUseOnly.PerformLayout();
            this.gbContactDetails.ResumeLayout(false);
            this.gbContactDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.GroupBox gbOfficeUseOnly;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.GroupBox gbContactDetails;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSuburb;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dateTimePickerDOB;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.TextBox txtSuburb;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.ListBox lbCategory;
    }
}