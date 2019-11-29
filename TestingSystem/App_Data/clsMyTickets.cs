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
    class clsMyTickets
    {
         SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsMyTickets()
        {
            con = obj.Con();
        }
        public string User_id { get; set; }
        public string TicketNumber { get; set; }
        public string ModuleName { get; set; }
        public string status { get; set; }
        public DataTable ImageName { get; set; }
        public string TicketID { get; set; }
        public int pagesize { get; set; }
        public int PageNumber { get; set; }
        
       public DataTable GetUserTicket()
        {
            DataTable dt = new DataTable();
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_AssignedTicket]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "MyTicket");
                cmd.Parameters.AddWithValue("@Assigned", User_id);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                if ( TicketNumber!=string.Empty)
                cmd.Parameters.AddWithValue("@TicketNumber", TicketNumber);
                if (ModuleName!=null && ModuleName != string.Empty)
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
               


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                con.Close();
                adp.Fill(dt);
                cmd.Parameters.Clear();

                return dt;

                //GridMyTicket.DataSource = dt;
                //GridMyTicket.AutoGenerateColumns = false;
                //GridMyTicket.Columns["Ticket_ID"].Visible = false;
                //con.Close();
            }
            catch 
            {
                return dt;
            }

        }
       public int getTotalMyTicketsRecord()
       {


           try
           {
               con.Open();

               SqlCommand cmd = new SqlCommand("[SP_AssignedTicket]", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Assigned", User_id);
               cmd.Parameters.AddWithValue("@Status", status);
               cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
               cmd.Parameters.AddWithValue("@pagesize", pagesize);
               if (TicketNumber != string.Empty)
                   cmd.Parameters.AddWithValue("@TicketNumber", TicketNumber);
               if (ModuleName != string.Empty)
                   cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
           
               SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
               return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
               cmd.Parameters.Add(return_parameter);
               cmd.Parameters.AddWithValue("@Action", "GetTotalMyRecord");
               cmd.ExecuteNonQuery();
               Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
               cmd.Parameters.Clear();

               con.Close();

               return result;




           }
           catch
           {
               con.Close();
               return 0;
           }
       }
       public DataTable GetImage()
       {
           DataTable dt = new DataTable();
          
           try
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("[SP_AssignedTicket]", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Action", "GetImage");
               cmd.Parameters.AddWithValue("@Ticket_ID", TicketID);
               



               SqlDataAdapter adp = new SqlDataAdapter(cmd);
               con.Close();
               adp.Fill(dt);
               cmd.Parameters.Clear();

               return dt;

               //GridMyTicket.DataSource = dt;
               //GridMyTicket.AutoGenerateColumns = false;
               //GridMyTicket.Columns["Ticket_ID"].Visible = false;
               //con.Close();
           }
           catch 
           {
               return dt;
           }

       }
      

    }
}
