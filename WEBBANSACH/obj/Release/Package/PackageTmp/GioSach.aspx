<%@ Page Title="" Language="C#" MasterPageFile="~/BANSACH.Master" AutoEventWireup="true" CodeBehind="GioSach.aspx.cs" Inherits="WEBBANSACH.GioSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Chọn">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text='<%#Eval("MASACH") %>'/>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("MASACH") %>'/>
                </ItemTemplate>
            </asp:TemplateField>     
            
            <asp:BoundField DataField="TENSACH" HeaderText="Tên sách"/>
            <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá"/>


            <asp:TemplateField HeaderText="Số lượng">               
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("SOLUONG") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền"/>
           
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Thành tiền"></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

    <div class="ButtonNe">
    <table style="width:50%">
        <tr>
            <td><asp:Button ID="Button3"  runat="server" Text="Xóa" style="width:100%" OnClick="Button1_Click" /></td>
            <td><asp:Button ID="Button4"  runat="server" Text="Sửa" style="width:100%" OnClick="Button2_Click"/></td>
        </tr>
    </table>
    </div>

</asp:Content>
