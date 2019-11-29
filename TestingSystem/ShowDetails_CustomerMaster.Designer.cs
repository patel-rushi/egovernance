namespace TestingSystems
{
    partial class ShowDetails_CustomerMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDetails_CustomerMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkStatutory = new System.Windows.Forms.CheckBox();
            this.btnContactDetail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBankDetail = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbtnTDCDetail = new System.Windows.Forms.RadioButton();
            this.rdbTestingCharge = new System.Windows.Forms.RadioButton();
            this.dgvOtherDetails = new System.Windows.Forms.DataGridView();
            this.ViewImages = new System.Windows.Forms.DataGridViewImageColumn();
            this.rdbAddress = new System.Windows.Forms.RadioButton();
            this.rdbBank = new System.Windows.Forms.RadioButton();
            this.rdbContact = new System.Windows.Forms.RadioButton();
            this.btnAddressDetail = new System.Windows.Forms.Button();
            this.cmbCategory = new AutoCompleteComboBox.SuggestComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblPageNums = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.Revise = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNo4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxNo5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Division = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commissionerate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customerflag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            this.cmbCustomerName = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbType = new AutoCompleteComboBox.SuggestComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.panel3);
            this.groupBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(1010, 591);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Customer Register";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.chkStatutory);
            this.panel3.Controls.Add(this.btnContactDetail);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnBankDetail);
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Controls.Add(this.btnAddressDetail);
            this.panel3.Controls.Add(this.cmbCategory);
            this.panel3.Controls.Add(this.btnDownload);
            this.panel3.Controls.Add(this.lblPageNums);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.cmbCustomerName);
            this.panel3.Controls.Add(this.cmbType);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1004, 569);
            this.panel3.TabIndex = 0;
            // 
            // chkStatutory
            // 
            this.chkStatutory.AutoSize = true;
            this.chkStatutory.Location = new System.Drawing.Point(696, 42);
            this.chkStatutory.Name = "chkStatutory";
            this.chkStatutory.Size = new System.Drawing.Size(171, 21);
            this.chkStatutory.TabIndex = 4;
            this.chkStatutory.Text = "Other Statutory Details";
            this.chkStatutory.UseVisualStyleBackColor = true;
            // 
            // btnContactDetail
            // 
            this.btnContactDetail.AutoSize = true;
            this.btnContactDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnContactDetail.Location = new System.Drawing.Point(731, 69);
            this.btnContactDetail.Name = "btnContactDetail";
            this.btnContactDetail.Size = new System.Drawing.Size(130, 28);
            this.btnContactDetail.TabIndex = 9;
            this.btnContactDetail.Text = "Show Contact Detail";
            this.btnContactDetail.UseVisualStyleBackColor = true;
            this.btnContactDetail.Click += new System.EventHandler(this.btnContactDetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(923, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBankDetail
            // 
            this.btnBankDetail.AutoSize = true;
            this.btnBankDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBankDetail.Location = new System.Drawing.Point(472, 69);
            this.btnBankDetail.Name = "btnBankDetail";
            this.btnBankDetail.Size = new System.Drawing.Size(114, 28);
            this.btnBankDetail.TabIndex = 7;
            this.btnBankDetail.Text = "Show Bank Detail";
            this.btnBankDetail.UseVisualStyleBackColor = true;
            this.btnBankDetail.Click += new System.EventHandler(this.btnBankDetail_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbtnTDCDetail);
            this.groupBox6.Controls.Add(this.rdbTestingCharge);
            this.groupBox6.Controls.Add(this.dgvOtherDetails);
            this.groupBox6.Controls.Add(this.rdbAddress);
            this.groupBox6.Controls.Add(this.rdbBank);
            this.groupBox6.Controls.Add(this.rdbContact);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox6.Location = new System.Drawing.Point(6, 391);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(985, 164);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other Details";
            // 
            // rbtnTDCDetail
            // 
            this.rbtnTDCDetail.AutoSize = true;
            this.rbtnTDCDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbtnTDCDetail.Location = new System.Drawing.Point(702, 16);
            this.rbtnTDCDetail.Name = "rbtnTDCDetail";
            this.rbtnTDCDetail.Size = new System.Drawing.Size(77, 17);
            this.rbtnTDCDetail.TabIndex = 4;
            this.rbtnTDCDetail.Text = "TDC Detail";
            this.rbtnTDCDetail.UseVisualStyleBackColor = true;
            this.rbtnTDCDetail.CheckedChanged += new System.EventHandler(this.rbtnTDCDetail_CheckedChanged);
            // 
            // rdbTestingCharge
            // 
            this.rdbTestingCharge.AutoSize = true;
            this.rdbTestingCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rdbTestingCharge.Location = new System.Drawing.Point(594, 16);
            this.rdbTestingCharge.Name = "rdbTestingCharge";
            this.rdbTestingCharge.Size = new System.Drawing.Size(102, 17);
            this.rdbTestingCharge.TabIndex = 3;
            this.rdbTestingCharge.Text = "Testing Charges";
            this.rdbTestingCharge.UseVisualStyleBackColor = true;
            this.rdbTestingCharge.CheckedChanged += new System.EventHandler(this.rdbTestingCharge_CheckedChanged);
            // 
            // dgvOtherDetails
            // 
            this.dgvOtherDetails.AllowUserToAddRows = false;
            this.dgvOtherDetails.AllowUserToDeleteRows = false;
            this.dgvOtherDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOtherDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewImages});
            this.dgvOtherDetails.Location = new System.Drawing.Point(7, 39);
            this.dgvOtherDetails.Name = "dgvOtherDetails";
            this.dgvOtherDetails.ReadOnly = true;
            this.dgvOtherDetails.Size = new System.Drawing.Size(975, 114);
            this.dgvOtherDetails.TabIndex = 5;
            this.dgvOtherDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherDetails_CellContentClick);
            // 
            // ViewImages
            // 
            this.ViewImages.HeaderText = "";
            this.ViewImages.Image = ((System.Drawing.Image)(resources.GetObject("ViewImages.Image")));
            this.ViewImages.Name = "ViewImages";
            this.ViewImages.ReadOnly = true;
            this.ViewImages.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewImages.ToolTipText = "View Images";
            this.ViewImages.Visible = false;
            // 
            // rdbAddress
            // 
            this.rdbAddress.AutoSize = true;
            this.rdbAddress.Checked = true;
            this.rdbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rdbAddress.Location = new System.Drawing.Point(288, 16);
            this.rdbAddress.Name = "rdbAddress";
            this.rdbAddress.Size = new System.Drawing.Size(98, 17);
            this.rdbAddress.TabIndex = 0;
            this.rdbAddress.TabStop = true;
            this.rdbAddress.Text = "Address Details";
            this.rdbAddress.UseVisualStyleBackColor = true;
            this.rdbAddress.CheckedChanged += new System.EventHandler(this.rdbAddress_CheckedChanged);
            // 
            // rdbBank
            // 
            this.rdbBank.AutoSize = true;
            this.rdbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rdbBank.Location = new System.Drawing.Point(503, 16);
            this.rdbBank.Name = "rdbBank";
            this.rdbBank.Size = new System.Drawing.Size(85, 17);
            this.rdbBank.TabIndex = 2;
            this.rdbBank.Text = "Bank Details";
            this.rdbBank.UseVisualStyleBackColor = true;
            this.rdbBank.CheckedChanged += new System.EventHandler(this.rdbBank_CheckedChanged);
            // 
            // rdbContact
            // 
            this.rdbContact.AutoSize = true;
            this.rdbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rdbContact.Location = new System.Drawing.Point(397, 16);
            this.rdbContact.Name = "rdbContact";
            this.rdbContact.Size = new System.Drawing.Size(97, 17);
            this.rdbContact.TabIndex = 1;
            this.rdbContact.Text = "Contact Details";
            this.rdbContact.UseVisualStyleBackColor = true;
            this.rdbContact.CheckedChanged += new System.EventHandler(this.rdbContact_CheckedChanged);
            // 
            // btnAddressDetail
            // 
            this.btnAddressDetail.AutoSize = true;
            this.btnAddressDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddressDetail.Location = new System.Drawing.Point(595, 69);
            this.btnAddressDetail.Name = "btnAddressDetail";
            this.btnAddressDetail.Size = new System.Drawing.Size(130, 28);
            this.btnAddressDetail.TabIndex = 8;
            this.btnAddressDetail.Text = "Show Address Detail";
            this.btnAddressDetail.UseVisualStyleBackColor = true;
            this.btnAddressDetail.Click += new System.EventHandler(this.btnAddressDetail_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FilterRule = null;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Location = new System.Drawing.Point(147, 72);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.PropertySelector = null;
            this.cmbCategory.Size = new System.Drawing.Size(178, 23);
            this.cmbCategory.SuggestBoxHeight = 95;
            this.cmbCategory.SuggestListOrderRule = null;
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.SelectionChangeCommitted += new System.EventHandler(this.cmbCategory_SelectionChangeCommitted);
            this.cmbCategory.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCategory_PreviewKeyDown);
            // 
            // btnDownload
            // 
            this.btnDownload.AutoSize = true;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDownload.Location = new System.Drawing.Point(369, 69);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(90, 28);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblPageNums
            // 
            this.lblPageNums.AutoSize = true;
            this.lblPageNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblPageNums.Location = new System.Drawing.Point(18, 72);
            this.lblPageNums.Name = "lblPageNums";
            this.lblPageNums.Size = new System.Drawing.Size(123, 16);
            this.lblPageNums.TabIndex = 5;
            this.lblPageNums.Text = "Customer Category";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearch.Location = new System.Drawing.Point(867, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(371, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Ind. Type";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(867, 69);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear Filters";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox4.Location = new System.Drawing.Point(3, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(988, 266);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Customer";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvShow);
            this.panel1.Controls.Add(this.pagingControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 246);
            this.panel1.TabIndex = 5;
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvShow.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Revise,
            this.Delete,
            this.RowNo,
            this.Customer_Name,
            this.TypeName,
            this.CustomerCategoryId,
            this.CustomerGroupId,
            this.CustomerTypeId,
            this.CategoryName,
            this.GroupName,
            this.TaxNo1,
            this.TaxNo2,
            this.TaxNo3,
            this.TaxNo4,
            this.TaxNo5,
            this.Range,
            this.Division,
            this.Commissionerate,
            this.VendorCode,
            this.CustomerCode,
            this.Customerflag,
            this.IsDeleted,
            this.Customer_Id,
            this.GSTNo});
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(0, 0);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(982, 201);
            this.dgvShow.TabIndex = 0;
            this.dgvShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellClick);
            this.dgvShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellContentClick);
            this.dgvShow.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_RowEnter);
            // 
            // Revise
            // 
            this.Revise.Frozen = true;
            this.Revise.HeaderText = "";
            this.Revise.LinkColor = System.Drawing.Color.Black;
            this.Revise.Name = "Revise";
            this.Revise.ReadOnly = true;
            this.Revise.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Revise.Text = "EDIT";
            this.Revise.ToolTipText = "EDIT";
            this.Revise.VisitedLinkColor = System.Drawing.Color.Black;
            this.Revise.Width = 5;
            // 
            // Delete
            // 
            this.Delete.Frozen = true;
            this.Delete.HeaderText = "";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Text = "DELETE";
            this.Delete.ToolTipText = "DELETE";
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 5;
            // 
            // RowNo
            // 
            this.RowNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RowNo.DataPropertyName = "RowNo";
            this.RowNo.Frozen = true;
            this.RowNo.HeaderText = "Sr. No.";
            this.RowNo.Name = "RowNo";
            this.RowNo.ReadOnly = true;
            this.RowNo.Width = 40;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "CustomerName";
            this.Customer_Name.Frozen = true;
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 98;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Type";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 56;
            // 
            // CustomerCategoryId
            // 
            this.CustomerCategoryId.DataPropertyName = "CustomerCategoryId";
            this.CustomerCategoryId.HeaderText = "CustomerCategoryId";
            this.CustomerCategoryId.Name = "CustomerCategoryId";
            this.CustomerCategoryId.ReadOnly = true;
            this.CustomerCategoryId.Visible = false;
            this.CustomerCategoryId.Width = 127;
            // 
            // CustomerGroupId
            // 
            this.CustomerGroupId.DataPropertyName = "CustomerGroupId";
            this.CustomerGroupId.HeaderText = "CustomerGroupId";
            this.CustomerGroupId.Name = "CustomerGroupId";
            this.CustomerGroupId.ReadOnly = true;
            this.CustomerGroupId.Visible = false;
            this.CustomerGroupId.Width = 114;
            // 
            // CustomerTypeId
            // 
            this.CustomerTypeId.DataPropertyName = "CustomerTypeId";
            this.CustomerTypeId.HeaderText = "CustomerTypeId";
            this.CustomerTypeId.Name = "CustomerTypeId";
            this.CustomerTypeId.ReadOnly = true;
            this.CustomerTypeId.Visible = false;
            this.CustomerTypeId.Width = 109;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Width = 74;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Group";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Visible = false;
            this.GroupName.Width = 61;
            // 
            // TaxNo1
            // 
            this.TaxNo1.DataPropertyName = "TaxNo1";
            this.TaxNo1.HeaderText = "TaxNo1";
            this.TaxNo1.Name = "TaxNo1";
            this.TaxNo1.ReadOnly = true;
            this.TaxNo1.Width = 70;
            // 
            // TaxNo2
            // 
            this.TaxNo2.DataPropertyName = "TaxNo2";
            this.TaxNo2.HeaderText = "TaxNo2";
            this.TaxNo2.Name = "TaxNo2";
            this.TaxNo2.ReadOnly = true;
            this.TaxNo2.Width = 70;
            // 
            // TaxNo3
            // 
            this.TaxNo3.DataPropertyName = "TaxNo3";
            this.TaxNo3.HeaderText = "TaxNo3";
            this.TaxNo3.Name = "TaxNo3";
            this.TaxNo3.ReadOnly = true;
            this.TaxNo3.Width = 70;
            // 
            // TaxNo4
            // 
            this.TaxNo4.DataPropertyName = "TaxNo4";
            this.TaxNo4.HeaderText = "TaxNo4";
            this.TaxNo4.Name = "TaxNo4";
            this.TaxNo4.ReadOnly = true;
            this.TaxNo4.Width = 70;
            // 
            // TaxNo5
            // 
            this.TaxNo5.DataPropertyName = "TaxNo5";
            this.TaxNo5.HeaderText = "TaxNo5";
            this.TaxNo5.Name = "TaxNo5";
            this.TaxNo5.ReadOnly = true;
            this.TaxNo5.Width = 70;
            // 
            // Range
            // 
            this.Range.DataPropertyName = "Range";
            this.Range.HeaderText = "Range";
            this.Range.Name = "Range";
            this.Range.ReadOnly = true;
            this.Range.Width = 64;
            // 
            // Division
            // 
            this.Division.DataPropertyName = "Division";
            this.Division.HeaderText = "Division";
            this.Division.Name = "Division";
            this.Division.ReadOnly = true;
            this.Division.Width = 69;
            // 
            // Commissionerate
            // 
            this.Commissionerate.DataPropertyName = "Commissionerate";
            this.Commissionerate.HeaderText = "Commission Rate ";
            this.Commissionerate.Name = "Commissionerate";
            this.Commissionerate.ReadOnly = true;
            this.Commissionerate.Width = 106;
            // 
            // VendorCode
            // 
            this.VendorCode.DataPropertyName = "VendorCode";
            this.VendorCode.HeaderText = "Vendor Code";
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.ReadOnly = true;
            this.VendorCode.Width = 87;
            // 
            // CustomerCode
            // 
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "Customer Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            this.CustomerCode.Width = 96;
            // 
            // Customerflag
            // 
            this.Customerflag.DataPropertyName = "Customerflag";
            this.Customerflag.HeaderText = "Customer Flag";
            this.Customerflag.Name = "Customerflag";
            this.Customerflag.ReadOnly = true;
            this.Customerflag.Visible = false;
            this.Customerflag.Width = 91;
            // 
            // IsDeleted
            // 
            this.IsDeleted.DataPropertyName = "IsDeleted";
            this.IsDeleted.HeaderText = "IsDeleted";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            this.IsDeleted.Visible = false;
            this.IsDeleted.Width = 77;
            // 
            // Customer_Id
            // 
            this.Customer_Id.DataPropertyName = "CustomerId";
            this.Customer_Id.HeaderText = "CustomerId";
            this.Customer_Id.Name = "Customer_Id";
            this.Customer_Id.ReadOnly = true;
            this.Customer_Id.Visible = false;
            this.Customer_Id.Width = 85;
            // 
            // GSTNo
            // 
            this.GSTNo.DataPropertyName = "GSTNo";
            this.GSTNo.HeaderText = "GSTNo";
            this.GSTNo.Name = "GSTNo";
            this.GSTNo.ReadOnly = true;
            this.GSTNo.Width = 68;
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPageSize = 20;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(0, 201);
            this.pagingControl1.Margin = new System.Windows.Forms.Padding(4);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.PageSize = ((System.Collections.Generic.List<int>)(resources.GetObject("pagingControl1.PageSize")));
            this.pagingControl1.ProgressMessage = "Loading...";
            this.pagingControl1.ShowProgressBar = true;
            this.pagingControl1.Size = new System.Drawing.Size(982, 45);
            this.pagingControl1.TabIndex = 1;
            this.pagingControl1.TotalRecords = 0;
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.FilterRule = null;
            this.cmbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.IntegralHeight = false;
            this.cmbCustomerName.Location = new System.Drawing.Point(147, 43);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.PropertySelector = null;
            this.cmbCustomerName.Size = new System.Drawing.Size(178, 23);
            this.cmbCustomerName.SuggestBoxHeight = 95;
            this.cmbCustomerName.SuggestListOrderRule = null;
            this.cmbCustomerName.TabIndex = 1;
            this.cmbCustomerName.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomerName_SelectionChangeCommitted);
            this.cmbCustomerName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCustomerName_PreviewKeyDown);
            // 
            // cmbType
            // 
            this.cmbType.FilterRule = null;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.IntegralHeight = false;
            this.cmbType.Location = new System.Drawing.Point(502, 40);
            this.cmbType.Name = "cmbType";
            this.cmbType.PropertySelector = null;
            this.cmbType.Size = new System.Drawing.Size(178, 23);
            this.cmbType.SuggestBoxHeight = 95;
            this.cmbType.SuggestListOrderRule = null;
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectionChangeCommitted += new System.EventHandler(this.cmbType_SelectionChangeCommitted);
            this.cmbType.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbType_PreviewKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(6, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // ShowDetails_CustomerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1027, 615);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShowDetails_CustomerMaster";
            this.ShowIcon = false;
            this.groupBoxMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherDetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageNums;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvShow;
        private PagingUserControl.PagingControl pagingControl1;
        private AutoCompleteComboBox.SuggestComboBox cmbCategory;
        private AutoCompleteComboBox.SuggestComboBox cmbType;
        private AutoCompleteComboBox.SuggestComboBox cmbCustomerName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbAddress;
        private System.Windows.Forms.RadioButton rdbBank;
        private System.Windows.Forms.RadioButton rdbContact;
        private System.Windows.Forms.DataGridView dgvOtherDetails;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBankDetail;
        private System.Windows.Forms.RadioButton rdbTestingCharge;
        private System.Windows.Forms.RadioButton rbtnTDCDetail;
        private System.Windows.Forms.DataGridViewImageColumn ViewImages;
        private System.Windows.Forms.DataGridViewLinkColumn Revise;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNo4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxNo5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Division;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commissionerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customerflag;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTNo;
        private System.Windows.Forms.Button btnAddressDetail;
        private System.Windows.Forms.Button btnContactDetail;
        private System.Windows.Forms.CheckBox chkStatutory;
    }
}