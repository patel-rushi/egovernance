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
    public partial class PerformanceCriteria : Form
    {
        int total;
        public Int32 FullScreenOff = 0;

        public PerformanceCriteria()
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }        

        private void Efficiency_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total+= Convert.ToInt32(Efficiency.Value);
            total+= Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if (total != 100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }

        }

        private void Effectiveness_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total += Convert.ToInt32(Efficiency.Value);
            total += Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if(total!=100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }
        }
        
        private void Attendance_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total += Convert.ToInt32(Efficiency.Value);
            total += Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if (total != 100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }
        }

        private void ManagementFeedback_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total += Convert.ToInt32(Efficiency.Value);
            total += Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if (total != 100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }
        }

        private void Skillset_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total += Convert.ToInt32(Efficiency.Value);
            total += Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if (total != 100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }
        }

        private void ColleagueFeedback_ValueChanged(object sender, EventArgs e)
        {
            total = 0;
            total += Convert.ToInt32(Efficiency.Value);
            total += Convert.ToInt32(Effectiveness.Value);
            total += Convert.ToInt32(Attendance.Value);
            total += Convert.ToInt32(ManagementFeedback.Value);
            total += Convert.ToInt32(Skillset.Value);
            total += Convert.ToInt32(ColleagueFeedback.Value);
            tot.Text = total.ToString();
            if (total != 100)
            {
                errorProvider1.SetError(tot, "Total must be 100 %");
            }
            else { errorProvider1.Clear(); }
        }

        private void PerformanceCriteria_Load(object sender, EventArgs e)
        {
             
            AutoFitForm.SetFormToMaximize(this);
            UserType.Text = "DEVELOPER";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsPerformanceCriteria obj = new clsPerformanceCriteria();
            if (total == 100)
            {
                obj.UserType = UserType.Text;
                obj.Efficiency =Convert.ToInt32(Efficiency.Value);
                obj.Effectiveness = Convert.ToInt32(Effectiveness.Value);
                obj.Attendance = Convert.ToInt32(Attendance.Value);
                obj.ManagementF = Convert.ToInt32(ManagementFeedback.Value);
                obj.Skillset = Convert.ToInt32(Skillset.Value);
                obj.ColleagueF = Convert.ToInt32(ColleagueFeedback.Value);

                if (obj.Set() == 1)
                {
                    MessageBox.Show("Performance Criteria Updated !");
                }
            }
            else
            { MessageBox.Show("Total must be 100%"); return; }
        }

        private void UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPerformanceCriteria obj = new clsPerformanceCriteria();
            DataTable dt = new DataTable();
            obj.UserType = UserType.Text;
            dt = obj.Get();
            Efficiency.Value = Convert.ToInt32(dt.Rows[0]["Weightage"]);
            Effectiveness.Value = Convert.ToInt32(dt.Rows[1]["Weightage"]);
            Attendance.Value = Convert.ToInt32(dt.Rows[2]["Weightage"]);
            ManagementFeedback.Value = Convert.ToInt32(dt.Rows[3]["Weightage"]);
            Skillset.Value = Convert.ToInt32(dt.Rows[4]["Weightage"]);
            ColleagueFeedback.Value = Convert.ToInt32(dt.Rows[5]["Weightage"]);
        }
    }
}
