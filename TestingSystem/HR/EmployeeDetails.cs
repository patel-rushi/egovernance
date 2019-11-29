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

namespace TestingSystems.HR
{
    public partial class EmployeeDetails : Form
    {
        public Int32 FullScreenOff = 0;
        public EmployeeDetails()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            dtpRemoveDate.Focus();
        }

        DataTable dtGrid = new DataTable();
        public Int16 EmployeeID;
        int dummy = 2;
        int ColumnDisplay = 0;

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            dtpRemoveDate.Focus();
            try
            {
                dgvEmployeeDetail.AutoGenerateColumns = false;
                dtpDatefrom.Value = System.DateTime.Now;
                dtpRemoveDate.Value = System.DateTime.Now;

                if (!bwEmployeeCode.IsBusy)
                    bwEmployeeCode.RunWorkerAsync();

                if (!bwEmployeeName.IsBusy)
                    bwEmployeeName.RunWorkerAsync();

                if (!bwFilterEmployeeCode.IsBusy)
                    bwFilterEmployeeCode.RunWorkerAsync();

                btnClose.Text = Helper.ButtonCaptions.Close;                
                

                Getdata();
                AutoFitForm.SetFormToMaximize(this);

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Getdata()
        {


            clsEmployeeDetails objEmployeeDetails = new clsEmployeeDetails();


            if (cmbFilterEmployeeCode.SelectedValue != null && cmbFilterEmployeeCode.SelectedValue.ToString() != String.Empty && cmbFilterEmployeeCode.SelectedValue != Helper.DropdownDefaultText.Select)
            {
                objEmployeeDetails.EmployeeCode = cmbFilterEmployeeCode.SelectedValue.ToString();
            }
            if (cmbFirstName.SelectedValue != null && cmbFirstName.SelectedValue.ToString() != String.Empty && cmbFirstName.SelectedValue != Helper.DropdownDefaultText.Select)
            {
                objEmployeeDetails.EmployeeName = cmbFirstName.SelectedValue.ToString();
            }
            //if (_EmployeeMasterInputParameters.isDummy == 1)
            objEmployeeDetails.IsDummy = dummy;
            if (ColumnDisplay == 0)
                dgvEmployeeDetail.Columns["IsDummy"].Visible = false;
            else if (ColumnDisplay == 1)
                dgvEmployeeDetail.Columns["IsDummy"].Visible = true;

            if (rbtnInActicve.Checked)
            {
                objEmployeeDetails.ISAct = 0;                
            }
            else if (rbtnActive.Checked)
            {
                objEmployeeDetails.ISAct = 1;
            }
            else
            {
                objEmployeeDetails.ISAct = -1;
            }


            dtGrid = objEmployeeDetails.FetchEmployeeDataSearch();
            if (dtGrid != null && dtGrid.Rows.Count > 0)
            {
                dgvEmployeeDetail.DataSource = dtGrid;
            }
            else
            {
                dgvEmployeeDetail.DataSource = null;
            }
            dgvEmployeeDetail.AutoGenerateColumns = false;
            dgvEmployeeDetail.Refresh();
        }

        private void dtpDatefrom_ValueChanged(object sender, EventArgs e)
        {
            Getdata();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbEmployeeCode.SelectedValue == null)
            {
                MessageBox.Show("Please select employee code", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEmployeeCode.Focus();
                return;
            }


            clsDailyAttendanceSheet DailyAttendanceSheet = new clsDailyAttendanceSheet();
            DailyAttendanceSheet.RemovalDate = dtpRemoveDate.Value.Date;
            // if (cmbEmployeeCode.SelectedValue != null && cmbEmployeeCode.SelectedValue.ToString() == "")
            DailyAttendanceSheet.EmployeeCode = cmbEmployeeCode.SelectedValue.ToString();
            DailyAttendanceSheet.RemoveEmployeeCode = chkRemoveEmployeeCode.Checked ? true : false;
            DailyAttendanceSheet.RemoveAllEmployee = chkRemoveAllData.Checked ? true : false;
            DailyAttendanceSheet.AddOrRemoveHrsStartTime = txtAddOrRemoveHrs.Text;
            DailyAttendanceSheet.AddOrRemoveHrsEndTime = txtAddHrsOutTime.Text;

           // Int32 result = DailyAttendanceSheet.RemoveEmployeeDummyData();

            //if (result == 1)
            //{
            //    MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    if (!bwEmployeeCode.IsBusy)
            //        bwEmployeeCode.RunWorkerAsync();
            //    dtpRemoveDate.Value = System.DateTime.Now;
            //    chkRemoveAllData.Checked = false;
            //    chkRemoveEmployeeCode.Checked = false;
            //    txtAddHrsOutTime.Text = "";
            //    txtAddOrRemoveHrs.Text = "";
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Getdata();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //dtpDatefrom.Value = System.DateTime.Now;
            if (cmbEmployeeCode.Items.Count > 0)
                cmbEmployeeCode.SelectedIndex = 0;
            if (cmbFilterEmployeeCode.Items.Count > 0)
                cmbFilterEmployeeCode.SelectedIndex = 0;
            if (cmbFirstName.Items.Count > 0)
                cmbFirstName.SelectedIndex = 0;
            Clear();
        }

        public void Clear()
        {
            dtpDatefrom.Value = System.DateTime.Now;
            dtpRemoveDate.Value = System.DateTime.Now;
            txtAddHrsOutTime.Text = string.Empty;
            txtAddOrRemoveHrs.Text = string.Empty;
            chkRemoveAllData.Checked = false;
            chkRemoveEmployeeCode.Checked = false;
            rbtnAll.Checked = true;
            if (!bwEmployeeCode.IsBusy)
                bwEmployeeCode.RunWorkerAsync();
            if (!bwFilterEmployeeCode.IsBusy)
                bwFilterEmployeeCode.RunWorkerAsync();
            if (!bwEmployeeName.IsBusy)
                bwEmployeeName.RunWorkerAsync();
            dummy = 2;
            ColumnDisplay = 0;
            Getdata();
            dtpRemoveDate.Focus();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        String Filters = "";

            //        //var dateAndTime = DateTime.Now;
            //        //var Crntdate = dateAndTime.Date;

            //        //var dtFilter = dtpDatefrom.Value;
            //        //var dateFilter = dtFilter.Date;

            //        //int result = DateTime.Compare(dateFilter, Crntdate);

            //        //if (result != 0)
            //        //{
            //        if (cmbFilterEmployeeCode.SelectedValue != null && cmbFilterEmployeeCode.SelectedValue != Helper.DropdownDefaultText.Select)
            //            Filters += "Code : " + cmbFilterEmployeeCode.SelectedValue.ToString();
            //        if (cmbFirstName.SelectedValue != null && cmbFirstName.SelectedValue != Helper.DropdownDefaultText.Select)
            //            Filters += " Name : " + cmbFirstName.SelectedValue.ToString();
            //        if (rbtnAll.Checked)
            //            Filters += " Status : ALL ";
            //        else if (rbtnActive.Checked)
            //            Filters += " Status : Active ";
            //        else
            //            Filters += " Status : InActive ";
            //        if (dummy == 1)
            //            Filters += " All Dummy Employee";
            //        if (dummy == 2)
            //            Filters += " All Employee";
            //        if (dummy == 0)
            //            Filters += " Regular Employee ";



            //        // }

            //        //Int32 v = ColumnDisplay;


            //        //clsDailyAttendanceSheet DailyAttendanceSheet = new clsDailyAttendanceSheet();
            //        //dtGrid = DailyAttendanceSheet.Fetch_EmployeeDetail_ALL_inActive();
            //        //Reports objReports = new Reports();                            

            //        List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();
            //        listDatatable.Add(new KeyValuePair<DataTable, string>(dtGrid, "BankDetail"));

            //        List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            //        list.Add(new KeyValuePair<string, string>("Filters", Filters));
            //        list.Add(new KeyValuePair<string, string>("IsDummy", ColumnDisplay.ToString()));
            //        //List<KeyValuePair<string, Int32>> IsDummy = new List<KeyValuePair<string, Int32>>();
            //        //IsDummy.Add(new KeyValuePair<string, Int32>("IsDummy", ColumnDisplay));

            //        //CUS Code is used in ISO and ReportName both tables. If you want to change then you have to change in both tables

            //        DownloadReports report = new DownloadReports(@"reports/EmployeeDetailReport.rdlc", "ED", false, listDatatable, list);
            //        report.Show();

            //    }
            //    catch (Exception ex)
            //    {
            //        ExceptionHandler.LogException(ex);
            //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        private void dgvEmployeeDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsEmployeeDetails objEmployeeDetails = new clsEmployeeDetails();
                EmployeeID = Convert.ToInt16(dgvEmployeeDetail.Rows[e.RowIndex].Cells["EmpId"].Value.ToString());                
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)//Gridview Edit Button Click
                {
                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {

                        if (Application.OpenForms.OfType<EmployeeMaster>().Count() == 1)
                            Application.OpenForms.OfType<EmployeeMaster>().First().Close();
                        EmployeeMaster obj = new EmployeeMaster(EmployeeID);
                        obj.FullScreenOff = 1;
                        obj.MdiParent = this.ParentForm;
                        obj.Show();
                        obj.Focus();                        
                    }
                }
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)//Gridview Delete Button Clicked
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objEmployeeDetails.EmployeeId = EmployeeID;
                        int result = objEmployeeDetails.DeleteEmployeeDetails();
                        if (result > 0)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvEmployeeDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvEmployeeDetail.Columns[e.ColumnIndex].Name == "IsDummy")
                    {
                        dgvEmployeeDetail.Rows[e.RowIndex].Cells["IsUpdated"].Value = 1;
                    }
                }
            }
            catch (Exception ex)
            {


                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployeeDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //try
            //{
            //    if (dtGrid != null)
            //    {
            //        foreach (DataGridViewRow row in dgvEmployeeDetail.Rows)
            //        {
            //            if ((row.Cells["isActive"].Value.ToString()) == "Active")
            //            {
            //                row.DefaultCellStyle.ForeColor = Color.Gray;
            //                row.DefaultCellStyle.Font = new Font(dgvEmployeeDetail.DefaultCellStyle.Font, FontStyle.Strikeout);
            //            }
            //        }
            //    }
            //}
            //catch
            //{ }
        }

        private void bwEmployeeCode_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsDailyAttendanceSheet DailyAttendanceSheet = new clsDailyAttendanceSheet();
                DailyAttendanceSheet.IsDummy = dummy;
                //DataTable dtEmployeeCode = DailyAttendanceSheet.Fetch_EmployeeCode();
              //  e.Result = dtEmployeeCode as DataTable;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwEmployeeCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    DataTable dtEmployeeCode = (DataTable)e.Result;
                    DataTable dtFilterEmployeeCode = (DataTable)e.Result;
                    if (dtEmployeeCode != null && dtEmployeeCode.Rows.Count > 0)
                    {
                        dtEmployeeCode.AddSelectRow(0, 0);
                        cmbEmployeeCode.DataSource = dtEmployeeCode;

                        cmbEmployeeCode.DisplayMember = "EmployeeCode";
                        cmbEmployeeCode.ValueMember = "EmployeeCode";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwEmployeeName_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsEmployeeDetails objEmployeeDetails = new clsEmployeeDetails();
                objEmployeeDetails.isEmpCodeOrName = 1;
                objEmployeeDetails.IsDummy = dummy;
                DataTable dtEmloyeeName = objEmployeeDetails.FetchEmployeeDetails();
                e.Result = dtEmloyeeName as DataTable;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwEmployeeName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    DataTable dtEmloyeeName = (DataTable)e.Result;

                    if (dtEmloyeeName != null && dtEmloyeeName.Rows.Count > 0)
                    {
                        dtEmloyeeName.AddSelectRow(0, 0);
                        cmbFirstName.DataSource = dtEmloyeeName;
                        cmbFirstName.DisplayMember = "EmployeeName";
                        cmbFirstName.ValueMember = "EmployeeName";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bwFilterEmployeeCode_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsEmployeeDetails objEmployeeDetails = new clsEmployeeDetails();
                objEmployeeDetails.isEmpCodeOrName = 0;
                objEmployeeDetails.IsDummy = dummy;
                DataTable dtFilterEmployeeCode = objEmployeeDetails.FetchEmployeeDetails();
                e.Result = dtFilterEmployeeCode as DataTable;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwFilterEmployeeCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    DataTable dtFilterEmployeeCode = (DataTable)e.Result;
                    if (dtFilterEmployeeCode != null && dtFilterEmployeeCode.Rows.Count > 0)
                    {
                        dtFilterEmployeeCode.AddSelectRow(0, 0);
                        cmbFilterEmployeeCode.DataSource = dtFilterEmployeeCode;
                        cmbFilterEmployeeCode.DisplayMember = "EmployeeCode";
                        cmbFilterEmployeeCode.ValueMember = "EmployeeCode";
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     
    }
}
