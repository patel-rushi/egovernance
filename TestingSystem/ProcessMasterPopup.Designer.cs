namespace TestingSystems
{
    partial class ProcessMasterPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessMasterPopup));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.chkProcess = new System.Windows.Forms.CheckedListBox();
            this.btnSaveProcess = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.chkAll);
            this.gbMain.Controls.Add(this.btnAddProcess);
            this.gbMain.Controls.Add(this.label40);
            this.gbMain.Controls.Add(this.chkProcess);
            this.gbMain.Controls.Add(this.btnSaveProcess);
            this.gbMain.Controls.Add(this.btnClose);
            this.gbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.gbMain.Location = new System.Drawing.Point(11, 11);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(411, 328);
            this.gbMain.TabIndex = 5;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Process Master";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkAll.Location = new System.Drawing.Point(128, 24);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(83, 20);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddProcess.BackgroundImage")));
            this.btnAddProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAddProcess.Location = new System.Drawing.Point(361, 46);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(24, 24);
            this.btnAddProcess.TabIndex = 2;
            this.btnAddProcess.UseVisualStyleBackColor = false;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label40.Location = new System.Drawing.Point(15, 46);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(98, 16);
            this.label40.TabIndex = 121;
            this.label40.Text = "Process Name";
            // 
            // chkProcess
            // 
            this.chkProcess.CheckOnClick = true;
            this.chkProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chkProcess.FormattingEnabled = true;
            this.chkProcess.Location = new System.Drawing.Point(125, 46);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(230, 228);
            this.chkProcess.TabIndex = 1;
            // 
            // btnSaveProcess
            // 
            this.btnSaveProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSaveProcess.Location = new System.Drawing.Point(122, 292);
            this.btnSaveProcess.Name = "btnSaveProcess";
            this.btnSaveProcess.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProcess.TabIndex = 3;
            this.btnSaveProcess.Text = "Save";
            this.btnSaveProcess.UseVisualStyleBackColor = true;
            this.btnSaveProcess.Click += new System.EventHandler(this.btnSaveProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(212, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProcessMasterPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(429, 347);
            this.Controls.Add(this.gbMain);
            this.Name = "ProcessMasterPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProcessMasterPopup_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.CheckedListBox chkProcess;
        private System.Windows.Forms.Button btnSaveProcess;
        private System.Windows.Forms.Button btnClose;
    }
}