using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.App_Data;
using TestingSystems.Helpers;

namespace TestingSystems
{
    public partial class AddSkillForm : Form
    {
        public Int32 FullScreenOff = 0;
        public byte[] ProfilePic;
        public Guid SkillId;
        public int UserId;
        public AddSkillForm(string _UserID)
        {
            InitializeComponent();
            BindEvent();
            BindCource();
            lblApproval.Visible = false;
            chkApproval.Visible = false;
            cmbEvent.Enabled = true;
            cmbCourse.Enabled = true;
            txtOrganization.ReadOnly = false;
            btnLogo.Enabled = true;
            SkillId = Guid.Empty;
            UserId = Convert.ToInt32(_UserID);
            btn_Submit.Text = "Submit";
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);
        }

        public AddSkillForm(Guid _SkillId)
        {
            InitializeComponent();
            btn_Submit.Text = "Update";
            BindEvent();
            BindCource();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(groupBox1);

            clsSkillSet obj = new clsSkillSet();
            obj.SkillId = _SkillId;
            DataTable dt = obj.GetSkillDetailsFromId();

            SkillId = (Guid)dt.Rows[0]["SkillId"];
            lblApproval.Visible = true;
            chkApproval.Visible = true;
            cmbEvent.Enabled = false;
            cmbCourse.Enabled = false;
            txtOrganization.ReadOnly = true;
            btnLogo.Enabled = false;
            cmbEvent.SelectedIndex = CmbIdxFindByValue(dt.Rows[0]["eventname"].ToString(), cmbEvent);
            cmbCourse.SelectedIndex = CmbIdxFindByValue(dt.Rows[0]["course"].ToString(), cmbCourse);
            txtOrganization.Text = dt.Rows[0]["organization"].ToString();

            ProfilePic = dt.Rows[0]["img"] as byte[];
            MemoryStream ms = new MemoryStream(ProfilePic);
            ImgProfilePic.Image = Image.FromStream(ms);


            int _approval = Convert.ToInt32(dt.Rows[0]["approval"]);
            if (_approval == 1)
            {
                chkApproval.Checked = true;
            }
            else
            {
                chkApproval.Checked = false;
            }
        }

        private int CmbIdxFindByValue(string text, ComboBox cmbCd) 
        {
            int c = 0;
            if (cmbCd.Name == cmbEvent.Name)
            {
                List<clsSkillSet.SkillEvent> dtx = (List<clsSkillSet.SkillEvent>)cmbCd.DataSource;
                if (dtx != null)
                {
                    for (int i = 0; i < dtx.Count(); i++)
                    {
                        if (dtx[i].Name == text)
                        {
                            c = i;
                        }
                    }
                    return c;

                }
                else
                {
                    return c;
                }
            }
            else
            {
                List<clsSkillSet.SkillCource> dtx = (List<clsSkillSet.SkillCource>)cmbCd.DataSource;

                if (dtx != null)
                {
                    for (int i = 0; i < dtx.Count(); i++)
                    {
                        if (dtx[i].Name == text)
                        {
                            c = i;
                        }
                    }
                    return c;

                }
                else
                {
                    return c;
                }
            }
        }

        void BindEvent()
        {
            List<clsSkillSet.SkillEvent> ListEvent = new List<clsSkillSet.SkillEvent>();
            clsSkillSet.SkillEvent obj = new clsSkillSet.SkillEvent();
            obj.Name = "Select";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "International";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "National";
            ListEvent.Add(obj);

            obj = new clsSkillSet.SkillEvent();
            obj.Name = "Local";
            ListEvent.Add(obj);

            cmbEvent.DataSource = ListEvent;
            cmbEvent.DisplayMember = "Name";
            cmbEvent.ValueMember = "Name";
        }
        void BindCource()
        {
            List<clsSkillSet.SkillCource> ListCource = new List<clsSkillSet.SkillCource>();
            clsSkillSet.SkillCource obj = new clsSkillSet.SkillCource();
            obj.Name = "Select";
            ListCource.Add(obj);

            obj = new clsSkillSet.SkillCource();
            obj.Name = "Technical";
            ListCource.Add(obj);

            obj = new clsSkillSet.SkillCource();
            obj.Name = "Nontechnical";
            ListCource.Add(obj);

            cmbCourse.DataSource = ListCource;
            cmbCourse.DisplayMember = "Name";
            cmbCourse.ValueMember = "Name";
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            clsSkillSet obj = new clsSkillSet();
            obj.userid = 6;
            if (cmbEvent.SelectedIndex > 0)
            {
                obj.eventname = Convert.ToString(cmbEvent.SelectedValue);
            }
            else
            {
                const string type = "Select Event";
                System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                return;
            }

            if (cmbCourse.SelectedIndex > 0)
            {
                obj.course = Convert.ToString(cmbCourse.SelectedValue);
            }
            else
            {
                const string type = "Select Course";
                System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                return;
            }

            if (txtOrganization.Text != "")
            {
                obj.organization = txtOrganization.Text;
            }
            else
            {
                const string type = "Enter Organization Name";
                System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                return;
            }

            if (txtLogo.Text.Trim() != "")
            {
                byte[] a = ImageToByte(txtLogo.Text);
                if (a != null)
                    obj.ProfilePic = a;
                else
                    return;
            }

            if (chkApproval.Checked == true)
            {
                obj.approval = 1;
            }
            else
            {
                obj.approval = 0;
            }

            int result = 0;
            if (SkillId == Guid.Empty)
            {
                result = obj.Insert_SkillSet_Details();
            }
            else
            {
                obj.SkillId = SkillId;
                result = obj.Update_SkillSet_Details();
            }

            if (result > 0)
            {
                if (SkillId == Guid.Empty)
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Application.OpenForms.OfType<SkillsetDetails>().Count() == 1)
                        Application.OpenForms.OfType<SkillsetDetails>().First().Close();
                    SkillsetDetails obj1 = new SkillsetDetails();
                    obj1.FullScreenOff = 0;
                    obj1.MdiParent = this.ParentForm;
                    obj1.Show();
                    obj1.Focus();

                }
                
                if (FullScreenOff == 1)
                {
                    this.Close();
                }
                Clear();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Clear()
        {
            BindEvent();
            BindCource();
            txtOrganization.Text = string.Empty;
            txtLogo.Text = string.Empty;
            ImgProfilePic.Image = null;
        }


        private void btnLogo_Click(object sender, EventArgs e)
        {
            FileDialogLogo.Filter = "JEPG files (*.jpg)|*.jpg|JPG files (*.jpeg)|*.jpeg|PNG files (*.png)|*.png|BitMap files (*.bmp)|*.bmp|All files (*.bmp)|*.*";
            FileDialogLogo.ShowDialog();
        }

        private void FileDialogLogo_FileOk(object sender, CancelEventArgs e)
        {
            txtLogo.Text = FileDialogLogo.FileName.ToString();

            String Extension = System.IO.Path.GetExtension(txtLogo.Text).ToLower();

            if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".bmp")
            {
                byte[] barrImg = ImageToByte(txtLogo.Text);
                SetProfilePic(barrImg, txtLogo.Text);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select image file.");

                FileDialogLogo.FileName = "";
                txtLogo.Text = "";
            }
        }
      

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != ' '))
                e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
                e.Handled = true;
        }

        public static byte[] ImageToByte(string LogoName)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.FileName = LogoName;

            String ext = Path.GetExtension(f.FileName);
            if (ext == ".jpeg" || ext == ".jpg" || ext == ".png")
            {
                PictureBox p = new PictureBox();
                p.Image = Image.FromFile(f.FileName);

                LogoName = f.SafeFileName.ToString();
                if (p.Image != null)
                {
                    MemoryStream ms = new MemoryStream();

                    p.Refresh();
                    p.Image.Save(ms, p.Image.RawFormat);

                    byte[] a = ms.GetBuffer();
                    ms.Close();

                    LogoName = string.Empty;
                    p.Image = null;

                    return a;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Invalid File. Please upload jpg, jpeg, png File.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Invalid File. Please upload jpg, jpeg, png File.", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public void SetProfilePic(byte[] barrImg, string ImagePath)
        {
            if (ImagePath.IsNullOrEmpty())
            {
                DownloadProfileFromDB(barrImg);

                if (System.IO.File.Exists(PathHelper.GetUserProfileImagePath()))
                    ImgProfilePic.Image = Image.FromFile(PathHelper.GetUserProfileImagePath());
            }
            else
                ImgProfilePic.Image = Image.FromFile(ImagePath);
        }

        public static void DownloadProfileFromDB(byte[] barrImg)
        {
            if (barrImg != null)
            {
                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs = new FileStream(Helpers.PathHelper.GetUserProfileImagePath(), FileMode.Create, FileAccess.Write);
                fs.Write(barrImg, 0, barrImg.Length);
                fs.Flush();
                fs.Close();
            }
        }

        private void AddSkillForm_Load(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
        }


    }
}
