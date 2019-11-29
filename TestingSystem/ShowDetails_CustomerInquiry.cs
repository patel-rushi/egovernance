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

namespace TestingSystems
{
    public partial class ShowDetails_CustomerInquiry : Form
    {
        bool _DateTime = false;
        public ShowDetails_CustomerInquiry()
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        private void ShowDetails_CustomerInquiry_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            if (!bw_CompanyName.IsBusy)
                bw_CompanyName.RunWorkerAsync();

            if (!bw_PersonRep.IsBusy)
                bw_PersonRep.RunWorkerAsync();

            if (!bw_Product.IsBusy)
                bw_Product.RunWorkerAsync();

            fv_CurrentStatus();
            Fill_State(0);
            Fill_City(0);

            dtp_inquiryDateTo.Value = DateTime.Now;
            dtpInquiryDate.Value = DateTime.Now.AddMonths(-1);
        }
        private void fv_CurrentStatus()
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("Sno", typeof(string));
                dt.Columns.Add("Status", typeof(string));

                dt.Rows.Add("0", "--SELECT--");
                dt.Rows.Add("1", "Open");
                dt.Rows.Add("2", "Won");
                dt.Rows.Add("3", "Lost");

                cmbStatus.DataSource = dt;
                cmbStatus.DisplayMember = "Status";
                cmbStatus.ValueMember = "Sno";

                //scmb_Status.Items.Add("Open");
                //scmb_Status.Items.Add("Won");
                //scmb_Status.Items.Add("Lost");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message + Ex.StackTrace);
                ExceptionHandler.LogException(Ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchRecords()
        {
            try
            {
                DateTime? _dt = null;
                DateTime? _dtTo = null;
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();

                if ((cmbCompanyName.SelectedIndex>0) && (cmbCompanyName.SelectedValue != string.Empty) && (cmbCompanyName.SelectedValue != Helper.DropdownDefaultText.Select))
                    cidb.CustomerId = Guid.Parse(cmbCompanyName.SelectedValue.ToString());

                
                if ((cmbCity.SelectedIndex > 0) && (cmbCity.SelectedValue != string.Empty) && (cmbCity.SelectedValue != Helper.DropdownDefaultText.Select))
                    cidb.CityId = Convert.ToInt32(cmbCity.SelectedValue.ToString());

                if ((cmbState.SelectedIndex > 0) && (cmbState.SelectedValue != string.Empty) && (cmbState.SelectedValue != Helper.DropdownDefaultText.Select))
                    cidb.StateId = Convert.ToInt32(cmbState.SelectedValue.ToString());

                if((cmbStatus.Text != "--SELECT--") && (cmbStatus.Text != String.Empty))
                cidb.CurrentStatus = cmbStatus.Text.ToString();

                if ((scmb_PersonRep.Text != String.Empty) && (scmb_PersonRep.Text != "--SELECT--") && (Guid.Parse(scmb_PersonRep.SelectedValue.ToString()) != Guid.Empty))
                    cidb.PersonRep = scmb_PersonRep.Text.ToString();

                if ((scmb_Product.SelectedIndex > 0) && (scmb_Product.Text != String.Empty) )
                    cidb.Product = scmb_Product.Text.ToString();

                if (_DateTime == true)
                {
                    _dt = dtpInquiryDate.Value;
                    _dtTo = dtp_inquiryDateTo.Value;
                }
                else{
                    _dt = null;
                    _dtTo = null;
                }
                cidb.Date = _dt;
                cidb.Todate = _dtTo;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = cidb.Fetch_ALL_InquiryRecord();
             
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
                SearchRecords();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearPage()
        {
            try
            {


                dtp_inquiryDateTo.Value = DateTime.Now;
                dtpInquiryDate.Value = DateTime.Now.AddMonths(-1);
                dataGridView1.DataSource = null;
                cmbCompanyName.SelectedIndex = 0;
                cmbCity.SelectedIndex = 0;
                cmbState.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
                scmb_PersonRep.SelectedIndex = 0;
                _DateTime = false;
                scmb_Product.DataSource = null;

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
        private void btnClearFilter_Click(object sender, EventArgs e)

        {
            try
            {
                ClearPage();
                SearchRecords();
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
                        Guid InquiryId = Guid.Parse(selectrow.Cells["InquiryId"].Value.ToString());

                        if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                            //if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (Application.OpenForms.OfType<Customer_Inquiry>().Count() == 1)
                                    Application.OpenForms.OfType<Customer_Inquiry>().First().Close();

                                Customer_Inquiry obj = new Customer_Inquiry(InquiryId);
                                obj.MdiParent = this.ParentForm;
                                obj.Show();
                            }

                        }
                        else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                                cidb.InquiryId = InquiryId;
                                cidb.DeleteInquiry();
                                MessageBox.Show("Deleted.");
                            }
                        }
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
        private void Fill_State(int CityID)
        {
            const string DisplayMember = "State";
            const string ValueMember = "StateId";
            //values.CityID = CityID;
            CustomerInquiry_Database cidb = new CustomerInquiry_Database();
            cidb.CityId = CityID;
            DataTable dt = cidb.Fetch_State_fromCityID();

            if (dt != null && dt.Rows.Count > 0)
            {
                dt.AddSelectRow(0, 1);

                cmbState.DataSource = dt;
                cmbState.DisplayMember = DisplayMember;
                cmbState.ValueMember = ValueMember;
                cmbState.SelectedIndex = 0;

            }
            //if (dt.Rows.Count == 2)
            //{
            //    cmbState.SelectedIndex = 1;
            //    cmbState_SelectionChangeCommitted(cmbState, null);
            //}

        }

        private void Fill_City(int StateId)
        {
            //values.StateId = Convert.ToInt32(cmbState.SelectedValue);
            CustomerInquiry_Database cidb = new CustomerInquiry_Database();
            DataTable dt = cidb.FetchCity();
            const string DisplayMember = "City";
            const string ValueMember = "CityId";
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.AddSelectRow(1, 2);

                cmbCity.DataSource = dt;
                cmbCity.DisplayMember = DisplayMember;
                cmbCity.ValueMember = ValueMember;
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
                ClearPage();
                SearchRecords();
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
                    cmbCompanyName.DataSource = pdt_CompanyName;
                    cmbCompanyName.DisplayMember = DisplayMember;
                    cmbCompanyName.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpInquiryDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _DateTime = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                scmb_PersonRep.Visible = false;
                scmb_PersonRep.Enabled = false;

                //txt_PersonRep.Visible = true;
                //txt_PersonRep.Enabled = true;
                //txt_PersonRep.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.F5))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClearPage();
                        return true;
                    }
                }
                if (keyData == (Keys.Escape))
                {
                    cmbCompanyName.Focus();
                    return true;
                //    if (txt_PersonRep.Text == string.Empty)
                //    {
                //        scmb_PersonRep.Visible = true;
                //        scmb_PersonRep.Enabled = true;

                //        scmb_PersonRep.Focus();

                //        txt_PersonRep.Visible = false;
                //        txt_PersonRep.Enabled = false;

                //    }
                }
                //if (keyData == (Keys.Enter))
                //{
                //    if (txt_PersonRep.Text != string.Empty)
                //    {
                //        PersonRepDatabase prdb = new PersonRepDatabase();
                //        prdb.PersonName = txt_PersonRep.Text;
                //        if (prdb.Insert_PersonName() == 1)
                //        {
                //            scmb_PersonRep.Visible = true;
                //            scmb_PersonRep.Enabled = true;

                //            scmb_PersonRep.Focus();

                //            txt_PersonRep.Visible = false;
                //            txt_PersonRep.Enabled = false;

                //            scmb_PersonRep.DataSource = null;
                //            if (!bw_PersonRep.IsBusy)
                //                bw_PersonRep.RunWorkerAsync();

                //            txt_PersonRep.Text = string.Empty;
                //        }
                //    }
                //}
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

        private void dtp_inquiryDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _DateTime = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                if (cmb.Text == "")
                {
                    cmb.Text = Helper.DropdownDefaultText.Select;
                }
                if (cmb.SelectedValue != null)
                {
                    Fill_State(Convert.ToInt32(cmbCity.SelectedValue));
                    cmbState.SelectedIndex = 1;
                }
                else
                    cmb.Text = Helper.DropdownDefaultText.Select;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                if (cmb.Text == "")
                {
                    cmb.Text = Helper.DropdownDefaultText.Select;
                }
                if (cmb.SelectedValue != null)
                {
                    Fill_State(Convert.ToInt32(cmbCity.SelectedValue));
                    cmbState.SelectedIndex = 1;
                }
                else
                    cmb.Text = Helper.DropdownDefaultText.Select;
            }
            catch (Exception ex)
            {
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
