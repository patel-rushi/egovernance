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
    class clsTicketApproval
    {
        public string User_id{get;set;}
         public Guid Ticket_id{get;set;}
         public int pagesize { get; set; }
         public int PageNumber { get; set; }
          SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsTicketApproval()
        {
            con = obj.Con();
        }
       public DataTable GetApprovalData()
        {

            
          
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectForApproved");
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                //cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
                cmd.Parameters.AddWithValue("@UserID", Constants.UserAssignId);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                adp.Fill(dt);
                con.Close();
                return dt;
                //this.GridApproval.AllowUserToAddRows = false;
                //GridApproval.DataSource = dt;
                //GridApproval.Columns["Ticket_ID"].Visible = false;
                //this.GridApproval.AllowUserToAddRows = false;

                
            }
            catch 
            {
                con.Close();
                return dt;


            }
          
        }

       public int getTotalApprovalRecord()
        {

            
          
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetTotalApproval");
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
               
                cmd.ExecuteNonQuery();
                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();

                return result;
                //this.GridApproval.AllowUserToAddRows = false;
                //GridApproval.DataSource = dt;
                //GridApproval.Columns["Ticket_ID"].Visible = false;
                //this.GridApproval.AllowUserToAddRows = false;

                
            }
            catch 
            {
                con.Close();
                return 0;


            }
          
        }
       public int NotApproved()
       {


          
           try
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Action", "NotApproved");
               cmd.Parameters.AddWithValue("@UserID", Constants.UserAssignId);

               cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
               cmd.ExecuteNonQuery();
               cmd.Parameters.Clear();
               con.Close();
               return 1;
           }
           catch 
           {
               con.Close();
               return 0;


           }
       
       
       
       }
        public int ApproveTicket()
        {
        
        
        try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Approved");
                cmd.Parameters.AddWithValue("@UserID", Constants.UserAssignId);

                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
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
