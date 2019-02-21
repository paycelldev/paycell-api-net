<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryReconciliation.aspx.cs" Inherits="paycell_web_api_client.Aspx.SummaryReconciliation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Summary Reconciliation</title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
        th.wid {width:300px;}
        th.wid1 {width:50px;}
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

    <form id="summaryReconciliationForm" runat="server">

        <div>
            <table border="1">
            <tr>
                <th class="wid">Merchant Information</th>
                <th class="wid1"></th>
                <th class="wid">System Information</th>
                <th class="wid1"></th>
            </tr>
            <tr>
                <td><asp:Label runat="server">Reconciliation Date:  </asp:Label></td>
                <td><asp:TextBox ID="reconciliationDateIn" runat="server">20160404</asp:TextBox></td>

                <td><asp:Label runat="server">Reconciliation Result:  </asp:Label></td>
                <td><asp:TextBox ID="reconciliationResult" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Sale Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleAmountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Sale Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Sale Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleCountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Sale Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalSaleCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Reverse Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseAmountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Reverse Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Reverse Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseCountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Reverse Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalReverseCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Refund Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundAmountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Refund Amount:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server">Total Refund Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundCountIn" runat="server">0</asp:TextBox></td>

                <td><asp:Label runat="server">Response Total Refund Count:  </asp:Label></td>
                <td><asp:TextBox ID="totalRefundCountRes" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>
        </table>
        </div>
        <div>
            <table border="1">
                <tr>
                    <th class="wid"></th>
                    <th class="wid1"></th>
                    <th class="wid"></th>
                    <th class="wid1"></th>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Post Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthAmountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Post Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Post Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthCountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Post Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthCountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Post Auth Reverse Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthReverseAmountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Total Post Auth Reverse Amount Res:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthReverseAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Post Auth Reverse Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthReverseCountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Total Post Auth Reverse Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPostAuthReverseCountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Pre Auth Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthAmountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Pre Auth Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Pre Auth Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthCountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Pre Auth Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthCountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Pre Auth Reverse Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthReverseAmountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Pre Auth Reverse Amount:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthReverseAmountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server">Total Pre Auth Reverse Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthReverseCountIn" runat="server"></asp:TextBox></td>

                    <td><asp:Label runat="server">Response Total Pre Auth Count:  </asp:Label></td>
                    <td><asp:TextBox ID="totalPreAuthReverseCountRes" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>
        </div>

        <div>
            <asp:Button ID="Submit" runat="server" Text="Summary Reconciliation" OnClick="Submit_Click"/>
        </div>

    </form>
</body>
</html>
