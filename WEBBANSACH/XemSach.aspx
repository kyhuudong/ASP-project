<%@ Page Title="" Language="C#" MasterPageFile="~/BANSACH.Master" AutoEventWireup="true" CodeBehind="XemSach.aspx.cs" Inherits="WEBBANSACH.XemSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" >
        <ItemTemplate>
            <table>
                <tr>
                    <td rowspan="4">
                        <asp:ImageButton ID="ImageButton1" runat="server" Width="100px" Height="130px" ImageUrl='<%#"~/Hinh/"+Eval("HINH") %>' CommandArgument='<%#Eval("MASACH") %>'  OnClick="ImageButton1_Click" style=""/>
                    </td>
                    <td style="width: 100px"><asp:Label ID="Label1" runat="server" Text="Mã sách:"></asp:Label></td>
                    <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("MASACH") %>'></asp:Label></td>
                </tr>

                <tr>
                    <td style="width: 100px"><asp:Label ID="Label3" runat="server" Text="Tên sách:"></asp:Label></td>
                    <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("TENSACH") %>'></asp:Label></td>
                </tr>
                
                <tr>
                    <td style="width: 100px"><asp:Label ID="Label5" runat="server" Text="Đơn giá:"></asp:Label></td>
                    <td><asp:Label ID="Label6" runat="server" Text='<%#Eval("DONGIA") %>'></asp:Label></td>
                </tr>

                <tr>
                    
                    <td colspan="2"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"MatSachChiTiet.aspx?MASACH="+Eval("MASACH") %>'>Chi tiết sách</asp:HyperLink></td>
                </tr>

                

            </table>
        </ItemTemplate>
    </asp:DataList>

</asp:Content>
