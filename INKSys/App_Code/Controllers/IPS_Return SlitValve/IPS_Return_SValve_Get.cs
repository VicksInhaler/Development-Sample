using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class IPS_Return_SValve_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public DataTable GetIPSReturnSValve()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPSReturnSValve_GetData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
}