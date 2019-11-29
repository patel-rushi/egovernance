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
    class ClsPatternCheckLIstMaster
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public int CheckListType = 0;
        public int IsGRN { get; set; }

        public ClsPatternCheckLIstMaster()
        {
            con = obj.Con();
        }

        #region DataProperties
        public string PatternCheckLIst { get; set; }
        public Guid PatternCheckListID { get; set; }
        #endregion

        #region Function
        public int InsertIntoPatternCheckList()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PatternCHeckListMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);
                cmd.Parameters.AddWithValue("@PatternCheckList", PatternCheckLIst);
                cmd.Parameters.AddWithValue("@CheckListType", CheckListType);
                cmd.Parameters.AddWithValue("@IsGRN", IsGRN);
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

        public DataTable FetchPatternCheckLIstDetail()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PatternCHeckListMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);
                cmd.Parameters.AddWithValue("@CheckListType", CheckListType);
                if (IsGRN != null)
                {
                    cmd.Parameters.AddWithValue("@IsGRN", IsGRN);
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

        public Int32 UpdatePatternCheckList()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PatternCHeckListMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 3);

                cmd.Parameters.AddWithValue("@PatternCheckListID",PatternCheckListID);

                cmd.Parameters.AddWithValue("@PatternCheckList", PatternCheckLIst);
                cmd.Parameters.AddWithValue("@IsGRN", IsGRN);

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

        public Int32 DeleteFromPatternCheckLIst()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PatternCHeckListMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@PatternCheckListID", PatternCheckListID);

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

                return -1;
            }
        }

        public DataTable CheckForRepeatPatternName()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PatternCHeckListMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);
                cmd.Parameters.AddWithValue("@PatternCheckList", PatternCheckLIst);
                cmd.Parameters.AddWithValue("@CheckListType", CheckListType);
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

        #endregion
    }
}
