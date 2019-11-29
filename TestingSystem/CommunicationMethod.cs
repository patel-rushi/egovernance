using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems.Helpers;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class CommunicationMethod : Form
    {
        public Int32 FullScreenOff = 0;
        Guid CommMethodId;

        public CommunicationMethod()
        {
            InitializeComponent();

            FullScreenOff = clsValues.Instance.FullScreenOff;
            Search();
        }

        private void CommunicationMethod_Load(object sender, EventArgs e)
        {
            FullScreenOff = clsValues.Instance.FullScreenOff;
       
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_CommMethod.Text != String.Empty)
                {
                    if (btn_Add.Text == "Add")
                    {
                        CommMethodDataBase cmdb = new CommMethodDataBase();
                        cmdb.MethodName = txt_CommMethod.Text.ToString();
                        if (cmdb.Insert_CommMethod() == 1)
                        {
                            MessageBox.Show("Added");
                        }
                    }
                    else if(btn_Add.Text == "Update")
                    {
                        CommMethodDataBase cmdb = new CommMethodDataBase();
                        cmdb.MethodName = txt_CommMethod.Text.ToString();
                        cmdb.CommMethodId = CommMethodId;
                        if (cmdb.Update_CommMethod() == 1)
                        {
                            MessageBox.Show("Updated");
                            Search();
                           
                        }
                    }
                    Clear();

                }
                else
                {
                    MessageBox.Show("Enter Method Name. ");
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
            try
            {
                Clear();


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
            txt_CommMethod.Text = string.Empty;
            btn_Add.Text = "Add";
            Search();
        }
        private void dgv_CommMethod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dgv_CommMethod.AutoGenerateColumns = false;
                    dgv_CommMethod.Rows[e.RowIndex].Selected = true;
                    if (dgv_CommMethod.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dgv_CommMethod.Rows[e.RowIndex];
                        CommMethodId = Guid.Parse(selectrow.Cells["MethodId"].Value.ToString());

                        if (dgv_CommMethod.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {
                            // if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                btn_Add.Text = "Update";
                                FillUpdates(CommMethodId);
                            
                            }

                        }
                        else if (dgv_CommMethod.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CommMethodDataBase cmdb = new CommMethodDataBase();
                                cmdb.CommMethodId = CommMethodId;
                                if (cmdb.Delete_CommMethod() == 1)
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
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillUpdates(Guid CommMethodId)
        {
            try
            {
                CommMethodDataBase cmdb = new CommMethodDataBase();
                cmdb.CommMethodId = CommMethodId;
                DataTable dt  = cmdb.Search_CommMethod();
                if (dt.Rows.Count > 0)
                {
                    txt_CommMethod.Text = dt.Rows[0][1].ToString();
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
                CommMethodDataBase cmdb = new CommMethodDataBase();
                DataTable dt = cmdb.Search_CommMethod();
                dgv_CommMethod.DataSource = null;
                dgv_CommMethod.AutoGenerateColumns = false;
                dgv_CommMethod.DataSource = dt;
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
