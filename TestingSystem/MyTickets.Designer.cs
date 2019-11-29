namespace TestingSystems
{
    partial class Mytickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mytickets));
            this.GridMyTicket = new System.Windows.Forms.DataGridView();
            this.ViewTicket = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ViewImages = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approval_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbModuleName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbclosed = new System.Windows.Forms.RadioButton();
            this.RdbOpen = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            ((System.ComponentModel.ISupportInitialize)(this.GridMyTicket)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridMyTicket
            // 
            this.GridMyTicket.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridMyTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMyTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViewTicket,
            this.ViewImages,
            this.ClientName,
            this.ModuleName,
            this.FormName,
            this.Priority,
            this.SubmissionDate,
            this.Version,
            this.Description,
            this.STATUS_,
            this.Approval_Status,
            this.EntryDate,
            this.IssueDate,
            this.TicketNumber,
            this.TicketID});
            this.GridMyTicket.Location = new System.Drawing.Point(0, 121);
            this.GridMyTicket.Name = "GridMyTicket";
            this.GridMyTicket.ShowRowErrors = false;
            this.GridMyTicket.Size = new System.Drawing.Size(1076, 495);
            this.GridMyTicket.TabIndex = 3;
            this.GridMyTicket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMyTicket_CellContentClick);
            // 
            // ViewTicket
            // 
            this.ViewTicket.HeaderText = "View Ticket";
            this.ViewTicket.Name = "ViewTicket";
            this.ViewTicket.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewTicket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewTicket.Text = "View Ticket";
            this.ViewTicket.UseColumnTextForButtonValue = true;
            // 
            // ViewImages
            // 
            this.ViewImages.HeaderText = "View Images";
            this.ViewImages.Name = "ViewImages";
            this.ViewImages.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewImages.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewImages.Text = "View Images";
            this.ViewImages.ToolTipText = "ViewImages";
            this.ViewImages.UseColumnTextForButtonValue = true;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "Module Name";
            this.ModuleName.Name = "ModuleName";
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormName";
            this.FormName.HeaderText = "Name Of Form";
            this.FormName.Name = "FormName";
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.Width = 50;
            // 
            // SubmissionDate
            // 
            this.SubmissionDate.DataPropertyName = "SubmissionDate";
            this.SubmissionDate.HeaderText = "SubmissionDate";
            this.SubmissionDate.Name = "SubmissionDate";
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.Width = 50;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // STATUS_
            // 
            this.STATUS_.DataPropertyName = "STATUS";
            this.STATUS_.HeaderText = "Status";
            this.STATUS_.Name = "STATUS_";
            this.STATUS_.Width = 50;
            // 
            // Approval_Status
            // 
            this.Approval_Status.DataPropertyName = "Approval_Status";
            this.Approval_Status.HeaderText = "Approval Status";
            this.Approval_Status.Name = "Approval_Status";
            this.Approval_Status.Width = 50;
            // 
            // EntryDate
            // 
            this.EntryDate.DataPropertyName = "EntryDate";
            this.EntryDate.HeaderText = "Entry Date";
            this.EntryDate.Name = "EntryDate";
            // 
            // IssueDate
            // 
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "Ticket Number";
            this.TicketNumber.Name = "TicketNumber";
            // 
            // TicketID
            // 
            this.TicketID.DataPropertyName = "Ticket_ID";
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(551, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(490, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "My Tickets";
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Location = new System.Drawing.Point(317, 46);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.Size = new System.Drawing.Size(200, 20);
            this.txtTicketNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ticket Number";
            // 
            // cmbModuleName
            // 
            this.cmbModuleName.FormattingEnabled = true;
            this.cmbModuleName.Items.AddRange(new object[] {
            "Master",
            "Pattern"});
            this.cmbModuleName.Location = new System.Drawing.Point(317, 81);
            this.cmbModuleName.Name = "cmbModuleName";
            this.cmbModuleName.Size = new System.Drawing.Size(200, 21);
            this.cmbModuleName.TabIndex = 1;
            this.cmbModuleName.SelectionChangeCommitted += new System.EventHandler(this.cmbModuleName_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Module Name";
            // 
            // rdbclosed
            // 
            this.rdbclosed.AutoSize = true;
            this.rdbclosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbclosed.Location = new System.Drawing.Point(653, 47);
            this.rdbclosed.Name = "rdbclosed";
            this.rdbclosed.Size = new System.Drawing.Size(99, 17);
            this.rdbclosed.TabIndex = 14;
            this.rdbclosed.TabStop = true;
            this.rdbclosed.Text = "ClosedTicket";
            this.rdbclosed.UseVisualStyleBackColor = true;
            this.rdbclosed.CheckedChanged += new System.EventHandler(this.rdbclosed_CheckedChanged);
            // 
            // RdbOpen
            // 
            this.RdbOpen.AutoSize = true;
            this.RdbOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbOpen.Location = new System.Drawing.Point(550, 47);
            this.RdbOpen.Name = "RdbOpen";
            this.RdbOpen.Size = new System.Drawing.Size(91, 17);
            this.RdbOpen.TabIndex = 13;
            this.RdbOpen.TabStop = true;
            this.RdbOpen.Text = "OpenTicket";
            this.RdbOpen.UseVisualStyleBackColor = true;
            this.RdbOpen.CheckedChanged += new System.EventHandler(this.RdbOpen_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pagingControl1);
            this.groupBox1.Controls.Add(this.GridMyTicket);
            this.groupBox1.Controls.Add(this.rdbclosed);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.RdbOpen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTicketNo);
            this.groupBox1.Controls.Add(this.cmbModuleName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(84, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 670);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPageSize = 20;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(3, 622);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.PageSize = ((System.Collections.Generic.List<int>)(resources.GetObject("pagingControl1.PageSize")));
            this.pagingControl1.ProgressMessage = "Loading...";
            this.pagingControl1.ShowProgressBar = true;
            this.pagingControl1.Size = new System.Drawing.Size(1070, 45);
            this.pagingControl1.TabIndex = 17;
            this.pagingControl1.TotalRecords = 0;
            // 
            // Mytickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1245, 691);
            this.Controls.Add(this.groupBox1);
            this.Name = "Mytickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyTickets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MyTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridMyTicket)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridMyTicket;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModuleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbclosed;
        private System.Windows.Forms.RadioButton RdbOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewButtonColumn ViewTicket;
        private System.Windows.Forms.DataGridViewButtonColumn ViewImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmissionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approval_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private PagingUserControl.PagingControl pagingControl1;
    }
}