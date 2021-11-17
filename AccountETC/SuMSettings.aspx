<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="SuMSettings.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.SuMSettings" %>

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
    </style><br />
                    <h3 style="color:#6840D9;display:inline;" class="text-dark mb-4"><p class="forcecolor" style="display:inline;" id="UserNameForShow0" runat="server"></p> SuM Settings</h3><br /><br />
                    <div class="row mb-3">
                        <div class="col-lg-4" style="height: 90%;">
                            <div class="card mb-3" style="margin-top:2px !important;">
                                <div class="card-header py-3">
                                    <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">SuM Dark Mode</p>
                                </div>
                                <div class="card-body text-center shadow" style="vertical-align:middle;">
                                    <img src="/AccountETC/DarkMoon.svg" style="width:auto;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;">Enable Dark Mode</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;" type="checkbox" id="DarkModeS" runat="server"></div>
                                </div>
                            </div>
                            <div class="card mb-3" style="margin-bottom:2px !important;">
                                <div class="card-header py-3">
                                    <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">SuM Live Notification</p>
                                </div>
                                <div class="card-body text-center shadow" style="vertical-align:middle;">
                                    <img src="/AccountETC/Noti.svg" style="width:auto;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;">Get The latest</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:36px;height:18px;float:right;" type="checkbox" id="Checkbox1" runat="server"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-8">
                            <div class="row">
                                <div class="col">
                                    <div class="card shadow mb-3">
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
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card shadow mb-5">
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
                                            <div class="form-check form-switch"><input class="form-check-input" type="checkbox" id="NofifyCheckEP" runat="server" checked><label class="form-check-label" for="formCheck-1"><strong>Notify me about the prosses on my email!</strong></label></div>
                                        </div>
                                        <div class="mb-3">
                                            <div class="mb-3">
                                                <asp:Button CssClass="btn btn-primary btn-sm" style="float:right;" OnClick="BACApply" runat="server" Text="Apply Now" BorderColor="#6840d9" BackColor="#6840d9" />
                                                <!-- <button class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" runat="server">Apply&nbsp;Now</button> -->
                                            </div>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
