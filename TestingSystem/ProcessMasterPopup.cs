
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
    public partial class ProcessMasterPopup : Form
    {
        public DataTable dtCheckedProcess { get; set; }
        public Boolean IsMachineShop { get; set; }
        //public ProcessPopupInputParameters ObjProcessPopupInputParameters;
        private ProcessPopupInputParameters objPopProcess;

        //public ProcessMasterPopup()
        //{
        //    InitializeComponent();
        //}

        public ProcessMasterPopup(ProcessPopupInputParameters objPopProcess)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.objPopProcess = objPopProcess;
        }

        private void FillUpGridRecord()
        {
            try
            {
                clsProcess clElemntMstr = new clsProcess();
                clElemntMstr.IsMachineShop = IsMachineShop;
                DataTable dtAllElement = clElemntMstr.Fetch_ProcessName();

                chkProcess.DataSource = dtAllElement;
                chkProcess.DisplayMember = "ProcessName"; 
                chkProcess.ValueMember = "ProcessId";

                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    chkProcess.SetItemCheckState(i, CheckState.Checked);
                }

                Guid value;
                List<String> list = new List<String>();


                dtCheckedProcess = objPopProcess.dtCheckedProcess;
                if (dtCheckedProcess != null && dtCheckedProcess.Rows.Count > 0)
                {
                    list = dtCheckedProcess.AsEnumerable().Select(row => (Convert.ToString(row[0]))).ToList();
                    
                    for (int i = 0; i < chkProcess.Items.Count; i++)
                    {
                        DataRowView view = chkProcess.Items[i] as DataRowView;
                        value = (Guid)view["ProcessId"];
                        if (list.Contains(value.ToString()))
                            chkProcess.SetItemCheckState(i, CheckState.Checked);
                        else
                            chkProcess.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
            catch
            { }
        }
     
        #region Short cut Key code

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveProcess_Click(btnSaveProcess, null);
            }
            if (keyData == (Keys.F5))
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FillUpGridRecord();
                    btnSaveProcess.Text = Helper.ButtonCaptions.Save;
                    chkProcess.Focus();
                    return true;
                }
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void ProcessMasterPopup_Load(object sender, EventArgs e)
        {
            try
            {               
                FillUpGridRecord();
            }
            catch
            { }
        }

        private void btnSaveProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string exists = string.Empty;

                    DataTable dtTmpChemical = new DataTable();
                    DataTable dtTempMechanical = new DataTable();
                    int MyRowCount = 0;

                    MyRowCount = dtCheckedProcess.Rows.Count;
                    dtTempMechanical = dtCheckedProcess.Clone();
                   

                    int row = 0;

                    foreach (int x in chkProcess.CheckedIndices)
                    {
                        //Adding Value of Checked Metal Grade Properties 

                        chkProcess.SelectedIndex = x;

                        
                            string NamesSelect = chkProcess.Text;
                            DataRow[] foundAuthors = dtCheckedProcess.Select("ProcessName = '" + NamesSelect + "'");

                            // DataRow[] foundAuthors = dtCheckedProcess.Select("MechanicalMetalElementId = '" + chkMetalElement.SelectedValue + "'");
                            if (foundAuthors.Length == 0)
                            {
                                dtCheckedProcess.Rows.Add();
                                if (dtCheckedProcess.Columns.Contains("ProcessId"))
                                    dtCheckedProcess.Rows[MyRowCount]["ProcessId"] = chkProcess.SelectedValue.ToString();
                                if (dtCheckedProcess.Columns.Contains("ProcessName"))
                                    dtCheckedProcess.Rows[MyRowCount]["ProcessName"] = chkProcess.Text;
                                MyRowCount++;
                            }
                            dtTempMechanical.Rows.Add();
                            if (dtTempMechanical.Columns.Contains("ProcessId"))
                                dtTempMechanical.Rows[row]["ProcessId"] = chkProcess.SelectedValue.ToString();
                            if (dtTempMechanical.Columns.Contains("ProcessName"))
                                dtTempMechanical.Rows[row]["ProcessName"] = chkProcess.Text;
                       
                        row++;
                    }

                    if (dtCheckedProcess != null)
                    {
                        for (int rows = 0; rows < dtCheckedProcess.Rows.Count; )
                        {
                            DataRow[] foundAuthors = dtTempMechanical.Select("ProcessName = '" + dtCheckedProcess.Rows[rows]["ProcessName"].ToString() + "'");
                            if (foundAuthors.Length == 0)
                            {
                                dtCheckedProcess.Rows.RemoveAt(rows);
                            }
                            else
                            {
                                rows++;
                            }
                        }
                    }
                    this.Close();
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

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            try
            {
                clsValues.Instance.FullScreenOff = 1;

                //ProcessMaster objitemtype = new ProcessMaster();
                //objitemtype.MinimizeBox = false;
                //objitemtype.MaximizeBox = false;
                //objitemtype.ShowInTaskbar = false;
                //objitemtype.ShowDialog();
                //FillUpGridRecord();

            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    if (chkAll.Checked)
                        chkProcess.SetItemCheckState(i, CheckState.Checked);
                    else
                        chkProcess.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            catch
            { }
        }

       // public MetalElementInputParameters ObjMetalElementInputParameters;


    }
}
