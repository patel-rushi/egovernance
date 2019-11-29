using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace TestingSystems.App_Data
{
    class clsAssigneTickets
    {
          
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsAssigneTickets()
        {
            con = obj.Con();
        }
      
        public Guid Ticket_id { get; set; }
        public string ClientName { get; set; }
        public string Status { get; set; }
        public string Module { get; set; }
        public string FormName { get; set; }
        public string Priority { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string IssueDate { get; set; }
        public string AssignTo { get; set; }
        public string TicketStatus { get; set; }
        public int Levels { get; set; }
        public int QALevelNo { get; set; }
        public string lvl1 { get; set; }
        public string lvl2 { get; set; }
        public string lvl3 { get; set; }

        public DateTime AssignDate { get; set; }
        public DateTime AssignTime { get; set; }
       
        
        public void AssignTicket()
        {
           
           
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("[SP_NewTicketAssign]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "AssignTicket");
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);                
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                   
                    ClientName = dt.Rows[0]["ClientName"].ToString();
                    Status = dt.Rows[0]["STATUS"].ToString();
                    Module = dt.Rows[0]["ModuleName"].ToString();
                    FormName = dt.Rows[0]["FormName"].ToString();
                    Priority = dt.Rows[0]["Priority"].ToString();
                    Version = dt.Rows[0]["Version"].ToString();
                    Description = dt.Rows[0]["Description"].ToString();
                    IssueDate = dt.Rows[0]["IssueDate"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }
     public   int  AssignedByAdmin()
        {
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AssignedTicket", con);


                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Action", "AssignTicket");
                cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
                cmd.Parameters.AddWithValue("@AssignedTO", AssignTo);
                cmd.Parameters.AddWithValue("@assignedDate", AssignDate);
                cmd.Parameters.AddWithValue("@AssignedTime", AssignTime);
                cmd.Parameters.AddWithValue("@Levels", Levels);

                for (int i=1; i<=3; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("SP_AssignedTicket", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    if (i==1&&lvl1!="")
                    {
                        cmd2.Parameters.AddWithValue("@QALevelNo", 1);
                        cmd2.Parameters.AddWithValue("@User_ID", lvl1);
                    }
                    else if (i == 2&&lvl2!="")
                    {
                        cmd2.Parameters.AddWithValue("@QALevelNo", 2);
                        cmd2.Parameters.AddWithValue("@User_ID", lvl2);
                    }
                    else if (i == 3&&lvl3!="")
                    {
                        cmd2.Parameters.AddWithValue("@QALevelNo", 3);
                        cmd2.Parameters.AddWithValue("@User_ID", lvl3);
                    }
                    cmd2.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
                    cmd2.Parameters.AddWithValue("@Action", "QAAssign");

                    cmd2.ExecuteNonQuery();
                }
                
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            catch{
               

                return 0;
            }
            
        
        }
     public int ChangeStatus()
     {
         try
         {
          
             con.Open();
             SqlCommand cmd = new SqlCommand("[SP_Approval]", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Action", "UpdateStatus");
             cmd.Parameters.AddWithValue("@Ticket_ID", Ticket_id);
             cmd.Parameters.AddWithValue("@Status", TicketStatus);
             cmd.ExecuteNonQuery();
             
             return 1;
         }
         catch(Exception ex)
         {
                MessageBox.Show(ex.ToString());
                return 0;
         
         
         }

     }
       
    }
}
