using Newtonsoft.Json;
using System;
using System.Web.Services;

public partial class Views_Default : System.Web.UI.Page
{
    static IPS_Return_Spout_Get getReturnSpout = new IPS_Return_Spout_Get();
    static IPS_Return_Spout_Update updateReturnSpout = new IPS_Return_Spout_Update();

    DateTime dateTime = DateTime.Now;

    static string workshift, createdby, datecreated;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    [WebMethod]
    public static string GetIPSReturnSpout()    //GET RETURN SPOUT DATA
    {
        return JsonConvert.SerializeObject(getReturnSpout.GetIPSReturnSpout());
    }
    [WebMethod]
    public static string UpdateIPSReturnSpout(string returnlotno, string partlotno, string amount, string cavityno, string boxno) //UPDATE SPOUT RETURN DATA FROM TABLE SPOUT RETURN
    {
        return JsonConvert.SerializeObject(updateReturnSpout.updateIPSReturnSpout(returnlotno, partlotno, amount, cavityno, boxno));
    }
}