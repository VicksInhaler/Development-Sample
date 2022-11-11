using System;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admin_UserAccounts : System.Web.UI.Page
{
    static UserController useraccount = new UserController();
    static UserModel user = new UserModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDropDownList();
     
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {        
        CreateUser();
    }
    public void CreateUser()
    {
        if (txtEmployeeNo.Text == "" || txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" || ddlPosition.SelectedIndex == 0 || ddlRole.SelectedIndex == 0 || ddlSection.SelectedIndex==0 || ddlWorkShift.SelectedIndex==0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Empty Fields');", true);
        }
        else
        {
            #region Parameters
            string UPDATEDBY = Session["UserName"].ToString();
            var logDateToday = DateTime.Now;
            string logDateTime = logDateToday.ToString("MM/dd/yyyy hh:mm:ss tt");
            user.EMPLOYEENUMBER = int.Parse(txtEmployeeNo.Text);
            user.PASSWORD = txtEmployeeNo.Text;
            user.FIRSTNAME = txtFirstName.Text;
            user.MIDDLENAME = txtMiddleName.Text;
            user.LASTNAME = txtLastName.Text;
            user.NICKNAME = txtNickName.Text;
            user.POSITION = ddlPosition.SelectedValue;
            user.ROLE = ddlRole.SelectedValue;
            user.SECTION = ddlSection.SelectedValue;
            user.WORKSHIFT = ddlWorkShift.SelectedValue;
            #endregion  
            useraccount.CreateInksysUser(user.EMPLOYEENUMBER, user.PASSWORD, user.FIRSTNAME, user.MIDDLENAME,
                                  user.LASTNAME, user.NICKNAME, user.POSITION, user.SECTION, user.ROLE,
                                  user.WORKSHIFT, logDateTime, UPDATEDBY);

            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Check Create');", true);
            ClearFields();
        }
      
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateUser();
        btnSave.Visible = true;
    }  
    public void UpdateUser()
    {
        if (txtID.Text=="")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Error Update');", true);
        }
        else
        {
            #region Parameters
            string UPDATEDBY = Session["UserName"].ToString();
            var logDateToday = DateTime.Now;
            string logDateTime = logDateToday.ToString("MM/dd/yyyy hh:mm:ss tt");
            string id = txtID.Text;
            user.EMPLOYEENUMBER = int.Parse(txtEmployeeNo.Text);
            user.PASSWORD = txtEmployeeNo.Text;
            user.FIRSTNAME = txtFirstName.Text;
            user.MIDDLENAME = txtMiddleName.Text;
            user.LASTNAME = txtLastName.Text;
            user.NICKNAME = txtNickName.Text;
            user.POSITION = ddlPosition.SelectedValue;
            user.ROLE = ddlRole.SelectedValue;
            user.SECTION = ddlSection.SelectedValue;
            user.WORKSHIFT = ddlWorkShift.SelectedValue;
            #endregion
            useraccount.UpdateInksysUser(id, user.EMPLOYEENUMBER, user.PASSWORD, user.FIRSTNAME, user.MIDDLENAME,
                                     user.LASTNAME, user.NICKNAME, user.POSITION, user.SECTION, user.ROLE,
                                     user.WORKSHIFT, logDateTime, UPDATEDBY);
            ScriptManager.RegisterStartupScript(this, GetType(), "string", "alert('Check Update');", true);
            ClearFields();
        }
       
    }
    [WebMethod]
    public static string GetUserData()
    {
        return JsonConvert.SerializeObject(useraccount.GetUserDataList());
    }
    public void GetDropDownList()
    {
        ddlWorkShift.Items.Insert(0, new ListItem("Choose WorkShift", "0"));
        ddlPosition.Items.Insert(0, new ListItem("Choose Position", "0"));
        ddlRole.Items.Insert(0, new ListItem("Choose WorkShift", "0"));
        ddlSection.Items.Insert(0, new ListItem("Choose WorkShift", "0"));
    }
    public void ClearFields()
    {
        txtID.Text = null;
        txtEmployeeNo.Text=null;
        txtEmployeeNo.Text=null;
        txtFirstName.Text =null;
        txtMiddleName.Text=null;
        txtLastName.Text  =null;
        txtNickName.Text = null;
        ddlPosition.SelectedIndex = 0;
        ddlRole.SelectedIndex = 0;
        ddlSection.SelectedIndex = 0;
        ddlWorkShift.SelectedIndex = 0;
    } 
}