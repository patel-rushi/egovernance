using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;


namespace TestingSystems.App_Data
{
    class clsNewTickets
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsNewTickets()
        {
            con = obj.Con();
        }


        public Guid ClientName { get; set; }
        public string User_id { get; set; }
        public int TicketType { get; set; }
        public string IssueDate { get; set; }
        public string ModuleName { get; set; }
        public string FormName { get; set; }
        public string Version { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public byte FileUpload { get; set; }
        public DataTable dtFileUploadImage { set; get; }
        public string FilePath { set; get; }
        public Guid Ticket_ID { get; set; }
        public string ReprasentativeName { set; get; }
        public Guid ReprasentativeID { set; get; }
        public string ReportedBy { set; get; }


        public int InsertReprasentative()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "InsertRep");
                cmd.Parameters.AddWithValue("@ReprasentativeName", ReprasentativeName);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }
        }

        public int InsertModule()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "InsertModule");
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }

        }
        public int InsertForm()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "InsertForm");
                cmd.Parameters.AddWithValue("@FormName", FormName);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }

        }

        public int DeleteForm()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DeleteForm");
                cmd.Parameters.AddWithValue("@FormName", FormName);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }

        }


        public int InsertVersion()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "InsertVersion");
                cmd.Parameters.AddWithValue("@Version", Version);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;

            }
        }
        public int AssignNewTicket()
        {
            try
            {
               String XMLUploadImage;

                using (StringWriter stringWriter = new StringWriter())
                {
                    dtFileUploadImage.TableName = "ImageUpload";

                    dtFileUploadImage.WriteXml(stringWriter);

                    XMLUploadImage =stringWriter.ToString();
                }

               
               

                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "IssueTicket");
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                cmd.Parameters.AddWithValue("@UserId", User_id);
                cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                cmd.Parameters.AddWithValue("@FormName", FormName);
                cmd.Parameters.AddWithValue("@Version", Version);
                cmd.Parameters.AddWithValue("@Priority", Priority);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@FileAtt", XMLUploadImage);
                cmd.Parameters.AddWithValue("@ReportedBy", ReportedBy);
                cmd.Parameters.AddWithValue("@TicketType", TicketType);
                cmd.Parameters.AddWithValue("@ReprasentativeID", ReprasentativeID);
                cmd.Parameters.AddWithValue("@FilePath", FilePath);
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch (Exception)
            {
                return 0;
                
            }
        }

        public int UpdateData()
        {
            try
            {
                String XMLUploadImage;

                using (StringWriter stringWriter = new StringWriter())
                {
                    dtFileUploadImage.TableName = "ImageUpload";

                    dtFileUploadImage.WriteXml(stringWriter);

                    XMLUploadImage = stringWriter.ToString();
                }
              
                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "IssueTicketUpdate");
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_ID);
                cmd.Parameters.AddWithValue("@ClientName", ClientName);
                
                cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                cmd.Parameters.AddWithValue("@ModuleName", ModuleName);
                cmd.Parameters.AddWithValue("@FormName", FormName);
                cmd.Parameters.AddWithValue("@Version", Version);
                cmd.Parameters.AddWithValue("@Priority", Priority);
                cmd.Parameters.AddWithValue("@ReprasentativeID", ReprasentativeID);
                cmd.Parameters.AddWithValue("@ReportedBy", ReportedBy);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@TicketType", TicketType);
                cmd.Parameters.AddWithValue("@FileAtt", XMLUploadImage);
                cmd.Parameters.AddWithValue("@FilePath", FilePath);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        
        }
        DataSet ds;
        public DataSet  SelectForUpdate( )
        {
            
            
            try
            {
              

            

                SqlCommand cmd = new SqlCommand("SP_NewTicketAssign", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SelectForUpdate");
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_ID);
                DataSet ds=new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adp.Fill(ds);



                return ds;
            }
            catch (Exception)
            {
                return ds;

            }
        }
        
    }
}
