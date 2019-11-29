using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TestingSystems
{
    class clsCustomerTypeCategoryGroupMaster
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public Guid CustomerGroupId { get; set; }
        public String GroupCode { get; set; }
        public String GroupName { get; set; }
        public String GroupShortCode { get; set; }

        public Guid CustomerCategoryId { get; set; }
        public String CategoryCode { get; set; }
        public String CategoryName { get; set; }
        public String CategoryShortCode { get; set; }

        public Guid CustomerTypeId { get; set; }
        public String TypeCode { get; set; }
        public String TypeName { get; set; }
        public String TypeShortCode { get; set; }

        public Int32 CreatedBy { get; set; }
        public DateTime Createdon { get; set; }
        public Int32 Isdeleted { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime Modifiedon { get; set; }

        public clsCustomerTypeCategoryGroupMaster()
        {
            con = obj.Con();
        }

        public Int32 Insert_Customer_Type_Details() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@TypeCode", TypeCode);

                cmd.Parameters.AddWithValue("@TypeName", TypeName);

                cmd.Parameters.AddWithValue("@TypeShortCode", TypeShortCode);

                cmd.Parameters.AddWithValue("@CreatedBy", session.UserId);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);
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

        public Int32 Insert_Customer_Category_Details() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@CategoryCode", CategoryCode);

                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);

                cmd.Parameters.AddWithValue("@CategoryShortCode", CategoryShortCode);

                cmd.Parameters.AddWithValue("@CreatedBy", session.UserId);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);
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

        public Int32 Insert_Customer_Group_Details() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 3);

                cmd.Parameters.AddWithValue("@GroupCode", GroupCode);

                cmd.Parameters.AddWithValue("@GroupName", GroupName);

                cmd.Parameters.AddWithValue("@GroupShortCode", GroupShortCode);

                cmd.Parameters.AddWithValue("@CreatedBy", session.UserId);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);
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

        public DataTable Fetch_Customer_Type_Details()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);

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

        public DataTable Fetch_Customer_Category_Details()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);

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

        public DataTable Fetch_Customer_Group_Details()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);

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

        public int Delete_Customer_Type_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 7);
                        cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                        cmd.Parameters.AddWithValue("@DeletedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }

        public int Delete_Customer_Category_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 8);
                        cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                        cmd.Parameters.AddWithValue("@DeletedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }

        public int Delete_Customer_Group_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 9);
                        cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);
                        cmd.Parameters.AddWithValue("@DeletedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }


        public Int32 Update_Customer_Type_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 10);
                        cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                        cmd.Parameters.AddWithValue("@TypeCode", TypeCode);
                        cmd.Parameters.AddWithValue("@TypeName", TypeName);
                        cmd.Parameters.AddWithValue("@TypeShortCode", TypeShortCode);
                        cmd.Parameters.AddWithValue("@ModifiedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }

        public Int32 Update_Customer_Category_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 11);
                        cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                        cmd.Parameters.AddWithValue("@CategoryCode", CategoryCode);
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                        cmd.Parameters.AddWithValue("@CategoryShortCode", CategoryShortCode);
                        cmd.Parameters.AddWithValue("@ModifiedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }

        public Int32 Update_Customer_Group_Details()
        {
            var session = Session.Get();
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
                        cmd.CommandText = "CustomerTypeCategoryGroupDetails";
                        cmd.Parameters.AddWithValue("@Parameter", 12);
                        cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);
                        cmd.Parameters.AddWithValue("@GroupCode", GroupCode);
                        cmd.Parameters.AddWithValue("@GroupName", GroupName);
                        cmd.Parameters.AddWithValue("@GroupShortCode", GroupShortCode);
                        cmd.Parameters.AddWithValue("@ModifiedBy", session.UserId);
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

                        return 0;
                    }
                }
            }
        }

        public DataTable Fetch_Type_Code() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 13);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);   
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

        public DataTable Fetch_Category_Code() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 14);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);
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

        public DataTable Fetch_Group_Code() //Save in CustomerTypeCategoryGroup Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();
            var session = Session.Get();
            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "CustomerTypeCategoryGroupDetails";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 15);
                cmd.Parameters.AddWithValue("@EntityId", session.EntityID);
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
