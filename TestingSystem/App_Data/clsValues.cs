using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsValues
    {


        public static readonly clsValues Instance = new clsValues();

        #region //Global Variables       
        public string IsSandOrDie { get; set; }

        public Boolean IsSandCasting { get; set; }
        public Boolean IsDieCasting { get; set; }
        public Boolean IsInvestmentCasting { get; set; }
        public Boolean IsLostForm { get; set; }                


        public int AdminAccess { get; set; }
        public int SuperAdminAccess { get; set; }       //SuperAdmin     
        public String ShortcutKey { get; set; }
        public string coreImageFileFolder { get; set; }
        public System.String dateFormat
        {
            get
            {
                return "MM/dd/yyyy";
            }
        }
        public Int32 FullScreenOff { get; set; }
        public bool appClosing { get; set; }

        #endregion

    }
}
