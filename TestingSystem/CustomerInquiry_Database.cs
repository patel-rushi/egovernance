using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestingSystems
{
    class CustomerInquiry_Database
    {
        #region
        public Guid CustomerId { get; set; }
        public Guid ContactId { get; set; }
        public Guid InquiryId { get; set; }
        public string CompanyName { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string ContentNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Todate { get; set; }
        public string InquirySource { get; set; }
        public string Refrence { get; set; }
        public string Product  { get; set; }
        public string PersonRep { get; set; }
        public string CurrentStatus { get; set; }
        public string ifLost { get; set; }
        public DateTime LossWonDate { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        #endregion

        //Fetch Customer Name from CustomerMaster Table  --(1)
        public DataTable Fetch_CustomerName()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        } 
        //Fetch Customer Details --(2)
        public DataTable Fetch_PersonName()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmd.Parameters.AddWithValue("@Customerflag", 'C');
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }
        //--(4)
        public DataTable Fetch_CustomerDetail()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId); 
                        cmd.Parameters.AddWithValue("@Customerflag", 'C');
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }

        public DataTable Fetch_CustomerDetail2()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 14);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }
        // --(3)
        public int Update_CustomerInquiry()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                        if(ContactId!=Guid.Empty)
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);

                        cmd.Parameters.AddWithValue("@PersonName", PersonName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ContentNo", ContentNo);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@InquirySource", InquirySource);
                        cmd.Parameters.AddWithValue("@Refrence", Refrence);
                        cmd.Parameters.AddWithValue("@CompanyReprentative", Product);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@ifLost", ifLost);
                        cmd.Parameters.AddWithValue("@LossWonDate", LossWonDate);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ex.StackTrace);
                return 0;
            }
        }
        // --(5)
        public DataTable Fetch_ALL_InquiryRecord()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 5);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");

                        if(CustomerId != Guid.Empty)
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                        cmd.Parameters.AddWithValue("@CityId", CityId);
                        cmd.Parameters.AddWithValue("@StateId", StateId);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@CompanyReprentative", Product);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@Todate", Todate);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }
        // --(9)
        public DataTable Fetch_ALL_InquiryRecord_For_FillUpdate()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 9);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@InquiryId", InquiryId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }
        //--(6) not use
        public int Update_AND_Insert_CustomerInquiry()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 6);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmd.Parameters.AddWithValue("@PersonName", PersonName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ContentNo", ContentNo);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@InquirySource", InquirySource);
                        cmd.Parameters.AddWithValue("@Refrence", Refrence);
                        cmd.Parameters.AddWithValue("@CompanyReprentative", Product);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@ifLost", ifLost);
                        cmd.Parameters.AddWithValue("@LossWonDate", LossWonDate);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return 0;
            }
        }
        //--(7) not use
        public int INSERT_CustomerInquiry()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 7);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                        cmd.Parameters.AddWithValue("@PersonName", PersonName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ContentNo", ContentNo);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@InquirySource", InquirySource);
                        cmd.Parameters.AddWithValue("@Refrence", Refrence);
                        cmd.Parameters.AddWithValue("@CompanyReprentative", Product);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@ifLost", ifLost);
                        cmd.Parameters.AddWithValue("@LossWonDate", LossWonDate);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return 0;
            }
        }

        //--(8)
        public int DeleteInquiry()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 8);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@InquiryId", @InquiryId);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return 0;
            }
        }

        // --(10)
        public int UpdateALL()
        {
            try
            {
                #region
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 10);
                        cmd.Parameters.AddWithValue("@Customerflag", "C");
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                        if(ContactId!=Guid.Empty)
                        cmd.Parameters.AddWithValue("@ContactId", ContactId);

                        cmd.Parameters.AddWithValue("@InquiryId", InquiryId);
                        cmd.Parameters.AddWithValue("@PersonName", PersonName);
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ContentNo", ContentNo);
                        cmd.Parameters.AddWithValue("@City", City);
                        cmd.Parameters.AddWithValue("@State", State);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@InquirySource", InquirySource);
                        cmd.Parameters.AddWithValue("@Refrence", Refrence);
                        cmd.Parameters.AddWithValue("@CompanyReprentative", Product);
                        cmd.Parameters.AddWithValue("@PersonRep", PersonRep);
                        cmd.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
                        cmd.Parameters.AddWithValue("@ifLost", ifLost);
                        cmd.Parameters.AddWithValue("@LossWonDate", LossWonDate);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                #endregion
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return 0;
            }
        }

        //--(11)
        public DataTable FetchState()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.Parameters.AddWithValue("@Parameter", 11);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion
        }
        //--(12)
        public DataTable FetchCity()
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 12);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion

        }
        public DataTable Fetch_State_fromCityID()    //Fetch data for State
        {
            #region
            DataTable dt = new DataTable();
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_InquiryMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 13);
                        cmd.Parameters.AddWithValue("@CityId", CityId);
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        cmd.Parameters.Clear();
                        con.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return dt;
            #endregion

        }
    }
}
