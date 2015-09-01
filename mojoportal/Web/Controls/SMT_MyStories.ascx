<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SMT_MyStories.ascx.cs" Inherits="mojoPortal.Web.Controls._SMT_MyStories" %>
<portal:mojoLabel ID="mojoLabel1" runat="server" Text ="My Stories"></portal:mojoLabel>



<asp:Repeater ID="myStoriesRepeater" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
</asp:Repeater>
<%--<asp:SqlDataSource ID="myStoriesDataSource" runat="server"></asp:SqlDataSource>--%>




