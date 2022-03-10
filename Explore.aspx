﻿<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="SuM_Manga_V3.Explore" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
        /*var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();*/
        androidAPIs.SetLightStatusBarColor();
        //}
        androidAPIs.SetLightStatusBarColor();
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
        }, 420);
    </script>
    <div id="ScriptInjectorA000" style="display:none !important;visibility:hidden !important;" runat="server">
        <script>
            androidAPIs.ShowSuMToastsOverview('welcome UserName!');
        </script>
    </div>
    <style>
        * {box-sizing: border-box;}
.mySlides {display: none;}
img {vertical-align: middle;}

/* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
            /*background-color:transparent !important;*/
        }

/* Caption text */
        .text {
            color: #f2f2f2;
            font-size: 16px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
            font-family: VarelaRound !important;
        }

/* Number text (1/3 etc) */
.numbertext {
  color: #f2f2f2;
  font-size: 12px;
  padding: 8px 12px;
  position: absolute;
  top: 0;
}

/* The dots/bullets/indicators */
.dot {
  height: 6px;
  width: 6px;
  margin: 0 2px;
  background-color: rgba(255,255,255,0.32);
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: #fffffff0;
}

/* Fading animation */
.fade {
  -webkit-animation-name: fade;
  -webkit-animation-duration: 4s;
  animation-name: fade;
  animation-duration: 4s;
}

@-webkit-keyframes fade {
  from {opacity: .99} 
  to {opacity: 1}
}

@keyframes fade {
  from {opacity: .99} 
  to {opacity: 1}
}

/* On smaller screens, decrease text size */
@media only screen and (max-width: 300px) {
  .text {font-size: 16px}
}
/*ClickEFFECT*/
.ClickEffect:active {
    width: 70px;
    height: 74px;
}
    </style>
<div style="background-color:rgba(242,242,242) !important;width:100% !important;height:100% !important;margin:0 auto !important">
    <div style="background-color:rgba(242,242,242,0.74) !important;position:fixed !important;top:0 !important;z-index:997 !important;height:fit-content !important;width:100vw !important;display:block;padding:0px !important;" class="" id="SuMMangaTopBar">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;overflow:hidden !important;" id="SuMMangaTopBarHeightHelper"></div>
    </div>
    <div id="AnimatedMainContHEx" runat="server" class="fadeIn animated" style="height:100% !important;width:100vw !important;max-width:720px !important;margin:0 auto !important;overflow-y:scroll;height: 100vh;   scroll-snap-type: y mandatory !important; scroll-behavior: smooth !important; scroll-padding-top:32px !important;scroll-padding-bottom:32px !important">
        <div style="width:100% !important;height:12px;margin:0 auto !important;" id="SuMStatusBarHeightFixUpF0C0"></div>
        <script>
        var StatusBarHeightValueFromSuMAndroidAPIsF0C0 = androidAPIs.getStatusBarHeight();
        document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C0 + 12) + 'px';
        </script>
<div class="slideshow-container" id="cardscontain" runat="server" style="border:0.5px #dfdfdf solid !important;scroll-margin-top:38px; border-radius:20px;width:calc(100% - 24px) !important;height:fit-content !important;overflow:hidden !important;margin-top:12px;margin-left:12px;display:block;background-color:rgba(0,0,0,0.74) !important;transition: background-color 0.32s ease !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;">
    <div id="ThisPageTopBarFixer" style="background-color:transparent !important;width:100% !important;height:fit-content !important;display:block;margin-bottom:-16px;padding-top:8px !important;">
        <img id="ThisPageSBarFixUpPropElm0" style="display:inline;margin-left:16px;margin-top:8px;float:left;" width="38" height="38" src="/svg/awesomeTW.svg" />
        <p id="ThisPageSBarFixUpPropElm1" style="color:#fffffff0 !important;font-size:128%;margin-top:12px;margin-left:6px;display:inline;float:left;">The latest of manga !</p>
    </div>
    <script>/*
        var ThisPageSBarFixUpPropElmVar0 = document.getElementById('ThisPageSBarFixUpPropElm0');
        var ThisPageSBarFixUpPropElmVar1 = document.getElementById('ThisPageSBarFixUpPropElm1');
        var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
        ThisPageSBarFixUpPropElmVar0.style.marginTop = (12 + StatusBarHeightValue) + 'px !important';
        ThisPageSBarFixUpPropElmVar1.style.marginTop = (12 + StatusBarHeightValue) + 'px !important';*/
    </script>
    <div style="background-color:transparent !important;width:100%;height:fit-content;">
    <div id="cardstoshow" runat="server" style="margin:0 auto !important;border-radius:18px !important;margin-top:12px !important;width:fit-content;height:fit-content;overflow:hidden !important;width:calc(100% - 24px) !important;overflow:hidden !important;margin:12px;margin-bottom:2px !important;">
<div class="mySlides fade" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;padding:12px;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:#ffffff;font-size:160%;display:block;">Blue Exorcist</h1>
    <p style="color:#f2f2f2"></p>
    </a>
    <div style="background-color:rgba(145, 114, 227, 0.58);width:94px;height:42px;border-top-right-radius:16px;float:right;margin-bottom:0px;margin-right:0px;">
        <a href="#">Read Now</a>
    </div>
</div>
        <div class="mySlides fade" style="overflow:hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:#ffffff;font-size:160%;">Blue Exorcist</h1>
    <p style="text-align:center;vertical-align:middle;"></p>
    </a>
</div>
        <div class="mySlides fade" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:#ffffff;font-size:160%;">Blue Exorcist</h1>
    <p></p>
    </a>
</div>
     </div>
        </div>
    <div id="cardsdots" runat="server" style="text-align:center;background-color:transparent !important;width:100%;height:fit-content;margin-top:-6px !important;border-bottom-right-radius:18px;border-bottom-left-radius:18px;">
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span> 
</div>
</div>
<script>
    var SlideShowCardElm = document.getElementById('<%= cardscontain.ClientID %>');
    var slideIndex = 0;
    showSlides();
    function showSlides() {
        var i;
        var slides = document.getElementsByClassName("mySlides");
        var dots = document.getElementsByClassName("dot");
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slideIndex++;
        if (slideIndex > slides.length) { slideIndex = 1 }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";
        SlideShowCardElm.style.backgroundColor = document.getElementById('CardNuM' + (slideIndex) + 'Theme').innerText;
        setTimeout(showSlides, 3360); // Change image every 2 seconds
    }
</script><!--
<script src="/dragscroll.js"></script> -->
        <style>
            .XYFitContantSuMUpdatePanelFixUpScroll {
                width:fit-content !important;
                height:fit-content !important;
            }
        </style>
        <div id="RecentsCont" runat="server" style="scroll-snap-align:start !important;scroll-snap-stop: always !important;" class="animated fadeInRight">
        <asp:Button ID="UPDATERESESNTS" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
                        <div id="RecentsSuperCont" runat="server" style="display:block;">
                            <div id="RescentBody" runat="server" style="border:0.5px #dfdfdf solid !important;height:168px!important; width:calc(100% - 24px);overflow:hidden;border-radius:20px;background-color:var(--SuMThemeColorOP74) !important;margin:0 auto !important;padding:18px;padding-left:4px;margin-top:2px !important;overflow-x:scroll !important;overflow-y:hidden !important;margin-top:16px !important;transition: background-color 0.32s ease !important;">
                                <img src="/svg/historyTW.svg" width="30" height="30" style="display:inline;float:left !important;margin-left:12px !important;margin-right:2px !important;margin-top:0px !important;" />
                                <p style="font-size:132%;height:fit-content;width:calc(100% - 50px) !important;color:#fffffff0;float:left !important;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;overflow: hidden;text-align:center !important;display:block !important;margin-bottom:6px !important;text-align:left !important;margin-top:0px !important;margin-left:2px;">Recently viewed</p>
                                <div id="RecentScrollContS" style="width:calc(100% + 15px);margin:0 auto !important;margin-left:0px !important;overflow-y:hidden;overflow-x:scroll !important;">
                                    <asp:UpdatePanel ID="RESENTSUPATEPANLE" runat="server" UpdateMode="Conditional" style="width:fit-content;height:fit-content;">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="UPDATERESESNTS" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Panel runat="server" style="width:fit-content;height:fit-content;">
                                                <div class=" " id="Recent" runat="server" style="padding-left:-8px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;height:100%;display:flex !important;width:fit-content !important;overflow-x:scroll !important;overflow-y:hidden !important;">
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <script>
                            if (document.cookie.includes('SuMCurrentUser') == false) {
                                document.getElementById('<%= RecentsSuperCont.ClientID %>').style.display = 'none';
                            }
                            else {
                                document.getElementById('<%= RecentsSuperCont.ClientID %>').style.display = 'block';
                            }
                        </script>
        <script>
            setTimeout(() => {
                document.getElementById('<%= UPDATERESESNTS.ClientID %>').click();
            }, 10);
            setTimeout(() => {
                var currRecentItemThemeColorFS = document.getElementById('RecentItem1').style.backgroundColor;
                if (currRecentItemThemeColorFS != null) {
                    document.getElementById('<%= RescentBody.ClientID %>').style.backgroundColor = currRecentItemThemeColorFS;
                }
            }, 360);
            var isScrollingSuMRecentsFuncF0CS;
            document.getElementById('RecentScrollContS').onscroll = function () {

                window.clearTimeout(isScrollingSuMRecentsFuncF0CS);

                isScrollingSuMRecentsFuncF0CS = setTimeout(function () {

                    var RecentF0CSElm = document.getElementById('RecentScrollContS');
                    var RescentBodyF0CSElm = document.getElementById('<%= RescentBody.ClientID %>');
                    var currLeftID = Math.round(RecentF0CSElm.scrollLeft / 112) + 1;
                    var currRecentItemThemeColor = document.getElementById('RecentItem' + currLeftID).style.backgroundColor;
                    if (currRecentItemThemeColor != null) {
                        RescentBodyF0CSElm.style.backgroundColor = currRecentItemThemeColor;
                    }

                }, 32);

            };
        </script>
        </div>
         <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="CategoryX" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Action</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Action" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;" >
            </div>
        </div>

        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div1" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Fantasy</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Fantasy" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div2" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Comedy</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Comedy" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div3" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Supernatural</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Supernatural" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div4" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Sci-Fi</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="SciFi" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div5" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Drama</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Drama" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div6" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Mystery</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="Mystery" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <!-- br placeholder -->
        <div style="border:0.5px #dfdfdf solid !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;height:fit-content;max-height:302px !important; width:calc(100% - 24px);overflow:hidden; background-color:#ffffff !important;margin-left:12px;margin-top:18px !important;display:block !important;border-radius:20px;padding:12px;padding-top:22px;" id="Div7" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;display:inline;">Slice of Life</h2>
            <a style="display:inline-block; width:2px;height:18px;background-color:rgba(0,0,0,0.32);margin-bottom:-3px;border-radius:1px;margin-left:5px;overflow:hidden;"></a><h6 style="color:rgba(0,0,0,0.64);margin-left:2px;margin-bottom:-18px;display:inline;">Newest 12</h6>
            <div id="SliceofLife" runat="server" style="  scroll-snap-type: x mandatory;padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        <div style="display:block !important;width:100% !important;height:232px !important;background-color:transparent !important;text-align:center;margin:0 auto !important;"></div>
    </div>
    <script>
        androidAPIs.SetLightStatusBarColor();
        var ThisPageScrollContaner = document.getElementById('<%= AnimatedMainContHEx.ClientID %>');
        var ThisPageChangeStartElm = document.getElementById('<%= cardscontain.ClientID %>');
        var HeightFixrFASIT208CutJK3 = document.getElementById('<%= cardstoshow.ClientID %>').offsetHeight + 2;
        var SuMMangaTopBarElm = document.getElementById('SuMMangaTopBar');
        var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MaxScrollHDetected = 24;
        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';

        androidAPIs.SetLightStatusBarColor();
        androidAPIs.SetLightStatusBarColor();
        var StatusBarHeightValueFromSuMAndroidAPIsF0C1 = androidAPIs.getStatusBarHeight();
        document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
            document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
            setTimeout(() => {
                androidAPIs.SetLightStatusBarColor();
                document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                setTimeout(() => {
                    androidAPIs.SetLightStatusBarColor();
                    setTimeout(() => {
                        androidAPIs.SetLightStatusBarColor();
                        setTimeout(() => {
                            androidAPIs.SetLightStatusBarColor();
                            document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                            setTimeout(() => {
                                androidAPIs.SetLightStatusBarColor();
                                setTimeout(() => {
                                    androidAPIs.SetLightStatusBarColor();
                                    document.getElementById('SuMStatusBarHeightFixUpF0C0').style.height = (StatusBarHeightValueFromSuMAndroidAPIsF0C1 + 12) + 'px';
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</div>
</asp:Content>