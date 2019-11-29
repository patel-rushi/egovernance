using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems.App_Data
{
   
    class clsPerformance
    {
        

        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public String UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public clsPerformance()
        {
            con = obj.Con();
        }

        public DataTable Get()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[sp_Performancetry]", con);

            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(FromDate) );
            cmd.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(ToDate));
            cmd.Parameters.AddWithValue("@Action", "finalreport");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            dt.Clear();
            adp.Fill(dt);
            con.Close();
            return dt;

        }
    }

}
