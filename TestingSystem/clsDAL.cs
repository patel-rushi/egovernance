using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestingSystems
{
    class clsDAL
    {
        string SERVER_Name = "DESKTOP-9361SGE\\SQLEXPRESS";
        string DataBaseName = "db_EllipHR";
        string UserID = "SA";
        string Password = "4774";
        public SqlConnection Con()
        {
            try
            {
                string connectionString = "Data Source=" + SERVER_Name + ";Initial Catalog=" + DataBaseName + ";User ID=" + UserID+ ";password=" + Password + "";

                SqlConnection con = new SqlConnection(connectionString);
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
