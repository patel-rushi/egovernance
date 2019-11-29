using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems
{
    public class PurchaseItemInputParameters : FormInputParameters
    {
        public PurchaseItemInputParameters(Enums.FormMode FormMode)
            : base(FormMode)
        { }
        public Guid PurchaseItemId { get; set; }
        public string linkText { get; set; }

    }
}
