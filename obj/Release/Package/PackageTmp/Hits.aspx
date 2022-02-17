<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Hits.aspx.cs" Inherits="SuM_Manga_V3.Hits" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetDarkStatusBarColor();
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
        }
    </script>
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
        * {
            /*-webkit-transition: all 0.5s !important;
            -moz-transition: all 0.5s !important;
            -ms-transition: all 0.5s !important;
            -o-transition: all 0.5s !important;
            transition: all 0.5s !important;*/
        }
    </style>
    <div style="background-color:rgba(255,255,255,0.86) !important;position:fixed !important;top:0 !important;animation-duration:0.16s !important;z-index:997 !important;height:fit-content !important;width:100% !important;display:none;padding-top:6px;padding-bottom:6px;padding-left:4px;border-bottom-left-radius:22px;border-bottom-right-radius:22px;" class="animated fadeInDown" id="SuMMangaTopBar">
        <div style="background-color:transparent;width:100%;margin:0 auto !important;height:24px;" id="SuMMangaTopBarHeightHelper"></div>
        <p style="font-size:118%;margin-left:18px;margin-bottom:8px;display:block;height:fit-content;width:fit-content;" class="text-black"><img src="/svg/MostSeenB.svg" width="30" height="30" style="" /> SuM Hits</p>
    </div>
    <div style="display:none;" ID="HitsStylePlaceHolder" runat="server" >
        <style>

            @keyframes rainbow {
                0% {
                    background-color: #f2f2f2;
                }

                10% {
                    background-color: #ffffff;
                }

                20% {
                    background-color: #85798b;
                }

                30% {
                    background-color: #85798b;
                }

                40% {
                    background-color: #85798b;
                }

                50% {
                    background-color: #82667b;
                }

                60% {
                    background-color: #85798b;
                }

                70% {
                    background-color: #968aae;
                }

                80% {
                    background-color: #85798b;
                }

                90% {
                    background-color: #85798b;
                }

                100% {
                    background-color: #baa9cc;
                }
            }
        </style>
    </div>
    <div id="ScrollingDivHits" runat="server" class="fadeIn animated" style="height:100% !important;width:100vw !important;max-width:720px !important;margin:0 auto !important;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;">
        <div id="ScrollHelperFASET204CutG65" style="background-color:#f2f2f2 !important;margin:0 auto !important;width:100%;height:fit-content;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;">
        <div id="HotsScrollHelper" runat="server" style="background-color:#ffffff;margin:0 auto !important;padding:0px;width:100%;height:fit-content;border-bottom-left-radius:20px !important;border-bottom-right-radius:20px !important;display:block !important;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;">
        <div id="HitsBG" style="margin:0 auto !important;padding:0px;margin-bottom:0px !important;border-bottom-left-radius:20px !important;border-bottom-right-radius:20px !important;display:block !important;width:100% !important;height:fit-content !important;transition: background-color .3s !important; -webkit-transition: background-color .3s !important; -o-transition: background-color .3s !important; -moz-transition: background-color .3s !important;padding-top:28px !important;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;">
            <div style="width:100% !important;">
                <h2 id="ThisPageSBarFixUpPropElm" style="color:#ffffff;margin:0 auto !important;text-align:center;margin-top:18px !important;margin-bottom:16px !important;"><img src="/svg/MostSeenW.svg" width="36" height="36" style="display:inline;margin-top:-8px;" /> Top 10 on SuM Manga!</h2>
                <p style="color:rgba(255,255,255,0.82);font-size:86%;text-align:center !important;width:100%;height:fit-content;margin:0 auto !important;margin-top:12px !important;margin-bottom:8px !important;display:none !important;visibility:hidden !important;">This section's purpose is to showcase the ten mangas with the highest views on this platform, ranked from the highest to the lowest. This section is updated live!</p>
            </div>
            <script>
                var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
                var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
                ThisPageSBarFixUpPropElmVar.style.marginTop = (12 + StatusBarHeightValue) + 'px !important';
            </script>
            <div id="Top10Con" runat="server" style="margin:0 auto !important;width:100%;height:fit-content;background-color:#ffffff;position:relative;width:calc(100% - 24px);margin-bottom:26px !important;border-radius:18px;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;">

            </div>
            <script>
                var Top1elm = document.getElementById('NuM1');
                var Top1RestElm = document.getElementById('NuM1CardRest');
                var Top2elm = document.getElementById('NuM2');
                var Top2RestElm = document.getElementById('NuM2CardRest');
                var Top3elm = document.getElementById('NuM3');
                var Top3RestElm = document.getElementById('NuM3CardRest');
                var Top4elm = document.getElementById('NuM4');
                var Top4RestElm = document.getElementById('NuM4CardRest');
                var Top5elm = document.getElementById('NuM5');
                var Top5RestElm = document.getElementById('NuM5CardRest');
                var Top6elm = document.getElementById('NuM6');
                var Top6RestElm = document.getElementById('NuM6CardRest');
                var Top7elm = document.getElementById('NuM7');
                var Top7RestElm = document.getElementById('NuM7CardRest');
                var Top8elm = document.getElementById('NuM8');
                var Top8RestElm = document.getElementById('NuM8CardRest');
                var Top9elm = document.getElementById('NuM9');
                var Top9RestElm = document.getElementById('NuM9CardRest');
                var Top10elm = document.getElementById('NuM10');
                var Top10RestElm = document.getElementById('NuM10CardRest');
                var Top1Expandor = document.getElementById('NuM1Expandor');
                var Top2Expandor = document.getElementById('NuM2Expandor');
                var Top3Expandor = document.getElementById('NuM3Expandor');
                var Top4Expandor = document.getElementById('NuM4Expandor');
                var Top5Expandor = document.getElementById('NuM5Expandor');
                var Top6Expandor = document.getElementById('NuM6Expandor');
                var Top7Expandor = document.getElementById('NuM7Expandor');
                var Top8Expandor = document.getElementById('NuM8Expandor');
                var Top9Expandor = document.getElementById('NuM9Expandor');
                var Top10Expandor = document.getElementById('NuM10Expandor');

                var HitsBGElm = document.getElementById('HitsBG');
                var HitsOrBGC = HitsBGElm.style.backgroundColor;
                var HitsOrTran = HitsBGElm.style.transition;

                var Top1ThemeC = document.getElementById('Top1ThemeColor').innerText;
                var Top2ThemeC = document.getElementById('Top2ThemeColor').innerText;
                var Top3ThemeC = document.getElementById('Top3ThemeColor').innerText;
                var Top4ThemeC = document.getElementById('Top4ThemeColor').innerText;
                var Top5ThemeC = document.getElementById('Top5ThemeColor').innerText;
                var Top6ThemeC = document.getElementById('Top6ThemeColor').innerText;
                var Top7ThemeC = document.getElementById('Top7ThemeColor').innerText;
                var Top8ThemeC = document.getElementById('Top8ThemeColor').innerText;
                var Top9ThemeC = document.getElementById('Top9ThemeColor').innerText;
                var Top10ThemeC = document.getElementById('Top10ThemeColor').innerText;

                document.onreadystatechange = function () {
                    if (document.readyState == "interactive") {
                        Top1elm.style.height = (Top1Expandor.offsetHeight - 10) + 'px';
                        Top2elm.style.height = (Top2Expandor.offsetHeight - 10) + 'px';
                        Top3elm.style.height = (Top3Expandor.offsetHeight - 10) + 'px';
                        Top4elm.style.height = (Top4Expandor.offsetHeight - 10) + 'px';
                        Top5elm.style.height = (Top5Expandor.offsetHeight - 10) + 'px';
                        Top6elm.style.height = (Top6Expandor.offsetHeight - 10) + 'px';
                        Top7elm.style.height = (Top7Expandor.offsetHeight - 10) + 'px';
                        Top8elm.style.height = (Top8Expandor.offsetHeight - 10) + 'px';
                        Top9elm.style.height = (Top9Expandor.offsetHeight - 10) + 'px';
                        Top10elm.style.height = (Top10Expandor.offsetHeight - 10) + 'px';
                    }
                };
                function UnexpandRestButThis(elm) {
                    if (elm != 'NuM1') {
                        if (Top1RestElm.style.display == 'block') {
                            ExpandControler1();
                        }
                    }
                    if (elm != 'NuM2') {
                        if (Top2RestElm.style.display == 'block') {
                            ExpandControler2();
                        }
                    }
                    if (elm != 'NuM3') {
                        if (Top3RestElm.style.display == 'block') {
                            ExpandControler3();
                        }
                    }
                    if (elm != 'NuM4') {
                        if (Top4RestElm.style.display == 'block') {
                            ExpandControler4();
                        }
                    }
                    if (elm != 'NuM5') {
                        if (Top5RestElm.style.display == 'block') {
                            ExpandControler5();
                        }
                    }
                    if (elm != 'NuM6') {
                        if (Top6RestElm.style.display == 'block') {
                            ExpandControler6();
                        }
                    }
                    if (elm != 'NuM7') {
                        if (Top7RestElm.style.display == 'block') {
                            ExpandControler7();
                        }
                    }
                    if (elm != 'NuM8') {
                        if (Top8RestElm.style.display == 'block') {
                            ExpandControler8();
                        }
                    }
                    if (elm != 'NuM9') {
                        if (Top9RestElm.style.display == 'block') {
                            ExpandControler9();
                        }
                    }
                    if (elm != 'NuM10') {
                        if (Top10RestElm.style.display == 'block') {
                            ExpandControler10();
                        }
                    }
                };

                function ExpandControler1() {
                    if (Top1RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM1');
                        Top1RestElm.style.display = 'block';
                        Top1elm.style.height = (Top1elm.offsetHeight + Top1RestElm.offsetHeight + 78) + 'px';
                        Top1Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top1ThemeC;
                        if (Top1RestElm.classList.contains('fadeInDown') == false) {
                            Top1RestElm.classList.remove('fadeOutUp');
                            Top1RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top1RestElm.classList.remove('fadeInDown');
                        Top1RestElm.classList.add('fadeOutUp');
                        Top1elm.style.height = (Top1elm.offsetHeight - Top1RestElm.offsetHeight - 78) + 'px';
                        Top1Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top1RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler2() {
                    if (Top2RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM2');
                        Top2RestElm.style.display = 'block';
                        Top2elm.style.height = (Top2elm.offsetHeight + Top2RestElm.offsetHeight + 78) + 'px';
                        Top2Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top2ThemeC;
                        if (Top2RestElm.classList.contains('fadeInDown') == false) {
                            Top2RestElm.classList.remove('fadeOutUp');
                            Top2RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top2RestElm.classList.remove('fadeInDown');
                        Top2RestElm.classList.add('fadeOutUp');
                        Top2elm.style.height = (Top2elm.offsetHeight - Top2RestElm.offsetHeight - 78) + 'px';
                        Top2Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top2RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler3() {
                    if (Top3RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM3');
                        Top3RestElm.style.display = 'block';
                        Top3elm.style.height = (Top3elm.offsetHeight + Top3RestElm.offsetHeight + 78) + 'px';
                        Top3Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top3ThemeC;
                        if (Top3RestElm.classList.contains('fadeInDown') == false) {
                            Top3RestElm.classList.remove('fadeOutUp');
                            Top3RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top3RestElm.classList.remove('fadeInDown');
                        Top3RestElm.classList.add('fadeOutUp');
                        Top3elm.style.height = (Top3elm.offsetHeight - Top3RestElm.offsetHeight - 78) + 'px';
                        Top3Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top3RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler4() {
                    if (Top4RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM4');
                        Top4RestElm.style.display = 'block';
                        Top4elm.style.height = (Top4elm.offsetHeight + Top4RestElm.offsetHeight + 78) + 'px';
                        Top4Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top4ThemeC;
                        if (Top4RestElm.classList.contains('fadeInDown') == false) {
                            Top4RestElm.classList.remove('fadeOutUp');
                            Top4RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top4RestElm.classList.remove('fadeInDown');
                        Top4RestElm.classList.add('fadeOutUp');
                        Top4elm.style.height = (Top4elm.offsetHeight - Top4RestElm.offsetHeight - 78) + 'px';
                        Top4Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top4RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler5() {
                    if (Top5RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM5');
                        Top5RestElm.style.display = 'block';
                        Top5elm.style.height = (Top5elm.offsetHeight + Top5RestElm.offsetHeight + 78) + 'px';
                        Top5Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top5ThemeC;
                        if (Top5RestElm.classList.contains('fadeInDown') == false) {
                            Top5RestElm.classList.remove('fadeOutUp');
                            Top5RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top5RestElm.classList.remove('fadeInDown');
                        Top5RestElm.classList.add('fadeOutUp');
                        Top5elm.style.height = (Top5elm.offsetHeight - Top5RestElm.offsetHeight - 78) + 'px';
                        Top5Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top5RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler6() {
                    if (Top6RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM6');
                        Top6RestElm.style.display = 'block';
                        Top6elm.style.height = (Top6elm.offsetHeight + Top6RestElm.offsetHeight + 78) + 'px';
                        Top6Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top6ThemeC;
                        if (Top6RestElm.classList.contains('fadeInDown') == false) {
                            Top6RestElm.classList.remove('fadeOutUp');
                            Top6RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top6RestElm.classList.remove('fadeInDown');
                        Top6RestElm.classList.add('fadeOutUp');
                        Top6elm.style.height = (Top6elm.offsetHeight - Top6RestElm.offsetHeight - 78) + 'px';
                        Top6Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top6RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler7() {
                    if (Top7RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM7');
                        Top7RestElm.style.display = 'block';
                        Top7elm.style.height = (Top7elm.offsetHeight + Top7RestElm.offsetHeight + 78) + 'px';
                        Top7Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top7ThemeC;
                        if (Top7RestElm.classList.contains('fadeInDown') == false) {
                            Top7RestElm.classList.remove('fadeOutUp');
                            Top7RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top7RestElm.classList.remove('fadeInDown');
                        Top7RestElm.classList.add('fadeOutUp');
                        Top7elm.style.height = (Top7elm.offsetHeight - Top7RestElm.offsetHeight - 78) + 'px';
                        Top7Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top7RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler8() {
                    if (Top8RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM8');
                        Top8RestElm.style.display = 'block';
                        Top8elm.style.height = (Top8elm.offsetHeight + Top8RestElm.offsetHeight + 78) + 'px';
                        Top8Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top8ThemeC;
                        if (Top8RestElm.classList.contains('fadeInDown') == false) {
                            Top8RestElm.classList.remove('fadeOutUp');
                            Top8RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top8RestElm.classList.remove('fadeInDown');
                        Top8RestElm.classList.add('fadeOutUp');
                        Top8elm.style.height = (Top8elm.offsetHeight - Top8RestElm.offsetHeight - 78) + 'px';
                        Top8Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top8RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler9() {
                    if (Top9RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM9');
                        Top9RestElm.style.display = 'block';
                        Top9elm.style.height = (Top9elm.offsetHeight + Top9RestElm.offsetHeight + 78) + 'px';
                        Top9Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top9ThemeC;
                        if (Top9RestElm.classList.contains('fadeInDown') == false) {
                            Top9RestElm.classList.remove('fadeOutUp');
                            Top9RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top9RestElm.classList.remove('fadeInDown');
                        Top9RestElm.classList.add('fadeOutUp');
                        Top9elm.style.height = (Top9elm.offsetHeight - Top9RestElm.offsetHeight - 78) + 'px';
                        Top9Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top9RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler10() {
                    if (Top10RestElm.style.display == 'none') {
                        UnexpandRestButThis('NuM10');
                        Top10RestElm.style.display = 'block';
                        Top10elm.style.height = (Top10elm.offsetHeight + Top10RestElm.offsetHeight + 78) + 'px';
                        Top10Expandor.style.marginTop = '18px';
                        HitsBGElm.style.animation = 'none';
                        HitsBGElm.style.backgroundColor = Top10ThemeC;
                        if (Top10RestElm.classList.contains('fadeInDown') == false) {
                            Top10RestElm.classList.remove('fadeOutUp');
                            Top10RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top10RestElm.classList.remove('fadeInDown');
                        Top10RestElm.classList.add('fadeOutUp');
                        Top10elm.style.height = (Top10elm.offsetHeight - Top10RestElm.offsetHeight - 78) + 'px';
                        Top10Expandor.style.marginTop = '-26px';
                        HitsBGElm.style.backgroundColor = null;
                        HitsBGElm.style.animation = null;
                        setTimeout(() => {
                            Top10RestElm.style.display = 'none';
                        }, 260);
                    }
                };
            </script>
        </div>
        </div>
        </div>
        <div style="display:none !important;visibility:hidden !important;background-color:#f2f2f2 !important;width:100%;height:32px;border-bottom-left-radius:20px;border-bottom-right-radius:20px;margin:0 auto !important;margin-bottom:12px !important;"></div>
        <h2 id="TopOfEachInfoCard" style="width:100%;text-align:center !important;background-color:#f2f2f2 !important;padding:12px;padding-top:18px;padding-bottom:12px;color:#000000f0;position:relative;top:0;z-index:997;border-bottom-left-radius:18px !important;border-bottom-right-radius:18px !important;">Top 10 for each by category</h2>
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
        <div style="display:block !important;width:100% !important;height:164px !important;background-color:transparent !important;text-align:center;margin:0 auto !important;"></div>
    </div>
    <script>
        var ThisPageScrollContaner = document.getElementById('<%= ScrollingDivHits.ClientID %>');
        var ThisPageChangeStartElm = document.getElementById('ScrollHelperFASET204CutG65');
        var SuMMangaTopBarElm = document.getElementById('SuMMangaTopBar');
        var SuMMangaTopBarHeightHelperElm = document.getElementById('SuMMangaTopBarHeightHelper');
        var StatusBarHeightValueFromAPIs = androidAPIs.getStatusBarHeight();
        var MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        setTimeout(() => {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        }, 1200);
        document.onclick = function (event) {
            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;
        };
        SuMMangaTopBarHeightHelperElm.style.height = (StatusBarHeightValueFromAPIs + 6) + 'px !important';
        ThisPageScrollContaner.onscroll = function () {

            MaxScrollHDetected = ThisPageChangeStartElm.offsetHeight;

            if (ThisPageScrollContaner.scrollTop >= MaxScrollHDetected) {

                androidAPIs.SetLightStatusBarColor();
                SuMMangaTopBarElm.style.display = 'block';

            } else {

                androidAPIs.SetDarkStatusBarColor();
                SuMMangaTopBarElm.style.display = 'none';

            }

        };
        init();
    </script>
</asp:Content>