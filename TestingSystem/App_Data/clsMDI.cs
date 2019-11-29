using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystems.App_Data
{
    class clsMDI
    {
        public string Userid { get; set; }
        public string Usertype { get; set; }
        
        public void NewTickets()
        {

            NewTicket obj = new NewTicket(Userid, Usertype);
           
            
            obj.Show();
        }
        public void DueTickets()
        {
            DuesTicket obj = new DuesTicket(Userid, Usertype);
            obj.Show();
        }
        public void Mytickets()
        {
        Mytickets obj = new Mytickets(Userid, Usertype);
            obj.Show();
        }
        public void ApproveTickets()
        {

            TicketsApproval obj = new TicketsApproval(Userid, Usertype);
            obj.Show();
        
        }
        public void LogOut()
        {
           
            UserLogIn obj = new UserLogIn();
            
            obj.Show();
        
        }
    }
}
