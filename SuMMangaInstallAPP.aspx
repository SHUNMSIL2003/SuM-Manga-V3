<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuMMangaInstallAPP.aspx.cs" Inherits="SuM_Manga_V3.SuMMangaInstallAPP" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
        <title>Install SuM-Manga</title>
        <meta name="description" content="The gate to sum-world! ">
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
        <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
        <link rel="stylesheet" href="/assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="/assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="/assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100">
        <link rel="stylesheet" href="/assets/animate.min.css">
        <style>
            :root {
                --SuMBack: var(--SuMDGray);
                --SuMCardBack: var(--SuMDWhite);
                --SuMThemeColor: rgb(104,64,217);
                --SuMThemeColorOP94: rgba(104,64,217,0.940);
                --SuMThemeColorOP92: rgba(104,64,217,0.920);
                --SuMThemeColorOP86: rgba(104,64,217,0.860);
                --SuMThemeColorOP84: rgba(104,64,217,0.840);
                --SuMThemeColorOP74: rgba(104,64,217,0.740);
                --SuMThemeColorOP64: rgba(104,64,217,0.640);
                --SuMThemeColorOP62: rgba(104,64,217,0.620);
                --SuMThemeColorOP54: rgba(104,64,217,0.540);
                --SuMThemeColorOP32: rgba(104,64,217,0.320);
                --SuMThemeColorOP14: rgba(104,64,217,0.140);
                --SuMThemeColorOP08: rgba(104,64,217,0.080);
                --SuMThemeColorOP00: rgba(104,64,217,0.000);
                --SuMThemeColorSec: rgb(136, 136, 136);
            }
    </style>
</head>

<body class="bg-gradient-primary" style="background: var(--SuMDGray);">
    <div style="visibility:hidden !important;display:none !important;" id="SuMLightModeControleThemeDiv">
        <style>
            :root {
                --SuMBack: rgb(0242,0242,0242);
                --SuMCardBack: rgb(0255,0255,0255);
                --SuMThemeColorSec: rgb(0136, 0136, 0136);
                --SuMDWhite:rgb(0255,0255,0255);
                --SuMDWhiteOP100:rgba(0255,0255,0255,0.1000);
                --SuMDWhiteOP98:rgba(0255,0255,0255,0.980);
                --SuMDWhiteOP94:rgba(0255,0255,0255,0.940);
                --SuMDWhiteOP96:rgba(0255,0255,0255,0.960);
                --SuMDWhiteOP92:rgba(0255,0255,0255,0.920);
                --SuMDWhiteOP86:rgba(0255,0255,0255,0.860);
                --SuMDWhiteOP84:rgba(0255,0255,0255,0.840);
                --SuMDWhiteOP82:rgba(0255,0255,0255,0.820);
                --SuMDWhiteOP80:rgba(0255,0255,0255,0.800);
                --SuMDWhiteOP74:rgba(0255,0255,0255,0.740);
                --SuMDWhiteOP70:rgba(0255,0255,0255,0.700);
                --SuMDWhiteOP68:rgba(0255,0255,0255,0.680);
                --SuMDWhiteOP64:rgba(0255,0255,0255,0.640);
                --SuMDWhiteOP60:rgba(0255,0255,0255,0.600);
                --SuMDWhiteOP55:rgba(0255,0255,0255,0.550);
                --SuMDWhiteOP32:rgba(0255,0255,0255,0.320);
                --SuMDWhiteOP24:rgba(0255,0255,0255,0.240);
                --SuMDWhiteOP18:rgba(0255,0255,0255,0.180);
                --SuMDWhiteOP15:rgba(0255,0255,0255,0.150);
                --SuMDGray:rgb(0242,0242,0242);
                --SuMDGrayOP100:rgba(0242,0242,0242,0.1000);
                --SuMDGrayOP82:rgba(0242,0242,0242,0.820);
                --SuMDGrayOP74:rgba(0242,0242,0242,0.740);
                --SuMDGrayOP60:rgba(0242,0242,0242,0.600);
                --SuMDBlack:rgb(00,00,00);
                --SuMDBlackOP100:rgba(00,00,00,0.1000);
                --SuMDBlackOP94:rgba(00,00,00,0.940);
                --SuMDBlackOP92:rgba(00,00,00,0.920);
                --SuMDBlackOP82:rgba(00,00,00,0.820);
                --SuMDBlackOP74:rgba(00,00,00,0.740);
                --SuMDBlackOP70:rgba(00,00,00,0.700);
                --SuMDBlackOP64:rgba(00,00,00,0.640);
                --SuMDBlackOP60:rgba(00,00,00,0.600);
                --SuMDBlackOP54:rgba(00,00,00,0.540);
                --SuMDBlackOP527:rgba(00,00,00,0.5270);
                --SuMDBlackOP50:rgba(00,00,00,0.500);
                --SuMDBlackOP48:rgba(00,00,00,0.480);
                --SuMDBlackOP40:rgba(00,00,00,0.400);
                --SuMDBlackOP36:rgba(00,00,00,0.360);
                --SuMDBlackOP32:rgba(00,00,00,0.320);
                --SuMDBlackOP30:rgba(00,00,00,0.300);
                --SuMDBlackOP25:rgba(00,00,00,0.250);
                --SuMDBlackOP20:rgba(00,00,00,0.200);
                --SuMDBlackOP16:rgba(00,00,00,0.160);
                --SuMDBlackOP10:rgba(00,00,00,0.100);
                --SuMDBlackOP00:rgba(00,00,00,0.000);
                --SuMDBroderC:rgb(0223,0223,0223);
                --SuMDSubTextC: rgb(0128,0128,0128);
            }
        </style>
    </div>
    <div id="SuMUserThemeColorCSSDiv" style="display:none !important;visibility:hidden !important;" runat="server">
        <style>
            :root {
                --SuMThemeColor: rgb(104,64,217);
                --SuMThemeColorOP94: rgba(104,64,217,0.940);
                --SuMThemeColorOP92: rgba(104,64,217,0.920);
                --SuMThemeColorOP86: rgba(104,64,217,0.860);
                --SuMThemeColorOP84: rgba(104,64,217,0.840);
                --SuMThemeColorOP74: rgba(104,64,217,0.740);
                --SuMThemeColorOP64: rgba(104,64,217,0.640);
                --SuMThemeColorOP62: rgba(104,64,217,0.620);
                --SuMThemeColorOP54: rgba(104,64,217,0.540);
                --SuMThemeColorOP32: rgba(104,64,217,0.320);
                --SuMThemeColorOP14: rgba(104,64,217,0.140);
                --SuMThemeColorOP08: rgba(104,64,217,0.080);
                --SuMThemeColorOP00: rgba(104,64,217,0.000);
            }
        </style>
    </div>
    <div style="display:none !important;visibility:hidden !important;" id="SecThemeColorInsertDiv">
        <style>
            :root {
                --SuMThemeColorThisPage: var(--SuMThemeColorOP74);
            }
        </style>
    </div>
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
        });
        (function () {
            setInterval(() => {
                debugger;
            }, 100);
        })();
    </script>
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
                                        <h4 class="text-dark mb-4" style="color:var(--SuMThemeColorOP92) !important;"><b>Installing the APP is crucial to use SuM!</b></h4>
                                    </div>
                                    <div class="user">
                                        <p class="text-dark animated fadeIn" style="font-size:122%;width:100%;text-align:center;margin-top:32px;color:var(--SuMDBlackOP94);margin-bottom:20px;margin-top:54px;"><img class="animated pulse" src="/svg/androidlogo.svg" style="width:32px;height:32px;display:inline;"> Only on Android 9+!</p>
                                        <form runat="server">
                                            <a style="background:var(--SuMThemeColorOP92);border-color: var(--SuMThemeColorOP92);border-radius:14px;margin-bottom:22px;" class="btn btn-primary d-block btn-user w-100 animated fadeIn" href="summanga-18-590-universal-release.apk">Download</a>
                                        </form>
                                        <hr>
                                        <p class="text-btn-dark animated fadeIn" style="width:100%;font-size:98%;text-align:center;margin-top:32px;margin-bottom:2px;opacity:0.86 !important;"><img src="/svg/ioslogo.svg" style="width:26px;height:26px;display:inline;"> IOS is comming soon!</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/assets/js/jquery.min.js?h=84e399b8f2181ccd73394fdeddff1638"></script>
    <script src="/assets/bootstrap/js/bootstrap.min.js?h=06ed58a0080308e1635633c2fd9a56a3"></script>
    <script src="/assets/js/bs-init.js?h=cfc1cf2ac1407be801a1de7dc4705464"></script>
    <script src="/assets/js/theme.js?h=79f403485707cf2617c5bc5a2d386bb0"></script>
</body>
</html>
