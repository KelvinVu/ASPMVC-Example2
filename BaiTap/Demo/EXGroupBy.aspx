<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EXGroupBy.aspx.cs" Inherits="BaiTap.Demo.EXGroupBy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnVd1" runat="server" Text="vd1" OnClick="btnVd1_Click" />
        <asp:Button ID="btnVd2" runat="server" Text="vd2" OnClick="btnVd2_Click" />
        <asp:Button ID="btnVd3" runat="server" Text="vd3" OnClick="btnVd3_Click" />
        <asp:Button ID="btnVd4" runat="server" Text="vd4" OnClick="btnVd4_Click" />
        <asp:Button ID="btnVd5" runat="server" Text="vd5" OnClick="btnVd5_Click" />

        <asp:GridView ID="grv1" runat="server"></asp:GridView>
        <asp:Literal id="ketqua" runat="server" />
    </div>
    </form>
</body>
</html>
