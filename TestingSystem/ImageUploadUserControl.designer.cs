using System;

namespace TestingSystems
{
    partial class ImageUploadUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageUploadUserControl));
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.panelThumbs = new System.Windows.Forms.Panel();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFileUploads = new System.Windows.Forms.Button();
            this.btnDeletePatternImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePatternImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPicture.BackColor = System.Drawing.Color.White;
            this.mainPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainPicture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainPicture.Location = new System.Drawing.Point(0, 0);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(547, 388);
            this.mainPicture.TabIndex = 2;
            this.mainPicture.TabStop = false;
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonLeft.Location = new System.Drawing.Point(5, 5);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(25, 72);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Text = "<";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRight.Location = new System.Drawing.Point(517, 5);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(25, 72);
            this.buttonRight.TabIndex = 2;
            this.buttonRight.Text = ">";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // panelThumbs
            // 
            this.panelThumbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThumbs.Location = new System.Drawing.Point(35, 6);
            this.panelThumbs.Margin = new System.Windows.Forms.Padding(0);
            this.panelThumbs.Name = "panelThumbs";
            this.panelThumbs.Size = new System.Drawing.Size(477, 70);
            this.panelThumbs.TabIndex = 1;
            this.panelThumbs.TabStop = true;
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.White;
            this.panelNavigation.Controls.Add(this.buttonLeft);
            this.panelNavigation.Controls.Add(this.buttonRight);
            this.panelNavigation.Controls.Add(this.panelThumbs);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigation.Location = new System.Drawing.Point(0, 394);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(547, 82);
            this.panelNavigation.TabIndex = 3;
            this.panelNavigation.TabStop = true;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 48);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(547, 346);
            this.axAcroPDF1.TabIndex = 4;
            this.axAcroPDF1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFileUploads);
            this.panel1.Controls.Add(this.btnDeletePatternImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 45);
            this.panel1.TabIndex = 171;
            // 
            // btnFileUploads
            // 
            this.btnFileUploads.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFileUploads.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFileUploads.BackgroundImage")));
            this.btnFileUploads.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFileUploads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnFileUploads.Location = new System.Drawing.Point(3, 3);
            this.btnFileUploads.Name = "btnFileUploads";
            this.btnFileUploads.Size = new System.Drawing.Size(39, 36);
            this.btnFileUploads.TabIndex = 168;
            this.btnFileUploads.UseVisualStyleBackColor = false;
            this.btnFileUploads.Click += new System.EventHandler(this.btnFileUploads_Click);
            // 
            // btnDeletePatternImage
            // 
            this.btnDeletePatternImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletePatternImage.BackgroundImage")));
            this.btnDeletePatternImage.Location = new System.Drawing.Point(48, 2);
            this.btnDeletePatternImage.Name = "btnDeletePatternImage";
            this.btnDeletePatternImage.Size = new System.Drawing.Size(34, 36);
            this.btnDeletePatternImage.TabIndex = 169;
            this.btnDeletePatternImage.TabStop = false;
            this.btnDeletePatternImage.Click += new System.EventHandler(this.btnDeletePatternImage_Click);
            // 
            // ImageUploadUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.mainPicture);
            this.Controls.Add(this.panelNavigation);
            this.Name = "ImageUploadUserControl";
            this.Size = new System.Drawing.Size(547, 476);
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.panelNavigation.ResumeLayout(false);
            try
            {
                ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            }
            catch { }

                this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDeletePatternImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Panel panelThumbs;
        private System.Windows.Forms.Panel panelNavigation;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFileUploads;
        private System.Windows.Forms.PictureBox btnDeletePatternImage;
    }
}
