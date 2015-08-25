<%@ Page Language="c#" CodeBehind="home.aspx.cs" MasterPageFile="~/App_MasterPages/SMT.Master" StylesheetTheme="" AutoEventWireup="false" Inherits="mojoPortal.Web.UI.HomePage" %>

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

                        <h1>Featured</h1>

                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>

                    </div>

                    <div class="dark-section storysection  w-col w-col-7">
                         <h1>Latest stories</h1>
                        <div class="w-row">
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                        </div>
                        <div>
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                        </div>
                        <div>
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                            <div class="dark-section w-col w-col-6">
                                <img src="http://codelayers.net/templates/hasta/law/fullwidth/images/539.jpg" alt="" class="img-responsive">
                                <div class="clearfix"></div>
                                <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                                <br>
                                <a href="#" class="read-more stone">Read Story</a>
                            </div>
                        </div>
                    </div>

                    <div class="dark-section storysection  w-col w-col-2">
                         <h1>Trending </h1>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                        <div>
                            <img class="team-image" src="http://uploads.webflow.com/541b9733d4c14cd218cdacf4/542382b8d903582652f04e21_team2.jpg"
                                width="300" data-ix="team-image" style="transition: transform 500ms; transform: scale(1) translateX(0px) translateY(0px);">
                            <div class="clearfix"></div>
                            <h5 class="uppercase roboto-slab paddtop1">Family Law</h5>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse et justo. Praesent mattis commodo augue. Aliquam ornare hendrerit augue. </p>
                            <br>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


