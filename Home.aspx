<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style ="min-height:635px;max-height:2500px;">
    </div>
    <div style ="min-height:430px;">
        <div style ="margin:15% 0 0 35%;width:410px;height:290px;background-color:white;">
            <br />
            <div style ="margin:0 0 0 15%">
                <asp:Label ID="Label2" runat="server" Text="WELCOME: This is Assignment 1..."></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>
</asp:Content>

