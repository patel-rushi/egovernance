using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsDepartment
    {
        public clsDepartment()
        {

        }

        public DataTable FetchSystemDepartment()
        {
            clsDAL obj = new clsDAL();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection con = new SqlConnection(obj.Cn()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "FetchSystemDepartment";
                        cmd.ExecuteNonQuery();
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        con.Close();

                        ExceptionHandler.LogException(ex);
                        System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return dt;
                    }
                }
            }


        }
    }
}
