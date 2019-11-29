using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestingSystems.Helpers
{
    public class AssemblyHelper
    {
        #region Public methods

        /// <summary>
        /// Get attribute of assembly
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="value">Attribute value</param>
        /// <returns></returns>
        public static string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(T));
            return value.Invoke(attribute);
        }
        
        #endregion
    }
}
