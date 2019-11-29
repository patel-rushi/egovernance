
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    public class ProcessPopupInputParameters : FormInputParameters
    {
        public ProcessPopupInputParameters(Enums.FormMode FormMode) : base(FormMode) { }
        public Label lbldeleteMetalElement = new Label();
        public Guid ReferenceId { get; set; }
        public Int32 ReferenceType { get; set; }
        public String LinkText { get; set; }
        public DataTable dtCheckedProcess { get; set; }
        public DataTable dtCheckedProcessAll { get; set; }
    }
}
