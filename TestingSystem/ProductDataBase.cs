﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TestingSystems
{
    class ProductDataBase
    {
        #region
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        #endregion

        public int Insert_Product()
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
                        cmd.CommandText = "SP_ProductMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 1);
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
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

        public DataTable Search_Product()
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
                        cmd.CommandText = "SP_ProductMaster"; //Service Programmability Name
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 2);

                        if (ProductId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ProductId", ProductId);

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

        public int Update_Product()
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
                        cmd.CommandText = "SP_ProductMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 3);
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);

                        if (ProductId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ProductId", ProductId);

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
        public int Delete_Product()
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
                        cmd.CommandText = "SP_ProductMaster";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Parameter", 4);

                        if (ProductId != Guid.Empty)
                            cmd.Parameters.AddWithValue("@ProductId", ProductId);

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
    }
}