namespace TestingSystems
{
    partial class TicketsApproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketsApproval));
            this.GridApproval = new System.Windows.Forms.DataGridView();
            this.Approved = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NotApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            ((System.ComponentModel.ISupportInitialize)(this.GridApproval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridApproval
            // 
            this.GridApproval.AllowUserToAddRows = false;
            this.GridApproval.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GridApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Approved,
            this.NotApprove,
            this.UserName,
            this.ClientName,
            this.ModuleName,
            this.FormName,
            this.Priority,
            this.Version,
            this.Description,
            this.IssueDate,
            this.Status,
            this.ApprovalStatus,
            this.TicketNumber,
            this.TicketID});
            this.GridApproval.Location = new System.Drawing.Point(0, 55);
            this.GridApproval.Name = "GridApproval";
            this.GridApproval.Size = new System.Drawing.Size(1076, 501);
            this.GridApproval.TabIndex = 0;
            this.GridApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridApproval_CellContentClick);
            this.GridApproval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridApproval_DataBindingComplete);
            // 
            // Approved
            // 
            this.Approved.HeaderText = "Completed";
            this.Approved.Name = "Approved";
            this.Approved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Approved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Approved.Text = "Completed";
            this.Approved.UseColumnTextForButtonValue = true;
            // 
            // NotApprove
            // 
            this.NotApprove.HeaderText = "Pending";
            this.NotApprove.Name = "NotApprove";
            this.NotApprove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NotApprove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NotApprove.Text = "Pending";
            this.NotApprove.UseColumnTextForButtonValue = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "FixedBy";
            this.UserName.HeaderText = "Fixed By";
            this.UserName.Name = "UserName";
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.HeaderText = "ClientName";
            this.ClientName.Name = "ClientName";
            // 
            // ModuleName
            // 
            this.ModuleName.DataPropertyName = "ModuleName";
            this.ModuleName.HeaderText = "ModuleName";
            this.ModuleName.Name = "ModuleName";
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormName";
            this.FormName.HeaderText = "Form Name";
            this.FormName.Name = "FormName";
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.Width = 50;
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
            // IssueDate
            // 
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "STATUS";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 50;
            // 
            // ApprovalStatus
            // 
            this.ApprovalStatus.DataPropertyName = "Approval_Status";
            this.ApprovalStatus.HeaderText = "ApprovalStatus";
            this.ApprovalStatus.Name = "ApprovalStatus";
            this.ApprovalStatus.Width = 50;
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
            this.label1.Location = new System.Drawing.Point(437, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tickets For Approval";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pagingControl1);
            this.groupBox1.Controls.Add(this.GridApproval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(45, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1080, 603);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pagingControl1
            // 
            this.pagingControl1.AutoSize = true;
            this.pagingControl1.CurrentPageSize = 20;
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(3, 555);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.PageSize = ((System.Collections.Generic.List<int>)(resources.GetObject("pagingControl1.PageSize")));
            this.pagingControl1.ProgressMessage = "Loading...";
            this.pagingControl1.ShowProgressBar = true;
            this.pagingControl1.Size = new System.Drawing.Size(1074, 45);
            this.pagingControl1.TabIndex = 17;
            this.pagingControl1.TotalRecords = 0;
            // 
            // TicketsApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1136, 630);
            this.Controls.Add(this.groupBox1);
            this.Name = "TicketsApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicketsApproval";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TicketsApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridApproval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridApproval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private PagingUserControl.PagingControl pagingControl1;
        private System.Windows.Forms.DataGridViewButtonColumn Approved;
        private System.Windows.Forms.DataGridViewButtonColumn NotApprove;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
    }
}