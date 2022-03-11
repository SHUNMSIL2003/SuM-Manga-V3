﻿<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="SuM_Manga_V3.Library" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
        }
        setTimeout(() => {
            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        }, 420);
</script>
    <style>
        img {
  border-radius: 10px;
}
.box {
	border-top-left-radius: 10px;
	border-bottom-right-radius: 10px;
    border-radius: 10px;
}
.txtmaxw {
  max-width: 175px;
}
img {
            pointer-events: none;
        }
            .floutright {
                float:right !important;
                display:inline !important;
                /*text-align: right !important ;*/
            }
            h3 {
                max-width:160px !important;
            }
            .backgroundforjim {
            background-color:#f0edf7 !important;
            border: 2px solid var(--SuMThemeColor) !important;
            margin: -2px;
        }
        .ForceMaxW {
            max-width:960px !important;
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
    <div style="background-color:var(--SuMDWhiteOP86) !important;position:fixed !important;top:0 !important;animation-duration:0.16s !important;z-index:997 !important;height:fit-content !important;width:100% !important;display:none;padding-top:6px;padding-bottom:6px;padding-left:4px;border-bottom-left-radius:22px;border-bottom-right-radius:22px;" class="animated fadeInDown" id="SuMMangaTopBar">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;" id="SuMMangaTopBarHeightHelper"></div>
        <p style="font-size:118%;margin-left:18px;margin-bottom:8px;display:block;height:fit-content;width:fit-content;" class="text-black"><img src="/svg/awesomeTblack.svg" width="30" height="30" style="" /> SuM's latest</p>
    </div>
                    <div class="animated fadeIn ForceMaxW" style="width:100%;height:100vh;padding-bottom:132px;overflow:scroll;">
                        <div id="SSElmF1C1" class="card-body">
                            <div id="MangasAvalibleDiv" runat="server" style="text-align:center;align-items:center; width:fit-content; margin:0 auto !important;margin-top:26px !important;">
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="width:fit-content;height:fit-content;margin:0 auto !important;">
                                    <nav style="" class="d-lg-flex justify-content-lg-end dataTables_paginate paging_simple_numbers">
                                        <ul style="float:right !important;border-radius:32px !important;overflow:hidden;" class="pagination">
                                            <li style="float:right !important;" id="PPS" runat="server" class="page-item disabled"><a id="PrePageG" runat="server" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true">« Prev page</span></a></li>
                                            <li style="float:right !important;" class="page-item active"><a id="CurrPageNum" runat="server" class="page-link" style="pointer-events:none;-moz-user-select: none; -webkit-user-select:none; user-select: none;border-radius:12px;">1</a></li>
                                            <li style="float:right !important;" id="NPS" runat="server" class="page-item"><a id="NextPageG" runat="server" class="page-link" href="#" aria-label="Next"><span aria-hidden="true">Next page »</span></a></li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
    <script>
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        var ThisPageScrollContaner = document.getElementById('SSElmF1C1'); 
        var SuMMangaTopBarElm = document.getElementById('SuMMangaTopBar');
        var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MaxScrollHDetected = androidAPIs.getStatusBarHeight() + 12t;
        setTimeout(() => {
            MaxScrollHDetected = androidAPIs.getStatusBarHeight() + 12t;
        }, 540);
        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';
        ThisPageScrollContaner.onscroll = function () {

            if (ThisPageScrollContaner.scrollTop >= MaxScrollHDetected) {

                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                SuMMangaTopBarElm.style.display = 'block';

            } else {

                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                SuMMangaTopBarElm.style.display = 'none';

            }

        };

        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
        setTimeout(() => {
            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
            setTimeout(() => {
                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                setTimeout(() => {
                    if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                    setTimeout(() => {
                        if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                        setTimeout(() => {
                            if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                            setTimeout(() => {
                                if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                                setTimeout(() => {
                                    if ("androidAPIs" in window == true) { var SUMSTATEBITFMC0 = getCookie('SuMUserThemeState').replace(' ', ''); if (SUMSTATEBITFMC0 == 0 || SUMSTATEBITFMC0 == '0' || SUMSTATEBITFMC0 == '' || SUMSTATEBITFMC0 == ' ' || SUMSTATEBITFMC0 == null) { androidAPIs.SetLightStatusBarColor(); } else { androidAPIs.SetDarkStatusBarColor(); } }
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</asp:Content>