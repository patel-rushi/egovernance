namespace TestingSystems
{
    partial class Performance
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
            this.lblUT = new System.Windows.Forms.Label();
            this.UserType = new System.Windows.Forms.ComboBox();
            this.lblUN = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.ComboBox();
            this.lblss = new System.Windows.Forms.Label();
            this.lblcf = new System.Windows.Forms.Label();
            this.lblmf = new System.Windows.Forms.Label();
            this.lblatten = new System.Windows.Forms.Label();
            this.lbleffec = new System.Windows.Forms.Label();
            this.lbleffi = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cf = new System.Windows.Forms.TextBox();
            this.ss = new System.Windows.Forms.TextBox();
            this.mf = new System.Windows.Forms.TextBox();
            this.atten = new System.Windows.Forms.TextBox();
            this.effect = new System.Windows.Forms.TextBox();
            this.effi = new System.Windows.Forms.TextBox();
            this.tot = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Search);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.todate);
            this.groupBox1.Controls.Add(this.fromdate);
            this.groupBox1.Controls.Add(this.lblUT);
            this.groupBox1.Controls.Add(this.UserType);
            this.groupBox1.Controls.Add(this.lblUN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 515);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblUT
            // 
            this.lblUT.AutoSize = true;
            this.lblUT.Location = new System.Drawing.Point(132, 45);
            this.lblUT.Name = "lblUT";
            this.lblUT.Size = new System.Drawing.Size(62, 13);
            this.lblUT.TabIndex = 53;
            this.lblUT.Text = "User Type :";
            this.lblUT.Visible = false;
            // 
            // UserType
            // 
            this.UserType.FormattingEnabled = true;
            this.UserType.Items.AddRange(new object[] {
            "DEVELOPER",
            "QA"});
            this.UserType.Location = new System.Drawing.Point(214, 42);
            this.UserType.Name = "UserType";
            this.UserType.Size = new System.Drawing.Size(121, 21);
            this.UserType.TabIndex = 52;
            this.UserType.Visible = false;
            this.UserType.SelectedIndexChanged += new System.EventHandler(this.UserType_SelectedIndexChanged_1);
            // 
            // lblUN
            // 
            this.lblUN.AutoSize = true;
            this.lblUN.Location = new System.Drawing.Point(438, 45);
            this.lblUN.Name = "lblUN";
            this.lblUN.Size = new System.Drawing.Size(66, 13);
            this.lblUN.TabIndex = 51;
            this.lblUN.Text = "User Name :";
            this.lblUN.Visible = false;
            // 
            // UserName
            // 
            this.UserName.FormattingEnabled = true;
            this.UserName.Items.AddRange(new object[] {
            "DEVELOPER",
            "QA"});
            this.UserName.Location = new System.Drawing.Point(508, 42);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(133, 21);
            this.UserName.TabIndex = 50;
            this.UserName.Visible = false;
            // 
            // lblss
            // 
            this.lblss.AutoSize = true;
            this.lblss.Location = new System.Drawing.Point(331, 244);
            this.lblss.Name = "lblss";
            this.lblss.Size = new System.Drawing.Size(10, 13);
            this.lblss.TabIndex = 49;
            this.lblss.Text = ".";
            // 
            // lblcf
            // 
            this.lblcf.AutoSize = true;
            this.lblcf.Location = new System.Drawing.Point(331, 294);
            this.lblcf.Name = "lblcf";
            this.lblcf.Size = new System.Drawing.Size(10, 13);
            this.lblcf.TabIndex = 48;
            this.lblcf.Text = ".";
            // 
            // lblmf
            // 
            this.lblmf.AutoSize = true;
            this.lblmf.Location = new System.Drawing.Point(331, 195);
            this.lblmf.Name = "lblmf";
            this.lblmf.Size = new System.Drawing.Size(10, 13);
            this.lblmf.TabIndex = 47;
            this.lblmf.Text = ".";
            // 
            // lblatten
            // 
            this.lblatten.AutoSize = true;
            this.lblatten.Location = new System.Drawing.Point(331, 145);
            this.lblatten.Name = "lblatten";
            this.lblatten.Size = new System.Drawing.Size(10, 13);
            this.lblatten.TabIndex = 46;
            this.lblatten.Text = ".";
            // 
            // lbleffec
            // 
            this.lbleffec.AutoSize = true;
            this.lbleffec.Location = new System.Drawing.Point(331, 99);
            this.lbleffec.Name = "lbleffec";
            this.lbleffec.Size = new System.Drawing.Size(10, 13);
            this.lbleffec.TabIndex = 45;
            this.lbleffec.Text = ".";
            // 
            // lbleffi
            // 
            this.lbleffi.AutoSize = true;
            this.lbleffi.Location = new System.Drawing.Point(331, 46);
            this.lbleffi.Name = "lbleffi";
            this.lbleffi.Size = new System.Drawing.Size(10, 13);
            this.lbleffi.TabIndex = 44;
            this.lbleffi.Text = ".";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(305, 292);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 17);
            this.label14.TabIndex = 43;
            this.label14.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(305, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 42;
            this.label13.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(305, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 41;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(305, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 17);
            this.label11.TabIndex = 40;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(305, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 17);
            this.label10.TabIndex = 39;
            this.label10.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(305, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "%";
            // 
            // cf
            // 
            this.cf.Location = new System.Drawing.Point(192, 289);
            this.cf.Name = "cf";
            this.cf.ReadOnly = true;
            this.cf.Size = new System.Drawing.Size(100, 20);
            this.cf.TabIndex = 37;
            // 
            // ss
            // 
            this.ss.Location = new System.Drawing.Point(192, 241);
            this.ss.Name = "ss";
            this.ss.ReadOnly = true;
            this.ss.Size = new System.Drawing.Size(100, 20);
            this.ss.TabIndex = 36;
            // 
            // mf
            // 
            this.mf.Location = new System.Drawing.Point(192, 192);
            this.mf.Name = "mf";
            this.mf.ReadOnly = true;
            this.mf.Size = new System.Drawing.Size(100, 20);
            this.mf.TabIndex = 35;
            // 
            // atten
            // 
            this.atten.Location = new System.Drawing.Point(192, 140);
            this.atten.Name = "atten";
            this.atten.ReadOnly = true;
            this.atten.Size = new System.Drawing.Size(100, 20);
            this.atten.TabIndex = 34;
            // 
            // effect
            // 
            this.effect.Location = new System.Drawing.Point(192, 92);
            this.effect.Name = "effect";
            this.effect.ReadOnly = true;
            this.effect.Size = new System.Drawing.Size(100, 20);
            this.effect.TabIndex = 33;
            // 
            // effi
            // 
            this.effi.Location = new System.Drawing.Point(192, 43);
            this.effi.Name = "effi";
            this.effi.ReadOnly = true;
            this.effi.Size = new System.Drawing.Size(100, 20);
            this.effi.TabIndex = 32;
            // 
            // tot
            // 
            this.tot.Location = new System.Drawing.Point(473, 46);
            this.tot.Name = "tot";
            this.tot.ReadOnly = true;
            this.tot.Size = new System.Drawing.Size(100, 20);
            this.tot.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(592, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 17);
            this.label18.TabIndex = 30;
            this.label18.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(430, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Total :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Colleague Feedback :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Skill set :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Management Feedback :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Attendance :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Effectiveness :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Efficiency :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Performance";
            // 
            // fromdate
            // 
            this.fromdate.CustomFormat = "dd MMM yyyy";
            this.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdate.Location = new System.Drawing.Point(214, 98);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(121, 20);
            this.fromdate.TabIndex = 54;
            this.fromdate.Value = new System.DateTime(2019, 5, 1, 0, 0, 0, 0);
            // 
            // todate
            // 
            this.todate.CustomFormat = "dd MMM yyyy";
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todate.Location = new System.Drawing.Point(508, 99);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(133, 20);
            this.todate.TabIndex = 55;
            this.todate.Value = new System.DateTime(2019, 6, 25, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.effi);
            this.groupBox2.Controls.Add(this.tot);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.lblss);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.effect);
            this.groupBox2.Controls.Add(this.lblcf);
            this.groupBox2.Controls.Add(this.atten);
            this.groupBox2.Controls.Add(this.lblmf);
            this.groupBox2.Controls.Add(this.mf);
            this.groupBox2.Controls.Add(this.lblatten);
            this.groupBox2.Controls.Add(this.ss);
            this.groupBox2.Controls.Add(this.lbleffec);
            this.groupBox2.Controls.Add(this.cf);
            this.groupBox2.Controls.Add(this.lbleffi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(55, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 331);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(132, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "From Date :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 58;
            this.label16.Text = "To Date :";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(354, 140);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(81, 32);
            this.Search.TabIndex = 59;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.groupBox1);
            this.Name = "Performance";
            this.Text = "Performance";
            this.Load += new System.EventHandler(this.Performance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cf;
        private System.Windows.Forms.TextBox ss;
        private System.Windows.Forms.TextBox mf;
        private System.Windows.Forms.TextBox atten;
        private System.Windows.Forms.TextBox effect;
        private System.Windows.Forms.TextBox effi;
        private System.Windows.Forms.TextBox tot;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblss;
        private System.Windows.Forms.Label lblcf;
        private System.Windows.Forms.Label lblmf;
        private System.Windows.Forms.Label lblatten;
        private System.Windows.Forms.Label lbleffec;
        private System.Windows.Forms.Label lbleffi;
        private System.Windows.Forms.Label lblUN;
        private System.Windows.Forms.ComboBox UserName;
        private System.Windows.Forms.Label lblUT;
        private System.Windows.Forms.ComboBox UserType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Button Search;
    }
}