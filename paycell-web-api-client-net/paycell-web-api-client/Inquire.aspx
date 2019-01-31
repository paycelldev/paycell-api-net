<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inquire.aspx.cs" Inherits="paycell_web_api_client.Inquire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inquire</title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
    </style>
</head>
<body style="height: 589px">

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

    <form id="inquireForm" runat="server">
        <div>

            <table>
                <tr>
                    <td>Chosen Msisdn : </td>
                    <td><asp:TextBox ID="selectedMsisdn" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Chosen CardId : </td>
                    <td><asp:TextBox ID="selectedCardId" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Chosen CardToken : </td>
                    <td><asp:TextBox ID="selectedCardToken" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>threeDSessionId : </td>
                    <td><asp:TextBox ID="threeDSessionId" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>originalReferenceNumber : </td>
                    <td><asp:TextBox ID="originalReferenceNumber" runat="server"></asp:TextBox></td>
                </tr>
            </table>

            <asp:Button ID="inquire" runat="server" OnClick="Inquire_Click" Text="Inquire" />

        </div>


        <br />
        <br />
        <br />

        <div>
            <table border="1" >
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="acquirerBankCode"></asp:Label></td>
                    <td><asp:TextBox ID="acquirerBankCode" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="approvalCode"></asp:Label></td>
                    <td><asp:TextBox ID="approvalCode" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="orderId"></asp:Label></td>
                    <td><asp:TextBox ID="orderId" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="status"></asp:Label></td>
                    <td><asp:TextBox ID="status" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>
        </div>

        <br />

        <div>
            <asp:GridView ID="ProvisionsGridView" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="approvalCode" HeaderText="approvalCode" ItemStyle-Width="200" ReadOnly="True" />
                    <asp:BoundField DataField="transactionId" HeaderText="transactionId" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="amount" HeaderText="amount" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="dateTime" HeaderText="dateTime" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="provisionType" HeaderText="provisionType" ItemStyle-Width="150" ReadOnly="True" />
                    <asp:BoundField DataField="reconciliationDate" HeaderText="reconciliationDate" ItemStyle-Width="150" ReadOnly="True" />
                  </Columns>
            </asp:GridView>

        </div>

        <br />

        <div>
            <asp:Button ID="ReverseButton" runat="server" Text="Reverse" Visible="false" OnClick="ReverseButton_Click" Width="105px" />
        </div>

        <br />

        <div>
            <asp:Panel ID="RefundLabel" runat="server" Visible="false">            
                <asp:TextBox ID="amount" runat="server"></asp:TextBox>
                <asp:Button ID="RefundButton" runat="server" Text="Refund" OnClick="RefundButton_Click" Width="105px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
