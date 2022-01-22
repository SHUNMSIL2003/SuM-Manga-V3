<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="SettingsUnavaliblePOPUP" runat="server" style="animation-duration:0.36s !important;background-color:rgba(0,0,0,0.32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center animated fadeIn">
        <div id="SUAC000SP" class="animated zoomIn card shadow-sm" style="animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">This option is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:rgba(0, 0, 0, 0.527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather there is a bug therefore its temporarily disabled or your device does not support it.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;">OK</a>
            </div>
        </div>
    </div>
    <div style="background-color:rgb(242,242,242) !important;width:100vw;height:100vh;">
    <div id="LibCatTopPart" class="animated fadeIn" style="animation-duration:0.32s !important;width:100vw;height:fit-content;background-color:rgb(242,242,242);text-align:center;padding-top:6px;padding-bottom:2px;position:fixed !important;">
        <div style="width:fit-content;height:fit-content;background-color:rgba(255,255,255,0.74);border:2px solid rgba(255,255,255,0.92);border-radius:23px;margin:0 auto !important;padding-top:3px;padding-bottom:3px;padding-left:8px;padding-right:8px;text-align:center;margin-top:8px !important;">
            <a class="" id="cr" style="display:inline-block; background-color:rgb(104,64,217,0.94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(255,255,255,0.80);" runat="server" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Curr', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Curr'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Curr'; }" href="#"><b style="font-size:90%">Currently</b></a>
            <a class="" id="mf" runat="server" style="background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);" onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" href="#"><b style="font-size:98%">Favorites</b></a>
            <a class="" id="wr" runat="server" style="margin-right:3px;color:#1d1d1d;" onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" href="#"><b style="font-size:90%">Want To</b></a>
        </div>
        <div class="animated fadeIn" id="infocard" style="padding:22px !important;animation-duration:0.32s !important;width:100vw;height:fit-content;margin-top:16px;margin-bottom:18px;display:block !important;position:relative !important;z-index:999 !important;">
            <img id="InfoIMG" src="/svg/info.svg" style="width:86px;height:86px;float:left;margin-top:0px !important;margin-left:18px;margin-left:-8px !important;display:block !important;" />
            <p id="InfoAboutC" runat="server" style="padding-left:4px !important;padding-right:20px !important;padding-top:8px;width:calc(100% - 126px) !important;display:inline;height:fit-content;color:#00000066;font-size:78%;text-align:center !important;">DESC</p>
        </div>
    </div>
    <div class="animated slideInUp" id="ShowReqContant" style="animation-duration:0.96s !important;background-color:#ffffff !important;height:fit-content !important;overflow-y:scroll !important;overflow-x:clip;border-top-left-radius:22px;border-top-right-radius:22px;margin-top:68px !important;padding-top:12px;padding-left:6px;padding-right:6px;padding-bottom:116px !important;min-height:calc(100vh - 76px) !important;" runat="server">
    </div>
        <script>
            document.getElementById('<%= ShowReqContant.ClientID %>').style.marginTop = document.getElementById('LibCatTopPart').offsetHeight + 'px';
            document.getElementById('InfoIMG').marginTop = ((document.getElementById('<%= InfoAboutC.ClientID %>').offsetHeight / 2) - (document.getElementById('InfoIMG').offsetHeight / 2)) + 'px';
        </script>
    </div>
</asp:Content>