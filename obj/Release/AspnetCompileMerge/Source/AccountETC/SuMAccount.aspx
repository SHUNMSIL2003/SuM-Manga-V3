<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="SuMAccount.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.SuMAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hide {
             display: none;
        }
        .forcecolor {
            color:#6840D9 !important;
        }
        body {
            overflow: hidden; /* Hide scrollbars */
        }
        /* Hide scrollbar for Chrome, Safari and Opera */
        ::-webkit-scrollbar {
            display: none;
        }

        /* Hide scrollbar for IE, Edge and Firefox */
        body {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }
        img {
            pointer-events:all !important;
        }
    </style>
    <div style="width:100% !important;height:100% !important;background-color:#f2f2f2 !important;">
        <br />
                    <h3 style="color:#6840D9;display:inline;" class="text-dark mb-4"><p class="forcecolor" style="display:inline;" id="UserNameForShow0" runat="server"></p>'s Profile</h3>
                        <div style="padding-top:0px !important;padding-bottom:12px !important;background-color:#ffffff !important;margin-top:24px !important;">
                            <div class="">
                                <div class="card-header py-3" style="background-color:#ffffff !important;">
                                    <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Profile Pic</p>
                                </div>
                                <div class="card-body text-center" style="background-color:#ffffff !important;">
                                    <img class="rounded-circle mb-3 mt-4 lazyload" id="PFP" src="/assets/img/avatars/DeafultPFP.jpg" width="160" height="160" runat="server">

                                    <div class="mb-3"><asp:Button CssClass="btn btn-primary btn-sm" ID="chpfp000" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="ChangePFP" Text="Save Pic" />
                                    <!--    <button class="btn btn-primary btn-sm" type="button" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" runat="server" onclick="ChangePFP" >Apply Change</button> --> </div>

                                    <script>
                                        document.getElementById("MainContent_PFP").onclick = function () {

                                            document.getElementById("MainContent_SuMCustomPFP").click();

                                        };
                                        var loadFile = function (event) {
                                            var image = document.getElementById('MainContent_PFP');
                                            image.src = URL.createObjectURL(event.target.files[0]);
                                        };
                    </script>
                                   <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" ID="SuMCustomPFP" runat="server" HiddenField="true" />

                                </div>
                            </div>
                        </div>
        <div style="padding-top:0px !important;padding-bottom:12px !important;background-color:#ffffff !important;margin-top:24px !important;" class="mb-3">
                                        <div class="card-header py-3" style="background-color:#ffffff !important;">
                                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Account Settings</p>
                                        </div>
                                        <div class="card-body" style="background-color:#ffffff !important;">
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
                                                    <asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" OnClick="ChangeEmail" Text="Change Email" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                    <div style="padding-top:0px !important;padding-bottom:12px !important;background-color:#ffffff !important;margin-top:24px !important;">
                        <div class="card-header py-3" style="background-color:#ffffff !important">
                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Forum Profile Settings</p>
                        </div>
                        <div class="card-body" style="background-color:#ffffff !important;">
                            <div class="row">
                                <div class="col-md-6">
                                    <form>
                                        <div class="mb-3"><label class="form-label" for="signature"><strong>Signature</strong><br></label><textarea class="form-control" id="SignaturePE" rows="4" name="signature" placeholder="..." runat="server"></textarea></div>
                                        <div class="mb-3">
                                            <div class="form-check form-switch"><input class="form-check-input" type="checkbox" id="NofifyCheckEP" runat="server"><label class="form-check-label" for="formCheck-1"><strong>Notify me about new replies</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            <asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="ChangeSIG" Text="Change signature" />

                                        </div>
                                    </form>
                                </div>
                                <div class="col">
                                    <div >
                                        <!-- <div class="card-header py-3">
                                            <p class="text-primary m-0 fw-bold">Contact Settings</p>
                                        </div> -->
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
                                                <div class="mb-3"><button class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" runat="server">Save&nbsp;Settings</button></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

        
                                    <div class="card mb-3">
                                        <div class="card-header py-3">
                                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Payment Settings</p>
                                        </div>
                                        <div class="card-body">
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
                                <div class="mb-3"><button class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;width:64px;" runat="server"> Save! </button></div>
                            </div>
                        </div>
                    </div>
                                            </div>
                                        </div>
                                    </div>
        
                    <div class="card mb-5">
                        <div class="card-header py-3">
                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Apply to be a creator</p>
                        </div>
                        <div class="card-body" id="creatorsupmitform" runat="server">
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
                                            <div class="form-check form-switch"><input class="form-check-input" type="checkbox" id="Checkbox1" runat="server" checked><label class="form-check-label" for="formCheck-1"><strong>Notify me about the prosses on my email!</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            <div class="mb-3">
                                                <asp:Button CssClass="btn btn-primary btn-sm" style="float:right;" runat="server" Text="Apply Now" BorderColor="#6840d9" BackColor="#6840d9" />
                                                <!-- <button class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" runat="server">Apply&nbsp;Now</button> -->
                                            </div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>

        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </div>
</asp:Content>