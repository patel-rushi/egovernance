namespace TestingSystems
{
    partial class SpRequirementMaster
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
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.chkDepartment = new System.Windows.Forms.CheckedListBox();
            this.lblDepartmentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSpRequirement = new System.Windows.Forms.DataGridView();
            this.EDIT = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpRequirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SP_RequirementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSpRequirement = new System.Windows.Forms.TextBox();
            this.GroupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpRequirement)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.Controls.Add(this.chkDepartment);
            this.GroupBoxMain.Controls.Add(this.lblDepartmentLabel);
            this.GroupBoxMain.Controls.Add(this.label3);
            this.GroupBoxMain.Controls.Add(this.txtCode);
            this.GroupBoxMain.Controls.Add(this.label2);
            this.GroupBoxMain.Controls.Add(this.label36);
            this.GroupBoxMain.Controls.Add(this.btnCancle);
            this.GroupBoxMain.Controls.Add(this.btnSave);
            this.GroupBoxMain.Controls.Add(this.dgvSpRequirement);
            this.GroupBoxMain.Controls.Add(this.label1);
            this.GroupBoxMain.Controls.Add(this.txtSpRequirement);
            this.GroupBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(671, 503);
            this.GroupBoxMain.TabIndex = 0;
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Text = "Sp Requirement Master";
            this.GroupBoxMain.Enter += new System.EventHandler(this.GroupBoxMain_Enter);
            // 
            // chkDepartment
            // 
            this.chkDepartment.CheckOnClick = true;
            this.chkDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkDepartment.FormattingEnabled = true;
            this.chkDepartment.Location = new System.Drawing.Point(255, 117);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(222, 116);
            this.chkDepartment.TabIndex = 2;
            this.chkDepartment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkDepartment_ItemCheck);
            // 
            // lblDepartmentLabel
            // 
            this.lblDepartmentLabel.AutoSize = true;
            this.lblDepartmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblDepartmentLabel.Location = new System.Drawing.Point(144, 117);
            this.lblDepartmentLabel.Name = "lblDepartmentLabel";
            this.lblDepartmentLabel.Size = new System.Drawing.Size(78, 16);
            this.lblDepartmentLabel.TabIndex = 46;
            this.lblDepartmentLabel.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(500, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "*";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(255, 43);
            this.txtCode.MaxLength = 5;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(222, 22);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Code";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(500, 82);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(14, 18);
            this.label36.TabIndex = 36;
            this.label36.Text = "*";
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancle.Location = new System.Drawing.Point(357, 248);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "Close";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(276, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSpRequirement
            // 
            this.dgvSpRequirement.AllowUserToAddRows = false;
            this.dgvSpRequirement.AllowUserToDeleteRows = false;
            this.dgvSpRequirement.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSpRequirement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpRequirement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDIT,
            this.DELETE,
            this.Code,
            this.SpRequirement,
            this.SP_RequirementID});
            this.dgvSpRequirement.Location = new System.Drawing.Point(20, 285);
            this.dgvSpRequirement.Name = "dgvSpRequirement";
            this.dgvSpRequirement.ReadOnly = true;
            this.dgvSpRequirement.Size = new System.Drawing.Size(628, 207);
            this.dgvSpRequirement.TabIndex = 5;
            this.dgvSpRequirement.TabStop = false;
            this.dgvSpRequirement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpRequirement_CellContentClick);
            // 
            // EDIT
            // 
            this.EDIT.ActiveLinkColor = System.Drawing.Color.Black;
            this.EDIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EDIT.HeaderText = "";
            this.EDIT.LinkColor = System.Drawing.Color.Black;
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "EDIT";
            this.EDIT.ToolTipText = "EDIT";
            this.EDIT.UseColumnTextForLinkValue = true;
            this.EDIT.VisitedLinkColor = System.Drawing.Color.Black;
            this.EDIT.Width = 80;
            // 
            // DELETE
            // 
            this.DELETE.ActiveLinkColor = System.Drawing.Color.Black;
            this.DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DELETE.HeaderText = "";
            this.DELETE.LinkColor = System.Drawing.Color.Black;
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Text = "DELETE";
            this.DELETE.ToolTipText = "DELETE";
            this.DELETE.UseColumnTextForLinkValue = true;
            this.DELETE.VisitedLinkColor = System.Drawing.Color.Black;
            this.DELETE.Width = 80;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // SpRequirement
            // 
            this.SpRequirement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SpRequirement.DataPropertyName = "SPRequirement";
            this.SpRequirement.HeaderText = "Requirement";
            this.SpRequirement.Name = "SpRequirement";
            this.SpRequirement.ReadOnly = true;
            // 
            // SP_RequirementID
            // 
            this.SP_RequirementID.DataPropertyName = "SPRequirementID";
            this.SP_RequirementID.HeaderText = "SP_RequirementID";
            this.SP_RequirementID.Name = "SP_RequirementID";
            this.SP_RequirementID.ReadOnly = true;
            this.SP_RequirementID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sp. Requirement";
            // 
            // txtSpRequirement
            // 
            this.txtSpRequirement.Location = new System.Drawing.Point(255, 81);
            this.txtSpRequirement.Name = "txtSpRequirement";
            this.txtSpRequirement.Size = new System.Drawing.Size(222, 22);
            this.txtSpRequirement.TabIndex = 1;
            // 
            // SpRequirementMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(695, 521);
            this.Controls.Add(this.GroupBoxMain);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SpRequirementMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SpRequirementMaster_Load);
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpRequirement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSpRequirement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSpRequirement;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewLinkColumn EDIT;
        private System.Windows.Forms.DataGridViewLinkColumn DELETE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpRequirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn SP_RequirementID;
        private System.Windows.Forms.CheckedListBox chkDepartment;
        private System.Windows.Forms.Label lblDepartmentLabel;
    }
}