using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory_Management.Common
{
    public class Constants
    {
        public class Culture
        {
            public const string IN = "en-IN";
            public const string US = "en-US";
        }

        public class CurrencySymbol
        {
            /// <summary>
            /// Symbol: ₹
            /// </summary>
            //public const string INR = "₹";
            public const string INR = "\u20B9";

            /// <summary>
            /// Symbol: Rs.
            /// </summary>
            public const string INROLD = "Rs.";
        }

        public class DateFormat
        {
            /// <summary>
            /// <para>Format: dd-MMM-yyyy</para> 
            /// <para>Sample: 01-Jan-2001</para> 
            /// </summary>
            public const string ddMMMyyyy = "dd-MMM-yyyy";
        }

        public class FileExtension
        {
            public const string Bmp = ".bmp";

            public const string Emf = ".emf";

            public const string Exif = ".exif";

            public const string Gif = ".gif";

            public const string Icon = ".ico";

            public const string Jpeg = ".jpeg";

            public const string Png = ".png";

            public const string Tiff = ".tiff";

            public const string Wmf = ".wmf";

            public const string Pdf = ".pdf";

            public const string Xls = ".xls";

            public const string Xlsx = ".xlsx";
        }

        public class MenuParameters
        {
            public const String ParentNodeName = "MenuItem";
            public const String NodeName = "MenuParameter";
        }

        public class MenuParameterKey
        {
            public const String ReportId = "ReportId";
            public const String SysDepartmentID = "DepartmentId";
            public const String ProcessID = "ProcessId";
        }
        public class FileNames
        {
            public const string DatabaseConnector = "SQLConnector.xml";
        }       
    }
}
