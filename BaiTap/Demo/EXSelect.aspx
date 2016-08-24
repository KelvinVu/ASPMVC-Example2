<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EXSelect.aspx.cs" Inherits="BaiTap.Demo.EXSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnVd1" Text="convert data type" runat="server" OnClick="btnVd1_Click" />
        <asp:Button ID="btnVd2" Text="Conver data type 2" runat="server" OnClick="btnVd2_Click" />
        <asp:GridView ID="grv2" runat="server" CssClass="table table-bordered table-hover">
            <HeaderStyle CssClass="info"/>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
