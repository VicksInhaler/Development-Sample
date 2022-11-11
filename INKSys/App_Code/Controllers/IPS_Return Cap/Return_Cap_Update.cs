using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Return_Cap_Update
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    public string updateIPSReturnCap(string returnlotno, string partlotno, string amount, string cavityno, string boxno)
    {
        string Message = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("USP_IPS_ReturnCap_Patch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RETURNLOTNO", returnlotno);
                cmd.Parameters.AddWithValue("@PARTLOTNO", partlotno);
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