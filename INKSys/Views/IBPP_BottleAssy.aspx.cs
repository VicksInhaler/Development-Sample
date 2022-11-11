using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_IBPP_BottleAssy : System.Web.UI.Page
{
    static IBPP_BottleAssy_Get getBottleAssy = new IBPP_BottleAssy_Get();
    static Maintenance_INK maint = new Maintenance_INK();
    static IBPP_Line_Get getLine = new IBPP_Line_Get();
    static IBPP_BottleAssy_Create create = new IBPP_BottleAssy_Create();
    static string _unboxed, _model, _destination, _color, _workshift, _boxno, _updatedby, _updateddatetime, bottleassylotno;
    static string _year, _month, _day;
    DateTime datetime = DateTime.Now;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {    
            OnloadProperties();
        }
    }
    [WebMethod]
    public static string GetBottleAssy() 
    {
        return JsonConvert.SerializeObject(getBottleAssy.getBottleAssyDetails());
    }
    public void GetModelData()
    {
        DataTable data = new DataTable();
        data = maint.getModelData(txtModelCode.Text);
        txtType.Text = data.Rows[0]["MODEL"].ToString();
        txtDestination.Text = data.Rows[0]["DESTINATION"].ToString();
        txtColor.Text = data.Rows[0]["COLOR"].ToString();
    }
    public void GetShrinkFilmPartName()
    {
        DataTable data = new DataTable();
        data = maint.getSFPartName(txtSFPartCode.Text);
        txtSFPartName.Text = data.Rows[0]["PARTNAME"].ToString();
    }
    public void GetLine()
    {
        DataTable dt = new DataTable();
        dt = maint.getIBPPCuringLine();
        ddlCuringLine.DataSource = dt;
        ddlCuringLine.DataTextField = "CURINGLINE";
        ddlCuringLine.DataValueField = "CURINGLINE";
        ddlCuringLine.DataBind();
        ddlCuringLine.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddlCuringLine.SelectedIndex = 0;
        ddlCuringLine.Items[0].Attributes.Add("disabled", "disabled");
        DataTable dt2 = new DataTable();
        dt2 = maint.getIBPPLineArea();
        ddlLineStockArea.DataSource = dt2;
        ddlLineStockArea.DataTextField = "IBPPSTOCKAREA";
        ddlLineStockArea.DataValueField = "IBPPSTOCKAREA";
        ddlLineStockArea.DataBind();
        ddlLineStockArea.Items.Insert(0, new ListItem("--SELECT--", "0"));
        ddlLineStockArea.SelectedIndex = 0;
        ddlLineStockArea.Items[0].Attributes.Add("disabled", "disabled");
    }
    #region TextChanged Properties
    protected void chkModelQR_CheckedChanged(object sender, EventArgs e)
    {
        if (chkModelQR.Checked)
        {
            txtModelCode.Enabled = false;
            txtModelQR.Enabled = true;
            txtModelCode.BackColor = Color.Gray;
            txtModelQR.BackColor = Color.White; 
        }
        else
        {
            txtModelCode.Enabled = true;
            txtModelQR.Enabled = false;
            txtModelCode.BackColor = Color.White;
            txtModelQR.BackColor = Color.Gray;
        }
    }
    protected void txtModelQR_TextChanged(object sender, EventArgs e)
    {
        string[] QRitem = txtModelQR.Text.ToUpper().Trim().Split(new char[] { '|' });
        txtModelQR.Text = "";
        string strZNo;
        foreach (string str in QRitem)
        {
            strZNo = str.Substring(0, 2);
            txtModelCode.Text = (strZNo == "Z1") ? str.Remove(0, 2) : txtModelCode.Text; break;
        }

        ModelCodeCheck();
    }
    protected void txtModelCode_TextChanged(object sender, EventArgs e)
    {
        ModelCodeCheck();
    }
    protected void txtSFPartCode_TextChanged(object sender, EventArgs e)
    {
        ShrinkFilmCodeCheck();
    }
    protected void txtSFLotNo_TextChanged(object sender, EventArgs e)
    {
        ShrinkFilmLotCheck();
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
        }
        BottleLotCheck();
    }
    protected void txtBottlePartCode_TextChanged(object sender, EventArgs e)
    {
        BottlePartCodeCheck();
    }
    protected void txtBottleLotNo_TextChanged(object sender, EventArgs e)
    {
        BottleLotCheck();
    }
    public void ModelCodeCheck()
    {
        if (!string.IsNullOrEmpty(txtModelCode.Text))
        {
            if (maint.checkModel(txtModelCode.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtSFPartCode.ClientID + "').focus();}, 500);", true);
                GetModelData();
                btnChangeModel.Enabled = true;
                txtModelCode.Enabled = false;
                txtModelCode.BackColor = Color.Gray;
                chkModelQR.Enabled = false;
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
        if (txtModelCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtSFPartCode.Text = null;
        }
        else
        {
            if (maint.checkShrinkFilm(txtModelCode.Text, txtSFPartCode.Text))
            {
                GetShrinkFilmPartName();
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
    public void ShrinkFilmLotCheck()
    {
        if (txtModelCode.Text == "" || txtSFPartCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
            txtBottlePartCode.Text = null;
        }
        else
        {
            if (maint.checkShrinkFilmLot(txtModelCode.Text, txtSFPartCode.Text, txtSFLotNo.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtQRBottle.ClientID + "').focus();}, 500);", true);
                GetShrinkFilmPartName();


            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtBottlePartCode.ClientID + "').focus();}, 500);", true);
                txtBottlePartCode.Text = null;
            }
        }
    }
    public void BottleQRCheck()
    {
        string modelcode = txtModelCode.Text.Trim();

        if (string.IsNullOrEmpty(modelcode))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            //ResetQRBottleFields();
        }
        else if (!string.IsNullOrEmpty(modelcode) && !string.IsNullOrEmpty(txtBottlePartCode.Text) && !string.IsNullOrEmpty(txtBottleLotNo.Text))
        {
            if (maint.checkBottleQR(modelcode, txtBottlePartCode.Text, txtBottleLotNo.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + ddlLineStockArea.ClientID + "').focus();}, 500);", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "noDataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtQRBottle.ClientID + "').focus();}, 500);", true);
                // ResetQRBottleFields();
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
            if (maint.checkBottlePartCode(txtModelCode.Text, txtBottlePartCode.Text))
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
    public void BottleLotCheck()
    {
        if (txtModelCode.Text == "")
        {
            txtBottleLotNo.Text = null;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ModelCodeMissingAlert();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtModelCode.ClientID + "').focus();}, 500);", true);
           
        }
        else
        {
            if (maint.checkBottleLot(txtModelCode.Text, txtBottlePartCode.Text, txtBottleLotNo.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "dataFoundAlert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FocusScript", "setTimeout(function(){$get('" + txtAmount.ClientID + "').focus();}, 500);", true);
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
    protected void btnChangeModel_Click(object sender, EventArgs e)
    {
        Application["Count"] = null;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Popup", "ChangeModelAlert();", true);
        txtModelCode.Enabled = true;
        txtType.Text = null;
        txtDestination.Text = null;
        txtColor.Text = null;
        txtModelCode.BackColor = Color.White;
        chkModelQR.Enabled = true;
    }
    #region Create and Save Properties
    protected void btnSave_Click(object sender, EventArgs e)
    {
          if (ddlLineStockArea.SelectedIndex == 0 || ddlCuringLine.SelectedIndex==0 || txtCavityNo.Text=="")
          {
              return;
          }
          else
          {
            GenerateBottleAssyLotID();
            CreateBottleAssySub();
            CreateBottleAssy();
          }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ViewState["CurrentTable"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BOTTLELOTNO", typeof(string));
            dt.Columns.Add("SFLOTNO", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Rows.Add(txtBottleLotNo.Text.Trim().ToUpper(), txtSFLotNo.Text.Trim().ToUpper(), txtAmount.Text.Trim().ToUpper());
            ViewState["CurrentTable"] = dt;
            this.grvBottleAssyList.DataSource = dt;
            this.grvBottleAssyList.DataBind();
        }
        else
        {
            DataTable dt2 = (DataTable)ViewState["CurrentTable"];
            dt2.Rows.Add(txtBottleLotNo.Text.Trim().ToUpper(), txtSFLotNo.Text.Trim().ToUpper(), txtAmount.Text.Trim().ToUpper());
            this.grvBottleAssyList.DataSource = dt2;
            this.grvBottleAssyList.DataBind();
            ViewState["CurrentTable"] = dt2;
        }
    }
    public void CreateBottleAssySub()
    {
        DataTable dt = (DataTable)ViewState["CurrentTable"];
        string bottlelotno, sflotno, amount;
        foreach (DataRow row in dt.Rows)
        {
            bottlelotno = row["BOTTLELOTNO"].ToString();
            sflotno = row["SFLOTNO"].ToString();
            amount = row["AMOUNT"].ToString();
            create.createSubData(bottleassylotno, bottlelotno, sflotno, amount);

            ViewState["CurrentTable"] = null;
            grvBottleAssyList.DataSource = (DataTable)ViewState["CurrentTable"];
            grvBottleAssyList.DataBind();
        }
    }
    public void CreateBottleAssy()
    {
      boxno();
      _workshift = Session["WORKSHIFT"].ToString();
      _updatedby = Session["EMPLOYEENO"].ToString();
      _updateddatetime = datetime.ToString("MM/dd/yyyy hh:mm:ss tt");
      create.createBottleAssy(txtModelCode.Text.Trim().ToUpper(),
                              bottleassylotno,
                              txtBottlePartCode.Text.Trim().ToUpper(),
                              txtSFPartCode.Text.Trim().ToUpper(), 
                              txtCavityNo.Text.Trim().ToUpper(),
                              _boxno,
                              ddlLineStockArea.SelectedValue,
                              _workshift,
                              _updatedby,
                              _updateddatetime);
    }
    public void GenerateBottleAssyLotID()
    {
                              string c = "C";
                              string curingline = c + ddlCuringLine.SelectedValue;
                              string workshift = Session["WORKSHIFT"].ToString();
                              string controlnumber = create.GenerateControl(curingline, workshift);
                              bottleassylotno = controlnumber;
    }
    #endregion
    public void OnloadProperties()
    {
                              GetLine();
                              txtType.Enabled = false;
                              txtDestination.Enabled = false;
                              txtColor.Enabled = false;
                              txtType.BackColor = Color.Gray;
                              txtDestination.BackColor = Color.Gray;
                              txtColor.BackColor = Color.Gray;
                              txtModelCode.Text = null;
                          
                              if (chkModelQR.Checked)
                              {
                                  txtModelCode.Enabled = false;
                                  txtModelQR.Enabled = true;    
                                  txtModelCode.BackColor = Color.Gray;
                              }
                              else
                              {
                                  txtModelCode.Enabled = true;
                                  txtModelQR.Enabled = false;
                                  txtModelQR.BackColor = Color.Gray;
                              }
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

    protected void btnPrintBottleAssy_Click(object sender, EventArgs e)
    {
        Response.Redirect("IBPP_BottleAssy_PrintAll.aspx");
    }
}