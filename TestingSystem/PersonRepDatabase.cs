using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestingSystems
{
    class PersonRepDatabase
    {
        #region
        public Guid PersonRepId { get; set; }
        public string PersonName { get; set; }
        #endregion

        public int Insert_PersonName()
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
                        cmd.CommandText = "SP_PersonRep";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.AddWithValue("@PersonName", PersonName);
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

        public DataTable Search_PersonName()
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
                        cmd.CommandText = "SP_PersonRep"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);

                        if (PersonRepId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@PersonRepId", PersonRepId);

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
        public int Update_PersonName()
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
                        cmd.CommandText = "SP_PersonRep";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);

                        cmd.Parameters.AddWithValue("@PersonName", PersonName);

                        if (PersonRepId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@PersonrepId", PersonRepId);
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
        public int Delete_PersonName()
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
                        cmd.CommandText = "SP_PersonRep";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);
                        cmd.Parameters.AddWithValue("@PersonName", PersonName);


                        if (PersonRepId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@PersonrepId", PersonRepId);

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
