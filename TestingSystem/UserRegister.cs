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
    public partial class UserRegister : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestingCon"].ConnectionString);

        public UserRegister()
        {
            InitializeComponent();
        }
       
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try {


                clsRegister obj = new clsRegister();
                obj.UserName = txtUserName.Text;
                obj.Password = txtPass.Text;
                obj.UserType = cmbType.Text;
                if (txtUserName.Text != "" && txtPass.Text != "" && cmbType.Text != "Select")
                {


                    if (obj.UserRegisteration() > 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Register SuccessFully. ");
                        UserLogIn userobj = new UserLogIn();
                        userobj.Show();
                        this.Dispose();
                    }

                   



                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("Please Select All Fields. ");
                }
               
                
                
               
                
            
            
            }
            catch { 
            
            
            
            
            }
           
            
        }
    }
}
