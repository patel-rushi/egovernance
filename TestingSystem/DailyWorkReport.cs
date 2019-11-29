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
    public partial class DailyWorkReport : Form
    {
        int User_Name;
        string User_Type;
        public Int32 FullScreenOff = 0;
        public DailyWorkReport(string UserName, string UserType)
        {

            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            this.dgvWorkReport.AutoGenerateColumns = false;

            User_Name = Convert.ToInt32(UserName);
            User_Type = UserType;
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void bindTask()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindTask();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    dt.AddSelectRow(1, 0);
                    // cmbAssignTo.Items.Add("Select");

                    cmbTaskType.ValueMember = "Taskid";
                    cmbTaskType.DisplayMember = "TaskType";
                    cmbTaskType.DataSource = dt;

                }

            }

        }

        void bindTicketNumber()
        {

            clsWorkReport obj = new clsWorkReport();
            obj.UserType = "";
            obj.Assigned = Constants.UserAssignId;
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

        void bindClient()
        {


            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dt.AddSelectRow(1, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbClient.ValueMember = "CustomerId";
                    cmbClient.DisplayMember = "CustomerName";
                    cmbClient.DataSource = dt;

                }

            }
        }
        DataRow dr;
        DataTable dt = new DataTable();
        private void DailyWorkReport_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            this.ControlBox = true;
            DateTimePicker timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            bindClient();
            bindTask();
            bindTicketNumber();



        }
        void bindtable()
        {
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add("Date");
                dt.Columns.Add("FromTime");
                dt.Columns.Add("ToTime");
                dt.Columns.Add("ClientName");
                dt.Columns.Add("ClientID");
                dt.Columns.Add("TaskType");
                dt.Columns.Add("Description");
                dt.Columns.Add("TaskID");
                dt.Columns.Add("TicketNumber");
            }


        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Guid.Parse(cmbClient.SelectedValue.ToString()) == Guid.Empty)
            {
                System.Windows.Forms.MessageBox.Show("Select Client Name.");
                return;

            }
            if (Convert.ToInt32(cmbTaskType.SelectedValue.ToString()) <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Select Task Name.");
                return;
            }
            if (cmbTicketNumber.SelectedIndex <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Select Ticket Number.");
                return;
            }
            bindtable();

            dr = dt.NewRow();
            dr["Date"] = DtDate.Value;
            dr["FromTime"] = Dtfrom.Value.ToShortTimeString();
            dr["ToTime"] = DtTo.Value.ToShortTimeString();
            dr["ClientName"] = cmbClient.Text;
            dr["ClientID"] = cmbClient.SelectedValue.ToString();
            dr["TaskType"] = cmbTaskType.Text;
            dr["TaskID"] = Convert.ToInt32(cmbTaskType.SelectedValue.ToString());
            dr["Description"] = txtDescription.Text;
            dr["TicketNumber"] = cmbTicketNumber.Text.ToString();
            dt.Rows.Add(dr);

            dgvWorkReport.Columns["ClientID"].Visible = false;
            dgvWorkReport.DataSource = dt;


        }
        public void clear()
        {
            dgvWorkReport.DataSource = null;
            bindClient();
            bindTask();
            bindTicketNumber();
            txtDescription.Text = "";

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            bindClient();
            cmbTaskType.SelectedIndex = 1;

            txtDescription.Text = "";
            this.dgvWorkReport.DataSource = null;
            dt.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            DataRow ddr;
            DataTable dt_Save = new DataTable();
            if (dt_Save.Rows.Count <= 0)
            {

                dt_Save.Columns.Add("Date");
                dt_Save.Columns.Add("FromTime");
                dt_Save.Columns.Add("ToTime");
                dt_Save.Columns.Add("ClientID");
                dt_Save.Columns.Add("TaskType");
                dt_Save.Columns.Add("Description");
                dt_Save.Columns.Add("User_ID");
                dt_Save.Columns.Add("TaskTypeText");
                dt_Save.Columns.Add("TicketNumber");
            }
            for (int i = 0; i < dgvWorkReport.Rows.Count; i++)
            {

                ddr = dt_Save.NewRow();
                ddr["ClientID"] = dgvWorkReport.Rows[i].Cells["ClientID"].Value;
                ddr["Date"] = dgvWorkReport.Rows[i].Cells["Date"].Value;
                ddr["FromTime"] = dgvWorkReport.Rows[i].Cells["FromTime"].Value;
                ddr["ToTime"] = dgvWorkReport.Rows[i].Cells["ToTime"].Value;
                ddr["TaskType"] = dgvWorkReport.Rows[i].Cells["TaskID"].Value;
                ddr["Description"] = dgvWorkReport.Rows[i].Cells["Description"].Value;
                ddr["User_ID"] = User_Name;
                ddr["TaskTypeText"] = dgvWorkReport.Rows[i].Cells["TaskType"].Value;
                ddr["TicketNumber"] = dgvWorkReport.Rows[i].Cells["TicketNumber"].Value;
                dt_Save.Rows.Add(ddr);
            }
            clsWorkReport obj = new clsWorkReport();
            obj.Dt = dt_Save;
            obj.UserName = User_Name;
            //obj.TaskTypeText = dgvWorkReport.Rows[i].Cells["Date"].Value;
            if (dt_Save.Rows.Count > 0)
            {
                if (obj.InsertWorkData() > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Record Save SuccessFully.");
                    clear();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Record Can't Save.");

                }
            }
            else
            {

                System.Windows.Forms.MessageBox.Show("Select Client Name.");
                return;

            }


        }

        private void dgvWorkReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
