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

namespace TestingSystems.HR
{
    public partial class EmployeeMaster : Form
    {
        public int Employee_Id;
        public Int32 FullScreenOff = 0;
        public byte[] ProfilePic;
        public int UserId = 0;

        public EmployeeMaster()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(this.grpboxEmployeeMaster);
            dtpLeavingDate.MinDate = new DateTime(1985, 6, 20);
            dtpLeavingDate.MaxDate = DateTime.Today;
            BindUserName();

        }

        public EmployeeMaster(int EmployeeId)
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;
            AutoFitForm.SetGroupBoxLoction(this.grpboxEmployeeMaster);
            btnRegister.Visible = false;
            dtpLeavingDate.MinDate = new DateTime(1985, 6, 20);
            dtpLeavingDate.MaxDate = DateTime.Today;
            BindUserName();
            Employee_Id = EmployeeId;
            DataTable dtObj = new DataTable();
            clsEmployeeDetails ced = new clsEmployeeDetails();
            ced.EmployeeId = EmployeeId;
            dtObj = ced.GetUserIdbyEmployeeId();

            if (dtObj != null)
            {
                try
                {
                    int UserId = Convert.ToInt32(dtObj.Rows[0][0]);
                    if (UserId > 0)
                    {
                        int index = cmbUsername.Items.IndexOf(UserId.ToString());
                        cmbUsername.SelectedIndex = CmbIdxFindByValue(Convert.ToString(UserId), cmbUsername);
                    }
                    else
                    {
                        cmbUsername.SelectedIndex = 0;
                    }
                }
                catch { }
            }

            BindUpdatingValue(Employee_Id);
        }

        private int CmbIdxFindByValue(string text, ComboBox cmbCd)
        {
            int c = 0; ;
            DataTable dtx = (DataTable)cmbCd.DataSource;
            if (dtx != null)
            {
                foreach (DataRow dx in dtx.Rows)
                {
                    if (dx[cmbCd.ValueMember.ToString()].ToString() == text)
                        return c;
                    c++;
                }
                return -1;
            }
            else
                return -1;
        }

        private void EmployeeMaster_Load(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeCode.Focus();
                lblIsDummy.Visible = false;
                chkIsDummy.Visible = false;
                ((DateTimePicker)dtpLeavingDate).CustomFormat = " ";
                ((DateTimePicker)dtpLeavingDate).Format = DateTimePickerFormat.Custom;


            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BindUpdatingValue(int EmpId)
        {
            dtCheckedRecord = new DataTable();
            clsEmployeeDetails objEmployeeDetails = new clsEmployeeDetails();
            objEmployeeDetails.EmployeeId = EmpId;
            btnSave.Text = "Update";
            DataTable dt = new DataTable();
            objEmployeeDetails.IsDummy = 2;
            dt = objEmployeeDetails.FetchEmployee_Record();
            txtEmployeeCode.Text = dt.Rows[0]["EmployeeCode"].ToString();
            txtFirstName.Text = dt.Rows[0]["EmployeeName"].ToString();
            txtMiddleName.Text = dt.Rows[0]["MiddleName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtOtherName.Text = dt.Rows[0]["OtherName"].ToString();
            dtpDateofBirth.Text = dt.Rows[0]["DOB"].ToString();
            dtpJoinedDate.Text = dt.Rows[0]["JoiningDate"].ToString();
            txtTotalc2c.Text = dt.Rows[0]["Salary"].ToString();
            txtEmailID.Text = dt.Rows[0]["EmailId"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            if (dt.Rows[0]["ProfilePic"] != null && Convert.ToString(dt.Rows[0]["ProfilePic"]) != "")
            {
                try
                {
                    ProfilePic = dt.Rows[0]["ProfilePic"] as byte[];
                    MemoryStream ms = new MemoryStream(ProfilePic);
                    ImgProfilePic.Image = Image.FromStream(ms);
                }
                catch { }
            }

            if (dt.Rows[0]["IsDummy"].ToString() == "1")
                chkIsDummy.Checked = true;
            else
                chkIsDummy.Checked = false;

            if (dt.Rows[0]["isActive"].ToString() == "InActive")
                rbtnInactive.Checked = true;
            else
                rbtnActive.Checked = true;

            if (dt.Rows[0]["Gender"].ToString() == "Male")
                rbtnMale.Checked = true;
            else if (dt.Rows[0]["Gender"].ToString() == "Female")
                rbtnFemale.Checked = true;
            else if (dt.Rows[0]["Gender"].ToString() == "Other")
                rbtnOther.Checked = true;

            if (dt.Rows[0]["EmployeeType"].ToString() == "Company Payroll")
                rbtnCompanyPayroll.Checked = true;
            else if (dt.Rows[0]["EmployeeType"].ToString() == "Contractor")
                rbtnContractor.Checked = true;
            else if (dt.Rows[0]["EmployeeType"].ToString() == "Employee of Contractor")
                rbtnEmployeeofContractor.Checked = true;

            if (dt.Rows[0]["LeavingDate"].ToString() != "")
            {
                dtpLeavingDate.Enabled = true;
                dtpLeavingDate.CustomFormat = "dd MMM yyyy ";
                dtpLeavingDate.Text = dt.Rows[0]["LeavingDate"].ToString();
            }
        }

        void BindUserName()
        {

            clsEmployeeDetails obj = new clsEmployeeDetails();
            DataTable dt = obj.BindUserName();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserName"] = "Select";

                    dt.Rows.InsertAt(dr, 0);
                    cmbUsername.ValueMember = "ID";
                    cmbUsername.DisplayMember = "UserName";
                    cmbUsername.DataSource = dt;
                }

            }

        }

        #region General Functiton

        public void Clear()
        {
            try
            {
                BindUserName();
                tabCntrlEmployeeMaster.SelectedIndex = 0;
                txtEmployeeCode.Text = String.Empty;
                txtFirstName.Text = String.Empty;
                txtMiddleName.Text = String.Empty;
                txtLastName.Text = String.Empty;
                txtOtherName.Text = String.Empty;
                txtTotalc2c.Text = String.Empty;
                txtEmailID.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtLogo.Text = string.Empty;
                ImgProfilePic.Image = null;
                rbtnMale.Checked = true;
                dtpDateofBirth.Value = DateTime.Now;
                chkIsDummy.Checked = false;
                rbtnActive.Checked = true;
                rbtnCompanyPayroll.Checked = true;
                dtpJoinedDate.Value = DateTime.Now;
                txtEmployeeCode.Focus();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsername.SelectedIndex > 0)
                {
                    UserId = Convert.ToInt32(cmbUsername.SelectedValue);
                }
                else
                {
                    const string type = "select User Name";
                    System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                    return;
                }
                clsEmployeeDetails employeeDetails = new clsEmployeeDetails();

                if (txtEmployeeCode.Text == null || txtEmployeeCode.Text == String.Empty)
                {
                    const string type = "Enter Employee Code";
                    System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                    txtEmployeeCode.Focus();
                    return;
                }

                if (txtFirstName.Text == null || txtFirstName.Text == String.Empty)
                {
                    const string type = "Enter Employee Name";
                    System.Windows.Forms.MessageBox.Show(type, "Require", MessageBoxButtons.OK);
                    txtFirstName.Focus();
                    return;
                }


                if (txtMiddleName.Text == null || txtMiddleName.Text == String.Empty)
                {
                    const string type = "Enter Middle Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtMiddleName.Focus();
                    return;

                }

                if (txtLastName.Text == null || txtLastName.Text == string.Empty)
                {
                    const string type = "Enter Last Name";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    txtLastName.Focus();
                    return;
                }


                if (txtEmailID.Text.Trim() != "")
                {
                    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                    if (!rEMail.IsMatch(txtEmailID.Text.Trim()))
                    {
                        const string type = "Please enter valid Email ID";
                        System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                        txtEmailID.Focus();
                        return;
                    }
                }

                employeeDetails.EmailID = txtEmailID.Text.Trim();
                employeeDetails.MobileNo = txtMobileNo.Text.Trim();

                if (txtLogo.Text.Trim() != "")
                {
                    byte[] a = ImageToByte(txtLogo.Text);
                    if (a != null)
                        employeeDetails.ProfilePic = a;
                    else
                        return;
                }
                else if (Convert.ToString(btnSave.Text).ToLower() == "update" && ProfilePic != null && ProfilePic.Length > 0)
                {
                    employeeDetails.ProfilePic = ProfilePic;
                }

                employeeDetails.UserId = UserId;
                employeeDetails.EmployeeCode = txtEmployeeCode.Text;
                employeeDetails.EmployeeName = txtFirstName.Text;
                employeeDetails.MiddleName = txtMiddleName.Text;
                employeeDetails.LastName = txtLastName.Text;
                employeeDetails.OtherName = txtOtherName.Text;
                employeeDetails.dtCheckedRecord = dtCheckedRecord;

                if (rbtnMale.Checked)
                    employeeDetails.Gender = 0;
                else if (rbtnFemale.Checked)
                    employeeDetails.Gender = 1;
                else if (rbtnOther.Checked)
                    employeeDetails.Gender = 2;

                employeeDetails.DOB = dtpDateofBirth.Value;

                if (chkIsDummy.Checked)
                    employeeDetails.IsDummy = 1;
                else
                    employeeDetails.IsDummy = 0;


                if (rbtnActive.Checked)
                    employeeDetails.isActive = true;
                else
                    employeeDetails.isActive = false;

                if (rbtnCompanyPayroll.Checked)
                    employeeDetails.EmployeeType = 1;
                else if (rbtnContractor.Checked)
                    employeeDetails.EmployeeType = 2;
                else if (rbtnEmployeeofContractor.Checked)
                    employeeDetails.EmployeeType = 3;

                if (txtTotalc2c.Text != null && txtTotalc2c.Text != String.Empty)
                    employeeDetails.Salary = Convert.ToDecimal(txtTotalc2c.Text);

                String dtpLeaving = dtpLeavingDate.Text;
                dtpLeaving = dtpLeaving.Trim();
                if (dtpLeaving != "")
                {
                    employeeDetails.LeavingDate = dtpLeavingDate.Value;
                    employeeDetails.isLdate = true;
                }
                else
                {
                    employeeDetails.isLdate = false;
                }

                employeeDetails.JoiningDate = dtpJoinedDate.Value;

                int result = 0;
                if (btnSave.Text == Helper.ButtonCaptions.Save)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        result = employeeDetails.Insert_Employee_Details();


                        if (result > 0)
                        {
                            DataTable dt = new DataTable();
                            dt = employeeDetails.GetEmployeeIdByEmpCode();
                            if (dt != null)
                            {
                                try
                                {
                                    int EmpId = Convert.ToInt32(dt.Rows[0][0]);
                                    if (EmpId > 0)
                                    {
                                        employeeDetails.EmployeeId = EmpId;
                                        result = employeeDetails.UpdateUserInfoEmployeeId();
                                    }
                                }
                                catch { }
                            }
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
                else if (btnSave.Text == Helper.ButtonCaptions.Update)
                {
                    if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        employeeDetails.EmployeeId = Employee_Id;
                        result = employeeDetails.UpdateEmployeeDetails(true);
                    }
                    if (result == 1)
                    {
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (FullScreenOff == 1)
                        {
                            if (Application.OpenForms.OfType<EmployeeDetails>().Count() == 1)
                                Application.OpenForms.OfType<EmployeeDetails>().First().Close();
                            EmployeeDetails obj = new EmployeeDetails();
                            obj.FullScreenOff = 0;
                            obj.MdiParent = this.ParentForm;
                            obj.Show();
                            obj.Focus();
                        }
                        Clear();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Data Not Updated", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnSave.Text = "Save";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabCntrlEmployeeMaster.SelectedIndex = (tabCntrlEmployeeMaster.TabPages.Count - 1 == tabCntrlEmployeeMaster.SelectedIndex) ? 0 : tabCntrlEmployeeMaster.SelectedIndex + 1;
        }

        #endregion

        private void txtEmployeeCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeCode.Text != string.Empty)
                {
                    clsEmployeeDetails employee = new clsEmployeeDetails();
                    employee.EmployeeCode = txtEmployeeCode.Text;
                    bool Exist = employee.CheckEmpCOdeExist();
                    if (Exist)
                    {
                        MessageBox.Show("Employee code already exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmployeeCode.Text = string.Empty;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTotalc2c_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.AllowFloatOnly();
        }

        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(btnSave, null);
            }

            //if (keyData == (Keys.Control | Keys.R))
            //{
            //    btnRegister_Click(btnRegister, null);
            //}

            if (keyData == (Keys.F5))
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Clear();
                    return true;
                }

            }

            if (keyData == (Keys.Control | Keys.Alt | Keys.H))
            {
                chkIsDummy.Visible = true;

                lblIsDummy.Visible = true;
                txtEmployeeCode.Focus();
            }

            if (keyData == (Keys.Escape))
            {
                if (FullScreenOff == 1)
                {
                    this.Close();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        #endregion

        private void dtpLeavingDate_ValueChanged(object sender, EventArgs e)
        {
            dtpLeavingDate.CustomFormat = "dd MMM yyyy ";
            rbtnInactive.Checked = true;
            rbtnActive.Checked = false;
        }

        bool IsLoadDepartment = false;
        DataTable dtCheckedRecord = new DataTable();

        #region Harshad Chauhan 12.Jan.2019
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
        #endregion

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<EmployeeDetails>().Count() == 1)
                Application.OpenForms.OfType<EmployeeDetails>().First().Close();
            EmployeeDetails obj = new EmployeeDetails();
            obj.FullScreenOff = 0;
            obj.MdiParent = this.ParentForm;
            obj.Show();
            obj.Focus();



        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsername.SelectedIndex > 0)
            {
                clsEmployeeDetails obj = new clsEmployeeDetails();
                obj.UserId = Convert.ToInt32(cmbUsername.SelectedValue);
                //if (Employee_Id > 0)
                //{
                DataTable dt = obj.GetEmployeeIdByUserId();
                if (dt != null)
                {
                    try
                    {
                        int EmpId = Convert.ToInt32(dt.Rows[0][0]);
                        if (EmpId > 0)
                        {
                            Employee_Id = EmpId;
                            BindUpdatingValue(EmpId);
                        }
                        else
                        {
                            try
                            {
                                tabCntrlEmployeeMaster.SelectedIndex = 0;
                                txtEmployeeCode.Text = String.Empty;
                                txtFirstName.Text = String.Empty;
                                txtMiddleName.Text = String.Empty;
                                txtLastName.Text = String.Empty;
                                txtOtherName.Text = String.Empty;
                                txtTotalc2c.Text = String.Empty;
                                txtEmailID.Text = string.Empty;
                                txtMobileNo.Text = string.Empty;
                                txtLogo.Text = string.Empty;
                                ImgProfilePic.Image = null;
                                rbtnMale.Checked = true;
                                dtpDateofBirth.Value = DateTime.Now;
                                chkIsDummy.Checked = false;
                                rbtnActive.Checked = true;
                                rbtnCompanyPayroll.Checked = true;
                                dtpJoinedDate.Value = DateTime.Now;
                                txtEmployeeCode.Focus();
                                btnSave.Text = "Save";
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandler.LogException(ex);
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch
                    {

                        try
                        {
                            tabCntrlEmployeeMaster.SelectedIndex = 0;
                            txtEmployeeCode.Text = String.Empty;
                            txtFirstName.Text = String.Empty;
                            txtMiddleName.Text = String.Empty;
                            txtLastName.Text = String.Empty;
                            txtOtherName.Text = String.Empty;
                            txtTotalc2c.Text = String.Empty;
                            txtEmailID.Text = string.Empty;
                            txtMobileNo.Text = string.Empty;
                            txtLogo.Text = string.Empty;
                            ImgProfilePic.Image = null;
                            rbtnMale.Checked = true;
                            dtpDateofBirth.Value = DateTime.Now;
                            chkIsDummy.Checked = false;
                            rbtnActive.Checked = true;
                            rbtnCompanyPayroll.Checked = true;
                            dtpJoinedDate.Value = DateTime.Now;
                            txtEmployeeCode.Focus();
                            btnSave.Text = "Save";
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.LogException(ex);
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

            }
            //}

        }

        private void EmployeeMaster_Load_1(object sender, EventArgs e)
        {
            AutoFitForm.SetFormToMaximize(this);
        }
    }
}
