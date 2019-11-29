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
    public partial class LeaveApplicationRegister : Form
    {
        DataRow dr;
        DataTable dt = new DataTable();
        public Int32 FullScreenOff = 0;

        public LeaveApplicationRegister()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        void bindtable()
        {
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add("UserName");
                dt.Columns.Add("From Date");
                dt.Columns.Add("<==");
                dt.Columns.Add("To Date");
                dt.Columns.Add("<--");
                dt.Columns.Add("Description");
                dt.Columns.Add("Status");
                dt.Columns.Add("Paid");

            }


        }
        void bindUserName()
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

                    

                    UserName.ValueMember = "ID";
                    UserName.DisplayMember = "UserName";

                    UserName.DataSource = dt;

                    Status.Text = "Select";
                }
            }
        }
       
        private void LeaveApplicationRegister_Load(object sender, EventArgs e)
        {
            
            bindUserName();
            
            AutoFitForm.SetFormToMaximize(this);
            
        }

        DataGridViewRow myselectrow;

        private void Approve_Click(object sender, EventArgs e)
        {
            var myrows = DGV.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["select"].Value) == true).ToList();
            if (myrows.Count > 0)
            {
                for (int i = 0; i < myrows.Count; i++)
                {
                    if (Convert.ToBoolean(DGV.Rows[myrows[i].Index].Cells[0].Value) == true)
                    {
                        myselectrow = DGV.Rows[myrows[i].Index];
                        String UserName = Convert.ToString(myselectrow.Cells["UserName"].Value);
                        DateTime FromDate = Convert.ToDateTime(myselectrow.Cells["From Date"].Value);
                        DateTime ToDate = Convert.ToDateTime(myselectrow.Cells["To Date"].Value);
                        clsLeaveApplication obj = new clsLeaveApplication();

                        obj.UserName = UserName;
                        obj.FromDate = FromDate;
                        obj.ToDate = ToDate;
                        if(Paid.Checked)
                        {
                            obj.Paid = 1;
                        }
                        else { obj.Paid = 0; }


                        if (obj.Approved()== 1)
                        {
                            System.Windows.Forms.MessageBox.Show("Leave Approved !");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Some Error ! Call Your Developer.");

                        }
                    }
                }
            }
            else
            {

                System.Windows.Forms.MessageBox.Show("Select a row");
            }

            LeaveApplicationRegister_Load(sender, e);

        }

        private void NotApprove_Click(object sender, EventArgs e)
        {
            var myrows = DGV.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["select"].Value) == true).ToList();
            if (myrows.Count > 0)
            {
                for (int i = 0; i < myrows.Count; i++)
                {
                    if (Convert.ToBoolean(DGV.Rows[myrows[i].Index].Cells[0].Value) == true)
                    {
                        myselectrow = DGV.Rows[myrows[i].Index];
                        String UserName = Convert.ToString(myselectrow.Cells["UserName"].Value);
                        DateTime FromDate = Convert.ToDateTime(myselectrow.Cells["From Date"].Value);
                        DateTime ToDate = Convert.ToDateTime(myselectrow.Cells["To Date"].Value);
                        clsLeaveApplication obj = new clsLeaveApplication();

                        obj.UserName = UserName;
                        obj.FromDate = FromDate;
                        obj.ToDate = ToDate;
                        
                        if (obj.NotApproved() == 1)
                        {
                            System.Windows.Forms.MessageBox.Show("Leave UnApproved !");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Some Error ! Call Your Developer.");

                        }
                    }
                }
            }
            else
            {

                System.Windows.Forms.MessageBox.Show("Select a row");
            }

            LeaveApplicationRegister_Load(sender, e);
        }

        void bindData()
        {
            clsLeaveApplication obj = new clsLeaveApplication();
            bindtable();
            dt.Clear();

            if (UserName.Text == "Select")
            { obj.User_ID = ""; }
            else { obj.User_ID = UserName.SelectedValue.ToString(); }

            if (Status.Text == "Select")
            { obj.Status = ""; }
            else { obj.Status = Status.Text; }

            obj.FromDate = Convert.ToDateTime(FromDate.Value.ToString());
            obj.ToDate = Convert.ToDateTime(ToDate.Value.ToString());

            DataTable clsdt = new DataTable();
            clsdt.Clear();
            clsdt = obj.GetForAdmin();

            for (int i = 0; i < clsdt.Rows.Count; i++)
            {

                dr = dt.NewRow();
                dr["UserName"] = Convert.ToString(clsdt.Rows[i]["UserName"]);
                dr["From Date"] = Convert.ToDateTime(clsdt.Rows[i]["FromDate"]);
                if (Convert.ToInt32(clsdt.Rows[i]["FirstDay_Half"]) == 1)
                { dr["<=="] = " (HALF) "; }

                dr["To Date"] = Convert.ToDateTime(clsdt.Rows[i]["ToDate"]);

                if (Convert.ToInt32(clsdt.Rows[i]["LastDay_Half"]) == 1)
                { dr["<--"] = " (HALF) "; }


                dr["Description"] = clsdt.Rows[i]["Descripation"].ToString();
                dr["Status"] = clsdt.Rows[i]["Status"].ToString();

                if (Convert.ToInt32(clsdt.Rows[i]["Paid"]) == -1)
                { dr["Paid"] = "Pending"; }

                else if (Convert.ToInt32(clsdt.Rows[i]["Paid"]) == 0)
                { dr["Paid"] = "No"; }

                else if (Convert.ToInt32(clsdt.Rows[i]["Paid"]) == 1)
                { dr["Paid"] = "Yes"; }

                dt.Rows.Add(dr);
            }

            DGV.DataSource = dt;

            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void UserName_SelectedIndexChanged(object sender, EventArgs e)
        {

            bindData();
           
        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindData();
            
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            bindData();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
