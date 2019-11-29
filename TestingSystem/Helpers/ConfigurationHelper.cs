using TestingSystems.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using TestingSystems.Helpers;

namespace TestingSystems.Helpers
{
    internal class ConfigurationHelper
    {
        #region Private properties/members

        private const string _ApplicationConfigurationFileName = "ApplicationConfiguration.xml";
        private const string _PageConfigurationFileName = "PageConfiguration.xml";

        private static List<string> _ApplicationDirectoryList = new List<string>()
        {
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Path.DirectorySeparatorChar + "Ellipsis Infotech",
            Path.DirectorySeparatorChar + "iCast",
            Path.DirectorySeparatorChar + "Client"
        };

        #endregion

        #region Internal methods

        /// <summary>
        /// Get application configuration
        /// </summary>
        /// <returns></returns>
        internal static ApplicationConfiguration GetApplicationConfiguration()
        {
            var applicationConfigurationFilePath = GetApplicationConfigurationFilePath();
            if (!File.Exists(applicationConfigurationFilePath))
                return new ApplicationConfiguration();

            return SerializeDeserializeHelper.Deserialize<ApplicationConfiguration>(Enums.SerializatioDeSerializationMethod.Encrypted, Enums.XmlInputType.XmlFile, applicationConfigurationFilePath);
        }

        /// <summary>
        /// Get page configuration
        /// </summary>
        /// <returns></returns>
        internal static PageConfiguration GetPageConfiguration()
        {
            var pageConfigurationFilePath = GetPageConfigurationFilePath();
            if (!File.Exists(pageConfigurationFilePath))
                return new PageConfiguration();

            return SerializeDeserializeHelper.Deserialize<PageConfiguration>(Enums.SerializatioDeSerializationMethod.Encrypted, Enums.XmlInputType.XmlFile, pageConfigurationFilePath);
        }

        /// <summary>
        /// Create application configuration file
        /// </summary>
        internal static void CreateApplicationConfigurationFile()
        {
            var applicationConfigurationFilePath = GetApplicationConfigurationFilePath();
            //if (File.Exists(applicationConfigurationFilePath))
            //    return;

            CreateApplicationConfigurationFile(applicationConfigurationFilePath);
        }

        /// <summary>
        /// Create page configuration file
        /// </summary>
        internal static void CreatePageConfigurationFile()
        {
            var pageConfigurationFilePath = GetPageConfigurationFilePath();
            //if (File.Exists(pageConfigurationFilePath))
            //    return;

            CreatePageConfigurationFile(pageConfigurationFilePath);
        }

        /// <summary>
        /// Delete application configuration file
        /// </summary>
        internal static void DeleteApplicationConfigurationFile()
        {
            var applicationConfigurationFilePath = GetApplicationConfigurationFilePath();
            if (!File.Exists(applicationConfigurationFilePath))
                return;

            File.Delete(applicationConfigurationFilePath);
        }

        /// <summary>
        /// Delete page configuration file
        /// </summary>
        internal static void DeletePageConfigurationFile()
        {
            var pageConfigurationFilePath = GetPageConfigurationFilePath();
            if (!File.Exists(pageConfigurationFilePath))
                return;

            File.Delete(pageConfigurationFilePath);
        }

        #endregion

        #region Private methods

        private static string GetRootPath()
        {
            var folderPath = string.Empty;

            foreach (var path in _ApplicationDirectoryList)
                folderPath = folderPath + path;

            return folderPath;
        }

        /// <summary>
        /// Get application configuration file path
        /// </summary>
        /// <returns></returns>

        private static string GetApplicationConfigurationFilePath()
        {
            var folderPath = GetRootPath();
            return Path.Combine(folderPath, _ApplicationConfigurationFileName);
        }

        /// <summary>
        /// Get page configuration file path
        /// </summary>
        /// <returns></returns>
        private static string GetPageConfigurationFilePath()
        {
            var folderPath = GetRootPath();
            return Path.Combine(folderPath, _PageConfigurationFileName);
        }

        /// <summary>
        /// Create application configuration file
        /// </summary>
        /// <param name="applicationConfigurationFilePath">File path</param>
        private static void CreateApplicationConfigurationFile(string applicationConfigurationFilePath)
        {
            //var dtConfig = new TestingSystems.App_Data.clsUserMaster().Fetch_Config();
            //if (dtConfig == null || dtConfig.Rows.Count == 0)
            //    return;

            //var applicationConfiguration = new ApplicationConfiguration()
            //{
            //    IsFoundryReturnEnable = Convert.ToBoolean(dtConfig.Rows[0]["FR"]),
            //    IsEvaluationSheetEnable = Convert.ToBoolean(dtConfig.Rows[0]["ES"]),
            //    IsInqQuoteEnable = Convert.ToBoolean(dtConfig.Rows[0]["IN"]),
            //    IsInqQuoteDetailEnable = Convert.ToBoolean(dtConfig.Rows[0]["IND"]),
            //    IsServiceItemEnable = Convert.ToBoolean(dtConfig.Rows[0]["SIM"]),
            //    IsPOEnable = Convert.ToBoolean(dtConfig.Rows[0]["PO"]),
            //    IsIndentEnable = Convert.ToBoolean(dtConfig.Rows[0]["IM"]),
            //    IsJobworkEnable = Convert.ToBoolean(dtConfig.Rows[0]["JW"]),
            //    IsSalesInvoiceEnable = Convert.ToBoolean(dtConfig.Rows[0]["SI"]),
            //    IsTCEnable = Convert.ToBoolean(dtConfig.Rows[0]["TC"]),
            //    IsInHouseStockTransferEnable = Convert.ToBoolean(dtConfig.Rows[0]["INP"]),
            //    IsExportEnable = Convert.ToBoolean(dtConfig.Rows[0]["EXP"]),
            //    IsCastingPurchaseEnable = Convert.ToBoolean(dtConfig.Rows[0]["CP"]),
            //    IsHeatwise = Convert.ToBoolean(dtConfig.Rows[0]["HT"]),
            //    IsHeatNoManualAuto = Convert.ToBoolean(dtConfig.Rows[0]["HMA"]),
            //    IsCastCodeEnable = Convert.ToBoolean(dtConfig.Rows[0]["CCE"]),
            //    IsConsumptionMethod = Convert.ToBoolean(dtConfig.Rows[0]["CM"]),
            //    IsSetItemEnable = Convert.ToBoolean(dtConfig.Rows[0]["SET"]),
            //    IsContractorEnable = Convert.ToBoolean(dtConfig.Rows[0]["CNTR"]),
            //    IsAccesibleValueEnableOnAPC = Convert.ToBoolean(dtConfig.Rows[0]["APCON"]),
            //    IsItemWiseTC = Convert.ToBoolean(dtConfig.Rows[0]["TCITM"]),
            //    IsAutoGradeSelection = Convert.ToBoolean(dtConfig.Rows[0]["AUTO"]),
            //    IsMolding = Convert.ToBoolean(dtConfig.Rows[0]["MLD"]),
            //    IsMoldingAndProduction = Convert.ToBoolean(dtConfig.Rows[0]["MP"]),
            //    IsCoreProduction = Convert.ToBoolean(dtConfig.Rows[0]["CORE"]),
            //    IsChargeCalculation = Convert.ToBoolean(dtConfig.Rows[0]["CC"]),
            //    IsItemAndPackingInvoice = Convert.ToBoolean(dtConfig.Rows[0]["IPSI"]),
            //    IsApprove = Convert.ToBoolean(dtConfig.Rows[0]["APP"]),
            //    IsBackDateLock = Convert.ToBoolean(dtConfig.Rows[0]["BDL"]),
            //    IsInwardBatchWise = Convert.ToBoolean(dtConfig.Rows[0]["IBW"]),
            //    IsInwardBatchWiseManual = Convert.ToBoolean(dtConfig.Rows[0]["IBWMA"]),
            //    IsProcessInspection = Convert.ToBoolean(dtConfig.Rows[0]["QC"]),
            //    IsPouring = Convert.ToBoolean(dtConfig.Rows[0]["ISP"]),
            //    IsHeatCodeDuplicate = Convert.ToBoolean(dtConfig.Rows[0]["HCUD"]),
            //    IsProcessPerform = Convert.ToBoolean(dtConfig.Rows[0]["PP"]),
            //    IsJoborderEnable = Convert.ToBoolean(dtConfig.Rows[0]["JOE"]),
            //    IsAutoPOofJobOrder = Convert.ToBoolean(dtConfig.Rows[0]["APJ"]),
            //    IsPatternPurchaseOrderEnable = Convert.ToBoolean(dtConfig.Rows[0]["PPO"]),
            //    IsMoldBoxDetailInPatternEnable = Convert.ToBoolean(dtConfig.Rows[0]["MOBOX"]),
            //    IsDepartmentwiseDataEnable = Convert.ToBoolean(dtConfig.Rows[0]["SYSDE"]),
            //    SpecialRequirement = Convert.ToBoolean(dtConfig.Rows[0]["SR"]),
            //    TDCDetail = Convert.ToBoolean(dtConfig.Rows[0]["TD"]),
            //    JOBWORKFromPO = Convert.ToBoolean(dtConfig.Rows[0]["JFPO"]),
            //    SampleDevelopment = Convert.ToBoolean(dtConfig.Rows[0]["SADEV"]),
            //    PatternRevisionEnabled = Convert.ToBoolean(dtConfig.Rows[0]["PRE"]),
            //    ToleranceEnable = Convert.ToBoolean(dtConfig.Rows[0]["TOLER"]),
            //    PatternInDetail = Convert.ToBoolean(dtConfig.Rows[0]["PID"]),
            //    Priority = Convert.ToBoolean(dtConfig.Rows[0]["PRIOR"]),
            //    RAWMATERIALSALE = Convert.ToBoolean(dtConfig.Rows[0]["RS"]),
            //    IsDispatchAdviceApproval = Convert.ToBoolean(dtConfig.Rows[0]["DAPP"]),
            //    IsAmendment = Convert.ToBoolean(dtConfig.Rows[0]["AMD"]),
            //    IsVolumeBasedORWeight = Convert.ToBoolean(dtConfig.Rows[0]["SC"]),
            //    IsMetalMapping = Convert.ToBoolean(dtConfig.Rows[0]["MM"]),
            //    ShowAllItemInIndent = Convert.ToBoolean(dtConfig.Rows[0]["SAI"]),
            //    RawMaterialIspection = Convert.ToBoolean(dtConfig.Rows[0]["RMI"]),
            //    Planning = Convert.ToBoolean(dtConfig.Rows[0]["PLAN"]),
            //    SafetyStockWisePlanning = Convert.ToBoolean(dtConfig.Rows[0]["SSWP"]),
            //    IsProcessTransferModule = Convert.ToBoolean(dtConfig.Rows[0]["PST"]),
            //    IsInvestmentCasting = Convert.ToBoolean(dtConfig.Rows[0]["INVCA"]),
            //    IsHR = Convert.ToBoolean(dtConfig.Rows[0]["HR"]),
            //    IsGatePassEnable = Convert.ToBoolean(dtConfig.Rows[0]["GPE"]),
            //    IsTopBottomDetail = Convert.ToBoolean(dtConfig.Rows[0]["TBD"]),
            //    IsPurchaseIndentApprove = Convert.ToBoolean(dtConfig.Rows[0]["PIA"]),
            //    IsMaterialRequisitionApprove = Convert.ToBoolean(dtConfig.Rows[0]["MRA"]),
            //    IsMachineShop = Convert.ToBoolean(dtConfig.Rows[0]["MS"]),
            //    IsiCastLyt = Convert.ToBoolean(dtConfig.Rows[0]["LYT"]),
            //    IsItemCodeManually = Convert.ToBoolean(dtConfig.Rows[0]["ICM"]),
            //    IsSupplierApproval = Convert.ToBoolean(dtConfig.Rows[0]["SUPAP"]),
            //    IsSampleIdentificationAuto = Convert.ToBoolean(dtConfig.Rows[0]["SIATO"]),

            //    ProcessWiseSeparatePage = Convert.ToBoolean(dtConfig.Rows[0]["SPPE"]),
            //    IsRework = Convert.ToBoolean(dtConfig.Rows[0]["PRW"]),
            //    IsReworkInspection = Convert.ToBoolean(dtConfig.Rows[0]["PRWI"]),
            //    IsFoundryReturnCostAuto = Convert.ToBoolean(dtConfig.Rows[0]["FRC"]),
            //};

            //SerializeDeserializeHelper.Serialize<ApplicationConfiguration>(Enums.SerializatioDeSerializationMethod.Encrypted, applicationConfiguration, applicationConfigurationFilePath);
        }

        /// <summary>
        /// Create page configuration file
        /// </summary>
        /// <param name="pageConfigurationFilePath">File path</param>
        private static void CreatePageConfigurationFile(string pageConfigurationFilePath)
        {
            var dtConfig = new TestingSystems.App_Data.clsConfigaration().FetchAllConfigarationSettings();
            if (dtConfig == null || dtConfig.Rows.Count == 0)
                return;

            var pageConfiguration = new PageConfiguration()
            {
                LossActorFix = Convert.ToBoolean(dtConfig.Rows[0]["LossActualorFix"]),
                HeatNoPrintInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["HeatNoPrintInInvoice"]),
                CastNoPrintInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["CastNoPrintInInvoice"]),
                VatRoundoff = Convert.ToBoolean(dtConfig.Rows[0]["VatRoundoff"]),
                PrintServiceItemInChallan = Convert.ToBoolean(dtConfig.Rows[0]["PrintServiceItemInChallan"]),
                ISONoPrinted = Convert.ToBoolean(dtConfig.Rows[0]["ISONoPrinted"]),
                PerPcWeightPrinted = Convert.ToBoolean(dtConfig.Rows[0]["PerPcWeightPrinted"]),
                DisplayTransaction = Convert.ToBoolean(dtConfig.Rows[0]["DisplayTransaction"]),
                DisplayHeatCode = Convert.ToBoolean(dtConfig.Rows[0]["DisplayHeatCode"]),
                DisplayDrawingNoInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayDrawingNoInInvoice"]),
                DisplayGradeInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayGradeInInvoice"]),
                DisplayLineNoInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayLineNoInInvoice"]),
                DisplayWeightInPackingList = Convert.ToBoolean(dtConfig.Rows[0]["DisplayWeightInPackingList"]),
                DisplayItemDescription = Convert.ToBoolean(dtConfig.Rows[0]["DisplayItemDescription"]),
                DisplayCustomerCode = Convert.ToBoolean(dtConfig.Rows[0]["DisplayCustomerCode"]),
                DisplayTotalWeightInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayTotalWeightInInvoice"]),
                DisplayCurrencyRoundOff = Convert.ToBoolean(dtConfig.Rows[0]["DisplayCurrencyRoundOff"]),
                PrintManualItemname = Convert.ToBoolean(dtConfig.Rows[0]["PrintManualItemname"]),
                DummyAttendanceSheet = Convert.ToBoolean(dtConfig.Rows[0]["DummyAttendanceSheet"]),
                DisplayAllProcess = Convert.ToBoolean(dtConfig.Rows[0]["DisplayAllProcess"]),
                DisplayHeatCodeInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayHeatCodeInInvoice"]),
                MoldPlan = Convert.ToBoolean(dtConfig.Rows[0]["MoldPlan"]),
                CorePlan = Convert.ToBoolean(dtConfig.Rows[0]["CorePlan"]),
                LossFixValue = Convert.ToDouble(dtConfig.Rows[0]["LossFixValue"]),
                invMethod = Convert.ToInt32(dtConfig.Rows[0]["invMethod"]),
                FurnaceMultiplicationFactor = Convert.ToInt64(dtConfig.Rows[0]["FunrnaceMultiplicationFactor"]),
                ElectricMeterMultiplicationfactor = Convert.ToInt64(dtConfig.Rows[0]["ElectricMeterMultiplicationfactor"]),
                SuperAdminPassword = Convert.ToString(dtConfig.Rows[0]["SuperAdminPassword"]),
                InvoiceSerieis = Convert.ToInt32(dtConfig.Rows[0]["InvoiceSeries"]),
                WeekOffDay = Convert.ToInt32(dtConfig.Rows[0]["WeekOffDay"]),
                TotalWorkingHours = Convert.ToInt32(dtConfig.Rows[0]["TotalWorkingHours"]),
                TotalShiftPerDay = Convert.ToInt32(dtConfig.Rows[0]["TotalShiftPerDay"]),
                ExtraProductionPer = Convert.ToInt32(dtConfig.Rows[0]["ExtraProductionPer"]),
                FoundryMethod = Convert.ToInt32(dtConfig.Rows[0]["FoundryMethod"]),
                LockRouteCardProcess = Convert.ToBoolean(dtConfig.Rows[0]["LockRouteCardProcess"]),
                ApproveLevel = Convert.ToBoolean(dtConfig.Rows[0]["ApproveLevel"]),
                PrefixLevel = Convert.ToBoolean(dtConfig.Rows[0]["PrefixLevel"]),
                DispatchFromProcess = Convert.ToBoolean(dtConfig.Rows[0]["DIspatchFromProcess"]),
                DisplayCastingCodeInInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayCastingCodeInInvoice"]),
                MetalToSandRatio = Convert.ToInt32(dtConfig.Rows[0]["MetalToSandRatio"]),
                IsConsumptionEditable = Convert.ToBoolean(dtConfig.Rows[0]["IsConsumptionEditable"]),
                DefaultMoldingProcess = Convert.ToInt32(dtConfig.Rows[0]["DefaultMoldingProcess"]),
                DisplayDrawingNoInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplayDrawingNoInOrder"]),
                DisplayMoldTypeInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplayMoldTypeInOrder"]),
                DisplaySandTypeInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplaySandTypeInOrder"]),
                DisplayCastingCodeInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplayCastingCodeInOrder"]),
                NoOfHeatinaDay = Convert.ToInt32(dtConfig.Rows[0]["NoOfHeatinaDay"]),
                IsExciseRoundOff = Convert.ToBoolean(dtConfig.Rows[0]["IsExciseRoundOff"]),
                isSalesInvoiceRateEditable = Convert.ToBoolean(dtConfig.Rows[0]["isSalesInvoiceRateEditable"]),
                InvoiceTaxable = Convert.ToInt32(dtConfig.Rows[0]["InvoiceTaxable"]),
                GSTEffectiveDate = Convert.ToDateTime(dtConfig.Rows[0]["GSTEffectiveDate"]),
                InvoiceTaxableRate = Convert.ToDouble(dtConfig.Rows[0]["InvoiceTaxableRate"]),
                DisplayHSNCodeInExportInvoice = Convert.ToBoolean(dtConfig.Rows[0]["DisplayHSNCodeInExportInvoice"]),
                AllowAdditionalInward = Convert.ToBoolean(dtConfig.Rows[0]["AllowAdditionalInward"]),
                EnableTaxesCalculationInCO = Convert.ToBoolean(dtConfig.Rows[0]["EnableTaxesCalculationInCO"]),
                EnableTaxesCalculationInPO = Convert.ToBoolean(dtConfig.Rows[0]["EnableTaxesCalculationInPO"]),
                ReminderTimeMinute = Convert.ToInt32(dtConfig.Rows[0]["ReminderTimeMinute"]),
                DisplayRequirementInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplayRequirementInOrder"]),
                DisplayRequirementDescriptionInOrder = Convert.ToBoolean(dtConfig.Rows[0]["DisplayRequirementDescriptionInOrder"]),
                printToleranceInPO = Convert.ToBoolean(dtConfig.Rows[0]["PrintToleranceInPO"]),
                PrintToleranceInOA = Convert.ToBoolean(dtConfig.Rows[0]["PrintToleranceInOA"]),
                IsSandMixEnable = Convert.ToBoolean(dtConfig.Rows[0]["IsSandMixEnable"]),
                IsPerCavityMoldEnable = Convert.ToBoolean(dtConfig.Rows[0]["IsPerCavityMoldEnable"]),
                GeneratePatternAccordingTo = Convert.ToBoolean(dtConfig.Rows[0]["GeneratePatternAccordingTo"]),
                BatchNoWhenShelLife = Convert.ToBoolean(dtConfig.Rows[0]["BatchNoforItemwithShelfLifeOnly"]),
                FinancialYear = Convert.ToInt32(dtConfig.Rows[0]["FinancialYear"]),
                UOM = (dtConfig.Rows[0]["UOM"].ToString()),
                PrintCustNameInWO = Convert.ToBoolean(dtConfig.Rows[0]["PrintCustNameInWO"])//,
                //AllProcessForRework = Convert.ToBoolean(dtConfig.Rows[0]["AllProcessForRework"])
                
            };

            SerializeDeserializeHelper.Serialize<PageConfiguration>(Enums.SerializatioDeSerializationMethod.Encrypted, pageConfiguration, pageConfigurationFilePath);
        }

        #endregion
    }
}
