using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.Helpers;

namespace TestingSystems
{
    public partial class LeaveApplication : Form
    {
        String User_ID;
        DataRow dr;
        DataTable dt = new DataTable();

        public Int32 FullScreenOff = 0;
        public LeaveApplication(String User_Id)
        {
            InitializeComponent();
            User_ID = User_Id;
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        private void LeaveApplication_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);


            clsLeaveApplication obj = new clsLeaveApplication();
            dt.Clear();
            obj.User_ID = User_ID;
            DataTable clsdt = new DataTable();
            clsdt = obj.Get();
            bindtable();

            for(int i=0; i<clsdt.Rows.Count; i++)
            {
                dr = dt.NewRow();
                if(Convert.ToInt32(clsdt.Rows[i]["FirstDay_Half"])==1)
                { dr["From Date"] = Convert.ToString(clsdt.Rows[i]["FromDate"]) + " (HALF)"; }
                else { dr["From Date"] = Convert.ToDateTime(clsdt.Rows[i]["FromDate"]); }

                if (Convert.ToInt32(clsdt.Rows[i]["LastDay_Half"]) == 1)
                { dr["To Date"] = Convert.ToDateTime(clsdt.Rows[i]["ToDate"]) + " (HALF)"; }
                else { dr["To Date"] = Convert.ToDateTime(clsdt.Rows[i]["ToDate"]); }
                
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
            //DGV.Rows.Clear();           
            DGV.DataSource = dt;

            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DGV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            

        }

       

        void bindtable()
        {
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add("From Date");
                dt.Columns.Add("To Date");
                dt.Columns.Add("Description");
                dt.Columns.Add("Status");
                dt.Columns.Add("Paid");
                
            }


        }

        private void submit_Click(object sender, EventArgs e)
        {
            bindtable();
            clsLeaveApplication obj = new clsLeaveApplication();


            if (description.Text =="")
            {
                System.Windows.Forms.MessageBox.Show("Write Some Description.");
                return;

            }
            
            obj.User_ID = User_ID;
            obj.FromDate = FromDate.Value;
            obj.ToDate = ToDate.Value;
            if (halffromdate.Checked)
            { obj.HDF = 1; }
            else { obj.HDF = 0; }

            if (halftodate.Checked)
            { obj.HDT = 1; }
            else { obj.HDT = 0; }
            obj.Desc = description.Text;

            obj.Set();
            LeaveApplication_Load(sender, e);

            MessageBox.Show("Your Leave Application is Submitted ! Wait for the Response. ");


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
