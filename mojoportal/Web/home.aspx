<%@ Page Language="c#" CodeBehind="home.aspx.cs" MasterPageFile="~/App_MasterPages/SMT.Master" StylesheetTheme="" AutoEventWireup="false" Inherits="mojoPortal.Web.UI.HomePage" %>

<%-- @ OutputCache Duration="120" VaryByParam="*"  --%>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">

  <div class="maincontainer">

    <div class="w-section section">
        <div class="w-container contact-container" style="max-width:100%">
            <img src="Content/images/banner.PNG" />
        </div>
    </div>

    <div class="w-section homepagesections">

        <div class="w-row">
        </div>
        <div class="w-row">
            <div class="wf-empty w-col w-col-3 w-col-medium-4 wf-selected">
                <h3 class="team-title">Latest Stories</h3>

                <div class="dark-section storysection">test</div>

            </div>
            <div class="wf-empty w-col w-col-6 w-col-medium-4">
                <h3 class="team-title">Featured stories</h3>
                 <div class="dark-section storysection">test</div>
            </div>
            <div class="wf-empty w-col w-col-3 w-col-medium-4">
                <h3 class="team-title">Readers Favorite</h3>
                 <div class="dark-section storysection">test</div>

            </div>
        </div>
    </div>
      </div>
</asp:Content>


