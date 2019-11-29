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
    public partial class Performance : Form
    {
        String UserId;
        double Total;
        public Performance(String UserID)
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            UserId = UserID;

        }
        void bindUserName()
        {

            clsBindUser obj = new clsBindUser();
            obj.UserType = UserType.Text;
            DataTable dt = obj.BindUserUsingUserType();
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
                    
                }
            }
        }

        void bindData()
        {
            if (UserName.Text != "Select")
            {
                clsPerformance obj = new clsPerformance();
                obj.UserId = UserName.SelectedValue.ToString();
                obj.FromDate = Convert.ToDateTime(fromdate.Value.ToString());
                obj.ToDate = Convert.ToDateTime(todate.Value.ToString());

                DataTable dt = new DataTable();
                dt = obj.Get();

                effi.Text = Convert.ToString(dt.Rows[1]["efficiency"]);
                effect.Text = Convert.ToString(dt.Rows[1]["effectiveness"]);
                atten.Text = Convert.ToString(dt.Rows[1]["attendance"]);
                mf.Text = Convert.ToString(dt.Rows[1]["managementfeedback"]);
                ss.Text = Convert.ToString(dt.Rows[1]["skillset"]);
                cf.Text = Convert.ToString(dt.Rows[1]["colleaguesfeedback"]);
                Total = Convert.ToDouble(dt.Rows[1]["efficiency"]) + Convert.ToDouble(dt.Rows[1]["effectiveness"]) + Convert.ToDouble(dt.Rows[1]["attendance"]) + Convert.ToDouble(dt.Rows[1]["managementfeedback"]) + Convert.ToDouble(dt.Rows[1]["skillset"]) + Convert.ToDouble(dt.Rows[1]["colleaguesfeedback"]);
                tot.Text = Total.ToString();
            }
        }

     

        private void Performance_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
            Total = 0;

            if (UserId == "1")
            {
                UserName.Visible = true;
                lblUN.Visible = true;
                UserType.Visible = true;
                lblUT.Visible = true;
                UserType.Text = "DEVELOPER";
                bindUserName();
               
            }
            else
            {
                clsPerformance obj = new clsPerformance();
                obj.UserId = UserId;
                obj.FromDate = Convert.ToDateTime(fromdate.Value);
                obj.ToDate = Convert.ToDateTime(todate.Value);
                DataTable dt = new DataTable();
                dt = obj.Get();
                
                effi.Text = Convert.ToString(dt.Rows[1]["efficiency"]);
                effect.Text = Convert.ToString(dt.Rows[1]["effectiveness"]);
                atten.Text = Convert.ToString(dt.Rows[1]["attendance"]);
                mf.Text = Convert.ToString(dt.Rows[1]["managementfeedback"]);
                ss.Text = Convert.ToString(dt.Rows[1]["skillset"]);
                cf.Text = Convert.ToString(dt.Rows[1]["colleaguesfeedback"]);

                Total = Convert.ToDouble(dt.Rows[1]["efficiency"]) + Convert.ToDouble(dt.Rows[1]["effectiveness"]) + Convert.ToDouble(dt.Rows[1]["attendance"]) + Convert.ToDouble(dt.Rows[1]["managementfeedback"]) + Convert.ToDouble(dt.Rows[1]["skillset"]) + Convert.ToDouble(dt.Rows[1]["colleaguesfeedback"]);
                tot.Text = Total.ToString();
            }
            

        }

       
        private void UserType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            clsPerformanceCriteria obj = new clsPerformanceCriteria();
            DataTable dt = new DataTable();
            obj.UserType = UserType.Text;
            dt = obj.Get();
            lbleffi.Text = "( Out of " + Convert.ToString(dt.Rows[0]["Weightage"]) + " % )";
            lbleffec.Text = "( Out of " + Convert.ToString(dt.Rows[1]["Weightage"]) + " % )";
            lblatten.Text = "( Out of " + Convert.ToString(dt.Rows[2]["Weightage"]) + " % )";
            lblmf.Text = "( Out of " + Convert.ToString(dt.Rows[3]["Weightage"]) + " % )";
            lblss.Text = "( Out of " + Convert.ToString(dt.Rows[4]["Weightage"]) + " % )";
            lblcf.Text = "( Out of " + Convert.ToString(dt.Rows[5]["Weightage"]) + " % )";

            bindUserName();

            effi.Text = "0";
            effect.Text = "0";
            atten.Text = "0";
            mf.Text = "0";
            ss.Text = "0";
            cf.Text = "0";
            tot.Text = "0";
        }

       
        private void Search_Click(object sender, EventArgs e)
        {
            bindData();
        }
    }
}
