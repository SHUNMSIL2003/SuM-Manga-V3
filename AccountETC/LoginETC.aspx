<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginETC.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.LoginETC" %>

<!DOCTYPE html>
<html>
  
<head runat="server">
    <link rel="manifest" href="/manifest.json">
    <script src="/runsw.js"></script>
    <meta charset="utf-8" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Login - SuM Manga</title>
    <meta name="theme-color" content="rgb(242,242,242)">
    <meta name="description" content="Shun Manga Shop">
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
    <link rel="manifest" href="../manifest.json?h=f7ca12cbff627266dac4280164023899">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="../assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/animate.min.css">
    <meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos" />
    <meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc" />


    >
    <meta name="description" content="Shun Manga">
    <link rel="icon" type="image/png" sizes="16x16" href="/assets/img/any_icon_x16.png?h=57b6f23874c6f0554f87db98b188162f">
    <link rel="icon" type="image/png" sizes="32x32" href="/assets/img/any_icon_x32.png?h=c6e95e86bee5c429ad96d74eb8a03d17">
    <link rel="icon" type="image/png" sizes="180x180" href="/assets/img/any_icon_x180.png?h=871c022ab54519fd72e751e1fb1e8b51">
    <link rel="icon" type="image/png" sizes="192x192" href="/assets/img/any_icon_x192.png?h=ce0f4944b0b251649d44e6c8399f6165">
    <link rel="icon" type="image/png" sizes="512x512" href="/assets/img/any_icon_x512.png?h=951d9a72d5c8436fe4694aec7383dc0a">
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
    <!-- <link rel="manifest" href="manifest.json?h=f7ca12cbff627266dac4280164023899" /> -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="/assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="/assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="/assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="/assets/animate.min.css">
    <meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos" />
    <meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc" />

    <!-- VALID PWA START -->
    <link rel="apple-touch-icon" sizes="180x180" href="/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="/favicon-16x16.png">
    <link rel="manifest" href="/manifest.webmanifest" crossorigin="use-credentials">
    <link rel="mask-icon" href="/safari-pinned-tab.svg" color="#6840d9">
    <link rel="shortcut icon" href="/favicon.ico">
    <meta name="apple-mobile-web-app-title" content="SuM Manga">
    <meta name="application-name" content="SuM Manga">
    <meta name="msapplication-TileColor" content="#f2f2f2">
    <meta name="msapplication-TileImage" content="/mstile-144x144.png">
    <meta name="theme-color" content="#f2f2f2">
    <meta name="msapplication-TileColor" content="#f2f2f2">
    <meta name="msapplication-TileImage" content="/mstile-144x144.png">

    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <link rel="apple-touch-icon" href="/assets/img/any_icon_x180.png">
    <link rel="apple-touch-icon" sizes="152x152" href="/ios/152.png">
    <link rel="apple-touch-icon" sizes="167x167" href="/ios/167.png">
    <link rel="apple-touch-icon" sizes="100x100" href="/ios/100.png">
    <link rel="apple-touch-icon" sizes="1024x1024" href="/ios/1024.png">
    <link rel="apple-touch-icon" sizes="114x114" href="/ios/114.png">
    <link rel="apple-touch-icon" sizes="120x120" href="/ios/120.png">
    <link rel="apple-touch-icon" sizes="128x128" href="/ios/128.png">
    <link rel="apple-touch-icon" sizes="144x144" href="/ios/144.png">
    <link rel="apple-touch-icon" sizes="16x16" href="/ios/16.png">
    <link rel="apple-touch-icon" sizes="192x192" href="/ios/192.png">
    <link rel="apple-touch-icon" sizes="20x20" href="/ios/20.png">
    <link rel="apple-touch-icon" sizes="256x256" href="/ios/256.png">
    <link rel="apple-touch-icon" sizes="29x29" href="/ios/29.png">
    <link rel="apple-touch-icon" sizes="32x32" href="/ios/32.png">
    <link rel="apple-touch-icon" sizes="40x40" href="/ios/40.png">
    <link rel="apple-touch-icon" sizes="50x50" href="/ios/50.png">
    <link rel="apple-touch-icon" sizes="512x512" href="/ios/512.png">
    <link rel="apple-touch-icon" sizes="57x57" href="/ios/57.png">
    <link rel="apple-touch-icon" sizes="58x58" href="/ios/58.png">
    <link rel="apple-touch-icon" sizes="60x60" href="/ios/60.png">
    <link rel="apple-touch-icon" sizes="64x64" href="/ios/64.png">
    <link rel="apple-touch-icon" sizes="72x72" href="/ios/72.png">
    <link rel="apple-touch-icon" sizes="76x76" href="/ios/76.png">
    <link rel="apple-touch-icon" sizes="80x80" href="/ios/80.png">
    <link rel="apple-touch-icon" sizes="87x87" href="/ios/87.png">
    <link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphone6_splash.png" media="(device-width: 375px) and (device-height: 667px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphoneplus_splash.png" media="(device-width: 621px) and (device-height: 1104px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphonex_splash.png" media="(device-width: 375px) and (device-height: 812px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphonexr_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/iphonexsmax_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/ipad_splash.png" media="(device-width: 768px) and (device-height: 1024px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/ipadpro1_splash.png" media="(device-width: 834px) and (device-height: 1112px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/ipadpro3_splash.png" media="(device-width: 834px) and (device-height: 1194px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <link href="/splashscreens/ipadpro2_splash.png" media="(device-width: 1024px) and (device-height: 1366px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image" />
    <!--  VALID PWA END  -->


</head>

<body class="bg-gradient-primary" style="background: rgb(242,242,242);">
    <style>
         * {
             -moz-user-select: none;
             -webkit-user-select: none;
             user-select: none;
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
    <form id="SuM" method="post" runat="server">
    <div class="container bounce animated">
        <div class="row justify-content-center">
            <div class="col-md-9 col-lg-12 col-xl-10">
                <div class="card shadow-lg o-hidden border-0 my-5">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-flex">
                                <div class="flex-grow-1 bg-login-image" style="background: url(&quot;/assets/img/dogs/SuM-Reader.jpg?h=0086b7bb234345281e92a417000e3a03&quot;);"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h4 class="text-dark mb-4">Welcome Back to SuM!</h4>
                                    </div>
                                    <div class="user">
                                        <div class="mb-3"><input class="form-control form-control-user" type="text" style="" id="UserNameL" placeholder="User Name" name="UserName" runat="server"></div>
                                        <div class="mb-3"><input class="form-control form-control-user" type="password" style="" id="PasswordL" placeholder="Password" name="password" runat="server"></div>
                                        <div style="text-align:center;width:100%;height:fit-content;"><h6 style="color:red;" id="LoginStatus" runat="server"></h6><asp:Button CssClass="btn btn-primary btn-sm" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);float:right;" OnClick="ResendConfLink" Visible="false" ID="ResendConf" Text="Re-Send Email" /></div>
                                        <div class="mb-3">
                                            <div class="custom-control custom-checkbox small">
                                                <div class="form-check"><input class="form-check-input custom-control-input" type="checkbox" checked="checked" id="formCheck-1"><label id="rem" runat="server" class="form-check-label custom-control-label" for="formCheck-1">Remember Me</label></div>
                                            </div> 
                                        </div><!-- <button class="btn btn-primary d-block btn-user w-100" type="submit" style="background: rgb(104,64,217);" onclick="LoginToSuM" runat="server">Login</button> -->
                                        <asp:Button CssClass="btn btn-primary d-block btn-user w-100" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="LoginToSuM" runat="server" Text="Login" />
                                        <hr><a class="btn btn-primary d-block btn-google btn-user w-100 mb-2" role="button"><i class="fab fa-google"></i>&nbsp; Login with Google</a><a class="btn btn-primary d-block btn-facebook btn-user w-100" role="button"><i class="fab fa-facebook-f"></i>&nbsp; Login with Facebook</a>
                                        <hr>
                                    </div>
                                    <div class="text-center"><a class="small" href="../AccountETC/PassRecovryETC.aspx" style="color: rgb(104,64,217);">Forgot Password?</a></div>
                                    <div class="text-center"><a class="small" href="../AccountETC/RegisterETC.aspx" style="color: rgb(104,64,217);">Create an Account!</a></div>
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
        </form>
</body>

</html>
