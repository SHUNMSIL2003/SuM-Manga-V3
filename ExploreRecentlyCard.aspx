<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.MainCard.Master" AutoEventWireup="true" CodeBehind="ExploreRecentlyCard.aspx.cs" Inherits="SuM_Manga_V3.ExploreRecentlyCard" %>

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
            /*background-color:transparent !important;*/
        }

/* Caption text */
        .text {
            color: var(--SuMDGray);
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
  color: var(--SuMDGray);
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
  background-color: var(--SuMDWhiteOP32);
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: var(--SuMDWhiteOP94);
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
        <style>
            .XYFitContantSuMUpdatePanelFixUpScroll {
                width:fit-content !important;
                height:fit-content !important;
            }
        </style>
        <div id="RecentsCont" runat="server" style="scroll-snap-align:start !important;scroll-snap-stop: always !important;background-color:transparent !important;" class="">
        <asp:Button ID="UPDATERESESNTS" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
                        <div id="RecentsSuperCont" runat="server" style="display:block;">
                            <div id="RescentBody" style="border:0.5px var(--SuMDBroderC) solid !important;height:168px!important; width:100vw;overflow:hidden;border-radius:20px;background-color:var(--SuMThemeColorOP74) !important;margin:0 auto !important;padding:18px;padding-left:4px;overflow-x:scroll !important;overflow-y:hidden !important;transition: background-color 0.32s ease !important;padding-right:4px !important;">
                                <img src="/svg/historyTW.svg" width="30" height="30" style="display:inline;float:left !important;margin-left:12px !important;margin-right:2px !important;margin-top:0px !important;" />
                                <p style="font-size:132%;height:fit-content;width:calc(100% - 50px) !important;color:rgba(255,255,255,0.92);float:left !important;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;overflow: hidden;text-align:center !important;display:block !important;margin-bottom:6px !important;text-align:left !important;margin-top:0px !important;margin-left:2px;">Recently viewed</p>
                                <div id="RecentScrollContS" style="width:100% !important;margin:0 auto !important;margin-left:0px !important;overflow-y:hidden;overflow-x:scroll !important;">
                                    <asp:UpdatePanel ID="RESENTSUPATEPANLE" runat="server" UpdateMode="Conditional" style="width:fit-content;height:fit-content;">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="UPDATERESESNTS" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Panel runat="server" style="width:fit-content;height:fit-content;">
                                                <div class=" " id="Recent" runat="server" style="padding-left:-8px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:calc(100% + 15px) !important;height:100%;display:flex !important;width:fit-content !important;overflow-x:scroll !important;overflow-y:hidden !important;">
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
            <script>
                androidAPIs.SuMLoadCounter();
                setTimeout(() => {
                    var style = getComputedStyle(document.body);
                    console.log(style.getPropertyValue('--SuMThemeColorOP74'));
                    document.getElementById('RescentBody').style.backgroundColor = style.getPropertyValue('--SuMThemeColorOP74');
                    document.getElementById('<%= UPDATERESESNTS.ClientID %>').click();
                }, 10);
                var isScrollingSuMRecentsFuncF0CS;
                document.getElementById('RecentScrollContS').onscroll = function () {
                    window.clearTimeout(isScrollingSuMRecentsFuncF0CS);
                    isScrollingSuMRecentsFuncF0CS = setTimeout(function () {
                        var RecentF0CSElm = document.getElementById('RecentScrollContS');
                        var RescentBodyF0CSElm = document.getElementById('RescentBody');
                        var currLeftID = Math.round(RecentF0CSElm.scrollLeft / 112) + 1;
                        if (currLeftID != 1 && currLeftID != 0) {
                            var currRecentItemThemeColor = document.getElementById('RecentItem' + currLeftID).style.backgroundColor;
                            if (currRecentItemThemeColor != null) {
                                RescentBodyF0CSElm.style.backgroundColor = currRecentItemThemeColor;
                            }
                        } else {
                            var style = getComputedStyle(document.body);
                            console.log(style.getPropertyValue('--SuMThemeColorOP74'));
                            RescentBodyF0CSElm.style.backgroundColor = style.getPropertyValue('--SuMThemeColorOP74');
                        }
                    }, 20);
                };
                setTimeout(() => {
                    var style = getComputedStyle(document.body);
                    console.log(style.getPropertyValue('--SuMThemeColorOP74'));
                    document.getElementById('RescentBody').style.backgroundColor = style.getPropertyValue('--SuMThemeColorOP74');
                }, 540);
            </script>
</div>
</asp:Content>