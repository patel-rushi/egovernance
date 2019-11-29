using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using TestingSystems.App_Data;
using TestingSystems.Helpers;

using System.Data.SqlClient;

namespace TestingSystems
{
    public partial class ShowDetailsDuesTicket : BaseForm
    {


        string Status = "";
        string UserName;
        string UserType;
        public Int32 FullScreenOff = 0;

        public ShowDetailsDuesTicket(String UserID, String User_Type)
        {

            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            UserName = UserID;
            UserType = User_Type;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            this.pagingControl1.Pagingevent += StartDataRetrievalProcess;
            if (Convert.ToInt32(UserName) == 1)
            {
                bindClient();
            }
            else
            {
                cmbUserName.Visible = false;
                lblUserName.Visible = false;
                // bindClient();

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
        void bindClient()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbUserName.ValueMember = "ID";
                    cmbUserName.DisplayMember = "UserName";

                    cmbUserName.DataSource = dt;


                }
            }
        }
        public override void OnShown()
        {
            #region On shown
            try
            {
                this.Refresh();
                setdate();
                this.pagingControl1.InitializeBackgroundWorker(bwProcessDataRetrieval_DoWork, bwProcessDataRetrieval_ProgressChanged, bwProcessDataRetrieval_RunWorkerCompleted);
                InitializeData();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        private void bwProcessDataRetrieval_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            this.pagingControl1.CommitProcess();
        }
        private void bwProcessDataRetrieval_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bwProcessDataRetrieval_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }
        #region InitializeData
        private void InitializeData()
        {
            var dtCustomerName = new DataTable();
            var dtJOType = new DataTable();
            var dtCastingCode = new DataTable();
            var dtCastingName = new DataTable();

            this.UsingBusyIndicator(() =>
            {
                #region Get data for dropdowns

                dtCustomerName = getCLientDetails();

                GetData();
                #endregion
            }, () =>
            {
                #region Assign data source to dropdowns
                bindClient(dtCustomerName);
                if (UserType == "ADMIN")
                {
                    bindTicketNumber(UserType, "");
                }
                else
                {
                    bindTicketNumber("", Constants.UserAssignId);
                }
                FillGrid();
                this.pagingControl1.CommitProcess();
                #endregion
            });

        }
        #endregion
        protected DataTable getCLientDetails()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            return dt;
        }
        #region CustomerNameGetData
        private DataTable CustomerNameGetData()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            return dt;
        }
        #endregion
        DataTable dtGrid = new DataTable();
        private void GetData()
        {
            clsWorkReport obj = new clsWorkReport();

            if (ClientName != Guid.Empty)
                obj.ClientName = ClientName;

            obj.FromDate = Convert.ToDateTime(dtFrom.Value.ToString());
            obj.ToDate = Convert.ToDateTime(dtTo.Value.ToString());
            obj.pagesize = this.pagingControl1.CurrentPageSize;
            obj.PageNumber = this.pagingControl1.CurrentPageIndex;
            obj.TicketNumber = TicketNo;

            if (UserID > 0)
            {
                obj.UserName = UserID;
            }
            else
            {
                obj.UserName = Convert.ToInt32(UserName);
            }
            int TotalRecords = obj.getTotalRecord();

            this.pagingControl1.TotalRecords = TotalRecords;
            dtGrid = obj.GetWorkData();


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
                    gridShowTicket.DataSource = dtGrid;
                    this.gridShowTicket.AllowUserToAddRows = false;
                    // gridShowTicket.Cells[columnIndex].Style.BackColor = Color.Red;
                    this.pagingControl1.CommitProcess();
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void startDataRetrivingProcess()
        {
            btnSearch_Click(btnSearch, null);
        }
        private void DuesTicket_Load(object sender, EventArgs e)
        {
            this.ControlBox = true;
            
            AutoFitForm.SetFormToMaximize(this);
            InitializeData();

            gridShowTicket.AutoGenerateColumns = false;

            btnSearch_Click(btnSearch, null);





        }
        void bindClient(DataTable dt)
        {


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbName.ValueMember = "CustomerId";
                    cmbName.DisplayMember = "CustomerName";
                    cmbName.DataSource = dt;

                }

            }

        }
        //void bindTicketNumber()
        //{

        //    clsWorkReport obj = new clsWorkReport();
        //    obj.UserType = "";
        //    obj.Assigned = Constants.UserAssignId;
        //    DataTable dt = obj.GetTicketNumberForRPT();
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {

        //            dt.AddSelectRow(1, 0);
        //            cmbTicketNumber.ValueMember = "Ticket_ID";
        //            cmbTicketNumber.DisplayMember = "TicketNumber";
        //            cmbTicketNumber.DataSource = dt;

        //        }

        //    }

        //}
        void bindTicketNumber(string UserType, string AssignedId)
        {

            clsWorkReport obj = new clsWorkReport();
            obj.UserID = Convert.ToInt32(UserName);
            if (UserType == "ADMIN")
            {
                obj.UserType = UserType;
            }
            else
            {
                obj.UserType = "";
            }

            if (AssignedId != "")
            {
                obj.Assigned = AssignedId;
            }
            else
            {
                obj.Assigned = "";
            }
            DataTable dt = obj.GetTicketNumberForRPT();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    dt.AddSelectRow(1, 0);
                    cmbTicketNumber.ValueMember = "Ticket_ID";
                    cmbTicketNumber.DisplayMember = "TicketNumber";
                    cmbTicketNumber.DataSource = dt;

                }

            }

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        //public override void OnShown()
        //{
        //    #region On shown
        //    try
        //    {
        //        this.Refresh();              
        //        setdate();
        //    }
        //    catch 
        //    {
        //      }
        //    #endregion
        //}




        #region Setdate

        public void setdate()
        {
            try
            {
                int Year = DateTime.Now.Date.AddMonths(-3).Year;
                DateTime parsedDate = new DateTime(Year, 4, 1);
                DateTime ToparsedDate = new DateTime(Year + 1, 3, 31);
                dtFrom.Value = parsedDate;
                dtTo.Value = ToparsedDate;
            }
            catch
            {

            }
        }

        #endregion


        void GetDueTickets()
        {

            clsDueTickets obj = new clsDueTickets();

            obj.status = Status;
            if (cmbName.SelectedValue.ToString() != string.Empty)
                obj.ClientName = Guid.Parse(cmbName.SelectedValue.ToString());
            obj.FromDate = dtFrom.Value.ToString();
            obj.ToDate = dtTo.Value.ToString();
            DataTable dt = obj.GetData();
            gridShowTicket.DataSource = dt;
            this.gridShowTicket.AllowUserToAddRows = false;
            gridShowTicket.Columns["TicketID"].Visible = false;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            try
            {
                this.UsingBusyIndicator(() =>
                {
                    GetData();

                }, () =>
                {
                    FillGrid();
                    this.pagingControl1.CommitProcess();
                });
                //if (!BwGetDuetickets.IsBusy)
                //    {
                //        BwGetDuetickets.RunWorkerAsync();
                //    }

            }
            catch 
            {

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RdbOpen_Click(object sender, EventArgs e)
        {
            Status = "OPEN";
        }

        private void rdbclosed_Click(object sender, EventArgs e)
        {
            Status = "CLOSE";
        }


        private void gridShowTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {





        }



        DataTable dtt;

        private void BwGetDuetickets_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                clsWorkReport obj = new clsWorkReport();

                if (ClientName != Guid.Empty)
                    obj.ClientName = ClientName;
                obj.FromDate = Convert.ToDateTime(dtFrom.Value.ToString());
                obj.ToDate = Convert.ToDateTime(dtTo.Value.ToString());
                obj.pagesize = this.pagingControl1.CurrentPageSize;
                obj.PageNumber = this.pagingControl1.CurrentPageIndex;
                obj.TicketNumber = TicketNo;
                int TotalRecords = obj.getTotalRecord();
                this.pagingControl1.TotalRecords = TotalRecords;
                DataTable dt = obj.GetWorkData();
                if (dt != null)
                {
                    e.Result = dt;
                    dtt = dt;
                }
                e.Result = dt;
            }
            catch 
            {


            }
            //gridShowTicket.DataSource = dt;
            //this.gridShowTicket.AllowUserToAddRows = false;
            //gridShowTicket.Columns["Ticket_ID"].Visible = false;
        }

        private void BwGetDuetickets_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (((DataTable)e.Result) != null)
            {
                if (((DataTable)e.Result).Rows.Count >= 0)
                {
                    //clsDueTickets obj = new clsDueTickets();

                    gridShowTicket.DataSource = ((DataTable)e.Result);
                    this.gridShowTicket.AllowUserToAddRows = false;
                    // gridShowTicket.Cells[columnIndex].Style.BackColor = Color.Red;
                    this.pagingControl1.CommitProcess();


                }

            }
        }


        Guid ClientName = Guid.Empty;
        string TicketNo = "";
        private void cmbName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbName_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Guid.Parse(cmbName.SelectedValue.ToString()) != Guid.Empty)
                    ClientName = Guid.Parse(cmbName.SelectedValue.ToString());
            }
            catch
            {
                ClientName = Guid.Empty;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void clear()
        {

            setdate();




        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
            InitializeData();
            bindClient();
            UserID = 0;
            ClientName = Guid.Empty;
            //if (!BwGetDuetickets.IsBusy)
            //{
            //    BwGetDuetickets.RunWorkerAsync();
            //}

            if (UserType == "ADMIN")
            {
                bindTicketNumber(UserType, "");
            }
            else
            {
                bindTicketNumber("", Constants.UserAssignId);
            }
            this.pagingControl1.CommitProcess();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {


            //ReportDueTickets objduetickets = new ReportDueTickets(dtt);
            //objduetickets.Show();
        }

        private void pagingControl1_Load(object sender, EventArgs e)
        {

        }
        int UserID = 0;
        private void cmbUserName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserName.SelectedValue.ToString() != "Select" && cmbUserName.SelectedValue.ToString() != string.Empty)
                {
                    UserID = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                    clsWorkReport obj = new clsWorkReport();
                    obj.UserID = UserID;
                    obj.UserType = "OTHER";
                    DataTable dt = obj.GetTicketNumberForRPT();

                    string s = Convert.ToString(dt.Rows[0][0]);
                    bindTicketNumber("", s);
                }
                else
                {
                    if (UserType == "ADMIN")
                    {
                        bindTicketNumber(UserType, "");
                    }
                    else
                    {
                        bindTicketNumber("", Constants.UserAssignId);
                    }
                }
            }
            catch
            {
                UserID = 0;
                if (UserType == "ADMIN")
                {
                    bindTicketNumber(UserType, "");
                }
                else
                {
                    bindTicketNumber("", Constants.UserAssignId);
                }
            }

        }

        private void cmbTicketNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTicketNumber.SelectedIndex > 0)
            {
                TicketNo = cmbTicketNumber.Text.ToString();
            }
            else
            {
                TicketNo = "";
            }

        }
    }
}
