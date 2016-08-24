<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExLazyLoading.aspx.cs" Inherits="BaiTap.Demo.ExLazyLoading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnViDu1" runat="server" OnClick="btnViDu1_Click" Text="Ví dụ 1" />
        &nbsp;<asp:Button ID="btnViDu2" runat="server" OnClick="btnViDu2_Click" Text="Ví dụ 2" />
        &nbsp;<asp:Button ID="btnViDu3" runat="server" OnClick="btnViDu3_Click" Text="Ví dụ 3" />
        &nbsp;<asp:Button ID="btnViDu4" runat="server" OnClick="btnViDu4_Click" Text="Ví dụ 3" />
        <br />
        <br />
        <asp:GridView ID="gvwKetQua" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
