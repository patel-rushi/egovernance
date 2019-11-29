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
    public partial class FeedbackDetails : Form
    {
        public Int32 FullScreenOff = 0;
        public int _UserId = 0;
        public string _UserType = "";
        DataTable dtGrid = new DataTable();
        public FeedbackDetails(int UserId, string UserType)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            _UserType = UserType;
            if (UserType.ToLower() == "admin")
            {
                _UserId = 0;
                groupBox3.Enabled = true;               
                bindClient();
            }
            else
            {
                _UserId = UserId;                
                groupBox3.Enabled = false;
            }
            GetFeedBackDetails();
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
            if (_UserType.ToLower() == "admin")
            {
                cmbUserName.SelectedIndex = 0;
                btnSearch_Click(null, null);
            }
        }

        void GetFeedBackDetails()
        {
            clsFeedback objFeedBackDetails = new clsFeedback();
            objFeedBackDetails.UserId = _UserId;

            dtGrid = objFeedBackDetails.GetFeedback();
            if (dtGrid != null && dtGrid.Rows.Count > 0)
            {
                dgvFeedBackDetail.DataSource = dtGrid;
            }
            else
            {
                dgvFeedBackDetail.DataSource = null;
            }
            dgvFeedBackDetail.AutoGenerateColumns = false;
            dgvFeedBackDetail.Refresh();
        }

        private void FeedbackDetails_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsFeedback objFeedBackDetails = new clsFeedback();
            if (_UserType.ToLower() == "admin")
            {
                if (cmbUserName.SelectedIndex > 0)
                {
                    objFeedBackDetails.UserId = Convert.ToInt32(cmbUserName.SelectedValue);
                }
                else
                {
                    objFeedBackDetails.UserId = 0;
                }

            }
            dtGrid = objFeedBackDetails.GetFeedback();
            if (dtGrid != null && dtGrid.Rows.Count > 0)
            {
                dgvFeedBackDetail.DataSource = dtGrid;
            }
            else
            {
                dgvFeedBackDetail.DataSource = null;
            }
            dgvFeedBackDetail.AutoGenerateColumns = false;
            dgvFeedBackDetail.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
