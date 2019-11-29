namespace TestingSystems
{
    partial class DuesTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuesTicket));
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridShowTicket = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClientNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approval_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pagingControl2 = new PagingUserControl.PagingControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbassign = new System.Windows.Forms.ComboBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.assign = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cmbName = new AutoCompleteComboBox.SuggestComboBox();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            this.BwGetDuetickets = new System.ComponentModel.BackgroundWorker();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridShowTicket)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(366, 176);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridShowTicket
            // 
            this.gridShowTicket.AllowUserToAddRows = false;
            this.gridShowTicket.AllowUserToDeleteRows = false;
            this.gridShowTicket.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridShowTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShowTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.ClientNames,
            this.Version,
            this.Priority,
            this.ModuleName,
            this.Form,
            this.Description,
            this.AssignedTo,
            this.EntryDate,
            this.AssignTo,
            this.Status_,
            this.Approval_Status,
            this.TicketNumber,
            this.TicketID});
            this.gridShowTicket.Location = new System.Drawing.Point(0, 236);
            this.gridShowTicket.Name = "gridShowTicket";
            this.gridShowTicket.Size = new System.Drawing.Size(1076, 364);
            this.gridShowTicket.TabIndex = 6;
            this.gridShowTicket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShowTicket_CellClick);
            this.gridShowTicket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShowTicket_CellContentClick);
            // 
            // select
            // 
            this.select.HeaderText = "";
            this.select.Name = "select";
            this.select.Width = 25;
            // 
            // ClientNames
            // 
            this.ClientNames.DataPropertyName = "ClientName";
            this.ClientNames.HeaderText = "Client Name";
            this.ClientNames.Name = "ClientNames";
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.Width = 70;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.Width = 70;
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "NameOfModule";
            this.ModuleName.Name = "ModuleName";
            // 
            // Form
            // 
            this.Form.DataPropertyName = "FormName";
            this.Form.HeaderText = "NameOfForm";
            this.Form.Name = "Form";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Ticket Description";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // AssignedTo
            // 
            this.AssignedTo.DataPropertyName = "AssignedTo";
            this.AssignedTo.HeaderText = "AssignedTo";
            this.AssignedTo.Name = "AssignedTo";
            // 
            // EntryDate
            // 
            this.EntryDate.DataPropertyName = "EntryDate";
            this.EntryDate.HeaderText = "Assigned Date";
            this.EntryDate.Name = "EntryDate";
            // 
            // AssignTo
            // 
            this.AssignTo.DataPropertyName = "IssueDate";
            this.AssignTo.HeaderText = "Issue Date";
            this.AssignTo.Name = "AssignTo";
            // 
            // Status_
            // 
            this.Status_.DataPropertyName = "Status";
            this.Status_.HeaderText = "Status";
            this.Status_.Name = "Status_";
            this.Status_.Width = 50;
            // 
            // Approval_Status
            // 
            this.Approval_Status.DataPropertyName = "Approval_Status";
            this.Approval_Status.HeaderText = "Approval Status";
            this.Approval_Status.Name = "Approval_Status";
            this.Approval_Status.Width = 50;
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "TicketNumber";
            this.TicketNumber.Name = "TicketNumber";
            // 
            // TicketID
            // 
            this.TicketID.DataPropertyName = "Ticket_ID";
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tickets";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-96, -233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "ClientName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "From Date";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd MMM yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(276, 79);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(186, 20);
            this.dtFrom.TabIndex = 3;
            this.dtFrom.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd MMM yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(276, 117);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(186, 20);
            this.dtTo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "To Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pagingControl2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbassign);
            this.groupBox1.Controls.Add(this.cmbtype);
            this.groupBox1.Controls.Add(this.cmbstatus);
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.edit);
            this.groupBox1.Controls.Add(this.assign);
            this.groupBox1.Controls.Add(this.btnclear);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gridShowTicket);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbName);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(63, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 676);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pagingControl2
            // 
            this.pagingControl2.AutoSize = true;
            this.pagingControl2.CurrentPageSize = 20;
            this.pagingControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl2.Location = new System.Drawing.Point(3, 628);
            this.pagingControl2.Name = "pagingControl2";
            this.pagingControl2.PageSize = ((System.Collections.Generic.List<int>)(resources.GetObject("pagingControl2.PageSize")));
            this.pagingControl2.ProgressMessage = "Loading...";
            this.pagingControl2.ShowProgressBar = true;
            this.pagingControl2.Size = new System.Drawing.Size(1070, 45);
            this.pagingControl2.TabIndex = 73;
            this.pagingControl2.TotalRecords = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(561, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 72;
            this.label8.Text = "Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(561, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 71;
            this.label7.Text = "Assign";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(561, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Status";
            // 
            // cmbassign
            // 
            this.cmbassign.FormattingEnabled = true;
            this.cmbassign.Items.AddRange(new object[] {
            "Select",
            "Assigned",
            "Not Assigned"});
            this.cmbassign.Location = new System.Drawing.Point(637, 78);
            this.cmbassign.Name = "cmbassign";
            this.cmbassign.Size = new System.Drawing.Size(121, 21);
            this.cmbassign.TabIndex = 69;
            this.cmbassign.SelectedIndexChanged += new System.EventHandler(this.cmbassign_SelectedIndexChanged);
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Select",
            "Bug",
            "New requirement",
            "Training"});
            this.cmbtype.Location = new System.Drawing.Point(637, 117);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(121, 21);
            this.cmbtype.TabIndex = 68;
            this.cmbtype.SelectedIndexChanged += new System.EventHandler(this.cmbtype_SelectedIndexChanged);
            // 
            // cmbstatus
            // 
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Select",
            "OPEN",
            "CLOSE"});
            this.cmbstatus.Location = new System.Drawing.Point(638, 42);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(121, 21);
            this.cmbstatus.TabIndex = 67;
            this.cmbstatus.SelectedIndexChanged += new System.EventHandler(this.cmbstatus_SelectedIndexChanged);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.SystemColors.Control;
            this.delete.Location = new System.Drawing.Point(131, 176);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(61, 45);
            this.delete.TabIndex = 65;
            this.delete.Text = "Delete Ticket";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.SystemColors.Control;
            this.edit.Location = new System.Drawing.Point(67, 176);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(58, 45);
            this.edit.TabIndex = 64;
            this.edit.Text = "Edit Ticket";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // assign
            // 
            this.assign.BackColor = System.Drawing.SystemColors.Control;
            this.assign.Location = new System.Drawing.Point(3, 176);
            this.assign.Name = "assign";
            this.assign.Size = new System.Drawing.Size(58, 45);
            this.assign.TabIndex = 63;
            this.assign.Text = "Assign Ticket";
            this.assign.UseVisualStyleBackColor = false;
            this.assign.Click += new System.EventHandler(this.assign_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.SystemColors.Control;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(574, 176);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(79, 28);
            this.btnclear.TabIndex = 15;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.SystemColors.Control;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(473, 176);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(79, 28);
            this.btnDownload.TabIndex = 14;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.FilterRule = null;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(276, 42);
            this.cmbName.Name = "cmbName";
            this.cmbName.PropertySelector = null;
            this.cmbName.Size = new System.Drawing.Size(186, 21);
            this.cmbName.SuggestBoxHeight = 95;
            this.cmbName.SuggestListOrderRule = null;
            this.cmbName.TabIndex = 2;
            this.cmbName.SelectionChangeCommitted += new System.EventHandler(this.cmbName_SelectionChangeCommitted);
            this.cmbName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbName_PreviewKeyDown);
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPageSize = 20;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(3, 610);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.PageSize = ((System.Collections.Generic.List<int>)(resources.GetObject("pagingControl1.PageSize")));
            this.pagingControl1.ProgressMessage = "Loading...";
            this.pagingControl1.ShowProgressBar = true;
            this.pagingControl1.Size = new System.Drawing.Size(1070, 45);
            this.pagingControl1.TabIndex = 16;
            this.pagingControl1.TotalRecords = 0;
            // 
            // BwGetDuetickets
            // 
            this.BwGetDuetickets.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwGetDuetickets_DoWork);
            this.BwGetDuetickets.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwGetDuetickets_RunWorkerCompleted);
            // 
            // DuesTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1201, 731);
            this.Controls.Add(this.groupBox1);
            this.Name = "DuesTicket";
            this.Text = "DuesTicket";
            this.Load += new System.EventHandler(this.DuesTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridShowTicket)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;

        private AutoCompleteComboBox.SuggestComboBox cmbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView gridShowTicket;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker BwGetDuetickets;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnDownload;
        private PagingUserControl.PagingControl pagingControl1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button assign;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approval_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private System.Windows.Forms.ComboBox cmbassign;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private PagingUserControl.PagingControl pagingControl2;
    }
}