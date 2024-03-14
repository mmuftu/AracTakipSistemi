<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AracTakipSistemi._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= Resources.Strings.LoginPageTitle %></title>
    <link rel="stylesheet" type="text/css" href="css/LoginStyle.css"/>
</head>
<body>
 
    
    <form id="form1" runat="server" class="container">
        <div> <asp:Image ID="Image1" runat="server" ImageUrl="~/img/mobit_logo.png" ImageAlign="Middle"/></div>
        <div class="label_baslik"><asp:Label ID="Label_baslik" runat="server" Text="<%$ Resources:Strings,LoginPageTitle %>"></asp:Label></div>
   
        <div class="form-group">
            <asp:DropDownList ID="ddlLanguage"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
               <asp:ListItem Text="Türkçe" Value="tr" />
                <asp:ListItem Text="English" Value="en" />
                
            </asp:DropDownList>
            </div>
        <div class="form-group">
            <asp:Label ID="lblUsername" runat="server" Text="<%$ Resources:Strings,Username %>"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="<%$ Resources:Strings,Password %>"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:CheckBox ID="chkRememberMe" runat="server" Text="<%$ Resources:Strings,RememberMe %>"></asp:CheckBox>
        </div>
   
            <asp:Button ID="btnLogin"   class="form-button" runat="server" Text="<%$ Resources:Strings,Login %>" OnClick="btnLogin_Click" />
    <br /><br />
      <asp:Label ID="Label_mesaj" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>

