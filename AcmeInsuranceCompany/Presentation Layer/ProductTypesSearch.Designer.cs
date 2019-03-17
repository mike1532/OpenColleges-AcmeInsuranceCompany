namespace AcmeInsuranceCompany.Presentation_Layer
{
    partial class frmProductTypesSearch
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbListAll = new System.Windows.Forms.RadioButton();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.rbLife = new System.Windows.Forms.RadioButton();
            this.rbHouseContents = new System.Windows.Forms.RadioButton();
            this.rbCar = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(252, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 40);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(43, 228);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(138, 40);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbListAll
            // 
            this.rbListAll.AutoSize = true;
            this.rbListAll.Checked = true;
            this.rbListAll.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbListAll.Location = new System.Drawing.Point(43, 50);
            this.rbListAll.Name = "rbListAll";
            this.rbListAll.Size = new System.Drawing.Size(131, 24);
            this.rbListAll.TabIndex = 21;
            this.rbListAll.TabStop = true;
            this.rbListAll.Text = "List all records";
            this.rbListAll.UseVisualStyleBackColor = true;
            // 
            // rbIncome
            // 
            this.rbIncome.AutoSize = true;
            this.rbIncome.Location = new System.Drawing.Point(223, 50);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new System.Drawing.Size(167, 24);
            this.rbIncome.TabIndex = 29;
            this.rbIncome.TabStop = true;
            this.rbIncome.Text = "Income Protection";
            this.rbIncome.UseVisualStyleBackColor = true;
            // 
            // rbLife
            // 
            this.rbLife.AutoSize = true;
            this.rbLife.Location = new System.Drawing.Point(43, 101);
            this.rbLife.Name = "rbLife";
            this.rbLife.Size = new System.Drawing.Size(132, 24);
            this.rbLife.TabIndex = 28;
            this.rbLife.TabStop = true;
            this.rbLife.Text = "Life Insurance";
            this.rbLife.UseVisualStyleBackColor = true;
            // 
            // rbHouseContents
            // 
            this.rbHouseContents.AutoSize = true;
            this.rbHouseContents.Location = new System.Drawing.Point(43, 152);
            this.rbHouseContents.Name = "rbHouseContents";
            this.rbHouseContents.Size = new System.Drawing.Size(253, 24);
            this.rbHouseContents.TabIndex = 27;
            this.rbHouseContents.TabStop = true;
            this.rbHouseContents.Text = "Home and Contents Insurance";
            this.rbHouseContents.UseVisualStyleBackColor = true;
            // 
            // rbCar
            // 
            this.rbCar.AutoSize = true;
            this.rbCar.Location = new System.Drawing.Point(223, 101);
            this.rbCar.Name = "rbCar";
            this.rbCar.Size = new System.Drawing.Size(134, 24);
            this.rbCar.TabIndex = 26;
            this.rbCar.TabStop = true;
            this.rbCar.Text = "Car Insurance";
            this.rbCar.UseVisualStyleBackColor = true;
            // 
            // frmProductTypesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 296);
            this.Controls.Add(this.rbIncome);
            this.Controls.Add(this.rbLife);
            this.Controls.Add(this.rbHouseContents);
            this.Controls.Add(this.rbCar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.rbListAll);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductTypesSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Product Types";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbListAll;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.RadioButton rbLife;
        private System.Windows.Forms.RadioButton rbHouseContents;
        private System.Windows.Forms.RadioButton rbCar;
    }
}