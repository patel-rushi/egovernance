using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems.App_Data
{
    class clsDailyAttendanceSheet
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsDailyAttendanceSheet()
        {
            con = obj.Con();
        }
        public DataTable dtShift { get; set; }
        public DateTime EffectiveDate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int IsDummy { get; set; }

        public int isDeleteFlag { get; set; }
        public int isDeleteActiveFlag { get; set; }

        public DateTime RemovalDate { get; set; }

        public String EmployeeCode { get; set; }
        public Boolean RemoveEmployeeCode { get; set; }
        public Boolean RemoveAllEmployee { get; set; }

        public String AddOrRemoveHrsStartTime { get; set; }
        public String AddOrRemoveHrsEndTime { get; set; }

        public DateTime Time { get; set; }

        //public DataTable Fetch_EmployeeDetail()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();

        //        cmd.Connection = con;

        //        cmd.CommandText = "HRPayRoll";

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Parameter", 1);

        //        da.SelectCommand = cmd;

        //        da.Fill(dt);

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return dt;
        //    }
        //}

        //public DataTable Fetch_ALL_inActive_EmployeeDetail()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();

        //        cmd.Connection = con;

        //        cmd.CommandText = "HRPayRoll";

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Parameter", 13);

        //        da.SelectCommand = cmd;

        //        da.Fill(dt);

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return dt;
        //    }
        //}

        //public DataTable Fetch_EmployeeDetail_ALL_inActive()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();

        //        cmd.Connection = con;

        //        cmd.CommandText = "HRPayRoll";

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Parameter", 12);

        //        da.SelectCommand = cmd;

        //        da.Fill(dt);

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return dt;
        //    }
        //}

        //public DataTable Fetch_Shift()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();

        //        cmd.Connection = con;

        //        cmd.CommandText = "HRPayRoll";

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Parameter", 2);

        //        da.SelectCommand = cmd;

        //        da.Fill(dt);

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return dt;
        //    }
        //}
        //public int Update_EmployeeShift()
        //{

        //    var session = Session.Get();
        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 3);

        //        cmd.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);

        //        string XMLShift = "";

        //        using (StringWriter sw = new StringWriter())
        //        {
        //            dtShift.TableName = "ShiftDetail";

        //            dtShift.WriteXml(sw);

        //            XMLShift = sw.ToString();
        //        }

        //        cmd.Parameters.AddWithValue("@ShiftDetail", XMLShift);
        //        cmd.Parameters.AddWithValue("@EntityId", session.EntityID);

        //        SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

        //        return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

        //        cmd.Parameters.Add(return_parameter);

        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return 1;
        //    }

        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return -1;
        //    }
        //}
        //public DataTable Fetch_DailyAttendanceSheetActual()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 4);

        //        cmd.Parameters.AddWithValue("@StartDate", StartDate);

        //        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //        cmd.Parameters.AddWithValue("@isFilterDeleteFlag", isDeleteFlag);
        //        cmd.Parameters.AddWithValue("@isFilterActiveFlag", isDeleteActiveFlag);
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return null;
        //    }
        //}
        //public DataTable Fetch_DailyAttendanceSheetDummy()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 5);

        //        cmd.Parameters.AddWithValue("@StartDate", StartDate);

        //        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //        cmd.Parameters.AddWithValue("@isFilterDeleteFlag", isDeleteFlag);
        //        cmd.Parameters.AddWithValue("@isFilterActiveFlag", isDeleteActiveFlag);
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return null;
        //    }
        //}
        //public DataTable Fetch_EmployeeCode()
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "SP_EmployeeDetails";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 13);
        //        //cmd.Parameters.AddWithValue("@IsDummy", IsDummy);

        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return null;
        //    }
        //}
        //public int RemoveEmployeeDummyData()
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 7);

        //        cmd.Parameters.AddWithValue("@EffectiveDate", RemovalDate);
        //        cmd.Parameters.AddWithValue("@RemoveAll", RemoveAllEmployee);
        //        cmd.Parameters.AddWithValue("@RemoveEmployeeCode", RemoveEmployeeCode);
        //        cmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
        //        cmd.Parameters.AddWithValue("@AddOrRemoveHrsStartTime", AddOrRemoveHrsStartTime);
        //        cmd.Parameters.AddWithValue("@AddOrRemoveHrsEndTime", @AddOrRemoveHrsEndTime);


        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return 1;
        //    }

        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return -1;
        //    }
        //}
        //public DataSet Fetch_MonthlyAttendanceSummary()
        //{
        //    DataSet dt = new DataSet();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 8);

        //        cmd.Parameters.AddWithValue("@StartDate", StartDate);

        //        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //        cmd.Parameters.AddWithValue("@isFilterDeleteFlag", isDeleteFlag);
        //        cmd.Parameters.AddWithValue("@isFilterActiveFlag", isDeleteActiveFlag);


        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return null;
        //    }
        //}  // Dummy Data Summary

        //public DataSet Fetch_MonthlyAttendanceSummaryActual()  // ACtual SUmmary
        //{
        //    DataSet dt = new DataSet();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandText = "HRPayRoll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Parameter", 9);

        //        cmd.Parameters.AddWithValue("@StartDate", StartDate);

        //        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //        cmd.Parameters.AddWithValue("@isFilterDeleteFlag", isDeleteFlag);
        //        cmd.Parameters.AddWithValue("@isFilterActiveFlag", isDeleteActiveFlag);
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return null;
        //    }
        //}


        //public DataTable FetchEmpInOROut(bool Dummy)
        //{
        //    DataTable dt = new DataTable();

        //    SqlCommand cmd = new SqlCommand();

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    try
        //    {
        //        con.Open();

        //        cmd.Connection = con;

        //        cmd.CommandText = "HRPayRoll";

        //        cmd.CommandType = CommandType.StoredProcedure;

        //        if (Dummy)
        //            cmd.Parameters.AddWithValue("@Parameter", 11);
        //        else
        //            cmd.Parameters.AddWithValue("@Parameter", 10);

        //        cmd.Parameters.AddWithValue("@isFilterDeleteFlag", isDeleteFlag);
        //        cmd.Parameters.AddWithValue("@isFilterActiveFlag", isDeleteActiveFlag);
        //        cmd.Parameters.AddWithValue("@StartDate", StartDate.Date);

        //        cmd.Parameters.AddWithValue("@Time", Time.TimeOfDay);

        //        da.SelectCommand = cmd;

        //        da.Fill(dt);

        //        cmd.Parameters.Clear();

        //        con.Close();

        //        return dt;

        //    }

        //    catch (Exception ex)
        //    {
        //        con.Close();

        //        ExceptionHandler.LogException(ex);
        //        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return dt;
        //    }
        //}
    }
}
