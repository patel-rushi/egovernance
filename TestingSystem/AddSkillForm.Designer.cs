namespace TestingSystems
{
    partial class AddSkillForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkApproval = new System.Windows.Forms.CheckBox();
            this.lblApproval = new System.Windows.Forms.Label();
            this.ImgProfilePic = new System.Windows.Forms.PictureBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.btnLogo = new System.Windows.Forms.Button();
            this.txtOrganization = new System.Windows.Forms.TextBox();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.FileDialogLogo = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkApproval);
            this.groupBox1.Controls.Add(this.lblApproval);
            this.groupBox1.Controls.Add(this.ImgProfilePic);
            this.groupBox1.Controls.Add(this.btn_Submit);
            this.groupBox1.Controls.Add(this.cmbCourse);
            this.groupBox1.Controls.Add(this.txtLogo);
            this.groupBox1.Controls.Add(this.btnLogo);
            this.groupBox1.Controls.Add(this.txtOrganization);
            this.groupBox1.Controls.Add(this.cmbEvent);
            this.groupBox1.Controls.Add(this.lblOrganization);
            this.groupBox1.Controls.Add(this.lblDocument);
            this.groupBox1.Controls.Add(this.lblCourse);
            this.groupBox1.Controls.Add(this.lblEvent);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.Location = new System.Drawing.Point(74, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 599);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skill Form";
            // 
            // chkApproval
            // 
            this.chkApproval.AutoSize = true;
            this.chkApproval.Location = new System.Drawing.Point(205, 196);
            this.chkApproval.Name = "chkApproval";
            this.chkApproval.Size = new System.Drawing.Size(83, 21);
            this.chkApproval.TabIndex = 26;
            this.chkApproval.Text = "Approval";
            this.chkApproval.UseVisualStyleBackColor = true;
            // 
            // lblApproval
            // 
            this.lblApproval.AutoSize = true;
            this.lblApproval.Location = new System.Drawing.Point(60, 197);
            this.lblApproval.Name = "lblApproval";
            this.lblApproval.Size = new System.Drawing.Size(64, 17);
            this.lblApproval.TabIndex = 25;
            this.lblApproval.Text = "Approval";
            // 
            // ImgProfilePic
            // 
            this.ImgProfilePic.Location = new System.Drawing.Point(477, 22);
            this.ImgProfilePic.Name = "ImgProfilePic";
            this.ImgProfilePic.Size = new System.Drawing.Size(555, 571);
            this.ImgProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgProfilePic.TabIndex = 22;
            this.ImgProfilePic.TabStop = false;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(205, 237);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(75, 24);
            this.btn_Submit.TabIndex = 9;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(205, 100);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(215, 25);
            this.cmbCourse.TabIndex = 5;
            // 
            // txtLogo
            // 
            this.txtLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtLogo.Location = new System.Drawing.Point(205, 164);
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.ReadOnly = true;
            this.txtLogo.Size = new System.Drawing.Size(179, 21);
            this.txtLogo.TabIndex = 7;
            // 
            // btnLogo
            // 
            this.btnLogo.AutoSize = true;
            this.btnLogo.Location = new System.Drawing.Point(390, 161);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(30, 27);
            this.btnLogo.TabIndex = 8;
            this.btnLogo.Text = "...";
            this.btnLogo.UseVisualStyleBackColor = true;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // txtOrganization
            // 
            this.txtOrganization.Location = new System.Drawing.Point(205, 131);
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Size = new System.Drawing.Size(215, 23);
            this.txtOrganization.TabIndex = 6;
            // 
            // cmbEvent
            // 
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.Location = new System.Drawing.Point(205, 69);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(215, 25);
            this.cmbEvent.TabIndex = 4;
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(60, 134);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(89, 17);
            this.lblOrganization.TabIndex = 3;
            this.lblOrganization.Text = "Organization";
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Location = new System.Drawing.Point(60, 165);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(121, 17);
            this.lblDocument.TabIndex = 2;
            this.lblDocument.Text = "Upload Document";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(60, 104);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(53, 17);
            this.lblCourse.TabIndex = 1;
            this.lblCourse.Text = "Course";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(60, 72);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(44, 17);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event";
            // 
            // FileDialogLogo
            // 
            this.FileDialogLogo.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialogLogo_FileOk);
            // 
            // AddSkillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 712);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddSkillForm";
            this.Text = "AddSkillForm";
            this.Load += new System.EventHandler(this.AddSkillForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtOrganization;
        private System.Windows.Forms.TextBox txtLogo;
        private System.Windows.Forms.Button btnLogo;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.OpenFileDialog FileDialogLogo;
        private System.Windows.Forms.PictureBox ImgProfilePic;
        private System.Windows.Forms.Label lblApproval;
        private System.Windows.Forms.CheckBox chkApproval;
    }
}