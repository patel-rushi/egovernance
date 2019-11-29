using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems.App_Data
{
    class clsManagementFeedback
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public string UserId { get; set; }
        public int Communication { get; set; }
        public int TeamWork { get; set; }
        public int Reporting { get; set; }
        
        public clsManagementFeedback()
        {
            con = obj.Con();
        }
        public int Set()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_managementfeedback]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@communication", Communication);
                cmd.Parameters.AddWithValue("@reporting", Reporting);
                cmd.Parameters.AddWithValue("@teamwork", TeamWork);
                cmd.Parameters.AddWithValue("@Action", "InsertFeedback");

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
    }
}
