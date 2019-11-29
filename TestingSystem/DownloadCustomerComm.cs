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
using TestingSystems.Helpers;
using Microsoft.Reporting.WinForms;

namespace TestingSystems
{
    public partial class DownloadCustomerComm : Form
    {
        DataTable DT;
        public string _CompanyName;
        public DownloadCustomerComm(DataTable dt)
        {
            InitializeComponent();
            
            reportViewer1.ShowExportButton = false;

            AutoFitForm.SetGroupBoxLoction(groupBox1);
            ToolStripButton newExportButton = new ToolStripButton("Export", null, new EventHandler(btnExport), "newExport");
            ((ToolStrip)(reportViewer1.Controls.Find("toolStrip1", true)[0])).Items.Add(newExportButton);

            DT = dt;
        }

        private void DownloadCustomerComm_Load(object sender, EventArgs e)
        {

            AutoFitForm.SetFormToMaximize(this);
            //set Processing Mode of Report as Local  
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report  

            reportViewer1.LocalReport.ReportPath = "D:\\HRPortal\\trunk\\TestingSystem\\Reports\\CustomerCommunication.rdlc";


            //Providing DataSource for the Report  
            ReportDataSource rds = new ReportDataSource("DataSet1", DT);
            ReportDataSource rds2 = new ReportDataSource("DataSet2", DT);
            reportViewer1.LocalReport.DataSources.Clear();
            //Add ReportDataSource  
           
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.DataSources.Add(rds2);
            ReportParameter ReportPara = new ReportParameter("CompanyNameSet", _CompanyName);
            reportViewer1.LocalReport.SetParameters(ReportPara);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 75;
           
            this.reportViewer1.RefreshReport();
        
        }

        private void btnExport(object sender, EventArgs e)
        {
            string ReportName = "CustomerCommunication";
            reportViewer1.ExportExcel(ReportName);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
