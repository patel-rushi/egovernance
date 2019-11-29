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
    public partial class AssigneTicket : Form
    {
        private ImageList imagelst;
        Guid Ticket_ID;
        string User_Type;
        string User_Name;
        public AssigneTicket(Guid TicketID,string UserType,string UserName)
        {
            
            InitializeComponent();
            Ticket_ID = TicketID;
            User_Type = UserType;
            User_Name = UserName;
            imagelst = new ImageList();
        }
        void BindUser()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if (dt!=null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");
                    cmbAssignTo.ValueMember = "UserID";
                    cmbAssignTo.DisplayMember = "UserName";
                    cmbAssignTo.DataSource = dt;

                }

                }
          
        }

        void bindlvl1()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);
                    lvl1.ValueMember = "UserID";
                    lvl1.DisplayMember = "UserName";
                    lvl1.DataSource = dt;
                }
            }
        }

        void bindlvl2()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);
                    lvl2.ValueMember = "UserID";
                    lvl2.DisplayMember = "UserName";
                    lvl2.DataSource = dt;
                }
            }
        }

        void bindlvl3()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindUser();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);
                    lvl3.ValueMember = "UserID";
                    lvl3.DisplayMember = "UserName";
                    lvl3.DataSource = dt;
                }
            }
        }

        void BindAssignData()
        {
            clsAssigneTickets obj = new clsAssigneTickets();
            obj.Ticket_id = Ticket_ID;
            obj.AssignTicket();
           
            ClientName.Text = obj.ClientName;
            Status.Text = obj.Status;
            Module.Text = obj.Module;
            FormName.Text = obj.FormName;
            Priority.Text = obj.Priority;
            Version.Text = obj.Version;
            rtbDescription.Text = obj.Description;
            IssueDate.Text = obj.IssueDate;

           


        }
       
        private void AssigneTicket_Load(object sender, EventArgs e)
        {
            cmbQA.Text = "Select";
            btnAssign.Enabled = false;
            if (User_Type == "ADMIN")
            {
                BindUser();
                BindAssignData();
                cmbAssignTo.Enabled = true;
                complete.Visible = false;
                lblHeaderAssign.Text = "Assign Ticket ";
                lblAssignTo.Visible = true;
                cmbQA.Visible = true;
                label10.Visible = false;
                Hours_Of_Work.Enabled = true;
                work.Enabled = true;
                btnAssign.Enabled = true;
            }
            else {

              
                cmbAssignTo.Enabled =false;
                DtDate.Enabled = false;
                DtTime.Enabled = false;
                lblHeaderAssign.Text = "Ticket Status :";
                lblAssignTo.Visible = false;
                lblSubmissionDate.Enabled = true;
                lblSubmissionTime.Enabled = true;
                cmbQA.Visible = false;
                cmbAssignTo.Visible = false;
                label4.Visible = false;
                cmbQA.Visible = false;
                btnAssign.Text = "Submit";
                complete.Visible = true;
                Hours_Of_Work.Enabled = true;
                work.Enabled = false;


                BindAssignData();

            
            }
        }

        

        private void btnAssign_Click(object sender, EventArgs e)
        {

            try
            {
                if (User_Type == "ADMIN")
                {


                    if (cmbAssignTo.Text == "Select" || cmbAssignTo.Text == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Please Select Assign Name. ");
                        return;
                    }
                    else
                    {

                        clsAssigneTickets obj = new clsAssigneTickets();
                        obj.Ticket_id = Ticket_ID;
                        obj.AssignTo = cmbAssignTo.SelectedValue.ToString() ;
                        obj.AssignDate = DtDate.Value;
                        obj.AssignTime = DtTime.Value;
                        obj.Levels = Convert.ToInt32(cmbQA.Text);
                        obj.lvl1 = lvl1.SelectedValue.ToString();
                        obj.lvl2 = lvl2.SelectedValue.ToString();
                        obj.lvl3 = lvl3.SelectedValue.ToString();

                        if (obj.AssignedByAdmin() > 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Ticket Assigned To " + cmbAssignTo.Text);
                            
                            DuesTicket Obj = new DuesTicket(User_Name, User_Type);
                            
                            Obj.Refresh();
                            this.Hide();
                        }

                        


                    }
                }
                else
                {
                    //if (cmbStatus.Text == "Select" || cmbStatus.Text == "")
                    //{
                    //    System.Windows.Forms.MessageBox.Show("Please Select Status ");
                    //    return;
                    //}
                    
                    clsAssigneTickets obj = new clsAssigneTickets();
                    obj.Ticket_id = Ticket_ID;
                    obj.TicketStatus = "CLOSE";
                    if (obj.ChangeStatus() > 0)
                    {

                        System.Windows.Forms.MessageBox.Show("Ticket Completed ! Under Review by QA ");
                        
                        this.Hide();
                    }
                   
                }
            }
            catch 
            {
               

            }
        
        }

        private void lblHeaderAssign_Click(object sender, EventArgs e)
        {

        }

        private void cmbQA_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindlvl1();
            bindlvl2();
            bindlvl3();

            if(cmbQA.Text=="Select")
            {
                lvl1.Visible = false;
                lvl2.Visible = false;
                lvl3.Visible = false;

                labellvl1.Visible = false;
                labellvl2.Visible = false;
                labellvl3.Visible = false;
            }

            if (cmbQA.Text=="1")
            {
                

                lvl1.Visible = true;
                lvl2.Visible = false;
                lvl3.Visible = false;

                labellvl1.Visible = true;
                labellvl2.Visible = false;
                labellvl3.Visible = false;
            }

            else if (cmbQA.Text == "2")
            {
                lvl1.Visible = true;
                lvl2.Visible = true;
                lvl3.Visible = false;


                labellvl1.Visible = true;
                labellvl2.Visible = true;
                labellvl3.Visible = false;
            }
            else if (cmbQA.Text == "3")
            {
                lvl1.Visible = true;
                lvl2.Visible = true;
                lvl3.Visible = true;


                labellvl1.Visible = true;
                labellvl2.Visible = true;
                labellvl3.Visible = true;
            }
        }

        private void complete_CheckedChanged(object sender, EventArgs e)
        {
            if(complete.Checked)
            {
                btnAssign.Enabled = true;
                lblcd.Visible = true;
                lblct.Visible = true;
                cd.Visible = true;
                ct.Visible = true;
            }
            else
            {
                btnAssign.Enabled = false;
                lblcd.Visible = false;
                lblct.Visible = false;
                cd.Visible = false;
                ct.Visible = false;
            }
        }
    }
}
