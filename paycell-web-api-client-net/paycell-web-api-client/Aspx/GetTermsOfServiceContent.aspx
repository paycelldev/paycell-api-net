<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetTermsOfServiceContent.aspx.cs" Inherits="paycell_web_api_client.Aspx.GetTermsOfServiceContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Terms Of Service Content</title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
        a.boldborder {padding-bottom: 15px; font-weight: bold; }
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
            <a class="border" href="ASPX/GetTermsOfServiceContent.aspx">:  Get Terms Of Service Content  :</a>
        </div>
    </div>

    <form id="form" runat="server">
        <div>
            <div>
                <table>
                    <tr>
                        <td><asp:Button ID="TermsOfServiceButton" runat="server" OnClick="TermsOfServiceButton_Click" Text="Sözleşme Metni Getir" /></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="TRButton" runat="server" OnClick="TRButton_Click" Text="TR" />
                            <asp:Button ID="ENButton" runat="server" OnClick="ENButton_Click" Text="EN" />
                        </td></tr>
                </table>
            </div>

            <asp:Literal ID="TermsOfTr" runat="server" Visible="true"></asp:Literal>
            
            <asp:Literal ID="TermsOfEn" runat="server" Visible="false"></asp:Literal>
        </div>
    </form>
</body>
</html>
