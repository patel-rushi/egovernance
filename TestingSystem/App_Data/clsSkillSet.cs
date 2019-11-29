using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems.App_Data
{
    class clsSkillSet
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public Guid SkillId { get; set; }
        public int userid { get; set; }
        public string eventname { get; set; }
        public string course { get; set; }
        public string organization { get; set; }
        public int approval = 0;
        public decimal InserDate = 0;
        public byte[] ProfilePic { get; set; }
        public clsSkillSet()
        {
            con = obj.Con();
        }
        public class SkillEvent
        {
            public string Name { get; set; }
        }

        public class SkillCource
        {
            public string Name { get; set; }
        }

        public DataTable GetSkillDetailsFromId()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                con.Open();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SP_SkillSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 1);
                cmd.Parameters.AddWithValue("@SkillId", SkillId);

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

        public Int32 Insert_SkillSet_Details() 
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_SkillSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 2);
                cmd.Parameters.AddWithValue("@SkillId", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@eventname", eventname);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.Parameters.AddWithValue("@approval", approval);
                cmd.Parameters.AddWithValue("@InsertDate", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@img", ProfilePic);

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

        public Int32 Update_SkillSet_Details()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SP_SkillSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 3);
                cmd.Parameters.AddWithValue("@SkillId", SkillId);                            
                cmd.Parameters.AddWithValue("@approval", approval);
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

        public DataTable SearchSkillDetails() 
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                con.Open();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SP_SkillSet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 4);
                cmd.Parameters.AddWithValue("@eventname", eventname);
                cmd.Parameters.AddWithValue("@course", course);

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
        
    }
}


