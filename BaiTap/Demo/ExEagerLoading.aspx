<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExEagerLoading.aspx.cs" Inherits="BaiTap.Demo.ExEagerLoading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="1" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="2" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="3" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="4" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="5" />
        <asp:Label ID="lbKetQua" runat="server" />
        <asp:Literal ID="literalKetQua" runat="server" />
        <br />
    
    </div>
    </form>
</body>
</html>
