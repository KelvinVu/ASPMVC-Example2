<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExSelectMany.aspx.cs" Inherits="Baitap.Demo.ExSelectMany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnViDu1" runat="server" OnClick="btnViDu1_Click" Text="Ví dụ 1" />
        <asp:Button ID="btnViDu2" runat="server" OnClick="btnViDu2_Click" Text="Ví dụ 2" />
        <asp:Button ID="btnViDu3" runat="server" OnClick="btnViDu3_Click" Text="Ví dụ 3" />
        <asp:Button ID="btnViDu4" runat="server" OnClick="btnViDu4_Click" Text="Ví dụ 4" />
        <asp:Button ID="btnViDu5" runat="server" OnClick="btnViDu5_Click" Text="Ví dụ 5" />
        <asp:Button ID="btnViDu6" runat="server" OnClick="btnViDu6_Click" Text="Ví dụ 6" />
        <asp:Button ID="btnViDu7" runat="server" OnClick="btnViDu7_Click" Text="Ví dụ 7" />
       <asp:GridView ID="gvwKetQua" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
