using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace TestingSystems.Helpers
{
    public class ApplicationHelper
    {
        #region Public methods

        /// <summary>
        /// Get application name
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationName()
        {
            return AssemblyHelper.GetAssemblyAttribute<AssemblyProductAttribute>(a => a.Product);
        }

        /// <summary>
        /// Get company name
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyName()
        {
            return AssemblyHelper.GetAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company);
        }

        /// <summary>
        /// Setup application directories
        /// </summary>
        public static void SetupApplicationDirectories()
        {
            CreateDirectory(PathHelper.GetApplicationDirectoryPath());
            SetupMenuXMLDirectory();
            SetupErrorLogDirectory();
            SetupClientDirectory();
        }

        #endregion

        #region Internal/Private methods

        /// <summary>
        /// Setup error log directories
        /// </summary>
        private static void SetupErrorLogDirectory()
        {
            var logDirectoryPath = PathHelper.GetLogDirectoryPath();
            CreateDirectory(logDirectoryPath);
        }

        /// <summary>
        /// Setup menu xml
        /// </summary>
        private static void SetupMenuXMLDirectory()
        {
            var menuXMLDirectoryPath = PathHelper.GetMenuXMLDirectoryPath();
            CreateDirectory(menuXMLDirectoryPath);
        }

        /// <summary>
        /// Setup menu xml
        /// </summary>
        private static void SetupClientDirectory()
        {
            var ClientDirectoryPath = PathHelper.GetClientFolderDirectoryPath();
            CreateDirectory(ClientDirectoryPath);
        }


        

        /// <summary>
        /// Create directory
        /// </summary>
        /// <param name="directoryPath">Directory path</param>
        private static void CreateDirectory(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath) || Directory.Exists(directoryPath))
                return;

            Directory.CreateDirectory(directoryPath);
            SetDirectoryPermissions(directoryPath);
        }

        /// <summary>
        /// Set directory permission
        /// </summary>
        /// <param name="directoryPath">Directory path</param>
        private static void SetDirectoryPermissions(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                return;

            var directoryInfo = new DirectoryInfo(directoryPath);
            var windowsIdentity = WindowsIdentity.GetCurrent();
            var directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.AddAccessRule
            (
                new FileSystemAccessRule
                (
                    windowsIdentity.Name,
                    FileSystemRights.WriteData,
                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow
                )
            );

            directoryInfo.SetAccessControl(directorySecurity);
        }

        #endregion
    }
}
