using TestingSystems.App_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TestingSystems
{
    public partial class BankMaster : Form
    {
        CustomerMaster _Owner;
        //SupplierMaster _Sowner;
        //CompanyMaster _COwner;
        public Int32 FullScreenOff = 0;
        public BankMaster(CustomerMaster Owner)
        {
            InitializeComponent();
            _Owner = Owner;
        }
        //public BankMaster(SupplierMaster Owner)
        //{
        //    InitializeComponent();
        //    _Sowner = Owner;
        //}
        //public BankMaster(CompanyMaster Owner)
        //{
        //    InitializeComponent();
        //    _COwner = Owner;
        //}

        private void BankMaster_Load(object sender, EventArgs e)
        {
            dgvBankDetail.AutoGenerateColumns = false;
            CLEAR();
            FillGrid();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsBankMaster bankdata = new clsBankMaster();

                if (txtBankName.Text.Trim() == "")
                {
                    const string type = "Enter Bank Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtBankName.Focus();
                    return;
                }
                bankdata.BankName = txtBankName.Text.Trim();

                int result = 0;

                if (btnSave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        result = bankdata.Insert_Bank_Master();
                    }

                    if (result == 1)
                    {
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid();
                        CLEAR();
                        txtBankName.Focus();
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
                        bankdata.BankId = Bank_Id;

                        result = bankdata.Update_Bank_Master();
                    }
                    if (result == 1)
                    {
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillGrid();
                        CLEAR();
                        txtBankName.Focus();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region CLEAR Values

        private void CLEAR()
        {

            txtBankName.Clear();
            btnSave.Text = Helper.ButtonCaptions.Save;
            txtBankName.Focus();
        }
        #endregion

        #region Fill Grid

        private void FillGrid()
        {
            clsBankMaster bankdata = new clsBankMaster();

            DataTable dt = bankdata.FetchBankDetail();

            dgvBankDetail.DataSource = dt;


            dgvBankDetail.Columns["BankId"].Visible = false;

        }

        #endregion
        Guid Bank_Id = Guid.Empty;
        private void dgvBankDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvBankDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgvBankDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        clsBankMaster bankdata = new clsBankMaster();
                        if (dgvBankDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                        {
                            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Bank_Id = Guid.Parse(dgvBankDetail.Rows[e.RowIndex].Cells["BankId"].Value.ToString());
                                bankdata.BankId = Bank_Id;
                                int result = 0;
                                result = bankdata.DeleteBankName();
                                if (result == 1)
                                {
                                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FillGrid();
                                    CLEAR();
                                    txtBankName.Focus();
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else if (dgvBankDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                        {
                            btnSave.Text = Helper.ButtonCaptions.Update;
                            Bank_Id = Guid.Parse(dgvBankDetail.Rows[e.RowIndex].Cells["BankId"].Value.ToString());
                            txtBankName.Text = dgvBankDetail.Rows[e.RowIndex].Cells["BankName"].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
