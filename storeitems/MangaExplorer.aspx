<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" Async="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
        .imagefix2241 {
            margin-left:0px !important;
            margin-right:0px !important;
        }
        .ForceChMaxW {
            max-width:806px !important;
        }
        ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: #ffffff !important;
            opacity: 0.8 !important; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: rgba(255,255,255,0.8) !important;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: rgba(255,255,255,0.8) !important;
        }
        textarea:focus,
        textarea.form-control:focus,
        input.form-control:focus,
        input[type=text]:focus,
        input[type=password]:focus,
        input[type=email]:focus,
        input[type=number]:focus,
        [type=text].form-control:focus,
        [type=password].form-control:focus,
        [type=email].form-control:focus,
        [type=tel].form-control:focus,
        [contenteditable].form-control:focus {
            box-shadow: inset 0 0px 0 #000 !important;
        }
    </style>
    <div class="" id="pfc" runat="server" style="background-color:#6840D9;margin:0 auto !important;width:100vw !important;height:100vh !important;">
        <div class="animated fadeInRight" style="margin:0 auto !important;width:100vw !important;">
            <div id="ThisPageSubContaner" class="nospace ContantDivSuM" style="height:fit-content;width:calc(100vw - 18px) !important;margin:0 auto !important;max-width:720px !important;background-color:#ffffff !important;margin-top:32px !important;margin-bottom:164px !important;border-radius:20px !important;">
                <div id="InfoCardBGForJAVA" style="background-color:rgba(0,0,0,0.12);width:calc(100% - 18px) !important;height:fit-content;border-radius:20px !important;margin:0 auto !important;margin-top:26px !important;margin-bottom:16px !important;">
                    <div style="width:100% !important;height:fit-content !important;font-size:96%;padding-left:16px !important;padding-top:22px !important;padding-bottom:8px !important;">
                        <p id="MangaName" runat="server" style="display:inline-block !important;font-size:118%;color:rgba(0,0,0,1) !important;">#name</p>
                        <a id="InfoDividerForJAVA" style="width:2px;height:16px;display:inline-block;background-color:rgba(0,0,0,0.54);border-radius:1px;margin-bottom:-2px;margin-right:2px;margin-left:1px;"></a>
                        <p id="ChapterWordForJAVA" style="display:inline-block !important;font-size:98%;color:rgba(0,0,0,0.54) !important;"><b style="font-size:80%;">Chapter</b></p>
                        <p style="display:inline-block !important;font-size:120%;"><b id="ChapterNum" runat="server" style="color:rgba(132,145,162,1);">#num</b></p>
                        <asp:Button ID="HIDDENADDTOFAV" OnClick="AddToFavList" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:Button ID="HIDDEMREMOVEFROMFAV" OnClick="RemoveFromFavList" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:Button ID="UpdateInfo" OnClick="Page_Load" runat="server" style="display:none !important;visibility:hidden;" />
                        <asp:UpdatePanel ID="FAVBTNUPDATE" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="HIDDENADDTOFAV" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="HIDDEMREMOVEFROMFAV" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="UpdateInfo" EventName="Click" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Panel runat="server">
                                    <a class="animated pulse" id="AddToFavSHOWNBTN" runat="server" style="float:right !important;width:fit-content !important;height:fit-content !important;padding:2px;margin-right:8px !important;"><svg id="FavSVG" xmlns="http://www.w3.org/2000/svg" height="30px" viewBox="0 0 24 24" width="30px" fill="#fffffff0" ><path d="M0 0h24v24H0V0z" fill="none"/><path id="FavPath" d="M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z"/></svg></a>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="" id="TheMangaPhotos" runat="server" style="width:calc(100% - 18px) !important;height:fit-content !important;margin:0 auto !important;padding:0px !important;border-radius:20px !important;margin-bottom:28px !important;border:2px solid rgba(0,0,0,0.12) !important;">

                </div>
                <script>
                    var DetectedThemeColor = null;

                    location.search.substring(1).split("&").forEach(function (val) {

                        var currVal = val.split("=");
                        if (currVal[0] == "TC") {

                            DetectedThemeColor = decodeURI(currVal[1]);

                        }

                    });
                    document.getElementById('InfoDividerForJAVA').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.54");
                    document.getElementById('ChapterWordForJAVA').style.color = DetectedThemeColor.replace("0.74", "0.58");
                    var NewBoredr = '2px solid ' + DetectedThemeColor.replace("0.74", "0.18");
                    document.getElementById('<%= TheMangaPhotos.ClientID %>').style.border = NewBoredr;
                    document.getElementById('InfoCardBGForJAVA').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.18");
                    var BTNELMCOLORFulOp = DetectedThemeColor.replace("0.74", "1");
                    document.getElementById('FavSVG').setAttribute('fill', BTNELMCOLORFulOp);
                    document.getElementById('<%= FAVBTNUPDATE.ClientID %>').style = 'float:right !important;width:fit-content !important;height:fit-content !important;';

                    var FavNOTFILLEDPATH = "M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z";
                    var FavFILLEDPATH = "M13.35 20.13c-.76.69-1.93.69-2.69-.01l-.11-.1C5.3 15.27 1.87 12.16 2 8.28c.06-1.7.93-3.33 2.34-4.29 2.64-1.8 5.9-.96 7.66 1.1 1.76-2.06 5.02-2.91 7.66-1.1 1.41.96 2.28 2.59 2.34 4.29.14 3.88-3.3 6.99-8.55 11.76l-.1.09z";
                    var FavPathElm = document.getElementById('FavPath');
                    var FavFuncKeyBTN = document.getElementById('<%= AddToFavSHOWNBTN.ClientID %>');
                    var ADDTOFAVASPBTN = document.getElementById('<%= HIDDENADDTOFAV.ClientID %>');
                    var REMOVEFROMFAVASPBTN = document.getElementById('<%= HIDDEMREMOVEFROMFAV.ClientID %>');

                    function ADDTOFAV() {
                        ADDTOFAVASPBTN.click();
                        FavFuncKeyBTN.setAttribute("onclick", "REMOVEFROMFAV();");
                        //FavPathElm.setAttribute("d", FavFILLEDPATH);
                        setTimeout(() => {
                            FavPathElm.setAttribute("d", FavFILLEDPATH);
                            document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        }, 720);
                    };

                    function REMOVEFROMFAV() {
                        REMOVEFROMFAVASPBTN.click();
                        FavFuncKeyBTN.setAttribute("onclick", "ADDTOFAV();");
                        //FavPathElm.setAttribute("d", FavNOTFILLEDPATH);
                        setTimeout(() => {
                            FavPathElm.setAttribute("d", FavNOTFILLEDPATH);
                            document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        }, 720);
                    };

                    var UPDATEDCONTANT = false;
                    if (UPDATEDCONTANT == false) {
                        document.getElementById('<%= UpdateInfo.ClientID %>').click();
                        UPDATEDCONTANT = true;
                    }
                </script>
            </div>
        </div>
        <div id="CommentsSecCont" runat="server" class="animated slideDown" style="border:4px rgba(225,225,225,0.75) solid;border-top:4px rgba(0,0,0,0) solid;max-height:90%;border-top-right-radius: 22px;border-top-left-radius:22px;background-color:rgba(255,255,255,0.74);display:none;margin-top:30vh;width:100vw;height:fit-content;position:absolute;top:0 !important;padding-top:100vh;z-index:998;">
            <a id="CommentsSecTopPartColor" runat="server" style="margin-top:0px !important;margin:0 auto !important;width:100vw !important;height:fit-content !important;background:rgba(0,0,0,0);padding:0px !important;">
                <h5 class="animated fadeIn" style="color:#fff;padding-top:26px;padding-left:22px;padding-bottom:4px;font-size:96%;margin-top:calc(12px - 100vh);">Comments section</h5>
                <div class="animated fadeIn" id="SendCommentAria" style="border-radius:12px;width:100%;height:fit-content;margin:0 auto;padding:6px;margin-top:8px;margin-bottom:6px;display:block;">
                    <!--<a style="display:inline;color:#141414;">add a comment...</a>-->
                    <asp:TextBox CssClass="form-control form-control-user" runat="server" ID="UserComment" BackColor="Transparent" BorderColor="Transparent" ForeColor="#ffffff" style="display:inline;width:84%;height:74px;" placeholder="add a comment..."></asp:TextBox>
                    <asp:ImageButton OnClick="SendComment" ID="SendBTN" style="background-color:#fff;border-radius:4px;width:38px;height:32px;margin:4px;" ImageAlign="AbsMiddle" ImageUrl="/svg/send.svg" runat="server" />
                </div>
            </a>
            <style>
                .HiddenASPBTN {
                    display:none !important;
                    visibility:hidden !important;
                }
            </style>
            <asp:Button ID="CommentsSecOpenBTN" runat="server" OnClick="LoadCommentsSection" CssClass="HiddenASPBTN" />
            <script type="text/javascript">
                var CommentsSecIsloaded = false;
                var CommentsSecFirstLoad = true;
                var elm = document.getElementById("MainContent_CommentsSecCont");
                elm.style.marginTop = (elm.style.marginTop - document.getElementById('subnavscont2').offsetHeight) + 'px';
                function FuncLoadCommentsSec() {
                    if (CommentsSecIsloaded == false) {
                        if (CommentsSecFirstLoad == true) {
                            setTimeout(() => {
                                document.getElementById('<%= CommentsSecOpenBTN.ClientID %>').click();
                                CommentsSecFirstLoad = false;
                            }, 1800);
                        }
                        CommentsSecIsloaded = true;
                        setTimeout(() => {
                            elm.classList.remove('slideDown');
                            elm.classList.add('slideInUp');
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = "block";
                        }, 10);
                    }
                    else {
                        document.getElementById('<%= CommentsSecCont.ClientID %>').style.display = 'none';
                        CommentsSecIsloaded = false;
                        setTimeout(() => {
                            elm.classList.remove('slideInUp');
                            document.getElementById('MainContent_Comments').classList.remove('fadeIn');
                            elm.style.display = 'none';
                            elm.classList.add('slideDown');
                            elm.style.display = 'block';
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = 'none';
                            document.getElementById('MainContent_Comments').classList.add('fadeIn');
                        }, 800);
                    }
                };
            </script>
            <asp:UpdatePanel ID="CommentsSecUpdatePanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SendBTN" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CommentsSecOpenBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="Comments" style="width:calc(100vw - 20px) !important;max-height:calc(70vh - 208px) !important;height:calc(70vh - 208px) !important;overflow-x:hidden;overflow-y:scroll;background-color:#ffffff !important;border-radius:18px;padding-left:12px;padding-right:12px;padding-top:18px;padding-bottom:18px;margin-left:10px;margin-right:10px;margin-top:10px;" runat="server">
                            <div class="animated fadeIn" style="width:100%;height:fit-content;margin-top:calc(35vh - 128px) !important;text-align:center !important;">
                                <a id="dot1" runat="server" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000066;margin-right:12px;"></a>
                                <a id="dot2" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;margin-right:6px;"></a>
                                <a id="dot3" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;"></a>
                            </div>
                            <script>
                                var dot1 = document.getElementById('MainContent_dot1');
                                var dot2 = document.getElementById('dot2');
                                var dot3 = document.getElementById('dot3');
                                var DotsThemeColor = dot1.style.backgroundColor;
                                var Deafultcolor = '#00000029';
                                function AnimationDots123() {
                                    setTimeout(() => {
                                        dot2.style.backgroundColor = DotsThemeColor;
                                        dot1.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 600);
                                    setTimeout(() => {
                                        dot3.style.backgroundColor = DotsThemeColor;
                                        dot2.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1200);
                                    setTimeout(() => {
                                        dot1.style.backgroundColor = DotsThemeColor;
                                        dot3.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1800);

                                    setTimeout(AnimationDots123, 1900);
                                }
                                AnimationDots123();
                            </script>
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <div class="animated fadeIn" id="NextChapter" style="display:block;position:absolute;top:0;margin-left:calc(92vw - 60px);margin-top:4px;" runat="server" >
                <a style="" class="btn btn-primary btn-sm animated fadeInUp" href="#"></a>
            </div>
    </div>
</asp:Content>