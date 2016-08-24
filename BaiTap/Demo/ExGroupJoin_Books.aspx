<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExGroupJoin_Books.aspx.cs" Inherits="BaiTap.Demo.ExGroupJoin_Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
            <br />
            <asp:Button ID="btnViDu1" runat="server" OnClick="btnViDu1_Click" Text="1-GroupJoin (Thống kê)" />
            <asp:Button ID="btnViDu2" runat="server"  Text="2-GroupJoin" OnClick="btnViDu2_Click" />
             <asp:Button ID="btnViDu3" runat="server"  Text="3-GroupJoin" OnClick="btnViDu3_Click" />
             <asp:Button ID="btnViDu4" runat="server" Text="4-GroupJoin &amp; SelectMany (Liệt kê)" OnClick="btnViDu4_Click" />
        <asp:Button ID="btnViDu5" runat="server" Text="GroupJoin &amp; DefaultIfEmpty (Liệt kê)" OnClick="btnViDu5_Click"  />

          <br />
        </p>
    <div>
    
        <asp:GridView ID="gvwKetQua" runat="server">
        </asp:GridView>
        <asp:Literal ID="LiteralKetQua" runat="server"></asp:Literal>
       

    </div>
    </form>
</body>
</html>
