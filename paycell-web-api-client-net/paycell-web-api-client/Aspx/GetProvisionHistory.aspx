<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetProvisionHistory.aspx.cs" Inherits="paycell_web_api_client.Aspx.GetProvisionHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Provision History</title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
    </style>
</head>
<body>

    <div class="container">
        <div class="double">
            <a class="border" href="/">:  Home  :</a>
            <a class="border" href="GetCardsList.aspx">:  Get Cards  :</a>
            <a class="border" href="RegisterCard.aspx">:  Register Card  :</a>
            <a class="border" href="Provision.aspx">:  Provision  :</a>
            <a class="border" href="Inquire.aspx">:  Inquire  :</a>
            <a class="border" href="ProvisionForMarketPlace.aspx">:  Provision For MarketPlace  :</a>
            <a class="border" href="SummaryReconciliation.aspx">:  Summary Reconciliation  :</a>
            <a class="border" href="GetProvisionHistory.aspx">:  Provision History  :</a>
            <a class="border" href="GetTermsOfServiceContent.aspx">:  Get Terms Of Service Content  :</a>
        </div>
    </div>

    <form id="form" runat="server">
        <div>
            <table border="1">

                <tr>
                    <td><asp:Label runat="server" Text="Reconciliation Date : "></asp:Label></td>
                    <td><asp:TextBox ID="reconciliationDate" runat="server" >20181121</asp:TextBox></td>
                </tr>
        
            </table>

            <br />

            <asp:Button ID="GetProvisionHistoryButton" runat="server" OnClick="GetProvisionHistory_Click" Text="Get ProvisionHistory" />
        </div>

        <br />

        <div>
            <asp:GridView ID="ProvisionHistoryGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="transactionDateTime" HeaderText="transactionDateTime" ItemStyle-Width="200" ReadOnly="True" />
                    <asp:BoundField DataField="amount" HeaderText="amount" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="netAmount" HeaderText="netAmount" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="approvalCode" HeaderText="approvalCode" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="orderId" HeaderText="orderId" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="transactionId" HeaderText="transactionId" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="referenceNumber" HeaderText="referenceNumber" ItemStyle-Width="150" ReadOnly="True" />
                  </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
