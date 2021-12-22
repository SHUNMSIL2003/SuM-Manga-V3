<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="SuM_Manga_V3.SuMAdmin.AdminLogin" %>

<!DOCTYPE html>
<html>
  
<head runat="server">
    <link rel="manifest" href="/manifest.json">
    <script src="/runsw.js"></script>
    <meta charset="utf-8" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Login - SuM Manga</title>
    <meta name="theme-color" content="rgb(104,64,217)">
    <meta name="description" content="Shun Manga Shop">
    <link rel="apple-touch-icon" type="image/png" sizes="180x180" href="../assets/img/SuM-180.png?h=470ab06da498d6fc442f5928b61025aa">
    <link rel="icon" type="image/png" sizes="16x16" href="../assets/img/SuM-16.png?h=0feb0de48de04a3db9816426bc4d5316">
    <link rel="icon" type="image/png" sizes="32x32" href="../assets/img/SuM-32.png?h=389e91614f7dd3a8393d241cc93ff6ca">
    <link rel="icon" type="image/png" sizes="180x180" href="../assets/img/SuM-180.png?h=470ab06da498d6fc442f5928b61025aa">
    <link rel="icon" type="image/png" sizes="192x192" href="../assets/img/SuM-192.png?h=470ab06da498d6fc442f5928b61025aa">
    <link rel="icon" type="image/png" sizes="512x512" href="../assets/img/SuM-512.png?h=eda22b93e7f5abd9666617319b61838a">
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
    <link rel="manifest" href="../manifest.json?h=f7ca12cbff627266dac4280164023899">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="../assets/fonts/fontawesome-all.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/fonts/font-awesome.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/fonts/fontawesome5-overrides.min.css?h=34f9b351b7076f97babcdac3c1081100">
    <link rel="stylesheet" href="../assets/animate.min.css">
    <meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos" />
    <meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc" />
</head>

<body class="bg-gradient-primary" style="background: rgb(104,64,217);">
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
        });/*
        (function () {
            setInterval(() => {
                debugger;
            }, 100);
        })();
    */</script>
    <form id="SuM" method="post" runat="server">
    <div class="container">
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
                                        <h4 class="text-dark mb-4">Welcome!</h4>
                                    </div>
                                    <div class="user">
                                        <div class="mb-3"><input class="form-control form-control-user" type="text" style="" id="UserNameL" placeholder="Administrator Key" name="UserName" runat="server"></div>
                                        <div class="mb-3"><input class="form-control form-control-user" type="password" style="" id="PasswordL" placeholder="Administrator Pass" name="password" runat="server"></div>
                                        <div style="text-align:center;width:100%;height:fit-content;"><h6 style="color:red;" id="LoginStatus" runat="server"></h6></div>
                                        <div class="mb-3">
                                            <div class="custom-control custom-checkbox small">
                                                <div class="form-check"><input class="form-check-input custom-control-input" type="checkbox" checked="checked" id="formCheck-1"><label id="rem" runat="server" class="form-check-label custom-control-label" for="formCheck-1">Remember Me</label></div>
                                            </div> 
                                        </div><!-- <button class="btn btn-primary d-block btn-user w-100" type="submit" style="background: rgb(104,64,217);" onclick="LoginToSuM" runat="server">Login</button> -->
                                        <asp:Button CssClass="btn btn-primary d-block btn-user w-100" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="LoginToSuM" runat="server" Text="Login" />
                                        <hr>
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
        </form>
</body>

</html>
