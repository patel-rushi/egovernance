namespace PagingUserControl
{
    partial class PagingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPaging = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblLoading = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecordsValue = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.btnLastRecord = new System.Windows.Forms.Button();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblSaperator = new System.Windows.Forms.Label();
            this.btnNextRecord = new System.Windows.Forms.Button();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.btnPreviousRecord = new System.Windows.Forms.Button();
            this.btnFirstRecord = new System.Windows.Forms.Button();
            this.bwPaging = new System.ComponentModel.BackgroundWorker();
            this.bwProcessDataRetrieval = new System.ComponentModel.BackgroundWorker();
            this.gbPaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPaging
            // 
            this.gbPaging.Controls.Add(this.progressBar1);
            this.gbPaging.Controls.Add(this.lblLoading);
            this.gbPaging.Controls.Add(this.label2);
            this.gbPaging.Controls.Add(this.lblTotalRecordsValue);
            this.gbPaging.Controls.Add(this.lblTotalRecords);
            this.gbPaging.Controls.Add(this.label1);
            this.gbPaging.Controls.Add(this.label8);
            this.gbPaging.Controls.Add(this.ddlPageSize);
            this.gbPaging.Controls.Add(this.lblPageSize);
            this.gbPaging.Controls.Add(this.btnLastRecord);
            this.gbPaging.Controls.Add(this.lblTotalPages);
            this.gbPaging.Controls.Add(this.lblSaperator);
            this.gbPaging.Controls.Add(this.btnNextRecord);
            this.gbPaging.Controls.Add(this.txtPageNumber);
            this.gbPaging.Controls.Add(this.btnPreviousRecord);
            this.gbPaging.Controls.Add(this.btnFirstRecord);
            this.gbPaging.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPaging.Location = new System.Drawing.Point(0, 0);
            this.gbPaging.Name = "gbPaging";
            this.gbPaging.Size = new System.Drawing.Size(706, 45);
            this.gbPaging.TabIndex = 0;
            this.gbPaging.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(618, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeftLayout = true;
            this.progressBar1.Size = new System.Drawing.Size(80, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLoading.Location = new System.Drawing.Point(618, 19);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(0, 13);
            this.lblLoading.TabIndex = 19;
            this.lblLoading.Visible = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(610, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 28);
            this.label2.TabIndex = 18;
            // 
            // lblTotalRecordsValue
            // 
            this.lblTotalRecordsValue.AutoSize = true;
            this.lblTotalRecordsValue.Location = new System.Drawing.Point(549, 19);
            this.lblTotalRecordsValue.Name = "lblTotalRecordsValue";
            this.lblTotalRecordsValue.Size = new System.Drawing.Size(13, 13);
            this.lblTotalRecordsValue.TabIndex = 1;
            this.lblTotalRecordsValue.Text = "0";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(463, 19);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(80, 13);
            this.lblTotalRecords.TabIndex = 1;
            this.lblTotalRecords.Text = "Total Records :";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(455, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 28);
            this.label1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(324, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 28);
            this.label8.TabIndex = 16;
            // 
            // ddlPageSize
            // 
            this.ddlPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPageSize.FormattingEnabled = true;
            this.ddlPageSize.Location = new System.Drawing.Point(399, 16);
            this.ddlPageSize.Name = "ddlPageSize";
            this.ddlPageSize.Size = new System.Drawing.Size(50, 21);
            this.ddlPageSize.TabIndex = 9;
            this.ddlPageSize.SelectedIndexChanged += new System.EventHandler(this.ddlPageSize_SelectedIndexChanged);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(332, 19);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(61, 13);
            this.lblPageSize.TabIndex = 8;
            this.lblPageSize.Text = "Page Size :";
            // 
            // btnLastRecord
            // 
            this.btnLastRecord.Location = new System.Drawing.Point(278, 14);
            this.btnLastRecord.Name = "btnLastRecord";
            this.btnLastRecord.Size = new System.Drawing.Size(40, 23);
            this.btnLastRecord.TabIndex = 7;
            this.btnLastRecord.Text = ">>";
            this.btnLastRecord.UseVisualStyleBackColor = true;
            this.btnLastRecord.Click += new System.EventHandler(this.btnLastRecord_Click);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Location = new System.Drawing.Point(177, 19);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(13, 13);
            this.lblTotalPages.TabIndex = 6;
            this.lblTotalPages.Text = "0";
            // 
            // lblSaperator
            // 
            this.lblSaperator.AutoSize = true;
            this.lblSaperator.Location = new System.Drawing.Point(159, 19);
            this.lblSaperator.Name = "lblSaperator";
            this.lblSaperator.Size = new System.Drawing.Size(12, 13);
            this.lblSaperator.TabIndex = 5;
            this.lblSaperator.Text = "/";
            // 
            // btnNextRecord
            // 
            this.btnNextRecord.Location = new System.Drawing.Point(232, 14);
            this.btnNextRecord.Name = "btnNextRecord";
            this.btnNextRecord.Size = new System.Drawing.Size(40, 23);
            this.btnNextRecord.TabIndex = 4;
            this.btnNextRecord.Text = ">";
            this.btnNextRecord.UseVisualStyleBackColor = true;
            this.btnNextRecord.Click += new System.EventHandler(this.btnNextRecord_Click);
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(98, 16);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(55, 20);
            this.txtPageNumber.TabIndex = 3;
            this.txtPageNumber.Text = "0";
            this.txtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNumber_KeyPress);
            // 
            // btnPreviousRecord
            // 
            this.btnPreviousRecord.Location = new System.Drawing.Point(52, 14);
            this.btnPreviousRecord.Name = "btnPreviousRecord";
            this.btnPreviousRecord.Size = new System.Drawing.Size(40, 23);
            this.btnPreviousRecord.TabIndex = 2;
            this.btnPreviousRecord.Text = "<";
            this.btnPreviousRecord.UseVisualStyleBackColor = true;
            this.btnPreviousRecord.Click += new System.EventHandler(this.btnPreviousRecord_Click);
            // 
            // btnFirstRecord
            // 
            this.btnFirstRecord.Location = new System.Drawing.Point(6, 14);
            this.btnFirstRecord.Name = "btnFirstRecord";
            this.btnFirstRecord.Size = new System.Drawing.Size(40, 23);
            this.btnFirstRecord.TabIndex = 1;
            this.btnFirstRecord.Text = "<<";
            this.btnFirstRecord.UseVisualStyleBackColor = true;
            this.btnFirstRecord.Click += new System.EventHandler(this.btnFirstRecord_Click);
            // 
            // bwPaging
            // 
            this.bwPaging.WorkerReportsProgress = true;
            this.bwPaging.WorkerSupportsCancellation = true;
            this.bwPaging.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPaging_DoWork);
            this.bwPaging.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwPaging_ProgressChanged);
            this.bwPaging.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPaging_RunWorkerCompleted);
            // 
            // bwProcessDataRetrieval
            // 
            this.bwProcessDataRetrieval.WorkerReportsProgress = true;
            this.bwProcessDataRetrieval.WorkerSupportsCancellation = true;
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPaging);
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(706, 50);
            this.gbPaging.ResumeLayout(false);
            this.gbPaging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPaging;
        private System.Windows.Forms.Button btnFirstRecord;
        private System.Windows.Forms.Button btnPreviousRecord;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Button btnNextRecord;
        private System.Windows.Forms.Label lblSaperator;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Button btnLastRecord;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox ddlPageSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecordsValue;
        private System.Windows.Forms.Label lblLoading;
        private System.ComponentModel.BackgroundWorker bwPaging;
        public System.ComponentModel.BackgroundWorker bwProcessDataRetrieval;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
