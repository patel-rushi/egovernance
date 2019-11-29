using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
using TestingSystems.App_Data;
using TestingSystems.Helpers;
using TestingSystems;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystems
{
    public partial class CustomerMaster : Form
    {  
        clsCustomerMaster obj_CustomerMaster = new clsCustomerMaster();
        private DataTable dtCustomerType;
        private DataTable dtCustomerCategory;
        public Int32 FullScreenOff = 0;        
        Int32 TDCId = 0;
        private int RawId;
        private CustomerSupplierInputParameters _CustomerSupplierInputParameters;

        public CustomerMaster(CustomerSupplierInputParameters CustomerSupplierInputParameters)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;

            if (FullScreenOff != 1)
            {
                AutoFitForm.SetGroupBoxLoction(this.groupBoxMain);
            }

            if (FullScreenOff == 1)
            {
                btnView.Visible = false;
            }
            _CustomerSupplierInputParameters = CustomerSupplierInputParameters;
        }
        private void FrmCustomerMaster_Load(object sender, EventArgs e)
        {
            //AutoFitForm.SetFormToMaximize(this);
            //FillCity();

            FullScreenOff = clsValues.Instance.FullScreenOff;

            if (FullScreenOff != 1)
            {
                AutoFitForm.SetFormToMaximize(this);
                //AutoFitForm.SetGroupBoxLoction(this.groupBoxMain);
            }
            if (FullScreenOff == 1)
            {
                btnView.Visible = false;
            }

            txtCustomerName.Focus();
            dgvBankDetails.AutoGenerateColumns = false;
            AssignLabels();
            dgvTestingCharges.AutoGenerateColumns = false;
            dgvTDCDetail.AutoGenerateColumns = false;

         
            if (_CustomerSupplierInputParameters.FormMode == Enums.FormMode.Insert)
            {
                if (!bwCustomerType.IsBusy)
                    bwCustomerType.RunWorkerAsync();
                if (!bwCustomerCategory.IsBusy)
                    bwCustomerCategory.RunWorkerAsync();
                if (!bwCustomerGroup.IsBusy)
                    bwCustomerGroup.RunWorkerAsync();
                if (!bwBankName.IsBusy)
                    bwBankName.RunWorkerAsync();
            }
            btnView.Text = Helper.ButtonCaptions.View;
            //FillCity();
            Fill_Country(0);
            Fill_State(0);
            Fill_City(0);
            Fill_CityBank(0);
            if (!bwSpecialRequirement.IsBusy)
                bwSpecialRequirement.RunWorkerAsync();
            if (!bwGrade.IsBusy)
                bwGrade.RunWorkerAsync();
            FetchUnit();

        }

        private void CustomerMaster_Activated(object sender, EventArgs e)
        {
            //FillCity();
            //if (!bwCustomerType.IsBusy)
            //    bwCustomerType.RunWorkerAsync();
            //if (!bwCustomerCategory.IsBusy)
            //    bwCustomerCategory.RunWorkerAsync();




            if (_CustomerSupplierInputParameters.FormMode == Enums.FormMode.Edit)
            {
                btnSave.Text = Helper.ButtonCaptions.Update;
                StartOperation();
            }
        }
        
        #region  Method For Clear Button

        private void CLR()
        {

            txtVendorCode.Text = string.Empty;

            txtCustomerCode.Text = string.Empty;

            cmbCategory.Text = Helper.DropdownDefaultText.Select;

            cmbType.Text = Helper.DropdownDefaultText.Select;

            cmbCustomerGroup.Text = Helper.DropdownDefaultText.Select;



            cmbCity.Text = Helper.DropdownDefaultText.Select;
            cmbState.DataSource = null;
            cmbState.Text = Helper.DropdownDefaultText.Select;
            cmbCountry.DataSource = null;
            cmbCountry.Text = Helper.DropdownDefaultText.Select;

            FillCity();
            dgvBankDetails.DataSource = null;




            cmbType.Enabled = true;

            cmbCategory.Enabled = true;

            cmbCustomerGroup.Enabled = true;

            txtCustomerName.Clear();

            if (!bwCustomerType.IsBusy)
                bwCustomerType.RunWorkerAsync();
            if (!bwCustomerCategory.IsBusy)
                bwCustomerCategory.RunWorkerAsync();
            if (!bwCustomerGroup.IsBusy)
                bwCustomerGroup.RunWorkerAsync();


            btnSave.Text = Helper.ButtonCaptions.Save;

            dgvAddress.DataSource = null;

            dgvContact.DataSource = null;
            ClearBankDetails();
            foreach (Control a in tabAddress.Controls)             // Clear Address 
            {
                if (a is TextBox)
                {
                    a.Text = string.Empty;
                }
            }

            foreach (Control a in groupBoxCustomer.Controls)            // Clear Customer 
            {
                if (a is TextBox)
                {
                    a.Text = string.Empty;
                }
            }

            foreach (Control a in tabContact.Controls)             // Clear Contact 
            {
                if (a is TextBox)
                {
                    a.Text = string.Empty;
                }
            }

            foreach (Control a in groupBoxFinance.Controls)             // Clear Finance 
            {
                if (a is TextBox)
                {
                    a.Text = string.Empty;
                }
            }
            _CustomerSupplierInputParameters = new CustomerSupplierInputParameters(Enums.FormMode.Insert);
        }

        #endregion

        #region Method For Fill combobox

        private void Fill_Country(int StateID)
        {
            clsCityState citystate = new clsCityState();
            const string DisplayMember = "CountryName";
            const string ValueMember = "CountryID";
            citystate.StateId = StateID;
            DataTable dt = citystate.Fetch_CountryByState();

            if (dt != null && dt.Rows.Count > 0)
            {
                dt.AddSelectRow(0, 1);

                cmbCountry.DataSource = dt;
                cmbCountry.DisplayMember = DisplayMember;
                cmbCountry.ValueMember = ValueMember;

            }
            if (dt.Rows.Count == 2)
            {
                cmbCountry.SelectedIndex = 1;
            }
        }

        private void Fill_State(int CityID)
        {
            const string DisplayMember = "State";
            const string ValueMember = "StateId";
            //values.CityID = CityID;
            clsCityState citystate = new clsCityState();
            citystate.CityId = CityID;
            DataTable dt = citystate.Fetch_State_fromCityID();

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
            //values.StateId = Convert.ToInt32(cmbState.SelectedValue);
            clsCityState citystate = new clsCityState();
            DataTable dt = citystate.FetchCity();
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

        #endregion

        #region Fill City

        private void cmbState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {
                Fill_Country(Convert.ToInt32(cmbState.SelectedValue));
            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;


        }

        #endregion

        #region Code for Update Combobox Items


        #endregion

        #region General Function

        private void Fill_CityBank(int StateId)
        {
            try
            {
                clsCityState citystate = new clsCityState();
                DataTable dtCity = citystate.FetchCity();
                const string DisplayMember = "City";
                const string ValueMember = "CityId";
                if (dtCity != null && dtCity.Rows.Count > 0)
                {
                    dtCity.AddSelectRow(1, 2);

                    cmbCityBank.DataSource = dtCity;
                    cmbCityBank.DisplayMember = DisplayMember;
                    cmbCityBank.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCity()
        {
            //values.StateId = Convert.ToInt32(cmbState.SelectedValue);
            clsCityState citystate = new clsCityState();
            DataTable dt = citystate.Fetch_City_All();
            const string DisplayMember = "City";
            const string ValueMember = "CityId";
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.AddSelectRow(0, 1);

                cmbCity.DataSource = dt;
                cmbCity.DisplayMember = DisplayMember;
                cmbCity.ValueMember = ValueMember;
            }
        }

        private void StartOperation()
        {

            GetValue();

        }

        private void ClearBankDetails()
        {
            try
            {
                if (cmbBankName.Items.Count > 0)
                    cmbBankName.SelectedIndex = 0;
                txtBranchName.Clear();
                txtAccNo.Clear();
                txtIFSCNo.Clear();
                txtMICRCode.Clear();
                if (!bwBankName.IsBusy) bwBankName.RunWorkerAsync();
                if (cmbCityBank.Items.Count > 0)
                    cmbCityBank.SelectedIndex = 0;
                if (cmbStateBank.Items.Count > 0)
                    cmbStateBank.SelectedIndex = 0;
                if (cmbCountryBank.Items.Count > 0)
                    cmbCountryBank.SelectedIndex = 0;
                btnadd.Text = Helper.ButtonCaptions.Add;
                cmbBankName.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DataClear()
        {
            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CLR();                                           //Clear All Controls from Form
            }

            btnAddContact.Text = Helper.ButtonCaptions.Add;
            btnAddress.Text = Helper.ButtonCaptions.Add;
        }

        public void PerformRefresh()
        {
            cmbState.DataSource = null;
            cmbState.Text = Helper.DropdownDefaultText.Select;
            cmbCountry.DataSource = null;
            cmbCountry.Text = Helper.DropdownDefaultText.Select;
            FillCity();
            Fill_Country(0);
            Fill_State(0);
            Fill_City(0);
            Fill_CityBank(0);

        }

        private void AssignLabels()
        {
            clsCustomLabelText objCustomLabelText = new clsCustomLabelText();
            DataTable dsLabels = objCustomLabelText.Fetch_CustomLabelText();
            if (dsLabels.Rows.Count > 0)
            {
                lblTaxNo1.Text = dsLabels.Rows[0]["TaxNo1"].ToString();
                lblTaxNo2.Text = dsLabels.Rows[0]["TaxNo2"].ToString();
                lblTaxNo3.Text = dsLabels.Rows[0]["TaxNo3"].ToString();
                lblTaxNo4.Text = dsLabels.Rows[0]["TaxNo4"].ToString();
                lblTaxNo5.Text = dsLabels.Rows[0]["TaxNo5"].ToString();
            }
        }

        private DataTable GetGradeData()
        {
            try
            {
                clsDieMaster objDieMaster = new clsDieMaster();
                DataTable dtFetchGradeData = objDieMaster.Fetch_Metal_Name_With_Filters();
                return dtFetchGradeData;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        private void FillGradeData(DataTable dtFetchGradeData)
        {
            try
            {
                if (dtFetchGradeData != null)
                {
                    dtFetchGradeData.AddSelectRow(0, 1);

                    cmbGrade.DataSource = dtFetchGradeData;

                    cmbGrade.ValueMember = "MetalID";

                    cmbGrade.DisplayMember = "MetalName";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTDCDetail()
        {
            try
            {
                if (cmbGrade.Items.Count > 0)
                    cmbGrade.SelectedValue = 0;
                txtTDCNo.Text = string.Empty;
                lblTDFFilePath.Text = string.Empty;
                lblTDCFileName.Text = string.Empty;

                cmbGrade.Enabled = true;
                btnaddTDCDetail.Text = Helper.ButtonCaptions.Add;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditAddress(int Rowindex, DataGridViewCellEventArgs e)
        {
            btnAddress.Text = Helper.ButtonCaptions.Update;
            txtStreet.Focus();
            id = Rowindex;
            if (e.RowIndex >= 0)
            {
                if (txtStreet.Text == "" && txtArea.Text == "" && (cmbState.SelectedValue == null || cmbState.SelectedValue.ToString() == Helper.DropdownDefaultText.Select) || (Convert.ToInt32(cmbCity.SelectedValue.ToString()) == 0 || cmbCity.SelectedValue.ToString() == Helper.DropdownDefaultText.Select))
                {
                    txtStreet.DataBindings.Add("text", dgvAddress.DataSource, "Street");
                    txtArea.DataBindings.Add("text", dgvAddress.DataSource, "Area");
                    FillCity();
                    //Fill_City(Convert.ToInt32(cmbState.SelectedValue));
                    cmbCity.DataBindings.Add("text", dgvAddress.DataSource, "City");

                    Fill_State(Convert.ToInt32(cmbCity.SelectedValue));
                    cmbState.DataBindings.Add("text", dgvAddress.DataSource, "State");
                    Fill_Country(Convert.ToInt32(cmbState.SelectedValue));
                    cmbCountry.DataBindings.Add("SelectedValue", dgvAddress.DataSource, "CountryId");

                    txtPinCode.DataBindings.Add("text", dgvAddress.DataSource, "PinCode");

                    txtStreet.DataBindings.Clear();
                    txtArea.DataBindings.Clear();
                    cmbState.DataBindings.Clear();
                    cmbCity.DataBindings.Clear();
                    cmbCountry.DataBindings.Clear();
                    txtPinCode.DataBindings.Clear();


                    // dgvAddress.Rows.Remove(dgvAddress.Rows[e.RowIndex]);
                }
                else
                {
                    const string error = "Cancel your previous selection.";
                    System.Windows.Forms.MessageBox.Show(error, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean DeleteAddress(int Rowindex)
        {
            try
            {
                id = Rowindex;
                dgvAddress.Rows.RemoveAt(id);
                return true;
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void EditContact(int Rowindex, DataGridViewCellEventArgs e)
        {

            id = Rowindex;
            btnAddContact.Text = Helper.ButtonCaptions.Update;
            txtPersonName.Focus();
            if (e.RowIndex >= 0)
            {
                if (txtPersonName.Text == "" && txtDesignation.Text == "" && txtDesignation.Text == "" && txtEmail.Text == "" && txtContact.Text == "")
                {

                    txtPersonName.DataBindings.Add("text", dgvContact.DataSource, "PersonName");
                    txtDepartment.DataBindings.Add("text", dgvContact.DataSource, "Department");
                    txtDesignation.DataBindings.Add("text", dgvContact.DataSource, "Designation");
                    txtEmail.DataBindings.Add("text", dgvContact.DataSource, "Email");
                    txtContact.DataBindings.Add("text", dgvContact.DataSource, "ContactNo");

                    txtPersonName.DataBindings.Clear();
                    txtDepartment.DataBindings.Clear();
                    txtDesignation.DataBindings.Clear();
                    txtEmail.DataBindings.Clear();
                    txtContact.DataBindings.Clear();

                    // dgvContact.Rows.Remove(dgvContact.Rows[e.RowIndex]);
                }
                else
                {
                    const string error = "Cancel your previous selection.";
                    System.Windows.Forms.MessageBox.Show(error, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean DeleteContact(int Rowindex)
        {
            try
            {
                id = Rowindex;
                dgvContact.Rows.RemoveAt(id);
                return true;
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Fill_StateBank(int CityID)
        {
            try
            {
                const string DisplayMember = "State";
                const string ValueMember = "StateId";
                //values.CityID = CityID;
                clsCityState citystate = new clsCityState();
                citystate.CityId = CityID;
                DataTable dtStateBank = citystate.Fetch_State_fromCityID();

                if (dtStateBank != null && dtStateBank.Rows.Count > 0)
                {
                    dtStateBank.AddSelectRow(0, 1);

                    cmbStateBank.DataSource = dtStateBank;
                    cmbStateBank.DisplayMember = DisplayMember;
                    cmbStateBank.ValueMember = ValueMember;


                }
                if (dtStateBank.Rows.Count == 2)
                {
                    cmbStateBank.SelectedIndex = 1;
                    cmbStateBank_SelectionChangeCommitted(cmbStateBank, null);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fill_CountryBank(int StateID)
        {
            try
            {
                clsCityState citystate = new clsCityState();
                const string DisplayMember = "CountryName";
                const string ValueMember = "CountryID";
                // values.StateId = StateID;
                citystate.StateId = StateID;
                DataTable dtCountry = citystate.Fetch_CountryByState();

                if (dtCountry != null && dtCountry.Rows.Count > 0)
                {
                    dtCountry.AddSelectRow(0, 1);

                    cmbCountryBank.DataSource = dtCountry;
                    cmbCountryBank.DisplayMember = DisplayMember;
                    cmbCountryBank.ValueMember = ValueMember;

                }
                if (dtCountry.Rows.Count == 2)
                {
                    cmbCountryBank.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Method GetValue

        private void GetValue()
        {
            try
            {
                DataTable dt_values = new DataTable();
                const string cus_flag = "C";
                obj_CustomerMaster.Customer_Id = _CustomerSupplierInputParameters.CustomerId;
                obj_CustomerMaster.Customer_flag = cus_flag;


                dt_values = obj_CustomerMaster.Fetch_Customer_Details();

                DataTable dtContact = obj_CustomerMaster.Fetch_Customer_Contact_Details();

                dgvContact.DataSource = dtContact;

                DataTable dtBank = obj_CustomerMaster.Fetch_Customer_Bank_Details();
                dgvBankDetails.DataSource = dtBank;

                DataTable dtAddress = obj_CustomerMaster.Fetch_Customer_Address();

                dgvAddress.DataSource = dtAddress;

                try
                {
                    dgvAddress.Columns["CityId"].Visible = false;                    
                    dgvAddress.Columns["CountryId"].Visible = false;
                    dgvAddress.Columns["StateCode"].Visible = false;
                    dgvAddress.Columns["CountryName"].Visible = false;

                }
                catch
                { }

                txtCustomerName.Text = dt_values.Rows[0]["CustomerName"].ToString();

                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                dtCustomerType = customerTypeCategoryGroupMaster.Fetch_Customer_Type_Details();
                dtCustomerType.AddSelectRow(0, 2);
                cmbType.DataSource = dtCustomerType;
                cmbType.DisplayMember = "TypeName";
                cmbType.ValueMember = "CustomerTypeId";

                if (dt_values.Rows[0]["CustomerTypeId"].ToString() != "")
                {
                    cmbType.SelectedValue = (dt_values.Rows[0]["CustomerTypeId"].ToString());
                }

                dtCustomerCategory = customerTypeCategoryGroupMaster.Fetch_Customer_Category_Details();
                dtCustomerCategory.AddSelectRow(0, 2);
                cmbCategory.DataSource = dtCustomerCategory;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CustomerCategoryId";

                if (dt_values.Rows[0]["CustomerCategoryId"].ToString() != "")
                {
                    cmbCategory.SelectedValue = (dt_values.Rows[0]["CustomerCategoryId"].ToString());
                }

                DataTable dtCustomerGroup = customerTypeCategoryGroupMaster.Fetch_Customer_Group_Details();
                dtCustomerGroup.AddSelectRow(0, 2);
                cmbCustomerGroup.DataSource = dtCustomerGroup;
                cmbCustomerGroup.DisplayMember = "GroupName";
                cmbCustomerGroup.ValueMember = "CustomerGroupId";

                if (dt_values.Rows[0]["CustomerGroupId"].ToString() != "")
                {
                    cmbCustomerGroup.SelectedValue = (dt_values.Rows[0]["CustomerGroupId"].ToString());
                }

                txtTaxNo1.Text = dt_values.Rows[0]["TaxNo1"].ToString();

                txtTaxNo2.Text = dt_values.Rows[0]["TaxNo2"].ToString();

                txtTaxNo3.Text = dt_values.Rows[0]["TaxNo3"].ToString();

                txtTaxNo4.Text = dt_values.Rows[0]["TaxNo4"].ToString();

                txtTaxNo5.Text = dt_values.Rows[0]["TaxNo5"].ToString();

                txtRange.Text = dt_values.Rows[0]["Range"].ToString();

                txtDivision.Text = dt_values.Rows[0]["Division"].ToString();

                txtCommissionrate.Text = dt_values.Rows[0]["Commissionerate"].ToString();

                txtVendorCode.Text = dt_values.Rows[0]["VendorCode"].ToString();

                txtCustomerCode.Text = dt_values.Rows[0]["CustomerCode"].ToString();

                txtGSTNo.Text = dt_values.Rows[0]["GSTNo"].ToString();

                txtPaymentTerms.Text = dt_values.Rows[0]["PaymentTerms"].ToString();

                DataTable dtFetchTestingCharges = obj_CustomerMaster.FetchTestingCharges();

                dgvTestingCharges.DataSource = dtFetchTestingCharges;

                DataTable dtFetchTDCDetail = obj_CustomerMaster.Fetch_TDDetail();

                for (int j = 0; j < dtFetchTDCDetail.Rows.Count; j++)
                {
                    DataTable dtTDCDetail = new DataTable();
                    obj_CustomerMaster.TDCId = Guid.Parse(dtFetchTDCDetail.Rows[j]["TDCId"].ToString());

                    DataTable dtFetchFile = obj_CustomerMaster.Fetch_FileNameByTDC();
                    if (!dtFetchFile.IsNullOrEmpty())
                    {
                        for (int i = 0; i < dtFetchFile.Rows.Count; i++)
                        {
                            string folderName = AppDomain.CurrentDomain.BaseDirectory;
                            string pathString = System.IO.Path.Combine(folderName, "TempCustomerTDSDetail\\").Replace(@"\", "\\");

                            if (!Directory.Exists(pathString))
                            {
                                System.IO.Directory.CreateDirectory(pathString);
                            }

                            if (File.Exists(Helpers.PathHelper.CustomerTDCImageFile() + dtFetchFile.Rows[i]["FileName"].ToString()))
                            {
                                String TransferFileFrom = Helpers.PathHelper.CustomerTDCImageFile() + dtFetchFile.Rows[i]["FileName"].ToString();
                                String Name = TransferFileFrom.Substring(TransferFileFrom.LastIndexOf("\\") + 1);
                                File.Copy(TransferFileFrom, pathString + dtFetchFile.Rows[i]["FileName"].ToString(), true);
                            }

                            if (dtFetchTDCDetail.Rows[j]["TDCId"].ToString() == dtFetchFile.Rows[i]["Id"].ToString())
                            {
                                dtFetchTDCDetail.Rows[j]["Filepath"] = pathString + dtFetchFile.Rows[i]["FileName"].ToString();
                                dtFetchTDCDetail.Rows[j]["FileName"] = dtFetchFile.Rows[i]["FileName"].ToString();
                            }
                        }
                    }
                }


                dgvTDCDetail.DataSource = dtFetchTDCDetail;



            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Save_Click

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //ValidationHelper.RequiredFieldValidation(txtCustomerName, epRequiredField);
                if (txtCustomerName.Text == "")
                {
                    const string type = "Enter Customer Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtCustomerName.Focus();
                    return;
                }
                if (cmbType.SelectedValue == null || cmbType.SelectedValue.ToString() == string.Empty || cmbType.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Guid.Parse(cmbType.SelectedValue.ToString()) == Guid.Empty)
                {
                    const string type = "Select Customer Type";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbType.Focus();
                    return;
                }
                if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue.ToString() == string.Empty || cmbCategory.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Guid.Parse(cmbCategory.SelectedValue.ToString()) == Guid.Empty)
                {
                    const string type = "Select Customer Category";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbCategory.Focus();
                    return;
                }

                obj_CustomerMaster.Customer_Name = txtCustomerName.Text;
                obj_CustomerMaster.CustomerTypeId = Guid.Parse(cmbType.SelectedValue.ToString());
                obj_CustomerMaster.CustomerCategoryId = Guid.Parse(cmbCategory.SelectedValue.ToString());
                if (cmbCustomerGroup.SelectedValue != null && cmbCustomerGroup.SelectedValue.ToString() != string.Empty && cmbCustomerGroup.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbCustomerGroup.SelectedValue.ToString()) != Guid.Empty)
                    obj_CustomerMaster.CustomerGroupId = Guid.Parse(cmbCustomerGroup.SelectedValue.ToString());
                else
                    obj_CustomerMaster.CustomerGroupId = Guid.Empty;

                //Financial Details


                obj_CustomerMaster.Customer_flag = "C";
                obj_CustomerMaster.TaxNo1 = txtTaxNo1.Text;
                obj_CustomerMaster.TaxNo2 = txtTaxNo2.Text;
                obj_CustomerMaster.TaxNo3 = txtTaxNo3.Text;
                obj_CustomerMaster.TaxNo4 = txtTaxNo4.Text;
                obj_CustomerMaster.TaxNo5 = txtTaxNo5.Text;
                if (txtPaymentTerms.Text != string.Empty)
                    obj_CustomerMaster.PaymentTerms = Convert.ToInt32(txtPaymentTerms.Text);
                obj_CustomerMaster.Range = txtRange.Text;

                obj_CustomerMaster.Division = txtDivision.Text;

                obj_CustomerMaster.Commissionerate = txtCommissionrate.Text;
                var session = Session.Get();
                obj_CustomerMaster.Created_By = session.UserId;

                obj_CustomerMaster.Created_On = System.DateTime.Now;

                obj_CustomerMaster.Modified_By = session.UserId;

                obj_CustomerMaster.Modified_On = System.DateTime.Now;

                obj_CustomerMaster.EntityId = session.EntityID;

                obj_CustomerMaster.VendorCode = txtVendorCode.Text.Trim();
                obj_CustomerMaster.CustomerCode = txtCustomerCode.Text.Trim();
                obj_CustomerMaster.GSTNo = txtGSTNo.Text;

                #region  Add Address Details to dt

                try
                {
                    DataTable dt_Address = new DataTable();

                    dt_Address.Columns.Add("Street");
                    dt_Address.Columns.Add("Area");
                    dt_Address.Columns.Add("CityId");
                    //  dt_Address.Columns.Add("StateId");
                    dt_Address.Columns.Add("Pincode");


                    DataRow dr;

                    for (int i = 0; i < dgvAddress.Rows.Count; i++)
                    {
                        dr = dt_Address.NewRow();

                        dr["Street"] = dgvAddress.Rows[i].Cells["Street"].Value;
                        dr["Area"] = dgvAddress.Rows[i].Cells["Area"].Value;
                        dr["CityId"] = dgvAddress.Rows[i].Cells["CityId"].Value;
                        // dr["StateId"] = dgvAddress.Rows[i].Cells["StateId"].Value;
                        dr["Pincode"] = dgvAddress.Rows[i].Cells["Pincode"].Value;

                        dt_Address.Rows.Add(dr);
                    }

                    obj_CustomerMaster.dt_Address = dt_Address;                      //Passing Address value to Create XML data for Curser
                }
                catch (Exception ex)
                {

                    ExceptionHandler.LogException(ex);
                    //const string error = "Exception in Save Address";
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                #region  Add Contact Details to dt

                try
                {
                    DataTable dt_Contact = new DataTable();

                    dt_Contact.Columns.Add("PersonName");
                    dt_Contact.Columns.Add("Department");
                    dt_Contact.Columns.Add("Designation");
                    dt_Contact.Columns.Add("Email");
                    dt_Contact.Columns.Add("ContactNo");
                    dt_Contact.Columns.Add("ContactId");

                    DataRow dr;

                    for (int i = 0; i < dgvContact.Rows.Count; i++)
                    {
                        dr = dt_Contact.NewRow();

                        dr["PersonName"] = dgvContact.Rows[i].Cells["PersonName"].Value;
                        dr["Email"] = dgvContact.Rows[i].Cells["Email"].Value;
                        dr["ContactNo"] = dgvContact.Rows[i].Cells["ContactNo"].Value;
                        dr["Designation"] = dgvContact.Rows[i].Cells["Designation"].Value;
                        dr["Department"] = dgvContact.Rows[i].Cells["Department"].Value;
                        if (dgvContact.Rows[i].Cells["ContactId"].Value != null)
                            dr["ContactId"] = dgvContact.Rows[i].Cells["ContactId"].Value;
                        else
                            dr["ContactId"] = Guid.Empty;

                        dt_Contact.Rows.Add(dr);

                    }

                    obj_CustomerMaster.dt_Contact = dt_Contact;
                }
                catch (Exception ex)
                {

                    ExceptionHandler.LogException(ex);
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                #endregion

                #region  Add Bank Details to dt

                try
                {
                    DataTable dt_Bank = new DataTable();
                    dt_Bank.Columns.Add("PartyBankId");
                    dt_Bank.Columns.Add("BankId");
                    dt_Bank.Columns.Add("BankName");
                    dt_Bank.Columns.Add("BranchName");
                    dt_Bank.Columns.Add("ACCNo");
                    dt_Bank.Columns.Add("IFSCNo");
                    dt_Bank.Columns.Add("MICRNo");
                    dt_Bank.Columns.Add("CityId");
                    dt_Bank.Columns.Add("StateId");
                    dt_Bank.Columns.Add("CountryId");
                    dt_Bank.Columns.Add("City");
                    dt_Bank.Columns.Add("State");
                    dt_Bank.Columns.Add("CountryName");

                    DataRow dr;

                    for (int i = 0; i < dgvBankDetails.Rows.Count; i++)
                    {
                        dr = dt_Bank.NewRow();
                        dr["BankId"] = dgvBankDetails.Rows[i].Cells["BankId"].Value;
                        dr["BankName"] = dgvBankDetails.Rows[i].Cells["BankName"].Value;
                        dr["BranchName"] = dgvBankDetails.Rows[i].Cells["BranchName"].Value;
                        dr["ACCNo"] = dgvBankDetails.Rows[i].Cells["ACCNo"].Value;
                        dr["IFSCNo"] = dgvBankDetails.Rows[i].Cells["IFSCNo"].Value;
                        dr["MICRNo"] = dgvBankDetails.Rows[i].Cells["MICRNo"].Value;
                        dr["CityId"] = dgvBankDetails.Rows[i].Cells["CityId"].Value;
                        dr["StateId"] = dgvBankDetails.Rows[i].Cells["StateId"].Value;
                        dr["CountryId"] = dgvBankDetails.Rows[i].Cells["CountryId"].Value;
                        dr["City"] = dgvBankDetails.Rows[i].Cells["City"].Value;
                        dr["State"] = dgvBankDetails.Rows[i].Cells["State"].Value;
                        dr["CountryName"] = dgvBankDetails.Rows[i].Cells["CountryName"].Value;

                        if (dgvBankDetails.Rows[i].Cells["PartyBankId"].Value != null)
                            dr["PartyBankId"] = dgvBankDetails.Rows[i].Cells["PartyBankId"].Value;


                        dt_Bank.Rows.Add(dr);
                    }

                    obj_CustomerMaster.dt_Bank = dt_Bank;                      //Passing Address value to Create XML data for Curser
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogException(ex);
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

                #region AddTestingChargeDeatilToDt
                try
                {
                    DataTable dtTestingCharge = new DataTable();

                    dtTestingCharge.Columns.Add("SpRequirementID");
                    dtTestingCharge.Columns.Add("SpRequirement");
                    dtTestingCharge.Columns.Add("EffectiveDate");
                    dtTestingCharge.Columns.Add("UnitID");
                    dtTestingCharge.Columns.Add("Unit");
                    dtTestingCharge.Columns.Add("Charge");

                    DataRow drTestingCharge;

                    for (int i = 0; i < dgvTestingCharges.Rows.Count; i++)
                    {
                        drTestingCharge = dtTestingCharge.NewRow();
                        drTestingCharge["SpRequirementID"] = dgvTestingCharges.Rows[i].Cells["SpRequirementID"].Value;
                        drTestingCharge["SpRequirement"] = dgvTestingCharges.Rows[i].Cells["SpRequirement"].Value;
                        drTestingCharge["EffectiveDate"] = dgvTestingCharges.Rows[i].Cells["EffectiveDate"].Value;
                        drTestingCharge["UnitID"] = dgvTestingCharges.Rows[i].Cells["UnitID"].Value;
                        drTestingCharge["Unit"] = dgvTestingCharges.Rows[i].Cells["Unit"].Value;
                        drTestingCharge["Charge"] = dgvTestingCharges.Rows[i].Cells["Charge"].Value;

                        dtTestingCharge.Rows.Add(drTestingCharge);
                    }

                    obj_CustomerMaster.DtTestingCharges = dtTestingCharge;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogException(ex);
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                #endregion

                #region AddTDCDetail
                try
                {
                    DataTable dtTDCDetail = new DataTable();

                    dtTDCDetail.Columns.Add("MetalId");
                    dtTDCDetail.Columns.Add("TDCNo");
                    dtTDCDetail.Columns.Add("FileName");

                    DataRow drTDCDetail;


                    for (int i = 0; i < dgvTDCDetail.Rows.Count; i++)
                    {
                        drTDCDetail = dtTDCDetail.NewRow();
                        drTDCDetail["MetalId"] = dgvTDCDetail.Rows[i].Cells["MetalId"].Value;
                        drTDCDetail["TDCNo"] = dgvTDCDetail.Rows[i].Cells["TDCNo"].Value;

                        if (dgvTDCDetail.Rows[i].Cells["FileName"].Value != null && dgvTDCDetail.Rows[i].Cells["FileName"].Value.ToString() != string.Empty)
                        {
                            String destinationpath = Helpers.PathHelper.CustomerTDCImageFile() + dgvTDCDetail.Rows[i].Cells["FileName"].Value.ToString();
                            if (!File.Exists(Helpers.PathHelper.CustomerTDCImageFile() + dgvTDCDetail.Rows[i].Cells["FileName"].Value.ToString()))
                            {
                                string folderName = AppDomain.CurrentDomain.BaseDirectory;
                                string pathString = System.IO.Path.Combine(folderName, "TempCustomerTDSDetail\\").Replace(@"\", "\\");
                                File.Move(pathString.Replace(@"\", "\\") + dgvTDCDetail.Rows[i].Cells["FileName"].Value.ToString(), Helpers.PathHelper.CustomerTDCImageFile() + dgvTDCDetail.Rows[i].Cells["FileName"].Value.ToString());
                            }
                            drTDCDetail["FileName"] = dgvTDCDetail.Rows[i].Cells["FileName"].Value;
                        }
                        else
                        {
                            drTDCDetail["FileName"] = string.Empty;
                        }
                        dtTDCDetail.Rows.Add(drTDCDetail);
                    }

                    obj_CustomerMaster.dt_TDCDetail = dtTDCDetail;
                }
                catch (Exception ex)
                {

                    ExceptionHandler.LogException(ex);
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                #endregion

                int value = 0;

                if (btnSave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        value = obj_CustomerMaster.Insert_Customer_Master();


                        if (value == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CLR();
                            ClearBankDetails();
                            txtCustomerName.Focus();
                            dgvTestingCharges.DataSource = null;
                            ClearTestingChargesDetail();
                            dgvTestingCharges.DataSource = null;
                            ClearTDCDetail();
                            dgvTDCDetail.DataSource = null;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (btnSave.Text == Helper.ButtonCaptions.Update)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        obj_CustomerMaster.DeleteDataContact = _CustomerSupplierInputParameters.lbldeleteContact.Text;
                        value = obj_CustomerMaster.UpdateCustomerMaster();


                        if (value == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CLR();
                            ClearBankDetails();
                            txtCustomerName.Focus();
                            ClearTestingChargesDetail();
                            dgvTestingCharges.DataSource = null;
                            ClearTDCDetail();
                            dgvTDCDetail.DataSource = null;

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

        #endregion

        #region Add Address and Contact

        int id = 0; // To get selecetd index of Grid View.

        private void btnAddress_Click(object sender, EventArgs e)                     //Add button for Address details
        {
            try
            {
                if (txtStreet.Text == "")
                {
                    const string type = "Enter Street";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtStreet.Focus();
                    return;
                }

                if (txtArea.Text == "")
                {
                    const string type = "Enter Area";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtArea.Focus();
                    return;
                }
                if (cmbCity.SelectedValue == null || cmbCity.Text == Helper.DropdownDefaultText.Select)
                {
                    const string type = "Select City";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbCity.Focus();
                    return;
                }

                if (cmbState.SelectedValue == null || cmbState.Text == Helper.DropdownDefaultText.Select)
                {
                    const string type = "Select State";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbState.Focus();
                    return;
                }

                if (cmbCountry.SelectedValue == null || cmbCountry.Text == Helper.DropdownDefaultText.Select)
                {
                    const string type = "Select Country";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbCountry.Focus();
                    return;
                }

                DataTable dt = new DataTable();

                dt.Columns.Add("Street");
                dt.Columns.Add("Area");
                dt.Columns.Add("City");
                dt.Columns.Add("CityId");
                dt.Columns.Add("State");
                dt.Columns.Add("PinCode");
                dt.Columns.Add("Country");
                dt.Columns.Add("CountryId");


                DataRow dr;

                for (int i = 0; i < dgvAddress.Rows.Count; i++)
                {
                    dr = dt.NewRow();

                    dr["Street"] = dgvAddress.Rows[i].Cells["Street"].Value;
                    dr["Area"] = dgvAddress.Rows[i].Cells["Area"].Value;
                    dr["CityId"] = dgvAddress.Rows[i].Cells["CityId"].Value;
                    dr["City"] = dgvAddress.Rows[i].Cells["City"].Value;
                    dr["State"] = dgvAddress.Rows[i].Cells["State"].Value;
                    dr["PinCode"] = dgvAddress.Rows[i].Cells["PinCode"].Value;
                    dr["Country"] = dgvAddress.Rows[i].Cells["Country"].Value;
                    dr["CountryId"] = dgvAddress.Rows[i].Cells["CountryId"].Value;

                    dt.Rows.Add(dr);
                }
                if (btnAddress.Text == Helper.ButtonCaptions.Add)
                {
                    dr = dt.NewRow();

                    dr["Street"] = txtStreet.Text;
                    dr["Area"] = txtArea.Text;
                    dr["CityId"] = cmbCity.SelectedValue.ToString();
                    dr["City"] = cmbCity.Text;
                    dr["State"] = cmbState.Text;
                    dr["PinCode"] = txtPinCode.Text.Trim().Replace(" ", "");
                    dr["Country"] = cmbCountry.Text;
                    dr["CountryId"] = cmbCountry.SelectedValue.ToString();
                    dt.Rows.Add(dr);

                }
                else if (btnAddress.Text == Helper.ButtonCaptions.Update)
                {
                    dt.Rows[id]["Street"] = txtStreet.Text;
                    dt.Rows[id]["Area"] = txtArea.Text;
                    dt.Rows[id]["CityId"] = cmbCity.SelectedValue.ToString();
                    dt.Rows[id]["City"] = cmbCity.Text;
                    dt.Rows[id]["State"] = cmbState.Text;
                    dt.Rows[id]["PinCode"] = txtPinCode.Text.Trim().Replace(" ", "");
                    dt.Rows[id]["Country"] = cmbCountry.Text;
                    dt.Rows[id]["CountryId"] = cmbCountry.SelectedValue.ToString();
                }

                dgvAddress.DataSource = dt;

                foreach (Control a in tabAddress.Controls)
                {
                    if (a is TextBox)
                    {
                        a.Text = "";
                    }
                    cmbState.Text = Helper.DropdownDefaultText.Select;
                    cmbCity.Text = Helper.DropdownDefaultText.Select;
                    cmbCountry.Text = Helper.DropdownDefaultText.Select;
                    try
                    {
                        dgvAddress.Columns["CityId"].Visible = false;
                        dgvAddress.Columns["CountryId"].Visible = false;
                        dgvAddress.Columns["StateCode"].Visible = false;
                        dgvAddress.Columns["CountryName"].Visible = false;

                    }
                    catch
                    { }
                }


                btnAddress.Text = Helper.ButtonCaptions.Add;
                txtStreet.Focus();
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAddContact_Click(object sender, EventArgs e)            //Add button for Contact details
        {
            try
            {
                if (txtPersonName.Text == "")
                {
                    const string type = "Enter Person Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtPersonName.Focus();
                    return;
                }

                if (txtPersonName.Text != "" || txtEmail.Text != "" || txtContact.Text != "" || txtDesignation.Text != "" || txtDepartment.Text != "")
                {

                    DataTable dt = new DataTable();

                    dt.Columns.Add("PersonName");
                    dt.Columns.Add("Department");
                    dt.Columns.Add("Designation");
                    dt.Columns.Add("Email");
                    dt.Columns.Add("ContactNo");
                    dt.Columns.Add("ContactId");

                    DataRow dr;

                    for (int i = 0; i < dgvContact.Rows.Count; i++)
                    {
                        dr = dt.NewRow();

                        dr["PersonName"] = dgvContact.Rows[i].Cells["PersonName"].Value;
                        dr["Email"] = dgvContact.Rows[i].Cells["Email"].Value;
                        dr["ContactNo"] = dgvContact.Rows[i].Cells["ContactNo"].Value;
                        dr["Designation"] = dgvContact.Rows[i].Cells["Designation"].Value;
                        dr["Department"] = dgvContact.Rows[i].Cells["Department"].Value;
                        dr["ContactId"] = dgvContact.Rows[i].Cells["ContactId"].Value;

                        dt.Rows.Add(dr);
                    }

                    if (btnAddContact.Text == Helper.ButtonCaptions.Add)
                    {
                        dr = dt.NewRow();

                        dr["PersonName"] = txtPersonName.Text;
                        dr["Email"] = txtEmail.Text;
                        dr["ContactNo"] = txtContact.Text;
                        dr["Designation"] = txtDesignation.Text;
                        dr["Department"] = txtDepartment.Text;
                        dr["ContactId"] = Guid.Empty;
                        dt.Rows.Add(dr);
                    }
                    else if (btnAddContact.Text == Helper.ButtonCaptions.Update)
                    {
                        dt.Rows[id]["PersonName"] = txtPersonName.Text;
                        dt.Rows[id]["Email"] = txtEmail.Text;
                        dt.Rows[id]["ContactNo"] = txtContact.Text;
                        dt.Rows[id]["Designation"] = txtDesignation.Text;
                        dt.Rows[id]["Department"] = txtDepartment.Text;
                        dt.Rows[id]["ContactId"] = dgvContact.Rows[id].Cells["ContactId"].Value;
                    }
                    dgvContact.DataSource = dt;

                    foreach (Control a in tabContact.Controls)
                    {
                        if (a is TextBox)
                        {
                            a.Text = "";
                        }

                    }
                    btnAddContact.Text = Helper.ButtonCaptions.Add;
                    btnSave.Focus();
                    //  }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Mandatory, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                txtPersonName.Focus();
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                const string error = "Error Occured";
                System.Windows.Forms.MessageBox.Show(error, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        #endregion

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region ESC Shortcut

            if (keyData == (Keys.Escape))
            {



                if (FullScreenOff == 1)
                    this.Close();


            }

            #endregion

            if (keyData == (Keys.Alt | Keys.T))
            {
                btnCustomerType_Click_1(btnCustomerType, null);
            }

            if (keyData == (Keys.Alt | Keys.C))
            {
                btnCustomerCategory_Click(btnCustomerCategory, null);
            }

            if (keyData == (Keys.Alt | Keys.G))
            {
                btnCustomerGroup_Click(btnCustomerGroup, null);
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(btnSave, null);
            }

            if (Convert.ToString(keyData) == clsValues.Instance.ShortcutKey)
            {
                button2_Click(btnView, null);
            }

            if (keyData == (Keys.F5))
            {
                DataClear();
                ClearTestingChargesDetail();
                txtCustomerName.Focus();
                return true;

            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        #endregion

        #region PinCodeValidation

        private void txtPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true)
                {
                    if (txtPinCode.Text.Trim().Replace(" ", "").Length >= 6)
                    {
                        if (e.KeyChar == (char)8)
                        { }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    e.Handled = true;
                }

                if (e.KeyChar == 13)
                {
                    btnAddContact_Click(null, null);
                    txtStreet.Focus();
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        #endregion

        #region Click Event

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.ClearConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CLR();                                           //Clear All Controls from Form
            }

            btnAddContact.Text = Helper.ButtonCaptions.Add;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
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

        private void btnCancelContact_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == Helper.ButtonCaptions.Update)
            {
                //btnAddContact_Click(btnAddContact, null);
            }

            btnAddContact.Text = Helper.ButtonCaptions.Add;

            txtPersonName.Clear();
            txtDepartment.Clear();
            txtDesignation.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtPersonName.Focus();

        }

        private void btnCancelAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == Helper.ButtonCaptions.Update)
                {
                    btnAddress_Click(null, null);
                }
                btnAddContact.Text = Helper.ButtonCaptions.Add;


                cmbState.DataSource = null;
                cmbState.Text = Helper.DropdownDefaultText.Select;
                cmbCountry.DataSource = null;
                cmbCountry.Text = Helper.DropdownDefaultText.Select;
                FillCity();
                txtStreet.Clear();
                txtArea.Clear();
                txtPinCode.Clear();
                cmbCity.Text = Helper.DropdownDefaultText.Select;
                txtStreet.Focus();
                //FillCity();                                     //Fill State
                // cmbState_SelectionChangeCommitted(null, null);    //Fill City

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabDetails.SelectedIndex = (tabDetails.TabPages.Count - 1 == tabDetails.SelectedIndex) ? 0 : tabDetails.SelectedIndex + 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ////if ShowDetails_CustomerMaster is already open then it close first 
                if (Application.OpenForms.OfType<ShowDetails_CustomerMaster>().Count() == 1)
                    Application.OpenForms.OfType<ShowDetails_CustomerMaster>().First().Close();

                ShowDetails_CustomerMaster
                    CusInqiry = new ShowDetails_CustomerMaster();
                CusInqiry.MdiParent = this.ParentForm;
                CusInqiry.Show();
                CusInqiry.Focus();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            //((MDIParent)this.MdiParent).FormLoadEdit(MenuHelper.MenuIdentityCodes.CUSTOMERREGISTER);
         
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            DataTable dtBank = new DataTable();
            try
            {
                if (cmbBankName.SelectedValue == null || cmbBankName.SelectedValue.ToString() == "" || Guid.Parse(cmbBankName.SelectedValue.ToString()) == Guid.Empty) //Customer Name  Required Field
                {
                    const string type = "Select Bank Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbBankName.Focus();
                    return;
                }

                if (txtBranchName.Text == string.Empty)
                {
                    const string type = "Enter Branch Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtBranchName.Focus();
                    return;
                }

                if (txtAccNo.Text == string.Empty)
                {
                    const string type = "Enter A/C No";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtAccNo.Focus();
                    return;
                }

                if (txtIFSCNo.Text == string.Empty)
                {
                    const string type = "Enter IFSC No";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtIFSCNo.Focus();
                    return;
                }


                if (dtBank.Columns.Count <= 0)
                {
                    dtBank.Columns.Add("BankId");
                    dtBank.Columns.Add("BankName");
                    dtBank.Columns.Add("BranchName");
                    dtBank.Columns.Add("ACCNo");
                    dtBank.Columns.Add("IFSCNo");
                    dtBank.Columns.Add("MICRNo");
                    dtBank.Columns.Add("CityId");
                    dtBank.Columns.Add("StateId");
                    dtBank.Columns.Add("CountryId");
                    dtBank.Columns.Add("City");
                    dtBank.Columns.Add("State");
                    dtBank.Columns.Add("CountryName");
                }
                DataRow drBank;

                for (int i = 0; i < dgvBankDetails.Rows.Count; i++)
                {
                    drBank = dtBank.NewRow();
                    drBank["BankId"] = dgvBankDetails.Rows[i].Cells["BankId"].Value;
                    drBank["BankName"] = dgvBankDetails.Rows[i].Cells["BankName"].Value;
                    drBank["BranchName"] = dgvBankDetails.Rows[i].Cells["BranchName"].Value;
                    drBank["ACCNo"] = dgvBankDetails.Rows[i].Cells["ACCNo"].Value;
                    drBank["IFSCNo"] = dgvBankDetails.Rows[i].Cells["IFSCNo"].Value;
                    drBank["MICRNo"] = dgvBankDetails.Rows[i].Cells["MICRNo"].Value;
                    drBank["CityId"] = dgvBankDetails.Rows[i].Cells["CityId"].Value;
                    drBank["StateId"] = dgvBankDetails.Rows[i].Cells["StateId"].Value;
                    drBank["CountryId"] = dgvBankDetails.Rows[i].Cells["CountryId"].Value;
                    drBank["City"] = dgvBankDetails.Rows[i].Cells["City"].Value;
                    drBank["State"] = dgvBankDetails.Rows[i].Cells["State"].Value;
                    drBank["CountryName"] = dgvBankDetails.Rows[i].Cells["CountryName"].Value;

                    dtBank.Rows.Add(drBank);
                }


                if (btnadd.Text == Helper.ButtonCaptions.Add)
                {
                    drBank = dtBank.NewRow();


                    // drBank = dtBank.NewRow();
                    drBank["BankID"] = Guid.Parse(cmbBankName.SelectedValue.ToString());
                    drBank["BankName"] = cmbBankName.Text;
                    drBank["BranchName"] = txtBranchName.Text.Trim();
                    drBank["ACCNo"] = txtAccNo.Text.Trim();
                    drBank["IFSCNo"] = txtIFSCNo.Text.Trim();
                    drBank["MICRNo"] = txtMICRCode.Text.Trim();
                    if (cmbCityBank.SelectedValue != null && cmbCityBank.SelectedValue.ToString() != "" && cmbCityBank.SelectedValue.ToString() != "0" && cmbCityBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        drBank["CityId"] = cmbCityBank.SelectedValue.ToString();
                        drBank["City"] = cmbCityBank.Text;
                    }
                    if (cmbStateBank.SelectedValue != null && cmbStateBank.SelectedValue.ToString() != "" && cmbStateBank.SelectedValue.ToString() != "0" && cmbStateBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        drBank["StateId"] = cmbStateBank.SelectedValue.ToString();
                        drBank["State"] = cmbStateBank.Text;
                    }
                    if (cmbCountryBank.SelectedValue != null && cmbCountryBank.SelectedValue.ToString() != "" && cmbCountryBank.SelectedValue.ToString() != "0" && cmbCountryBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        drBank["CountryId"] = cmbCountryBank.SelectedValue.ToString();
                        drBank["CountryName"] = cmbCountryBank.Text;
                    }

                    dtBank.Rows.Add(drBank);

                }

                else if (btnadd.Text == Helper.ButtonCaptions.Update)
                {
                    dtBank.Rows[RawId]["BankId"] = Guid.Parse(cmbBankName.SelectedValue.ToString());
                    dtBank.Rows[RawId]["BankName"] = cmbBankName.Text;
                    dtBank.Rows[RawId]["BranchName"] = txtBranchName.Text.Trim();
                    dtBank.Rows[RawId]["ACCNo"] = txtAccNo.Text.Trim();
                    dtBank.Rows[RawId]["IFSCNo"] = txtIFSCNo.Text.Trim();
                    dtBank.Rows[RawId]["MICRNo"] = txtMICRCode.Text.Trim();
                    if (cmbCityBank.SelectedValue != null && cmbCityBank.SelectedValue.ToString() != "" && cmbCityBank.SelectedValue.ToString() != "0" && cmbCityBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        dtBank.Rows[RawId]["CityId"] = cmbCityBank.SelectedValue;
                        dtBank.Rows[RawId]["City"] = cmbCityBank.Text;
                    }
                    if (cmbStateBank.SelectedValue != null && cmbStateBank.SelectedValue.ToString() != "" && cmbStateBank.SelectedValue.ToString() != "0" && cmbStateBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        dtBank.Rows[RawId]["StateId"] = cmbStateBank.SelectedValue;
                        dtBank.Rows[RawId]["State"] = cmbStateBank.Text;
                    }
                    if (cmbCountryBank.SelectedValue != null && cmbCountryBank.SelectedValue.ToString() != "" && cmbCountryBank.SelectedValue.ToString() != "0" && cmbCountryBank.Text != Helper.DropdownDefaultText.Select)
                    {
                        dtBank.Rows[RawId]["CountryId"] = cmbCountryBank.SelectedValue;
                        dtBank.Rows[RawId]["CountryName"] = cmbCountryBank.Text;
                    }
                }

                if (dtBank.Rows.Count > 0)
                    dgvBankDetails.DataSource = dtBank;
                if (dgvBankDetails.Columns.Contains("BankId"))
                    dgvBankDetails.Columns["BankId"].Visible = false;
                if (dgvBankDetails.Columns.Contains("CityId"))
                    dgvBankDetails.Columns["CityId"].Visible = false;
                if (dgvBankDetails.Columns.Contains("StateId"))
                    dgvBankDetails.Columns["StateId"].Visible = false;
                if (dgvBankDetails.Columns.Contains("CountryId"))
                    dgvBankDetails.Columns["CountryId"].Visible = false;


                ClearBankDetails();
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelBankDetail_Click(object sender, EventArgs e)
        {
            ClearBankDetails();
        }

        //private void btnCustomerType_Click(object sender, EventArgs e)
        //{
        //    if (_CustomerSupplierInputParameters.LinkText == null || _CustomerSupplierInputParameters.LinkText == string.Empty)
        //    {
        //        _CustomerSupplierInputParameters.LinkText = "Type";
        //    }

        //    clsValues.Instance.FullScreenOff = 1;
        //    var CustomerSupplierInputParameters = new CustomerSupplierInputParameters(Inventory_Management.Common.Enums.FormMode.Insert);
        //    CustomerSupplierInputParameters.LinkText = _CustomerSupplierInputParameters.LinkText;
        //    CustomerTypeCategoryGroupMaster objitemtype = new CustomerTypeCategoryGroupMaster(CustomerSupplierInputParameters);
        //    objitemtype.MinimizeBox = false;
        //    objitemtype.MaximizeBox = false;
        //    objitemtype.ShowInTaskbar = false;
        //    objitemtype.ShowDialog();
        //    clsValues.Instance.FullScreenOff = 0;
        //    if (_CustomerSupplierInputParameters.LinkText == "Type")
        //    {
        //        if (!bwCustomerType.IsBusy)
        //            bwCustomerType.RunWorkerAsync();
        //    }
        //    else if (_CustomerSupplierInputParameters.LinkText == "Category")
        //    {
        //        if (!bwCustomerCategory.IsBusy)
        //            bwCustomerCategory.RunWorkerAsync();
        //    }
        //    else if (_CustomerSupplierInputParameters.LinkText == "Group")
        //    {
        //        if (!bwCustomerGroup.IsBusy)
        //            bwCustomerGroup.RunWorkerAsync();
        //    }
        //    _CustomerSupplierInputParameters.LinkText = string.Empty;
        //}

        private void btnCustomerCategory_Click(object sender, EventArgs e)
        {
            _CustomerSupplierInputParameters.LinkText = "Category";
            btnCustomerType_Click_1(sender, e);
            _CustomerSupplierInputParameters.LinkText = string.Empty;

        }

        private void btnCustomerGroup_Click(object sender, EventArgs e)
        {
            _CustomerSupplierInputParameters.LinkText = "Group";
            btnCustomerType_Click_1(sender, e);
            _CustomerSupplierInputParameters.LinkText = string.Empty;

        }

        private void btnCustomerType_Click_1(object sender, EventArgs e)
        {
            if (_CustomerSupplierInputParameters.LinkText == null || _CustomerSupplierInputParameters.LinkText == string.Empty)
            {
                _CustomerSupplierInputParameters.LinkText = "Type";
            }

            clsValues.Instance.FullScreenOff = 1;
            var CustomerSupplierInputParameters = new CustomerSupplierInputParameters(Enums.FormMode.Insert);
            CustomerSupplierInputParameters.LinkText = _CustomerSupplierInputParameters.LinkText;
            CustomerTypeCategoryGroupMaster objitemtype = new CustomerTypeCategoryGroupMaster(CustomerSupplierInputParameters);
            objitemtype.MinimizeBox = false;
            objitemtype.MaximizeBox = false;
            objitemtype.ShowInTaskbar = false;
            objitemtype.ShowDialog();
            clsValues.Instance.FullScreenOff = 0;
            //if (_CustomerSupplierInputParameters.LinkText == "Type")
            //{
                if (!bwCustomerType.IsBusy)
                    bwCustomerType.RunWorkerAsync();
            //}
            //else if (_CustomerSupplierInputParameters.LinkText == "Category")
            //{
                if (!bwCustomerCategory.IsBusy)
                    bwCustomerCategory.RunWorkerAsync();
            //}
            //else if (_CustomerSupplierInputParameters.LinkText == "Group")
            //{
                if (!bwCustomerGroup.IsBusy)
                    bwCustomerGroup.RunWorkerAsync();
            //}
            _CustomerSupplierInputParameters.LinkText = string.Empty;
        }

        private void btnCountryAddress_Click(object sender, EventArgs e)
        {
            StateCitypopup pack = new StateCitypopup(this);
            pack.MinimizeBox = false;
            pack.MaximizeBox = false;
            pack.ShowInTaskbar = false;
            pack.ShowDialog();
        }

        private void btnBankDetail_Click(object sender, EventArgs e)
        {
            BankMaster pack = new BankMaster(this);
            pack.MinimizeBox = false;
            pack.MaximizeBox = false;
            pack.ShowInTaskbar = false;
            pack.ShowDialog();
            if (!bwBankName.IsBusy) bwBankName.RunWorkerAsync();
        }

        private void btnCountryBank_Click(object sender, EventArgs e)
        {
            StateCitypopup pack = new StateCitypopup(this);
            pack.MinimizeBox = false;
            pack.MaximizeBox = false;
            pack.ShowInTaskbar = false;
            pack.ShowDialog();
        }

        private void btnCancelTestCharge_Click(object sender, EventArgs e)
        {
            ClearTestingChargesDetail();
        }

        private void btnRequirement_Click(object sender, EventArgs e)
        {
            clsValues.Instance.FullScreenOff = 1;
            SpRequirementMaster objrequirement = new SpRequirementMaster();
            objrequirement.MinimizeBox = false;
            objrequirement.MaximizeBox = false;
            objrequirement.ShowInTaskbar = false;
            objrequirement.ShowDialog();
            clsValues.Instance.FullScreenOff = 0;

            if (!bwSpecialRequirement.IsBusy) bwSpecialRequirement.RunWorkerAsync();
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "All files (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    if (open.FileName.EndsWith(".pdf") == true || open.FileName.EndsWith(".PDF") == true)
                    {
                        Random _r = new Random();
                        String FileName = (open.FileName.Substring(open.FileName.LastIndexOf("\\") + 1));
                        string rndFileName = _r.Next() + FileName;
                        lblTDFFilePath.Text = open.FileName;
                        lblTDCFileName.Text = open.FileName.Substring(open.FileName.LastIndexOf("\\") + 1); // rndFileName.Substring(rndFileName.LastIndexOf("\\") + 1);


                        //string folderName = AppDomain.CurrentDomain.BaseDirectory;
                        //string pathString = System.IO.Path.Combine(folderName, "TempCustomerTDSDetail\\").Replace(@"\", "\\");

                        //if (!Directory.Exists(pathString))
                        //{
                        //    System.IO.Directory.CreateDirectory(pathString);
                        //}

                        //File.Copy(open.FileName.Replace(@"\", "\\"), pathString.Replace(@"\", "\\") + rndFileName.Substring(rndFileName.LastIndexOf("\\") + 1), true);
                    }
                    else
                    {
                        MessageBox.Show("Upload only PDF file");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnaddTDCDetail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAddTDCDetail = new DataTable();

                if (cmbGrade.SelectedValue == null || cmbGrade.SelectedValue.ToString() == string.Empty || cmbGrade.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Convert.ToInt32(cmbGrade.SelectedValue.ToString()) == 0)
                {
                    const string type = "Select grade";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbGrade.Focus();
                    return;
                }

                if (txtTDCNo.Text == string.Empty)
                {
                    const string type = "Enter TDC no";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    cmbGrade.Focus();
                    return;
                }

                #region Metal already exists

                #region Check from gridview

                if (dgvTDCDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvTDCDetail.Rows.Count; i++)
                    {
                        if (cmbGrade.SelectedValue.ToString() == dgvTDCDetail.Rows[i].Cells["MetalId"].Value.ToString() && txtTDCNo.Text == dgvTDCDetail.Rows[i].Cells["TDCNo"].Value.ToString())
                        {
                            if (btnaddTDCDetail.Text == Helper.ButtonCaptions.Update && TDCId == i)
                            {
                                continue;
                            }
                            System.Windows.Forms.MessageBox.Show("Grade and TCNo both are already exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                #endregion

                #region Check From Datatabse

                if (cmbGrade.SelectedValue != null && cmbGrade.SelectedValue.ToString() != string.Empty && cmbGrade.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Convert.ToInt32(cmbGrade.SelectedValue.ToString()) != 0)
                {
                    obj_CustomerMaster.MetalId = Convert.ToInt32(cmbGrade.SelectedValue.ToString());
                    DataTable dtFetchTDCNo = obj_CustomerMaster.FetchTDCNoByMetal();

                    if (!dtFetchTDCNo.IsNullOrEmpty())
                    {
                        for (int i = 0; i < dtFetchTDCNo.Rows.Count; i++)
                        {
                            if (txtTDCNo.Text == dtFetchTDCNo.Rows[i]["TDCNo"].ToString())
                            {

                                System.Windows.Forms.MessageBox.Show("Grade and TCNo both are already exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                #endregion

                #endregion

                if (dtAddTDCDetail.Columns.Count <= 0)
                {
                    dtAddTDCDetail.Columns.Add("MetalId");
                    dtAddTDCDetail.Columns.Add("MetalName");
                    dtAddTDCDetail.Columns.Add("TDCNo");
                    dtAddTDCDetail.Columns.Add("FilePath");
                    dtAddTDCDetail.Columns.Add("FileName");
                }

                DataRow drAddTDCDetail;

                for (int i = 0; i < dgvTDCDetail.Rows.Count; i++)
                {
                    drAddTDCDetail = dtAddTDCDetail.NewRow();
                    drAddTDCDetail["MetalId"] = dgvTDCDetail.Rows[i].Cells["MetalId"].Value;
                    drAddTDCDetail["MetalName"] = dgvTDCDetail.Rows[i].Cells["MetalName"].Value;
                    drAddTDCDetail["TDCNo"] = dgvTDCDetail.Rows[i].Cells["TDCNo"].Value;
                    drAddTDCDetail["FilePath"] = dgvTDCDetail.Rows[i].Cells["FilePath"].Value;
                    drAddTDCDetail["FileName"] = dgvTDCDetail.Rows[i].Cells["FileName"].Value;

                    dtAddTDCDetail.Rows.Add(drAddTDCDetail);
                }

                if (btnaddTDCDetail.Text == Helper.ButtonCaptions.Add)
                {
                    drAddTDCDetail = dtAddTDCDetail.NewRow();
                    drAddTDCDetail["MetalId"] = cmbGrade.SelectedValue;
                    drAddTDCDetail["MetalName"] = cmbGrade.Text;
                    drAddTDCDetail["TDCNo"] = txtTDCNo.Text;

                    string folderName = AppDomain.CurrentDomain.BaseDirectory;
                    string pathString = System.IO.Path.Combine(folderName, "TempCustomerTDSDetail\\").Replace(@"\", "\\");

                    if (!Directory.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }

                    if (lblTDCFileName.Text != string.Empty)
                    {
                        Random _r = new Random();
                        String FileName = (lblTDCFileName.Text.Substring(lblTDCFileName.Text.LastIndexOf("\\") + 1));
                        string rndFileName = _r.Next() + FileName;

                        File.Copy(lblTDFFilePath.Text.Replace(@"\", "\\"), pathString.Replace(@"\", "\\") + rndFileName.Substring(rndFileName.LastIndexOf("\\") + 1), true);

                        drAddTDCDetail["FilePath"] = lblTDFFilePath.Text;
                        drAddTDCDetail["FileName"] = rndFileName;
                    }
                    dtAddTDCDetail.Rows.Add(drAddTDCDetail);
                }
                else if (btnaddTDCDetail.Text == Helper.ButtonCaptions.Update)
                {
                    dtAddTDCDetail.Rows[TDCId]["MetalId"] = cmbGrade.SelectedValue;
                    dtAddTDCDetail.Rows[TDCId]["MetalName"] = cmbGrade.Text;
                    dtAddTDCDetail.Rows[TDCId]["TDCNo"] = txtTDCNo.Text;
                    //dtAddTDCDetail.Rows[TDCId]["FilePath"] = lblTDFFilePath.Text;
                    //dtAddTDCDetail.Rows[TDCId]["FileName"] = lblTDCFileName.Text;


                    string folderName = AppDomain.CurrentDomain.BaseDirectory;
                    string pathString = System.IO.Path.Combine(folderName, "TempCustomerTDSDetail\\").Replace(@"\", "\\");

                    if (!Directory.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }

                    if (lblTDCFileName.Text != string.Empty)
                    {
                        Random _r = new Random();
                        String FileName = (lblTDCFileName.Text.Substring(lblTDCFileName.Text.LastIndexOf("\\") + 1));
                        string rndFileName = _r.Next() + FileName;
                        if (!File.Exists(pathString.Replace(@"\", "\\") + rndFileName.Substring(rndFileName.LastIndexOf("\\") + 1)))
                            File.Copy(lblTDFFilePath.Text.Replace(@"\", "\\"), pathString.Replace(@"\", "\\") + rndFileName.Substring(rndFileName.LastIndexOf("\\") + 1), true);

                        dtAddTDCDetail.Rows[TDCId]["FilePath"] = lblTDFFilePath.Text;
                        dtAddTDCDetail.Rows[TDCId]["FileName"] = rndFileName;
                    }


                }
                if (!dtAddTDCDetail.IsNullOrEmpty())
                {
                    dgvTDCDetail.DataSource = dtAddTDCDetail;
                }

                ClearTDCDetail();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelTDCDetail_Click(object sender, EventArgs e)
        {
            ClearTDCDetail();
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            clsValues.Instance.FullScreenOff = 1;

            //MetalMaster detail = new MetalMaster();
            //detail.ShowInTaskbar = false;
            //detail.ShowDialog();
            clsValues.Instance.FullScreenOff = 0;
            if (!bwGrade.IsBusy) bwGrade.RunWorkerAsync();
        }

        #endregion

        #region Key Event

        private void cmbType_KeyUp(object sender, KeyEventArgs e)
        {
            cmbType.DroppedDown = true;
        }

        private void cmbCategory_KeyUp(object sender, KeyEventArgs e)
        {

            cmbCategory.DroppedDown = true;
        }

        private void cmbCity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                cmbCity.DroppedDown = true;
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAddContact_Click(btnAddContact, null);
                //txtStreet.Focus();
            }
        }

        private void cmbState_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                cmbState.DroppedDown = true;
        }

        private void dgvAddress_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }
            if (e.KeyCode == Keys.Home)
            {
                for (int i = 0; i < dgvAddress.Rows.Count; i++)
                //foreach (DataGridViewRow row in dgvPurchaseItem.Rows)
                {
                    ((DataGridViewCell)dgvAddress.Rows[i].Cells["Revise"]).Selected = true;
                }
            }
        }

        private void dgvContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }

            if (e.KeyCode == Keys.Home)
            {
                for (int i = 0; i < dgvContact.Rows.Count; i++)
                //foreach (DataGridViewRow row in dgvPurchaseItem.Rows)
                {
                    ((DataGridViewCell)dgvContact.Rows[i].Cells["ReviseContact"]).Selected = true;
                }
            }
        }

        private void txtStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvAddress.Focus();
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelAddress.Focus();
            }
        }

        private void txtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvContact.Focus();
            }
        }

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancelContact.Focus();

        }

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || e.KeyChar == '.')
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void IntegerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.AllowIntegerOnly();
        }
        
        #endregion

        #region BackGround Worker

        private void bwCustomerType_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                dtCustomerType = customerTypeCategoryGroupMaster.Fetch_Customer_Type_Details();

                dtCustomerType.AddSelectRow(0, 2);
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerType_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (dtCustomerType.Rows.Count > 0)
            {
                const string DisplayMember = "TypeName";
                const string ValueMember = "CustomerTypeId";
                cmbType.DataSource = dtCustomerType;
                cmbType.DisplayMember = DisplayMember;
                cmbType.ValueMember = ValueMember;
            }
            //if (!bwCustomerCategory.IsBusy)
            //{
            //    if (_CustomerSupplierInputParameters.CustomerId != Guid.Empty && _CustomerSupplierInputParameters.CustomerId != null)
            //    {
            //        StartOperation();
            //    }
            //}
        }

        private void bwCustomerCategory_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                dtCustomerCategory = customerTypeCategoryGroupMaster.Fetch_Customer_Category_Details();

                dtCustomerCategory.AddSelectRow(0, 2);
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bwCustomerCategory_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (dtCustomerCategory.Rows.Count > 0)
            {
                const string DisplayMember = "CategoryName";
                const string ValueMember = "CustomerCategoryId";
                cmbCategory.DataSource = dtCustomerCategory;
                cmbCategory.DisplayMember = DisplayMember;
                cmbCategory.ValueMember = ValueMember;
            }
            //if (!bwCustomerType.IsBusy)
            //{
            //    if (_CustomerSupplierInputParameters.CustomerId != Guid.Empty && _CustomerSupplierInputParameters.CustomerId != null)
            //    {
            //        StartOperation();
            //    }
            //}
        }

        private void bwCustomerGroup_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                DataTable dtCustomerGroup = customerTypeCategoryGroupMaster.Fetch_Customer_Group_Details();

                dtCustomerGroup.AddSelectRow(0, 2);

                e.Result = dtCustomerGroup as DataTable;

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwCustomerGroup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dtCustomerGroup = new DataTable();
            dtCustomerGroup = (DataTable)e.Result;
            if (dtCustomerGroup.Rows.Count > 0)
            {
                const string DisplayMember = "GroupName";
                const string ValueMember = "CustomerGroupId";
                cmbCustomerGroup.DataSource = dtCustomerGroup;
                cmbCustomerGroup.DisplayMember = DisplayMember;
                cmbCustomerGroup.ValueMember = ValueMember;
            }

        }

        private void bwBankName_DoWork(object sender, DoWorkEventArgs e)
        {
            clsBankMaster bankname = new clsBankMaster();
            DataTable dtBankName = new DataTable();

            dtBankName = bankname.FetchBankDetail();
            dtBankName.AddSelectRow(0, 1);
            e.Result = dtBankName;
        }

        private void bwBankName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if ((e.Result as DataTable) != null && (e.Result as DataTable).Rows.Count > 0)
                {
                    cmbBankName.DataSource = (e.Result as DataTable);
                    cmbBankName.DisplayMember = "BankName";
                    cmbBankName.ValueMember = "BankId";

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
        }

        private void bwGrade_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = GetGradeData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
        }

        private void bwGrade_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGradeData(e.Result as DataTable);
        }

        private void SpecialRequirement_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = SpRequirementGetData();
        }

        private void SpecialRequirement_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SPRequirementFillData(e.Result as DataTable);
        }


        #endregion

        private void dgvContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = e.RowIndex;
                EditContact(e.RowIndex, e);
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = e.RowIndex;
                EditAddress(id, e);
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
                
        private void cmbType_Leave(object sender, EventArgs e)
        {
            if (cmbType.SelectedText != Helper.DropdownDefaultText.Select)
            {
                cmbCategory.Focus();
            }

            cmbType.DroppedDown = false;
        }

        private void lnkbtnAddNewType_LinkClicked(object sender, EventArgs e)
        {

        }

        //private void lnkbtnAddNewType_LinkClicked(object sender, EventArgs e)
        //{
        //    txtType.Visible = true;
        //    cmbType.Enabled = false;

        //    lnkbtnAddNewType.Visible = false;
        //    // lnkbtnAddNewCategory.Visible = true;

        //    if (txtCategory.Text == "")
        //    {
        //        txtCategory.Visible = false;
        //        lnkbtnAddNewCategory.Visible = true;
        //        cmbCategory.Enabled = true;
        //    }
        //    txtType.Focus();
        //}
                
        private void cmbState_Enter(object sender, EventArgs e)
        {
            cmbState.DroppedDown = true;
        }

        private void cmbState_Leave(object sender, EventArgs e)
        {
            cmbState.DroppedDown = false;
        }
                
        private void cmbCity_Leave(object sender, EventArgs e)
        {
            cmbCity.DroppedDown = false;
        }
                
        private void txtCustomerName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtPersonName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void txtContact_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void cmbType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
                
        private void cmbState_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbState_SelectionChangeCommitted(sender, e);
            }
        }
   
        private void cmbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;

        }

        private void cmbCountry_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbCountry_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbCity_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void cmbCity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbCity_SelectionChangeCommitted(sender, e);
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }
             
        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }

        private void cmbCategory_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbCategory_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbType_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbType_SelectionChangeCommitted(sender, e);
            }
        }

        private void dgvAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 0)        //Code For Update Button OF Grid View
                {
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                    {

                        EditAddress(e.RowIndex, e);
                    }
                }

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 1)        //Code For Update Button OF Grid View
                {

                    int result = 0;

                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (DeleteAddress(e.RowIndex))
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnAddress.Text = Helper.ButtonCaptions.Add;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvContact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 0)        //Code For Update Button OF Grid View
                {
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                    {

                        EditContact(e.RowIndex, e);
                    }
                }

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 1)        //Code For Update Button OF Grid View
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        id = e.RowIndex;
                        Guid Contact_Id;
                        clsCustomerMaster customerMaster = new clsCustomerMaster();
                        if (dgvContact.Rows[e.RowIndex].Cells["ContactId"].Value != null && dgvContact.Rows[e.RowIndex].Cells["ContactId"].ToString() != "")
                        {
                            Contact_Id = Guid.Parse(dgvContact.Rows[e.RowIndex].Cells["ContactId"].Value.ToString());
                            customerMaster.ContactId = Contact_Id;

                            if (Contact_Id != Guid.Empty)
                            {
                                _CustomerSupplierInputParameters.lbldeleteContact.Text = _CustomerSupplierInputParameters.lbldeleteContact.Text + ",'" + Contact_Id + "'";
                            }
                        }
                        dgvContact.Rows.RemoveAt(e.RowIndex);
                        //if (DeleteContact(e.RowIndex))
                        //{
                        //    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Deletedone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    btnAddContact.Text = Helper.ButtonCaptions.Add;
                        //}
                        //else
                        //{
                        //    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }

        private void btnCancelContact_Leave(object sender, EventArgs e)
        {
            txtPersonName.Focus();
        }

        private void btnCancelAddress_Leave(object sender, EventArgs e)
        {
            //txtStreet.Focus();
        }
                
        private void txtStreet_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void txtPersonName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
                
        private void tabDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
                
        private void cmbCustomerGroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbCustomerGroup_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbCustomerGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }

        private void cmbCityBank_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbCityBank_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbCityBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {
                Fill_StateBank(Convert.ToInt32(cmbCityBank.SelectedValue));
            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }

        private void cmbStateBank_SelectionChangeCommitted(object sender, EventArgs e)
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
                    Fill_CountryBank(Convert.ToInt32(cmbStateBank.SelectedValue));
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

        private void cmbCountryBank_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            cmbCountry_SelectionChangeCommitted(sender, e);
        }

        private void cmbCountryBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.Text == "")
            {
                cmb.Text = Helper.DropdownDefaultText.Select;
            }
            if (cmb.SelectedValue != null)
            {

            }
            else
                cmb.Text = Helper.DropdownDefaultText.Select;
        }
  
        private void dgvBankDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvBankDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgvBankDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        if (dgvBankDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                        {
                            if (dgvBankDetails.Rows[e.RowIndex].Cells["BankId"] != null)
                            {


                                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {

                                    dgvBankDetails.Rows.RemoveAt(e.RowIndex);
                                }
                            }
                            btnadd.Text = "Add";
                        }


                        else if (dgvBankDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                        {
                            RawId = e.RowIndex;
                            clsBankMaster bankname = new clsBankMaster();
                            DataTable dtBankName = new DataTable();
                            dtBankName = bankname.FetchBankDetail();
                            cmbBankName.DataSource = dtBankName;
                            cmbBankName.DisplayMember = "BankName";
                            cmbBankName.ValueMember = "BankId";

                            cmbBankName.SelectedValue = dgvBankDetails.Rows[e.RowIndex].Cells["BankId"].Value.ToString();
                            txtBranchName.Text = dgvBankDetails.Rows[e.RowIndex].Cells["Branchname"].Value.ToString();
                            txtAccNo.Text = dgvBankDetails.Rows[e.RowIndex].Cells["Accno"].Value.ToString();
                            txtIFSCNo.Text = dgvBankDetails.Rows[e.RowIndex].Cells["IFSCNo"].Value.ToString();
                            txtMICRCode.Text = dgvBankDetails.Rows[e.RowIndex].Cells["MICRNo"].Value.ToString();
                            if (dgvBankDetails.Rows[e.RowIndex].Cells["CityId"] != null && dgvBankDetails.Rows[e.RowIndex].Cells["CityId"].Value.ToString() != "")
                            {
                                if (dgvBankDetails.Rows[e.RowIndex].Cells["CityId"].Value != null && dgvBankDetails.Rows[e.RowIndex].Cells["CityId"].Value.ToString() != "")
                                    cmbCityBank.SelectedValue = dgvBankDetails.Rows[e.RowIndex].Cells["CityId"].Value.ToString();
                                if (cmbCityBank.SelectedValue != null)
                                {
                                    Fill_StateBank(Convert.ToInt32(cmbCityBank.SelectedValue));
                                    if (dgvBankDetails.Rows[e.RowIndex].Cells["StateId"].Value != null && dgvBankDetails.Rows[e.RowIndex].Cells["StateId"].Value.ToString() != "")
                                        cmbStateBank.SelectedValue = dgvBankDetails.Rows[e.RowIndex].Cells["StateId"].Value.ToString();
                                }
                                if (cmbStateBank.SelectedValue != null)
                                {
                                    Fill_CountryBank(Convert.ToInt32(cmbStateBank.SelectedValue));
                                    if (dgvBankDetails.Rows[e.RowIndex].Cells["CountryId"].Value != null && dgvBankDetails.Rows[e.RowIndex].Cells["CountryId"].Value.ToString() != "")
                                        cmbCountryBank.SelectedValue = dgvBankDetails.Rows[e.RowIndex].Cells["CountryId"].Value.ToString();
                                }
                            }

                            btnadd.Text = Helper.ButtonCaptions.Update;

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
                     
        #region CustomerMasterTestingCharges

        #region BackGroundWorker

        #region SpRequirementGetData

        private DataTable SpRequirementGetData()
        {
            ClsSPRequirement sprequirement = new ClsSPRequirement();
            DataTable dtSpRequirement = new DataTable();
            dtSpRequirement = sprequirement.FetchSpRequirementDetail();
            dtSpRequirement.AddSelectRow(0, 2);
            return dtSpRequirement;
        }

        #endregion

        #region SpRequirementFillData
        
        private void SPRequirementFillData(DataTable dtSpRequirement)
        {
            try
            {
                if (dtSpRequirement != null && dtSpRequirement.Rows.Count > 0)
                {
                    cmbSpRequirement.DataSource = dtSpRequirement;
                    cmbSpRequirement.DisplayMember = "SPRequirement";
                    cmbSpRequirement.ValueMember = "SPRequirementID";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
                
        #endregion

        #region Function
        //This function is used to add Unit in ComboBox
        public void FetchUnit()
        {
            DataTable dtUnit = new DataTable();//Create New DataTable
            //Add Columns to DataTable
            dtUnit.Columns.Add("Id");
            dtUnit.Columns.Add("Unit");
            DataRow Unit;

            Unit = dtUnit.NewRow();
            Unit["Id"] = "1";
            Unit["Unit"] = "Per Heat";
            dtUnit.Rows.Add(Unit);

            Unit = dtUnit.NewRow();
            Unit["Id"] = "2";
            Unit["Unit"] = "Per Kg";
            dtUnit.Rows.Add(Unit);

            Unit = dtUnit.NewRow();
            Unit["Id"] = "3";
            Unit["Unit"] = "Per Sq In.";
            dtUnit.Rows.Add(Unit);

            dtUnit.AddSelectRow(0, 1);

            cmbUnit.DataSource = dtUnit;
            cmbUnit.DisplayMember = "Unit";
            cmbUnit.ValueMember = "Id";


        }
        #endregion
        
        private void BtnAddTestingCharge_Click(object sender, EventArgs e)
        {

            DataTable dtTestingCharge = new DataTable();

            #region Condition

            if (cmbSpRequirement.SelectedValue == null || cmbSpRequirement.SelectedValue.ToString() == string.Empty || Guid.Parse(cmbSpRequirement.SelectedValue.ToString()) == Guid.Empty)
            {
                const string type = "Select requirement";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                cmbSpRequirement.Focus();
                return;
            }

            if (cmbUnit.SelectedValue == null || cmbUnit.SelectedValue.ToString() == string.Empty || Convert.ToInt32(cmbUnit.SelectedValue.ToString()) == 0)
            {
                const string type = "Select unit";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                cmbUnit.Focus();
                return;
            }

            if (txtCharge.Text == null || txtCharge.Text == string.Empty)
            {
                const string type = "Enter charges";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                txtCharge.Focus();
                return;
            }

            #endregion

            #region Requirement already exists

            if (dgvTestingCharges.Rows.Count > 0)
            {
                for (int i = 0; i < dgvTestingCharges.Rows.Count; i++)
                {
                    if (cmbSpRequirement.SelectedValue.ToString() == dgvTestingCharges.Rows[i].Cells["SpRequirementID"].Value.ToString())
                    {
                        if (BtnAddTestingCharge.Text == Helper.ButtonCaptions.Update && ID == i)
                        {
                            continue;
                        }
                        System.Windows.Forms.MessageBox.Show("Requirement already exists.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            #endregion

            if (dtTestingCharge.Columns.Count <= 0)
            {
                dtTestingCharge.Columns.Add("TestingChargeID");
                dtTestingCharge.Columns.Add("SpRequirementID");
                dtTestingCharge.Columns.Add("SpRequirement");
                dtTestingCharge.Columns.Add("EffectiveDate");
                dtTestingCharge.Columns.Add("UnitID");
                dtTestingCharge.Columns.Add("Unit");
                dtTestingCharge.Columns.Add("Charge");
            }
            DataRow drTestingCharge;

            for (int i = 0; i < dgvTestingCharges.Rows.Count; i++)
            {
                drTestingCharge = dtTestingCharge.NewRow();
                drTestingCharge["TestingChargeID"] = dgvTestingCharges.Rows[i].Cells["TestingChargeID"].Value;
                drTestingCharge["SpRequirementID"] = dgvTestingCharges.Rows[i].Cells["SpRequirementID"].Value;
                drTestingCharge["SpRequirement"] = dgvTestingCharges.Rows[i].Cells["SpRequirement"].Value;
                drTestingCharge["EffectiveDate"] = dgvTestingCharges.Rows[i].Cells["EffectiveDate"].Value;
                drTestingCharge["UnitID"] = dgvTestingCharges.Rows[i].Cells["UnitID"].Value;
                drTestingCharge["Unit"] = dgvTestingCharges.Rows[i].Cells["Unit"].Value;
                drTestingCharge["Charge"] = dgvTestingCharges.Rows[i].Cells["Charge"].Value;

                dtTestingCharge.Rows.Add(drTestingCharge);
            }

            if (BtnAddTestingCharge.Text == Helper.ButtonCaptions.Add)
            {
                drTestingCharge = dtTestingCharge.NewRow();
                drTestingCharge["TestingChargeID"] = Guid.Empty;
                drTestingCharge["SpRequirementID"] = cmbSpRequirement.SelectedValue;
                drTestingCharge["SpRequirement"] = cmbSpRequirement.Text;
                drTestingCharge["EffectiveDate"] = dtpTestingDate.Text;
                drTestingCharge["UnitID"] = cmbUnit.SelectedValue;
                drTestingCharge["Unit"] = cmbUnit.Text;
                drTestingCharge["Charge"] = txtCharge.Text;

                dtTestingCharge.Rows.Add(drTestingCharge);

            }
            else if (BtnAddTestingCharge.Text == Helper.ButtonCaptions.Update)
            {
                dtTestingCharge.Rows[ID]["SpRequirementID"] = cmbSpRequirement.SelectedValue;
                dtTestingCharge.Rows[ID]["SpRequirement"] = cmbSpRequirement.Text;
                dtTestingCharge.Rows[ID]["EffectiveDate"] = dtpTestingDate.Text;
                dtTestingCharge.Rows[ID]["UnitID"] = cmbUnit.SelectedValue;
                dtTestingCharge.Rows[ID]["Unit"] = cmbUnit.Text;
                dtTestingCharge.Rows[ID]["Charge"] = txtCharge.Text;
            }

            if (!dtTestingCharge.IsNullOrEmpty())
            {
                dgvTestingCharges.DataSource = dtTestingCharge;
            }
            ClearTestingChargesDetail();
            cmbSpRequirement.Focus();
        }

        private int ID;
        private void dgvTestingCharges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvTestingCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgvTestingCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != string.Empty)
                    {
                        if (dgvTestingCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                        {
                            if (dgvTestingCharges.Rows[id].Cells["TestingChargeID"].Value != null && dgvTestingCharges.Rows[id].Cells["TestingChargeID"].Value.ToString() != string.Empty && Guid.Parse(dgvTestingCharges.Rows[id].Cells["TestingChargeID"].Value.ToString()) != Guid.Empty)
                            {
                                clsCustomerMaster objcustomermaster = new clsCustomerMaster();
                                objcustomermaster.TestingChargeID = Guid.Parse(dgvTestingCharges.Rows[id].Cells["TestingChargeID"].Value.ToString());

                                Int32 Result = objcustomermaster.Delete_Requirement_Parameter();

                                if (Result == 1)
                                {
                                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        dgvTestingCharges.Rows.RemoveAt(e.RowIndex);
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Order is already prepared for this requirement", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    dgvTestingCharges.Rows.RemoveAt(e.RowIndex);
                                }
                            }




                            BtnAddTestingCharge.Text = Helper.ButtonCaptions.Add;
                        }


                        else if (dgvTestingCharges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                        {
                            cmbSpRequirement.Enabled = false;
                            BtnAddTestingCharge.Text = Helper.ButtonCaptions.Update;
                            ID = e.RowIndex;
                            DataTable dtSpReq = new DataTable();
                            dtSpReq = SpRequirementGetData();
                            if (!dtSpReq.IsNullOrEmpty())
                            {
                                SPRequirementFillData(dtSpReq);
                            }

                            cmbSpRequirement.SelectedValue = dgvTestingCharges.Rows[e.RowIndex].Cells["SpRequirementID"].Value;
                            dtpTestingDate.Value = Convert.ToDateTime(dgvTestingCharges.Rows[e.RowIndex].Cells["EffectiveDate"].Value);
                            FetchUnit();
                            cmbUnit.SelectedValue = dgvTestingCharges.Rows[e.RowIndex].Cells["UnitID"].Value;
                            txtCharge.Text = dgvTestingCharges.Rows[e.RowIndex].Cells["Charge"].Value.ToString();

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

        private void ClearTestingChargesDetail()
        {
            txtCharge.Text = string.Empty;
            FetchUnit();
            if (cmbSpRequirement.Items.Count > 0)
                cmbSpRequirement.SelectedIndex = 0;
            if (cmbUnit.Items.Count > 0)
                cmbUnit.SelectedIndex = 0;
            cmbSpRequirement.Enabled = true;
            BtnAddTestingCharge.Text = Helper.ButtonCaptions.Add;
            if (!bwSpecialRequirement.IsBusy)
                bwSpecialRequirement.RunWorkerAsync();
            dtpTestingDate.Text = DateTime.Now.ToString();

            FetchUnit();
        }

        #endregion
             
        private void dgvTDCDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvTDCDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgvTDCDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != string.Empty)
                    {
                        if (dgvTDCDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.DELETE)
                        {
                            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                dgvTDCDetail.Rows.RemoveAt(e.RowIndex);
                            }

                            btnaddTDCDetail.Text = Helper.ButtonCaptions.Add;
                        }
                        else if (dgvTDCDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == Helper.LinkButtonCaptions.EDIT)
                        {
                            DataTable dtFetchMetal = GetGradeData();
                            FillGradeData(dtFetchMetal);
                            btnaddTDCDetail.Text = Helper.ButtonCaptions.Update;
                            cmbGrade.Enabled = false;
                            TDCId = e.RowIndex;

                            cmbGrade.SelectedValue = dgvTDCDetail.Rows[e.RowIndex].Cells["MetalId"].Value.ToString();
                            txtTDCNo.Text = dgvTDCDetail.Rows[e.RowIndex].Cells["TDCNo"].Value.ToString();
                            lblTDCFileName.Text = dgvTDCDetail.Rows[e.RowIndex].Cells["FileName"].Value.ToString();
                            lblTDFFilePath.Text = dgvTDCDetail.Rows[e.RowIndex].Cells["FilePath"].Value.ToString();
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

        private void cmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvBankDetails.Focus();
            }
        }

        private void dgvBankDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }
        }

        private void cmbSpRequirement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvTestingCharges.Focus();
            }
        }

        private void dgvTestingCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }
        }

        private void cmbGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvTDCDetail.Focus();
            }
        }

        private void dgvTDCDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
         
    }
}