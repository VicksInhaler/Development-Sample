using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Web.Services;
using System.Web.UI;

public partial class Views_Default : System.Web.UI.Page
{
    static Return_Cap_Get getReturnCap = new Return_Cap_Get();
    static Return_Cap_Update updateReturnCap = new Return_Cap_Update();
    static Maintenance_INK maint = new Maintenance_INK();
    string returnlotid,_boxno;

    DateTime dateTime = DateTime.Now;

    static string workshift, createdby, datecreated;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    [WebMethod]
    public static string GetIPSReturnCap()    //GET RETURN CAP DATA
    {
        return JsonConvert.SerializeObject(getReturnCap.GetIPSReturnCap());
    }
    [WebMethod]
    public static string UpdateIPSReturnCap(string returnlotno, string partlotno, string amount, string cavityno, string boxno) //UPDATE CAP RETURN DATA FROM TABLE CAP RETURN
    {
        return JsonConvert.SerializeObject(updateReturnCap.updateIPSReturnCap(returnlotno, partlotno, amount, cavityno, boxno));
    }
    protected void txtModelCode_TextChanged(object sender, EventArgs e)
    {
        ModelCodeCheck();
    }
    protected void txtPartName_TextChanged(object sender, EventArgs e)
    {
        if(txtPartName.Text !=null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtCavityNo.ClientID + "').focus();}, 500);", true);
        }
    }
    protected void txtCavityNo_TextChanged(object sender, EventArgs e)
    {
        if (txtCavityNo.Text != null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtAmount.ClientID + "').focus();}, 500);", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "emptyFieldsAlert();", true);
        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        if (txtAmount.Text != null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtAmount.ClientID + "').focus();}, 500);", true);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void txtPartCode_TextChanged(object sender, EventArgs e)
    {
        ModelPartCodeCheck();
    }
    #region TextChanged Properties
    public void ModelCodeCheck()
    {
        if (!string.IsNullOrEmpty(txtModelCode.Text))
        {
            if (maint.checkModel(txtModelCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPartName.ClientID + "').focus();}, 500);", true);
                txtModelCode.Enabled = false;
                txtModelCode.BackColor = Color.Gray;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
                txtModelCode.Text = null;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "emptyFields();", true);
        }
    }
    public void ModelPartCodeCheck()
    {
        if (txtModelCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtPartCode.Text = null;
        }
        else
        {
            if (maint.checkModelPartcode(txtModelCode.Text, txtPartCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPartName.ClientID + "').focus();}, 500);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPartCode.ClientID + "').focus();}, 500);", true);
                txtPartCode.Text = null;
            }
        }
    }
    public void ShrinkFilmLotCheck()
    {
        if (txtModelCode.Text == "" || txtPartName.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtPartName.Text = null;
        }
        else
        {
            if (maint.checkShrinkFilmLot(txtModelCode.Text, txtPartName.Text, txtPartName.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtCavityNo.ClientID + "').focus();}, 500);", true);
                GetPartName();


            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPartName.ClientID + "').focus();}, 500);", true);
                txtPartName.Text = null;
            }
        }
    }
    public void GetPartName()
    {
        DataTable data = new DataTable();
        data = maint.getPartName(txtPartCode.Text);
        txtPartName.Text = data.Rows[0]["PARTNAME"].ToString();
    }
    public void GenerateControlID()
    {
        string letter = "RC";
        string workshift = Session["WORKSHIFT"].ToString();
        string controlnumber = getReturnCap.GenerateControl(letter, workshift);
        returnlotid = controlnumber;
    }
    public void boxno()
    {
        int counter;

        if (Application["Count"] != null)
        {
            counter = Convert.ToInt32(Application["Count"]);
        }
        else
        {
            counter = 0;
        }
        counter = counter + 1;
        Application["Count"] = counter;
        _boxno = counter.ToString()/* .PadLeft(3, '0')*/;
    }
    #endregion



    protected void txtOldLotNo_TextChanged(object sender, EventArgs e)
    {

    }
}