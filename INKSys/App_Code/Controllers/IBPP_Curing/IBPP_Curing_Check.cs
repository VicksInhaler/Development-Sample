using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for IBPP_Validate
/// </summary>
public class IBPP_Curing_Check
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    //TO CHECK IF MODEl PARTCODE EXIST 
    public bool checkModel(string modelcode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPCuring_Model_GetnCheck", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
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
    public bool checkShrinkFilm(string modelcode ,string shrinkfilmcode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPCuring_ShrinkFilm_Check", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@SFCODE", shrinkfilmcode);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
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
    //TO CHECK IF BOTTLE INFORMATION QR EXIST
    public bool checkBottleQR(string modelcode, string bottlecode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPCuring_Bottle_Check", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@BOTTLECODE", bottlecode);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
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
    //TO CHECK IF BOTTLE PARTCODE EXIST
    public bool checkBottlePartCode(string modelcode, string bottlecode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPCuring_Bottle_Check", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@BOTTLECODE", bottlecode);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
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
    //TO CHECK IF BOTTLE LOT NO EXIST
    public bool checkBottleLot(string modelcode, string bottlecode, string bottlelot)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPCuring_BottleLot_GetnCheck", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@BOTTLECODE", bottlecode);
            sqlcmd.Parameters.AddWithValue("@BOTTLELOT", bottlelot);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
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
}