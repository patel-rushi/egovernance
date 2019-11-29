using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class ReportedBy : Form
    {
        public ReportedBy()
        {
            InitializeComponent();
          //  AutoFitForm.SetGroupBoxLoction(GBReportedThrough);
        }

        private void ReportedBy_Load(object sender, EventArgs e)
        {
           // AutoFitForm.SetFormToMaximize(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsNewTickets obj = new clsNewTickets();
            if (txtRep.Text != string.Empty)
                obj.ReprasentativeName = txtRep.Text;
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert Reprasentative Name.");
                return;
            }
           
            if (obj.InsertReprasentative() > 0)
            {
                System.Windows.Forms.MessageBox.Show("Save Done.");
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(" Can't Save .");
            }
        }
    }
}
