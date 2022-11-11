<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IBPP_BottleAssy_PrintAll.aspx.cs" Inherits="Views_IBPP_BottleAssy_PrintAll" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </div>
                <asp:GridView ID="grvBottleAssy" Width="100%" AutoGenerateColumns="false"
        HeaderStyle-BackColor="Yellow" HeaderStyle-Width="100%" RowStyle-BackColor="#95afc0" runat="server">
        <Columns>

            <asp:BoundField DataField="PRODUCTCODE" HeaderText="Code" />
            <asp:BoundField DataField="BOTTLEASSYLOTNO" HeaderText="Bottle Assy Lot No." />
            <asp:BoundField DataField="BOTTLELOTNO" HeaderText="Bottle Lot No." />
            <asp:BoundField DataField="SFLOTNO" HeaderText="Shrink Film Lot No." />
            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
            <asp:BoundField DataField="BOXNO" HeaderText="Box No." />
             <asp:BoundField DataField="CAVITYNO" HeaderText="Cavity No." />      
            <asp:BoundField DataField="MODEL" HeaderText="Model" />
            <asp:BoundField DataField="DESTINATION" HeaderText="Destination" />
            <asp:BoundField DataField="COLOR" HeaderText="Color" />
            <asp:BoundField DataField="LINE" HeaderText="Stock Line" />
            <asp:BoundField DataField="INCHARGE" HeaderText="In Charge" />
        </Columns>
    </asp:GridView>
   
    </form>
</body>
</html>
