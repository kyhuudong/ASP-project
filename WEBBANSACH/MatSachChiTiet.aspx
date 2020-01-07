<%@ Page Title="" Language="C#" MasterPageFile="~/BANSACH.Master" AutoEventWireup="true" CodeBehind="MatSachChiTiet.aspx.cs" Inherits="WEBBANSACH.MatSachChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><link href="GUI/StyleSheet1.css" rel="stylesheet" />
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table>
        <tr>
            <td rowspan="5"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#"~/Hinh/"+Eval("HINH") %>' CommandArgument='<%#Eval("MASACH") %>' Width="100px" Height="130px"/></td>
            <td><asp:Label ID="Label1" runat="server" Text="Tên sách:"></asp:Label></td>
            <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("TENSACH") %>'></asp:Label></td>
        </tr>

        <tr>
            <td style="width:100px"><asp:Label ID="Label3" runat="server" Text="Mô tả:"></asp:Label></td>
            <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("MOTA") %>'></asp:Label></td>
        </tr>

        <tr>
            <td style="width:100px"><asp:Label ID="Label5" runat="server" Text="Đơn giá:"></asp:Label></td>
            <td><asp:Label ID="Label6" runat="server" Text='<%#Eval("DONGIA") %>'></asp:Label></td>
        </tr>

        <tr>
            <td style="width:100px" ><asp:Label ID="Label7" runat="server" Text="Số lượng:"></asp:Label></td>
            <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:center" colspan="2" class="auto-style1"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Giỏ hàng</asp:LinkButton></td>
        </tr>

        <tr>
            <td><asp:Button ID="Button1" runat="server" Text="Mua" OnClick="Button1_Click" /></td>
        </tr>

        </table>
        </ItemTemplate>
    </asp:DataList>

    <div><asp:Label ID="Label8" runat="server" Text=""></asp:Label></div>
</asp:Content>
