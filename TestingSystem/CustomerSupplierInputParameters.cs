
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    public class CustomerSupplierInputParameters : FormInputParameters
    {
        public CustomerSupplierInputParameters(TestingSystems.Enums.FormMode FormMode) : base(FormMode) { }
        public Label lbldeleteContact = new Label();
        public Guid CustomerId { get; set; }
        public String LinkText { get; set; }
    }
}
