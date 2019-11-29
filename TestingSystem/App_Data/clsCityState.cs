using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsCityState
    {


        public static readonly clsCityState Instance = new clsCityState();

        #region Properties

        public int CountryId { get; set; }

        private int _StateId;

        public int StateId
        {
            get
            {
                return _StateId;
            }
            set
            {
                _StateId = value;
            }
        }

        private int _CityId;

        public int CityId
        {
            get
            {
                return _CityId;
            }
            set
            {
                _CityId = value;
            }
        }

        public string CountryName { get; set; }

        private int _IsDeleted;

        public int IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                _IsDeleted = value;
            }
        }

        private string _State;

        public string State
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

        private int _State_Code;

        public int State_Code
        {
            get
            {
                return _State_Code;
            }
            set
            {
                _State_Code = value;
            }
        }

        private string _City;

        public string City
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

        #endregion

        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        public clsCityState()
        {
            con = obj.Con();
        }

        public DataTable Fetch_State()    //Fetch data for State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 1);

                cmd.Parameters.AddWithValue("@State", _State);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);

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

        public DataTable Fetch_City()    //Fetch data for City
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@StateId", _StateId);

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

        public Int32 Delete_From_CityState() // Delete value from CityMaster
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);

                cmd.Parameters.AddWithValue("@CityId", _CityId);

                cmd.Parameters.AddWithValue("@IsDeleted", _IsDeleted);

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


        public DataTable Fetch_AllDetails()    //Fetch All City State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

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

        public Int32 Insert_CityState_Master()           //Save in City State Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 3);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);

                cmd.Parameters.AddWithValue("@State", _State);

                cmd.Parameters.AddWithValue("@City", _City);

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



        public Int32 Insert_City_Master()           //Insert in City in City Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@StateId", _StateId);

                cmd.Parameters.AddWithValue("@City", _City);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);

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

        public Int32 Update_CityState_Master()           //Save in City State Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 12);

                cmd.Parameters.AddWithValue("@CityId", _CityId);
                cmd.Parameters.AddWithValue("@StateId", _StateId);
                cmd.Parameters.AddWithValue("@CountryId", CountryId);

                cmd.Parameters.AddWithValue("@City", City);

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



        public bool CheckDuplication()    //Fetch All City State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 7);
                cmd.Parameters.AddWithValue("@City", City);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool CheckDuplicationExceptID()    //Fetch All City State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 8);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@CityId", CityId);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool StateCheckDuplication()    //Fetch All City State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 9);
                cmd.Parameters.AddWithValue("@State", State);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool StateCheckDuplicationExceptID()    //Fetch All City State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 10);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@StateId", StateId);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable Fetch_SelectedDetails()    //Fetch All City State Selefcted from Combobox
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                cmd.Parameters.AddWithValue("@StateId", _StateId);

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

        public DataTable Fetch_Country()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 13);

                cmd.Parameters.AddWithValue("@State", _State);

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


        public DataTable Fetch_CountryByState()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 36);

                cmd.Parameters.AddWithValue("@StateID", StateId);

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



        public bool CountryCheckDuplicate()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 14);
                cmd.Parameters.AddWithValue("@CountryName", CountryName);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int Insert_Country_CityState_Master()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 15);

                cmd.Parameters.AddWithValue("@CountryName", CountryName);

                cmd.Parameters.AddWithValue("@State", _State);

                cmd.Parameters.AddWithValue("@City", _City);

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

        public int InsertIntoCountry()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 22);

                cmd.Parameters.AddWithValue("@CountryName", CountryName);



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

        public int InsertIntoState()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 23);

                cmd.Parameters.AddWithValue("@CountryID", CountryId);//Addin Filter

                cmd.Parameters.AddWithValue("@State", _State);

                cmd.Parameters.AddWithValue("@StateCode", _State_Code);

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

        public int InsertIntoCity()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 24);
                cmd.Parameters.AddWithValue("@StateId", StateId);//Addin Filter


                cmd.Parameters.AddWithValue("@City", _City);

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


        public DataTable FetchCountry()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 19);

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

        public DataTable FetchState()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 20);
                if (CountryId != null && CountryId != 0)//Addin Filter
                {
                    cmd.Parameters.AddWithValue("@CountryId", CountryId);
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

        public DataTable FetchCity()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 21);
                if (StateId != null && StateId != 0)
                    cmd.Parameters.AddWithValue("@StateId", StateId);//Addin Filter
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

        public int UpdateIntoCountry()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 25);

                cmd.Parameters.AddWithValue("@CountryName", CountryName);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);

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

        public int UpdateIntoState()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 26);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);//Addin Filter

                cmd.Parameters.AddWithValue("@State", _State);

                cmd.Parameters.AddWithValue("@StateCode", _State_Code);

                cmd.Parameters.AddWithValue("@StateId", _StateId);

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

        public int UpdateIntoCity()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 27);

                cmd.Parameters.AddWithValue("StateID", StateId);//Addin State ID Depnedancy
                cmd.Parameters.AddWithValue("@City", _City);

                cmd.Parameters.AddWithValue("@CityId", _CityId);

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

        public bool CheckDuplicateCountry()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 28);
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                cmd.Parameters.AddWithValue("@CountryId", CountryId);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckDuplicateState()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 29);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@StateId", StateId);
                cmd.Parameters.AddWithValue("@CountryId", CountryId);//Country Dependancy Added

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckDuplicateCity()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 30);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@StateId", StateId);
                cmd.Parameters.AddWithValue("@CityId", CityId);

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                con.Close();

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;


            }

            catch (Exception ex)
            {
                con.Close();
                  
                ExceptionHandler.LogException(ex);
                System.Windows.Forms.MessageBox.Show(Helper.MessageBoxMessages.entryerror, Helper.MessageBoxCaptions.Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Int32 DeleteCountry() // Delete value from Country
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 31);

                cmd.Parameters.AddWithValue("@CountryId", CountryId);



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

        public Int32 DeleteState() // Delete value from State
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 32);

                cmd.Parameters.AddWithValue("@StateId", StateId);



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

        public Int32 DeleteCity() // Delete value from City
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 33);

                cmd.Parameters.AddWithValue("@CityId", CityId);



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

        public DataTable FetchStateByStateId()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 35);
                cmd.Parameters.AddWithValue("@StateId", StateId);
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

        public DataTable FetchCityByCityID()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter", 34);
                cmd.Parameters.AddWithValue("@CityId", CityId);
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

        public DataTable Fetch_State_fromCityID()    //Fetch data for State
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 17);

                cmd.Parameters.AddWithValue("@CityID", _CityId);

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

        public DataTable Fetch_CountryFromStateID()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 18);

                cmd.Parameters.AddWithValue("@StateId", _StateId);

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

        public DataTable Fetch_City_All()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "SP_City-State";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                //   cmd.Parameters.AddWithValue("@StateId", _StateId);

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
