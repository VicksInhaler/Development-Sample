using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class IPS_Return_Spout_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public DataTable GetIPSReturnSpout()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPSReturnSpout_GetData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
}