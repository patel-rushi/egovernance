using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Data.SqlClient;

//using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using TestingSystems.App_Data;
using TestingSystems;

//using Microsoft.CSharp;
//using Microsoft.CSharp.RuntimeBinder.Binder;


namespace MasterUpload
{
    public partial class Form2 : Form
    {
      
        #region Data Properties
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

       
         
        //SqlConnection scon = new SqlConnection(cnstr);
        SqlConnection scon = new SqlConnection();
         SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public Form2()
        {
            InitializeComponent();
            scon = obj.Con();
          
          

        }
        clsConnection conString = new clsConnection();
        
        SqlCommand scmd = new SqlCommand();
        SqlDataReader dr;
        
        DataTable CustomerMaster_dt = new DataTable();
        DataTable CustomerAddress_dt = new DataTable();
        DataTable CustomerContact_dt = new DataTable();

        DataTable SupplierMaster_dt = new DataTable();
        DataTable SupplieAddress_dt = new DataTable();
        DataTable SupplieContact_dt = new DataTable();

        DataTable Pattern_dt = new DataTable();
        DataTable PatternCustomerMapping_dt = new DataTable();
        DataTable CoreBox_dt = new DataTable();
        DataTable DieMachineMapping_dt = new DataTable();

        DataTable Metal_dt = new DataTable();
        DataTable Casting_dt = new DataTable();
        DataTable CastingMetal_dt = new DataTable();
        DataTable FGRate_dt = new DataTable();

        DataTable PurchaseItem_dt = new DataTable();
        DataTable SupplierItemMapping_dt = new DataTable();
        DataTable RMRate_dt = new DataTable();
        //  DataTable HeatProperties_dt = new DataTable();
        DataTable Machine_dt = new DataTable();
        DataTable Core_dt = new DataTable();
        DataTable RateContract_dt = new DataTable();
        DataTable OpeningStock_dt = new DataTable();

        Int32 j = 0;//Progess Percentage Counter;
        Int32 K = 0;//Remaining Counter;
        Int32 Percentage_Complete = 0;
        Int32 Total_Rows = 0;
        Int32 Process_1_Flag = 0;
        Int32 Process_2_Flag = 0;

        Boolean IsSandFlag = false;
        Boolean IsDieFlag = false;

        bool IsOldCasting = false;
        Boolean _IsBatchWise = false;
        int _UserID = 0;
        int _EntityId = 0;
        Boolean _IsSupplierApproval = false;
        #endregion

        bool CheckIsPattern = true;
        bool AssignValuePatternDie = false;
        int PtrCustomerClick = 1;

      

       

        //private void Form2_Load(object sender, EventArgs e)
        //{
        //    scon = conString.Connection();
        //    scmd.Connection = scon;
        //    scmd.CommandText = "select (cast((ISNULL(IsSandCasting,0)) as INT)) as IsSandCasting,(cast((ISNULL(IsDieCasting,0)) as INT)) as IsDieCasting,(cast((ISNULL(IsInvestmentCasting,0)) as INT)) as IsInvestmentCasting,(cast((ISNULL(IsLostForm,0)) as INT)) as IsLostForm from ProductionMethod";
        //    scon.Open();
        //    dr = scmd.ExecuteReader();
        //    int SandFlag = 0;
        //    int DieFlag = 0;
        //    int InvestFlag = 0;
        //    int LostFlag = 0;
        //    if (dr.Read())
        //    {
        //        SandFlag = dr.GetInt32(0);
        //        DieFlag = dr.GetInt32(1);
        //        InvestFlag = dr.GetInt32(2);
        //        LostFlag = dr.GetInt32(3); 
        //    }
        //    if (!dr.IsClosed)
        //        dr.Close();
        //    scon.Close();

        //    IsSandFlag = false;
        //    IsDieFlag = false;
        //    if (SandFlag == 1 && (DieFlag == 1 || InvestFlag == 1 || LostFlag == 1))
        //    {
        //        IsSandFlag = true;
        //        IsDieFlag = true;
        //    }
        //    else if (SandFlag == 1)
        //    {
        //        IsSandFlag = true;
        //    }
        //    else
        //    {
        //        IsDieFlag = true;
        //    }

            
        //}

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.E))
            {
                lb_ExportFile_LinkClicked(null, null);
            }

           

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void btn_upload_Click(object sender, EventArgs e)
        {
            Int32 Valid = 0;

            

            if (Valid == 0)
            {
                if (txt_PathCMaster.Text == ""
                   
                 
                   )
                {
                    MessageBox.Show("Please select any one file", "Select file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_browseCMaster.Focus();
                    return;
                }
                                
              

     

                this.txt_PathCMaster.Enabled = false;
               
               

                if (!this.Fetch_Work.IsBusy)
                    this.Fetch_Work.RunWorkerAsync();
            }
        }

        private void GetExcelSheetNames(string DB_Path, DataTable dt)
        {
            DataTable dt_ = new DataTable();
            try
            {

                if (DB_Path.Substring(DB_Path.LastIndexOf('.')).ToLower() == ".xlsx")
                    cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DB_Path + ";Extended Properties=\"Excel 12.0;HDR=Yes;\"";
                else
                    cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DB_Path + ";Extended Properties=\"Excel 8.0;HDR=Yes;\"";

                cn.Open();
                cmd.Connection = cn;
                dt_ = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            catch
            {
                MessageBox.Show("Please Action on below instruction " + Environment.NewLine + "    1. Please select valid file to upload record." + Environment.NewLine
                                                                                            + "    2. Please close Excel file whenever you are used." + Environment.NewLine
                                                                                            + "    3. Please Install Oledb access database engine.", "file interrupted.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (dt_.Rows.Count > 0)
                {
                    cmd.CommandText = "select * from [" + dt_.Rows[0]["TABLE_NAME"].ToString() + "]";
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }

                cmd.Parameters.Clear();
                cn.Close();
            }
            catch
            {
                MessageBox.Show("Please Action on below instruction " + Environment.NewLine + "    1. Please select valid file to upload record." + Environment.NewLine 
                                                                                            + "    2. Please close Excel file whenever you are used." + Environment.NewLine                                                                                           + "    3. Please Install Oledb access database engine.", "file interrupted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #region Comment Code

            //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //Excel.Range xlRange;


            //int xlCol, xlRow;
            //xlWorkBook = xlApp.Workbooks.Open(DB_Path);
            //xlWorkSheet = xlWorkBook.ActiveSheet();
            //xlRange = xlWorkSheet.UsedRange;

            //if (xlRange.Columns.Count > 0)
            //{
            //    if (xlRange.Rows.Count > 0)
            //    {
            //        for (xlRow = 2; xlRow < xlRange.Rows.Count; xlRow++)
            //        {
            //            for (xlCol = 1; xlCol < xlRange.Columns.Count; xlCol++)
            //            {
            //                // dt[xlCol -1] = xlRange.Cells[xlRow, xlCol].text;
            //            }
            //            //  dt.LoadDataRow((dt, true);
            //        }
            //        xlWorkBook.Close();
            //        xlApp.Quit();
            //        //KillExcelProcess()
            //    }
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("Please Select Excel File", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            #endregion
        }

        private void Fetch_Work_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //////////////// Customer Master///////////////////////

                if (txt_PathCMaster.Text != "")
                {
                    GetExcelSheetNames(txt_PathCMaster.Text, CustomerMaster_dt);
                }

                //////////////////////// Customer Address /////////////////////////

               

                //////////////////////// Customer Contact /////////////////////////

               

                ////////////////Spectro HeatProperties Excel file///////////////////////
                //if (txtPropertiesFile.Text != "")
                //{
                //    GetExcelSheetNames(txtPropertiesFile.Text, HeatProperties_dt);
                //}

                Process_1_Flag = 1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                cn.Close();
            }
        }

        private void Fetch_Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Process_1_Flag == 1)
            {
                Total_Rows = 0;

                //Bug
                Total_Rows += CustomerMaster_dt.Rows.Count;
                Total_Rows += CustomerAddress_dt.Rows.Count;
                Total_Rows += CustomerContact_dt.Rows.Count;
                //Requirment
                Total_Rows += SupplierMaster_dt.Rows.Count;
                Total_Rows += SupplieAddress_dt.Rows.Count;
                Total_Rows += SupplieContact_dt.Rows.Count;

               
               
                this.Insert_Work.RunWorkerAsync();
            }
        }

        private void Insert_Work_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
              DataTable CustomerMaster_Remain = new DataTable();
                DataTable CustomerAddress_Remain = new DataTable();
                DataTable CustomerContact_Remain = new DataTable();

                

                string Reason = "";
                Int64 SerialNO = 0;
                                              
                #region Customer Master

                //---Remaining Customer Saved in CustomerMaster_Remain------//
                if (CustomerMaster_Remain.Columns.Count <= 0)
                {
                    CustomerMaster_Remain.Columns.Add("CustomerName");
                    CustomerMaster_Remain.Columns.Add("ModuleName");
                    CustomerMaster_Remain.Columns.Add("FormName");
                    CustomerMaster_Remain.Columns.Add("VersionName");


                  
                }
                //------End of Party Manual-----------------------------//

                for (int i = 0; (i < CustomerMaster_dt.Rows.Count); i++) // && !CustomerMaster_dt.Rows[i].IsNull(0); i++)
                {
                    if (CustomerMaster_dt.Rows[i][0].ToString() == "" || CustomerMaster_dt.Rows[i][1].ToString() == "" || CustomerMaster_dt.Rows[i][2].ToString() == "")
                    //0 refers to CustomerName
                    //1 refers to CustomerType
                    //2 refers to CustomerCategory
                    {
                        if (CustomerMaster_dt.Rows[i][0].ToString() == "")
                        {
                            Reason = "Customer Name is Missing";
                        }
                        

                        else if (CustomerMaster_dt.Rows[i][2].ToString() == "")
                        {
                            Reason = "Error Module is Missing";
                        }
                        else if (CustomerMaster_dt.Rows[i][3].ToString() == "")
                        {
                            Reason = " Error Page is Missing";
                        }
                        CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][0].ToString(), Reason);
                        scmd.Parameters.Clear();
                        scon.Close();
                        K = K + 1;
                        System.Threading.Thread.Sleep(10);
                        Percentage_Complete = ((j + K) * 100) / Total_Rows;
                        this.Insert_Work.ReportProgress(j + K);
                       
                    }
                    else
                    {
                        if (scon.State == ConnectionState.Open)
                            scon.Close();
                        
                        scon.Open();
                        scmd.Connection = scon;
                        //Check CustomerName Exists or not
                        scmd.CommandText = "Select CustomerID from CustomerMaster where ( CustomerName=@CustomerName) ";

                        scmd.Parameters.Clear();
                        string CustName = CustomerMaster_dt.Rows[i][0].ToString();
                        CustName = CustName.Trim();
                        scmd.Parameters.AddWithValue("@CustomerName", CustName); 
                        dr = scmd.ExecuteReader();
                        bool CheckForAddUpdate = true;
                        Guid CustomerID = Guid.NewGuid();
                      
                       
                        if (dr.Read())
                        {
                            CustomerID = dr.GetGuid(0);
                            dr.Close();
                           
                        }
                      
                        else
                        {

                            //CheckForAddUpdate = false;
                            //CustomerID = dr.GetGuid(0);
                            if (!dr.Read())
                            {

                                dr.Close();

                                if (scon.State == ConnectionState.Open)
                                    scon.Close();
                                scon.Open();
                                scmd.Connection = scon;
                               CustomerID = Guid.NewGuid();
                                //Check CustomerName Exists or not
                                scmd.CommandText = "insert into  CustomerMaster (CustomerId,CustomerName,Customerflag,IsDeleted) values(@CustomerId,@CustomerName,'C',0)";
                                scmd.Parameters.Clear();
                                scmd.Parameters.AddWithValue("@CustomerId", CustomerID);
                                scmd.Parameters.AddWithValue("@CustomerName", CustomerMaster_dt.Rows[i][0].ToString());

                                if (!dr.IsClosed)
                                    dr.Close();
                                int chkInsert = scmd.ExecuteNonQuery();

                                dr.Close();
                            }

                            else
                            {
                                Reason = "Customer Name already exist";
                                CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][0].ToString(), Reason);
                                if (!dr.IsClosed)
                                    dr.Close();
                                scon.Close();
                                K = K + 1;
                                System.Threading.Thread.Sleep(10);
                                Percentage_Complete = ((j + K) * 100) / Total_Rows;
                                this.Insert_Work.ReportProgress(j + K);
                               
                            }
                        }
                           if (scon.State == ConnectionState.Open)
                            scon.Close();
                        //dr.Close();
                        scon.Open();
                        scmd.Connection = scon;
                        //Check CustomerName Exists or not
                        scmd.CommandText = "Select ID from Module_Master where  Module_Name=@ModuleName";

                        scmd.Parameters.Clear();
                        string ModuleName = CustomerMaster_dt.Rows[i][2].ToString();
                        ModuleName = ModuleName.Trim();
                        scmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                       
                        dr = scmd.ExecuteReader();
                        int Moduleid=0;
                        if (dr.Read())
                        {
                            Moduleid = dr.GetInt32(0);
                            dr.Close();
                        }
                        else
                        {
                            if (!dr.Read())
                            {
                                scon.Close();
                                scon.Open();
                                scmd.Connection = scon;
                                //Check CustomerName Exists or not
                                scmd.CommandText = "Select isnull( MAX( ID ),1) from Module_Master ";

                                dr = scmd.ExecuteReader();
                                if (dr.Read())
                                    Moduleid = dr.GetInt32(0);

                                dr.Close();

                                if (scon.State == ConnectionState.Open)
                                    scon.Close();
                                scon.Open();
                                scmd.Connection = scon;

                                //Check CustomerName Exists or not
                                scmd.CommandText = "insert into  Module_Master (Module_Name) values(@ModuleName)";
                                scmd.Parameters.Clear();
                                scmd.Parameters.AddWithValue("@ModuleName", CustomerMaster_dt.Rows[i][2].ToString());

                                if (!dr.IsClosed)
                                    dr.Close();
                                int chkInsert = scmd.ExecuteNonQuery();


                                dr.Close();

                            }
                            else
                            {

                                Reason = "Module already exist";
                                CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][2].ToString(), Reason);
                                if (!dr.IsClosed)
                                    dr.Close();
                                scon.Close();
                                K = K + 1;
                                System.Threading.Thread.Sleep(10);
                                Percentage_Complete = ((j + K) * 100) / Total_Rows;
                                this.Insert_Work.ReportProgress(j + K);


                            }
                        }

                               ///
                                   if (scon.State == ConnectionState.Open)
                            scon.Close();
                        //dr.Close();
                        scon.Open();
                        scmd.Connection = scon;
                        //Check CustomerName Exists or not
                        scmd.CommandText = "Select ID from Form_Master where  Form_Name=@FormName";

                        scmd.Parameters.Clear();
                        string FormName = CustomerMaster_dt.Rows[i][3].ToString();
                        FormName = FormName.Trim();
                        scmd.Parameters.AddWithValue("@FormName", FormName);
                        int Formid=0;
                        dr = scmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Formid = dr.GetInt32(0);
                            dr.Close();
                        }
                        else
                        {

                            if (!dr.Read())
                            {
                                scon.Close();
                                scon.Open();
                                scmd.Connection = scon;
                                //Check CustomerName Exists or not

                                scmd.CommandText = "Select isnull( MAX( ID ),1)  from Form_Master ";

                                dr = scmd.ExecuteReader();
                                if (dr.Read())
                                    Formid = dr.GetInt32(0);

                                dr.Close();

                                if (scon.State == ConnectionState.Open)
                                    scon.Close();
                                scon.Open();
                                scmd.Connection = scon;
                                Guid CustTtypeID = Guid.NewGuid();
                                //Check CustomerName Exists or not
                                scmd.CommandText = "insert into  Form_Master (Form_Name) values(@FormName)";
                                scmd.Parameters.Clear();
                                scmd.Parameters.AddWithValue("@FormName", CustomerMaster_dt.Rows[i][3].ToString());

                                if (!dr.IsClosed)
                                    dr.Close();
                                int chkInsert = scmd.ExecuteNonQuery();

                                dr.Close();

                            }
                            else
                            {

                                Reason = "Form already exist";
                                CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][2].ToString(), Reason);
                                if (!dr.IsClosed)
                                    dr.Close();
                                scon.Close();
                                K = K + 1;
                                System.Threading.Thread.Sleep(10);
                                Percentage_Complete = ((j + K) * 100) / Total_Rows;
                                this.Insert_Work.ReportProgress(j + K);


                            }
                        }
                        
                            ///
                            if (scon.State == ConnectionState.Open)
                                scon.Close();
                            //dr.Close();
                            scon.Open();
                            scmd.Connection = scon;

                            //Check CustomerName Exists or not
                            scmd.CommandText = "Select ID from Version_Master where   VersionName=@VersionName";

                            scmd.Parameters.Clear();
                            string VersionName = string.Empty;
                             VersionName = CustomerMaster_dt.Rows[i][5].ToString();
                            VersionName = VersionName.Trim();
                            scmd.Parameters.AddWithValue("@VersionName", VersionName);

                            dr = scmd.ExecuteReader();

                            int Versionid=0;
                            if (dr.Read())
                            {
                                Versionid = dr.GetInt32(0);
                                dr.Close();
                            }
                            else
                            {

                                if (!dr.Read())
                                {
                                   

                                    if (scon.State == ConnectionState.Open)
                                        scon.Close();
                                    scon.Open();
                                    scmd.Connection = scon;
                                    if (CustomerMaster_dt.Rows[i][5].ToString() != string.Empty)
                                    {
                                        //Check CustomerName Exists or not
                                        scmd.CommandText = "insert into  Version_Master (VersionName) values(@VersionName)";
                                        scmd.Parameters.Clear();
                                        scmd.Parameters.AddWithValue("@VersionName", CustomerMaster_dt.Rows[i][5].ToString());

                                        if (!dr.IsClosed)
                                            dr.Close();
                                        int chkInsert = scmd.ExecuteNonQuery();

                                        dr.Close();
                                        scon.Close();
                                        
                                    }
                                    scon.Close();
                                    scon.Open();
                                    scmd.Connection = scon;
                                    //Check CustomerName Exists or not
                                    scmd.CommandText = "Select isnull( MAX( ID ),1)  from Version_Master ";

                                    dr = scmd.ExecuteReader();
                                    if (dr.Read())
                                        Versionid = dr.GetInt32(0);


                                    dr.Close();

                                }
                                else
                                {



                                    Reason = "Form already exist";
                                    CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][5].ToString(), Reason);
                                    if (!dr.IsClosed)
                                        dr.Close();
                                    scon.Close();
                                    K = K + 1;
                                    System.Threading.Thread.Sleep(10);
                                    Percentage_Complete = ((j + K) * 100) / Total_Rows;
                                    this.Insert_Work.ReportProgress(j + K);


                                }
                            }
                        //
                            if (scon.State == ConnectionState.Open)
                                scon.Close();

                            scon.Open();
                            scmd.Connection = scon;
                            //Check CustomerName Exists or not
                            scmd.CommandText = "Select id from Reprasentative where ( ReprasentativeName=@Reprasentative) ";

                            scmd.Parameters.Clear();
                            string Reprasentative = CustomerMaster_dt.Rows[i][8].ToString();
                            Reprasentative = Reprasentative.Trim();
                            scmd.Parameters.AddWithValue("@Reprasentative", Reprasentative);
                            dr = scmd.ExecuteReader();
                          //  bool CheckForAddUpdate = true;
                            Guid ReprasentativeID = Guid.NewGuid();


                            if (dr.Read())
                            {
                                ReprasentativeID = dr.GetGuid(0);
                                dr.Close();

                            }

                          else 
                            {

                                //CheckForAddUpdate = false;
                                //CustomerID = dr.GetGuid(0);
                                if (!dr.Read())
                                {

                                    dr.Close();

                                    if (scon.State == ConnectionState.Open)
                                        scon.Close();
                                    scon.Open();
                                    scmd.Connection = scon;
                                    ReprasentativeID = Guid.NewGuid();
                                    //Check CustomerName Exists or not
                                    scmd.CommandText = "insert into  Reprasentative (Id,ReprasentativeName) values(@ReprasentativeId,@ReprasentativeName)";
                                    scmd.Parameters.Clear();
                                    scmd.Parameters.AddWithValue("@ReprasentativeId", ReprasentativeID);
                                    scmd.Parameters.AddWithValue("@ReprasentativeName", CustomerMaster_dt.Rows[i][8].ToString());

                                    if (!dr.IsClosed)
                                        dr.Close();
                                    int chkInsert = scmd.ExecuteNonQuery();

                                    dr.Close();
                                }

                                else
                                {
                                    Reason = " Reprasentative Name already exist";
                                    CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][8].ToString(), Reason);
                                    if (!dr.IsClosed)
                                        dr.Close();
                                    scon.Close();
                                    K = K + 1;
                                    System.Threading.Thread.Sleep(10);
                                    Percentage_Complete = ((j + K) * 100) / Total_Rows;
                                    this.Insert_Work.ReportProgress(j + K);

                                }
                            }
                            if (scon.State == ConnectionState.Open)
                                scon.Close();
                            //dr.Close();
                            scon.Open();
                            scmd.Connection = scon;
                        //
                            dr.Close();

                            if (scon.State == ConnectionState.Open)
                                scon.Close();
                            scon.Open();
                            scmd.Connection = scon;
                           
                            //Check CustomerName Exists or not
                            if (CustomerMaster_dt.Rows[i][0].ToString()!=string.Empty)
                            {
                                scmd.CommandText = "insert into  IssueTicket (Ticket_ID,User_ID,ModuleID,FormID,VersionID,Description,EntryDate,IssueDate,IsDeleted,Client_ID,Priority,STATUS,ReportedBy,ReprasentativeID,TicketType) values(NewID(),1,@ModluleID,@FormID,@VersionID,@Description,getdate(),@IssueDate,0,@CustomerID,@Priority,@Status,@ReportedThrough,@ReprasentativeID,@TicketType)";
                            scmd.Parameters.Clear();
                        
                            scmd.Parameters.AddWithValue("@ModluleID", Moduleid);
                            scmd.Parameters.AddWithValue("@Description", CustomerMaster_dt.Rows[i][4].ToString());
                            scmd.Parameters.AddWithValue("@FormID", Formid);
                            scmd.Parameters.AddWithValue("@VersionID", Versionid);
                            scmd.Parameters.AddWithValue("@IssueDate", CustomerMaster_dt.Rows[i][10].ToString());
                            scmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                            scmd.Parameters.AddWithValue("@Status", CustomerMaster_dt.Rows[i][6].ToString());
                            scmd.Parameters.AddWithValue("@Priority", CustomerMaster_dt.Rows[i][1].ToString());
                            scmd.Parameters.AddWithValue("@ReportedThrough", CustomerMaster_dt.Rows[i][7].ToString());
                            scmd.Parameters.AddWithValue("@ReprasentativeID", ReprasentativeID);
                            int  Tickety =Convert.ToInt32( CustomerMaster_dt.Rows[i][9].ToString());
                            scmd.Parameters.AddWithValue("@TicketType", Tickety);   
                           
                            if (!dr.IsClosed)
                                dr.Close();
                             scmd.ExecuteNonQuery();

                            dr.Close();
                            scon.Close(); ;
                            }


                        

                        //end  Check CustomerName Exists or not

                        //#region Check For Customer Type

                        //if (scon.State == ConnectionState.Open)
                        //    scon.Close();
                        //if (!dr.IsClosed)
                        //    dr.Close();
                        //scon.Open();
                        //scmd.Connection = scon;

                        ////Check CustomerName Exists or not
                        //scmd.CommandText = "select CustomerTypeId from CustomerTypeMaster where TypeName =@TypeName";
                        //scmd.Parameters.AddWithValue("@TypeName", CustomerMaster_dt.Rows[i][1].ToString());

                        //dr = scmd.ExecuteReader();
                        //Guid CustTtypeID = new Guid();
                        //string TypeCode = "";
                        //bool IsNotFound = true;
                        //if (dr.HasRows == false)
                        //{
                        //    IsNotFound = false;
                        //}
                        //if (dr.Read() && IsNotFound == true)
                        //{
                        //    CustTtypeID = dr.GetGuid(0);
                        //    dr.Close();
                        //}
                        //else
                        //{
                        //    dr.Close();
                        //    if (scon.State == ConnectionState.Open)
                        //        scon.Close();
                        //    scon.Open();
                        //    scmd.Connection = scon;

                        //    scmd.CommandText = "select RIGHT('00' + CONVERT(VARCHAR(100), ISNULL(MAX(TypeCode), 0) + 1), 3) AS TypeCode from CustomerTypeMaster";
                        //    dr = scmd.ExecuteReader();
                        //    TypeCode = "";
                        //    if (dr.Read())
                        //    {
                        //        TypeCode = dr.GetString(0);
                        //        dr.Close();

                        //        if (scon.State == ConnectionState.Open)
                        //            scon.Close();
                        //        scon.Open();
                        //        scmd.Connection = scon;
                        //        CustTtypeID = Guid.NewGuid();
                        //        //Check CustomerName Exists or not
                        //        scmd.CommandText = "insert into  CustomerTypeMaster (CustomerTypeId,TypeName,TypeCode,IsDeleted,TypeShortCode,CreatedOn,CreatedBy,EntityId) values(@CustomerTypeId,@TypeName,@TypeCode,@IsDeleted,@TypeShortCode,@CreatedOn,@CreatedBy,@EntityId)";
                        //        scmd.Parameters.Clear();
                        //        scmd.Parameters.AddWithValue("@CustomerTypeId", CustTtypeID);
                        //        scmd.Parameters.AddWithValue("@TypeName", CustomerMaster_dt.Rows[i][1].ToString());
                        //        scmd.Parameters.AddWithValue("@TypeCode", TypeCode);
                        //        scmd.Parameters.AddWithValue("@TypeShortCode", TypeCode);
                        //        scmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //        scmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                        //        scmd.Parameters.AddWithValue("@CreatedBy", _UserID);
                        //        scmd.Parameters.AddWithValue("@EntityId", _EntityId);
                        //        if (!dr.IsClosed)
                        //            dr.Close();
                        //        int chkInsert = scmd.ExecuteNonQuery();

                        //        if (chkInsert == 1)
                        //        {
                        //            if (!dr.IsClosed)
                        //                dr.Close();
                        //        }
                        //        else
                        //        {
                        //            if (!dr.IsClosed)
                        //                dr.Close();
                        //            Reason = "Not found CustomerType";
                        //            CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][0].ToString(), CustomerMaster_dt.Rows[i][1].ToString(), CustomerMaster_dt.Rows[i][2].ToString(), Reason);
                        //            K = K + 1;
                        //            System.Threading.Thread.Sleep(10);
                        //            Percentage_Complete = ((j + K) * 100) / Total_Rows;
                        //            this.Insert_Work.ReportProgress(j + K);
                        //            continue;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (!dr.IsClosed)
                        //            dr.Close();
                        //        Reason = "Not found CustomerType";
                        //        CustomerMaster_Remain.Rows.Add(CustomerMaster_dt.Rows[i][0].ToString(), CustomerMaster_dt.Rows[i][1].ToString(), CustomerMaster_dt.Rows[i][2].ToString(), Reason);
                        //        K = K + 1;
                        //        System.Threading.Thread.Sleep(10);
                        //        Percentage_Complete = ((j + K) * 100) / Total_Rows;
                        //        this.Insert_Work.ReportProgress(j + K);
                        //        continue;
                        //    }
                        //}

                        //#endregion
                    }
                       
                        }
                       
                          }
            
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                Process_2_Flag = 0;
            }
            finally
            {
                scon.Close();
            }
        }

        private void Insert_CoreCastingMapping(Guid CoreBoxID, Guid Castingid , Guid PatternID)
        {
            try
            {
                #region Core Casting Mapping

               // Guid Castingid = new Guid();

                dr.Close();
                if (scon.State == ConnectionState.Open)
                    scon.Close();
                scon.Open();
                scmd.Connection = scon;

                scmd.CommandText = "select CastingMaster.CastingId,CastingMaster.CastingCode from CastingMaster"
                                    + " inner join PatternMaster on PatternMaster.PatternId = CastingMaster.Dieid"
                                    + " where (PatternId = @PatternId)"
                                    + " And CastingMaster.ParentID IS NULL";

                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@PatternId", PatternID);
                dr = scmd.ExecuteReader();               
                if (dr.Read())
                {
                    if (dr.FieldCount > 1)
                    {
                      // string Reason = "Multiple found Casting Mapping";
                       return;
                    }
                    else if (dr.FieldCount == 0)
                    {
                        Castingid = dr.GetGuid(0);
                        dr.Close();
                    }                    
                }


                if (Castingid != null && Castingid != Guid.Empty)
                {
                    scmd.Parameters.Clear();
                    scmd.CommandText = "INSERT  INTO CoreCastingMapping ( CoreMappingId,CoreBoxID, CastingId ) values (@CoreMappingId,@CoreBoxID,@CastingId)";
                    scmd.Parameters.AddWithValue("@CoreMappingId", Guid.NewGuid());
                    scmd.Parameters.AddWithValue("@CoreBoxID", CoreBoxID);
                    scmd.Parameters.AddWithValue("@CastingId", Castingid);
                    if (!dr.IsClosed)
                        dr.Close();
                    scmd.ExecuteNonQuery();
                }


                #endregion
            }
            catch { }

        }

        private string GetValueForBlank(string CrntVal)
        {
            try
            {
                string UpdateVal = CrntVal;
                UpdateVal = UpdateVal.Trim();
                if (UpdateVal == "")
                    return "0";
                return UpdateVal;
            }
            catch
            { }
            return "0";
        }

        private void Insert_Work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           

        }

        private void Insert_Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
                System.Windows.Forms.MessageBox.Show("File Upload interrupted.");
            

            CheckIsPattern = true;
            AssignValuePatternDie = false;
            PtrCustomerClick = 1;

            txt_PathCMaster.Text = "";
          
           
            CustomerMaster_dt = new DataTable();
            CustomerAddress_dt = new DataTable();
            CustomerContact_dt = new DataTable();

            SupplierMaster_dt = new DataTable();
            SupplieAddress_dt = new DataTable();
            SupplieContact_dt = new DataTable();

            Pattern_dt = new DataTable();
            PatternCustomerMapping_dt = new DataTable();
            CoreBox_dt = new DataTable();
            DieMachineMapping_dt = new DataTable();

            


            j = 0;//Progess Percentage Counter;
            K = 0;//Remaining Counter;

            Percentage_Complete = 0;
            Total_Rows = 0;
            Process_1_Flag = 0;
            Process_2_Flag = 0;
        }

        private void btn_can_Click(object sender, EventArgs e)
        {

            try
            {
                this.Insert_Work.CancelAsync();

               

                CustomerMaster_dt = new DataTable();
                CustomerAddress_dt = new DataTable();
                CustomerContact_dt = new DataTable();

                SupplierMaster_dt = new DataTable();
                SupplieAddress_dt = new DataTable();
                SupplieContact_dt = new DataTable();

                Pattern_dt = new DataTable();
                PatternCustomerMapping_dt = new DataTable();
                CoreBox_dt = new DataTable();
                DieMachineMapping_dt = new DataTable();


                Metal_dt = new DataTable();
                Casting_dt = new DataTable();
                CastingMetal_dt = new DataTable();
                FGRate_dt = new DataTable();

                PurchaseItem_dt = new DataTable();
                SupplierItemMapping_dt = new DataTable();
                RMRate_dt = new DataTable();

                Machine_dt = new DataTable();
                Core_dt = new DataTable();
                RateContract_dt = new DataTable();
                OpeningStock_dt = new DataTable();
                // HeatProperties_dt = new DataTable();

                btn_upload.Enabled = true;


                j = 0;//Progess Percentage Counter;
                K = 0;//Remaining Counter;

                Percentage_Complete = 0;
                Total_Rows = 0;
                Process_1_Flag = 0;
                Process_2_Flag = 0;

               

                CheckIsPattern = true;
                AssignValuePatternDie = false;
                PtrCustomerClick = 1;

                //if (scon.State == ConnectionState.Open)
                //    scon.Close();
                //scon.Open();
                //dr.Close();
                //scmd.Connection = scon;
                //scmd.CommandText = "Select FoundryMethod from configuration";

                //dr = scmd.ExecuteReader();
                //int sandordie = 0;
                //if (dr.Read())
                //{
                //    sandordie = dr.GetInt32(0);
                //}
                //scon.Close();

                //if (sandordie == 0)
                //    IsSandOrDie = true;
                //else
                //    IsSandOrDie = false;

               
            }
            catch
            { }
            //this.Insert_Work.RunWorkerAsync();
        }

        private void btn_browse3_Click(object sender, EventArgs e)
        {
            File_Dialog_Matle.ShowDialog();
        }

        private void btn_empty_Click(object sender, EventArgs e)
        {
            //scmd.Connection = scon;
            //scon.Open();

            //string str = "truncate table CustomerPatternMapping; ";
            //str += "Truncate Table AddressMaster; ";
            //str += "truncate table ContactMaster; ";
            //str += "truncate table CoreBoxDetails; ";
            //str += "truncate table MetalMaster; ";
            //str += "truncate table CastingMaster; ";
            //str += "truncate table CastingMetal; ";
            //str += "truncate table PurchaseItemMaster; ";
            //str += "delete from CustomerMaster; ";
            //str += "delete from PatternMaster; ";
            //scmd.CommandText = str;
            //scmd.ExecuteNonQuery();

            //scon.Close();

            //System.Windows.Forms.MessageBox.Show("All the data has been Truncated");
        }

        private void btn_empty_master_Click(object sender, EventArgs e)
        {

            //scmd.Connection = scon;
            //scon.Open();


            //scmd.CommandText = "truncate table BOQ_Item_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table BOQ_Item_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table RouteCardEst_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table RouteCardEst_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table Invoice_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table Invoice_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table Item_Attribute";
            //scmd.ExecuteNonQuery();

            //scmd.CommandText = "truncate table Item_Order_Code";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table Marketing_Report_Log_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table NC_Stock";
            //scmd.ExecuteNonQuery();

            //scmd.CommandText = "truncate table Payroll";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "truncate table Question_Master";
            //scmd.ExecuteNonQuery();

            //scmd.CommandText = "Truncate table Boq_master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table BOQ_Master_Temp";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table BOQ_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table BOQ_Trans_Temp";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Challan_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Challan_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table  Indent_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Indent_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Inquiry_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Inquiry_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Issue_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Order_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Order_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Heat_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table HeatCasTMapping";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Heat_Item_Mapping";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Rejection_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table QC_Trans";
            //scmd.ExecuteNonQuery();


            //scmd.CommandText = "Truncate Table Pattern_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Quotation_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table Quotation_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate table RateContract";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Heat_Transcation";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Heat_Treatment_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Heat_Treatment_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table TC_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table TC_Template_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table TC_Template_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Test_Certficate";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table GRN_Master";
            //scmd.ExecuteNonQuery();
            ////scmd.CommandText = "Truncate Table Manpower_Master";
            ////scmd.ExecuteNonQuery();
            ////scmd.CommandText = "Truncate Table Manpower_Trans";
            ////scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Material_Consumption";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Sales_Return_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Sales_Return_Trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Update Store_Trans Set Stock=0";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Inquriy_Quotation_Process";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Issue_Indent_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Issue_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Order_Master";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Rate_History";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Order_Process";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Batch_Transcation";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Order_Trans_Direct";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Invoice_Trans_Direct";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table invoice_heatwise_tracking";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table pattern_return_trans";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table OnFloorStock";
            //scmd.ExecuteNonQuery();
            //scmd.CommandText = "Truncate Table Stock_trans_History";
            //scmd.ExecuteNonQuery();
            //scon.Close();

            //System.Windows.Forms.MessageBox.Show("All The Transaction Data has been Truncated");
        }

        #region Select File Button Events

        // For Customer Master Import Record
        private void button1_Click(object sender, EventArgs e)
        {
            File_Dialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog.ShowDialog();
        }

        private void File_Dialog_FileOk(object sender, CancelEventArgs e)
        {
            txt_PathCMaster.Text = File_Dialog.FileName.ToString();

            String Extension = System.IO.Path.GetExtension(txt_PathCMaster.Text);

            if (Extension == ".xls" || Extension == ".XLS" || Extension == ".xlsx" || Extension == ".XLSX")
            {

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select .xlsx or .xls file.");

                File_Dialog.FileName = "";

                txt_PathCMaster.Text = "";
            }
        }

        // For Customer Address Import Record
        private void btn_browseCAddress_Click(object sender, EventArgs e)
        {
            File_Dialog_CAddress.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_CAddress.ShowDialog();
        }

        private void File_Dialog_CAddress_FileOk(object sender, CancelEventArgs e)
        {
          

           
           
        }

        // For Customer Contact Import Record
        private void btn_browseCContact_Click(object sender, EventArgs e)
        {
            File_Dialog_CContact.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_CContact.ShowDialog();
        }

        private void File_Dialog_CContact_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        // For Supplier Master Import Record
        private void btn_browseSMaster_Click(object sender, EventArgs e)
        {
            File_Dialog_SMaster.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_SMaster.ShowDialog();
        }

        private void File_Dialog_SMaster_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Supplier Address Import Record
        private void btn_browseSAddress_Click(object sender, EventArgs e)
        {
            File_Dialog_SAddress.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_SAddress.ShowDialog();
        }

        private void File_Dialog_SAddress_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Supplier Contact Import Record
        private void btn_browseSContact_Click(object sender, EventArgs e)
        {
            File_Dialog_SContact.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_SContact.ShowDialog();
        }

        private void File_Dialog_SContact_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Matle Import Record
        private void btn_browseMatle_Click(object sender, EventArgs e)
        {
            File_Dialog_Matle.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_Matle.ShowDialog();
        }

        private void File_Dialog3_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Pattern Import Record
       
        private void btn_browse2_Click(object sender, EventArgs e)
        {
           
        }

        private void File_Dialog2_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Pattern Customer Mapping Import Record
       
        private void btn_browsePatternCustomerMapping_Click(object sender, EventArgs e)
        {
           
        }

        private void File_Dialog_PatternCustomerMapping_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Core Box Import Record
        private void btn_browseCoreBox_Click(object sender, EventArgs e)
        {
            PtrCustomerClick = 3;
            if (AssignValuePatternDie == false)
            {
               
                if (IsSandFlag)
                {
                    CheckIsPattern = true;
                    AssignValuePatternDie = true;
                    File_Dialog_CoreBox.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                    File_Dialog_CoreBox.ShowDialog();
                }
                else
                {
                    CheckIsPattern = false;
                    AssignValuePatternDie = true;
                    File_Dialog_CoreBox.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                    File_Dialog_CoreBox.ShowDialog();
                }
            }
            else
            {
                File_Dialog_CoreBox.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_CoreBox.ShowDialog();
            }
           
        }

        private void File_Dialog_CoreBox_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Casting Import Record
        private void btn_browse4_Click(object sender, EventArgs e)
        {
            File_Dialog_Casting.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_Casting.ShowDialog();
        }

        private void File_Dialog4_FileOk_1(object sender, CancelEventArgs e)
        {
            
        }

        // For Casting Metal Import Record
        private void btn_browseCastingMetal_Click(object sender, EventArgs e)
        {
            File_Dialog_CastingMetal.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_CastingMetal.ShowDialog();
        }

        private void File_Dialog_CastingMetal_FileOk(object sender, CancelEventArgs e)
        {
            

        }

        // For FG Rate Import Record
        private void btn_browseFGRate_Click(object sender, EventArgs e)
        {
            File_Dialog_FGRate.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_FGRate.ShowDialog();
        }

        private void File_Dialog_FGRate_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Purchase Item Import Record
        private void btn_browse6_Click(object sender, EventArgs e)
        {
            File_Dialog_PurchaseItem.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_PurchaseItem.ShowDialog();
        }

        private void File_Dialog6_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Supplier Item Mapping Import Record
        private void btn_browseSupplierItemMapping_Click(object sender, EventArgs e)
        {
            File_Dialog_SupplierItemMapping.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_SupplierItemMapping.ShowDialog();
        }

        private void File_Dialog_SupplierItemMapping_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For RM Rate Import Record
        private void btn_browseRMRate_Click(object sender, EventArgs e)
        {
            File_Dialog_RMRate.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_RMRate.ShowDialog();
        }

        private void File_Dialog_RMRate_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Machine Import Record
        private void btn_browseMachine_Click(object sender, EventArgs e)
        {
            File_Dialog_Machine.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            File_Dialog_Machine.ShowDialog();
        }

        private void File_Dialog_Machine_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        // For Core Import Record
        private void btn_browseCore_Click(object sender, EventArgs e)
        {
            try
            {
                File_Dialog_Core.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_Core.ShowDialog();
            }
            catch
            {
            }
        }

        private void File_Dialog_Core_FileOk(object sender, CancelEventArgs e)
        {
            

        }

        #endregion

        private void lb_ExportFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form3 objExportDB = new Form3();
            //objExportDB.MdiParent = this.MdiParent;
            //objExportDB.Show();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Windows.Forms.MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        #region Remove entries click event

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show("Remove Entries?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;

                scmd = new SqlCommand("spTruncateTable", scon);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@AllFlag", 0);
                scmd.Parameters.AddWithValue("@UserID", _UserID);
                scon.Open();
                if (!dr.IsClosed)
                    dr.Close();
                scmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Entries removed Successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                scon.Close();
            }
        }

        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show("Remove Entries?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;

                scmd = new SqlCommand("spTruncateTable", scon);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@AllFlag", 1);
                scmd.Parameters.AddWithValue("@UserID", _UserID);
                scon.Open();
                if (!dr.IsClosed)
                    dr.Close();
                scmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Entries and masters removed Successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                scon.Close();
            }
        }

        private void btn_RemoveSalesEntrieswithMasters_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Windows.Forms.MessageBox.Show("Remove Entries?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;

                scmd = new SqlCommand("spTruncateTable", scon);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@parameter", 1);
                scmd.Parameters.AddWithValue("@UserID", _UserID);
                scon.Open();
                if (!dr.IsClosed)
                    dr.Close();
                scmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Entries and masters removed Successfully.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                scon.Close();
            }
        }

        #endregion

        private void Form2_Enter(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
            }
            catch
            {
            }
        }

        #region Clear Button Click Events

        private void btClrCustomer_Click(object sender, EventArgs e)
        {
            txt_PathCMaster.Text = "";
        }

        private void btClrCAddress_Click(object sender, EventArgs e)
        {
           
        }

       

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_browseOpeningStock_Click(object sender, EventArgs e)
        {
            try
            {
                File_Dialog_OpeningStock.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_OpeningStock.ShowDialog();
            }
            catch
            {
            }
        }

        private void btClrOpeningStock_Click(object sender, EventArgs e)
        {
           
        }

        private void File_Dialog_OpeningStock_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void btnPatternUpdate_Click(object sender, EventArgs e)
        {
            
            if (PtrCustomerClick == 1)
            {
                File_Dialog_Pattern.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_Pattern.ShowDialog();
            }
            else if(PtrCustomerClick == 2)
            {       
                File_Dialog_PatternCustomerMapping.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_PatternCustomerMapping.ShowDialog();
            }
            else 
            {
                File_Dialog_CoreBox.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
                File_Dialog_CoreBox.ShowDialog();
            }
        }

        private void btnCloseMaster_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnBrowseProperties_Click(object sender, EventArgs e)
        //{
        //    FD_PropertiesFile.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
        //    FD_PropertiesFile.ShowDialog();
        //}

        //private void FD_PropertiesFile_FileOk(object sender, CancelEventArgs e)
        //{
        //    txtPropertiesFile.Text = FD_PropertiesFile.FileName.ToString();

        //    String Extension = System.IO.Path.GetExtension(txtPropertiesFile.Text);

        //    if (Extension == ".xls" || Extension == ".XLS" || Extension == ".xlsx" || Extension == ".XLSX")
        //    {

        //    }
        //    else
        //    {
        //        System.Windows.Forms.MessageBox.Show("Please select .xlsx or .xls file.");

        //        FD_PropertiesFile.FileName = "";

        //        txtPropertiesFile.Text = "";
        //    }
        //}
                #endregion
    }
}