using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using TestingSystems.App_Data;
using Inventory_Management;


namespace TestingSystems
{
    public partial class Mytickets : BaseForm
    {
        string User_ID;
        string User_Type;
        string Status;
        public Int32 FullScreenOff = 0;
      
        public Mytickets(string UserID,string UserType)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            this.pagingControl1.Pagingevent += StartDataRetrievalProcess;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            this.GridMyTicket.AllowUserToAddRows = false;
            this.GridMyTicket.AutoGenerateColumns = false;
            User_ID = UserID;
            User_Type = UserType;
           
        }

        private void MyTickets_Load(object sender, EventArgs e)
        {
          AutoFitForm.SetFormToMaximize(this);
          this.ControlBox = true;
            RdbOpen.Checked = true;
            Status = "OPEN";
            GridMyTicket.AutoGenerateColumns = false;
            bindModule();
            serachData();
            this.pagingControl1.CommitProcess();
           
            
        }
        void serachData()
        {

            try
            {
                this.UsingBusyIndicator(() =>
                {
                    getTickets();
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
        void bindModule()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindModuleName();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Module_Name"] = "Select";

                dt.Rows.InsertAt(dr, 0);

                // cmbAssignTo.Items.Add("Select");
                
                cmbModuleName.ValueMember = "ID";
                cmbModuleName.DisplayMember = "Module_Name";

                cmbModuleName.DataSource = dt;



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
        #region CustomerNameFillData
        private void CustomerNameFillData(DataTable dt)
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
        #endregion
        private void bwProcessDataRetrieval_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bwProcessDataRetrieval_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            this.pagingControl1.CommitProcess();
            //if (((DataTable)e.Result) != null)
            //{
            //    if (((DataTable)e.Result).Rows.Count >= 0)
            //    {
            //        //clsDueTickets obj = new clsDueTickets();


            //        gridShowTicket.DataSource = ((DataTable)e.Result);

            //        this.gridShowTicket.AllowUserToAddRows = false;
            //        // gridShowTicket.Cells[columnIndex].Style.BackColor = Color.Red;
            //        gridShowTicket.Columns["TicketID"].Visible = false;


            //    }

            //}
            //this.pagingControl1.CommitProcess();
        }
        public override void OnShown()
        {
            #region On shown
            try
            {
                this.Refresh();
              
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
        private void bwProcessDataRetrieval_DoWork(object sender, DoWorkEventArgs e)
        {
            getTickets();
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

                dtCustomerName = CustomerNameGetData();

                getTickets();
                #endregion
            }, () =>
            {
                #region Assign data source to dropdowns

                CustomerNameFillData(dtCustomerName);

                FillGrid();
                this.pagingControl1.CommitProcess();
                #endregion
            });

        }
        #endregion
        #region CustomerNameGetData
        private DataTable CustomerNameGetData()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            return dt;
        }
        #endregion
        void getTickets()
        {
            
            clsMyTickets obj = new clsMyTickets();
            obj.User_id = User_ID;
            obj.status = Status;
            obj.TicketNumber = txtTicketNo.Text;
            if (CmbModuleID != null && CmbModuleID != String.Empty)
            {
                obj.ModuleName = CmbModuleID;
            }
            obj.pagesize = this.pagingControl1.CurrentPageSize;
            obj.PageNumber = this.pagingControl1.CurrentPageIndex;
            int TotalRecords = obj.getTotalMyTicketsRecord();
            this.pagingControl1.TotalRecords = TotalRecords;
            dtGrid = obj.GetUserTicket();
           
           //// GridMyTicket.AutoGenerateColumns = false;
           // GridMyTicket.DataSource = dt;
           // GridMyTicket.Columns["TicketID"].Visible = false;
        
        }
        private delegate void FillGrid_Delegate();
        private void FillGrid()
        {
            if (InvokeRequired)
            {
                Invoke(new FillGrid_Delegate(FillGrid));
            }
            else
            {
                GridMyTicket.AutoGenerateColumns = false;
                GridMyTicket.DataSource = dtGrid;
                GridMyTicket.Columns["TicketID"].Visible = false;
            }
        }
        private DataTable dtGrid = new DataTable();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.UsingBusyIndicator(() =>
                {
                    getTickets();

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
           
           
            //FilterTickets();
        }

       

        private void GridMyTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                if (GridMyTicket.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View Images")
                {
                    DataGridViewRow selectIndex = GridMyTicket.Rows[e.RowIndex];
                    Guid Ticket_ID = Guid.Parse(selectIndex.Cells["TicketID"].Value.ToString());
                    DataTable dtImage = new DataTable();
                    clsMyTickets obj = new clsMyTickets();
                    obj.TicketID = Convert.ToString(Ticket_ID);

                    dtImage = obj.GetImage();
                    if (dtImage.Rows.Count == 0)
                    {
                        MessageBox.Show("There is no image.");
                        return;
                    }
                    PatternImagePopup obj1 = new PatternImagePopup(dtImage);
                    obj1.ShowDialog();

                }
                else
                {
                    DataGridView Dg = (DataGridView)sender;
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        if (GridMyTicket.SelectedCells.Count > 0)
                        {
                            DataGridViewRow selectIndex = GridMyTicket.Rows[e.RowIndex];
                            Guid Ticket_ID = Guid.Parse(selectIndex.Cells["TicketID"].Value.ToString());
                            AssigneTicket obj = new AssigneTicket(Ticket_ID, User_Type, User_ID);
                            obj.ShowDialog();
                            btnSearch_Click(btnSearch, null);
                        }
                    }
                }
            }
        }

        private void RdbOpen_CheckedChanged(object sender, EventArgs e)
        {
            Status = "OPEN";
        }

        private void rdbclosed_CheckedChanged(object sender, EventArgs e)
        {
            Status = "CLOSE";
        }

        private void btnCloseMaster_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string CmbModuleID = string.Empty;
        private void cmbModuleName_SelectionChangeCommitted(object sender, EventArgs e)
        {

            CmbModuleID = cmbModuleName.SelectedValue.ToString();
            
        }

      
    }
}
