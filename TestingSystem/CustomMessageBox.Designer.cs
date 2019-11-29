namespace TestingSystems
{
    partial class CustomMessageBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.skipthis = new System.Windows.Forms.Button();
            this.skipall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket Assigned can\'t be deleted !";
            // 
            // skipthis
            // 
            this.skipthis.Location = new System.Drawing.Point(189, 70);
            this.skipthis.Name = "skipthis";
            this.skipthis.Size = new System.Drawing.Size(84, 37);
            this.skipthis.TabIndex = 1;
            this.skipthis.Text = "Skip This";
            this.skipthis.UseVisualStyleBackColor = true;
            this.skipthis.Click += new System.EventHandler(this.skipthis_Click);
            // 
            // skipall
            // 
            this.skipall.Location = new System.Drawing.Point(36, 70);
            this.skipall.Name = "skipall";
            this.skipall.Size = new System.Drawing.Size(84, 37);
            this.skipall.TabIndex = 2;
            this.skipall.Text = "Skip All";
            this.skipall.UseVisualStyleBackColor = true;
            this.skipall.Click += new System.EventHandler(this.skipall_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 131);
            this.Controls.Add(this.skipall);
            this.Controls.Add(this.skipthis);
            this.Controls.Add(this.label1);
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button skipthis;
        private System.Windows.Forms.Button skipall;
    }
}