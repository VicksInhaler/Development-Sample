<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inksys.master" AutoEventWireup="true" CodeFile="IBPP_BottleAssy.aspx.cs" Inherits="Views_IBPP_BottleAssy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--STYLES-->
    <link href="../resources/custom/ibpp-curing/css/ibpp-incoming-for-curing.css" rel="stylesheet" />
    <style>
        .label {
            font-size: 12px;
        }
    </style>
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
                        <h5>BOTTLE ASSY & LOT LABEL PRINTING</h5>
                    </div>
                    <!-- MAIN CONTENT -->
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>
                                 <div class="form-row">
                                      <div class="col">
                                              <asp:Label CssClass="label" Text="CURING LINE" runat="server"  /><span class="required">*</span>
                                           <div class="input-group">
                                            <asp:DropDownList ID="ddlCuringLine" CssClass="form-control" runat="server">
                                            </asp:DropDownList> 
                                        </div>
                                     </div>
                                    
                                    
                                   </div>
                                    <!--MODEL CONTENT -->
                                    <div class="form-row">
                                        <div class="col">
                                           <asp:TextBox runat="server" ID="txtID" hidden="true"/>
                                            <asp:Label CssClass="label" Text="QR Unboxed Code" runat="server" /><span class="required">*</span>
                                            <div class="input-group">
                                                   <asp:TextBox ID="txtModelQR" CssClass="form-control text-uppercase" OnTextChanged="txtModelQR_TextChanged" runat="server" />
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <asp:CheckBox ID="chkModelQR" CssClass="checkbox" OnCheckedChanged="chkModelQR_CheckedChanged" AutoPostBack="true"  runat="server" />
                                                    </span>
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="Part Code" runat="server" /><span class="required">*</span>
                                             <asp:TextBox ID="txtModelCode" CssClass="form-control" OnTextChanged="txtModelCode_TextChanged" runat="server" />
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="Model" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtType" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="Destination" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtDestination" CssClass="form-control" runat="server" />
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="Color" runat="server" /><span class="required">*</span>
                                                <asp:TextBox ID="txtColor" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <!--END MODEL CONTENT -->
                            
                                    <!--SHRINK FILM CONTENT -->
                                    <div class="form-row">
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="SF PartCode" runat="server" /><span class="required">*</span> </label>
                                            <asp:TextBox ID="txtSFPartCode" CssClass="form-control" runat="server" OnTextChanged="txtSFPartCode_TextChanged" />
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="SF Lot No." runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtSFLotNo" CssClass="form-control" runat="server" OnTextChanged="txtSFLotNo_TextChanged"/>
                                        </div>
                                        <div class="col">
                                            <asp:Label CssClass="label" Text="SF PartName" runat="server" /><span class="required">*</span>
                                            <asp:TextBox ID="txtSFPartName" CssClass="form-control" runat="server" />
                                        </div>  
                                    
                                    </div>
                                    <!--END SHRINK FILM CONTENT -->
                                </div>
                                <div class="form-row">
                                    <div class="col">
                                        <asp:Label CssClass="label" Text="QR Code" runat="server" /><span class="required">*</span>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtQRBottle" CssClass="form-control" runat="server" OnTextChanged="txtQRBottle_TextChanged" />
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <asp:CheckBox ID="chkBottle" CssClass="checkbox" runat="server"  />
                                                </span>
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <asp:Label CssClass="label" Text="Bottle PartCode" runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtBottlePartCode" CssClass="form-control" runat="server" OnTextChanged="txtBottlePartCode_TextChanged" />
                                    </div>
                                    <div class="col">
                                        <asp:Label CssClass="label" Text="Bottle Lot No." runat="server" /><span class="required">*</span>
                                        <asp:TextBox ID="txtBottleLotNo" CssClass="form-control" runat="server" OnTextChanged="txtBottleLotNo_TextChanged" />
                                    </div>
                                     <div class="col">
                                     <asp:Label CssClass="label" Text="AMOUNT" runat="server" /><span class="required">*</span>
                                      
                                        <div class="input-group mb-3">
                                         <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" />
                                          
                                            <div class="input-group-append">
                                                  <asp:Button ID="btnAdd" CssClass="add btn-dark" Text="ADD"  OnClick="btnAdd_Click" UseSubmitBehavior="false" runat="server" />
                                                  <asp:Button ID="btnHide2" hidden="true" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                 
                                    <div class="col">
                                       <asp:Label CssClass="label" Text="CAVITY NO" Style="margin-left: 15px;" runat="server" /><spa n class="required">*</spa>
                                        <asp:Label CssClass="label" Text="LINE" Style="margin-left: 15px;" runat="server" /><span class="required">*</span>
                                        <div class="input-group">
                                              <asp:TextBox ID="txtCavityNo" CssClass="form-control" runat="server" />
                                            <asp:DropDownList ID="ddlLineStockArea" CssClass="form-control" runat="server">
                                            </asp:DropDownList> 
                                            
                                        </div>
                                    </div>
                                </div>   
                                
                                <div class="card-body">
                                    <asp:GridView ID="grvBottleAssyList" CssClass="table-bordered" Width="100%" AutoGenerateColumns="false"
                                            HeaderStyle-BackColor="Yellow" HeaderStyle-Width="100%" RowStyle-BackColor="#95afc0" runat="server">
                                            <Columns>
                                                <%--<asp:BoundField DataField="ID" HeaderText="ID" />--%>
                                               <%-- <asp:BoundField DataField="BOTTLEASSYLOTID" Visible="false" HeaderText="ID" />--%>
                                                <asp:BoundField DataField="BOTTLELOTNO" HeaderText="Bottle Lot No." />
                                                <asp:BoundField DataField="SFLOTNO" HeaderText="Shrink Film Lot No." />
                                                <asp:BoundField DataField="AMOUNT" HeaderText="Amount" ItemStyle-Width="120" />
                                            </Columns>
                                        </asp:GridView>
                                </div>
                                <!--BUTTONS-->
                                <div class="card-footer">
                                    <div class="row">
                                           <div class="col-md-6">
                                               <asp:Button ID="btnHide" hidden="true" runat="server" />
                                         <asp:Button ID="btnChangeModel" Text="Change Model" CssClass="btn btn-primary" OnClick="btnChangeModel_Click" runat="server" />
                                                  <asp:Button ID="btnPrintBottleAssy" Text="PRINT Model" CssClass="btn btn-primary" OnClick="btnPrintBottleAssy_Click" runat="server" />
                                    </div>
                                    <div class="col-md-6">
                                          <asp:Button ID="btnSave" CssClass="btn btn-success" Text="Save" runat="server" OnClick="btnSave_Click" UseSubmitBehavior="False" />
                                    </div>                                 
                                    </div>                                 
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                  <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="divider">
                        </div>
                       <div class="row">
                            <div class="col-md-12">
                                <table class="bottleassy-table table table-bordered text-nowrap" style="width: 100%; border: 1px solid #000;"></table>
                            </div>
                        </div>
                        <!-- END TABLE-->
                    </div>
                </div>
       </div>
            <!-- END MAIN CONTENT -->
        </div>
        <%--<div class="modal fade" id="ModalEdit">
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
</div>--%>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="Server">
    <script src="../resources/plugins/sweetalert2-manual/dist/sweetalert2.all.min.js"></script>
    <script src="../resources/custom/ibpp-bottleassy/js/ibpp-bottleassy.js"></script>
    <script src="../resources/custom/notifications/notification.js"></script>
</asp:Content>

