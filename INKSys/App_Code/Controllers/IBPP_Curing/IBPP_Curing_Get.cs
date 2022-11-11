using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public class IBPP_Curing_Get
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];

    public DataTable getIBPPCuring() //GET CURING DATA FROM TABLE PCMA
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPCuring_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }

    public DataTable getModelData(string modelcode) //DISPLAY MODEL, DESTINATION, COLOR DATA IN TEXTFIELDS
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPCuring_Model_GetnCheck", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }

    public DataTable getIBPPBottleLot( string bottlecode, string bottlelotno) //DISPLAY BOTTLELOTNO, BOTTLEAMOUNT DATA IN TEXTFIELDS
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPCuring_BottleLot_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOTTLECODE", bottlecode);
            cmd.Parameters.AddWithValue("@BOTTLELOT", bottlelotno);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
}