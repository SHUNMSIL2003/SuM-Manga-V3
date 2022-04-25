<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="ContantExplorerCard.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.ContantExplorerCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>var FMID = 0;</script>
    <div style="display:none !important;visibility:hidden !important;" id="ScriptInjectorB000" runat="server"></div>
    <asp:Button ID="UpdateWannaNFavNCurr" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden !important;" />
    <style>
        .ForceMaxW {
            max-width:1600px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:var(--SuMThemeColor) !important;
        }

    </style>
    <div id="CONTANERFROCONTANTEXPLORER" style="width:100vw !important;max-width:740px !important;margin:0 auto !important;">
            <div style="background-color:transparent !important;height:fit-content;width:100%;">
        <div style="overflow:hidden;background-color:rgba(0,0,0,0.32) !important;margin:0 auto;height:fit-content;margin-top:0px !important;padding-top:0px !important;">
            <div id="AddToFavNWanna" runat="server" style="overflow:hidden !important;animation-duration:0.26s !important;width:fit-content;height:38px;background-color:transparent !important;border-radius:18px;padding:4px !important;margin-left:0px;float:left !important;margin-top:0px !important;border-bottom-left-radius:0px !important;border-top-left-radius:0px !important;margin-top:8px !important;width:100vw !important;" class="animated pulse" >
                <asp:Button ID="ADDTOFAV" runat="server" OnClick="AddToFavList" style="display:none;visibility:hidden;" />
                <asp:Button ID="REMOVEFROMFAV" runat="server" OnClick="RemoveFromFavList" style="display:none;visibility:hidden;" />
                <asp:Button ID="ADDTOWANNA" runat="server" OnClick="AddToWannaList" style="display:none;visibility:hidden;" />
                <asp:Button ID="REMOVEFROMWANNA" runat="server" OnClick="RemoveFromWannaList" style="display:none;visibility:hidden;" />
                <asp:UpdatePanel ID="CEFAVNWANNAUpdatepanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="REMOVEFROMWANNA" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ADDTOWANNA" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="REMOVEFROMFAV" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ADDTOFAV" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="UpdateWannaNFavNCurr" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <img id="Fav" runat="server" src="/svg/favoriteNOTFILLED.svg" style="margin-left:18px;margin-right:6px !important;pointer-events:all !important;" height="26" width="26" class="animated pulse" />
                        <a style="display:inline-block !important;width:2px !important;height:18px !important;margin:0 auto !important;vertical-align:middle !important;background-color:#ffffff30 !important;border-radius:1px !important;overflow:hidden;"></a>
                        <img id="Wanna" runat="server" src="/svg/add.svg" style="margin-right:-4px;display:inline !important;pointer-events:all !important;" height="30" width="30" class="animated pulse" />
                        <p style="color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" id="WannaListTXT" runat="server" class="animated pulse"><b>Wanna list</b></p>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
                <script>
                    var FAVIMGBTN = document.getElementById('<%= Fav.ClientID %>');
                    var WANNAIMGBTN = document.getElementById('<%= Wanna.ClientID %>');
                    var HIDDENFAVadd = document.getElementById('<%= ADDTOFAV.ClientID %>');
                    var HIDDENFAVremove = document.getElementById('<%= REMOVEFROMFAV.ClientID %>');
                    var HIDDENWANNAadd = document.getElementById('<%= ADDTOWANNA.ClientID %>');
            var HIDDENWANNAremove = document.getElementById('<%= REMOVEFROMWANNA.ClientID %>');

            function AddToFavJava() {
                FAVIMGBTN.src = '/svg/favorite.svg';
                HIDDENFAVadd.click();
                setTimeout(() => {
                    document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
            };

            function RemoveFromFavJava() {
                FAVIMGBTN.src = '/svg/favoriteNOTFILLED.svg';
                HIDDENFAVremove.click();
                setTimeout(() => {
                    document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
            };

            function AddToWannaJava() {
                WANNAIMGBTN.src = '/svg/check.svg';
                HIDDENWANNAadd.click();
                setTimeout(() => {
                    document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
            };

            function RemoveFromWannaJava() {
                WANNAIMGBTN.src = '/svg/add.svg';
                HIDDENWANNAremove.click();
                setTimeout(() => {
                    document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                }, 720);
                    };
                </script>
                <a id="SuMShare" style="width:38px;width:38px;float:right;margin-top:-36px;padding:4px;margin-right:6px;display:inline !important;" class="animated fadeIn" onclick="androidAPIs.ShareThisPage();">
                <img src="/svg/share.svg" style="width:28px;height:28px;" alt="Share">
            </a>
            </div>
            <asp:UpdatePanel ID="CurrStateLoad" runat="server" style="width:100vw !important" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UpdateWannaNFavNCurr" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated pulse" id="MRSC" runat="server" style="margin-top:3px !important;margin-bottom:13px !important;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;display:inline;overflow:hidden !important;">
                            <a id="MRSW" onclick="" runat="server" href="#" style="color:var(--SuMThemeColor);"></a>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
            <asp:Button ID="LoadMOreChapters" OnClick="LOADMORECHAPTERS" runat="server" style="display:none;visibility:hidden;" />
            <div id="MangaChAMConta" style="display:block;height:fit-content;min-height:100vh !important;background-color:transparent !important;padding-bottom:164px !important;min-height:calc(100vh + 6px) !important;" runat="server">
            <asp:UpdatePanel ID="LoadChapters" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="LoadMOreChapters" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="TheMangaPhotosF" style="width:100%;height:fit-content;background-color:transparent;padding:8px !important;padding-top:14px !important;" runat="server">
                        </div>
                        <a id="ThreIsMoreACard" onclick="document.getElementById('MainContent_LoadMOreChapters').click(); return false;" runat="server" style="width:100%;height:fit-content;text-align:center !important;margin:0 auto !important;display:block;padding-bottom:130px !important;padding-top:60px !important;" >
                            <p style="color:#FFFFFFEB !important;width:100%;text-align:center !important;margin:0 auto !important;font-size:92%;"><b style="color:#FFFFFFEB;">Tap anywhere for more</b></p>
                            <img src="/svg/expandmore.svg" style="width:46px;height:46px;margin:0 auto !important;margin-top:8px !important;margin-top:-12px !important;" />
                        </a>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            </div>
        </div>
    <p id="SuMViewsPlaceHolder" runat="server" style="display:none !important;visibility:hidden !important;"></p>
    <script>/*
        var FMID;
        var currurlfcardc0 = document.URL.replace(" ", "");
        var tryingtogetfuidhelper = currurlfcardc0.split("&");
        for (var i = 0; i < tryingtogetfuidhelper.length; i++) {
            if (tryingtogetfuidhelper[i].includes("VC=")) {
                MangaIDFoundCardExploreInfo = tryingtogetfuidhelper[i].replace("VC=");
            }
        }*/
        var MangaIDFoundCardExploreInfo = document.getElementById('<%= SuMViewsPlaceHolder.ClientID %>').innerText;
        $.ajax({
            dataType: "json",
            method: 'post',
            url: '<%= ResolveUrl("~/BTNTesting.aspx/GetMangaViewsCountFMySql") %>',
            data: JSON.stringify({ MID: MangaIDFoundCardExploreInfo }),
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                $("#SuMViewsPlaceHolder").append(msg.d);
                androidAPIs.SuMExploreMangaViews(msg.d);
            },
            error: function (e) {
                androidAPIs.SuMExploreMangaViews('error!');
            }
        });
    </script>
</asp:Content>