using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.Helpers;

//Author : Yashvi Shah
//Date   : 30 DECEMBER 2017

namespace TestingSystems
{
    public partial class SpRequirementMaster : Form
    {
        #region Constructor
        public SpRequirementMaster()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            if (FullScreenOff != 1)
            {
                AutoFitForm.SetGroupBoxLoction(this.GroupBoxMain);
            }
            FillGrid();
            txtCode.Focus();

        }
        #endregion

        #region Data properties
        public Int32 FullScreenOff = 0;
        Guid SPRequirementID = Guid.Empty;
        DataTable dtCheckedRecord = new DataTable();
        #endregion

        #region Function
        private void FillGrid()
        {
            ClsSPRequirement SPRequirement = new ClsSPRequirement();

            DataTable dt = SPRequirement.FetchSpRequirementDetail();

            dgvSpRequirement.DataSource = dt;

            dgvSpRequirement.Columns["SP_RequirementID"].Visible = false;

            clsAccessMenu access_menu = new clsAccessMenu();
            dgvSpRequirement.Columns["EDIT"].Visible = access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.SPREQUIREMENTMASTER);
            dgvSpRequirement.Columns["DELETE"].Visible = access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.SPREQUIREMENTMASTER);

            txtCode.Focus();

        }
        
        private void ClearData()
        {
            txtCode.Text = string.Empty;
            txtCode.Focus();
            txtSpRequirement.Text = string.Empty;
            btnSave.Text = Helper.ButtonCaptions.Save;
            FillGrid();

            foreach (int i in chkDepartment.CheckedIndices)
            {
                chkDepartment.SetItemCheckState(i, CheckState.Unchecked);
            }
            dtCheckedRecord = null;
            txtCode.Enabled = true;
        }

        private void Fill_Department()
        {
            try
            {
                clsDepartment objdepartment = new clsDepartment();
                DataTable FetchSystemDepartment = objdepartment.FetchSystemDepartment();

                if (!FetchSystemDepartment.IsNullOrEmpty())
                {
                    IsLoadDepartment = false;
                    chkDepartment.DataSource = FetchSystemDepartment;
                    chkDepartment.ValueMember = "DepartmentId";
                    chkDepartment.DisplayMember = "DepartMentName";
                    IsLoadDepartment = true;
                }
                txtCode.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region ClickEvents
        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            ClsSPRequirement SpRequirement = new ClsSPRequirement();

            if (txtCode.Text == null || txtCode.Text == string.Empty)
            {
                const string type = "Enter Sp. requirement code.";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                txtCode.Focus();
                return;
            }

            if (txtSpRequirement.Text == null || txtSpRequirement.Text == string.Empty)
            {
                const string type = "Enter Sp. requirement.";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                txtSpRequirement.Focus();
                return;
            }

            SpRequirement.SpRequirement = txtSpRequirement.Text;
            SpRequirement.Code = txtCode.Text;

            #region Department Field
                        
            DataTable dtDepartment = new DataTable();

            if (dtDepartment.Rows.Count == 0)
            {
                dtDepartment.Columns.Add("DepartmentId");
            }
            string comp = string.Empty;

            for (int i = 0; i < chkDepartment.CheckedItems.Count; i++)
            {
                comp = (chkDepartment.CheckedItems[i] as DataRowView)["DepartmentId"].ToString();
                DataRow dradd = dtDepartment.NewRow();
                dradd["DepartmentId"] = (chkDepartment.CheckedItems[i] as DataRowView)["DepartmentId"].ToString();// dtIssueIndentAdd.Rows[RowIndex];
                dtDepartment.Rows.Add(dradd);
            }

            SpRequirement.dtDepartment = dtDepartment;

            SpRequirement.dtCheckedRecord = dtCheckedRecord;


            #endregion


            if (btnSave.Text == Helper.ButtonCaptions.Save)
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = SpRequirement.InsertIntoSpRequirementMaster();
                }

                if (result == 1)
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                    ClearData();

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == Helper.ButtonCaptions.Update)
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SpRequirement.SpRequirementID = SPRequirementID;

                    result = SpRequirement.UpdateSpRequirementMaster();
                }
                if (result == 1)
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillGrid();
                    ClearData();

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(btnSave, null);
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            if (keyData == (Keys.F5))
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearData();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region DataGridViewEvent
        private void dgvSpRequirement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClsSPRequirement SPRequirement = new ClsSPRequirement();
            ClsPatternCheckLIstMaster patternCheckList = new ClsPatternCheckLIstMaster();
            if (dgvSpRequirement.Rows[e.RowIndex].Cells["SP_RequirementID"].Value != null && dgvSpRequirement.Rows[e.RowIndex].Cells["SP_RequirementID"].Value.ToString() != string.Empty && Guid.Parse(dgvSpRequirement.Rows[e.RowIndex].Cells["SP_RequirementID"].Value.ToString()) != Guid.Empty)
            {
                SPRequirementID = Guid.Parse(dgvSpRequirement.Rows[e.RowIndex].Cells["SP_RequirementID"].Value.ToString());
            }
            else
            {
                SPRequirementID = Guid.Empty;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvSpRequirement.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                {
                    dtCheckedRecord = new DataTable();
                    foreach (int i in chkDepartment.CheckedIndices)
                    {
                        chkDepartment.SetItemCheckState(i, CheckState.Unchecked);
                    }

                    #region Department


                    clsProcess objclsProcess = new clsProcess();
                    objclsProcess.ReferenceType = 2;

                    if (SPRequirementID != null && SPRequirementID != Guid.Empty)
                        objclsProcess.ReferenceId = SPRequirementID;


                    if (!(dtCheckedRecord != null && dtCheckedRecord.Rows.Count > 0))
                        dtCheckedRecord = objclsProcess.Fetch_ProductionProcessMapping_With_ProcessName_Equip_SPRequire();
                    

                    ClsSPRequirement DepartmentRequire = new ClsSPRequirement();
                    DepartmentRequire.SpRequirementID = SPRequirementID;
                    DataTable dtFetchDepartment = DepartmentRequire.FetchDepartment();
                    IsLoadDepartment = false;
                    if (!dtFetchDepartment.IsNullOrEmpty())
                    {
                        Guid value = Guid.Empty;
                        List<Guid> list = dtFetchDepartment.AsEnumerable().Select(row => Guid.Parse(Convert.ToString(row[2]))).ToList();//.ToList();
                        for (int i = 0; i < chkDepartment.Items.Count; i++)
                        {
                            DataRowView view = chkDepartment.Items[i] as DataRowView;
                            value = (Guid)view["DepartmentId"];
                            if (list.Contains(value))
                                chkDepartment.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                    IsLoadDepartment = true;
                    #endregion
                    txtCode.Enabled = false;
                    txtCode.Text = dgvSpRequirement.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                    txtSpRequirement.Text = dgvSpRequirement.Rows[e.RowIndex].Cells["SpRequirement"].Value.ToString();
                    btnSave.Text = Helper.ButtonCaptions.Update;

                }
                else if (dgvSpRequirement.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                {
                    int result = 0;

                    SPRequirement.SpRequirementID = SPRequirementID;

                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        result = SPRequirement.DeleteFromSpRequirement();
                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillGrid();
                            ClearData();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("This requirement is already used in customer.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region LeaveEvent
        private void txtCode_Leave(object sender, EventArgs e)
        {
            ClsSPRequirement SPRequirement = new ClsSPRequirement();

            int result = 0;
            SPRequirement.Code = txtCode.Text;
            //CheckCodeDuplicate() function will check that if Code which is entered by user is exist in database or not.
            result = SPRequirement.CheckCodeDuplicate();
            if (result == 1)
            {
                MessageBox.Show("Code already exist.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Clear();
                txtCode.Focus();
                return;
            }

        }
        #endregion

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtCode.Text.Length >= 5)
            //{
            //    System.Windows.Forms.MessageBox.Show("Code maximum length should be five characters.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
            //    txtCode.Clear();
            //    txtCode.Focus();
            //    return;

            //}
        }

        private void SpRequirementMaster_Load(object sender, EventArgs e)
        {
            //var applicationConfiguration = TestingSystems.Helpers.ConfigurationHelper.GetApplicationConfiguration();

            //if (!applicationConfiguration.IsDepartmentwiseDataEnable)
            //{
            //    lblDepartmentLabel.Visible = false;
            //    chkDepartment.Visible = false;
            //}
            //else
            //{
            //    Fill_Department();
            //}

           // Fill_Process();
        }

        private void GroupBoxMain_Enter(object sender, EventArgs e)
        {

        }

        bool IsLoadDepartment = false;
        private void chkDepartment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (e.NewValue == CheckState.Checked && IsLoadDepartment)
                {
                    int selected = e.Index;
                    DataRowView view = chkDepartment.Items[selected] as DataRowView;
                    String value = (String)view["DepartMentName"];
                    if ((value.ToLower()).Contains("production") || (value.ToLower()).Contains("machining"))
                    {
                        clsValues.Instance.FullScreenOff = 1;


                        clsProcess objclsProcess = new clsProcess();
                        objclsProcess.ReferenceType = 0;

                        if (SPRequirementID != null && SPRequirementID != Guid.Empty)
                            objclsProcess.ReferenceId = SPRequirementID;

                        if (!(dtCheckedRecord != null && dtCheckedRecord.Rows.Count > 0))
                            dtCheckedRecord = objclsProcess.Fetch_ProductionProcessMapping_With_ProcessName_Equip_SPRequire();


                        ProcessPopupInputParameters objPopProcess = new ProcessPopupInputParameters(Enums.FormMode.Insert);
                        objPopProcess.ReferenceType = 0;

                        objPopProcess.dtCheckedProcess = dtCheckedRecord;
                        // objProcessMstPopp.ObjProcessPopupInputParameters = objPopProcess;

                        ProcessMasterPopup objProcessMstPopp = new ProcessMasterPopup(objPopProcess);
                        if ((value.ToLower()).Contains("production"))
                        {
                            objProcessMstPopp.IsMachineShop = false;
                        }
                        else
                        {
                            objProcessMstPopp.IsMachineShop = true;
                        }
                        objProcessMstPopp.MinimizeBox = false;
                        objProcessMstPopp.MaximizeBox = false;
                        objProcessMstPopp.ShowInTaskbar = false;

                        objProcessMstPopp.ShowDialog();
                        clsValues.Instance.FullScreenOff = 0;
                        dtCheckedRecord = objProcessMstPopp.dtCheckedProcess;
                    }
                }
            }
            catch
            { }
        }

    }
}
