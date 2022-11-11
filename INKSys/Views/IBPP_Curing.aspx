<%@ Page Title="IBPP Incoming For Curing" Language="C#" MasterPageFile="~/Views/Inksys.master" AutoEventWireup="true" CodeFile="IBPP_Curing.aspx.cs" Inherits="Views_IBPP_IncomingForCuring" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<!--STYLES-->
<link href="../resources/custom/ibpp-curing/css/ibpp-incoming-for-curing.css" rel="stylesheet" />
<!--SWEET ALERT CSS-->
<link href="../resources/plugins/sweetalert2-manual/dist/animate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-info mt-2">
                <!--TITLE HEADER-->
                <div class="card-header">
                    <h5>PARTS CURING MACHINE ALLOCATION</h5>
                </div>
                <!-- MAIN CONTENT -->
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: -20px;">
                                <!--MODEL-->
                                <div class="col-md-4 p-3">
                                    <!-- ID -->
                                    <asp:TextBox ID="txtID" hidden="true" runat="server" />
                                    <!-- /ID -->
                                    <div class="form-group row">
                                        <div class="col-md-8 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="QR Code" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtModelQR" CssClass="form-control text-uppercase" OnTextChanged="txtModelQR_TextChanged" runat="server" />
                                        </div>
                                        <div class="col-md-3 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="check." runat="server" /><span class="required">*</span>
                                            <asp:CheckBox ID="chkModelQR" CssClass="form-check" runat="server" AutoPostBack="true" OnCheckedChanged="chkModelQR_CheckedChanged" />
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Part Code" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtModelCode" CssClass="form-control" OnTextChanged="txtModelCode_TextChanged" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Model" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtType" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Destination" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtDestination" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Color" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtColor" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <!--SHRINK FILM-->
                                <div class="col-md-4 p-3">
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Shrink Film PartCode" runat="server" /><span class="required">*</span>
                                        </label>
                                        <asp:TextBox ID="txtSFPartCode" CssClass="form-control" OnTextChanged="txtSFPartCode_TextChanged" onkeypress="return isNumber(event)" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Shrink Film Lot No." runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtSFLotNo" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Shrink Film PartName" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtSFPartName" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Shrink Film Amount" runat="server" onkeypress="return isNumber(event)" /><span class="required">*</span>
                                        </label>
                                        <asp:TextBox ID="txtSFAmount" CssClass="form-control" onkeypress="return isNumber(event)" runat="server" />
                                    </div>
                                </div>
                                <!--BOTTLE-->

                                <div class="col-md-4 p-3">
                                    <div class="form-group row">
                                        <div class="col-md-8 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="QR Code" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtQRBottle" CssClass="form-control" OnTextChanged="txtQRBottle_TextChanged" runat="server" />
                                        </div>
                                        <div class="col-md-3 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="check." runat="server" /><span class="required">*</span>
                                            <asp:CheckBox ID="chkBottle" CssClass="form-check" runat="server" AutoPostBack="true" OnCheckedChanged="chkBottle_CheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Bottle PartCode" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtBottlePartCode" CssClass="form-control" OnTextChanged="txtBottlePartCode_TextChanged" onkeypress="return isNumber(event)" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Bottle Lot No." runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtBottleLotNo" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-7 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="Bottle Amount" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtBottleAmount" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="col-md-5 pl-0 pr-0">
                                            <asp:Label CssClass="label" Text="Cavity No." runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtCavityNo" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label CssClass="label" Text="Curing Machine" runat="server" /><span class="required">*</span>
                                        <asp:DropDownList ID="ddlCuringMachine" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <!--BUTTONS-->
                            <div class="row button-group" style="margin-top: -20px;">
                                <asp:Button ID="btnHide" hidden="true" runat="server" />
                                <asp:Button ID="btnSave" CssClass="action-button" Text="Save" OnClick="btnSave_Click" runat="server" UseSubmitBehavior="False" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="divider">
                        <span></span>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <table class="curing-table table table-bordered text-nowrap" style="width: 100%; border: 1px solid #000;"></table>
                        </div>
                    </div>
                    <!-- END TABLE-->
                </div>
            </div>
        </div>
        <!-- END MAIN CONTENT -->

    </div>
    <div class="modal fade" id="ModalEdit">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Unboxed Partcode:<label id="lbl_ModelCode"></label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="hidden" id="txt_ID">
                                <label>SHRINK FILM PARTCODE:</label>
                                <h4>
                                    <label id="lbl_SFPartCode"></label>
                                </h4>
                            </div>
                            <div class="form-group">
                                <label>SHRINK FILM LOT NO</label>
                                <input type="text" id="txt_SFLotNo" class="form-control">
                            </div>
                            <div class="form-group">
                                <label>SHRINK FILM PARTNAME</label>
                                <input type="text" id="txt_SFPartName" class="form-control">
                            </div>
                            <div class="form-group">
                                <label for="inputProjectLeader">SHRINK FILM AMOUNT</label>
                                <input type="text" id="txt_SFFilmAmount" class="form-control">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>BOTTLE PARTCODE:</label>
                                <h4>
                                    <label id="lbl_BottleCode"></label>
                                </h4>
                            </div>
                            <div class="form-group row">
                                <label for="">BOTTLE LOT NO:</label>
                                <input type="text" id="txtBottleLot" class="form-control">
                            </div>
                            <div class="form-group row">
                                <div class="col-md-7 pl-0 pr-0">
                                    <label for="">BOTTLE AMOUNT:</label>
                                    <input type="text" id="txt_BottleAmount" class="form-control">
                                </div>
                                <div class="col-md-5 pl-0 pr-0">
                                    <label for="">CAVITY NO:</label>
                                    <input type="text" id="txt_CavityNo" class="form-control">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="">CURING MACHINE</label>
                                <asp:DropDownList ID="ddl_CuringMachine" CssClass="form-control select2" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer justify-content-between">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" id="btnUpdate">Update</button>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
        </div>
    </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="Server">
<!--Sweet Alert Manual -->
<script src="../resources/plugins/sweetalert2-manual/dist/sweetalert2.all.min.js"></script>
<!--Scripts-->
<script src="../resources/custom/ibpp-curing/js/ibpp-curing.js"></script>
<!-- Notification Alert JS -->
<script src="../resources/custom/ibpp-curing/js/notification.js"></script>
</asp:Content>

