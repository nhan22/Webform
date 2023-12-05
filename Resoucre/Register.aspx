<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Webtestcode.Resoucre.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html lang="vi">
<head runat="server">
    <title>Đăng Ký</title>
    <link rel="stylesheet" href="../StyleSheet/Register.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Đăng ký</h2>
            <div>
                <label>Tên đăng nhập:</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Mật khẩu:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <label>Xác nhận mật khẩu:</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <a href="Login.aspx">Bạn chưa đã có tài khoản? Đến đăng nhập!</a>
            </div>
            <div>
                <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
