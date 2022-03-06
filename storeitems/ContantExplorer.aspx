<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        document.getElementById('fullnavscont').style.display = 'block';
        /*var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
        }*/
        //androidAPIs.DeactivateFullScreenMode();
        if ("androidAPIs" in window) {
            //androidAPIs.DeactivateFullScreenMode();
            androidAPIs.FullyTransStatusBar();
        }
        else {
            location.href = '/SuMMangaInstallAPP.aspx';
        }
        androidAPIs.SetDarkStatusBarColor();
    </script>
    <div id="SuMLoadingPIndHandler" class="" style="overflow:hidden !important;border-radius:0px;display:block;position:fixed !important;top:0 !important;z-index:998 !important;background-color:#ffffff;width:100%;height:100%;margin-top:0px;margin-left:0px;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;">
        <div id="SuMLoadingFHandBG" runat="server" style="overflow:hidden !important;width:100%;height:100%;background-color:rgba(0,0,0,0.74);margin:0 auto;">
            <div id="SuMLoadingHandDivConF0C0" style="transition:all 0.18s !important;display: block; height: fit-content; width: 280px; background-color: rgb(255, 255, 255); border-radius: 18px; margin-right: auto; margin-bottom: 0px; padding: 38px 32px 32px; margin-left: calc(50vw - 140px); position: fixed !important; top: 0px !important; z-index: 1999 !important; margin-top: calc(50vh - 120px) !important; text-align: center !important;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;" class="shadow-sm">
                <svg id="SuMLoadingSVGPreviewHandler" style="display:inline !important;margin-left:12px !important;margin-top:-6px;" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="36px" viewBox="0 0 24 24" width="36px" fill="rgba(143,107,171,0.92)"><g><rect fill="none" height="24" width="24"></rect><rect fill="none" height="24" width="24"></rect></g><g><path d="M17.5,4.5c-1.95,0-4.05,0.4-5.5,1.5c-1.45-1.1-3.55-1.5-5.5-1.5c-1.45,0-2.99,0.22-4.28,0.79C1.49,5.62,1,6.33,1,7.14 l0,11.28c0,1.3,1.22,2.26,2.48,1.94C4.46,20.11,5.5,20,6.5,20c1.56,0,3.22,0.26,4.56,0.92c0.6,0.3,1.28,0.3,1.87,0 c1.34-0.67,3-0.92,4.56-0.92c1,0,2.04,0.11,3.02,0.36c1.26,0.33,2.48-0.63,2.48-1.94l0-11.28c0-0.81-0.49-1.52-1.22-1.85 C20.49,4.72,18.95,4.5,17.5,4.5z M21,17.23c0,0.63-0.58,1.09-1.2,0.98c-0.75-0.14-1.53-0.2-2.3-0.2c-1.7,0-4.15,0.65-5.5,1.5V8 c1.35-0.85,3.8-1.5,5.5-1.5c0.92,0,1.83,0.09,2.7,0.28c0.46,0.1,0.8,0.51,0.8,0.98V17.23z"></path><g></g><path d="M13.98,11.01c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.54-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,10.99,14.05,11.01,13.98,11.01z"></path><path d="M13.98,13.67c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,13.66,14.05,13.67,13.98,13.67z"></path><path d="M13.98,16.33c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.7-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,16.32,14.05,16.33,13.98,16.33z"></path></g></svg>
                <p id="SuMLoadingHandlerTXT" runat="server" style="display: inline-block; margin-left: 4px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 132%; color: rgba(143, 107, 171, 0.92); margin-bottom: -8px; text-align: left; width: calc(100% - 64px) !important;">Chapter 1</p>
                <p id="SuMLoadingHandlerComTXT" class="animated fadeIn" style="font-size: 26px; width: 100%; display: block; text-align: center; height: 26px;margin-top: 10px;margin-bottom:6px; color: rgba(143, 107, 171, 0.64);">loading complete</p>
                <script>
                    var LoadDetThemeColor = document.getElementById('<%= SuMLoadingHandlerTXT.ClientID %>').style.color;
                    document.getElementById('SuMLoadingSVGPreviewHandler').setAttribute('fill', LoadDetThemeColor);
                    document.getElementById('SuMLoadingHandlerComTXT').style.color = LoadDetThemeColor.replace('0.92', '0.64');
            </script>
            </div>
        </div>
    </div>
    <script>
        var SuMLoadingPIndHandlerElm = document.getElementById('SuMLoadingPIndHandler');
        var SuMLoadingHandDivConF0C0Elm = document.getElementById('SuMLoadingHandDivConF0C0');
        setTimeout(() => {
            //FixAnimations While Caching
            SuMLoadingPIndHandlerElm.style.height = '100%';
            SuMLoadingPIndHandlerElm.style.width = '100%';
            SuMLoadingPIndHandlerElm.style.marginTop = '0';
            SuMLoadingPIndHandlerElm.style.marginLeft = '0';
            SuMLoadingPIndHandlerElm.classList.remove('fadeOut');
            SuMLoadingHandDivConF0C0Elm.classList.remove('fadeOut');
            SuMLoadingPIndHandlerElm.style.display = 'block';
            SuMLoadingPIndHandlerElm.style.visibility = null;
            SuMLoadingPIndHandlerElm.style.borderRadius = null;
            SuMLoadingHandDivConF0C0Elm.style.display = 'block';
            SuMLoadingHandDivConF0C0Elm.style.visibility = null;
            SuMLoadingHandDivConF0C0Elm.classList.remove('animated');
            SuMLoadingPIndHandlerElm.classList.remove('animated');
            SuMLoadingHandDivConF0C0Elm.style.marginLeft = 'calc(50vw - 140px)';
            //SuMLoadingPIndHandlerElm.style.transition = 'all 0.6s !important';
            //Animation Start from here
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.style.height = '360px';
                SuMLoadingPIndHandlerElm.style.width = '360px';
                SuMLoadingPIndHandlerElm.style.marginTop = 'calc(50vh - 200px)';
                SuMLoadingPIndHandlerElm.style.marginLeft = 'calc(50vw - 180px)';
                SuMLoadingPIndHandlerElm.style.borderRadius = '180px';
                SuMLoadingHandDivConF0C0Elm.style.marginLeft = 'calc(50% - 140px) !important';
                //SuMLoadingHandDivConF0C0Elm.style.margin = '0 auto !important';
            }, 80);
            setTimeout(() => {
                SuMLoadingHandDivConF0C0Elm.classList.add('animated');
                SuMLoadingHandDivConF0C0Elm.classList.add('fadeOut');
            }, 280);
            setTimeout(() => {
                SuMLoadingHandDivConF0C0Elm.style.display = 'none';
                SuMLoadingHandDivConF0C0Elm.style.visibility = 'hidden';
                SuMLoadingHandDivConF0C0Elm.style.margin = null;
            }, 360);
            setTimeout(() => {
                //SuMLoadingPIndHandlerElm.style.transition = 'all 1s !important';
                SuMLoadingPIndHandlerElm.style.height = '0px';
                SuMLoadingPIndHandlerElm.style.width = '0px';
                SuMLoadingPIndHandlerElm.style.marginTop = '50vh';
                SuMLoadingPIndHandlerElm.style.marginLeft = '50vw';
                SuMLoadingPIndHandlerElm.style.borderRadius = '12px';
            }, 560);
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.classList.add('animated');
                SuMLoadingPIndHandlerElm.classList.add('fadeOut');
            }, 540);
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.style.display = 'none';
                SuMLoadingPIndHandlerElm.style.visibility = 'hidden';
            }, 820);
        }, 960);
    </script>
    <div style="display:none !important;visibility:hidden !important;" id="ScriptInjectorB000" runat="server"></div>
    <asp:Button ID="UpdateWannaNFavNCurr" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden !important;" />
    <div id="ChapterUnavaliblePOPUP" runat="server" style="background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:none;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center GoodBlurAnim">
        <div id="SUAC000SP" runat="server" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">Chapter is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:rgba(0, 0, 0, 0.527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather the chapter is not Finished/Uploaded yet, or it is not sutable for audience from your contry or your age.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
    <div id="SuMMangaTopBar" runat="server" style="background-color:rgba(135,56,65,0.82) !important;position:fixed !important;top:0 !important;animation-duration:0.16s !important;z-index:999 !important;height:fit-content !important;width:100% !important;display:block;padding-top:6px;padding-bottom:0px;padding-left:4px;border-bottom-left-radius:22px;border-bottom-right-radius:22px;" class="animated fadeInDown">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;" id="SuMMangaTopBarHeightHelper"></div>
        <div style="font-size:118%;margin-left:18px;margin-bottom:-18px;display:inline-block;height:fit-content;width:fit-content;color:#fffffff0;" class="">
            <img src="/svg/ExploreBook.svg" width="30" height="30" style="display:inline;margin-top:-6px;">
            <p style="display:inline;margin-left:8px;font-size:120%;" id="SliderTXTFIll" runat="server">#T</p>
            <p style="display:inline-block;margin-right:28px;font-size:86%;color:#ffffffbd;float:right;margin-top:6px;margin-left:4px;" id="SliderChaptersSta" runat="server">- #CN chapters</p>
        </div>
    </div>
    <div id="SuMLogInAbsCon" runat="server">
    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="LoginBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="SuMLoginUI" runat="server" style=" background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:block;z-index:999 !important;margin:0 auto !important;position:absolute !important;" class="row justify-content-center GoodBlur">
            <div id="SacondContForLogin" style="width:100vw !important;height:100vh !important;" class="col-md-9 col-lg-12 col-xl-10">
                <div style="border-radius:22px !important;max-width:960px !important;margin:0 auto !important;margin-top:82px !important;" class="card shadow-lg o-hidden border-0 my-5 sumsmoothtrans">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-flex">
                                <div class="flex-grow-1 bg-login-image" style="background: url(&quot;/assets/img/dogs/SuM-Reader.jpg?h=0086b7bb234345281e92a417000e3a03&quot;);"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5 sumsmoothtrans">
                                <a style="float:right;width:32px;height:32px;padding:4px;margin-right:-32px !important;margin-top:-32px !important;" onclick="document.getElementById('MainContent_SuMLoginUI').style.display = 'none'; document.getElementById('MainContent_SuMLoginUI').classList.add('fadeIn'); document.getElementById('MainContent_SuMLoginUI').classList.add('animated'); document.getElementById('SacondContForLogin').classList.add('pulse'); document.getElementById('SacondContForLogin').classList.add('animated'); document.getElementById('fullnavscont').style.display = 'none'; document.getElementById('fullnavscont').classList.remove('slideOutDown'); document.getElementById('fullnavscont').classList.add('slideInUp'); document.getElementById('fullnavscont').style.display = 'block';">
                                    <img style="width:22px;height:22px;" src="/svg/close.svg" />
                                </a>
                                    <div class="text-center">
                                        <h4 class="text-dark mb-4">Login to start reading!</h4>
                                    </div>
                                    <div class="user">
                                        <div class="mb-3"><input class="form-control form-control-user" type="text" style="border-radius:14px;" id="UserNameL" placeholder="User Name" name="UserName" runat="server"></div>
                                        <div class="mb-3"><input class="form-control form-control-user" type="password" style="border-radius:14px;" id="PasswordL" placeholder="Password" name="password" runat="server"></div>
                                        <div style="text-align:center;width:100%;height:fit-content;margin-bottom:16px;">
                                            <div class="animated fadeInDown" runat="server" id="LogInProssInfo" style="display:none;">
                                                <h6 class="animated pulse" style="color:rgb(255,90,69);padding:8px;" id="LoginStatus" runat="server"></h6>
                                                <asp:Button CssClass="btn btn-primary d-block btn-user w-100" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="ResendConfLink" Visible="false" ID="ResendConf" Text="Re-Send Email" />
                                                <asp:Button CssClass="btn btn-primary d-block btn-user w-100" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="LogOutOffAll" Visible="false" ID="LogOutOffAllBTN" Text="Logout of all devices" />
                                            </div>
                                        </div>
                                        <div class="mb-3 sumsmoothtrans">
                                            <div class="custom-control custom-checkbox small">
                                                <div class="form-check"><input class="form-check-input custom-control-input" type="checkbox" checked="checked" id="formCheck-1"><label id="rem" runat="server" class="form-check-label custom-control-label" for="formCheck-1">Remember Me</label></div>
                                            </div> 
                                        </div>
                                        <asp:Button ID="LoginBTN" CssClass="btn btn-primary d-block btn-user w-100 sumsmoothtrans" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="LoginToSuM" runat="server" Text="Login" />
                                        <hr class="sumsmoothtrans">
                                        <a style="border-radius:14px !important;" class="sumsmoothtrans btn btn-primary d-block btn-google btn-user w-100 mb-2" role="button"><i class="fab fa-google"></i>&nbsp; Login with Google</a>
                                        <a style="border-radius:14px !important;" class="sumsmoothtrans btn btn-primary d-block btn-facebook btn-user w-100" role="button"><i class="fab fa-facebook-f"></i>&nbsp; Login with Facebook</a>
                                        <hr class="sumsmoothtrans">
                                    </div>
                                    <div class="text-center sumsmoothtrans"><a class="small" href="/AccountETC/PassRecovryETC.aspx" style="color: rgb(104,64,217);">Forgot Password?</a></div>
                                    <div class="text-center sumsmoothtrans"><a class="small" href="/AccountETC/RegisterETC.aspx" style="color: rgb(104,64,217);">Create an Account!</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
    <script>
        document.getElementById('MainContent_SuMLoginUI').style.display = 'none';
        document.getElementById('MainContent_SuMLoginUI').classList.add('fadeIn');
        document.getElementById('MainContent_SuMLoginUI').classList.add('animated');
        document.getElementById('SacondContForLogin').classList.add('pulse');
        document.getElementById('SacondContForLogin').classList.add('animated');

        /*document.getElementById('fullnavscont').style.display = 'none';
        document.getElementById('fullnavscont').classList.remove('slideOutDown');
        document.getElementById('fullnavscont').classList.add('slideInUp');
        document.getElementById('fullnavscont').style.display = 'block';*/
    </script>
    </div>
    <style>
        /*# {
            animation: rainbow 10s linear infinite;
        }*/

        @keyframes rainbow {
            0% {
                background-color: #baa9ccd1;
            }

            25% {
                background-color: #85798bd1;
            }

            50% {
                background-color: #82667bd1;
            }

            75% {
                background-color: #968aaed1;
            }

            100% {
                background-color: #baa9ccd1;
            }
        }
        .ForceMaxW {
            max-width:1600px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }

    </style>
    <script>
        /* navigator.share({title:'SuM Manga',text:'Check out X on SuM Manga.',url:'LINK'}); */
        /*if (fullnavscont.classList.contains('slideInUp')) {
            fullnavscont.classList.remove('slideOutDown');
            fullnavscont.classList.remove('slideInUp');
            fullnavscont.style.display = 'block';
        };*/
        fullnavscont.style.display = 'block';
        document.addEventListener("DOMContentLoaded", function () {

            var fullnavscont = document.getElementById("fullnavscont");
            if (fullnavscont.classList.contains('slideOutDown')) {
                fullnavscont.classList.remove('slideOutDown');
                fullnavscont.classList.add('slideInUp');
                fullnavscont.style.display = 'block';
            };

            // Check if there is a local storage item with tbe name "animate"
            /*if (window.localStorage.getItem("animate") != null) {

                fullnavscont.style.display = "none";
                */
                // Remove the item
                /*window.localStorage.removeItem("animate");

                fullnavscont.classList.add("animated", "slideInUp");

                fullnavscont.style.display = null;

            }*/

            /*window.onclick = function (e) {

                //console.log(e);

                // Check if this action was triggered by clicking an <a> element
                if (document.activeElement.tagName == "A" && document.activeElement.getAttribute("name") != "no-animation") {

                    // Get the element's href
                    var redirectLink = document.activeElement.getAttribute("href");

                    // Prevent the page from being redirected
                    e.preventDefault();

                    // Add the slide down animation
                    fullnavscont.classList.add("animated", "slideOutDown");

                    setTimeout(function () {

                        window.location.href = redirectLink;

                    }, 480);

                }

            };
        });*/
    </script>
    <div id="FakeBody" runat="server" style="background-color:rgb(255,255,255);width:100vw !important;height:100vh !important;max-height:100vh !important;position:absolute !important;">
    <div id="background" runat="server"  style="background-color:rgba(0,0,0,0.74) !important;width:100vw !important;height:100vh !important;">
    <div id="3rdGBLayer" style="background-color:transparent;width:100vw;height:100vh;">
    <div id="CONTANERFROCONTANTEXPLORER" style="width:100vw !important;max-width:740px !important;margin:0 auto !important;">
    <div id="ACont0" runat="server" class="fadeIn animated" style="width:100%;">
    <div class="animated fadeIn" style="height:fit-content;width:100%;overflow:hidden; background-color:transparent !important;position:fixed;max-width:720px;overflow-x:hidden !important;" id="CategoryX" runat="server">
        <style>
            .ZoomInBackground {
                -webkit-animation: SuMZoomInBG 5s linear !important;
                animation: SuMZoomInBG 5s linear !important;
            }
            .ZoomOutFromInBackground {
                -webkit-animation: SuMZoomOutFromInBG 5s linear !important;
                animation: SuMZoomOutFromInBG 5s linear !important;
            }
            @-webkit-keyframes SuMZoomInBG {
                0% {
                    background-size: 100%;
                }

                100% {
                    background-size: 180%;
                }
            }
            @-webkit-keyframes SuMZoomOutFromInBG {
                0% {
                    background-size: 180%;
                }

                100% {
                    background-size: 100%;
                }
            }
        </style>
    <div id="infoCover" runat="server" class="mySlides animated pulse" style="animation-duration:1.2s !important;overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/X/X.jpg); background-size: cover; background-position: center;width:100% !important;height:fit-content;padding-top:2px !important;">
    <div style="width:94%;height:fit-content;position:relative;margin:0 auto;margin-top:32px;">
        <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;width:100%;height:fit-content;">#</h1>
        <p style="color:rgb(255, 255, 255, 0.82);float:right;margin-top:-18px;margin-right:10px;">By <b id="MangaCreator" style="font-size:80%;" runat="server"></b></p>
    </div>
        <hr style="margin:0 auto !important;height:2.6px !important;border-width:0;color:#ffffff;background-color:#ffffff;width:82%;opacity:0.26;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:6px;margin-bottom:6px !important;">
    <p style="text-align:center;height:fit-content;width:auto;max-width:96%;font-size:96%;color:#ffffff;margin:14px !important;margin-bottom:26px !important;margin-top:2px !important;height:fit-content !important;min-height:280px !important;" id="MdiscS" runat="server">#</p>
    <div id="HiehtFixUpNCHxInfo" style="margin:0 auto;margin-bottom:32px !important;height:fit-content;width:100%;position:relative;">
        <a style="display:block;float:right !important;margin-right:22px;margin-top:-5px;">
            <p style="display:inline;color:rgba(255,255,255,0.74);" id="MangaRating" runat="server"></p>
            <img style="width:20px;height:20px;display:inline;" src="/svg/views.svg" />
            <p style="display:inline;color:#ffffff;" id="ViewsSutNum" runat="server"></p>
            <b style="display:inline;color:#ffffff;" id="ViewsSutLater" runat="server"></b>
        </a>
    </div>
        <div style="margin:0 auto;margin-bottom:28px;height:12px !important;width:100%;position:fixed;"></div>
</div>
        <script>
            var ThisPageSBarFixUpPropElmVar = document.getElementById('<%= infoCover.ClientID %>');
            var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
            ThisPageSBarFixUpPropElmVar.style.paddingTop = (2 + StatusBarHeightValue) + 'px !important';
        </script>
</div>
            </div>
        <div class="animated fadeIn" style="animation-duration:0.18s;opacity:0;float:left !important;margin-top:20vh;width:100% !important;height:66px !important;overflow:hidden !important;position:fixed !important;" id="FavNWannaContaner" runat="server">
            <div id="AddToFavNWanna" runat="server" style="animation-duration:0.26s !important;width:fit-content;height:38px;background-color:red;border-radius:18px;padding:4px !important;opacity:0;" class="animated pulse" >
                <asp:Button ID="ADDTOFAV" runat="server" OnClick="AddToFavList" style="display:none;visibility:hidden;" />
                <asp:Button ID="REMOVEFROMFAV" runat="server" OnClick="RemoveFromFavList" style="display:none;visibility:hidden;" />
                <asp:Button ID="ADDTOWANNA" runat="server" OnClick="AddToWannaList" style="display:none;visibility:hidden;" />
                <asp:Button ID="REMOVEFROMWANNA" runat="server" OnClick="RemoveFromWannaList" style="display:none;visibility:hidden;" />
                <asp:UpdatePanel ID="CEFAVNWANNAUpdatepanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="REMOVEFROMWANNA" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ADDTOWANNA" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="REMOVEFROMFAV" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ADDTOFAV" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="UpdateWannaNFavNCurr" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <img id="Fav" runat="server" src="/svg/favoriteNOTFILLED.svg" style="margin-left:18px;margin-right:6px !important;pointer-events:all !important;" height="26" width="26" class="animated pulse" />
                        <a style="display:inline-block !important;width:2px !important;height:18px !important;margin:0 auto !important;vertical-align:middle !important;background-color:#ffffff30 !important;border-radius:1px !important;overflow:hidden;"></a>
                        <img id="Wanna" runat="server" src="/svg/add.svg" style="margin-right:-4px;display:inline !important;pointer-events:all !important;" height="30" width="30" class="animated pulse" />
                        <p style="color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" id="WannaListTXT" runat="server" class="animated pulse"><b>Wanna list</b></p>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
                <script>
                    var FAVIMGBTN = document.getElementById('<%= Fav.ClientID %>');
                    var WANNAIMGBTN = document.getElementById('<%= Wanna.ClientID %>');
                    var HIDDENFAVadd = document.getElementById('<%= ADDTOFAV.ClientID %>');
                    var HIDDENFAVremove = document.getElementById('<%= REMOVEFROMFAV.ClientID %>');
                    var HIDDENWANNAadd = document.getElementById('<%= ADDTOWANNA.ClientID %>');
                    var HIDDENWANNAremove = document.getElementById('<%= REMOVEFROMWANNA.ClientID %>');

                    var DetectedThemeColor = null;
                    location.search.substring(1).split("&").forEach(function (val) {

                        var currVal = val.split("=");
                        if (currVal[0] == "TC") {

                            DetectedThemeColor = decodeURI(currVal[1]);

                        }

                    });

                    //document.getElementById('3rdGBLayer').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.32");

                    function AddToFavJava() {
                        FAVIMGBTN.src = '/svg/favorite.svg';
                        HIDDENFAVadd.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function RemoveFromFavJava() {
                        FAVIMGBTN.src = '/svg/favoriteNOTFILLED.svg';
                        HIDDENFAVremove.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function AddToWannaJava() {
                        WANNAIMGBTN.src = '/svg/check.svg';
                        HIDDENWANNAadd.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function RemoveFromWannaJava() {
                        WANNAIMGBTN.src = '/svg/add.svg';
                        HIDDENWANNAremove.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };
                </script>
            </div>
        </div>
        <div class="animated fadeInUp" id="ChaptersAndFuncCard" style="animation-duration:0.26s !important;opacity: 0;margin-top:-20px;height:fit-content;background-color:transparent !important;max-width:720px !important;">
            <div style="width:100% !important;height:32px !important;background-color:transparent !important;overflow:hidden !important;"></div>
            <div style="background-color:#ffffff;border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;width:100%;">
        <div id="GernsTags" runat="server" style="border-top-right-radius:22px;border-top-left-radius:22px;width:100%;height:fit-content;background-color:transparent;align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(0,0,0,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
        <div style="background-color:aqua;margin:0 auto;height:fit-content;position:relative;margin-top:-2px !important;" id="SVC" runat="server">
            <asp:UpdatePanel ID="CurrStateLoad" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UpdateWannaNFavNCurr" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <hr style="width:82%;height:2px;border-radius:1px;color:#ffffff30;margin:0 auto !important;margin-top:-6px !important;margin-bottom:6px !important;position:absolute;z-index:998;margin-left:9% !important;" />
                        <div class="animated pulse" id="MRSC" runat="server" style="margin-top:3px !important;margin-bottom:13px !important;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;display:inline;overflow:hidden !important;">
                            <a id="MRSW" onclick="" runat="server" href="#" style="color:#6840D9;"></a>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <a id="SuMShare" style="width:38px;width:38px;float:right;margin-top:-46px;padding:4px;margin-right:6px;display:inline !important;" class="animated fadeIn" onclick="androidAPIs.ShareThisPage();">
                <img src="/svg/share.svg" style="width:28px;height:28px;" alt="Share" />
            </a>
        </div>
            <asp:Button ID="LoadMOreChapters" OnClick="LOADMORECHAPTERS" runat="server" style="display:none;visibility:hidden;" />
            <div id="MangaChAMConta" style="display:block;height:fit-content;min-height:100vh !important;padding-bottom:164px !important;min-height:100vh;" runat="server">
            <asp:UpdatePanel ID="LoadChapters" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="LoadMOreChapters" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="TheMangaPhotosF" style="width:100%;height:fit-content;padding-top:6px;" runat="server">
                        </div>
                        <a id="ThreIsMoreACard" onclick="document.getElementById('MainContent_LoadMOreChapters').click(); return false;" runat="server" style="width:100%;height:fit-content;text-align:center !important;margin:0 auto !important;display:block;padding-bottom:130px !important;padding-top:60px !important;" >
                            <p style="color:#FFFFFFEB !important;width:100%;text-align:center !important;margin:0 auto !important;font-size:92%;"><b style="color:#FFFFFFEB;">Tap anywhere for more</b></p>
                            <img src="/svg/expandmore.svg" style="width:46px;height:46px;margin:0 auto !important;margin-top:8px !important;margin-top:-12px !important;" />
                        </a>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            </div>
       </div>
        </div>
        </div>
        </div>
        </div>
    <script>

        var ELMChaptersAndFuncCard = document.getElementById("ChaptersAndFuncCard");
        var ELMFavNWannaContaner = document.getElementById('<%= FavNWannaContaner.ClientID %>');
        ELMChaptersAndFuncCard.style.opacity = "0";
        ELMFavNWannaContaner.style.opacity = "0";
        ELMChaptersAndFuncCard.style.display = "block";
        ELMFavNWannaContaner.style.display = "block";

        document.onreadystatechange = function () {
            if (document.readyState == "interactive") {

                document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();

                var CatXHeight = document.getElementById('<%= CategoryX.ClientID %>').getBoundingClientRect();

                ELMFavNWannaContaner.style.marginTop = (CatXHeight.height - 220) + "px";

                ELMFavNWannaContaner.style.display = "none";
                ELMChaptersAndFuncCard.style.marginTop = (CatXHeight.height - 36) + "px";

                setTimeout(() => {
                    ELMChaptersAndFuncCard.style.display = "none";
                    ELMChaptersAndFuncCard.style.opacity = "1";
                    ELMChaptersAndFuncCard.style.display = "block";
                }, 90);

                setTimeout(() => {
                    ELMFavNWannaContaner.style.marginTop = (CatXHeight.height - 90) + "px";
                    ELMFavNWannaContaner.style.opacity = "1";
                    ELMFavNWannaContaner.style.display = "block";
                    document.getElementById('HiehtFixUpNCHxInfo').style.marginBottom = '96px';
                }, 790);
            }
        };
        /*var UsedLoadMoreOne = false;
        var ChaptersELM = document.getElementById("MainContent_FakeBody");
        ChaptersELM.onscroll = function () {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };

        ChaptersELM.ontouchmove = function () {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };

        ChaptersELM.on('touchmove', TuchMoveLOADMORE);
        function TuchMoveLOADMORE() {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };
        ChaptersELM.on('scroll', scrollMoveLOADMORE);
        function scrollMoveLOADMORE() {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };*/
    </script>
    <script>
        var CatXHeightNCF248C672 = document.getElementById('<%= CategoryX.ClientID %>').getBoundingClientRect();


        var ThisPageScrollContaner = document.getElementById('3rdGBLayer');
        //var ThisPageChangeStartElm = document.getElementById('ScrollHelperFASET204CutG65');
        var SuMMangaTopBarElm = document.getElementById('<%= SuMMangaTopBar.ClientID %>');
            var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
            var InfoCoverWBGF2CSElm = document.getElementById('<%= infoCover.ClientID %>');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MaxScrollHDetected = (CatXHeightNCF248C672.height - 32);
        setTimeout(() => {
            MaxScrollHDetected = (CatXHeightNCF248C672.height - 32);
        }, 1200);


            //var MidWayScrollHDetected = document.getElementById('<%= infoCover.ClientID %>').getBoundingClientRect().height;


        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';
        /*ThisPageScrollContaner.onscroll = function () {

            MaxScrollHDetected = (CatXHeightNCF248C672.height - 32);

            //MidWayScrollHDetected = InfoCoverWBGF2CSElm.getBoundingClientRect().height;

            if (ThisPageScrollContaner.scrollTop >= MaxScrollHDetected) {

                //androidAPIs.DeactivateFullScreenMode();
                androidAPIs.SetDarkStatusBarColor();
                SuMMangaTopBarElm.style.display = 'block';
                InfoCoverWBGF2CSElm.classList.remove('ZoomOutFromInBackground');
                InfoCoverWBGF2CSElm.classList.add('ZoomInBackground');

            } else {

                //androidAPIs.DeactivateFullScreenMode();
                androidAPIs.SetDarkStatusBarColor();
                SuMMangaTopBarElm.style.display = 'none';
                InfoCoverWBGF2CSElm.classList.remove('ZoomInBackground');
                InfoCoverWBGF2CSElm.classList.add('ZoomOutFromInBackground');
            }

            };*/

            var isScrollingSuMRecentsFuncF2CS;
            document.getElementById('3rdGBLayer').onscroll = function () {

                window.clearTimeout(isScrollingSuMRecentsFuncF2CS);

                isScrollingSuMRecentsFuncF2CS = setTimeout(function () {

                    MaxScrollHDetected = (CatXHeightNCF248C672.height - 32);
                    if (ThisPageScrollContaner.scrollTop >= MaxScrollHDetected) {
                        androidAPIs.SetDarkStatusBarColor();
                        SuMMangaTopBarElm.style.display = 'block';
                        InfoCoverWBGF2CSElm.classList.remove('pulse');
                        //InfoCoverWBGF2CSElm.classList.add('pulse');
                    } else {
                        androidAPIs.SetDarkStatusBarColor();
                        SuMMangaTopBarElm.style.display = 'none';
                        InfoCoverWBGF2CSElm.classList.remove('pulse');
                        InfoCoverWBGF2CSElm.classList.add('pulse');
                    }
                }, 10);

            };
    </script>
</asp:Content>
