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
    class clsAccessMenu
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public DataTable dtMenuUpdateDetail { get; set; }

        public Boolean IsSubSrNo { get; set; }
        public Int32 SrNo { get; set; }
        
        public clsAccessMenu()
        {
            con = obj.Con();
        }

        public Int64 AccessMenuId { get; set; }

        public Int64 MenuId { get; set; }

        public Int64 ParentID { get; set; }        

        public int UserId { get; set; }

        public bool AccessAdd { get; set; }

        public bool AccessEdit { get; set; }

        public bool AccessDelete { get; set; }

        public bool AccessApprove { get; set; }

        public bool AccessPrint { get; set; }

        public bool AccessView { get; set; }

        public String FormName { get; set; }

        public DataTable dt_menu_rights_details { get; set; }

        public DataTable Fetch_Menu()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Access_Menu";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@UserId", UserId);

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

        public Int32 Insert_Access_Page_Menu()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {

                con.Open();

                cmd.Connection = con;

                cmd.CommandTimeout = 0;

                cmd.CommandText = "SP_Access_Menu";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@UserId", UserId);

                if (dt_menu_rights_details != null)
                {
                    string XML = "";

                    using (StringWriter sw = new StringWriter())
                    {
                        dt_menu_rights_details.TableName = "Access_Page_Menu";

                        dt_menu_rights_details.WriteXml(sw);

                        XML = sw.ToString();
                    }

                    cmd.Parameters.AddWithValue("@Access_Page_Menu", XML);
                }

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

        public bool Fetch_Frm_Right(string type, string formname)
        {
            var session = Session.Get();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            bool userright = false;
            try
            {
                if (session.UserType.ToLower() == "admin")
                    return true;

                con.Open();

                cmd.Connection = con;

                cmd.CommandTimeout = 0;

                cmd.CommandText = "SP_Access_Menu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 4);
                cmd.Parameters.AddWithValue("@UserId", session.UserId);
                cmd.Parameters.AddWithValue("@FormName", formname);
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    switch (type.ToUpper())
                    {
                        case "ADD": return Convert.ToBoolean(dt.Rows[0]["AccessAdd"]);
                        case "EDIT": return Convert.ToBoolean(dt.Rows[0]["AccessEdit"]);
                        case "DELETE": return Convert.ToBoolean(dt.Rows[0]["AccessDelete"]);
                        case "APPROVE": return Convert.ToBoolean(dt.Rows[0]["AccessApprove"]);
                        case "PRINT": return Convert.ToBoolean(dt.Rows[0]["AccessPrint"]);
                        case "VIEW": return Convert.ToBoolean(dt.Rows[0]["AccessView"]);
                        default: return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return userright;
            }
        }
               
        public Int32 UpdateMenuDetails()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Access_Menu";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

                string XML = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    dtMenuUpdateDetail.TableName = "MenuUpdate";

                    dtMenuUpdateDetail.WriteXml(stringWriter);

                    XML = stringWriter.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                }

                cmd.Parameters.AddWithValue("@Access_Page_Menu", XML);

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

        public Int32 Update_SrNoMenuDetails()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "sp_Menu";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 10);

                cmd.Parameters.AddWithValue("@IsSubSrNo", IsSubSrNo);

                cmd.Parameters.AddWithValue("@MenuId", MenuId);

                cmd.Parameters.AddWithValue("@SrNo", SrNo);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                
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

        public Int32 Update_MenuMasterDetails()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "sp_Menu";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                cmd.Parameters.AddWithValue("@IsSubSrNo", IsSubSrNo);
                cmd.Parameters.AddWithValue("@MenuId", MenuId); 
                cmd.Parameters.AddWithValue("@ParentId", ParentID);
                cmd.Parameters.AddWithValue("@UserId", UserId); 
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

    }
}
