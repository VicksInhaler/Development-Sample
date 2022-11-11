using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admin : System.Web.UI.MasterPage
{
    public static string strUserID;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblNickname.Text = Session["Username"].ToString();
        string strUserName = "";
        if (!this.IsPostBack)
        {

            //check Session
            if (Session["UserID"] != null)
            {
                strUserID = Session["UserID"].ToString();
                strUserName = Session["UserName"].ToString();
                Constants cons = new Constants();
                bool isAuthorized = ServiceLocator.GetLoginService().IsAuthorized(cons.INKSYSTEM_ID, cons.ADMIN_USERACCOUNTS, strUserID);
                string strSubSystemRole = "";
                if (isAuthorized)
                {
                    Maintenance maint = new Maintenance();
                    //check user role
                    DataSet ds = maint.GetUserSubsystemRole(strUserID, cons.INKSYSTEM_ID, cons.ADMIN_USERACCOUNTS);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strSubSystemRole = ds.Tables[0].Rows[0]["ROLE"].ToString();
                            Session["ROLEID"] = strSubSystemRole;
                        }
                    }        
                }
                else
                {                 
                    Response.Redirect("Login.aspx");
                }

            }
            else
            { 
                Response.Redirect("Login.aspx");
            }

        }
    }
}
