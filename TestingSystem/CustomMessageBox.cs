using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        public int returnvalue;
        private void skipthis_Click(object sender, EventArgs e)
        {

            returnvalue = 0;
            this.Close();
        }

        private void skipall_Click(object sender, EventArgs e)
        {
            returnvalue = 1;
        }
    }
}
