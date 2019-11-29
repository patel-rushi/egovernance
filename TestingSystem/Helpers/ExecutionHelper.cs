using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems.Helpers
{
    internal class ExecutionHelper
    {
        public static void ExecuteSafely(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecuteSafely(string errorMessage, Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
