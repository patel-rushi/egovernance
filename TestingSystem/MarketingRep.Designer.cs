namespace TestingSystems
{
    partial class MarketingRep
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Rep = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_RepName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.dgv_Rep);
            this.groupBox1.Controls.Add(this.btn_Clear);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Controls.Add(this.txt_RepName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 261);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marketing Rep";
            // 
            // dgv_Rep
            // 
            this.dgv_Rep.AllowUserToAddRows = false;
            this.dgv_Rep.AllowUserToDeleteRows = false;
            this.dgv_Rep.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_Rep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.Method,
            this.RepId});
            this.dgv_Rep.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv_Rep.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_Rep.Location = new System.Drawing.Point(11, 116);
            this.dgv_Rep.Name = "dgv_Rep";
            this.dgv_Rep.ReadOnly = true;
            this.dgv_Rep.RowHeadersVisible = false;
            this.dgv_Rep.Size = new System.Drawing.Size(214, 128);
            this.dgv_Rep.TabIndex = 4;
            this.dgv_Rep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Rep_CellClick);
            // 
            // Edit
            // 
            this.Edit.ActiveLinkColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = "Edit";
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.HeaderText = "Edit";
            this.Edit.LinkColor = System.Drawing.Color.Black;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Black;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.ActiveLinkColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.HeaderText = "Delete";
            this.Delete.LinkColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.VisitedLinkColor = System.Drawing.Color.Black;
            this.Delete.Width = 50;
            // 
            // Method
            // 
            this.Method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Method.DataPropertyName = "PersonName";
            this.Method.HeaderText = "Rep Name";
            this.Method.Name = "Method";
            this.Method.ReadOnly = true;
            // 
            // RepId
            // 
            this.RepId.DataPropertyName = "PersonRepId";
            this.RepId.HeaderText = "PersonRepId";
            this.RepId.Name = "RepId";
            this.RepId.ReadOnly = true;
            this.RepId.Visible = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(123, 72);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(55, 23);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(62, 72);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(55, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // txt_RepName
            // 
            this.txt_RepName.Location = new System.Drawing.Point(102, 35);
            this.txt_RepName.Name = "txt_RepName";
            this.txt_RepName.Size = new System.Drawing.Size(123, 20);
            this.txt_RepName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rep Name :";
            // 
            // MarketingRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 262);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MarketingRep";
            this.Text = "MarketingRep";
            this.Load += new System.EventHandler(this.MarketingRep_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Rep;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox txt_RepName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepId;
    }
}