<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryReconciliation.aspx.cs" Inherits="paycell_web_api_client.SummaryReconciliation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Summary Reconciliation</title>
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
        </div>
    </div>

    <form id="summaryReconciliationForm" runat="server">
        <div>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"/>
        </div>

        <div>

            <table border="1">
            <tr>
                <td><asp:Label runat="server">Reconciliation Date:  </asp:Label></td>
                <td><asp:TextBox ID="reconciliationDate" runat="server">20160404</asp:TextBox></td>

                <td><asp:Label runat="server">Reconciliation Result:  </asp:Label></td>
                <td><asp:TextBox ID="reconciliationResult" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Sale Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleAmount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Sale Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Sale Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleCount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Sale Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Reverse Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseAmount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Reverse Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Reverse Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseCount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Reverse Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Refund Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundAmount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Refund Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Refund Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundCount" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Refund Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
