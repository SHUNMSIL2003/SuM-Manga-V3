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
                    <h3 style="color:#6840D9;display:inline;" class="text-dark mb-4"><p class="forcecolor" style="display:inline;" id="UserNameForShow0" runat="server"></p>'s Profile</h3><br /><br />
                    <div class="row mb-3">
                        <div class="col-lg-4" style="height: 90%;">
                            <div class="card mb-3">
                                <div class="card-header py-3">
                                    <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Profile Pic</p>
                                </div>
                                <div class="card-body text-center shadow">
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
                        <div class="col-lg-8">
                           <!-- <div class="row mb-3 d-none">
                                 <div class="col">
                                     <div class="card textwhite bg-primary text-white shadow">
                                        <div class="card-body">
                                            <div class="row mb-2">
                                                <div class="col">
                                                    <p class="m-0">Peformance</p>
                                                    <p class="m-0"><strong>65.2%</strong></p>
                                                </div>
                                                <div class="col-auto"><i class="fas fa-rocket fa-2x"></i></div>
                                            </div>
                                            <p class="text-white-50 small m-0"><i class="fas fa-arrow-up"></i>&nbsp;5% since last month</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="card textwhite bg-success text-white shadow">
                                        <div class="card-body">
                                            <div class="row mb-2">
                                                <div class="col">
                                                    <p class="m-0">Peformance</p>
                                                    <p class="m-0"><strong>65.2%</strong></p>
                                                </div>
                                                <div class="col-auto"><i class="fas fa-rocket fa-2x"></i></div>
                                            </div>
                                            <p class="text-white-50 small m-0"><i class="fas fa-arrow-up"></i>&nbsp;5% since last month</p>
                                        </div>
                                    </div>
                                </div>
                            </div> -->
                            <div class="row">
                                <div class="col">
                                    <div class="card shadow mb-3">
                                        <div class="card-header py-3">
                                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Account Settings</p>
                                        </div>
                                        <div class="card-body">
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
                                                    <asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="ChangeEmail" Text="Change Email" />
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
                            <p style="color:#6840D9;" class="text-primary m-0 fw-bold forcecolor">Forum Profile Settings</p>
                        </div>
                        <div class="card-body">
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
                                                <div class="mb-3"><button class="btn btn-primary btn-sm" type="submit" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" runat="server">Save&nbsp;Settings</button></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>