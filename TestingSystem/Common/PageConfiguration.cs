using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems.Common
{
    [Serializable]
    public class PageConfiguration
    {

        public bool PrintHeatNoInInvoice { get; set; }
        public bool LossActorFix { get; set; }
        public bool HeatNoPrintInInvoice { get; set; }
        public bool CastNoPrintInInvoice { get; set; }
        public bool VatRoundoff { get; set; }
        public bool PrintServiceItemInChallan { get; set; }
        public bool ISONoPrinted { get; set; }
        public bool PerPcWeightPrinted { get; set; }
        public bool DisplayTransaction { get; set; }
        public bool DisplayHeatCode { get; set; }
        public bool DisplayDrawingNoInInvoice { get; set; }
        public bool DisplayGradeInInvoice { get; set; }
        public bool DisplayLineNoInInvoice { get; set; }
        public bool DisplayWeightInPackingList { get; set; }
       
        public bool DisplayItemDescription { get; set; }
        public bool DisplayCustomerCode { get; set; }
        public bool DisplayTotalWeightInInvoice { get; set; }
        public bool DisplayCurrencyRoundOff { get; set; }
        public bool PrintManualItemname { get; set; }
        public bool DummyAttendanceSheet { get; set; }
        public bool DisplayAllProcess { get; set; }
        public bool LockRouteCardProcess { get; set; }
       
       
        public bool DisplayHeatCodeInInvoice { get; set; }
        public bool DisplayCastingCodeInInvoice { get; set; }
        public bool MoldPlan { get; set; }
        public bool CorePlan { get; set; }

        public Double LossFixValue { get; set; }
        public int invMethod { get; set; }
        public float FurnaceMultiplicationFactor { get; set; }
        public float ElectricMeterMultiplicationfactor { get; set; }
        public string SuperAdminPassword { get; set; }

        public DateTime GSTEffectiveDate { get; set; }
        public int InvoiceSerieis { get; set; }
      
        public int WeekOffDay { get; set; }
        public int TotalWorkingHours { get; set; }
        public int TotalShiftPerDay { get; set; }
        public int ExtraProductionPer { get; set; }
        public int FoundryMethod { get; set; }
        public bool ApproveLevel { get; set; }
        public bool PrefixLevel { get; set; }
        public bool DispatchFromProcess { get; set; }
        public int MetalToSandRatio { get; set; }
        public bool IsConsumptionEditable { get; set; }
        public int DefaultMoldingProcess { get; set; }
        public bool DisplayDrawingNoInOrder { get; set; }
        public bool DisplayMoldTypeInOrder { get; set; }
        public bool DisplaySandTypeInOrder { get; set; }
        public bool DisplayCastingCodeInOrder { get; set; }
        public Int32 NoOfHeatinaDay { get; set; }
        public bool IsExciseRoundOff { get; set; }
        public bool isSalesInvoiceRateEditable { get; set; }

        public bool IsSandMixEnable { get; set; }
        public bool IsPerCavityMoldEnable { get; set; }

        public int InvoiceTaxable { get; set; }
        public Double InvoiceTaxableRate { get; set; }
        public bool AllowAdditionalInward { get; set; }
        public bool DisplayHSNCodeInExportInvoice { get; set; }
        public bool EnableTaxesCalculationInCO { get; set; }
        public bool EnableTaxesCalculationInPO { get; set; }
       
        public Int32 ReminderTimeMinute { get; set; }
        public bool DisplayRequirementInOrder { get; set; }
        public bool DisplayRequirementDescriptionInOrder { get; set; }
        public bool printToleranceInPO { get; set; }
        public bool PrintToleranceInOA { get; set; }
        public bool GeneratePatternAccordingTo { get; set; }

        public bool BatchNoWhenShelLife { get; set; }
        public Int32 FinancialYear { get; set; }
        public string UOM { get; set; }
        public bool PrintCustNameInWO { get; set; }
       
    }
}
