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
    class ClsSPRequirement
    {

        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public ClsSPRequirement()
        {
            con = obj.Con();
        }

        #region DataProperties
        public string SpRequirement { get; set; }
        public Guid SpRequirementID { get; set; }
        public string Code { get; set; }
        public DataTable dtDepartment { get; set; }
        public DataTable dtCheckedRecord { get; set; }
        #endregion

        #region Function
        public int InsertIntoSpRequirementMaster()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);
                cmd.Parameters.AddWithValue("@SpRequirement", SpRequirement);
                cmd.Parameters.AddWithValue("@Code", Code);

                string XML_Department = "";

                using (StringWriter dept = new StringWriter())
                {
                    dtDepartment.TableName = "DepartmentDetail";

                    dtDepartment.WriteXml(dept);

                    XML_Department = dept.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                }

                cmd.Parameters.AddWithValue("@DepartmentDetail", XML_Department);

                string XMLProduction = "";

                if (dtCheckedRecord != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {

                        dtCheckedRecord.TableName = "productionDetail";
                        dtCheckedRecord.WriteXml(sw);

                        XMLProduction = sw.ToString();
                    }
                }
                cmd.Parameters.AddWithValue("@productionDetail", XMLProduction);


                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public DataTable FetchDepartment()         // Get Process Record is per SpRequirementID
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);
                cmd.Parameters.AddWithValue("@SpRequirementID", SpRequirementID);
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

        public DataTable FetchSpRequirementDetail()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 3);

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

        public Int32 UpdateSpRequirementMaster()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@SpRequirementID", SpRequirementID);

                cmd.Parameters.AddWithValue("@SpRequirement", SpRequirement);

                string XML_Department = "";

                using (StringWriter dept = new StringWriter())
                {
                    dtDepartment.TableName = "DepartmentDetail";

                    dtDepartment.WriteXml(dept);

                    XML_Department = dept.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                }

                cmd.Parameters.AddWithValue("@DepartmentDetail", XML_Department);

                string XMLProduction = "";

                if (dtCheckedRecord != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {

                        dtCheckedRecord.TableName = "productionDetail";
                        dtCheckedRecord.WriteXml(sw);

                        XMLProduction = sw.ToString();
                    }
                }
                cmd.Parameters.AddWithValue("@productionDetail", XMLProduction);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                con.Close();

                return 1;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public Int32 DeleteFromSpRequirement()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                if (SpRequirementID != null && SpRequirementID != Guid.Empty)
                    cmd.Parameters.AddWithValue("@SpRequirementID", SpRequirementID);


                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(return_parameter);

                cmd.ExecuteNonQuery();

                Int32 result = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;
                cmd.Parameters.Clear();

                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        public Int32 CheckCodeDuplicate()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_RequirementMaster";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

                cmd.Parameters.AddWithValue("@Code", Code);

                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(return_parameter);

                cmd.ExecuteNonQuery();

                Int32 SQL_Status = Convert.ToInt32(cmd.Parameters["@RETURN_VALUE"].Value);

                cmd.Parameters.Clear();

                con.Close();

                return SQL_Status;

            }
            catch (Exception ex)
            {
                con.Close();

                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }
        #endregion



    }
}
