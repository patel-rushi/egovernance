using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems
{
    class CommMethodDataBase
    {
        #region
        public Guid CommMethodId { get; set; }
        public string MethodName { get; set; }
        #endregion

        public int Insert_CommMethod()
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
                        cmd.CommandText = "SP_CommMethod";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.Add("@MethodName", MethodName);
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

        public DataTable Search_CommMethod()
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
                        cmd.CommandText = "SP_CommMethod"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);

                        if (CommMethodId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@CommMethodId", CommMethodId);
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
            }
            return dt;
            #endregion
        }

        public int Update_CommMethod()
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
                        cmd.CommandText = "SP_CommMethod";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);
                        cmd.Parameters.Add("@MethodName", MethodName);

                        if (CommMethodId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@CommMethodId", CommMethodId);

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

        public int Delete_CommMethod()
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
                        cmd.CommandText = "SP_CommMethod";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);

                        if (CommMethodId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@CommMethodId", CommMethodId);
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

    }
}
