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
    public partial class AddFeedback : Form
    {
        public Int32 FullScreenOff = 0;
        public int _UserId = 0;
        int rbhValue = 0;
        int rbbValue = 0;
        public AddFeedback(int UserId)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(this.groupBox1);
            _UserId = UserId;
            bindClient();
        }

        void bindClient()
        {

            clsFeedback obj = new clsFeedback();
            obj.UserId = _UserId;
            DataTable dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";
                    dt.Rows.InsertAt(dr, 0);
                    cmbUserName.ValueMember = "ID";
                    cmbUserName.DisplayMember = "UserName";
                    cmbUserName.DataSource = dt;
                }
            }
        }

        void Clear()
        {
            bindClient();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                clsFeedback obj = new clsFeedback();
                obj.FromId = _UserId;
                if (cmbUserName.SelectedIndex > 0)
                {
                    obj.ToId = Convert.ToInt32(cmbUserName.SelectedValue);
                }
                else
                {
                    const string type = "select User Name";
                    System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                    return;
                }



                obj.Helpful = rbhValue;
                obj.Behaviour = rbbValue;


                int result = 0;
                result = obj.Insert_FeedBack();
                if (result > 0)
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (FullScreenOff == 1)
                    //{
                    this.Close();
                    //}
                    Clear();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFeedback_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
        }

        private void btnShowFeedBack_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FeedbackDetails>().Count() == 1)
                Application.OpenForms.OfType<FeedbackDetails>().First().Close();
            FeedbackDetails obj = new FeedbackDetails(_UserId, "");
            obj.FullScreenOff = 0;
            obj.MdiParent = this.ParentForm;
            obj.Show();
            obj.Focus();
        }

        private void rbh1_CheckedChanged(object sender, EventArgs e)
        {
            rbhValue = Convert.ToInt32(rbh1.Text);
        }

        private void rbh2_CheckedChanged(object sender, EventArgs e)
        {
            rbhValue = Convert.ToInt32(rbh2.Text);
        }

        private void rbh3_CheckedChanged(object sender, EventArgs e)
        {
            rbhValue = Convert.ToInt32(rbh3.Text);
        }

        private void rbh4_CheckedChanged(object sender, EventArgs e)
        {
            rbhValue = Convert.ToInt32(rbh4.Text);
        }

        private void rbh5_CheckedChanged(object sender, EventArgs e)
        {
            rbhValue = Convert.ToInt32(rbh5.Text);
        }

        private void rbb1_CheckedChanged(object sender, EventArgs e)
        {
            rbbValue = Convert.ToInt32(rbb1.Text);
        }

        private void rbb2_CheckedChanged(object sender, EventArgs e)
        {
            rbbValue = Convert.ToInt32(rbb2.Text);
        }

        private void rbb3_CheckedChanged(object sender, EventArgs e)
        {
            rbbValue = Convert.ToInt32(rbb3.Text);
        }

        private void rbb4_CheckedChanged(object sender, EventArgs e)
        {
            rbbValue = Convert.ToInt32(rbb4.Text);
        }

        private void rbb5_CheckedChanged(object sender, EventArgs e)
        {
            rbbValue = Convert.ToInt32(rbb5.Text);
        }
    }
}

