namespace MasterUpload
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Fetch_Work = new System.ComponentModel.BackgroundWorker();
            this.Insert_Work = new System.ComponentModel.BackgroundWorker();
            this.File_Dialog = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_Pattern = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_Matle = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_Casting = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_CastingMetal = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_PurchaseItem = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_CAddress = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_CContact = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_SMaster = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_SAddress = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_SContact = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_PatternCustomerMapping = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_CoreBox = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_FGRate = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_RMRate = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_SupplierItemMapping = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_Machine = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_Core = new System.Windows.Forms.OpenFileDialog();
            this.File_Dialog_OpeningStock = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btClrCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PathCMaster = new System.Windows.Forms.TextBox();
            this.btn_browseCMaster = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.btn_can = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.rbtInsert = new System.Windows.Forms.RadioButton();
            this.btnCloseMaster = new System.Windows.Forms.Button();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fetch_Work
            // 
            this.Fetch_Work.WorkerReportsProgress = true;
            this.Fetch_Work.WorkerSupportsCancellation = true;
            this.Fetch_Work.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Fetch_Work_DoWork);
            this.Fetch_Work.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Fetch_Work_RunWorkerCompleted);
            // 
            // Insert_Work
            // 
            this.Insert_Work.WorkerReportsProgress = true;
            this.Insert_Work.WorkerSupportsCancellation = true;
            this.Insert_Work.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Insert_Work_DoWork);
            this.Insert_Work.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Insert_Work_ProgressChanged);
            this.Insert_Work.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Insert_Work_RunWorkerCompleted);
            // 
            // File_Dialog
            // 
            this.File_Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_FileOk);
            // 
            // File_Dialog_Pattern
            // 
            this.File_Dialog_Pattern.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog2_FileOk);
            // 
            // File_Dialog_Matle
            // 
            this.File_Dialog_Matle.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog3_FileOk);
            // 
            // File_Dialog_Casting
            // 
            this.File_Dialog_Casting.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog4_FileOk_1);
            // 
            // File_Dialog_CastingMetal
            // 
            this.File_Dialog_CastingMetal.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_CastingMetal_FileOk);
            // 
            // File_Dialog_PurchaseItem
            // 
            this.File_Dialog_PurchaseItem.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog6_FileOk);
            // 
            // File_Dialog_CAddress
            // 
            this.File_Dialog_CAddress.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_CAddress_FileOk);
            // 
            // File_Dialog_CContact
            // 
            this.File_Dialog_CContact.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_CContact_FileOk);
            // 
            // File_Dialog_SMaster
            // 
            this.File_Dialog_SMaster.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_SMaster_FileOk);
            // 
            // File_Dialog_SAddress
            // 
            this.File_Dialog_SAddress.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_SAddress_FileOk);
            // 
            // File_Dialog_SContact
            // 
            this.File_Dialog_SContact.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_SContact_FileOk);
            // 
            // File_Dialog_PatternCustomerMapping
            // 
            this.File_Dialog_PatternCustomerMapping.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_PatternCustomerMapping_FileOk);
            // 
            // File_Dialog_CoreBox
            // 
            this.File_Dialog_CoreBox.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_CoreBox_FileOk);
            // 
            // File_Dialog_FGRate
            // 
            this.File_Dialog_FGRate.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_FGRate_FileOk);
            // 
            // File_Dialog_RMRate
            // 
            this.File_Dialog_RMRate.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_RMRate_FileOk);
            // 
            // File_Dialog_SupplierItemMapping
            // 
            this.File_Dialog_SupplierItemMapping.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_SupplierItemMapping_FileOk);
            // 
            // File_Dialog_Machine
            // 
            this.File_Dialog_Machine.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_Machine_FileOk);
            // 
            // File_Dialog_Core
            // 
            this.File_Dialog_Core.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_Core_FileOk);
            // 
            // File_Dialog_OpeningStock
            // 
            this.File_Dialog_OpeningStock.FileOk += new System.ComponentModel.CancelEventHandler(this.File_Dialog_OpeningStock_FileOk);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btClrCustomer);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txt_PathCMaster);
            this.groupBox3.Controls.Add(this.btn_browseCMaster);
            this.groupBox3.Controls.Add(this.btn_upload);
            this.groupBox3.Controls.Add(this.btn_can);
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 155);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Upload Excel Files";
            // 
            // btClrCustomer
            // 
            this.btClrCustomer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btClrCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btClrCustomer.BackgroundImage")));
            this.btClrCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClrCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btClrCustomer.Location = new System.Drawing.Point(568, 13);
            this.btClrCustomer.Name = "btClrCustomer";
            this.btClrCustomer.Size = new System.Drawing.Size(28, 23);
            this.btClrCustomer.TabIndex = 1;
            this.btClrCustomer.UseVisualStyleBackColor = false;
            this.btClrCustomer.Click += new System.EventHandler(this.btClrCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Bug LIst :";
            // 
            // txt_PathCMaster
            // 
            this.txt_PathCMaster.Location = new System.Drawing.Point(301, 16);
            this.txt_PathCMaster.Name = "txt_PathCMaster";
            this.txt_PathCMaster.ReadOnly = true;
            this.txt_PathCMaster.Size = new System.Drawing.Size(225, 21);
            this.txt_PathCMaster.TabIndex = 2;
            this.txt_PathCMaster.TabStop = false;
            // 
            // btn_browseCMaster
            // 
            this.btn_browseCMaster.AutoSize = true;
            this.btn_browseCMaster.Location = new System.Drawing.Point(532, 13);
            this.btn_browseCMaster.Name = "btn_browseCMaster";
            this.btn_browseCMaster.Size = new System.Drawing.Size(30, 26);
            this.btn_browseCMaster.TabIndex = 0;
            this.btn_browseCMaster.Text = "...";
            this.btn_browseCMaster.UseVisualStyleBackColor = true;
            this.btn_browseCMaster.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.AutoSize = true;
            this.btn_upload.Location = new System.Drawing.Point(172, 56);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(122, 26);
            this.btn_upload.TabIndex = 36;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_can
            // 
            this.btn_can.AutoSize = true;
            this.btn_can.Location = new System.Drawing.Point(311, 56);
            this.btn_can.Name = "btn_can";
            this.btn_can.Size = new System.Drawing.Size(122, 26);
            this.btn_can.TabIndex = 37;
            this.btn_can.Text = "Cancel";
            this.btn_can.UseVisualStyleBackColor = true;
            this.btn_can.Click += new System.EventHandler(this.btn_can_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label22.Location = new System.Drawing.Point(176, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(118, 16);
            this.label22.TabIndex = 272;
            this.label22.Text = "File Upload Action";
            // 
            // rbtInsert
            // 
            this.rbtInsert.AutoSize = true;
            this.rbtInsert.Checked = true;
            this.rbtInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.rbtInsert.Location = new System.Drawing.Point(307, 10);
            this.rbtInsert.Name = "rbtInsert";
            this.rbtInsert.Size = new System.Drawing.Size(58, 20);
            this.rbtInsert.TabIndex = 0;
            this.rbtInsert.TabStop = true;
            this.rbtInsert.Text = "Insert";
            this.rbtInsert.UseVisualStyleBackColor = true;
            // 
            // btnCloseMaster
            // 
            this.btnCloseMaster.AutoSize = true;
            this.btnCloseMaster.Location = new System.Drawing.Point(635, 20);
            this.btnCloseMaster.Name = "btnCloseMaster";
            this.btnCloseMaster.Size = new System.Drawing.Size(122, 26);
            this.btnCloseMaster.TabIndex = 273;
            this.btnCloseMaster.Text = "Close";
            this.btnCloseMaster.UseVisualStyleBackColor = true;
            this.btnCloseMaster.Click += new System.EventHandler(this.btnCloseMaster_Click);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.btnCloseMaster);
            this.groupBoxMain.Controls.Add(this.rbtInsert);
            this.groupBoxMain.Controls.Add(this.label22);
            this.groupBoxMain.Controls.Add(this.groupBox3);
            this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(770, 221);
            this.groupBoxMain.TabIndex = 57;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Master Upload";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(807, 246);
            this.Controls.Add(this.groupBoxMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Enter += new System.EventHandler(this.Form2_Enter);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker Fetch_Work;
        private System.ComponentModel.BackgroundWorker Insert_Work;
        private System.Windows.Forms.OpenFileDialog File_Dialog;
        private System.Windows.Forms.OpenFileDialog File_Dialog_Pattern;
        private System.Windows.Forms.OpenFileDialog File_Dialog_Matle;
        private System.Windows.Forms.OpenFileDialog File_Dialog_Casting;
        private System.Windows.Forms.OpenFileDialog File_Dialog_CastingMetal;
        private System.Windows.Forms.OpenFileDialog File_Dialog_PurchaseItem;
        private System.Windows.Forms.OpenFileDialog File_Dialog_CAddress;
        private System.Windows.Forms.OpenFileDialog File_Dialog_CContact;
        private System.Windows.Forms.OpenFileDialog File_Dialog_SMaster;
        private System.Windows.Forms.OpenFileDialog File_Dialog_SAddress;
        private System.Windows.Forms.OpenFileDialog File_Dialog_SContact;
        private System.Windows.Forms.OpenFileDialog File_Dialog_PatternCustomerMapping;
        private System.Windows.Forms.OpenFileDialog File_Dialog_CoreBox;
        private System.Windows.Forms.OpenFileDialog File_Dialog_FGRate;
        private System.Windows.Forms.OpenFileDialog File_Dialog_RMRate;
        private System.Windows.Forms.OpenFileDialog File_Dialog_SupplierItemMapping;
        private System.Windows.Forms.OpenFileDialog File_Dialog_Machine;
        private System.Windows.Forms.OpenFileDialog File_Dialog_Core;
        private System.Windows.Forms.OpenFileDialog File_Dialog_OpeningStock;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btClrCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PathCMaster;
        private System.Windows.Forms.Button btn_browseCMaster;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_can;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rbtInsert;
        private System.Windows.Forms.Button btnCloseMaster;
        private System.Windows.Forms.GroupBox groupBoxMain;
    }
}