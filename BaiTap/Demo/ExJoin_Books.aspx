<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExJoin_Books.aspx.cs" Inherits="BaiTap.Demo.ExJoin_Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:Button ID="btnViDu1" runat="server" Text="Ví dụ 1" OnClick="btnViDu1_Click" />
        <asp:Button ID="btnViDu2" runat="server" Text="Ví dụ 2" OnClick="btnViDu2_Click" />
        <asp:Button ID="btnViDu3" runat="server" Text="Ví dụ 3" OnClick="btnViDu3_Click" />
        <asp:Button ID="btnViDu4" runat="server" Text="Ví dụ 4" OnClick="btnViDu4_Click" />
    
    </div>
        <asp:GridView ID="gridViewKetQua" runat="server"></asp:GridView>
        <asp:Repeater ID="repeaterKetQua" runat="server">
            <ItemTemplate>
                <h5>
                    <%# Eval("sachResult.SachID") %> - 
                    <%# Eval("sachResult.TenSach") %>
                </h5>
                <div style="padding-left:20px">
                    Chủ đề:&nbsp; <%# Eval("chuDeResult.TenChuDe") %><br />
                    Giá bán: <%# Eval("sachResult.GiaBan") %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
