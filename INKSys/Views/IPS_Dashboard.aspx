<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inksys.master" AutoEventWireup="true" CodeFile="IPS_Dashboard.aspx.cs" Inherits="Views_IPS_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.form-control {
border-color: #2a2e32;
width: 98%;
}
.info-box-text{
    font-size:medium;
    font-weight:bold;

}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<asp:ScriptManager ID="IPSDashboard" runat="server"></asp:ScriptManager>
<section class="content-header">
<div class="container-fluid">
<div class="row mb-2">
    <div class="col-sm-6">
        <h1>IPS Parts Scanning</h1>
    </div>
    <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item active">Parts Scanning</li>
        </ol>
    </div>
</div>
</div>
</section>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box">
                        <span class="info-box-icon bg-primary">
                        <asp:Label ID="lblBottleAssy" runat="server">000</asp:Label></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Bottle Assy</span>      
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box">
                        <span class="info-box-icon bg-success"><asp:Label ID="lblCapAmount" runat="server">0</asp:Label></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Cap</span> 
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box">
                        <span class="info-box-icon bg-warning"><asp:Label ID="lblSpoutAmount" runat="server">0</asp:Label></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Spout</span>           
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box">
                        <span class="info-box-icon bg-danger"><asp:Label ID="lblSlitValveAmount" runat="server">0</asp:Label></span>
                        <div class="info-box-content">
                            <span class="info-box-text">Slit Valve</span> 
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<section class="content">
<div class="container-fluid">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div class="col-md-12">
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Parts Scanning</h3>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 p-3">
                            <div class="form-group row">
                                <div class="col-md-7 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Bottle Assy Lot No:" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtBottleAssy" CssClass="form-control" placeholder="Enter Bottle Assy Lot" runat="server" OnTextChanged="txtBottleAmount_TextChanged" AutoPostBack="true" EnableViewState="True" />
                                    <asp:TextBox ID="txtID" runat="server" visible="true" />
                                </div>
                                <div class="col-md-5 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Amount" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtBaAmount" CssClass="form-control" placeholder="Enter Amount" disabled="true" runat="server" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-7 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Cap Lot No:" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtCap" CssClass="form-control" placeholder="Enter Lot No:" runat="server" OnTextChanged="txtCap_TextChanged" />
                                </div>
                                <div class="col-md-5 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Amount" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtCapAmount" CssClass="form-control" placeholder="Enter Amount:" disabled="true" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 p-3">
                            <div class="form-group row">
                                <div class="col-md-7 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Spout Lot:" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtSpout" CssClass="form-control" placeholder="Enter Lot No:" runat="server" OnTextChanged="txtSpout_TextChanged" />
                                </div>
                                <div class="col-md-5 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Amount" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtSpoutAmount" CssClass="form-control" placeholder="Enter Amount" disabled="true" runat="server" />
                                </div>

                            </div>
                            <div class="form-group row">
                                <div class="col-md-7 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Slitvalve Lot No:" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtSlitvalve" CssClass="form-control" placeholder="Enter Lot No:" runat="server" OnTextChanged="txtSlitvalve_TextChanged" />
                                </div>
                                <div class="col-md-5 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Amount" runat="server" /><span class="required">*</span>
                                    <asp:TextBox ID="txtSlitAmount" CssClass="form-control" placeholder="Enter Amount" disabled="true" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 p-3">
                            <div class="form-group row">
                                <div class="col-md-6 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="Pack Bottle Lot:" runat="server" /><span class="required" style="color: red">*</span>
                                    <asp:TextBox ID="txtPackBottle" CssClass="form-control" placeholder="Enter Lot No:" runat="server" OnTextChanged="txtPackBottle_TextChanged" />
                                </div>
                                <div class="col-md-6 pl-0 pr-0">
                                    <asp:Label CssClass="label" Text="INK Lot:" runat="server" /><span class="required" style="color: red">*</span>
                                    <asp:TextBox ID="txtInk" CssClass="form-control" placeholder="Enter Lot No:" runat="server" OnTextChanged="txtInk_TextChanged" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label CssClass="label" Text="LINE MACHINE:" runat="server" /><span class="required" style="color: red">*</span>
                                <asp:DropDownList ID="ddlLineMachine" CssClass="form-control text-uppercase"
                                    AutoCompleteType="Disabled" runat="server" OnTextChanged="ddlLineMachine_TextChanged">
                                    <asp:ListItem Text="Line A" Value="A" />
                                    <asp:ListItem Text="Line B" Value="B" />
                                    <asp:ListItem Text="Line C" Value="C" />
                                    <asp:ListItem Text="Line D" Value="D" />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer" style="margin-left: auto;">
                    <asp:Button runat="server" CssClass=" btn btn-primary" Text="Save" ID="btnSave"  OnClick="btnSave_Click" UseSubmitBehavior="False" />
                    <asp:Button runat="server" CssClass=" btn btn-warning" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click"  UseSubmitBehavior="False" />   
                    <asp:Button runat="server" ID="btnHide" hidden="true" />
              </div>
           </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <%--  <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click"/>--%>
    </Triggers>
</asp:UpdatePanel>
<div class="col-md-12">
    <div class="container-fluid">
        <div class="card card-primary card-outline">
            <div class="card-header">
                <h3 class="card-title">Part Scanning</h3>
            </div>
            <div class="card-body pad table-responsive">
                <div class="table">
                    <table class="partscan table table-bordered table-sm text-nowrap" style="width: 100%; border: 1px solid #000;"></table>
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
    <script src="../resources/custom/ips-parts-scan/parts_scanning.js"></script>
</asp:Content>

