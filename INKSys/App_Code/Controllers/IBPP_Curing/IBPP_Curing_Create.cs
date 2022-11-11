using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IBPP_PostCuring
/// </summary>
public class IBPP_Curing_Create
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    //ADDING DATA TO PCMA TABLE
    public void createIBPPCuring(string partcode, string model, string destination, string color,
                                 string sflotno, string sfpartcode, string sfpartname, string sfamount, 
                                 string bottlelotno, string bottlepartcode,string bottleamount,string cavityno,
                                 string curingline, string workshift, string createdby, string datecreated)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPCuring_Post", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PARTCODE", partcode);
            cmd.Parameters.AddWithValue("@MODEL", model);
            cmd.Parameters.AddWithValue("@DESTINATION", destination);
            cmd.Parameters.AddWithValue("@COLOR", color);
            cmd.Parameters.AddWithValue("@SFLOTNO", sflotno);
            cmd.Parameters.AddWithValue("@SFPARTCODE", sfpartcode);
            cmd.Parameters.AddWithValue("@SFPARTNAME", sfpartname);
            cmd.Parameters.AddWithValue("@SFAMOUNT", sfamount);
            cmd.Parameters.AddWithValue("@BOTTLELOTNO", bottlelotno);
            cmd.Parameters.AddWithValue("@BOTTLEPARTCODE", bottlepartcode);
            cmd.Parameters.AddWithValue("@BOTTLEAMOUNT", bottleamount);
            cmd.Parameters.AddWithValue("@CAVITYNO", cavityno);
            cmd.Parameters.AddWithValue("@CURINGLINE", curingline);
            cmd.Parameters.AddWithValue("@WORKSHIFT", workshift);
            cmd.Parameters.AddWithValue("@CREATEDBY", createdby);
            cmd.Parameters.AddWithValue("@DATECREATED",datecreated);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}