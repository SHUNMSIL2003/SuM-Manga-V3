<%@ Page Language="C#" enableEventValidation="false" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SuM_Manga_V3.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
        .forcecolor2 {
            background-color:#6840D9 !important;
            border-color:#6840D9 !important;
        }
        .ForceMaxW {
            max-width:1200px !important;
            margin: 0 auto;
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
    </style>
                        <div class="card shadow ForceMaxW">
                        <div class="card-header py-3">
                            <p class="text-primary m-0 fw-bold forcecolor">SuM - Info</p>
                        </div>
                        <div class="card-body"><br />
                            <h1 style="color:#6840D9;padding-left:16px;">Shun Manga</h1>
                            <h3 class="text-dark mb-4" style="padding-left:16px;">SuM is a grate website to access high quality Manga, it comes with a cost of 14.99 USD per month.<br></h3>
                            <!-- <p style="float:right;" id="dataTable_info" class="dataTables_info" role="status" aria-live="polite">Start Exploring !</p> -->
                            <a id="MPB" class="btn btn-primary btn-lg" href="/AccountETC/LoginETC.aspx" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;margin-bottom:12px;margin-right:12px;" data-bss-hover-animate="pulse" runat="server">Login Or Sign Up</a>
                        </div>
                    </div>
    <br />
                    <div class="card shadow ForceMaxW">
                        <!-- <div class="card-header py-3">
                            <p class="text-primary m-0 fw-bold forcecolor">SuM - More</p>
                        </div> -->
                        <div class="card-body"><br />
    <div class="row">
        <div class="col-md-4">
            <h2 style="color:#6840D9;">User agreement.</h2>
            <p class="text-dark mb-4">
                By creating an account u automaticly agree to thos tirms.
            </p>
            <a style="margin-bottom:12px;">
                <a class="btn btn-primary btn-sm forcecolor2" data-bss-hover-animate="pulse" href="../UserAgreementBD.aspx"> Tirms & Con... &raquo;</a>
            </a><br /><br />
        </div>
        <div class="col-md-4">
            <h2 style="color:#6840D9;">Need Help?</h2>
            <p class="text-dark mb-4">
                Contact is active from Monday-Friday 10:00AM-6:00PM.
            </p>
            <a style="margin-bottom:12px;">
                <a class="btn btn-primary btn-sm forcecolor2" data-bss-hover-animate="pulse" href="../Contact.aspx">Contact Us! &raquo;</a>
            </a><br /><br />
        </div>
        <div class="col-md-4">
            <h2 style="color:#6840D9;">Social Meadia...</h2>
            <p class="text-dark mb-4">
                Our offical Twitter,U can get the status and reports about our site from there.
            </p>
            <a style="margin-bottom:12px;">
                <a class="btn btn-primary btn-sm forcecolor2" data-bss-hover-animate="pulse" href="https://twitter.com/">Learn more &raquo;</a>
            </a><br /><br />
        </div>
    </div>
                        </div>
                    </div>
</asp:Content>
