<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExRawSQLQuery.aspx.cs" Inherits="Baitap.Demo.ExRawSQLQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnSqlQuery1" runat="server" OnClick="btnSqlQuery1_Click" Text="1-SqlQuery" />
        <asp:Button ID="btnSqlQuery2" runat="server"  Text="2-SqlQuery" OnClick="btnSqlQuery2_Click" />
        <asp:Button ID="btnExecuteSqlCommandInsert" runat="server" Text="ExecuteSqlCommand - Insert" OnClick="btnExecuteSqlCommandInsert_Click" />
        <asp:Button ID="btnExecuteSqlCommandUpdate" runat="server" Text="ExecuteSqlCommand - Update" OnClick="btnExecuteSqlCommandUpdate_Click"  />
           <asp:Button ID="btnExecuteSqlCommandDelete" runat="server" Text="ExecuteSqlCommand - Delete" OnClick="btnExecuteSqlCommandDelete_Click"  />
        <br />
        <br />
        <asp:GridView ID="gvKetQua" runat="server">
        </asp:GridView>
        <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
