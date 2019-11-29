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
    public partial class Customer_Inquiry : Form
    {
        Guid CustomerId;
        Guid ContactId;
        Guid InquiryId;
        public Customer_Inquiry()
        {
            try
            {
                InitializeComponent();
                AutoFitForm.SetGroupBoxLoction(groupBox3);
                InquiryId = Guid.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        public Customer_Inquiry(Guid _InquiryId)
        {
            try
            {
                InitializeComponent();
                AutoFitForm.SetGroupBoxLoction(groupBox3);
                InquiryId = _InquiryId;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Customer_Inquiry_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);

            fv_InquirySource();
            fv_CurrentStatus();
            Fill_State(0);
            Fill_City(0);

            if (!bw_CompanyName.IsBusy)
                bw_CompanyName.RunWorkerAsync();

            if (!bw_PersonRep.IsBusy)
                bw_PersonRep.RunWorkerAsync();


            if (!bw_Product.IsBusy)
                bw_Product.RunWorkerAsync();

            scmb_CompanyName.Focus();
        }

        private void fv_InquirySource()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Sno", typeof(string));
                dt.Columns.Add("InquirySource", typeof(string));

                dt.Rows.Add("0", "--SELECT--");
                dt.Rows.Add("1", "IFEX");
                dt.Rows.Add("2", "Google");
                dt.Rows.Add("3", "Refrence");
                dt.Rows.Add("4", "Advertisement");
                dt.Rows.Add("5", "Google Ad.");
                dt.Rows.Add("6", "Event");

                scmb_InquirySource.DataSource = dt;
                scmb_InquirySource.DisplayMember = "InquirySource";
                scmb_InquirySource.ValueMember = "Sno";

                //scmb_InquirySource.Items.Add("IFEX");
                //scmb_InquirySource.Items.Add("Google");
                //scmb_InquirySource.Items.Add("Refrence");
                //scmb_InquirySource.Items.Add("Advertisement");
                //scmb_InquirySource.Items.Add("Google Ad.");
                //scmb_InquirySource.Items.Add("Event");
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                scmb_Status.DataSource = dt;
                scmb_Status.DisplayMember = "Status";
                scmb_Status.ValueMember = "Sno";

                //scmb_Status.Items.Add("Open");
                //scmb_Status.Items.Add("Won");
                //scmb_Status.Items.Add("Lost");
            }
            catch (Exception Ex)
            {
                ExceptionHandler.LogException(Ex);
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
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_CompanyName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CompanyName_Fill(e.Result as DataTable);
                if (InquiryId != Guid.Empty)
                {
                    btnSave.Text = "Update";
                    FillUpdates();
                }
                else
                {
                    btnSave.Text = "Save";
                }

            }
            catch (Exception ex)
            {
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

                    scmb_CompanyName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillUpdates()
        {
            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                cidb.InquiryId = InquiryId;
                DataTable dt = cidb.Fetch_ALL_InquiryRecord_For_FillUpdate();
                scmb_CompanyName.SelectedValue = dt.Rows[0]["CustomerId"].ToString();
                PersonNameGet();
                scmb_Person.SelectedValue = dt.Rows[0]["ContactId"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                cmbCity.Text = dt.Rows[0]["City"].ToString();
                cmbState.Text = dt.Rows[0]["State"].ToString();
                dtp_InquiryDate.Value = Convert.ToDateTime(dt.Rows[0]["InquiryDate"].ToString());
                scmb_InquirySource.Text = dt.Rows[0]["InquirySource"].ToString();
                txtRefrence.Text = dt.Rows[0]["Refrence"].ToString();
                scmb_Product.Text = dt.Rows[0]["Representative_Company"].ToString();
                scmb_PersonRep.Text = dt.Rows[0]["RepresentativePerson"].ToString();
                scmb_Status.Text = dt.Rows[0]["Current_Status"].ToString();
                dtp_WLDate.Value = Convert.ToDateTime(dt.Rows[0]["Inquiry_Loss_Win_Date"].ToString());
                txtIfLoss.Text = dt.Rows[0]["Reason_For_Lost"].ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void scmb_CompanyName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PersonNameGet();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PersonNameGet()
        {
            try
            {
                
                if ( (scmb_CompanyName.SelectedIndex > 0) && (scmb_CompanyName.SelectedText.ToString() != Helper.DropdownDefaultText.Select) && (scmb_CompanyName.SelectedValue != string.Empty) )
                {
                    CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());

                    if(CustomerId != Guid.Empty)
                    Fetch_Detail_For_CompanyName(CustomerId);
                }
                else
                {
                    CustomerId = Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
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
                    dt.AddSelectRow(1,0);
                    scmb_Person.DataSource = dt;
                    scmb_Person.DisplayMember = DisplayMember;
                    scmb_Person.ValueMember = ValueMember;

                    txtEmail.Enabled = true;
                    txtPhone.Enabled = true;
                }
                else
                {
                    txtEmail.Enabled = false;
                    txtPhone.Enabled = false;
                    scmb_Person.DataSource = null;
                    clearCustomerdetail();
                }

                DataTable dt2 = cidb.Fetch_CustomerDetail2();
                if (dt2.Rows.Count > 0)
                {
                    cmbCity.Text = dt2.Rows[0]["City"].ToString();
                    cmbState.Text = dt2.Rows[0]["State"].ToString();
                }
                if (scmb_Person.Items.Count > 0)
                {
                    scmb_Person.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveButton();
           
        }

        private void SaveButton()
        {
            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();

                #region Comapny Name
                //if (scmb_CompanyName.Enabled == true)
                {
                    if ((scmb_CompanyName.SelectedIndex > 0) &&(scmb_CompanyName.Text != string.Empty) && (scmb_CompanyName.Text != "--SELECT--"))
                    {
                        CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());
                        cidb.CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Select Company Name");
                        scmb_CompanyName.Focus();
                        return;
                    }
                }
                //else if ((scmb_CompanyName.Enabled == false) && (txtCompanyName.Text != string.Empty))
                //{
                //    CustomerId = Guid.Empty;
                //    cidb.CompanyName = txtCompanyName.Text;
                //}
                //else
                //{
                //    Console.WriteLine("Insert Company Name");
                //    txtCompanyName.Focus();
                //    return;
                //}
                #endregion

               
                #region Person name
                //if (scmb_Person.Enabled == true)
                //{
                    if ((scmb_Person.SelectedIndex>0) && (scmb_Person.Text != string.Empty) && (scmb_Person.Text != "--SELECT--"))
                    {
                        ContactId = Guid.Parse(scmb_Person.SelectedValue.ToString());
                        cidb.ContactId = Guid.Parse(scmb_Person.SelectedValue.ToString());
                    }
                //    else
                //    {
                //        Console.WriteLine("Select Person Name");
                //        scmb_Person.Focus();
                //        return;
                //    }
                //}
                //else if ((scmb_Person.Enabled == false) && (txtPersonName.Text != string.Empty))
                //{
                //    ContactId = Guid.Empty;
                //    cidb.PersonName = txtPersonName.Text;
                //}
                //else
                //{
                //    Console.WriteLine("Insert Person Name");
                //    txtPersonName.Focus();
                //    return;
                //}
                #endregion

                #region Email
                if ((txtEmail.Text != string.Empty) && (txtEmail.Text != "--SELECT--"))
                {
                    cidb.Email = txtEmail.Text;
                }
                #endregion

                #region Contact no
                if ((txtPhone.Text != string.Empty) && (txtPhone.Text != "--SELECT--"))
                {
                    cidb.ContentNo = txtPhone.Text;
                }
                #endregion
                if (scmb_Product.SelectedIndex <= 0)
                {
                    MessageBox.Show("Select product ");
                    return;
                }
                #region City
                if ((cmbCity.SelectedIndex>0) && (cmbCity.SelectedValue != string.Empty) && (cmbCity.SelectedValue != "--SELECT--"))
                {
                    cidb.City = cmbCity.SelectedValue.ToString();
                }
                #endregion

                #region State
                if ((cmbState.SelectedIndex>0) && (cmbState.Text != string.Empty) && (cmbState.Text != "--SELECT--"))
                {
                    cidb.State = cmbState.Text;
                }
                #endregion

                #region Date
                cidb.Date = dtp_InquiryDate.Value;
                cidb.LossWonDate = dtp_WLDate.Value;
                #endregion

                #region Inquiry Source
                if ((scmb_InquirySource.Text != string.Empty) && (scmb_InquirySource.Text != "--SELECT--"))
                {
                    cidb.InquirySource = scmb_InquirySource.Text;
                }
                else
                {
                    Console.WriteLine("Please Select the InquirySource ");
                    scmb_InquirySource.Focus();
                    return;
                }
                #endregion

                #region Refrence
                if (scmb_InquirySource.Text == "Refrence")
                {
                    if (txtRefrence.Text != String.Empty)
                    {
                        cidb.Refrence = txtRefrence.Text;
                    }
                    else
                    {
                        Console.WriteLine("Please insert a refrence");
                        txtRefrence.Focus();
                        return;
                    }
                }
                #endregion

                #region CompanyRepresentative
                if((scmb_Product.SelectedIndex > 0) && (scmb_Product.Text != String.Empty))
                {
                    cidb.Product = scmb_Product.Text;
                }
                #endregion

                #region Person Representative
                if ((scmb_PersonRep.Text != String.Empty) && (scmb_PersonRep.Text != "--SELECT--") && (Guid.Parse(scmb_PersonRep.SelectedValue.ToString()) != Guid.Empty))
                {
                    cidb.PersonRep = scmb_PersonRep.Text;
                }
                else
                {
                    Console.WriteLine(" select Rep name");
                    scmb_PersonRep.Focus();
                    return;
                }
                #endregion

                #region CurrentStatus
                if ((scmb_Status.Text != String.Empty) && (scmb_Status.Text != "-SELECT--"))
                {
                    cidb.CurrentStatus = scmb_Status.Text;
                }
                else
                {
                    Console.WriteLine("Please insert status");
                    scmb_Status.Focus();
                    return;
                }
                #endregion

                #region if loss
                if (scmb_Status.Text == "Lost")
                {
                    if (txtIfLoss.Text != string.Empty)
                    {
                        cidb.ifLost = txtIfLoss.Text;
                    }
                }
                #endregion

                if (CustomerId != Guid.Empty)
                {
                    //Update query for company name 
                    //if (ContactId != Guid.Empty)
                    {
                        if (btnSave.Text == "Save")
                        {
                            cidb.CustomerId = Guid.Parse(scmb_CompanyName.SelectedValue.ToString());
                            if (cidb.Update_CustomerInquiry() == 1)
                            {
                                clearPage();
                                MessageBox.Show("Saved");
                            }
                        }
                        else if (btnSave.Text == "Update")
                        {
                            cidb.InquiryId = InquiryId;
                            if (cidb.UpdateALL() == 1)
                            {
                                clearPage();
                                MessageBox.Show("Updated");
                                btnSave.Text = "Save";
                            }
                        }
                    }
                    //else if (ContactId == Guid.Empty)
                    //{
                    //    if (cidb.Update_AND_Insert_CustomerInquiry() == 1)
                    //    {
                    //        clearPage();
                    //        MessageBox.Show("Saved");
                    //    }
                    //}

                }
                else
                {
                    //if (cidb.INSERT_CustomerInquiry() == 1)
                    //{
                    //    clearPage();
                    //    MessageBox.Show("Saved");
                    //}
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearPage();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clearPage()
        {
            try
            {
                scmb_Person.DataSource = null;
                scmb_CompanyName.SelectedIndex = 0;
                scmb_CompanyName.Focus();
                clearCustomerdetail();
                scmb_InquirySource.SelectedIndex = 0;
                scmb_PersonRep.Text = string.Empty;
                scmb_Status.SelectedIndex = 0;
                txtIfLoss.Text = string.Empty;
                txtRefrence.Text = string.Empty;
                btnSave.Text = "Save";
                scmb_Product.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void clearCustomerdetail()
        {
            try 
            {
                txtCompanyName.Text = string.Empty;
                txtPersonName.Text = string.Empty;
                cmbCity.SelectedValue = 0;
                cmbState.Text = string.Empty;
                dtp_InquiryDate.Value = DateTime.Now;
                
                
                scmb_Person.Text = string.Empty;
                //btnAddPerson.Visible = true;
                //txtPersonName.Visible = false;
                //scmb_Person.Enabled = true;

                scmb_CompanyName.Enabled = true;
                txtCompanyName.Visible = false;
                btnAddCompanyName.Visible = true;

                txtEmail.Text = string.Empty;
                txtPhone.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void scmb_Person_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CustomerDetailGet();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CustomerDetailGet()
        {
            try
            {
                if ( (scmb_Person.SelectedIndex>=0) && (scmb_Person.SelectedValue != string.Empty) && (scmb_Person.SelectedValue.ToString() != Helper.DropdownDefaultText.Select))
                {
                    ContactId = Guid.Parse(scmb_Person.SelectedValue.ToString());
                    CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                    cidb.CustomerId = CustomerId;
                    cidb.ContactId = Guid.Parse(scmb_Person.SelectedValue.ToString());
                    DataTable dt = cidb.Fetch_CustomerDetail();

                    if (dt.Rows.Count > 0)
                    {
                        txtEmail.Text = dt.Rows[0]["Email"].ToString();
                        txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                    }
                    else
                    {
                        ContactId = Guid.Empty;
                        clearCustomerdetail();
                    }
                }
                else
                {
                    ContactId = Guid.Empty;
                    clearCustomerdetail();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fv_InquirySourceIfRefrence()
        {
            try
            {
                if (scmb_InquirySource.Text == "Refrence")
                {
                    txtRefrence.Visible = true;
                    lbl_refrence.Visible = true;
                }
                else
                {
                    txtRefrence.Visible = false;
                    lbl_refrence.Visible = false;
                    txtRefrence.Text = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fv_IfLost()
        {
            try 
            {
                if (scmb_Status.Text == "Lost")
                {
                    txtIfLoss.Enabled = true;
                }
                else {
                    txtIfLoss.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                if (Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().Count() == 1)
                    Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().First().Close();

                ShowDetails_CustomerInquiry

                    clientregisterform = new ShowDetails_CustomerInquiry();
                clientregisterform.MdiParent = this.ParentForm;
              
                clientregisterform.Show();
                clientregisterform.Focus();

                clearPage();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                _CustomerMaster();
                #region
                //scmb_Person.Enabled = false;
                //txtPersonName.Visible = true;
                //btnAddPerson.Visible = false;
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCompanyName_Click(object sender, EventArgs e)
        {
            try
            {
                _CustomerMaster();
                               
                #region
                //scmb_CompanyName.Enabled = false;
                //txtCompanyName.Visible = true;
                //btnAddCompanyName.Visible = false;

                //scmb_Person.Enabled = false;
                //txtPersonName.Visible = true;
                //btnAddPerson.Visible = false;
                #endregion
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _CustomerMaster()
        {
            try
            {
                //if Customer Master is already open then it close first 
                if (Application.OpenForms.OfType<CustomerMaster>().Count() == 1)
                    Application.OpenForms.OfType<CustomerMaster>().First().Close();

                CustomerMaster customerMaster = new CustomerMaster(new CustomerSupplierInputParameters(Enums.FormMode.Insert));
                clsValues.Instance.FullScreenOff = 1;
                customerMaster.ShowDialog();
                customerMaster.Focus();
                clsValues.Instance.FullScreenOff = 0;

                scmb_CompanyName.DataSource = null;
             
                if (!bw_CompanyName.IsBusy)
                    bw_CompanyName.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void scmb_InquirySource_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void scmb_Status_SelectionChangeCommitted(object sender, EventArgs e)
        {
           

        }

        private void scmb_InquirySource_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fv_InquirySourceIfRefrence();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void scmb_Status_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fv_IfLost();
            }
            catch (Exception ex)
            {
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


            }
            if (dt.Rows.Count == 2)
            {
                cmbState.SelectedIndex = 1;
                cmbState_SelectionChangeCommitted(cmbState, null);
            }

        }

        private void Fill_City(int StateId)
        {
            try
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
            catch (Exception ex)
            {
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
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    cmbCity_SelectionChangeCommitted(sender, e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbState_SelectionChangeCommitted(object sender, EventArgs e)
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
                   // Fill_Country(Convert.ToInt32(cmbState.SelectedValue));
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.AllowIntegerOnly();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRefrence_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
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
        #region ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveButton();
                    }
                }
                if (keyData == (Keys.F5))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clearPage();
                        return true;
                    }
                }
                if (keyData == (Keys.Escape))
                {
                    scmb_CompanyName.Focus();
                    //if (txt_PersonRep.Text == string.Empty)
                    //{
                    //    scmb_PersonRep.Visible = true;
                    //    scmb_PersonRep.Enabled = true;

                    //    scmb_PersonRep.Focus();

                    //    txt_PersonRep.Visible = false;
                    //    txt_PersonRep.Enabled = false;

                    //    //if (txtPersonName.Text == string.Empty)
                    //    //{
                    //    //    scmb_Person.Enabled = true;
                    //    //    txtPersonName.Visible = false;
                    //    //    btnAddPerson.Visible = true;
                    //    //}
                    //    if (txtCompanyName.Text == string.Empty)
                    //    {
                    //        scmb_CompanyName.Enabled = true;
                    //        txtCompanyName.Visible = false;
                    //        btnAddCompanyName.Visible = true;
                    //    }
                    //}
                }
                if (keyData == (Keys.Enter))
                {
                    //if (txt_PersonRep.Text != string.Empty)
                    //{
                    //    PersonRepDatabase prdb = new PersonRepDatabase();
                    //    prdb.PersonName = txt_PersonRep.Text;
                    //    if (prdb.Insert_PersonName() == 1)
                    //    {
                    //        scmb_PersonRep.Visible = true;
                    //        scmb_PersonRep.Enabled = true;

                    //        scmb_PersonRep.Focus();

                    //        txt_PersonRep.Visible = false;
                    //        txt_PersonRep.Enabled = false;

                    //        scmb_PersonRep.DataSource = null;
                    //        if (!bw_PersonRep.IsBusy)
                    //            bw_PersonRep.RunWorkerAsync();

                    //        txt_PersonRep.Text = string.Empty;
                    //    }
                    //}
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void scmb_Person_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                CustomerDetailGet();
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

        private void btn_Product_Click(object sender, EventArgs e)
        {
            try
            {
                ////if ShowDetails_CustomerMaster is already open then it close first 
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

    }
}
