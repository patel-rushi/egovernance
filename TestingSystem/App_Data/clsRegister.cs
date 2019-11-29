using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace TestingSystems.App_Data
{
    class clsRegister
    {


        //clsConnection con = new clsConnection();
        
            #region Rushi's Code
        clsDAL obj = new clsDAL();
        #endregion

        SqlConnection objcon = new SqlConnection();
        
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public clsRegister()
        {
            //    objcon = con.Connection();

            #region Rushi's Code
            objcon = obj.Con();
            #endregion
        }



        public int  UserRegisteration()
        {



            
                objcon.Open();
                SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", objcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Register");
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@UserType", UserType);
              
                cmd.ExecuteNonQuery();
                objcon.Close();
                cmd.Parameters.Clear();

               

                    return 1;
               
               
                //DuesTicket obj = new DuesTicket( );
                //obj.Show();

        }


    }
}
