using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PartsScanController
/// </summary>
public class PartsScanController
{
    private string InksysConnection;
    readonly SqlConnection dbConnection;
    public PartsScanController()
    {
        this.InksysConnection = System.Configuration.ConfigurationManager.AppSettings["dbINKSYS"];
        dbConnection = new SqlConnection(InksysConnection);
    }
    public DataTable GetIPSPartData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetIpsParts");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
        }
        return dt;
    }
    public DataTable GetTotalOfParts()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetTotalPart");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
        }
        return dt;
    }
    public void CreateIPSPartScan(string baln,string balnamount,string cap,string capamount,string spout,
                                  string spoutamount, string slitvalve,string slitamount,string ink,
                                  string packbottle,string line,string updatedby, string updateddate)
    {
        {
            using (SqlConnection conn = new SqlConnection(InksysConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Post", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BOTTLEASSYLOTNO",baln);
                cmd.Parameters.AddWithValue("@BALNAMOUNT",balnamount);
                cmd.Parameters.AddWithValue("@CAPLOTNO",cap);
                cmd.Parameters.AddWithValue("@CAPAMOUNT",capamount);
                cmd.Parameters.AddWithValue("@SPOUTLOTNO",spout); 
                cmd.Parameters.AddWithValue("@SPOUTAMOUNT",spoutamount);
                cmd.Parameters.AddWithValue("@SLITVALVELNO",slitvalve);
                cmd.Parameters.AddWithValue("@SLITAMOUNT",slitamount);
                cmd.Parameters.AddWithValue("@INKLOTNO",ink);
                cmd.Parameters.AddWithValue("@PACKBOTLELOTNO",packbottle);
                cmd.Parameters.AddWithValue("@LINEMACHINE",line);
                cmd.Parameters.AddWithValue("@UPDATEDBY",updatedby);
                cmd.Parameters.AddWithValue("@UPDATEDDATE" ,updateddate);  
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    public void UpdatePartScan(string id,string baln, string balnamount, string cap, string capamount, string spout,
                                  string spoutamount, string slitvalve, string slitamount, string ink,
                                  string packbottle, string line, string updatedby, string updateddate)
    {
        {
            using (SqlConnection conn = new SqlConnection(InksysConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Patch", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@BOTTLEASSYLOTNO", baln);
                cmd.Parameters.AddWithValue("@BALNAMOUNT", balnamount);
                cmd.Parameters.AddWithValue("@CAPLOTNO", cap);
                cmd.Parameters.AddWithValue("@CAPAMOUNT", capamount);
                cmd.Parameters.AddWithValue("@SPOUTLOTNO", spout);
                cmd.Parameters.AddWithValue("@SPOUTAMOUNT", spoutamount);
                cmd.Parameters.AddWithValue("@SLITVALVELNO", slitvalve);
                cmd.Parameters.AddWithValue("@SLITAMOUNT", slitamount);
                cmd.Parameters.AddWithValue("@INKLOTNO", ink);
                cmd.Parameters.AddWithValue("@PACKBOTLELOTNO", packbottle);
                cmd.Parameters.AddWithValue("@LINEMACHINE", line);
                cmd.Parameters.AddWithValue("@UPDATEDBY", updatedby);
                cmd.Parameters.AddWithValue("@UPDATEDDATE", updateddate);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    #region CheckExist
    public bool CheckBottleAssyExist(string bottleassy)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection)) {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckBottleAssy");
            cmd.Parameters.AddWithValue("@BALN", bottleassy);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool CheckCapExist(string cap)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckCap");
            cmd.Parameters.AddWithValue("@CAP", cap);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
           
    }
    public bool CheckSpoutExist(string spout)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckSpout");
            cmd.Parameters.AddWithValue("@SPOUT", spout);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
    }
    public bool CheckSlitValveExist(string sv)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckSV");
            cmd.Parameters.AddWithValue("@SLITVALVE", sv);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       
    }
    public bool CheckPackBottleExist(string packbottle)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckPackBottle");
            cmd.Parameters.AddWithValue("@PACKBOTTLE", packbottle);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
    public bool CheckInkExist(string ink)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_CheckExist", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "CheckInk");
            cmd.Parameters.AddWithValue("@INKPART", ink);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Close();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
          
    }
    #endregion

    #region Display Value of Parts
    public string GetBottleAssyAmount(string value)
    {
        string balnamount = "";
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetBottleAssyAmount");
            cmd.Parameters.AddWithValue("@BALN", value);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                balnamount = reader["BOTTLEAMOUNT"].ToString();
            }
        }
        return balnamount;
    }
    public string GetCapAmount(string value)
    {
        string amount = "";
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetCap");
            cmd.Parameters.AddWithValue("@CAP", value);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                amount = reader["AMOUNT"].ToString();
            }
        }
        return amount;
    }
 
    public string GetSpoutAmount(string value)
    {
        string amount = "";
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetSpout");
            cmd.Parameters.AddWithValue("@SPOUT", value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                amount = reader["AMOUNT"].ToString();
            }
        }
        return amount;
    }
    public string GetSlitValveAmount(string value)
    {
        string amount = "";
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IPS_Parts_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SP", "GetSV");
            cmd.Parameters.AddWithValue("@SLITVALVE", value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                amount = reader["AMOUNT"].ToString();
            }
        }
        return amount;
    }
    #endregion
}