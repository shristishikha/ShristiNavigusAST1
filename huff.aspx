<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="huff.aspx.cs" Inherits="huff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div runat = "server" style = "margin:30px 0 0 378px;width:900px;background:white;min-height:450px;padding:50px 0 0 50px">
<div style ="position:fixed;height:30px;float:right;margin-left:50%;">
<asp:Label ID="Label1" runat="server" Text="Currently Active "></asp:Label>&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnCurr" runat="server" Text="" OnClick="btnCurr_Click"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnHis" runat="server" Text="Show History" OnClick="btnHis_Click" />
</div>
<br /><br /><br />
<asp:Button ID="btnShare" runat="server" Text="Share" style="text-align:left;float:right;margin-right:80px" OnClick="btnShare_Click"/>
<br />
<asp:Label ID="lblPage" runat="server" Text=""></asp:Label>
<br />  <br />
<asp:GridView ID="gvCurr" runat="server" Visible ="false"></asp:GridView>
</div>
</asp:Content>
