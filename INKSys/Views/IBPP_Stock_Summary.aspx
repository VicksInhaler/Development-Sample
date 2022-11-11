<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inksys.master" AutoEventWireup="true" CodeFile="IBPP_Stock_Summary.aspx.cs" Inherits="Views_IBPP_Stock_Summary" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
    .increase-size {
            font-size: 1rem;
        }
    .card card cap{
        background-color:black;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <section class="content-header">
<div class="container-fluid">
<div class="row mb-2">
    <div class="col-sm-6">
        <h1>Stock Monitoring</h1>
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
<section class="content">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                  <!-- START CAP CHART -->
                <div class="card card-primary">
                    <div class="card-header" style="background-color:cyan;color:black">
                        <h3 class="card-title">CAP IBPP Stocks</h3>
                    </div>
                    <asp:UpdatePanel ID="CapPanel" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="CapChart" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="CapAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label1" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Labe2" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label2" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label3" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                     <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                       
                    </asp:UpdatePanel>                
                </div>
                  <!--  END CAP CHART -->
                <!-- Spout CHART -->
                <div class="card card-danger">
                    <div class="card-header"  style="background-color:magenta">
                        <h3 class="card-title">Spout IBPP Stocks</h3>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="SpoutChart" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="SpoutAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label4" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label5" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label6" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label7" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <!-- /.card -->

                <!-- Slit-Valve CHART -->
                <div class="card card-warning">
                    <div class="card-header">
                        <h3 class="card-title">Slit Valve IBPP Stocks</h3> 
                    </div>
                    <asp:UpdatePanel ID="SlitValvePanel" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="SlitValveChart" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="SlitValveAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label8" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label9" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label10" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label11" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                           <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <!-- /.card -->
                   <!-- Bottle Assy CHART -->
                <div class="card card-danger">
                     <div class="card-header" style="background-color:black">
                        <h3 class="card-title">Bottle Assy IBPP Stocks</h3> 
                    </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="BottleAssyChart" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="BottleAssyAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label12" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label13" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label14" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label15" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <!-- /.card -->
                 <asp:Timer ID="UpdateChartTimer" runat="server" Interval="150000" OnTick="UpdateChartTimer_Tick">
        </asp:Timer>
            </div>
            <!-- /.col (LEFT) -->
            <div class="col-md-6">
                <!-- CapArea -->
                <div class="card card-primary">
                    <div class="card-header"  style="background-color:cyan; color:black">
                        <h3 class="card-title">Inbound Cap IPS Area</h3>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="Cap" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="BottleAssyAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label20" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label21" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label22" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label23" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
                 <!-- LINE CHART -->
                <div class="card card-primary">
                    <div class="card-header"  style="background-color:magenta">
                        <h3 class="card-title">Inbound Spout IPS Area</h3>
                    </div>
                   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="Chart3" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="BottleAssyAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label24" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label25" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label26" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label27" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->

                <!-- BAR CHART -->
                <div class="card card-warning">
                    <div class="card-header">
                        <h3 class="card-title">Inbound Slit-Valve IPS Area</h3>

                    </div>
                   <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="Chart4" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="BottleAssyAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label28" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label29" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label30" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label31" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->

                <!-- STACKED BAR CHART -->
                <div class="card card-success">
                    <div class="card-header"  style="background-color:black">
                        <h3 class="card-title">Inbound Bottle Assy IPS Area</h3>
                    </div>
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                      <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Chart ID="Chart1" runat="server" CssClass="table table-bordered table-condensed table-responsive chart">
                                    <Series>
                                        <asp:Series Name="Series"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="BottleAssyAreaChart"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                            <div></div>
                         <div class="col-md-6">
                             <div class="card-body" style="text-align:right;">
                                 <div class="form-group">
                                    <a href="#"><b>IBPP Stock Area:</b></a>
                                     <asp:Label ID="Label16" Text="1,000,000" runat="server" />
                                 </div>
                                   <div class="form-group">
                                      <a href="#"><b>Rework Stock Area:</b></a>
                                      <asp:Label ID="Label17" Text="1,000,000" runat="server" />
                                   </div>
                                  <div class="form-group">
                                       <a href="#"><b>Return Stock Area:</b></a>
                                      <asp:Label ID="Label18" Text="1,000,000" runat="server" />
                                   </div>
                                   <div class="form-group">
                                        <b>Total Available Stocks:</b><asp:Label ID="Label19" Text="3,000,000" CssClass="right badge badge-danger increase-size" runat="server" />
                                   </div>                               
                             </div>
                         </div>
                        </div>
                    </div>
                        </ContentTemplate>
                               <Triggers>
                <asp:AsyncPostBackTrigger ControlID="UpdateChartTimer" EventName="Tick" />
            </Triggers>
                    </asp:UpdatePanel>  
                </div>
                <!-- /.card -->

            </div>
            <!-- /.col (RIGHT) -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>

<div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

