<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCard.aspx.cs" Inherits="paycell_web_api_client.RegisterCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Register Card </title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
    </style>
</head>
<body style="height: 443px">

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

    <form id="registerCardForm" runat="server" class="auto-style5">

        <div>

            <table border="1">
                <tr>
                    <td>Chosen Msisdn : </td>
                    <td><asp:TextBox ID="selectedMsisdn" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Chosen CardToken : </td>
                    <td><asp:TextBox ID="selectedCardToken" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>threeDSessionId : </td>
                    <td><asp:TextBox ID="threeDSessionId" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>alias : </td>
                    <td><asp:TextBox ID="alias" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>isDefault : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="isDefault" Width="200px">
                            <asp:ListItem Text="True" Value="True"></asp:ListItem>
                            <asp:ListItem Text="False" Value="False" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

        </div>
        <div class="auto-style7"><asp:Button ID="registerCardButton" runat="server" Text="Register Card" onclick="RegisterCardButtonOnClick" CausesValidation="true" Width="232px" ValidationGroup="Register"/></div>
    </form>
</body>
</html>
