using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;
using System.Data.SqlClient;

namespace TestingSystems
{
    public partial class AccessRights : Form
    {
        DataTable dt = new DataTable();
        public Int32 FullScreenOff = 0;
        public AccessRights()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        private void AccessRights_Load(object sender, EventArgs e)
        {

            AutoFitForm.SetFormToMaximize(this);
            
        }

        void BindUserName()
        {
            clsBindUser obj = new clsBindUser();
            dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");
                    cmbusername.ValueMember = "UserID";
                    cmbusername.DisplayMember = "UserName";
                    cmbusername.DataSource = dt;

                }

            }

        }



        private void cmbusertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BindUserName();
            clsAccessRights obj = new clsAccessRights();
            obj.UserType = cmbusertype.Text;
            dt = obj.Fetch_AccessRights();

            //DGV.DataSource = dt;
            FillGrid();
            //DGV.Rows.Add(dt);

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
                    DGV.DataSource = dt;
                    this.DGV.AllowUserToAddRows = false;

                }
                this.DGV.Columns["UserName"].Frozen = true;
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {

                clsAccessRights obj = new clsAccessRights();

                for (int i = 0; i < DGV.RowCount; i++)
                {
                   
                    obj.WorkReport = Convert.ToInt16(DGV.Rows[i].Cells[1].Value);
                    obj.WorkReportRegister = Convert.ToInt16(DGV.Rows[i].Cells[2].Value);
                    obj.NewTickets = Convert.ToInt16(DGV.Rows[i].Cells[3].Value);
                    obj.Tickets = Convert.ToInt16(DGV.Rows[i].Cells[4].Value);
                    obj.MyTickets = Convert.ToInt16(DGV.Rows[i].Cells[5].Value);
                    obj.TicketsApproval = Convert.ToInt16(DGV.Rows[i].Cells[6].Value);
                    obj.ApprovedTickets = Convert.ToInt16(DGV.Rows[i].Cells[7].Value);
                    obj.CustomerMaster = Convert.ToInt16(DGV.Rows[i].Cells[8].Value);
                    obj.Inquiry = Convert.ToInt16(DGV.Rows[i].Cells[9].Value);
                    obj.Communication = Convert.ToInt16(DGV.Rows[i].Cells[10].Value);
                    obj.ClientOrder = Convert.ToInt16(DGV.Rows[i].Cells[11].Value);
                    obj.MasterUpload = Convert.ToInt16(DGV.Rows[i].Cells[12].Value);
                    obj.Register = Convert.ToInt16(DGV.Rows[i].Cells[13].Value);
                    obj.AccessRights = Convert.ToInt16(DGV.Rows[i].Cells[14].Value);
                    obj.LeaveApplication = Convert.ToInt16(DGV.Rows[i].Cells[15].Value);
                    obj.LeaveApplicationRegister = Convert.ToInt16(DGV.Rows[i].Cells[16].Value);
                    obj.Logout = Convert.ToInt16(DGV.Rows[i].Cells[17].Value);


                    obj.UserName = Convert.ToString(DGV.Rows[i].Cells[0].Value);
                    obj.UserType = cmbusertype.Text;
                    obj.Update();



                }


                MessageBox.Show("Update Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
