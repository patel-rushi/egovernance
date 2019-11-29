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
    public partial class PendingAction : Form
    {

        public Int32 FullScreenOff = 0;
        Guid ActionId;
        public PendingAction()
        {
            InitializeComponent();
            Search();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Action.Text != String.Empty)
                {
                    if (btn_Add.Text == "Add")
                    {
                        ActionDataBase adb = new ActionDataBase();
                        adb.Action = txt_Action.Text.ToString();
                        if (adb.Insert_Action() == 1)
                        {
                            MessageBox.Show("Added");
                        }
                    }
                    else if (btn_Add.Text == "Update")
                    {
                        ActionDataBase adb = new ActionDataBase();
                        adb.Action = txt_Action.Text.ToString();
                        adb.ActionId = ActionId;
                        if (adb.Update_Action() == 1)
                        {
                            MessageBox.Show("Updated");
                            Search();

                        }
                    }
                    Clear();

                }
                else
                {
                    MessageBox.Show("Enter Pending Action. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgv_CommMethod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dgv_pendingAction.AutoGenerateColumns = false;
                    dgv_pendingAction.Rows[e.RowIndex].Selected = true;
                    if (dgv_pendingAction.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dgv_pendingAction.Rows[e.RowIndex];
                        ActionId = Guid.Parse(selectrow.Cells["_ActionId"].Value.ToString());

                        if (dgv_pendingAction.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                            // if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                btn_Add.Text = "Update";
                                FillUpdates(ActionId);

                            }

                        }
                        else if (dgv_pendingAction.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ActionDataBase adb = new ActionDataBase();
                                adb.ActionId = ActionId;
                                if (adb.Delete_Action() == 1)
                                {
                                    const string type = "Deleted";
                                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                }
                                Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Clear()
        {
            txt_Action.Text = string.Empty;
            btn_Add.Text = "Add";
            Search();
        }
        private void FillUpdates(Guid CommMethodId)
        {
            try
            {
                ActionDataBase adb = new ActionDataBase();
                adb.ActionId = ActionId;
                DataTable dt = adb.Search_Action();
                if (dt.Rows.Count > 0)
                {
                    txt_Action.Text = dt.Rows[0][1].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search()
        {
            try
            {
                ActionDataBase adb = new ActionDataBase();
     
                DataTable dt = adb.Search_Action();
                dgv_pendingAction.DataSource = null;
                dgv_pendingAction.AutoGenerateColumns = false;
                dgv_pendingAction.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
