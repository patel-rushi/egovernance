using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace TestingSystems.App_Data
{
    class clsWorkReport
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsWorkReport()
        {
            con = obj.Con();
        }
        public DataTable Dt { get; set; }
        public Int32 UserName { get; set; }
        public Int32 UserID { get; set; }
        public Guid ClientName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int pagesize { get; set; }
        public int PageNumber { get; set; }
        public string Assigned { get; set; }
        public string TicketNumber { get; set; }
        public string UserType { get; set; }
        //public string TaskTypeText { get; set; }
        private object XMLWorkReport;
        //int i = 0;
        public int InsertWorkData()
        {

            try
            {
                if (Dt.Rows.Count > 0)
                {

                    string XMLWorkReport = "";
                    if (Dt != null && Dt.Rows.Count > 0)
                    {

                        using (StringWriter stringWriter = new StringWriter())
                        {
                            Dt.TableName = "WorkReportTable";

                            Dt.WriteXml(stringWriter);

                            XMLWorkReport = stringWriter.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                        }
                        //TaskTypeText = Dt.Rows[i].Cells["TaskTypeText"].Value;

                    }




                    con.Open();
                    SqlCommand cmd = new SqlCommand("Sp_WorkReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "InsertData");
                    cmd.Parameters.AddWithValue("@XMLWorkData", XMLWorkReport);
                    cmd.Parameters.AddWithValue("@UserID", UserName);
                    //cmd.Parameters.AddWithValue("@TaskTypeText", TaskTypeText);



                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                return 1;
            }
            catch
            {

                return 0;
            }

        }
        public DataTable GetWorkData()
        {

            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[Sp_WorkReport]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ShowRecord");
                if (ClientName != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ClientID", ClientName);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@TicketNumber", TicketNumber);
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
            catch 
            {
                return dt;
            }

        }
        public int getTotalRecord()
        {

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[Sp_WorkReport]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (ClientName != Guid.Empty)
                    cmd.Parameters.AddWithValue("@ClientID", ClientName);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@TicketNumber", TicketNumber);
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
                cmd.Parameters.AddWithValue("@Action", "TotalWailyWiseData");
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

        public object XMLCoreBoxDetails { get; set; }


        public DataTable GetTicketNumberForRPT()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_GetTicketNumber_For_Work_RPT]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (UserType.ToLower() == "admin")
                {
                    cmd.Parameters.AddWithValue("@Action", UserType);
                    cmd.Parameters.AddWithValue("@UserId", UserID);
                }
                else if (UserType.ToLower() == "other")
                {
                    cmd.Parameters.AddWithValue("@Action", "GetUserId");
                    cmd.Parameters.AddWithValue("@UserId", UserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserId", -1);
                    cmd.Parameters.AddWithValue("@Action", "");
                    cmd.Parameters.AddWithValue("@Assigned", Assigned);
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                dt = new DataTable();
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
