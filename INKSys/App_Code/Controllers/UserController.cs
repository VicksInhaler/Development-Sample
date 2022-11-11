using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccounts
/// </summary>
public class UserController
{
    private string InksysConnection;
    readonly SqlConnection dbConnection;
  
    public UserController()
    {
        this.InksysConnection = System.Configuration.ConfigurationManager.AppSettings["dbINKSYS"];
        dbConnection = new SqlConnection(InksysConnection);
       
    }
    public DataTable GetUserDataList()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            SqlCommand cmd = new SqlCommand("ASP_Admin_User_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
        }
        return dt;

    }
    public void CreateInksysUser(int employeeno,string password, string firstname, string middlename,
        string lastname, string nickname, string position, string section, string role,
        string workshift, string updateddate, string updatedby )
    {
       using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("ASP_Admin_User_Post", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMPLOYEENO", employeeno);
            cmd.Parameters.AddWithValue("@PASSWORD", password);
            cmd.Parameters.AddWithValue("@FIRSTNAME", firstname);
            cmd.Parameters.AddWithValue("@MIDDLENAME", middlename);
            cmd.Parameters.AddWithValue("@LASTNAME", lastname);
            cmd.Parameters.AddWithValue("@NICKNAME", nickname);
            cmd.Parameters.AddWithValue("@POSITION", position);
            cmd.Parameters.AddWithValue("@SECTION", section);
            cmd.Parameters.AddWithValue("@ROLE", role);
            cmd.Parameters.AddWithValue("@WORKSHIFT", workshift);
            cmd.Parameters.AddWithValue("@UPDATEDDATE", updateddate);
            cmd.Parameters.AddWithValue("@UPDATEDBY", updatedby);
            cmd.ExecuteNonQuery();
            conn.Close();
        
        }

    }
    public void UpdateInksysUser(string id,int employeeno, string password, string firstname, string middlename,
       string lastname, string nickname, string position, string section, string role,
       string workshift, string updateddate, string updatedby)
    {
        using (SqlConnection conn = new SqlConnection(InksysConnection))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("ASP_Admin_User_Patch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@EMPLOYEENO", employeeno);
            cmd.Parameters.AddWithValue("@PASSWORD", password);
            cmd.Parameters.AddWithValue("@FIRSTNAME", firstname);
            cmd.Parameters.AddWithValue("@MIDDLENAME", middlename);
            cmd.Parameters.AddWithValue("@LASTNAME", lastname);
            cmd.Parameters.AddWithValue("@NICKNAME", nickname);
            cmd.Parameters.AddWithValue("@POSITION", position);
            cmd.Parameters.AddWithValue("@SECTION", section);
            cmd.Parameters.AddWithValue("@ROLE", role);
            cmd.Parameters.AddWithValue("@WORKSHIFT", workshift);
            cmd.Parameters.AddWithValue("@UPDATEDDATE", updateddate);
            cmd.Parameters.AddWithValue("@UPDATEDBY", updatedby);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}