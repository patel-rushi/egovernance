using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.Helpers;

namespace TestingSystems
{
    public partial class ClientOrder_Register : Form
    {
        
        ClientOrder co = new ClientOrder();
        public bool pb_DateTime = false;
        public ClientOrder_Register()
        {
            try
            {
                InitializeComponent();
                AutoFitForm.SetGroupBoxLoction(groupBox1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClientOrder_Register_Load(object sender, EventArgs e)
        {
            try
            {
                AutoFitForm.SetFormToMaximize(this);

                if (!bwClientName.IsBusy)
                    bwClientName.RunWorkerAsync();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear Filter
                if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //if (!bwClientName.IsBusy)
                    //    bwClientName.RunWorkerAsync();

                    Clear();
                    SEARCH_DATA();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void Clear()
        {
            try
            {
                //Clear Filter
                cmb_ClientName.Text = "--SELECT--";
                //ClientNo.Text = String.Empty;
                scmb_OrderNo.DataSource = null;
                AMCPANEL.Enabled = true;
                radioButton1.Select();
                pb_DateTime = false;
                setdate();
                OrderNoGet(Guid.Empty);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = null;
                SEARCH_DATA();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        public void SEARCH_DATA()
        {
            try
            {
                //Search Result
                ClientOrderDatabase codb = new ClientOrderDatabase();
                if ((cmb_ClientName.SelectedIndex > 0) && (cmb_ClientName.Text.ToString() != "--SELECT--"))
                {
                    codb.CustomerId = Guid.Parse(cmb_ClientName.SelectedValue.ToString());
                }

                //if ((ClientNo.Text != null) && (ClientNo.Text != ""))
                //    codb.ClientOrderNo = ClientNo.Text.ToString();

                if ((scmb_OrderNo.SelectedIndex > 0) && (scmb_OrderNo.Text != string.Empty))
                    codb.ClientOrderNo = scmb_OrderNo.Text.ToString();
                if (Fromdate.Value > ToDate.Value)
                {
                    const string type = "Invalid Serach";
                    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    ToDate.Focus();
                    return;
                }
                if (radioButton1.Checked == true)
                {
                    codb.AMCRequired = -1;
                }
                else if (radioButton2.Checked == true)
                {
                    codb.AMCRequired = 1;
                }
                else if(radioButton1.Checked == true)
                {
                    codb.AMCRequired = 0;
                }
                if (pb_DateTime == true)
                {
                    codb.AMCStartDate = Fromdate.Value;
                    codb.AMCEndDate = ToDate.Value;
                }
                else
                {
                    codb.AMCStartDate = null;
                    codb.AMCEndDate = null;
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = codb.Search_ClientOrderMaster(3);
                dataGridView1.Columns["ClientOrderID"].Visible = false;
                dataGridView1.Columns["IsDeleted"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void bwClientName_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                e.Result = cidb.Fetch_CustomerName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
       
        private void bwClientName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CompanyName_Fill(e.Result as DataTable);
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(  ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CompanyName_Fill(DataTable pdt_CompanyName)
        {
            try
            {
                if (pdt_CompanyName.Rows.Count > 0)
                {
                    const string DisplayMember = "CustomerName";
                    const string ValueMember = "CustomerId";

                    pdt_CompanyName.AddSelectRow(0, 1);
                    cmb_ClientName.DataSource = pdt_CompanyName;
                    cmb_ClientName.DisplayMember = DisplayMember;
                    cmb_ClientName.ValueMember = ValueMember;
                    Clear();
                    OrderNoGet(Guid.Empty);
                    SEARCH_DATA();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                co.Register.Visible = true;
                co.Submit.Text = "Submit";
                this.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    dataGridView1.Rows[e.RowIndex].Selected = true;
            //    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //    {
            //        if (dataGridView1.SelectedCells.Count > 0)
            //        {
            //            DataGridViewRow selectrow = dataGridView1.Rows[e.RowIndex];
            //            Guid ClientOrderID = Guid.Parse(selectrow.Cells["ClientOrderID"].Value.ToString());

            //            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
            //            {

            //                if (Application.OpenForms.OfType<ClientOrder>().Count() == 1)
            //                    Application.OpenForms.OfType<ClientOrder>().First().Close();

            //                ClientOrder obj = new ClientOrder(ClientOrderID);
            //                obj.MdiParent = this.ParentForm;
            //                obj.Show();
                            
            //            }
            //            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            //            {
            //                if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                {
            //                    ClientOrderDatabase codb = new ClientOrderDatabase();
            //                    codb.ClientOrderID = ClientOrderID;
            //                    codb.Update_Is_Deleted();

            //                    SEARCH_DATA();
            //                    MessageBox.Show("Deleted.");
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionHandler.LogException(ex);
            //    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            //}
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    int RowIndex = e.RowIndex;
                    Guid ClientOrderID = Guid.Parse(dataGridView1.Rows[RowIndex].Cells["ClientOrderID"].Value.ToString());
                    ClientOrderDatabase codb = new ClientOrderDatabase();
                    codb.ClientOrderID = ClientOrderID;
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = codb.Search_ClientOrderMaster(8);
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Escape)
                {
                    dataGridView2.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Escape)
                {
                    Close.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        public void setdate()
        {
            try
            {
                int Year = DateTime.Now.Date.AddMonths(-3).Year;
                DateTime parsedDate = new DateTime(Year, 4, 1);
                DateTime ToparsedDate = new DateTime(Year + 1, 3, 31);
                Fromdate.Value = parsedDate;
                ToDate.Value = ToparsedDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        DataGridViewRow selectrow = dataGridView1.Rows[e.RowIndex];
                        Guid ClientOrderID = Guid.Parse(selectrow.Cells["ClientOrderID"].Value.ToString());

                        if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
                        {

                            if (Application.OpenForms.OfType<ClientOrder>().Count() == 1)
                                Application.OpenForms.OfType<ClientOrder>().First().Close();

                            ClientOrder obj = new ClientOrder(ClientOrderID);
                            obj.MdiParent = this.ParentForm;
                            obj.Show();

                        }
                        else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
                        {
                            if (MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ClientOrderDatabase codb = new ClientOrderDatabase();
                                codb.ClientOrderID = ClientOrderID;
                                codb.Update_Is_Deleted();

                                SEARCH_DATA();
                                MessageBox.Show("Deleted.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmb_ClientName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if ((cmb_ClientName.SelectedIndex > 0) && (Guid.Parse(cmb_ClientName.SelectedValue.ToString()) != Guid.Empty))
                {
                    OrderNoGet(Guid.Parse(cmb_ClientName.SelectedValue.ToString()));
                }
                else if((cmb_ClientName.SelectedIndex == 0) || (cmb_ClientName.Text == string.Empty))
                {
                    OrderNoGet(Guid.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_ClientName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if ((cmb_ClientName.SelectedIndex > 0) && (Guid.Parse(cmb_ClientName.SelectedValue.ToString()) != Guid.Empty))
                {
                    OrderNoGet(Guid.Parse(cmb_ClientName.SelectedValue.ToString()));
                }
                else if((cmb_ClientName.SelectedIndex == 0) || (cmb_ClientName.Text == string.Empty))
                {
                    OrderNoGet(Guid.Empty);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderNoGet(Guid pGd_CustomerId)
        {
            try
            {
                ClientOrderDatabase codb = new ClientOrderDatabase();
                codb.CustomerId = pGd_CustomerId;
                
                DataTable dt  = codb.Fetch_OrderNo();
                if (dt.Rows.Count > 0)
                {
                    dt.AddSelectRow(1,0);
                    scmb_OrderNo.DataSource = null;
                    scmb_OrderNo.ValueMember = "ClientOrderID";
                    scmb_OrderNo.DisplayMember = "ClientOrderNo";
                    scmb_OrderNo.DataSource = dt;
                
                }
                else
                {
                    scmb_OrderNo.DataSource = null;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace); 
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Fromdate_ValueChanged(object sender, EventArgs e)
        {
            pb_DateTime = true;
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            pb_DateTime = true;
        }

    }
}
