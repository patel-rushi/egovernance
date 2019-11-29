namespace TestingSystems.HR
{
    partial class EmployeeDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnInActicve = new System.Windows.Forms.RadioButton();
            this.rbtnActive = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpDatefrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.chkRemoveEmployeeCode = new System.Windows.Forms.CheckBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.chkRemoveAllData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilterEmployeeCode = new AutoCompleteComboBox.SuggestComboBox();
            this.txtAddOrRemoveHrs = new System.Windows.Forms.TextBox();
            this.dtpDateto = new System.Windows.Forms.DateTimePicker();
            this.dtpRemoveDate = new System.Windows.Forms.DateTimePicker();
            this.cmbEmployeeCode = new AutoCompleteComboBox.SuggestComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFirstName = new AutoCompleteComboBox.SuggestComboBox();
            this.txtAddHrsOutTime = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.dgvEmployeeDetail = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.isDeleteFlag = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JoiningDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDummy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeavingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxFilteres = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bwEmployeeCode = new System.ComponentModel.BackgroundWorker();
            this.bwEmployeeName = new System.ComponentModel.BackgroundWorker();
            this.bwFilterEmployeeCode = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnInActicve);
            this.groupBox1.Controls.Add(this.rbtnActive);
            this.groupBox1.Controls.Add(this.rbtnAll);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.dtpDatefrom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkRemoveEmployeeCode);
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Controls.Add(this.chkRemoveAllData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFilterEmployeeCode);
            this.groupBox1.Controls.Add(this.txtAddOrRemoveHrs);
            this.groupBox1.Controls.Add(this.dtpDateto);
            this.groupBox1.Controls.Add(this.dtpRemoveDate);
            this.groupBox1.Controls.Add(this.cmbEmployeeCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbFirstName);
            this.groupBox1.Controls.Add(this.txtAddHrsOutTime);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.dgvEmployeeDetail);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.groupBoxFilteres);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(74, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 599);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // rbtnInActicve
            // 
            this.rbtnInActicve.AutoSize = true;
            this.rbtnInActicve.Location = new System.Drawing.Point(664, 149);
            this.rbtnInActicve.Name = "rbtnInActicve";
            this.rbtnInActicve.Size = new System.Drawing.Size(75, 21);
            this.rbtnInActicve.TabIndex = 13;
            this.rbtnInActicve.Text = "InActive";
            this.rbtnInActicve.UseVisualStyleBackColor = true;
            // 
            // rbtnActive
            // 
            this.rbtnActive.AutoSize = true;
            this.rbtnActive.Location = new System.Drawing.Point(602, 149);
            this.rbtnActive.Name = "rbtnActive";
            this.rbtnActive.Size = new System.Drawing.Size(64, 21);
            this.rbtnActive.TabIndex = 12;
            this.rbtnActive.Text = "Active";
            this.rbtnActive.UseVisualStyleBackColor = true;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(561, 149);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(41, 21);
            this.rbtnAll.TabIndex = 11;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoSize = true;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDownload.Location = new System.Drawing.Point(946, 150);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(84, 26);
            this.btnDownload.TabIndex = 16;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(724, 81);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(850, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 26);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear Filters";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(754, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(23, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee Code";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label20.Location = new System.Drawing.Point(357, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Employee Code";
            // 
            // dtpDatefrom
            // 
            this.dtpDatefrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpDatefrom.CustomFormat = "dd MMM yyyy ";
            this.dtpDatefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpDatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatefrom.Location = new System.Drawing.Point(471, 17);
            this.dtpDatefrom.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpDatefrom.Name = "dtpDatefrom";
            this.dtpDatefrom.Size = new System.Drawing.Size(160, 21);
            this.dtpDatefrom.TabIndex = 0;
            this.dtpDatefrom.Value = new System.DateTime(2014, 4, 1, 0, 0, 0, 0);
            this.dtpDatefrom.Visible = false;
            this.dtpDatefrom.ValueChanged += new System.EventHandler(this.dtpDatefrom_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.Location = new System.Drawing.Point(23, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Date";
            // 
            // chkRemoveEmployeeCode
            // 
            this.chkRemoveEmployeeCode.AutoSize = true;
            this.chkRemoveEmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkRemoveEmployeeCode.Location = new System.Drawing.Point(724, 52);
            this.chkRemoveEmployeeCode.Name = "chkRemoveEmployeeCode";
            this.chkRemoveEmployeeCode.Size = new System.Drawing.Size(69, 20);
            this.chkRemoveEmployeeCode.TabIndex = 5;
            this.chkRemoveEmployeeCode.Text = "Absent";
            this.chkRemoveEmployeeCode.UseVisualStyleBackColor = true;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblFirstName.Location = new System.Drawing.Point(312, 150);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(73, 16);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // chkRemoveAllData
            // 
            this.chkRemoveAllData.AutoSize = true;
            this.chkRemoveAllData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkRemoveAllData.Location = new System.Drawing.Point(820, 52);
            this.chkRemoveAllData.Name = "chkRemoveAllData";
            this.chkRemoveAllData.Size = new System.Drawing.Size(178, 20);
            this.chkRemoveAllData.TabIndex = 6;
            this.chkRemoveAllData.Text = "Remove All Dummy Data";
            this.chkRemoveAllData.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(423, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(19, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Change InTime In Minutes";
            // 
            // cmbFilterEmployeeCode
            // 
            this.cmbFilterEmployeeCode.FilterRule = null;
            this.cmbFilterEmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbFilterEmployeeCode.FormattingEnabled = true;
            this.cmbFilterEmployeeCode.IntegralHeight = false;
            this.cmbFilterEmployeeCode.Location = new System.Drawing.Point(135, 147);
            this.cmbFilterEmployeeCode.Name = "cmbFilterEmployeeCode";
            this.cmbFilterEmployeeCode.PropertySelector = null;
            this.cmbFilterEmployeeCode.Size = new System.Drawing.Size(160, 23);
            this.cmbFilterEmployeeCode.SuggestBoxHeight = 95;
            this.cmbFilterEmployeeCode.SuggestListOrderRule = null;
            this.cmbFilterEmployeeCode.TabIndex = 9;
            // 
            // txtAddOrRemoveHrs
            // 
            this.txtAddOrRemoveHrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtAddOrRemoveHrs.Location = new System.Drawing.Point(182, 85);
            this.txtAddOrRemoveHrs.Name = "txtAddOrRemoveHrs";
            this.txtAddOrRemoveHrs.Size = new System.Drawing.Size(160, 21);
            this.txtAddOrRemoveHrs.TabIndex = 3;
            // 
            // dtpDateto
            // 
            this.dtpDateto.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpDateto.CustomFormat = "dd MMM yyyy ";
            this.dtpDateto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpDateto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateto.Location = new System.Drawing.Point(257, 17);
            this.dtpDateto.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpDateto.Name = "dtpDateto";
            this.dtpDateto.Size = new System.Drawing.Size(160, 21);
            this.dtpDateto.TabIndex = 0;
            this.dtpDateto.Value = new System.DateTime(2015, 3, 31, 0, 0, 0, 0);
            this.dtpDateto.Visible = false;
            // 
            // dtpRemoveDate
            // 
            this.dtpRemoveDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpRemoveDate.CustomFormat = "dd MMM yyyy ";
            this.dtpRemoveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.dtpRemoveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemoveDate.Location = new System.Drawing.Point(182, 54);
            this.dtpRemoveDate.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpRemoveDate.Name = "dtpRemoveDate";
            this.dtpRemoveDate.Size = new System.Drawing.Size(160, 21);
            this.dtpRemoveDate.TabIndex = 1;
            this.dtpRemoveDate.Value = new System.DateTime(2015, 3, 31, 0, 0, 0, 0);
            // 
            // cmbEmployeeCode
            // 
            this.cmbEmployeeCode.FilterRule = null;
            this.cmbEmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbEmployeeCode.FormattingEnabled = true;
            this.cmbEmployeeCode.IntegralHeight = false;
            this.cmbEmployeeCode.ItemHeight = 15;
            this.cmbEmployeeCode.Location = new System.Drawing.Point(536, 49);
            this.cmbEmployeeCode.Name = "cmbEmployeeCode";
            this.cmbEmployeeCode.PropertySelector = null;
            this.cmbEmployeeCode.Size = new System.Drawing.Size(160, 23);
            this.cmbEmployeeCode.SuggestBoxHeight = 95;
            this.cmbEmployeeCode.SuggestListOrderRule = null;
            this.cmbEmployeeCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.Location = new System.Drawing.Point(357, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Change OutTime In Minutes";
            // 
            // cmbFirstName
            // 
            this.cmbFirstName.FilterRule = null;
            this.cmbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbFirstName.FormattingEnabled = true;
            this.cmbFirstName.IntegralHeight = false;
            this.cmbFirstName.Location = new System.Drawing.Point(391, 147);
            this.cmbFirstName.Name = "cmbFirstName";
            this.cmbFirstName.PropertySelector = null;
            this.cmbFirstName.Size = new System.Drawing.Size(160, 23);
            this.cmbFirstName.SuggestBoxHeight = 95;
            this.cmbFirstName.SuggestListOrderRule = null;
            this.cmbFirstName.TabIndex = 10;
            // 
            // txtAddHrsOutTime
            // 
            this.txtAddHrsOutTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtAddHrsOutTime.Location = new System.Drawing.Point(536, 83);
            this.txtAddHrsOutTime.Name = "txtAddHrsOutTime";
            this.txtAddHrsOutTime.Size = new System.Drawing.Size(160, 21);
            this.txtAddHrsOutTime.TabIndex = 4;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(455, 565);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(68, 25);
            this.btnsave.TabIndex = 17;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Visible = false;
            // 
            // dgvEmployeeDetail
            // 
            this.dgvEmployeeDetail.AllowUserToAddRows = false;
            this.dgvEmployeeDetail.AllowUserToDeleteRows = false;
            this.dgvEmployeeDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployeeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.isDeleteFlag,
            this.Status,
            this.EmployeeCode,
            this.EmployeeName,
            this.MiddleName,
            this.LastName,
            this.OtherName,
            this.Gender1,
            this.Gender,
            this.EntityId,
            this.Salary,
            this.DOB,
            this.JoiningDate,
            this.EmployeeType,
            this.IsDummy,
            this.IsUpdated,
            this.EmpId,
            this.LeavingDate});
            this.dgvEmployeeDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvEmployeeDetail.Location = new System.Drawing.Point(22, 193);
            this.dgvEmployeeDetail.Name = "dgvEmployeeDetail";
            this.dgvEmployeeDetail.ReadOnly = true;
            this.dgvEmployeeDetail.Size = new System.Drawing.Size(1019, 365);
            this.dgvEmployeeDetail.TabIndex = 17;
            this.dgvEmployeeDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeDetail_CellContentClick);
            this.dgvEmployeeDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeDetail_CellEndEdit);
            this.dgvEmployeeDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEmployeeDetail_DataBindingComplete);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.LinkColor = System.Drawing.Color.Black;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Black;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 65;
            // 
            // isDeleteFlag
            // 
            this.isDeleteFlag.DataPropertyName = "isDeleteFlag";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isDeleteFlag.DefaultCellStyle = dataGridViewCellStyle2;
            this.isDeleteFlag.HeaderText = "Status";
            this.isDeleteFlag.LinkColor = System.Drawing.Color.Black;
            this.isDeleteFlag.Name = "isDeleteFlag";
            this.isDeleteFlag.ReadOnly = true;
            this.isDeleteFlag.Visible = false;
            this.isDeleteFlag.VisitedLinkColor = System.Drawing.Color.Black;
            this.isDeleteFlag.Width = 54;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "isActive";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 73;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.FillWeight = 93.73628F;
            this.EmployeeCode.HeaderText = "Employee Code";
            this.EmployeeCode.MinimumWidth = 10;
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.ReadOnly = true;
            this.EmployeeCode.Width = 75;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.DataPropertyName = "MiddleName";
            this.MiddleName.HeaderText = "MiddleName";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // OtherName
            // 
            this.OtherName.DataPropertyName = "OtherName";
            this.OtherName.HeaderText = "OtherName";
            this.OtherName.Name = "OtherName";
            this.OtherName.ReadOnly = true;
            // 
            // Gender1
            // 
            this.Gender1.DataPropertyName = "Gender";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gender1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Gender1.FillWeight = 62.35155F;
            this.Gender1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gender1.HeaderText = "Gender";
            this.Gender1.Name = "Gender1";
            this.Gender1.ReadOnly = true;
            this.Gender1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Gender1.Visible = false;
            this.Gender1.Width = 62;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            this.Gender.Width = 75;
            // 
            // EntityId
            // 
            this.EntityId.DataPropertyName = "EntityId";
            this.EntityId.HeaderText = "EntityId";
            this.EntityId.Name = "EntityId";
            this.EntityId.ReadOnly = true;
            this.EntityId.Visible = false;
            this.EntityId.Width = 79;
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "Salary";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            this.Salary.Width = 70;
            // 
            // DOB
            // 
            this.DOB.DataPropertyName = "DOB";
            this.DOB.HeaderText = "DOB";
            this.DOB.Name = "DOB";
            this.DOB.ReadOnly = true;
            // 
            // JoiningDate
            // 
            this.JoiningDate.DataPropertyName = "JoiningDate";
            this.JoiningDate.HeaderText = "JoiningDate";
            this.JoiningDate.Name = "JoiningDate";
            this.JoiningDate.ReadOnly = true;
            // 
            // EmployeeType
            // 
            this.EmployeeType.DataPropertyName = "EmployeeType";
            this.EmployeeType.HeaderText = "EmployeeType";
            this.EmployeeType.Name = "EmployeeType";
            this.EmployeeType.ReadOnly = true;
            this.EmployeeType.Width = 120;
            // 
            // IsDummy
            // 
            this.IsDummy.DataPropertyName = "IsDummy";
            this.IsDummy.HeaderText = "IsDummy";
            this.IsDummy.Name = "IsDummy";
            this.IsDummy.ReadOnly = true;
            this.IsDummy.Width = 70;
            // 
            // IsUpdated
            // 
            this.IsUpdated.DataPropertyName = "IsUpdated";
            this.IsUpdated.HeaderText = "IsUpdated";
            this.IsUpdated.Name = "IsUpdated";
            this.IsUpdated.ReadOnly = true;
            this.IsUpdated.Visible = false;
            this.IsUpdated.Width = 97;
            // 
            // EmpId
            // 
            this.EmpId.DataPropertyName = "EmployeeId";
            this.EmpId.HeaderText = "EmployeeId";
            this.EmpId.Name = "EmpId";
            this.EmpId.ReadOnly = true;
            this.EmpId.Visible = false;
            this.EmpId.Width = 106;
            // 
            // LeavingDate
            // 
            this.LeavingDate.DataPropertyName = "LeavingDate";
            this.LeavingDate.HeaderText = "LeavingDate";
            this.LeavingDate.Name = "LeavingDate";
            this.LeavingDate.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(964, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 25);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxFilteres
            // 
            this.groupBoxFilteres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBoxFilteres.Location = new System.Drawing.Point(13, 38);
            this.groupBoxFilteres.Name = "groupBoxFilteres";
            this.groupBoxFilteres.Size = new System.Drawing.Size(1019, 84);
            this.groupBoxFilteres.TabIndex = 0;
            this.groupBoxFilteres.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(13, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1019, 59);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // bwEmployeeCode
            // 
            this.bwEmployeeCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEmployeeCode_DoWork);
            this.bwEmployeeCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwEmployeeCode_RunWorkerCompleted);
            // 
            // bwEmployeeName
            // 
            this.bwEmployeeName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEmployeeName_DoWork);
            this.bwEmployeeName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwEmployeeName_RunWorkerCompleted);
            // 
            // bwFilterEmployeeCode
            // 
            this.bwFilterEmployeeCode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFilterEmployeeCode_DoWork);
            this.bwFilterEmployeeCode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFilterEmployeeCode_RunWorkerCompleted);
            // 
            // EmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1201, 712);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeeDetails";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "EmployeeDetails";
            this.Load += new System.EventHandler(this.EmployeeDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnInActicve;
        private System.Windows.Forms.RadioButton rbtnActive;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpDatefrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkRemoveEmployeeCode;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.CheckBox chkRemoveAllData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AutoCompleteComboBox.SuggestComboBox cmbFilterEmployeeCode;
        private System.Windows.Forms.TextBox txtAddOrRemoveHrs;
        private System.Windows.Forms.DateTimePicker dtpDateto;
        private System.Windows.Forms.DateTimePicker dtpRemoveDate;
        private AutoCompleteComboBox.SuggestComboBox cmbEmployeeCode;
        private System.Windows.Forms.Label label3;
        private AutoCompleteComboBox.SuggestComboBox cmbFirstName;
        private System.Windows.Forms.TextBox txtAddHrsOutTime;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dgvEmployeeDetail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxFilteres;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewLinkColumn isDeleteFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Gender1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn JoiningDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDummy;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeavingDate;
        private System.ComponentModel.BackgroundWorker bwEmployeeCode;
        private System.ComponentModel.BackgroundWorker bwEmployeeName;
        private System.ComponentModel.BackgroundWorker bwFilterEmployeeCode;

    }
}