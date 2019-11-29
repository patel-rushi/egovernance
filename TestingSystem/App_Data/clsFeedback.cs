using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems.App_Data
{
    class clsFeedback
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public int UserId = 0;
        public int FromId = 0;
        public int ToId = 0;
        public decimal Helpful = 0;
        public decimal Behaviour = 0;
        public clsFeedback()
        {
            con = obj.Con();
        }
        public DataTable BindUser()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[colleagueFeedBack]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UserBind");
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

        public Int32 Insert_FeedBack() //Save in Employee Details
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "colleagueFeedBack";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "InsertFeedback");
                cmd.Parameters.AddWithValue("@FromID", FromId);
                cmd.Parameters.AddWithValue("@ToId", ToId);
                cmd.Parameters.AddWithValue("@HelpFul", Helpful);
                cmd.Parameters.AddWithValue("@Behaviour", Behaviour);

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

        public DataTable GetFeedback()
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[colleagueFeedBack]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (UserId > 0)
                {
                    cmd.Parameters.AddWithValue("@Action", "ShowFeedbackId");
                    cmd.Parameters.AddWithValue("@ToId", UserId);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Action", "ShowFeedback");
                    //cmd.Parameters.AddWithValue("@ToId", UserId); 
                }
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
