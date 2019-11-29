using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TestingSystems.Common
{
    [Serializable]
    public class ApplicationConfiguration
    {
        public bool IsFoundryReturnEnable { get; set; }

        public bool IsEvaluationSheetEnable { get; set; }

        public bool IsInqQuoteEnable { get; set; }

        public bool IsInqQuoteDetailEnable { get; set; }

        public bool IsServiceItemEnable { get; set; }

        public bool IsPOEnable { get; set; }

        public bool IsIndentEnable { get; set; }

        public bool IsJobworkEnable { get; set; }

        public bool IsSalesInvoiceEnable { get; set; }

        public bool IsInHouseStockTransferEnable { get; set; }

        public bool IsExportEnable { get; set; }

        public bool IsTariffCodeEnable { get; set; }

        public bool IsCastingPurchaseEnable { get; set; }

        public bool IsSandOrDie { get; set; }

        public bool IsHeatwise { get; set; }

        public bool IsTCEnable { get; set; }

        public bool IsMetalMapping { get; set; }

        public bool IsContractorEnable { get; set; }

        public bool IsHeatNoManualAuto { get; set; }

        public bool IsCastCodeEnable { get; set; }

        public bool IsItemWiseTC { get; set; }

        public bool IsAutoGradeSelection { get; set; }

        public bool IsMolding { get; set; }

        public bool IsMoldingAndProduction { get; set; }

        public bool IsCoreProduction { get; set; }

        public bool IsChargeCalculation { get; set; }

        public bool IsItemAndPackingInvoice { get; set; }

        //  public bool IsHeatCodeEnable { get; set; }

        public bool IsConsumptionMethod { get; set; }

        public bool IsSetItemEnable { get; set; }

        public bool IsAccesibleValueEnableOnAPC { get; set; }

        public bool IsApprove { get; set; }

        public bool IsWithheatProperty { get; set; }

        public bool IsBackDateLock { get; set; }

        public bool IsInwardBatchWise { get; set; }

        public bool IsInwardBatchWiseManual { get; set; }

        public bool IsProcessInspection { get; set; }

        public bool AllowAdditionalInward { get; set; }

        public bool IsPouring { get; set; } // Use only at production register to choose which page to open at edit operation 

        public bool IsHeatCodeDuplicate { get; set; } // Use to check to allow same Heat code or not

        public bool IsProcessPerform { get; set; } // Use to check to allow same Heat code or not

        public bool IsJoborderEnable { get; set; } //  For enable Job work PO

        public bool IsAutoPOofJobOrder { get; set; } // Job work PO should be AUto or manual

        public bool IsPatternPurchaseOrderEnable { get; set; }

        public bool IsDepartmentwiseDataEnable { get; set; }

        public bool IsMoldBoxDetailInPatternEnable { get; set; }

        public bool SpecialRequirement { get; set; }

        public bool TDCDetail { get; set; }

        public bool JOBWORKFromPO { get; set; }

        public bool SampleDevelopment { get; set; }

        public bool PatternRevisionEnabled { get; set; }

        public bool ToleranceEnable { get; set; }

        public bool PatternInDetail { get; set; }

        public bool Priority { get; set; }

        public bool IsDispatchAdviceApproval { get; set; }

        public bool IsAmendment { get; set; }

        public bool RAWMATERIALSALE { get; set; }

        public bool IsVolumeBasedORWeight { get; set; }

        public bool ShowAllItemInIndent { get; set; }

        public bool RawMaterialIspection { get; set; }

        public bool Planning { get; set; }

        public bool SafetyStockWisePlanning { get; set; }

        public bool IsProcessTransferModule { get; set; }

        public bool IsInvestmentCasting { get; set; }

        public bool IsHR { get; set; }

        public bool IsGatePassEnable { get; set; }

        public bool IsTopBottomDetail { get; set; }

        public bool IsPurchaseIndentApprove { get; set; }

        public bool IsMaterialRequisitionApprove { get; set; }

        public bool IsMachineShop { get; set; }

        public bool IsItemCodeManually { get; set; }

        public bool IsiCastLyt { get; set; }

        public bool IsSupplierApproval { get; set; }

        public bool ProcessWiseSeparatePage { get; set; }

        public bool IsSampleIdentificationAuto { get; set; }

    }
}
