
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;

namespace Inventory_Management
{
    public partial class MetalMaster : Form
    {
        //private Int32 isTCEnable;
        public Int32 FullScreenOff = 0;
        //GlobleFunctionsHelper gh = new GlobleFunctionsHelper();
        DataTable dtAllElement = new DataTable();
        DataTable dtAllElementMicrostruture = new DataTable();

        public MetalMaster()
        {
            InitializeComponent();
            FullScreenOff = clsValues.Instance.FullScreenOff;

            if (FullScreenOff != 1)
                AutoFitForm.SetGroupBoxLoction(this.groupBox1);


            if (FullScreenOff == 1)
            {
                // btnClose.Visible = false;
            }
        }
        private void BindMetalType()
        {
            clsCastingMaster castingmaster = new clsCastingMaster();
            DataTable dt = castingmaster.SelectDistinctMetalType();
            dt.AddSelectRowName(0, 0);
            cmbMetalType.DataSource = dt;
        }

        private void BindSearchMetal()
        {
            try
            {
                clsCastingMaster castingmaster = new clsCastingMaster();
                DataTable dt = castingmaster.Fetch_MetalMaster_ALl();
                dt.AddSelectRowName(0, 1);
                cmbSearchMetal.DataSource = dt;
                cmbSearchMetal.ValueMember = "MetalId";
                cmbSearchMetal.DisplayMember = "MetalName";
            }
            catch
            { }
        }

        Int32 MetalID = 0;
        Int32 OLDMetalID = 0;

        clsAccessMenu access_menu = new clsAccessMenu();

        private void txtMetalName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMetalName.Text != "")
                {
                    clsCastingMaster castingmaster = new clsCastingMaster();

                    castingmaster.Metal = txtMetalName.Text;
                    if (btnSave.Text == Helper.ButtonCaptions.Update)
                    {
                        castingmaster.Metal_Id = MetalID;
                    }
                    DataTable dt = castingmaster.FetchMetalnameDuplicateCheck();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (btnSave.Enabled == true)
                        {
                            System.Windows.Forms.MessageBox.Show("Already Exist");
                            txtMetalName.Clear();
                            txtMetalName.Focus();
                        }
                    }
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("Enter Metal Name");
                    //return;
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region Shortcut Keys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                if (txtItemType.Focused == true)
                {
                    cmbMetalType.Enabled = true;
                    txtItemType.Visible = false;
                    lblItemTypeRequired.Visible = false;
                    btnAddMetalGrp.Visible = true;
                    txtItemType.Clear();
                }

                if (txtItemType.Text == "")
                {
                    btnAddMetalGrp.Visible = true;
                    cmbMetalType.Enabled = true;
                }


                if (FullScreenOff == 1)

                    this.Close();
            }


            if (keyData == (Keys.Control | Keys.S))
            {
                btnSave_Click(btnSave, null);
            }

            if (keyData == (Keys.F5))
            {
                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLEAR();
                    txtMetalName.Focus();
                    ItemType = Guid.Empty;
                    ItemCategory = Guid.Empty;
                    ItemGroup = Guid.Empty;
                    
                    Fill_Item_Type();
                    Fill_Item_Category();
                    Fill_Item_Group();
                    Fill_Item_Code();
                    Fill_Item_Name();
                }
            }

            if (keyData == (Keys.Alt | Keys.T))
            {
                txtItemType.Visible = true;
                lblItemTypeRequired.Visible = true;
                cmbMetalType.Enabled = false;
                btnAddMetalGrp.Visible = false;

                txtItemType.Focus();

            }

            if (keyData == (Keys.Alt | Keys.N))
            {
                tabControl1.SelectedIndex = (tabControl1.TabPages.Count - 1 == tabControl1.SelectedIndex) ? 0 : tabControl1.SelectedIndex + 1;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        #endregion
        private void DataClears()
        {
            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.RefreshConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                txtMetalName.Clear();
                txtdensity.Clear();

                foreach (Control txt in grpChemical.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }
                foreach (Control txt in grpMechanical.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }
                foreach (Control txt in tabPage1.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }
                cmbMetalType.Enabled = true;
                txtItemType.Visible = false;
                lblItemTypeRequired.Visible = false;
                btnAddMetalGrp.Visible = true;
                txtItemType.Clear();
                if (cmbMetalType.Items.Count > 0)
                    cmbMetalType.SelectedIndex = 0;
                btnSave.Text = Helper.ButtonCaptions.Save;
                metal_id.Text = "";
                btnSave.Enabled = true;
                btnSaveMapping.Enabled = true;
                btnClose.Enabled = true;
                dgvMetalMaterialMapping.Enabled = true;

              
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtMetalName.Text != "" && ((cmbMetalType.Enabled || txtItemType.Text != "") && (!cmbMetalType.Enabled || cmbMetalType.SelectedIndex > 0)))
            //{

            if (txtMetalName.Text == string.Empty)
            {
                const string type = "Enter Metal Name";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                txtMetalName.Focus();                   
                return;
            }

            if (cmbMetalType.Enabled == true)
            {
                if (cmbMetalType.SelectedValue == null || cmbMetalType.Text == Helper.DropdownDefaultText.Select)
                {
                    const string type = "Select Metal Type";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    cmbMetalType.Focus();                       
                    return;
                }
            }
            else
            {
                if (txtItemType.Text == string.Empty)
                {
                    const string type = "Enter Metal Type";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    txtItemType.Focus();                       
                    return;
                }
            }

            IsMaterialMappingFlag = false;
            if (IsMaterialMappingFlag)
            {
                if (dgvMetalMaterialMapping.Rows.Count <= 0 )
                {
                    const string type = "Please enter Metal Material Mapping Items";
                    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabControl1.TabPages["MetalMapping"];
                    cmbItemGroup.Focus();                   
                    return;
                }
            }

            //bool CheckForEnterMinMax = GlobleFunctionsHelper.GetCheckForElementHave(dtChecmicalProcess);
            //if (CheckForEnterMinMax)
            //{
            //    const string type = "Please enter Min and Max selected elements";
            //    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
            //    dgvChemicalElement.Focus();
            //    return;
            //}

            //CheckForEnterMinMax = GlobleFunctionsHelper.GetCheckForElementHave(dtMechanicalProcess);
            //if (CheckForEnterMinMax)
            //{
            //    const string type = "Please enter Min and Max selected elements";
            //    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
            //    dgvMechanicalElement.Focus();
            //    return;
            //}

            dtMicrostructureProcess = (DataTable)dgvMicrostructureElement.DataSource;
            if(dtMicrostructureProcess != null)
            dtMicrostructureProcess.AcceptChanges();
            ////CheckForEnterMinMax = GlobleFunctionsHelper.GetCheckForElementHave(dtMicrostructureProcess);
            ////if (CheckForEnterMinMax)
            ////{
            ////    const string type = "Please enter Min and Max selected elements";
            ////    System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
            ////    dgvMicrostructureElement.Focus();
            ////    return;
            ////}
           
            #region Code For Metal Properties

            DataTable dtCombineMetal = new DataTable();
            dtCombineMetal.Columns.Add("MetalElementId");
            dtCombineMetal.Columns.Add("Minimum");
            dtCombineMetal.Columns.Add("Maximum");
            dtCombineMetal.Columns.Add("Type");
            dtCombineMetal.Columns.Add("Element");
            int rowAddCmt = 0;
            bool isUpdatedGradeProperty = true;

            if (metal_id.Text != "")
            {
                if (dgvChemicalElement.DataSource != null && dtOldChemicalProcess != null)
                {                    
                    if (dgvChemicalElement.DataSource != null)
                    {
                        if (dtOldChemicalProcess != null)
                        {
                            DataTable dtChem = (DataTable)dgvChemicalElement.DataSource;
                            if(dtChem != null)
                            dtChem.AcceptChanges();
                            isUpdatedGradeProperty = GlobleFunctionsHelper.CompareDatatable(dtOldChemicalProcess, dtChem);
                        }
                    }
                }
                else if (dgvChemicalElement.DataSource == null && dtOldChemicalProcess == null)
                {
                    isUpdatedGradeProperty = true;
                }
                else
                {
                    isUpdatedGradeProperty = false;
                }
            }

            if (dtChecmicalProcess != null)
            {
                if (dtChecmicalProcess.Rows.Count > 0)
                {
                    if (dgvChemicalElement.DataSource != null)
                    {
                        for (int row = 0; row < dgvChemicalElement.Rows.Count; row++)
                        {
                            string MinVal = (((dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim());
                            string MaxVal = (((dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim());
                            double ValueMin = Convert.ToDouble(MinVal);
                            double ValueMax = Convert.ToDouble(MaxVal);

                            if (ValueMax != 0)
                            {
                                if (ValueMax < ValueMin)
                                {
                                    string Message = "Property out of range";
                                    MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                                    dgvChemicalElement.Focus();
                                    return;
                                }
                            }

                            dtCombineMetal.Rows.Add();
                            dtCombineMetal.Rows[rowAddCmt]["MetalElementId"] = dgvChemicalElement.Rows[row].Cells["ChemicalMetalElementId"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Minimum"] = dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Maximum"] = dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Type"] = dgvChemicalElement.Rows[row].Cells["ChemicalName"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Element"] = "Chemical";
                            
                            rowAddCmt++;

                        }
                    }
                }
            }


            if (metal_id.Text != "")
            {
                if (isUpdatedGradeProperty == false)
                {
                    if (dgvMechanicalElement.DataSource != null && dtOldMechanicalProcess != null)
                    {
                        if (dgvMechanicalElement.DataSource != null)
                        {
                            if (dtOldMechanicalProcess != null)
                            {
                                DataTable dtChem = (DataTable)dgvMechanicalElement.DataSource;
                                if (dtChem != null)
                                dtChem.AcceptChanges();
                                isUpdatedGradeProperty = GlobleFunctionsHelper.CompareDatatable(dtOldMechanicalProcess, dtChem);
                            }
                        }
                    }
                    else if (dgvMechanicalElement.DataSource == null && dtOldMechanicalProcess == null)
                    {
                        isUpdatedGradeProperty = true;
                    }
                    else
                    {
                        isUpdatedGradeProperty = false;
                    }
                }
            }
            
            if (dtMechanicalProcess != null)
            {
                if (dtMechanicalProcess.Rows.Count > 0)
                {
                    if (dgvMechanicalElement.DataSource != null)
                    {
                        for (int row = 0; row < dgvMechanicalElement.Rows.Count; row++)
                        {
                            string MinVal = (((dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim());
                            string MaxVal = (((dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim());
                            double ValueMin = Convert.ToDouble(MinVal);
                            double ValueMax = Convert.ToDouble(MaxVal);

                            if (ValueMax != 0)
                            {
                                if (ValueMax < ValueMin)
                                {
                                    string Message = "Property out of range";
                                    MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                                    dgvMechanicalElement.Focus();
                                    return;
                                }
                            }
                            dtCombineMetal.Rows.Add();
                            dtCombineMetal.Rows[rowAddCmt]["MetalElementId"] = dgvMechanicalElement.Rows[row].Cells["MechanicalMetalElementId"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Minimum"] = dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Maximum"] = dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Type"] = dgvMechanicalElement.Rows[row].Cells["MechanicalName"].Value.ToString();
                            dtCombineMetal.Rows[rowAddCmt]["Element"] = "Mechanical";
                            
                            rowAddCmt++;
                        }
                    }
                }
            }

            #endregion

            #region Microstructure

            bool isUpdatedGradePropertyMicro = true;
            DataTable dtCombineMetalMicro = new DataTable();
            dtCombineMetalMicro.Columns.Add("MetalElementId");
            dtCombineMetalMicro.Columns.Add("Minimum");
            dtCombineMetalMicro.Columns.Add("Maximum");
            dtCombineMetalMicro.Columns.Add("Type");
            dtCombineMetalMicro.Columns.Add("Element");
            rowAddCmt = 0;

            if (metal_id.Text != "")
            {
                if (dgvMicrostructureElement.DataSource != null && dtOldMicrostructureProcess != null)
                {
                    if (dgvMicrostructureElement.DataSource != null)
                    {
                        if (dtOldMicrostructureProcess != null)
                        {
                            DataTable dtChem = (DataTable)dgvMicrostructureElement.DataSource;
                            if (dtChem != null)
                            dtChem.AcceptChanges();
                            isUpdatedGradePropertyMicro = GlobleFunctionsHelper.CompareDatatable(dtOldMicrostructureProcess, dtChem);
                        }
                    }
                }
                else if (dgvMicrostructureElement.DataSource == null && dtOldMicrostructureProcess == null)
                {
                    isUpdatedGradePropertyMicro = true;
                }
                else
                {
                    isUpdatedGradePropertyMicro = false;
                }
            }


            if (dgvMicrostructureElement != null)
            {
                if (dgvMicrostructureElement.Rows.Count > 0)
                {
                    if (dgvMicrostructureElement.DataSource != null)
                    {
                        for (int row = 0; row < dgvMicrostructureElement.Rows.Count; row++)
                        {
                            string MinVal = (((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim());
                            string MaxVal = (((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim());
                            double ValueMin = Convert.ToDouble(MinVal);
                            double ValueMax = Convert.ToDouble(MaxVal);

                            if (ValueMax != 0)
                            {
                                if (ValueMax < ValueMin)
                                {
                                    string Message = "Property out of range";
                                    MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                                    dgvMicrostructureElement.Focus();
                                    return;
                                }
                            }

                            dtCombineMetalMicro.Rows.Add();
                            dtCombineMetalMicro.Rows[rowAddCmt]["MetalElementId"] = dgvMicrostructureElement.Rows[row].Cells["MicrostructureMetalElementId"].Value.ToString();
                            dtCombineMetalMicro.Rows[rowAddCmt]["Minimum"] = dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString();
                            dtCombineMetalMicro.Rows[rowAddCmt]["Maximum"] = dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString();
                            dtCombineMetalMicro.Rows[rowAddCmt]["Type"] = dgvMicrostructureElement.Rows[row].Cells["MicrostructureName"].Value.ToString();
                            dtCombineMetalMicro.Rows[rowAddCmt]["Element"] = "Microstructure";

                            rowAddCmt++;

                        }
                    }
                }
            }

            #endregion


            dtCombineMetal = setValueWhenMinAndMaxBlank(dtCombineMetal);

            DataTable dtGrdPrptyClm = GlobleFunctionsHelper.GetGradepropertyColumns(false,false,false);
            DataTable dtGradePropertyRecord = GlobleFunctionsHelper.SetGradePropertyRecords(dtGrdPrptyClm, dtCombineMetal, false, dtAllElement,false);

            clsMicrostructure objMicrostructure = new clsMicrostructure();
            objMicrostructure.Metal_Id = MetalID;
            objMicrostructure.IsCastingId = false;
            DataTable dtMsRecord = objMicrostructure.Fetch_Microstrucutre_Grade_Property();

            DataTable dtGrdPrptyClmMicro = (DataTable)dgvMicrostructureElement.DataSource;
            if (dtGrdPrptyClmMicro != null)
            dtGrdPrptyClmMicro.AcceptChanges();
            DataTable dtGradePropertyRecordMicrostructure = GlobleFunctionsHelper.SetGradePropertyRecordsMicrostructure_save( dtMsRecord ,dtGrdPrptyClmMicro);
            
           // return;
            var session = Session.Get();
            clsCastingMaster castingmaster = new clsCastingMaster();
            castingmaster.Metal = txtMetalName.Text;
            if(txtdensity.Text != string.Empty)
                castingmaster.Density = Convert.ToDouble(txtdensity.Text);
            else
                castingmaster.Density = 0;
            castingmaster.EntityID = session.EntityID;

            castingmaster.Created_By = session.UserId;

            castingmaster.Created_On = System.DateTime.Now;

            castingmaster.Modified_By = session.UserId;

            castingmaster.Modified_On = System.DateTime.Now;

            castingmaster.Effective_date = System.DateTime.Now;

            castingmaster.Che_Carbon_Min = txtCMin.Text.Trim();

            castingmaster.Che_Si_Min = txtSiMin.Text.Trim();
            castingmaster.Che_Mg_Min = txtMgMin.Text.Trim();
            castingmaster.Che_Mn_Min = txtMnMin.Text.Trim();
            castingmaster.Che_S_Min = txtSMin.Text.Trim();
            castingmaster.Che_P_Min = txtPMin.Text.Trim();
            castingmaster.Che_Cr_Min = txtCrMin.Text.Trim();
            castingmaster.Che_Ni_Min = txtNiMin.Text.Trim();
            castingmaster.Che_Mo_Min = txtMoMin.Text.Trim();
            castingmaster.Che_Cu_Min = txtCuMin.Text.Trim();
            castingmaster.Che_Ti_Min = txtTiMin.Text.Trim();
            castingmaster.Che_Al_Min = txtAlMin.Text.Trim();
            castingmaster.Che_B_Min = txtBMin.Text.Trim();
            castingmaster.Che_NB_Min = txtNBMin.Text.Trim();
            castingmaster.Che_V_Min = txtVMin.Text.Trim();
            //It was txtcumax
            castingmaster.Che_Carbon_Max = txtCMax.Text.Trim();
            castingmaster.Che_Si_Max = txtSiMax.Text.Trim();
            castingmaster.Che_Mg_Max = txtMgMax.Text.Trim();
            castingmaster.Che_Mn_Max = txtMnMax.Text.Trim();
            castingmaster.Che_S_Max = txtSMax.Text.Trim();
            castingmaster.Che_P_Max = txtPMax.Text.Trim();
            castingmaster.Che_Cr_Max = txtCrMax.Text.Trim();
            castingmaster.Che_Ni_Max = txtNiMax.Text.Trim();
            castingmaster.Che_Mo_Max = txtMoMax.Text.Trim();
            castingmaster.Che_Cu_Max = txtCuMax.Text.Trim();
            castingmaster.Che_Ti_Max = txtTiMax.Text.Trim();
            castingmaster.Che_Al_Max = txtAlMax.Text.Trim();
            castingmaster.Che_B_Max = txtBMax.Text.Trim();
            castingmaster.Che_NB_Max = txtNBMax.Text.Trim();
            castingmaster.Che_V_Max = txtVMax.Text.Trim();

            castingmaster.Me_Carbon_Min = txtUTSMin.Text.Trim();
            castingmaster.Me_Si_Min = txtYSMin.Text.Trim();
            castingmaster.Me_Mn_Min = txtElongationMin.Text.Trim();
            castingmaster.Me_S_Min = txthardnessMin.Text.Trim();
            castingmaster.Me_Ra_Min = txtRAMIn.Text.Trim();
            castingmaster.Me_Bend_Test_Min = txtBendTestMin.Text.Trim();
            castingmaster.Me_P_Min = txtImpact1Min.Text.Trim();
            castingmaster.Me_Cr_Min = txtImpact2Min.Text.Trim();
            castingmaster.Me_Ni_Min = txtImpact3Min.Text.Trim();
            castingmaster.Me_Mo_Min = txtAverageImpactMin.Text.Trim();

            castingmaster.Me_Carbon_Max = txtUTSMax.Text.Trim();
            castingmaster.Me_Si_Max = txtYSMax.Text.Trim();
            castingmaster.Me_Mn_Max = txtElongationMax.Text.Trim();
            castingmaster.Me_S_Max = txtHardnessMax.Text.Trim();
            castingmaster.Me_Ra_Max = txtRAMax.Text.Trim();
            castingmaster.Me_Bend_Test_Max = txtBendTestMax.Text.Trim();
            castingmaster.Me_P_Max = txtImpact1Max.Text.Trim();
            castingmaster.Me_Cr_Max = txtImpact2Max.Text.Trim();
            castingmaster.Me_Ni_Max = txtImpact3Max.Text.Trim();
            castingmaster.Me_Mo_Max = txtAverageImpactMax.Text.Trim();
            if (cmbMetalType.Enabled)
            {
                if (cmbMetalType.SelectedValue != null && cmbMetalType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select)
                    castingmaster.MetalType = cmbMetalType.SelectedValue.ToString();
            }
            else
            {
                castingmaster.MetalType = txtItemType.Text;
            }
            castingmaster.GradeStandard = txtGradeStandard.Text;
            castingmaster.Remarks = txtRemarks.Text;

           

            castingmaster.dtMetalGrade = dtCombineMetal;
            castingmaster.IsMaterialMappingFlag = IsMaterialMappingFlag;

            castingmaster.Metal_Id = Convert.ToInt32( ((metal_id.Text.ToString()) == "" ? "0" :(metal_id.Text.ToString())));
            DataTable dtOldGradePrpty = castingmaster.Fetch_Grade_Property();
            castingmaster.dtOldGradePrpty = dtOldGradePrpty;

            if (isUpdatedGradeProperty)                           
                castingmaster.IsUpdateGradeProperty = 0;           
            else
                castingmaster.IsUpdateGradeProperty = 1;

            castingmaster.Effective_date = System.DateTime.Now;

            castingmaster.dtGradePrpty = dtGradePropertyRecord;

            if (isUpdatedGradePropertyMicro)
                castingmaster.IsUpdateGradePropertyMicrostructure = 0;
            else
                castingmaster.IsUpdateGradePropertyMicrostructure = 1;

            castingmaster.dtGradePropertyRecordMicrostructure = dtGradePropertyRecordMicrostructure;

            if (IsMaterialMappingFlag)
            {
                DataTable dtMaterialMapping = new DataTable();
                dtMaterialMapping = (DataTable)dgvMetalMaterialMapping.DataSource;
                if (dtMaterialMapping != null)
                dtMaterialMapping.AcceptChanges();
                castingmaster.dtMaterialMapping = dtMaterialMapping;
            }

            if (metal_id.Text == "")
            {

                DataTable dt = castingmaster.FetchMetalnameDuplicateCheck();

                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Already Exist");
                    txtMetalName.Clear();
                    txtMetalName.Focus();
                    return;
                }


                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Saveconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = castingmaster.Insert_Metal_master();

                    if (result == 1)
                    {

                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.SaveDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (Control txt in grpChemical.Controls)
                        {
                            if (txt is TextBox)
                            {
                                txt.Text = "";
                            }
                        }
                        foreach (Control txt in grpMechanical.Controls)
                        {
                            if (txt is TextBox)
                            {
                                txt.Text = "";
                            }
                        }
                        CLEAR();                       
                        txtMetalName.Clear();
                        dgvMetal.RowEnter -= dgvMetal_RowEnter;
                    }
                }

            }
            else
            {
                castingmaster.Metal_Id = Convert.ToInt32(metal_id.Text);
                DataTable dt = castingmaster.FetchMetalnameDuplicateCheck();

                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Already Exist");
                    txtMetalName.Clear();
                    txtMetalName.Focus();
                    return;
                }

                if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Updateconfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int result = castingmaster.Insert_Metal_master();

                    if (result == 1)
                    {
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UpdateDone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (Control txt in grpChemical.Controls)
                        {
                            if (txt is TextBox)
                            {
                                txt.Text = "";
                            }
                        }
                        foreach (Control txt in grpMechanical.Controls)
                        {
                            if (txt is TextBox)
                            {
                                txt.Text = "";
                            }
                        }
                        CLEAR();                        
                        txtMetalName.Clear();
                        dgvMetal.RowEnter -= dgvMetal_RowEnter;
                    }
                }

            }

            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("Enter Metal Name");
            //    txtMetalName.Focus();
            //    return;
            //}
            //tabControl1.SelectedIndex = (tabControl1.TabPages.Count - 1 == tabControl1.SelectedIndex) ? 0 : tabControl1.SelectedIndex + 1;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
            txtMetalName.Focus();
        }

        private DataTable setValueWhenMinAndMaxBlank(DataTable dtCombineMetal)
        {
            try
            {
                for (int row = 0; row < dtCombineMetal.Rows.Count; row++)
                {
                    string minValue = dtCombineMetal.Rows[row]["Minimum"].ToString();
                    string maxValue = dtCombineMetal.Rows[row]["Maximum"].ToString();
                    minValue = minValue.Trim();
                    maxValue = maxValue.Trim();

                    if (maxValue == "" && minValue == "")
                    {
                        dtCombineMetal.Rows[row]["Minimum"] = "0";
                    }
                }
            }
            catch
            {
            }
            return dtCombineMetal;
        }

      
        DataTable dtSaveMetalProperties = new DataTable();

        private void LoadSaveMetalPropertiesDatatable()
        {
            try
            {
                if (!(dtSaveMetalProperties.Columns.Contains("ChemicalMetalElementId")))
                    dtSaveMetalProperties.Columns.Add("ChemicalMetalElementId");

                if (!(dtSaveMetalProperties.Columns.Contains("Name")))
                    dtSaveMetalProperties.Columns.Add("Name");

                if (!(dtSaveMetalProperties.Columns.Contains("Minimum")))
                    dtSaveMetalProperties.Columns.Add("Minimum");

                if (!(dtSaveMetalProperties.Columns.Contains("Maximum")))
                    dtSaveMetalProperties.Columns.Add("Maximum");

                if (!(dtSaveMetalProperties.Columns.Contains("Maximum")))
                    dtSaveMetalProperties.Columns.Add("Maximum");

                if (!(dtSaveMetalProperties.Columns.Contains("Maximum")))
                    dtSaveMetalProperties.Columns.Add("Maximum");

            }
            catch
            { }
        }

        private void getMetalPropertiesData()
        {
            try
            {
                dtSaveMetalProperties.Rows.Clear();
            }
            catch
            {
            }
        }

        Boolean IsMaterialMappingFlag = true;

        private void MetalMaster_Load(object sender, EventArgs e)
        {    
            if (FullScreenOff != 1)
                AutoFitForm.SetFormToMaximize(this);
            tabControl1.TabPages.Remove(tabPage2);

            clsElementMaster clElemntMstr = new clsElementMaster();
            dtAllElement = clElemntMstr.Fetch_Element_Details();

            dtAllElementMicrostruture = GlobleFunctionsHelper.fillMicrostructure_Metal_Itemwise_Heat();
            dgvMicrostructureElement.AutoGenerateColumns = false;
            dgvMicrostructureElement.DataSource = dtAllElementMicrostruture;
            // isTCEnable = clsValues.Instance.IsTCEnable;
            LoadSaveMetalPropertiesDatatable();
            LoadMechanicalMetalDatatable("MechanicalMetalElementId");
            LoadChemicalMetalDatatable("ChemicalMetalElementId");
            LoadMicrostructureMetalDatatable("MicrostructureMetalElementId");
            CLEAR();
           
            dgvMetal.AutoGenerateColumns = false;

            GlobleFunctionsHelper.GetElementChemicalLabelNameData(lblElementC1, lblElementC2, lblElementC3, lblElementC4, lblElementC5, lblElementC6, lblElementC7, lblElementC8, lblElementC9, lblElementC10, lblElementC11, lblElementC12, lblElementC13, lblElementC14, lblElementC15);
            GlobleFunctionsHelper.GetElementMechanicalLabelNameData(lblElementM1, lblElementM2, lblElementM3, lblElementM4, lblElementM5, lblElementM6, lblElementM7, lblElementM8, lblElementM9, lblElementM10);
            var applicationConfiguration = Inventory_Management.Helpers.ConfigurationHelper.GetApplicationConfiguration();
            //if (isTCEnable == 0)
            int chkNxtbtn = 0;
            if (!applicationConfiguration.IsTCEnable)
            {
                tabControl1.TabPages.Remove(tabPage3);
                //tabPage3
               // btnNext.Visible = false;
                chkNxtbtn = chkNxtbtn + 1;
            }

            IsMaterialMappingFlag = applicationConfiguration.IsMetalMapping;
            // Metal Material Mapping
            if (IsMaterialMappingFlag)
            {
                Fill_Item_Type();
                Fill_Item_Category();
                Fill_Item_Group();
                Fill_Item_Code();
                Fill_Item_Name();
            }
            else
            {
                tabControl1.TabPages.Remove(MetalMapping);
                chkNxtbtn = chkNxtbtn + 1;
            }

            if (chkNxtbtn == 2)
                btnNext.Visible = false;

        }

        private void ClearSearch()
        {
            try
            {
                BindSearchMetal();
                chkViewBlock.Checked = true;
                SearchMetalRecord();
                MetalID =  -1;
            }
            catch
            { }
        }

        private void SearchMetalRecord()
        {
            try
            {
                int ViewBlock = 1;
                if (chkViewBlock.Checked == false)
                    ViewBlock = 0;
                string MetalName = null;

                if (cmbSearchMetal.SelectedIndex == 0)
                {
                    MetalIdFilter = 0;
                }

                if (MetalIdFilter != 0)
                {
                    MetalName = MetalIdFilter.ToString();
                    FillGrid(MetalName, ViewBlock);
                }
                else
                    FillGrid(null, ViewBlock);
            }
            catch
            { }
        }

        private void CLEAR()
        {
            try
            {
                clsElementMaster clElemntMstr = new clsElementMaster();
                dtAllElement = clElemntMstr.Fetch_Element_Details();
                ClearSearch();
                dgvMetal.DataSource = null;
                clerGridControl();

                try
                {                    
                    for (int i = 0; i < dgvMetalMaterialMapping.Rows.Count; )
                    {
                        dgvMetalMaterialMapping.Rows.RemoveAt(i);
                    }
                    dgvMetalMaterialMapping.Enabled = true;
                }
                catch
                { }

                BindMetalType();
                BindSearchMetal();
                FillGrid();
                MetalID = -1;
                txtMetalName.Clear();
                txtdensity.Clear();

                if (cmbMetalType.Items.Count > 0)
                    cmbMetalType.SelectedIndex = 0;

                cmbMetalType.Enabled = true;
                txtItemType.Visible = false;
                lblItemTypeRequired.Visible = false;
                txtMetalName.Clear();
                txtItemType.Clear();
                btnAddMetalGrp.Visible = true;
                txtGradeStandard.Clear();
                txtRemarks.Clear();
               
                dtChecmicalProcess.Rows.Clear();
                btnSave.Text = Helper.ButtonCaptions.Save;
                dtChecmicalProcess.Rows.Clear();
                dtMechanicalProcess.Rows.Clear();
                dtMicrostructureProcess.Rows.Clear();
                dtSaveMetalProperties.Rows.Clear();
                metal_id.Text = string.Empty;
                txtMetalName.Focus();
                btnSaveMapping.Enabled = true;
                btnSave.Enabled = true;
                dgvMetalMaterialMapping.Enabled = true;
                btnClose.Enabled = true;
                int chkNxtbtn = 0;
                var applicationConfiguration = Inventory_Management.Helpers.ConfigurationHelper.GetApplicationConfiguration();
                //if (isTCEnable == 0)

                if (!applicationConfiguration.IsTCEnable)
                {
                    tabControl1.TabPages.Remove(tabPage3);
                    chkNxtbtn = chkNxtbtn + 1;
                 //   btnNext.Visible = false;
                }

                IsMaterialMappingFlag = applicationConfiguration.IsMetalMapping;
                // Metal Material Mapping
                if (IsMaterialMappingFlag)
                {
                    Fill_Item_Type();
                    Fill_Item_Category();
                    Fill_Item_Group();
                    Fill_Item_Code();
                    Fill_Item_Name();
                }
                else
                {
                    tabControl1.TabPages.Remove(MetalMapping);
                    chkNxtbtn = chkNxtbtn + 1;
                }

                if(chkNxtbtn == 2)
                    btnNext.Visible = false;

                foreach (Control txt in grpChemical.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }
                foreach (Control txt in grpMechanical.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }
                foreach (Control txt in tabPage1.Controls)
                {
                    if (txt is TextBox)
                    {
                        ((TextBox)txt).Clear();
                    }
                }


                dtAllElementMicrostruture = GlobleFunctionsHelper.fillMicrostructure_Metal_Itemwise_Heat();
                dgvMicrostructureElement.AutoGenerateColumns = false;
                dgvMicrostructureElement.DataSource = dtAllElementMicrostruture;
               
            }
            catch
            { }
        }

        private void clerGridControl()
        {
            try
            {
                dgvChemicalElement.DataSource = null;
                dgvMechanicalElement.DataSource = null;
                dgvMicrostructureElement.DataSource = null;

                dtMechanicalProcess = new DataTable();
                dtChecmicalProcess = new DataTable();
                dtMicrostructureProcess = new DataTable();
            }
            catch
            { }
        }

        private void FillGrid(string MetalName = null, int ViewBlock = 1)
        {
            clsCastingMaster castingmaster = new clsCastingMaster();

            DataTable dt_metal = castingmaster.Fetch_MetalMaster_ALl(MetalName, ViewBlock);

            dgvMetal.RowEnter -= dgvMetal_RowEnter;//This line will prevent to call the chkRemoveAllDate_CheckedChanged Event by doing Minus(-)           
            dgvMetal.DataSource = dt_metal;
            if (dgvMetal.Columns.Contains("Density"))
                dgvMetal.Columns["Density"].Visible = false;


            if (dt_metal != null)
            {
                if (dt_metal.Rows.Count > 0)
                {
                    dgvMetal.Rows[0].Cells[0].Selected = false;
                    dgvMetal.ClearSelection();

                    dgvMetal.Columns["Revise"].Visible = access_menu.Fetch_Frm_Right("Edit", MenuHelper.MenuIdentityCodes.METALMASTER);
                    dgvMetal.Columns["Delete"].Visible = access_menu.Fetch_Frm_Right("Delete", MenuHelper.MenuIdentityCodes.METALMASTER);

                    dgvMetal.Columns["MetalID"].Visible = false;
                    dgvMetal.Columns["IsDeleted"].Visible = false;
                }
            }
        }

        DataTable dtOldChemicalProcess = new DataTable();
        DataTable dtOldMechanicalProcess = new DataTable();
        DataTable dtOldMicrostructureProcess = new DataTable();
        
        private void dgvMetal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsCastingMaster castingmaster = new clsCastingMaster();
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    MetalID = Convert.ToInt32(dgvMetal.Rows[e.RowIndex].Cells["MetalID"].Value.ToString());

                    var senderGrid = (DataGridView)sender;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 0)        //Code For Edit OF Grid View
                    {
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                        {

                            btnSave.Enabled = true;
                            btnSaveMapping.Enabled = true;

                            clsPurchaseItemMaster purchase = new clsPurchaseItemMaster();
                            purchase.Metal_ID = MetalID;
                            txtMetalName.Text = dgvMetal.Rows[e.RowIndex].Cells["MetalName"].Value.ToString();
                            cmbMetalType.DataBindings.Clear();
                           // txtMetalName.DataBindings.Add("text", dgvMetal.DataSource, "MetalName");
                            cmbMetalType.DataBindings.Add("SelectedValue", dgvMetal.DataSource, "MetalType");
                            txtGradeStandard.DataBindings.Clear();
                            txtGradeStandard.DataBindings.Add("text", dgvMetal.DataSource, "GradeStandard");
                            txtRemarks.DataBindings.Clear();
                            txtRemarks.DataBindings.Add("text", dgvMetal.DataSource, "Remarks");
                            txtdensity.DataBindings.Clear();
                            txtdensity.DataBindings.Add("text", dgvMetal.DataSource, "MetalDensity");


                            metal_id.Text = MetalID.ToString();

                            // Guid MetalId = Guid.Parse(dgvMetal.Rows[e.RowIndex].Cells["MetalId"].Value.ToString());
                            btnSave.Text = Helper.ButtonCaptions.Update;
                            castingmaster.Metal_Id = MetalID;
                            DataTable dtGradeProperty = castingmaster.Fetch_Grade_Property();

                            clsMicrostructure objMicroStructure = new clsMicrostructure();
                            objMicroStructure.Metal_Id = MetalID;
                            DataTable dtMicrostructureGradeProperty = objMicroStructure.Fetch_Microstrucutre_Grade_Property();

                            dtMicrostructureProcess = GlobleFunctionsHelper.SetRecordofMicrostructure_Metal_Itemwise_Heat(dtMicrostructureGradeProperty, dtAllElementMicrostruture);

                            #region Metal Grade Property

                            //DataTable dtMetalGradeProperty = castingmaster.Fetch_Metal_Grade_Property();

                            //castingmaster.IsChemical = 0;
                            //dtChecmicalProcess.Rows.Clear();
                            //castingmaster.IsOnlyMetal = 0;
                            //dtChecmicalProcess = castingmaster.Fetch_Metal_Grade_Property();
                            //castingmaster.IsChemical = 1;
                            //dtMechanicalProcess.Rows.Clear();
                            //dtMechanicalProcess = castingmaster.Fetch_Metal_Grade_Property();

                          //  dgvChemicalElement.AutoGenerateColumns = false;
                          //  dgvChemicalElement.DataSource = dtChecmicalProcess;
                          //  dgvMechanicalElement.AutoGenerateColumns = false;
                         //   dgvMechanicalElement.DataSource = dtMechanicalProcess;

                            //DataTable dtMetalGradeProperty = castingmaster.Fetch_All_Metal_Grade_Property();

                            //try
                            //{
                            //    var results = from myRow in dtMetalGradeProperty.AsEnumerable()
                            //                  where myRow.Field<int>("MetalType") == 0
                            //                  select myRow;

                            //    dtChecmicalProcess.Rows.Clear();
                            //    dtChecmicalProcess = results.CopyToDataTable();
                            //}
                            //catch
                            //{ }

                            //try
                            //{

                            //    var results = from myRow in dtMetalGradeProperty.AsEnumerable()
                            //                  where myRow.Field<int>("MetalType") == 1
                            //                  select myRow;
                            //    dtMechanicalProcess.Rows.Clear();
                            //    dtMechanicalProcess = results.CopyToDataTable();
                            //}
                            //catch
                            //{ }

                            //dgvChemicalElement.AutoGenerateColumns = false;
                            //dgvChemicalElement.DataSource = dtChecmicalProcess;
                            //dgvMechanicalElement.AutoGenerateColumns = false;
                            //dgvMechanicalElement.DataSource = dtMechanicalProcess;


                            #endregion
                            
                            #region ChangeColumnName

                            //if (dtChecmicalProcess.Columns.Contains("MetalElementId"))
                            //dtChecmicalProcess.Columns["MetalElementId"].ColumnName = "ChemicalMetalElementId";

                            //dtChecmicalProcess.AcceptChanges();

                            //dtMechanicalProcess.Columns["MetalElementId"].ColumnName = "MechanicalMetalElementId";
                            //dtMechanicalProcess.AcceptChanges();

                            #endregion

                            if (IsMaterialMappingFlag)
                            {
                                DataTable dtMetalMateMapp = castingmaster.Fetch_Metal_Material_Mapping();
                                dgvMetalMaterialMapping.AutoGenerateColumns = false;
                                dgvMetalMaterialMapping.DataSource = dtMetalMateMapp;
                                dgvMetalMaterialMapping.Enabled = true;
                            }

                            txtMetalName.DataBindings.Clear();
                            cmbMetalType.DataBindings.Clear();
                            txtGradeStandard.DataBindings.Clear();
                            txtRemarks.DataBindings.Clear();
                            txtdensity.DataBindings.Clear();

                            if (dtGradeProperty != null && dtGradeProperty.Rows.Count > 0)
                            {
                                dtChecmicalProcess = GlobleFunctionsHelper.GetRecordforGradeProperty(dtGradeProperty, "Che_", dtAllElement, false, null);
                                dtChecmicalProcess = GlobleFunctionsHelper.RemoveBlankMinMax(dtChecmicalProcess);
                                dgvChemicalElement.AutoGenerateColumns = false;
                                dgvChemicalElement.DataSource = dtChecmicalProcess;

                                dtOldChemicalProcess = dtChecmicalProcess.Copy();

                                dtMechanicalProcess = GlobleFunctionsHelper.GetRecordforGradePropertyMechanical(dtGradeProperty, "Me_", dtAllElement, false, null);
                                dtMechanicalProcess = GlobleFunctionsHelper.RemoveBlankMinMax(dtMechanicalProcess);
                                dgvMechanicalElement.AutoGenerateColumns = false;
                                dgvMechanicalElement.DataSource = dtMechanicalProcess;

                                dtOldMechanicalProcess = dtMechanicalProcess.Copy();
                                
                               
                                dgvMicrostructureElement.AutoGenerateColumns = false;
                                dgvMicrostructureElement.DataSource = dtMicrostructureProcess;

                                dtOldMicrostructureProcess = dtMicrostructureProcess.Copy();

                                //txtCMin.Text = dtGradeProperty.Rows[0]["Che_Carbon_Min"].ToString();
                                //txtSiMin.Text = dtGradeProperty.Rows[0]["Che_Si_Min"].ToString();
                                //txtMgMin.Text = dtGradeProperty.Rows[0]["Che_Mg_Min"].ToString();
                                //txtMnMin.Text = dtGradeProperty.Rows[0]["Che_Mn_Min"].ToString();
                                //txtSMin.Text = dtGradeProperty.Rows[0]["Che_S_Min"].ToString();
                                //txtPMin.Text = dtGradeProperty.Rows[0]["Che_P_Min"].ToString();
                                //txtCrMin.Text = dtGradeProperty.Rows[0]["Che_Cr_Min"].ToString();
                                //txtNiMin.Text = dtGradeProperty.Rows[0]["Che_Ni_Min"].ToString();
                                //txtMoMin.Text = dtGradeProperty.Rows[0]["Che_Mo_Min"].ToString();
                                //txtCuMin.Text = dtGradeProperty.Rows[0]["Che_Cu_Min"].ToString();
                                //txtTiMin.Text = dtGradeProperty.Rows[0]["Che_Ti_Min"].ToString();
                                //txtAlMin.Text = dtGradeProperty.Rows[0]["Che_Al_Min"].ToString();
                                //txtBMin.Text = dtGradeProperty.Rows[0]["Che_B_Min"].ToString();
                                //txtNBMin.Text = dtGradeProperty.Rows[0]["Che_NB_Min"].ToString();
                                //txtVMin.Text = dtGradeProperty.Rows[0]["Che_V_Min"].ToString();

                                //txtCMax.Text = dtGradeProperty.Rows[0]["Che_Carbon_Max"].ToString();
                                //txtSiMax.Text = dtGradeProperty.Rows[0]["Che_Si_Max"].ToString();
                                //txtMgMax.Text = dtGradeProperty.Rows[0]["Che_Mg_Max"].ToString();
                                //txtMnMax.Text = dtGradeProperty.Rows[0]["Che_Mn_Max"].ToString();
                                //txtSMax.Text = dtGradeProperty.Rows[0]["Che_S_Max"].ToString();
                                //txtPMax.Text = dtGradeProperty.Rows[0]["Che_P_Max"].ToString();
                                //txtCrMax.Text = dtGradeProperty.Rows[0]["Che_Cr_Max"].ToString();
                                //txtNiMax.Text = dtGradeProperty.Rows[0]["Che_Ni_Max"].ToString();
                                //txtMoMax.Text = dtGradeProperty.Rows[0]["Che_Mo_Max"].ToString();
                                //txtCuMax.Text = dtGradeProperty.Rows[0]["Che_Cu_Max"].ToString();
                                //txtTiMax.Text = dtGradeProperty.Rows[0]["Che_Ti_Max"].ToString();
                                //txtAlMax.Text = dtGradeProperty.Rows[0]["Che_Al_Max"].ToString();
                                //txtBMax.Text = dtGradeProperty.Rows[0]["Che_B_Max"].ToString();
                                //txtNBMax.Text = dtGradeProperty.Rows[0]["Che_NB_Max"].ToString();
                                //txtVMax.Text = dtGradeProperty.Rows[0]["Che_V_Max"].ToString();

                                //txtUTSMin.Text = dtGradeProperty.Rows[0]["Me_Carbon_Min"].ToString();
                                //txtYSMin.Text = dtGradeProperty.Rows[0]["Me_Si_Min"].ToString();
                                //txtElongationMin.Text = dtGradeProperty.Rows[0]["Me_Mn_Min"].ToString();
                                //txthardnessMin.Text = dtGradeProperty.Rows[0]["Me_S_Min"].ToString();
                                //txtRAMIn.Text = dtGradeProperty.Rows[0]["Me_Ra_Min"].ToString();
                                //txtBendTestMin.Text = dtGradeProperty.Rows[0]["Me_Bend_Test_Min"].ToString();
                                //txtImpact1Min.Text = dtGradeProperty.Rows[0]["Me_P_Min"].ToString();
                                //txtImpact2Min.Text = dtGradeProperty.Rows[0]["Me_Cr_Min"].ToString();
                                //txtImpact3Min.Text = dtGradeProperty.Rows[0]["Me_Ni_Min"].ToString();
                                //txtAverageImpactMin.Text = dtGradeProperty.Rows[0]["Me_Mo_Min"].ToString();

                                //txtUTSMax.Text = dtGradeProperty.Rows[0]["Me_Carbon_Max"].ToString();
                                //txtYSMax.Text = dtGradeProperty.Rows[0]["Me_Si_Max"].ToString();
                                //txtElongationMax.Text = dtGradeProperty.Rows[0]["Me_Mn_Max"].ToString();
                                //txtHardnessMax.Text = dtGradeProperty.Rows[0]["Me_S_Max"].ToString();
                                //txtRAMax.Text = dtGradeProperty.Rows[0]["Me_Ra_Max"].ToString();
                                //txtBendTestMax.Text = dtGradeProperty.Rows[0]["Me_Bend_Test_Max"].ToString();
                                //txtImpact1Max.Text = dtGradeProperty.Rows[0]["Me_P_Max"].ToString();
                                //txtImpact2Max.Text = dtGradeProperty.Rows[0]["Me_Cr_Max"].ToString();
                                //txtImpact3Max.Text = dtGradeProperty.Rows[0]["Me_Ni_Max"].ToString();
                                //txtAverageImpactMax.Text = dtGradeProperty.Rows[0]["Me_Mo_Max"].ToString();


                                cmbMetalType.Enabled = true;
                                btnAddMetalGrp.Visible = true;
                                txtItemType.Visible = false;
                                lblItemTypeRequired.Visible = false;
                            }




                        }
                    }
                    if (senderGrid.Rows[e.RowIndex].Cells["Delete"].Value.ToString() == Helper.LinkButtonCaptions.Block && e.ColumnIndex == 1)        //Code For Delete Button OF Grid View
                    {
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.ColumnIndex == 1)
                        {
                            int result = 0;

                            if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.BlockConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                var session = Session.Get();
                                castingmaster.Is_Deleted = 1;
                                castingmaster.Metal_Id = MetalID;

                                castingmaster.DeletedBy = session.UserId;

                                castingmaster.DeletedOn = System.DateTime.Now;


                                //DataSet dt_check = castingmaster.checkmetal_From_MetalMaster();

                                //if (dt_check != null && (dt_check.Tables[0].Rows.Count > 0 || dt_check.Tables[1].Rows.Count > 0 || dt_check.Tables[2].Rows.Count > 0))
                                //{
                                //    System.Windows.Forms.MessageBox.Show("Metal Grade is in use.");
                                //}
                                //else
                                //{
                                result = castingmaster.delete_From_MetalMaster();

                                if (result == 1)
                                {
                                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Blockdone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CLEAR();                                    
                                }
                                else
                                {
                                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.BlockError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    BindMetalType();
                                    BindSearchMetal();
                                    FillGrid();
                                }

                            }
                        }
                        //  }


                    }
                    // unblocked code of metal started as discussed with bhumin sir
                    else if (senderGrid.Rows[e.RowIndex].Cells["Delete"].Value.ToString() == Helper.LinkButtonCaptions.UnBlock && e.ColumnIndex == 1)     //Code For Unblock Button      
                    {
                        var session = Session.Get();

                        castingmaster.Metal_Id = MetalID;

                        castingmaster.DeletedBy = session.UserId;

                        castingmaster.DeletedOn = System.DateTime.Now;

                        SuperLogin sprLgn = new SuperLogin();

                        sprLgn.ShowInTaskbar = false;
                        sprLgn.ShowDialog();

                        int Result = 0;
                        int AdminAccess = 0;
                        AdminAccess = clsValues.Instance.AdminAccess;
                        if (AdminAccess == 1)
                        {
                            Result = castingmaster.UnBlock_From_MetalMaster();

                            if (Result == 1)
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.Unblockeddone, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //  Fill_Grid();
                                CLEAR();  
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.UnblockedError, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Fill_Grid();
                                CLEAR();
                            }
                        }
                    }

                }
            }



            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
                     
        #region Make Code in GlobleFunctionHelper

        //private DataTable RemoveBlankMinMax(DataTable dtChecmicalProcess)
        //{
        //    try
        //    {
        //        for (int row = 0; row < dtChecmicalProcess.Rows.Count;)
        //        {
        //            if ((dtChecmicalProcess.Rows[row]["Minimum"].ToString()).Trim() == "" && (dtChecmicalProcess.Rows[row]["Maximum"].ToString()).Trim() == "")
        //            {
        //                dtChecmicalProcess.Rows.RemoveAt(row);
        //                continue;
        //            }
        //            row++;
        //        }

        //        for (int row = 0; row < dtChecmicalProcess.Rows.Count;row++ )
        //        {
        //            dtChecmicalProcess.Rows[row]["SqNo"] = (row + 1).ToString();                                           
        //        }

        //        return dtChecmicalProcess;

        //    }
        //    catch
        //    { }
        //    return null;
        //}


        //private DataTable GetRecordforGradeProperty(DataTable dtGradeProperty, string p)
        //{
        //    throw new NotImplementedException();
        //}

        //private DataTable GetRecordforGradeProperty(DataTable dtGradeProperty, string typeElement)
        //{
        //    try
        //    {
        //        clsElementMaster clElemntMstr = new clsElementMaster();
        //        DataTable dtAllElement = clElemntMstr.Fetch_Element_Details();

        //        DataTable dtTmp = new DataTable();
        //        dtTmp.Columns.Add("ChemicalMetalElementId");               
        //        dtTmp.Columns.Add("Name");
        //        dtTmp.Columns.Add("Minimum");
        //        dtTmp.Columns.Add("Maximum");
        //        dtTmp.Columns.Add("SqNo");

        //        int E1 = 0;                
        //        for (int row = 0; row < dtGradeProperty.Rows.Count; row++)
        //        {
        //            for (int col = 0; col < dtGradeProperty.Columns.Count; col++)
        //            {
        //                string GrdClmns = dtGradeProperty.Columns[col].ToString();
        //                if (GrdClmns.Contains(typeElement))
        //                {
        //                    string GrdValu = dtGradeProperty.Rows[row][col].ToString();
        //                    GrdValu = GrdValu.Trim();

        //                    string TmpGrdClumns = GrdClmns.Trim();
        //                   // Che_Si_Min
        //                    TmpGrdClumns = TmpGrdClumns.Replace("_Min", "");
        //                    TmpGrdClumns = TmpGrdClumns.Replace("_Max", "");
        //                   // if (GrdValu == "")
        //                  //      continue;
        //                    string gtElements = "";
        //                    switch (TmpGrdClumns)
        //                    {
        //                        case "Che_Carbon":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC1", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Si":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC2", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Mg":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC3", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Mn":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC4", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_S":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC5", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_P":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC6", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Cr":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC7", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Ni":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC8", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Mo":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC9", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Cu":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC10", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Ti":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC11", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_Al":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC12", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_B":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC13", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_NB":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC14", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;

        //                        case "Che_V":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementC15", gtElements, GrdValu, ref E1, row, GrdClmns, "ChemicalMetalElementId");
        //                            break;
        //                    }

        //                }
        //            }
        //        }

        //        return dtTmp;

        //    }
        //    catch
        //    { }
        //    return null;
        //}

        //private DataTable GetRecordforGradePropertyMechanical(DataTable dtGradeProperty, string typeElement)
        //{
        //    try
        //    {
        //        clsElementMaster clElemntMstr = new clsElementMaster();
        //        DataTable dtAllElement = clElemntMstr.Fetch_Element_Details();

        //        DataTable dtTmp = new DataTable();
        //        dtTmp.Columns.Add("MechanicalMetalElementId");
        //        dtTmp.Columns.Add("Name");
        //        dtTmp.Columns.Add("Minimum");
        //        dtTmp.Columns.Add("Maximum");
        //        dtTmp.Columns.Add("SqNo");

        //        int E1 = 0;
        //        for (int row = 0; row < dtGradeProperty.Rows.Count; row++)
        //        {
        //            for (int col = 0; col < dtGradeProperty.Columns.Count; col++)
        //            {
        //                string GrdClmns = dtGradeProperty.Columns[col].ToString();
        //                if (GrdClmns.Contains(typeElement))
        //                {
        //                    string GrdValu = dtGradeProperty.Rows[row][col].ToString();
        //                    GrdValu = GrdValu.Trim();

        //                    string TmpGrdClumns = GrdClmns.Trim();
        //                    // Che_Si_Min
        //                    TmpGrdClumns = TmpGrdClumns.Replace("_Min", "");
        //                    TmpGrdClumns = TmpGrdClumns.Replace("_Max", "");
        //                    //if (GrdValu == "")
        //                    //    continue;
        //                    string gtElements = "";
        //                    switch (TmpGrdClumns)
        //                    {
        //                        case "Me_Carbon":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM1", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Si":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM2", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Mn":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM3", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_S":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM4", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Ra":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM5", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_P":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM6", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Cr":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM7", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Ni":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM8", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Mo":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM9", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;

        //                        case "Me_Cu":
        //                            ViewElementRecord(dtAllElement, ref dtTmp, "ElementM10", gtElements, GrdValu, ref E1, row, GrdClmns, "MechanicalMetalElementId");
        //                            break;                                
        //                    }

        //                }
        //            }
        //        }

        //        return dtTmp;

        //    }
        //    catch
        //    { }
        //    return null;
        //}
        
        //private void ViewElementRecord(DataTable dtAllElement, ref DataTable dtTmp, string ElementColumns, string gtElements, string GrdValu, ref int E1, int row, string GrdClmns, string ElmntNamesClmn)
        //{
        //    try
        //    {
        //        gtElements = dtAllElement.Rows[row][ElementColumns].ToString();

        //        DataRow[] results1;
        //        results1 = dtTmp.Select("Name = '" + gtElements + "'");

        //        if (results1.Count() > 0 && gtElements != "")
        //        {
        //            int Nos = Convert.ToInt32(results1[0]["SqNo"].ToString());
        //            dtTmp.Rows[Nos][ElmntNamesClmn] = "";
        //            dtTmp.Rows[Nos]["Name"] = gtElements;
        //            if (GrdClmns.Contains("_Min"))
        //                dtTmp.Rows[Nos]["Minimum"] = GrdValu;
        //            else
        //                dtTmp.Rows[Nos]["Maximum"] = GrdValu;
        //            dtTmp.Rows[Nos]["SqNo"] = E1;

        //        }
        //        else
        //        {
        //            dtTmp.Rows.Add();
        //            dtTmp.Rows[E1][ElmntNamesClmn] = "";
        //            dtTmp.Rows[E1]["Name"] = gtElements;
        //            if (GrdClmns.Contains("_Min"))
        //                dtTmp.Rows[E1]["Minimum"] = GrdValu;
        //            else
        //                dtTmp.Rows[E1]["Maximum"] = GrdValu;
        //            dtTmp.Rows[E1]["SqNo"] = E1;
        //            E1++;
        //        }     
        //    }
        //    catch
        //    { }
        //}

        //private bool CompareDatatable(DataTable dtOldChemicalProcess, DataTable dtChem)
        //{
        //    try
        //    {
        //        if (dtOldChemicalProcess.Rows.Count == dtChem.Rows.Count)
        //        {
        //            for (int row = 0; row < dtChem.Rows.Count; row++)
        //            {
        //                for (int col = 0; col < dtChem.Columns.Count; col++)
        //                {
        //                    if (dtChem.Rows[row][col].ToString() != dtOldChemicalProcess.Rows[row][col].ToString())
        //                    {
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //            return true;

        //    }
        //    catch
        //    { }
        //    return false;
        //}

        //private bool GetCheckForElementHave(DataTable dtChecmicalProcess)
        //{
        //    try
        //    {
        //        for (int row = 0; row < dtChecmicalProcess.Rows.Count; row++)
        //        {
        //            string EleMin = dtChecmicalProcess.Rows[row]["Minimum"].ToString();
        //            string EleMax = dtChecmicalProcess.Rows[row]["Maximum"].ToString();

        //            if (!(EleMax == "" && EleMin == ""))
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //    catch
        //    { }
        //    return true;
        //}

        //private DataTable SetGradePropertyRecords(DataTable dtGrdPrptyClm, DataTable dtCombineMetal)
        //{
        //    try
        //    {
        //        clsElementMaster clElemntMstr = new clsElementMaster();
        //        DataTable dtAllElement = clElemntMstr.Fetch_Element_Details();

        //        DataTable dtNewGradeProperty = new DataTable();
        //        dtNewGradeProperty = dtGrdPrptyClm.Clone();

        //        for (int r = 0; r < dtAllElement.Rows.Count; r++)
        //        {
        //            dtNewGradeProperty.Rows.Add();
        //        }

        //        for (int row = 0; row < dtCombineMetal.Rows.Count; row++)
        //        {
        //            string GetForElement = dtCombineMetal.Rows[row]["Element"].ToString();
        //            string NameOfElementType = dtCombineMetal.Rows[row]["Type"].ToString();
        //            string NameOfElement = "";
        //            int NosRowAdd = 0;
        //            bool isBreak = false;

        //            for (int tmpCnt = 0; tmpCnt < dtAllElement.Rows.Count; tmpCnt++)
        //            {
        //                for (int tmpCntClm = 0; tmpCntClm < dtAllElement.Columns.Count; tmpCntClm++)
        //                {
        //                    string Vlas = dtAllElement.Rows[tmpCnt][tmpCntClm].ToString();
        //                    if (Vlas == NameOfElementType)
        //                    {
        //                        NameOfElement = dtAllElement.Columns[tmpCntClm].ToString();
        //                        NosRowAdd = tmpCnt;
        //                        isBreak = true;
        //                        break;
        //                    }
        //                }
        //                if (isBreak)
        //                    break;
        //            }


        //            if (GetForElement == "Chemical")
        //            {
        //                switch (NameOfElement)
        //                {
        //                    case "ElementC1":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Carbon_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Carbon_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC2":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Si_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Si_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC3":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mg_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mg_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC4":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mn_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mn_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC5":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_S_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_S_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC6":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_P_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_P_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC7":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Cr_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Cr_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC8":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Ni_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Ni_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC9":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mo_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Mo_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC10":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Cu_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Cu_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC11":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Ti_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Ti_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC12":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Al_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_Al_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC13":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_B_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_B_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC14":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_NB_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_NB_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementC15":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_V_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Che_V_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                }


        //            }
        //            else
        //            {
        //                switch (NameOfElement)
        //                {
        //                    case "ElementM1":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Carbon_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Carbon_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM2":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Si_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Si_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM3":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Mn_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Mn_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM4":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_S_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_S_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM5":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Ra_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Ra_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM6":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_P_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_P_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM7":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Cr_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Cr_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM8":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Ni_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Ni_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM9":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Mo_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Mo_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;
        //                    case "ElementM10":
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Cu_Min"] = dtCombineMetal.Rows[row]["Minimum"].ToString();
        //                        dtNewGradeProperty.Rows[NosRowAdd]["Me_Cu_Max"] = dtCombineMetal.Rows[row]["Maximum"].ToString();
        //                        break;                            
        //                }

        //            }
        //        }
        //        return dtNewGradeProperty;
        //    }
        //    catch
        //    { }
        //    return null;
        //}

        //private DataTable GetGradepropertyColumns()
        //{
        //    try
        //    {
        //        clsCastingMaster objClsCasting = new clsCastingMaster();
        //        DataTable dtGrdColmns = objClsCasting.Fetch_Grade_Property_Column_Format();
        //        DataTable dTmptGrdColmns = dtGrdColmns.Clone();
        //        return dTmptGrdColmns;
        //    }
        //    catch
        //    {
        //    }
        //    return null;

        //}


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cmbComboBox_MouseDown(object sender, MouseEventArgs e)
        {

            if (!((ComboBox)sender).DroppedDown)
                ((ComboBox)sender).DroppedDown = true;
        }

        private void dgvMetal_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMetal.Rows)
            {
                DataGridViewCell cell1 = (DataGridViewCell)row.Cells["Revise"]; //Column Index for the dataGridViewButtonColumn
                DataGridViewLinkCell cell = (DataGridViewLinkCell)row.Cells["Delete"]; //Column Index for the dataGridViewButtonColumn
                if (Convert.ToInt32(row.Cells["IsDeleted"].Value.ToString()) == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;

                    row.DefaultCellStyle.Font = new Font(dgvMetal.DefaultCellStyle.Font, FontStyle.Strikeout);
                    cell1.Value = null;
                    cell1 = new DataGridViewTextBoxCell();
                    cell.Style.Font = new Font(dgvMetal.DefaultCellStyle.Font, FontStyle.Regular);
                    cell.ReadOnly = false;
                    cell.Value = Helper.LinkButtonCaptions.UnBlock;
                }
                else
                {
                    cell.ReadOnly = false;
                    cell.Value = Helper.LinkButtonCaptions.Block;

                    cell1.ReadOnly = false;
                    cell1.Value = Helper.LinkButtonCaptions.EDIT;
                }
            }
        }
        private void lnkbtnAddNewType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtItemType.Visible = true;
            lblItemTypeRequired.Visible = true;
            cmbMetalType.Enabled = false;

            btnAddMetalGrp.Visible = false;
            txtItemType.Focus();
        }

        private void btnNextDieDetails_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = (tabControl1.TabPages.Count - 1 == tabControl1.SelectedIndex) ? 0 : tabControl1.SelectedIndex + 1;
            //txtCMin.Focus();
        }

        private void btnNextDieDetails_Leave(object sender, EventArgs e)
        {
            //tabControl1.SelectedIndex = (tabControl1.TabPages.Count - 1 == tabControl1.SelectedIndex) ? tabControl1.SelectedIndex : tabControl1.SelectedIndex + 1;
        }
        private void txtItemType_Leave(object sender, EventArgs e)
        {
            if (txtItemType.Text == "")
            {
                txtItemType.Visible = false;
                lblItemTypeRequired.Visible = false;
                cmbMetalType.Enabled = true;
                btnAddMetalGrp.Visible = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMetal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                for (int i = 0; i < dgvMetal.Rows.Count; i++)
                //foreach (DataGridViewRow row in dgvPurchaseItem.Rows)
                {
                    ((DataGridViewCell)dgvMetal.Rows[i].Cells["Revise"]).Selected = true;
                }
            }
        }

        private void dgvMetal_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            #region 
            try
            {
                MetalID = Convert.ToInt32(dgvMetal.Rows[e.RowIndex].Cells["MetalID"].Value.ToString());
                if (OLDMetalID != MetalID)
                {
                    OLDMetalID = MetalID;
                    clsCastingMaster castingmaster = new clsCastingMaster();
                    clsPurchaseItemMaster purchase = new clsPurchaseItemMaster();
                    purchase.Metal_ID = MetalID;
                    txtMetalName.Text = dgvMetal.Rows[e.RowIndex].Cells["MetalName"].Value.ToString();
                    cmbMetalType.DataBindings.Clear();
                    cmbMetalType.DataBindings.Add("SelectedValue", dgvMetal.DataSource, "MetalType");
                    txtGradeStandard.DataBindings.Clear();
                    txtGradeStandard.DataBindings.Add("text", dgvMetal.DataSource, "GradeStandard");
                    txtRemarks.DataBindings.Clear();
                    txtRemarks.DataBindings.Add("text", dgvMetal.DataSource, "Remarks");
                    txtdensity.DataBindings.Clear();
                    txtdensity.DataBindings.Add("text", dgvMetal.DataSource, "MetalDensity");

                    metal_id.Text = MetalID.ToString();
                    castingmaster.Metal_Id = MetalID;
                    DataTable dtGradeProperty = castingmaster.Fetch_Grade_Property();

                    clsMicrostructure objMicrostructure = new clsMicrostructure();
                    objMicrostructure.Metal_Id = MetalID;
                    objMicrostructure.IsCastingId = false;

                    DataTable dtMsRecord = objMicrostructure.Fetch_Microstrucutre_Grade_Property();

                    #region GradeProperty
                    if (dtGradeProperty != null && dtGradeProperty.Rows.Count > 0)
                    {
                        dtChecmicalProcess = GlobleFunctionsHelper.GetRecordforGradeProperty(dtGradeProperty, "Che_", dtAllElement, false, null);

                        dtChecmicalProcess = GlobleFunctionsHelper.RemoveBlankMinMax(dtChecmicalProcess);
                        dgvChemicalElement.AutoGenerateColumns = false;
                        dgvChemicalElement.DataSource = dtChecmicalProcess;

                        dtMechanicalProcess = GlobleFunctionsHelper.GetRecordforGradePropertyMechanical(dtGradeProperty, "Me_", dtAllElement, false, null);
                        dtMechanicalProcess = GlobleFunctionsHelper.RemoveBlankMinMax(dtMechanicalProcess);
                        dgvMechanicalElement.AutoGenerateColumns = false;
                        dgvMechanicalElement.DataSource = dtMechanicalProcess;

                        if (dtMsRecord != null && dtMsRecord.Rows.Count > 0)
                        {
                            DataTable dtGradePropertyMS = GlobleFunctionsHelper.fillMicrostructure_Metal_Itemwise_Heat();
                            dtMicrostructureProcess = GlobleFunctionsHelper.SetGradePropertyRecordsMicrostructure_Fill(dtMsRecord, dtGradePropertyMS);
                            dgvMicrostructureElement.AutoGenerateColumns = false;
                            dgvMicrostructureElement.DataSource = dtMicrostructureProcess;
                        }
                        //txtCMin.Text = dtGradeProperty.Rows[0]["Che_Carbon_Min"].ToString();
                        //txtSiMin.Text = dtGradeProperty.Rows[0]["Che_Si_Min"].ToString();
                        //txtMgMin.Text = dtGradeProperty.Rows[0]["Che_Mg_Min"].ToString();
                        //txtMnMin.Text = dtGradeProperty.Rows[0]["Che_Mn_Min"].ToString();
                        //txtSMin.Text = dtGradeProperty.Rows[0]["Che_S_Min"].ToString();
                        //txtPMin.Text = dtGradeProperty.Rows[0]["Che_P_Min"].ToString();
                        //txtCrMin.Text = dtGradeProperty.Rows[0]["Che_Cr_Min"].ToString();
                        //txtNiMin.Text = dtGradeProperty.Rows[0]["Che_Ni_Min"].ToString();
                        //txtMoMin.Text = dtGradeProperty.Rows[0]["Che_Mo_Min"].ToString();
                        //txtCuMin.Text = dtGradeProperty.Rows[0]["Che_Cu_Min"].ToString();
                        //txtTiMin.Text = dtGradeProperty.Rows[0]["Che_Ti_Min"].ToString();
                        //txtAlMin.Text = dtGradeProperty.Rows[0]["Che_Al_Min"].ToString();
                        //txtBMin.Text = dtGradeProperty.Rows[0]["Che_B_Min"].ToString();
                        //txtNBMin.Text = dtGradeProperty.Rows[0]["Che_NB_Min"].ToString();
                        //txtVMin.Text = dtGradeProperty.Rows[0]["Che_V_Min"].ToString();

                        //txtCMax.Text = dtGradeProperty.Rows[0]["Che_Carbon_Max"].ToString();
                        //txtSiMax.Text = dtGradeProperty.Rows[0]["Che_Si_Max"].ToString();
                        //txtMgMax.Text = dtGradeProperty.Rows[0]["Che_Mg_Max"].ToString();
                        //txtMnMax.Text = dtGradeProperty.Rows[0]["Che_Mn_Max"].ToString();
                        //txtSMax.Text = dtGradeProperty.Rows[0]["Che_S_Max"].ToString();
                        //txtPMax.Text = dtGradeProperty.Rows[0]["Che_P_Max"].ToString();
                        //txtCrMax.Text = dtGradeProperty.Rows[0]["Che_Cr_Max"].ToString();
                        //txtNiMax.Text = dtGradeProperty.Rows[0]["Che_Ni_Max"].ToString();
                        //txtMoMax.Text = dtGradeProperty.Rows[0]["Che_Mo_Max"].ToString();
                        //txtCuMax.Text = dtGradeProperty.Rows[0]["Che_Cu_Max"].ToString();
                        //txtTiMax.Text = dtGradeProperty.Rows[0]["Che_Ti_Max"].ToString();
                        //txtAlMax.Text = dtGradeProperty.Rows[0]["Che_Al_Max"].ToString();
                        //txtBMax.Text = dtGradeProperty.Rows[0]["Che_B_Max"].ToString();
                        //txtNBMax.Text = dtGradeProperty.Rows[0]["Che_NB_Max"].ToString();
                        //txtVMax.Text = dtGradeProperty.Rows[0]["Che_V_Max"].ToString();

                        //txtUTSMin.Text = dtGradeProperty.Rows[0]["Me_Carbon_Min"].ToString();
                        //txtYSMin.Text = dtGradeProperty.Rows[0]["Me_Si_Min"].ToString();
                        //txtElongationMin.Text = dtGradeProperty.Rows[0]["Me_Mn_Min"].ToString();
                        //txthardnessMin.Text = dtGradeProperty.Rows[0]["Me_S_Min"].ToString();
                        //txtRAMIn.Text = dtGradeProperty.Rows[0]["Me_Ra_Min"].ToString();
                        //txtBendTestMin.Text = dtGradeProperty.Rows[0]["Me_Bend_Test_Min"].ToString();
                        //txtImpact1Min.Text = dtGradeProperty.Rows[0]["Me_P_Min"].ToString();
                        //txtImpact2Min.Text = dtGradeProperty.Rows[0]["Me_Cr_Min"].ToString();
                        //txtImpact3Min.Text = dtGradeProperty.Rows[0]["Me_Ni_Min"].ToString();
                        //txtAverageImpactMin.Text = dtGradeProperty.Rows[0]["Me_Mo_Min"].ToString();

                        //txtUTSMax.Text = dtGradeProperty.Rows[0]["Me_Carbon_Max"].ToString();
                        //txtYSMax.Text = dtGradeProperty.Rows[0]["Me_Si_Max"].ToString();
                        //txtElongationMax.Text = dtGradeProperty.Rows[0]["Me_Mn_Max"].ToString();
                        //txtHardnessMax.Text = dtGradeProperty.Rows[0]["Me_S_Max"].ToString();
                        //txtRAMax.Text = dtGradeProperty.Rows[0]["Me_Ra_Max"].ToString();
                        //txtBendTestMax.Text = dtGradeProperty.Rows[0]["Me_Bend_Test_Max"].ToString();
                        //txtImpact1Max.Text = dtGradeProperty.Rows[0]["Me_P_Max"].ToString();
                        //txtImpact2Max.Text = dtGradeProperty.Rows[0]["Me_Cr_Max"].ToString();
                        //txtImpact3Max.Text = dtGradeProperty.Rows[0]["Me_Ni_Max"].ToString();
                        //txtAverageImpactMax.Text = dtGradeProperty.Rows[0]["Me_Mo_Max"].ToString();


                        cmbMetalType.Enabled = true;
                        btnAddMetalGrp.Visible = true;
                        txtItemType.Visible = false;
                        lblItemTypeRequired.Visible = false;


                    }
                    #endregion

                    if (IsMaterialMappingFlag)
                    {
                        DataTable dtMetalMateMapp = castingmaster.Fetch_Metal_Material_Mapping();
                        dgvMetalMaterialMapping.AutoGenerateColumns = false;
                        dgvMetalMaterialMapping.DataSource = dtMetalMateMapp;
                        dgvMetalMaterialMapping.Enabled = false;
                    }


                    #region Metal Grade Property

                    //DataTable dtMetalGradeProperty = castingmaster.Fetch_All_Metal_Grade_Property();

                    //try
                    //{
                    //    var results = from myRow in dtMetalGradeProperty.AsEnumerable()
                    //                  where myRow.Field<int>("MetalType") == 0
                    //                  select myRow;

                    //    dtChecmicalProcess.Rows.Clear();
                    //    dtChecmicalProcess = results.CopyToDataTable();
                    //}
                    //catch
                    //{ }

                    //try
                    //{

                    //    var results = from myRow in dtMetalGradeProperty.AsEnumerable()
                    //                  where myRow.Field<int>("MetalType") == 1
                    //                  select myRow;
                    //    dtMechanicalProcess.Rows.Clear();
                    //    dtMechanicalProcess = results.CopyToDataTable();
                    //}
                    //catch
                    //{ }

                    //dgvChemicalElement.AutoGenerateColumns = false;
                    //dgvChemicalElement.DataSource = dtChecmicalProcess;
                    //dgvMechanicalElement.AutoGenerateColumns = false;
                    //dgvMechanicalElement.DataSource = dtMechanicalProcess;


                    #endregion

                    btnSave.Enabled = false;
                    btnSaveMapping.Enabled = false;
                }
            }
            catch
            { }
            #endregion
            
        }

        private void dgvMetal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMetal.RowEnter += dgvMetal_RowEnter;//This line will prevent to call the chkRemoveAllDate_CheckedChanged Event by doing Minus(-)
            dgvMetal_RowEnter(sender, e);
        }
                
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MetalID = -1;
            SearchMetalRecord();
        }

        private void cmbSearchMetal_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbSearchMetal_SelectionChangeCommitted(sender, e);
            }
        }

        int MetalIdFilter = 0;
        private void cmbSearchMetal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
               // MetalIdFilter;
                ComboBox cmb = (ComboBox)sender;
                if (cmb.Text == "")
                {
                    cmb.Text = Helper.DropdownDefaultText.Select;
                }
                if (cmb.SelectedValue != null && Convert.ToInt32(cmb.SelectedValue) > 0)
                {
                    MetalIdFilter = Convert.ToInt32(cmb.SelectedValue);
                }
                else
                {
                    cmb.Text = Helper.DropdownDefaultText.Select;
                    MetalIdFilter = 0;
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSearchFilter_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void btnAddMetalGrp_Click(object sender, EventArgs e)
        {
            txtItemType.Visible = true;
            lblItemTypeRequired.Visible = true;
            cmbMetalType.Enabled = false;
            btnAddMetalGrp.Visible = false;
            txtItemType.Focus();
        }

        DataTable dtMechanicalProcess = new DataTable();
        DataTable dtChecmicalProcess = new DataTable();
        DataTable dtMicrostructureProcess = new DataTable();
        private int currentRow;
        private bool resetRow = false;
        private int McurrentRow;
        private bool MresetRow = false;
        private int MScurrentRow;
        private bool MSresetRow = false;

        private void LoadChemicalMetalDatatable(string MetalElementIdName)
        {
            try
            {
                if (!(dtChecmicalProcess.Columns.Contains(MetalElementIdName)))
                    dtChecmicalProcess.Columns.Add(MetalElementIdName);

                if (!(dtChecmicalProcess.Columns.Contains("Name")))
                    dtChecmicalProcess.Columns.Add("Name");

                if (!(dtChecmicalProcess.Columns.Contains("Minimum")))
                    dtChecmicalProcess.Columns.Add("Minimum");

                if (!(dtChecmicalProcess.Columns.Contains("Maximum")))
                    dtChecmicalProcess.Columns.Add("Maximum");
            }
            catch
            { }
           
        }

        private void LoadMechanicalMetalDatatable(string MetalElementIdName)
        {
            try
            {
                if (!(dtMechanicalProcess.Columns.Contains(MetalElementIdName)))
                    dtMechanicalProcess.Columns.Add(MetalElementIdName);

                if (!(dtMechanicalProcess.Columns.Contains("Name")))
                    dtMechanicalProcess.Columns.Add("Name");

                if (!(dtMechanicalProcess.Columns.Contains("Minimum")))
                    dtMechanicalProcess.Columns.Add("Minimum");

                if (!(dtMechanicalProcess.Columns.Contains("Maximum")))
                    dtMechanicalProcess.Columns.Add("Maximum");
            }
            catch
            { }            
        }

        private void LoadMicrostructureMetalDatatable(string MetalElementIdName)
        {
            try
            {
                if (!(dtMicrostructureProcess.Columns.Contains(MetalElementIdName)))
                    dtMicrostructureProcess.Columns.Add(MetalElementIdName);

                if (!(dtMicrostructureProcess.Columns.Contains("Name")))
                    dtMicrostructureProcess.Columns.Add("Name");

                if (!(dtMicrostructureProcess.Columns.Contains("Minimum")))
                    dtMicrostructureProcess.Columns.Add("Minimum");

                if (!(dtMicrostructureProcess.Columns.Contains("Maximum")))
                    dtMicrostructureProcess.Columns.Add("Maximum");
            }
            catch
            { }
        }
                       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 2)
                {
                    //dgvChemicalElement.AutoGenerateColumns = false;
                    //dgvChemicalElement.DataSource = dtChecmicalProcess;

                    //dgvMechanicalElement.AutoGenerateColumns = false;
                    //dgvMechanicalElement.DataSource = dtMechanicalProcess;
                    
                }
            }
            catch
            { }
        }

        private void dgvChemicalElement_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch
            { }
        }
               
        private void dgvChemicalElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvChemicalElement != null)
            {
                if (dgvChemicalElement.CurrentCell != null)
                {
                    if (dgvChemicalElement.CurrentCell.ColumnIndex != 0)
                    {
                        if (e.KeyChar.ToString() != "-")
                        {
                            e.AllowFloatOnly();
                        }
                    }
                }
            }
        }

        private void dgvChemicalElement_Leave(object sender, EventArgs e)
        {
            try
            {
                // Check for minimum and maximum of value

                for (int row = 0; row < dgvChemicalElement.Rows.Count; row++)
                {
                    if (dgvChemicalElement.CurrentCell.ColumnIndex != 0)
                    {
                        string MinVal = (((dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString()).Trim());
                        string MaxVal = (((dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString()).Trim());
                        double ValueMin = Convert.ToDouble(MinVal);
                        double ValueMax = Convert.ToDouble(MaxVal);

                        if (ValueMax != 0)
                        {
                            if (ValueMax < ValueMin)
                            {
                                string Message = "Property out of range";
                                MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvChemicalElement.Rows[row].Selected = true;
                                dgvChemicalElement.Focus();
                                dgvChemicalElement.SelectedRows[row].Selected = true;
                                resetRow = true;
                                currentRow = row;
                                return;
                            }
                        }
                    }
                }

            }
            catch
            { }
        }
               
        private void dgvChemicalElement_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvChemicalElement_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvChemicalElement_KeyPress);
        }

        private void dgvChemicalElement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChemicalElement.CurrentCell.ColumnIndex != 0)
                {
                    string MinVal = (((dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMinimum"].Value.ToString()).Trim());
                    string MaxVal = (((dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvChemicalElement.Rows[e.RowIndex].Cells["ChemicalMaximum"].Value.ToString()).Trim());
                    double ValueMin = Convert.ToDouble(MinVal);
                    double ValueMax = Convert.ToDouble(MaxVal);


                    if (ValueMax != 0)
                    {
                        if (ValueMax < ValueMin)
                        {
                            string Message = "Property out of range";
                            MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvChemicalElement.Focus();
                            dgvChemicalElement.SelectedRows[e.RowIndex].Selected = true;
                            resetRow = true;
                            currentRow = e.RowIndex;
                            return;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void dgvChemicalElement_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                dgvChemicalElement.CurrentCell = dgvChemicalElement.Rows[currentRow].Cells[0];
            }
        }
        
        private void dgvMechanicalElement_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch
            { }
        }

        private void dgvMechanicalElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMechanicalElement != null)
            {
                if (dgvMechanicalElement.CurrentCell != null)
                {
                    if (dgvMechanicalElement.CurrentCell.ColumnIndex != 0)
                    {
                        if (e.KeyChar.ToString() != "-")
                        {
                            e.AllowFloatOnly();
                        }
                    }
                }
            }
        }

        private void dgvMechanicalElement_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvMechanicalElement_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvMechanicalElement_KeyPress);
        }
       
        private void dgvMechanicalElement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMechanicalElement.CurrentCell.ColumnIndex != 0)
                {
                    string MinVal = (((dgvMechanicalElement.Rows[e.RowIndex].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[e.RowIndex].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.CurrentRow.Cells["MechanicalMinimum"].Value.ToString()).Trim());
                    string MaxVal = (((dgvMechanicalElement.Rows[e.RowIndex].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[e.RowIndex].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.CurrentRow.Cells["MechanicalMaximum"].Value.ToString()).Trim());
                    double ValueMin = Convert.ToDouble(MinVal);
                    double ValueMax = Convert.ToDouble(MaxVal);


                    if (ValueMax != 0)
                    {
                        if (ValueMax < ValueMin)
                        {
                            string Message = "Property out of range";
                            MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch
            { }
        }

        private void dgvMechanicalElement_Leave(object sender, EventArgs e)
        {
            try
            {
                // Check for minimum and maximum of value

                for (int row = 0; row < dgvMechanicalElement.Rows.Count; row++)
                {
                    if (dgvMechanicalElement.CurrentCell.ColumnIndex != 0)
                    {
                        string MinVal = (((dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString()).Trim());
                        string MaxVal = (((dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "" || ((dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString()).Trim());
                        double ValueMin = Convert.ToDouble(MinVal);
                        double ValueMax = Convert.ToDouble(MaxVal);

                        if (ValueMax != 0)
                        {
                            if (ValueMax < ValueMin)
                            {
                                string Message = "Property out of range";
                                MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvMechanicalElement.Rows[row].Selected = true;
                                dgvMechanicalElement.Focus();
                                dgvMechanicalElement.SelectedRows[row].Selected = true;
                                MresetRow = true;
                                McurrentRow = row;
                                return;
                            }
                        }
                    }
                }

            }
            catch
            { }
        }

        private void dgvMechanicalElement_SelectionChanged(object sender, EventArgs e)
        {
            if (MresetRow)
            {
                MresetRow = false;
                dgvMechanicalElement.CurrentCell = dgvMechanicalElement.Rows[McurrentRow].Cells[0];
            }
        }

        #region Metal Mapping

        private Guid ItemType { get; set; }
        private Guid ItemCategory { get; set; }
        private Guid ItemGroup { get; set; }
       
        #region Method TO Fill Combobox

        public void Fill_Item_Type()
        {
            try
            {
                clsPurchaseItemTypeCategoryGroupMaster purchaseItemTypeCategoryGroupMaster = new clsPurchaseItemTypeCategoryGroupMaster();
                DataTable dtFetchItemType = purchaseItemTypeCategoryGroupMaster.Fetch_PurchaseItem_Type_Details();

                if (!dtFetchItemType.IsNullOrEmpty())
                {
                    dtFetchItemType.AddSelectRow(0, 2);
                    cmbItemType.DataSource = dtFetchItemType;
                    cmbItemType.ValueMember = "PurchaseItemTypeId";
                    cmbItemType.DisplayMember = "TypeName";
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Fill_Item_Category()
        {
            try
            {
                clsPurchaseItemTypeCategoryGroupMaster purchaseItemTypeCategoryGroupMaster = new clsPurchaseItemTypeCategoryGroupMaster();
                DataTable dtFetchItemCategory = purchaseItemTypeCategoryGroupMaster.Fetch_PurchaseItem_Category_Details();

                if (!dtFetchItemCategory.IsNullOrEmpty())
                {
                    dtFetchItemCategory.AddSelectRow(0, 2);
                    cmbItemSubgroup.DataSource = dtFetchItemCategory;
                    cmbItemSubgroup.ValueMember = "PurchaseItemCategoryId";
                    cmbItemSubgroup.DisplayMember = "CategoryName";
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Fill_Item_Group()
        {
            try
            {
                clsPurchaseItemTypeCategoryGroupMaster purchaseItemTypeCategoryGroupMaster = new clsPurchaseItemTypeCategoryGroupMaster();
                DataTable dtFetchItemGroup = purchaseItemTypeCategoryGroupMaster.Fetch_PurchaseItem_Group_Details();

                if (!dtFetchItemGroup.IsNullOrEmpty())
                {
                    dtFetchItemGroup.AddSelectRow(0, 2);
                    cmbItemGroup.DataSource = dtFetchItemGroup;
                    cmbItemGroup.ValueMember = "PurchaseItemGroupId";
                    cmbItemGroup.DisplayMember = "GroupName";
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Fill_Item_Name()
        {
            try
            {
                clsPurchaseItemMaster itemMaster = new clsPurchaseItemMaster();
                DataTable dtItemName = new DataTable();
                dtItemName = itemMaster.FetchItemName(); //itemMaster.Fetch_ItemNameItemCode();
                dtItemName.AddSelectRow(0, 0);

                if (!dtItemName.IsNullOrEmpty())
                {
                    cmbItemName.DataSource = dtItemName;
                    cmbItemName.DisplayMember = "ItemName";
                    cmbItemName.ValueMember = "ItemName";
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Fill_Item_Code()
        {
            try
            {
                clsPurchaseItemMaster itemMaster = new clsPurchaseItemMaster();

                DataTable dtItemCode = new DataTable();

                dtItemCode = itemMaster.Fetch_ItemCode_from_ItemName();

                dtItemCode.AddSelectRow(0, 1);

                if (!dtItemCode.IsNullOrEmpty())
                {
                    cmbItemCode.DataSource = dtItemCode;

                    cmbItemCode.DisplayMember = "ItemCode";

                    cmbItemCode.ValueMember = "PurchaseItemId";

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Fill_Item_Detail()
        {
            clsPurchaseItemMaster objitemmaster = new clsPurchaseItemMaster();
            if (ItemType != null && ItemType != Guid.Empty)
                objitemmaster.PurchaseItemTypeId = ItemType;
            if (ItemCategory != null && ItemCategory != Guid.Empty)
                objitemmaster.PurchaseItemCategoryId = ItemCategory;
            if (ItemGroup != null && ItemGroup != Guid.Empty)
                objitemmaster.PurchaseItemGroupId = ItemGroup;
            DataTable dtFetchItemDetail = objitemmaster.FetchItemDetail();

            if (!dtFetchItemDetail.IsNullOrEmpty())
            {
                DataTable dtFetchItemName = dtFetchItemDetail.Copy();
                dtFetchItemDetail.AddSelectRow(0, 1);
                cmbItemCode.DataSource = dtFetchItemDetail;
                cmbItemCode.ValueMember = "PurchaseItemId";
                cmbItemCode.DisplayMember = "ItemCode";

                if (dtFetchItemDetail.Rows.Count == 2)
                {
                    cmbItemCode.SelectedValue = dtFetchItemDetail.Rows[1]["PurchaseItemId"].ToString();
                }

                if (!dtFetchItemName.IsNullOrEmpty())
                {
                    dtFetchItemName.AddSelectRow(2, 2);
                    cmbItemName.DataSource = dtFetchItemName;
                    cmbItemName.ValueMember = "ItemName";
                    cmbItemName.DisplayMember = "ItemName";

                    if (dtFetchItemName.Rows.Count == 2)
                    {
                        cmbItemName.SelectedValue = dtFetchItemName.Rows[1]["ItemName"].ToString();
                    }
                }
            }
            else
            {
                cmbItemCode.DataSource = null;
                cmbItemName.DataSource = null;
            }
        }

        #endregion

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue == null || cmbItemName.SelectedValue.ToString() == string.Empty || cmbItemName.SelectedValue.ToString() == Helper.DropdownDefaultText.Select)
            {
                const string type = "Select item name";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                cmbItemName.Focus();
                return;
            }

            if (cmbItemCode.SelectedValue == null || cmbItemCode.SelectedValue.ToString() == string.Empty || cmbItemCode.SelectedValue.ToString() == Helper.DropdownDefaultText.Select || Guid.Parse(cmbItemCode.SelectedValue.ToString()) == Guid.Empty)
            {
                const string type = "Select item code";
                System.Windows.Forms.MessageBox.Show(type, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK);
                cmbItemCode.Focus();
                return;
            }

            string ItemNames = "";
            string GrdItemNames = "";
            string GrdItemCode = "";
            Guid PurchaseItemID = Guid.Empty;


            if (cmbItemName.SelectedValue != null && cmbItemName.SelectedValue.ToString() != string.Empty && cmbItemName.SelectedValue.ToString() != Helper.DropdownDefaultText.Select)
            {
                ItemNames = cmbItemName.SelectedValue.ToString();
                GrdItemNames = ItemNames;
            }

            if (cmbItemCode.SelectedValue != null && cmbItemCode.SelectedValue.ToString() != string.Empty && cmbItemCode.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbItemCode.SelectedValue.ToString()) != Guid.Empty)
            {
                PurchaseItemID = Guid.Parse(cmbItemCode.SelectedValue.ToString());
                GrdItemCode = cmbItemCode.Text.ToString();
            }

            if (PurchaseItemID != null)
            {
                if (PurchaseItemID != Guid.Empty)
                {
                    DataTable dtTopDownSprue = new DataTable();
                    DataRow drTopDownSprue;

                    if (dtTopDownSprue.Columns.Count == 0)
                    {
                        dtTopDownSprue.Columns.Add("ItemName");
                        dtTopDownSprue.Columns.Add("ItemCode");
                        dtTopDownSprue.Columns.Add("PurchaseItemID");
                    }

                    for (int i = 0; i < dgvMetalMaterialMapping.Rows.Count; i++)
                    {
                        Guid GrdPurchaseID = Guid.Parse(dgvMetalMaterialMapping.Rows[i].Cells["PurchaseItemID"].Value.ToString());
                        if (GrdPurchaseID == PurchaseItemID)
                        {
                            MessageBox.Show("This Item already exist", Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        drTopDownSprue = dtTopDownSprue.NewRow();
                        drTopDownSprue["ItemName"] = dgvMetalMaterialMapping.Rows[i].Cells["ItemName"].Value;
                        drTopDownSprue["ItemCode"] = dgvMetalMaterialMapping.Rows[i].Cells["ItemCode"].Value;
                        drTopDownSprue["PurchaseItemID"] = dgvMetalMaterialMapping.Rows[i].Cells["PurchaseItemID"].Value;
                        dtTopDownSprue.Rows.Add(drTopDownSprue);
                    }


                    drTopDownSprue = dtTopDownSprue.NewRow();
                    drTopDownSprue["ItemName"] = GrdItemNames;
                    drTopDownSprue["ItemCode"] = GrdItemCode;
                    drTopDownSprue["PurchaseItemID"] = PurchaseItemID;

                    dtTopDownSprue.Rows.Add(drTopDownSprue);

                    if (!dtTopDownSprue.IsNullOrEmpty())
                    {
                        dgvMetalMaterialMapping.DataSource = dtTopDownSprue;
                    }

                    ClearMetalMaterialMappingDetail();
                    cmbItemGroup.Focus();
                    // dgvMetalMaterialMapping.Rows.Add();

                }
            }
        }

        private void ClearMetalMaterialMappingDetail()
        {
            try
            {
                cmbItemGroup.SelectedIndex = 0;
                cmbItemSubgroup.SelectedIndex = 0;
                cmbItemType.SelectedIndex = 0;
                cmbItemName.SelectedIndex = 0;
                cmbItemCode.SelectedIndex = 0;
            }
            catch
            { }
        }


        #region PreviewKeydown and SelectionCommited

        private void cmbItemGroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbItemGroup_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbItemGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemGroup.SelectedValue != null && cmbItemGroup.SelectedValue.ToString() != string.Empty && cmbItemGroup.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbItemGroup.SelectedValue.ToString()) != Guid.Empty)
            {
                ItemGroup = Guid.Parse(cmbItemGroup.SelectedValue.ToString());
            }
            else
            {
                ItemGroup = Guid.Empty;
            }

            Fill_Item_Detail();
        }

        private void cmbItemSubgroup_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbItemSubgroup_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbItemSubgroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemSubgroup.SelectedValue != null && cmbItemSubgroup.SelectedValue.ToString() != string.Empty && cmbItemSubgroup.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbItemSubgroup.SelectedValue.ToString()) != Guid.Empty)
            {
                ItemCategory = Guid.Parse(cmbItemSubgroup.SelectedValue.ToString());
            }
            else
            {
                ItemCategory = Guid.Empty;
            }
            Fill_Item_Detail();
        }

        private void cmbItemType_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbItemType_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemType.SelectedValue != null && cmbItemType.SelectedValue.ToString() != string.Empty && cmbItemType.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbItemType.SelectedValue.ToString()) != Guid.Empty)
            {
                ItemType = Guid.Parse(cmbItemType.SelectedValue.ToString());
            }
            else
            {
                ItemType = Guid.Empty;
            }
            Fill_Item_Detail();
        }

        private void cmbItemName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbItemCode_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbItemName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue != null && cmbItemName.SelectedValue.ToString() != string.Empty && cmbItemName.SelectedValue.ToString() != Helper.DropdownDefaultText.Select)
            {
                clsPurchaseItemMaster objpuchasitem = new clsPurchaseItemMaster();
                objpuchasitem.Item_Name = cmbItemName.SelectedValue.ToString();
                DataTable dtFetchItemCode = objpuchasitem.Fetch_ItemCode_from_ItemName();
                if (!dtFetchItemCode.IsNullOrEmpty())
                {
                    dtFetchItemCode.AddSelectRow(0, 1);
                    cmbItemCode.DataSource = dtFetchItemCode;
                    cmbItemCode.ValueMember = "PurchaseItemId";
                    cmbItemCode.DisplayMember = "ItemCode";

                    if (dtFetchItemCode.Rows.Count == 2)
                        cmbItemCode.SelectedValue = dtFetchItemCode.Rows[1]["PurchaseItemId"].ToString();
                }
            }
        }

        private void cmbItemCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbItemCode_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbItemCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemCode.SelectedValue != null && cmbItemCode.SelectedValue.ToString() != string.Empty && cmbItemCode.SelectedValue.ToString() != Helper.DropdownDefaultText.Select && Guid.Parse(cmbItemCode.SelectedValue.ToString()) != Guid.Empty)
            {
                clsPurchaseItemMaster objpuchasitem = new clsPurchaseItemMaster();
                objpuchasitem.purchaseItemID = Guid.Parse(cmbItemCode.SelectedValue.ToString());
                DataTable dtFetchItemName = objpuchasitem.FetchItemNameByItemCode();
                if (!dtFetchItemName.IsNullOrEmpty())
                {
                    dtFetchItemName.AddSelectRow(0, 0);
                    cmbItemName.DataSource = dtFetchItemName;
                    cmbItemName.ValueMember = "ItemName";
                    cmbItemName.DisplayMember = "ItemName";

                    if (dtFetchItemName.Rows.Count == 2)
                        cmbItemName.SelectedValue = dtFetchItemName.Rows[1]["ItemName"].ToString();
                }
            }
        }

        #endregion

        private void dgvMetalMaterialMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                   // DownSprueTopId = e.RowIndex;

                    if (dgvMetalMaterialMapping.Columns[e.ColumnIndex].Name == "DeleteMetalMapping")         //For Delete 
                    {
                        if (System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.DeleteConfirm, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dgvMetalMaterialMapping.Rows.RemoveAt(e.RowIndex);
                            btnSaveMapping.Text = Helper.ButtonCaptions.Add;
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            ClearMetalMaterialMappingDetail();
        }

        private void dgvChemicalElement_Enter(object sender, EventArgs e)
        {
            try
            {
                if (dgvChemicalElement.Rows.Count > 0)
                {
                    dgvChemicalElement.CurrentCell = dgvChemicalElement[1, 0];
                }
            }
            catch
            { }
        }

        private void dgvMechanicalElement_Enter(object sender, EventArgs e)
        {
            try
            {
                if (dgvMechanicalElement.Rows.Count > 0)
                {
                    dgvMechanicalElement.CurrentCell = dgvMechanicalElement[1, 0];
                }
            }
            catch
            { }
        }

        private void lnkAddChemicalMetal_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DataTable dtChecmical = new DataTable();
                //clsMetalElementMaster clMetalEleMaster = new clsMetalElementMaster();
                //clMetalEleMaster.ElementType = 0;
              //  dtChecmical = clMetalEleMaster.Fetch_Metal_Element_Details();

                clsValues.Instance.FullScreenOff = 1;
                LoadChemicalMetalDatatable("ChemicalMetalElementId");


                if (dtChecmicalProcess != null)
                {
                    if (dtChecmicalProcess.Rows.Count > 0)
                    {
                        if (dgvChemicalElement.DataSource != null)
                        {
                            for (int row = 0; row < dgvChemicalElement.Rows.Count; row++)
                            {
                                dtChecmicalProcess.Rows[row]["Minimum"] = dgvChemicalElement.Rows[row].Cells["ChemicalMinimum"].Value.ToString();
                                dtChecmicalProcess.Rows[row]["Maximum"] = dgvChemicalElement.Rows[row].Cells["ChemicalMaximum"].Value.ToString();
                            }
                        }
                    }
                }

                MetalElementProcess objitemtype = new MetalElementProcess();
                objitemtype.MinimizeBox = false;
                objitemtype.MaximizeBox = false;
                objitemtype.ShowInTaskbar = false;
                objitemtype.IsChemical = 0;
                objitemtype.dtChecmicalProcess = dtChecmicalProcess;
                //objitemtype.dttSuplier = dtCust;
                objitemtype.ShowDialog();
                dtChecmicalProcess = objitemtype.dtChecmicalProcess;

                dgvChemicalElement.AutoGenerateColumns = false;
                dgvChemicalElement.DataSource = dtChecmicalProcess;
                //bool isSave = objitemtype.isSave;
                clsValues.Instance.FullScreenOff = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkAddMechanicalMetal_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DataTable dtMechanical = new DataTable();
                //clsMetalElementMaster clMetalEleMaster = new clsMetalElementMaster();
               // clMetalEleMaster.ElementType = 1;
               // dtMechanical = clMetalEleMaster.Fetch_Metal_Element_Details();

                clsValues.Instance.FullScreenOff = 1;
                LoadMechanicalMetalDatatable("MechanicalMetalElementId");


                if (dtMechanicalProcess != null)
                {
                    if (dtMechanicalProcess.Rows.Count > 0)
                    {
                        if (dgvMechanicalElement.DataSource != null)
                        {
                            for (int row = 0; row < dgvMechanicalElement.Rows.Count; row++)
                            {
                                dtMechanicalProcess.Rows[row]["Minimum"] = dgvMechanicalElement.Rows[row].Cells["MechanicalMinimum"].Value.ToString();
                                dtMechanicalProcess.Rows[row]["Maximum"] = dgvMechanicalElement.Rows[row].Cells["MechanicalMaximum"].Value.ToString();
                            }
                        }
                    }
                }

                MetalElementProcess objitemtype = new MetalElementProcess();
                objitemtype.MinimizeBox = false;
                objitemtype.MaximizeBox = false;
                objitemtype.ShowInTaskbar = false;
                objitemtype.IsChemical = 1;
                objitemtype.dtMechanicalProcess = dtMechanicalProcess;

                objitemtype.ShowDialog();
                dtMechanicalProcess = objitemtype.dtMechanicalProcess;
                dgvMechanicalElement.AutoGenerateColumns = false;
                dgvMechanicalElement.DataSource = dtMechanicalProcess;

                clsValues.Instance.FullScreenOff = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChemicalElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lnkAddMechanicalMetal.Focus();
            }
        }

        private void dgvMechanicalElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgvMicrostructureElement.Focus();
            }
        }

        private void txtdensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.AllowFloatOnly();
        }

        private void cmbMetalType_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                cmbMetalType_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbMetalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
               // Fetch_MetalMaster_Last_Density()
                try
                {

                    ComboBox cmb = (ComboBox)sender;

                    if (cmb.Text == string.Empty)
                    {
                        cmb.Text = Helper.DropdownDefaultText.Select;                      
                    }

                    if (cmb.SelectedValue != null && cmb.SelectedValue.ToString() != "" )
                    {
                        txtdensity.Text = "";
                        clsCastingMaster objCastingMstr = new clsCastingMaster();
                        objCastingMstr.MetalType = cmb.Text.ToString();
                        DataTable dtMetalDensity = objCastingMstr.Fetch_MetalMaster_Last_Density();

                        if (dtMetalDensity != null)
                        {
                            if (dtMetalDensity.Rows.Count > 0)
                            {
                                string Mtld = dtMetalDensity.Rows[0]["MetalDensity"].ToString();
                                Mtld = Mtld.Trim();
                                if (Mtld != "")
                                {
                                    txtdensity.Text = dtMetalDensity.Rows[0]["MetalDensity"].ToString();
                                }
                            }
                        }

                    }
                    else
                    {
                        cmb.Text = Helper.DropdownDefaultText.Select;                        
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.LogException(ex);
                    System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            { }
        }

        #region Microstucture

        #endregion

        private void dgvMicrostructureElement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMicrostructureElement.CurrentCell.ColumnIndex != 0)
                {
                    string MinVal = (((dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMinimum"].Value.ToString()).Trim());
                    string MaxVal = (((dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[e.RowIndex].Cells["MicrostructureMaximum"].Value.ToString()).Trim());
                    double ValueMin = Convert.ToDouble(MinVal);
                    double ValueMax = Convert.ToDouble(MaxVal);


                    if (ValueMax != 0)
                    {
                        if (ValueMax < ValueMin)
                        {
                            string Message = "Property out of range";
                            MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvMicrostructureElement.Focus();
                            dgvMicrostructureElement.SelectedRows[e.RowIndex].Selected = true;
                            MSresetRow = true;
                            MScurrentRow = e.RowIndex;
                            return;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void dgvMicrostructureElement_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch
            { }
        }
                
        private void dgvMicrostructureElement_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvMicrostructureElement_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvMicrostructureElement_KeyPress);
        }

        private void dgvMicrostructureElement_Enter(object sender, EventArgs e)
        {
            try
            {
                if (dgvMicrostructureElement.Rows.Count > 0)
                {
                    dgvMicrostructureElement.CurrentCell = dgvMicrostructureElement[1, 0];
                }
            }
            catch
            { }
        }

        private void dgvMicrostructureElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnNext.Focus();
            }
        }

        private void dgvMicrostructureElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMicrostructureElement != null)
            {
                if (dgvMicrostructureElement.CurrentCell != null)
                {
                    if (dgvMicrostructureElement.CurrentCell.ColumnIndex != 0)
                    {
                        if (e.KeyChar.ToString() != "-")
                        {
                            e.AllowFloatOnly();
                        }
                    }
                }
            }
        }

        private void dgvMicrostructureElement_Leave(object sender, EventArgs e)
        {
            try
            {
                // Check for minimum and maximum of value

                for (int row = 0; row < dgvMicrostructureElement.Rows.Count; row++)
                {
                    if (dgvMicrostructureElement.CurrentCell.ColumnIndex != 0)
                    {
                        string MinVal = (((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[row].Cells["MicrostructureMinimum"].Value.ToString()).Trim());
                        string MaxVal = (((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "" || ((dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim()) == "-" ? "0" : (dgvMicrostructureElement.Rows[row].Cells["MicrostructureMaximum"].Value.ToString()).Trim());
                        double ValueMin = Convert.ToDouble(MinVal);
                        double ValueMax = Convert.ToDouble(MaxVal);

                        if (ValueMax != 0)
                        {
                            if (ValueMax < ValueMin)
                            {
                                string Message = "Property out of range";
                                MessageBox.Show(Message, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvMicrostructureElement.Rows[row].Selected = true;
                                dgvMicrostructureElement.Focus();
                                dgvMicrostructureElement.SelectedRows[row].Selected = true;
                                MSresetRow = true;
                                MScurrentRow = row;
                                return;
                            }
                        }
                    }
                }

            }
            catch
            { }
        }

        private void dgvMicrostructureElement_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                dgvMicrostructureElement.CurrentCell = dgvMicrostructureElement.Rows[MScurrentRow].Cells[0];
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
