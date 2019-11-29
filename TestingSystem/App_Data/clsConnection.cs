using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace TestingSystems.App_Data
{
  public  class clsConnection
    {
      public SqlConnection Connection()
        {

            String connstring = ConfigurationManager.ConnectionStrings["TestingCon"].ConnectionString;
            SqlConnection con = new SqlConnection(connstring);  
          return con;
        }
    }
}
