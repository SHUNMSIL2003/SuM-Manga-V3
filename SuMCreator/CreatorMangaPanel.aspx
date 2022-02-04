<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="CreatorMangaPanel.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.CreatorMangaPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .ForceMaxW {
            max-width:1600px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }
    </style>
    <asp:UpdatePanel ID="CretorMangaPanel" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SendBTN" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CommentsSecOpenBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
    <div id="FakeBody" runat="server" style="width:100vw !important;height:100vh !important;max-height:100vh !important;position:absolute !important;">
    <div id="background" style="background-color:rgba(255,255,255,0.92);width:100vw !important;height:100vh !important;">
    <div id="3rdGBLayer" style="background-color:rgba(255,255,255,0.64);width:100vw;height:100vh;">
    <div id="CONTANERFROCONTANTEXPLORER" style="width:100vw !important;max-width:740px !important;margin:0 auto !important;">
    <div id="ACont0" runat="server" class="fadeIn animated" style="width:100%;">
    <div class="animated fadeIn" style="height:fit-content;width:100%;overflow:hidden; background-color:transparent !important;position:fixed;max-width:720px;overflow-x:hidden !important;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides animated pulse" style="animation-duration:1.2s !important;overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/X/X.jpg); background-size: cover; background-position: center;width:100% !important;height:fit-content;">
    <div style="width:94%;height:fit-content;position:relative;margin:0 auto;margin-top:32px;">
        <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;width:100%;height:fit-content;">#</h1>
        <p style="color:rgb(255, 255, 255, 0.82);float:right;margin-top:-18px;margin-right:10px;">By <b id="MangaCreator" style="font-size:80%;" runat="server"></b></p>
    </div>
        <hr style="margin:0 auto !important;height:2.6px !important;border-width:0;color:#ffffff;background-color:#ffffff;width:82%;opacity:0.26;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:6px;margin-bottom:6px !important;">
    <p style="text-align:center;height:fit-content;width:auto;max-width:96%;font-size:96%;color:#ffffff;margin:14px !important;margin-bottom:26px !important;margin-top:2px !important;height:fit-content !important;min-height:280px !important;" id="MdiscS" runat="server">#</p>
    <div id="HiehtFixUpNCHxInfo" style="margin:0 auto;margin-bottom:32px !important;height:fit-content;width:100%;position:relative;">
        <a style="display:block;float:right !important;margin-right:22px;margin-top:-5px;">
            <asp:TextBox style="display:inline;color:rgba(255,255,255,0.74);" ID="MangaRatingTextBox" runat="server" />
            <img style="width:20px;height:20px;display:inline;" src="/svg/views.svg" />
            <p style="display:inline;color:#ffffff;" runat="server">Views num</p>
            <b style="display:inline;color:#ffffff;" runat="server"></b>
        </a>
    </div>
        <div style="margin:0 auto;margin-bottom:28px;height:12px !important;width:100%;position:fixed;"></div>
</div>
</div>
            </div>
        <div class="animated fadeIn" style="animation-duration:0.18s;opacity:0;float:left !important;margin-top:20vh;width:100% !important;height:66px !important;overflow:hidden !important;position:fixed !important;" id="FavNWannaContaner" runat="server">
            <div id="AddToFavNWanna" runat="server" style="animation-duration:0.26s !important;width:fit-content;height:38px;background-color:red;border-radius:18px;padding:4px !important;opacity:0;" class="animated pulse" >
                <div style="opacity:0.32 !important;">
                        <img src="/svg/favoriteNOTFILLED.svg" style="margin-left:18px;margin-right:6px !important;pointer-events:all !important;" height="26" width="26" class="animated pulse" />
                        <a style="display:inline-block !important;width:2px !important;height:18px !important;margin:0 auto !important;vertical-align:middle !important;background-color:#ffffff30 !important;border-radius:1px !important;overflow:hidden;"></a>
                        <img src="/svg/add.svg" style="margin-right:-4px;display:inline !important;pointer-events:all !important;" height="30" width="30" class="animated pulse" />
                        <p style="color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" id="WannaListTXT" runat="server" class="animated pulse"><b>Wanna list</b></p>
                </div>
                <script>
                    var DetectedThemeColor = null;
                    location.search.substring(1).split("&").forEach(function (val) {

                        var currVal = val.split("=");
                        if (currVal[0] == "TC") {

                            DetectedThemeColor = decodeURI(currVal[1]);

                        }

                    });

                    document.getElementById('3rdGBLayer').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.32");
                </script>
            </div>
        </div>
        <div class="animated fadeInUp" id="ChaptersAndFuncCard" style="animation-duration:0.26s !important;opacity: 0;margin-top:-20px;height:fit-content;background-color:transparent !important;max-width:720px !important;">
            <div style="width:100% !important;height:32px !important;background-color:transparent !important;overflow:hidden !important;"></div>
            <div style="background-color:#ffffff;border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;width:100%;">
        <div id="GernsTags" runat="server" style="border-top-right-radius:22px;border-top-left-radius:22px;width:100%;height:fit-content;background-color:transparent;align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(0,0,0,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
        <div style="background-color:aqua;margin:0 auto;height:fit-content;position:relative;margin-top:-2px !important;" id="SVC" runat="server">
                        <hr style="width:82%;height:2px;border-radius:1px;color:#ffffff30;margin:0 auto !important;margin-top:-6px !important;margin-bottom:6px !important;position:absolute;z-index:998;margin-left:9% !important;" />
                        <div class="animated pulse" id="MRSC" runat="server" style="margin-top:3px !important;margin-bottom:13px !important;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;display:inline;overflow:hidden !important;opacity:0.32 !important;">
                            <a id="MRSW" onclick="" runat="server" href="#" style="color:#6840D9;"></a>
                        </div>
            <a style="width:38px;width:38px;float:right;margin-top:-46px;padding:4px;margin-right:6px;display:inline !important;opacity:0.23 !important;" class="animated fadeIn" >
                <img src="/svg/share.svg" style="width:28px;height:28px;" alt="Share" />
            </a>
        </div>
            <div id="MangaChAMConta" style="display:block;height:fit-content;min-height:100vh !important;padding-bottom:164px !important;min-height:100vh;" runat="server">
           
                        <div id="TheMangaPhotosF" style="width:100%;height:fit-content;padding-top:6px;" runat="server">
                        </div>
            </div>
            </div>
       </div>
        </div>
        </div>
        </div>
        </div>
    <script>

        var ELMChaptersAndFuncCard = document.getElementById("ChaptersAndFuncCard");
        var ELMFavNWannaContaner = document.getElementById('<%= FavNWannaContaner.ClientID %>');
        ELMChaptersAndFuncCard.style.opacity = "0";
        ELMFavNWannaContaner.style.opacity = "0";
        ELMChaptersAndFuncCard.style.display = "block";
        ELMFavNWannaContaner.style.display = "block";

        document.onreadystatechange = function () {
            if (document.readyState == "interactive") {

                var CatXHeight = document.getElementById('<%= CategoryX.ClientID %>').getBoundingClientRect();

                ELMFavNWannaContaner.style.marginTop = (CatXHeight.height - 220) + "px";

                ELMFavNWannaContaner.style.display = "none";
                ELMChaptersAndFuncCard.style.marginTop = (CatXHeight.height - 36) + "px";

                setTimeout(() => {
                    ELMChaptersAndFuncCard.style.display = "none";
                    ELMChaptersAndFuncCard.style.opacity = "1";
                    ELMChaptersAndFuncCard.style.display = "block";
                }, 90);

                setTimeout(() => {
                    ELMFavNWannaContaner.style.marginTop = (CatXHeight.height - 90) + "px";
                    ELMFavNWannaContaner.style.opacity = "1";
                    ELMFavNWannaContaner.style.display = "block";
                    document.getElementById('HiehtFixUpNCHxInfo').style.marginBottom = '96px';
                }, 790);
            }
        };
    </script>
                        
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
