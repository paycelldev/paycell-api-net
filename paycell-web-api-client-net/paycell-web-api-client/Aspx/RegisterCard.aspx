<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCard.aspx.cs" Inherits="paycell_web_api_client.Aspx.RegisterCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Register Card </title>
    <style>
        div.double {border-style: double; padding: 15px;}
        a.border { border-style: double; padding: 5px; }
    </style>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
      $( function() {
        $( "#dialog" ).dialog();
        $( "#dialog" ).dialog('close');
        });
     </script>

     <script type="text/javascript">
         $(document).ready(function()
         {
             $('#<%= rejectButton.ClientID %>').click(function(e) 
             { 
                $( "#dialog" ).dialog('close');
                 
             });
         });
      </script>

    <script>
        function openDialog() {
             $(document).ready(function()
             {
                $( "#dialog" ).dialog('open').dialog( "option", "width", 1200 );
             });
        }
    </script>
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
            <a class="border" href="GetTermsOfServiceContent.aspx">:  Get Terms Of Service Content  :</a>
        </div>
    </div>

    <form id="registerCardForm" runat="server" class="auto-style5">

        <div id="dialog" title="Sözleşme Metin Onayı" style="height:100px;width200px;">
            <table>
                <tr>
                    <asp:Literal ID="TermsOfTr" runat="server" Visible="true"></asp:Literal>
                </tr>
                <tr>
                    <td><asp:Button ID="registerCardButton" runat="server" Text="Kabul Et" OnClick="RegisterCardButtonOnClick" UseSubmitBehavior="false" data-dismiss="modal"/></td>
                    <td><asp:Button ID="rejectButton" runat="server" Text="Reddet" ClientIDMode="Static" OnClientClick="return false;"/></td>
                </tr>
            </table>
               
        </div>
    
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
        <asp:Button ID="ShowTermsOfService" runat="server" Text="Register Card" OnClick="ShowTermsOfService_Click"/>
    </form>

</body>
</html>
