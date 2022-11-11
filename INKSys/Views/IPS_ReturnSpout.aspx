<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inksys.master" AutoEventWireup="true" CodeFile="IPS_ReturnSpout.aspx.cs" Inherits="Views_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- STYLES -->
    <link href="../resources/custom/ips-return-spout/css/return-spout.css" rel="stylesheet" />
    <!--SWEET ALERT CSS-->
    <link href="../resources/plugins/sweetalert2-manual/dist/animate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="#">Home</a></li>
                        <li class="breadcrumb-item"><a href="#">IPS</a></li>
                        <li class="breadcrumb-item active">Return Spout</li>
                    </ol>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- Main content -->
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-maroon pb-0">
                    <!--TITLE HEADER-->
                    <div class="card-header">
                        <h3 style="font-family: 'Comic Sans MS'">RETURN SPOUT</h3>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <contenttemplate>
                                <!-- FORM START -->
                                <div class="row">
                                    <div class="col-sm-4">
                                        <!-- ID -->
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtID" hidden="true"></asp:TextBox>
                                        <!-- /ID -->
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblReturnLotNo" Font-Bold="true">RETURN LOT NUMBER:</asp:Label>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtReturnLotNo" Style="background-color: gray; color: white; height: 111px; text-align: center;" />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblPartLotNo" Font-Bold="true">PART LOT NUMBER:</asp:Label><span class="required" style="color: red;">*</span>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtPartLotNo" Placeholder="Scan/Input Part Code" onkeypress="return isNumber(event)" />
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblCavityNo" Font-Bold="true">CAVITY NUMBER:</asp:Label><span class="required" style="color: red;">*</span>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCavityNo" />
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblAmount" Font-Bold="true">AMOUNT:</asp:Label><span class="required" style="color: red;">*</span>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtAmount" />
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblBoxNo" Font-Bold="true">BOX NUMBER:</asp:Label><span class="required" style="color: red;">*</span>
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtBoxNo" />
                                        </div>
                                    </div>
                                    <!-- FORM END -->
                                    <div class="divider">
                                        <span></span>
                                    </div>
                                </div>
                                <!-- LEGEND AND BUTTONS -->
                                <div class="row">
                                    <div class="col-md-4 shift">
                                        <label></label>
                                        <div class="form-group row" style="text-align: center;">
                                            <div class="day-shift mr-3">Day Shift</div>
                                            <div class="night-shift">Night Shift</div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                    <!-- BUTTONS -->
                                    <div class="col-md-4 btn-group">
                                        <asp:Button CssClass="button-group btn-success" ID="btnSave" Text="Save" runat="server" />
                                        <asp:Button ID="Button1" runat="server" hidden="true" />
                                    </div>
                                </div>
                                <div class="divider">
                                    <span></span>
                                </div>
                            </contenttemplate>
                        </asp:UpdatePanel>
                        <!--TABLE-->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="return-spout-table table table-bordered text-nowrap" style="width: 100%; border: 1px solid #000;">
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- END TABLE-->
                        <!--PRINT BUTTON-->
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <asp:Button CssClass="button-group btn-warning" ID="btnPrint" Text="PRINT LOT LABEL" runat="server" />
                            </div>
                        </div>
                        <!--PRINT BUTTON END-->
                    </div>
                </div>
                <!-- CARD BODY END -->
            </div>
        </div>

        <!-- UPDATE MODAL -->
        <div class="modal fade" id="ModalEdit">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: deeppink;">
                        <h4 class="modal-title" style="color: white;">Edit Spout Returns<label id="lbl_EditReturnSpout"></label></h4>
                        <button type="button" class="close" style="font-size: xx-large; color: white;" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <input type="hidden" id="txt_ReturnLotNo">
                                    <label>RETURN LOT NUMBER:</label>
                                    <h4>
                                        <label id="lbl_ReturnLotNo"></label>
                                    </h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>AMOUNT:</label>
                                    <input type="text" id="txt_Amount" class="form-control">
                                </div>
                                <div class="form-group">
                                    <label>BOX NUMBER:</label>
                                    <input type="text" id="txt_BoxNo" class="form-control">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>PART LOT NUMBER:</label>
                                    <input type="text" id="txt_PartLotNo" class="form-control">
                                </div>
                                <div class="form-group">
                                    <label>CAVITY NO:</label>
                                    <input type="text" id="txt_CavityNo" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- MODAL BUTTONS -->
                    <div class="row">
                        <div class="col-md-4">
                            <button type="button" class="button-group-modals btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <button type="button" class="button-group-modals btn-primary" id="btnUpdate">Update</button>
                        </div>
                    </div>
                    <!-- MODAL BUTTONS END -->
                </div>
            </div>
        </div>
    </div>
    <!-- MODAL END -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Get Return Spout Data -->
    <script src="../resources/custom/ips-return-spout/js/get-ibpp-returnspout-details.js"></script>
    <!-- Notifications -->
    <script src="../resources/custom/ips-return-spout/js/notification.js"></script>
    <!-- Validations -->
    <script src="../resources/custom/Validations/Validations.js"></script>
    <!--Sweet Alert Manual -->
    <script src="../resources/plugins/sweetalert2-manual/dist/sweetalert2.all.min.js"></script>
</asp:Content>

