using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace TestingSystems.App_Data
{
    class clsEmployeeDetails
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public int isEmpCodeOrName { get; set; }
        public Boolean isLdate { get; set; }
        public int ISAct = -1;
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public byte[] ProfilePic { get; set; }

        public clsEmployeeDetails()
        {
            con = obj.Con();
        }

        #region Property
        private int _EmployeeId;
        public int EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        public string _EmployeeName;
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        public string _EmployeeCode;
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
            set
            {
                _EmployeeCode = value;
            }
        }

        private int _Gender;
        public int Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        //private int _EntityId;
        //public int EntityId
        //{
        //    get
        //    {
        //        return _EntityId;
        //    }
        //    set
        //    {
        //        _EntityId = value;
        //    }
        //}

        //private int _ShiftId;
        //public int ShiftId
        //{
        //    get
        //    {
        //        return _ShiftId;
        //    }
        //    set
        //    {
        //        _ShiftId = value;
        //    }
        //}

        private int _IsDummy;
        public int IsDummy
        {
            get
            {
                return _IsDummy;
            }
            set
            {
                _IsDummy = value;
            }
        }

        private Boolean _isActive;
        public Boolean isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                _MiddleName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        private string _OtherName;
        public string OtherName
        {
            get
            {
                return _OtherName;
            }
            set
            {
                _OtherName = value;
            }
        }

        private DateTime _DOB;
        public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }

        private Decimal _Salary;
        public Decimal Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
            }
        }

        private DateTime _JoiningDate;
        public DateTime JoiningDate
        {
            get
            {
                return _JoiningDate;
            }
            set
            {
                _JoiningDate = value;
            }
        }


        public DateTime LeavingDate
        {
            get;
            set;
        }
        private int _EmployeeType;
        public int EmployeeType
        {
            get
            {
                return _EmployeeType;
            }
            set
            {
                _EmployeeType = value;
            }
        }
        private int _IsDelete;
        public int IsDelete
        {
            get
            {
                return _IsDelete;
            }
            set
            {
                _IsDelete = value;
            }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DataTable dtDepartment { get; set; }
        public DataTable dtCheckedRecord { get; set; }
        public DataTable dtProcessDetails { get; set; }
        public Guid SysDepartmentID { get; set; }

        public bool SysDepartmentMapping { get; set; }
        public Guid ProcessId { get; set; }

        public int ShiftType { get; set; }
        public int Capacity { get; set; }

        #endregion

        public Int32 Insert_Employee_Details() //Save in Employee Details
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 1);
                cmd.Parameters.AddWithValue("@EmployeeName", _EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", _EmployeeCode);
                cmd.Parameters.AddWithValue("@Gender", _Gender);
                cmd.Parameters.AddWithValue("@IsDummy", _IsDummy);
                cmd.Parameters.AddWithValue("@isActive", _isActive);
                cmd.Parameters.AddWithValue("@MiddleName", _MiddleName);
                cmd.Parameters.AddWithValue("@LastName", _LastName);
                cmd.Parameters.AddWithValue("@OtherName", _OtherName);
                cmd.Parameters.AddWithValue("@DOB", _DOB);
                cmd.Parameters.AddWithValue("@Salary", _Salary);
                cmd.Parameters.AddWithValue("@JoiningDate", _JoiningDate);
                cmd.Parameters.AddWithValue("@EmployeeType", _EmployeeType);
                if (isLdate)
                    cmd.Parameters.AddWithValue("@LeavingDate", LeavingDate);
                cmd.Parameters.AddWithValue("@IsDeleteEmployee", 0);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                cmd.Parameters.AddWithValue("@ProfilePic", ProfilePic);
                cmd.Parameters.AddWithValue("@UserId", ProfilePic);

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

        public bool CheckEmpCOdeExist()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@EmployeeCode", _EmployeeCode);

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

        public DataTable FetchEmployeeDetails()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 3);
                cmd.Parameters.AddWithValue("@isEmpCodeOrName", isEmpCodeOrName);
                //cmd.Parameters.AddWithValue("@IsDummy", IsDummy);
                //if (SysDepartmentID != null && SysDepartmentID != Guid.Empty)
                //    cmd.Parameters.AddWithValue("@SysDepartmentID", SysDepartmentID);

                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable FetchEmployeeDataSearch()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                con.Open();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 4);
                if (EmployeeCode != null && EmployeeCode != "")
                    cmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);

                if (EmployeeName != null && EmployeeName != "")
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);

                if (EmployeeId > 0)
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);


                cmd.Parameters.AddWithValue("@iSAct", ISAct);                



                //if (IsDummy > 0)
                //    cmd.Parameters.AddWithValue("@IsDummy", IsDummy);
                //else if (IsDummy == 2)
                //    cmd.Parameters.AddWithValue("@IsDummy", IsDummy);
                //else
                //    cmd.Parameters.AddWithValue("@IsDummy", 0);

                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 UpdateEmployeeDetails(bool isUpdate)
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_EmployeeDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", _EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", _EmployeeCode);
                cmd.Parameters.AddWithValue("@Gender", _Gender);
                cmd.Parameters.AddWithValue("@isActive", _isActive);
                if (isUpdate)
                {
                    cmd.Parameters.AddWithValue("@IsDummy", _IsDummy);
                    cmd.Parameters.AddWithValue("@MiddleName", _MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", _LastName);
                    cmd.Parameters.AddWithValue("@OtherName", _OtherName);
                    cmd.Parameters.AddWithValue("@DOB", _DOB);
                    cmd.Parameters.AddWithValue("@Salary", _Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", _JoiningDate);
                    cmd.Parameters.AddWithValue("@EmployeeType", _EmployeeType);
                    if (isLdate)
                        cmd.Parameters.AddWithValue("@LeavingDate", LeavingDate);
                    cmd.Parameters.AddWithValue("@IsDeleteEmployee", 0);
                }

                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                cmd.Parameters.AddWithValue("@ProfilePic", ProfilePic);

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

        public Int32 DeleteEmployeeDetails()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_EmployeeDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);
                cmd.Parameters.AddWithValue("@EmployeeId", _EmployeeId);
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

        public DataTable FetchEmployee_Record()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 7);
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int UserId { get; set; }
        public int UserName { get; set; }


        public DataTable BindUserName()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_EmployeeDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 8);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;


            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }

        }

        public DataTable GetEmployeeIdByUserId()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_EmployeeDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 9);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;


            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }

        }


        public DataTable GetEmployeeIdByEmpCode()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_EmployeeDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 10);
                cmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;


            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }

        }

        public Int32 UpdateUserInfoEmployeeId()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_EmployeeDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 11);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
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

        public DataTable GetUserIdbyEmployeeId()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_EmployeeDetails]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 12);
                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;


            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }

        }

    }
}