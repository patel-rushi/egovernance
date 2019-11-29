namespace TestingSystems
{
    partial class LeaveApplicationRegister
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Paid = new System.Windows.Forms.CheckBox();
            this.NotApprove = new System.Windows.Forms.Button();
            this.Approve = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.UserName = new System.Windows.Forms.ComboBox();
            this.Status = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Paid);
            this.groupBox1.Controls.Add(this.NotApprove);
            this.groupBox1.Controls.Add(this.Approve);
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ToDate);
            this.groupBox1.Controls.Add(this.FromDate);
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(85, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 595);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Paid
            // 
            this.Paid.AutoSize = true;
            this.Paid.Location = new System.Drawing.Point(591, 544);
            this.Paid.Name = "Paid";
            this.Paid.Size = new System.Drawing.Size(47, 17);
            this.Paid.TabIndex = 12;
            this.Paid.Text = "Paid";
            this.Paid.UseVisualStyleBackColor = true;
            // 
            // NotApprove
            // 
            this.NotApprove.BackColor = System.Drawing.SystemColors.Control;
            this.NotApprove.Location = new System.Drawing.Point(388, 534);
            this.NotApprove.Name = "NotApprove";
            this.NotApprove.Size = new System.Drawing.Size(83, 33);
            this.NotApprove.TabIndex = 11;
            this.NotApprove.Text = "Not Approve ";
            this.NotApprove.UseVisualStyleBackColor = false;
            this.NotApprove.Click += new System.EventHandler(this.NotApprove_Click);
            // 
            // Approve
            // 
            this.Approve.BackColor = System.Drawing.SystemColors.Control;
            this.Approve.Location = new System.Drawing.Point(504, 534);
            this.Approve.Name = "Approve";
            this.Approve.Size = new System.Drawing.Size(81, 34);
            this.Approve.TabIndex = 10;
            this.Approve.Text = "Approve ";
            this.Approve.UseVisualStyleBackColor = false;
            this.Approve.Click += new System.EventHandler(this.Approve_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.DGV.Location = new System.Drawing.Point(44, 148);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(916, 365);
            this.DGV.TabIndex = 9;
            // 
            // select
            // 
            this.select.HeaderText = "";
            this.select.Name = "select";
            this.select.Width = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "To Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd MMM yyyy";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(607, 97);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(200, 20);
            this.ToDate.TabIndex = 4;
            this.ToDate.Value = new System.DateTime(2019, 8, 1, 0, 0, 0, 0);
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "dd MMM yyyy";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(607, 60);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(200, 20);
            this.FromDate.TabIndex = 3;
            this.FromDate.Value = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // UserName
            // 
            this.UserName.FormattingEnabled = true;
            this.UserName.Location = new System.Drawing.Point(292, 57);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(121, 21);
            this.UserName.TabIndex = 2;
            this.UserName.SelectedIndexChanged += new System.EventHandler(this.UserName_SelectedIndexChanged);
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "Select",
            "Approved",
            "NotApproved",
            "Pending"});
            this.Status.Location = new System.Drawing.Point(292, 98);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(121, 21);
            this.Status.TabIndex = 1;
            this.Status.SelectedIndexChanged += new System.EventHandler(this.Status_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave  Application Register";
            // 
            // LeaveApplicationRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1194, 641);
            this.Controls.Add(this.groupBox1);
            this.Name = "LeaveApplicationRegister";
            this.Text = "LeaveApplicationRegister";
            this.Load += new System.EventHandler(this.LeaveApplicationRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox UserName;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Button NotApprove;
        private System.Windows.Forms.Button Approve;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.CheckBox Paid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
    }
}