using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingSystems.App_Data;

namespace TestingSystems
{
    public class FormInputParameters
    {
        public Enums.FormMode FormMode { get; set; }

        public FormInputParameters(Enums.FormMode formMode)
        {
            FormMode = formMode;
        }

        public FormInputParameters()
        {
            // TODO: Complete member initialization
        }
    }
}
