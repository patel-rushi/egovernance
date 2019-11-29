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

using System.Data.SqlClient;

namespace TestingSystems
{
    public partial class DuesTicket : BaseForm
    {


        string Status = "";
        string UserName;
        string UserType;
        int Assigned;
        public Int32 FullScreenOff = 0;
        public Int32 tickettype = 0;


        public DuesTicket(string User_Name, string User_Type)
        {

            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            this.pagingControl2.Pagingevent += StartDataRetrievalProcess;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            UserName = User_Name;
            UserType = User_Type;



        }
        private void StartDataRetrievalProcess()
        {
            try
            {

                if (!this.pagingControl2.bwProcessDataRetrieval.IsBusy)
                {
                    this.pagingControl2.bwProcessDataRetrieval.RunWorkerAsync();
                }

            }
            catch (Exception ex)
            {


                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DuesTicket_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            this.ControlBox = true;
            bindClient();


            cmbstatus.Text = "Select";
            cmbtype.Text = "Select";
            cmbassign.Text = "Select";


            Status = "ALL";
            Assigned = -1;
            tickettype = -1;

            gridShowTicket.AutoGenerateColumns = false;

            btnSearch_Click(btnSearch, null);

        }
        void bindClient()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
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

                        cmbName.ValueMember = "CustomerId";
                        cmbName.DisplayMember = "CustomerName";
                        cmbName.DataSource = dt;

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

        private void label1_Click(object sender, EventArgs e)
        {

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

                GetData();
                #endregion
            }, () =>
            {
                #region Assign data source to dropdowns

                CustomerNameFillData(dtCustomerName);

                FillGrid();
                this.pagingControl2.CommitProcess();
                #endregion
            });

        }

        private void GetData()
        {
            try
            {

                clsDueTickets obj = new clsDueTickets();
                obj.status = Status;
                obj.Assigned = Assigned;
                obj.ticketType = tickettype;


                if (ClientName != Guid.Empty)
                    obj.ClientName = ClientName;
                obj.FromDate = dtFrom.Value.ToString();
                obj.ToDate = dtTo.Value.ToString();

                obj.pagesize = this.pagingControl2.CurrentPageSize;
                obj.PageNumber = this.pagingControl2.CurrentPageIndex;

                TotalRecord = obj.getTotalRecord();

                this.pagingControl2.TotalRecords = TotalRecord;
                dtGrid = new DataTable();
                dtGrid = obj.GetData();
                if (dtGrid != null)
                {
                    dtt = dtGrid;
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private DataTable dtGrid = new DataTable();

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
                    if (dtGrid != null)
                        gridShowTicket.DataSource = dtGrid;
                    this.gridShowTicket.AllowUserToAddRows = false;
                    // gridShowTicket.Cells[columnIndex].Style.BackColor = Color.Red;
                    gridShowTicket.Columns["TicketID"].Visible = false;
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion


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

            clsDueTickets obj1 = new clsDueTickets();

            obj1.status = Status;
            if (cmbName.SelectedValue.ToString() != string.Empty)
                obj1.ClientName = Guid.Parse(cmbName.SelectedValue.ToString());
            obj1.FromDate = dtFrom.Value.ToString();
            obj1.ToDate = dtTo.Value.ToString();
            DataTable dt = obj1.GetData();
            gridShowTicket.DataSource = dt;
            this.gridShowTicket.AllowUserToAddRows = false;
            gridShowTicket.Columns["TicketID"].Visible = false;
            this.pagingControl2.CommitProcess();

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
                    this.pagingControl2.CommitProcess();
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

        #region Old Code
        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void all_1_Click(object sender, EventArgs e)
        {
            Status = "ALL";
        }
        private void all_1_CheckedChanged(object sender, EventArgs e)
        {

        }*/
        #endregion

        private void gridShowTicket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            #region Old Code
            /*if (UserType != "DEVELOPER")
            {
                DataGridView objsender = (DataGridView)sender;

                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    if (gridShowTicket.SelectedCells.Count > 0)
                    {

                        DataGridViewRow selectrow = gridShowTicket.Rows[e.RowIndex];
                        Guid TicketId = Guid.Parse(selectrow.Cells["TicketID"].Value.ToString());
                        string AssignedName = selectrow.Cells["AssignedTo"].Value.ToString();
                        clsDueTickets obj1 = new clsDueTickets();
                        obj1.Ticket_ID = TicketId;

                        if (obj1.checkAssignTicket() > 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Ticket assigned Can't Change.");
                        }
                        else
                        {
                            if (gridShowTicket.Columns[e.ColumnIndex].HeaderText == "Edit Ticket")
                            {
                                
                                
                                NewTicket obj = new NewTicket(TicketId);
                                obj.MdiParent = this.ParentForm;
                            
                                obj.Show();

                            }
                            else if (gridShowTicket.Columns[e.ColumnIndex].HeaderText == "Delete Ticket")
                            {

                                clsDueTickets obj = new clsDueTickets();
                                obj.Ticket_ID = TicketId;
                                if (obj.Deleteticket() > 0)
                                {
                                    System.Windows.Forms.MessageBox.Show("Ticket Deleted.");
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show("Ticket cant't Delete.");
                                }


                            }
                            else
                            {
                              
                                    GetDueTickets();
                                    AssigneTicket obj = new AssigneTicket(TicketId, UserType, UserName);
                                    obj.Show();




                            }
                            
                        }

                    }
                }
            }
                else
                {

                    System.Windows.Forms.MessageBox.Show("You Don't Have Permission. ");


                }

                btnSearch_Click(btnSearch, null);*/

            #endregion
        }
        int TotalRecord = 0;
        void gettotalRecords()
        {
            clsDueTickets obj = new clsDueTickets();

            obj.status = Status;
            obj.ticketType = tickettype;
            obj.Assigned = Assigned;

            if (ClientName != Guid.Empty)
                obj.ClientName = ClientName;
            obj.FromDate = dtFrom.Value.ToString();
            obj.ToDate = dtTo.Value.ToString();
            obj.pagesize = this.pagingControl2.CurrentPageSize;
            obj.PageNumber = this.pagingControl2.CurrentPageIndex;
            TotalRecord = obj.getTotalRecord();


        }

        public override void OnShown()
        {
            #region On shown
            try
            {
                this.Refresh();
                setdate();
                this.pagingControl2.InitializeBackgroundWorker(bwProcessDataRetrieval_DoWork, bwProcessDataRetrieval_ProgressChanged, bwProcessDataRetrieval_RunWorkerCompleted);
                InitializeData();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        DataTable dtt;

        private void BwGetDuetickets_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // gettotalRecords();
                clsDueTickets obj = new clsDueTickets();
                obj.status = Status;
                obj.ticketType = tickettype;
                obj.Assigned = Assigned;

                if (ClientName != Guid.Empty)
                    obj.ClientName = ClientName;
                obj.FromDate = dtFrom.Value.ToString();
                obj.ToDate = dtTo.Value.ToString();

                obj.pagesize = this.pagingControl2.CurrentPageSize;
                obj.PageNumber = this.pagingControl2.CurrentPageIndex;

                TotalRecord = obj.getTotalRecord();

                this.pagingControl2.TotalRecords = TotalRecord;

                DataTable dt = obj.GetData();
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

        }

        private void BwGetDuetickets_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (((DataTable)e.Result) != null)
            {
                if (((DataTable)e.Result).Rows.Count >= 0)
                {


                    gridShowTicket.DataSource = ((DataTable)e.Result);

                    this.gridShowTicket.AllowUserToAddRows = false;

                    gridShowTicket.Columns["TicketID"].Visible = false;

                }

            }
            this.pagingControl2.CommitProcess();
        }

        Guid ClientName = Guid.Empty;
        private void cmbName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbName_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbName.SelectedIndex > 0)
            {
                if (Guid.Parse(cmbName.SelectedValue.ToString()) != Guid.Empty)
                    ClientName = Guid.Parse(cmbName.SelectedValue.ToString());
            }
            else
            {
                ClientName = Guid.Empty;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void clear()
        {
            cmbName.SelectedIndex = -1;
            setdate();

            cmbassign.Text = "Select";
            cmbstatus.Text = "Select";
            cmbtype.Text = "Select";



        }
        private void btnclear_Click(object sender, EventArgs e)
        {

            clear();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                int aS=-1;

                if(string.Equals(cmbassign.Text,"Assigned"))
                {
                    aS=1;
                }
                else if(string.Equals(cmbassign.Text,"Not Assigned"))
                {
                    aS=0;
                }
                int ty=-1;

                string s="";
                string cname="ALL";
                if(cmbstatus.SelectedIndex >0)
                {
                    s=cmbstatus.SelectedItem.ToString();
                }
                Guid c=Guid.Empty;
                if(cmbName.SelectedIndex > 0)
                {
                    c=Guid.Parse(Convert.ToString(cmbName.SelectedValue));
                    cname=cmbName.Text;
                }

                if(cmbtype.Text=="Bug")
                {
                    ty=0;
                }
                else if(cmbtype.Text=="New requirement")
                {
                    ty =1;
                }
                else if(cmbtype.Text =="Training")
                {
                    ty=2;
                }

                string df=dtFrom.Value.Date.ToString("yyyy-MM-dd");
                string dt=dtTo.Value.Date.ToString("yyyy-MM-dd");

                 ReportDueTickets objduetickets = new ReportDueTickets(c,cname,s,aS,ty,df,dt);
                 objduetickets.Show();
            }
            catch(Exception ex)
            { 
                string s=ex.Message.ToString();
            }
        }
           
        

        private void bwProcessDataRetrieval_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();

        }

        private void bwProcessDataRetrieval_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillGrid();
            this.pagingControl2.CommitProcess();

        }

        private void bwProcessDataRetrieval_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void btnCloseMaster_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Old Code
        /*
        private void rdbBug_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBug.Checked)
            {
                rdbBug.Checked = true;
                RdbNewReq.Checked = false;
                training.Checked = false;
                all_3.Checked = false;
                tickettype = 0;
            }
        }

        private void RdbNewReq_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbNewReq.Checked)
            {
                RdbNewReq.Checked = true;
                rdbBug.Checked = false;
                training.Checked = false;
                all_3.Checked = false;
                tickettype = 1;
            }
        }
        #region Rushi's Code
        private void training_CheckedChanged(object sender, EventArgs e)
        {
            if (training.Checked)
            {
                training.Checked = true;
                RdbNewReq.Checked = false;
                rdbBug.Checked = false;
                all_3.Checked = false;
                tickettype = 2;
            }
        }

        private void all_3_CheckedChanged(object sender, EventArgs e)
        {
            if(all_3.Checked)
            {
                all_3.Checked = true;
                training.Checked = false;
                RdbNewReq.Checked = false;
                rdbBug.Checked = false;
                tickettype = -1;
            }
        }

        private void assigned_CheckedChanged(object sender, EventArgs e)
        {
            if(assigned.Checked)
            {
                notassigned.Checked = false;
                all_2.Checked = false;
                Assigned = 1;
            }
        }

        private void notassigned_CheckedChanged(object sender, EventArgs e)
        {
            if (notassigned.Checked)
            {
                assigned.Checked = false;
                all_2.Checked = false;
                Assigned = 0;
            }

        }

        private void all_2_CheckedChanged(object sender, EventArgs e)
        {
            if (all_2.Checked)
            {
                notassigned.Checked = false;
                assigned.Checked = false;
                Assigned = -1;
            }
        }
        #endregion
        private void RdbOpen_CheckedChanged(object sender, EventArgs e)
        {

        }
        */
        #endregion
        DataGridViewCellEventArgs ex = null;
        DataGridViewRow myselectrow;
        int count = 0;
        private void gridShowTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ex = e;
                myselectrow = gridShowTicket.Rows[e.RowIndex];
            }
            catch { }
        }

        int getSelectedRow()
        {
            count = 0;
            for (int i = 0; i < gridShowTicket.RowCount; i++)
            {
                if (Convert.ToBoolean(gridShowTicket.Rows[i].Cells[0].Value) == true)
                {
                    count++;
                }
            }
            return count;
        }

        //================================================================== Rushi's Code ======================================================================
        #region Rushi's CODE

        private void assign_Click(object sender, EventArgs e)
        {

            if (UserType != "DEVELOPER")
            {

                var myrows = gridShowTicket.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["select"].Value) == true).ToList();
                if (myrows.Count > 0)
                {
                    for (int i = 0; i < myrows.Count; i++)
                    {
                        if (Convert.ToBoolean(gridShowTicket.Rows[myrows[i].Index].Cells[0].Value) == true)
                        {
                            myselectrow = gridShowTicket.Rows[myrows[i].Index];
                            Guid TicketId = Guid.Parse(myselectrow.Cells["TicketID"].Value.ToString());
                            string AssignedName = myselectrow.Cells["AssignedTo"].Value.ToString();
                            clsDueTickets obj1 = new clsDueTickets();
                            obj1.Ticket_ID = TicketId;

                            if (obj1.checkAssignTicket() == 1)
                            {
                                System.Windows.Forms.MessageBox.Show("Ticket already assigned");
                            }
                            else
                            {

                                GetDueTickets();
                                AssigneTicket obj = new AssigneTicket(TicketId, UserType, UserName);
                                obj.Show();
                                obj.Focus();
                            }
                        }
                    }
                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("Select a row to assign");
                }
            }
            else { System.Windows.Forms.MessageBox.Show("You Don't Have Permission. "); }

            btnSearch_Click(btnSearch, null);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (UserType != "DEVELOPER")
            {
                //DataGridView objsender = (DataGridView)sender;


                if (getSelectedRow() > 1)
                {
                    MessageBox.Show("Multiple Tickets Can't be edited !");
                }
                else
                {
                    if (ex != null)
                    {
                        for (int i = 0; i < gridShowTicket.RowCount; i++)
                        {
                            if (Convert.ToBoolean(gridShowTicket.Rows[i].Cells[0].Value) == true)
                            {
                                if (gridShowTicket.SelectedCells.Count > 0)
                                {
                                    myselectrow = gridShowTicket.Rows[i];
                                    Guid TicketId = Guid.Parse(myselectrow.Cells["TicketID"].Value.ToString());
                                    string AssignedName = myselectrow.Cells["AssignedTo"].Value.ToString();
                                    clsDueTickets obj1 = new clsDueTickets();
                                    obj1.Ticket_ID = TicketId;

                                    if (obj1.checkAssignTicket() > 0)
                                    {
                                        System.Windows.Forms.MessageBox.Show("Ticket assigned Can't be edited");
                                    }
                                    else
                                    {
                                        NewTicket obj = new NewTicket(TicketId);
                                        obj.MdiParent = this.ParentForm;

                                        obj.Show();

                                    }
                                }
                            }
                        }

                    }
                    else { System.Windows.Forms.MessageBox.Show("Select a row to edit"); }

                }
            }

            else { System.Windows.Forms.MessageBox.Show("You Don't Have Permission. "); }

            btnSearch_Click(btnSearch, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (UserType != "DEVELOPER")
            {
                //DataGridView objsender = (DataGridView)sender;

                if (ex != null)
                {

                    if (gridShowTicket.SelectedCells.Count > 0)
                    {
                        for (int i = 0; i < gridShowTicket.RowCount; i++)
                        {
                            if (Convert.ToBoolean(gridShowTicket.Rows[i].Cells[0].Value) == true)
                            {
                                myselectrow = gridShowTicket.Rows[i];
                                Guid TicketId = Guid.Parse(myselectrow.Cells["TicketID"].Value.ToString());
                                string AssignedName = myselectrow.Cells["AssignedTo"].Value.ToString();
                                clsDueTickets obj1 = new clsDueTickets();
                                obj1.Ticket_ID = TicketId;

                                if (obj1.checkAssignTicket() > 0)
                                {
                                    /*CustomMessageBox msg = new CustomMessageBox();
                                    msg.Show();
                                    msg.Focus();
                                    
                                    if(msg.returnvalue==0)
                                    { 
                                        
                                    }
                                    else
                                    { msg.Close(); }*/
                                    System.Windows.Forms.MessageBox.Show("Ticket assigned can't be deleted");
                                }
                                else
                                {

                                    clsDueTickets obj = new clsDueTickets();
                                    obj.Ticket_ID = TicketId;
                                    if (obj.Deleteticket() > 0)
                                    {

                                        System.Windows.Forms.MessageBox.Show("Ticket Deleted.");
                                    }
                                    else
                                    {
                                        System.Windows.Forms.MessageBox.Show("Ticket cant't Delete.");
                                    }
                                }
                            }
                        }

                    }
                }
                else { System.Windows.Forms.MessageBox.Show("Select a row to delete"); }
            }
            else { System.Windows.Forms.MessageBox.Show("You Don't Have Permission. "); }

            btnSearch_Click(btnSearch, null);
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (string.Compare(Convert.ToString(cmbtype.Text), "Bug") == 0)
            {
                tickettype = 0;
            }
            else if (string.Compare(Convert.ToString(cmbtype.Text), "New requirement") == 0)
            {
                tickettype = 1;
            }
            else if (String.Equals(cmbtype.Text, "Training"))
            {
                tickettype = 2;
            }
            else if (String.Equals(cmbtype.Text, "Select"))
            {
                tickettype = -1;
            }
        }

        private void cmbassign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.Equals(cmbassign.Text, "Select"))
            {
                Assigned = -1;
            }

            else if (String.Equals(cmbassign.Text, "Assigned"))
            {
                Assigned = 1;
            }
            else if (String.Equals(cmbassign.Text, "Not Assigned"))
            {
                Assigned = 0;
            }
        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.Compare(cmbstatus.Text, "Select") == 0)
            {
                Status = "ALL";
            }
            else
            {
                Status = cmbstatus.Text;
            }
        }

        private void pagingControl2_Load(object sender, EventArgs e)
        {

        }
    }
        #endregion
    //=================================================================================================================================================
}
