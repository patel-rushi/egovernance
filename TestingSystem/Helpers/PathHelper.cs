using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace TestingSystems.Helpers
{
    public class PathHelper
    {
        public static string PatternImageFile()
        {
            string PatternImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "TempTickets\\");
            if (!Directory.Exists(PatternImagePath))
            {
                try
                {
                    Directory.CreateDirectory(PatternImagePath);
                }
                catch
                {
                    return "0";
                }
            }
            return PatternImagePath;
        }
        #region Public methods

        /// <summary>
        /// Get database connector file path
        /// </summary>
        /// <returns></returns>
       
       

        /// <summary>
        /// Get log directory path
        /// </summary>
        /// <returns></returns>

        public static string GetLogDirectoryPath()
        {
            return GetParticularDirectoryPathOfApplicationDirectory("Logs");
        }

        /// <summary>
        /// Get menu xml directory path
        /// </summary>
        /// <returns></returns>
        public static string GetMenuXMLDirectoryPath()
        {
            return GetParticularDirectoryPathOfApplicationDirectory("MenuXML");
        }

        /// <summary>
        /// Get Client folder directory path
        /// </summary>
        /// <returns></returns>
        public static string GetClientFolderDirectoryPath()
        {
            return GetParticularDirectoryPathOfApplicationDirectory("Client");
        }

        /// <summary>
        /// Get menu xml file name including path
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="userName">User name</param>
        /// <returns></returns>
        public static string GetMenuXMLFilePath(int userId, string userName)
        {
            return Path.Combine(GetParticularDirectoryPathOfApplicationDirectory("MenuXML"), string.Format("{0}-{1}-MENU.xml", userId, userName.Trim().ToUpper()));
        }

        /// <summary>
        /// Get letter head image path
        /// </summary>
        /// <returns></returns>
        public static string GetLetterHeadImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "LetterHead.jpeg");
        }

        /// <summary>
        /// Get image path of client's company logo
        /// </summary>
        /// <returns></returns>
        public static string GetClientCompanyLogoImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "Logo.jpeg");
        }
        /// <summary>
        /// Get TC prepared by Sign
        /// </summary>
        /// <returns></returns>
        public static string GetTCPreparedBySignImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "PreparedBySign.jpeg");
        }
        /// <summary>
        /// TC Authorized sign
        /// </summary>
        /// <returns></returns>
        public static string GetTCAuthorizedSignImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "AuthorizedSign.jpeg");
        }

        /// <summary>
        /// Get Export invoice prepared by sign
        /// </summary>
        /// <returns></returns>
        public static string GetExportPreparedBySignImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "PreparedBySignExport.jpeg");
        }

        /// <summary>
        /// Get application directory path (ex: 'C:\Users\CurrentUser\AppData\Local\Company Name\Product Name')
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationDirectoryPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AssemblyHelper.GetAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company), AssemblyHelper.GetAssemblyAttribute<AssemblyProductAttribute>(a => a.Product));
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get execution directory path
        /// </summary>
        /// <returns></returns>
        private static string GetExecutionDirectoryPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Get document directory path of execution directory
        /// </summary>
        /// <returns></returns>
        private static string GetDocumentDirectoryPathOfExecutionDirectory()
        {
            return Path.Combine(GetExecutionDirectoryPath(), "Documents");
        }

        /// <summary>
        /// Get image directory path of execution directory
        /// </summary>
        /// <returns></returns>
        private static string GetImageDirectoryPathOfExecutionDirectory()
        {
            return Path.Combine(GetDocumentDirectoryPathOfExecutionDirectory(), "Images");
        }

        /// <summary>
        /// Get path of particular directory of application directory
        /// </summary>
        /// <param name="directoryName">Directory name</param>
        /// <returns></returns>
        private static string GetParticularDirectoryPathOfApplicationDirectory(string directoryName)
        {
            var applicationDirectoryPath = GetApplicationDirectoryPath();
            if (!Directory.Exists(applicationDirectoryPath))
                return string.Empty;

            return Path.Combine(applicationDirectoryPath, directoryName);
        }


        //Edited By Roshani 27-02-2017
        static string path;
        public static string GetServerPath()
        {
            List<string> sqlServerInstanceNames = new List<string>();
           //ataTable dtInstanceNames = SqlDataSourceEnumerator.Instance.GetDataSources();
           //ataRow[] dr_temp = dtInstanceNames.Select("InstanceName = 'EIEXPRESS' ");
            //if (dr_temp.Length > 0)
            //{
            //    DataTable instancename = dr_temp.CopyToDataTable();
            //    path = "\\\\" + "Server";
            //    //path = "\\\\" + instancename.Rows[0]["ServerName"].ToString();
            //}
            // path = "\\\\" + dtInstanceNames.Rows[0]["ServerName"].ToString();
            path = "\\\\" + "Server";
            return path;
        }


        static string Localpath;
        public static string GetLocalPath()
        {
            List<string> sqlServerInstanceNames = new List<string>();
            //  DataTable dtInstanceNames = SqlDataSourceEnumerator.Instance.GetDataSources();
            //  path = "\\\\" + dtInstanceNames.Rows[0]["ServerName"].ToString();
            Localpath = AppDomain.CurrentDomain.BaseDirectory + "Documents\\Images";
            String LocalImagePath = Localpath.Replace(@"\", "\\");
            return LocalImagePath;
        }

        public static string GetDirectoryPathOfCoreImage()
        {
            //if (dtInstanceNames != null && dtInstanceNames.Rows.Count > 0)
            //{
            //    clsValues.Instance.coreImageFileFolder = string.Concat("\\\\" + dtInstanceNames.Rows[0]["ServerName"], "\\iCast-Updates\\CoreImage\\");
            //}
            // return Path.Combine(GetServerPath(), "iCast-Updates");

            if (path == null || path == string.Empty)
            {
                return Path.Combine(GetServerPath(), "iCast-Updates");
            }
            else
            {
                return Path.Combine("\\\\SERVER", "iCast-Updates");
            }
        }

        public static string CoreImageFile()
        {
            string coreImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "CoreImage\\");
            if (!Directory.Exists(coreImagePath))
            {
                try
                {
                    Directory.CreateDirectory(coreImagePath);
                }
                catch
                {
                    return "0";
                }
            }                
            return coreImagePath;
        }

        public static string JobCardImageFile()
        {
            string JobCardImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "JobCardImage\\");
            if (!Directory.Exists(JobCardImagePath))
                Directory.CreateDirectory(JobCardImagePath);
            return JobCardImagePath;
        }

        public static string TempJobCard()
        {
            string TempJobCardImagePath = Path.Combine(GetLocalPath(), "TempCardImage\\");
            if (!Directory.Exists(TempJobCardImagePath))
                Directory.CreateDirectory(TempJobCardImagePath);
            return TempJobCardImagePath;
        }


        public static string CastingImageFile()
        {
            string castingImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "CastingFiles\\Images\\");
            if (!Directory.Exists(castingImagePath))
                Directory.CreateDirectory(castingImagePath);
            return castingImagePath;
        }

        public static string CastingPDFFile()
        {
            string castingPDFPath = Path.Combine(GetDirectoryPathOfCoreImage(), "CastingFiles\\PDF\\");
            if (!Directory.Exists(castingPDFPath))
                Directory.CreateDirectory(castingPDFPath);
            return castingPDFPath;
        }

        public static string OAFiles()
        {
            string OAFilePath = Path.Combine(GetDirectoryPathOfCoreImage(), "OAFiles\\");
            if (!Directory.Exists(OAFilePath))
            {
                try
                {
                    Directory.CreateDirectory(OAFilePath);
                }
                catch
                {
                    return "0";
                }
            }  
            return OAFilePath;
        }

        public static string TestingSystems()
        {
            string PatternImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "TempTickets\\");
            if (!Directory.Exists(PatternImagePath))
            {
                try
                {
                    Directory.CreateDirectory(PatternImagePath);
                }
                catch
                {
                    return "0";
                }
            }
            return PatternImagePath;
        }

        public static string MaterialSampleInspectionFiles()
        {
            string SampleInspectionFilesPath = Path.Combine(GetDirectoryPathOfCoreImage(), "SampleInspectionFiles\\");
            if (!Directory.Exists(SampleInspectionFilesPath))
            {
                try
                {
                    Directory.CreateDirectory(SampleInspectionFilesPath);
                }
                catch
                {
                    return "0";
                }
            }
            return SampleInspectionFilesPath;
        }

        public static string SupplierApprovalFiles()
        {
            string SampleInspectionFilesPath = Path.Combine(GetDirectoryPathOfCoreImage(), "SupplierApprovalFiles\\");
            if (!Directory.Exists(SampleInspectionFilesPath))
            {
                try
                {
                    Directory.CreateDirectory(SampleInspectionFilesPath);
                }
                catch
                {
                    return "0";
                }
            }
            return SampleInspectionFilesPath;
        }

        public static string CustomerTDCImageFile()
        {
            string PatternImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "CustomerTDCFiles\\");
            if (!Directory.Exists(PatternImagePath))
                Directory.CreateDirectory(PatternImagePath);
            return PatternImagePath;
        }

        public static string ISODocumentImageFile()
        {
            string ISODocumentImagePath = Path.Combine(GetDirectoryPathOfCoreImage(), "ISODocumentFiles\\");
            if (!Directory.Exists(ISODocumentImagePath))
                Directory.CreateDirectory(ISODocumentImagePath);
            return ISODocumentImagePath;
        }
        //End Editing



        #endregion

        internal static string TestingSystemsImageFile()
        {
            throw new NotImplementedException();
        }

        public static string GetUserProfileImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "ProfilePic.jpeg");
        }
        public static string GetPdfIconImagePath()
        {
            return Path.Combine(GetImageDirectoryPathOfExecutionDirectory(), "Icon.jpg");
        }
    }
}
