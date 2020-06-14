<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="Forgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Recovery</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="min-height:430px;max-height:2500px;">
        <div style ="margin:15% 0 0 37%;width:370px; height:250px; background-color:white;">
            <div style ="padding:0 0 0 42%;padding-top:5px"><h3><asp:Label ID="Label1" runat="server" Text="Recovery"></asp:Label></h3></div>
            <br />
            <div style ="margin:0 0 0 15%">
                <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtUname" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="Security Question" Visible ="false"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtAns" runat="server" Visible ="false"></asp:TextBox>
                <br /><br />
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Recover"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </div>
    </div>
</asp:Content>

