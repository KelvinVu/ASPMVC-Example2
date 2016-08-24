<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EXUseStoreProcedure.aspx.cs" Inherits="BaiTap.Demo.EXUseStoreProcedure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn1" Text="xem" runat="server" OnClick="btn1_Click" />
        <asp:Button ID="btn2" Text="xóa" runat="server" OnClick="btn2_Click" />
        <asp:GridView ID="grv1" runat="server">

        </asp:GridView>
    </div>
    </form>
</body>
</html>
