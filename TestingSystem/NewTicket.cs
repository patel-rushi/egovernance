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

using System.IO;
using MasterUpload;

namespace TestingSystems
{
    public partial class NewTicket : Form
    {
        List<String> multipleImage = new List<string>();
        string User_ID;
        string User_Type;
        Guid Ticket_ID;
        public Int32 FullScreenOff = 0;
        public NewTicket(string UserID,string UserType)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            User_ID=UserID;
            User_Type = UserType;
        }
        public NewTicket(Guid TicketID)
        {
            InitializeComponent();
            AutoFitForm.SetGroupBoxLoction(groupBox1);
            Ticket_ID = TicketID;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

          

        }

        private void NewTicket_Load(object sender, EventArgs e)
        {
            this.ControlBox = true;
            rdbBug.Checked = true;
            AutoFitForm.SetFormToMaximize(this);
            bindClient();
            bindModule();
            bindForm();
            bindVersion();
            bindReprasentative();
            if (Ticket_ID!=Guid.Empty)
            {
               
                FillUpdate();
                btnSubmit.Text = "Update";
               
           

               
            }
           
        }
        void bindReprasentative()
        {
            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindReprasentative();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["ReprasentativeName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbrep.ValueMember = "Id";
                    cmbrep.DisplayMember = "ReprasentativeName";
                    cmbrep.DataSource = dt;

                }

            }
        
        }

       
        void bindClient()
        {


            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindClientName();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["CustomerName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbClientName.ValueMember = "CustomerId";
                    cmbClientName.DisplayMember = "CustomerName";
                    cmbClientName.DataSource = dt;

                }

            }
        }
        void bindModule()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindModuleName();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Module_Name"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbmodule.ValueMember = "ID";
                    cmbmodule.DisplayMember = "Module_Name";

                    cmbmodule.DataSource = dt;



                }
            }
        }
        void bindForm()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindForm();
            if(dt!=null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Form_Name"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbForm.ValueMember = "ID";
                    cmbForm.DisplayMember = "Form_Name";

                    cmbForm.DataSource = dt;

                }

            }

        }
        void bindVersion()
        {

            clsBindUser obj = new clsBindUser();
            DataTable dt = obj.BindVersion();
              if(dt!=null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["VersionName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);

                    // cmbAssignTo.Items.Add("Select");

                    cmbVersion.ValueMember = "ID";
                    cmbVersion.DisplayMember = "VersionName";

                    cmbVersion.DataSource = dt;


                }
            }

        }
        void FillUpdate()
        {

           
                clsNewTickets obj = new clsNewTickets();
                obj.Ticket_ID = Ticket_ID;
                DataSet ds = obj.SelectForUpdate();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmbClientName.SelectedValue = ds.Tables[0].Rows[0]["Client_ID"].ToString();

                        ReDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                        if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != null)
                        cmbmodule.SelectedValue = ds.Tables[0].Rows[0]["ModuleID"].ToString();

                        if (ds.Tables[0].Rows[0]["FormID"].ToString() != null)
                        cmbForm.SelectedValue = ds.Tables[0].Rows[0]["FormID"].ToString();
                        if (ds.Tables[0].Rows[0]["ReprasentativeID"].ToString() != null)
                        cmbrep.SelectedValue = ds.Tables[0].Rows[0]["ReprasentativeID"].ToString();
                        if (ds.Tables[0].Rows[0]["ReportedBy"].ToString() != null)
                        txtreportedby.Text = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
                        if (ds.Tables[0].Rows[0]["VersionID"].ToString() != null)
                        cmbVersion.SelectedValue = ds.Tables[0].Rows[0]["VersionID"].ToString();

                        cmbpriority.Text = ds.Tables[0].Rows[0]["Priority"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                        if (Convert.ToInt32( ds.Tables[0].Rows[0]["TicketType"])==0)
                        {
                            rdbBug.Checked = true;
                            RdbNewReq.Checked = false;
                            training.Checked = false;
                            TicketType = 0;
                        }
                        else if (Convert.ToInt32(ds.Tables[0].Rows[0]["TicketType"]) == 1)
                        {
                            RdbNewReq.Checked = true;
                            rdbBug.Checked = false;
                        training.Checked = false;
                            TicketType = 1;
                        }
                        else
                    {
                        RdbNewReq.Checked = false;
                        rdbBug.Checked = false;
                        training.Checked = true;
                        TicketType = 2;
                    }

                }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        fillImage(ds.Tables[1]);
                    }
                }
        }
        void ClearData()
        {
            
            cmbpriority.SelectedValue = "";
            txtreportedby.Text = "";
            txtDescription.Text = "";
            imageUploadUserControl1.ClearAllImages();


        }
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
           
            if (cmbForm.Text.Trim() == "Select")
            {
                System.Windows.Forms.MessageBox.Show("Please Select Form Name");
            }
            else if (cmbmodule.Text.Trim() == "Select")
            {
                System.Windows.Forms.MessageBox.Show("Please Select module Name");

            }
            else
            {

                #region Code for Image Save

                /// Image move from one folder to another folder

                multipleImage = new List<string>();
                string folderName = AppDomain.CurrentDomain.BaseDirectory;
                string pathString = System.IO.Path.Combine(folderName, "TempTickets\\").Replace(@"\", "\\");
                if (Directory.Exists(pathString))
                {
                    foreach (string f in Directory.GetFiles(pathString))
                    {
                        multipleImage.Add(f);
                    }
                }

                DataTable dtFileUploadImagefile = new DataTable();

                dtFileUploadImagefile.Columns.Add("Photo", typeof(string));
                DataRow drFileUploadImage;

                for (int i = 0; i < multipleImage.Count; i++)
                {
                    #region Move file from temporary folder to server

                    Random _r = new Random();
                    String FileName = multipleImage[i].Substring(multipleImage[i].LastIndexOf("\\") + 1);
                    string rndFileName = _r.Next() + FileName;

                    string destinationpathCheck = Helpers.PathHelper.GetServerPath();
                    if (destinationpathCheck == "0")
                    {
                        const string type = "Shared folder of iCast file on server is not accessible files , so can not be uploaded. do you want to continue with data ?";
                        DialogResult dresult = System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dresult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    if (destinationpathCheck != "0")
                    {
                        String destinationpath = Helpers.PathHelper.TestingSystems() + rndFileName;
                        if (!File.Exists(Helpers.PathHelper.TestingSystems() + FileName))
                        {
                            if (multipleImage[i].Contains("//") || multipleImage[i].Contains("\\"))
                            {
                                File.Move(multipleImage[i], destinationpath);
                            }

                            #region Random file name store into datatable

                            drFileUploadImage = dtFileUploadImagefile.NewRow();
                            drFileUploadImage["Photo"] = rndFileName;
                            dtFileUploadImagefile.Rows.Add(drFileUploadImage);

                            #endregion
                        }
                    }
                    #endregion
                   
                }

               

                //  dieMaster.dtDeleteImage = dtDeleteImage;
               
                #endregion
                if (btnSubmit.Text == "Submit")
                {
                 clsNewTickets obj = new clsNewTickets();

                 obj.dtFileUploadImage = dtFileUploadImagefile;
                 obj.FilePath = Helpers.PathHelper.TestingSystems();
                obj.User_id = User_ID;
                obj.TicketType = TicketType;
                obj.ClientName =Guid.Parse(cmbClientName.SelectedValue.ToString());
                obj.ModuleName = cmbmodule.SelectedValue.ToString();
                obj.IssueDate = ReDate.Value.ToString();
                obj.FormName = cmbForm.SelectedValue.ToString();
                obj.Version = cmbVersion.SelectedValue.ToString();
                obj.Priority = cmbpriority.Text;
                obj.Description = txtDescription.Text;
                if ( cmbrep.SelectedValue.ToString()!=null && Guid.Parse(cmbrep.SelectedValue.ToString())!=Guid.Empty)
                 obj.ReprasentativeID =Guid.Parse(cmbrep.SelectedValue.ToString());
                obj.ReportedBy = txtreportedby.Text;
                if (obj.AssignNewTicket() > 0)
                {
                    bindClient();
                    bindModule();
                    bindForm();
                    bindVersion();
                    bindReprasentative();
                    ClearData();
                    System.Windows.Forms.MessageBox.Show("Ticket Generated Successfully.");

                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("Ticket Can't Save .");

                }
            }



                if (btnSubmit.Text == "Update")
                {
                    clsNewTickets obj = new clsNewTickets();
                   

                    obj.dtFileUploadImage = dtFileUploadImagefile;
                    obj.FilePath = Helpers.PathHelper.TestingSystems();
                    obj.Ticket_ID = Ticket_ID;
                    obj.ClientName =Guid.Parse( cmbClientName.SelectedValue.ToString());
                    obj.ModuleName = cmbmodule.SelectedValue.ToString();
                    obj.IssueDate = ReDate.Value.ToString();
                    obj.TicketType = TicketType;
                    obj.FormName = cmbForm.SelectedValue.ToString();
                    obj.Version = cmbVersion.SelectedValue.ToString();
                    obj.Priority = cmbpriority.Text;
                    obj.Description = txtDescription.Text;

                    if (cmbrep.SelectedValue.ToString() != null && Guid.Parse(cmbrep.SelectedValue.ToString()) != Guid.Empty)
                        obj.ReprasentativeID = Guid.Parse(cmbrep.SelectedValue.ToString());
                    obj.ReportedBy = txtreportedby.Text;
                    btnSubmit.Text = "Submit";


                    if (obj.UpdateData() != 0)
                    {
                        ClearData();
                        System.Windows.Forms.MessageBox.Show("Update SuccessFully.");
                    }
                    else
                    {

                        System.Windows.Forms.MessageBox.Show("Update not SuccessFull.");
                    }
                }
            }
        }
        void fillImage(DataTable dtFetchImageFiles)
        {
            #region Fetch ImageFile


            if (dtFetchImageFiles != null && dtFetchImageFiles.Rows.Count>0)
            {
                try
                {
                    string folderName = AppDomain.CurrentDomain.BaseDirectory;
                    string pathString = System.IO.Path.Combine(folderName, "TempTickets\\").Replace(@"\", "\\");
                    if (!Directory.Exists(pathString))
                        System.IO.Directory.CreateDirectory(pathString);

                    string destinationpathCheck = Helpers.PathHelper.PatternImageFile();
                    if (destinationpathCheck == "0")
                    {
                        const string type = "Shared folder of iCast file on server is not accessible files , so can not be uploaded.";
                        System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (destinationpathCheck != "0")
                    {
                        if (Directory.Exists(Helpers.PathHelper.PatternImageFile()))
                        {
                            for (int i = 0; i < dtFetchImageFiles.Rows.Count; i++)
                            {
                                if (File.Exists(Helpers.PathHelper.PatternImageFile() + dtFetchImageFiles.Rows[i]["FileName"].ToString()))
                                {
                                    String TransferFileFrom = Helpers.PathHelper.PatternImageFile() + dtFetchImageFiles.Rows[i]["FileName"].ToString();
                                    String Name = TransferFileFrom.Substring(TransferFileFrom.LastIndexOf("\\") + 1);
                                    multipleImage.Add(TransferFileFrom + "," + Name.Substring(10));
                                    File.Copy(multipleImage[i].Split(',')[0], pathString + dtFetchImageFiles.Rows[i]["FileName"].ToString(), true);

                                    if (multipleImage[i].Split(',')[0].EndsWith(".pdf") == true || multipleImage[i].Split(',')[0].EndsWith(".PDF") == true)
                                    {
                                        imageUploadUserControl1.Hide();

                                       
                                        //axUploadPatternPDF.Show();
                                        //axUploadPatternPDF.LoadFile(multipleImage[i].Split(',')[0]);
                                        //lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].LastIndexOf("\\") + 1);
                                        //axUploadPatternPDF.Refresh();
                                    }
                                    else
                                    {
                                        imageUploadUserControl1.Show();
                                         imageUploadUserControl1.AddImageRange(multipleImage[i]);
                                        //axUploadPatternPDF.Hide();

                                        //lblPatternImageName.Text = multipleImage[i].Split(',')[0].Substring(multipleImage[i].Split(',')[0].LastIndexOf("\\") + 1);
                                        imageUploadUserControl1.Image = Bitmap.FromFile(multipleImage[i].Split(',')[0]);
                                        imageUploadUserControl1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    }
                                }
                            }


                            //if (multipleImage.Count() >= 1)
                            //{
                            //    btnDeletePatternImage.Visible = true;
                            //}

                            //int count = 0;
                            //count = multipleImage.Count();
                            //if (count >= 2)
                            //{
                            //    btnPatternPrev.Visible = true;
                            //}
                            //if (Fileuploadpos == (count - 1))
                            //{
                            //    brnPatternNext.Visible = false;
                            //}

                            //CountImages.Text = multipleImage.Count.ToString();
                        }
                    }
                }
                catch
                { }
            }

            #endregion

        }
        private void BtnShow_Click_1(object sender, EventArgs e)
        {
            DuesTicket obj = new DuesTicket(User_ID, User_Type);
            obj.Show();
            this.Hide();
        }

        

        private void FileAttach_Click(object sender, EventArgs e)
        {
            //string path;
            //openFileDialog1.Filter = "PDF Files | *.pdf";
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if (openFileDialog1.FileName.Length > 0)
            //    {
            //        path = openFileDialog1.FileName;
            //    }
            //}

            //// Read the file and convert it to Byte Array
            //string filePath = path;
            //string contenttype = String.Empty;

            //contenttype = "UploadedFiles";

            //if (contenttype != String.Empty)
            //{
            //    Stream fs = File.OpenRead(filePath);
            //    BinaryReader br = new BinaryReader(fs);
            //    bytes = br.ReadBytes((Int32)fs.Length);
            //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NewTicket_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnEllipsisrep_Click(object sender, EventArgs e)
        {
            ReportedBy obj = new ReportedBy();
            obj.ShowDialog();
           
            bindReprasentative();
          
        }

        private void addmodule_Click(object sender, EventArgs e)
        {
            
            Add_Module obj = new Add_Module();
            obj.ShowDialog();

            bindModule();
        }

        private void addform_Click(object sender, EventArgs e)
        {
            Add_Form obj = new Add_Form();
            obj.ShowDialog();

            bindForm();
        }

        private void version_Click(object sender, EventArgs e)
        {
            Add_Version obj = new Add_Version();
            obj.ShowDialog();

            bindVersion();
        }

        private void btnCloseMaster_Click(object sender, EventArgs e)
        {
            
        }
        public int TicketType = 0;

        private void rdbBug_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rdbBug.Checked)
            {
                rdbBug.Checked = true;
                RdbNewReq.Checked = false;
                training.Checked = false;
                TicketType = 0;
            }
            
        }

        private void RdbNewReq_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbNewReq.Checked)
            {
                RdbNewReq.Checked = true;
                rdbBug.Checked = false;
                training.Checked = false;
                TicketType = 1;
            }
        }

        private void training_CheckedChanged(object sender, EventArgs e)
        {
            if (training.Checked)
            {
                training.Checked = true;
                RdbNewReq.Checked = false;
                rdbBug.Checked = false;
                TicketType = 2;
            }
        }

       
    }
}
