using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsProcess
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsProcess()
        {
            con = obj.Con();
        }

        #region Properties

        public String ProcessCode { get; set; }

        private int _Created_By;

        public int Created_By
        {
            get
            {
                return _Created_By;
            }
            set
            {
                _Created_By = value;
            }

        }

        private int _IsDeleted;

        public int IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
            }

        }

        private Guid _ProcessId;

        public Guid ProcessId
        {
            get
            {
                return _ProcessId;
            }
            set
            {
                _ProcessId = value;
            }
        }

        private Guid _OtherProcessId;

        public Guid OtherProcessId
        {
            get
            {
                return _OtherProcessId;
            }
            set
            {
                _OtherProcessId = value;
            }
        }

        private DateTime _Created_On;

        public DateTime Created_On
        {
            get
            {
                return _Created_On;
            }
            set
            {
                _Created_On = value;
            }
        }

        private DateTime _Modified_On;

        public DateTime Modified_On
        {
            get
            {
                return _Modified_On;
            }
            set
            {
                _Modified_On = value;
            }
        }

        private int _Modified_By;

        public int Modified_By
        {
            get
            {
                return _Modified_By;
            }
            set
            {
                _Modified_By = value;
            }
        }

        private String _ProcessName;

        public String ProcessName
        {
            get
            {
                return _ProcessName;
            }
            set
            {
                _ProcessName = value;
            }
        }

        private String _Remarks;

        public String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        private String _MenuName;

        public String MenuName
        {
            get
            {
                return _MenuName;
            }
            set
            {
                _MenuName = value;
            }
        }

        public Boolean _AutoProcess { get; set; }
        public Boolean ProcessInspection { get; set; }
       // public Boolean ProcessPerform { get; set; }
        public Boolean IsProcessTransferModule { get; set; }
        public Boolean IsMachineShop { get; set; }

        public DataTable dtDepartment { get; set; }
        

        public string ShortCode { get; set; }
        public string ShortCodeComplete { get; set; }
        public string ShortCodeInspection { get; set; }

        public string DisplayName { get; set; }
        public string DisplayNameComplete { get; set; }
        public string DisplayNameInspection { get; set; }

        //public Guid _Customer_ID { get; set; }
        //public Guid _Casting_ID { get; set; }
        //public string _Casting_Name { get; set; }
        public Int32 SerialNo { get; set; }
        public Int32 OtherSerialNo { get; set; }
        public Guid Casting_Id { get; set; }
        public Guid Report_Id { get; set; }
        public Int32 ReferenceType { get; set; }
       // public Int32 HrTime { get; set; }
        public Int32 MinTime { get; set; }
        public Int32 SecTime { get; set; }
        public Guid ReferenceId { get; set; }
        public int EmpReferenceId { get; set; }
        public Guid ProdProcessMappingId { get; set; }
        public bool ProcessWiseSeparatePage { get; set; }
        public bool CreateNewMenuStatus { get; set; }
        //public Int32 OtherSerialNo { get; set; }
        public Double Ton { get; set; }

        public bool IsReworkProcess { get; set; }

        #endregion
        public int DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }


        public Int32 InsertProcessMaster()             //Save in ProcessMaster
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@ProcessName", _ProcessName);

                cmd.Parameters.AddWithValue("@MenuName", _MenuName);
                cmd.Parameters.AddWithValue("@ProcessWiseSeparatePage", ProcessWiseSeparatePage);
                cmd.Parameters.AddWithValue("@MenuStatus", CreateNewMenuStatus);
                cmd.Parameters.AddWithValue("@Remarks", _Remarks);

                cmd.Parameters.AddWithValue("@SequenceNo", SerialNo);

                cmd.Parameters.AddWithValue("@CreatedBy", _Created_By);

                cmd.Parameters.AddWithValue("@CreatedOn", _Created_On);
                cmd.Parameters.AddWithValue("@ProcessInspection", ProcessInspection);
                //cmd.Parameters.AddWithValue("@ProcessPerform", ProcessPerform);
                cmd.Parameters.AddWithValue("@IsProcessTransferModule", IsProcessTransferModule);
               
                cmd.Parameters.AddWithValue("@AutoProcess", _AutoProcess);

                if (ShortCode.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@ShortCode", ShortCode);
                if (ShortCodeComplete.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@ShortCodeComplete", ShortCodeComplete);
                if (ShortCodeInspection.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@ShortCodeInspection", ShortCodeInspection);

                if (DisplayName.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
                if (DisplayNameComplete.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@DisplayNameComplete", DisplayNameComplete);
                if (DisplayNameInspection.Trim() != string.Empty)
                cmd.Parameters.AddWithValue("@DisplayNameInspection", DisplayNameInspection);

                if (MinTime > 0)
                    cmd.Parameters.AddWithValue("@min", MinTime);
                if (SecTime > 0)
                    cmd.Parameters.AddWithValue("@sec", SecTime);
                if (Ton > 0)
                    cmd.Parameters.AddWithValue("@ton", Ton);
                cmd.Parameters.AddWithValue("@IsMachineShop", IsMachineShop);

                cmd.Parameters.AddWithValue("@IsReworkProcess", IsReworkProcess);


                string XML_Department = "";

                using (StringWriter dept = new StringWriter())
                {
                    dtDepartment.TableName = "DepartmentDetail";

                    dtDepartment.WriteXml(dept);

                    XML_Department = dept.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                }

                cmd.Parameters.AddWithValue("@DepartmentDetail", XML_Department);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        public DataTable FetchProcessDetails()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public DataTable Fetch_ProductionProcessMapping()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                if(ProcessId != null && ProcessId != Guid.Empty)
                cmd.Parameters.AddWithValue("@ProcessId", ProcessId);

                if (ReferenceId != null && ReferenceId != Guid.Empty)
                cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);

                if (ProdProcessMappingId != null && ProdProcessMappingId != Guid.Empty)
                cmd.Parameters.AddWithValue("@ProdProcessMappingId", ProdProcessMappingId);

                if (ReferenceType >= 0)
                cmd.Parameters.AddWithValue("@ReferenceType", ReferenceType);

                
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public DataTable Fetch_ProductionProcessMapping_WithEmployee()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                if (ProcessId != null && ProcessId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);

                if (EmpReferenceId != null && EmpReferenceId > 0)
                    cmd.Parameters.AddWithValue("@EmpReferenceId", EmpReferenceId);

                if (ProdProcessMappingId != null && ProdProcessMappingId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProdProcessMappingId", ProdProcessMappingId);

                if (ReferenceType >= 0)
                    cmd.Parameters.AddWithValue("@ReferenceType", ReferenceType);


                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }


        public DataTable Fetch_ProductionProcessMapping_With_ProcessName(bool isReference)          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 17);

                if (ProcessId != null && ProcessId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);

                if (EmpReferenceId != null && EmpReferenceId > 0)
                    cmd.Parameters.AddWithValue("@EmpReferenceId", EmpReferenceId);

                if (ReferenceId != null && ReferenceId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);

                if (ProdProcessMappingId != null && ProdProcessMappingId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProdProcessMappingId", ProdProcessMappingId);

                if (ReferenceType >= 0)
                    cmd.Parameters.AddWithValue("@ReferenceType", ReferenceType);


                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public DataTable Fetch_ProductionProcessMapping_With_ProcessName_Employee()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 20);

                if (ProcessId != null && ProcessId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);

                if (EmpReferenceId != null && EmpReferenceId > 0)
                    cmd.Parameters.AddWithValue("@EmpReferenceId", EmpReferenceId);
              
                if (ProdProcessMappingId != null && ProdProcessMappingId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProdProcessMappingId", ProdProcessMappingId);

                if (ReferenceType >= 0)
                    cmd.Parameters.AddWithValue("@ReferenceType", ReferenceType);


                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public DataTable Fetch_ProductionProcessMapping_With_ProcessName_Equip_SPRequire()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 19);

                if (ProcessId != null && ProcessId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);
                                
                if (ReferenceId != null && ReferenceId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);

                if (ProdProcessMappingId != null && ProdProcessMappingId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProdProcessMappingId", ProdProcessMappingId);

                if (ReferenceType >= 0)
                    cmd.Parameters.AddWithValue("@ReferenceType", ReferenceType);


                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }


        //  
        public DataTable FetchDepartment()         // Get Department Record is per ProcessID
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 14);
                cmd.Parameters.AddWithValue("@ProcessId", ProcessId);
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public Int32 UpdateProcessMaster()             //Update in Process Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 3);

                cmd.Parameters.AddWithValue("@ProcessName", _ProcessName);

                cmd.Parameters.AddWithValue("@Remarks", _Remarks);

                cmd.Parameters.AddWithValue("@ModifiedBy", _Modified_By);

                cmd.Parameters.AddWithValue("@ModifiedOn", _Modified_On);

                cmd.Parameters.AddWithValue("@ProcessId", _ProcessId);

                cmd.Parameters.AddWithValue("@processSequence", SerialNo);

                cmd.Parameters.AddWithValue("@OtherProcessId", _OtherProcessId);

                cmd.Parameters.AddWithValue("@OtherSerialNo", OtherSerialNo);


                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        public Int32 DeleteProcessMaster()             // Delete Process Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@IsDeleted", _IsDeleted);
                cmd.Parameters.AddWithValue("@DeletedBy", DeletedBy);
                cmd.Parameters.AddWithValue("@DeletedOn", DeletedOn);
                cmd.Parameters.AddWithValue("@ProcessId", _ProcessId);

                //cmd.ExecuteNonQuery();

                //cmd.Parameters.Clear();

                //con.Close();

                //return 1;
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(return_parameter);

                cmd.ExecuteNonQuery();

                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }

        }
        public Int32 UnblockProcessMaster()             // Delete Process Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

                cmd.Parameters.AddWithValue("@IsDeleted", _IsDeleted);

                cmd.Parameters.AddWithValue("@ProcessId", _ProcessId);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }

        }


        public DataTable Fetch_ProcessName()  // Fetch ProcessName
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);
                
                cmd.Parameters.AddWithValue("@IsMachineShop", IsMachineShop);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;

            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }

        }

        public DataTable Fetch_SequenceNo()  // Fetch ProcessName
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 7);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;

            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }

        }

        public DataTable Fetch_Process_Name()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 8);

                if (ProcessName != null && ProcessName != "")
                {
                    cmd.Parameters.AddWithValue("@ProcessName", ProcessName);
                }

                if (ProcessId != null && ProcessId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);
                }
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }

        }

        public DataTable Fetch_Process_ALL_Details()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 23);
                               
                if (ProcessId != null && ProcessId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);
                }
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }

        }


        public Int32 ChkDefaultValue()             // Delete Process Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 10);

                cmd.Parameters.AddWithValue("@ProcessId", _ProcessId);


                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(return_parameter);

                cmd.ExecuteNonQuery();

                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
        }


        public DataTable FetchProcessCompletedId()          // Fetch Completed ProcessId
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                if (ProcessName != null && ProcessName != "")
                {
                    cmd.Parameters.AddWithValue("@ProcessName", ProcessName);
                }

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public Int32 ProcessUpate()             //Update in Process Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 12);

                cmd.Parameters.AddWithValue("@ProcessName", _ProcessName);

                cmd.Parameters.AddWithValue("@MenuName", _MenuName);
                cmd.Parameters.AddWithValue("@ProcessWiseSeparatePage", ProcessWiseSeparatePage);
                cmd.Parameters.AddWithValue("@MenuStatus", CreateNewMenuStatus);

                cmd.Parameters.AddWithValue("@Remarks", _Remarks);

                cmd.Parameters.AddWithValue("@ModifiedBy", _Modified_By);

                cmd.Parameters.AddWithValue("@ModifiedOn", _Modified_On);

                cmd.Parameters.AddWithValue("@ProcessId", _ProcessId);

                if (ShortCode.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@ShortCode", ShortCode);
                if (ShortCodeComplete.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@ShortCodeComplete", ShortCodeComplete);
                if (ShortCodeInspection.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@ShortCodeInspection", ShortCodeInspection);

                if (DisplayName.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@DisplayName", DisplayName);
                if (DisplayNameComplete.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@DisplayNameComplete", DisplayNameComplete);
                if (DisplayNameInspection.Trim() != string.Empty)
                    cmd.Parameters.AddWithValue("@DisplayNameInspection", DisplayNameInspection);

                if (MinTime > 0)
                    cmd.Parameters.AddWithValue("@min", MinTime);
                if (SecTime > 0)
                    cmd.Parameters.AddWithValue("@sec", SecTime);
                if (Ton > 0)
                    cmd.Parameters.AddWithValue("@ton", Ton);
                cmd.Parameters.AddWithValue("@IsMachineShop", IsMachineShop);

                string XML_Department = "";

                using (StringWriter dept = new StringWriter())
                {
                    dtDepartment.TableName = "DepartmentDetail";

                    dtDepartment.WriteXml(dept);

                    XML_Department = dept.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                }

                cmd.Parameters.AddWithValue("@DepartmentDetail", XML_Department);


                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        public DataTable Fetch_Default_Process_Name()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 13);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }

        }

        public bool CheckProcessCodeExist()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Process_Master";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 18);

                cmd.Parameters.AddWithValue("@ShortCode", ProcessCode);

                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
                cmd.ExecuteNonQuery();
                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;

                bool Exist = Convert.ToBoolean(result);
                return Exist;
            }
            catch (Exception ex)
            {
                con.Close();
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Fetch Process Record as per machinshop is false or 0
        public DataTable Fetch_ProcessMaster_By_MachineShop_Record()          // Fetch Process Master Details
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 21);

                if (ProcessId != null && ProcessId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ProcessId", ProcessId);
                                
                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dt;
            }

        }

        public DataTable FetchPocessNameInhouseOrMachineShop()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Process_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 22);                
                cmd.Parameters.AddWithValue("@IsMachineShop", IsMachineShop);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();
                return dt;
            }
            catch (Exception ex)
            {


                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

    }
}
