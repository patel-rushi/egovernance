using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems.App_Data
{
    

    class clsLeaveApplication
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public String User_ID;
        public DateTime FromDate { get; set; }
        
        public DateTime ToDate { get; set; }
        public string Desc { get; set; }
        public int HDF { get; set; }
        public int HDT { get; set; }
        public string Status { get; set; }
        public int Paid { get; set; }
        public string UserName { get; set; }

        public clsLeaveApplication()
        {
            con = obj.Con();
        }
        public void Set()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[Leave]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@UserId", User_ID);
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.Parameters.AddWithValue("@HDF", HDF);
                cmd.Parameters.AddWithValue("@HDT", HDT);
                cmd.Parameters.AddWithValue("@Description", Desc);
                cmd.Parameters.AddWithValue("@Paid", -1);
                cmd.Parameters.AddWithValue("@Status", "Pending");
                cmd.Parameters.AddWithValue("@Action", "LeaveInsert");

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch 
            {
                con.Close();
            }
        }
        public DataTable Get()
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("[Leave]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DisplayUser");
                cmd.Parameters.AddWithValue("@UserId", User_ID);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                adp.Fill(dt);
                
                con.Close();
                return dt;
            
        }

        public DataTable GetForAdmin()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[Leave]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "AdminSelect");
            cmd.Parameters.AddWithValue("@UserId",User_ID);
            cmd.Parameters.AddWithValue("@Status",Status);
            cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
            cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            adp.Fill(dt);

            con.Close();
            return dt;
        }

        public int Approved()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[Leave]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Approved");
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Paid", Paid);
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int NotApproved()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[Leave]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "NotApproved");
                cmd.Parameters.AddWithValue("@UserName", UserName); 
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

    }
}
