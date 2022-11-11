using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBPP_BottleAssy_Get
/// </summary>
public class IBPP_BottleAssy_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    public DataTable getBottleAssyData() 
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPBottle_Assy_Print", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public DataTable getBottleAssyDetails()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPBottle_Assy_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public DataTable getBottleAssyBarcode() //GET CURING DATA FROM TABLE CURING
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPBottle_Assy_Print", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
}