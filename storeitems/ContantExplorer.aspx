<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        document.getElementById('fullnavscont').style.display = 'block';
        if ("androidAPIs" in window) {
            androidAPIs.FullyTransStatusBar();
        }
        else {
            location.href = '/SuMMangaInstallAPP.aspx';
        }
    </script>
    <asp:Button ID="UpdateWannaNFavNCurr" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden !important;" />
    <div id="ChapterUnavaliblePOPUP" runat="server" style="background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:none;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center GoodBlurAnim">
        <div id="SUAC000SP" runat="server" class="animated zoomIn card shadow-sm" style="margin:0 auto !important;max-width:382px !important;animation-duration:0.28s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(50vh - 106px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:0px;margin:0 auto;margin-top:6px !important;">Chapter is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:84% !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;margin-top:8px !important;border-radius:1px !important;">
            <p style="width:80% !important;margin:0 auto;color:rgba(0, 0, 0, 0.527);height:fit-content;text-align:center;display:block;font-size:112%;">The reason is eather the chapter is not Finished/Uploaded yet, or it is not sutable for audience from your contry or your age.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;margin-bottom:8px !important;">OK</a>
            </div>
        </div>
    </div>
    
    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="LoginBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="SuMLoginUI" runat="server" style=" background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:block;z-index:999 !important;margin:0 auto !important;position:absolute !important;" class="row justify-content-center GoodBlur">
            <div id="SacondContForLogin" style="width:100vw !important;height:100vh !important;" class="col-md-9 col-lg-12 col-xl-10">
                <div style="border-radius:22px !important;max-width:960px !important;margin:0 auto !important;margin-top:64px !important;" class="card shadow-lg o-hidden border-0 my-5 sumsmoothtrans">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-flex">
                                <div class="flex-grow-1 bg-login-image" style="background: url(&quot;/assets/img/dogs/SuM-Reader.jpg?h=0086b7bb234345281e92a417000e3a03&quot;);"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5 sumsmoothtrans">
                                <a style="float:right;width:32px;height:32px;padding:4px;margin-right:-32px !important;margin-top:-32px !important;" onclick="document.getElementById('MainContent_SuMLoginUI').style.display = 'none'; document.getElementById('MainContent_SuMLoginUI').classList.add('fadeIn'); document.getElementById('MainContent_SuMLoginUI').classList.add('animated'); document.getElementById('SacondContForLogin').classList.add('pulse'); document.getElementById('SacondContForLogin').classList.add('animated'); document.getElementById('fullnavscont').style.display = 'none'; document.getElementById('fullnavscont').classList.remove('slideOutDown'); document.getElementById('fullnavscont').classList.add('slideInUp'); document.getElementById('fullnavscont').style.display = 'block';">
                                    <img style="width:22px;height:22px;" src="/svg/close.svg" />
                                </a>
                                    <div class="text-center">
                                        <h4 class="text-dark mb-4">Login to start reading!</h4>
                                    </div>
                                    <div class="user">
                                        <div class="mb-3"><input class="form-control form-control-user" type="text" style="border-radius:14px;" id="UserNameL" placeholder="User Name" name="UserName" runat="server"></div>
                                        <div class="mb-3"><input class="form-control form-control-user" type="password" style="border-radius:14px;" id="PasswordL" placeholder="Password" name="password" runat="server"></div>
                                        <div style="text-align:center;width:100%;height:fit-content;margin-bottom:16px;">
                                            <div class="animated fadeInDown" runat="server" id="LogInProssInfo" style="display:none;">
                                                <h6 class="animated pulse" style="color:rgb(255,90,69);padding:8px;" id="LoginStatus" runat="server"></h6>
                                                <asp:Button CssClass="btn btn-primary d-block btn-user w-100" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="ResendConfLink" Visible="false" ID="ResendConf" Text="Re-Send Email" />
                                                <asp:Button CssClass="btn btn-primary d-block btn-user w-100" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="LogOutOffAll" Visible="false" ID="LogOutOffAllBTN" Text="Logout of all devices" />
                                            </div>
                                        </div>
                                        <div class="mb-3 sumsmoothtrans">
                                            <div class="custom-control custom-checkbox small">
                                                <div class="form-check"><input class="form-check-input custom-control-input" type="checkbox" checked="checked" id="formCheck-1"><label id="rem" runat="server" class="form-check-label custom-control-label" for="formCheck-1">Remember Me</label></div>
                                            </div> 
                                        </div>
                                        <asp:Button ID="LoginBTN" CssClass="btn btn-primary d-block btn-user w-100 sumsmoothtrans" style="background: rgb(104,64,217);border-color: rgb(104,64,217);border-radius:14px;" OnClick="LoginToSuM" runat="server" Text="Login" />
                                        <hr class="sumsmoothtrans">
                                        <a style="border-radius:14px !important;" class="sumsmoothtrans btn btn-primary d-block btn-google btn-user w-100 mb-2" role="button"><i class="fab fa-google"></i>&nbsp; Login with Google</a>
                                        <a style="border-radius:14px !important;" class="sumsmoothtrans btn btn-primary d-block btn-facebook btn-user w-100" role="button"><i class="fab fa-facebook-f"></i>&nbsp; Login with Facebook</a>
                                        <hr class="sumsmoothtrans">
                                    </div>
                                    <div class="text-center sumsmoothtrans"><a class="small" href="/AccountETC/PassRecovryETC.aspx" style="color: rgb(104,64,217);">Forgot Password?</a></div>
                                    <div class="text-center sumsmoothtrans"><a class="small" href="/AccountETC/RegisterETC.aspx" style="color: rgb(104,64,217);">Create an Account!</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
    <script>
        document.getElementById('MainContent_SuMLoginUI').style.display = 'none';
        document.getElementById('MainContent_SuMLoginUI').classList.add('fadeIn');
        document.getElementById('MainContent_SuMLoginUI').classList.add('animated');
        document.getElementById('SacondContForLogin').classList.add('pulse');
        document.getElementById('SacondContForLogin').classList.add('animated');

        /*document.getElementById('fullnavscont').style.display = 'none';
        document.getElementById('fullnavscont').classList.remove('slideOutDown');
        document.getElementById('fullnavscont').classList.add('slideInUp');
        document.getElementById('fullnavscont').style.display = 'block';*/
    </script>
    <style>
        /*# {
            animation: rainbow 10s linear infinite;
        }*/

        @keyframes rainbow {
            0% {
                background-color: #baa9ccd1;
            }

            25% {
                background-color: #85798bd1;
            }

            50% {
                background-color: #82667bd1;
            }

            75% {
                background-color: #968aaed1;
            }

            100% {
                background-color: #baa9ccd1;
            }
        }
        .ForceMaxW {
            max-width:1600px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }

    </style>
    <script>
        /* navigator.share({title:'SuM Manga',text:'Check out X on SuM Manga.',url:'LINK'}); */
        if (fullnavscont.classList.contains('slideInUp')) {
            fullnavscont.classList.remove('slideOutDown');
            fullnavscont.classList.remove('slideInUp');
            fullnavscont.style.display = 'block';
        };
        document.addEventListener("DOMContentLoaded", function () {

            var fullnavscont = document.getElementById("fullnavscont");
            if (fullnavscont.classList.contains('slideOutDown')) {
                fullnavscont.classList.remove('slideOutDown');
                fullnavscont.classList.add('slideInUp');
                fullnavscont.style.display = 'block';
            };

            // Check if there is a local storage item with tbe name "animate"
            /*if (window.localStorage.getItem("animate") != null) {

                fullnavscont.style.display = "none";
                */
                // Remove the item
                /*window.localStorage.removeItem("animate");

                fullnavscont.classList.add("animated", "slideInUp");

                fullnavscont.style.display = null;

            }*/

            window.onclick = function (e) {

                //console.log(e);

                // Check if this action was triggered by clicking an <a> element
                if (document.activeElement.tagName == "A" && document.activeElement.getAttribute("name") != "no-animation") {

                    // Get the element's href
                    var redirectLink = document.activeElement.getAttribute("href");

                    // Prevent the page from being redirected
                    e.preventDefault();

                    // Add the slide down animation
                    fullnavscont.classList.add("animated", "slideOutDown");

                    setTimeout(function () {

                        window.location.href = redirectLink;

                    }, 480);

                }

            };
        });
    </script>
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
            <p style="display:inline;color:rgba(255,255,255,0.74);" id="MangaRating" runat="server"></p>
            <img style="width:20px;height:20px;display:inline;" src="/svg/views.svg" />
            <p style="display:inline;color:#ffffff;" id="ViewsSutNum" runat="server"></p>
            <b style="display:inline;color:#ffffff;" id="ViewsSutLater" runat="server"></b>
        </a>
    </div>
        <div style="margin:0 auto;margin-bottom:28px;height:12px !important;width:100%;position:fixed;"></div>
</div>
</div>
            </div>
        <div class="animated fadeIn" style="animation-duration:0.18s;opacity:0;float:left !important;margin-top:20vh;width:100% !important;height:66px !important;overflow:hidden !important;position:fixed !important;" id="FavNWannaContaner" runat="server">
            <div id="AddToFavNWanna" runat="server" style="animation-duration:0.26s !important;width:fit-content;height:38px;background-color:red;border-radius:18px;padding:4px !important;opacity:0;" class="animated pulse" >
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

                    var DetectedThemeColor = null;
                    location.search.substring(1).split("&").forEach(function (val) {

                        var currVal = val.split("=");
                        if (currVal[0] == "TC") {

                            DetectedThemeColor = decodeURI(currVal[1]);

                        }

                    });

                    document.getElementById('3rdGBLayer').style.backgroundColor = DetectedThemeColor.replace("0.74", "0.32");

                    function AddToFavJava() {
                        FAVIMGBTN.src = '/svg/favorite.svg';
                        HIDDENFAVadd.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function RemoveFromFavJava() {
                        FAVIMGBTN.src = '/svg/favoriteNOTFILLED.svg';
                        HIDDENFAVremove.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function AddToWannaJava() {
                        WANNAIMGBTN.src = '/svg/check.svg';
                        HIDDENWANNAadd.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };

                    function RemoveFromWannaJava() {
                        WANNAIMGBTN.src = '/svg/add.svg';
                        HIDDENWANNAremove.click();
                        setTimeout(() => {
                            document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();
                        }, 720);
                        //return false;
                    };
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
            <asp:UpdatePanel ID="CurrStateLoad" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UpdateWannaNFavNCurr" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <hr style="width:82%;height:2px;border-radius:1px;color:#ffffff30;margin:0 auto !important;margin-top:-6px !important;margin-bottom:6px !important;position:absolute;z-index:998;margin-left:9% !important;" />
                        <div class="animated pulse" id="MRSC" runat="server" style="margin-top:3px !important;margin-bottom:13px !important;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;display:inline;overflow:hidden !important;">
                            <a id="MRSW" onclick="" runat="server" href="#" style="color:#6840D9;"></a>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <a id="SuMShare" style="width:38px;width:38px;float:right;margin-top:-46px;padding:4px;margin-right:6px;display:inline !important;" class="animated fadeIn" onclick="androidAPIs.ShareThisPage();">
                <img src="/svg/share.svg" style="width:28px;height:28px;" alt="Share" />
            </a>
        </div>
            <asp:Button ID="LoadMOreChapters" OnClick="LOADMORECHAPTERS" runat="server" style="display:none;visibility:hidden;" />
            <div id="MangaChAMConta" style="display:block;height:fit-content;min-height:100vh !important;padding-bottom:164px !important;min-height:100vh;" runat="server">
            <asp:UpdatePanel ID="LoadChapters" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="LoadMOreChapters" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="TheMangaPhotosF" style="width:100%;height:fit-content;padding-top:6px;" runat="server">
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

                document.getElementById('<%= UpdateWannaNFavNCurr.ClientID %>').click();

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
        /*var UsedLoadMoreOne = false;
        var ChaptersELM = document.getElementById("MainContent_FakeBody");
        ChaptersELM.onscroll = function () {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };

        ChaptersELM.ontouchmove = function () {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };

        ChaptersELM.on('touchmove', TuchMoveLOADMORE);
        function TuchMoveLOADMORE() {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };
        ChaptersELM.on('scroll', scrollMoveLOADMORE);
        function scrollMoveLOADMORE() {

            if (ChaptersELM.scrollHeight == (ChaptersELM.scrollTop + ChaptersELM.clientHeight) && UsedLoadMoreOne == false) {
                document.getElementById('MainContent_LoadMOreChapters').click();
                UsedLoadMoreOne = true;
            };

        };*/
    </script>
</asp:Content>
