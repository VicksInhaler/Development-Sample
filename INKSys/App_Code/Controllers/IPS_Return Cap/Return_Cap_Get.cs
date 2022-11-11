using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Return_Cap_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public DataTable GetIPSReturnCap()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_ReturnCap_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public string GenerateControl(string letter, string workshift)
    {
        string ControlNumber = "";
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("GENERATE_RETURNLOTNO_CAP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LETTER", letter);
            cmd.Parameters.AddWithValue("@WORKSHIFT", workshift);
            cmd.Parameters.Add("@OUTPUT", SqlDbType.NVarChar, 50);
            cmd.Parameters["@OUTPUT"].Direction = ParameterDirection.Output;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            ControlNumber = ((string)cmd.Parameters["@OUTPUT"].Value).ToString();
            conn.Close();
            return ControlNumber;
        }

    }
}