namespace TestingSystems
{
    partial class StateCitypopup
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCityCountry = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbCityState = new AutoCompleteComboBox.SuggestComboBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCitySave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btncityCancle = new System.Windows.Forms.Button();
            this.tabState = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbStateCountry = new AutoCompleteComboBox.SuggestComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnstateCancle = new System.Windows.Forms.Button();
            this.btnstateSave = new System.Windows.Forms.Button();
            this.txtstate = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.tabCountry = new System.Windows.Forms.TabPage();
            this.txtcountry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btncountrySave = new System.Windows.Forms.Button();
            this.btncountryCancel = new System.Windows.Forms.Button();
            this.epRequiredField = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtStateCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCity.SuspendLayout();
            this.tabState.SuspendLayout();
            this.tabCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRequiredField)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.tabControl1);
            this.groupBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBoxMain.Location = new System.Drawing.Point(27, 24);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(308, 189);
            this.groupBoxMain.TabIndex = 2;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "State City Master";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCity);
            this.tabControl1.Controls.Add(this.tabState);
            this.tabControl1.Controls.Add(this.tabCountry);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(26, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 150);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCity
            // 
            this.tabCity.Controls.Add(this.label2);
            this.tabCity.Controls.Add(this.cmbCityCountry);
            this.tabCity.Controls.Add(this.cmbCityState);
            this.tabCity.Controls.Add(this.txtCity);
            this.tabCity.Controls.Add(this.label6);
            this.tabCity.Controls.Add(this.label1);
            this.tabCity.Controls.Add(this.label7);
            this.tabCity.Controls.Add(this.btnCitySave);
            this.tabCity.Controls.Add(this.label8);
            this.tabCity.Controls.Add(this.btncityCancle);
            this.tabCity.Location = new System.Drawing.Point(4, 22);
            this.tabCity.Name = "tabCity";
            this.tabCity.Padding = new System.Windows.Forms.Padding(3);
            this.tabCity.Size = new System.Drawing.Size(252, 124);
            this.tabCity.TabIndex = 0;
            this.tabCity.Text = "City";
            this.tabCity.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(219, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "*";
            // 
            // cmbCityCountry
            // 
            this.cmbCityCountry.DisplayMember = "CountryName";
            this.cmbCityCountry.FilterRule = null;
            this.cmbCityCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbCityCountry.FormattingEnabled = true;
            this.cmbCityCountry.Location = new System.Drawing.Point(64, 4);
            this.cmbCityCountry.Name = "cmbCityCountry";
            this.cmbCityCountry.PropertySelector = null;
            this.cmbCityCountry.Size = new System.Drawing.Size(150, 23);
            this.cmbCityCountry.SuggestBoxHeight = 95;
            this.cmbCityCountry.SuggestListOrderRule = null;
            this.cmbCityCountry.TabIndex = 64;
            this.cmbCityCountry.ValueMember = "CountryId";
            this.cmbCityCountry.SelectionChangeCommitted += new System.EventHandler(this.cmbCityCountry_SelectionChangeCommitted);
            // 
            // cmbCityState
            // 
            this.cmbCityState.DisplayMember = "State";
            this.cmbCityState.FilterRule = null;
            this.cmbCityState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cmbCityState.FormattingEnabled = true;
            this.cmbCityState.Location = new System.Drawing.Point(63, 36);
            this.cmbCityState.Name = "cmbCityState";
            this.cmbCityState.PropertySelector = null;
            this.cmbCityState.Size = new System.Drawing.Size(150, 23);
            this.cmbCityState.SuggestBoxHeight = 95;
            this.cmbCityState.SuggestListOrderRule = null;
            this.cmbCityState.TabIndex = 65;
            this.cmbCityState.ValueMember = "StateId";
            this.cmbCityState.SelectionChangeCommitted += new System.EventHandler(this.cmbCityState_SelectionChangeCommitted);
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCity.Location = new System.Drawing.Point(63, 68);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 21);
            this.txtCity.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(4, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 72;
            this.label6.Text = "Country";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "City";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(4, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "State";
            // 
            // btnCitySave
            // 
            this.btnCitySave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCitySave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCitySave.Location = new System.Drawing.Point(29, 95);
            this.btnCitySave.Name = "btnCitySave";
            this.btnCitySave.Size = new System.Drawing.Size(75, 23);
            this.btnCitySave.TabIndex = 67;
            this.btnCitySave.Text = "Save";
            this.btnCitySave.UseVisualStyleBackColor = true;
            this.btnCitySave.Click += new System.EventHandler(this.btnCitySave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(219, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 71;
            this.label8.Text = "*";
            // 
            // btncityCancle
            // 
            this.btncityCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btncityCancle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btncityCancle.Location = new System.Drawing.Point(110, 95);
            this.btncityCancle.Name = "btncityCancle";
            this.btncityCancle.Size = new System.Drawing.Size(75, 23);
            this.btncityCancle.TabIndex = 68;
            this.btncityCancle.Text = "Cancel";
            this.btncityCancle.UseVisualStyleBackColor = true;
            this.btncityCancle.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabState
            // 
            this.tabState.Controls.Add(this.txtStateCode);
            this.tabState.Controls.Add(this.label10);
            this.tabState.Controls.Add(this.label11);
            this.tabState.Controls.Add(this.label9);
            this.tabState.Controls.Add(this.cmbStateCountry);
            this.tabState.Controls.Add(this.label5);
            this.tabState.Controls.Add(this.btnstateCancle);
            this.tabState.Controls.Add(this.btnstateSave);
            this.tabState.Controls.Add(this.txtstate);
            this.tabState.Controls.Add(this.label22);
            this.tabState.Controls.Add(this.label36);
            this.tabState.Location = new System.Drawing.Point(4, 22);
            this.tabState.Name = "tabState";
            this.tabState.Padding = new System.Windows.Forms.Padding(3);
            this.tabState.Size = new System.Drawing.Size(252, 124);
            this.tabState.TabIndex = 1;
            this.tabState.Text = "State";
            this.tabState.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(231, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 18);
            this.label9.TabIndex = 70;
            this.label9.Text = "*";
            // 
            // cmbStateCountry
            // 
            this.cmbStateCountry.DisplayMember = "CountryName";
            this.cmbStateCountry.FilterRule = null;
            this.cmbStateCountry.FormattingEnabled = true;
            this.cmbStateCountry.Location = new System.Drawing.Point(77, 6);
            this.cmbStateCountry.Name = "cmbStateCountry";
            this.cmbStateCountry.PropertySelector = null;
            this.cmbStateCountry.Size = new System.Drawing.Size(150, 21);
            this.cmbStateCountry.SuggestBoxHeight = 95;
            this.cmbStateCountry.SuggestListOrderRule = null;
            this.cmbStateCountry.TabIndex = 63;
            this.cmbStateCountry.ValueMember = "CountryId";
            this.cmbStateCountry.SelectionChangeCommitted += new System.EventHandler(this.cmbStateCountry_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(4, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Country";
            // 
            // btnstateCancle
            // 
            this.btnstateCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnstateCancle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnstateCancle.Location = new System.Drawing.Point(155, 93);
            this.btnstateCancle.Name = "btnstateCancle";
            this.btnstateCancle.Size = new System.Drawing.Size(74, 23);
            this.btnstateCancle.TabIndex = 66;
            this.btnstateCancle.Text = "Cancel";
            this.btnstateCancle.UseVisualStyleBackColor = true;
            this.btnstateCancle.Click += new System.EventHandler(this.btnstateCancle_Click);
            // 
            // btnstateSave
            // 
            this.btnstateSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnstateSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnstateSave.Location = new System.Drawing.Point(74, 93);
            this.btnstateSave.Name = "btnstateSave";
            this.btnstateSave.Size = new System.Drawing.Size(74, 23);
            this.btnstateSave.TabIndex = 65;
            this.btnstateSave.Text = "Save";
            this.btnstateSave.UseVisualStyleBackColor = true;
            this.btnstateSave.Click += new System.EventHandler(this.btnstateSave_Click);
            // 
            // txtstate
            // 
            this.txtstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtstate.Location = new System.Drawing.Point(77, 34);
            this.txtstate.Name = "txtstate";
            this.txtstate.Size = new System.Drawing.Size(150, 21);
            this.txtstate.TabIndex = 64;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(4, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 16);
            this.label22.TabIndex = 67;
            this.label22.Text = "State";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(231, 35);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(14, 18);
            this.label36.TabIndex = 68;
            this.label36.Text = "*";
            // 
            // tabCountry
            // 
            this.tabCountry.Controls.Add(this.txtcountry);
            this.tabCountry.Controls.Add(this.label3);
            this.tabCountry.Controls.Add(this.label4);
            this.tabCountry.Controls.Add(this.btncountrySave);
            this.tabCountry.Controls.Add(this.btncountryCancel);
            this.tabCountry.Location = new System.Drawing.Point(4, 22);
            this.tabCountry.Name = "tabCountry";
            this.tabCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tabCountry.Size = new System.Drawing.Size(242, 124);
            this.tabCountry.TabIndex = 2;
            this.tabCountry.Text = "Country";
            this.tabCountry.UseVisualStyleBackColor = true;
            // 
            // txtcountry
            // 
            this.txtcountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtcountry.Location = new System.Drawing.Point(66, 11);
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(150, 21);
            this.txtcountry.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(222, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Country";
            // 
            // btncountrySave
            // 
            this.btncountrySave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btncountrySave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btncountrySave.Location = new System.Drawing.Point(34, 47);
            this.btncountrySave.Name = "btncountrySave";
            this.btncountrySave.Size = new System.Drawing.Size(75, 23);
            this.btncountrySave.TabIndex = 54;
            this.btncountrySave.Text = "Save";
            this.btncountrySave.UseVisualStyleBackColor = true;
            this.btncountrySave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btncountryCancel
            // 
            this.btncountryCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btncountryCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btncountryCancel.Location = new System.Drawing.Point(115, 47);
            this.btncountryCancel.Name = "btncountryCancel";
            this.btncountryCancel.Size = new System.Drawing.Size(75, 23);
            this.btncountryCancel.TabIndex = 55;
            this.btncountryCancel.Text = "Cancel";
            this.btncountryCancel.UseVisualStyleBackColor = true;
            this.btncountryCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // epRequiredField
            // 
            this.epRequiredField.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(282, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtStateCode
            // 
            this.txtStateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtStateCode.Location = new System.Drawing.Point(77, 62);
            this.txtStateCode.Name = "txtStateCode";
            this.txtStateCode.Size = new System.Drawing.Size(150, 21);
            this.txtStateCode.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(4, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 72;
            this.label10.Text = "State Code";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(230, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 18);
            this.label11.TabIndex = 73;
            this.label11.Text = "*";
            // 
            // StateCitypopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(369, 235);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StateCitypopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StateCitypopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StateCitypopup_FormClosing);
            this.Load += new System.EventHandler(this.StateCitypopup_Load);
            this.groupBoxMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCity.ResumeLayout(false);
            this.tabCity.PerformLayout();
            this.tabState.ResumeLayout(false);
            this.tabState.PerformLayout();
            this.tabCountry.ResumeLayout(false);
            this.tabCountry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epRequiredField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.ErrorProvider epRequiredField;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCity;
        private AutoCompleteComboBox.SuggestComboBox cmbCityCountry;
        private AutoCompleteComboBox.SuggestComboBox cmbCityState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCitySave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btncityCancle;
        private System.Windows.Forms.TabPage tabState;
        private System.Windows.Forms.TabPage tabCountry;
        private System.Windows.Forms.Label label9;
        private AutoCompleteComboBox.SuggestComboBox cmbStateCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnstateCancle;
        private System.Windows.Forms.Button btnstateSave;
        private System.Windows.Forms.TextBox txtstate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtcountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btncountrySave;
        private System.Windows.Forms.Button btncountryCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStateCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;

    }
}