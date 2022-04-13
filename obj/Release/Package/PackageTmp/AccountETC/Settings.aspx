<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.Settings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        a {
            pointer-events: all;
        }
        slideInDown{
            animation-duration:0.4s !important;
        }
    </style><!-- 
    <a id="DebugSettings" runat="server">

    </a>
    <a id="RootDebug" runat="server">

    </a> -->
    <div style="background-color:transparent !important;width:100% !important;height:24px;position:fixed !important;top:0 !important;z-index:997 !important;" id="SuMSettingStatausBarHelperF000C000"></div>
    <asp:Button ID="EnablePreMode" runat="server" OnClick="SavePreformanceSettingCookie" style="display:none !important;visibility:hidden;" />
    <asp:Button ID="DisablePreMode" runat="server" OnClick="RemovePreformanceSettingCookie" style="display:none !important;visibility:hidden;" />
    <asp:Button ID="FixUpPageRe" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
    <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomPFP" runat="server" HiddenField="true" />
    <asp:FileUpload onchange="loadFile2(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomBanner" runat="server" HiddenField="true" />
    <div id="SettingsUnavaliblePOPUP" runat="server" style=" animation-duration:0.36s !important;background-color:var(--SuMDBlackOP32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center animated fadeIn GoodBlur">
        <div id="SUAC000SP" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:var(--SuMDWhite);vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">This option is unavalible</p>
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
            <p style="width:80% !important;margin:0 auto;color:var(--SuMDBlackOP527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather there is a bug therefore its temporarily disabled or your device does not support it.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:var(--SuMThemeColor);color:var(--SuMDWhite);border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
                        <div id="SuMRnadomScrollHelper" style="scroll-snap-type: y mandatory;height:100vh;width:100vw; padding:0px !important;padding-top:0px !important;padding-bottom:8px !important; background-color:transparent !important;margin:0 auto !important; margin-top:0px !important;">
    <div style="scroll-margin-top:32px !important;scroll-margin-bottom:32px !important; height:100vh !important;width:100vw;max-width:720px !important;margin:0 auto !important;height: 100vh;scroll-snap-type: y proximity !important; scroll-behavior: smooth !important; scroll-padding-top:32px !important;scroll-padding-bottom:32px !important;padding-bottom:164px !important;padding-top:64px !important;">
        <div style="width:100% !important;height:12px;margin:0 auto !important;" id="SuMStatusBarHeightFixUpF0C0"></div>
    <script>
        var StatusBarHeightValueFromSuMAndroidAPIsF0C0 = 24;
        if ("androidAPIs" in window == true) {
            StatusBarHeightValueFromSuMAndroidAPIsF0C0 = androidAPIs.getStatusBarHeight();
        }
        document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C0) + 'px';
    </script>
    <div id="ThisPageSBarFixUpPropElm" style="width:100%;height:0px;background-color:transparent !important;display:block;"></div>
        <script>
            var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
            var StatusBarHeightValue = 24;
            if ("androidAPIs" in window == true) {
                StatusBarHeightValue = androidAPIs.getStatusBarHeight();
            }
            if (StatusBarHeightValue != null) {
                ThisPageSBarFixUpPropElmVar.style.height = (StatusBarHeightValue + 12) + 'px !important';
            }
            else {
                ThisPageSBarFixUpPropElmVar.style.height = (24 + 12) + 'px !important';
            }
        </script>
    <div id="SlideDownCard" runat="server" style="animation-duration:0.26s !important;width:calc(100% - 24px); padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:var(--SuMDWhite) !important;margin:0 auto !important;margin:12px !important;border-radius:20px !important;padding:0px !important;margin-bottom:0px !important;border:0.5px var(--SuMDBroderC) solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;" class="animated slideInDown">
        <asp:UpdatePanel ID="ProfileInfoUpdatepANEL" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="EnablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DisablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="FixUpPageRe" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
        <div id="ThisPageMaxNoShowScrool" runat="server" style="background-color:var(--SuMThemeColorOP74) !important;border-radius:20px !important;width:100%;margin:0 auto !important;padding:16px !important;margin-top:0px !important; margin-bottom:0px !important;z-index:998;position:relative;">
            <a runat="server" id="AccountSettingsOrLogin" onclick="" href="/AccountETC/LoginETC.aspx" style="height:112px !important;width:calc(100% - 60px) !important;background-color:transparent !important;display:block !important;margin-top:8px;margin-bottom:8px; margin-left:8px;position:relative;z-index:998;">
            <div style="width:86px;height:86px;border-radius:50%;background-color:var(--SuMDWhite);border:2px solid var(--SuMDWhite) !important;float:left;display:inline;margin-bottom:4px;padding:0px !important;">
                <img class="animated pulse" id="PFP" runat="server" style="width:82px !important;height:82px !important;border-radius:50% !important;" src="/AccountETC/UsersUploads/DeafultPFP.jpg" />
            </div>
                <div id="UserInfoDiv" runat="server" class="fadeIn animated" style="float:left;display:inline;margin-left:8px;padding-top:12px !important;width:calc(100% - 94px) !important;">
                    <h3 id="SuMUserName" runat="server" style="color:rgb(255,255,255);margin-left:12px;width:fit-content;max-width:100% !important;white-space:nowrap !important;overflow:hidden;text-overflow:ellipsis !important;">Login to SuM</h3>
                    <h6 id="SignedWith" runat="server" style="color:rgba(255,255,2550.86);font-size:74%;margin-left:12px;width:fit-content;max-width:100% !important;white-space:nowrap !important;overflow:hidden;text-overflow:ellipsis !important;"></h6>
                </div>
            </a>
            <asp:ImageButton ID="LogOutBTN" runat="server" ImageUrl="/svg/logoutW.svg" Width="28px" Height="28px" BackColor="Transparent" ForeColor="Transparent" OnClick="LogOut" style="float:right !important;margin-right:8px;margin-top:-22px !important;" />
            <p id="TapForXText" runat="server" style="color:rgba(255,255,2550.64);margin-top:-18px;width:100%;text-align:center;font-size:76%;margin-left:42px;padding-bottom:-16px;">Tap for more!</p>
        </div>
                        <p style="display:none !important;visibility:hidden !important;object-fit: cover;" id="CurrUserBannerPlaceHolder" runat="server">/svg/add.svg</p>
        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div runat="server" id="UserSettingsCards" class="" style="display:block;height:0px;overflow:hidden;transition: height 0.4s;background-color:var(--SuMDWhite);padding:0px;">
            <div style="width:100%;height:fit-content;padding: 18px 6px 12px;display:block;">
            <div style="width:100% !important;height:100% !important;background-color:var(--SuMDWhite) !important;padding:8px;">

                        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:var(--SuMDWhite) !important;margin-top:0px !important;width:100vw;height:fit-content;">
                                <div onclick="SuMSettingDivExpandor('PFPDiv');" class="card-header py-3" style="background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                    <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><g><path d="M0,0h24v24H0V0z" fill="none"/></g><g><path d="M10.25,13c0,0.69-0.56,1.25-1.25,1.25S7.75,13.69,7.75,13S8.31,11.75,9,11.75S10.25,12.31,10.25,13z M15,11.75 c-0.69,0-1.25,0.56-1.25,1.25s0.56,1.25,1.25,1.25s1.25-0.56,1.25-1.25S15.69,11.75,15,11.75z M22,12c0,5.52-4.48,10-10,10 S2,17.52,2,12S6.48,2,12,2S22,6.48,22,12z M20,12c0-0.78-0.12-1.53-0.33-2.24C18.97,9.91,18.25,10,17.5,10 c-3.13,0-5.92-1.44-7.76-3.69C8.69,8.87,6.6,10.88,4,11.86C4.01,11.9,4,11.95,4,12c0,4.41,3.59,8,8,8S20,16.41,20,12z"/></g></svg>
                                    <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Profile Pic & Banner</p>
                                </div>
                                <div id="PFPDiv" runat="server" class="card-body text-center animated slideInDown" style="animation-duration: 0.4s !important;background-color:var(--SuMDWhite) !important;display:none;height:fit-content;position:relative;z-index:996;width: calc(100% - 32px);">
                                    <div style="width:100%;max-width:740px;height:fit-content;position:relative;margin:0 auto !important;padding-left:-12px !important;display:block;">
                                    <a onclick="document.getElementById('MainContent_SuMCustomPFP').click();" style="width:fit-content;height:fit-content;">
                                    <img style="position:relative !important;z-index:999 !important;" class="rounded-circle mb-3 mt-4 lazyload" id="PFPC" src="/assets/img/avatars/DeafultPFP.jpg" width="160" height="160" runat="server">
                                        <script>
                                            document.getElementById('<%= PFPC.ClientID %>').src = document.getElementById('<%= PFP.ClientID %>').src;
                                        </script>
                                    </a>
                                    <div class="mb-3">
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="chpfp000" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFP" Text="Save Pic" />
                                        <p style="display:inline-block !important;"> Or </p>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="RemovePFP" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFPAtRandom" Text="Reset PFP" />
                                    </div>
                                    <script>
                                        var loadFile = function (event) {
                                            var image = document.getElementById('MainContent_PFPC');
                                            image.src = URL.createObjectURL(event.target.files[0]);
                                        };
                                    </script>
                                    <!-- New Banner -->
                                    <a onclick="document.getElementById('MainContent_SuMCustomBanner').click();" style="width:fit-content;height:fit-content;">
                                    <img style="position:relative !important;z-index:999 !important;width:calc(100% - 64px);border-radius:18px;background-color:var(--SuMThemeColorOP32);height:132px;margin-bottom:18px;margin-top:32px;background-size:cover; background-position:center;object-fit: cover;" class="lazyload" id="BannerPr" runat="server" src="/svg/add.svg">
                                        <script>
                                            document.getElementById('<%= BannerPr.ClientID %>').src = document.getElementById('<%= CurrUserBannerPlaceHolder.ClientID %>').innerText;
                                        </script>
                                    </a>
                                    <div class="mb-3">
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="ChangeBannerBTN" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangeUserBanner" Text="Save Banner" />
                                        <p style="display:inline-block !important;"> Or </p>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="RemoveBannerBTN" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="RemoveBanner" Text="Remove Banner" />
                                    </div>
                                    <script>
                                        document.getElementById('<%= ChangeBannerBTN.ClientID %>').addEventListener("click", function () {
                                            setTimeout(() => {
                                                DeleteSuMCache();
                                            }, 180);
                                        });
                                        document.getElementById('<%= RemoveBannerBTN.ClientID %>').addEventListener("click", function () {
                                            setTimeout(() => {
                                                DeleteSuMCache();
                                            }, 20);
                                        });
                                        var loadFile2 = function (event) {
                                            var image2 = document.getElementById('<%= BannerPr.ClientID %>');
                                            image2.src = URL.createObjectURL(event.target.files[0]);
                                        };
                                    </script>

                                   </div>

                                </div>
                        </div>
                <!-- Device Manege fucherdsafsd -->
                <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:var(--SuMDWhite) !important;margin-top:0px !important;display:none !important;">
                    <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
                    <div onclick="if (document.getElementById('ManageDevicesCard').style.display == 'none') { document.getElementById('ManageDevicesCard').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('ManageDevicesCard').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('ManageDevicesCard').offsetHeight + 'px'; document.getElementById('ManageDevicesCard').style.display = 'none'; }" class="card-header py-3" style="background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                        <img src="/svg/devices.svg" style="width:26px;height:26px;display:inline;float:left;" />
                        <p style="color:var(--SuMDBlack) !important;display:inline;float:left;margin:8px;">Manage Devices</p>
                    </div>
                    <div class="" style="animation-duration: 0.4s !important;background-color:var(--SuMDWhite) !important;display:none;height:fit-content;position:relative;z-index:996" id="ManageDevicesCard">
                        <p id="DVsText" style="color:var(--SuMDBlack);"><b id="DevicesNum" style="color:var(--SuMThemeColor);" runat="server" ></b> Device(s) loged in</p>
                        <div style="width:100vw;height:fit-content;" id="CurrDevice">
                            <img src="/svg/phonePR.svg" width="24" height="24" style="display:inline;" />
                            <p style="color:var(--SuMThemeColor);display:inline;">Current Device</p>
                            <p style="color:#251d37b2;font-size:80%;" id="CurrDeviceDate" runat="server"></p>
                        </div>
                         <div style="width:100vw;height:fit-content;" id="SecDevice" runat="server">
                            <img src="/svg/phone.svg" width="24" height="24" style="display:inline;" />
                            <p style="color:var(--SuMThemeColor);display:inline;">Second Device</p>
                            <p style="color:#251d37b2;font-size:80%;" id="SecDeviceDate" runat="server"></p>
                        </div>
                    </div>
                </div>
        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:var(--SuMDWhite) !important;margin-top:0px !important;" class="">
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                                        <div onclick="SuMSettingDivExpandor('ChangeEmailDiv');" class="card-header py-3" style="background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                            <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><g><rect fill="none" height="24" width="24"/></g><g><g><g><g><path d="M21,10V4c0-1.1-0.9-2-2-2H3C1.9,2,1.01,2.9,1.01,4L1,16c0,1.1,0.9,2,2,2h11v-5c0-1.66,1.34-3,3-3H21z M11.53,10.67 c-0.32,0.2-0.74,0.2-1.06,0L3.4,6.25C3.15,6.09,3,5.82,3,5.53c0-0.67,0.73-1.07,1.3-0.72L11,9l6.7-4.19 C18.27,4.46,19,4.86,19,5.53c0,0.29-0.15,0.56-0.4,0.72L11.53,10.67z"/><path d="M22,14c-0.55,0-1,0.45-1,1v3c0,1.1-0.9,2-2,2s-2-0.9-2-2v-4.5c0-0.28,0.22-0.5,0.5-0.5s0.5,0.22,0.5,0.5V17 c0,0.55,0.45,1,1,1s1-0.45,1-1v-3.5c0-1.38-1.12-2.5-2.5-2.5S15,12.12,15,13.5V18c0,2.21,1.79,4,4,4s4-1.79,4-4v-3 C23,14.45,22.55,14,22,14z"/></g></g></g></g></svg>
                                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Change Email</p>
                                        </div>
                                        <div runat="server" id="ChangeEmailDiv" class="card-body animated fadeInDown" style="animation-duration: 0.4s !important;background-color:var(--SuMDWhite) !important;display:none;position:relative;z-index:996;">
                                            <div>
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="username"><strong>Username (Unchangeable!)</strong></label><input class="form-control" type="text" id="UserNameEP" placeholder="username" name="username" runat="server"></div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="email"><strong>Change Email Address</strong></label><input class="form-control" type="email" id="EmailEP" placeholder="user@example.com" name="email" runat="server"></div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="first_name"><strong>Password (To Save changes !)</strong></label><input class="form-control" type="text" id="first_name" placeholder="Password" name="first_name"></div>
                                                    </div>
                                                </div>
                                                <div class="mb-3">
                                                    <!-- <asp:Button OnClientClick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none'; return false;" CssClass="btn btn-primary btn-sm" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);float:right;" Text="Change Email" /> -->
                                                    <button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Change Email</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                    <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:var(--SuMDWhite) !important;margin-top:0px !important;">
                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                        <div onclick="SuMSettingDivExpandor('SigAndMore');" class="card-header py-3" style="background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                            <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" viewBox="0 0 24 24" fill="var(--SuMThemeColor)"><g><path d="M0,0h24v24H0V0z" fill="none"/></g><g><path d="M16,3H5C3.9,3,3,3.9,3,5v14c0,1.1,0.9,2,2,2h14c1.1,0,2-0.9,2-2V8L16,3z M8,7h3c0.55,0,1,0.45,1,1v0c0,0.55-0.45,1-1,1H8 C7.45,9,7,8.55,7,8v0C7,7.45,7.45,7,8,7z M16,17H8c-0.55,0-1-0.45-1-1v0c0-0.55,0.45-1,1-1h8c0.55,0,1,0.45,1,1v0 C17,16.55,16.55,17,16,17z M16,13H8c-0.55,0-1-0.45-1-1v0c0-0.55,0.45-1,1-1h8c0.55,0,1,0.45,1,1v0C17,12.55,16.55,13,16,13z M15,8 V5l4,4h-3C15.45,9,15,8.55,15,8z"/></g></svg>
                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Signature & more</p>
                        </div>
                        <div id="SigAndMore" runat="server" class="card-body animated slideInDown" style="animation-duration: 0.4s !important;background-color:var(--SuMDWhite) !important;display:none;">
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="mb-3"><label class="form-label" for="signature"><strong>Signature</strong><br></label><textarea class="form-control" id="SignaturePE" rows="4" name="signature" placeholder="..." runat="server"></textarea></div>
                                        <div class="mb-3">
                                            <div class="form-check form-switch"><input onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); this.checked = false; return false;" class="form-check-input" type="checkbox" id="NofifyCheckEP" runat="server"><label class="form-check-label" for="formCheck-1"><strong>Notify me about new replies</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            <asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;float:right;" OnClick="ChangeSIG" Text="Change signature" />

                                        </div>
                                </div>
                                <div class="col" style="display:none !important;visibility:hidden !important;">
                                    <div >
                                        <div >
                                            <div>
                                                <div class="mb-3"><label class="form-label" for="address"><strong>Address (optional!)</strong></label><input class="form-control" type="text" id="AddressEP" placeholder="Tel Aviv, 37" name="address" runat="server"></div>
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="city"><strong>City (optional!)</strong></label><input class="form-control" type="text" id="CityEP" placeholder="Tel Aviv" name="city" runat="server"></div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="country"><strong>Country (optional!)</strong></label><input class="form-control" type="text" id="CountryPE" placeholder="Israel" name="country" runat="server"></div>
                                                    </div>
                                                </div>
                                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Save&nbsp;Adress</button></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

        
                                    <div style="background-color:var(--SuMDWhite) !important;">
                                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                                        <div style="border:none;height:54px;overflow:hidden;background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('PaymentCard');" class="card-header py-3">
                                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M20 4H4c-1.11 0-1.99.89-1.99 2L2 18c0 1.11.89 2 2 2h16c1.11 0 2-.89 2-2V6c0-1.11-.89-2-2-2zm-1 14H5c-.55 0-1-.45-1-1v-5h16v5c0 .55-.45 1-1 1zm1-10H4V7c0-.55.45-1 1-1h14c.55 0 1 .45 1 1v1z"/></svg>
                                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Payment</p>
                                        </div>
                                        <div id="PaymentCard" runat="server" style="display:none;animation-duration: 0.4s !important;" class="card-body animated slideInDown">
                                            <div style="width:100%;">          
                    <div style="width:100%;text-align:center;">
                        <p style="color:var(--SuMThemeColor);"><b>You will be charged 14.99$ once evry month</b></p>
                    </div>
                    <div class="col-md-6" style="width:100%;">
                        <div class="row" style="width:100%;">
                            <div class="col-sm-7">
                                <div class="mb-3"><label class="form-label" for="card_holder">Card Holder</label><input class="form-control" type="text" id="card_holder" placeholder="Card Holder" name="card_holder"></div>
                            </div>
                            <div class="col-sm-5">
                                <div class="mb-3"><label class="form-label">Expiration date</label>
                                    <div class="input-group expiration-date"><input class="form-control" type="text" placeholder="MM" name="expiration_month"><input class="form-control" type="text" placeholder="YY" name="expiration_year"></div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="mb-3"><label class="form-label" for="card_number">Card Number</label><input class="form-control" type="text" id="card_number" placeholder="Card Number" name="card_number"></div>
                            </div>
                            <div class="col-sm-4">
                                <div class="mb-3"><label class="form-label" for="cvc">CVC</label><input class="form-control" type="text" id="cvc" placeholder="CVC" name="cvc"></div>
                            </div>
                            <div class="col-sm-12">
                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server"> Save! </button></div>
                            </div>
                        </div>
                    </div>
                                            </div>
                                        </div>
                                    </div>
        
                    <div class="" style="background-color:var(--SuMDWhite) !important;">
                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                        <div id="CreatorClick" runat="server" style="border:none;height:54px;overflow:hidden;background-color:var(--SuMDWhite) !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('creatorsupmitform');" class="card-header py-3">
                            <svg xmlns="http://www.w3.org/2000/svg" style="width:auto;height:30px;display:inline;float:left;" enable-background="new 0 0 20 20" viewBox="0 0 20 20" fill="var(--SuMThemeColor)"><rect fill="none" height="20" width="20"/><path d="M15.35,8.83l0.71-0.71c0.59-0.59,0.59-1.54,0-2.12L15,4.94c-0.59-0.59-1.54-0.59-2.12,0l-0.71,0.71L15.35,8.83z M11.11,6.71 l-6.96,6.96C4.05,13.77,4,13.89,4,14.03v2.47C4,16.78,4.22,17,4.5,17h2.47c0.13,0,0.26-0.05,0.35-0.15l6.96-6.96L11.11,6.71z M4.51,11.18C3.59,10.76,3,10.16,3,9.25c0-1.31,1.39-1.99,2.61-2.59C6.45,6.24,7.5,5.73,7.5,5.25C7.5,4.91,6.83,4.5,6,4.5 c-0.94,0-1.36,0.46-1.38,0.48C4.35,5.29,3.88,5.33,3.57,5.07C3.26,4.81,3.21,4.35,3.46,4.03C3.55,3.93,4.34,3,6,3 c1.47,0,3,0.84,3,2.25C9,6.66,7.55,7.37,6.27,8C5.56,8.35,4.5,8.87,4.5,9.25c0,0.3,0.48,0.56,1.17,0.78L4.51,11.18z M14.14,12.16 c0.83,0.48,1.36,1.14,1.36,2.09c0,1.94-2.44,2.75-3.75,2.75C11.34,17,11,16.66,11,16.25s0.34-0.75,0.75-0.75 c0.77,0,2.25-0.49,2.25-1.25c0-0.39-0.38-0.71-0.97-0.97L14.14,12.16z"/></svg>
                            <p id="CraetorSecTitle" runat="server" style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Apply to be a creator</p>
                        </div>
                        <div class="card-body animated slideInDown" style="display:none;animation-duration: 0.4s !important;" id="creatorsupmitform" runat="server">
                            <div class="row">
                                <div class="col">
                                    <div >
                                        <div >
                                            <div>
                                                <div class="mb-3"><label class="form-label" for="address"><strong>Creator Name</strong></label><input style="" class="form-control" type="text" id="CreatorNameBAC" placeholder="Choose a unique name!" name="address" runat="server"></div>
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="city"><strong>Phone number</strong></label><input style="" class="form-control" type="tel" id="PhoneNumBAC" placeholder="Phone number with Conrty code!" name="PhoneNum" runat="server"></div>
                                                    </div>
                                                    <div class="col">
                                                        <div class="mb-3"><label class="form-label" for="country"><strong>Type your password</strong></label><input style="" class="form-control" type="password" id="PasswordBAC" placeholder="password..." name="country" runat="server"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                        <div class="mb-3"><label class="form-label" for="q"><strong>Got a question?</strong><br></label><textarea class="form-control" id="Q" rows="4" name="q" placeholder="Ask us anything you want :)" runat="server"></textarea></div>
                                        <div class="mb-3">
                                            <div class="form-check form-switch"><input class="form-check-input" type="checkbox" id="Checkbox2" runat="server" checked><label class="form-check-label" for="formCheck-1"><strong>Notify me about the prosses on my email!</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            
                                            <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: var(--SuMThemeColor);border-color: var(--SuMThemeColor);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Apply&nbsp;Now</button></div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </div>
        </div>
        </div>
</div>
        <div class="animated fadeIn" id="SuMCoinsManagerCard" style="width:calc(100% - 24px) !important;height:fit-content;background-color:var(--SuMDWhiteOP86) !important;border-radius:20px !important;padding: 32px !important;margin-top:12px !important;margin:12px !important;padding-top:32px !important;border:0.5px var(--SuMDBroderC) solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;">
            <div style="width:100%;height:fit-content;display:block;">
                <p style="font-size:138%;color:var(--SuMDBlack);display:inline-block;">SuM-Coins</p>
                <div style="float:right;display:inline-block;border-radius:16px;width:fit-content;height:32px;padding-top:3px;padding-left:8px;padding-right:12px;overflow:hidden;margin-top:12px !important;">
                    <img src="/svg/sumtokencoin.svg" style="display:inline-block;width:20px;height:20px;margin-right:3px;">
                    <p id="CoinsCount" style="width:fit-content;height:fit-content;display:inline-block;font-size:126%;float:right;margin-top:-1px;margin-left:1px;">0</p>
                </div>
                <p style="font-size:92%;width:100%;margin-top:-18px;">Watch ADs for coins</p>
            </div>
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:18px !important;">
            <div style="width:100%;height:fit-content;display:block;padding-top:26px;">
                <div style="width:100%;height:fit-content;margin:0 auto;padding:12px;">
                    <p style="display:inline-block;color:var(--SuMThemeColorOP74);font-size:132%;">1 Coin</p>
                    <p style="display:inline-block;color:var(--SuMDBlackOP32);font-size:86%;">10-6 seconds AD</p>
                    <a id="SuMOneCoinBTN" class="btn" onclick="SuMPushAnAd(1);" style="float:right;display:inline-block;color:rgba(255,255,255,0.92);background-color:var(--SuMThemeColorOP74);height:28px;padding-top:1px;border-radius:15px;margin-top:2px;">watch</a>
                </div>
                <div style="width:100%;height:fit-content;margin:0 auto;padding:12px;display:none !important;visibility:hidden !important;">
                    <p style="display:inline-block;color:var(--SuMThemeColorOP74);font-size:132%;">2 Coins</p>
                    <p style="display:inline-block;color:var(--SuMDBlackOP32);font-size:86%;">12 seconds AD</p>
                    <a class="btn" onclick="SuMPushAnAd(2);" style="float:right;display:inline-block;color:rgba(255,255,255,0.92);background-color:var(--SuMThemeColorOP74);height:28px;padding-top:1px;border-radius:15px;margin-top:2px;">claim</a>
                </div>
                <div style="width:100%;height:fit-content;margin:0 auto;padding:12px;display:none !important;visibility:hidden !important;">
                    <p style="display:inline-block;color:var(--SuMThemeColorOP74);font-size:132%;">4 Coins</p>
                    <p style="display:inline-block;color:var(--SuMDBlackOP32);font-size:86%;">32 seconds AD</p>
                    <a class="btn" onclick="SuMPushAnAd(4);" style="float:right;display:inline-block;color:rgba(255,255,255,0.92);background-color:var(--SuMThemeColorOP74);height:28px;padding-top:1px;border-radius:15px;margin-top:2px;">claim</a>
                </div>
            </div>
        </div>
        <script>
            var TTDUIDF5C0 = getUIDFrUserCo();
            if (TTDUIDF5C0 != null && TTDUIDF5C0 != '') {
                document.getElementById('SuMCoinsManagerCard').style.display = 'block';
                SuMCoinsCount(TTDUIDF5C0);
            }
            else {
                document.getElementById('SuMCoinsManagerCard').style.display = 'none';
            }
            function SuMADShowAsLoad() {
            };
            function SuMADBTNReset() {
            };
            function SuMRewardVoucherFD(SuMToken) {
                SuMUpdateCoinsCount(TTDUIDF5C0, SuMToken);
                document.getElementById('CoinsCount').innerText = (CurrSuMCoinsCount + SuMToken);
                CurrSuMCoinsCount = CurrSuMCoinsCount + SuMToken;
            }
        </script>
        <div id="StartSetAnim" runat="server" class="fadeIn animated" style="width:calc(100% - 24px) !important;height:fit-content;background-color:var(--SuMDWhiteOP86) !important;border-radius:20px !important;padding: 32px !important;margin-top:12px !important;margin:12px !important;padding-top:32px !important;border:0.5px var(--SuMDBroderC) solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;">
            <div style="width:100%;height:fit-content;display:block;padding:4px;padding-top:0px;padding-bottom:6px;padding-top:0px !important;">
                <p style="font-size:138%;color:var(--SuMDBlack);display:inline-block;">SuM-Settings</p>
                <div style="float:right;display:inline-block;border-radius:16px;width:46px;height:46px;padding-top:3px;padding-left:8px;padding-right:12px;overflow:hidden;margin-top:6px !important;">
                    <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" viewBox="0 0 24 24" style="max-height:38px;max-width:38px;width:62px;height:62px;display:block;" fill="var(--SuMThemeColor)"><rect fill="none" height="24" width="24"></rect><path d="M19.5,12c0-0.23-0.01-0.45-0.03-0.68l1.86-1.41c0.4-0.3,0.51-0.86,0.26-1.3l-1.87-3.23c-0.25-0.44-0.79-0.62-1.25-0.42 l-2.15,0.91c-0.37-0.26-0.76-0.49-1.17-0.68l-0.29-2.31C14.8,2.38,14.37,2,13.87,2h-3.73C9.63,2,9.2,2.38,9.14,2.88L8.85,5.19 c-0.41,0.19-0.8,0.42-1.17,0.68L5.53,4.96c-0.46-0.2-1-0.02-1.25,0.42L2.41,8.62c-0.25,0.44-0.14,0.99,0.26,1.3l1.86,1.41 C4.51,11.55,4.5,11.77,4.5,12s0.01,0.45,0.03,0.68l-1.86,1.41c-0.4,0.3-0.51,0.86-0.26,1.3l1.87,3.23c0.25,0.44,0.79,0.62,1.25,0.42 l2.15-0.91c0.37,0.26,0.76,0.49,1.17,0.68l0.29,2.31C9.2,21.62,9.63,22,10.13,22h3.73c0.5,0,0.93-0.38,0.99-0.88l0.29-2.31 c0.41-0.19,0.8-0.42,1.17-0.68l2.15,0.91c0.46,0.2,1,0.02,1.25-0.42l1.87-3.23c0.25-0.44,0.14-0.99-0.26-1.3l-1.86-1.41 C19.49,12.45,19.5,12.23,19.5,12z M12.04,15.5c-1.93,0-3.5-1.57-3.5-3.5s1.57-3.5,3.5-3.5s3.5,1.57,3.5,3.5S13.97,15.5,12.04,15.5z"></path></svg>
                </div>
                <p style="font-size:92%;width:100%;margin-top:-18px;">Do as you see fit</p>
            </div>
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-bottom:0px !important;margin-top:12px !important;" />
            <div style="vertical-align:middle;display:block !important;padding-bottom:6px !important;padding-top:12px;">
                                    <svg style="display:inline;float:left;" xmlns="http://www.w3.org/2000/svg" height="30px" viewBox="0 0 24 24" width="30px" id="SuMLockIcon" fill="var(--SuMDBlack)"><g fill="none"><path d="M0 0h24v24H0V0z"/><path d="M0 0h24v24H0V0z" opacity=".87"/></g><path d="M18 8h-1V6c0-2.76-2.24-5-5-5S7 3.24 7 6v2H6c-1.1 0-2 .9-2 2v10c0 1.1.9 2 2 2h12c1.1 0 2-.9 2-2V10c0-1.1-.9-2-2-2zm-6 9c-1.1 0-2-.9-2-2s.9-2 2-2 2 .9 2 2-.9 2-2 2zM9 8V6c0-1.66 1.34-3 3-3s3 1.34 3 3v2H9z"/></svg>
                                    <p style="color:var(--SuMDBlack);display:inline;float:left;margin:8px;font-size:112%;margin-top:4px;">SuM Lock</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;margin-right:8px;margin-top:6px;opacity:0.86;" type="checkbox" onclick="SuMLockModeM(1);" id="SuMLockSwitchT" /> </div>
                <p style="font-size:82%;color:var(--SuMDSubTextC);float:left;margin-left:38px;margin-top:4px;width:calc(100% - 86px);">more privacy accomplished by requiring a biometric scan when opening the app.</p>
                <script>
                    var SuMStateBit = getCookie('SuMLockMode').replace(' ', '');
                    if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                        document.getElementById('SuMLockSwitchT').checked = false;
                        document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(1);');
                    }
                    if (SuMStateBit == 1 || SuMStateBit == '1') {
                        document.getElementById('SuMLockSwitchT').checked = true;
                        document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(0);');
                    }
                    function SuMLockModeM(BITX) {
                        if (BITX == 1 || BITX == '1') {
                            document.cookie = "SuMLockMode=" + BITX + "; expires=Thu, 18 Dec 9999 12:00:00 UTC; path=/";
                            androidAPIs.SuMRestart();
                        }
                        else {
                            document.cookie = "SuMLockMode=0; expires=Thu, 18 Dec 1000 12:00:00 UTC; path=/";
                            androidAPIs.SuMRestart();
                        }
                        if (BITX == 0) {
                            document.getElementById('SuMLockSwitchT').checked = false;
                            document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(1);');
                        }
                        if (BITX == 1) {
                            document.getElementById('SuMLockSwitchT').checked = true;
                            document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(0);');
                        }
                    };
                </script>
                                </div>
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
                                <div style="vertical-align:middle;display:block !important;padding-bottom:6px !important;padding-top:12px !important;">
                                    <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 20 20" style="width:auto;height:30px;display:inline;float:left;" viewBox="0 0 20 20" fill="var(--SuMDBlack)"><rect fill="none" height="20" width="20"/><path d="M3.5,4.75c0-0.69,0.56-1.25,1.25-1.25S6,4.06,6,4.75S5.44,6,4.75,6S3.5,5.44,3.5,4.75z M10,2C9.26,2,8.55,2.1,7.87,2.29 C7.32,2.45,7.13,3.13,7.54,3.54l0,0c0.19,0.19,0.47,0.27,0.73,0.2C8.82,3.59,9.4,3.5,10,3.5c3.69,0,6.67,3.09,6.49,6.81 c-0.16,3.33-2.86,6.03-6.18,6.18C6.59,16.67,3.5,13.69,3.5,10c0-0.6,0.09-1.18,0.24-1.73c0.07-0.26-0.01-0.54-0.2-0.73l0,0 c-0.41-0.41-1.1-0.22-1.25,0.33C2.1,8.55,2,9.26,2,10c0,4.48,3.69,8.1,8.19,8c4.24-0.1,7.71-3.56,7.81-7.8C18.1,5.69,14.48,2,10,2z M5,10c0-2.76,2.24-5,5-5s5,2.24,5,5c0,2.76-2.24,5-5,5S5,12.76,5,10z"/></svg>
                                    <p style="color:var(--SuMDBlack);display:inline;float:left;margin:8px;font-size:112%;margin-top:4px;">Performance Mode</p><a style="display:inline-block !important;height:fit-content;width:fit-content;padding-top:2px;padding-left:6px;padding-right:6px;color:rgba(255,255,255,0.92);background-color:var(--SuMThemeColorOP64);margin-left:2px;border-radius:8px;font-size:60%;">Beta !</a>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;margin-right:8px;margin-top:6px;opacity:0.86;" type="checkbox" onclick="SuMPerfModeM(1);" id="PerformanceModeSwitch" /> </div>
                                    <script>
                                        var SuMStateBit = getCookie('SuMPerformanceMode').replace(' ', '');
                                        if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                                            document.getElementById('PerformanceModeSwitch').checked = false;
                                            document.getElementById('PerformanceModeSwitch').setAttribute('onclick', 'SuMPerfModeM(1);');
                                        }
                                        if (SuMStateBit == 1 || SuMStateBit == '1') {
                                            document.getElementById('PerformanceModeSwitch').checked = true;
                                            document.getElementById('PerformanceModeSwitch').setAttribute('onclick', 'SuMPerfModeM(0);');
                                        }
                                        function SuMPerfModeM(BITX) {
                                            document.cookie = "SuMPerformanceMode=" + BITX + "; expires=Thu, 18 Dec 9999 12:00:00 UTC; path=/";
                                            if (BITX == 0) {
                                                document.getElementById('PerformanceModeSwitch').checked = false;
                                                document.getElementById('PerformanceModeSwitch').setAttribute('onclick', 'SuMPerfModeM(1);');
                                                SuMPerfModeHandler();
                                            }
                                            if (BITX == 1) {
                                                document.getElementById('PerformanceModeSwitch').checked = true;
                                                document.getElementById('PerformanceModeSwitch').setAttribute('onclick', 'SuMPerfModeM(0);');
                                                SuMPerfModeHandler();
                                            }
                                        };
                                    </script>
                <p style="font-size:82%;color:var(--SuMDSubTextC);float:left;margin-left:38px;margin-top:4px;width:calc(100% - 86px);">This mode removes all animations SuM-Theme-Set to improve performance on low-end devices.</p>
                                </div>
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
            
            <div class="" style="vertical-align:middle;display:block !important;padding-bottom:6px !important;padding-top:12px !important;">
                                    <svg xmlns="http://www.w3.org/2000/svg" style="width:30px;height:30px;display:inline;float:left;" viewBox="0 0 24 24">
	<g id="Layer_2" data-name="Layer 2">
		<g id="moon">
			<g id="moon-2" data-name="moon">
				<rect style="fill:var(--SuMDBlack);opacity:0;" width="24" height="24"/>
				<path style="fill:var(--SuMDBlack);" class="cls-2" d="M12.3,22h-.1a10.31,10.31,0,0,1-7.34-3.15,10.46,10.46,0,0,1-.26-14,10.13,10.13,0,0,1,4-2.74,1,1,0,0,1,1.06.22,1,1,0,0,1,.24,1,8.4,8.4,0,0,0,1.94,8.81,8.47,8.47,0,0,0,8.83,1.94,1,1,0,0,1,1.27,1.29A10.16,10.16,0,0,1,19.6,19,10.28,10.28,0,0,1,12.3,22Z"/>
			</g>
		</g>
	</g>
</svg>
                                    <p style="color:var(--SuMDBlack);display:inline;float:left;margin:8px;font-size:112%;margin-top:4px;">Dark Mode</p>
                                    <a style="display:inline-block !important;height:fit-content;width:fit-content;padding-top:2px;padding-left:6px;padding-right:6px;color:rgba(255,255,255,0.92);background-color:var(--SuMThemeColorOP64);margin-left:2px;border-radius:8px;font-size:60%;">Beta !</a>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;">
                                        <input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;opacity:0.86 !important;margin-right:8px;margin-top:6px;" type="checkbox" onclick="SuMDarkModeM(1);" id="DarkModeS" />
                                        <script>
                                            var SuMStateBit = getCookie('SuMUserThemeState').replace(' ', '');
                                            if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                                                document.getElementById('DarkModeS').checked = false;
                                                document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(1);');
                                            }
                                            if (SuMStateBit == 1 || SuMStateBit == '1') {
                                                document.getElementById('DarkModeS').checked = true;
                                                document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(0);');
                                            }
                                            function SuMDarkModeM(BITX) {
                                                document.cookie = "SuMUserThemeState=" + BITX + "; expires=Thu, 18 Dec 9999 12:00:00 UTC; path=/";
                                                if (BITX == 0) {
                                                    document.getElementById('DarkModeS').checked = false;
                                                    document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(1);');
                                                }
                                                if (BITX == 1) {
                                                    document.getElementById('DarkModeS').checked = true;
                                                    document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(0);');
                                                }
                                                SuMSetThemeState(BITX);
                                            };
                                        </script>
                                    </div>
                                    <p style="font-size:82%;color:var(--SuMDSubTextC);float:left;margin-left:38px;margin-top:4px;width:calc(100% - 86px);">Changes SuM Theme to darker shades of color. this mode may not apply to all SuM's parts! </p>
                                </div>
            <hr style="display:none !important;visibility:hidden !important;margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
            
            <div class=""  style="vertical-align:middle;display:block !important;padding-top:12px !important;display:none !important;visibility:hidden !important;">
<svg style="width:auto;height:30px;display:inline;float:left;" viewBox="0 0 16 20" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
    <!-- Generator: Sketch 52.5 (67469) - http://www.bohemiancoding.com/sketch -->
    <title>notifications</title>
    <desc>Created with Sketch.</desc>
    <g id="Icons" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
        <g id="Rounded" transform="translate(-444.000000, -4100.000000)">
            <g id="Social" transform="translate(100.000000, 4044.000000)">
                <g id="-Round-/-Social-/-notifications" transform="translate(340.000000, 54.000000)">
                    <g>
                        <polygon id="Path" points="0 0 24 0 24 24 0 24"></polygon>
                        <path d="M12,22 C13.1,22 14,21.1 14,20 L10,20 C10,21.1 10.89,22 12,22 Z M18,16 L18,11 C18,7.93 16.36,5.36 13.5,4.68 L13.5,4 C13.5,3.17 12.83,2.5 12,2.5 C11.17,2.5 10.5,3.17 10.5,4 L10.5,4.68 C7.63,5.36 6,7.92 6,11 L6,16 L4.71,17.29 C4.08,17.92 4.52,19 5.41,19 L18.58,19 C19.47,19 19.92,17.92 19.29,17.29 L18,16 Z" id="🔹-Icon-Color" fill="var(--SuMDBlack)"></path>
                    </g>
                </g>
            </g>
        </g>
    </g>
</svg>
        <p style="color:var(--SuMDBlack);display:inline;float:left;margin:8px;font-size:112%;margin-top:4px;">Get The latest</p>
        <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:36px;height:18px;float:right;opacity:0.32 !important;margin-right:8px;margin-top:6px;" onclick="SuMTXTShowThis('Unavailable','var(--SuMThemeColorOP74)','Get The latest','Settings'); document.getElementById('GetTheLatest').checked = false; return false;" type="checkbox" id="GetTheLatest" ></div>
               <p style="font-size:82%;color:var(--SuMDSubTextC);float:left;margin-left:38px;margin-top:4px;width:calc(100% - 86px);">Get The latest News about mangas in general</p>
            </div>
    </div>
                        <div class="" style="background-color:transparent !important;border-radius:0px !important; padding: 4px !important;margin-top:6px !important;margin-top:12px;">
        </div>
            <div class="" style="background-color:transparent !important;border-radius:0px !important; padding: 2px !important;margin-top:8px !important;position:relative;overflow:hidden !important;">
            <div class="" style="background-color:transparent !important;margin-top:-2px;vertical-align:middle;display:block !important;height:100px;overflow:hidden !important;padding-bottom:280px !important;padding-left:8px !important;">
                <p class="" style="color:var(--SuMDBlackOP64);margin-left:18px;"><b style="font-size:96%;display:inline;">SuM Manga </b><b style="font-size:150%;display:inline;">·</b><b style="font-size:84%;display:inline;"> Version</b> 3.2.4 Beta</p>
                <p onload="CacheInfoLoading();" style="color:var(--SuMDBlackOP64);margin-left:18px;margin-top:-16px;">Cached files size: <b id="cachesizenum" style="display:inline;color:var(--SuMDBlackOP64);">calculating</b><b style="display:inline;color:var(--SuMDBlackOP64);" id="cachesizeyunit"></b><a id="ClearCacheBTN" onclick="DeleteSuMCache();" style="font-size:86%;color:rgba(255,255,255,0.9) !important;background: var(--SuMThemeColorOP62);border-color: var(--SuMThemeColor);display:inline-block !important;width:fit-content;border-radius:12px;padding-top:3px;padding-bottom:-2px;padding-left:8px;padding-right:8px;margin-left:8px;">Clear cache</a></p>
                <p class="" style="color:var(--SuMDBlackOP64);margin-left:20px;font-size:68%;margin-top:-12px;">This website/APP is a school project and will be deleted soon!</p>
                <p class="" style="color:var(--SuMDBlackOP64);margin-left:20px;font-size:68%;margin-top:0px;width:100%;height:32px;"></p>
            </div>
        </div>
                        <script>
                            CacheInfoLoading();
                        </script>
        </div>
        </div>
    <script>
            async function getCacheStoragesAssetTotalSize() {

                const cacheNames = await caches.keys();

                let total = 0;

                const sizePromises = cacheNames.map(async cacheName => {
                    const cache = await caches.open(cacheName);
                    const keys = await cache.keys();
                    let cacheSize = 0;

                    await Promise.all(keys.map(async key => {
                        const response = await cache.match(key);
                        const blob = await response.blob();
                        total += blob.size;
                        cacheSize += blob.size;
                    }));
                });

                await Promise.all(sizePromises);

                return (total / 1000);
            };
            function CacheInfoLoading() {
                getCacheStoragesAssetTotalSize().then(function (result) {
                    var currcachesizeinmb = result;
                    var currcachesymb = 'KB';
                    if (currcachesizeinmb > 1000) {
                        currcachesizeinmb = (currcachesizeinmb / 1000);
                        currcachesymb = 'MB';
                        if (currcachesizeinmb > 1000) {
                            currcachesizeinmb = (currcachesizeinmb / 1000);
                            currcachesymb = 'GB';
                            if (currcachesizeinmb > 1000) {
                                currcachesizeinmb = (currcachesizeinmb / 1000);
                                currcachesymb = 'TB';
                            }
                        }
                    }
                    if (currcachesizeinmb < 0.00499) {
                        document.getElementById('ClearCacheBTN').style.background = 'var(--SuMDBlackOP16)';
                    }
                    document.getElementById('cachesizenum').innerText = currcachesizeinmb.toFixed(2);
                    document.getElementById('cachesizeyunit').innerText = currcachesymb;
                });
            };
        document.onreadystatechange = function () {
            if (document.readyState == "interactive") {
                setTimeout(() => {
                    document.getElementById('<%= FixUpPageRe.ClientID %>').click();
                }, 180);
                setTimeout(() => {
                    CacheInfoLoading();
                }, 360);
            }
        };
        function DeleteSuMCache() {
            caches.delete('SuMMangaCache').then(function (boolean) { });
            androidAPIs.DeleteSuMCache();
            document.getElementById('ClearCacheBTN').style.background = 'var(--SuMDBlackOP16)';
            CacheInfoLoading();
        };
            var UserSettingsCardsDiv = document.getElementById('<%= UserSettingsCards.ClientID %>');
            function SuMSettingDivExpandor(NormallId) {
                var ChangeDivv = document.getElementById('MainContent_' + NormallId);
                if (ChangeDivv.style.display == 'none') {
                    ChangeDivv.style.display = 'block';
                    UserSettingsCardsDiv.style.height = UserSettingsCardsDiv.offsetHeight + ChangeDivv.offsetHeight + 'px';
                }
                else {
                    UserSettingsCardsDiv.style.height = UserSettingsCardsDiv.offsetHeight - ChangeDivv.offsetHeight + 'px';
                    ChangeDivv.style.display = 'none';
                }
            };
        document.forms[0].addEventListener('submit', e => {
            setTimeout(() => {
                CacheInfoLoading();
            }, 820);
        });
    </script>
    <script>
        if ("androidAPIs" in window == true) {
              
        }
        var ThisPageScrollContaner = document.getElementById('SuMRnadomScrollHelper');
        var ThisPageChangeStartElm = document.getElementById('<%= ThisPageMaxNoShowScrool.ClientID %>');
        var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
        var StatusBarHeightValueFromAPIs = 24;
        if ("androidAPIs" in window == true) {
            StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        }
        var MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        setTimeout(() => {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        }, 540);
        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';

        function UpdateDrakModeState() {
            var SuMStateBit = getCookie('SuMUserThemeState').replace(' ', '');
            if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                document.getElementById('DarkModeS').checked = false;
                document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(1);');
            }
            if (SuMStateBit == 1 || SuMStateBit == '1') {
                document.getElementById('DarkModeS').checked = true;
                document.getElementById('DarkModeS').setAttribute('onclick', 'SuMDarkModeM(0);');
            }
        };

        function UpdateLockModeState() {
            var SuMStateBit = getCookie('SuMLockMode').replace(' ', '');
            if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                document.getElementById('SuMLockSwitchT').checked = false;
                document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(1);');
            }
            if (SuMStateBit == 1 || SuMStateBit == '1') {
                document.getElementById('SuMLockSwitchT').checked = true;
                document.getElementById('SuMLockSwitchT').setAttribute('onclick', 'SuMLockModeM(0);');
            }
        };

        var StatusBarHeightValueFromSuMAndroidAPIsF0C1 = 24;
        if ("androidAPIs" in window == true) {
            StatusBarHeightValueFromSuMAndroidAPIsF0C1 = androidAPIs.getStatusBarHeight();
        }
        document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1) + 'px';
        //document.getElementById('SuMSettingStatausBarHelperF000C000').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1) + 'px';
        UpdateDrakModeState();
        UpdateLockModeState();
        setTimeout(() => {
            if ("androidAPIs" in window == true) {
                  
            }
            UpdateDrakModeState();
            UpdateLockModeState();
            document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
            //document.getElementById('SuMSettingStatausBarHelperF000C000').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 2) + 'px';
            setTimeout(() => {
                if ("androidAPIs" in window == true) {
                      
                }
                UpdateDrakModeState();
                UpdateLockModeState();
                document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                //document.getElementById('SuMSettingStatausBarHelperF000C000').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 2) + 'px';
                setTimeout(() => {
                    if ("androidAPIs" in window == true) {
                          
                    }
                    UpdateDrakModeState();
                    UpdateLockModeState();
                    setTimeout(() => {
                        if ("androidAPIs" in window == true) {
                              
                        }
                        UpdateDrakModeState();
                        UpdateLockModeState();
                        setTimeout(() => {
                              
                            document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                            //document.getElementById('SuMSettingStatausBarHelperF000C000').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 2) + 'px';
                            setTimeout(() => {
                                if ("androidAPIs" in window == true) {
                                      
                                }
                                UpdateDrakModeState();
                                UpdateLockModeState();
                                setTimeout(() => {
                                    if ("androidAPIs" in window == true) {
                                          
                                    }
                                    UpdateDrakModeState();
                                    UpdateLockModeState();
                                    document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                                    //document.getElementById('SuMSettingStatausBarHelperF000C000').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 2) + 'px';
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</asp:Content>