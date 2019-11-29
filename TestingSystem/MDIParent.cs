using MasterUpload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.HR;

namespace TestingSystems
{
    public partial class MDIParent : Form
    {
        String UserID;
        String User_Type;
        String User_Name;

        public MDIParent(string User_ID, string UserType)
        {
            UserID = User_ID;
            User_Type = UserType;
            InitializeComponent();
            lOgoutToolStripMenuItem.Text = "LogOut : " + User_Type;


        }
        public MDIParent(string User_ID, string UserType, string UserName)
        {
            UserID = User_ID;
            User_Type = UserType;
            User_Name = UserName;
            InitializeComponent();
            lOgoutToolStripMenuItem.Text = "LogOut : " + User_Type + " (" + UserName + ")";

        }
        void CloseBrowser()
        {
            
            webBrowser1.Visible = false;
        }

        void Close_All_Forms()
        {

            if (Application.OpenForms.OfType<DailyWorkReport>().Count() == 1)
                Application.OpenForms.OfType<DailyWorkReport>().First().Close();

            if (Application.OpenForms.OfType<DuesTicket>().Count() == 1)
                Application.OpenForms.OfType<DuesTicket>().First().Close();

            if (Application.OpenForms.OfType<ShowDetailsDuesTicket>().Count() == 1)
                Application.OpenForms.OfType<ShowDetailsDuesTicket>().First().Close();

            if (Application.OpenForms.OfType<NewTicket>().Count() == 1)
                Application.OpenForms.OfType<NewTicket>().First().Close();

            if (Application.OpenForms.OfType<Mytickets>().Count() == 1)
                Application.OpenForms.OfType<Mytickets>().First().Close();


            if (Application.OpenForms.OfType<TicketsApproval>().Count() == 1)
                Application.OpenForms.OfType<TicketsApproval>().First().Close();

            if (Application.OpenForms.OfType<ApprovedTickets>().Count() == 1)
                Application.OpenForms.OfType<ApprovedTickets>().First().Close();

            if (Application.OpenForms.OfType<ClientOrder>().Count() == 1)
                Application.OpenForms.OfType<ClientOrder>().First().Close();

            if (Application.OpenForms.OfType<Customer_Inquiry>().Count() == 1)
                Application.OpenForms.OfType<Customer_Inquiry>().First().Close();

            if (Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().Count() == 1)
                Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().First().Close();

            if (Application.OpenForms.OfType<CustomerCommunication>().Count() == 1)
                Application.OpenForms.OfType<CustomerCommunication>().First().Close();

            if (Application.OpenForms.OfType<CustomerMaster>().Count() == 1)
                Application.OpenForms.OfType<CustomerMaster>().First().Close();


            if (Application.OpenForms.OfType<Form2>().Count() == 1)
                Application.OpenForms.OfType<Form2>().First().Close();

            if (Application.OpenForms.OfType<UserRegister>().Count() == 1)
                Application.OpenForms.OfType<UserRegister>().First().Close();

            if (Application.OpenForms.OfType<AccessRights>().Count() == 1)
                Application.OpenForms.OfType<AccessRights>().First().Close();

            if (Application.OpenForms.OfType<LeaveApplication>().Count() == 1)
                Application.OpenForms.OfType<LeaveApplication>().First().Close();


        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            UserLogIn obj = new UserLogIn();

            obj.Show();
            this.Hide();

        }



        private void MDIParent_Load_1(object sender, EventArgs e)
        {
            //GoogleFeeds gobj = new GoogleFeeds();
            //gobj.Show();
           // webBrowser1.Navigate("www.google.co.in");

            if (User_Type == "ADMIN")
            {
                Report.Visible = true;
                workReportToolStripMenuItem.Visible = true;
                registerWorkReportsToolStripMenuItem.Visible = true;

                Tickets.Visible = true;
                newTicketsToolStripMenuItem.Visible = true;
                ticketsRegisterToolStripMenuItem.Visible = true;
                myTicketsToolStripMenuItem1.Visible = true;
                ticketsForApprovalToolStripMenuItem.Visible = true;
                approvedTicketsToolStripMenuItem.Visible = true;

                Marketing.Visible = true;
                customerMasterToolStripMenuItem.Visible = true;
                inquiryToolStripMenuItem1.Visible = true;
                inquiryRegisterToolStripMenuItem.Visible = true;
                clientCommunicationToolStripMenuItem.Visible = true;
                orderAndAMCToolStripMenuItem.Visible = true;

                FileUpload.Visible = true;

                configurationsToolStripMenuItem.Visible = true;
                newUserRegistrationToolStripMenuItem.Visible = true;
                accessRightsToolStripMenuItem.Visible = true;

                attendanceToolStripMenuItem.Visible = true;
                leaveApplicationToolStripMenuItem.Visible = true;
                leaveApplicationRegisterToolStripMenuItem.Visible = true;

                lOgoutToolStripMenuItem.Visible = true;
            }
            else
            {
                clsAccessRights obj = new clsAccessRights();
                DataTable dt = obj.get(UserID, User_Type, User_Name);

                if (Convert.ToInt16(dt.Rows[0][0]) == 1)
                {
                    Report.Visible = true;
                    workReportToolStripMenuItem.Visible = true;
                }


                if (Convert.ToInt16(dt.Rows[0][1]) == 1)
                {
                    Report.Visible = true;
                    registerWorkReportsToolStripMenuItem.Visible = true;
                }

                if (Convert.ToInt16(dt.Rows[0][2]) == 1)
                {
                    Tickets.Visible = true;
                    newTicketsToolStripMenuItem.Visible = true;
                }

                if (Convert.ToInt16(dt.Rows[0][3]) == 1)
                {
                    Tickets.Visible = true;
                    ticketsRegisterToolStripMenuItem.Visible = true;

                }

                if (Convert.ToInt16(dt.Rows[0][4]) == 1)
                {
                    Tickets.Visible = true;
                    myTicketsToolStripMenuItem1.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][5]) == 1)
                {
                    Tickets.Visible = true;
                    ticketsForApprovalToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][6]) == 1)
                {
                    Tickets.Visible = true;
                    approvedTicketsToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][7]) == 1)
                {
                    Marketing.Visible = true;
                    customerMasterToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][8]) == 1)
                {
                    Marketing.Visible = true;
                    inquiryToolStripMenuItem1.Visible = true;
                    inquiryRegisterToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][9]) == 1)
                {
                    Marketing.Visible = true;
                    clientCommunicationToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][10]) == 1)
                {
                    Marketing.Visible = true;
                    orderAndAMCToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][11]) == 1)
                {
                    FileUpload.Visible = true;
                }

                if (Convert.ToInt16(dt.Rows[0][12]) == 1)
                {
                    configurationsToolStripMenuItem.Visible = true;
                    newUserRegistrationToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][13]) == 1)
                {
                    configurationsToolStripMenuItem.Visible = true;
                    accessRightsToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][16]) == 1)
                {
                    lOgoutToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][14]) == 1)
                {
                    attendanceToolStripMenuItem.Visible = true;
                    leaveApplicationToolStripMenuItem.Visible = true;
                }
                if (Convert.ToInt16(dt.Rows[0][15]) == 1)
                {
                    attendanceToolStripMenuItem.Visible = true;
                    leaveApplicationRegisterToolStripMenuItem.Visible = true;
                }
            }

        }

        private void MasterFileMenustrip_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Form2 obj = new Form2();

            obj.MdiParent = this;
            obj.Show();
           
        }

        private void lOgoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<UserRegister>().Count() == 1)
                Application.OpenForms.OfType<UserRegister>().First().Close();
            UserLogIn obj = new UserLogIn();

            obj.Show();
            this.Hide();
          

        }

        private void registerWorkReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Forms();
            CloseBrowser();
            ShowDetailsDuesTicket obj = new ShowDetailsDuesTicket(UserID, User_Type);

            obj.FullScreenOff = 0;

            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
          

        }



        private void workReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Forms();
            CloseBrowser();
            DailyWorkReport obj = new DailyWorkReport(UserID, User_Type);
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void newTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Close_All_Forms();
            CloseBrowser();
            NewTicket obj = new NewTicket(UserID, User_Type);

            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
           

        }

        private void ticketsRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Close_All_Forms();
            CloseBrowser();
            DuesTicket obj = new DuesTicket(UserID, User_Type);
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();

            
        }

        private void myTicketsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Close_All_Forms();
            CloseBrowser();
            Mytickets obj = new Mytickets(UserID, User_Type);

            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void ticketsForApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close_All_Forms();
            CloseBrowser();
            TicketsApproval obj = new TicketsApproval(UserID, User_Type);

            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
            //  obj.NewTickets();



        }

        private void approvedTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_All_Forms();
            CloseBrowser();
            ApprovedTickets obj = new ApprovedTickets();

            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void customerMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {

                Close_All_Forms();
                CloseBrowser();
                CustomerMaster customerMaster = new CustomerMaster(new CustomerSupplierInputParameters(Enums.FormMode.Insert));

                customerMaster.FullScreenOff = 0;
                customerMaster.MdiParent = this;
                customerMaster.Show();
                customerMaster.Focus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
        }

        private void inquiryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                Close_All_Forms();
                CloseBrowser();
                Customer_Inquiry
                    CusInqiry = new Customer_Inquiry();
                CusInqiry.MdiParent = this;
                CusInqiry.Show();
                CusInqiry.Focus();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
        }

        private void clientCommunicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseBrowser();
                //if Customer_Communication is already open then it close first 
                Close_All_Forms();

                CustomerCommunication
                    customerComm = new CustomerCommunication();
                customerComm.MdiParent = this;
                customerComm.Show();
                customerComm.Focus();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
          
        }

        private void orderAndAMCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseBrowser();
                Close_All_Forms();

                ClientOrder
                    clientorderform = new ClientOrder();
                clientorderform.MdiParent = this;
                clientorderform.Show();
                clientorderform.Focus();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
           
        }

        private void accessRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            AccessRights obj = new AccessRights();
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void newUserRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            UserRegister obj = new UserRegister();
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void inquiryRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            try
            {

                if (Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().Count() == 1)
                    Application.OpenForms.OfType<ShowDetails_CustomerInquiry>().First().Close();

                ShowDetails_CustomerInquiry

                    clientregisterform = new ShowDetails_CustomerInquiry();
                clientregisterform.MdiParent = this.ParentForm;

                clientregisterform.Show();
                clientregisterform.Focus();

            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void leaveApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            LeaveApplication obj = new LeaveApplication(UserID);
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void leaveApplicationRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            LeaveApplicationRegister obj = new LeaveApplicationRegister();
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
           
        }

        private void performanceCriteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            PerformanceCriteria obj = new PerformanceCriteria();
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
            
        }

        private void skillSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (User_Type.ToLower() == "admin")
            {
                CloseBrowser();
                Close_All_Forms();
                SkillsetDetails obj = new SkillsetDetails();
                obj.FullScreenOff = 0;
                obj.MdiParent = this;
                obj.Show();
                obj.Focus();
            }
            else
            {
                CloseBrowser();
                Close_All_Forms();
                AddSkillForm obj = new AddSkillForm(UserID);
                obj.FullScreenOff = 0;
                obj.MdiParent = this;
                obj.Show();
                obj.Focus();
            }
            
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            EmployeeMaster obj = new EmployeeMaster();
            obj.FullScreenOff = 0;
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Close_All_Forms();
            if (User_Type.ToLower() != "admin")
            {
                AddFeedback obj = new AddFeedback(Convert.ToInt32(UserID));
                obj.FullScreenOff = 0;
                obj.MdiParent = this;
                obj.Show();
                obj.Focus();
            }
            else
            {
                CloseBrowser();
                FeedbackDetails obj = new FeedbackDetails(Convert.ToInt32(UserID), User_Type);
                obj.FullScreenOff = 0;
                obj.MdiParent = this;
                obj.Show();
                obj.Focus();
            }
        }

        private void performanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            Performance obj = new Performance(UserID);
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();
        }

        private void managementFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseBrowser();
            ManagementFeedback obj = new ManagementFeedback();
            obj.MdiParent = this;
            obj.Show();
            obj.Focus();

           
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.Visible = true;
        }
    }
}
