<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetCardsList.aspx.cs" Inherits="paycell_web_api_client.GetCardsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Card List</title>
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
        </div>
    </div>

    <form id="form1" runat="server">

        <div class="double">
        <div>
            
            <div><a class="boldborder">Registered Cards</a></div>
            
            <br />

            <div>
                <table>
                    <tr>
                        <td>Msisdn : </td>
                        <td><asp:TextBox ID="Msisdn" runat="server">905465553333</asp:TextBox></td>
                        <td><asp:Button ID="SearchButton" runat="server" OnClick="SearchButtonOnClick" Text="Get Cards" /></td>
                    </tr>
                </table>
            </div>
            
        </div>

        <br />

        <div>

            <div>
                <asp:GridView ID="GetCardsGridView" runat="server" AutoGenerateColumns="false" OnRowEditing="GetCardsGridView_RowEditing"
                autogenerateselectbutton="True" onselectedindexchanging="GetCardsGridView_SelectedIndexChanging" DataKeyNames="CardId"
                OnRowCancelingEdit="GetCardsGridView_RowCancelingEdit" OnRowDeleting="GetCardsGridView_RowDeleting" OnRowUpdating="GetCardsGridView_RowUpdating">
                
                <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="true"/> 
                
                    <Columns>
                        <asp:BoundField DataField="CardId" HeaderText="CardId" ItemStyle-Width="200" ReadOnly="True" />
                        <asp:BoundField DataField="CardBrand" HeaderText="CardBrand" ItemStyle-Width="150" ReadOnly="True" />
                        <asp:BoundField DataField="MaskedCardNo" HeaderText="MaskedCardNo" ItemStyle-Width="150" ReadOnly="True" />

                        <asp:TemplateField HeaderText="Alias" SortExpression="Alias">
                            <ItemTemplate>
                                <asp:Label ID="Alias" runat="server" Text='<%# Bind("Alias") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="AliasT" runat="server" Text='<%# Bind("Alias") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="IsDefault" SortExpression="IsDefault">
                            <ItemTemplate>
                                <asp:Label ID="IsDefault" runat="server" Text='<%# Bind("IsDefault") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="IsDefaultT" runat="server" Text='<%# Bind("IsDefault") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="IsExpired" HeaderText="IsExpired" ItemStyle-Width="150" ReadOnly="True" />
                        <asp:BoundField DataField="ShowEulaId" HeaderText="ShowEulaId" ItemStyle-Width="150" ReadOnly="True" />
                        <asp:BoundField DataField="IsThreeDValidated" HeaderText="IsThreeDValidated" ItemStyle-Width="150" ReadOnly="True" />
                        <asp:BoundField DataField="IsOTPValidated" HeaderText="IsOTPValidated" ItemStyle-Width="150" ReadOnly="True" />
                        <asp:BoundField DataField="ActivationDate" HeaderText="ActivationDate" ItemStyle-Width="150" ReadOnly="True" />
                    
                        <asp:CommandField DeleteText="Delete" EditText="Edit" ShowCancelButton="True" ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>

        <br />

        <div class="double">

            <div><a class="boldborder">Select Another Card</a></div>

            <br />

            <div>
                <table>
                    <tr>
                        <td>creditCardNo : </td>
                        <td><asp:TextBox ID="creditCardNo" runat="server">5254135922971748</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>expireDateMonth : </td>
                        <td><asp:TextBox ID="expireDateMonth" runat="server">12</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>expireDateYear : </td>
                        <td><asp:TextBox ID="expireDateYear" runat="server">20</asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>cvcNo : </td>
                        <td><asp:TextBox ID="cvcNo" runat="server">000</asp:TextBox></td>
                        <td><a href="#" runat="server" onServerClick="SelectUnRegisterCard_Click">Select</a></td>
                    </tr>
                </table>
            </div>

        </div>

        <br />

        <div class="double">

            <div><a class="boldborder">Selected Card Details</a></div>

            <br />

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
                        <td>Chosen ThreeDSessionId : </td>
                        <td><asp:TextBox ID="selectedThreeDSessionId" runat="server" Enabled="false"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>

        <br />

        <div class="double">

            <div><a class="boldborder">Get ThreeDSessionId</a></div>

            <br />

            <div>
                <table>
                    <tr>
                        <td><asp:Button ID="ThreeDSecureButton" runat="server" OnClick="GetThreeDSessionIdButton_Click" Text="3D SessionId Al" /></td>
                        <td><asp:TextBox ID="ThreeDSecureId" runat="server" Enabled="false"></asp:TextBox></td>
                        <td><asp:Button ID="ThreeDSecureResultButton" runat="server" OnClick="ThreeDSecureResultButton_Click" Text="3D Session Dogrulama" /></td>
                        <td><asp:Button ID="TestThreeDSessionId" runat="server" OnClick="TestThreeDSessionId_Click" Text="3D Session Id Result Test" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
