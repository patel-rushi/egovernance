
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using TestingSystems.App_Data;

namespace TestingSystems
{

   
    public partial class UserLogIn : Form
    {
       
       
        
        string userID;
        string UserType;
       
        public UserLogIn()
        {
            InitializeComponent();
            
          // AutoFitForm.SetGroupBoxLoction(groupBoxMain);
        }
        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                btnSave_Click(null, null);
            }
          
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                Clslogin objLogin = new Clslogin();
                objLogin.username = txtUserName.Text;
                objLogin.Password = txtPassword.Text;
                DataTable dtLogin = objLogin.getLogin();

                if (dtLogin != null && dtLogin.Rows.Count > 0)
                {
                    UserType = dtLogin.Rows[0]["UserType"].ToString();
                    userID = dtLogin.Rows[0]["ID"].ToString();
                    Constants.UserAssignId = dtLogin.Rows[0]["UserID"].ToString();
                    Session.Create(Convert.ToInt32(dtLogin.Rows[0]["ID"]), Convert.ToInt32(userID), dtLogin.Rows[0]["username"].ToString(), dtLogin.Rows[0]["UserType"].ToString(), "", Convert.ToInt32(userID));                                                                                    
                           
                    this.Hide();
                    MDIParent obj = new MDIParent(userID, UserType, txtUserName.Text);
                    

                    obj.Show();
                }
                else
                {
                  
                    System.Windows.Forms.MessageBox.Show(" Incorrect Password.");
                }
            }
            catch 
            {
                MessageBox.Show("Some invalid access");
            }

        }

        /*private void btnRegister_Click(object sender, EventArgs e)
        {
            UserRegister obj = new UserRegister();
            obj.Show();
        }*/

        private void UserLogIn_Load(object sender, EventArgs e)
        {
           // AutoFitForm.SetFormToMaximize(this);

        }

        private void groupBoxMain_Enter(object sender, EventArgs e)
        {

        }
    }
}
