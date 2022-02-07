<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
            androidAPIs.SetLightStatusBarColor();
        }
        androidAPIs.SetLightStatusBarColor();
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
        }, 420);
    </script>
    <asp:Button ID="UpdatePageContant" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden !important" />
    <div id="SettingsUnavaliblePOPUP" runat="server" style="animation-duration:0.36s !important;background-color:rgba(0,0,0,0.32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center animated fadeIn">
        <div id="SUAC000SP" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">This option is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:rgba(0, 0, 0, 0.527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather there is a bug therefore its temporarily disabled or your device does not support it.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
    <div id="ThisPageSBarFixUpPropElm" style="background-color:rgb(242,242,242) !important;width:100vw;height:100vh;padding-top:24px !important;">
    <div id="LibCatTopPart" runat="server" class="animated fadeIn" style="animation-duration:0.32s !important;width:100vw;height:fit-content;background-color:rgb(242,242,242);text-align:center;padding-top:6px;padding-bottom:2px;position:fixed !important;padding-top:0px !important;">
        <div style="width:fit-content;height:fit-content;background-color:rgba(255,255,255,0.74);border:2px solid rgba(255,255,255,0.92);border-radius:23px;margin:0 auto !important;padding-top:3px;padding-bottom:3px;padding-left:8px;padding-right:8px;text-align:center;margin-top:8px !important;">
            <a class="" id="cr" style="display:inline-block; background-color:rgba(104,64,217,0.94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(255,255,255,0.80);" runat="server" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Curr', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Curr'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Curr'; }" href="#"><b style="font-size:90%">Currently</b></a>
            <a class="" id="mf" runat="server" style="background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Fav', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Fav'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Fav'; }" href="#"><b style="font-size:98%">Favorites</b></a>
            <a class="" id="wr" runat="server" style="margin-right:3px;color:#1d1d1d;" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Wanna', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Wanna'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Wanna'; }" href="#"><b style="font-size:90%">Want To</b></a>
        </div>
        <div class="animated fadeIn" id="infocard" runat="server" style="margin:0 auto;padding:22px !important;animation-duration:0.32s !important;width:100vw;height:fit-content;margin-top:16px;margin-bottom:18px;display:block !important;position:relative !important;z-index:999 !important;max-width:720px !important;">
            <img id="InfoIMG" src="/svg/info.svg" style="width:86px;height:86px;float:left;margin-top:0px !important;margin-left:18px;margin-left:-8px !important;display:block !important;" />
            <p id="InfoAboutC" runat="server" style="padding-left:4px !important;padding-right:20px !important;padding-top:8px;width:calc(100% - 126px) !important;display:inline;height:fit-content;color:#00000066;font-size:78%;text-align:center !important;">DESC</p>
        </div>
    </div>
   <div runat="server" class="animated slideInUp" id="ShowReqContantContaner" style="margin:0 auto;animation-duration:0.96s !important;background-color:#ffffff !important;height:fit-content !important;overflow-y:scroll !important;overflow-x:clip;border-top-left-radius:22px;border-top-right-radius:22px;margin-top:68px !important;padding-top:12px;padding-left:6px;padding-right:6px;padding-bottom:116px !important;min-height:calc(100vh - 76px) !important;max-width:720px !important;position:relative !important;" >
        <asp:UpdatePanel ID="UpdateCOntant990" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="UpdatePageContant" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="ShowReqContant" runat="server" style="width:100%;height:fit-content;">
                        </div>
                        <div id="ShowIFmoreCont" style="width:100%;height:fit-content;margin:0 auto !important;text-align:center !important;display:none !important;visibility:hidden !important;">
                            <p style="color:#000000EB !important;width:100%;text-align:center !important;margin:0 auto !important;font-size:92%;"><b style="color:#FFFFFFEB;">Tap anywhere for more</b></p>
                            <img src="/svg/expandmoreTBlack.svg" style="width:46px;height:46px;margin:0 auto !important;margin-top:8px !important;margin-top:-12px !important;" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
   </div>
        <script>
            document.getElementById('<%= ShowReqContantContaner.ClientID %>').style.marginTop = (document.getElementById('<%= LibCatTopPart.ClientID %>').offsetHeight - 24) + 'px';
            document.getElementById('InfoIMG').marginTop = ((document.getElementById('<%= InfoAboutC.ClientID %>').offsetHeight / 2) - (document.getElementById('InfoIMG').offsetHeight / 2)) + 'px';
            setTimeout(() => {
                document.getElementById('<%= UpdatePageContant.ClientID %>').click();
            }, 80);
        </script>
    </div>
    <script>
        var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
        var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
        ThisPageSBarFixUpPropElmVar.style.paddingTop = (StatusBarHeightValue) + 'px !important';
    </script>
</asp:Content>