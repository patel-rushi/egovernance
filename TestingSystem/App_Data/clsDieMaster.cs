using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace TestingSystems
{
    class clsDieMaster
    {
        SqlConnection con = new SqlConnection();
        clsDAL obj = new clsDAL();

        #region Property


        public int DeletedBy { get; set; }

        public DateTime DeletedOn { get; set; }

        public int Safety_Stock { get; set; }

        public Int32 DieQty { get; set; }

        public String InwardDate { get; set; }

        public Guid Store { get; set; }

        public Double DieValue { get; set; }

        public clsDieMaster()
        {
            con = obj.Con();
        }

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


        public int EntityID { get; set; }



        private int _All_Cust;

        public int All_Cust
        {
            get
            {
                return _All_Cust;
            }
            set
            {
                _All_Cust = value;
            }

        }

        private String _Casting_Code;

        public String Casting_Code
        {
            get
            {
                return _Casting_Code;
            }
            set
            {
                _Casting_Code = value;
            }
        }

        private String _Casting_Name;

        public String Casting_Name
        {
            get
            {
                return _Casting_Name;
            }
            set
            {
                _Casting_Name = value;
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

        private Guid _DieId;

        public Guid DieId
        {
            get
            {
                return _DieId;
            }
            set
            {
                _DieId = value;
            }
        }



        private DateTime _DieDate;

        public DateTime DieDate
        {
            get
            {
                return _DieDate;
            }
            set
            {
                _DieDate = value;
            }
        }

        private String _Reason;

        public String Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        private String _Metal_Grade;

        public String Metal_Grade
        {
            get
            {
                return _Metal_Grade;
            }
            set
            {
                _Metal_Grade = value;
            }
        }



        private DataTable _dt_CustValue;

        public DataTable dt_CustValue
        {
            get
            {
                return _dt_CustValue;
            }
            set
            {
                _dt_CustValue = value;
            }
        }

        private DataTable _dtCastingDieMapping;

        public DataTable dtCastingDieMapping
        {
            get
            {
                return _dtCastingDieMapping;
            }
            set
            {
                _dtCastingDieMapping = value;
            }
        }

        private DataTable _dtcavity;

        public DataTable dtcavity
        {
            get
            {
                return _dtcavity;
            }
            set
            {
                _dtcavity = value;
            }
        }

        private DataTable _dt_MachineDieMapping;

        public DataTable dt_MachineDieMapping
        {
            get
            {
                return _dt_MachineDieMapping;
            }
            set
            {
                _dt_MachineDieMapping = value;
            }
        }

        private String _Die_Code;

        public String Die_Code
        {
            get
            {
                return _Die_Code;
            }
            set
            {
                _Die_Code = value;
            }
        }

        private String _Die_Name;

        public String Die_Name
        {
            get
            {
                return _Die_Name;
            }
            set
            {
                _Die_Name = value;
            }

        }

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

        private int _IsActive;      //Die Active flag

        public int IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }

        }

        private int _No_of_Removables;

        public int No_of_Removables
        {
            get
            {
                return _No_of_Removables;
            }
            set
            {
                _No_of_Removables = value;
            }

        }

        private Guid _CastingId;

        public Guid CastingId
        {
            get
            {
                return _CastingId;
            }
            set
            {
                _CastingId = value;
            }
        }

        private Guid _CustomerId;

        public Guid Customer_Id
        {
            get
            {
                return _CustomerId;
            }
            set
            {
                _CustomerId = value;
            }
        }

        private String _Plunger_Size;

        public String Plunger_Size
        {
            get
            {
                return _Plunger_Size;
            }
            set
            {
                _Plunger_Size = value;
            }
        }

        private String _Metal_Temp;

        public String Metal_Temp
        {
            get
            {
                return _Metal_Temp;
            }
            set
            {
                _Metal_Temp = value;
            }
        }

        private String _No_Of_Cavity;

        public String No_Of_Cavity
        {
            get
            {
                return _No_Of_Cavity;
            }
            set
            {
                _No_Of_Cavity = value;
            }
        }


        private String _DieLocation;

        public String DieLocation
        {
            get
            {
                return _DieLocation;
            }
            set
            {
                _DieLocation = value;
            }
        }



        private String _DieType;

        public String DieType
        {
            get
            {
                return _DieType;
            }
            set
            {
                _DieType = value;
            }
        }

        private double _GrossWeight;

        public double GrossWeight
        {
            get
            {
                return _GrossWeight;
            }
            set
            {
                _GrossWeight = value;
            }
        }

        private double _RunnerRiserWeight;

        public double RunnerRiserWeight
        {
            get
            {
                return _RunnerRiserWeight;
            }
            set
            {
                _RunnerRiserWeight = value;
            }
        }

        private double _NetWeight;

        public double NetWeight
        {
            get
            {
                return _NetWeight;
            }
            set
            {
                _NetWeight = value;
            }
        }

        private String _LossOn;

        public String LossOn
        {
            get
            {
                return _LossOn;
            }
            set
            {
                _LossOn = value;
            }
        }

        private String _LossWeight;

        public String LossWeight
        {
            get
            {
                return _LossWeight;
            }
            set
            {
                _LossWeight = value;
            }
        }

        private String _LossPercent;

        public String LossPercent
        {
            get
            {
                return _LossPercent;
            }
            set
            {
                _LossPercent = value;
            }
        }

        private String _Remarks;

        public String Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        //DieMachine_Mapping


        private String _Priority;

        public String Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }

        private double _Best_Production_hour;

        public double Best_Production_hour
        {
            get
            {
                return _Best_Production_hour;
            }
            set
            {
                _Best_Production_hour = value;
            }
        }



        private double _Shot_weight;

        public double Shot_weight
        {
            get
            {
                return _Shot_weight;
            }
            set
            {
                _Shot_weight = value;
            }
        }

        private double _Casting_weight;

        public double Casting_weight
        {
            get
            {
                return _Casting_weight;
            }
            set
            {
                _Casting_weight = value;
            }
        }

        private String _Limit_Switch;

        public String Limit_Switch
        {
            get
            {
                return _Limit_Switch;
            }
            set
            {
                _Limit_Switch = value;
            }
        }

        private String _Phase1;

        public String Phase1
        {
            get
            {
                return _Phase1;
            }
            set
            {
                _Phase1 = value;
            }
        }

        private String _Phase2;

        public String Phase2
        {
            get
            {
                return _Phase2;
            }
            set
            {
                _Phase2 = value;
            }
        }

        private String _Phase3;

        public String Phase3
        {
            get
            {
                return _Phase3;
            }
            set
            {
                _Phase3 = value;
            }
        }

        private String _T1;

        public String T1
        {
            get
            {
                return _T1;
            }
            set
            {
                _T1 = value;
            }
        }

        private String _T2;

        public String T2
        {
            get
            {
                return _T2;
            }
            set
            {
                _T2 = value;
            }
        }


        private String _T3;

        public String T3
        {
            get
            {
                return _T3;
            }
            set
            {
                _T3 = value;
            }
        }

        private String _T4;

        public String T4
        {
            get
            {
                return _T4;
            }
            set
            {
                _T4 = value;
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
        public bool ShotBlastable { get; set; }

        public Guid MachineId { get; set; }

        public String DenzingIndexNo { get; set; }
        public String GrainSize { get; set; }
        public String DieTempreture { get; set; }
        public String DegassingTime { get; set; }
        public String PouringTime { get; set; }
        public String SolidificationTime { get; set; }
        public String Humidity { get; set; }
        public Int64 DieExpiry { get; set; }

        //added by yashvi
        public DataTable DtCastingDieDetail { get; set; }
        public Boolean IsSaveCastingDetails { get; set; }


        public bool IsOwnByUs { get; set; }

        public bool IsOwnByCustomer { get; set; }
        #endregion

        public Int32 Insert_Die_master() //Save in Die Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@CustomerId", _CustomerId);

                cmd.Parameters.AddWithValue("@DieCode", _Die_Code);

                cmd.Parameters.AddWithValue("@AllCust", _All_Cust);

                cmd.Parameters.AddWithValue("@DieType", _DieType);

                cmd.Parameters.AddWithValue("@DieLocation", _DieLocation);

                cmd.Parameters.AddWithValue("@Store", Store);

                cmd.Parameters.AddWithValue("@DieName", _Die_Name);

                cmd.Parameters.AddWithValue("@Plunger_Size", _Plunger_Size);

                cmd.Parameters.AddWithValue("@Metal_Temp", _Metal_Temp);

                cmd.Parameters.AddWithValue("@No_of_Removables", _No_of_Removables);

                cmd.Parameters.AddWithValue("@No_Of_Cavity", _No_Of_Cavity);

                cmd.Parameters.AddWithValue("@Best_Production_hour", _Best_Production_hour);

                cmd.Parameters.AddWithValue("@Shot_Weight", _Shot_weight);

                //cmd.Parameters.AddWithValue("@Casting_Weight", _Casting_weight);

                cmd.Parameters.AddWithValue("@GrossWt", _GrossWeight);

                cmd.Parameters.AddWithValue("@NetWt", _NetWeight);

                cmd.Parameters.AddWithValue("@RunnerRiserWt", _RunnerRiserWeight);

                cmd.Parameters.AddWithValue("@Loss_On", _LossOn);
                if (_LossWeight != string.Empty)
                    cmd.Parameters.AddWithValue("@LossWt", _LossWeight);
                if (_LossPercent != string.Empty)
                    cmd.Parameters.AddWithValue("@LossPercent", _LossPercent);

                cmd.Parameters.AddWithValue("@Remarks", _Remarks);

                cmd.Parameters.AddWithValue("@Active_Deactive_Date", _DieDate);

                cmd.Parameters.AddWithValue("@Reason", _Reason);

                cmd.Parameters.AddWithValue("@IsActive", _IsActive);

                cmd.Parameters.AddWithValue("@Created_By", _Created_By);

                cmd.Parameters.AddWithValue("@Created_On", _Created_On);

                cmd.Parameters.AddWithValue("@EntityID", EntityID);
                cmd.Parameters.AddWithValue("@ShotBlastable", ShotBlastable);
                cmd.Parameters.AddWithValue("@DenzingIndexNo", DenzingIndexNo);
                cmd.Parameters.AddWithValue("@GrainSize", GrainSize);
                cmd.Parameters.AddWithValue("@DieTempreture", DieTempreture);
                cmd.Parameters.AddWithValue("@DegassingTime", DegassingTime);
                cmd.Parameters.AddWithValue("@PouringTime", PouringTime);
                cmd.Parameters.AddWithValue("@SolidificationTime", SolidificationTime);
                cmd.Parameters.AddWithValue("@Humidity", Humidity);
                cmd.Parameters.AddWithValue("@DieExpiry", DieExpiry);

                cmd.Parameters.AddWithValue("@OwnByUs", IsOwnByUs);

                cmd.Parameters.AddWithValue("@OwnByCustomer", IsOwnByCustomer);

                //added by yashvi
                cmd.Parameters.AddWithValue("@DieQty", DieQty);

                if(InwardDate != null && InwardDate != string.Empty && InwardDate != " ")
                {
                    cmd.Parameters.AddWithValue("@InwardDate", InwardDate);
                }
               

               

                cmd.Parameters.AddWithValue("@DieValue", DieValue);

                //DieMachine_Mapping

                string XML = string.Empty;

                if (_dt_MachineDieMapping != null && _dt_MachineDieMapping.Rows.Count > 0)
                {

                    using (StringWriter sw = new StringWriter())
                    {
                        _dt_MachineDieMapping.TableName = "DieMachineMapping";

                        _dt_MachineDieMapping.WriteXml(sw);

                        XML = sw.ToString();
                    }
                }
                cmd.Parameters.AddWithValue("@DieMachineMappingTable", XML);                    //Data Of Grid of FrmDieMaster Passing from XML to Database


                //DieCasting_Mapping

                string XMLCasting = string.Empty;

                using (StringWriter sw = new StringWriter())
                {
                    if (_dtCastingDieMapping != null && _dtCastingDieMapping.Rows.Count > 0)
                    {
                        _dtCastingDieMapping.TableName = "CastingMaster";

                        _dtCastingDieMapping.WriteXml(sw);

                        XMLCasting = sw.ToString();
                    }
                }

                cmd.Parameters.AddWithValue("@CastingMasterTable", XMLCasting);                    //Data Of Grid of FrmDieMaster Passing from XML to Database


                //DieCavity_Mapping

                string XMLCavity = string.Empty;


                using (StringWriter sw = new StringWriter())
                {
                    if (_dtcavity != null && _dtcavity.Rows.Count > 0)
                    {
                        _dtcavity.TableName = "CavityMaster";

                        _dtcavity.WriteXml(sw);

                        XMLCavity = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                    }
                }

                cmd.Parameters.AddWithValue("@CavityMasterTable", XMLCavity);


                // CustomerDieMapping

                string XML_Cust = string.Empty;

                using (StringWriter sw_Cust = new StringWriter())
                {
                    if (_dt_CustValue != null && _dt_CustValue.Rows.Count > 0)
                    {
                        _dt_CustValue.TableName = "CustomerDieMapping";

                        _dt_CustValue.WriteXml(sw_Cust);

                        XML_Cust = sw_Cust.ToString();
                    }
                }

                cmd.Parameters.AddWithValue("@CustomerDieMappingTable", XML_Cust);


                #region CastingDieDetail Added By Yashvi
                if (DtCastingDieDetail != null && DtCastingDieDetail.Rows.Count > 0)
                {
                    string XMLCastingPattern = "";
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        DtCastingDieDetail.TableName = "CastingPatternMapping";

                        DtCastingDieDetail.WriteXml(stringWriter);

                        XMLCastingPattern = stringWriter.ToString();
                    }
                    cmd.Parameters.AddWithValue("@CastingPatternMapping", XMLCastingPattern);
                }

                cmd.Parameters.AddWithValue("@IsSaveCastingDetails", IsSaveCastingDetails);
                #endregion

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
                return -1;
            }
        }


        public Int32 Update_Die_master() //Update in Die Master
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 9);

                cmd.Parameters.AddWithValue("@CustomerId", _CustomerId);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

                cmd.Parameters.AddWithValue("@AllCust", _All_Cust);

                cmd.Parameters.AddWithValue("@DieCode", _Die_Code);

                cmd.Parameters.AddWithValue("@DieName", _Die_Name);

                cmd.Parameters.AddWithValue("@DieType", _DieType);

                cmd.Parameters.AddWithValue("@DieLocation", _DieLocation);

                cmd.Parameters.AddWithValue("@Store", Store);

                cmd.Parameters.AddWithValue("@Plunger_Size", _Plunger_Size);

                cmd.Parameters.AddWithValue("@Metal_Temp", _Metal_Temp);

                cmd.Parameters.AddWithValue("@No_Of_Cavity", _No_Of_Cavity);

                cmd.Parameters.AddWithValue("@Best_Production_hour", _Best_Production_hour);

                cmd.Parameters.AddWithValue("@Shot_Weight", _Shot_weight);

                cmd.Parameters.AddWithValue("@Casting_Weight", _Casting_weight);

                cmd.Parameters.AddWithValue("@GrossWt", _GrossWeight);

                cmd.Parameters.AddWithValue("@NetWt", _NetWeight);

                cmd.Parameters.AddWithValue("@RunnerRiserWt", _RunnerRiserWeight);

                cmd.Parameters.AddWithValue("@Loss_On", _LossOn);
                if (_LossWeight != string.Empty)
                    cmd.Parameters.AddWithValue("@LossWt", _LossWeight);
                if (_LossPercent != string.Empty)
                    cmd.Parameters.AddWithValue("@LossPercent", _LossPercent);


                cmd.Parameters.AddWithValue("@Remarks", _Remarks);

                cmd.Parameters.AddWithValue("@No_of_Removables", _No_of_Removables);

                cmd.Parameters.AddWithValue("@Reason", _Reason);

                cmd.Parameters.AddWithValue("@IsActive", _IsActive);

                cmd.Parameters.AddWithValue("@Active_Deactive_Date", _DieDate);

                cmd.Parameters.AddWithValue("@Modified_By", _Modified_By);

                cmd.Parameters.AddWithValue("@Modified_On", _Modified_On);

                cmd.Parameters.AddWithValue("@EntityID", EntityID);
                cmd.Parameters.AddWithValue("@ShotBlastable", ShotBlastable);
                cmd.Parameters.AddWithValue("@DenzingIndexNo", DenzingIndexNo);
                cmd.Parameters.AddWithValue("@GrainSize", GrainSize);
                cmd.Parameters.AddWithValue("@DieTempreture", DieTempreture);
                cmd.Parameters.AddWithValue("@DegassingTime", DegassingTime);
                cmd.Parameters.AddWithValue("@PouringTime", PouringTime);
                cmd.Parameters.AddWithValue("@SolidificationTime", SolidificationTime);
                cmd.Parameters.AddWithValue("@Humidity", Humidity);
                cmd.Parameters.AddWithValue("@DieExpiry", DieExpiry);
                cmd.Parameters.AddWithValue("@OwnByUs", IsOwnByUs);

                cmd.Parameters.AddWithValue("@OwnByCustomer", IsOwnByCustomer);

                //added by yashvi
                cmd.Parameters.AddWithValue("@DieQty", DieQty);
                if (InwardDate != null && InwardDate != string.Empty && InwardDate != " ")
                {
                    cmd.Parameters.AddWithValue("@InwardDate", InwardDate);
                }

                cmd.Parameters.AddWithValue("@DieValue", DieValue);

                //DieMachine_Mapping

                string XML = string.Empty;
                //if (_dt_MachineDieMapping != null && _dt_MachineDieMapping.Rows.Count > 0)
                //{
                //    using (StringWriter sw = new StringWriter())
                //    {
                //        if (!_dt_MachineDieMapping.IsNullOrEmpty())
                //        {
                //            _dt_MachineDieMapping.TableName = "DieMachineMapping";

                //            _dt_MachineDieMapping.WriteXml(sw);

                //            XML = sw.ToString();
                //        }
                        
                //    }

                //    cmd.Parameters.AddWithValue("@DieMachineMappingTable", XML);                    //Data Of Grid of FrmDieMaster Passing from XML to Database
                //}



                // Die Casting Details

                string XMLCasting = string.Empty;

                //if (_dtCastingDieMapping != null && _dtCastingDieMapping.Rows.Count > 0)
                //{
                //    using (StringWriter sw = new StringWriter())
                //    {
                //        if (!_dtCastingDieMapping.IsNullOrEmpty())
                //        {
                //            _dtCastingDieMapping.TableName = "CastingMaster";

                //            _dtCastingDieMapping.WriteXml(sw);

                //            XMLCasting = sw.ToString();
                //        }
                //    }

                //    cmd.Parameters.AddWithValue("@CastingMasterTable", XMLCasting);
                //}
                //DieCavity_Mapping

                string XMLCavity = string.Empty;

                //using (StringWriter sw = new StringWriter())
                //{
                //    if (!dtcavity.IsNullOrEmpty())
                //    {
                //        dtcavity.TableName = "CavityMaster";

                //        dtcavity.WriteXml(sw);

                //        XMLCavity = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                //    }
                    
                //}

                //cmd.Parameters.AddWithValue("@CavityMasterTable", XMLCavity);

                // CustomerDieMapping

                string XML_Cust = string.Empty;

                //using (StringWriter sw_Cust = new StringWriter())
                //{
                //    if (!dt_CustValue.IsNullOrEmpty())
                //    {
                //        dt_CustValue.TableName = "CustomerDieMapping";

                //        dt_CustValue.WriteXml(sw_Cust);

                //        XML_Cust = sw_Cust.ToString();
                //    }
                //}

                //cmd.Parameters.AddWithValue("@CustomerDieMappingTable", XML_Cust);


                #region CastingDieDetail Added By Yashvi
                //if (DtCastingDieDetail != null && DtCastingDieDetail.Rows.Count > 0)
                //{
                //    string XMLCastingPattern = "";
                //    using (StringWriter stringWriter = new StringWriter())
                //    {
                //        if (!DtCastingDieDetail.IsNullOrEmpty())
                //        {
                //            DtCastingDieDetail.TableName = "CastingPatternMapping";

                //            DtCastingDieDetail.WriteXml(stringWriter);

                //            XMLCastingPattern = stringWriter.ToString();
                //        }
                       
                //    }
                //    cmd.Parameters.AddWithValue("@CastingPatternMapping", XMLCastingPattern);
                //}

                cmd.Parameters.AddWithValue("@IsSaveCastingDetails", IsSaveCastingDetails);
                #endregion

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


        public Int32 Delete_From_DieMaster() // Delete value from DieMaster and from DieMachineMapping with DieId
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 6);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

                cmd.Parameters.AddWithValue("@IsDeleted", _Is_Deleted);

                cmd.Parameters.AddWithValue("@DeletedBy", DeletedBy);

                cmd.Parameters.AddWithValue("@DeletedOn", DeletedOn);

                cmd.Parameters.AddWithValue("@EntityID", EntityID);


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

        public DataTable FetchDieCodeDieName()  // Fetch all Details for Grid from Table DieMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 12);
                if (_Die_Name != null)
                {
                    cmd.Parameters.AddWithValue("@DieName", _Die_Name);
                }
                if (_Die_Code != null)
                {
                    cmd.Parameters.AddWithValue("@DieCode", _Die_Code);
                }
                if (_DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
                }

                da.SelectCommand = cmd;

                da.Fill(dt);

                cmd.Parameters.Clear();

                _DieId = Guid.Empty;

                _Die_Name = null;

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

        ///  <summary>
        ///   Table Name         |  Fields
        /// -----------------------------------------
        ///1) DieMachineMapping  | Priority,Limit_Switch,Phase1,Phase2,Phase3,T1,T2,T3,T4
        ///2) MachineMaster      | MachineNo,MachineName
        ///  </summary>
        public DataTable Fetch_Machine_Details_From_DieMaster()  // Fetch Machine Details for Grid where Die Code in Known
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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


        public DataTable Fetch_Details_From_DieMaster()  // Fetch all Details for Grid from Table DieMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 4);

                cmd.Parameters.AddWithValue("@PageNumber", _PageNumber);
                cmd.Parameters.AddWithValue("@PageSize", _PageSize);
                cmd.Parameters.AddWithValue("@InitialLoad", _InitialLoad);
                if (_DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
                }
                if (_CustomerId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _CustomerId);
                }
                if (_Casting_Name != null && _Casting_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingName", _Casting_Name);
                }

                if (_Die_Name != null && _Die_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieName", _Die_Name);
                }

                if (_DieType != null && _DieType != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieType", _DieType);
                }

                if (_CastingId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingId", _CastingId);
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
        /// <summary>
        /// This Function will fetch total no of Records and show in Paging Control.
        /// </summary>
       
        public Int32 Fetch_Total_DieRecords()  
        {

            SqlCommand cmd = new SqlCommand();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                if (_DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
                }
                if (_CustomerId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _CustomerId);
                }
                if (_Casting_Name != null && _Casting_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingName", _Casting_Name);
                }

                if (_Die_Name != null && _Die_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieName", _Die_Name);
                }

                if (_DieType != null && _DieType != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieType", _DieType);
                }

                if (_CastingId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingId", _CastingId);
                }

                SqlParameter return_parameter = new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int);
                return_parameter.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(return_parameter);
                cmd.Parameters.AddWithValue("@Parameter", 19);
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

        public DataTable FetchDieType()  // Fetch Die Type DieMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 15);

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

        public DataTable FetchMetalGrade()  // Fetch Metal Grade
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                cmd.Parameters.AddWithValue("@MetalGrade", _Metal_Grade);

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

        public DataTable FetchMetalGradeFilter()  // Fetch Metal Grade
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

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


        public DataTable Fetch_Details_From_Machine_Master()  // Fetch all Details  from Table MachineMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

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

        public DataTable Fetch_DieId_From_DieMaster()  // Fetch DieId from DieMaster where diecode is known
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 5);

                cmd.Parameters.AddWithValue("@DieCode", _Die_Code);

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

        public DataTable Fetch_Details_From_DieMaster_From_DieId()  // Fetch DieId from DieMaster and DieStatus Details where dieId is known
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 7);

                if (_DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
                }
                cmd.Parameters.AddWithValue("@DieCode", _Die_Code);

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

        public DataTable Fetch_Details_From_DieMachineMapping_From_DieId()  // Fetch DieId from DieMachineMapping where dieId is known
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 8);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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

        public DataTable Fetch_Casting_details_From_Casting_Master()        //Fetch Casting Details from Casting Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Casting_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 2);

                cmd.Parameters.AddWithValue("@CastingCode", _Casting_Code);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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

        public DataTable Fetch_Casting_Grade_details()        //Fetch Casting Details from Casting Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Casting_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 30);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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


        public DataTable Fetch_Cavity_details()        //Fetch Casting Details from Casting Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Casting_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 13);



                cmd.Parameters.AddWithValue("@DieId", _DieId);

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




        public DataTable Fetch_Details_From_CustomerDieMapping()  // Fetch DieId from CustomerDieMapping where dieId is known
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 10);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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

        public DataTable SearchingDieRegister()  // Searching in Die Register
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 13);

                if (_DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
                }
                if (_CustomerId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CustomerId", _CustomerId);
                }
                if (_Casting_Name != null && _Casting_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingName", _Casting_Name);
                }

                if (_Die_Name != null && _Die_Name != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieName", _Die_Name);
                }

                if (_DieType != null && _DieType != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieType", _DieType);
                }

                if (_CastingId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@CastingId", _CastingId);
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

        public DataTable Fetch_ItemName()  // Searching in Die Register
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 14);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

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





        public DataTable Fetch_CastingCode_Casting_Master()        //Check for already exist Casting Code Casting Master
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Casting_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 11);

                cmd.Parameters.AddWithValue("@CastingCode", _Casting_Code);

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

        public DataTable FetchDieName()  // Fetch all Details for Grid from Table DieMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 17);

                if (_DieId != Guid.Empty)
                    cmd.Parameters.AddWithValue("@DieId", _DieId);

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

        public DataTable CheckStatusofCustomer()  // Fetch Metal Grade
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 18);

                cmd.Parameters.AddWithValue("@DieID", _DieId);

                cmd.Parameters.AddWithValue("@CustomerID", _CustomerId);

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


        public int UnBlock_From_DieMaster()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            DataTable dt = new DataTable();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 20);

                cmd.Parameters.AddWithValue("@DieId", _DieId);

                cmd.Parameters.AddWithValue("@IsDeleted", _Is_Deleted);

                cmd.Parameters.AddWithValue("@DeletedBy", DeletedBy);

                cmd.Parameters.AddWithValue("@DeletedOn", DeletedOn);

                cmd.Parameters.AddWithValue("@EntityID", EntityID);


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

        // Edited By Roopal

        public DataTable Fetch_Metal_Name_With_Filters()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 16);

                cmd.Parameters.AddWithValue("@MetalGrade", _Metal_Grade);

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

        public DataTable Fetch_Machine_Data()  // Fetch CastingCode from CastingMaster
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 21);


                if (MachineId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@MachineId", MachineId);
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

        public DataTable Fetch_DieCode()
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 22);


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

        public DataTable FetchMetalName()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "Die_Master";

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", 23);

                if (DieId != Guid.Empty)
                {
                    cmd.Parameters.AddWithValue("@DieId", _DieId);
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
    }
}
