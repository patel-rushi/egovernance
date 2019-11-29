namespace TestingSystems
{
    partial class LeaveApplication
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
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancel = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.desc = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.halftodate = new System.Windows.Forms.CheckBox();
            this.halffromdate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "dd MMM yyyy ";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(142, 47);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(200, 20);
            this.FromDate.TabIndex = 0;
            this.FromDate.Value = new System.DateTime(2019, 6, 18, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date :";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd MMM yyyy ";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(142, 91);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(200, 20);
            this.ToDate.TabIndex = 2;
            this.ToDate.Value = new System.DateTime(2019, 6, 18, 0, 0, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel);
            this.groupBox1.Controls.Add(this.submit);
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Controls.Add(this.desc);
            this.groupBox1.Controls.Add(this.description);
            this.groupBox1.Controls.Add(this.halftodate);
            this.groupBox1.Controls.Add(this.halffromdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ToDate);
            this.groupBox1.Location = new System.Drawing.Point(111, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 617);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.Control;
            this.cancel.Location = new System.Drawing.Point(494, 280);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(80, 33);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.SystemColors.Control;
            this.submit.Location = new System.Drawing.Point(393, 280);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(83, 33);
            this.submit.TabIndex = 10;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // DGV
            // 
            this.DGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(142, 319);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(767, 236);
            this.DGV.TabIndex = 9;
            // 
            // desc
            // 
            this.desc.AutoSize = true;
            this.desc.Location = new System.Drawing.Point(74, 139);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(66, 13);
            this.desc.TabIndex = 8;
            this.desc.Text = "Description :";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(142, 136);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(767, 138);
            this.description.TabIndex = 7;
            this.description.Text = "";
            // 
            // halftodate
            // 
            this.halftodate.AutoSize = true;
            this.halftodate.Location = new System.Drawing.Point(362, 93);
            this.halftodate.Name = "halftodate";
            this.halftodate.Size = new System.Drawing.Size(70, 17);
            this.halftodate.TabIndex = 6;
            this.halftodate.Text = "Half Day ";
            this.halftodate.UseVisualStyleBackColor = true;
            // 
            // halffromdate
            // 
            this.halffromdate.AutoSize = true;
            this.halffromdate.Location = new System.Drawing.Point(360, 48);
            this.halffromdate.Name = "halffromdate";
            this.halffromdate.Size = new System.Drawing.Size(70, 17);
            this.halffromdate.TabIndex = 5;
            this.halffromdate.Text = "Half Day ";
            this.halffromdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Leave Application";
            // 
            // LeaveApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1193, 641);
            this.Controls.Add(this.groupBox1);
            this.Name = "LeaveApplication";
            this.Text = "LeaveApplication";
            this.Load += new System.EventHandler(this.LeaveApplication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox halftodate;
        private System.Windows.Forms.CheckBox halffromdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.DataGridView DGV;
    }
}