using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Authorize
/// </summary>
public class Authorize
{
    private string inksysconn;
    SqlConnection dbcon;
    public Authorize()
    {
        this.inksysconn = System.Configuration.ConfigurationManager.AppSettings["dbINKSYS"];
        dbcon = new SqlConnection(inksysconn);
    }
    public DataTable ValidateIBPPUser(string empno)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(inksysconn))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Validate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "VALIDATEIBBPUSER");
            cmd.Parameters.AddWithValue("@EMPLOYEENO", empno);
            using (var da = new SqlDataAdapter(cmd))
            da.Fill(dt);

        }
        return dt;
    }
    public DataTable ValidateIPSUser(string empno)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(inksysconn))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Validate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "VALIDATEIPSUSER");
            cmd.Parameters.AddWithValue("@EMPLOYEENO", empno);
            using (var da = new SqlDataAdapter(cmd))
                da.Fill(dt);

        }
        return dt;
    }
    public DataTable ValidateAdminUser(string empno)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(inksysconn))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Validate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "VALIDATEADMINUSER");
            cmd.Parameters.AddWithValue("@EMPLOYEENO", empno);
            using (var da = new SqlDataAdapter(cmd))
                da.Fill(dt);

        }
        return dt;
    }
}