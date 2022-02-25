<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.Settings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        /*var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();*/
        androidAPIs.SetLightStatusBarColor();
        //}
        androidAPIs.SetLightStatusBarColor();
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
        }, 420);
        //androidAPIs.SUMAuthReset();
        //androidAPIs.SUMAuthProssIsDone();
        //androidAPIs.SUMAuthProssResult();
    </script>
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
    <div style="background-color:rgba(255,255,255,0.86) !important;position:fixed !important;top:0 !important;animation-duration:0.16s !important;z-index:997 !important;height:fit-content !important;width:100% !important;display:none;padding-top:6px;padding-bottom:6px;padding-left:4px;border-bottom-left-radius:22px;border-bottom-right-radius:22px;" class="animated fadeInDown" id="SuMMangaTopBar">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;" id="SuMMangaTopBarHeightHelper"></div>
        <p style="font-size:118%;margin-left:18px;margin-bottom:8px;display:block;height:fit-content;width:fit-content;" class="text-black"><img src="/svg/settingstBlack.svg" width="30" height="30" style="" /> SuM Settings</p>
    </div>
    <asp:Button ID="EnablePreMode" runat="server" OnClick="SavePreformanceSettingCookie" style="display:none !important;visibility:hidden;" />
    <asp:Button ID="DisablePreMode" runat="server" OnClick="RemovePreformanceSettingCookie" style="display:none !important;visibility:hidden;" />
    <asp:Button ID="FixUpPageRe" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
    <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomPFP" runat="server" HiddenField="true" />
    <div id="SettingsUnavaliblePOPUP" runat="server" style=" animation-duration:0.36s !important;background-color:rgba(0,0,0,0.32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center animated fadeIn GoodBlur">
        <div id="SUAC000SP" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">This option is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:rgba(0, 0, 0, 0.527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather there is a bug therefore its temporarily disabled or your device does not support it.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
                        <div id="SuMRnadomScrollHelper" style="height:100vh;width:100vw; padding:0px !important;padding-top:0px !important;padding-bottom:8px !important; background-color:#f2f2f2 !important;margin:0 auto !important; margin-top:0px !important;">
    <div style="height:100% !important;width:100vw;max-width:720px !important;margin:0 auto !important;">
    <div id="ThisPageSBarFixUpPropElm" style="width:100%;height:0px;background-color:#ffffff !important;display:block;"></div>
        <script>
            var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
            var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
            ThisPageSBarFixUpPropElmVar.style.height = (StatusBarHeightValue + 2) + 'px !important';
        </script>
    <div id="SlideDownCard" runat="server" style="animation-duration:0.26s !important;width:100%; padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:#ffffff !important;margin:0 auto !important; margin-top:0px !important;border-bottom-left-radius:20px;border-bottom-right-radius:20px;padding:0px !important;padding-bottom:12px !important;padding-top:8px !important;margin-bottom:22px !important;" class="animated slideInDown">
        <div style="width:100vw;height:22px;background-color:#ffffff;position:relative;z-index:998;margin-top:-8px !important;"></div>
        <asp:UpdatePanel ID="ProfileInfoUpdatepANEL" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="EnablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DisablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="FixUpPageRe" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
        <div id="ThisPageMaxNoShowScrool" style="background-color:#ffffff !important;border-radius:0px !important; padding: 4px !important;margin-top:0px !important; margin-bottom:0px !important;z-index:998;position:relative;">
            <a runat="server" id="AccountSettingsOrLogin" onclick="" href="/AccountETC/LoginETC.aspx" style="height:112px !important;width:calc(100% - 60px) !important;background-color:transparent !important;display:block !important;margin-top:8px;margin-bottom:8px; margin-left:8px;position:relative;z-index:998;">
            <div style="width:90px;height:90px;border-radius:45px;background-color:#ffffff;border:2px solid #1d1d1d !important;float:left;display:inline;margin-bottom:6px;padding:1px !important;">
                <img class="animated pulse" id="PFP" runat="server" style="width:84px !important;height:84px !important;border-radius:50% !important;" src="/AccountETC/UsersUploads/DeafultPFP.jpg" />
            </div>
                <div id="UserInfoDiv" runat="server" class="fadeIn animated" style="float:left;display:inline;margin-left:8px;padding-top:32px !important;">
                    <h3 id="SuMUserName" runat="server" style="color:#1d1d1d;">Loging to SuM</h3>
                    <h6 id="SignedWith" runat="server" style="color:#919191;font-size:74%;"></h6>
                </div>
            </a>
            <asp:ImageButton ID="LogOutBTN" runat="server" ImageUrl="/svg/logout.svg" Width="28px" Height="28px" BackColor="Transparent" ForeColor="Transparent" OnClick="LogOut" style="float:right !important;margin-right:8px;margin-top:-38px !important;" />
            <p id="TapForXText" runat="server" style="color:rgba(0,0,0,0.32);margin-top:-18px;width:100%;text-align:center;font-size:76%;margin-left:42px;padding-bottom:-16px;">Tap for more!</p>
        </div>
        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        <div runat="server" id="UserSettingsCards" class="" style="display:block;height:0px;overflow:hidden;transition: height 0.4s;background-color:#ffffff;">
            <div style="width:100% !important;height:100% !important;background-color:#ffffff !important;">

                        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;width:100vw;height:fit-content;">
                            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                                <div onclick="SuMSettingDivExpandor('PFPDiv');" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                    <img src="/svg/face.svg" style="width:26px;height:26px;display:inline;float:left;" />
                                    <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Change profile pic</p>
                                </div>
                                <div id="PFPDiv" runat="server" class="card-body text-center animated slideInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;height:fit-content;position:relative;z-index:996;">
                                    <a onclick="document.getElementById('MainContent_SuMCustomPFP').click();" style="width:fit-content;height:fit-content;">
                                    <img style="position:relative !important;z-index:999 !important;" class="rounded-circle mb-3 mt-4 lazyload" id="PFPC" src="/assets/img/avatars/DeafultPFP.jpg" width="160" height="160" runat="server">
                                    </a>
                                    <div class="mb-3">
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="chpfp000" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFP" Text="Save Pic" />
                                        <script>
                                            const FilePuloadEndElement = document.getElementById('<%= chpfp000.ClientID %>');

                                            // always checking if the element is clicked, if so, do alert('hello')
                                            FilePuloadEndElement.addEventListener("click", () => {
                                                setTimeout(() => {
                                                    androidAPIs.SuMRestart();
                                                }, 360);
                                            });
                                        </script>
                                        <p style="display:inline-block !important;"> Or </p>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="RemovePFP" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFPAtRandom" Text="Reset PFP" />
                                    </div>
                                    <script>
                                        var loadFile = function (event) {
                                            var image = document.getElementById('MainContent_PFPC');
                                            image.src = URL.createObjectURL(event.target.files[0]);
                                        };
                                    </script>
                                </div>
                        </div>
                <!-- Device Manege fucherdsafsd -->
                <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;display:none !important;">
                    <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                    <div onclick="if (document.getElementById('ManageDevicesCard').style.display == 'none') { document.getElementById('ManageDevicesCard').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('ManageDevicesCard').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('ManageDevicesCard').offsetHeight + 'px'; document.getElementById('ManageDevicesCard').style.display = 'none'; }" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                        <img src="/svg/devices.svg" style="width:26px;height:26px;display:inline;float:left;" />
                        <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Manage Devices</p>
                    </div>
                    <div class=" " style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;height:fit-content;position:relative;z-index:996" id="ManageDevicesCard">
                        <p id="DVsText" style="color:rgb(0,0,0);"><b id="DevicesNum" style="color:rgb(104,64,217);" runat="server" ></b> Device(s) loged in</p>
                        <div style="width:100vw;height:fit-content;" id="CurrDevice">
                            <img src="/svg/phonePR.svg" width="24" height="24" style="display:inline;" />
                            <p style="color:rgb(104,64,217);display:inline;">Current Device</p>
                            <p style="color:#251d37b2;font-size:80%;" id="CurrDeviceDate" runat="server"></p>
                        </div>
                         <div style="width:100vw;height:fit-content;" id="SecDevice" runat="server">
                            <img src="/svg/phone.svg" width="24" height="24" style="display:inline;" />
                            <p style="color:rgb(104,64,217);display:inline;">Second Device</p>
                            <p style="color:#251d37b2;font-size:80%;" id="SecDeviceDate" runat="server"></p>
                        </div>
                    </div>
                </div>
        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;" class="">
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                                        <div onclick="SuMSettingDivExpandor('ChangeEmailDiv');" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                            <img src="/svg/attachemail.svg" style="width:26px;height:26px;display:inline;float:left;" />
                                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Change Email</p>
                                        </div>
                                        <div runat="server" id="ChangeEmailDiv" class="card-body animated fadeInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;position:relative;z-index:996;">
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
                                                    <!-- <asp:Button OnClientClick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'none'; return false;" CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" Text="Change Email" /> -->
                                                    <button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Change Email</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                    <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;">
                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                        <div onclick="SuMSettingDivExpandor('SigAndMore');" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                            <img src="/svg/feed.svg" style="width:26px;height:26px;display:inline;float:left;" />
                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Signature & more</p>
                        </div>
                        <div id="SigAndMore" runat="server" class="card-body animated slideInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;">
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="mb-3"><label class="form-label" for="signature"><strong>Signature</strong><br></label><textarea class="form-control" id="SignaturePE" rows="4" name="signature" placeholder="..." runat="server"></textarea></div>
                                        <div class="mb-3">
                                            <div class="form-check form-switch"><input onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); this.checked = false; return false;" class="form-check-input" type="checkbox" id="NofifyCheckEP" runat="server"><label class="form-check-label" for="formCheck-1"><strong>Notify me about new replies</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            <asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;float:right;" OnClick="ChangeSIG" Text="Change signature" />

                                        </div>
                                </div>
                                <div class="col">
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
                                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Save&nbsp;Adress</button></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

        
                                    <div style="background-color:#ffffff !important;">
                                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                                        <div style="border:none;height:54px;overflow:hidden;background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('PaymentCard');" class="card-header py-3">
                                            <img src="/svg/payment.svg" style="width:26px;height:26px;display:inline;float:left;" />
                                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Payment</p>
                                        </div>
                                        <div id="PaymentCard" runat="server" style="display:none;animation-duration: 0.4s !important;" class="card-body animated slideInDown">
                                            <div style="width:100%;">          
                    <div style="width:100%;text-align:center;">
                        <p style="color:#6840D9;"><b>You will be charged 14.99$ once evry month</b></p>
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
                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server"> Save! </button></div>
                            </div>
                        </div>
                    </div>
                                            </div>
                                        </div>
                                    </div>
        
                    <div class="" style="background-color:#ffffff !important;">
                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                        <div id="CreatorClick" runat="server" style="border:none;height:54px;overflow:hidden;background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="SuMSettingDivExpandor('creatorsupmitform');" class="card-header py-3">
                            <img src="/svg/publish.svg" style="width:26px;height:26px;display:inline;float:left;" />
                            <p id="CraetorSecTitle" runat="server" style="color:#000000 !important;display:inline;float:left;margin:8px;">Apply to be a creator</p>
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
                                            
                                            <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; androidAPIs.VIBRATEPhone(); return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Apply&nbsp;Now</button></div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </div>
        </div>
</div>
        <asp:UpdatePanel ID="SuMSettingsUpdatepanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="EnablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="DisablePreMode" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="FixUpPageRe" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
        <div id="StartSetAnim" runat="server" class="fadeIn animated" style="width:100%;height:fit-content;background-color:#f2f2f2 !important;border-radius:0px !important; padding: 12px !important;margin-top:8px !important;">
            <div style="vertical-align:middle;display:block !important;">
                                    <img src="/svg/motionphotos.svg" style="width:auto;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;font-size:112%;">Performance Mode</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;" type="checkbox" onclick="TurnPreModeOn();" id="PerformanceModeCB" runat="server" /> </div>
                                    <p style="font-size:82%;color:#808080;float:left;margin-left:36px;">This mode removes all animations and blur from SuM Manga to improve performance on low-end devices.</p>
                                </div>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;margin-top:12px !important;margin-bottom:18px !important;">
            <div style="vertical-align:middle;display:block !important;">
                                    <svg style="display:inline;float:left;" xmlns="http://www.w3.org/2000/svg" height="32px" viewBox="0 0 24 24" width="32px" id="SuMLockIcon" fill="#231f20"><g fill="none"><path d="M0 0h24v24H0V0z"/><path d="M0 0h24v24H0V0z" opacity=".87"/></g><path d="M18 8h-1V6c0-2.76-2.24-5-5-5S7 3.24 7 6v2H6c-1.1 0-2 .9-2 2v10c0 1.1.9 2 2 2h12c1.1 0 2-.9 2-2V10c0-1.1-.9-2-2-2zm-6 9c-1.1 0-2-.9-2-2s.9-2 2-2 2 .9 2 2-.9 2-2 2zM9 8V6c0-1.66 1.34-3 3-3s3 1.34 3 3v2H9z"/></svg>
                                    <p style="color:#000000;display:inline;float:left;margin:8px;font-size:112%;">SuM Lock</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;" type="checkbox" onclick="document.getElementById('<%= SuMLockTuOnBTN.ClientID %>').click(); setTimeout(() => { androidAPIs.SuMRestart(); }, 450);" runat="server" id="SuMLockSBTN" /> </div>
                <p style="font-size:82%;color:#808080;float:left;margin-left:36px;">more privacy accomplished by requiring a biometric scan when opening the app.</p>
                <asp:Button style="display:none !important;visibility:hidden !important;" ID="SuMLockTuOnBTN" OnClick="SaveSuMLockSettingCookie" runat="server" />
                <asp:Button style="display:none !important;visibility:hidden !important;" ID="SuMLockTuOffBTN" OnClick="RemoveSuMLockSettingCookie" runat="server" />
                <script>
                    var SuMCookieCopyF3C0 = document.cookie;
                    //var SuMLockIconElm = document.getElementById('SuMLockIcon');
                    var SuMLockSBTNElm = document.getElementById('<%= SuMLockSBTN.ClientID %>');
                    if (SuMCookieCopyF3C0.includes('SuMLockMode') == true) {
                        SuMLockSBTNElm.setAttribute("checked", "checked");
                        SuMLockSBTNElm.setAttribute("onclick", "document.getElementById('<%= SuMLockTuOffBTN.ClientID %>').click(); setTimeout(() => { androidAPIs.SuMRestart(); }, 450);");
                    }
                    else {
                        SuMLockSBTNElm.setAttribute("unchecked", "unchecked");
                        SuMLockSBTNElm.setAttribute("onclick", "document.getElementById('<%= SuMLockTuOnBTN.ClientID %>').click(); setTimeout(() => { androidAPIs.SuMRestart(); }, 450);");
                    }
                </script>
                                </div>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;margin-top:12px !important;margin-bottom:18px !important;">
                                <div class="" style="vertical-align:middle;display:block !important;">
                                    <img src="/AccountETC/DarkMoon.svg" style="width:32px;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;font-size:112%;">Dark Mode</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;opacity:0.54 !important;" type="checkbox" onclick="SuMTXTShowThis('Unavailable','rgba(104,64,217,0.74)','Dark Mode','Settings'); document.getElementById('DarkModeS').checked = false; return false;" id="DarkModeS" ></div>
                                    <p style="font-size:82%;color:#808080;float:left;margin-left:36px;">Change SuM Theme to dark shades of color, This option is not recommended!</p>
                                </div>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;margin-top:12px !important;margin-bottom:18px !important;">
            <div class=""  style="vertical-align:middle;display:block !important;margin-top:12px !important;">
        <img src="/AccountETC/Noti.svg" style="width:auto;height:32px;display:inline;float:left;" />
        <p style="color:#1d1d1d;display:inline;float:left;margin:8px;font-size:112%;">Get The latest</p>
        <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:36px;height:18px;float:right;opacity:0.54 !important;" onclick="SuMTXTShowThis('Unavailable','rgba(104,64,217,0.74)','Get The latest','Settings'); document.getElementById('GetTheLatest').checked = false; return false;" type="checkbox" id="GetTheLatest" ></div>
               <p style="font-size:82%;color:#808080;float:left;margin-left:36px;">Get The latest News about mangas in general</p>
            </div>
        <div class="" style="background-color:#f2f2f2 !important;border-radius:0px !important; padding: 4px !important;margin-top:6px !important;margin-top:12px;">
        </div>
            <div class="" style="background-color:#f2f2f2 !important;border-radius:0px !important; padding: 2px !important;margin-top:8px !important;position:relative;overflow:hidden !important;">
            <div class="" style="margin-top:-2px;vertical-align:middle;display:block !important;height:100px;overflow:hidden !important;padding-bottom:280px !important;">
                <p class="" style="color:#a6a6a6;margin-left:18px;"><b style="font-size:96%;display:inline;">SuM Manga </b><b style="font-size:150%;display:inline;">·</b><b style="font-size:84%;display:inline;"> Version</b> 3.1.1 Beta</p>
                <p onload="CacheInfoLoading();" style="color:#a6a6a6;margin-left:18px;margin-top:-16px;">Cached files size: <b id="cachesizenum" style="display:inline;">calculating</b><b style="display:inline;" id="cachesizeyunit"></b><a id="ClearCacheBTN" onclick="DeleteSuMCache();" style="font-size:86%;color:#ffffff;background: rgba(104,64,217,0.62);border-color: rgb(104,64,217);display:inline-block !important;width:fit-content;border-radius:12px;padding-top:3px;padding-bottom:-2px;padding-left:8px;padding-right:8px;margin-left:8px;">Clear cache</a></p>
                <p class="" style="color:#8f8f8f94;margin-left:20px;font-size:68%;margin-top:-12px;">This website/APP is a school project and will be deleted soon!</p>
                <p class="" style="color:#8f8f8f94;margin-left:20px;font-size:68%;margin-top:0px;width:100%;height:164px;"></p>
                <!-- <a style="width:80vw;height:26vh;background-color:#000;display:block;position:fixed !important;margin-top:32vh;top:0;z-index:1999 !important;pointer-events:all !important;" onclick="androidAPIs.SUMVerification();" ></a> -->
                <!-- <a onclick="UploadReplaceFunc">BETA UPLOAD ON ANDROID TESTING BTN</a>
                <script>
                    navigator.camera.getPicture(function () {
                        // On Success logic
                        that._onPhotoURISuccess.apply(that, arguments);
                    }, function () {
                        // On Failure logic
                        cameraApp._onFail.apply(that, arguments);
                    }, {
                        quality: 50,
                        destinationType: cameraApp._destinationType.FILE_URI,
                        sourceType: PHOTOLIBRARY
                    });
            </script>-->
            </div>
        </div>
    </div>
                        <script>
                            CacheInfoLoading();
                        </script>
                        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
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
                        document.getElementById('ClearCacheBTN').style.background = 'rgba(0,0,0,0.16)';
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
                document.getElementById('ClearCacheBTN').style.background = 'rgba(0,0,0,0.16)';
                CacheInfoLoading();
            };
            var PerModeSwitchElm = document.getElementById('<%= PerformanceModeCB.ClientID %>');
            function TurnPreModeOn() {
                document.getElementById('<%= EnablePreMode.ClientID %>').click();
                setTimeout(() => {
                    document.getElementById('<%= FixUpPageRe.ClientID %>').click();
                }, 1200);
                DeleteSuMCache();
                setTimeout(() => { androidAPIs.SuMRestart(); }, 450);
            };
            function TurnPreModeOff() {
                document.getElementById('<%= DisablePreMode.ClientID %>').click();
                setTimeout(() => {
                    document.getElementById('<%= FixUpPageRe.ClientID %>').click();
                }, 1200);
                DeleteSuMCache();
                setTimeout(() => { androidAPIs.SuMRestart(); }, 450);
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

        androidAPIs.SetLightStatusBarColor();
        var ThisPageScrollContaner = document.getElementById('SuMRnadomScrollHelper');
        var ThisPageChangeStartElm = document.getElementById('ThisPageMaxNoShowScrool');
        var SuMMangaTopBarElm = document.getElementById('SuMMangaTopBar');
        var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        setTimeout(() => {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        }, 540);
        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';
        ThisPageScrollContaner.onscroll = function () {

            if (ThisPageScrollContaner.scrollTop >= MaxScrollHDetected) {

                androidAPIs.SetLightStatusBarColor();
                SuMMangaTopBarElm.style.display = 'block';

            } else {

                androidAPIs.SetLightStatusBarColor();
                SuMMangaTopBarElm.style.display = 'none';

            }

        };


        androidAPIs.SetLightStatusBarColor();
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
                                    setTimeout(() => {
                                        androidAPIs.SetLightStatusBarColor();
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