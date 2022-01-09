<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        //PlaceHolder
        //document.getElementById('MainContent_SuMLoginUI').style.display = 'block';
    </script>
    <div id="ChapterUnavaliblePOPUP" runat="server" style="background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:none;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;" class="row justify-content-center">
        <div class="animated pulse card" style="animation-duration:0.36s !important;width:fit-content;height:fit-content;padding:6px;border-radius:18px;background-color:#ffffff;vertical-align:middle !important;margin-top:calc(48vh - 120px) !important;">
            <p style="font-size:146%;color:#232323;margin-bottom:3px;margin-left:12px;margin-top:2px;">Chapter is unavalible</p>
            <hr style="margin:0 auto !important;height:1px;border-width:0;color:rgba(0, 0, 0, 0.527);background-color:rgba(0, 0, 0, 0.527);width:calc(96vw - 36px) !important;margin:0px;margin-block:0px;height:2px !important;margin-bottom:12px !important;">
            <p style="color:rgba(0, 0, 0, 0.527);height:fit-content;width:auto;text-align:center;display:block;font-size:112%;">The reason is eather the chapter is not Finished/Uploaded or it does not sutable for audience from your contry.</p>
            <div style="text-align:center;margin-top:16px;">
                <a onclick="document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'none';" class="btn" style="margin:0 auto !important;background-color:rgb(104,64,217);color:#ffffff;border-radius:12px;width:fit-content;height:fit-content;padding-top:5px;padding-bottom:5px;padding-left:20px;padding-right:20px;">OK</a>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManagerLogin" EnablePartialRendering="true" runat="server" EnablePageMethods="true">
       </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="LoginBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="SuMLoginUI" runat="server" style=" background-color:aqua;overflow:hidden;width:100vw;height:100vh;display:block;z-index:999 !important;margin:0 auto !important;position:absolute !important;" class="row justify-content-center">
            <div id="SacondContForLogin" class="col-md-9 col-lg-12 col-xl-10">
                <div style="border-radius:22px !important;" class="card shadow-lg o-hidden border-0 my-5 sumsmoothtrans">
                    <div class="card-body p-0">
                        <div class="row">
                            <div style="width:100%;position:relative;">
                                <a style="float:right;width:32px;height:32px;padding:4px;margin-right:12px;margin-top:12px;" onclick="document.getElementById('MainContent_SuMLoginUI').style.display = 'none'; document.getElementById('MainContent_SuMLoginUI').classList.add('fadeIn'); document.getElementById('MainContent_SuMLoginUI').classList.add('animated'); document.getElementById('SacondContForLogin').classList.add('pulse'); document.getElementById('SacondContForLogin').classList.add('animated'); document.getElementById('fullnavscont').style.display = 'none'; document.getElementById('fullnavscont').classList.remove('slideOutDown'); document.getElementById('fullnavscont').classList.add('slideInUp'); document.getElementById('fullnavscont').style.display = 'block';">
                                    <img style="width:22px;height:22px;" src="/svg/close.svg" />
                                </a>
                            </div>
                            <div class="col-lg-6 d-none d-lg-flex">
                                <div class="flex-grow-1 bg-login-image" style="background: url(&quot;/assets/img/dogs/SuM-Reader.jpg?h=0086b7bb234345281e92a417000e3a03&quot;);"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5 sumsmoothtrans">
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
            max-width:1200px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }

    </style>
    <script>
        /* navigator.share({title:'SuM Manga',text:'Check out X on SuM Manga.',url:'LINK'}); */
        document.addEventListener("DOMContentLoaded", function () {

            var fullnavscont = document.getElementById("fullnavscont");

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
    <div id="FakeBody" runat="server" style="">
    <div id="background" style="background-color:rgba(225,225,225,0.50);">
    <div class="fadeIn animated">
    <div style="height:fit-content;width:100vw;overflow:hidden; background-color:transparent !important;position:fixed;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides animated fadeIn" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/X/X.jpg); background-size: cover; background-position: center;width:100vw !important;height:fit-content;">
    <div style="width:94vw;height:fit-content;position:relative;margin:0 auto;margin-top:32px;">
        <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;width:100%;height:fit-content;">#</h1>
        <p style="color:rgb(255, 255, 255, 0.82);float:right;margin-top:-18px;margin-right:10px;">By <b id="MangaCreator" style="font-size:80%;" runat="server"></b></p>
    </div>
        <hr style="margin:0 auto !important;height:2.6px !important;border-width:0;color:#ffffff;background-color:#ffffff;width:82vw;opacity:0.26;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:6px;margin-bottom:6px !important;">
    <p style="text-align:center;height:fit-content;min-height:54vw !important; width:auto;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;margin-bottom:26px !important;margin-top:2px !important;" id="MdiscS" runat="server">#</p>
    <div style="margin:0 auto;margin-bottom:28px;height:fit-content;width:100%;position:relative;">
        <a style="display:block;float:right !important;margin-right:12px;">
            <p style="display:inline;color:rgba(255,255,255,0.74);" id="MangaRating" runat="server"></p>
            <img style="width:20px;height:20px;display:inline;" src="/svg/views.svg" />
            <p style="display:inline;color:#ffffff;" id="ViewsSutNum" runat="server"></p>
            <b style="display:inline;color:#ffffff;" id="ViewsSutLater" runat="server"></b>
        </a>
    </div>
</div>
</div>
            </div>
        <div class="animated fadeInUp" id="ChaptersAndFuncCard" style="opacity: 0 !important;margin-top:-20px;background-color:#ffffff;border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;">
        <div id="GernsTags" runat="server" style="border-top-right-radius:22px;border-top-left-radius:22px;width:100vw;height:fit-content;background-color:transparent;align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(0,0,0,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
        <div style="background-color:aqua;margin:0 auto;height:fit-content;position:relative;margin-top:-2px !important;" id="SVC" runat="server">
            <div class="animated pulse" id="MRSC" runat="server" style="margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;display:inline;">
                <a id="MRSW" onclick="" runat="server" href="#" style="color:#6840D9;"></a>
            </div>
            <a id="SuMShare" runat="server" style="width:38px;width:38px;float:right;margin-top:-46px;padding:4px;margin-right:6px;display:inline !important;" class="animated fadeIn" onclick="#">
                <img src="/svg/share.svg" style="width:28px;height:28px;" alt="Share" />
            </a>
        </div>
    <div style="display:block;height:fit-content;min-height:100vh !important;background-color:rgba(1,65,54,0.544);padding-bottom:128px !important;" id="TheMangaPhotosF" runat="server">
     </div>
       </div>
        </div>
        </div>
    <script>
        document.onreadystatechange = function () {
            if (document.readyState == "complete") {

                var CatXHeight = document.getElementById('MainContent_CategoryX').getBoundingClientRect();
                document.getElementById('ChaptersAndFuncCard').style.marginTop = (CatXHeight.height - 22) + "px";
                document.getElementById("ChaptersAndFuncCard").style.opacity = null;
                document.getElementById("ChaptersAndFuncCard").style.display = "none";
                document.getElementById("ChaptersAndFuncCard").style.display = "block";

            }
        };
    </script>
</asp:Content>
