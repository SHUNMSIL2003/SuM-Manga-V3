<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateUsers.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.ValidateUsers" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <link rel="manifest" href="/manifest.json">
    <script src="/runsw.js"></script>
    <meta charset="utf-8" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Verifying Account - SuM Manga</title>
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
</head>

<body class="bg-gradient-primary" style="background: rgb(104,64,217);">
    <style>
         * {
             -moz-user-select: none;
             -webkit-user-select: none;
             user-select: none;
         }
         text, h1, h2, h3, h4, h5, h6, p {
            pointer-events: none;
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
                                <div class="flex-grow-1 bg-password-image" style="background: url(&quot;/assets/img/dogs/SuM-ReadingStart.jpg?h=0e0aeefcf9f98107fc6ff0598e2236e1&quot;);min-height:600px"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h4 style="color:rgb(104,64,217)" id="vtitle" runat="server" class="text-dark mb-2">Please Waite!</h4>
                                        <p style="" id="vp" runat="server" class="mb-4">The server is configuring your account and saving it,You will be automaticly redirected to login page...</p>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="ReSendLink2" runat="server" style="background: rgb(104,64,217);border-color: rgb(104,64,217);" OnClick="ResendConfLink" Visible="false" Text="Re-Send Email" />
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