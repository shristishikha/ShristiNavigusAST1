<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="UMain.aspx.cs" Inherits="UMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat = "server" style = "margin:30px 0 0 378px;width:900px;background:white;min-height:450px;padding:50px 0 0 50px">                        
        <asp:GridView ID="gv" runat="server" Visible ="false" AutoGenerateColumns ="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID ="lb" runat ="Server" Text = '<%#Eval("Page_Name")%>' CommandArgument ='<%#Eval("Page_Name")%>' OnClick ="Unnamed_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="" Visible = "false"></asp:Label>
        <br />
        <asp:LinkButton ID="lbtnNPage" runat="server" OnClick="lbtnNPage_Click">Create a new page...</asp:LinkButton>
    </div>
</asp:Content>

