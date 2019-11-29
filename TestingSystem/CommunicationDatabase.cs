using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TestingSystems.Helpers;
using System.Windows.Forms;

namespace TestingSystems
{
    class CommunicationDatabase
    {
        #region
        public Guid CommunicationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ContactId { get; set; }
        public string CompanyRep { get; set; }
        public string PersonRep { get; set; }
        public string Discussion { get; set; }
        public DateTime? _Date { get; set; }
        public string CommMethod { get; set; }
        //-------------------------------------
        public string ActionName { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Remark { get; set; }
        #endregion

        public int Insert_ClientDiscussion()
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
                        cmd.CommandText = "SP_ClientDiscussion";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        if(ContactId!= Guid.Empty)
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);
                        cmd.Parameters.AddWithValue("@CommMethod", CommMethod);
                        cmd.Parameters.AddWithValue("@CompanyRep", CompanyRep);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@Discussion", Discussion);
                        cmd.Parameters.AddWithValue("@DiscussDate", _Date);

                        if (ActionName != String.Empty)
                        {
                            cmd.Parameters.AddWithValue("@ActionName", ActionName);
                            cmd.Parameters.AddWithValue("@ActionDate", ActionDate);
                            cmd.Parameters.AddWithValue("@Remark", Remark);
                        }
                       
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

        public int Update_ClientDiscussion()
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
                        cmd.CommandText = "SP_ClientDiscussion";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);
                        cmd.Parameters.AddWithValue("@CommunicationId", CommunicationId);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        if(ContactId!=Guid.Empty)
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);

                        cmd.Parameters.AddWithValue("@CompanyRep", CompanyRep);

                        cmd.Parameters.AddWithValue("@CommMethod", CommMethod);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@Discussion", Discussion);


                        cmd.Parameters.AddWithValue("@DiscussDate", _Date);

                        if (ActionName != string.Empty)
                        {
                            cmd.Parameters.AddWithValue("@ActionName", ActionName);
                            cmd.Parameters.AddWithValue("@ActionDate", ActionDate);
                            cmd.Parameters.AddWithValue("@Remark", Remark);
                        }
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

        public int Delete_ClientDiscussion()
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
                        cmd.CommandText = "SP_ClientDiscussion";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);
                        cmd.Parameters.AddWithValue("@CommunicationId", CommunicationId);
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

        public DataTable Search_ClientDiscussion()
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
                        cmd.CommandText = "SP_ClientDiscussion"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);
                        if (CustomerId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        
                        if(ContactId !=Guid.Empty)
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);

                        cmd.Parameters.AddWithValue("@CompanyRep", CompanyRep);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);

                        if(_Date != null)
                        cmd.Parameters.AddWithValue("@DiscussDate", _Date);

                        if (ActionDate != null)
                        {
                            cmd.Parameters.AddWithValue("@ActionDate", ActionDate);
                        }
                        if (ActionName != string.Empty)
                            cmd.Parameters.AddWithValue("@ActionName", ActionName);

                        cmd.Parameters.AddWithValue("@CommMethod", CommMethod);
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

        public DataTable Search_For_Update()
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
                        cmd.CommandText = "SP_ClientDiscussion"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 5);
                        cmd.Parameters.AddWithValue("@CommunicationId", CommunicationId);

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
      
    }
}
