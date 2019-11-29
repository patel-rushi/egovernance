using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using TestingSystems.App_Data;
using Microsoft.Reporting.WinForms;

namespace TestingSystems.App_Data
{
    class clsDueTickets
    {

        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsDueTickets()
        {
            con = obj.Con();
        }
        public string status { get; set; }
        public Guid ClientName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public Guid Ticket_ID { get; set; }
        public int pagesize { get; set; }
        public int ticketType { get; set; }
        public int PageNumber { get; set; }
        public int Assigned { get; set; }

        DataTable dt;

        public SqlCommand getdueticketsrecords()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Status");
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@TicketType", ticketType);
            cmd.Parameters.AddWithValue("@AssignedStatus", Assigned);
            if (ClientName != Guid.Empty)
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
            cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
            cmd.Parameters.AddWithValue("@pagesize", pagesize);
            cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(FromDate));
            cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(ToDate));

            return cmd;
        }

        public DataTable GetData()
        {
            try
            {
                ReportDueTickets myobj = new ReportDueTickets();

                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Status");
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TicketType", ticketType);
                cmd.Parameters.AddWithValue("@AssignedStatus", Assigned);
                if (ClientName != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(ToDate));
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adp.Fill(dt);

                //DataSet1 ds = new DataSet1();
                //adp.Fill(ds, ds.Tables[0].TableName);
                //ReportDataSource rds = new ReportDataSource("dueTickets", ds.Tables[0]);

                con.Close();
                myobj.data(status, Ticket_ID, ticketType, Assigned, ClientName, PageNumber, pagesize, FromDate, ToDate);
                return dt;
            }
            catch
            {
                return dt;
            }




        }
        public int checkAssignTicket()
        {


            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_ID);
                cmd.Parameters.AddWithValue("@Action", "CheckAssignTicket");


                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }



            }
            catch
            {
                con.Close();
                return 0;
            }
        }
        public int Deleteticket()
        {

            try
            {


                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_ID);
                cmd.Parameters.AddWithValue("@Action", "DeleteTicket");

                con.Open();

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
        public int getTotalRecord()
        {

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Status", status);
                if (ClientName != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@TicketType", ticketType);
                cmd.Parameters.AddWithValue("@AssignedStatus", Assigned);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@DateFrom", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@DateTo", Convert.ToDateTime(ToDate));
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
                cmd.Parameters.AddWithValue("@Action", "GetTotalDuesRecord");
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



    }
}
