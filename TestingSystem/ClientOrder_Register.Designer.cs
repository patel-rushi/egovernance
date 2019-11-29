namespace TestingSystems
{
    partial class ClientOrder_Register
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.Button();
            this.AMCPANEL = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.Fromdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ClearFilter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EDIT = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ClientOrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMCRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriprtion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bwClientName = new System.ComponentModel.BackgroundWorker();
            this.scmb_OrderNo = new AutoCompleteComboBox.SuggestComboBox();
            this.cmb_ClientName = new AutoCompleteComboBox.SuggestComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.AMCPANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.scmb_OrderNo);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.Close);
            this.groupBox1.Controls.Add(this.AMCPANEL);
            this.groupBox1.Controls.Add(this.ClearFilter);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmb_ClientName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ClientOrder Register";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(611, 85);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(81, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.Text = "W/ t AMC";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(611, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "AMC";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(611, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartDate,
            this.EndDate,
            this.Amount});
            this.dataGridView2.Location = new System.Drawing.Point(127, 384);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(611, 185);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView2_KeyDown);
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "AMCStartDate";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.StartDate.HeaderText = "From Date";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "AMCEndDate";
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.EndDate.HeaderText = "To Date";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "AMCAmount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Location = new System.Drawing.Point(794, 12);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 8;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // AMCPANEL
            // 
            this.AMCPANEL.Controls.Add(this.label3);
            this.AMCPANEL.Controls.Add(this.ToDate);
            this.AMCPANEL.Controls.Add(this.Fromdate);
            this.AMCPANEL.Controls.Add(this.label4);
            this.AMCPANEL.Location = new System.Drawing.Point(127, 74);
            this.AMCPANEL.Name = "AMCPANEL";
            this.AMCPANEL.Size = new System.Drawing.Size(468, 43);
            this.AMCPANEL.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "From Date:";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd-MMM-yyyy";
            this.ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(360, 7);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(100, 20);
            this.ToDate.TabIndex = 1;
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // Fromdate
            // 
            this.Fromdate.CustomFormat = "dd-MMM-yyyy";
            this.Fromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Fromdate.Location = new System.Drawing.Point(115, 7);
            this.Fromdate.Name = "Fromdate";
            this.Fromdate.Size = new System.Drawing.Size(121, 20);
            this.Fromdate.TabIndex = 0;
            this.Fromdate.ValueChanged += new System.EventHandler(this.Fromdate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(268, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "To Date: ";
            // 
            // ClearFilter
            // 
            this.ClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFilter.Location = new System.Drawing.Point(438, 123);
            this.ClearFilter.Name = "ClearFilter";
            this.ClearFilter.Size = new System.Drawing.Size(89, 26);
            this.ClearFilter.TabIndex = 5;
            this.ClearFilter.Text = "Clear Filter";
            this.ClearFilter.UseVisualStyleBackColor = true;
            this.ClearFilter.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(347, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order No.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Name: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.DELETE,
            this.ClientOrderName,
            this.ClientOrderNo,
            this.OrderAmount,
            this.AMCRequired,
            this.Descriprtion,
            this.OrderDate,
            this.ClientOrderID,
            this.IsDeleted});
            this.dataGridView1.Location = new System.Drawing.Point(12, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(863, 212);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // EDIT
            // 
            this.EDIT.ActiveLinkColor = System.Drawing.Color.Black;
            this.EDIT.HeaderText = "Edit";
            this.EDIT.LinkColor = System.Drawing.Color.Black;
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EDIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EDIT.Text = "Edit";
            this.EDIT.UseColumnTextForLinkValue = true;
            this.EDIT.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // DELETE
            // 
            this.DELETE.ActiveLinkColor = System.Drawing.Color.Black;
            this.DELETE.HeaderText = "Delete";
            this.DELETE.LinkColor = System.Drawing.Color.Black;
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELETE.Text = "Delete";
            this.DELETE.UseColumnTextForLinkValue = true;
            this.DELETE.VisitedLinkColor = System.Drawing.Color.Black;
            // 
            // ClientOrderName
            // 
            this.ClientOrderName.DataPropertyName = "CustomerName";
            this.ClientOrderName.HeaderText = "Company Name";
            this.ClientOrderName.Name = "ClientOrderName";
            this.ClientOrderName.ReadOnly = true;
            // 
            // ClientOrderNo
            // 
            this.ClientOrderNo.DataPropertyName = "ClientOrderNo";
            this.ClientOrderNo.HeaderText = "Order No.";
            this.ClientOrderNo.Name = "ClientOrderNo";
            this.ClientOrderNo.ReadOnly = true;
            // 
            // OrderAmount
            // 
            this.OrderAmount.DataPropertyName = "OrderAmount";
            this.OrderAmount.HeaderText = "Amount";
            this.OrderAmount.Name = "OrderAmount";
            this.OrderAmount.ReadOnly = true;
            // 
            // AMCRequired
            // 
            this.AMCRequired.DataPropertyName = "AMCRequired";
            this.AMCRequired.HeaderText = "AMC Required";
            this.AMCRequired.Name = "AMCRequired";
            this.AMCRequired.ReadOnly = true;
            // 
            // Descriprtion
            // 
            this.Descriprtion.DataPropertyName = "Descriptions";
            this.Descriprtion.HeaderText = "Description";
            this.Descriprtion.Name = "Descriprtion";
            this.Descriprtion.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            dataGridViewCellStyle6.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle6.NullValue = null;
            this.OrderDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.OrderDate.HeaderText = "Date";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // ClientOrderID
            // 
            this.ClientOrderID.DataPropertyName = "ClientOrderID";
            this.ClientOrderID.HeaderText = "ClientOrderID";
            this.ClientOrderID.Name = "ClientOrderID";
            this.ClientOrderID.ReadOnly = true;
            this.ClientOrderID.Visible = false;
            // 
            // IsDeleted
            // 
            this.IsDeleted.DataPropertyName = "IsDeleted";
            this.IsDeleted.HeaderText = "IsDeleted";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            this.IsDeleted.Visible = false;
            // 
            // bwClientName
            // 
            this.bwClientName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwClientName_DoWork);
            this.bwClientName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwClientName_RunWorkerCompleted);
            // 
            // scmb_OrderNo
            // 
            this.scmb_OrderNo.FilterRule = null;
            this.scmb_OrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_OrderNo.FormattingEnabled = true;
            this.scmb_OrderNo.Location = new System.Drawing.Point(487, 35);
            this.scmb_OrderNo.Name = "scmb_OrderNo";
            this.scmb_OrderNo.PropertySelector = null;
            this.scmb_OrderNo.Size = new System.Drawing.Size(100, 21);
            this.scmb_OrderNo.SuggestBoxHeight = 95;
            this.scmb_OrderNo.SuggestListOrderRule = null;
            this.scmb_OrderNo.TabIndex = 12;
            // 
            // cmb_ClientName
            // 
            this.cmb_ClientName.FilterRule = null;
            this.cmb_ClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_ClientName.FormattingEnabled = true;
            this.cmb_ClientName.Location = new System.Drawing.Point(242, 33);
            this.cmb_ClientName.Name = "cmb_ClientName";
            this.cmb_ClientName.PropertySelector = null;
            this.cmb_ClientName.Size = new System.Drawing.Size(121, 21);
            this.cmb_ClientName.SuggestBoxHeight = 95;
            this.cmb_ClientName.SuggestListOrderRule = null;
            this.cmb_ClientName.TabIndex = 0;
            this.cmb_ClientName.SelectionChangeCommitted += new System.EventHandler(this.cmb_ClientName_SelectionChangeCommitted);
            this.cmb_ClientName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmb_ClientName_PreviewKeyDown);
            // 
            // ClientOrder_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "ClientOrder_Register";
            this.Text = "ClientOrder_Register";
            this.Load += new System.EventHandler(this.ClientOrder_Register_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.AMCPANEL.ResumeLayout(false);
            this.AMCPANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker Fromdate;
        private System.Windows.Forms.Label label3;
        private AutoCompleteComboBox.SuggestComboBox cmb_ClientName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.ComponentModel.BackgroundWorker bwClientName;
        private System.Windows.Forms.Panel AMCPANEL;
        private new System.Windows.Forms.Button Close;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridViewLinkColumn EDIT;
        private System.Windows.Forms.DataGridViewLinkColumn DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientOrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMCRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriprtion;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeleted;
        private AutoCompleteComboBox.SuggestComboBox scmb_OrderNo;
    }
}