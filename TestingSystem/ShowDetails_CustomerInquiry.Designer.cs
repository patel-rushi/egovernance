namespace TestingSystems
{
    partial class ShowDetails_CustomerInquiry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scmb_Product = new AutoCompleteComboBox.SuggestComboBox();
            this.dtp_inquiryDateTo = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.scmb_PersonRep = new AutoCompleteComboBox.SuggestComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpInquiryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbState = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbCity = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbCompanyName = new AutoCompleteComboBox.SuggestComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InquiryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InquirySource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Refrence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReasonIfLost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WLDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bw_CompanyName = new System.ComponentModel.BackgroundWorker();
            this.bw_PersonRep = new System.ComponentModel.BackgroundWorker();
            this.bw_Product = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.scmb_Product);
            this.groupBox1.Controls.Add(this.dtp_inquiryDateTo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.scmb_PersonRep);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnClearFilter);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpInquiryDate);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.cmbCompanyName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1060, 597);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Inquiry Register";
            // 
            // scmb_Product
            // 
            this.scmb_Product.FilterRule = null;
            this.scmb_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.scmb_Product.FormattingEnabled = true;
            this.scmb_Product.Location = new System.Drawing.Point(783, 77);
            this.scmb_Product.Name = "scmb_Product";
            this.scmb_Product.PropertySelector = null;
            this.scmb_Product.Size = new System.Drawing.Size(174, 21);
            this.scmb_Product.SuggestBoxHeight = 95;
            this.scmb_Product.SuggestListOrderRule = null;
            this.scmb_Product.TabIndex = 3;
            // 
            // dtp_inquiryDateTo
            // 
            this.dtp_inquiryDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtp_inquiryDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtp_inquiryDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_inquiryDateTo.Location = new System.Drawing.Point(783, 140);
            this.dtp_inquiryDateTo.Name = "dtp_inquiryDateTo";
            this.dtp_inquiryDateTo.Size = new System.Drawing.Size(174, 20);
            this.dtp_inquiryDateTo.TabIndex = 7;
            this.dtp_inquiryDateTo.ValueChanged += new System.EventHandler(this.dtp_inquiryDateTo_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(585, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Inquiry date To :";
            // 
            // scmb_PersonRep
            // 
            this.scmb_PersonRep.FilterRule = null;
            this.scmb_PersonRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.scmb_PersonRep.FormattingEnabled = true;
            this.scmb_PersonRep.Location = new System.Drawing.Point(783, 107);
            this.scmb_PersonRep.Name = "scmb_PersonRep";
            this.scmb_PersonRep.PropertySelector = null;
            this.scmb_PersonRep.Size = new System.Drawing.Size(174, 21);
            this.scmb_PersonRep.SuggestBoxHeight = 95;
            this.scmb_PersonRep.SuggestListOrderRule = null;
            this.scmb_PersonRep.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(979, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClearFilter.Location = new System.Drawing.Point(539, 167);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 9;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSearch.Location = new System.Drawing.Point(447, 167);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpInquiryDate
            // 
            this.dtpInquiryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpInquiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpInquiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInquiryDate.Location = new System.Drawing.Point(247, 140);
            this.dtpInquiryDate.Name = "dtpInquiryDate";
            this.dtpInquiryDate.Size = new System.Drawing.Size(174, 20);
            this.dtpInquiryDate.TabIndex = 6;
            this.dtpInquiryDate.ValueChanged += new System.EventHandler(this.dtpInquiryDate_ValueChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FilterRule = null;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(783, 47);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.PropertySelector = null;
            this.cmbStatus.Size = new System.Drawing.Size(174, 21);
            this.cmbStatus.SuggestBoxHeight = 95;
            this.cmbStatus.SuggestListOrderRule = null;
            this.cmbStatus.TabIndex = 1;
            // 
            // cmbState
            // 
            this.cmbState.FilterRule = null;
            this.cmbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(247, 109);
            this.cmbState.Name = "cmbState";
            this.cmbState.PropertySelector = null;
            this.cmbState.Size = new System.Drawing.Size(174, 21);
            this.cmbState.SuggestBoxHeight = 95;
            this.cmbState.SuggestListOrderRule = null;
            this.cmbState.TabIndex = 4;
            // 
            // cmbCity
            // 
            this.cmbCity.FilterRule = null;
            this.cmbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(247, 78);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.PropertySelector = null;
            this.cmbCity.Size = new System.Drawing.Size(174, 21);
            this.cmbCity.SuggestBoxHeight = 95;
            this.cmbCity.SuggestListOrderRule = null;
            this.cmbCity.TabIndex = 2;
            this.cmbCity.SelectionChangeCommitted += new System.EventHandler(this.cmbCity_SelectionChangeCommitted);
            this.cmbCity.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCity_PreviewKeyDown);
            // 
            // cmbCompanyName
            // 
            this.cmbCompanyName.FilterRule = null;
            this.cmbCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbCompanyName.FormattingEnabled = true;
            this.cmbCompanyName.Location = new System.Drawing.Point(247, 47);
            this.cmbCompanyName.Name = "cmbCompanyName";
            this.cmbCompanyName.PropertySelector = null;
            this.cmbCompanyName.Size = new System.Drawing.Size(174, 21);
            this.cmbCompanyName.SuggestBoxHeight = 95;
            this.cmbCompanyName.SuggestListOrderRule = null;
            this.cmbCompanyName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(87, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Inquiry Date from :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(585, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Rep Person :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(585, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Product :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(585, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current Status :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(87, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "State Filter :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(87, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "City Filter :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(87, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Name :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.CustomerId,
            this.ContactId,
            this.InquiryId,
            this.CompanyName,
            this.PersonName,
            this.Email,
            this.ContactNo,
            this.City,
            this.State,
            this.Date,
            this.InquirySource,
            this.Refrence,
            this.CompanyRep,
            this.RepName,
            this.CurrentStatus,
            this.ReasonIfLost,
            this.WLDate});
            this.dataGridView1.Location = new System.Drawing.Point(7, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1047, 358);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Edit
            // 
            this.Edit.ActiveLinkColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.NullValue = "Edit";
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.Frozen = true;
            this.Edit.HeaderText = "Edit";
            this.Edit.LinkColor = System.Drawing.Color.Black;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Text = "Edit";
            this.Edit.VisitedLinkColor = System.Drawing.Color.Black;
            this.Edit.Width = 57;
            // 
            // Delete
            // 
            this.Delete.ActiveLinkColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.Frozen = true;
            this.Delete.HeaderText = "Delete";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Text = "Delete";
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 74;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            this.CustomerId.Width = 104;
            // 
            // ContactId
            // 
            this.ContactId.DataPropertyName = "ContactId";
            this.ContactId.HeaderText = "ContactId";
            this.ContactId.Name = "ContactId";
            this.ContactId.ReadOnly = true;
            this.ContactId.Visible = false;
            this.ContactId.Width = 92;
            // 
            // InquiryId
            // 
            this.InquiryId.DataPropertyName = "InquiryID";
            this.InquiryId.HeaderText = "InquiryId";
            this.InquiryId.Name = "InquiryId";
            this.InquiryId.ReadOnly = true;
            this.InquiryId.Visible = false;
            this.InquiryId.Width = 86;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CustomerName";
            this.CompanyName.Frozen = true;
            this.CompanyName.HeaderText = "Company Name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 122;
            // 
            // PersonName
            // 
            this.PersonName.DataPropertyName = "PersonName";
            this.PersonName.HeaderText = "Company Rep";
            this.PersonName.Name = "PersonName";
            this.PersonName.ReadOnly = true;
            this.PersonName.Width = 112;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 67;
            // 
            // ContactNo
            // 
            this.ContactNo.DataPropertyName = "ContactNo";
            this.ContactNo.HeaderText = "Contact No";
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.ReadOnly = true;
            this.ContactNo.Width = 95;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 56;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 66;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "InquiryDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.Date.DefaultCellStyle = dataGridViewCellStyle3;
            this.Date.HeaderText = "Inquiry Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // InquirySource
            // 
            this.InquirySource.DataPropertyName = "InquirySource";
            this.InquirySource.HeaderText = "Inquiry Source";
            this.InquirySource.Name = "InquirySource";
            this.InquirySource.ReadOnly = true;
            this.InquirySource.Width = 114;
            // 
            // Refrence
            // 
            this.Refrence.DataPropertyName = "Refrence";
            this.Refrence.HeaderText = "Refrence";
            this.Refrence.Name = "Refrence";
            this.Refrence.ReadOnly = true;
            this.Refrence.Width = 91;
            // 
            // CompanyRep
            // 
            this.CompanyRep.DataPropertyName = "Representative_Company";
            this.CompanyRep.HeaderText = "Product";
            this.CompanyRep.Name = "CompanyRep";
            this.CompanyRep.ReadOnly = true;
            this.CompanyRep.Width = 82;
            // 
            // RepName
            // 
            this.RepName.DataPropertyName = "RepresentativePerson";
            this.RepName.HeaderText = "Representative Person";
            this.RepName.Name = "RepName";
            this.RepName.ReadOnly = true;
            this.RepName.Width = 162;
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.DataPropertyName = "Current_Status";
            this.CurrentStatus.HeaderText = "Inquiry Status";
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.ReadOnly = true;
            this.CurrentStatus.Width = 109;
            // 
            // ReasonIfLost
            // 
            this.ReasonIfLost.DataPropertyName = "Reason_For_Lost";
            this.ReasonIfLost.HeaderText = "if Lost, Reason";
            this.ReasonIfLost.Name = "ReasonIfLost";
            this.ReasonIfLost.ReadOnly = true;
            this.ReasonIfLost.Width = 117;
            // 
            // WLDate
            // 
            this.WLDate.DataPropertyName = "Inquiry_Loss_Win_Date";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.WLDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.WLDate.HeaderText = "Lost/Won Date";
            this.WLDate.Name = "WLDate";
            this.WLDate.ReadOnly = true;
            this.WLDate.Width = 116;
            // 
            // bw_CompanyName
            // 
            this.bw_CompanyName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_CompanyName_DoWork);
            this.bw_CompanyName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_CompanyName_RunWorkerCompleted);
            // 
            // bw_PersonRep
            // 
            this.bw_PersonRep.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_PersonRep_DoWork);
            this.bw_PersonRep.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_PersonRep_RunWorkerCompleted);
            // 
            // bw_Product
            // 
            this.bw_Product.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_Product_DoWork);
            this.bw_Product.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_Product_RunWorkerCompleted);
            // 
            // ShowDetails_CustomerInquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1085, 621);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShowDetails_CustomerInquiry";
            this.Text = "ShowDetails_CustomerInquiry";
            this.Load += new System.EventHandler(this.ShowDetails_CustomerInquiry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private AutoCompleteComboBox.SuggestComboBox cmbCompanyName;
        private System.Windows.Forms.DateTimePicker dtpInquiryDate;
        private AutoCompleteComboBox.SuggestComboBox cmbStatus;
        private AutoCompleteComboBox.SuggestComboBox cmbState;
        private AutoCompleteComboBox.SuggestComboBox cmbCity;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bw_CompanyName;
        private AutoCompleteComboBox.SuggestComboBox scmb_PersonRep;
        private System.ComponentModel.BackgroundWorker bw_PersonRep;
        private System.Windows.Forms.DateTimePicker dtp_inquiryDateTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InquiryId;
        private new System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn InquirySource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Refrence;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonIfLost;
        private System.Windows.Forms.DataGridViewTextBoxColumn WLDate;
        private AutoCompleteComboBox.SuggestComboBox scmb_Product;
        private System.ComponentModel.BackgroundWorker bw_Product;
    }
}