namespace TestingSystems
{
    partial class SkillsetDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCourse = new AutoCompleteComboBox.SuggestComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEvent = new AutoCompleteComboBox.SuggestComboBox();
            this.dgvSkillDetail = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkillDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dgvSkillDetail);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(191, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 416);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skill Details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbCourse);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbEvent);
            this.groupBox3.Location = new System.Drawing.Point(17, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 59);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(461, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(220, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Course";
            // 
            // cmbCourse
            // 
            this.cmbCourse.FilterRule = null;
            this.cmbCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.IntegralHeight = false;
            this.cmbCourse.Location = new System.Drawing.Point(277, 23);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.PropertySelector = null;
            this.cmbCourse.Size = new System.Drawing.Size(160, 23);
            this.cmbCourse.SuggestBoxHeight = 95;
            this.cmbCourse.SuggestListOrderRule = null;
            this.cmbCourse.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Event";
            // 
            // cmbEvent
            // 
            this.cmbEvent.FilterRule = null;
            this.cmbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.IntegralHeight = false;
            this.cmbEvent.Location = new System.Drawing.Point(54, 23);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.PropertySelector = null;
            this.cmbEvent.Size = new System.Drawing.Size(160, 23);
            this.cmbEvent.SuggestBoxHeight = 95;
            this.cmbEvent.SuggestListOrderRule = null;
            this.cmbEvent.TabIndex = 11;
            // 
            // dgvSkillDetail
            // 
            this.dgvSkillDetail.AllowUserToAddRows = false;
            this.dgvSkillDetail.AllowUserToDeleteRows = false;
            this.dgvSkillDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSkillDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSkillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkillDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Status,
            this.Course,
            this.Organization,
            this.approval,
            this.insertdate,
            this.SkillId,
            this.UserId,
            this.Img});
            this.dgvSkillDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSkillDetail.Location = new System.Drawing.Point(17, 107);
            this.dgvSkillDetail.Name = "dgvSkillDetail";
            this.dgvSkillDetail.ReadOnly = true;
            this.dgvSkillDetail.Size = new System.Drawing.Size(545, 269);
            this.dgvSkillDetail.TabIndex = 19;
            this.dgvSkillDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSkillDetail_CellContentClick);
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
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "eventname";
            this.Status.HeaderText = "Event Name";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Course
            // 
            this.Course.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Course.DataPropertyName = "course";
            this.Course.FillWeight = 93.73628F;
            this.Course.HeaderText = "Course";
            this.Course.MinimumWidth = 10;
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            // 
            // Organization
            // 
            this.Organization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Organization.DataPropertyName = "organization";
            this.Organization.HeaderText = "Organization";
            this.Organization.Name = "Organization";
            this.Organization.ReadOnly = true;
            // 
            // approval
            // 
            this.approval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approval.DataPropertyName = "Approval";
            this.approval.HeaderText = "Approval";
            this.approval.Name = "approval";
            this.approval.ReadOnly = true;
            // 
            // insertdate
            // 
            this.insertdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.insertdate.DataPropertyName = "InsertDate";
            this.insertdate.HeaderText = "Submit Date";
            this.insertdate.Name = "insertdate";
            this.insertdate.ReadOnly = true;
            // 
            // SkillId
            // 
            this.SkillId.DataPropertyName = "SkillId";
            this.SkillId.HeaderText = "Skill ID";
            this.SkillId.Name = "SkillId";
            this.SkillId.ReadOnly = true;
            this.SkillId.Visible = false;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "userid";
            this.UserId.HeaderText = "User Id";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // Img
            // 
            this.Img.DataPropertyName = "img";
            this.Img.HeaderText = "img";
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            this.Img.Visible = false;
            // 
            // SkillsetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1201, 712);
            this.Controls.Add(this.groupBox1);
            this.Name = "SkillsetDetails";
            this.Text = "SkillsetDetails";
            this.Load += new System.EventHandler(this.SkillsetDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkillDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSkillDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private AutoCompleteComboBox.SuggestComboBox cmbCourse;
        private System.Windows.Forms.Label label5;
        private AutoCompleteComboBox.SuggestComboBox cmbEvent;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organization;
        private System.Windows.Forms.DataGridViewTextBoxColumn approval;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkillId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Img;
    }
}