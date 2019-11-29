using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestingSystems.Helpers;
using TestingSystems.App_Data;
using TestingSystems;

namespace TestingSystems
{
    public partial class StateCitypopup : Form
    {
        CustomerMaster _Owner;
       // SupplierMaster _Sowner;
        //CompanyMaster _Cowner;
        public Int32 FullScreenOff = 1;
        public StateCitypopup(CustomerMaster Owner)
        {
            InitializeComponent();
            _Owner = Owner;
            FillCountry();
            FillStateComBobox();
            if (FullScreenOff == 1)
                button1.Visible = false;
        }

        //public StateCitypopup(SupplierMaster Owner)
        //{
        //    InitializeComponent();
        //    _Sowner = Owner;
        //    FillCountry();
        //    FillStateComBobox();
        //    if (FullScreenOff == 1)
        //        button1.Visible = false;
        //}

        //public StateCitypopup(CompanyMaster Owner)
        //{
        //    InitializeComponent();
        //    _Cowner = Owner;
        //    FillCountry();
        //    FillStateComBobox();
        //    if (FullScreenOff == 1)
        //        button1.Visible = false;
        //}


        private void StateCitypopup_Load(object sender, EventArgs e)
        {

        }

        private void FillCountry()
        {
            clsCityState cityState = new clsCityState();
            DataTable dt = cityState.FetchCountry();
            dt.AddSelectRow(1, 2);
            cmbCityCountry.DataSource = dt;
            cmbStateCountry.DataSource = dt.Copy();
        }

        private void FillStateComBobox()
        {
            clsCityState cityState = new clsCityState();
            if (cmbCityCountry.SelectedIndex > 0)
            {
                cityState.CountryId = Convert.ToInt32(cmbCityCountry.SelectedValue);
            }
            DataTable dtstate = cityState.FetchState();
            dtstate.AddSelectRow(1, 2);
            cmbCityState.DataSource = dtstate;
        }
        private void btnCitySave_Click(object sender, EventArgs e)
        {
            try
            {
                clsCityState citystate = new clsCityState();
                ValidationHelper.RequiredFieldValidation(txtCity, epRequiredField);
                ValidationHelper.RequiredFieldValidation(cmbCityState, epRequiredField);
                int result = 0;
                if (txtCity.Text != "" && cmbCityState.SelectedIndex > 0)
                {
                    citystate.StateId = Convert.ToInt32(cmbCityState.SelectedValue);//To add State Dependancy and code centralization
                    citystate.City = txtCity.Text.Trim();

                    if (!citystate.CheckDuplicateCity())
                    {
                        result = citystate.InsertIntoCity();
                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show(TestingSystems.Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtCity.Text = string.Empty;
                            txtStateCode.Text = string.Empty;
                            this.Close();

                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(TestingSystems.Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("City Already Exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Mandatory, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void StateCitypopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Owner != null)
            {
                _Owner.PerformRefresh();
            }
            //else if (_Sowner != null)
            //{
            //    _Sowner.PerformRefresh();
            //}
            //else
            //{
            //    _Cowner.PerformRefresh();
            //}

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbCityCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillStateComBobox();//On Selecting Country, state Combobox must me filtered code is written

        }

        private void cmbCityState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCityState.SelectedIndex > 0)
            {
                clsCityState citystate = new clsCityState();
                citystate.StateId = Convert.ToInt32(cmbCityState.SelectedValue);
                DataTable dt = citystate.FetchStateByStateId();
                cmbCityCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsCityState citystate = new clsCityState();
                // ValidationHelper.RequiredFieldValidation(cmbState, epRequiredField);
                // ValidationHelper.RequiredFieldValidation(cmbCountry, epRequiredField);
                ValidationHelper.RequiredFieldValidation(txtcountry, epRequiredField);


                ValidationHelper.RequiredFieldValidation(txtcountry, epRequiredField);
                int result = 0;
                if (txtcountry.Text != "")
                {

                    citystate.CountryName = txtcountry.Text.Trim();
                    if (!citystate.CheckDuplicateCountry())
                    {
                        citystate.CountryName = txtcountry.Text.Trim();
                        result = citystate.InsertIntoCountry();
                        if (result == 1)
                        {
                            System.Windows.Forms.MessageBox.Show("Data Added successfully", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillCountry();
                            txtcountry.Text = "";

                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Data Not Added ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Country Already Exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CLEAR()
        {
            btncountrySave.Text = Helper.ButtonCaptions.Save;
            foreach (Control txt in tabCountry.Controls)
            {
                if (txt is TextBox)
                {
                    txt.Text = "";
                }
                FillCountry();
                //cmbState.Text = Helper.DropdownDefaultText.Select;
                ////   cmbState.Focus();
                //cmbCountry.Text = Helper.DropdownDefaultText.Select;
                //cmbCountry.Focus();

                //lnkbtnAddNewType.Visible = true;

                //lnkbtnAddNewCountry.Visible = true;
                //cmbState.Enabled = true;
                //cmbCountry.Enabled = true;
                //txtState.Visible = false;
                //txtCountry.Visible = false;
            }
        }

        private void btnstateSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsCityState citystate = new clsCityState();
                ValidationHelper.RequiredFieldValidation(txtstate, epRequiredField);
                ValidationHelper.RequiredFieldValidation(cmbStateCountry, epRequiredField);
                ValidationHelper.RequiredFieldValidation(cmbStateCountry, epRequiredField);
                int result = 0;
                if (txtstate.Text != string.Empty && cmbStateCountry.SelectedValue != null && cmbStateCountry.SelectedValue.ToString() != string.Empty && cmbStateCountry.SelectedValue.ToString() != "0")
                {
                    citystate.CountryId = Convert.ToInt32(cmbStateCountry.SelectedValue);//To add Country Dependancy and code centralization
                    citystate.State = txtstate.Text.Trim();
                    citystate.State_Code = Convert.ToInt32(txtStateCode.Text);

                    if (!citystate.CheckDuplicateState())
                    {
                        result = citystate.InsertIntoState();
                        if (result == 1)
                        {
                            FillStateComBobox();
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtstate.Text = "";
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("State Already Exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Mandatory, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnstateCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbStateCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                if (FullScreenOff == 1)

                    this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
