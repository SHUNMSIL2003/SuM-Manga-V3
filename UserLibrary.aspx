<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        /*var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();*/
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        //}
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        setTimeout(() => {
            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        }, 420);
    </script>
    <asp:Button ID="UpdatePageContant" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden !important" />
    <div id="SettingsUnavaliblePOPUP" runat="server" style="animation-duration:0.36s !important;background-color:var(--SuMDBlackOP32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center animated fadeIn">
        <div id="SUAC000SP" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:var(--SuMDWhite);vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">This option is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:var(--SuMDBlackOP527);background-color:var(--SuMDBlackOP527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:var(--SuMDBlackOP527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather there is a bug therefore its temporarily disabled or your device does not support it.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:var(--SuMThemeColor);color:var(--SuMDWhite);border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
    <div id="ThisPageSBarFixUpPropElm" style="background-color:var(--SuMDGray) !important;width:100vw;height:100vh;padding-top:24px !important;">
    <div id="LibraryTopPartHeightValueHelper" style="height:fit-content;width:100%;margin:0 auto !important;">
        <div id="LibCatTopPart" runat="server" class="animated fadeIn" style="animation-duration:0.32s !important;width:100vw;height:fit-content;background-color:var(--SuMDGray);text-align:center;padding-top:6px;padding-bottom:2px;position:fixed !important;padding-top:0px !important;">
            <div style="width:fit-content;height:fit-content;background-color:var(--SuMDWhiteOP74);border:2px solid var(--SuMDWhiteOP92);border-radius:23px;margin:0 auto !important;padding-top:3px;padding-bottom:3px;padding-left:8px;padding-right:8px;text-align:center;margin-top:8px !important;">
                <a class="" id="cr" style="display:inline-block; background-color:var(--SuMThemeColorOP94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:var(--SuMDWhiteOP80);" runat="server" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Curr', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Curr'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Curr'; }" href="#"><b style="font-size:90%">Currently</b></a>
                <a class="" id="mf" runat="server" style="background-color:var(--SuMThemeColorOP00);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:var(--SuMDBlackOP60);" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Fav', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Fav'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Fav'; }" href="#"><b style="font-size:98%">Favorites</b></a>
                <a class="" id="wr" runat="server" style="margin-right:3px;color:#1d1d1d;" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Wanna', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Wanna'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Wanna'; }" href="#"><b style="font-size:90%">Want To</b></a>
            </div>
            <div class="animated fadeIn" id="infocard" runat="server" style="margin:0 auto;padding:22px !important;animation-duration:0.32s !important;width:100vw;height:fit-content;margin-top:16px;margin-bottom:18px;display:block !important;position:relative !important;z-index:999 !important;max-width:720px !important;">
                <svg id="InfoIMG" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width:86px;height:86px;float:left;margin-top:0px !important;margin-left:18px;margin-left:-8px !important;display:block !important;" fill="var(--SuMDBlackOP50)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 15c-.55 0-1-.45-1-1v-4c0-.55.45-1 1-1s1 .45 1 1v4c0 .55-.45 1-1 1zm1-8h-2V7h2v2z"/></svg>
                <p id="InfoAboutC" runat="server" style="padding-left:4px !important;padding-right:20px !important;padding-top:8px;width:calc(100% - 126px) !important;display:inline;height:fit-content;color:var(--SuMDBlackOP50);font-size:78%;text-align:center !important;">DESC</p>
            </div>
        </div>
    </div>
   <div runat="server" class="animated fadeInUp" id="ShowReqContantContaner" style="margin:0 auto !important;margin-top:206px !important; overflow-x: clip; border-radius: 20px; padding-top: 12px; padding-left: 6px; padding-right: 6px; animation-duration: 0.96s !important; background-color: var(--SuMDWhite) !important;overflow-y: scroll !important;height:calc(100vh - 386px); max-width: 720px !important; position: relative !important;width:calc(100% - 24px);margin-left:12px;border:0.5px var(--SuMDBroderC) solid !important;" >
        <asp:UpdatePanel ID="UpdateCOntant990" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="UpdatePageContant" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="ShowReqContant" runat="server" style="width:100%;height:fit-content;">
                        </div>
                        <script type="text/javascript">
                            setTimeout(() => {
                                SuMFixUpUserLibraryHeight();
                            }, 180);
                        </script>
                        <div id="ShowIFmoreCont" style="width:100%;height:fit-content;margin:0 auto !important;text-align:center !important;display:none !important;visibility:hidden !important;">
                            <p style="color:var(--SuMDBlackOP92) !important;width:100%;text-align:center !important;margin:0 auto !important;font-size:92%;"><b style="color:var(--SuMDWhiteOP92);">Tap anywhere for more</b></p>
                            <img src="/svg/expandmoreTBlack.svg" style="width:46px;height:46px;margin:0 auto !important;margin-top:8px !important;margin-top:-12px !important;" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
   </div>
        <script>
            document.getElementById('<%= ShowReqContantContaner.ClientID %>').style.marginTop = (document.getElementById('<%= LibCatTopPart.ClientID %>').offsetHeight - 24) + 'px !important';
            document.getElementById('InfoIMG').marginTop = ((document.getElementById('<%= InfoAboutC.ClientID %>').offsetHeight / 2) - (document.getElementById('InfoIMG').offsetHeight / 2)) + 'px';
            setTimeout(() => {
                document.getElementById('<%= UpdatePageContant.ClientID %>').click();
            }, 80);

            function SuMFixUpUserLibraryHeight() {
                var TopPartHeightF4C0 = document.getElementById('<%= LibCatTopPart.ClientID %>').getBoundingClientRect().height + 2;
                var BottomPartHeightF4C0 = GetSuMWebNavBarHeight();
                document.getElementById('<%= ShowReqContantContaner.ClientID %>').style.height = "calc(100vh - " + (TopPartHeightF4C0 + BottomPartHeightF4C0 + 24) + "px)";
            };

            SuMFixUpUserLibraryHeight();
        </script>
    </div>
    <script>
        var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
        var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
        if (StatusBarHeightValue == null) {
            StatusBarHeightValue = 12;
        }
        ThisPageSBarFixUpPropElmVar.style.paddingTop = (StatusBarHeightValue) + 'px !important';
        document.getElementById('<%= ShowReqContantContaner.ClientID %>').style.minHeight = 'calc(100vh - ' + (76 + 24 + StatusBarHeightValue) + 'px) !important';
    </script>
    <script>
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        setTimeout(() => {
            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
            setTimeout(() => {
                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                setTimeout(() => {
                    if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                    setTimeout(() => {
                        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                        setTimeout(() => {
                            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                            setTimeout(() => {
                                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                                setTimeout(() => {
                                    if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                                    setTimeout(() => {
                                        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                                    }, 10000);
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</asp:Content>