<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="SuM_Manga_V3.Explore" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
            androidAPIs.SetLightStatusBarColor();
        }
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
  background-color:transparent !important;
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
  font-family:VarelaRound !important;
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
  background-color: #bbb;
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: #717171;
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
    <div style="background-color:rgba(255,255,255,0.86) !important;position:fixed !important;top:0 !important;animation-duration:0.16s !important;z-index:997 !important;height:fit-content !important;width:100% !important;display:none;padding-top:6px;padding-bottom:6px;padding-left:4px;border-bottom-left-radius:22px;border-bottom-right-radius:22px;" class="animated fadeInDown" id="SuMMangaTopBar">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;" id="SuMMangaTopBarHeightHelper"></div>
        <p style="font-size:118%;margin-left:18px;margin-bottom:8px;display:block;height:fit-content;width:fit-content;" class="text-black"><img src="/svg/awesomeTblack.svg" width="30" height="30" style="" /> SuM's latest</p>
    </div>
    <div id="AnimatedMainContHEx" runat="server" class="fadeIn animated" style="height:100% !important;width:100vw !important;max-width:720px !important;margin:0 auto !important;overflow-y:scroll;">
<div class="slideshow-container" id="cardscontain" runat="server" style="width:100% !important;height:fit-content !important;overflow:hidden !important;">
    <div id="ThisPageTopBarFixer" style="background-color:#f2f2f2 !important;width:100% !important;height:fit-content !important;display:block;margin-bottom:-6px;padding-top:8px !important;">
        <img id="ThisPageSBarFixUpPropElm0" style="display:inline;margin-left:16px;margin-top:34px;float:left;" width="38" height="38" src="/svg/awesomeTblack.svg" />
        <p id="ThisPageSBarFixUpPropElm1" style="color:#000000f0 !important;font-size:128%;margin-top:36px;margin-left:6px;display:inline;float:left;">Latest of manga !</p>
    </div>
    <script>
        var ThisPageSBarFixUpPropElmVar0 = document.getElementById('ThisPageSBarFixUpPropElm0');
        var ThisPageSBarFixUpPropElmVar1 = document.getElementById('ThisPageSBarFixUpPropElm1');
        var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
        ThisPageSBarFixUpPropElmVar0.style.marginTop = (12 + StatusBarHeightValue) + 'px !important';
        ThisPageSBarFixUpPropElmVar1.style.marginTop = (12 + StatusBarHeightValue) + 'px !important';
    </script>
    <div style="background-color:#f2f2f2 !important;width:100%;height:fit-content;">
    <div id="cardstoshow" runat="server" style="margin:0 auto !important;border-radius:12px !important;margin-bottom:12px !important;margin-top:12px !important;width:fit-content;height:fit-content;overflow:hidden !important;">
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
    <div id="cardsdots" runat="server" style="text-align:center;background-color:#f2f2f2 !important;width:100%;height:fit-content;margin-top:-6px !important;border-bottom-right-radius:18px;border-bottom-left-radius:18px;">
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span> 
</div>
</div>
<script>
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
        setTimeout(showSlides, 4000); // Change image every 2 seconds
    }
</script><!--
<script src="/dragscroll.js"></script> -->
        <div id="RecentsCont" runat="server" class="animated fadeIn">
        <asp:Button ID="UPDATERESESNTS" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
        <asp:UpdatePanel ID="RESENTSUPATEPANLE" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="UPDATERESESNTS" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="RecentsSuperCont" runat="server" style="display:block;">
                            <img src="/svg/history.svg" width="30" height="30" style="display:inline;float:left !important;margin-left:12px !important;margin-right:2px !important;margin-top:28px !important;" />
                            <p style="font-size:132%;height:fit-content;width:calc(100% - 50px) !important;color:rgba(104,64,217,0.74);float:left !important;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;overflow: hidden;text-align:center !important;display:block !important;margin-bottom:7px !important;text-align:left !important;margin-top:28px !important;">Recently viewed </p>
                            <div id="RescentBody" runat="server" style="height:132px!important; width:calc(100% - 24px);overflow:hidden;border-radius:16px;background-color:rgba(104,64,217,0.74) !important;margin:0 auto !important;padding:18px;padding-left:4px;margin-top:2px !important;overflow-x:scroll !important;overflow-y:hidden !important;">
                                <div class=" " id="Recent" runat="server" style="padding-left:-8px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;height:100%;display:flex !important;width:fit-content !important;overflow-x:scroll !important;overflow-y:hidden !important;">
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
        </asp:UpdatePanel>
        <script>
            setTimeout(() => {
                document.getElementById('<%= UPDATERESESNTS.ClientID %>').click();
            }, 360);
        </script>
        </div>
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important; width:100%;overflow:hidden; background-color:#ffffff !important;" id="CategoryX" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Action</h2>
            <div id="Action" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;" >
            </div>
        </div>

        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important; width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div1" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Fantasy</h2>
            <div id="Fantasy" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div2" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Comedy</h2>
            <div id="Comedy" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div3" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Supernatural</h2>
            <div id="Supernatural" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div4" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Sci-Fi</h2>
            <div id="SciFi" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div5" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Drama</h2>
            <div id="Drama" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div6" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Mystery</h2>
            <div id="Mystery" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
        </div>
        
        <br style="height:4px !important;width:100% !important; margin:0 auto !important;" />
        <div style="height:fit-content;max-height:268px !important;width:100%;overflow-y:hidden;overflow-x:auto;background-color:#ffffff !important;" id="Div7" runat="server">
            <h2 style="color:#000000;margin-left:8px;margin-bottom:-18px;">Slice of Life</h2>
            <div id="SliceofLife" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;"></div>
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
        var MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight - HeightFixrFASIT208CutJK3;
        setTimeout(() => {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight - HeightFixrFASIT208CutJK3;
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
                                }, 1800);
                            }, 45);
                        }, 90);
                    }, 180);
                }, 360);
            }, 640);
        }, 960);
    </script>
</asp:Content>