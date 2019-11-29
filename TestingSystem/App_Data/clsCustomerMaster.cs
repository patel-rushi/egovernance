using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using TestingSystems.Helpers;

namespace TestingSystems
{
    class clsCustomerMaster
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsCustomerMaster()
        {
            con = obj.Con();
        }

        public String CustomerName { get; set; }

        public String EmailCode { get; set; }

        #region Properties

        public int SeriesID { get; set; }

        private int _Created_By;

        public int Created_By
        {
            get
            {
                return _Created_By;
            }
            set
            {
                _Created_By = value;
            }

        }

        public DataTable DtTestingCharges { get; set; }


        public int DeletedBy { get; set; }

        public DateTime DeletedOn { get; set; }

        public int EntityId { get; set; }
                
        private int _Is_Deleted;

        public int Is_Deleted
        {
            get
            {
                return _Is_Deleted;
            }
            set
            {
                _Is_Deleted = value;
            }

        }

        private DateTime _Created_On;

        public DateTime Created_On
        {
            get
            {
                return _Created_On;
            }
            set
            {
                _Created_On = value;
            }
        }

        private int _Modified_By;

        public int Modified_By
        {
            get
            {
                return _Modified_By;
            }
            set
            {
                _Modified_By = value;
            }

        }
        private DateTime _Modified_On;

        public DateTime Modified_On
        {
            get
            {
                return _Modified_On;
            }
            set
            {
                _Modified_On = value;
            }
        }

        private Guid _Customer_Id;

        public Guid Customer_Id
        {
            get
            {
                return _Customer_Id;
            }
            set
            {
                _Customer_Id = value;
            }
        }

        private String _Customer_flag;                      // Just flag for Customer or Supplier

        public String Customer_flag
        {
            get
            {
                return _Customer_flag;
            }
            set
            {
                _Customer_flag = value;
            }

        }

        private String _Category;                      // Just flag for Customer or Supplier

        public String Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }

        }

        private String _Customer_Name;

        public String Customer_Name
        {
            get
            {
                return _Customer_Name;
            }
            set
            {
                _Customer_Name = value;
            }
        }

        private String _User_Type;

        public String User_Type
        {
            get
            {
                return _User_Type;
            }
            set
            {
                _User_Type = value;
            }
        }

        //Address-Details


        private DataTable _dt_Address;

        public DataTable dt_Address
        {
            get
            {
                return _dt_Address;
            }
            set
            {
                _dt_Address = value;
            }
        }

        private String _Street;

        public String Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
            }
        }

        private String _Area;

        public String Area
        {
            get
            {
                return _Area;
            }
            set
            {
                _Area = value;
            }
        }

        private String _City;

        public String City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        private String _State;

        public String State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        private String _PinCode;

        public String PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }

        private String _Customer_Type;

        public String Customer_Type
        {
            get
            {
                return _Customer_Type;
            }
            set
            {
                _Customer_Type = value;
            }
        }

        private String _Customer_Category;

        public String Customer_Category
        {
            get
            {
                return _Customer_Category;
            }
            set
            {
                _Customer_Category = value;
            }
        }

        private String _Customer_Group;

        public String Customer_Group
        {
            get
            {
                return _Customer_Group;
            }
            set
            {
                _Customer_Group = value;
            }
        }
        
        // Contact-Details

        private DataTable _dt_Contact;

        public DataTable dt_Contact
        {
            get
            {
                return _dt_Contact;
            }
            set
            {
                _dt_Contact = value;
            }
        }
        private DataTable _dt_Bank;

        public DataTable dt_Bank
        {
            get
            {
                return _dt_Bank;
            }
            set
            {
                _dt_Bank = value;
            }
        }

        private String _Contact_Person;

        public String Contact_Person
        {
            get
            {
                return _Contact_Person;
            }
            set
            {
                _Contact_Person = value;
            }
        }

        private String __Contact;

        public String Contact
        {
            get
            {
                return __Contact;
            }
            set
            {
                __Contact = value;
            }
        }

        private String _E_mail;

        public String E_mail
        {
            get
            {
                return _E_mail;
            }
            set
            {
                _E_mail = value;
            }
        }

        private String _Department;

        public String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                _Department = value;
            }
        }

        private String _Designation;

        public String Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }

        // Financial-Details

        public String CustomerGroup { get; set; }
        public String TaxNo1 { get; set; }
        public String TaxNo2 { get; set; }
        public String TaxNo3 { get; set; }
        public String TaxNo4 { get; set; }
        public String TaxNo5 { get; set; }
        public Int32 PaymentTerms { get; set; }
        public string VendorCode { get; set; }
        public string CustomerCode { get; set; }
        public Guid ContactId { get; set; }
        public string DeleteDataContact { get; set; }

        private String _Division;

        public String Division
        {
            get
            {
                return _Division;
            }
            set
            {
                _Division = value;
            }
        }


        private String _Range;
        public String Range
        {
            get
            {
                return _Range;
            }
            set
            {
                _Range = value;
            }
        }

        private String _Commissionerate;
        public String Commissionerate
        {
            get
            {
                return _Commissionerate;
            }
            set
            {
                _Commissionerate = value;
            }
        }

        private Int32 _PageNumber;
        public Int32 PageNumber
        {
            get
            {
                return _PageNumber;
            }
            set
            {
                _PageNumber = value;
            }
        }

        private Int32 _PageSize;
        public Int32 PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = value;
            }
        }

        private Int32 _InitialLoad;
        public Int32 InitialLoad
        {
            get
            {
                return _InitialLoad;
            }
            set
            {
                _InitialLoad = value;
            }
        }

        private Guid _CustomerOrderId;
        public Guid CustomerOrderId
        {
            get
            {
                return _CustomerOrderId;
            }
            set
            {
                _CustomerOrderId = value;
            }
        }
        public String GSTNo { get; set; }
        public Guid CustomerTypeId { get; set; }
        public Guid CustomerCategoryId { get; set; }       
        public Guid CustomerGroupId { get; set; }
        private DataTable _dt_TDCDetail;
        public int SupStatus { get; set; }

        public DataTable dt_TDCDetail
        {
            get
            {
                return _dt_TDCDetail;
            }
            set
            {
                _dt_TDCDetail = value;
            }
        }

        public Guid TDCId { get; set; }
        public Int32 MetalId { get; set; }
        public Guid TestingChargeID { get; set; }
        #endregion

        public Int32 Insert_Customer_Master() //Save in Customer Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@CustomerName", _Customer_Name);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

                //   cmd.Parameters.AddWithValue("@CustomerType", _Customer_Type);

                //   cmd.Parameters.AddWithValue("@CustomerCategory", _Customer_Category);

                //   cmd.Parameters.AddWithValue("@CustomerGroup", CustomerGroup);

                cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);

                cmd.Parameters.AddWithValue("@TaxNo1", TaxNo1);
                cmd.Parameters.AddWithValue("@TaxNo2", TaxNo2);
                cmd.Parameters.AddWithValue("@TaxNo3", TaxNo3);
                cmd.Parameters.AddWithValue("@TaxNo4", TaxNo4);
                cmd.Parameters.AddWithValue("@TaxNo5", TaxNo5);
                cmd.Parameters.AddWithValue("@PaymentTerms", PaymentTerms);
                cmd.Parameters.AddWithValue("@Range", _Range);

                cmd.Parameters.AddWithValue("@Division", _Division);

                cmd.Parameters.AddWithValue("@Commssionerate", _Commissionerate);

                cmd.Parameters.AddWithValue("@Created_By", _Created_By);

                cmd.Parameters.AddWithValue("@Created_On", _Created_On);

                cmd.Parameters.AddWithValue("@EntityId", EntityId);

                cmd.Parameters.AddWithValue("@VendorCode", VendorCode);
                cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
                               
                //Address-Details

                string XML = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    dt_Address.TableName = "Address_Details";

                    dt_Address.WriteXml(stringWriter);

                    XML = stringWriter.ToString();
                }

                cmd.Parameters.AddWithValue("@Address_Details", XML);

                //Contact-Details

                string XML_Contact = "";

                using (StringWriter sw = new StringWriter())
                {
                    dt_Contact.TableName = "Contact_Details";

                    dt_Contact.WriteXml(sw);

                    XML_Contact = sw.ToString();
                }

                cmd.Parameters.AddWithValue("@Contact_Details", XML_Contact);

                string XML_Bank = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    dt_Bank.TableName = "Bank_Details";

                    dt_Bank.WriteXml(stringWriter);

                    XML_Bank = stringWriter.ToString();
                }

                cmd.Parameters.AddWithValue("@Bank_Details", XML_Bank);

                //Testing ChargeDetail
                string XMLChargeDetail = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (!DtTestingCharges.IsNullOrEmpty())
                    {
                        DtTestingCharges.TableName = "ChargeDetail";

                        DtTestingCharges.WriteXml(stringWriter);

                        XMLChargeDetail = stringWriter.ToString();
                    }

                }

                cmd.Parameters.AddWithValue("@TestingChargeDetail", XMLChargeDetail);

                string XMLTDCDetail = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (!dt_TDCDetail.IsNullOrEmpty())
                    {
                        dt_TDCDetail.TableName = "TDCDetail";

                        dt_TDCDetail.WriteXml(stringWriter);

                        XMLTDCDetail = stringWriter.ToString();
                    }

                }

                cmd.Parameters.AddWithValue("@TDCDetail", XMLTDCDetail);
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


        public DataTable Fetch_Customer_Type()    //Fetch data for Customer_Type
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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

        public Int32 Insert_Type_Master() //Save in User Type Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@UserType", _User_Type);

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


        public Int32 Insert_Category_Master() //Save in User Category Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@UserType", _User_Type);

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

        public DataTable Fetch_Customer_Supplier_Name_forfilter() //Fetch Customer Name from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Rate_Contract";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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

        public DataTable Fetch_Customer_Name() //Fetch Customer Name from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);
                if (_Customer_flag != null && _Customer_flag != string.Empty)
                    cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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

        public DataTable Fetch_Customer_Name_forTC() //Fetch Customer Name from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 19);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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
        public DataTable Fetch_Customer_Name_With_Filters() //Fetch Customer Name with Filters from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 7);

                cmd.Parameters.AddWithValue("@CustomerName", _Customer_Name);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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

        public DataTable Fetch_Supplier_Name_With_Filters() //Fetch Customer Name with Filters from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 15);

                cmd.Parameters.AddWithValue("@CustomerName", _Customer_Name);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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

        public DataTable Fetch_Customer_Category()    //Fetch data for Customer_Category
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

                cmd.Parameters.AddWithValue("@Customerflag", Customer_flag);

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

        public DataTable Fetch_CustomerId()    //Fetch Customer Id for Register where 
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 8);

                cmd.Parameters.AddWithValue("@CustomerName", _Customer_Name);

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

        public Int32 Delete_From_CustomerMaster() // Delete value from Customer Master and from Address master And Contact Master with CustomerId
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 9);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

                cmd.Parameters.AddWithValue("@IsDeleted", _Is_Deleted);

                cmd.Parameters.AddWithValue("@DeletedBy", DeletedBy);

                cmd.Parameters.AddWithValue("@DeletedOn", DeletedOn);

                cmd.Parameters.AddWithValue("@EntityId", EntityId);


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

        public DataTable Fetch_Customer_Address()    //Fetch Customer Address
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 10);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

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

        public DataTable Fetch_Customer_Contact_Details()    //Fetch Customer Contact Details
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

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

        public DataTable Fetch_Customer_Details()    //Fetch Customer Details where CustomerId in known
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 12);
                if (_Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);
                }

                if (_Customer_flag != null && _Customer_flag != "")
                {
                    cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);
                }
                if (_Customer_Category != null && _Customer_Category != "")
                {
                    cmd.Parameters.AddWithValue("@CustomerCategory", _Customer_Category);
                }

                if (_Customer_Type != null && _Customer_Type != "")
                {
                    cmd.Parameters.AddWithValue("@CustomerType", _Customer_Type);
                }

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

        public Int32 UpdateCustomerMaster() //Update in Customer Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 13);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

                cmd.Parameters.AddWithValue("@CustomerName", _Customer_Name);

                //cmd.Parameters.AddWithValue("@CustomerType", _Customer_Type);

                //cmd.Parameters.AddWithValue("@CustomerCategory", _Customer_Category);

                //cmd.Parameters.AddWithValue("@CustomerGroup", CustomerGroup);

                cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);

                cmd.Parameters.AddWithValue("@TaxNo1", TaxNo1);
                cmd.Parameters.AddWithValue("@TaxNo2", TaxNo2);
                cmd.Parameters.AddWithValue("@TaxNo3", TaxNo3);
                cmd.Parameters.AddWithValue("@TaxNo4", TaxNo4);
                cmd.Parameters.AddWithValue("@TaxNo5", TaxNo5);
                cmd.Parameters.AddWithValue("@PaymentTerms", PaymentTerms);
                cmd.Parameters.AddWithValue("@Range", _Range);

                cmd.Parameters.AddWithValue("@Division", _Division);

                cmd.Parameters.AddWithValue("@Commssionerate", _Commissionerate);

                cmd.Parameters.AddWithValue("@Modified_By", _Modified_By);

                cmd.Parameters.AddWithValue("@Modified_On", _Modified_On);

                cmd.Parameters.AddWithValue("@EntityId", EntityId);

                cmd.Parameters.AddWithValue("@VendorCode", VendorCode);
                cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
                string XML_Address = "";

                using (StringWriter stringWriter = new StringWriter())
                {
                    dt_Address.TableName = "Address_Details";

                    dt_Address.WriteXml(stringWriter);

                    XML_Address = stringWriter.ToString();
                }

                cmd.Parameters.AddWithValue("@Address_Details", XML_Address);

                //Contact-Details

                string XML_Contact = "";

                using (StringWriter sw = new StringWriter())
                {
                    dt_Contact.TableName = "Contact_Details";

                    dt_Contact.WriteXml(sw);

                    XML_Contact = sw.ToString();
                }

                cmd.Parameters.AddWithValue("@Contact_Details", XML_Contact);

                string XML_Bank = "";

                using (StringWriter sw = new StringWriter())
                {
                    dt_Bank.TableName = "Bank_Details";

                    dt_Bank.WriteXml(sw);

                    XML_Bank = sw.ToString();
                }

                cmd.Parameters.AddWithValue("@Bank_Details", XML_Bank);

                if (DeleteDataContact != null && DeleteDataContact != "")
                {
                    cmd.Parameters.AddWithValue("@DeleteDataContact", DeleteDataContact.Substring(1, (DeleteDataContact.Length) - 1));
                }

                string XMLChargeDetail = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (!DtTestingCharges.IsNullOrEmpty())
                    {
                        DtTestingCharges.TableName = "ChargeDetail";

                        DtTestingCharges.WriteXml(stringWriter);

                        XMLChargeDetail = stringWriter.ToString();
                    }

                }

                cmd.Parameters.AddWithValue("@TestingChargeDetail", XMLChargeDetail);

                string XMLTDCDetail = String.Empty;

                using (StringWriter stringWriter = new StringWriter())
                {
                    if (!dt_TDCDetail.IsNullOrEmpty())
                    {
                        dt_TDCDetail.TableName = "TDCDetail";

                        dt_TDCDetail.WriteXml(stringWriter);

                        XMLTDCDetail = stringWriter.ToString();
                    }

                }

                cmd.Parameters.AddWithValue("@TDCDetail", XMLTDCDetail);

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

        public DataSet checkcustomerdiemapping()    //Fetch Customer Address
        {
            DataSet dt = new DataSet();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 14);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

                //SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.BigInt);

                //return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                //cmd.Parameters.Add(return_parameter);


                da.SelectCommand = cmd;

                da.Fill(dt);

                //  Int32 Invoice_Id = (Int32)cmd.Parameters["@RETURN_VALUE"].Value;


                //  SqlParameter retval = cmd.Parameters.Add("@a", SqlDbType.VarChar);
                //   int returnvalue = (int)(cmd.Parameters["a"].Value);

                //var returnParameter = cmd.Parameters.Add("@a", SqlDbType.Int);
                //returnParameter.Direction = ParameterDirection.ReturnValue;
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

        public int Fetch_Total_CustomerRecords()
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", _PageNumber);

                cmd.Parameters.AddWithValue("@PageSize", _PageSize);

                cmd.Parameters.AddWithValue("@InitialLoad", _InitialLoad);

                if (_Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);
                }

                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

                if (CustomerTypeId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                }
                if (CustomerCategoryId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                }
                if (CustomerGroupId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);
                }

                if (SupStatus >= 0)
                {
                    cmd.Parameters.AddWithValue("@SupStatus", SupStatus);
                }

                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);

                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;

                cmd.Parameters.Add(return_parameter);

                cmd.Parameters.AddWithValue("@Parameter", 17);

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

        public DataTable Fetch_Customer_Details_Id()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                cmd.Parameters.AddWithValue("@PageNumber", _PageNumber);

                cmd.Parameters.AddWithValue("@PageSize", _PageSize);

                cmd.Parameters.AddWithValue("@InitialLoad", _InitialLoad);
                if (_Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);
                }
                cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

                if (CustomerTypeId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerTypeId", CustomerTypeId);
                }
                if (CustomerCategoryId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerCategoryId", CustomerCategoryId);
                }
                if (CustomerGroupId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerGroupId", CustomerGroupId);
                }
                if (SupStatus >= 0)
                {
                    cmd.Parameters.AddWithValue("@SupStatus", SupStatus);
                }

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

        public int UnBlock_From_CustomerMaster()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 18);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

                cmd.Parameters.AddWithValue("@IsDeleted", _Is_Deleted);

                cmd.Parameters.AddWithValue("@DeletedBy", DeletedBy);

                cmd.Parameters.AddWithValue("@DeletedOn", DeletedOn);

                cmd.Parameters.AddWithValue("@EntityId", EntityId);


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

        public DataTable Fetch_Customer_Name_forTCInRegister() //Fetch Customer Name from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "TestCertficate";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 28);


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

        public DataTable Fetch_EmailId() //Fetch EmialId from Contact Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PartyEmailSetup";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);

                cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);

                cmd.Parameters.AddWithValue("@Code", EmailCode);

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
        public DataTable Fetch_CompanyEmailId() //Fetch EmialId from Contact Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "ConfigurationSetting";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 7);
                cmd.Parameters.AddWithValue("@Code", EmailCode);

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

        public DataTable Fetch_EmailBody() //Fetch EmialId from Contact Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PartyEmailSetup";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 8);

                cmd.Parameters.AddWithValue("@Code", EmailCode);

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

        public DataTable GetOrderDetail()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Pending_OrderNo";

                cmd.CommandType = CommandType.StoredProcedure;

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

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

        public DataTable PendingCastingFromCustomer()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PendingCastingFromCustomer";

                cmd.CommandType = CommandType.StoredProcedure;

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

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

        public DataTable PendingUniqueCastingFromCustomer()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "PendingUniqueCastingFromCustomer";

                cmd.CommandType = CommandType.StoredProcedure;

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

                if (_CustomerOrderId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@CustomerOrderId", _CustomerOrderId);

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
        public DataTable Fetch_CustomerGroup()    //Fetch data for CustomerGroup
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 20);

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

        public DataTable Fetch_Customer_Bank_Details()    //Fetch Customer Consignee
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 21);

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }
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

        public DataTable Fetch_Data_From_BankDetails()    //Fetch Customer Bank Details
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 22);

                if (Customer_Id != Guid.Empty && Customer_Id != null)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

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
        public DataTable Fetch_CompanyGstNo()    //Fetch Customer Address
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Company_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                var session = Session.Get();
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


        public DataTable FetchCustomerGSTNo()    //Fetch Customer Address
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 23);

                var session = Session.Get();

                if (Customer_Id != Guid.Empty && Customer_Id != null)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

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

        public DataTable FetchCustomerpaymentTerms() //Fetch Customer Name from Customer Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 24);

                cmd.Parameters.AddWithValue("@CustomerID", _Customer_Id);

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

        public DataTable FetchTestingChargeDetail()//This will fetch Testing Charge Detail.
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 26);

                if (Customer_Id != Guid.Empty && Customer_Id != null)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

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

        public DataTable FetchTestingCharges()    //Fetch Customer Consignee
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 27);

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }
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

        public DataTable Fetch_TDDetail()    //Fetch Customer Address
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 28);

                cmd.Parameters.AddWithValue("@CustomerId", _Customer_Id);

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

        public DataTable Fetch_FileNameByTDC()    //Fetch Customer Address
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 29);

                cmd.Parameters.AddWithValue("@TDCId", TDCId);

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

        public DataTable FetchTDCNo()    //Fetch Customer Id for Register where 
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 30);

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }

                if (MetalId != 0)
                {
                    cmd.Parameters.AddWithValue("@MetalId", MetalId);
                }
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

        public DataTable FetchSpecialRequirement()    //Fetch Customer Id for Register where 
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 31);

                if (Customer_Id != null && Customer_Id != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", Customer_Id);
                }
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

        public DataTable FetchTDCNoByMetal() //Fetch EmialId from Contact Master
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 32);
                cmd.Parameters.AddWithValue("@MetalId", MetalId);

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

        public Int32 Delete_Requirement_Parameter()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 33);

                if (TestingChargeID != null && TestingChargeID != Guid.Empty)
                    cmd.Parameters.AddWithValue("@TestingChargeID", TestingChargeID);


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

        public DataTable FetchCustomerFlag() 
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 34);
                cmd.Parameters.AddWithValue("@customerId", Customer_Id);

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

        public DataTable FetchCustomerSupplier()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 35);

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


        public DataTable FetchSupplierNameSeriesWise()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_Customer_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 36);

                if (_Customer_flag != null && _Customer_flag != string.Empty)
                    cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

                if (SeriesID != 0)
                    cmd.Parameters.AddWithValue("@SeriesID",SeriesID);

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

        public DataTable FetchPrefixSuffixSeparator()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "FetchPrefix_Suffix";

                cmd.CommandType = CommandType.StoredProcedure;

                if (SeriesID != 0)
                    cmd.Parameters.AddWithValue("@SeriesID", SeriesID);

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

        //Added by yashvi
        //This will fetch Supplier Name whose rate contract has been prepared.
        public DataTable FetchCustomerNameAccordingToRateContract()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Rate_Contract";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 26);
                if (_Customer_flag != null && _Customer_flag != string.Empty)
                    cmd.Parameters.AddWithValue("@Customerflag", _Customer_flag);

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