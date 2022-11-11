using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StockController
/// </summary>
public class StockController
{
    private string InksysConnection;
    readonly SqlConnection dbConnection;
    public StockController()
    {
        this.InksysConnection = System.Configuration.ConfigurationManager.AppSettings["dbINKSYS"];
        dbConnection = new SqlConnection(InksysConnection);
    }
    public DataTable GetCapTotal()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {          
          SqlCommand cmd = new SqlCommand("RSP_Stock_Cap_Available", conn);
          cmd.CommandType = CommandType.StoredProcedure;
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          conn.Open();
          da.Fill(dt);
          conn.Close();
          return dt;
        }
    }
    public DataTable GetSpoutTotal()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("RSP_Stock_Spout_Available", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
    public DataTable GetSlitValveTotal()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("RSP_Stock_SlitValve_Available", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
    public DataTable GetBottleAssyTotal()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("RSP_Stock_BottleAssy_Available", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}