using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingSystems
{
    public sealed class Session
    {
        #region Private properties

        private static Session _Session = null;

        #endregion

        #region Properties

        public String UserName { get; set; }
        public String UserType { get; set; }
        public String CompanyName { get; set; }

        public int UserId { get; set; }
        public int EntityID { get; set; }
        public int EmployeeId { get; set; }

        #endregion

        #region Public method

        public static void Create(int userId, int entityId, string userName, string userType, string companyName , int EmployeeId)
        {
            _Session = new Session()
            {
                UserId = userId,
                EntityID = entityId,
                UserName = userName,
                UserType = userType,
                CompanyName = companyName,
                EmployeeId = EmployeeId
            };
        }

        public static Session Get()
        {
            if (_Session == null)
                _Session = new Session();

            return _Session;
        }

        #endregion
    }
}
