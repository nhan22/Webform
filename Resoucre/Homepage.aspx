﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Webtestcode.Resoucre.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html lang="vi">
<head runat="server">
    <title>Quản lý sinh viên</title>
    <link rel="stylesheet" href="../StyleSheet/Homepage.css">
</head>
<body>
    <form id="form1" runat="server">
        <h1>Chương Trình Quản Lý Sinh Viên</h1>
        <div class="InputData">
            <table class="TableInput">
                <tr class="TableTOP">
                    <td>
                        <asp:Label ID="Masv" runat="server" Text="Mã Sinh Viên"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMasv" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Makhoa" runat="server" Text="Mã Khoa"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaKhoa" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="TenKhoa" runat="server" Text="Tên Khoa"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenKhoa" runat="server"></asp:TextBox>
                    </td>
                </tr >
                <tr class="TableDOW">
                    <td>
                        <asp:Label ID="Hosv" runat="server" Text="Họ Sinh Viên"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHosv" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Tensv" runat="server" Text="Tên Sinh Viên"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTensv" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Ngaysinh" runat="server" Text="Ngày Sinh"></asp:Label>
                    </td>
                    <td>
                        <input type="date" id="txtNgaySinh" runat="server"  name="txtNgaySinh"/>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ShowData">
            <asp:GridView ID="GridViewDataSV" runat="server" AutoGenerateDeleteButton="false" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundField>
                    <asp:BoundField DataField="Masv" HeaderText="Mã Sinh Viên" SortExpression="Masv"></asp:BoundField>
                    <asp:BoundField DataField="Hosv" HeaderText="Họ Sinh Viên" SortExpression="Hosv"></asp:BoundField>
                    <asp:BoundField DataField="Tensv" HeaderText="Tên Sinh Viên" SortExpression="Tensv"></asp:BoundField>
                    <asp:BoundField DataField="Ngaysinh" HeaderText="Ngày Sinh" SortExpression="Ngaysinh"></asp:BoundField>
                    <asp:BoundField DataField="Makhoa" HeaderText="Mã Khoa" SortExpression="Makhoa"></asp:BoundField>
                    <asp:BoundField DataField="Tenkhoa" HeaderText="Tên Khoa" SortExpression="Tenkhoa"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="Controller_Button">
            <table class="TableButton">
                <tr class="Table_button_TOP">
                    <td>
                        <asp:Button ID="buttonAdd" runat="server" Text="Thêm" OnClick="buttonAdd_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="buttonRemove" runat="server" Text="Xóa" OnClick="buttonRemove_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="buttonChange" runat="server" Text="Sửa" OnClick="buttonChange_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="buttonCancel" runat="server" Text="Hủy" OnClick="buttonCancel_Click"></asp:Button>
                    </td>
                </tr>
                <tr class="Table_button_MID">
                    <td>
                        <asp:Button ID="buttonExit" runat="server" Text="Thoát" OnClick="buttonExit_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="buttonTakeData" runat="server" Text="Lấy Dữ Liệu" OnClick="buttonTakeData_Click"></asp:Button>
                    </td>
                </tr>
                <tr class="Table_lable_DOW">
                    <td>
                        <asp:Label ID="Count" runat="server" Text="Tổng Số Sinh Viên = "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Number" runat="server" Text=" 0 "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>