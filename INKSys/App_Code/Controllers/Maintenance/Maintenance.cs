using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Maintenance
/// </summary>
public class Maintenance
{
    private readonly string EPPIIIP;
    readonly SqlConnection conn_EPPIIIP;

    private readonly string dbINKSYS;
    readonly SqlConnection conn;
    private string strConnUAMS;
    SqlConnection connUAMS;


    public Maintenance()
    {
        //
        // TODO: Add constructor logic here
        //

        this.EPPIIIP = System.Configuration.ConfigurationManager.AppSettings["EPPIIIP"];
        conn_EPPIIIP = new SqlConnection(EPPIIIP);

        this.dbINKSYS = System.Configuration.ConfigurationManager.AppSettings["dbINKSYS"];
        conn = new SqlConnection(dbINKSYS);

        this.strConnUAMS = System.Configuration.ConfigurationManager.AppSettings["connectionUAMS"];
        connUAMS = new SqlConnection(strConnUAMS);
    }

    public DataTable GetUser(LoginDetails ld)
    {
        using (var cmd = new SqlCommand("LOGIN_GetUser", conn_EPPIIIP) { CommandType = CommandType.StoredProcedure })
        {
            cmd.Parameters.AddWithValue("@system_name", ld.system);
            cmd.Parameters.AddWithValue("@user_id", ld.username);
            cmd.Parameters.AddWithValue("@password", ld.password);
            cmd.Parameters.AddWithValue("@LDAP", ld.ldap);

            cmd.CommandTimeout = 300;





            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                if (conn_EPPIIIP.State == ConnectionState.Open)
                {
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    conn_EPPIIIP.Open();
                    da.Fill(dt);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                conn_EPPIIIP.Close();
            }
            return dt;
        }
    }
    public DataSet GetUserSubsystemRole(string strUserID, string strSystemID, string strSubSystemID)
    {

        SqlCommand sqlComm = new SqlCommand("LOGIN_GetUsersSubsystemsRole", connUAMS);
        sqlComm.Parameters.AddWithValue("@userid", strUserID);
        sqlComm.Parameters.AddWithValue("@system_name", strSystemID);
        sqlComm.Parameters.AddWithValue("@subsystem_id", strSubSystemID);

        sqlComm.CommandType = CommandType.StoredProcedure;
        sqlComm.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlComm;

        DataSet ds = new DataSet();
        da.Fill(ds);

        return ds;


    }

}