using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace TestingSystems.App_Data
{
    public class clsConfigaration
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public bool LossActualorFix { get; set; }
        public bool VatRoundOff { get; set; }
        public Double LossFixValue { get; set; }        
        public int IsSandCasting { get; set; }
        public int IsDieCasting { get; set; }
        public int IsInvestmentCasting { get; set; }
        public int IsLostForm { get; set; }
        
        public int invMethod { get; set; }
        public Double FunrnaceMultiplicationFactor { get; set; }
        public Double ElectricMeterMultiplicationFactor { get; set; }
        public bool HeatNoPrintInInvoice { get; set; }
        public bool CastNoPrintInInvoice { get; set; }
        public bool PrintServiceItemInChallan { get; set; }
        public bool ISONoPrinted { get; set; }
        public bool PerPcWeightPrinted { get; set; }
        public bool DisplayTransaction { get; set; }
        public bool DisplayHeatCode { get; set; }
        public bool DisplayGradeInInvoice { get; set; }
        public bool DisplayDrawingNoInInvoice { get; set; }
        public bool DisplayCastingCodeInInvoice { get; set; }
        public bool DisplayLineNoInInvoice { get; set; }
        public bool DisplayWeightInPackingList { get; set; }
        public bool DisplayOrderDate { get; set; }
        public bool DisplayItemDescription { get; set; }
        public bool DisplayCustomerCode { get; set; }
        public bool DisplayTotalWeightInInvoice { get; set; }
        public bool DisplayCurrencyRoundOff { get; set; }
        public bool PrintManualItemName { get; set; }
        public bool DummyAttendanceSheet { get; set; }
        public bool DisplayAllProcess { get; set; }
        public bool RejAll { get; set; }
        public bool SameExportAndInvoiceNo { get; set; }
        public bool StockDeductInInvoice { get; set; }
        public Int32 InvoiceSeries { get; set; }
        public Int32 ExportInvoiceSeries { get; set; }
        public bool DisplayHeatCodeInInvoice { get; set; }
        public Int32 AutoGRNSeries { get; set; }

        public bool MoldPlan { get; set; }
        public bool CorePlan { get; set; }
        public bool AllProcess { get; set; } //if true then Display All Process in process rework page else only production process 

        public bool IsSandMixEnable { get; set; }
        public bool IsPerCavityMoldEnable { get; set; }

        //added by yashvi
        public bool GeneratePatternAccordingTo { get; set; }
        public bool PrintCustomerNameInWO { get; set; }

        public Int32 TotalWorkingHours { get; set; }
        public Int32 TotalShiftPerDay { get; set; }
        public Double ExtraProductionPer { get; set; }

        public String EmailAddress { get; set; }
        public String ServerAddress { get; set; }
        public String Port { get; set; }
        public String EmailPassword { get; set; }
        public DataTable dtEmailSetting { get; set; }
        public DataTable dtExportSetting { get; set; }

        public DataTable dtConfig { get; set; }

        public Int32 ExportImageDisplayId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Double DrawbackDutyPer { get; set; }
        public bool ApproveLevel { get; set; }
        public DataTable dtLevel1 { get; set; }
        public DataTable dtLevel2 { get; set; }
        public bool PrefixLevel { get; set; }
        public bool Dispatchfromprocess { get; set; }
        public bool IsConsumptionEditable { get; set; }
        public bool FetchNextInhouseProcessEditable { get; set; }
        public Int32 MetaltoSandRatio { get; set; }


        //added

        public Int32 ExportSeriesId { get; set; }
        public Int32 DomSeriesID { get; set; }
        public String DomPrefix { get; set; }
        public String DomSuffix { get; set; }
        public String DomSeparator { get; set; }
        public DateTime DomApplyDate { get; set; }

        private string _Password;


        public string Password
        {
            get { return _Password; }

            set { _Password = clsEncrypt.MD5Hash(value); }
        }

        public String filepath { get; set; }

        public Double POFirstLevelApprovalAmount { get; set; }
        public Double POSecondLevelApprovalAmount { get; set; }
        public bool DisplayDrawingNoInOrder { get; set; }
        public bool DisplayMoldTypeInOrder { get; set; }
        public bool DisplaySandTypeInOrder { get; set; }
        public bool DisplayCastingCodeInOrder { get; set; }
        public Int32 InvoiceTaxable { get; set; }
        public Double InvoiceTaxableRate { get; set; }
        public Int32 NoOfHeatinaDay { get; set; }
        public bool AllowAdditionalInward { get; set; }

        public bool EnableTaxesCalculationInCO { get; set; }
        public bool EnableTaxesCalculationInPO { get; set; }
        public bool CommercialInvoiceRoundoff { get; set; }
        public Int32 Type { get; set; }
        public Int32 ReminderTimeMinute { get; set; }
        public Int32 SeriesID { get; set; }
        public bool DescriptionRequirementEnable { get; set; }
        public bool RequirementEnable { get; set; }
        public bool RateEditableInInvoice { get; set; }
        public bool PrintToleranceInOA { get; set; }
        public bool PrintToleranceInPO { get; set; }
        public bool BatchNoWhenShelLife { get; set; }
        public Int32 FinancialYear { get; set; } //Start Month of FY
        public String UOM { get; set; }
        
        public DataTable dtOASampleApprove { get; set; }
        public clsConfigaration()
        {
            con = obj.Con();
        }
        public DataTable FetchAllConfigarationSettings()        //Fetch JONo
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.Parameters.AddWithValue("@Parameter", 2);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public DataTable FetchAllConfigarationSettingsProdcutinMethod()        //Fetch Production Method
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.Parameters.AddWithValue("@Parameter", 17);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }
        
        public Int32 UpdateConfigurationSetting()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 3);
                cmd.Parameters.AddWithValue("@LossActualorFix", LossActualorFix);
                cmd.Parameters.AddWithValue("@LossFixValue", LossFixValue);               
                cmd.Parameters.AddWithValue("@invMethod", invMethod);
                cmd.Parameters.AddWithValue("@FunrnaceMultiplicationFactor", FunrnaceMultiplicationFactor);
                cmd.Parameters.AddWithValue("@ElectricMeterMultiplicationFactor", ElectricMeterMultiplicationFactor);
                cmd.Parameters.AddWithValue("@HeatNoPrintInInvoice", HeatNoPrintInInvoice);
                cmd.Parameters.AddWithValue("@CastNoPrintInInvoice", CastNoPrintInInvoice);
                cmd.Parameters.AddWithValue("@PrintServiceItemInChallan", PrintServiceItemInChallan);
                cmd.Parameters.AddWithValue("@VatRoundOff", VatRoundOff);
                cmd.Parameters.AddWithValue("@ISONoPrinted", ISONoPrinted);
                cmd.Parameters.AddWithValue("@PerPcWeightPrinted", PerPcWeightPrinted);
                cmd.Parameters.AddWithValue("@DisplayTransaction", DisplayTransaction);
                cmd.Parameters.AddWithValue("@DisplayHeatCode", DisplayHeatCode);
                cmd.Parameters.AddWithValue("@DisplayGradeInInvoice", DisplayGradeInInvoice);
                cmd.Parameters.AddWithValue("@DisplayCastingCodeInInvoice", DisplayCastingCodeInInvoice);
                cmd.Parameters.AddWithValue("@DisplayDrawingNoInInvoice", DisplayDrawingNoInInvoice);
                cmd.Parameters.AddWithValue("@DisplayLineNoInInvoice", DisplayLineNoInInvoice);
                cmd.Parameters.AddWithValue("@DisplayWeightInPackingList", DisplayWeightInPackingList);
                //cmd.Parameters.AddWithValue("@DisplayOrderDate", DisplayOrderDate);
                cmd.Parameters.AddWithValue("@DisplayItemDescription", DisplayItemDescription);
                cmd.Parameters.AddWithValue("@DisplayCustomerCode", DisplayCustomerCode);
                cmd.Parameters.AddWithValue("@DisplayTotalWeightInInvoice", DisplayTotalWeightInInvoice);
                cmd.Parameters.AddWithValue("@DisplayCurrencyRoundOff", DisplayCurrencyRoundOff);
                cmd.Parameters.AddWithValue("@PrintManualItemName", PrintManualItemName);
                cmd.Parameters.AddWithValue("@DummyAttendanceSheet", DummyAttendanceSheet);
                cmd.Parameters.AddWithValue("@DisplayAllProcess", DisplayAllProcess);
                cmd.Parameters.AddWithValue("@InvoiceSeries", InvoiceSeries);
                cmd.Parameters.AddWithValue("@DisplayHeatCodeInInvoice", DisplayHeatCodeInInvoice);
                cmd.Parameters.AddWithValue("@TotalWorkingHours", TotalWorkingHours);
                cmd.Parameters.AddWithValue("@TotalShiftPerDay", TotalShiftPerDay);
                cmd.Parameters.AddWithValue("@ExtraProductionPer", ExtraProductionPer);
                cmd.Parameters.AddWithValue("@PrefixLevel", PrefixLevel);
                cmd.Parameters.AddWithValue("@DispatchFromProcess", Dispatchfromprocess);
                cmd.Parameters.AddWithValue("@IsConsumptionEditable", IsConsumptionEditable);
                cmd.Parameters.AddWithValue("@MetaltoSandRatio", MetaltoSandRatio);
                cmd.Parameters.AddWithValue("@FetchNextProcessInInhouseProcess", FetchNextInhouseProcessEditable);
                cmd.Parameters.AddWithValue("@DisplayDrawingNoInOrder", DisplayDrawingNoInOrder);
                cmd.Parameters.AddWithValue("@DisplayMoldTypeInOrder", DisplayMoldTypeInOrder);
                cmd.Parameters.AddWithValue("@DisplaySandTypeInOrder", DisplaySandTypeInOrder);
                cmd.Parameters.AddWithValue("@DisplayCastingCodeInOrder",DisplayCastingCodeInOrder);
                cmd.Parameters.AddWithValue("@InvoiceTaxable", InvoiceTaxable);
                cmd.Parameters.AddWithValue("@InvoiceTaxableRate", InvoiceTaxableRate);
                cmd.Parameters.AddWithValue("@NoOfHeatinaDay", NoOfHeatinaDay);
                cmd.Parameters.AddWithValue("@AllowAdditionalInward", AllowAdditionalInward);
                cmd.Parameters.AddWithValue("@EnableTaxesCalculationInCO", EnableTaxesCalculationInCO);
                cmd.Parameters.AddWithValue("@EnableTaxesCalculationInPO", EnableTaxesCalculationInPO);
                cmd.Parameters.AddWithValue("@ReminderTimeMinute", ReminderTimeMinute);
                cmd.Parameters.AddWithValue("@SeriesID", AutoGRNSeries);
                cmd.Parameters.AddWithValue("@RequirementEnable", RequirementEnable);
                cmd.Parameters.AddWithValue("@DescriptionRequirementEnable", DescriptionRequirementEnable);
                cmd.Parameters.AddWithValue("@RateEditableInInvoice", RateEditableInInvoice);
                cmd.Parameters.AddWithValue("@PrintToleranceInOA", PrintToleranceInOA);
                cmd.Parameters.AddWithValue("@PrintToleranceInPO", PrintToleranceInPO);
                cmd.Parameters.AddWithValue("@GeneratePatternAccordingTo", GeneratePatternAccordingTo);
                cmd.Parameters.AddWithValue("@IsSandMixEnable", IsSandMixEnable);
                cmd.Parameters.AddWithValue("@IsPerCavityMoldEnable", IsPerCavityMoldEnable);
                cmd.Parameters.AddWithValue("@BatchNoWhenShelLife", BatchNoWhenShelLife);


                cmd.Parameters.AddWithValue("@IsSandCasting", IsSandCasting);
                cmd.Parameters.AddWithValue("@IsDieCasting", IsDieCasting);
                cmd.Parameters.AddWithValue("@IsInvestmentCasting", IsInvestmentCasting);
                cmd.Parameters.AddWithValue("@IsLostForm", IsLostForm);

                cmd.Parameters.AddWithValue("@UOM", UOM);
                cmd.Parameters.AddWithValue("@FinancialYear", FinancialYear);

                cmd.Parameters.AddWithValue("@PrintCustNameInWO", PrintCustomerNameInWO);

                
                //cmd.Parameters.AddWithValue("@Password", EmailPassword);
                //cmd.Parameters.AddWithValue("@Port", Port);
                cmd.ExecuteNonQuery();
                //result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }

            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int SuperAdminPasswordCheck()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "ConfigurationSetting";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@SuperAdminPassword", _Password);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    // clsValues.Instance.User_Name = dt.Rows[0]["username"].ToString();
                    // session.UserId = Convert.ToInt32(dt.Rows[0]["userid"].ToString());
                    return 1;
                }
                else
                    return 0;


            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        public DataSet FetchCompanyMasterEmailDetail()        //Fetch JONo
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.Parameters.AddWithValue("@Parameter", 5);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ds;
            }
        }

        public Int32 UpdateEmailSetting()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 6);


                string XMLEmail = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (dtEmailSetting != null)
                    {
                        dtEmailSetting.TableName = "EmailSetting";

                        dtEmailSetting.WriteXml(stringWriter);

                        XMLEmail = stringWriter.ToString();
                    }
                }
                cmd.Parameters.AddWithValue("@Email", XMLEmail);

                cmd.ExecuteNonQuery();
                //result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }

            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public Int32 UpdateExportSetting()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 8);


                string XMLExport = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (dtExportSetting != null)
                    {
                        dtExportSetting.TableName = "ExportSetting";

                        dtExportSetting.WriteXml(stringWriter);

                        XMLExport = stringWriter.ToString();
                    }
                }

                cmd.Parameters.AddWithValue("@Export", XMLExport);

                cmd.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);

                cmd.Parameters.AddWithValue("@DrawbackDutyPer", DrawbackDutyPer);

                cmd.Parameters.AddWithValue("@SameExportAndInvoiceNo", SameExportAndInvoiceNo);

                cmd.Parameters.AddWithValue("@StockDeductInInvoice", StockDeductInInvoice);

                cmd.Parameters.AddWithValue("@ExportInvoiceSeries", ExportInvoiceSeries);

                cmd.Parameters.AddWithValue("@DisplayOrderDate", DisplayOrderDate);

                cmd.Parameters.AddWithValue("@CommercialInvoiceRoundoff", CommercialInvoiceRoundoff);

                //added
                if (ExportSeriesId != 0)
                    cmd.Parameters.AddWithValue("@ExportSeriesId", ExportSeriesId);
               
                if(DomSeriesID != 0)
                    cmd.Parameters.AddWithValue("@DomSeriesId", DomSeriesID);

                cmd.Parameters.AddWithValue("@DomPrefix", DomPrefix);
                cmd.Parameters.AddWithValue("@DomSuffix", DomSuffix);
                cmd.Parameters.AddWithValue("@DomSeparator", DomSeparator);
                cmd.Parameters.AddWithValue("@DomApplyDate",DomApplyDate);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }

            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public DataTable FetchExportSignConfigarationSettings()        //Fetch JONo
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.Parameters.AddWithValue("@Parameter", 9);
                cmd.Parameters.AddWithValue("@ID", ExportImageDisplayId);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public bool UpdateConfig()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Sp_UserMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                //cmd.Parameters.AddWithValue("@EntityID", EntityID);
                string XML = "";
                if (dtConfig != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        dtConfig.TableName = "ConfigTable";

                        dtConfig.WriteXml(sw);

                        XML = sw.ToString();
                    }
                    cmd.Parameters.AddWithValue("@ConfigTable", XML);
                }
                cmd.ExecuteNonQuery();

                con.Close();

                return true;



            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public Int32 UpdateApproveSetting()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 10);
                cmd.Parameters.AddWithValue("@ApproveLevel", ApproveLevel);
                cmd.Parameters.AddWithValue("@POFirstLevelApprovalAmount", POFirstLevelApprovalAmount);
                cmd.Parameters.AddWithValue("@POSecondLevelApprovalAmount", POSecondLevelApprovalAmount);

                string XMLProcessFrom = "";
                if (dtLevel1 != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        dtLevel1.TableName = "ApproveDataFirstLevel";

                        dtLevel1.WriteXml(sw);

                        XMLProcessFrom = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                    }
                }

                cmd.Parameters.AddWithValue("@ApproveUserRightTableFirstLevel", XMLProcessFrom);



                string XMLProcessTo = "";
                if (dtLevel2 != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        dtLevel2.TableName = "ApproveDataSecondLevel";

                        dtLevel2.WriteXml(sw);

                        XMLProcessTo = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                    }
                }

                cmd.Parameters.AddWithValue("@ApproveUserRightTableSecondLevel", XMLProcessTo);



                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }

            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public DataTable Fetch_User_Name() // Select Company Detail Invoice report
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 11);
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public DataTable GetFirstLevelUser() // Select Company Detail Invoice report
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 12);
                cmd.Parameters.AddWithValue("@Type", Type);
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public DataTable GetSecondLevelUser() // Select Company Detail Invoice report
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 13);
                cmd.Parameters.AddWithValue("@Type", Type);
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                DataSet ds = new DataSet();
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public Int32 UpdateFilePath()        //Fetch JONo
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 14);
                cmd.Parameters.AddWithValue("@FilePath", filepath);
                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
                cmd.ExecuteNonQuery();
                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public DataTable FetchApprovalAmount()        //Fetch JONo
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.Parameters.AddWithValue("@Parameter", 15);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        public Int32 OASampleApprove()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "ConfigurationSetting";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 16);
                cmd.Parameters.AddWithValue("@ApproveLevel", ApproveLevel);
                cmd.Parameters.AddWithValue("@POFirstLevelApprovalAmount", POFirstLevelApprovalAmount);

                string XMLOAProcessFrom = "";
                if (dtOASampleApprove != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        dtOASampleApprove.TableName = "ApproveOADataFirstLevel";

                        dtOASampleApprove.WriteXml(sw);

                        XMLOAProcessFrom = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
    }
                }

                cmd.Parameters.AddWithValue("@ApproveUserRightOATableFirstLevel", XMLOAProcessFrom);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }

            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public DataTable FetchExportConfigSetting()//this will fetch ExportConfig Setting
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "FetchExportConfig";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Parameters.Clear();
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }
    }
}