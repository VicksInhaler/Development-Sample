using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
public class IBPP_BottleAssy_Create
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public void createSubData(string bottleassyno, string bottlelotno, string sflotno, string amount)
    {
        // string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(sqlconn))
        {
            using (SqlCommand cmd = new SqlCommand("USP_IBPPBottleAssy_Sub_Create", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BOTTLEASSYLOTNO", bottleassyno);
                cmd.Parameters.AddWithValue("@BOTTLELOTNO", bottlelotno);
                cmd.Parameters.AddWithValue("@SFLOTNO", sflotno);
                cmd.Parameters.AddWithValue("@AMOUNT", amount);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public void createBottleAssy(string modelcode, string bottleassylotno,string bottlepartcode,string sfpartcode,
        string cavityno, string boxno, string stockline, string workshift, string createby,
        string datecreated)
    {
        // string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(sqlconn))
        {
            using (SqlCommand cmd = new SqlCommand("USP_IBPPBottle_Assy_Create", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MODELCODE", modelcode);
                cmd.Parameters.AddWithValue("@BOTTLEASSYLOTNO", bottleassylotno);
                cmd.Parameters.AddWithValue("@BOTTLEPARTCODE", bottlepartcode);
                cmd.Parameters.AddWithValue("@SFPARTCODE", sfpartcode);
                cmd.Parameters.AddWithValue("@CAVITYNO", cavityno);
                cmd.Parameters.AddWithValue("@BOXNO", boxno);
                cmd.Parameters.AddWithValue("@LINE", stockline);
                cmd.Parameters.AddWithValue("@WORKSHIFT", workshift);
                cmd.Parameters.AddWithValue("@CREATEDBY", createby);
                cmd.Parameters.AddWithValue("@DATECREATED", datecreated);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public string GenerateControl( string curingline,string workshift) 
    {
        string ControlNumber = "";
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("GENERATE_CONTROLNO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CURINGLINE", curingline);
            cmd.Parameters.AddWithValue("@WORKSHIFT",workshift );
            cmd.Parameters.Add("@OUTPUT", SqlDbType.NVarChar,50);
            cmd.Parameters["@OUTPUT"].Direction = ParameterDirection.Output;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            ControlNumber = ((string)cmd.Parameters["@OUTPUT"].Value).ToString();
            conn.Close();
            return ControlNumber;
        }
 
    }
}