namespace TestingSystems
{
    partial class ApprovedTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovedTickets));
            this.GridApproved = new System.Windows.Forms.DataGridView();
            this.ApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FixedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUseName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bwApprovedTicket = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.GridApproved)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridApproved
            // 
            this.GridApproved.AllowUserToAddRows = false;
            this.GridApproved.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridApproved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApprovedBy,
            this.FixedBy,
            this.TicketNumber,
            this.Status,
            this.ModuleName,
            this.FormName,
            this.IssueDate});
            this.GridApproved.Location = new System.Drawing.Point(6, 128);
            this.GridApproved.Name = "GridApproved";
            this.GridApproved.Size = new System.Drawing.Size(942, 480);
            this.GridApproved.TabIndex = 4;
            // 
            // ApprovedBy
            // 
            this.ApprovedBy.DataPropertyName = "ApprovedBy";
            this.ApprovedBy.HeaderText = "Approved By";
            this.ApprovedBy.Name = "ApprovedBy";
            // 
            // FixedBy
            // 
            this.FixedBy.DataPropertyName = "FixedBy";
            this.FixedBy.HeaderText = "Fixed By";
            this.FixedBy.Name = "FixedBy";
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "Ticket Number";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.Width = 110;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "Module Name";
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Width = 150;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormName";
            this.FormName.HeaderText = "Form Name";
            this.FormName.Name = "FormName";
            this.FormName.Width = 150;
            // 
            // IssueDate
            // 
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Approved Tickets";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.pagingControl1);
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbUseName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.GridApproved);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(56, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 658);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(536, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 33);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.pagingControl1.Size = new System.Drawing.Size(948, 45);
            this.pagingControl1.TabIndex = 18;
            this.pagingControl1.TotalRecords = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.Location = new System.Drawing.Point(423, 89);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(86, 33);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd MMM yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(679, 52);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(186, 20);
            this.dtTo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(616, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "To Date";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd MMM yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(428, 52);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(186, 20);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "From Date";
            // 
            // cmbUseName
            // 
            this.cmbUseName.FormattingEnabled = true;
            this.cmbUseName.Location = new System.Drawing.Point(156, 51);
            this.cmbUseName.Name = "cmbUseName";
            this.cmbUseName.Size = new System.Drawing.Size(186, 21);
            this.cmbUseName.TabIndex = 0;
            this.cmbUseName.Text = "Select";
            this.cmbUseName.SelectionChangeCommitted += new System.EventHandler(this.cmbUseName_SelectionChangeCommitted_1);
            this.cmbUseName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbUseName_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "UserName";
            // 
            // bwApprovedTicket
            // 
            this.bwApprovedTicket.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgApprovedTicket_DoWork);
            this.bwApprovedTicket.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgApprovedTicket_RunWorkerCompleted);
            // 
            // ApprovedTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1138, 674);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApprovedTickets";
            this.Text = "ApprovedTickets";
            this.Load += new System.EventHandler(this.ApprovedTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridApproved)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridApproved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUseName;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bwApprovedTicket;
        private PagingUserControl.PagingControl pagingControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn FixedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.Button btnClear;
    }
}