namespace TestingSystems
{
    partial class ClientOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.amc1 = new TestingSystems.AMC();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonADD = new System.Windows.Forms.Button();
            this.dateTimePickerAMC = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxAMC = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOrderAmount = new System.Windows.Forms.TextBox();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxOrderNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxClientName = new AutoCompleteComboBox.SuggestComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bwClientName = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Register);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBoxAMC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxOrderAmount);
            this.groupBox1.Controls.Add(this.dateTimePickerOrderDate);
            this.groupBox1.Controls.Add(this.textBoxOrderNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxClientName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 592);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Order Detail";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(834, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(834, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(371, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(371, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "*";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(374, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Register
            // 
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Register.Location = new System.Drawing.Point(753, 12);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 8;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.amc1);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonADD);
            this.panel1.Controls.Add(this.dateTimePickerAMC);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Enabled = false;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel1.Location = new System.Drawing.Point(82, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 229);
            this.panel1.TabIndex = 6;
            // 
            // amc1
            // 
            this.amc1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.amc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amc1.Location = new System.Drawing.Point(87, 42);
            this.amc1.Margin = new System.Windows.Forms.Padding(4);
            this.amc1.Name = "amc1";
            this.amc1.Size = new System.Drawing.Size(515, 29);
            this.amc1.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDelete.Location = new System.Drawing.Point(605, 46);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(25, 25);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonADD
            // 
            this.buttonADD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonADD.BackgroundImage")));
            this.buttonADD.Location = new System.Drawing.Point(56, 46);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(25, 25);
            this.buttonADD.TabIndex = 2;
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePickerAMC
            // 
            this.dateTimePickerAMC.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dateTimePickerAMC.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerAMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickerAMC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAMC.Location = new System.Drawing.Point(192, 15);
            this.dateTimePickerAMC.Name = "dateTimePickerAMC";
            this.dateTimePickerAMC.Size = new System.Drawing.Size(230, 20);
            this.dateTimePickerAMC.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "AMC Period From:";
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Submit.Location = new System.Drawing.Point(293, 557);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxDescription.Location = new System.Drawing.Point(137, 134);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(552, 127);
            this.textBoxDescription.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description:";
            // 
            // checkBoxAMC
            // 
            this.checkBoxAMC.AutoSize = true;
            this.checkBoxAMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAMC.Location = new System.Drawing.Point(137, 292);
            this.checkBoxAMC.Name = "checkBoxAMC";
            this.checkBoxAMC.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAMC.TabIndex = 5;
            this.checkBoxAMC.UseVisualStyleBackColor = true;
            this.checkBoxAMC.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBoxAMC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBoxAMC_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "AMC Active:";
            // 
            // textBoxOrderAmount
            // 
            this.textBoxOrderAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxOrderAmount.Location = new System.Drawing.Point(598, 96);
            this.textBoxOrderAmount.Name = "textBoxOrderAmount";
            this.textBoxOrderAmount.Size = new System.Drawing.Size(230, 20);
            this.textBoxOrderAmount.TabIndex = 3;
            this.textBoxOrderAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrderAmount_KeyPress);
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePickerOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dateTimePickerOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(598, 58);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(230, 20);
            this.dateTimePickerOrderDate.TabIndex = 1;
            // 
            // textBoxOrderNo
            // 
            this.textBoxOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxOrderNo.Location = new System.Drawing.Point(138, 96);
            this.textBoxOrderNo.Name = "textBoxOrderNo";
            this.textBoxOrderNo.Size = new System.Drawing.Size(230, 20);
            this.textBoxOrderNo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(475, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Order Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order Number:";
            // 
            // comboBoxClientName
            // 
            this.comboBoxClientName.FilterRule = null;
            this.comboBoxClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxClientName.FormattingEnabled = true;
            this.comboBoxClientName.Location = new System.Drawing.Point(138, 57);
            this.comboBoxClientName.Name = "comboBoxClientName";
            this.comboBoxClientName.PropertySelector = null;
            this.comboBoxClientName.Size = new System.Drawing.Size(230, 21);
            this.comboBoxClientName.SuggestBoxHeight = 95;
            this.comboBoxClientName.SuggestListOrderRule = null;
            this.comboBoxClientName.TabIndex = 0;
            this.comboBoxClientName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxClientName_SelectionChangeCommitted);
            this.comboBoxClientName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBoxClientName_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Name:";
            // 
            // bwClientName
            // 
            this.bwClientName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CmbClientName_DoWork);
            this.bwClientName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CmbClientName_RunWorkerCompleted);
            // 
            // ClientOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(884, 604);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private AutoCompleteComboBox.SuggestComboBox comboBoxClientName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.TextBox textBoxOrderNo;
        private System.Windows.Forms.CheckBox checkBoxAMC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOrderAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.DateTimePicker dateTimePickerAMC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDelete;
        private System.ComponentModel.BackgroundWorker bwClientName;
        private AMC amc1;
        public System.Windows.Forms.Button Submit;
        public System.Windows.Forms.Button Register;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}