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
    public partial class ClientOrder : Form
    {
        //public static ClientOrder C1;

        //void Awake()
        //{
        //    C1 = this;
        //}
        public static int AMC1_Y_Location = 0;
        public static int uc_textbox_location1 = 0;
        public static int uc_textbox_location2 = 0;
        public static int uc_textbox_loaction3 = 0;
        AMC newAmc;
        public static int panelAMCCount = 1;
        public static int AmcNextValue = 0;
        public static Guid ClientOrderID;
        public ClientOrder()
        {
            InitializeComponent();

            Register.Visible = true;

            AutoFitForm.SetGroupBoxLoction(groupBox1);
            ClientOrderID = Guid.Empty;
            AMC1_Y_Location = amc1.Location.Y;
        }
        public ClientOrder(Guid _ClientOrderID)
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
           
            ClientOrderID = _ClientOrderID;

            AMC1_Y_Location = amc1.Location.Y;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAMC.Checked == true)
            {
                panel1.Enabled = true;
                amc1.Enabled = true;
            }
            else if (checkBoxAMC.Checked == false)
            {
                //panel1.Enabled = false;
                panelclear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD_AmcControl();
        }
        public void ADD_AmcControl()
        {
            try
            {
                int buttonPositionY = buttonADD.Location.Y;
                int uclocation = 0;
                #region
                int count = 0;
                foreach (Control cn in panel1.Controls)
                {
                    if (cn is UserControl)
                    {
                        count++;
                    }
                }
                foreach (Control cn in panel1.Controls)
                {
                    if (cn is UserControl)
                    {
                        if (cn.Location.Y == AMC1_Y_Location + ((count - 1) * 35))
                        {
                            foreach (Control a in cn.Controls)
                            {
                                if (a is TextBox)
                                {
                                    if (a.Location.X == uc_textbox_location2)
                                    {
                                        if ((a.Text != string.Empty) && (!a.Text.Contains("-")))
                                        {
                                            AmcNextValue = Convert.ToInt32(a.Text);
                                        }
                                        else
                                        {
                                            a.Focus();
                                            MessageBox.Show("Please Insert the remaining fields");
                                            return;
                                        }
                                    }
                                    if (a.Location.X == uc_textbox_loaction3)
                                    {
                                        if ((a.Text != "") && (a.Text != null))
                                        {
                                        }
                                        else
                                        {
                                            a.Focus();
                                            MessageBox.Show("Please Insert the remaining fields");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        cn.Enabled = false;
                        uclocation = cn.Location.Y;
                    }
                }
                #endregion

                #region Control add button
                //foreach (Control cn in panel1.Controls)
                //{
                //    if (cn is UserControl)
                //    {
                //        string amcName = cn.Name;
                //        if (amcName == "amc"+panelAMCCount)
                //        {
                //            //AMC Child controls
                //            foreach (Control a in cn.Controls)
                //            {
                //                if (a is TextBox)
                //                {
                //                    if (a.Location.X == uc_textbox_location2)
                //                    {
                //                        if ((a.Text != string.Empty) && (!a.Text.Contains("-")))
                //                        {
                //                        }
                //                        else
                //                        {
                //                            a.Focus();
                //                            MessageBox.Show("Please Insert the remaining fields");
                //                            return;
                //                        }
                //                    }
                //                    if (a.Location.X == uc_textbox_loaction3)
                //                    {
                //                        if ((a.Text != "") && (a.Text != null))
                //                        {
                //                        }
                //                        else{
                //                            a.Focus();
                //                            MessageBox.Show("Please Insert the remaining fields");
                //                            return;
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //        cn.Enabled = false;
                //    }
                //}
                #endregion

                
                count++;
                newAmc = new AMC();
                newAmc.textBox1.Enabled = false;
                panel1.Controls.Add(newAmc);
                newAmc.Name = "amc" + count;
                newAmc.textBox1.Text = AmcNextValue.ToString();

                newAmc.Location = new System.Drawing.Point(66, uclocation + 35);
               
                buttonADD.Location = new System.Drawing.Point(17, buttonPositionY + 35);
                buttonDelete.Location = new System.Drawing.Point(buttonDelete.Location.X, buttonPositionY + 35);

                buttonDelete.Visible = true;
                //newAmc.textBox2.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Delete_Button();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        public void Delete_Button()
        {
            try
            {
                int Location = 0;
                int buttonlocation = buttonADD.Location.Y;
                int Count = 0;
                foreach (Control uc in panel1.Controls)
                {
                    if (uc is UserControl)
                    {
                        Location = uc.Location.Y;
                        Count++;
                    }

                }
                if (Location >= (AMC1_Y_Location + 35))
                {
                    if (Location == (AMC1_Y_Location + 35))
                    {
                        buttonDelete.Visible = false;
                        amc1.Enabled = true;
                    }
                    foreach (Control uc in panel1.Controls)
                    {
                        if (uc is UserControl)
                        {
                            if (uc.Location.Y == (AMC1_Y_Location + ((Count - 1) * 35)))
                            //if (uc.Name == "amc" + panelAMCCount)
                            {
                                panel1.Controls.Remove(uc);
                            }
                            //if (uc.Name == "amc" + (panelAMCCount - 1))
                            if (uc.Location.Y == (AMC1_Y_Location + ((Count - 2) * 35)))
                            {
                                foreach (Control a in uc.Controls)
                                {
                                    if (a is TextBox)
                                    {
                                        if (a.Location.X == uc_textbox_location2)
                                        {
                                            AmcNextValue = Convert.ToInt32(a.Text);
                                            a.Text = "-";
                                            Console.WriteLine("AmcNextValue" + AmcNextValue);
                                        }
                                    }
                                }
                                uc.Enabled = true;
                            }
                        }
                    }
                    //panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
                    buttonADD.Location = new System.Drawing.Point(17, buttonlocation - 35);
                    buttonDelete.Location = new System.Drawing.Point(buttonDelete.Location.X, buttonlocation - 35);
                    Count--;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        private void ClientOrder_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
           
            if (!bwClientName.IsBusy)
                bwClientName.RunWorkerAsync();

            //if (ClientOrderID != Guid.Empty)
            //{
            //    FillUpdates();
            //    Submit.Text = "Update";
            //}
        }
        public void FillUpdates()
        {
            try
            {
                ClientOrderDatabase codb = new ClientOrderDatabase();
                codb.ClientOrderID = ClientOrderID;
                DataSet ds = codb.Fetch_ClientOrder();
                panelAMCCount = ds.Tables[0].Rows.Count;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //comboBoxClientName.Text = ds.Tables[0].Rows[0]["ClientOrderName"].ToString();
                    comboBoxClientName.SelectedValue = Guid.Parse(ds.Tables[0].Rows[0]["CustomerId"].ToString());
                    dateTimePickerOrderDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                    int CheckBox = Convert.ToInt32(ds.Tables[0].Rows[0]["AMCRequired"].ToString());
                    if (CheckBox == 1)
                    {
                        checkBoxAMC.Checked = true;
                    }
                    else
                    {
                        checkBoxAMC.Checked = false;
                    }
                    textBoxOrderNo.Text = ds.Tables[0].Rows[0]["ClientOrderNo"].ToString();
                    textBoxOrderAmount.Text = ds.Tables[0].Rows[0]["OrderAmount"].ToString();
                    textBoxDescription.Text = ds.Tables[0].Rows[0]["Descriptions"].ToString();

                    if (!checkBoxAMC.Checked == true)
                    {
                        return;
                    }
                    for (int ij = 0; ij < ds.Tables[0].Rows.Count; ij++)
                    {

                        DateTime StartDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AMCStart"].ToString());
                        DateTime FromDate = Convert.ToDateTime(ds.Tables[0].Rows[ij]["AMCStartDate"].ToString());

                        DateTime? ToDate = null;

                        if(ds.Tables[0].Rows[ij]["AMCEndDate"].ToString() != string.Empty)
                        ToDate = Convert.ToDateTime(ds.Tables[0].Rows[ij]["AMCEndDate"].ToString());

                        int Sno = Convert.ToInt32(ds.Tables[0].Rows[0]["Sno"].ToString());

                        if (ij == 0)
                        {
                            amc1.textBox3.Text = (ds.Tables[0].Rows[ij]["AMCAmount"].ToString());
                            if ((ToDate== null) && (panelAMCCount == ij+1))
                            {
                                amc1.textBox2.Text = "-";
                        
                            }
                            else
                            {
                                amc1.textBox2.Text = ((ToDate.Value.Year - StartDate.Year) + 1).ToString();
                            }
                            amc1.textBox1.Text = ((FromDate.Year - StartDate.Year) + 1).ToString();
                        }
                        else
                        {
                            ADD_AmcControl();

                            newAmc.textBox3.Text = (ds.Tables[0].Rows[ij]["AMCAmount"].ToString());
                            if ((ToDate == null) && (panelAMCCount == ij + 1))
                            {
                                newAmc.textBox2.Text = "-";
                            }
                            else
                            {
                                newAmc.textBox2.Text = ((ToDate.Value.Year - StartDate.Year) + 1).ToString();
                                
                            }
                            newAmc.textBox1.Text = ((FromDate.Year - StartDate.Year) + 1).ToString();
                            
                        }
                        dateTimePickerAMC.Value = StartDate; 
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                 Submit_Button();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }
        public void Submit_Button()
        {
            try
            {
                ClientOrderDatabase codb = new ClientOrderDatabase();

                if (Submit.Text == "Submit")
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Insert_ClientOrderDetail("Submit") == 1)
                        {
                            clear();
                        }
                    }

                }
                else if (Submit.Text == "Update")
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Insert_ClientOrderDetail("Update") == 1)
                        {
                            Submit.Text = "Submit";
                            clear();
                            //this.Close();
                        }
                    }
                    #region
                    //if (comboBoxClientName.SelectedValue == null || comboBoxClientName.Text == Helper.DropdownDefaultText.Select || Guid.Parse(comboBoxClientName.SelectedValue.ToString()) == Guid.Empty)
                    //{
                    //    const string type = "Select Client Name";
                    //    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    //    comboBoxClientName.Focus();
                    //    return;
                    //}
                    //else
                    //{
                    //    codb.ClientName = comboBoxClientName.SelectedValue.ToString();
                    //}

                    //if (textBoxOrderNo.Text == string.Empty)
                    //{
                    //    const string type = "Insert Order No";
                    //    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    //    textBoxOrderNo.Focus();
                    //    return;
                    //}
                    //else
                    //codb.ClientOrderNo = Convert.ToInt32(textBoxOrderNo.Text);

                    //if(textBoxDescription.Text !=string.Empty)
                    //codb.Descriptions = textBoxDescription.Text;


                    //codb.OrderDate = dateTimePickerOrderDate.Value;
                    //codb.OrderAmount = Convert.ToDouble(textBoxOrderAmount.Text);
                    //Guid ClientOrderId = ClientOrderID;
                    //codb.ClientOrderID = ClientOrderId;

                    //if (checkBoxAMC.Checked == true)
                    //{
                    //    codb.AMCRequired = 1;

                    //    DataTable dt_AMC = new DataTable();
                    //    dt_AMC.Columns.Add("AMCID", typeof(Guid));
                    //    dt_AMC.Columns.Add("ClientOrderID", typeof(Guid));
                    //    dt_AMC.Columns.Add("AMCAmount", typeof(double));
                    //    dt_AMC.Columns.Add("AMCStartDate", typeof(DateTime));
                    //    dt_AMC.Columns.Add("AMCEndDate", typeof(DateTime));
                    //    dt_AMC.Columns.Add("AMCStart", typeof(DateTime));
                    //    dt_AMC.Columns.Add("Sno", typeof(int));

                    //    DateTime dt_Start = Convert.ToDateTime(dateTimePickerAMC.Text);
                    //    DateTime dt_startdate = DateTime.Now;
                    //    DateTime dt_EndDate = DateTime.Now;
                    //    double f_Amount = 0;
                    //    int sno = 0;
                    //    foreach (Control cn in panel1.Controls)
                    //    {
                    //        if (cn is UserControl)
                    //        {
                    //            sno++;
                    //            Guid g_AMCID = new Guid();
                    //            foreach (Control a in cn.Controls)
                    //            {
                    //                if (a is TextBox)
                    //                {
                    //                    if (a.Location.X == uc_textbox_location1)
                    //                    {
                    //                        dt_startdate = Convert.ToDateTime(dateTimePickerAMC.Text).AddYears(Convert.ToInt32(a.Text) - 1);
                    //                    }
                    //                    if (a.Location.X == uc_textbox_location2)
                    //                    {
                    //                        dt_EndDate = Convert.ToDateTime(dateTimePickerAMC.Text).AddYears(Convert.ToInt32(a.Text) - 1);
                    //                    }
                    //                    if (a.Location.X == uc_textbox_loaction3)
                    //                    {
                    //                        f_Amount = Convert.ToDouble(a.Text);
                    //                    }
                    //                }
                    //            }
                    //            //row added in dt_amc(datatable for amc)
                    //            dt_AMC.Rows.Add(g_AMCID, ClientOrderId, f_Amount, dt_startdate, dt_EndDate, dt_Start,sno);
                    //        }
                    //    }
                    //    codb.pDt_AMC = dt_AMC;   
                    //    //codb.AMCAmount = 0; // cneed
                    //    //codb.AMCStartDate = DateTime.Now;//cneed
                    //    //codb.AMCEndDate = DateTime.Now; // cneed
                    //}
                    //else
                    //{
                    //    codb.AMCRequired = 0;
                    //}


                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int Insert_ClientOrderDetail(string Query)
        {
            try
            {
                ClientOrderDatabase codb = new ClientOrderDatabase();
                #region
                if ((comboBoxClientName.SelectedIndex <= 0)||(comboBoxClientName.Text.ToString() == string.Empty) || (comboBoxClientName.Text == "--Select--"))
                {
                    const string type = "Select Client Name";
                    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    comboBoxClientName.Focus();
                    return 0;
                }
                else
                {
                    codb.CustomerId = Guid.Parse(comboBoxClientName.SelectedValue.ToString());
                }

                if (textBoxOrderNo.Text == string.Empty)
                {
                    const string type = "Insert Order No";
                    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    textBoxOrderNo.Focus();
                    return 0;
                }
                else
                    codb.ClientOrderNo = textBoxOrderNo.Text;

                if (textBoxDescription.Text == string.Empty)
                {
                    //optional
                }
                else codb.Descriptions = textBoxDescription.Text;

                //if (dateTimePickerOrderDate.Value > DateTime.Now)
                //{
                //    const string type = "Please Select the valid Date";
                //    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                //    dateTimePickerOrderDate.Focus();
                //    return;
                //}
                //else
                codb.OrderDate = dateTimePickerOrderDate.Value;

                if (textBoxOrderAmount.Text == string.Empty)
                {
                    const string type = "Please enter amount";
                    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    textBoxOrderAmount.Focus();
                    return 0;
                }
                else
                {
                    codb.OrderAmount = Convert.ToDouble(textBoxOrderAmount.Text);
                }

                codb.ClientOrderID = ClientOrderID;

                if (checkBoxAMC.Checked == true)
                {
                    codb.AMCRequired = 1;

                    DataTable dt_AMC = new DataTable();
                    dt_AMC.Columns.Add("AMCID", typeof(Guid));
                    dt_AMC.Columns.Add("ClientOrderID", typeof(Guid));
                    dt_AMC.Columns.Add("AMCAmount", typeof(double));
                    dt_AMC.Columns.Add("AMCStartDate", typeof(DateTime));
                    dt_AMC.Columns.Add("AMCEndDate", typeof(DateTime));
                    dt_AMC.Columns.Add("AMCStart", typeof(DateTime));
                    dt_AMC.Columns.Add("Sno", typeof(int));

                    DateTime dt_Start = dateTimePickerAMC.Value;
                    DateTime dt_startdate = DateTime.Now;
                    DateTime? dt_EndDate = null;

                    if (dt_Start.Date < dateTimePickerOrderDate.Value.Date)
                    {
                        const string type = "Please enter a valid datetime";
                        MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                        dateTimePickerAMC.Focus();
                        return 0;
                    }
                    double f_Amount = 0;
                    int Sno = 0;
                    int count = 0;
                    foreach (Control cn in panel1.Controls)
                    {
                        if (cn is UserControl)
                        {
                            Sno++;
                        }
                    }
                    foreach (Control cn in panel1.Controls)
                    {
                        if (cn is UserControl)
                        {
                            count++;
                            Guid g_AMCID = new Guid();
                            foreach (Control a in cn.Controls)
                            {
                                if (a is TextBox)
                                {
                                    if (a.Text == string.Empty)
                                    {
                                        const string type = "Insert remaining fields";
                                        MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                                        a.Focus();
                                        return 0;
                                    }
                                    if (a.Location.X == uc_textbox_location1)
                                    {
                                        dt_startdate = Convert.ToDateTime(dateTimePickerAMC.Text).AddYears(Convert.ToInt32(a.Text) - 1).AddDays(1);
                                    }
                                    if (a.Location.X == uc_textbox_location2)
                                    {
                                        if ((a.Text != "-") && (cn.Location.Y == AMC1_Y_Location + ((Sno - 1) * 35)))
                                        {
                                            a.Text = "-";
                                            a.Focus();
                                            return 0;
                                        }
                                        if (a.Text == "-")
                                        {
                                            dt_EndDate = null;
                                            
                                        }
                                        else
                                        {
                                           dt_EndDate = Convert.ToDateTime(dateTimePickerAMC.Text).AddYears(Convert.ToInt32(a.Text) - 1);
                                        }
                                    }
                                    if (a.Location.X == uc_textbox_loaction3)
                                    {
                                        f_Amount = Convert.ToDouble(a.Text);
                                    }
                                }
                            }
                            //row added in dt_amc(datatable for amc)
                            dt_AMC.Rows.Add(g_AMCID, ClientOrderID, f_Amount, dt_startdate, dt_EndDate, dt_Start, count);
                        }
                    }
                    codb.pDt_AMC = dt_AMC;
                    //codb.AMCAmount = 0; // cneed
                    //codb.AMCStartDate = DateTime.Now;//cneed
                    //codb.AMCEndDate = DateTime.Now; // cneed
                }
                else
                {
                    codb.AMCRequired = 0;
                }
                if (codb.InsertClientOrder(Query) == 1)
                {
                    string type = "Successfully";
                    MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    return 1;
                }
                else
                {
                    return 0;
                }
                //codb.InsertClientOrder_Master();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                 ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                return 0;
            }
        }
        
        private void CmbClientName_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CustomerInquiry_Database cidb = new CustomerInquiry_Database();
                e.Result = cidb.Fetch_CustomerName();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void CmbClientName_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CompanyName_Fill(e.Result as DataTable);
                if (ClientOrderID != Guid.Empty)
                {
                    Submit.Text = "Update";
                    FillUpdates();
                }
                else
                {
                    Submit.Text = "Submit";
                }

            }
            catch (Exception ex)
            {
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
                    comboBoxClientName.DataSource = pdt_CompanyName;
                    comboBoxClientName.DisplayMember = DisplayMember;
                    comboBoxClientName.ValueMember = ValueMember;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void amc1_Load(object sender, EventArgs e)
        {
            try
            {
                amc1.textBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace); ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }

        private void textBoxOrderAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.AllowFloatOnly();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (Application.OpenForms.OfType<ClientOrder_Register>().Count() == 1)
                    Application.OpenForms.OfType<ClientOrder_Register>().First().Close();

                ClientOrder_Register
                
                    clientregisterform = new ClientOrder_Register();
                    clientregisterform.MdiParent = this.ParentForm;
                    clientregisterform.Show();
                    clientregisterform.Focus();

                    clear();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
               ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        public void clear()
        {
            try
            {
                comboBoxClientName.SelectedIndex = 0 ;// = "--Select--";
                textBoxDescription.Text = String.Empty;
                textBoxOrderAmount.Text = string.Empty;
                textBoxOrderNo.Text = string.Empty;
                dateTimePickerOrderDate.Value = DateTime.Now;
               
                dateTimePickerAMC.Value = DateTime.Now;

                amc1.textBox2.Text = String.Empty;
                amc1.textBox3.Text = String.Empty;

                panelclear();
                comboBoxClientName.Focus();
                Submit.Text = "Submit";
                Register.Visible = true;
                panelAMCCount = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        public void panelclear()
        {
            try
            {
                // if (checkBoxAMC.Checked == true)
                {
                    Control[] control = null;
                    int controlcount = 0;
                    foreach (Control cn in panel1.Controls)
                    {
                        if (cn is UserControl)
                        {
                            //MessageBox.Show("User control" + cn.Name);
                            if (cn.Location.Y == AMC1_Y_Location)
                            {
                                amc1.textBox2.Text = "-";
                                amc1.textBox3.Text = "";
                                buttonADD.Location = new System.Drawing.Point(17, 47);
                                buttonDelete.Location = new System.Drawing.Point(588, 47);
                                buttonDelete.Visible = false;
                            }
                            else
                            {
                                controlcount++;
                                Array.Resize(ref control, controlcount);
                                control[controlcount - 1] = cn;
                            }

                        }
                    }
                    for (int ij = 0; ij < controlcount; ij++)
                    {
                        panel1.Controls.Remove(control[ij]);
                    }

                    panel1.Enabled = false;
                    checkBoxAMC.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region shortcut keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Control | Keys.S))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Submit_Button();
                    }
                }
                if (keyData == (Keys.F5))
                {
                    if (MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clear();
                        return true;
                    }
                }
                if (keyData == Keys.Escape)
                {
                    Submit.Focus();
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void checkBoxAMC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == (Keys.Enter))
                {
                    if (checkBoxAMC.Checked == true)
                    {
                        checkBoxAMC.Checked = false;
                    }
                    else
                    {
                        checkBoxAMC.Checked = true;
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
        #endregion

        private void comboBoxClientName_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBoxClientName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

    }
}
