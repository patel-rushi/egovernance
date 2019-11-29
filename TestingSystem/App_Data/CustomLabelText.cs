using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsCustomLabelText
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public clsCustomLabelText()
        {
            con = obj.Con();
        }
        #region Properties

        public Guid CustomLabelTextId { get; set; }
        public string ModuleIdFilter { get; set; }
        public string LablelIdFilter { get; set; }

        public String ModuleName { get; set; }
        public String LabelName { get; set; }
        public String LabelDisplayName { get; set; }
        public String UsedPlaces { get; set; }
        public int Qty { get; set; }

        //added
        public Boolean IsExportOrDomestic { get; set; }
        #endregion
        public Int32 Insert_CustomLabelText()             //Save in CustomLabelText Master
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CustomLabelTextMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 1);
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                da.SelectCommand = cmd;
                da.Fill(dt);
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
        public DataTable Fetch_CustomLabelTextDetails()          // Fetch CustomLabelText Details
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CustomLabelTextMaster";
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
        public Int32 Update_CustomLabelText()             //Update in CustomLabelText Master
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CustomLabelTextMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 3);
                cmd.Parameters.AddWithValue("@LabelDisplayName", LabelDisplayName);
                cmd.Parameters.AddWithValue("@UsedPlaces", UsedPlaces);
                cmd.Parameters.AddWithValue("@CustomLabelTextId", CustomLabelTextId);
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
        public DataTable Fetch_CustomLabelText()          // Fetch CustomLabelText Details
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CustomLabelTextMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 4);
                if (ModuleName!=null && ModuleName != "")
                    cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
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

        public DataTable Fetch_Search_CustomLabelTextDetails()          // Fetch CustomLabelText Details
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "CustomLabelTextMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 5);

                if (ModuleIdFilter != null && ModuleIdFilter != string.Empty)
                cmd.Parameters.AddWithValue("@CustomLabelTextIdModule", ModuleIdFilter);

                if (LablelIdFilter != null && LablelIdFilter != string.Empty)
                cmd.Parameters.AddWithValue("@CustomLabelTextIdLabel", LablelIdFilter);
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

        public DataTable FetchExportSeries()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Invoice_Series";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

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

        public DataTable Fetch_CustomModule()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomLabelTextMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);

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

        public DataTable Fetch_CustomLabel()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomLabelTextMaster";

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

        public DataTable FetchDomesticSeries()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Invoice_Series";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

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
    }
}
