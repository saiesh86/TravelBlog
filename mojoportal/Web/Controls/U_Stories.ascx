<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Stories.ascx.cs" Inherits="mojoPortal.Web.Controls.CustomControls.U_Stories" %>
<h1>
    <asp:Label ID="LabelContentHeader" runat="server"></asp:Label>
</h1>
<asp:DataList runat="server" ID="DataListStories" RepeatDirection="Vertical">
    <HeaderTemplate>
        <asp:Label ID="LabelHeader" runat="server">
        </asp:Label>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:ImageButton class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
            Width="300" data-ix="team-image" Style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);"
            runat="server"></asp:ImageButton>
        <div class="clearfix"></div>
        <%--Text="<img src='App_Themes/.../Images/PDF.gif' /> PdfLink"--%>
        <h5>
            <asp:Label ID="LabelStoryName" class="uppercase roboto-slab paddtop1" runat="server" Text='<%# Eval("Heading") %>'></asp:Label>
        </h5>
        <asp:Label ID="LabelContent" Text='<%# Eval("Description").ToString().Substring(0, 25) %>' runat="server"></asp:Label>
        <br />
    </ItemTemplate>
</asp:DataList>

