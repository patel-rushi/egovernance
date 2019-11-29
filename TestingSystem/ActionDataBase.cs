using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TestingSystems
{
    class ActionDataBase
    {
        #region
        public Guid ActionId { get; set; }
        public string Action { get; set; }
        #endregion

        public int Insert_Action()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_Action";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.AddWithValue("@ActionName", Action);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return 0;
            }
        }

        public DataTable Search_Action()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_Action"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);

                        if (ActionId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ActionId", ActionId);

                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
            #endregion
        }

        public int Update_Action()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_Action";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);
                        cmd.Parameters.AddWithValue("@ActionName", Action);

                        if (ActionId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ActionId", ActionId);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Delete_Action()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_Action";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);

                        if (ActionId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ActionId", ActionId);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
