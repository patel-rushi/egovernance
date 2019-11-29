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
    class clsApprovedTicket
    {
        public string User_id {get;set;}
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int pagesize { get; set; }
        public int PageNumber { get; set; }
        
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsApprovedTicket()
        {
            con = obj.Con();
        }

        
        public DataTable GetApprovedTickets()
        {
          
            DataTable dt = new DataTable();
           
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectApprovedTickets");
                cmd.Parameters.AddWithValue("@UserID",User_id );
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                adp.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;

                //GridMyTicket.DataSource = dt;
                //GridMyTicket.AutoGenerateColumns = false;
                //GridMyTicket.Columns["Ticket_ID"].Visible = false;
                //con.Close();
            }
            catch (Exception ex)
            {
                return dt;
            }

        }

        public int getTotalApprovedRecord()
        {
          
           // DataTable dt = new DataTable();
           
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "GetTotalApprovedTickets");
                cmd.Parameters.AddWithValue("@UserID",User_id );
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);

                cmd.ExecuteNonQuery();
                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();

                return result;

                //GridMyTicket.DataSource = dt;
                //GridMyTicket.AutoGenerateColumns = false;
                //GridMyTicket.Columns["Ticket_ID"].Visible = false;
                //con.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
      
    }
}
