using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace TestingSystems.App_Data
{
    class Clslogin
    {
        clsDAL obj = new clsDAL();
        SqlConnection con = new SqlConnection();

        public string username { get; set; }
        public string Password { get; set; }
        public Clslogin()
        {
            con = obj.Con();

        }

        public DataTable getLogin()
        {
            //con.Open();

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_UserLogIn", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "LogIn");
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", Password);
                SqlDataAdapter ADP = new SqlDataAdapter(cmd);

                ADP.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }




    }
}
