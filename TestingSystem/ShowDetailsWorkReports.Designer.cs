namespace TestingSystems
{
    partial class ShowDetailsDuesTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDetailsDuesTicket));
            this.BwGetDuetickets = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTicketNumber = new AutoCompleteComboBox.SuggestComboBox();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.cmbUserName = new AutoCompleteComboBox.SuggestComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pagingControl1 = new PagingUserControl.PagingControl();
            this.btnclear = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gridShowTicket = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbName = new AutoCompleteComboBox.SuggestComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShowTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // BwGetDuetickets
            // 
            this.BwGetDuetickets.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwGetDuetickets_DoWork);
            this.BwGetDuetickets.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwGetDuetickets_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTicketNumber);
            this.groupBox1.Controls.Add(this.lblTicketNumber);
            this.groupBox1.Controls.Add(this.cmbUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.pagingControl1);
            this.groupBox1.Controls.Add(this.btnclear);
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
            this.groupBox1.Location = new System.Drawing.Point(78, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 658);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbTicketNumber
            // 
            this.cmbTicketNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTicketNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTicketNumber.FilterRule = null;
            this.cmbTicketNumber.FormattingEnabled = true;
            this.cmbTicketNumber.Location = new System.Drawing.Point(351, 122);
            this.cmbTicketNumber.Name = "cmbTicketNumber";
            this.cmbTicketNumber.PropertySelector = null;
            this.cmbTicketNumber.Size = new System.Drawing.Size(186, 21);
            this.cmbTicketNumber.SuggestBoxHeight = 95;
            this.cmbTicketNumber.SuggestListOrderRule = null;
            this.cmbTicketNumber.TabIndex = 19;
            this.cmbTicketNumber.SelectedIndexChanged += new System.EventHandler(this.cmbTicketNumber_SelectedIndexChanged);
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketNumber.Location = new System.Drawing.Point(241, 123);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(100, 15);
            this.lblTicketNumber.TabIndex = 20;
            this.lblTicketNumber.Text = "Ticket Number";
            // 
            // cmbUserName
            // 
            this.cmbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserName.FilterRule = null;
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(629, 48);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.PropertySelector = null;
            this.cmbUserName.Size = new System.Drawing.Size(186, 21);
            this.cmbUserName.SuggestBoxHeight = 95;
            this.cmbUserName.SuggestListOrderRule = null;
            this.cmbUserName.TabIndex = 17;
            this.cmbUserName.SelectionChangeCommitted += new System.EventHandler(this.cmbUserName_SelectionChangeCommitted);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(545, 48);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 15);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "UserName";
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
            this.pagingControl1.Size = new System.Drawing.Size(952, 45);
            this.pagingControl1.TabIndex = 16;
            this.pagingControl1.TotalRecords = 0;
            this.pagingControl1.Load += new System.EventHandler(this.pagingControl1_Load);
            // 
            // btnclear
            // 
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(532, 158);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(79, 28);
            this.btnclear.TabIndex = 15;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd MMM yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(629, 82);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(186, 20);
            this.dtTo.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(417, 158);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(545, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "To Date";
            // 
            // gridShowTicket
            // 
            this.gridShowTicket.AllowUserToAddRows = false;
            this.gridShowTicket.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridShowTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShowTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.User_Name,
            this.Task,
            this.Date,
            this.time,
            this.Description,
            this.TicketNumber});
            this.gridShowTicket.Location = new System.Drawing.Point(6, 198);
            this.gridShowTicket.Name = "gridShowTicket";
            this.gridShowTicket.Size = new System.Drawing.Size(945, 412);
            this.gridShowTicket.TabIndex = 6;
            this.gridShowTicket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridShowTicket_CellContentClick);
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            // 
            // User_Name
            // 
            this.User_Name.DataPropertyName = "UserName";
            this.User_Name.HeaderText = "UserName";
            this.User_Name.Name = "User_Name";
            // 
            // Task
            // 
            this.Task.DataPropertyName = "TaskType";
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // time
            // 
            this.time.DataPropertyName = "Time";
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 400;
            // 
            // TicketNumber
            // 
            this.TicketNumber.DataPropertyName = "TicketNumber";
            this.TicketNumber.HeaderText = "TicketNumber";
            this.TicketNumber.Name = "TicketNumber";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show Details Work Reports";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.FilterRule = null;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(351, 46);
            this.cmbName.Name = "cmbName";
            this.cmbName.PropertySelector = null;
            this.cmbName.Size = new System.Drawing.Size(186, 21);
            this.cmbName.SuggestBoxHeight = 95;
            this.cmbName.SuggestListOrderRule = null;
            this.cmbName.TabIndex = 2;
            this.cmbName.SelectionChangeCommitted += new System.EventHandler(this.cmbName_SelectionChangeCommitted);
            this.cmbName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbName_PreviewKeyDown);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd MMM yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(351, 83);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(186, 20);
            this.dtFrom.TabIndex = 3;
            this.dtFrom.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-96, -233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Client Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ShowDetailsDuesTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1201, 712);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "ShowDetailsDuesTicket";
            this.Text = "DuesTicket";
            this.Load += new System.EventHandler(this.DuesTicket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShowTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BwGetDuetickets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private AutoCompleteComboBox.SuggestComboBox cmbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridShowTicket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnclear;
        private PagingUserControl.PagingControl pagingControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private AutoCompleteComboBox.SuggestComboBox cmbUserName;
        private System.Windows.Forms.Label lblUserName;
        private AutoCompleteComboBox.SuggestComboBox cmbTicketNumber;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
    }
}