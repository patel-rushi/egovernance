using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems.App_Data
{
    class clsPerformanceCriteria
    {


        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public string UserType { get; set; }
        public int Efficiency { get; set; }
        public int Effectiveness { get; set; }
        public int Attendance { get; set; }
        public int ManagementF { get; set; }
        public int Skillset { get; set; }
        public int ColleagueF { get; set; }
        
        public clsPerformanceCriteria()
        {
            con = obj.Con();
        }
        public int Set()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[sp_Performance]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@Efficiency", Efficiency);
                cmd.Parameters.AddWithValue("@Effectiveness", Effectiveness);
                cmd.Parameters.AddWithValue("@Attendance", Attendance);
                cmd.Parameters.AddWithValue("@ManagementF", ManagementF);
                cmd.Parameters.AddWithValue("@Skillset", Skillset);
                cmd.Parameters.AddWithValue("@ColleagueF", ColleagueF);
                cmd.Parameters.AddWithValue("@Action", "UpdateWeightage");

                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch 
            {
                con.Close();
                return 0;
            }
        }

        public DataTable Get()
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("[sp_Performance]", con);
                
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@Action", "GetWeightage");

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt.Clear();
                adp.Fill(dt);
                con.Close();
                return dt;
            
        }
    }
}
