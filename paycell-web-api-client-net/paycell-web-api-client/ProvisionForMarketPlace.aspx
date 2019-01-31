<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProvisionForMarketPlace.aspx.cs" Inherits="paycell_web_api_client.App_Code.ProvisionForMarketPlace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Provision For Marketplace</title>
    <style type="text/css">
        .auto-style1 {
            width: 333px;
        }
        .auto-style2 {
            width: 83px;
        }
        .auto-style3 {
            width: 138px;
        }
        .auto-style4 {
            width: 229px;
        }

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

    <form id="form" runat="server">

        <div>
            <table border="1">
                <tr>
                    <td class="auto-style3">MSISDN : </td>
                    <td class="auto-style4"><asp:TextBox ID="selectedMsisdn" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">CardId : </td>
                    <td class="auto-style4"><asp:TextBox ID="selectedCardId" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">CardToken : </td>
                    <td class="auto-style4"><asp:TextBox ID="selectedCardToken" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">ThreeDSessionId : </td>
                    <td class="auto-style4"><asp:TextBox ID="threeDSessionId" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>AcquirerBankCode : </td>
                    <td><asp:TextBox ID="acquirerBankCodeIn" runat="server" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Currency : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="currencyIn" Width="333px" Height="16px">
                            <asp:ListItem Text="TRY" Value="TRY" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="EUR" Value="EUR"></asp:ListItem>
                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Installment Count : </td>
                    <td>
                        <asp:DropDownList runat="server" ID="installmentCountIn" Width="333px">
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
                        <asp:DropDownList runat="server" ID="paymentTypeIn" Width="333px">
                            <asp:ListItem Text="SALE" Value="SALE" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="PREAUTH" Value="PREAUTH"></asp:ListItem>
                            <asp:ListItem Text="POSTAUTH" Value="POSTAUTH"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Amount : </td>
                    <td><asp:TextBox ID="Amount" runat="server" Width="333px">253</asp:TextBox></td>
                </tr>
                <tr>
                    <td>Pin : </td>
                    <td><asp:TextBox ID="pin" runat="server" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Point Amount : </td>
                    <td><asp:TextBox ID="pointAmount" runat="server" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Add Extra Parameter : </td>
                    <td>
                        <table>
                            <tr>
                                <td>Key : </td>
                                <td><asp:TextBox ID="extraParameterKey" runat="server" Width="272px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Value : </td>
                                <td><asp:TextBox ID="extraParameterValue" runat="server" Width="272px"></asp:TextBox></td>
                            </tr>
                            <asp:Button ID="AddExtraParameter" runat="server" OnClick="AddExtraParameter_Click" Text="Add" />
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>Add SubMerchant : </td>
                    <td>
                        <table>
                            <tr>
                                <td>Key : </td>
                                <td><asp:TextBox ID="subMerchantKey" runat="server" Width="272px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Value : </td>
                                <td><asp:TextBox ID="subMerchantPrice" runat="server" Width="272px"></asp:TextBox></td>
                            </tr>
                            <asp:Button ID="AddSubMerchant" runat="server" OnClick="AddSubMerchant_Click" Text="Add" />
                        </table>

                    </td>
                </tr>
                <tr>
                    <td>Add Customer Email : </td>
                    <td><asp:TextBox ID="customerEmail" runat="server" Width="333px"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="GetProvision" runat="server" OnClick="GetProvision_Click" Text="Provision" />
        </div>
        


        <br />
        <br />
        <br />


        <div>
            <table border="1">
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label5" runat="server" Text="referenceNumber"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="referenceNumber" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label1" runat="server" Text="acquirerBankCode"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="acquirerBankCode" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label3" runat="server" Text="approvalCode"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="approvalCode" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="orderId"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="orderId" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2"><asp:Label ID="Label4" runat="server" Text="reconciliationDate"></asp:Label></td>
                    <td class="auto-style1"><asp:TextBox ID="reconciliationDate" runat="server" Enabled="false" Width="333px"></asp:TextBox></td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
