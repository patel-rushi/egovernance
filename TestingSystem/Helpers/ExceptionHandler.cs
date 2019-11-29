using TestingSystems.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystems
{
    public class ExceptionHandler
    {
        #region Public methods

        /// <summary>
        /// Unhandled exception
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Unhandled exception event args</param>
        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogException(e.ExceptionObject as Exception, "AppDomain.UnhandledException");
        }       

        /// <summary>
        /// Task scheduler exception
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Unobserved task exception event args</param>
        public static void TaskSchedulerException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            LogException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="ex">Exception</param>
        public static void LogException(Exception ex)
        {
            LogException(ex, string.Empty);
        }

        #endregion

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="eventName">Event name</param>
        private static void LogException(Exception ex, string eventName)
        {
            try
            {
                if (ex == null)
                    return;

                var logDirectoryPath = PathHelper.GetLogDirectoryPath();
                if (!Directory.Exists(logDirectoryPath))
                    return;

                var errorFileName = string.Format("{0}.{1}", DateTime.Now.ToString("dd-MMM-yyyy-hh-mm-ss-tt"), "txt");
                var errorFilePath = Path.Combine(logDirectoryPath, errorFileName);

                using (var stramWriter = new StreamWriter(errorFilePath, true))
                {
                    if (!string.IsNullOrEmpty(eventName))
                    {
                        stramWriter.WriteLine(string.Format("Event : {0}", eventName));
                        stramWriter.WriteLine(stramWriter.NewLine);
                    }

                    stramWriter.WriteLine(ex.InnerException == null ? ex.ToString() : ex.InnerException.ToString());
                    stramWriter.Flush();
                    stramWriter.Close();
                }
            }
            catch
            { }
        }
    }
}
