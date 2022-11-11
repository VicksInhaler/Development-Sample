using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_v4 : System.Web.UI.Page
{
    readonly string SqlConn = ConfigurationManager.AppSettings["dbINKSYS"];
    private string employeenumber, firstname, password, middlename, lastname, nickname, position, section, role, workshift;
    int RowCount;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strUserID = txtUserName.Text.ToString().Trim();
        string strPassword = txtPassword.Text.ToString();
        string strUserName = "";

        if (!System.Text.RegularExpressions.Regex.IsMatch(strUserID, "^[a-zA-Z ]"))
        {
            CheckUser(strUserID,strPassword);
        }
        else
        {
            CheckLdapUser(strUserID, strPassword, strUserName);      
        }
    }
    public void CheckUser(string userid, string userpass)
    {
        using (SqlConnection conn = new SqlConnection(SqlConn))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("LSP_Login_Get", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                employeenumber = dt.Rows[i]["EMPLOYEENO"].ToString();
                password = dt.Rows[i]["PASSWORD"].ToString();
                firstname = dt.Rows[i]["FIRSTNAME"].ToString();
                middlename = dt.Rows[i]["MIDDLENAME"].ToString();
                lastname = dt.Rows[i]["LASTNAME"].ToString();
                nickname = dt.Rows[i]["NICKNAME"].ToString();
                position = dt.Rows[i]["POSITION"].ToString();
                section = dt.Rows[i]["SECTION"].ToString();

                role = dt.Rows[i]["ROLE"].ToString();
                workshift = dt.Rows[i]["WORKSHIFT"].ToString();
                if (employeenumber == userid && password == userpass)
                {
                    Session["EMPLOYEENO"] = employeenumber;
                    Session["FIRSTNAME"] = firstname;
                    Session["MIDDLENAME"] = middlename;
                    Session["LASTNAME"] = lastname;
                    Session["NICKNAME"] = nickname;
                    Session["POSITION"] = position;
                    Session["SECTION"] = section;
                    Session["ROLE"] = role;
                    Session["WORKSHIFT"] = workshift;
                    if (dt.Rows[i]["ROLE"].ToString() == "0" && dt.Rows[i]["POSITION"].ToString() == "STAFF")
                    {
                        Response.Redirect("~/Views/Admin_Dashboard.aspx");
                    }
                    else if (dt.Rows[i]["ROLE"].ToString() == "1" && dt.Rows[i]["SECTION"].ToString() == "IBPP")
                    {
                        Response.Redirect("~/Views/Return_Cap.aspx");
                    }
                    else if (dt.Rows[i]["ROLE"].ToString() == "1" && dt.Rows[i]["SECTION"].ToString() == "IPS")
                    {
                        Response.Redirect("~/Views/IPS_Dashboard.aspx");
                    }
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('INVALID USERNAME OR PASSWORD');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "WarningAlert();", true);
                }
            }
            conn.Dispose();
        }
    }
    public void CheckLdapUser(string ldapid, string ldappass, string ldapuname)
    {
        //check if valid in LDAP
        bool isAuthenticated = ServiceLocator.GetLdapService().IsAuthenticated(ldapid, ldappass);
        //bool isAuthenticated = false;
        if (isAuthenticated)
        {
            //check if valid in have ADMIN MAIN role
            Constants cons = new Constants();

            bool isAuthorized = ServiceLocator.GetLoginService().IsAuthorized(cons.INKSYSTEM_ID, cons.ADMIN_USERACCOUNTS, ldapid);

            if (isAuthorized)
            {
                DataSet ds = ServiceLocator.GetLoginService().GetUser(ldapid);

                ldapuname = ds.Tables[0].Rows[0]["UserName"].ToString();

                Session["UserID"] = ldapid;
                Session["UserName"] = ldapuname;
                if (Session["Link"] != null)
                {
                    Response.Redirect(Session["Link"].ToString());
                }
                else
                {
                    Response.Redirect("~/Views_Admin/UserAccounts.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('LDAP');", true);
            }
        }
        else
        {
            //CHECK UAMS
            isAuthenticated = ServiceLocator.GetLoginService().IsValid(ldapid, ldappass);
            if (isAuthenticated)
            {
                //check if valid in have ADMIN MAIN role
                Constants cons = new Constants();

                bool isAuthorized = ServiceLocator.GetLoginService().IsAuthorized(cons.INKSYSTEM_ID, cons.ADMIN_USERACCOUNTS, ldapid);

                if (isAuthorized)
                {
                    DataSet ds = ServiceLocator.GetLoginService().GetUser(ldapid);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ldapuname = ds.Tables[0].Rows[0]["UserName"].ToString();
                            Session["UserID"] = ldapid;
                            Session["UserName"] = ldapuname;
                            if (Session["Link"] != null)
                            {
                                Response.Redirect(Session["Link"].ToString());
                            }
                            else
                            {
                                Response.Redirect("~/Views_Admin/UserAccounts.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('1');", true);
                            // showAlert("error", "Error", "User ID not registered to access the system. No User Name Found.");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('2');", true);
                        // showAlert("error", "Error", "User ID not registered to access the system. No User Name Found.");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('3');", true);
                    //showAlert("error", "Error", "User ID not registered to access the system.");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "WarningAlert();", true);
                //  showAlert("error", "Error", "User ID or Password is incorrect. Please check again.");
            }
        }
    }
}