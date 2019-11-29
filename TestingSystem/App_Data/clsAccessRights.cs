using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems.App_Data
{
    public class clsAccessRights
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

         public clsAccessRights()
        {
            con = obj.Con();
        }
        DataTable dt = new DataTable();
        
        public string UserType { get; set; }
        public string UserName { get; set; }
        public int WorkReport { get; set; }
        public int WorkReportRegister { get; set; }
        public int NewTickets { get; set; }
        public int Tickets { get; set; }
        public int MyTickets { get; set; }
        public int TicketsApproval { get; set; }
        public int ApprovedTickets { get; set; }
        public int CustomerMaster { get; set; }
        public int Inquiry { get; set; }
        public int Communication { get; set; }
        public int ClientOrder { get; set; }
        public int MasterUpload { get; set; }
        public int Register { get; set; }
        public int AccessRights { get; set; }
        public int Logout { get; set; }
        public int LeaveApplication { get; set; }
        public int LeaveApplicationRegister { get; set; }
        public string UpdateValues { get; set; }


        public DataTable Fetch_AccessRights()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[SP_UserLogIn]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@myUserType", UserType);
            cmd.Parameters.AddWithValue("@Action", "AccessRights");
            SqlDataAdapter adp = new SqlDataAdapter();
            adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);
            cmd.Parameters.Clear();
            con.Close();
            return dt;

        }
        
        public void Update()
        {
            try
            {
               

                con.Open();
                SqlCommand cmd = new SqlCommand("[UpdateAccessRights]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkReport", WorkReport);
                cmd.Parameters.AddWithValue("@WorkReportRegister", WorkReportRegister);
                cmd.Parameters.AddWithValue("@NewTickets", NewTickets);
                cmd.Parameters.AddWithValue("@Tickets", Tickets);
                cmd.Parameters.AddWithValue("@MyTickets", MyTickets);
                cmd.Parameters.AddWithValue("@TicketsApproval", TicketsApproval);
                cmd.Parameters.AddWithValue("@ApprovedTickets", ApprovedTickets);
                cmd.Parameters.AddWithValue("@CustomerMaster", CustomerMaster);
                cmd.Parameters.AddWithValue("@Inquiry", Inquiry);
                cmd.Parameters.AddWithValue("@Communication", Communication);
                cmd.Parameters.AddWithValue("@ClientOrder", ClientOrder);
                cmd.Parameters.AddWithValue("@MasterUpload", MasterUpload);
                cmd.Parameters.AddWithValue("@Register", Register);
                cmd.Parameters.AddWithValue("@AccessRights", AccessRights);
                cmd.Parameters.AddWithValue("@Logout", Logout);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@LeaveApplication", LeaveApplication);
                cmd.Parameters.AddWithValue("@LeaveApplicationRegister", LeaveApplicationRegister);

                cmd.Parameters.AddWithValue("@action", "Checked");
                cmd.ExecuteNonQuery();
                con.Close();
            }
                catch (Exception ex)
            {

                throw ex;
            }
        }
        String myUser_ID;
        public DataTable get(String UserID, String UserType, String UserName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[UpdateAccessRights]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //myUser_ID = "UID00000" + UserID;
            cmd.Parameters.AddWithValue("@UserID", myUser_ID);
            cmd.Parameters.AddWithValue("@UserType", UserType);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@action", "get");
           // cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            cmd.Parameters.Clear();
            con.Close();
            return dt;
        }
    }
}
