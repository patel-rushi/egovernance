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
    public partial class SkillsetDetails : Form
    {
        public Int32 FullScreenOff = 0;
        DataTable dtGrid = new DataTable();
        public SkillsetDetails()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            BindEvent();
            BindCource();
            GetSkillDetails();
        }

        void GetSkillDetails()
        {
            clsSkillSet objSkillDetails = new clsSkillSet();

            if (cmbEvent.SelectedIndex > 0)
            {
                objSkillDetails.eventname = cmbEvent.SelectedValue.ToString();
            }
            if (cmbCourse.SelectedIndex > 0)
            {
                objSkillDetails.course = cmbCourse.SelectedValue.ToString(); ;
            }



            dtGrid = objSkillDetails.SearchSkillDetails();
            if (dtGrid != null && dtGrid.Rows.Count > 0)
            {
                dgvSkillDetail.DataSource = dtGrid;
            }
            else
            {
                dgvSkillDetail.DataSource = null;
            }
            dgvSkillDetail.AutoGenerateColumns = false;
            dgvSkillDetail.Refresh();

        }
        void BindEvent()
        {
            List<clsSkillSet.SkillEvent> ListEvent = new List<clsSkillSet.SkillEvent>();
            clsSkillSet.SkillEvent obj = new clsSkillSet.SkillEvent();
            obj.Name = "Select";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "International";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "National";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "Local";
            ListEvent.Add(obj);

            cmbEvent.DataSource = ListEvent;
            cmbEvent.DisplayMember = "Name";
            cmbEvent.ValueMember = "Name";
        }
        void BindCource()
        {
            List<clsSkillSet.SkillCource> ListCource = new List<clsSkillSet.SkillCource>();
            clsSkillSet.SkillCource obj = new clsSkillSet.SkillCource();
            obj.Name = "Select";
            ListCource.Add(obj);

            obj = new clsSkillSet.SkillCource();
            obj.Name = "Technical";
            ListCource.Add(obj);

            obj = new clsSkillSet.SkillCource();
            obj.Name = "Nontechnical";
            ListCource.Add(obj);

            cmbCourse.DataSource = ListCource;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSkillDetails();
        }

        private void dgvSkillDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsSkillSet objSkillSetDetails = new clsSkillSet();
                Guid SkillId = (Guid)dgvSkillDetail.Rows[e.RowIndex].Cells["SkillId"].Value;
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)//Gridview Edit Button Click
                {
                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {

                        if (Application.OpenForms.OfType<AddSkillForm>().Count() == 1)
                            Application.OpenForms.OfType<AddSkillForm>().First().Close();
                        AddSkillForm obj1 = new AddSkillForm(SkillId);
                        obj1.FullScreenOff = 1;
                        obj1.MdiParent = this.ParentForm;
                        obj1.Show();
                        obj1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SkillsetDetails_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
        }
    }
}
