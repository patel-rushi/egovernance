using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class CustomerTypeCategoryGroupMaster : Form
    {
        public Guid _CustomerTypeId { get; set; }
        public Guid _CustomerCategoryId { get; set; }
        public Guid _CustomerGroupId { get; set; }
        public Int32 FullScreenOff = 0;
        private CustomerSupplierInputParameters _CustomerSupplierInputParameters;
        int Typeid = 0;
        int Categoryid = 0;
        int Groupid = 0;
        public CustomerTypeCategoryGroupMaster(CustomerSupplierInputParameters CustomerSupplierInputParameters)
        {
            InitializeComponent();

            _CustomerSupplierInputParameters = CustomerSupplierInputParameters;

            FullScreenOff = clsValues.Instance.FullScreenOff;

            if (FullScreenOff != 1)
            {
                AutoFitForm.SetGroupBoxLoction(this.gbMain);
            }
        }

        private void CustomerTypeCategoryGroupMaster_Load(object sender, EventArgs e)
        {
            try
            {
                // AutoFitForm.SetFormToMaximize(this);


                if (_CustomerSupplierInputParameters.LinkText == "Type")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tbType"];
                    txtTypeName.Focus();
                }
                else if (_CustomerSupplierInputParameters.LinkText == "Category")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tbCategory"];
                    txtCategoryName.Focus();
                }
                else if (_CustomerSupplierInputParameters.LinkText == "Group")
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tbGroup"];
                    txtGroupName.Focus();
                }



                txtTypeName.Focus();

                dgvCustomerCategoryMaster.AutoGenerateColumns = false;
                dgvCustomerGroupMaster.AutoGenerateColumns = false;
                dgvCustomerTypeMaster.AutoGenerateColumns = false;

                if (!this.bwFillCustomerTypeGrid.IsBusy) this.bwFillCustomerTypeGrid.RunWorkerAsync();
                if (!this.bwCustomerCategoryGrid.IsBusy) this.bwCustomerCategoryGrid.RunWorkerAsync();
                if (!this.bwCustomerGroupGrid.IsBusy) this.bwCustomerGroupGrid.RunWorkerAsync();

                if (btnCustomerTypeSave.Text == Helper.ButtonCaptions.Save)
                    fetch_TypeCodeNo();
                if (btnCustomerCategorySave.Text == Helper.ButtonCaptions.Save)
                    fetch_CategoryCodeNo();
                if (btnCustomerGroupSave.Text == Helper.ButtonCaptions.Save)
                    fetch_GroupCodeNo();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fetch_TypeCodeNo() // Fetch Type Code 
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                if (btnCustomerTypeSave.Text == Helper.ButtonCaptions.Save)
                {
                    DataTable dtCustomerTypeCode = customerTypeCategoryGroupMaster.Fetch_Type_Code();

                    if (dtCustomerTypeCode != null && dtCustomerTypeCode.Rows.Count > 0)
                    {
                        txtTypeCode.Text = dtCustomerTypeCode.Rows[0]["TypeCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fetch_CategoryCodeNo() // Fetch Category Code
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                if (btnCustomerCategorySave.Text == Helper.ButtonCaptions.Save)
                {
                    DataTable dtCustomerTypeCode = customerTypeCategoryGroupMaster.Fetch_Category_Code();

                    if (dtCustomerTypeCode != null && dtCustomerTypeCode.Rows.Count > 0)
                    {
                        txtCategoryCode.Text = dtCustomerTypeCode.Rows[0]["CategoryCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fetch_GroupCodeNo() // Fetch Group Code
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                if (btnCustomerGroupSave.Text == Helper.ButtonCaptions.Save)
                {
                    DataTable dtCustomerTypeCode = customerTypeCategoryGroupMaster.Fetch_Group_Code();

                    if (dtCustomerTypeCode != null && dtCustomerTypeCode.Rows.Count > 0)
                    {
                        txtGroupCode.Text = dtCustomerTypeCode.Rows[0]["GroupCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomerTypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCustomerTypeMaster.Rows.Count; i++)
                {
                    if (dgvCustomerTypeMaster.Rows[i].Cells["TypeName"].Value.ToString().ToUpper() == txtTypeName.Text.ToUpper())
                    {
                        if (btnCustomerTypeSave.Text == Helper.ButtonCaptions.Update && Typeid == i)
                        {
                            continue;
                        }
                        MessageBox.Show(txtTypeName.Text + " Is Already Exist.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTypeName.Focus();
                        return;
                    }
                }

                if (txtTypeCode.Text == string.Empty)
                {
                    const string type = "Enter Type Code";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtTypeCode.Focus();
                    return;
                }
                if (txtTypeName.Text == string.Empty)
                {
                    const string type = "Enter Type Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtTypeName.Focus();
                    return;
                }

                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                customerTypeCategoryGroupMaster.TypeCode = txtTypeCode.Text;
                customerTypeCategoryGroupMaster.TypeName = txtTypeName.Text;
                customerTypeCategoryGroupMaster.TypeShortCode = txtTypeShortCode.Text;

                if (btnCustomerTypeSave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = customerTypeCategoryGroupMaster.Insert_Customer_Type_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerType();
                            txtTypeName.Focus();
                            if (!this.bwFillCustomerTypeGrid.IsBusy) this.bwFillCustomerTypeGrid.RunWorkerAsync();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (btnCustomerTypeSave.Text == Helper.ButtonCaptions.Update)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        customerTypeCategoryGroupMaster.CustomerTypeId = _CustomerTypeId;
                        int result = customerTypeCategoryGroupMaster.Update_Customer_Type_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerType();
                            txtTypeCode.Focus();
                            if (!this.bwFillCustomerTypeGrid.IsBusy) this.bwFillCustomerTypeGrid.RunWorkerAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomerType()
        {
            try
            {
                btnCustomerTypeSave.Text = Helper.ButtonCaptions.Save;
                txtTypeCode.Clear();
                txtTypeName.Text = "";
                txtTypeShortCode.Clear();
                if (!bwFillCustomerTypeGrid.IsBusy)
                    bwFillCustomerTypeGrid.RunWorkerAsync();
                fetch_TypeCodeNo();
                txtTypeName.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomerCancel_Click(object sender, EventArgs e)
        {
            ClearCustomerType();
        }

        private void btnCustomerCategorySave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCustomerCategoryMaster.Rows.Count; i++)
                {
                    if (dgvCustomerCategoryMaster.Rows[i].Cells["CategoryName"].Value.ToString().ToUpper() == txtCategoryName.Text.ToUpper())
                    {
                        if (btnCustomerCategorySave.Text == Helper.ButtonCaptions.Update && Categoryid == i)
                        {
                            continue;
                        }
                        MessageBox.Show(txtCategoryName.Text + " Is Already Exist.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCategoryName.Focus();
                        return;
                    }
                }

                if (txtCategoryCode.Text == string.Empty)
                {
                    const string type = "Enter Category Code";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtCategoryCode.Focus();
                    return;
                }
                if (txtCategoryName.Text == string.Empty)
                {
                    const string type = "Enter Category Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtCategoryName.Focus();
                    return;
                }

                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                customerTypeCategoryGroupMaster.CategoryCode = txtCategoryCode.Text;
                customerTypeCategoryGroupMaster.CategoryName = txtCategoryName.Text;
                customerTypeCategoryGroupMaster.CategoryShortCode = txtCategoryShortCode.Text;

                if (btnCustomerCategorySave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = customerTypeCategoryGroupMaster.Insert_Customer_Category_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerCategory();
                            txtCategoryName.Focus();
                            if (!this.bwCustomerCategoryGrid.IsBusy) this.bwCustomerCategoryGrid.RunWorkerAsync();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (btnCustomerCategorySave.Text == Helper.ButtonCaptions.Update)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        customerTypeCategoryGroupMaster.CustomerCategoryId = _CustomerCategoryId;
                        int result = customerTypeCategoryGroupMaster.Update_Customer_Category_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerCategory();
                            txtCategoryName.Focus();
                            if (!this.bwCustomerCategoryGrid.IsBusy) this.bwCustomerCategoryGrid.RunWorkerAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomerCategory()
        {
            try
            {
                btnCustomerCategorySave.Text = Helper.ButtonCaptions.Save;
                txtCategoryCode.Clear();
                txtCategoryName.Text = "";
                txtCategoryShortCode.Clear();
                if (!bwCustomerCategoryGrid.IsBusy)
                    bwCustomerCategoryGrid.RunWorkerAsync();
                fetch_CategoryCodeNo();
                txtCategoryName.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustomerCategoryCancel_Click(object sender, EventArgs e)
        {
            ClearCustomerCategory();
        }

        private void btnCustomerGroupSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvCustomerGroupMaster.Rows.Count; i++)
                {
                    if (dgvCustomerGroupMaster.Rows[i].Cells["GroupCode"].Value.ToString().ToUpper() == txtGroupCode.Text.ToUpper())
                    {
                        if (btnCustomerGroupSave.Text == Helper.ButtonCaptions.Update && Groupid == i)
                        {
                            continue;
                        }
                        MessageBox.Show(txtGroupCode.Text + " Is Already Exist.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGroupCode.Focus();
                        return;
                    }
                    if (dgvCustomerGroupMaster.Rows[i].Cells["GroupName"].Value.ToString().ToUpper() == txtGroupName.Text.ToUpper())
                    {
                        MessageBox.Show(txtGroupName.Text + " Is Already Exist.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGroupName.Focus();
                        return;
                    }
                }

                if (txtGroupCode.Text == string.Empty)
                {
                    const string type = "Enter Group Code";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtGroupCode.Focus();
                    return;
                }
                if (txtGroupName.Text == string.Empty)
                {
                    const string type = "Enter Group Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtGroupName.Focus();
                    return;
                }

                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                customerTypeCategoryGroupMaster.GroupCode = txtGroupCode.Text;
                customerTypeCategoryGroupMaster.GroupName = txtGroupName.Text;
                customerTypeCategoryGroupMaster.GroupShortCode = txtGroupShortCode.Text;

                if (btnCustomerGroupSave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int result = customerTypeCategoryGroupMaster.Insert_Customer_Group_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerGroup();
                            txtGroupCode.Focus();
                            if (!this.bwCustomerGroupGrid.IsBusy) this.bwCustomerGroupGrid.RunWorkerAsync();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (btnCustomerGroupSave.Text == Helper.ButtonCaptions.Update)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        customerTypeCategoryGroupMaster.CustomerGroupId = _CustomerGroupId;
                        int result = customerTypeCategoryGroupMaster.Update_Customer_Group_Details();

                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearCustomerGroup();
                            txtGroupCode.Focus();
                            if (!this.bwCustomerGroupGrid.IsBusy) this.bwCustomerGroupGrid.RunWorkerAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCustomerGroup()
        {
            try
            {
                btnCustomerGroupSave.Text = Helper.ButtonCaptions.Save;
                txtGroupCode.Clear();
                txtGroupName.Text = "";
                txtGroupShortCode.Clear();
                if (!bwCustomerGroupGrid.IsBusy)
                    bwCustomerGroupGrid.RunWorkerAsync();
                fetch_GroupCodeNo();
                txtGroupName.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwFillCustomerTypeGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                e.Result = customerTypeCategoryGroupMaster.Fetch_Customer_Type_Details();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwFillCustomerTypeGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvCustomerTypeMaster.DataSource = e.Result as DataTable;

                clsAccessMenu access_menu = new clsAccessMenu();
                if (dgvCustomerTypeMaster.Columns.Contains("EDIT"))
                    dgvCustomerTypeMaster.Columns["EDIT"].Visible = true; // access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);

                if (dgvCustomerTypeMaster.Columns.Contains("DELETE"))
                    dgvCustomerTypeMaster.Columns["DELETE"].Visible = true; // access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerCategoryGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                e.Result = customerTypeCategoryGroupMaster.Fetch_Customer_Category_Details();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerCategoryGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvCustomerCategoryMaster.DataSource = e.Result as DataTable;

                if (tabControl1.SelectedTab == tabControl1.TabPages["tbCategory"])//your specific tabname
                {
                    clsAccessMenu access_menu = new clsAccessMenu();
                    if (dgvCustomerCategoryMaster.Columns.Contains("EDIT"))
                        dgvCustomerCategoryMaster.Columns["EDIT"].Visible = access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);
                    if (dgvCustomerCategoryMaster.Columns.Contains("DELETE"))
                        dgvCustomerCategoryMaster.Columns["DELETE"].Visible = access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerGroupGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                e.Result = customerTypeCategoryGroupMaster.Fetch_Customer_Group_Details();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerGroupGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvCustomerGroupMaster.DataSource = e.Result as DataTable;
                if (tabControl1.SelectedTab == tabControl1.TabPages["tbGroup"])//your specific tabname
                {
                    clsAccessMenu access_menu = new clsAccessMenu();
                    if (dgvCustomerGroupMaster.Columns.Contains("EDIT"))
                        dgvCustomerGroupMaster.Columns["EDIT"].Visible = access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);
                    if (dgvCustomerGroupMaster.Columns.Contains("DELETE"))
                        dgvCustomerGroupMaster.Columns["DELETE"].Visible = access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.CUSTOMERTYPECATEGORYGROUPMASTER);
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomerTypeMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    _CustomerTypeId = Guid.Parse(dgvCustomerTypeMaster.Rows[e.RowIndex].Cells["CustomerTypeId"].Value.ToString());
                    if (dgvCustomerTypeMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                    {
                        Typeid = e.RowIndex;
                        txtTypeCode.Enabled = false;
                        btnCustomerTypeSave.Text = Helper.ButtonCaptions.Update;
                        txtTypeCode.Text = dgvCustomerTypeMaster.Rows[e.RowIndex].Cells["TypeCode"].Value.ToString();
                        txtTypeName.Text = dgvCustomerTypeMaster.Rows[e.RowIndex].Cells["TypeName"].Value.ToString();
                        txtTypeShortCode.Text = dgvCustomerTypeMaster.Rows[e.RowIndex].Cells["TypeShortCode"].Value.ToString();
                    }
                    if (dgvCustomerTypeMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                    {
                        if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                            customerTypeCategoryGroupMaster.CustomerTypeId = _CustomerTypeId;
                            int result = customerTypeCategoryGroupMaster.Delete_Customer_Type_Details();

                            if (result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header);
                                btnCustomerTypeSave.Text = Helper.ButtonCaptions.Save;
                                if (!bwFillCustomerTypeGrid.IsBusy) bwFillCustomerTypeGrid.RunWorkerAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomerCategoryMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    _CustomerCategoryId = Guid.Parse(dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells["CustomerCategoryId"].Value.ToString());
                    if (dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                    {
                        Categoryid = e.RowIndex;
                        txtCategoryCode.Enabled = false;
                        btnCustomerCategorySave.Text = Helper.ButtonCaptions.Update;
                        txtCategoryCode.Text = dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells["CategoryCode"].Value.ToString();
                        txtCategoryName.Text = dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                        txtCategoryShortCode.Text = dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells["CategoryShortCode"].Value.ToString();
                    }
                    if (dgvCustomerCategoryMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                    {
                        if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                            customerTypeCategoryGroupMaster.CustomerCategoryId = _CustomerCategoryId;
                            int result = customerTypeCategoryGroupMaster.Delete_Customer_Category_Details();

                            if (result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header);
                                btnCustomerCategorySave.Text = Helper.ButtonCaptions.Save;
                                if (!bwCustomerCategoryGrid.IsBusy) bwCustomerCategoryGrid.RunWorkerAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomerGroupMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    _CustomerGroupId = Guid.Parse(dgvCustomerGroupMaster.Rows[e.RowIndex].Cells["CustomerGroupId"].Value.ToString());
                    if (dgvCustomerGroupMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                    {
                        Groupid = e.RowIndex;
                        txtGroupCode.Enabled = false;
                        btnCustomerGroupSave.Text = Helper.ButtonCaptions.Update;
                        txtGroupCode.Text = dgvCustomerGroupMaster.Rows[e.RowIndex].Cells["GroupCode"].Value.ToString();
                        txtGroupName.Text = dgvCustomerGroupMaster.Rows[e.RowIndex].Cells["GroupName"].Value.ToString();
                        txtGroupShortCode.Text = dgvCustomerGroupMaster.Rows[e.RowIndex].Cells["GroupShortCode"].Value.ToString();
                    }
                    if (dgvCustomerGroupMaster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                    {
                        if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                            customerTypeCategoryGroupMaster.CustomerGroupId = _CustomerGroupId;
                            int result = customerTypeCategoryGroupMaster.Delete_Customer_Group_Details();

                            if (result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header);
                                btnCustomerGroupSave.Text = Helper.ButtonCaptions.Save;
                                if (!bwCustomerGroupGrid.IsBusy) bwCustomerGroupGrid.RunWorkerAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tbType"])//your specific tabname
                {
                    btnCustomerTypeSave_Click(btnCustomerTypeSave, null);
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tbCategory"])//your specific tabname
                {
                    btnCustomerCategorySave_Click(btnCustomerCategorySave, null);
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages["tbGroup"])//your specific tabname
                {
                    btnCustomerGroupSave_Click(btnCustomerGroupSave, null);
                }
            }
            if (keyData == (Keys.F5))
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearCustomerCategory();
                    ClearCustomerGroup();
                    ClearCustomerType();
                    btnCustomerCategorySave.Text = Helper.ButtonCaptions.Save;
                    btnCustomerGroupSave.Text = Helper.ButtonCaptions.Save;
                    btnCustomerTypeSave.Text = Helper.ButtonCaptions.Save;
                    txtTypeCode.Focus();
                    return true;
                }
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnCustomerGroupCancel_Click(object sender, EventArgs e)
        {
            ClearCustomerGroup();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomerTypeMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose.Focus();
            }
        }

      

    }
}
