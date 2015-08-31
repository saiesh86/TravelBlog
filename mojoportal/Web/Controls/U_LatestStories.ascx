<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_LatestStories.ascx.cs" Inherits="mojoPortal.Web.Controls.CustomControls.U_LatestStories" %>
<h1>
    <asp:Label ID="LabelContentHeader" runat="server"></asp:Label>
</h1>
<asp:GridView runat="server" ID="GridViewStories" OnDataBound="GridViewStories_DataBound" OnRowDataBound="GridViewStories_RowDataBound">
    <Columns>       
        <asp:TemplateField>
            <ItemTemplate>
                <div class="w-row">
                    <asp:DataList ID="DataListRowStories" runat="server" RepeatDirection="Horizontal">
                        <HeaderTemplate>
                            <asp:Label ID="LabelHeader" runat="server">
                            </asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="dark-section w-col w-col-6">
                                <asp:ImageButton src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive" runat="server"></asp:ImageButton>
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">
                                    <asp:Label ID="LabelStoryName" runat="server" Text='<%# Eval("Heading") %>'></asp:Label>                                     
                                </h5>
                                <asp:Label ID="LabelContent" Text='<%# ((int)((string)Eval("Description")).Length >= 25) ? Eval("Description").ToString().Substring(0, 25) : Eval("Description") %>' runat="server"></asp:Label>
                                <%--<asp:Label ID="LabelContent" Text='<%# Eval("Description").ToString().Substring(0, 25) %>' runat="server"></asp:Label>--%>
                                <br />
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>

