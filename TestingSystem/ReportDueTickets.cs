using Microsoft.Reporting.WinForms;
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
using System.Data.SqlClient;

namespace TestingSystems
{
    public partial class ReportDueTickets : Form
    {
        //DataTable DT;
        string Filter = "";
        Guid ClientName_;
        string St;
        int AsSt, Tity;
        string DateF, DateT;
        string Cname;
        public ReportDueTickets(DataTable dt)
        {
            DataTable DT = new DataTable();
            InitializeComponent();
            reportViewer1.ShowExportButton = false;

            AutoFitForm.SetGroupBoxLoction(groupBox1);
            ToolStripButton newExportButton = new ToolStripButton("Export", null, new EventHandler(btnExport), "newExport");
            ((ToolStrip)(reportViewer1.Controls.Find("toolStrip1", true)[0])).Items.Add(newExportButton);

            DT = dt;

        }
        public ReportDueTickets(Guid ClientName,string cname,string Status,int AssignedStatus,int ticketType,string DateFrom,string DateTo)
        {
           
            InitializeComponent();
            reportViewer1.ShowExportButton = false;

            AutoFitForm.SetGroupBoxLoction(groupBox1);
            ToolStripButton newExportButton = new ToolStripButton("Export", null, new EventHandler(btnExport), "newExport");
            ((ToolStrip)(reportViewer1.Controls.Find("toolStrip1", true)[0])).Items.Add(newExportButton);

          //  DT = dt;
            ClientName_ = ClientName;
            St = Status;
            AsSt = AssignedStatus;
            Tity = ticketType;
            DateF = DateFrom;
            DateT = DateTo;
            Cname = cname;
            if (cname != null && cname.ToString() != string.Empty && cname != "ALL")
            {
                Filter += "  Client Name  :  " + cname;
            }
            if (Status != null && Status.ToString() != string.Empty)
            {
                Filter += "  Status  :  " + Status;
            }
            if (AssignedStatus != -1)
            {
                Filter += "  AssignedStatus  :  " + AssignedStatus;
            }
            if (ticketType != -1)
            {
                Filter += "  TicketType  :  " + ticketType;
            }
            if (DateFrom != null && DateFrom.ToString() != string.Empty)
            {
                Filter += "  DateFrom  :  " + DateFrom;
            }
            if (DateTo != null && DateTo.ToString() != string.Empty)
            {
                Filter += "  DateTo  :  " + DateTo;
            }
        }

        public ReportDueTickets()
        {

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

        public void data(string mystatus, Guid ticketid, int tickettype, int assigned, Guid clientname, int pgno, int pgsize, string fromdate, string todate)
        {
            status = mystatus;
            ClientName = clientname;
            FromDate = fromdate;
            ToDate = todate;
            Ticket_ID = ticketid;
            pagesize = pgsize;
            ticketType = tickettype;
            PageNumber = pgno;
            Assigned = assigned;
        }

        private void ReportDueTickets_Load(object sender, EventArgs e)
        {
            //DataSet1 ds123 = new DataSet1();
            DataSet ds = new DataSet();
            AutoFitForm.SetFormToMaximize(this);
            //set Processing Mode of Report as Local  
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report  
            reportViewer1.LocalReport.ReportPath = "D:\\HRPortal\\trunk\\TestingSystem\\dueTicketsReport.rdlc";
            
            
            //Providing DataSource for the Report  

            //ReportDataSource rds = new ReportDataSource("dsDueTickets", DT);

            //reportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource  
            //reportViewer1.LocalReport.DataSources.Add(rds);
            try
            {
                clsDueTickets cdt = new clsDueTickets();
                clsDAL obj = new clsDAL();
                SqlConnection con = new SqlConnection();

                con = obj.Con();
                con.Open();
               // SqlCommand cmd = new SqlCommand("ReportOnGetTickets", con);
               // cmd.CommandType = CommandType.StoredProcedure;
               // // cmd.Parameters.AddWithValue("@Action", "Status");
               // cmd.Parameters.AddWithValue("@Status", St);
               // cmd.Parameters.AddWithValue("@TicketType",Tity );
               // cmd.Parameters.AddWithValue("@AssignedStatus",AsSt );
               //// if (ClientName_ != Guid.Empty)
               //     cmd.Parameters.AddWithValue("@ClientName", ClientName_);
               // //cmd.Parameters.AddWithValue("@PageNumber", 1);
               // //cmd.Parameters.AddWithValue("@pagesize", 50);
               // cmd.Parameters.AddWithValue("@DateFrom", DateF);
               // cmd.Parameters.AddWithValue("@DateTo", DateT);
                SqlCommand cmd = new SqlCommand("SP_ReportOnAllTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@Action", "Status");
                cmd.Parameters.AddWithValue("@Status", St);
                cmd.Parameters.AddWithValue("@TicketTypeId", Tity);
                cmd.Parameters.AddWithValue("@AssignedId", AsSt);
                // if (ClientName_ != Guid.Empty)
                cmd.Parameters.AddWithValue("@ClientId", ClientName_);
                //cmd.Parameters.AddWithValue("@PageNumber", 1);
                //cmd.Parameters.AddWithValue("@pagesize", 50);
                cmd.Parameters.AddWithValue("@DateFrom", DateF);
                cmd.Parameters.AddWithValue("@DateTo", DateT);
                

                SqlDataAdapter sql = new SqlDataAdapter(cmd);

                sql.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ReportDataSource data = new ReportDataSource("DataSet1", ds.Tables[0]);
            Microsoft.Reporting.WinForms.ReportParameter fp = new Microsoft.Reporting.WinForms.ReportParameter("FilterPrint", Filter);
            reportViewer1.LocalReport.SetParameters(fp);
           // ReportParameter fILTERpRINT = new ReportParameter("FilterPrint", Filter);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(data);
            //if(true)
            //{
            //    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            //}
            //else
          //  {
              reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //}
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
            
        }

        private void btnExport(object sender, EventArgs e)
        {
            string ReportName = "RptDueTickets";
            reportViewer1.ExportExcel(ReportName);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           

           

        }
    }
}
