using System;

public partial class Views_Inksys : System.Web.UI.MasterPage
{
    private readonly Authorize authorize = new Authorize();
    private string employeeno,role,section,workshift;
    public string serviceName, BacsMenu, BacsSubMenu, IBPPCuring, BottleAssy, Sampling, NoGood;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserSession();
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Cookies.Clear();
        Response.Cache.SetNoStore();
        Response.CacheControl = "no-cache";
        Response.Redirect("~/Login.aspx");
    }
    public void GetUserSession()
    {
        if (Session["EMPLOYEENO"] != null)
        {
          dropdownSubMenu1.InnerHtml = Session["LASTNAME"].ToString() + ",  " + Session["FIRSTNAME"].ToString();
          lblNickname.Text = Session["NICKNAME"].ToString();
          lblPosition.Text = Session["POSITION"].ToString();
          employeeno = Session["EMPLOYEENO"].ToString();
          role = Session["ROLE"].ToString();
          section = Session["SECTION"].ToString();
          workshift = Session["WORKSHIFT"].ToString();
          CheckRole();
        }
        else
        {
            Response.Redirect("../Login.aspx");
        }
    }

    public void CheckRole()
    {
        if (role=="1" && section == "IBPP")
        {
            HideAdminForm();
            HideIPSForm();
        }
        else if (role=="1" && section =="IPS")
        {
            HideAdminForm();
            HideIBPPForm();
        }
        else
        {

        }
    }
    public void CheckWorkShift()
    {
        if (workshift =="DS")
        {
            Nighshift.Visible = false;
        }
        else
        {
            Dayshift.Visible = false;
        }
    }
    #region HIDE FORMS
    public void HideAdminForm()
    {
        
    }
    public void HideIBPPForm()
    {
         
    }
    public void HideIPSForm()
    {
      
    }
    #endregion
    //public void MenuService()
    //{
    //    serviceName = System.Web.VirtualPathUtility.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
    //    //if (serviceName == "Admin_UserAccounts.aspx")
    //    //{
    //    //    UserMasterMenu = "menu-open";
    //    //    UserMaster = "active open";
    //    //    UserCreate = "active";
    //    //    UserList = "";
    //    //    UserRoles = "";
    //    //}
    //    //else if(serviceName == "IBPP_Curing.aspx")
    //    //{
    //    //    IBPPFormMenu = "menu-open";
    //    //    IBPPBacsForms = "active open";
    //    //    IBPPCuring = "active";
    //    //    IBPPNG = "";
    //    //    IBPPSampling = "";
    //    //}
    //    if (serviceName == "IBPP_Curing.aspx")
    //    {
    //        BacsMenu = "nav-item menu-open";
    //        BacsSubMenu = "active open";
    //        IBPPCuring = "active";
    //        BottleAssy = "";
    //        Sampling = "";
    //        NoGood = "";

    //    }
    //}



}


