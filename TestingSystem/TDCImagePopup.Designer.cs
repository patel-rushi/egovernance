namespace TestingSystems
{
    partial class TDCImagePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TDCImagePopup));
            this.lblTDCImageName = new System.Windows.Forms.Label();
            this.lnkDownload1 = new System.Windows.Forms.PictureBox();
            this.gbimage = new System.Windows.Forms.GroupBox();
            this.axUploadTDCPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDownload1)).BeginInit();
            this.gbimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUploadTDCPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTDCImageName
            // 
            this.lblTDCImageName.AutoSize = true;
            this.lblTDCImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTDCImageName.Location = new System.Drawing.Point(586, 11);
            this.lblTDCImageName.Name = "lblTDCImageName";
            this.lblTDCImageName.Size = new System.Drawing.Size(0, 15);
            this.lblTDCImageName.TabIndex = 144;
            // 
            // lnkDownload1
            // 
            this.lnkDownload1.Location = new System.Drawing.Point(820, 12);
            this.lnkDownload1.Name = "lnkDownload1";
            this.lnkDownload1.Size = new System.Drawing.Size(18, 16);
            this.lnkDownload1.TabIndex = 145;
            this.lnkDownload1.TabStop = false;
            this.lnkDownload1.Click += new System.EventHandler(this.lnkDownload1_Click);
            // 
            // gbimage
            // 
            this.gbimage.Controls.Add(this.axUploadTDCPDF);
            this.gbimage.Controls.Add(this.lnkDownload1);
            this.gbimage.Controls.Add(this.lblTDCImageName);
            this.gbimage.Location = new System.Drawing.Point(13, 6);
            this.gbimage.Name = "gbimage";
            this.gbimage.Size = new System.Drawing.Size(844, 617);
            this.gbimage.TabIndex = 146;
            this.gbimage.TabStop = false;
            // 
            // axUploadTDCPDF
            // 
            this.axUploadTDCPDF.Enabled = true;
            this.axUploadTDCPDF.Location = new System.Drawing.Point(6, 31);
            this.axUploadTDCPDF.Name = "axUploadTDCPDF";
            this.axUploadTDCPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUploadTDCPDF.OcxState")));
            this.axUploadTDCPDF.Size = new System.Drawing.Size(829, 577);
            this.axUploadTDCPDF.TabIndex = 143;
            // 
            // TDCImagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 626);
            this.Controls.Add(this.gbimage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TDCImagePopup";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.TDCImagePopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lnkDownload1)).EndInit();
            this.gbimage.ResumeLayout(false);
            this.gbimage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUploadTDCPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTDCImageName;
        private System.Windows.Forms.PictureBox lnkDownload1;
        private System.Windows.Forms.GroupBox gbimage;
        private AxAcroPDFLib.AxAcroPDF axUploadTDCPDF;
    }
}