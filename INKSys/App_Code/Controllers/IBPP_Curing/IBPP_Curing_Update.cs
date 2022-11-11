using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IBPP_Curing_Update
/// </summary>
public class IBPP_Curing_Update
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    public string updateIBPPCuring(string id, string sflotno, string sfpartname, string sfamount, 
        string bottlelotno, string bottleamount, string cavityno, string curingline)
    {
        string Message = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("USP_IBPPCuring_Patch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@SFLOTNO", sflotno);
                cmd.Parameters.AddWithValue("@SFPARTNAME", sfpartname);
                cmd.Parameters.AddWithValue("@SFAMOUNT", sfamount);
                cmd.Parameters.AddWithValue("@BOTTLELOTNO", bottlelotno);
                cmd.Parameters.AddWithValue("@BOTTLEAMOUNT", bottleamount);
                cmd.Parameters.AddWithValue("@CAVITYNO", cavityno);
                cmd.Parameters.AddWithValue("@CURINGLINE", curingline);
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