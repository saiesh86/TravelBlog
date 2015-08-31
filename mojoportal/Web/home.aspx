<%@ Page Language="c#" CodeBehind="home.aspx.cs" MasterPageFile="~/App_MasterPages/SMT.Master" StylesheetTheme="" AutoEventWireup="false" Inherits="mojoPortal.Web.UI.HomePage" %>

<%@ Register Src="Controls/U_Stories.ascx" TagName="U_Stories" TagPrefix="uc1" %>
<%@ Register Src="Controls/U_LatestStories.ascx" TagName="U_LatestStories" TagPrefix="uc2" %>
<%-- @ OutputCache Duration="120" VaryByParam="*"  --%>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">

    <div>

        <%--    <div class="w-section section  homepagesections">
            <div class="w-row">

                <div class="wf-empty w-col w-col-7 carouselstory column_resp">
                 
                </div>

                <div class="wf-empty w-col w-col-5">
                    <div class="w-section lateststories">
                        <div class="w-row">
                            <div class="wf-empty w-col w-col-2">test</div>
                            <div class="wf-empty w-col w-col-2">test</div>
                        </div>
                        <div class="w-row">
                            <div class="wf-empty w-col w-col-2">test</div>
                            <div class="wf-empty w-col w-col-2">test</div>
                        </div>
                        <div class="w-row">
                            <div class="wf-empty w-col w-col-2">test</div>
                            <div class="wf-empty w-col w-col-2">test</div>
                        </div>
                    </div>
                </div>

            </div>
        </div>--%>


        <div class="w-slider slider _3" id="Home" data-animation="fade" data-duration="500" data-infinite="1" data-delay="4000" data-autoplay="1">
            <div class="w-slider-mask">
                <div class="w-slide slide-1" data-ix="slide-1" style="transform: translateX(0px); opacity: 1; z-index: 2; transition: opacity 500ms;">
                    <div class="w-container slider-info-box" style="transition: transform 500ms; transform: translateX(0px) translateY(30px);">
                        <h1 class="hero-title-left">Multi-Purpose Template
                            <br>
                            Make it yours now</h1>
                        <a class="button" href="#">Get started</a>
                    </div>
                </div>
                <div class="w-slide slide-2" style="transform: translateX(0px); opacity: 1; z-index: 1; visibility: hidden;">
                    <div class="w-container slider-info-box center" style="transition: transform 500ms; transform: translateX(0px) translateY(30px);">
                        <div class="hero-title-center" data-ix="hero-title-center" style="transform: scale(1); transition: transform 500ms;">OPEN A BETTER AND EASIER WAY TO MAKE YOUR WEBSITE AND BE INSTANTLY RESPONSIVE</div>
                        <a class="button" href="#">Choose Open template</a>
                    </div>
                </div>
            </div>
            <div class="w-slider-arrow-left">
                <div class="w-icon-slider-left slider-arrows"></div>
            </div>
            <div class="w-slider-arrow-right">
                <div class="w-icon-slider-right slider-arrows"></div>
            </div>
        </div>

        <div class="w-section banner-section">
            <div class="w-container">
                <div class="w-row">
                    <div class="w-col w-col-9 banner-text-column">
                        <div class="banner-text">We are passionate about your travel experiences.</div>
                    </div>
                    <div class="w-col w-col-3 banner-button"><a class="button" href="#">JOIN US today</a></div>
                </div>
            </div>
        </div>

        <div class="w-section section maincontainer">
            <div class="team-members">
                <div class="w-row">
                    <div class="dark-section storysection  w-col w-col-3">
                        <uc1:U_Stories ID="FeaturedStories" runat="server" NumberOfStories="3" Header="FeaturedStories" />
                    </div>

                    <div class="dark-section storysection  w-col w-col-7">
                        <uc2:U_LatestStories ID="U_LatestStories1" runat="server" Header="LatestStories" />
                    </div>

                    <div class="dark-section storysection  w-col w-col-2">
                        <uc1:U_Stories ID="TrendingStories" runat="server" NumberOfStories="3" Header="Trending" />
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>


