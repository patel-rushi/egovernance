namespace TestingSystems
{
    partial class DailyWorkReport
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
            this.cmbTicketNumber = new AutoCompleteComboBox.SuggestComboBox();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvWorkReport = new System.Windows.Forms.DataGridView();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTaskType = new AutoCompleteComboBox.SuggestComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClient = new AutoCompleteComboBox.SuggestComboBox();
            this.DtTo = new System.Windows.Forms.DateTimePicker();
            this.Dtfrom = new System.Windows.Forms.DateTimePicker();
            this.DtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTicketNumber);
            this.groupBox1.Controls.Add(this.lblTicketNumber);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.dgvWorkReport);
            this.groupBox1.Controls.Add(this.BtnAdd);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTaskType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbClient);
            this.groupBox1.Controls.Add(this.DtTo);
            this.groupBox1.Controls.Add(this.Dtfrom);
            this.groupBox1.Controls.Add(this.DtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(65, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(935, 601);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbTicketNumber
            // 
            this.cmbTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTicketNumber.FilterRule = null;
            this.cmbTicketNumber.FormattingEnabled = true;
            this.cmbTicketNumber.Location = new System.Drawing.Point(748, 164);
            this.cmbTicketNumber.Name = "cmbTicketNumber";
            this.cmbTicketNumber.PropertySelector = null;
            this.cmbTicketNumber.Size = new System.Drawing.Size(181, 21);
            this.cmbTicketNumber.SuggestBoxHeight = 95;
            this.cmbTicketNumber.SuggestListOrderRule = null;
            this.cmbTicketNumber.TabIndex = 20;
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketNumber.Location = new System.Drawing.Point(648, 167);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(94, 13);
            this.lblTicketNumber.TabIndex = 19;
            this.lblTicketNumber.Text = "Ticket Number:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(441, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(441, 273);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 17;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(383, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Daily Wise Work Report";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(347, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvWorkReport
            // 
            this.dgvWorkReport.AllowUserToAddRows = false;
            this.dgvWorkReport.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvWorkReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientName,
            this.TaskType,
            this.Date,
            this.FromTime,
            this.ToTime,
            this.Description,
            this.ClientID,
            this.TaskID,
            this.TicketNumber});
            this.dgvWorkReport.Location = new System.Drawing.Point(9, 302);
            this.dgvWorkReport.Name = "dgvWorkReport";
            this.dgvWorkReport.Size = new System.Drawing.Size(920, 221);
            this.dgvWorkReport.TabIndex = 14;
            this.dgvWorkReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkReport_CellContentClick);
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "ClientName";
            this.ClientName.Name = "ClientName";
            this.ClientName.Width = 150;
            // 
            // TaskType
            // 
            this.TaskType.DataPropertyName = "TaskType";
            this.TaskType.HeaderText = "TaskType";
            this.TaskType.Name = "TaskType";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // FromTime
            // 
            this.FromTime.DataPropertyName = "FromTime";
            this.FromTime.HeaderText = "FromTime";
            this.FromTime.Name = "FromTime";
            // 
            // ToTime
            // 
            this.ToTime.DataPropertyName = "ToTime";
            this.ToTime.HeaderText = "ToTime";
            this.ToTime.Name = "ToTime";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "ClientID";
            this.ClientID.HeaderText = "ClientID";
            this.ClientID.Name = "ClientID";
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.Visible = false;
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "TicketNumber";
            this.TicketNumber.Name = "TicketNumber";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(347, 273);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 12;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(92, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(529, 157);
            this.txtDescription.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Description:";
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTaskType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTaskType.FilterRule = null;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(748, 110);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.PropertySelector = null;
            this.cmbTaskType.Size = new System.Drawing.Size(181, 21);
            this.cmbTaskType.SuggestBoxHeight = 95;
            this.cmbTaskType.SuggestListOrderRule = null;
            this.cmbTaskType.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(648, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Task Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(648, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Client Name:";
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClient.FilterRule = null;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(748, 57);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.PropertySelector = null;
            this.cmbClient.Size = new System.Drawing.Size(181, 21);
            this.cmbClient.SuggestBoxHeight = 95;
            this.cmbClient.SuggestListOrderRule = null;
            this.cmbClient.TabIndex = 6;
            // 
            // DtTo
            // 
            this.DtTo.CustomFormat = "hh:mm tt";
            this.DtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtTo.Location = new System.Drawing.Point(532, 61);
            this.DtTo.Name = "DtTo";
            this.DtTo.ShowUpDown = true;
            this.DtTo.Size = new System.Drawing.Size(89, 20);
            this.DtTo.TabIndex = 1;
            // 
            // Dtfrom
            // 
            this.Dtfrom.CustomFormat = "hh:mm tt";
            this.Dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtfrom.Location = new System.Drawing.Point(441, 61);
            this.Dtfrom.Name = "Dtfrom";
            this.Dtfrom.ShowUpDown = true;
            this.Dtfrom.Size = new System.Drawing.Size(85, 20);
            this.Dtfrom.TabIndex = 5;
            // 
            // DtDate
            // 
            this.DtDate.CustomFormat = "dd MMM yyyy ";
            this.DtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtDate.Location = new System.Drawing.Point(92, 61);
            this.DtDate.Name = "DtDate";
            this.DtDate.Size = new System.Drawing.Size(196, 20);
            this.DtDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(344, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time Between:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // DailyWorkReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1074, 604);
            this.Controls.Add(this.groupBox1);
            this.Name = "DailyWorkReport";
            this.Text = "DailyWorkReport";
            this.Load += new System.EventHandler(this.DailyWorkReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtTo;
        private System.Windows.Forms.DateTimePicker Dtfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private AutoCompleteComboBox.SuggestComboBox cmbClient;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private AutoCompleteComboBox.SuggestComboBox cmbTaskType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvWorkReport;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button btnClose;
        private AutoCompleteComboBox.SuggestComboBox cmbTicketNumber;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
    }
}