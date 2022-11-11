using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IPS_Return_Cap_Create
/// </summary>
public class IPS_Return_Cap_Create
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public string createreturnCap(string modelcode, string returnlotno, string partcode, string partname, string amount, string cavityno, string boxno)
    {
        string Message = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("USP_IPS_ReturnCap_Patch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PRODUCTCODE", modelcode);
                cmd.Parameters.AddWithValue("@RETURNLOTNO", returnlotno);
                cmd.Parameters.AddWithValue("@PARTCODE", partcode);
                cmd.Parameters.AddWithValue("@PARTNAME", partname);
                cmd.Parameters.AddWithValue("@AMOUNT", amount);
                cmd.Parameters.AddWithValue("@CAVITYNO", cavityno);
                cmd.Parameters.AddWithValue("@BOXNO", boxno);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (SqlException sqlex)
        {
            Message = sqlex.Message.ToString();
        }
        catch (Exception ex)
        {
            Message = ex.Message.ToString();
        }
        return Message;
    }
}