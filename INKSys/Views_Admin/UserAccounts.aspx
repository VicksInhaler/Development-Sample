<%@ Page Title="" Language="C#" MasterPageFile="~/Views_Admin/Admin.master" AutoEventWireup="true" CodeFile="UserAccounts.aspx.cs" Inherits="Views_Admin_UserAccounts" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control {
            border-color: #2a2e32;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="UserAccounts" runat="server"></asp:ScriptManager>
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>User Accounts</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item active">User Accounts</li>
                    </ol>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </section>

    <section class="content">
        <div class="container-fluid">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="col-md-12">
                        <div class="card card-primary">

                            <div class="card-header">
                                <h3 class="card-title">Create User</h3>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="">EMPLOYEE NUMBER:</label>
                                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" hidden="true" />
                                            <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control" onkeypress="return isNumber(event)" placeholder="Enter Employee Number" />
                                        </div>
                                        <div class="form-group">
                                            <label for="">FIRST NAME:</label>
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter First Name" />
                                        </div>
                                        <div class="form-group">
                                            <label for="">MIDDLE NAME:</label>
                                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" placeholder="Enter Middle Name " />
                                        </div>
                                        <div class="form-group">
                                            <label for="">LAST NAME:</label>
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter Last Name" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label for="">NICKNAME:</label>
                                            <asp:TextBox ID="txtNickName" runat="server" CssClass="form-control" placeholder="Enter Employee Nickkname" />
                                        </div>
                                        <div class="form-group">
                                            <label>POSITION: <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlPosition" CssClass="form-control text-uppercase"
                                                AutoCompleteType="Disabled" runat="server">
                                                <asp:ListItem Text="OPERATOR" />
                                                <asp:ListItem Text="Line Leader" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>SECTION: <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlSection" CssClass="form-control text-uppercase"
                                                AutoCompleteType="Disabled" runat="server">

                                                <asp:ListItem Text="IBPP" />
                                                <asp:ListItem Text="IPS" />
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label>ROLE: <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlRole" CssClass="form-control text-uppercase"
                                                AutoCompleteType="Disabled" runat="server">
                                                <asp:ListItem Text="1" />
                                                <asp:ListItem Text="2" />
                                                <asp:ListItem Text="3" />
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>WORKSHIFT: <span style="color: red">*</span></label>
                                            <asp:DropDownList ID="ddlWorkShift" CssClass="form-control text-uppercase"
                                                AutoCompleteType="Disabled" runat="server">
                                                <asp:ListItem Text="DS" />
                                                <asp:ListItem Text="NS" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer" style="margin-left: auto;">
                                <asp:Button runat="server" CssClass=" btn btn-primary" Text="Save" ID="btnSave" OnClick="btnSave_Click" />
                                <asp:Button runat="server" CssClass=" btn btn-warning" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
                <Triggers>   
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"/>
                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"/>
                </Triggers>
            </asp:UpdatePanel>

            <div class="col-md-12">
                <div class="container-fluid">
                    <div class="card card-primary card-outline">
                        <div class="card-header">
                            <h3 class="card-title">User List</h3>
                        </div>
                              <div class="card-body pad table-responsive">
                                  <div class="table">
                        <table class="useraccounts table table-bordered text-nowrap" style="width: 100%; border: 1px solid #000;"></table>
                        </div>
                         </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <script src="../resources/custom/user-accounts/admin-user.js"></script>
    <script src="../resources/custom/user-accounts/admin-validation.js"></script>
</asp:Content>

