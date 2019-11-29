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

namespace TestingSystems
{
    public partial class ApprovedTickets : Form
    {
        public Int32 FullScreenOff = 0;
        public ApprovedTickets()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            this.GridApproved.AutoGenerateColumns = false;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
      

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

       

        private void BtnSearch_Click(object sender, EventArgs e)
        {


            if (!bwApprovedTicket.IsBusy)
                bwApprovedTicket.RunWorkerAsync();
            this.pagingControl1.CommitProcess();
        }
        void bindClient()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if(dt!=null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbUseName.ValueMember = "UserID";
                    cmbUseName.DisplayMember = "UserName";

                    cmbUseName.DataSource = dt;


                }
            }
        }
        private void ApprovedTickets_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            bindClient();
            if (!bwApprovedTicket.IsBusy)
                bwApprovedTicket.RunWorkerAsync();
            this.pagingControl1.CommitProcess();
           
        }

        private void bgApprovedTicket_DoWork(object sender, DoWorkEventArgs e)
        {
      
           
            try
            {
              
                clsApprovedTicket obj = new clsApprovedTicket();

                if (Username != string.Empty)
                    obj.User_id = Username;
                obj.FromDate = dtFrom.Value.ToString();
                obj.ToDate = dtTo.Value.ToString();
                obj.pagesize = this.pagingControl1.CurrentPageSize;
                obj.PageNumber = this.pagingControl1.CurrentPageIndex;
                DataTable dt = obj.GetApprovedTickets();
                int TotalRecord = obj.getTotalApprovedRecord();
                this.pagingControl1.TotalRecords = TotalRecord;
                if (dt != null)
                {
                    e.Result = dt;
                }
            }
            catch
            {

            }


        
        }

        private void bgApprovedTicket_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (((DataTable)e.Result) != null)
            {
                if (((DataTable)e.Result).Rows.Count >= 0)
                {
                    this.GridApproved.AllowUserToAddRows = false;
                    GridApproved.DataSource = (DataTable)e.Result;

                    this.GridApproved.AllowUserToAddRows = false;
                    this.pagingControl1.CommitProcess();
                }
            }
        }
        string Username="";
       


       

        private void cmbUseName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbUseName_SelectionChangeCommitted_1(sender, e);
            }
        }

        private void cmbUseName_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            Username = cmbUseName.SelectedValue.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bindClient();
        }

        private void btnCloseMaster_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
