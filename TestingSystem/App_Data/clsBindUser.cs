using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TestingSystems.App_Data
{
    class clsBindUser
    {
       
       SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();
        public string UserType { get; set; }
        public clsBindUser()
        {
            con = obj.Con();
        }

        public DataTable BindTask()
        {
            DataTable dt = new DataTable();

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "BindTaskType");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);



                adp.Fill(dt);

                con.Close();
                return dt;



            }
            catch
            {
                con.Close();
                return dt;
            }

        }
        public DataTable BindUser()
        {
            DataTable dt = new DataTable();  
            
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UserBind");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
              

                
                adp.Fill(dt);
               
                con.Close();
                return dt;



            }
            catch 
            {
                con.Close();
                return dt;
            }

        }

        public DataTable BindUserUsingUserType()
        {
            DataTable dt = new DataTable();

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@Action", "UserBindUsingUserType");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);



                adp.Fill(dt);

                con.Close();
                return dt;



            }
            catch
            {
               
                con.Close();
                return dt;
            }

        }

        public DataTable BindClientName()
        {
            DataTable dt = new DataTable();
            
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "BindClient");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);


                //  DataSet ds = new DataSet();
                //dt = ds.Tables[0];
                adp.Fill(dt);

                con.Close();
                return dt;


            }
            catch
            {
                
                con.Close();
                return dt;
            }

        }
        public DataTable BindReprasentative()
        {
            DataTable dt = new DataTable();

            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectRep");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);


                //  DataSet ds = new DataSet();
                //dt = ds.Tables[0];
                adp.Fill(dt);

                con.Close();
                return dt;


            }
            catch 
            {
                
                con.Close();
                return dt;
            }

        }
        public DataTable BindModuleName()
        {
            DataTable dt = new DataTable();
           
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "BindModule");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);


                //  DataSet ds = new DataSet();
                //dt = ds.Tables[0];
                adp.Fill(dt);

                con.Close();
                return dt;


            }
            catch 
            {
                con.Close();
                return dt;
            }

        }
        public DataTable BindForm()
        {
            DataTable dt = new DataTable();
         
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "BindForm");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);


                //  DataSet ds = new DataSet();
                //dt = ds.Tables[0];
                adp.Fill(dt);

                con.Close();
                return dt;


            }
            catch 
            {
                con.Close();
                return dt;
            }

        }
        public DataTable BindVersion()
        {
            DataTable dt = new DataTable();
           
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "BindVersion");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);


                //  DataSet ds = new DataSet();
                //dt = ds.Tables[0];
                adp.Fill(dt);

                con.Close();
                return dt;


            }
            catch 
            {
                con.Close();
                return dt;
            }

        }
    }
}
