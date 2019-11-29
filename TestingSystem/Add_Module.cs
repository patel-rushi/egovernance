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
    public partial class Add_Module : Form
    {
        public Add_Module()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsNewTickets obj = new clsNewTickets();
            if (txtRep.Text != string.Empty)
                obj.ModuleName = txtRep.Text;
            else
            {
                System.Windows.Forms.MessageBox.Show("Insert Module Name.");
                return;
            }

            if (obj.InsertModule() > 0)
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
