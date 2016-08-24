<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExLinqToEntities.aspx.cs" Inherits="BaiTap.Demo.ExLinqToEntities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn1" Text="1" runat="server" OnClick="btn1_Click" />
        <asp:Button ID="btn2" Text="2" runat="server" OnClick="btn2_Click" />
        <asp:Button ID="Button1" Text="3" runat="server" OnClick="Button3_Click" />
        <asp:Button ID="Button2" Text="4" runat="server" OnClick="Button4_Click" />
        <asp:Button ID="Button3" Text="5" runat="server" OnClick="Button5_Click" />
        <asp:Button ID="Button4" Text="6" runat="server" OnClick="Button6_Click" />
        <asp:Button ID="button7" Text="7" runat="server" Onclick="button7_Click"/>
        <asp:Button ID="button8" Text="8" runat="server" Onclick="button8_Click"/>
        <asp:Button ID="button9" Text="9" runat="server" Onclick="button9_Click"/>
        <asp:Button ID="button10" Text="10" runat="server" Onclick="button10_Click"/>
        <div>
            <h4> Thông tin sản phẩm</h4>
            <asp:Label Text="SanPhamID" runat="server" /> 
            <asp:TextBox ID="txtSanPhamID" runat="server"></asp:TextBox></br>
            <asp:Label Text="TenSanPham" runat="server" />
            <asp:TextBox runat="server" ID="txtTenSanPham" /></br>
            <asp:Label Text="GiaBan" runat="server" />/
            <asp:TextBox runat="server" ID="txtGiaBan"/></br>
            <asp:Label Text="TenLoai" runat="server" />
            <asp:TextBox runat="server" ID="txtTenLoai"/>
        </div>

        <asp:GridView ID="grv1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
