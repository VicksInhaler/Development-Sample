using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IBPP_Line_Get
/// </summary>
public class IBPP_Line_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public class CuringLine
    {
        public int ID { get; set; }
        public string Line { get; set; }
    }
    public DataTable getIBPPCuringLine() //DISPLAY BOTTLELOTNO, BOTTLEAMOUNT DATA IN TEXTFIELDS
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_Get_Line", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "Get_CuringLine");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
}