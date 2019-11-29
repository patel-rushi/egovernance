using TestingSystems.App_Data;
using TestingSystems.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems;

namespace TestingSystems
{
    public partial class ShowDetails_CustomerMaster : BaseForm //BaseForm
    {
        #region Data properties
        private int InitialLoad = 1;

        private DataTable dtCustomerName;

        private DataTable dtCustomerType;

        private DataTable dtCustomerCategoty;

        private DataTable dtGrid;

        private string CustomerName;

        private Guid CustomerId;

        private Guid CustomerTypeId_;

        DataTable dtCustomerCategory;

        private Guid CustomerCategoryId_;

        int id = 0;

        public static string flag = string.Empty;

        clsAccessMenu access_menu = new clsAccessMenu();
        #endregion

        public ShowDetails_CustomerMaster()
        {
            InitializeComponent();

            AutoFitForm.SetGroupBoxLoction(this.groupBoxMain);

            this.pagingControl1.Pagingevent += StartDataRetrievalProcess;
        }

        public override void OnShown()
        {
            #region On shown
            try
            {
                this.Refresh();
                btnClose.Text = Helper.ButtonCaptions.Close;
                this.pagingControl1.InitializeBackgroundWorker(bwProcessDataRetrieval_DoWork, bwProcessDataRetrieval_ProgressChanged, bwProcessDataRetrieval_RunWorkerCompleted);
                dgvShow.AutoGenerateColumns = false;
                InitializeData();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        #region Backgroud worker

        #region CustomerNameGetData
        private DataTable CustomerNameGetData()
        {
            clsCustomerMaster customerMaster = new clsCustomerMaster();

            customerMaster.Customer_flag = "C";

            dtCustomerName = new DataTable();

            dtCustomerName = customerMaster.Fetch_Customer_Name();

            dtCustomerName.AddSelectRow(0, 0);

            return dtCustomerName;
        }
        #endregion

        #region CustomerNameFillData
        private void CustomerNameFillData(DataTable dtCustomerName)
        {
            try
            {
                if (dtCustomerName.Rows.Count > 0)
                {
                    cmbCustomerName.DataSource = dtCustomerName;
                    cmbCustomerName.DisplayMember = "CustomerName";
                    cmbCustomerName.ValueMember = "CustomerId";
                    cmbCustomerName.Focus();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CustomerTypeGetData
        private DataTable CustomerTypeGetData()
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                dtCustomerType = customerTypeCategoryGroupMaster.Fetch_Customer_Type_Details();
                dtCustomerType.AddSelectRow(0, 2);
                return dtCustomerType;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region CustomerTypeFillData
        private void CustomerTypeFillData(DataTable dtCustomerType)
        {
            try
            {
                if (!dtCustomerType.IsNullOrEmpty())
                {
                    cmbType.DataSource = dtCustomerType;
                    cmbType.DisplayMember = "TypeName";
                    cmbType.ValueMember = "CustomerTypeId";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CustomerCategoryGetData
        private DataTable CustomerCategoryGetData()
        {
            try
            {
                clsCustomerTypeCategoryGroupMaster customerTypeCategoryGroupMaster = new clsCustomerTypeCategoryGroupMaster();
                dtCustomerCategory = customerTypeCategoryGroupMaster.Fetch_Customer_Category_Details();

                dtCustomerCategory.AddSelectRow(0, 2);
                return dtCustomerCategory;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region CustomerCategoryFillData
        private void CustomerCategoryFillData(DataTable dtCustomerCategory)
        {
            try
            {
                if (!dtCustomerCategory.IsNullOrEmpty())
                {
                    cmbCategory.DataSource = dtCustomerCategory;

                    cmbCategory.DisplayMember = "CategoryName";

                    cmbCategory.ValueMember = "CustomerCategoryId";

                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region InitializeData
        private void InitializeData()
        {
            var dtCustomerName = new DataTable();
            var dtCustomerType = new DataTable();
            var dtCustomerCategory = new DataTable();

            this.UsingBusyIndicator(() =>
            {
                #region Get data for dropdowns

                dtCustomerName = CustomerNameGetData();
                dtCustomerType = CustomerTypeGetData();
                dtCustomerCategoty = CustomerCategoryGetData();

                GetData();
                #endregion
            }, () =>
            {
                #region Assign data source to dropdowns

                CustomerNameFillData(dtCustomerName);
                CustomerTypeFillData(dtCustomerType);
                CustomerCategoryFillData(dtCustomerCategoty);

                FillGrid();
                this.pagingControl1.CommitProcess();
                #endregion
            });
        }
        #endregion
        #endregion

        #region SelectionChangeCommitted methods

        private void cmbCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
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
                    if (cmbCustomerName.SelectedValue.ToString() != "")
                    {
                        CustomerId = Guid.Parse(cmbCustomerName.SelectedValue.ToString());

                    }
                    else
                    {
                        CustomerId = Guid.Empty;
                    }
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

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue.ToString() == string.Empty || cmbCategory.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Guid.Parse(cmbCategory.SelectedValue.ToString()) == Guid.Empty)
                {
                    CustomerCategoryId_ = Guid.Empty;
                }
                else
                {
                    CustomerCategoryId_ = Guid.Parse(cmbCategory.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedValue == null || cmbType.SelectedValue.ToString() == string.Empty || cmbType.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Guid.Parse(cmbType.SelectedValue.ToString()) == Guid.Empty)
                {
                    CustomerTypeId_ = Guid.Empty;
                }
                else
                {
                    CustomerTypeId_ = Guid.Parse(cmbType.SelectedValue.ToString());
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region PreviewKeyDown methods

        private void cmbCustomerName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    cmbCustomerName_SelectionChangeCommitted(sender, e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #endregion

        #endregion

        #region Extra events

        //public override void RefreshForm()
        //{
        //    DataClear();
        //}

        public void DataClear()
        {
            //var dialogResult = MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult != DialogResult.Yes)
            //    return;

            CustomerId = Guid.Empty;

            chkStatutory.Checked = false;

            CustomerName = null;

            CustomerCategoryId_ = Guid.Empty;

            CustomerTypeId_ = Guid.Empty;

            if (cmbCustomerName.Items.Count > 0)
            {
                cmbCustomerName.SelectedIndex = 0;
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }
            InitializeData();
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                var senderGrid = (DataGridView)sender;

                if (e.RowIndex >= 0 && e.ColumnIndex >= -1)
                {
                    if (e.ColumnIndex == 2 || e.ColumnIndex == -1)   //Code For Show Address and Contact Details     
                    {
                        getdetailsother(e.RowIndex);
                    }
                }
            }

            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getdetailsother(int RowIndex)
        {
            try
            {
                clsCustomerMaster customerMaster = new clsCustomerMaster();
                customerMaster.Customer_Id = Guid.Parse(dgvShow.Rows[RowIndex].Cells["Customer_Id"].Value.ToString());

                if (rdbAddress.Checked)
                {
                    DataTable dtAddress = customerMaster.Fetch_Customer_Address();
                    dgvOtherDetails.DataSource = dtAddress;

                    if (dgvOtherDetails.Columns.Contains("ViewImages"))
                        dgvOtherDetails.Columns["ViewImages"].Visible = false;
                    try
                    {
                        if (dgvOtherDetails.Columns.Contains("CityId"))
                        dgvOtherDetails.Columns["CityId"].Visible = false;
                        if (dgvOtherDetails.Columns.Contains("CountryName"))
                        dgvOtherDetails.Columns["CountryName"].Visible = false;
                        if (dgvOtherDetails.Columns.Contains("StateCode"))
                        dgvOtherDetails.Columns["StateCode"].Visible = false;
                        if (dgvOtherDetails.Columns.Contains("CountryId"))
                        dgvOtherDetails.Columns["CountryId"].Visible = false;
                    }
                    catch
                    { }
                }
                if (rdbContact.Checked)
                {
                    DataTable dtContact = customerMaster.Fetch_Customer_Contact_Details();
                    dgvOtherDetails.DataSource = dtContact;

                    if (dgvOtherDetails.Columns.Contains("ViewImages"))
                        dgvOtherDetails.Columns["ViewImages"].Visible = false;

                    if (dgvOtherDetails.Columns.Contains("ContactId"))
                        dgvOtherDetails.Columns["ContactId"].Visible = false;
                    try
                    {
                        if (dgvOtherDetails.Columns.Contains("ContactId"))
                            dgvOtherDetails.Columns["ContactId"].Visible = false;                       
                    }
                    catch
                    { }

                }
                if (rdbBank.Checked)
                {
                    DataTable dtBank = customerMaster.Fetch_Data_From_BankDetails();
                    dgvOtherDetails.DataSource = dtBank;

                    if (dgvOtherDetails.Columns.Contains("ViewImages"))
                        dgvOtherDetails.Columns["ViewImages"].Visible = false;
                }
                //var applicationConfiguration = TestingSystems.Helpers.ConfigurationHelper.GetApplicationConfiguration();
                //if (applicationConfiguration.SpecialRequirement)
                //{
                //    if (rdbTestingCharge.Checked)
                //    {
                //        DataTable dtTestingCharge = customerMaster.FetchTestingChargeDetail();
                //        dgvOtherDetails.DataSource = dtTestingCharge;
                //    }

                //    if (dgvOtherDetails.Columns.Contains("ViewImages"))
                //        dgvOtherDetails.Columns["ViewImages"].Visible = false;
                //}

                //if (applicationConfiguration.TDCDetail)
                //{
                //    if (rbtnTDCDetail.Checked)
                //    {
                //        DataTable dtTDCDetail = customerMaster.Fetch_TDDetail();
                //        dgvOtherDetails.DataSource = dtTDCDetail;

                //        if (dgvOtherDetails.Columns.Contains("TDCId"))
                //            dgvOtherDetails.Columns["TDCId"].Visible = false;
                //        if (dgvOtherDetails.Columns.Contains("MetalId"))
                //            dgvOtherDetails.Columns["MetalId"].Visible = false;
                //        if (dgvOtherDetails.Columns.Contains("FilePath"))
                //            dgvOtherDetails.Columns["FilePath"].Visible = false;
                //        if (dgvOtherDetails.Columns.Contains("FileName"))
                //            dgvOtherDetails.Columns["FileName"].Visible = false;

                //        if (dgvOtherDetails.Columns.Contains("ViewImages"))
                //            dgvOtherDetails.Columns["ViewImages"].Visible = true;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShow_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            id = e.RowIndex;
            getdetailsother(e.RowIndex);
        }

        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsCustomerMaster customrMaster = new clsCustomerMaster();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var senderGrid = (DataGridView)sender;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 0)            //Code For Update Button OF Grid View
                    {
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                        {
                            try
                            {

                                var CustomerSupplierInputParameters = new CustomerMaster(new CustomerSupplierInputParameters(Enums.FormMode.Edit) { CustomerId = Guid.Parse(dgvShow.Rows[e.RowIndex].Cells["Customer_Id"].Value.ToString()) });
                                
                                //if Customer Master is already open then it close first 
                                if (Application.OpenForms.OfType<CustomerMaster>().Count() == 1)
                                    Application.OpenForms.OfType<CustomerMaster>().First().Close();

                                CustomerMaster customerMaster = CustomerSupplierInputParameters;

                                customerMaster.MdiParent = this.ParentForm;
                                customerMaster.Show();
                                customerMaster.Focus();
                              
                                //((MDIParent)this.MdiParent).FormLoadEdit(MenuHelper.MenuIdentityCodes.CUSTOMERMASTER, CustomerSupplierInputParameters);

                            }
                            catch (Exception ex)
                            {

                                ExceptionHandler.LogException(ex);
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    else if (senderGrid.Rows[e.RowIndex].Cells["Delete"].Value.ToString() == Helper.LinkButtonCaptions.Block && e.ColumnIndex == 1)     //Code For Delete Button Of Grid View       
                    {
                        if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.BlockConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            customrMaster.Customer_Id = Guid.Parse(dgvShow.Rows[e.RowIndex].Cells["Customer_Id"].Value.ToString());             // Passing Customer Id to clsCustomerMaster
                            customrMaster.Is_Deleted = 1;                                                             //Set value for Delete from table "1" is flagged variable
                            var session = Session.Get();

                            customrMaster.DeletedBy = session.UserId;

                            customrMaster.DeletedOn = System.DateTime.Now;

                            customrMaster.EntityId = session.EntityID;

                            int Result = 0;

                            Result = customrMaster.Delete_From_CustomerMaster();

                            if (Result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Blockdone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StartDataRetrievalProcess();

                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.BlockError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                StartDataRetrievalProcess();
                            }
                        }
                    }

                    else if (senderGrid.Rows[e.RowIndex].Cells["Delete"].Value.ToString() == Helper.LinkButtonCaptions.UnBlock && e.ColumnIndex == 1)     //Code For Unblock Button      
                    {
                        var session = Session.Get();
                        customrMaster.Customer_Id = Guid.Parse(dgvShow.Rows[e.RowIndex].Cells["Customer_Id"].Value.ToString());             // Passing Customer Id to clsCustomerMaster

                        customrMaster.Is_Deleted = 0;                                                             //Set value for Delete from table "1" is flagged variable

                        customrMaster.DeletedBy = session.UserId;

                        customrMaster.DeletedOn = System.DateTime.Now;

                        customrMaster.EntityId = session.EntityID;

                        //SuperLogin sprLgn = new SuperLogin();

                        //sprLgn.ShowInTaskbar = false;
                        //sprLgn.ShowDialog();

                        int Result = 0;
                        int AdminAccess = 0;
                        AdminAccess = clsValues.Instance.AdminAccess;
                        if (AdminAccess == 1)
                        {
                            Result = customrMaster.UnBlock_From_CustomerMaster();

                            if (Result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Unblockeddone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StartDataRetrievalProcess();

                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UnblockedError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                StartDataRetrievalProcess();
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

        private void Searching()
        {
            try
            {

                clsCustomerMaster customerMaster = new clsCustomerMaster();

                customerMaster.Customer_flag = "C";

                if (cmbCategory.SelectedText != "" || cmbCategory.Text != Helper.DropdownDefaultText.Select)
                {
                    customerMaster.Customer_Category = cmbCategory.SelectedValue.ToString();
                }

                if (cmbType.SelectedText != "" || cmbType.Text != Helper.DropdownDefaultText.Select)
                {
                    customerMaster.Customer_Type = cmbType.SelectedValue.ToString();
                }

                if (cmbCustomerName.SelectedValue != null && cmbCustomerName.SelectedValue.ToString() != "")
                {
                    customerMaster.Customer_Id = Guid.Parse(cmbCustomerName.SelectedValue.ToString());
                }

                DataTable dtCustomer = customerMaster.Fetch_Customer_Details();

                if (dtCustomer.Rows.Count > 0)
                {
                    dgvShow.DataSource = dtCustomer;
                    dgvShow.Columns["Customer_Id"].Visible = false;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Details not available", "Combination mismatched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Grid data retrival methods

        private void GetData()
        {
            try
            {
                dtGrid = new DataTable();

                clsCustomerMaster customerMaster = new clsCustomerMaster();

                customerMaster.Customer_flag = "C";

                if (CustomerId != null && CustomerId != Guid.Empty)
                {
                    customerMaster.Customer_Id = CustomerId;
                }
                if (CustomerTypeId_ != null && CustomerTypeId_ != Guid.Empty)
                {
                    customerMaster.CustomerTypeId = CustomerTypeId_;
                }
                if (CustomerCategoryId_ != null && CustomerCategoryId_ != Guid.Empty)
                {
                    customerMaster.CustomerCategoryId = CustomerCategoryId_;
                }

                customerMaster.PageNumber = this.pagingControl1.CurrentPageIndex;

                customerMaster.PageSize = this.pagingControl1.CurrentPageSize;

                customerMaster.InitialLoad = InitialLoad;

                dtGrid = customerMaster.Fetch_Customer_Details_Id();

                Int32 TotalRecords = customerMaster.Fetch_Total_CustomerRecords();

                this.pagingControl1.TotalRecords = TotalRecords;


                InitialLoad = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private delegate void FillGrid_Delegate();
        private void FillGrid()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new FillGrid_Delegate(FillGrid));
                }
                else
                {
                    dgvShow.DataSource = dtGrid;
                    if (dtGrid != null)
                    {
                        foreach (DataGridViewRow row in dgvShow.Rows)
                        {
                            DataGridViewCell cell1 = (DataGridViewCell)row.Cells["Revise"]; //Column Index for the dataGridViewButtonColumn
                            DataGridViewLinkCell cell = (DataGridViewLinkCell)row.Cells["Delete"]; //Column Index for the dataGridViewButtonColumn
                            
                            if ((row.Cells["IsDeleted"].Value.ToString() != string.Empty)
                                && (Convert.ToInt32(row.Cells["IsDeleted"].Value.ToString()) == 1))
                            {
                                row.DefaultCellStyle.ForeColor = Color.Gray;

                                row.DefaultCellStyle.Font = new Font(dgvShow.DefaultCellStyle.Font, FontStyle.Strikeout);
                                cell1.Value = null;
                                cell1 = new DataGridViewTextBoxCell();
                                cell.Style.Font = new Font(dgvShow.DefaultCellStyle.Font, FontStyle.Regular);
                                cell.ReadOnly = false;
                                cell.Value = Helper.LinkButtonCaptions.UnBlock;
                            }
                            else
                            {
                                cell.ReadOnly = false;
                                cell.Value = Helper.LinkButtonCaptions.Block;

                                cell1.ReadOnly = false;
                                cell1.Value = Helper.LinkButtonCaptions.EDIT;
                            }

                        }
                        if (dgvShow.Columns.Contains("Customer_Id"))
                            dgvShow.Columns["Customer_Id"].Visible = false;
                        if (dgvShow.Rows.Count > 0)
                            dgvShow.Rows[0].Selected = true;
                        if (dgvShow.Columns.Contains("Revise"))
                            dgvShow.Columns["Revise"].Visible = access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.CUSTOMERREGISTER);
                        if (dgvShow.Columns.Contains("Delete"))
                            dgvShow.Columns["Delete"].Visible = access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.CUSTOMERREGISTER);
                    }




                    clsCustomLabelText objCustomLabelText = new clsCustomLabelText();
                    DataTable dsLabels = objCustomLabelText.Fetch_CustomLabelText();
                    if (dgvShow.Columns.Contains("TaxNo1"))
                        dgvShow.Columns["TaxNo1"].HeaderText = dsLabels.Rows[0]["TaxNo1"].ToString();
                    if (dgvShow.Columns.Contains("TaxNo2"))
                        dgvShow.Columns["TaxNo2"].HeaderText = dsLabels.Rows[0]["TaxNo2"].ToString();
                    if (dgvShow.Columns.Contains("TaxNo3"))
                        dgvShow.Columns["TaxNo3"].HeaderText = dsLabels.Rows[0]["TaxNo3"].ToString();
                    if (dgvShow.Columns.Contains("TaxNo4"))
                        dgvShow.Columns["TaxNo4"].HeaderText = dsLabels.Rows[0]["TaxNo4"].ToString();
                    if (dgvShow.Columns.Contains("TaxNo5"))
                        dgvShow.Columns["TaxNo5"].HeaderText = dsLabels.Rows[0]["TaxNo5"].ToString();


                    //var applicationConfiguration = TestingSystems.Helpers.ConfigurationHelper.GetApplicationConfiguration();

                    //if (!applicationConfiguration.SpecialRequirement)
                    //{
                    //    rdbTestingCharge.Visible = false;
                    //}
                    //if (!applicationConfiguration.TDCDetail)
                    //{
                    //    rbtnTDCDetail.Visible = false;
                    //}

                    //if (rbtnTDCDetail.Checked)
                    //{
                    //    if (dgvOtherDetails.Columns.Contains("ViewImages"))
                    //        dgvOtherDetails.Columns["ViewImages"].Visible = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void StartDataRetrievalProcess()
        {
            try
            {

                if (!this.pagingControl1.bwProcessDataRetrieval.IsBusy)
                {
                    this.pagingControl1.bwProcessDataRetrieval.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwProcessDataRetrieval_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwProcessDataRetrieval_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        private void bwProcessDataRetrieval_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                FillGrid();
                this.pagingControl1.CommitProcess();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CheckedChanged methods

        private void rdbAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAddress.Checked)
                getdetailsother(id);
        }

        private void rdbContact_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbContact.Checked)
                getdetailsother(id);
        }

        private void rdbBank_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBank.Checked)
                getdetailsother(id);
        }

        private void rdbTestingCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTestingCharge.Checked)
                getdetailsother(id);
        }

        private void rbtnTDCDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTDCDetail.Checked)
                getdetailsother(id);
        }

        #endregion

        #region Click methods

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.UsingBusyIndicator(() =>
            {
                GetData();

            }, () =>
            {
                FillGrid();
                this.pagingControl1.CommitProcess();
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DataClear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                String Filters = "";
                String Statutory = "";
                if (chkStatutory.Checked)
                    Statutory = "1";
                else
                    Statutory = "0";
                if (CustomerId != null && CustomerId != Guid.Empty)
                {
                    Filters += "Customer Name : " + cmbCustomerName.Text;
                }

                if (cmbCategory.SelectedValue != null && cmbCategory.SelectedValue.ToString() != string.Empty &&
                    cmbCategory.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbCategory.SelectedValue.ToString()) != Guid.Empty)
                {
                    Filters += " Customer Category : " + cmbCategory.Text;
                }

                if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != string.Empty &&
                    cmbType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbType.SelectedValue.ToString()) != Guid.Empty)
                {
                    Filters += " Customer Type : " + cmbType.Text;
                }

                dtGrid = new DataTable();
                //Reports objReports = new Reports();

                //objReports.CustomerID = CustomerId;
                //objReports.CustomerCategoryId = Guid.Parse(cmbCategory.SelectedValue.ToString());
                //objReports.Customerflag = "C";
                //objReports.CustomerTypeId = Guid.Parse(cmbType.SelectedValue.ToString());

                //dtGrid = objReports.CustomerDetailExcel();

                clsCustomLabelText objCustomLabelText = new clsCustomLabelText();
                DataTable dsLabels = objCustomLabelText.Fetch_CustomLabelText();

                List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();
                listDatatable.Add(new KeyValuePair<DataTable, string>(dtGrid, "DataSet1"));

                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("Filters", Filters));
                list.Add(new KeyValuePair<string, string>("TaxNo1Text", dsLabels.Rows[0]["TaxNo1"].ToString()));
                list.Add(new KeyValuePair<string, string>("TaxNo2Text", dsLabels.Rows[0]["TaxNo2"].ToString()));
                list.Add(new KeyValuePair<string, string>("TaxNo3Text", dsLabels.Rows[0]["TaxNo3"].ToString()));
                list.Add(new KeyValuePair<string, string>("TaxNo4Text", dsLabels.Rows[0]["TaxNo4"].ToString()));
                list.Add(new KeyValuePair<string, string>("TaxNo5Text", dsLabels.Rows[0]["TaxNo5"].ToString()));
                list.Add(new KeyValuePair<string, string>("Statutory", Statutory.ToString()));

                //CUS Code is used in ISO and ReportName both tables. If you want to change then you have to change in both tables
                //DownloadReports report = new DownloadReports(@"reports/CustomerDetailExcelReport.rdlc", "CUS", false, listDatatable, list);
                //report.Show();

            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBankDetail_Click(object sender, EventArgs e)
        {

            clsCustomerMaster customerMaster = new clsCustomerMaster();
            String Filters = "";
            //if (CustomerId != null && CustomerId != Guid.Empty)
            //{
            //    Filters += "Customer Name : " + cmbCustomerName.Text;
            //    customerMaster.Customer_Id = Guid.Parse(cmbCustomerName.SelectedValue.ToString());
            //}

            //if (cmbCategory.SelectedValue != null && cmbCategory.SelectedValue.ToString() != string.Empty &&
            //        cmbCategory.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbCategory.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Category : " + cmbCategory.Text;
            //    customerMaster.Customer_Category = cmbCategory.Text;

            //}

            //if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != string.Empty &&
            //         cmbType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbType.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Type : " + cmbType.Text;
            //    customerMaster.Customer_Type = cmbType.Text;
            //}
            if (CustomerId != null && CustomerId != Guid.Empty)
            {
                Filters += "Customer Name : " + cmbCustomerName.Text;
                customerMaster.Customer_Id = CustomerId;
            }
            if (CustomerTypeId_ != null && CustomerTypeId_ != Guid.Empty)
            {
                Filters += " Customer Ind. Type : " + cmbType.Text;
                customerMaster.CustomerTypeId = CustomerTypeId_;
            }
            if (CustomerCategoryId_ != null && CustomerCategoryId_ != Guid.Empty)
            {
                Filters += " Customer Category : " + cmbCategory.Text;
                customerMaster.CustomerCategoryId = CustomerCategoryId_;
            }

            DataTable dt = new DataTable();

            //Reports objReports = new Reports();
            //objReports.CustomerID = CustomerId;
            //objReports.CustomerCategoryId = CustomerCategoryId_;
            //objReports.Customerflag = "C";
            //objReports.CustomerTypeId = CustomerTypeId_;

            //dt = objReports.FetchCustomerBankDetail();

            List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();

            listDatatable.Add(new KeyValuePair<DataTable, string>(dt, "BankDetail"));

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Filters", Filters));

            //CBD Code is used in ISO and ReportName both tables. If you want to change then you have to change in both tables
            //DownloadReports report = new DownloadReports(@"reports/CustomerBankDetailReport.rdlc", "CBD", false, listDatatable, list);
            //report.Show();
        }

        #endregion

        private void dgvOtherDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsCustomerMaster customrMaster = new clsCustomerMaster();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var senderGrid = (DataGridView)sender;

                    if (dgvOtherDetails.Columns[e.ColumnIndex].Name == "ViewImages")
                    {
                        clsCustomerMaster objcustomermaster = new clsCustomerMaster();
                        objcustomermaster.TDCId = Guid.Parse(dgvOtherDetails.Rows[e.RowIndex].Cells["TDCId"].Value.ToString());
                        DataTable dtImage = new DataTable();
                        dtImage = objcustomermaster.Fetch_FileNameByTDC();
                        if (dtImage.Rows.Count == 0)
                        {
                            MessageBox.Show("There is no image.");
                            return;
                        }

                        TDCImagePopup objTDCImage = new TDCImagePopup(dtImage);
                        objTDCImage.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddressDetail_Click(object sender, EventArgs e)
        {
            clsCustomerMaster customerMaster = new clsCustomerMaster();
            String Filters = "";
            //if (CustomerId != null && CustomerId != Guid.Empty)
            //{
            //    Filters += "Customer Name : " + cmbCustomerName.Text;
            //    customerMaster.Customer_Id = Guid.Parse(cmbCustomerName.SelectedValue.ToString());
            //}

            //if (cmbCategory.SelectedValue != null && cmbCategory.SelectedValue.ToString() != string.Empty &&
            //        cmbCategory.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbCategory.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Category : " + cmbCategory.Text;
            //    customerMaster.Customer_Category = cmbCategory.Text;

            //}

            //if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != string.Empty &&
            //         cmbType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbType.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Type : " + cmbType.Text;
            //    customerMaster.Customer_Type = cmbType.Text;
            //}
            if (CustomerId != null && CustomerId != Guid.Empty)
            {
                Filters += "Customer Name : " + cmbCustomerName.Text;
                customerMaster.Customer_Id = CustomerId;
            }
            if (CustomerTypeId_ != null && CustomerTypeId_ != Guid.Empty)
            {
                Filters += " Customer Type : " + cmbType.Text;
                customerMaster.CustomerTypeId = CustomerTypeId_;
            }
            if (CustomerCategoryId_ != null && CustomerCategoryId_ != Guid.Empty)
            {
                Filters += " Customer Category : " + cmbCategory.Text;
                customerMaster.CustomerCategoryId = CustomerCategoryId_;
            }

            DataTable dt = new DataTable();

            //Reports objReports = new Reports();
            //objReports.CustomerID = CustomerId;
            //objReports.CustomerCategoryId = CustomerCategoryId_;
            //objReports.Customerflag = "C";
            //objReports.CustomerTypeId = CustomerTypeId_;

            //dt = objReports.FetchCustomerAddressDetail();

            List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();

            listDatatable.Add(new KeyValuePair<DataTable, string>(dt, "AddressDetail"));

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Filters", Filters));
            list.Add(new KeyValuePair<string, string>("CustomerFlag", "C"));

            //CBD Code is used in ISO and ReportName both tables. If you want to change then you have to change in both tables
            //DownloadReports report = new DownloadReports(@"reports/CustomerAddressDetailReport.rdlc", "CAD", false, listDatatable, list);
            //report.Show();
        }

        private void btnContactDetail_Click(object sender, EventArgs e)
        {
            clsCustomerMaster customerMaster = new clsCustomerMaster();
            String Filters = "";
            //if (CustomerId != null && CustomerId != Guid.Empty)
            //{
            //    Filters += "Customer Name : " + cmbCustomerName.Text;
            //    customerMaster.Customer_Id = Guid.Parse(cmbCustomerName.SelectedValue.ToString());
            //}

            //if (cmbCategory.SelectedValue != null && cmbCategory.SelectedValue.ToString() != string.Empty &&
            //        cmbCategory.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbCategory.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Category : " + cmbCategory.Text;
            //    customerMaster.Customer_Category = cmbCategory.Text;

            //}

            //if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != string.Empty &&
            //         cmbType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbType.SelectedValue.ToString()) != Guid.Empty)
            //{
            //    Filters += " Customer Type : " + cmbType.Text;
            //    customerMaster.Customer_Type = cmbType.Text;
            //}
            if (CustomerId != null && CustomerId != Guid.Empty)
            {
                Filters += "Customer Name : " + cmbCustomerName.Text;
                customerMaster.Customer_Id = CustomerId;
            }
            if (CustomerTypeId_ != null && CustomerTypeId_ != Guid.Empty)
            {
                Filters += " Customer Type : " + cmbType.Text;
                customerMaster.CustomerTypeId = CustomerTypeId_;
            }
            if (CustomerCategoryId_ != null && CustomerCategoryId_ != Guid.Empty)
            {
                Filters += " Customer Category : " + cmbCategory.Text;
                customerMaster.CustomerCategoryId = CustomerCategoryId_;
            }

            DataTable dt = new DataTable();

            //Reports objReports = new Reports();
            //objReports.CustomerID = CustomerId;
            //objReports.CustomerCategoryId = CustomerCategoryId_;
            //objReports.Customerflag = "C";
            //objReports.CustomerTypeId = CustomerTypeId_;

            //dt = objReports.FetchCustomerContactDetail();

            List<KeyValuePair<DataTable, string>> listDatatable = new List<KeyValuePair<DataTable, string>>();

            listDatatable.Add(new KeyValuePair<DataTable, string>(dt, "ContactDetail"));

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Filters", Filters));
            list.Add(new KeyValuePair<string, string>("CustomerFlag", "C"));

            //CBD Code is used in ISO and ReportName both tables. If you want to change then you have to change in both tables
            //DownloadReports report = new DownloadReports(@"reports/CustomerContactDetailReport.rdlc", "CCD", false, listDatatable, list);
            //report.Show();
        }

       


    }
}



