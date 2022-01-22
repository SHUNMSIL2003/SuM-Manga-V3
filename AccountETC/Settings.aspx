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
    <div style="height:100%;width:100%; padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:#f2f2f2 !important;margin:0 auto !important; margin-top:0px !important;">
        <div style="width:100vw;height:22px;background-color:#f2f2f2;position:relative;z-index:998;margin-top:-8px !important;"></div>
        <div style="background-color:#ffffff !important;border-radius:0px !important; padding: 4px !important;margin-top:0px !important; margin-bottom:0px !important;z-index:998;position:relative;">
            <a runat="server" id="AccountSettingsOrLogin" onclick="" href="/AccountETC/SuMAccount.aspx" style="height:112px !important;width:calc(100vw - 56px) !important;background-color:transparent !important;display:block !important;margin-top:8px;margin-bottom:8px; margin-left:8px;position:relative;z-index:998;">
            <img class="animated pulse" id="PFP" runat="server" style="width:84px !important;height:84px !important;border-radius:50% !important;float:left;display:inline;margin-bottom:6px;" src="/AccountETC/UsersUploads/DeafultPFP.jpg" />
                <div class="fadeIn animated" style="float:left;display:inline;margin-left:8px;">
                    <h3 id="SuMUserName" runat="server" style="color:#1d1d1d;">Loging to SuM</h3>
                    <h6  id="SignedWith" runat="server" style="color:#919191;font-size:74%;"></h6>
                </div>
            </a>
            <asp:ImageButton ID="LogOutBTN" runat="server" ImageUrl="/svg/logout.svg" Width="28px" Height="28px" BackColor="Transparent" ForeColor="Transparent" OnClick="LogOut" style="float:right !important;margin-right:8px;margin-top:-38px !important;" />
        </div>
        <div id="UserSettingsCards" class="" style="display:block;height:0px;overflow:hidden;transition: height 0.4s;background-color:#ffffff;">
            <div style="width:100% !important;height:100% !important;background-color:#ffffff !important;">

                        <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;width:100vw;height:fit-content;">
                            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                                <div onclick="if (document.getElementById('PFPDiv').style.display == 'none') { document.getElementById('PFPDiv').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('PFPDiv').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('PFPDiv').offsetHeight + 'px'; document.getElementById('PFPDiv').style.display = 'none'; }" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                    <img src="/svg/face.svg" style="width:26px;height:26px;display:inline;float:left;" />
                                    <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Change profile pic</p>
                                </div>
                                <div id="PFPDiv" class="card-body text-center animated slideInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;height:fit-content;position:relative;z-index:996;">
                                    <a onclick="document.getElementById('MainContent_SuMCustomPFP').click();" style="width:fit-content;height:fit-content;">
                                    <img style="position:relative !important;z-index:999 !important;" class="rounded-circle mb-3 mt-4 lazyload" id="PFPC" src="/assets/img/avatars/DeafultPFP.jpg" width="160" height="160" runat="server">
                                    </a>
                                    <div class="mb-3">
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="chpfp000" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFP" Text="Save Pic" />
                                        <p style="display:inline-block !important;"> Or </p>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="RemovePFP" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);display:inline-block !important;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" OnClick="ChangePFPAtRandom" Text="Reset PFP" />
                                    </div>

                                    <script>
                                        var loadFile = function (event) {
                                            var image = document.getElementById('MainContent_PFP');
                                            image.src = URL.createObjectURL(event.target.files[0]);
                                        };
                                        /*if (document.getElementById('X').style.display == 'none') {
                                            document.getElementById('X').style.display = 'block';
                                            document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('X').offsetHeight + 'px';
                                        }
                                        else
                                        {
                                            document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('X').offsetHeight + 'px';
                                            document.getElementById('X').style.display = 'none';
                                        }*/
                                        //document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('X').offsetHeight + 'px';
                                        
                                        /*if (document.getElementById('UserSettingsCards').style.height == '0px') {
                                            document.getElementById('UserSettingsCards').style.height = '232px';
                                        }
                                        else {
                                            document.getElementById('UserSettingsCards').style.height = '0px';
                                            document.getElementById('PFPDiv').style.display = 'none';
                                            document.getElementById('ChangeEmailDiv').style.display = 'none';
                                            document.getElementById('SigAndMore').style.display = 'none';
                                            document.getElementById('creatorsupmitform').style.display = 'none';
                                            document.getElementById('MainContent_PaymentCard').style.display = 'none';
                                            document.getElementById('ManageDevicesCard').style.display = 'none';
                                        }*/
                                        //document.getElementById('UserSettingsCards').style.height = (document.getElementById('UserSettingsCards').style.height == 'fit-content') ? '0px;' : 'fit-content';
            </script>
                                   <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;" ID="SuMCustomPFP" runat="server" HiddenField="true" />

                                </div>
                        </div>
                <!-- Device Manege fucherdsafsd -->
                <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;display:none !important;">
                    <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                    <div onclick="if (document.getElementById('ManageDevicesCard').style.display == 'none') { document.getElementById('ManageDevicesCard').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('ManageDevicesCard').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('ManageDevicesCard').offsetHeight + 'px'; document.getElementById('ManageDevicesCard').style.display = 'none'; }" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                        <img src="/svg/devices.svg" style="width:26px;height:26px;display:inline;float:left;" />
                        <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Manage Devices</p>
                    </div>
                    <div class="animated fadeInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;height:fit-content;position:relative;z-index:996" id="ManageDevicesCard">
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
                                        <div onclick="if (document.getElementById('ChangeEmailDiv').style.display == 'none') { document.getElementById('ChangeEmailDiv').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('ChangeEmailDiv').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('ChangeEmailDiv').offsetHeight + 'px'; document.getElementById('ChangeEmailDiv').style.display = 'none'; }" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                                            <img src="/svg/attachemail.svg" style="width:26px;height:26px;display:inline;float:left;" />
                                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Change Email</p>
                                        </div>
                                        <div id="ChangeEmailDiv" class="card-body animated fadeInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;position:relative;z-index:996;">
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
                                                    <button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Change Email</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                    <div style="padding-top:0px !important;padding-bottom:0px !important;background-color:#ffffff !important;margin-top:0px !important;">
                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                        <div onclick="if (document.getElementById('SigAndMore').style.display == 'none') { document.getElementById('SigAndMore').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('SigAndMore').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('SigAndMore').offsetHeight + 'px'; document.getElementById('SigAndMore').style.display = 'none'; }" class="card-header py-3" style="background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;height:54px;overflow:hidden;border:none;">
                            <img src="/svg/feed.svg" style="width:26px;height:26px;display:inline;float:left;" />
                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Signature & more</p>
                        </div>
                        <div id="SigAndMore" class="card-body animated slideInDown" style="animation-duration: 0.4s !important;background-color:#ffffff !important;display:none;">
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="mb-3"><label class="form-label" for="signature"><strong>Signature</strong><br></label><textarea class="form-control" id="SignaturePE" rows="4" name="signature" placeholder="..." runat="server"></textarea></div>
                                        <div class="mb-3">
                                            <div class="form-check form-switch"><input onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block';this.checked = false; return false;" class="form-check-input" type="checkbox" id="NofifyCheckEP" runat="server"><label class="form-check-label" for="formCheck-1"><strong>Notify me about new replies</strong></label></div>
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
                                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Save&nbsp;Adress</button></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

        
                                    <div style="background-color:#ffffff !important;">
                                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                                        <div style="border:none;height:54px;overflow:hidden;background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="if (document.getElementById('MainContent_PaymentCard').style.display == 'none') { document.getElementById('MainContent_PaymentCard').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('MainContent_PaymentCard').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('MainContent_PaymentCard').offsetHeight + 'px'; document.getElementById('MainContent_PaymentCard').style.display = 'none'; }" class="card-header py-3">
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
                                <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server"> Save! </button></div>
                            </div>
                        </div>
                    </div>
                                            </div>
                                        </div>
                                    </div>
        
                    <div class="" style="background-color:#ffffff !important;">
                        <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
                        <div style="border:none;height:54px;overflow:hidden;background-color:#ffffff !important;position:relative;z-index:997;display: flex; align-items: center;flex-direction: row;" onclick="if (document.getElementById('creatorsupmitform').style.display == 'none') { document.getElementById('creatorsupmitform').style.display = 'block'; document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight + document.getElementById('creatorsupmitform').offsetHeight + 'px'; } else { document.getElementById('UserSettingsCards').style.height = document.getElementById('UserSettingsCards').offsetHeight - document.getElementById('creatorsupmitform').offsetHeight + 'px'; document.getElementById('creatorsupmitform').style.display = 'none'; }" class="card-header py-3">
                            <img src="/svg/publish.svg" style="width:26px;height:26px;display:inline;float:left;" />
                            <p style="color:#000000 !important;display:inline;float:left;margin:8px;">Apply to be a creator</p>
                        </div>
                        <div class="card-body animated slideInDown" style="display:none;animation-duration: 0.4s !important;" id="creatorsupmitform">
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
                                            
                                            <div class="mb-3"><button onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block'; return false;" class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:fit-content;border-radius:16px;padding-top:5px;padding-bottom:5px;padding-left:16px;padding-right:16px;" runat="server">Apply&nbsp;Now</button></div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </div>
        </div>
        <div style="background-color:#ffffff !important;border-radius:0px !important; padding: 12px !important;margin-top:8px !important;">
                                <div class="fadeIn animated" style="vertical-align:middle;display:block !important;">
                                    <img src="/AccountETC/DarkMoon.svg" style="width:auto;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;">Enable Dark Mode</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;" type="checkbox" onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block';document.getElementById('DarkModeS').checked = false; return false;" id="DarkModeS" ></div>
                                    <p style="font-size:60%;color:#808080;float:left;margin-left:36px;">Change SuM Theme to dark shades of color, This option is not recommended!</p>
                                </div>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:86vw;opacity:0.26;margin:0px;margin-block:0px;"/>
            <div class="fadeIn animated"  style="vertical-align:middle;display:block !important;margin-top:12px !important;">
        <img src="/AccountETC/Noti.svg" style="width:auto;height:32px;display:inline;float:left;" />
        <p style="color:#1d1d1d;display:inline;float:left;margin:8px;">Get The latest</p>
        <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:36px;height:18px;float:right;" onclick="document.getElementById('MainContent_SettingsUnavaliblePOPUP').style.display = 'block';document.getElementById('GetTheLatest').checked = false; return false;" type="checkbox" id="GetTheLatest" ></div>
               <p style="font-size:60%;color:#808080;float:left;margin-left:36px;">Get The latest News about mangas in general</p>
            </div>
        <div class="fadeIn animated" style="background-color:#ffffff !important;border-radius:0px !important; padding: 4px !important;margin-top:6px !important;margin-top:12px;">
        </div>
    </div>
        <div class="animated fadeIn" style="background-color:#ffffff !important;border-radius:0px !important; padding: 2px !important;margin-top:8px !important;position:relative;overflow:hidden !important;">
            <div class="fadeIn animated" style="margin-top:-4px;vertical-align:middle;display:block !important;height:64px;overflow:hidden !important;">
                <p class="" style="color:#a6a6a6;margin-left:18px;"><b style="font-size:96%;display:inline;">SuM Manga </b><b style="font-size:150%;display:inline;">·</b><b style="font-size:84%;display:inline;"> Version</b> 2.7.1 Beta</p>
                <p class="" style="color:#8f8f8f;margin-left:28px;font-size:68%;margin-top:-12px;">This website/APP is a school project and will be deleted soon!</p>
            </div>
        </div>
        </div>
    <script>
        document.getElementById('AccountOffline').style.display = 'block';
    </script>
</asp:Content>