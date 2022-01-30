<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Hits.aspx.cs" Inherits="SuM_Manga_V3.Hits" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
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
    <div style="display:none" ID="HitsStylePlaceHolder" runat="server" >
        <style>
            #HitsBG {
                animation: rainbow 11s linear infinite;
            }

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
    <div class="fadeIn animated" style="height:100% !important;width:100vw !important;max-width:720px !important;margin:0 auto !important;">
        <div id="HitsBG" style="animation: rainbow 32s linear infinite !important;margin:0 auto !important;padding:0px !important;margin-bottom:0px !important;">
            <div style="width:100% !important;">
                <h2 style="color:#ffffff;margin:0 auto !important;text-align:center;margin-top:18px !important;margin-bottom:16px !important;"><img src="/svg/MostSeenW.svg" width="36" height="36" style="display:inline;margin-top:-8px;" /> Top 10 on SuM Manga!</h2>
                <p style="color:rgba(255,255,255,0.82);font-size:86%;text-align:center !important;width:100%;height:fit-content;margin:0 auto !important;margin-top:12px !important;margin-bottom:8px !important;display:none !important;visibility:hidden !important;">This section's purpose is to showcase the ten mangas with the highest views on this platform, ranked from the highest to the lowest. This section is updated live!</p>
            </div>
            <div id="Top10Con" runat="server" style="margin:0 auto !important;width:100%;height:fit-content;background-color:#ffffff;position:relative;">
                <div id="NuM1" runat="server" style="background-color:rgba(132,145,162,0.74);padding:12px;padding-top:22px;padding-bottom:22px;background-image:linear-gradient(rgba(132, 145, 162, 0.74), rgba(0, 0, 0, 0.3)), url(/storeitems/blue-period/blue-period.jpg) !important;">
                    <div style="height:320px;width:100%;margin:0 auto !important;display:inline !important;position:relative;">
                        <p style="float:right;margin-top:18px;margin-right:18px;font-size:240%;color:rgba(255,255,255,0.86);">#1</p>
                        <p id="NuM1Title" style="font-size:120%;color:#ffffff;width:calc(100% - 64px);overflow:hidden;">Blue Period</p>
                        <p id="NuM1Disc" style="height:calc(100% - 64px);width:calc(100% - 92px);overflow:hidden;font-size:86%;color:rgba(255,255,255,0.8);"> a fascinating story about a young man exploring a new world and wanting more and not being satisfied with the level he’s at. I’d gather that this manga sits in the shounen or seinen genre. And while it is very educational, it can be a bit of information overload, especially towards the end.</p>
                        <div>
                            <p class="" id="MainContent_MangaRating" style="display:inline;color:rgba(255,255,255,0.74);">16+</p>
                            <img style="width:20px;height:20px;display:inline;" src="/svg/views.svg">
                            <p id="MainContent_ViewsSutNum" style="display:inline;color:#ffffff;">3.56</p>
                            <b id="MainContent_ViewsSutLater" style="display:inline;color:#ffffff;">M</b>
                        </div>
                    </div>
                </div>
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

                /*document.onreadystatechange = function () {
                    if (document.readyState == "interactive") {
                        Top1elm.style.height = document.getElementById('NuM1Expandor').offsetHeight + 'px';
                        Top2elm.style.height = document.getElementById('NuM2Expandor').offsetHeight + 'px';
                        Top3elm.style.height = document.getElementById('NuM3Expandor').offsetHeight + 'px';
                        Top4elm.style.height = document.getElementById('NuM4Expandor').offsetHeight + 'px';
                        Top5elm.style.height = document.getElementById('NuM5Expandor').offsetHeight + 'px';
                        Top6elm.style.height = document.getElementById('NuM6Expandor').offsetHeight + 'px';
                        Top7elm.style.height = document.getElementById('NuM7Expandor').offsetHeight + 'px';
                        Top8elm.style.height = document.getElementById('NuM8Expandor').offsetHeight + 'px';
                        Top9elm.style.height = document.getElementById('NuM9Expandor').offsetHeight + 'px';
                        Top10elm.style.height = document.getElementById('NuM10Expandor').offsetHeight + 'px';
                    }
                };*/

                function ExpandControler1() {
                    if (Top1RestElm.style.display == 'none') {
                        Top1RestElm.style.display = 'block';
                        Top1elm.style.height = (Top1elm.offsetHeight + Top1RestElm.offsetHeight) + 'px';
                        if (Top1RestElm.classList.contains('fadeInDown') == false) {
                            Top1RestElm.classList.remove('fadeOutUp');
                            Top1RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top1RestElm.classList.remove('fadeInDown');
                        Top1RestElm.classList.add('fadeOutUp');
                        Top1elm.style.height = (Top1elm.offsetHeight - Top1RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top1RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler2() {
                    if (Top2RestElm.style.display == 'none') {
                        Top2RestElm.style.display = 'block';
                        Top2elm.style.height = (Top2elm.offsetHeight + Top2RestElm.offsetHeight) + 'px';
                        if (Top2RestElm.classList.contains('fadeInDown') == false) {
                            Top2RestElm.classList.remove('fadeOutUp');
                            Top2RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top2RestElm.classList.remove('fadeInDown');
                        Top2RestElm.classList.add('fadeOutUp');
                        Top2elm.style.height = (Top2elm.offsetHeight - Top2RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top2RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler3() {
                    if (Top3RestElm.style.display == 'none') {
                        Top3RestElm.style.display = 'block';
                        Top3elm.style.height = (Top3elm.offsetHeight + Top3RestElm.offsetHeight) + 'px';
                        if (Top3RestElm.classList.contains('fadeInDown') == false) {
                            Top3RestElm.classList.remove('fadeOutUp');
                            Top3RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top3RestElm.classList.remove('fadeInDown');
                        Top3RestElm.classList.add('fadeOutUp');
                        Top3elm.style.height = (Top3elm.offsetHeight - Top3RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top3RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler4() {
                    if (Top4RestElm.style.display == 'none') {
                        Top4RestElm.style.display = 'block';
                        Top4elm.style.height = (Top4elm.offsetHeight + Top4RestElm.offsetHeight) + 'px';
                        if (Top4RestElm.classList.contains('fadeInDown') == false) {
                            Top4RestElm.classList.remove('fadeOutUp');
                            Top4RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top4RestElm.classList.remove('fadeInDown');
                        Top4RestElm.classList.add('fadeOutUp');
                        Top4elm.style.height = (Top4elm.offsetHeight - Top4RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top4RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler5() {
                    if (Top5RestElm.style.display == 'none') {
                        Top5RestElm.style.display = 'block';
                        Top5elm.style.height = (Top5elm.offsetHeight + Top5RestElm.offsetHeight) + 'px';
                        if (Top5RestElm.classList.contains('fadeInDown') == false) {
                            Top5RestElm.classList.remove('fadeOutUp');
                            Top5RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top5RestElm.classList.remove('fadeInDown');
                        Top5RestElm.classList.add('fadeOutUp');
                        Top5elm.style.height = (Top5elm.offsetHeight - Top5RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top5RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler6() {
                    if (Top6RestElm.style.display == 'none') {
                        Top6RestElm.style.display = 'block';
                        Top6elm.style.height = (Top6elm.offsetHeight + Top6RestElm.offsetHeight) + 'px';
                        if (Top6RestElm.classList.contains('fadeInDown') == false) {
                            Top6RestElm.classList.remove('fadeOutUp');
                            Top6RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top6RestElm.classList.remove('fadeInDown');
                        Top6RestElm.classList.add('fadeOutUp');
                        Top6elm.style.height = (Top6elm.offsetHeight - Top6RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top6RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler7() {
                    if (Top7RestElm.style.display == 'none') {
                        Top7RestElm.style.display = 'block';
                        Top7elm.style.height = (Top7elm.offsetHeight + Top7RestElm.offsetHeight) + 'px';
                        if (Top7RestElm.classList.contains('fadeInDown') == false) {
                            Top7RestElm.classList.remove('fadeOutUp');
                            Top7RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top7RestElm.classList.remove('fadeInDown');
                        Top7RestElm.classList.add('fadeOutUp');
                        Top7elm.style.height = (Top7elm.offsetHeight - Top7RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top7RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler8() {
                    if (Top8RestElm.style.display == 'none') {
                        Top8RestElm.style.display = 'block';
                        Top8elm.style.height = (Top8elm.offsetHeight + Top8RestElm.offsetHeight) + 'px';
                        if (Top8RestElm.classList.contains('fadeInDown') == false) {
                            Top8RestElm.classList.remove('fadeOutUp');
                            Top8RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top8RestElm.classList.remove('fadeInDown');
                        Top8RestElm.classList.add('fadeOutUp');
                        Top8elm.style.height = (Top8elm.offsetHeight - Top8RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top8RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler9() {
                    if (Top9RestElm.style.display == 'none') {
                        Top9RestElm.style.display = 'block';
                        Top9elm.style.height = (Top9elm.offsetHeight + Top9RestElm.offsetHeight) + 'px';
                        if (Top9RestElm.classList.contains('fadeInDown') == false) {
                            Top9RestElm.classList.remove('fadeOutUp');
                            Top9RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top9RestElm.classList.remove('fadeInDown');
                        Top9RestElm.classList.add('fadeOutUp');
                        Top9elm.style.height = (Top9elm.offsetHeight - Top9RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top9RestElm.style.display = 'none';
                        }, 260);
                    }
                };
                function ExpandControler10() {
                    if (Top10RestElm.style.display == 'none') {
                        Top10RestElm.style.display = 'block';
                        Top10elm.style.height = (Top10elm.offsetHeight + Top10RestElm.offsetHeight) + 'px';
                        if (Top10RestElm.classList.contains('fadeInDown') == false) {
                            Top10RestElm.classList.remove('fadeOutUp');
                            Top10RestElm.classList.add('fadeInDown');
                        }
                    }
                    else {
                        Top10RestElm.classList.remove('fadeInDown');
                        Top10RestElm.classList.add('fadeOutUp');
                        Top10elm.style.height = (Top10elm.offsetHeight - Top10RestElm.offsetHeight) + 'px';
                        setTimeout(() => {
                            Top10RestElm.style.display = 'none';
                        }, 260);
                    }
                };
            </script>
        </div>
        <div style="display:none !important;visibility:hidden !important;background-color:#f2f2f2 !important;width:100%;height:32px;border-bottom-left-radius:20px;border-bottom-right-radius:20px;margin:0 auto !important;margin-bottom:12px !important;"></div>
        <h2 style="width:100%;margin:0 auto !important;text-align:center !important;margin-top:0px !important;background-color:#f2f2f2 !important;padding:8px;padding-top:12px;margin-bottom:12px !important;color:#000000f0;">Top 10 for each by category</h2>
        
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
</asp:Content>