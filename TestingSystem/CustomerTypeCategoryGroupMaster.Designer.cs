namespace TestingSystems
{
    partial class CustomerTypeCategoryGroupMaster
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
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbType = new System.Windows.Forms.TabPage();
            this.dgvCustomerTypeMaster = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CustomerTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeShortCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCustomerCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCustomerTypeSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTypeShortCode = new System.Windows.Forms.TextBox();
            this.txtTypeCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.tbCategory = new System.Windows.Forms.TabPage();
            this.dgvCustomerCategoryMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CustomerCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryShortCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCustomerCategoryCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCustomerCategorySave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCategoryShortCode = new System.Windows.Forms.TextBox();
            this.txtCategoryCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.tbGroup = new System.Windows.Forms.TabPage();
            this.dgvCustomerGroupMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CustomerGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupShortCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCustomerGroupCancel = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCustomerGroupSave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGroupShortCode = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.bwFillCustomerTypeGrid = new System.ComponentModel.BackgroundWorker();
            this.bwCustomerCategoryGrid = new System.ComponentModel.BackgroundWorker();
            this.bwCustomerGroupGrid = new System.ComponentModel.BackgroundWorker();
            this.gbMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerTypeMaster)).BeginInit();
            this.tbCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCategoryMaster)).BeginInit();
            this.tbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerGroupMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.btnClose);
            this.gbMain.Controls.Add(this.tabControl1);
            this.gbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.gbMain.Location = new System.Drawing.Point(13, 13);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(598, 568);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Type Category Master";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(514, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbType);
            this.tabControl1.Controls.Add(this.tbGroup);
            this.tabControl1.Controls.Add(this.tbCategory);
            this.tabControl1.Location = new System.Drawing.Point(7, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 534);
            this.tabControl1.TabIndex = 0;
            // 
            // tbType
            // 
            this.tbType.Controls.Add(this.dgvCustomerTypeMaster);
            this.tbType.Controls.Add(this.btnCustomerCancel);
            this.tbType.Controls.Add(this.label6);
            this.tbType.Controls.Add(this.label12);
            this.tbType.Controls.Add(this.btnCustomerTypeSave);
            this.tbType.Controls.Add(this.label1);
            this.tbType.Controls.Add(this.label2);
            this.tbType.Controls.Add(this.txtTypeShortCode);
            this.tbType.Controls.Add(this.txtTypeCode);
            this.tbType.Controls.Add(this.label4);
            this.tbType.Controls.Add(this.txtTypeName);
            this.tbType.Location = new System.Drawing.Point(4, 26);
            this.tbType.Name = "tbType";
            this.tbType.Padding = new System.Windows.Forms.Padding(3);
            this.tbType.Size = new System.Drawing.Size(559, 504);
            this.tbType.TabIndex = 0;
            this.tbType.Text = "Type";
            this.tbType.UseVisualStyleBackColor = true;
            // 
            // dgvCustomerTypeMaster
            // 
            this.dgvCustomerTypeMaster.AllowUserToAddRows = false;
            this.dgvCustomerTypeMaster.AllowUserToDeleteRows = false;
            this.dgvCustomerTypeMaster.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerTypeMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerTypeMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.CustomerTypeId,
            this.TypeCode,
            this.TypeName,
            this.TypeShortCode});
            this.dgvCustomerTypeMaster.Location = new System.Drawing.Point(15, 173);
            this.dgvCustomerTypeMaster.Name = "dgvCustomerTypeMaster";
            this.dgvCustomerTypeMaster.ReadOnly = true;
            this.dgvCustomerTypeMaster.Size = new System.Drawing.Size(510, 316);
            this.dgvCustomerTypeMaster.TabIndex = 5;
            this.dgvCustomerTypeMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerTypeMaster_CellContentClick);
            this.dgvCustomerTypeMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerTypeMaster_KeyDown);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.LinkColor = System.Drawing.Color.Black;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "EDIT";
            this.Edit.ToolTipText = "Update";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Black;
            this.Edit.Width = 70;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "DELETE";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 70;
            // 
            // CustomerTypeId
            // 
            this.CustomerTypeId.DataPropertyName = "CustomerTypeId";
            this.CustomerTypeId.HeaderText = "CustomerTypeId";
            this.CustomerTypeId.Name = "CustomerTypeId";
            this.CustomerTypeId.ReadOnly = true;
            this.CustomerTypeId.Visible = false;
            // 
            // TypeCode
            // 
            this.TypeCode.DataPropertyName = "TypeCode";
            this.TypeCode.HeaderText = "Type Code";
            this.TypeCode.Name = "TypeCode";
            this.TypeCode.ReadOnly = true;
            // 
            // TypeName
            // 
            this.TypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "Type Name";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // TypeShortCode
            // 
            this.TypeShortCode.DataPropertyName = "TypeShortCode";
            this.TypeShortCode.HeaderText = "ShortCode";
            this.TypeShortCode.Name = "TypeShortCode";
            this.TypeShortCode.ReadOnly = true;
            // 
            // btnCustomerCancel
            // 
            this.btnCustomerCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerCancel.Location = new System.Drawing.Point(261, 138);
            this.btnCustomerCancel.Name = "btnCustomerCancel";
            this.btnCustomerCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerCancel.TabIndex = 4;
            this.btnCustomerCancel.Text = "Cancel";
            this.btnCustomerCancel.UseVisualStyleBackColor = true;
            this.btnCustomerCancel.Click += new System.EventHandler(this.btnCustomerCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(367, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 88;
            this.label6.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(367, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 18);
            this.label12.TabIndex = 87;
            this.label12.Text = "*";
            // 
            // btnCustomerTypeSave
            // 
            this.btnCustomerTypeSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerTypeSave.Location = new System.Drawing.Point(180, 138);
            this.btnCustomerTypeSave.Name = "btnCustomerTypeSave";
            this.btnCustomerTypeSave.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerTypeSave.TabIndex = 3;
            this.btnCustomerTypeSave.Text = "Save";
            this.btnCustomerTypeSave.UseVisualStyleBackColor = true;
            this.btnCustomerTypeSave.Click += new System.EventHandler(this.btnCustomerTypeSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(121, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 86;
            this.label1.Text = "Type Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(121, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 85;
            this.label2.Text = "Type Name";
            // 
            // txtTypeShortCode
            // 
            this.txtTypeShortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTypeShortCode.Location = new System.Drawing.Point(211, 91);
            this.txtTypeShortCode.Name = "txtTypeShortCode";
            this.txtTypeShortCode.Size = new System.Drawing.Size(150, 21);
            this.txtTypeShortCode.TabIndex = 2;
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.Enabled = false;
            this.txtTypeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTypeCode.Location = new System.Drawing.Point(211, 17);
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.ReadOnly = true;
            this.txtTypeCode.Size = new System.Drawing.Size(150, 21);
            this.txtTypeCode.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.Location = new System.Drawing.Point(121, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 90;
            this.label4.Text = "Short Code";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTypeName.Location = new System.Drawing.Point(211, 54);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(150, 21);
            this.txtTypeName.TabIndex = 1;
            // 
            // tbCategory
            // 
            this.tbCategory.Controls.Add(this.dgvCustomerCategoryMaster);
            this.tbCategory.Controls.Add(this.btnCustomerCategoryCancel);
            this.tbCategory.Controls.Add(this.label7);
            this.tbCategory.Controls.Add(this.label8);
            this.tbCategory.Controls.Add(this.btnCustomerCategorySave);
            this.tbCategory.Controls.Add(this.label9);
            this.tbCategory.Controls.Add(this.label10);
            this.tbCategory.Controls.Add(this.txtCategoryShortCode);
            this.tbCategory.Controls.Add(this.txtCategoryCode);
            this.tbCategory.Controls.Add(this.label11);
            this.tbCategory.Controls.Add(this.txtCategoryName);
            this.tbCategory.Location = new System.Drawing.Point(4, 26);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tbCategory.Size = new System.Drawing.Size(559, 504);
            this.tbCategory.TabIndex = 1;
            this.tbCategory.Text = "Category";
            this.tbCategory.UseVisualStyleBackColor = true;
            // 
            // dgvCustomerCategoryMaster
            // 
            this.dgvCustomerCategoryMaster.AllowUserToAddRows = false;
            this.dgvCustomerCategoryMaster.AllowUserToDeleteRows = false;
            this.dgvCustomerCategoryMaster.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerCategoryMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerCategoryMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1,
            this.dataGridViewLinkColumn2,
            this.CustomerCategoryId,
            this.CategoryCode,
            this.CategoryName,
            this.CategoryShortCode});
            this.dgvCustomerCategoryMaster.Location = new System.Drawing.Point(15, 173);
            this.dgvCustomerCategoryMaster.Name = "dgvCustomerCategoryMaster";
            this.dgvCustomerCategoryMaster.ReadOnly = true;
            this.dgvCustomerCategoryMaster.Size = new System.Drawing.Size(510, 316);
            this.dgvCustomerCategoryMaster.TabIndex = 5;
            this.dgvCustomerCategoryMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerCategoryMaster_CellContentClick);
            this.dgvCustomerCategoryMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerTypeMaster_KeyDown);
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "";
            this.dataGridViewLinkColumn1.LinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Text = "EDIT";
            this.dataGridViewLinkColumn1.ToolTipText = "Update";
            this.dataGridViewLinkColumn1.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn1.VisitedLinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn1.Width = 70;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.HeaderText = "";
            this.dataGridViewLinkColumn2.LinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Text = "DELETE";
            this.dataGridViewLinkColumn2.ToolTipText = "Delete";
            this.dataGridViewLinkColumn2.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn2.VisitedLinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn2.Width = 70;
            // 
            // CustomerCategoryId
            // 
            this.CustomerCategoryId.DataPropertyName = "CustomerCategoryId";
            this.CustomerCategoryId.HeaderText = "CustomerCategoryId";
            this.CustomerCategoryId.Name = "CustomerCategoryId";
            this.CustomerCategoryId.ReadOnly = true;
            this.CustomerCategoryId.Visible = false;
            // 
            // CategoryCode
            // 
            this.CategoryCode.DataPropertyName = "CategoryCode";
            this.CategoryCode.HeaderText = "Category Code";
            this.CategoryCode.Name = "CategoryCode";
            this.CategoryCode.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Category Name";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // CategoryShortCode
            // 
            this.CategoryShortCode.DataPropertyName = "CategoryShortCode";
            this.CategoryShortCode.HeaderText = "ShortCode";
            this.CategoryShortCode.Name = "CategoryShortCode";
            this.CategoryShortCode.ReadOnly = true;
            // 
            // btnCustomerCategoryCancel
            // 
            this.btnCustomerCategoryCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerCategoryCancel.Location = new System.Drawing.Point(261, 138);
            this.btnCustomerCategoryCancel.Name = "btnCustomerCategoryCancel";
            this.btnCustomerCategoryCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerCategoryCancel.TabIndex = 4;
            this.btnCustomerCategoryCancel.Text = "Cancel";
            this.btnCustomerCategoryCancel.UseVisualStyleBackColor = true;
            this.btnCustomerCategoryCancel.Click += new System.EventHandler(this.btnCustomerCategoryCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(384, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 100;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(384, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 99;
            this.label8.Text = "*";
            // 
            // btnCustomerCategorySave
            // 
            this.btnCustomerCategorySave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerCategorySave.Location = new System.Drawing.Point(180, 138);
            this.btnCustomerCategorySave.Name = "btnCustomerCategorySave";
            this.btnCustomerCategorySave.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerCategorySave.TabIndex = 3;
            this.btnCustomerCategorySave.Text = "Save";
            this.btnCustomerCategorySave.UseVisualStyleBackColor = true;
            this.btnCustomerCategorySave.Click += new System.EventHandler(this.btnCustomerCategorySave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label9.Location = new System.Drawing.Point(121, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 98;
            this.label9.Text = "Category Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.Location = new System.Drawing.Point(121, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 97;
            this.label10.Text = "Category Name";
            // 
            // txtCategoryShortCode
            // 
            this.txtCategoryShortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCategoryShortCode.Location = new System.Drawing.Point(231, 95);
            this.txtCategoryShortCode.Name = "txtCategoryShortCode";
            this.txtCategoryShortCode.Size = new System.Drawing.Size(150, 21);
            this.txtCategoryShortCode.TabIndex = 2;
            // 
            // txtCategoryCode
            // 
            this.txtCategoryCode.Enabled = false;
            this.txtCategoryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCategoryCode.Location = new System.Drawing.Point(231, 17);
            this.txtCategoryCode.Name = "txtCategoryCode";
            this.txtCategoryCode.ReadOnly = true;
            this.txtCategoryCode.Size = new System.Drawing.Size(150, 21);
            this.txtCategoryCode.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label11.Location = new System.Drawing.Point(121, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 102;
            this.label11.Text = "Short Code";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtCategoryName.Location = new System.Drawing.Point(231, 58);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(150, 21);
            this.txtCategoryName.TabIndex = 1;
            // 
            // tbGroup
            // 
            this.tbGroup.Controls.Add(this.dgvCustomerGroupMaster);
            this.tbGroup.Controls.Add(this.btnCustomerGroupCancel);
            this.tbGroup.Controls.Add(this.label14);
            this.tbGroup.Controls.Add(this.label15);
            this.tbGroup.Controls.Add(this.btnCustomerGroupSave);
            this.tbGroup.Controls.Add(this.label16);
            this.tbGroup.Controls.Add(this.label17);
            this.tbGroup.Controls.Add(this.txtGroupShortCode);
            this.tbGroup.Controls.Add(this.txtGroupCode);
            this.tbGroup.Controls.Add(this.label18);
            this.tbGroup.Controls.Add(this.txtGroupName);
            this.tbGroup.Location = new System.Drawing.Point(4, 26);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(559, 504);
            this.tbGroup.TabIndex = 2;
            this.tbGroup.Text = "Group";
            this.tbGroup.UseVisualStyleBackColor = true;
            // 
            // dgvCustomerGroupMaster
            // 
            this.dgvCustomerGroupMaster.AllowUserToAddRows = false;
            this.dgvCustomerGroupMaster.AllowUserToDeleteRows = false;
            this.dgvCustomerGroupMaster.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerGroupMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerGroupMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn3,
            this.dataGridViewLinkColumn4,
            this.CustomerGroupId,
            this.GroupCode,
            this.GroupName,
            this.GroupShortCode});
            this.dgvCustomerGroupMaster.Location = new System.Drawing.Point(15, 173);
            this.dgvCustomerGroupMaster.Name = "dgvCustomerGroupMaster";
            this.dgvCustomerGroupMaster.ReadOnly = true;
            this.dgvCustomerGroupMaster.Size = new System.Drawing.Size(510, 316);
            this.dgvCustomerGroupMaster.TabIndex = 5;
            this.dgvCustomerGroupMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerGroupMaster_CellContentClick);
            this.dgvCustomerGroupMaster.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerTypeMaster_KeyDown);
            // 
            // dataGridViewLinkColumn3
            // 
            this.dataGridViewLinkColumn3.HeaderText = "";
            this.dataGridViewLinkColumn3.LinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn3.Name = "dataGridViewLinkColumn3";
            this.dataGridViewLinkColumn3.ReadOnly = true;
            this.dataGridViewLinkColumn3.Text = "EDIT";
            this.dataGridViewLinkColumn3.ToolTipText = "Update";
            this.dataGridViewLinkColumn3.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn3.VisitedLinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn3.Width = 70;
            // 
            // dataGridViewLinkColumn4
            // 
            this.dataGridViewLinkColumn4.HeaderText = "";
            this.dataGridViewLinkColumn4.LinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn4.Name = "dataGridViewLinkColumn4";
            this.dataGridViewLinkColumn4.ReadOnly = true;
            this.dataGridViewLinkColumn4.Text = "DELETE";
            this.dataGridViewLinkColumn4.ToolTipText = "Delete";
            this.dataGridViewLinkColumn4.UseColumnTextForLinkValue = true;
            this.dataGridViewLinkColumn4.VisitedLinkColor = System.Drawing.Color.Black;
            this.dataGridViewLinkColumn4.Width = 70;
            // 
            // CustomerGroupId
            // 
            this.CustomerGroupId.DataPropertyName = "CustomerGroupId";
            this.CustomerGroupId.HeaderText = "CustomerGroupId";
            this.CustomerGroupId.Name = "CustomerGroupId";
            this.CustomerGroupId.ReadOnly = true;
            this.CustomerGroupId.Visible = false;
            // 
            // GroupCode
            // 
            this.GroupCode.DataPropertyName = "GroupCode";
            this.GroupCode.HeaderText = "Group Code";
            this.GroupCode.Name = "GroupCode";
            this.GroupCode.ReadOnly = true;
            // 
            // GroupName
            // 
            this.GroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Group Name";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // GroupShortCode
            // 
            this.GroupShortCode.DataPropertyName = "GroupShortCode";
            this.GroupShortCode.HeaderText = "ShortCode";
            this.GroupShortCode.Name = "GroupShortCode";
            this.GroupShortCode.ReadOnly = true;
            // 
            // btnCustomerGroupCancel
            // 
            this.btnCustomerGroupCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerGroupCancel.Location = new System.Drawing.Point(261, 138);
            this.btnCustomerGroupCancel.Name = "btnCustomerGroupCancel";
            this.btnCustomerGroupCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerGroupCancel.TabIndex = 4;
            this.btnCustomerGroupCancel.Text = "Cancel";
            this.btnCustomerGroupCancel.UseVisualStyleBackColor = true;
            this.btnCustomerGroupCancel.Click += new System.EventHandler(this.btnCustomerGroupCancel_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(364, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 112;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(364, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 111;
            this.label15.Text = "*";
            // 
            // btnCustomerGroupSave
            // 
            this.btnCustomerGroupSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCustomerGroupSave.Location = new System.Drawing.Point(180, 138);
            this.btnCustomerGroupSave.Name = "btnCustomerGroupSave";
            this.btnCustomerGroupSave.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerGroupSave.TabIndex = 3;
            this.btnCustomerGroupSave.Text = "Save";
            this.btnCustomerGroupSave.UseVisualStyleBackColor = true;
            this.btnCustomerGroupSave.Click += new System.EventHandler(this.btnCustomerGroupSave_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label16.Location = new System.Drawing.Point(121, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 16);
            this.label16.TabIndex = 110;
            this.label16.Text = "Group Code";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label17.Location = new System.Drawing.Point(121, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 16);
            this.label17.TabIndex = 109;
            this.label17.Text = "Group Name";
            // 
            // txtGroupShortCode
            // 
            this.txtGroupShortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtGroupShortCode.Location = new System.Drawing.Point(211, 91);
            this.txtGroupShortCode.Name = "txtGroupShortCode";
            this.txtGroupShortCode.Size = new System.Drawing.Size(150, 21);
            this.txtGroupShortCode.TabIndex = 2;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Enabled = false;
            this.txtGroupCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtGroupCode.Location = new System.Drawing.Point(211, 17);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.ReadOnly = true;
            this.txtGroupCode.Size = new System.Drawing.Size(150, 21);
            this.txtGroupCode.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label18.Location = new System.Drawing.Point(121, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 114;
            this.label18.Text = "Short Code";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtGroupName.Location = new System.Drawing.Point(211, 54);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(150, 21);
            this.txtGroupName.TabIndex = 1;
            // 
            // bwFillCustomerTypeGrid
            // 
            this.bwFillCustomerTypeGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFillCustomerTypeGrid_DoWork);
            this.bwFillCustomerTypeGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFillCustomerTypeGrid_RunWorkerCompleted);
            // 
            // bwCustomerCategoryGrid
            // 
            this.bwCustomerCategoryGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCustomerCategoryGrid_DoWork);
            this.bwCustomerCategoryGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCustomerCategoryGrid_RunWorkerCompleted);
            // 
            // bwCustomerGroupGrid
            // 
            this.bwCustomerGroupGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCustomerGroupGrid_DoWork);
            this.bwCustomerGroupGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCustomerGroupGrid_RunWorkerCompleted);
            // 
            // CustomerTypeCategoryGroupMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 589);
            this.Controls.Add(this.gbMain);
            this.Name = "CustomerTypeCategoryGroupMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CustomerTypeCategoryGroupMaster_Load);
            this.gbMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbType.ResumeLayout(false);
            this.tbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerTypeMaster)).EndInit();
            this.tbCategory.ResumeLayout(false);
            this.tbCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerCategoryMaster)).EndInit();
            this.tbGroup.ResumeLayout(false);
            this.tbGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerGroupMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TextBox txtTypeShortCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbType;
        private System.Windows.Forms.TabPage tbCategory;
        private System.Windows.Forms.TabPage tbGroup;
        private System.Windows.Forms.Button btnCustomerCancel;
        private System.Windows.Forms.Button btnCustomerTypeSave;
        private System.Windows.Forms.DataGridView dgvCustomerTypeMaster;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeShortCode;
        private System.Windows.Forms.Button btnCustomerCategoryCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCustomerCategorySave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCategoryShortCode;
        private System.Windows.Forms.TextBox txtCategoryCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnCustomerGroupCancel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCustomerGroupSave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGroupShortCode;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridView dgvCustomerCategoryMaster;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryShortCode;
        private System.Windows.Forms.DataGridView dgvCustomerGroupMaster;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupShortCode;
        private System.ComponentModel.BackgroundWorker bwFillCustomerTypeGrid;
        private System.ComponentModel.BackgroundWorker bwCustomerCategoryGrid;
        private System.ComponentModel.BackgroundWorker bwCustomerGroupGrid;
        private System.Windows.Forms.Button btnClose;
    }
}