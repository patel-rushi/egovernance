namespace Inventory_Management
{
    partial class PatternImagePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternImagePopup));
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.lblPatternImageName = new System.Windows.Forms.Label();
            this.axUploadPatternPDF = new AxAcroPDFLib.AxAcroPDF();
            this.btnPatternPrev = new System.Windows.Forms.PictureBox();
            this.btnPatternNext = new System.Windows.Forms.PictureBox();
            this.PatternPictureBox = new System.Windows.Forms.PictureBox();
            this.lnkDownload1 = new System.Windows.Forms.PictureBox();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUploadPatternPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPatternPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPatternNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatternPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDownload1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.lblPatternImageName);
            this.gbImage.Controls.Add(this.axUploadPatternPDF);
            this.gbImage.Controls.Add(this.PatternPictureBox);
            this.gbImage.Location = new System.Drawing.Point(35, 2);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(794, 591);
            this.gbImage.TabIndex = 1;
            this.gbImage.TabStop = false;
            // 
            // lblPatternImageName
            // 
            this.lblPatternImageName.AutoSize = true;
            this.lblPatternImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatternImageName.Location = new System.Drawing.Point(547, 16);
            this.lblPatternImageName.Name = "lblPatternImageName";
            this.lblPatternImageName.Size = new System.Drawing.Size(0, 15);
            this.lblPatternImageName.TabIndex = 143;
            // 
            // axUploadPatternPDF
            // 
            this.axUploadPatternPDF.Enabled = true;
            this.axUploadPatternPDF.Location = new System.Drawing.Point(0, 35);
            this.axUploadPatternPDF.Name = "axUploadPatternPDF";
            this.axUploadPatternPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUploadPatternPDF.OcxState")));
            this.axUploadPatternPDF.Size = new System.Drawing.Size(794, 553);
            this.axUploadPatternPDF.TabIndex = 142;
            // 
            // btnPatternPrev
            // 
            this.btnPatternPrev.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPatternPrev.BackgroundImage = global::TestingSystems.Properties.Resources.arrow_01;
            this.btnPatternPrev.Location = new System.Drawing.Point(12, 317);
            this.btnPatternPrev.Name = "btnPatternPrev";
            this.btnPatternPrev.Size = new System.Drawing.Size(17, 17);
            this.btnPatternPrev.TabIndex = 147;
            this.btnPatternPrev.TabStop = false;
            this.btnPatternPrev.Click += new System.EventHandler(this.btnPatternPrev_Click);
            // 
            // btnPatternNext
            // 
            this.btnPatternNext.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPatternNext.BackgroundImage = global::TestingSystems.Properties.Resources.arrow_02;
            this.btnPatternNext.Location = new System.Drawing.Point(837, 317);
            this.btnPatternNext.Name = "btnPatternNext";
            this.btnPatternNext.Size = new System.Drawing.Size(17, 17);
            this.btnPatternNext.TabIndex = 145;
            this.btnPatternNext.TabStop = false;
            this.btnPatternNext.Click += new System.EventHandler(this.lnkNext_Click);
            // 
            // PatternPictureBox
            // 
            this.PatternPictureBox.Location = new System.Drawing.Point(0, 35);
            this.PatternPictureBox.Name = "PatternPictureBox";
            this.PatternPictureBox.Size = new System.Drawing.Size(794, 579);
            this.PatternPictureBox.TabIndex = 0;
            this.PatternPictureBox.TabStop = false;
            // 
            // lnkDownload1
            // 
            this.lnkDownload1.Location = new System.Drawing.Point(837, 2);
            this.lnkDownload1.Name = "lnkDownload1";
            this.lnkDownload1.Size = new System.Drawing.Size(18, 16);
            this.lnkDownload1.TabIndex = 141;
            this.lnkDownload1.TabStop = false;
            this.lnkDownload1.Click += new System.EventHandler(this.lnkDownload1_Click);
            // 
            // PatternImagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(860, 615);
            this.Controls.Add(this.btnPatternPrev);
            this.Controls.Add(this.btnPatternNext);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.lnkDownload1);
            this.Location = new System.Drawing.Point(13, 13);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatternImagePopup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PatternImagePopup_Load);
            this.gbImage.ResumeLayout(false);
            this.gbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axUploadPatternPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPatternPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPatternNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatternPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDownload1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.PictureBox lnkDownload1;
        private System.Windows.Forms.PictureBox PatternPictureBox;
        private AxAcroPDFLib.AxAcroPDF axUploadPatternPDF;
        private System.Windows.Forms.PictureBox btnPatternNext;
        private System.Windows.Forms.PictureBox btnPatternPrev;
        private System.Windows.Forms.Label lblPatternImageName;
    }
}