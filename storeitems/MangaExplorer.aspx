<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" Async="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
        androidAPIs.SetSuMSecureFlag();
        androidAPIs.SetLightStatusBarColor();
        /*var IsFullScreenF248C467 = androidAPIs.SuMIsFullScreen();
        if (IsFullScreenF248C467 == true) {
            androidAPIs.DeactivateFullScreenMode();*/
        androidAPIs.SetLightStatusBarColor();
        //}
        androidAPIs.SetSuMSecureFlag();
        var intervalId = setInterval(function () {
            androidAPIs.SetLightStatusBarColor();
            androidAPIs.SetSuMSecureFlag();
            androidAPIs.SetLightStatusBarColor();
        }, 6000);
        FullScPlaceH.innerText = '1';
        ActivateFuncPerposClickElmF204C90.click();
    </script>
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
        .imagefix2241 {
            margin-left:0px !important;
            margin-right:0px !important;
        }
        .ForceChMaxW {
            max-width:806px !important;
        }
        ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: #ffffff !important;
            opacity: 0.8 !important; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: rgba(255,255,255,0.8) !important;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: rgba(255,255,255,0.8) !important;
        }
        textarea:focus,
        textarea.form-control:focus,
        input.form-control:focus,
        input[type=text]:focus,
        input[type=password]:focus,
        input[type=email]:focus,
        input[type=number]:focus,
        [type=text].form-control:focus,
        [type=password].form-control:focus,
        [type=email].form-control:focus,
        [type=tel].form-control:focus,
        [contenteditable].form-control:focus {
            box-shadow: inset 0 0px 0 #000 !important;
        }
    </style>
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
    <div id="ScriptInjectorC000" style="display:none !important;visibility:hidden !important;"><script>//androidAPIs.ShowSuMToastsOverview('Use full screen mode for a better experience!');</script></div>
    <a onclick="FullScreenModeManager();" id="SuMFullScreenManageBTNF204C90" style="pointer-events:all !important;width:42px;height:42px;display:block;position:fixed !important;z-index:999 !important;float:left !important;margin-left:calc(100% - 42px) !important;margin-top:74px !important;background-color:rgba(0,0,0,0.20) !important;border-top-left-radius:21px;border-bottom-left-radius:21px;border-top-right-radius:0px;border-bottom-right-radius:0px;padding-top:7px;padding-bottom:7px;padding-left:5px !important;padding-right:9px !important;display:none !important;visibility:hidden !important;"><img id="FullScStateIMG" src="/svg/openinfull.svg" style="width:28px;height:28px;margin:0 auto;" /></a>
    <div class="" id="pfc" runat="server" style="background-color:#6840D9;margin:0 auto !important;width:100vw !important;height:100vh !important;">
        <div class="animated fadeInDown shadow-sm" id="InfoCardBGForJAVA" style="position:fixed !important;top:0 !important;z-index:999 !important;background-color:rgb(255,255,255) !important;width:100% !important;height:fit-content;border-radius:20px !important;margin: 0px !important;background-color:#FFF;padding-top:24px;border-top-left-radius:0px !important;border-top-right-radius:0px !important;width:100%;">
                    <div style="width:100% !important;height:fit-content !important;font-size:96%;padding-left:16px !important;padding-top:22px !important;padding-bottom:8px !important;">
                        <a style="display:inline-block !important;font-size:118%;color:rgba(255,255,255,1) !important;" id="SuMExIMGSVG" runat="server"></a>
                        <p id="MangaName" runat="server" style="display:inline-block !important;font-size:118%;color:rgba(0,0,0,1) !important;"></p>
                        <a id="InfoDividerForJAVA" style="width:2px;height:16px;display:inline-block;background-color:rgba(0,0,0,0.54);border-radius:1px;margin-bottom:-2px;margin-right:2px;margin-left:1px;"></a>
                        <p id="ChapterWordForJAVA" style="display:inline-block !important;font-size:98%;color:rgba(0,0,0,0.54) !important;"><b style="font-size:80%;">Chapter</b></p>
                        <p style="display:inline-block !important;font-size:120%;"><b id="ChapterNum" runat="server" style="color:rgba(132,145,162,1);">#num</b></p>
                        <asp:Button ID="HIDDENADDTOFAV" OnClick="AddToFavList" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:Button ID="HIDDEMREMOVEFROMFAV" OnClick="RemoveFromFavList" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:Button ID="UpdateInfo" OnClick="Page_Load" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:UpdatePanel ID="FAVBTNUPDATE" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="HIDDENADDTOFAV" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="HIDDEMREMOVEFROMFAV" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="UpdateInfo" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Panel runat="server">
                                    <a class="animated pulse" id="AddToFavSHOWNBTN" runat="server" style="float:right !important;width:fit-content !important;height:fit-content !important;padding:2px;margin-right:12px !important;"><svg id="FavSVG" xmlns="http://www.w3.org/2000/svg" height="30px" viewBox="0 0 24 24" width="30px" fill="#fffffff0" ><path d="M0 0h24v24H0V0z" fill="none"/><path id="FavPath" d="M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z"/></svg></a>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <script>
                    var SuMSBarHeightFromAndroidAPIsValueF3C1 = androidAPIs.getStatusBarHeight();
                    if (SuMSBarHeightFromAndroidAPIsValueF3C1 == null) {
                        SuMSBarHeightFromAndroidAPIsValueF3C1 = 24;
                    }
                    document.getElementById('InfoCardBGForJAVA').style.paddingTop = (SuMSBarHeightFromAndroidAPIsValueF3C1 + 8) + 'px !important';
                </script>
        <div id="FirstAniDiv" runat="server" class="animated fadeInRight" style="margin:0 auto !important;width:100vw !important;height:100vh !important;overflow-y:scroll;">
            <div id="ThisPageSubContaner" class="nospace ContantDivSuM" style="height:fit-content;width:100vw !important;margin:0 auto !important;max-width:720px !important;background-color:#ffffff !important;margin-top:64px !important;margin-bottom:164px !important;border-radius:20px !important;">
                <div class="" id="TheMangaPhotos" runat="server" style="width:100% !important;height:fit-content !important;margin:0 auto !important;padding:0px !important;border-radius:0px !important;margin-bottom:28px !important;border:none;">

                </div>
                <script>
                    var DetectedThemeColor = null;

                    location.search.substring(1).split("&").forEach(function (val) {

                        var currVal = val.split("=");
                        if (currVal[0] == "TC") {

                            DetectedThemeColor = decodeURI(currVal[1]);

                        }

                    });
                    document.getElementById('InfoDividerForJAVA').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.54");
                    document.getElementById('ChapterWordForJAVA').style.color = DetectedThemeColor.replace("0.74", "0.58");
                    var NewBoredr = 'none'//'2px solid ' + DetectedThemeColor.replace("0.74", "0.18");
                    document.getElementById('<%= TheMangaPhotos.ClientID %>').style.border = NewBoredr;
                    //document.getElementById('InfoCardBGForJAVA').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.18");
                    var BTNELMCOLORFulOp = DetectedThemeColor.replace("0.74", "1");
                    document.getElementById('FavSVG').setAttribute('fill', BTNELMCOLORFulOp);
                    document.getElementById('<%= FAVBTNUPDATE.ClientID %>').style = 'float:right !important;width:fit-content !important;height:fit-content !important;';

                    var FavNOTFILLEDPATH = "M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z";
                    var FavFILLEDPATH = "M13.35 20.13c-.76.69-1.93.69-2.69-.01l-.11-.1C5.3 15.27 1.87 12.16 2 8.28c.06-1.7.93-3.33 2.34-4.29 2.64-1.8 5.9-.96 7.66 1.1 1.76-2.06 5.02-2.91 7.66-1.1 1.41.96 2.28 2.59 2.34 4.29.14 3.88-3.3 6.99-8.55 11.76l-.1.09z";
                    var FavPathElm = document.getElementById('FavPath');
                    var FavFuncKeyBTN = document.getElementById('<%= AddToFavSHOWNBTN.ClientID %>');
                    var ADDTOFAVASPBTN = document.getElementById('<%= HIDDENADDTOFAV.ClientID %>');
                    var REMOVEFROMFAVASPBTN = document.getElementById('<%= HIDDEMREMOVEFROMFAV.ClientID %>');

                    function ADDTOFAV() {
                        ADDTOFAVASPBTN.click();
                        FavFuncKeyBTN.setAttribute("onclick", "REMOVEFROMFAV();");
                        //FavPathElm.setAttribute("d", FavFILLEDPATH);
                        setTimeout(() => {
                            FavPathElm.setAttribute("d", FavFILLEDPATH);
                            document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        }, 720);
                    };

                    function REMOVEFROMFAV() {
                        REMOVEFROMFAVASPBTN.click();
                        FavFuncKeyBTN.setAttribute("onclick", "ADDTOFAV();");
                        //FavPathElm.setAttribute("d", FavNOTFILLEDPATH);
                        setTimeout(() => {
                            FavPathElm.setAttribute("d", FavNOTFILLEDPATH);
                            document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        }, 720);
                    };

                    var UPDATEDCONTANT = false;
                    if (UPDATEDCONTANT == false) {
                        document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        UPDATEDCONTANT = true;
                        androidAPIs.SetSuMSecureFlag();
                    }
                </script>
            </div>
        </div>
        <div id="CommentsSecCont" runat="server" class="animated slideDown GoodBlur" style=" border:4px rgba(225,225,225,0.75) solid;border-top:4px rgba(0,0,0,0) solid;max-height:90%;border-top-right-radius: 22px;border-top-left-radius:22px;background-color:rgba(255,255,255,0.74);display:none;margin-top:30vh;width:100vw;height:fit-content;position:absolute;top:0 !important;padding-top:100vh;z-index:998;">
            <a id="CommentsSecTopPartColor" runat="server" style="margin-top:0px !important;margin:0 auto !important;width:100vw !important;height:fit-content !important;background:rgba(0,0,0,0);padding:0px !important;">
                <h5 class="animated fadeIn" id="ComSecTi" runat="server" style="color:#fff;padding-top:26px;padding-left:22px;padding-bottom:4px;font-size:96%;margin-top:calc(12px - 100vh);">Comments section</h5>
                <div class="animated fadeIn" runat="server" id="SendCommentAria" style="border-radius:12px;width:100%;height:fit-content;margin:0 auto;padding:6px;margin-top:8px;margin-bottom:6px;display:block;">
                    <!--<a style="display:inline;color:#141414;">add a comment...</a>-->
                    <asp:TextBox CssClass="form-control form-control-user" MaxLength="150" runat="server" ID="UserComment" BackColor="Transparent" BorderColor="Transparent" ForeColor="#ffffff" style="display:inline;width:84%;height:74px;" placeholder="add a comment..."></asp:TextBox>
                    <asp:ImageButton OnClick="SendComment" ID="SendBTN" style="background-color:#fff;border-radius:4px;width:38px;height:32px;margin:4px;" ImageAlign="AbsMiddle" ImageUrl="/svg/send.svg" runat="server" />
                </div>
            </a>
            <style>
                .HiddenASPBTN {
                    display:none !important;
                    visibility:hidden !important;
                }
            </style>
            <asp:Button ID="CommentsSecOpenBTN" runat="server" OnClick="LoadCommentsSection" CssClass="HiddenASPBTN" />
            <script type="text/javascript">
                androidAPIs.SetSuMSecureFlag();
                var CommentsSecIsloaded = false;
                var CommentsSecFirstLoad = true;
                var elm = document.getElementById('<%= CommentsSecCont.ClientID %>');
                var NavBarHeightValue6544dfhf645 = androidAPIs.SuMGetNavigationBarHeight();
                elm.style.marginTop = (elm.style.marginTop - document.getElementById('subnavscont2').offsetHeight - NavBarHeightValue6544dfhf645) + 'px';
                function FuncLoadCommentsSec() {
                    if (CommentsSecIsloaded == false) {
                        if (CommentsSecFirstLoad == true) {
                            setTimeout(() => {
                                document.getElementById('<%= CommentsSecOpenBTN.ClientID %>').click();
                                CommentsSecFirstLoad = false;
                            }, 1800);
                        }
                        CommentsSecIsloaded = true;
                        setTimeout(() => {
                            elm.classList.remove('slideDown');
                            elm.classList.add('slideInUp');
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = "block";
                        }, 10);
                    }
                    else {
                        document.getElementById('<%= CommentsSecCont.ClientID %>').style.display = 'none';
                        CommentsSecIsloaded = false;
                        setTimeout(() => {
                            elm.classList.remove('slideInUp');
                            document.getElementById('MainContent_Comments').classList.remove('fadeIn');
                            elm.style.display = 'none';
                            elm.classList.add('slideDown');
                            elm.style.display = 'block';
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = 'none';
                            document.getElementById('MainContent_Comments').classList.add('fadeIn');
                        }, 800);
                    }
                };
            </script>
            <asp:UpdatePanel ID="CommentsSecUpdatePanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SendBTN" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CommentsSecOpenBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="Comments" style="width:calc(100vw - 20px) !important;max-height:calc(70vh - 208px) !important;height:calc(70vh - 208px) !important;overflow-x:hidden;overflow-y:scroll;background-color:#ffffff !important;border-radius:18px;padding-left:12px;padding-right:12px;padding-top:18px;padding-bottom:18px;margin-left:10px;margin-right:10px;margin-top:10px;" runat="server">
                            <div class="animated fadeIn" style="width:100%;height:fit-content;margin-top:calc(35vh - 128px) !important;text-align:center !important;">
                                <a id="dot1" runat="server" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000066;margin-right:12px;"></a>
                                <a id="dot2" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;margin-right:6px;"></a>
                                <a id="dot3" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;"></a>
                            </div>
                            <script>
                                var dot1 = document.getElementById('MainContent_dot1');
                                var dot2 = document.getElementById('dot2');
                                var dot3 = document.getElementById('dot3');
                                var DotsThemeColor = dot1.style.backgroundColor;
                                var Deafultcolor = '#00000029';
                                function AnimationDots123() {
                                    setTimeout(() => {
                                        dot2.style.backgroundColor = DotsThemeColor;
                                        dot1.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 600);
                                    setTimeout(() => {
                                        dot3.style.backgroundColor = DotsThemeColor;
                                        dot2.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1200);
                                    setTimeout(() => {
                                        dot1.style.backgroundColor = DotsThemeColor;
                                        dot3.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1800);

                                    setTimeout(AnimationDots123, 1900);
                                }
                                AnimationDots123();
                                androidAPIs.SetSuMSecureFlag();
                            </script>
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <div class="animated fadeIn" id="NextChapter" style="display:block;position:absolute;top:0;margin-left:calc(100vw - 174px);margin-top:4px;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;" runat="server" >
                <a style="" class="btn btn-primary btn-sm animated shadow-sm fadeInUp" href="#"></a>
            </div>
    </div>
    <p style="display:none !important;visibility:hidden !important;" id="FullScInfoElmPLaceHolder" >0</p>
    <script>
        var FullScPlaceH = document.getElementById('FullScInfoElmPLaceHolder');
        var ThisPageSubContanerElm = document.getElementById('ThisPageSubContaner');
        var InfoCardBGForJAVAElmjusjd5 = document.getElementById('InfoCardBGForJAVA');
        var MangasPhotsosElm = document.getElementById('<%= TheMangaPhotos.ClientID %>');
        var FullScreenImgElm = document.getElementById('FullScStateIMG');
        //
        var viewport = document.querySelector("meta[name=viewport]");
        //var SubConOrWidth = ThisPageSubContanerElm.style.width;
        var PhotosOrBorder = MangasPhotsosElm.style.border;
        function FullScreenModeManager() {
            if (FullScPlaceH.innerText.replace(/\s/g, '') == '0') {
                ThisPageSubContanerElm.style.width = '100vw';
                InfoCardBGForJAVAElmjusjd5.style.display = 'none';
                MangasPhotsosElm.style.width = '100vw';
                MangasPhotsosElm.style.border = null;
                androidAPIs.ActivateFullScreenMode();
                ThisPageSubContanerElm.style.marginTop = '0px';
                ThisPageSubContanerElm.style.borderRadius = '0px';
                MangasPhotsosElm.style.borderRadius = '0px';
                FullScreenImgElm.src = '/svg/closefullscreen.svg';
                FullScPlaceH.innerText = '1';
                HideMangaExplorerBar();
                HideCS5451();
                NextBtnFullSState();
                viewport.setAttribute('content', 'user-scalable=yes, initial-scale=1, maximum-scale=1.6, minimum-scale=1, width=device-width, height=device-height, target-densitydpi=device-dpi');
                androidAPIs.SetSuMSecureFlag();
                MakeSuMFullNavDisa();
            }/*
            else {
                androidAPIs.DeactivateFullScreenMode();
                ThisPageSubContanerElm.style.width = 'calc(100% - 18px)';
                InfoCardBGForJAVAElmjusjd5.style.display = null;
                MangasPhotsosElm.style.width = 'calc(100% - 18px)';
                MangasPhotsosElm.style.border = PhotosOrBorder;
                ThisPageSubContanerElm.style.marginTop = '64px';
                ThisPageSubContanerElm.style.borderRadius = '20px';
                MangasPhotsosElm.style.borderRadius = '20px';
                FullScreenImgElm.src = '/svg/openinfull.svg';
                FullScPlaceH.innerText = '0';
                ShowMangaExplorerBar();
                NextBtnOrState();
                androidAPIs.SetSuMSecureFlag();
                viewport.setAttribute('content', 'user-scalable=no, initial-scale=1, maximum-scale=1, minimum-scale=1, width=device-width, height=device-height, target-densitydpi=device-dpi');
            }*/
        }
        function HideCS5451() {
            document.getElementById('<%= CommentsSecCont.ClientID %>').style.display = 'none';
            CommentsSecIsloaded = false;
            elm.style.display = 'none';
            elm.classList.remove('slideInUp');
            document.getElementById('MainContent_Comments').classList.remove('fadeIn');
            elm.classList.add('slideDown');
            document.getElementById('MainContent_Comments').classList.add('fadeIn');
        }
        androidAPIs.SetSuMSecureFlag();
        /*var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            document.getElementById('FullScInfoElmPLaceHolder').innerText = '0';
            FullScreenModeManager();
            androidAPIs.ActivateFullScreenMode();
            androidAPIs.SetSuMSecureFlag();
            MakeSuMFullNavDisa();
            setTimeout(() => {
                MakeSuMFullNavDisa();
            }, 10);
            FullScreenModeManager();
            FullScreenModeManager();
        }*/
        androidAPIs.SetSuMSecureFlag();
    </script>
    <script>
        var ReactimntIsPermitedF565C0 = true;
        var ThisPageScrollContaner = document.getElementById('<%= FirstAniDiv.ClientID %>');
        var ThisPageChangeStartElm = document.getElementById('InfoCardBGForJAVA');
        var SuMMangaTopBarElm = document.getElementById('SuMMangaTopBar');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MangasContF212C01 = document.getElementById('<%= TheMangaPhotos.ClientID %>');
        var MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight + StatusBarHeightValueFromAPIs + 2;
        setTimeout(() => {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight + StatusBarHeightValueFromAPIs + 2;
        }, 1200);
        var SuMReadingModeIsApplyed = false;
        MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        ThisPageChangeStartElm.classList.remove('fadeOutUp');
        ThisPageChangeStartElm.classList.add('fadeInDown');
        ThisPageChangeStartElm.style.display = 'block';

        var SuMLastScrollTop = 0;
        var isScrollingSuMRecentsFuncF3CS;
        document.getElementById('<%= FirstAniDiv.ClientID %>').onscroll = function () {

            window.clearTimeout(isScrollingSuMRecentsFuncF3CS);

            isScrollingSuMRecentsFuncF3CS = setTimeout(function () {

                if (ThisPageScrollContaner.scrollTop > SuMLastScrollTop) {
                    if (SuMReadingModeIsApplyed == false) {
                        ThisPageSubContanerElm.style.width = '100vw';
                        InfoCardBGForJAVAElmjusjd5.style.display = 'none';
                        MangasPhotsosElm.style.width = '100vw';
                        MangasPhotsosElm.style.border = null;
                        ThisPageSubContanerElm.style.marginTop = '0px';
                        ThisPageSubContanerElm.style.marginBottom = '0px';
                        ThisPageSubContanerElm.style.borderRadius = '0px';
                        MangasPhotsosElm.style.borderRadius = '0px';
                        MangasContF212C01.style.marginBottom = '0px !important';
                        FullScreenImgElm.src = '/svg/closefullscreen.svg';
                        androidAPIs.ActivateFullScreenMode();
                        FullScPlaceH.innerText = '1';
                        HideMangaExplorerBar();
                        HideMangaExplorerTopPartBar();
                        HideCS5451();
                        NextBtnFullSState();
                        viewport.setAttribute('content', 'user-scalable=yes, initial-scale=1, maximum-scale=1.6, minimum-scale=1, width=device-width, height=device-height, target-densitydpi=device-dpi');
                        androidAPIs.SetSuMSecureFlag();
                        androidAPIs.SetLightStatusBarColor();
                        MakeSuMFullNavDisa();
                        androidAPIs.ActivateFullScreenMode();
                        SuMReadingModeIsApplyed = true;
                    }
                }
                else {
                    if (SuMReadingModeIsApplyed == true) {
                        androidAPIs.DeactivateFullScreenMode();
                        ThisPageSubContanerElm.style.borderRadius = '20px';
                        FullScPlaceH.innerText = '0';
                        MangasContF212C01.style.marginBottom = '28px !important';
                        InfoCardBGForJAVAElmjusjd5.classList.remove('fadeOutUp');
                        InfoCardBGForJAVAElmjusjd5.classList.add('fadeInDown');
                        InfoCardBGForJAVAElmjusjd5.style.visibility = null;
                        InfoCardBGForJAVAElmjusjd5.style.display = 'block';
                        ShowMangaExplorerBar();
                        NextBtnOrState();
                        androidAPIs.SetSuMSecureFlag();
                        androidAPIs.SetLightStatusBarColor();
                        viewport.setAttribute('content', 'user-scalable=no, initial-scale=1, maximum-scale=1, minimum-scale=1, width=device-width, height=device-height, target-densitydpi=device-dpi');
                        ReactimntIsPermitedF565C0 = true;
                        SuMReadingModeIsApplyed = false;
                    }
                }
                SuMLastScrollTop = ThisPageScrollContaner.scrollTop;

            }, 20);

        };
        var MangaExplorerTopPartBarElm = document.getElementById('InfoCardBGForJAVA');

        document.getElementById('InfoCardBGForJAVA').style.display = 'block';
        if (document.getElementById('InfoCardBGForJAVA').classList.contains('fadeInDown') == false || document.getElementById('InfoCardBGForJAVA').classList.contains('fadeOutUp') == true) {
            document.getElementById('InfoCardBGForJAVA').classList.remove('fadeOutUp');
            document.getElementById('InfoCardBGForJAVA').classList.add('fadeInDown');
        }

        function HideMangaExplorerTopPartBar() {
            //if (MangaExplorerTopPartBarElm.classList.contains('fadeInDown') == true || MangaExplorerTopPartBarElm.classList.contains('fadeOutUp') == false) {
            document.getElementById('InfoCardBGForJAVA').classList.remove('fadeInDown');
            if (document.getElementById('InfoCardBGForJAVA').classList.contains('fadeOutUp') == false) {
                document.getElementById('InfoCardBGForJAVA').classList.add('fadeOutUp');
            }
            setTimeout(() => {
                document.getElementById('InfoCardBGForJAVA').style.display = 'none';
            }, 360);
            //}
        }

        androidAPIs.SetLightStatusBarColor();
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
            setTimeout(() => {
                androidAPIs.SetLightStatusBarColor();
                setTimeout(() => {
                    androidAPIs.SetLightStatusBarColor();
                    setTimeout(() => {
                        androidAPIs.SetLightStatusBarColor();
                        setTimeout(() => {
                            androidAPIs.SetLightStatusBarColor();
                            setTimeout(() => {
                                androidAPIs.SetLightStatusBarColor();
                                setTimeout(() => {
                                    androidAPIs.SetLightStatusBarColor();
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</asp:Content>