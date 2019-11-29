using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class ManagementFeedback : Form
    {
        int Communication;
        int TeamWork;
        int Reporting;

        public ManagementFeedback()
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        void BindUser()
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
                    
                    UserName.ValueMember = "UserID";
                    UserName.DisplayMember = "UserName";
                    UserName.DataSource = dt;

                }

            }

        }

        private void ManagementFeedback_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            BindUser();
            commrb1.Checked = true;
            twrb1.Checked = true;
            rrb1.Checked = true;
        }

        private void commrb1_CheckedChanged(object sender, EventArgs e)
        {
            Communication = 1;

        }

        private void commrb2_CheckedChanged(object sender, EventArgs e)
        {
            Communication = 2;
        }

        private void commrb3_CheckedChanged(object sender, EventArgs e)
        {
            Communication = 3;
        }

        private void commrb4_CheckedChanged(object sender, EventArgs e)
        {
            Communication = 4;
        }

        private void commrb5_CheckedChanged(object sender, EventArgs e)
        {
            Communication = 5;
        }

        private void twrb1_CheckedChanged(object sender, EventArgs e)
        {
            TeamWork = 1;
        }

        private void twrb2_CheckedChanged(object sender, EventArgs e)
        {
            TeamWork = 2;
        }

        private void twrb3_CheckedChanged(object sender, EventArgs e)
        {
            TeamWork = 3;
        }

        private void twrb4_CheckedChanged(object sender, EventArgs e)
        {
            TeamWork = 4;
        }

        private void twrb5_CheckedChanged(object sender, EventArgs e)
        {
            TeamWork = 5;
        }

        private void rrb1_CheckedChanged(object sender, EventArgs e)
        {
            Reporting = 1;
        }

        private void rrb2_CheckedChanged(object sender, EventArgs e)
        {
            Reporting = 2;
        }

        private void rrb3_CheckedChanged(object sender, EventArgs e)
        {
            Reporting = 3;
        }

        private void rrb4_CheckedChanged(object sender, EventArgs e)
        {
            Reporting = 4;
        }

        private void rrb5_CheckedChanged(object sender, EventArgs e)
        {
            Reporting = 5;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if(UserName.Text=="Select")
            {
                MessageBox.Show("Select User Name to Submit Feedback !");
            }
            else
            {
                clsManagementFeedback obj = new clsManagementFeedback();
                obj.UserId = UserName.SelectedValue.ToString();
                obj.Communication = Communication;
                obj.TeamWork = TeamWork;
                obj.Reporting = Reporting;

                if(obj.Set()==1)
                {
                    MessageBox.Show("Your Feedback is Submitted !");
                }
                else
                {
                    MessageBox.Show("Some Error ! Check Connection or Call your developer");
                }
                ManagementFeedback_Load(sender, e);
            }
        }
    }
}
