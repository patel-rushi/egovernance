namespace TestingSystems
{
    partial class CustomerCommunication
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_AddAction = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dtp_ActionDate = new System.Windows.Forms.DateTimePicker();
            this.scmb_pendingAction = new AutoCompleteComboBox.SuggestComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.scmb_Product = new AutoCompleteComboBox.SuggestComboBox();
            this.btn_AddMethod = new System.Windows.Forms.Button();
            this.lblClientName = new System.Windows.Forms.Label();
            this.scmb_CommMethod = new AutoCompleteComboBox.SuggestComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCompanyRep = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.lblPersonRep = new System.Windows.Forms.Label();
            this.lbldiscuss = new System.Windows.Forms.Label();
            this.scmb_PersonRep = new AutoCompleteComboBox.SuggestComboBox();
            this.scmb_CompanyName = new AutoCompleteComboBox.SuggestComboBox();
            this.scmbPersonName = new AutoCompleteComboBox.SuggestComboBox();
            this.txtDiscuss = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunicationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscussDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discussion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bw_CompanyName = new System.ComponentModel.BackgroundWorker();
            this.bw_PersonRep = new System.ComponentModel.BackgroundWorker();
            this.bw_Action = new System.ComponentModel.BackgroundWorker();
            this.bw_CommMethod = new System.ComponentModel.BackgroundWorker();
            this.bw_Product = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 649);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Communication";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_AddAction);
            this.groupBox3.Controls.Add(this.txtRemark);
            this.groupBox3.Controls.Add(this.dtp_ActionDate);
            this.groupBox3.Controls.Add(this.scmb_pendingAction);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(104, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(817, 123);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pending Status ";
            // 
            // btn_AddAction
            // 
            this.btn_AddAction.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btn_AddAction.Location = new System.Drawing.Point(366, 22);
            this.btn_AddAction.Name = "btn_AddAction";
            this.btn_AddAction.Size = new System.Drawing.Size(25, 25);
            this.btn_AddAction.TabIndex = 1;
            this.btn_AddAction.UseVisualStyleBackColor = true;
            this.btn_AddAction.Click += new System.EventHandler(this.btn_AddAction_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(187, 60);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtRemark.Size = new System.Drawing.Size(555, 49);
            this.txtRemark.TabIndex = 3;
            // 
            // dtp_ActionDate
            // 
            this.dtp_ActionDate.CustomFormat = "dd-MMM-yyy";
            this.dtp_ActionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ActionDate.Location = new System.Drawing.Point(572, 22);
            this.dtp_ActionDate.Name = "dtp_ActionDate";
            this.dtp_ActionDate.Size = new System.Drawing.Size(170, 20);
            this.dtp_ActionDate.TabIndex = 2;
            this.dtp_ActionDate.ValueChanged += new System.EventHandler(this.dtp_ActionDate_ValueChanged);
            // 
            // scmb_pendingAction
            // 
            this.scmb_pendingAction.FilterRule = null;
            this.scmb_pendingAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_pendingAction.FormattingEnabled = true;
            this.scmb_pendingAction.Location = new System.Drawing.Point(187, 22);
            this.scmb_pendingAction.Name = "scmb_pendingAction";
            this.scmb_pendingAction.PropertySelector = null;
            this.scmb_pendingAction.Size = new System.Drawing.Size(173, 21);
            this.scmb_pendingAction.SuggestBoxHeight = 95;
            this.scmb_pendingAction.SuggestListOrderRule = null;
            this.scmb_pendingAction.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Remark :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Action Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pending Action :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.scmb_Product);
            this.groupBox2.Controls.Add(this.btn_AddMethod);
            this.groupBox2.Controls.Add(this.lblClientName);
            this.groupBox2.Controls.Add(this.scmb_CommMethod);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lblCompanyRep);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Controls.Add(this.lblPersonName);
            this.groupBox2.Controls.Add(this.lblPersonRep);
            this.groupBox2.Controls.Add(this.lbldiscuss);
            this.groupBox2.Controls.Add(this.scmb_PersonRep);
            this.groupBox2.Controls.Add(this.scmb_CompanyName);
            this.groupBox2.Controls.Add(this.scmbPersonName);
            this.groupBox2.Controls.Add(this.txtDiscuss);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Location = new System.Drawing.Point(103, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(817, 211);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(367, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // scmb_Product
            // 
            this.scmb_Product.FilterRule = null;
            this.scmb_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_Product.FormattingEnabled = true;
            this.scmb_Product.Location = new System.Drawing.Point(191, 63);
            this.scmb_Product.Name = "scmb_Product";
            this.scmb_Product.PropertySelector = null;
            this.scmb_Product.Size = new System.Drawing.Size(170, 21);
            this.scmb_Product.SuggestBoxHeight = 95;
            this.scmb_Product.SuggestListOrderRule = null;
            this.scmb_Product.TabIndex = 2;
            // 
            // btn_AddMethod
            // 
            this.btn_AddMethod.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btn_AddMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddMethod.Location = new System.Drawing.Point(367, 95);
            this.btn_AddMethod.Name = "btn_AddMethod";
            this.btn_AddMethod.Size = new System.Drawing.Size(25, 25);
            this.btn_AddMethod.TabIndex = 7;
            this.btn_AddMethod.UseVisualStyleBackColor = true;
            this.btn_AddMethod.Click += new System.EventHandler(this.btn_AddMethod_Click);
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(46, 32);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(102, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "Company Name :";
            // 
            // scmb_CommMethod
            // 
            this.scmb_CommMethod.FilterRule = null;
            this.scmb_CommMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_CommMethod.FormattingEnabled = true;
            this.scmb_CommMethod.Location = new System.Drawing.Point(191, 97);
            this.scmb_CommMethod.Name = "scmb_CommMethod";
            this.scmb_CommMethod.PropertySelector = null;
            this.scmb_CommMethod.Size = new System.Drawing.Size(170, 21);
            this.scmb_CommMethod.SuggestBoxHeight = 95;
            this.scmb_CommMethod.SuggestListOrderRule = null;
            this.scmb_CommMethod.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btnAdd.Location = new System.Drawing.Point(749, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCompanyRep
            // 
            this.lblCompanyRep.AutoSize = true;
            this.lblCompanyRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyRep.Location = new System.Drawing.Point(46, 66);
            this.lblCompanyRep.Name = "lblCompanyRep";
            this.lblCompanyRep.Size = new System.Drawing.Size(59, 13);
            this.lblCompanyRep.TabIndex = 1;
            this.lblCompanyRep.Text = "Product :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Comm Method :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(429, 100);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date :";
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.Location = new System.Drawing.Point(429, 32);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(93, 13);
            this.lblPersonName.TabIndex = 3;
            this.lblPersonName.Text = "Company Rep :";
            // 
            // lblPersonRep
            // 
            this.lblPersonRep.AutoSize = true;
            this.lblPersonRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonRep.Location = new System.Drawing.Point(429, 66);
            this.lblPersonRep.Name = "lblPersonRep";
            this.lblPersonRep.Size = new System.Drawing.Size(98, 13);
            this.lblPersonRep.TabIndex = 4;
            this.lblPersonRep.Text = "Marketing Rep :";
            // 
            // lbldiscuss
            // 
            this.lbldiscuss.AutoSize = true;
            this.lbldiscuss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscuss.Location = new System.Drawing.Point(46, 134);
            this.lbldiscuss.Name = "lbldiscuss";
            this.lbldiscuss.Size = new System.Drawing.Size(76, 13);
            this.lbldiscuss.TabIndex = 5;
            this.lbldiscuss.Text = "Discussion :";
            // 
            // scmb_PersonRep
            // 
            this.scmb_PersonRep.FilterRule = null;
            this.scmb_PersonRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_PersonRep.FormattingEnabled = true;
            this.scmb_PersonRep.Location = new System.Drawing.Point(573, 64);
            this.scmb_PersonRep.Name = "scmb_PersonRep";
            this.scmb_PersonRep.PropertySelector = null;
            this.scmb_PersonRep.Size = new System.Drawing.Size(170, 21);
            this.scmb_PersonRep.SuggestBoxHeight = 95;
            this.scmb_PersonRep.SuggestListOrderRule = null;
            this.scmb_PersonRep.TabIndex = 4;
            this.scmb_PersonRep.SelectedIndexChanged += new System.EventHandler(this.scmb_PersonRep_SelectedIndexChanged);
            // 
            // scmb_CompanyName
            // 
            this.scmb_CompanyName.FilterRule = null;
            this.scmb_CompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_CompanyName.FormattingEnabled = true;
            this.scmb_CompanyName.Location = new System.Drawing.Point(191, 29);
            this.scmb_CompanyName.Name = "scmb_CompanyName";
            this.scmb_CompanyName.PropertySelector = null;
            this.scmb_CompanyName.Size = new System.Drawing.Size(170, 21);
            this.scmb_CompanyName.SuggestBoxHeight = 95;
            this.scmb_CompanyName.SuggestListOrderRule = null;
            this.scmb_CompanyName.TabIndex = 0;
            this.scmb_CompanyName.SelectionChangeCommitted += new System.EventHandler(this.scmb_CompanyName_SelectionChangeCommitted);
            this.scmb_CompanyName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.scmb_CompanyName_PreviewKeyDown);
            // 
            // scmbPersonName
            // 
            this.scmbPersonName.FilterRule = null;
            this.scmbPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmbPersonName.FormattingEnabled = true;
            this.scmbPersonName.Location = new System.Drawing.Point(573, 32);
            this.scmbPersonName.Name = "scmbPersonName";
            this.scmbPersonName.PropertySelector = null;
            this.scmbPersonName.Size = new System.Drawing.Size(170, 21);
            this.scmbPersonName.SuggestBoxHeight = 95;
            this.scmbPersonName.SuggestListOrderRule = null;
            this.scmbPersonName.TabIndex = 1;
            // 
            // txtDiscuss
            // 
            this.txtDiscuss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscuss.Location = new System.Drawing.Point(191, 134);
            this.txtDiscuss.Multiline = true;
            this.txtDiscuss.Name = "txtDiscuss";
            this.txtDiscuss.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDiscuss.Size = new System.Drawing.Size(552, 68);
            this.txtDiscuss.TabIndex = 9;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(573, 100);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(170, 20);
            this.dtpDate.TabIndex = 8;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(354, 369);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(597, 369);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(516, 369);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(435, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.CompanyName,
            this.PersonName,
            this.CommunicationId,
            this.CustomerId,
            this.ContactId,
            this.CompanyRep,
            this.PersonRep,
            this.DiscussDate,
            this.CommMethod,
            this.Discussion});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(16, 398);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(991, 233);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Edit
            // 
            this.Edit.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.NullValue = "Edit";
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.HeaderText = "Edit";
            this.Edit.LinkColor = System.Drawing.Color.Black;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Black;
            this.Edit.Width = 50;
            // 
            // Delete
            // 
            this.Delete.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.HeaderText = "Delete";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 65;
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CompanyName.DataPropertyName = "CustomerName";
            this.CompanyName.HeaderText = "Company Name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // PersonName
            // 
            this.PersonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonName.DataPropertyName = "PersonName";
            this.PersonName.HeaderText = "Company Rep";
            this.PersonName.Name = "PersonName";
            this.PersonName.ReadOnly = true;
            this.PersonName.Width = 80;
            // 
            // CommunicationId
            // 
            this.CommunicationId.DataPropertyName = "CommunicationId";
            this.CommunicationId.HeaderText = "CommunicationId";
            this.CommunicationId.Name = "CommunicationId";
            this.CommunicationId.ReadOnly = true;
            this.CommunicationId.Visible = false;
            this.CommunicationId.Width = 113;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            this.CustomerId.Width = 85;
            // 
            // ContactId
            // 
            this.ContactId.DataPropertyName = "ContactId";
            this.ContactId.HeaderText = "ContactId";
            this.ContactId.Name = "ContactId";
            this.ContactId.ReadOnly = true;
            this.ContactId.Visible = false;
            this.ContactId.Width = 78;
            // 
            // CompanyRep
            // 
            this.CompanyRep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CompanyRep.DataPropertyName = "CompanyRep";
            this.CompanyRep.HeaderText = "Product";
            this.CompanyRep.Name = "CompanyRep";
            this.CompanyRep.ReadOnly = true;
            this.CompanyRep.Width = 80;
            // 
            // PersonRep
            // 
            this.PersonRep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonRep.DataPropertyName = "PersonRep";
            this.PersonRep.HeaderText = "Marketing Rep";
            this.PersonRep.Name = "PersonRep";
            this.PersonRep.ReadOnly = true;
            this.PersonRep.Width = 80;
            // 
            // DiscussDate
            // 
            this.DiscussDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DiscussDate.DataPropertyName = "DiscussDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.DiscussDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiscussDate.HeaderText = "Date";
            this.DiscussDate.Name = "DiscussDate";
            this.DiscussDate.ReadOnly = true;
            this.DiscussDate.Width = 80;
            // 
            // CommMethod
            // 
            this.CommMethod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CommMethod.DataPropertyName = "CommMethod";
            this.CommMethod.HeaderText = "Comm Method";
            this.CommMethod.Name = "CommMethod";
            this.CommMethod.ReadOnly = true;
            this.CommMethod.Width = 50;
            // 
            // Discussion
            // 
            this.Discussion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Discussion.DataPropertyName = "Discussion";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Discussion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Discussion.HeaderText = "Discussion";
            this.Discussion.Name = "Discussion";
            this.Discussion.ReadOnly = true;
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
            // bw_Action
            // 
            this.bw_Action.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_Action_DoWork);
            this.bw_Action.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_Action_RunWorkerCompleted);
            // 
            // bw_CommMethod
            // 
            this.bw_CommMethod.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_CommMethod_DoWork);
            this.bw_CommMethod.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_CommMethod_RunWorkerCompleted);
            // 
            // bw_Product
            // 
            this.bw_Product.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_Product_DoWork);
            this.bw_Product.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_Product_RunWorkerCompleted);
            // 
            // CustomerCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1050, 674);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerCommunication";
            this.Text = "CustomerCommunication";
            this.Load += new System.EventHandler(this.CustomerCommunication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDiscuss;
        private AutoCompleteComboBox.SuggestComboBox scmbPersonName;
        private AutoCompleteComboBox.SuggestComboBox scmb_CompanyName;
        private System.Windows.Forms.Label lbldiscuss;
        private System.Windows.Forms.Label lblPersonRep;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCompanyRep;
        private System.Windows.Forms.Label lblClientName;
        private System.ComponentModel.BackgroundWorker bw_CompanyName;
        private AutoCompleteComboBox.SuggestComboBox scmb_PersonRep;
        private System.ComponentModel.BackgroundWorker bw_PersonRep;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDownload;
        private AutoCompleteComboBox.SuggestComboBox scmb_CommMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DateTimePicker dtp_ActionDate;
        private AutoCompleteComboBox.SuggestComboBox scmb_pendingAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_AddAction;
        private System.Windows.Forms.Button btn_AddMethod;
        private System.ComponentModel.BackgroundWorker bw_Action;
        private System.ComponentModel.BackgroundWorker bw_CommMethod;
        private System.Windows.Forms.Button button1;
        private AutoCompleteComboBox.SuggestComboBox scmb_Product;
        private System.ComponentModel.BackgroundWorker bw_Product;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private new System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommunicationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscussDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discussion;
    }
}