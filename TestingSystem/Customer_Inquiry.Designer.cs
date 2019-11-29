namespace TestingSystems
{
    partial class Customer_Inquiry
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbState = new AutoCompleteComboBox.SuggestComboBox();
            this.cmbCity = new AutoCompleteComboBox.SuggestComboBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnAddCompanyName = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.scmb_Person = new AutoCompleteComboBox.SuggestComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dtp_InquiryDate = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.scmb_CompanyName = new AutoCompleteComboBox.SuggestComboBox();
            this.Date = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.Label();
            this.ContactNo = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Customer = new System.Windows.Forms.Label();
            this.CompanyName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Product = new System.Windows.Forms.Button();
            this.scmb_Product = new AutoCompleteComboBox.SuggestComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.scmb_PersonRep = new AutoCompleteComboBox.SuggestComboBox();
            this.scmb_Status = new AutoCompleteComboBox.SuggestComboBox();
            this.scmb_InquirySource = new AutoCompleteComboBox.SuggestComboBox();
            this.reason = new System.Windows.Forms.Label();
            this.lbl_refrence = new System.Windows.Forms.Label();
            this.txtRefrence = new System.Windows.Forms.TextBox();
            this.txtIfLoss = new System.Windows.Forms.TextBox();
            this.dtp_WLDate = new System.Windows.Forms.DateTimePicker();
            this.Loss_WinDate = new System.Windows.Forms.Label();
            this.CurrentStatus = new System.Windows.Forms.Label();
            this.RepName = new System.Windows.Forms.Label();
            this.CompanyRep = new System.Windows.Forms.Label();
            this.InquirySource = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bw_CompanyName = new System.ComponentModel.BackgroundWorker();
            this.bw_PersonRep = new System.ComponentModel.BackgroundWorker();
            this.bw_Product = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.btnAddPerson);
            this.groupBox1.Controls.Add(this.btnAddCompanyName);
            this.groupBox1.Controls.Add(this.txtPersonName);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.scmb_Person);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.dtp_InquiryDate);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.scmb_CompanyName);
            this.groupBox1.Controls.Add(this.Date);
            this.groupBox1.Controls.Add(this.State);
            this.groupBox1.Controls.Add(this.City);
            this.groupBox1.Controls.Add(this.ContactNo);
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.Customer);
            this.groupBox1.Controls.Add(this.CompanyName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(991, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CustomerDetails";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(642, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "*";
            // 
            // cmbState
            // 
            this.cmbState.FilterRule = null;
            this.cmbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(727, 95);
            this.cmbState.Name = "cmbState";
            this.cmbState.PropertySelector = null;
            this.cmbState.Size = new System.Drawing.Size(174, 21);
            this.cmbState.SuggestBoxHeight = 95;
            this.cmbState.SuggestListOrderRule = null;
            this.cmbState.TabIndex = 5;
            this.cmbState.SelectionChangeCommitted += new System.EventHandler(this.cmbState_SelectionChangeCommitted);
            // 
            // cmbCity
            // 
            this.cmbCity.FilterRule = null;
            this.cmbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(727, 63);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.PropertySelector = null;
            this.cmbCity.Size = new System.Drawing.Size(174, 21);
            this.cmbCity.SuggestBoxHeight = 95;
            this.cmbCity.SuggestListOrderRule = null;
            this.cmbCity.TabIndex = 3;
            this.cmbCity.SelectionChangeCommitted += new System.EventHandler(this.cmbCity_SelectionChangeCommitted);
            this.cmbCity.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbCity_PreviewKeyDown);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btnAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerson.Location = new System.Drawing.Point(447, 60);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(25, 25);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Visible = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnAddCompanyName
            // 
            this.btnAddCompanyName.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btnAddCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCompanyName.Location = new System.Drawing.Point(660, 22);
            this.btnAddCompanyName.Name = "btnAddCompanyName";
            this.btnAddCompanyName.Size = new System.Drawing.Size(25, 25);
            this.btnAddCompanyName.TabIndex = 1;
            this.btnAddCompanyName.UseVisualStyleBackColor = true;
            this.btnAddCompanyName.Click += new System.EventHandler(this.btnAddCompanyName_Click);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonName.Location = new System.Drawing.Point(447, 63);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(134, 20);
            this.txtPersonName.TabIndex = 5;
            this.txtPersonName.Visible = false;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(644, 23);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(134, 20);
            this.txtCompanyName.TabIndex = 2;
            this.txtCompanyName.Visible = false;
            // 
            // scmb_Person
            // 
            this.scmb_Person.FilterRule = null;
            this.scmb_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_Person.FormattingEnabled = true;
            this.scmb_Person.Location = new System.Drawing.Point(266, 63);
            this.scmb_Person.Name = "scmb_Person";
            this.scmb_Person.PropertySelector = null;
            this.scmb_Person.Size = new System.Drawing.Size(174, 21);
            this.scmb_Person.SuggestBoxHeight = 95;
            this.scmb_Person.SuggestListOrderRule = null;
            this.scmb_Person.TabIndex = 2;
            this.scmb_Person.SelectionChangeCommitted += new System.EventHandler(this.scmb_Person_SelectionChangeCommitted);
            this.scmb_Person.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.scmb_Person_PreviewKeyDown);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(910, 15);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // dtp_InquiryDate
            // 
            this.dtp_InquiryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_InquiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_InquiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_InquiryDate.Location = new System.Drawing.Point(727, 130);
            this.dtp_InquiryDate.Name = "dtp_InquiryDate";
            this.dtp_InquiryDate.Size = new System.Drawing.Size(174, 20);
            this.dtp_InquiryDate.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(266, 133);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(174, 20);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(266, 97);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // scmb_CompanyName
            // 
            this.scmb_CompanyName.FilterRule = null;
            this.scmb_CompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_CompanyName.FormattingEnabled = true;
            this.scmb_CompanyName.Location = new System.Drawing.Point(463, 22);
            this.scmb_CompanyName.Name = "scmb_CompanyName";
            this.scmb_CompanyName.PropertySelector = null;
            this.scmb_CompanyName.Size = new System.Drawing.Size(174, 21);
            this.scmb_CompanyName.SuggestBoxHeight = 95;
            this.scmb_CompanyName.SuggestListOrderRule = null;
            this.scmb_CompanyName.TabIndex = 0;
            this.scmb_CompanyName.SelectionChangeCommitted += new System.EventHandler(this.scmb_CompanyName_SelectionChangeCommitted);
            this.scmb_CompanyName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.scmb_CompanyName_PreviewKeyDown);
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.Location = new System.Drawing.Point(587, 138);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(42, 13);
            this.Date.TabIndex = 6;
            this.Date.Text = "Date :";
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State.Location = new System.Drawing.Point(587, 102);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(49, 13);
            this.State.TabIndex = 5;
            this.State.Text = "State : ";
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.City.Location = new System.Drawing.Point(587, 68);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(36, 13);
            this.City.TabIndex = 4;
            this.City.Text = "City :";
            // 
            // ContactNo
            // 
            this.ContactNo.AutoSize = true;
            this.ContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactNo.Location = new System.Drawing.Point(103, 138);
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.Size = new System.Drawing.Size(85, 13);
            this.ContactNo.TabIndex = 3;
            this.ContactNo.Text = "Contact no. : ";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(103, 102);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(45, 13);
            this.Email.TabIndex = 2;
            this.Email.Text = "Email :";
            // 
            // Customer
            // 
            this.Customer.AutoSize = true;
            this.Customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.Location = new System.Drawing.Point(103, 68);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(93, 13);
            this.Customer.TabIndex = 1;
            this.Customer.Text = "Company Rep :";
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSize = true;
            this.CompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyName.Location = new System.Drawing.Point(342, 25);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(98, 13);
            this.CompanyName.TabIndex = 0;
            this.CompanyName.Text = "Company Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_Product);
            this.groupBox2.Controls.Add(this.scmb_Product);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.scmb_PersonRep);
            this.groupBox2.Controls.Add(this.scmb_Status);
            this.groupBox2.Controls.Add(this.scmb_InquirySource);
            this.groupBox2.Controls.Add(this.reason);
            this.groupBox2.Controls.Add(this.lbl_refrence);
            this.groupBox2.Controls.Add(this.txtRefrence);
            this.groupBox2.Controls.Add(this.txtIfLoss);
            this.groupBox2.Controls.Add(this.dtp_WLDate);
            this.groupBox2.Controls.Add(this.Loss_WinDate);
            this.groupBox2.Controls.Add(this.CurrentStatus);
            this.groupBox2.Controls.Add(this.RepName);
            this.groupBox2.Controls.Add(this.CompanyRep);
            this.groupBox2.Controls.Add(this.InquirySource);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 254);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "InquiryDetails ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(443, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(907, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(443, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(443, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "*";
            // 
            // btn_Product
            // 
            this.btn_Product.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btn_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.Location = new System.Drawing.Point(461, 67);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(25, 25);
            this.btn_Product.TabIndex = 3;
            this.btn_Product.UseVisualStyleBackColor = true;
            this.btn_Product.Click += new System.EventHandler(this.btn_Product_Click);
            // 
            // scmb_Product
            // 
            this.scmb_Product.FilterRule = null;
            this.scmb_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_Product.FormattingEnabled = true;
            this.scmb_Product.Location = new System.Drawing.Point(266, 67);
            this.scmb_Product.Name = "scmb_Product";
            this.scmb_Product.PropertySelector = null;
            this.scmb_Product.Size = new System.Drawing.Size(174, 21);
            this.scmb_Product.SuggestBoxHeight = 95;
            this.scmb_Product.SuggestListOrderRule = null;
            this.scmb_Product.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::TestingSystems.Properties.Resources.Add_24;
            this.btnAdd.Location = new System.Drawing.Point(925, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // scmb_PersonRep
            // 
            this.scmb_PersonRep.FilterRule = null;
            this.scmb_PersonRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_PersonRep.FormattingEnabled = true;
            this.scmb_PersonRep.Location = new System.Drawing.Point(730, 63);
            this.scmb_PersonRep.Name = "scmb_PersonRep";
            this.scmb_PersonRep.PropertySelector = null;
            this.scmb_PersonRep.Size = new System.Drawing.Size(171, 21);
            this.scmb_PersonRep.SuggestBoxHeight = 95;
            this.scmb_PersonRep.SuggestListOrderRule = null;
            this.scmb_PersonRep.TabIndex = 4;
            // 
            // scmb_Status
            // 
            this.scmb_Status.FilterRule = null;
            this.scmb_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_Status.FormattingEnabled = true;
            this.scmb_Status.Location = new System.Drawing.Point(266, 105);
            this.scmb_Status.Name = "scmb_Status";
            this.scmb_Status.PropertySelector = null;
            this.scmb_Status.Size = new System.Drawing.Size(174, 21);
            this.scmb_Status.SuggestBoxHeight = 95;
            this.scmb_Status.SuggestListOrderRule = null;
            this.scmb_Status.TabIndex = 6;
            this.scmb_Status.SelectionChangeCommitted += new System.EventHandler(this.scmb_Status_SelectionChangeCommitted);
            this.scmb_Status.TextChanged += new System.EventHandler(this.scmb_Status_TextChanged);
            // 
            // scmb_InquirySource
            // 
            this.scmb_InquirySource.FilterRule = null;
            this.scmb_InquirySource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scmb_InquirySource.FormattingEnabled = true;
            this.scmb_InquirySource.Location = new System.Drawing.Point(266, 30);
            this.scmb_InquirySource.Name = "scmb_InquirySource";
            this.scmb_InquirySource.PropertySelector = null;
            this.scmb_InquirySource.Size = new System.Drawing.Size(174, 21);
            this.scmb_InquirySource.SuggestBoxHeight = 95;
            this.scmb_InquirySource.SuggestListOrderRule = null;
            this.scmb_InquirySource.TabIndex = 0;
            this.scmb_InquirySource.SelectionChangeCommitted += new System.EventHandler(this.scmb_InquirySource_SelectionChangeCommitted);
            this.scmb_InquirySource.TextChanged += new System.EventHandler(this.scmb_InquirySource_TextChanged);
            // 
            // reason
            // 
            this.reason.AutoSize = true;
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reason.Location = new System.Drawing.Point(103, 140);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(62, 13);
            this.reason.TabIndex = 13;
            this.reason.Text = "Reason : ";
            // 
            // lbl_refrence
            // 
            this.lbl_refrence.AutoSize = true;
            this.lbl_refrence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_refrence.Location = new System.Drawing.Point(587, 35);
            this.lbl_refrence.Name = "lbl_refrence";
            this.lbl_refrence.Size = new System.Drawing.Size(71, 13);
            this.lbl_refrence.TabIndex = 12;
            this.lbl_refrence.Text = "Refrence : ";
            this.lbl_refrence.Visible = false;
            // 
            // txtRefrence
            // 
            this.txtRefrence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefrence.Location = new System.Drawing.Point(730, 30);
            this.txtRefrence.Name = "txtRefrence";
            this.txtRefrence.Size = new System.Drawing.Size(171, 20);
            this.txtRefrence.TabIndex = 1;
            this.txtRefrence.Visible = false;
            this.txtRefrence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefrence_KeyPress);
            // 
            // txtIfLoss
            // 
            this.txtIfLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfLoss.Location = new System.Drawing.Point(266, 140);
            this.txtIfLoss.Multiline = true;
            this.txtIfLoss.Name = "txtIfLoss";
            this.txtIfLoss.Size = new System.Drawing.Size(458, 99);
            this.txtIfLoss.TabIndex = 8;
            // 
            // dtp_WLDate
            // 
            this.dtp_WLDate.CustomFormat = "dd-MMM-yyyy";
            this.dtp_WLDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_WLDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_WLDate.Location = new System.Drawing.Point(730, 99);
            this.dtp_WLDate.Name = "dtp_WLDate";
            this.dtp_WLDate.Size = new System.Drawing.Size(174, 20);
            this.dtp_WLDate.TabIndex = 7;
            // 
            // Loss_WinDate
            // 
            this.Loss_WinDate.AutoSize = true;
            this.Loss_WinDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loss_WinDate.Location = new System.Drawing.Point(587, 105);
            this.Loss_WinDate.Name = "Loss_WinDate";
            this.Loss_WinDate.Size = new System.Drawing.Size(108, 13);
            this.Loss_WinDate.TabIndex = 4;
            this.Loss_WinDate.Text = "Loss /Win Date : ";
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.AutoSize = true;
            this.CurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentStatus.Location = new System.Drawing.Point(103, 105);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(100, 13);
            this.CurrentStatus.TabIndex = 3;
            this.CurrentStatus.Text = "Current Status : ";
            // 
            // RepName
            // 
            this.RepName.AutoSize = true;
            this.RepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepName.Location = new System.Drawing.Point(587, 70);
            this.RepName.Name = "RepName";
            this.RepName.Size = new System.Drawing.Size(98, 13);
            this.RepName.TabIndex = 2;
            this.RepName.Text = "Marketing Rep :";
            // 
            // CompanyRep
            // 
            this.CompanyRep.AutoSize = true;
            this.CompanyRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyRep.Location = new System.Drawing.Point(103, 70);
            this.CompanyRep.Name = "CompanyRep";
            this.CompanyRep.Size = new System.Drawing.Size(59, 13);
            this.CompanyRep.TabIndex = 1;
            this.CompanyRep.Text = "Product :";
            // 
            // InquirySource
            // 
            this.InquirySource.AutoSize = true;
            this.InquirySource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InquirySource.Location = new System.Drawing.Point(103, 35);
            this.InquirySource.Name = "InquirySource";
            this.InquirySource.Size = new System.Drawing.Size(97, 13);
            this.InquirySource.TabIndex = 0;
            this.InquirySource.Text = "Inquiry Source :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(405, 488);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(506, 488);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1030, 589);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // bw_CompanyName
            // 
            this.bw_CompanyName.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_CompanyName_DoWork);
            this.bw_CompanyName.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_CompanyName_RunWorkerCompleted);
            // 
            // bw_PersonRep
            // 
            this.bw_PersonRep.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_PersonRep_DoWork);
            this.bw_PersonRep.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_PersonRep_RunWorkerCompleted);
            // 
            // bw_Product
            // 
            this.bw_Product.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_Product_DoWork);
            this.bw_Product.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_Product_RunWorkerCompleted);
            // 
            // Customer_Inquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1058, 604);
            this.Controls.Add(this.groupBox3);
            this.Name = "Customer_Inquiry";
            this.Text = "Customer_Inquiry";
            this.Load += new System.EventHandler(this.Customer_Inquiry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.Label ContactNo;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Customer;
        private new System.Windows.Forms.Label CompanyName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_InquiryDate;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label Loss_WinDate;
        private System.Windows.Forms.Label CurrentStatus;
        private System.Windows.Forms.Label RepName;
        private System.Windows.Forms.Label CompanyRep;
        private System.Windows.Forms.Label InquirySource;
        private System.Windows.Forms.TextBox txtRefrence;
        private System.Windows.Forms.TextBox txtIfLoss;
        private System.Windows.Forms.DateTimePicker dtp_WLDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label reason;
        private System.Windows.Forms.Label lbl_refrence;
        private System.Windows.Forms.Button btnRegister;
        private System.ComponentModel.BackgroundWorker bw_CompanyName;
        private AutoCompleteComboBox.SuggestComboBox scmb_Person;
        private AutoCompleteComboBox.SuggestComboBox scmb_CompanyName;
        private System.Windows.Forms.Button btnAddCompanyName;
        private AutoCompleteComboBox.SuggestComboBox scmb_Status;
        private AutoCompleteComboBox.SuggestComboBox scmb_InquirySource;
        private AutoCompleteComboBox.SuggestComboBox cmbState;
        private AutoCompleteComboBox.SuggestComboBox cmbCity;
        private AutoCompleteComboBox.SuggestComboBox scmb_PersonRep;
        private System.ComponentModel.BackgroundWorker bw_PersonRep;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnAddPerson;
        private AutoCompleteComboBox.SuggestComboBox scmb_Product;
        private System.ComponentModel.BackgroundWorker bw_Product;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}