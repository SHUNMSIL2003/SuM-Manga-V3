<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.MainCard.Master" AutoEventWireup="true" CodeBehind="SettingsAccountCard.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.SettingsAccountCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        * {
            overflow:hidden !important;
        }
        a {
            pointer-events: all;
        }
        slideInDown{
            animation-duration:0.4s !important;
        }
    </style>
    <asp:Button ID="FixUpPageRe" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
    <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomPFP" runat="server" HiddenField="true" />
    <asp:FileUpload onchange="loadFile2(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomBanner" runat="server" HiddenField="true" />
    <div id="SlideDownCard" runat="server" style="transition:none !important;animation-duration:0.26s !important;width:calc(100vw - 5px) !important;margin:2px !important;margin:0 auto !important;padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:transparent !important;margin:0 auto !important;border-radius:22px !important;padding:0px !important;border:0.5px var(--SuMDBroderC) solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;overflow:hidden !important;margin-top:2px !important;margin-bottom:2px !important;margin-left:2px !important;margin-right:3px !important;">
        <asp:UpdatePanel ID="ProfileInfoUpdatepANEL" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="FixUpPageRe" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
        <div id="ThisPageMaxNoShowScrool" runat="server" style="background-color:var(--SuMThemeColorOP74) !important;border-radius:20px !important;width:100%;margin:0 auto !important;padding:16px !important;margin-top:0px !important; margin-bottom:0px !important;z-index:998;position:relative;">
            <a runat="server" id="AccountSettingsOrLogin" onclick="" href="/AccountETC/LoginETC.aspx" style="height:112px !important;width:calc(100% - 60px) !important;background-color:transparent !important;display:block !important;margin-top:8px;margin-bottom:8px; margin-left:8px;position:relative;z-index:998;">
            <div style="width:86px;height:86px;border-radius:50%;background-color:transparent !important;border:2px solid var(--SuMDWhite) !important;float:left;display:inline;margin-bottom:4px;padding:0px !important;">
                <img class="animated pulse" id="PFP" runat="server" style="width:82px !important;height:82px !important;border-radius:50% !important;" src="/AccountETC/UsersUploads/DeafultPFP.jpg" />
            </div>
                <div id="UserInfoDiv" runat="server" class="fadeIn animated" style="float:left;display:inline;margin-left:8px;padding-top:12px !important;width:calc(100% - 94px) !important;">
                    <h3 id="SuMUserName" runat="server" style="color:rgb(255,255,255);margin-left:12px;width:fit-content;max-width:100% !important;white-space:nowrap !important;overflow:hidden;text-overflow:ellipsis !important;">Login to SuM</h3>
                    <h6 id="SignedWith" runat="server" style="color:rgba(255,255,2550.86);font-size:74%;margin-left:12px;width:fit-content;max-width:100% !important;white-space:nowrap !important;overflow:hidden;text-overflow:ellipsis !important;"></h6>
                </div>
            </a>
            <asp:ImageButton ID="LogOutBTN" runat="server" ImageUrl="/svg/logoutW.svg" Width="28px" Height="28px" BackColor="Transparent" ForeColor="Transparent" OnClick="LogOut" style="float:right !important;margin-right:8px;margin-top:-22px !important;" />
            <p id="TapForXText" runat="server" style="margin:0 auto;color:rgba(255,255,2550.64);margin-top:-18px;width:100%;text-align:center;font-size:76%;padding-bottom:-16px;">Tap for more!</p>
        </div>
                        <p style="display:none !important;visibility:hidden !important;object-fit: cover;" id="CurrUserBannerPlaceHolder" runat="server">/svg/add.svg</p>
        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div runat="server" id="UserSettingsCards" class="" style="display:block;height:0px;overflow:hidden;transition:none !important;background-color:transparent !important;padding:0px;">
            <div style="width:100%;height:fit-content;padding: 18px 6px 12px;display:block;">
            <div style="width:100% !important;height:100% !important;background-color:transparent !important;padding:8px;">

                        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:transparent !important;margin-top:0px !important;width:100vw;height:fit-content;">
                                <div onclick="SuMSettingDivExpandor('PFPDiv');" class="card-header py-3" style="background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                    <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><g><path d="M0,0h24v24H0V0z" fill="none"/></g><g><path d="M10.25,13c0,0.69-0.56,1.25-1.25,1.25S7.75,13.69,7.75,13S8.31,11.75,9,11.75S10.25,12.31,10.25,13z M15,11.75 c-0.69,0-1.25,0.56-1.25,1.25s0.56,1.25,1.25,1.25s1.25-0.56,1.25-1.25S15.69,11.75,15,11.75z M22,12c0,5.52-4.48,10-10,10 S2,17.52,2,12S6.48,2,12,2S22,6.48,22,12z M20,12c0-0.78-0.12-1.53-0.33-2.24C18.97,9.91,18.25,10,17.5,10 c-3.13,0-5.92-1.44-7.76-3.69C8.69,8.87,6.6,10.88,4,11.86C4.01,11.9,4,11.95,4,12c0,4.41,3.59,8,8,8S20,16.41,20,12z"/></g></svg>
                                    <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Profile Pic & Banner</p>
                                </div>
                                <div id="PFPDiv" runat="server" class="card-body text-center" style="animation-duration: 0.4s !important;background-color:transparent !important;display:none;height:fit-content;position:relative;z-index:996;width: calc(100% - 32px);">
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
                <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:transparent !important;margin-top:0px !important;display:none !important;">
                    <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;" />
                    <div onclick="if (document.getElementById('ManageDevicesCard').style.display == 'none') { document.getElementById('ManageDevicesCard').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('ManageDevicesCard').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('ManageDevicesCard').offsetHeight + 'px'; document.getElementById('ManageDevicesCard').style.display = 'none'; }" class="card-header py-3" style="background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                        <img src="/svg/devices.svg" style="width:26px;height:26px;display:inline;float:left;" />
                        <p style="color:var(--SuMDBlack) !important;display:inline;float:left;margin:8px;">Manage Devices</p>
                    </div>
                    <div class="" style="animation-duration: 0.4s !important;background-color:transparent !important;display:none;height:fit-content;position:relative;z-index:996" id="ManageDevicesCard">
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
        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:transparent !important;margin-top:0px !important;" class="">
            <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                                        <div onclick="SuMSettingDivExpandor('ChangeEmailDiv');" class="card-header py-3" style="background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                            <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><g><rect fill="none" height="24" width="24"/></g><g><g><g><g><path d="M21,10V4c0-1.1-0.9-2-2-2H3C1.9,2,1.01,2.9,1.01,4L1,16c0,1.1,0.9,2,2,2h11v-5c0-1.66,1.34-3,3-3H21z M11.53,10.67 c-0.32,0.2-0.74,0.2-1.06,0L3.4,6.25C3.15,6.09,3,5.82,3,5.53c0-0.67,0.73-1.07,1.3-0.72L11,9l6.7-4.19 C18.27,4.46,19,4.86,19,5.53c0,0.29-0.15,0.56-0.4,0.72L11.53,10.67z"/><path d="M22,14c-0.55,0-1,0.45-1,1v3c0,1.1-0.9,2-2,2s-2-0.9-2-2v-4.5c0-0.28,0.22-0.5,0.5-0.5s0.5,0.22,0.5,0.5V17 c0,0.55,0.45,1,1,1s1-0.45,1-1v-3.5c0-1.38-1.12-2.5-2.5-2.5S15,12.12,15,13.5V18c0,2.21,1.79,4,4,4s4-1.79,4-4v-3 C23,14.45,22.55,14,22,14z"/></g></g></g></g></svg>
                                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Change Email</p>
                                        </div>
                                        <div runat="server" id="ChangeEmailDiv" class="card-body" style="animation-duration: 0.4s !important;background-color:transparent !important;display:none;position:relative;z-index:996;">
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

                    <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:transparent !important;margin-top:0px !important;">
                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack) !important;width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                        <div onclick="SuMSettingDivExpandor('SigAndMore');" class="card-header py-3" style="background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                            <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" viewBox="0 0 24 24" fill="var(--SuMThemeColor)"><g><path d="M0,0h24v24H0V0z" fill="none"/></g><g><path d="M16,3H5C3.9,3,3,3.9,3,5v14c0,1.1,0.9,2,2,2h14c1.1,0,2-0.9,2-2V8L16,3z M8,7h3c0.55,0,1,0.45,1,1v0c0,0.55-0.45,1-1,1H8 C7.45,9,7,8.55,7,8v0C7,7.45,7.45,7,8,7z M16,17H8c-0.55,0-1-0.45-1-1v0c0-0.55,0.45-1,1-1h8c0.55,0,1,0.45,1,1v0 C17,16.55,16.55,17,16,17z M16,13H8c-0.55,0-1-0.45-1-1v0c0-0.55,0.45-1,1-1h8c0.55,0,1,0.45,1,1v0C17,12.55,16.55,13,16,13z M15,8 V5l4,4h-3C15.45,9,15,8.55,15,8z"/></g></svg>
                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Signature & more</p>
                        </div>
                        <div id="SigAndMore" runat="server" class="card-body" style="animation-duration: 0.4s !important;background-color:transparent !important;display:none;">
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

        
                                    <div style="background-color:transparent !important;">
                                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                                        <div style="border:none;height:54px;overflow:hidden;background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('PaymentCard');" class="card-header py-3">
                                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="width:26px;height:26px;display:inline;float:left;" fill="var(--SuMThemeColor)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M20 4H4c-1.11 0-1.99.89-1.99 2L2 18c0 1.11.89 2 2 2h16c1.11 0 2-.89 2-2V6c0-1.11-.89-2-2-2zm-1 14H5c-.55 0-1-.45-1-1v-5h16v5c0 .55-.45 1-1 1zm1-10H4V7c0-.55.45-1 1-1h14c.55 0 1 .45 1 1v1z"/></svg>
                                            <p style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Payment</p>
                                        </div>
                                        <div id="PaymentCard" runat="server" style="display:none;animation-duration: 0.4s !important;" class="card-body">
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
        
                    <div class="" style="background-color:transparent !important;">
                        <hr style="margin:0 auto !important;height:2px;border-width:0;color:var(--SuMDBlack);background-color:var(--SuMDBlack);width:calc(80% - 64px);opacity:0.06;margin:0px;margin-block:0px;border-radius:1px;margin:0 auto;margin-top:8px !important;margin-bottom:8px !important;" />
                        <div id="CreatorClick" runat="server" style="border:none;height:54px;overflow:hidden;background-color:transparent !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('creatorsupmitform');" class="card-header py-3">
                            <svg xmlns="http://www.w3.org/2000/svg" style="width:auto;height:30px;display:inline;float:left;" enable-background="new 0 0 20 20" viewBox="0 0 20 20" fill="var(--SuMThemeColor)"><rect fill="none" height="20" width="20"/><path d="M15.35,8.83l0.71-0.71c0.59-0.59,0.59-1.54,0-2.12L15,4.94c-0.59-0.59-1.54-0.59-2.12,0l-0.71,0.71L15.35,8.83z M11.11,6.71 l-6.96,6.96C4.05,13.77,4,13.89,4,14.03v2.47C4,16.78,4.22,17,4.5,17h2.47c0.13,0,0.26-0.05,0.35-0.15l6.96-6.96L11.11,6.71z M4.51,11.18C3.59,10.76,3,10.16,3,9.25c0-1.31,1.39-1.99,2.61-2.59C6.45,6.24,7.5,5.73,7.5,5.25C7.5,4.91,6.83,4.5,6,4.5 c-0.94,0-1.36,0.46-1.38,0.48C4.35,5.29,3.88,5.33,3.57,5.07C3.26,4.81,3.21,4.35,3.46,4.03C3.55,3.93,4.34,3,6,3 c1.47,0,3,0.84,3,2.25C9,6.66,7.55,7.37,6.27,8C5.56,8.35,4.5,8.87,4.5,9.25c0,0.3,0.48,0.56,1.17,0.78L4.51,11.18z M14.14,12.16 c0.83,0.48,1.36,1.14,1.36,2.09c0,1.94-2.44,2.75-3.75,2.75C11.34,17,11,16.66,11,16.25s0.34-0.75,0.75-0.75 c0.77,0,2.25-0.49,2.25-1.25c0-0.39-0.38-0.71-0.97-0.97L14.14,12.16z"/></svg>
                            <p id="CraetorSecTitle" runat="server" style="color:var(--SuMDBlackOP74) !important;display:inline;float:left;margin:8px;">Apply to be a creator</p>
                        </div>
                        <div class="card-body" style="display:none;animation-duration: 0.4s !important;" id="creatorsupmitform" runat="server">
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
    <script>
        document.getElementById('<%= FixUpPageRe.ClientID %>').click();
        var AbsContSuMSettingsCardElm = document.getElementById('<%= SlideDownCard.ClientID %>');
        var SettingSuMCardHeightDetacted = AbsContSuMSettingsCardElm.getBoundingClientRect().height + 4;
        androidAPIs.ResizewebView3AccountSettingsCard(SettingSuMCardHeightDetacted);
        document.addEventListener('click', function (event) {
            var SettingSuMCardHeightDetacted0 = document.getElementById('<%= SlideDownCard.ClientID %>').getBoundingClientRect().height + 4;
            androidAPIs.ResizewebView3AccountSettingsCard(SettingSuMCardHeightDetacted0);
            androidAPIs.LoadWebVersionValue("4.0.3 API-6");
        });
        function SuMSettingDivExpandor(NormallId) {
            var ChangeDivv = document.getElementById('MainContent_' + NormallId);
            var UserSettingsCardsDiv = document.getElementById('<%= UserSettingsCards.ClientID %>');
            if (ChangeDivv.style.display == 'none') {
                ChangeDivv.style.display = 'block';
                UserSettingsCardsDiv.style.height = UserSettingsCardsDiv.offsetHeight + ChangeDivv.offsetHeight + 'px';
            }
            else {
                UserSettingsCardsDiv.style.height = UserSettingsCardsDiv.offsetHeight - ChangeDivv.offsetHeight + 'px';
                ChangeDivv.style.display = 'none';
            }
            return false;
        };
        androidAPIs.LoadWebVersionValue("4.0.3 API-6");
    </script>
</asp:Content>