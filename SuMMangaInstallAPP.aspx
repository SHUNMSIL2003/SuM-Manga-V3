<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuMMangaInstallAPP.aspx.cs" Inherits="SuM_Manga_V3.SuMMangaInstallAPP" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
        <title>Install is required - SuM Manga</title>
        <meta name="theme-color" content="rgb(242,242,242)"><meta name="description" content="Shun Manga Shop">
        <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
        <link rel="manifest" href="../manifest.json?h=f7ca12cbff627266dac4280164023899">
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
        <link rel="stylesheet" href="../assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="../assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="../assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="../assets/animate.min.css"><meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos">
        <meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc">
        <meta name="google-signin-client_id" content="464504450730-iuk9hotshe7kjnq73p11mdvijc49ll5c.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async="" defer="" gapi_processed="true"></script>

    <meta name="description" content="Shun Manga"><link rel="icon" type="image/png" sizes="16x16" href="/assets/img/any_icon_x16.png?h=57b6f23874c6f0554f87db98b188162f"><link rel="icon" type="image/png" sizes="32x32" href="/assets/img/any_icon_x32.png?h=c6e95e86bee5c429ad96d74eb8a03d17"><link rel="icon" type="image/png" sizes="180x180" href="/assets/img/any_icon_x180.png?h=871c022ab54519fd72e751e1fb1e8b51"><link rel="icon" type="image/png" sizes="192x192" href="/assets/img/any_icon_x192.png?h=ce0f4944b0b251649d44e6c8399f6165"><link rel="icon" type="image/png" sizes="512x512" href="/assets/img/any_icon_x512.png?h=951d9a72d5c8436fe4694aec7383dc0a"><link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
    <!-- <link rel="manifest" href="manifest.json?h=f7ca12cbff627266dac4280164023899" /> -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"><link rel="stylesheet" href="/assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100"><link rel="stylesheet" href="/assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100"><link rel="stylesheet" href="/assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100"><link rel="stylesheet" href="/assets/animate.min.css"><meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos"><meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc">

    <!-- VALID PWA START -->
    <link rel="apple-touch-icon" sizes="180x180" href="/apple-touch-icon.png"><link rel="icon" type="image/png" sizes="32x32" href="/favicon-32x32.png"><link rel="icon" type="image/png" sizes="16x16" href="/favicon-16x16.png"><link rel="manifest" href="/manifest.webmanifest" crossorigin="use-credentials"><link rel="mask-icon" href="/safari-pinned-tab.svg" color="#6840d9"><link rel="shortcut icon" href="/favicon.ico"><meta name="apple-mobile-web-app-title" content="SuM Manga"><meta name="application-name" content="SuM Manga"><meta name="msapplication-TileColor" content="#f2f2f2"><meta name="msapplication-TileImage" content="/mstile-144x144.png"><meta name="theme-color" content="#f2f2f2"><meta name="msapplication-TileColor" content="#f2f2f2"><meta name="msapplication-TileImage" content="/mstile-144x144.png"><meta name="apple-mobile-web-app-capable" content="yes"><meta name="apple-mobile-web-app-status-bar-style" content="default"><link rel="apple-touch-icon" href="/assets/img/any_icon_x180.png"><link rel="apple-touch-icon" sizes="152x152" href="/ios/152.png"><link rel="apple-touch-icon" sizes="167x167" href="/ios/167.png"><link rel="apple-touch-icon" sizes="100x100" href="/ios/100.png"><link rel="apple-touch-icon" sizes="1024x1024" href="/ios/1024.png"><link rel="apple-touch-icon" sizes="114x114" href="/ios/114.png"><link rel="apple-touch-icon" sizes="120x120" href="/ios/120.png"><link rel="apple-touch-icon" sizes="128x128" href="/ios/128.png"><link rel="apple-touch-icon" sizes="144x144" href="/ios/144.png"><link rel="apple-touch-icon" sizes="16x16" href="/ios/16.png"><link rel="apple-touch-icon" sizes="192x192" href="/ios/192.png"><link rel="apple-touch-icon" sizes="20x20" href="/ios/20.png"><link rel="apple-touch-icon" sizes="256x256" href="/ios/256.png"><link rel="apple-touch-icon" sizes="29x29" href="/ios/29.png"><link rel="apple-touch-icon" sizes="32x32" href="/ios/32.png"><link rel="apple-touch-icon" sizes="40x40" href="/ios/40.png"><link rel="apple-touch-icon" sizes="50x50" href="/ios/50.png"><link rel="apple-touch-icon" sizes="512x512" href="/ios/512.png"><link rel="apple-touch-icon" sizes="57x57" href="/ios/57.png"><link rel="apple-touch-icon" sizes="58x58" href="/ios/58.png"><link rel="apple-touch-icon" sizes="60x60" href="/ios/60.png"><link rel="apple-touch-icon" sizes="64x64" href="/ios/64.png"><link rel="apple-touch-icon" sizes="72x72" href="/ios/72.png"><link rel="apple-touch-icon" sizes="76x76" href="/ios/76.png"><link rel="apple-touch-icon" sizes="80x80" href="/ios/80.png"><link rel="apple-touch-icon" sizes="87x87" href="/ios/87.png"><link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphone6_splash.png" media="(device-width: 375px) and (device-height: 667px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphoneplus_splash.png" media="(device-width: 621px) and (device-height: 1104px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonex_splash.png" media="(device-width: 375px) and (device-height: 812px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonexr_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonexsmax_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/ipad_splash.png" media="(device-width: 768px) and (device-height: 1024px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro1_splash.png" media="(device-width: 834px) and (device-height: 1112px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro3_splash.png" media="(device-width: 834px) and (device-height: 1194px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro2_splash.png" media="(device-width: 1024px) and (device-height: 1366px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image">
    <!--  VALID PWA END  -->


</head>

<body class="bg-gradient-primary" style="background: rgb(242,242,242);">
    <style>
        * {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
            text-decoration: none;
            -webkit-transition: all 0.5s;
            -moz-transition: all 0.5s;
            -ms-transition: all 0.5s;
            -o-transition: all 0.5s;
            transition: all 0.5s;
        }
        body {
            animation: rainbow 10s linear infinite;
        }

        @keyframes rainbow {
            0% {
                background-color: #baa9cc;
            }

            25% {
                background-color: #85798b;
            }

            50% {
                background-color: #82667b;
            }

            75% {
                background-color: #968aae;
            }

            100% {
                background-color: #baa9cc;
            }
        }
         img {
            pointer-events: none;
        }
         text, h1, h2, h3, h4, h5, h6, p {
            pointer-events: none;
         }
        body {
            overflow: hidden; /* Hide scrollbars */
        }
        ::-webkit-scrollbar {
            display: none;
        }
        input, textarea {
            -webkit-user-select: text !important;
            -khtml-user-select: text !important;
            -moz-user-select: text !important;
            -ms-user-select: text !important;
            user-select: text !important;
        }
/* Hide scrollbar for IE, Edge and Firefox */
        body {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }
    </style>
    <script>  
        document.onkeypress = function (event) {
            event = (event || window.event);
            if (event.keyCode == 123) {
                return false;
            }
        }
        document.onmousedown = function (event) {
            event = (event || window.event);
            if (event.keyCode == 123) {
                return false;
            }
        }
        document.onkeydown = function (event) {
            event = (event || window.event);
            if (event.keyCode == 123) {
                return false;
            }
        }
    </script>   
    <script>
        window.addEventListener('contextmenu', e => {
            e.preventDefault();
        });/*
        (function () {
            setInterval(() => {
                debugger;
            }, 100);
        })();*/
    </script>
<div class="aspNetHidden">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKMTQ2NTU2OTk0NmRk3trvmzQ4Opk45ssbSEpG4pMCxkUq/C+H8zRomeAoEWE=">
</div>

<div class="aspNetHidden">

	<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="B566693B">
</div>
    <div style="height:calc(100vh - 100px);" class="container pulse animated">
        <div class="row justify-content-center">
            <div class="col-md-9 col-lg-12 col-xl-10">
                <div style="border-radius:22px;" class="card shadow-lg o-hidden border-0 my-5">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-flex">
                                <div class="flex-grow-1 bg-login-image" style="background: url(&quot;/assets/img/dogs/SuM-Reader.jpg?h=0086b7bb234345281e92a417000e3a03&quot;);"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h4 class="text-dark mb-4" style="color:rgba(104,64,217,0.92) !important;"><b>Installing our App is required to use SuM!</b></h4>
                                    </div>
                                    <div class="user">
                                        <p class="text-dark animated fadeIn" style="font-size:122%;width:100%;text-align:center;margin-top:32px;color:#000000f0;margin-bottom:20px;margin-top:54px;"><img class="animated pulse" src="/svg/androidlogo.svg" style="width:32px;height:32px;display:inline;"> Only on Android!</p>
                                        <form runat="server">
                                            <asp:Button runat="server" OnClick="AndroidDownloadAppStart" ID="ADB2022SuMMangaAPK" CssClass="btn btn-primary d-block btn-user w-100 animated fadeIn" style="background:rgba(104,64,217,0.92);border-color: rgba(104,64,217,0.92);border-radius:14px;margin-bottom:22px;" Text="Download" />
                                        </form>
                                        <hr>
                                        <p class="text-btn-dark animated fadeIn" style="width:100%;font-size:98%;text-align:center;margin-top:32px;margin-bottom:2px;"><img src="/svg/ioslogo.svg" style="width:32px;height:32px;display:inline;"> IOS is comming soon!</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 
        <script>
            document.addEventListener("DOMContentLoaded", function () {

                if ("androidAPIs" in window) {

                    androidAPIs.layoutDoneLoading();

                }

            });
        </script>
        <div id="Offline" class="STBSUMBAR bg-white shadow animated slideInUp" style="display:none;overflow:clip;border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;overflow:hidden !important;background-color:#6840D9 !important;bottom:0 !important;">
            <div class=" navbar-light navbar-expand bg-white shadow  topbar static-top" style="height:fit-content;width:100vw !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;border-top:solid 0.4px #6840D9 !important;bottom:0 !important;overflow:clip;background-color:#6840D9 !important;">
                 <div style="text-align:center;" class="text-center">
                    <p class="lead animated fadeIn" style="margin-top:6px;font-size:140%;color:#FFFFFF !important;">You are offline!</p>
                    <p class="lead animated fadeIn" style="margin-top:-18px;font-size:80%;color:rgba(255,255,255,0.64) !important;"><b>Login is not avalibe ...</b></p>
                     <br>
                </div>
            </div>
        </div>
    <script>
</script>
    <script src="/assets/js/jquery.min.js?h=84e399b8f2181ccd73394fdeddff1638"></script>
    <script src="/assets/bootstrap/js/bootstrap.min.js?h=06ed58a0080308e1635633c2fd9a56a3"></script>
    <script src="/assets/js/bs-init.js?h=cfc1cf2ac1407be801a1de7dc4705464"></script>
    <script src="/assets/js/theme.js?h=79f403485707cf2617c5bc5a2d386bb0"></script>



</body></html>
