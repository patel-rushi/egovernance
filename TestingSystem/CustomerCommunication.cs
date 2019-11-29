using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.Helpers;
using Microsoft.Reporting.WinForms;

namespace TestingSystems
{
    public partial class CustomerCommunication : Form
    {
        Guid _CustomerId = Guid.Empty;
        bool b_Date = false;
        bool b_ActionDate = false;
        Guid _CommunicationId = Guid.Empty;
        public CustomerCommunication()
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        private void CustomerCommunication_Load(object sender, EventArgs e)
        {
            try
            {
                AutoFitForm.SetFormToMaximize(this);
                if (!bw_CompanyName.IsBusy)
                    bw_CompanyName.RunWorkerAsync();

                if (!bw_PersonRep.IsBusy)
                    bw_PersonRep.RunWorkerAsync();

                if (!bw_Action.IsBusy)
                    bw_Action.RunWorkerAsync();

                if (!bw_CommMethod.IsBusy)
                    bw_CommMethod.RunWorkerAsync();


                if (!bw_Product.IsBusy)
                    bw_Product.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void bw_CompanyName_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                e.Result = cidb.Fetch_CustomerName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void bw_CompanyName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CompanyName_Fill(e.Result as DataTable);
                scmb_CompanyName.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        private void CompanyName_Fill(DataTable pdt_CompanyName)
        {
            try
            {
                if (pdt_CompanyName.Rows.Count > 0)
                {
                    const string DisplayMember = "CustomerName";
                    const string ValueMember = "CustomerId";

                    pdt_CompanyName.AddSelectRow(0, 1);
                    scmb_CompanyName.DataSource = pdt_CompanyName;
                    scmb_CompanyName.DisplayMember = DisplayMember;
                    scmb_CompanyName.ValueMember = ValueMember;


                    //scmb_PersonRep.DataSource = null;
                    scmbPersonName.Items.Add("--SELECT--");
                    scmbPersonName.SelectedIndex = 0;
              
                   
                    Search();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void scmb_CompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PersonNameGet();
                if (scmb_CompanyName.SelectedIndex > 0)
                {
                    btnDownload.Enabled = true;
                }
                else
                {
                    btnDownload.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(  ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        private void PersonNameGet()
        {
            try
            {

                if ((scmb_CompanyName.SelectedIndex>=0) && scmb_CompanyName.SelectedValue != Helper.DropdownDefaultText.Select && scmb_CompanyName.SelectedValue != string.Empty)
                {
                    _CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());

                    if (_CustomerId != Guid.Empty)
                        Fetch_Detail_For_CompanyName(_CustomerId);
                    else
                        scmbPersonName.DataSource = null;
                }
                else
                {
                    _CustomerId = Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        private void Fetch_Detail_For_CompanyName(Guid ps_CustomerId)
        {
            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                cidb.CustomerId = ps_CustomerId;
                DataTable dt = cidb.Fetch_PersonName();
                if (dt.Rows.Count > 0)
                {
                    const string DisplayMember = "PersonName";
                    const string ValueMember = "ContactId";
                    dt.AddSelectRow(1, 0);
                    scmbPersonName.DataSource = dt;
                    scmbPersonName.DisplayMember = DisplayMember;
                    scmbPersonName.ValueMember = ValueMember;

                }
                else
                {
                    scmbPersonName.DataSource = null;
                }

                if (scmbPersonName.Items.Count > 0)
                {
                    scmbPersonName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message + Ex.StackTrace);
                ExceptionHandler.LogException(Ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save()
        {
            try
            {
                if ((scmb_CompanyName.SelectedIndex <= 0) && (Guid.Parse(scmb_CompanyName.SelectedValue.ToString()) == Guid.Empty))
                {
                    const string type = "Select Company Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    scmb_CompanyName.Focus();
                    return;
                }
                if ((scmb_PersonRep.SelectedIndex <= 0) || (scmb_PersonRep.Text == String.Empty) || (scmb_PersonRep.Text == "--SELECT--") || (Guid.Parse(scmb_PersonRep.SelectedValue.ToString()) == Guid.Empty))
                {
                    const string type = "Select Marketing Rep";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    scmb_PersonRep.Focus();
                    return;
                }
                if (txtDiscuss.Text == string.Empty)
                {
                    const string type = "Enter discussion";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);

                    txtDiscuss.Focus();
                    return;
                }
                if (scmb_Product.SelectedIndex <= 0)
                {
                    const string type = "Select Product";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);

                    scmb_Product.Focus();
                    return;
                }

                CommunicationDatabase cdb = new CommunicationDatabase();
                if (scmb_pendingAction.SelectedIndex > 0)
                {
                    cdb.ActionName = scmb_pendingAction.Text.ToString();// Guid.Parse(scmb_pendingAction.SelectedValue.ToString());
                    cdb.ActionDate = dtp_ActionDate.Value;
                    if (txtRemark.Text != string.Empty)
                    {
                        cdb.Remark = txtRemark.Text.ToString();
                    }
                }
                if (scmb_CommMethod.SelectedIndex > 0)
                {
                    cdb.CommMethod = scmb_CommMethod.Text.ToString();
                }
                cdb.CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());
                if (scmbPersonName.SelectedIndex > 0)
                    cdb.ContactId = Guid.Parse(scmbPersonName.SelectedValue.ToString());
                if (scmb_Product.SelectedIndex > 0)
                {
                    cdb.CompanyRep = scmb_Product.Text.ToString();
                }
                cdb.PersonRep = scmb_PersonRep.Text.ToString();
                cdb._Date = dtpDate.Value;
                cdb.Discussion = txtDiscuss.Text;
                if (btnSave.Text == "Save")
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cdb.Insert_ClientDiscussion() == 1)
                        {
                            const string type = "Saved";
                            System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                            clearpage();
                        }
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cdb.CommunicationId = _CommunicationId;
                        if (cdb.Update_ClientDiscussion() == 1)
                        {
                            const string type = "Updated";
                            System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                            clearpage();
                        }
                    }
                    btnSave.Text = "Save";
                }
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search()
        {
            try
            {
                DataTable dt = RecordGetFromDb();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable RecordGetFromDb()
        {
            DataTable dt = null;
            try
            {
                CommunicationDatabase cdb = new CommunicationDatabase();
                if ((scmb_CompanyName.SelectedIndex > 0) && (scmb_CompanyName.Text != string.Empty) && (scmb_CompanyName.Text != "--SELECT--") && (Guid.Parse(scmb_CompanyName.SelectedValue.ToString()) != Guid.Empty))
                {
                    cdb.CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());
                }
                if ((scmbPersonName.SelectedIndex > 0) && (scmbPersonName.Text != string.Empty) && (scmb_CompanyName.Text != "--SELECT--") && (Guid.Parse(scmbPersonName.SelectedValue.ToString()) != Guid.Empty))
                {
                    cdb.ContactId = Guid.Parse(scmbPersonName.SelectedValue.ToString());
                }
                if ((scmb_Product.SelectedIndex>0) && (scmb_Product.Text != string.Empty))
                {
                    cdb.CompanyRep = scmb_Product.Text.ToString();
                }
                if ((scmb_PersonRep.SelectedIndex > 0) && (scmb_PersonRep.Text != String.Empty) && (scmb_PersonRep.Text != "--SELECT--") && (Guid.Parse(scmb_PersonRep.SelectedValue.ToString()) != Guid.Empty))
                {
                    cdb.PersonRep = scmb_PersonRep.Text.ToString();
                }
                if (scmb_CommMethod.SelectedIndex > 0)
                {
                    cdb.CommMethod = scmb_CommMethod.Text.ToString();
                }
                if (b_Date == true)
                {
                    cdb._Date = dtpDate.Value;
                }
                else
                {
                    cdb._Date = null;
                }
                if (b_ActionDate == true)
                {
                    cdb.ActionDate = dtp_ActionDate.Value;
                }
                else
                {
                    cdb.ActionDate = null;
                }
                if (scmb_pendingAction.SelectedIndex > 0)
                {
                    cdb.ActionName = scmb_pendingAction.Text.ToString();
                }

                dt = cdb.Search_ClientDiscussion();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearpage();
                Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearpage()
        {
            try
            {
                scmb_CompanyName.SelectedIndex = 0;
                scmbPersonName.DataSource = null;
                scmb_PersonRep.SelectedIndex = 0;
                scmb_pendingAction.SelectedIndex = 0;
                scmb_CommMethod.SelectedIndex = 0;
                dtpDate.Value = DateTime.Now;
                txtDiscuss.Text = string.Empty;
                b_Date = false;
                b_ActionDate = false;
                dataGridView1.DataSource = null;
                scmb_PersonRep.Visible = true;
                scmb_PersonRep.Enabled = true;

                scmb_CommMethod.Visible = true;
                scmb_CommMethod.Enabled = true;
                scmb_pendingAction.Visible = true;
                scmb_pendingAction.Enabled = true;

                scmb_Product.SelectedIndex = 0;

                txtRemark.Text = string.Empty;

                dtp_ActionDate.Value = DateTime.Now;
              
                btnDownload.Enabled = false;

                btnSave.Text = "Save";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                b_Date = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dataGridView1.Rows[e.RowIndex];
                        _CommunicationId = Guid.Parse(selectrow.Cells["CommunicationId"].Value.ToString());

                        if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                           // if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                btnSave.Text = "Update";
                                FillUpdates(_CommunicationId);
                            }

                        }
                        else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CommunicationDatabase cdb = new CommunicationDatabase();
                                cdb.CommunicationId = _CommunicationId;
                                if (cdb.Delete_ClientDiscussion() == 1)
                                {
                                    const string type = "Deleted";
                                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                }
                            }
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
        private void FillUpdates(Guid _CommunicationId)
        {
            try
            {
                CommunicationDatabase cdb = new CommunicationDatabase();
                cdb.CommunicationId = _CommunicationId;
                DataTable dt = cdb.Search_For_Update();
                if (dt.Rows.Count > 0)
                {
                    scmb_CompanyName.SelectedValue = (dt.Rows[0]["CustomerId"].ToString());
                    PersonNameGet();
                    scmbPersonName.SelectedValue = (dt.Rows[0]["ContactId"].ToString());
                    scmb_Product.Text = dt.Rows[0]["CompanyRep"].ToString();
                    scmb_PersonRep.Text = dt.Rows[0]["PersonRep"].ToString();
                    dtpDate.Value = Convert.ToDateTime(dt.Rows[0]["DiscussDate"]);
                    txtDiscuss.Text = dt.Rows[0]["Discussion"].ToString();
                    if(dt.Rows[0]["CommMethod"].ToString() !=string.Empty)
                    {
                        scmb_CommMethod.Text = dt.Rows[0]["CommMethod"].ToString();
                    }
                    if (dt.Rows[0]["ActionName"].ToString() != string.Empty)
                    {
                        scmb_pendingAction.Text = dt.Rows[0]["ActionName"].ToString();
                    }
                    if (dt.Rows[0]["ActionDate"].ToString() != string.Empty)
                    {
                        dtp_ActionDate.Value = Convert.ToDateTime(dt.Rows[0]["ActionDate"].ToString());
                    }
                    if (dt.Rows[0]["Remark"].ToString() != string.Empty)
                    {
                        txtRemark.Text = dt.Rows[0]["Remark"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_PersonRep_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PersonRepDatabase prdb = new PersonRepDatabase();
                e.Result = prdb.Search_PersonName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bw_PersonRep_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                PersonRep_Fill(e.Result as DataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PersonRep_Fill(DataTable pdt_PersonRep)
        {
            try
            {
                if (pdt_PersonRep.Rows.Count > 0)
                {
                    const string DisplayMember = "PersonName";
                    const string ValueMember = "PersonRepId";

                    pdt_PersonRep.AddSelectRow(0, 1);
                    scmb_PersonRep.DataSource = pdt_PersonRep;
                    scmb_PersonRep.DisplayMember = DisplayMember;
                    scmb_PersonRep.ValueMember = ValueMember;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ////if ShowDetails_CustomerMaster is already open then it close first 
                if (Application.OpenForms.OfType<MarketingRep>().Count() == 1)
                    Application.OpenForms.OfType<MarketingRep>().First().Close();

                MarketingRep
                    Mrep = new MarketingRep();
                clsValues.Instance.FullScreenOff = 1;
                Mrep.ShowDialog();
                Mrep.Focus();
                clsValues.Instance.FullScreenOff = 0;

                if (!bw_PersonRep.IsBusy)
                    bw_PersonRep.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Shortcuts
        #region ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Save();
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.Message + Ex.StackTrace);
                            ExceptionHandler.LogException(Ex);
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return true;
                    }
                }
                if (keyData == (Keys.F5))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clearpage();
                        return true;
                    }
                }
                if (keyData == (Keys.Escape))
                {
                    scmb_CompanyName.Focus();
                    return true;
                }
                if (keyData == (Keys.Enter))
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//End Editition
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void scmb_CompanyName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                PersonNameGet();
                if (scmb_CompanyName.SelectedIndex > 0)
                {
                    btnDownload.Enabled = true;
                }
                else
                {
                    btnDownload.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void scmb_PersonRep_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Report_Download(DataTable dt,string ps_CompanyName)
        {
            try
            {
                DownloadCustomerComm objdwnldcomm = new DownloadCustomerComm(dt);
                objdwnldcomm._CompanyName = ps_CompanyName;

                objdwnldcomm.Show();

                //List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();
                //listDatatable.Add(new KeyValuePair<DataTable, string>(dt, "CustomerComm"));

                //DownloadReports report = new DownloadReports(@"CustomerCommunication.rdlc", "POE", false, listDatatable,null);
                //report.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (scmb_CompanyName.SelectedIndex > 0)
                {
                    DataTable dt = RecordGetFromDb();
                    Report_Download(dt,scmb_CompanyName.Text);
                }
                else
                btnDownload.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AddMethod_Click(object sender, EventArgs e)
        {
            try
            {
                ///if ShowDetails_CustomerMaster is already open then it close first 
                if (Application.OpenForms.OfType<CommunicationMethod>().Count() == 1)
                    Application.OpenForms.OfType<CommunicationMethod>().First().Close();

                CommunicationMethod
                    CMethod = new CommunicationMethod();
                clsValues.Instance.FullScreenOff = 1;
                CMethod.ShowDialog();
                CMethod.Focus();
                clsValues.Instance.FullScreenOff = 0;


                if (!bw_CommMethod.IsBusy)
                    bw_CommMethod.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AddAction_Click(object sender, EventArgs e)
        {
            try
            {
                ///if ShowDetails_CustomerMaster is already open then it close first 
                if (Application.OpenForms.OfType<PendingAction>().Count() == 1)
                    Application.OpenForms.OfType<PendingAction>().First().Close();

                PendingAction
                    action = new PendingAction();
                clsValues.Instance.FullScreenOff = 1;
                action.ShowDialog();
                action.Focus();
                clsValues.Instance.FullScreenOff = 0;


                if (!bw_Action.IsBusy)
                    bw_Action.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_Action_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ActionDataBase actndb = new ActionDataBase();
                e.Result = actndb.Search_Action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_Action_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                Action_Fill(e.Result as DataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Action_Fill(DataTable pdt_Action)
        {
            try
            {
                if (pdt_Action.Rows.Count > 0)
                {
                    const string DisplayMember = "ActionName";
                    const string ValueMember = "ActionId";

                    pdt_Action.AddSelectRow(0, 1);
                    scmb_pendingAction.DataSource = pdt_Action;
                    scmb_pendingAction.DisplayMember = DisplayMember;
                    scmb_pendingAction.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void bw_CommMethod_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CommMethodDataBase cmdb = new CommMethodDataBase();
                e.Result = cmdb.Search_CommMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_CommMethod_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Method_Fill(e.Result as DataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Method_Fill(DataTable pdt_Method)
        {
            try
            {
                if (pdt_Method.Rows.Count > 0)
                {
                    const string DisplayMember = "MethodName";
                    const string ValueMember = "CommMethodId";

                    pdt_Method.AddSelectRow(0,1);
                    scmb_CommMethod.DataSource = pdt_Method;
                    scmb_CommMethod.DisplayMember = DisplayMember;
                    scmb_CommMethod.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dtp_ActionDate_ValueChanged(object sender, EventArgs e)
        {
            b_ActionDate = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ///if ShowDetails_CustomerMaster is already open then it close first 
                if (Application.OpenForms.OfType<Product>().Count() == 1)
                    Application.OpenForms.OfType<Product>().First().Close();

                Product
                    productdb = new Product();
                clsValues.Instance.FullScreenOff = 1;
                productdb.ShowDialog();
                productdb.Focus();
                clsValues.Instance.FullScreenOff = 0;


                if (!bw_Product.IsBusy)
                    bw_Product.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_Product_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ProductDataBase productdb = new ProductDataBase();
                e.Result = productdb.Search_Product();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_Product_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Product_Fill(e.Result as DataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Product_Fill(DataTable pdt_Product)
        {
            try
            {
                if (pdt_Product.Rows.Count > 0)
                {
                    const string DisplayMember = "ProductName";
                    const string ValueMember = "ProductId";

                    pdt_Product.AddSelectRow(0, 1);
                    scmb_Product.DataSource = pdt_Product;
                    scmb_Product.DisplayMember = DisplayMember;
                    scmb_Product.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
