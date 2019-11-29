using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class Add_Form : Form
    {
        string Form_Name;
        public Add_Form()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRep.Text != String.Empty)
                {
                    
                        clsNewTickets obj = new clsNewTickets();
                        obj.FormName = txtRep.Text.ToString();
                        if (obj.InsertForm() > 0)
                        {
                            MessageBox.Show("Added");
                        }
                    

                }
                else
                {
                    MessageBox.Show("Enter Form Name. ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            /*clsNewTickets obj = new clsNewTickets();
            if (txtRep.Text != string.Empty)
                obj.FormName = txtRep.Text;
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert Form Name.");
                return;
            }

            if (obj.InsertForm() > 0)
            {
                System.Windows.Forms.MessageBox.Show("Save Done.");
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(" Can't Save .");
            }*/
        }

        private void dgv_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    dgv_Product.AutoGenerateColumns = false;
                    dgv_Product.Rows[e.RowIndex].Selected = true;
                    if (dgv_Product.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dgv_Product.Rows[e.RowIndex];
                        Form_Name = selectrow.Cells["Form"].Value.ToString();

                        if (dgv_Product.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                clsNewTickets obj = new clsNewTickets();
                                obj.FormName = Form_Name;
                                if (obj.DeleteForm() == 1)
                                {
                                    const string type = "Deleted";
                                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);

                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message + ex.StackTrace); }
        }
    }
}
