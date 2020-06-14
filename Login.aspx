<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="min-height:430px;">
        <div style ="margin:15% 0 0 35%;width:410px;height:290px;background-color:white;">
            <div style ="padding:0 0 0 42%;padding-top:5px"><h3><asp:Label ID="Label1" runat="server" Text="Login"></asp:Label></h3></div>
            <br />
            <div style ="margin:0 0 0 15%">
                <asp:Label ID="Label2" runat="server" Text="Username/Email"></asp:Label>
                <br /><br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                <%--<br />
                <asp:HyperLink ID="hypFPwd" runat="server" NavigateUrl ="~/Forgot.aspx" Font-Size ="Small">Forgot Password</asp:HyperLink>--%>
                <br /><br />
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
        </div>
    </div>
</asp:Content>

