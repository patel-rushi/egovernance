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

namespace TestingSystems
{
    public partial class TicketsApproval : BaseForm
    {
        
        string User_ID;
        string User_Type;
        public Int32 FullScreenOff = 0;
        public TicketsApproval(string UserID, string UserType)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            this.GridApproval.AutoGenerateColumns = false;
            this.pagingControl1.Pagingevent += StartDataRetrievalProcess;
             AutoFitForm.SetGroupBoxLoction(groupBox1);
            User_ID = UserID;
            User_Type = UserType;
          ;
        }
         DataTable tdGrid = new DataTable();
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
        #region CustomerNameGetData
        private DataTable CustomerNameGetData()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            return dt;
        }
        #endregion

        #region CustomerNameFillData
        private void CustomerNameFillData(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["CustomerName"] = "Select";

                        dt.Rows.InsertAt(dr, 0);

                        // cmbAssignTo.Items.Add("Select");

                        //cmbName.ValueMember = "CustomerId";
                        //cmbName.DisplayMember = "CustomerName";
                        //cmbName.DataSource = dt;

                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bwProcessDataRetrieval_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void bwProcessDataRetrieval_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadApprovalTickets();
        }
        private void bwProcessDataRetrieval_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            this.pagingControl1.CommitProcess();
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
        #endregion
        void serachData()
        {

            try
            {
                this.UsingBusyIndicator(() =>
                {
                    LoadApprovalTickets();
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
        private void TicketsApproval_Load(object sender, EventArgs e)
        {
            serachData();
            AutoFitForm.SetFormToMaximize(this);
            this.pagingControl1.CommitProcess();
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

                LoadApprovalTickets();
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
        private delegate void FillGrid_Delegate();
     private void FillGrid()
        {
         
                if (InvokeRequired)
                {
                    Invoke(new FillGrid_Delegate(FillGrid));
                }
                else
                {
           if (tdGrid != null)
            {
                this.GridApproval.AllowUserToAddRows = false;
                GridApproval.DataSource = tdGrid;
           
            GridApproval.Columns["TicketID"].Visible = false;
            this.GridApproval.AllowUserToAddRows = false;
            this.pagingControl1.CommitProcess();
     
     
       }
         }
     }
       
        void LoadApprovalTickets()
        {

            clsTicketApproval obj = new clsTicketApproval();
            obj.pagesize = this.pagingControl1.CurrentPageSize;
            obj.PageNumber = this.pagingControl1.CurrentPageIndex;
            obj.User_id = Constants.UserAssignId;
            
         int  TotalRecord = obj.getTotalApprovalRecord();

            this.pagingControl1.TotalRecords = TotalRecord;
           tdGrid = obj.GetApprovalData();
            //if (dt != null)
            //{
            //    this.GridApproval.AllowUserToAddRows = false;
            //    GridApproval.DataSource = dt;
           
            //GridApproval.Columns["TicketID"].Visible = false;
            //this.GridApproval.AllowUserToAddRows = false;
            //this.pagingControl1.CommitProcess();
            }
        
        
        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
       

        private void GridApproval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(GridApproval);
        }

        private void GridApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
                DataGridView objsender = (DataGridView)sender;
                 if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        if (e.ColumnIndex >= 0)
                        {
                            if (GridApproval.Columns[e.ColumnIndex].HeaderText == "Completed")
                            {
                                if (GridApproval.SelectedCells.Count > 0)
                                {
                                    DataGridViewRow selectrow = GridApproval.Rows[e.RowIndex];
                                    Guid TicketId = Guid.Parse(selectrow.Cells["TicketID"].Value.ToString());
                                    string ApproveStatus = selectrow.Cells["ApprovalStatus"].Value.ToString();
                                    clsTicketApproval obj = new clsTicketApproval();
                                    obj.Ticket_id = TicketId;
                                    obj.User_id = User_ID;
                                    if (ApproveStatus == "Approved")
                                    {

                                        System.Windows.Forms.MessageBox.Show("Ticket Already Approved.");
                                    }
                                    else
                                    {
                                        if (obj.ApproveTicket() > 0)
                                        {

                                            System.Windows.Forms.MessageBox.Show("Ticket Approved.");
                                            serachData();
                                        }

                                    }


                                }
                            }
                            else
                            {

                                if (GridApproval.SelectedCells.Count > 0)
                                {
                                    DataGridViewRow selectrow = GridApproval.Rows[e.RowIndex];
                                    Guid TicketId = Guid.Parse(selectrow.Cells["TicketID"].Value.ToString());
                                    string ApproveStatus = selectrow.Cells["ApprovalStatus"].Value.ToString();
                                    clsTicketApproval obj = new clsTicketApproval();
                                    obj.Ticket_id = TicketId;
                                    obj.User_id = User_ID;
                                    if (ApproveStatus == "Approved")
                                    {

                                        System.Windows.Forms.MessageBox.Show("Ticket Already Approved.");
                                    }
                                    else
                                    {
                                        if (obj.NotApproved() > 0)
                                        {

                                            System.Windows.Forms.MessageBox.Show("Ticket Not Approve.");
                                            LoadApprovalTickets();
                                        }

                                    }


                                }
                            
                            
                            }

                        }

                    }

                
                

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
