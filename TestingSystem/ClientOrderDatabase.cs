using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using TestingSystems.Helpers;

namespace TestingSystems
{
    class ClientOrderDatabase
    {
        #region
        //
        public Guid ClientOrderID { get; set; }
        public Guid CustomerId { get; set; }
        public string ClientOrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmount { get; set; }
        public string Descriptions { set; get; }
        public int AMCRequired { get; set; }

        //AMC required fields
        public DataTable pDt_AMC { get; set; }
        //public Guid AMCID { get; set; }
        //public double AMCAmount { get; set; }
        public DateTime? AMCStartDate { get; set; }
        public DateTime? AMCEndDate { get; set; }
        #endregion

        //public Int32 InsertClientOrder_Master()
        //{
        //    clsDAL obj = new clsDAL();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    using (SqlConnection con = new SqlConnection(obj.Cn()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            try
        //            {
        //                con.Open();
        //                cmd.Connection = con;
        //                cmd.CommandText = "SP_ClientOrder_Master";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Parameter", 1);

        //                cmd.Parameters.AddWithValue("@ClientOrderID",ClientOrderID);
        //                cmd.Parameters.AddWithValue("@ClientOrderName",ClientName);
        //                cmd.Parameters.AddWithValue("@ClientOrderNo",ClientOrderNo);
        //                cmd.Parameters.AddWithValue("@OrderDate",OrderDate);
        //                cmd.Parameters.AddWithValue("@OrderAmount",OrderAmount);
        //                cmd.Parameters.AddWithValue("@Descriptions",Descriptions);
        //                cmd.Parameters.AddWithValue("@AMCRequired",AMCRequired);
        //                //cmd.Parameters.AddWithValue("@AMCAmount",AMCAmount);
        //                //cmd.Parameters.AddWithValue("@AMCStartDate",AMCStartDate);
        //                //cmd.Parameters.AddWithValue("@AMCEndDate",AMCEndDate);

        //                cmd.ExecuteNonQuery();
        //                cmd.Parameters.Clear();
        //                con.Close();
        //                return 1;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message+ex.StackTrace);
        //                return -1;
        //            }
        //        }
        //    }
        //}

        //Fill Updates
        public DataSet Fetch_ClientOrder()
        {
            DataSet ds = new DataSet();
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
                        cmd.CommandText = "SP_ClientOrder_Master"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 5);
                        cmd.Parameters.AddWithValue("@ClientOrderID", ClientOrderID);
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        public int Update_Is_Deleted()
        {
            try
            {
                clsDAL obj = new clsDAL();
                SqlDataAdapter da = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(obj.Cn()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SP_ClientOrder_Master";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);
                        cmd.Parameters.AddWithValue("@ClientOrderID", ClientOrderID);
                       
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        con.Close();
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                
                return 0;
            }
        }
        public DataTable Search_ClientOrderMaster(int Parameter)
        {
            DataTable ClientOrder_Master = new DataTable();
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
                        cmd.CommandText = "SP_ClientOrder_Master"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", Parameter);

                        if (Parameter == 3)
                        {
                            if(CustomerId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                            cmd.Parameters.AddWithValue("@ClientOrderNo", ClientOrderNo);
                            cmd.Parameters.AddWithValue("@AMCRequired", AMCRequired);// if amc is -1 then all data retrieve 
                            cmd.Parameters.AddWithValue("@AMCStartDate", AMCStartDate);
                            cmd.Parameters.AddWithValue("@AMCEndDate", AMCEndDate);
                        }
                        else if (Parameter == 8)
                        {
                            cmd.Parameters.AddWithValue("@AMCRequired", AMCRequired);
                            cmd.Parameters.AddWithValue("@ClientOrderID", ClientOrderID);
                        }
                        //cmd.Parameters.AddWithValue("@AMCStartDate", AMCStartDate);
                        //cmd.Parameters.AddWithValue("@AMCEndDate",AMCEndDate);
                        da.SelectCommand = cmd;

                        da.Fill(ClientOrder_Master);

                        cmd.Parameters.Clear();

                        con.Close();

                    }
                }
                return ClientOrder_Master;
            }
            catch (Exception)
            {
                return ClientOrder_Master;
            }
        }
        // select all data
        public DataTable Fetch_OrderNo()
        {
            DataTable OrderNo = new DataTable();
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
                        cmd.CommandText = "SP_ClientOrder_Master"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 9);
                        if(CustomerId!=Guid.Empty)
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        da.SelectCommand = cmd;

                        da.Fill(OrderNo);

                        cmd.Parameters.Clear();

                        con.Close();

                    }
                }
                return OrderNo;
            }
            catch (Exception)
            {
                return OrderNo;
            }
        } /// not use
        public Int32 InsertClientOrder(string ps_Query)
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
                        con.Open();//Sql Connection 
                        cmd.Connection = con;
                        cmd.CommandText = "SP_ClientOrder_Master"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ps_Query == "Submit")
                        {
                            cmd.Parameters.AddWithValue("@Parameter", 1);
                        }
                        else if (ps_Query == "Update")
                        {
                            cmd.Parameters.AddWithValue("@Parameter", 6);
                        }

                        //Master table Parameters
                        cmd.Parameters.AddWithValue("@ClientOrderID", ClientOrderID);
                        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                        cmd.Parameters.AddWithValue("@ClientOrderNo", ClientOrderNo);
                        cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                        cmd.Parameters.AddWithValue("@OrderAmount", OrderAmount);
                        cmd.Parameters.AddWithValue("@Descriptions", Descriptions);
                        cmd.Parameters.AddWithValue("@AMCRequired", AMCRequired);
                        cmd.Parameters.AddWithValue("@IsDeleted", 0);
                        //----

                        String SP_ClientOrder_AMC = string.Empty;
                        using (StringWriter sw = new StringWriter())
                        {
                            if (!pDt_AMC.IsNullOrEmpty())
                            {
                                pDt_AMC.TableName = "SP_ClientOrder_AMC";
                                pDt_AMC.WriteXml(sw);
                                SP_ClientOrder_AMC = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                            }
                        }
                        cmd.Parameters.AddWithValue("@ClientOrder_AMCXML", SP_ClientOrder_AMC);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        con.Close();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + ex.StackTrace);
                        return -1;
                    }
                }
            }
        }

    }
}
