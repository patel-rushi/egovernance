using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystems
{
    public partial class MarketingRep : Form
    {
        Guid PersonRepId;
        public MarketingRep()
        {
            InitializeComponent();
            Search();
        }
        private void Search()
        {
            try
            {
                PersonRepDatabase Repdb = new PersonRepDatabase();
                DataTable dt = Repdb.Search_PersonName();
                dgv_Rep.DataSource = null;
                dgv_Rep.AutoGenerateColumns = false;
                dgv_Rep.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void MarketingRep_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_RepName.Text != String.Empty)
                {
                    if (btn_Add.Text == "Add")
                    {
                        PersonRepDatabase Repdb = new PersonRepDatabase();
                        Repdb.PersonName = txt_RepName.Text.ToString();
                        if (Repdb.Insert_PersonName() == 1)
                        {
                            MessageBox.Show("Added");
                        }
                    }
                    else if (btn_Add.Text == "Update")
                    {
                        PersonRepDatabase Repdb = new PersonRepDatabase();
                        Repdb.PersonName = txt_RepName.Text.ToString();
                        Repdb.PersonRepId = PersonRepId;
                        if (Repdb.Update_PersonName() == 1)
                        {
                            MessageBox.Show("Updated");
                            Search();

                        }
                    }

                    Clear();

                }
                else
                {
                    MessageBox.Show("Enter Rep Name. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txt_RepName.Text = string.Empty;
            btn_Add.Text = "Add";
            Search();
        }

        private void dgv_Rep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dgv_Rep.AutoGenerateColumns = false;
                    dgv_Rep.Rows[e.RowIndex].Selected = true;
                    if (dgv_Rep.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dgv_Rep.Rows[e.RowIndex];
                        PersonRepId = Guid.Parse(selectrow.Cells["RepId"].Value.ToString());

                        if (dgv_Rep.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                            // if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                btn_Add.Text = "Update";

                                FillUpdates(PersonRepId);

                            }

                        }
                        else if (dgv_Rep.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                PersonRepDatabase Repdb = new PersonRepDatabase();
                                Repdb.PersonRepId = PersonRepId;
                                if (Repdb.Delete_PersonName() == 1)
                                {
                                    const string type = "Deleted";
                                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);

                                    Clear();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message + ex.StackTrace); }
        }
        private void FillUpdates(Guid PersonRepId)
        {
            try
            {
                PersonRepDatabase Repdb = new PersonRepDatabase();
                Repdb.PersonRepId = PersonRepId;
                DataTable dt = Repdb.Search_PersonName();
                if (dt.Rows.Count > 0)
                {
                    txt_RepName.Text = dt.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
