using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public partial class Add_Version : Form
    {
        public Add_Version()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsNewTickets obj = new clsNewTickets();
            if (txtVer.Text != string.Empty)
                obj.Version = txtVer.Text;
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert Version Name.");
                return;
            }

            if (obj.InsertVersion() > 0)
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
