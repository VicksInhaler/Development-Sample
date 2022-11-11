using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class Views_IPS_Dashboard : System.Web.UI.Page
{
    static PartsScanController parts = new PartsScanController();
    protected void Page_Load(object sender, EventArgs e)
    {     
       if (!IsPostBack)
       {
           GetTotalPart();
           GetLineList();
           ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtBottleAssy.ClientID + "').focus();}, 500);", true);
       }       
    }
    [WebMethod]
    public static string GetIPSPart()
    {
        return JsonConvert.SerializeObject(parts.GetIPSPartData());
    }
    public void GetTotalPart()
    {      
        DataTable data = new DataTable();
        data = parts.GetTotalOfParts();
        lblBottleAssy.Text = data.Rows[0]["BALN"].ToString();
        lblCapAmount.Text = data.Rows[0]["CAPAMOUNT"].ToString();
        lblSpoutAmount.Text = data.Rows[0]["SPOUTAMOUNT"].ToString();
        lblSlitValveAmount.Text = data.Rows[0]["SLITAMOUNT"].ToString();  
    }
    public void GetLineList()
    {
        ddlLineMachine.Items.Insert(0, new ListItem("Choose Line Machine", "0"));
    }
    protected void txtBottleAmount_TextChanged(object sender, EventArgs e)
    {
        string value = txtBottleAssy.Text;
        if (parts.CheckBottleAssyExist(value))
        {
           string amount = parts.GetBottleAssyAmount(value);
           txtBaAmount.Text = amount;
       
           ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);
           ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtCap.ClientID + "').focus();}, 500);", true);
        }
        else
        {
           ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
           ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtBottleAssy.ClientID + "').focus();}, 500);", true);
           txtBaAmount.Text = null;
           txtBottleAssy.Text = "";
        }
    }
    protected void txtCap_TextChanged(object sender, EventArgs e)
    {
        string value = txtCap.Text;  
        if (parts.CheckCapExist(value))
        {
          string amount = parts.GetCapAmount(value);
          txtCapAmount.Text = amount;      
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSpout.ClientID + "').focus();}, 500);", true);
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);       
        }
        else
        {        
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtCap.ClientID + "').focus();}, 500);", true);
          txtCapAmount.Text = null;
         txtCap.Text = "";
        }
    }
    protected void txtSpout_TextChanged(object sender, EventArgs e)
    {
        string value = txtSpout.Text;
        if (parts.CheckSpoutExist(value))
        {
          string amount = parts.GetSpoutAmount(value);
          txtSpoutAmount.Text = amount;
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSlitvalve.ClientID + "').focus();}, 500);", true);
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);
        }
        else
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSpout.ClientID + "').focus();}, 500);", true);
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
          txtSpoutAmount.Text = null;
            txtSpout.Text = null;
        }
    }
    protected void txtSlitvalve_TextChanged(object sender, EventArgs e)
    {
        string value = txtSlitvalve.Text;
        if (parts.CheckSlitValveExist(value))
        {
          string amount = parts.GetSlitValveAmount(value);
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPackBottle.ClientID + "').focus();}, 500);", true);
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);
            txtSlitAmount.Text = amount;
        }
        else
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSlitvalve.ClientID + "').focus();}, 500);", true);
          ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
          txtSlitAmount.Text = null;
            txtSlitvalve.Text = null;
        }
    }
    protected void txtPackBottle_TextChanged(object sender, EventArgs e)
    {
        string value = txtPackBottle.Text;
        if (parts.CheckPackBottleExist(value))
        {
            txtPackBottle.Text = value; 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtInk.ClientID + "').focus();}, 500);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtPackBottle.ClientID + "').focus();}, 500);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
            txtPackBottle.Text = null;
        }
    }
    protected void txtInk_TextChanged(object sender, EventArgs e)
    {
        string value = txtInk.Text;
        if (parts.CheckInkExist(value))
        {
            txtInk.Text = value;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + ddlLineMachine.ClientID + "').focus();}, 500);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('DataFound');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtInk.ClientID + "').focus();}, 500);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('No DataFound');", true);
            txtInk.Text = null;
        }

    }
    protected void ddlLineMachine_TextChanged(object sender, EventArgs e)
    {
        if(ddlLineMachine.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + ddlLineMachine.ClientID + "').focus();}, 500);", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Must Select Line Machine');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + btnSave.ClientID + "').focus();}, 500);", true);
       
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtBaAmount.Text == "" || txtSpoutAmount.Text == "" || txtCapAmount.Text=="" || txtSlitAmount.Text =="" || txtInk.Text=="" || txtPackBottle.Text ==""|| ddlLineMachine.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Must CompleteField');", true);
            return;    
        }
        else
        {
            string bottleassy = txtBottleAssy.Text;
            string bottleassyamount = txtBaAmount.Text;
            string cap = txtCap.Text;
            string capamount = txtCapAmount.Text;
            string spout = txtSpout.Text;
            string spoutamount = txtSpoutAmount.Text;
            string slitvalve = txtSlitvalve.Text;
            string slitamount = txtSlitAmount.Text;
            string packbottle = txtPackBottle.Text;
            string ink = txtInk.Text;
            string linemachine = ddlLineMachine.SelectedValue;
            string updatedby = Session["EMPLOYEENO"].ToString();
            var logdatetoday = DateTime.Now;
            string logdatetime = logdatetoday.ToString("MM/dd/yyyy hh:mm:ss tt");
            parts.CreateIPSPartScan(bottleassy, bottleassyamount, cap, capamount, spout, spoutamount,
                                  slitvalve, slitamount, ink, packbottle, linemachine, updatedby, logdatetime);
            GetTotalPart();
            ClearFields();
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Save Success');", true);
        }     
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtID.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Must CompleteField');", true);
            return;
        }
        else
        {
            string id = txtID.Text;
            string bottleassy = txtBottleAssy.Text;
            string bottleassyamount = txtBaAmount.Text;
            string cap = txtCap.Text;
            string capamount = txtCapAmount.Text;
            string spout = txtSpout.Text;
            string spoutamount = txtSpoutAmount.Text;
            string slitvalve = txtSlitvalve.Text;
            string slitamount = txtSlitAmount.Text;
            string packbottle = txtPackBottle.Text;
            string ink = txtInk.Text;
            string linemachine = ddlLineMachine.SelectedValue;
            string updatedby = Session["EMPLOYEENO"].ToString();
            var logdatetoday = DateTime.Now;
            string logdatetime = logdatetoday.ToString("MM/dd/yyyy hh:mm:ss tt");
            parts.UpdatePartScan(id,bottleassy, bottleassyamount, cap, capamount, spout, spoutamount,
                                  slitvalve, slitamount, ink, packbottle, linemachine, updatedby, logdatetime);
            GetTotalPart();
            ClearFields();
          
        }

    }
    public void ClearFields()
    {
        txtBottleAssy.Text = null;
        txtBaAmount.Text = null;
        txtCap.Text = null;
        txtCapAmount.Text = null;
        txtSlitvalve.Text = null;
        txtSlitAmount.Text = null;
        txtSpout.Text = null;
        txtSpoutAmount.Text = null;
        txtInk.Text = null;
        txtPackBottle.Text = null;
        txtSlitAmount.Text = null;
        ddlLineMachine.SelectedIndex = 0;
    }
}