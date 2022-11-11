using System;
using System.Web.Services;
using System.Drawing;
using Newtonsoft.Json;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Views_IBPP_IncomingForCuring : System.Web.UI.Page
{
    static IBPP_Curing_Create _createCuring = new IBPP_Curing_Create();
    static IBPP_Curing_Get _getCuring = new IBPP_Curing_Get();
    static IBPP_Curing_Update updateCuring = new IBPP_Curing_Update();
    static IBPP_Line_Get _getLine = new IBPP_Line_Get();
    static IBPP_Curing_Check check = new IBPP_Curing_Check();

    DateTime datetime = DateTime.Now;

    static string _workshift, _updatedby, _updateddatetime,_createdby,_datecreated;
    static bool skipTextChange;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            disabledInputs();
            changeColor();
            getIBPPCuringLine();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
        }
    }
    #region JQUERY DISPLAY AND UPDATE
    [WebMethod]
    public static string getIBPPCUring() //GET CURING DATA FROM TABLE PCMA
    {
        return JsonConvert.SerializeObject(_getCuring.getIBPPCuring());
    }
    [WebMethod]
    public static string UpdateIBPPCuring(string id, string sflotno, string sfpartname, string sfamount,
                                        string bottlelotno, string bottleamount, string cavityno, string curingline) //GET CURING DATA FROM TABLE PCMA
    {
        return JsonConvert.SerializeObject(updateCuring.updateIBPPCuring(id, sflotno, sfpartname, sfamount, bottlelotno, bottleamount, cavityno, curingline));
    }
    #endregion

    #region ASP READ AND DISPLAY 
    public void GetModelData()
    {
        DataTable data = new DataTable();
        data = _getCuring.getModelData(txtModelCode.Text);
        txtType.Text = data.Rows[0]["MODEL"].ToString();
        txtDestination.Text = data.Rows[0]["DESTINATION"].ToString();
        txtColor.Text = data.Rows[0]["COLOR"].ToString();
    }
    public void GetBottleLotData()
    {
        DataTable data = new DataTable();
        data = _getCuring.getIBPPBottleLot(txtBottlePartCode.Text, txtBottleLotNo.Text);
        txtBottleAmount.Text = data.Rows[0]["BOTTLEAMOUNT"].ToString();
        txtCavityNo.Text = data.Rows[0]["CAVITYNO"].ToString();
    }
    public void getIBPPCuringLine() 
    {
        DataTable dt = new DataTable();
        dt = _getLine.getIBPPCuringLine();
        ddlCuringMachine.DataSource = dt;
        ddlCuringMachine.DataTextField = "CURINGLINE";
        ddlCuringMachine.DataValueField = "CURINGLINE";
        ddlCuringMachine.DataBind();
        ddlCuringMachine.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddlCuringMachine.SelectedIndex = 0;
        ddlCuringMachine.Items[0].Attributes.Add("disabled", "disabled");

        ddl_CuringMachine.DataSource = dt;
        ddl_CuringMachine.DataTextField = "CURINGLINE";
        ddl_CuringMachine.DataValueField = "CURINGLINE";
        ddl_CuringMachine.DataBind();
        ddl_CuringMachine.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddl_CuringMachine.SelectedIndex = 0;
        ddl_CuringMachine.Items[0].Attributes.Add("disabled", "disabled");
    }
    #endregion

    #region Create
    protected void btnSave_Click(object sender, EventArgs e) 
    {

        if (txtModelCode.Text == "" || txtSFLotNo.Text == "" || txtSFPartCode.Text==""|| txtSFPartName.Text==""|| txtSFAmount.Text == "" || txtBottlePartCode.Text==""|| txtBottleLotNo.Text == "" || txtBottleAmount.Text == "" || ddlCuringMachine.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "emptyFieldsAlert();", true);
        }
        else
        {
            _workshift = Session["WORKSHIFT"].ToString();
            _createdby = Session["EMPLOYEENO"].ToString();
            _datecreated = datetime.ToString("MM/dd/yyyy hh:mm:ss tt");

            _createCuring.createIBPPCuring(txtModelCode.Text, txtType.Text, txtDestination.Text, txtColor.Text, txtSFLotNo.Text, txtSFPartCode.Text, txtSFPartName.Text,
           txtSFAmount.Text, txtBottleLotNo.Text, txtBottlePartCode.Text, txtBottleAmount.Text, txtCavityNo.Text, ddlCuringMachine.SelectedValue, _workshift, _createdby, _datecreated);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "saveAlert();", true);

            resetFields();
        }
    }
    #endregion

    #region CheckBox OnChanged Properties 
    protected void chkModelQR_CheckedChanged(object sender, EventArgs e)
    {
        if (chkModelQR.Checked)
        {
            txtModelCode.Enabled = false;
            txtModelQR.Enabled = true;
            txtModelCode.BackColor = Color.Gray;
            txtModelQR.BackColor = Color.White;
            resetFields();
        }
        else
        {
            txtModelCode.Enabled = true;
            txtModelQR.Enabled = false;
            txtModelCode.BackColor = Color.White;
            txtModelQR.BackColor = Color.Gray;
            resetFields();
        }
    }
    protected void chkBottle_CheckedChanged(object sender, EventArgs e)
    {
        if (chkBottle.Checked)
        {
            txtQRBottle.Enabled = true;
            txtQRBottle.BackColor = Color.White;

            txtBottlePartCode.Enabled = false;
            txtBottlePartCode.BackColor = Color.Gray;

            txtBottleLotNo.Enabled = false;
            txtBottleLotNo.BackColor = Color.Gray;

            txtCavityNo.Enabled = false;
            txtCavityNo.BackColor = Color.Gray;

            txtBottleAmount.Enabled = false;
            txtBottleAmount.BackColor = Color.Gray;
            ResetQRBottleFields();
        }
        else
        {
            txtQRBottle.Enabled = false;
            txtQRBottle.BackColor = Color.Gray;

            txtBottlePartCode.Enabled = true;
            txtBottlePartCode.BackColor = Color.White;

            txtBottleLotNo.Enabled = true;
            txtBottleLotNo.BackColor = Color.White;

            txtCavityNo.Enabled = true;
            txtCavityNo.BackColor = Color.White;

            txtBottleAmount.Enabled = true;
            txtBottleAmount.BackColor = Color.White;

            ResetQRBottleFields();
        }

    }
    #endregion

    #region TextChanged Properties
    protected void txtModelQR_TextChanged(object sender, EventArgs e)
    {
        string[] QRitem = txtModelQR.Text.ToUpper().Trim().Split(new char[] { '|' });
        txtModelQR.Text = "";
        string strZNo;
        foreach (string str in QRitem)
        {
            strZNo = str.Substring(0, 2);
            txtModelCode.Text = (strZNo == "Z1") ? str.Remove(0, 2) : txtModelCode.Text;
        }
       ModelCodeCheck();
    }
    protected void txtQRBottle_TextChanged(object sender, EventArgs e)
    {
        
        string[] QRitem = txtQRBottle.Text.ToUpper().Trim().Split(new char[] { '|' });
        txtQRBottle.Text = "";
        string strZNo;
        foreach (string str in QRitem)
        {
            strZNo = str.Substring(0, 2);

            txtBottlePartCode.Text = (strZNo == "Z1") ? str.Remove(0, 2) : txtBottlePartCode.Text;
            txtBottleLotNo.Text = (strZNo == "Z2") ? str.Remove(0, 2) : txtBottleLotNo.Text;
            txtBottleAmount.Text = (strZNo == "Z3") ? str.Remove(0, 2) : txtBottleAmount.Text;
            txtCavityNo.Text = (strZNo == "Z4") ? str.Remove(0, 2) : txtCavityNo.Text;
        }
        BottleQRCheck();
    }
  

    protected void txtModelCode_TextChanged(object sender, EventArgs e)
    {
       ModelCodeCheck();
    }
    protected void txtSFPartCode_TextChanged(object sender, EventArgs e)
    {
        ShrinkFilmCodeCheck();
    }
    protected void txtBottlePartCode_TextChanged(object sender, EventArgs e)
    {
        BottlePartCodeCheck();
    }
    #endregion

    #region Trigger Properties
    public void ModelCodeCheck()
    {
        if (!string.IsNullOrEmpty(txtModelCode.Text))
        {
            if (check.checkModel(txtModelCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSFPartCode.ClientID + "').focus();}, 500);", true);
                GetModelData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
                txtModelCode.Text = null;
                txtType.Text = null;
                txtDestination.Text = null;
                txtColor.Text = null;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "emptyFields();", true);
        }
    }
    public void ShrinkFilmCodeCheck()
    {
        if (txtModelCode.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtSFPartCode.Text = null;
        }
        else
        {
            if (check.checkShrinkFilm(txtModelCode.Text, txtSFPartCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSFLotNo.ClientID + "').focus();}, 500);", true);       
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSFPartCode.ClientID + "').focus();}, 500);", true);
                txtSFPartCode.Text = null;
            }
        }
    }
    public void BottleQRCheck()
    {
        string modelcode = txtModelCode.Text.Trim();

        if(string.IsNullOrEmpty(modelcode))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ResetQRBottleFields();
        }
        else if (!string.IsNullOrEmpty(modelcode) && !string.IsNullOrEmpty(txtBottlePartCode.Text) && !string.IsNullOrEmpty(txtBottleLotNo.Text))
        {
            if (check.checkBottleQR(modelcode, txtBottlePartCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + ddlCuringMachine.ClientID + "').focus();}, 500);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtQRBottle.ClientID + "').focus();}, 500);", true);
                ResetQRBottleFields();
            }
        }  
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "emptyFields();", true);
        }
    }
    public void BottlePartCodeCheck()
    {
        if (txtModelCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtBottlePartCode.Text = null;
        }
        else
        {
            if (check.checkBottlePartCode(txtModelCode.Text, txtBottlePartCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtBottleLotNo.ClientID + "').focus();}, 500);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtBottlePartCode.ClientID + "').focus();}, 500);", true);
                txtBottlePartCode.Text = null;
            }
        }     
    }
    #endregion

    #region Additional Properties.
    public void ResetQRBottleFields()
    {
        txtBottleLotNo.Text = null;
        txtBottlePartCode.Text = null;
        txtCavityNo.Text = null;
        txtBottleAmount.Text = null;
    }
    public void ResetQRModelFields()
    {
        txtModelCode.Text = null;
        txtType.Text = null;
        txtDestination.Text = null;
        txtColor.Text = null;
    }
    public void resetFields() //CLEAR TEXT FIELDS
    {
        txtID.Text = null;
        txtModelCode.Text = null;
        txtType.Text = null;
        txtDestination.Text = null;
        txtColor.Text = null;
        txtSFLotNo.Text = null;
        txtSFPartCode.Text = null;
        txtSFPartName.Text = null;
        txtSFAmount.Text = null;
        txtBottleLotNo.Text = null;
        txtBottlePartCode.Text = null;
        txtBottleAmount.Text = null;
        txtCavityNo.Text = null;
        ddlCuringMachine.SelectedIndex = 0;
    }
    public void disabledInputs() //DISABLE INPUTS
    {
        txtType.Enabled = false;
        txtDestination.Enabled = false;
        txtColor.Enabled = false;

        if (chkModelQR.Checked)
        {
            txtModelCode.Enabled = false;
            txtModelQR.Enabled = true;
            txtCavityNo.Enabled = false;
            txtBottleAmount.Enabled = false;
            txtModelCode.BackColor = Color.Gray;
        }
        else
        {
            txtModelCode.Enabled = true;
            txtModelQR.Enabled = false;
            txtModelQR.BackColor = Color.Gray;
        }
        if (chkBottle.Checked)
        {
            txtQRBottle.Enabled = true;

            txtBottlePartCode.Enabled = false;
            txtBottlePartCode.BackColor = Color.Gray;

            txtBottleLotNo.Enabled = false;
            txtBottleLotNo.BackColor = Color.Gray;

            txtCavityNo.Enabled = false;
            txtCavityNo.BackColor = Color.Gray;

            txtBottleAmount.Enabled = false;
            txtBottleAmount.BackColor = Color.Gray;
        }
        else
        {
            txtQRBottle.Enabled = false;
            txtQRBottle.BackColor = Color.Gray;
            txtBottlePartCode.Enabled = true;
            txtBottleLotNo.Enabled = true;
            txtCavityNo.Enabled = true;
            txtBottleAmount.Enabled = true;
   
        }
    }
   public  void changeColor() //CHANGE BACKCOLOR
    {
        txtType.BackColor = Color.Gray;
        txtDestination.BackColor = Color.Gray;
        txtColor.BackColor = Color.Gray;
    }
    #endregion
}