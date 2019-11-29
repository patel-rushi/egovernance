using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TestingSystems
{
    class clsBankMaster
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public clsBankMaster()
        {
            con = obj.Con();
        }
        #region

        public Guid BankId { get; set; }
        public Guid CustomerId { get; set; }
        public String BankName { get; set; }
        public Int32 EntityId { get; set; }

        #endregion

        #region Methods

        public Int32 Insert_Bank_Master()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "InsertBankName";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BankName", BankName);

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

        public Int32 Update_Bank_Master()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "UpdateBankName";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BankName", BankName);

                cmd.Parameters.AddWithValue("@BankId", BankId);


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

        public DataTable FetchBankDetail()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "FetchBankDetail";

                cmd.CommandType = CommandType.StoredProcedure;

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

        public Int32 DeleteBankName()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "DeleteBankName";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BankId", BankId);


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

        public DataTable FetchBankDetailByCustomerName()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "FetchBankDetailByCustomerName";
                if (CustomerId != null)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                }
                cmd.CommandType = CommandType.StoredProcedure;

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
        public DataTable FetchBankName()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "FetchBankName";
                if (EntityId != null)
                {
                    cmd.Parameters.AddWithValue("@EntityId", EntityId);
                }
                cmd.CommandType = CommandType.StoredProcedure;

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
