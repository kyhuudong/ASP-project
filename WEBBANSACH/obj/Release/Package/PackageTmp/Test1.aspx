<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="WEBBANSACH.Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="outer">
            <div id="banner"></div>
            <div id="menu">
                
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">Trang chủ</asp:HyperLink>
                        
                            <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="#">Hỗ trợ</asp:HyperLink>
                       
                            <asp:HyperLink ID="HyperLink3" runat="server"  NavigateUrl="#">Liên hệ</asp:HyperLink>
                       
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        
                            <asp:Button ID="Button1" runat="server" Text="Search" />
                    
               
            </div>

            <div id="content">
                <div id="left">

                    <div class="label1"><asp:Label ID="Label1" runat="server" Text="Label">DANH MỤC THỂ LOẠI</asp:Label></div>

                    <asp:DataList ID="DataList1" runat="server">
                        <ItemTemplate>
                            <ul>
                                <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Text='<%#Eval("LOAISACH") %>'></asp:HyperLink></li>
                            </ul>                                                                
                        </ItemTemplate>    
                    </asp:DataList>
                </div>

                <div id="right">
                    <div class="label2"><asp:Label ID="Label2" runat="server" Text="ĐÂNG NHẬP"></asp:Label></div>
                    <table class="login" align="center">
                        
                        <tr>
                            <td><asp:Label ID="Label3" runat="server" Text="Tên đăng nhập" Font-Size="12px"></asp:Label></td>
                            <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td><asp:Label ID="Label4" runat="server" Text="Mật khẩu" Font-Size="12px"></asp:Label></td>
                            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td><asp:Button ID="Button2" runat="server" Text="Login" /></td>
                        </tr>
                    </table>
                </div>

                <div id="mid">

                </div>
            </div>

            <div id="footer"></div>
        </div>
    </form>
</body>
</html>
