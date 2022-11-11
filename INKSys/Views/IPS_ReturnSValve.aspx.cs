using Newtonsoft.Json;
using System;
using System.Web.Services;

public partial class Views_Default2 : System.Web.UI.Page
{
    static IPS_Return_SValve_Get getReturnSValve = new IPS_Return_SValve_Get();
    static IPS_Return_SValve_Update updateReturnSValve = new IPS_Return_SValve_Update();

    DateTime dateTime = DateTime.Now;

    static string workshift, createdby, datecreated;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    [WebMethod]
    public static string GetIPSReturnSValve()    //GET RETURN CAP DATA
    {
        return JsonConvert.SerializeObject(getReturnSValve.GetIPSReturnSValve());
    }
    [WebMethod]
    public static string UpdateIPSReturnSValve(string returnlotno, string partlotno, string amount, string cavityno, string boxno) //UPDATE CAP RETURN DATA FROM TABLE CAP RETURN
    {
        return JsonConvert.SerializeObject(updateReturnSValve.updateIPSReturnSValve(returnlotno, partlotno, amount, cavityno, boxno));
    }
}