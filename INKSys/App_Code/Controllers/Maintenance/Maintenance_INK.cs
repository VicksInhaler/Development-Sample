using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Maintenance_INK
/// </summary>
public class Maintenance_INK
{
    string sqlconn = ConfigurationManager.AppSettings["dbINKSYS"];
    public DataTable getIBPPCuringLine() 
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPP_CuringLine_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public DataTable getIBPPLineArea() 
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPP_LineArea_Get", conn);
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
    public DataTable getIBPPBottleLot(string bottlecode, string bottlelotno) //DISPLAY BOTTLELOTNO, BOTTLEAMOUNT DATA IN TEXTFIELDS
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
    public DataTable getSFPartName(string sfpartcode) 
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_IBPPBottle_Assy_SFLot_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PARTCODE", sfpartcode);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public DataTable getPartName(string partcode)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("USP_PartCode_Get_Check", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PARTCODE", partcode);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
        }
        return dt;
    }
    public bool checkModel(string modelcode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPP_Model_Check", conn);
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
    public bool checkModelPartcode(string modelcode,string partcode)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_Model_Partcode_Check", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@PARTCODE", partcode);
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
    public bool checkShrinkFilm(string modelcode, string shrinkfilmcode)
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
    public bool checkShrinkFilmLot(string modelcode, string sfcode, string sflot)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPBottle_Assy_SFLot_Check", conn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MODELCODE", modelcode);
            sqlcmd.Parameters.AddWithValue("@SFCODE", sfcode);
            sqlcmd.Parameters.AddWithValue("@SFLOT",sflot);
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
    public bool checkBottleQR(string modelcode, string bottlecode, string bottlelot)
    {
        using (SqlConnection conn = new SqlConnection(sqlconn))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPBottle_Assy_Check", conn);
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
            SqlCommand sqlcmd = new SqlCommand("USP_IBPPBottle_Assy_Check", conn);
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