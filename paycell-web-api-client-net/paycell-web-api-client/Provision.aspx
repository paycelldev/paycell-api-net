<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Provision.aspx.cs" Inherits="paycell_web_api_client.App_Code.Provision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Provision</title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
    </style>
</head>
<body style="height: 477px">

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

    <form id="provision" runat="server">
        
        <div>
            <table border="1">
                <tr>
                    <td>Chosen Msisdn : </td>
                    <td><asp:TextBox ID="selectedMsisdn" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Chosen CardId : </td>
                    <td><asp:TextBox ID="selectedCardId" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
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
                    <td>AcquirerBankCode : </td>
                    <td><asp:TextBox ID="acquirerBankCodeIn" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Currency : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="currencyIn" Width="200px">
                            <asp:ListItem Text="TRY" Value="TRY" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="EUR" Value="EUR"></asp:ListItem>
                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Installment Count : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="installmentCountIn" Width="200px">
                            <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Payment Type : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="paymentTypeIn" Width="200px">
                            <asp:ListItem Text="SALE" Value="SALE" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="PREAUTH" Value="PREAUTH"></asp:ListItem>
                            <asp:ListItem Text="POSTAUTH" Value="POSTAUTH"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Amount : </td>
                    <td><asp:TextBox ID="Amount" runat="server" Width="200px">253</asp:TextBox></td>
                </tr>
                <tr>
                    <td>Pin : </td>
                    <td><asp:TextBox ID="pin" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Point Amount : </td>
                    <td><asp:TextBox ID="pointAmount" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Add Extra Parameter : </td>
                    <td>
                        <table>
                            <tr>
                                <td>Key : </td>
                                <td><asp:TextBox ID="extraParameterKey" runat="server" Width="142px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Value : </td>
                                <td><asp:TextBox ID="extraParameterValue" runat="server" Width="141px"></asp:TextBox></td>
                            </tr>
                            <asp:Button ID="AddExtraParameter" runat="server" OnClick="AddExtraParameter_Click" Text="Add" />
                        </table>

                    </td>
                </tr>

            </table>

            <asp:Button ID="ProvisionButton" runat="server" OnClick="GetProvision_Click" Text="Provision" />

        </div>


        <br />
        <br />
        <br />


        <table border="1">
            <tr>
            <td>Referance Number : </td>
            <td><asp:Label ID="referanceNumber" runat="server" Width="200px"></asp:Label></td>
            </tr>
            <tr>
            <td>AcquirerBankCode : </td>
            <td><asp:Label ID="AcquirerBankCode" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td>ApprovalCode : </td>
            <td><asp:Label ID="ApprovalCode" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td>OrderId :</td>
            <td><asp:Label ID="OrderId" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td>ReconciliationDate : </td>
            <td><asp:Label ID="ReconciliationDate" runat="server"></asp:Label></td>
            </tr>
        </table>

    </form>

</body>
</html>
