<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuMSearch.aspx.cs" Inherits="SuM_Manga_V3.SuMSearch" %>

<!DOCTYPE html>
<html lang="en" style="overflow: hidden;">
<head id="head" runat="server">
  <link rel="stylesheet" href="/sh/jquery-ui.css">
  <link rel="stylesheet" href="/sh/style.css">
  <script src="/sh/jquery-3.6.0.js"></script>
  <script src="/sh/jquery-ui.js"></script>
  <script>
      $(function () {
          var availableTags = [
              "ActionScript",
              "AppleScript",
              "Asp",
              "BASIC",
              "C",
              "C++",
              "Clojure",
              "COBOL",
              "ColdFusion",
              "Erlang",
              "Fortran",
              "Groovy",
              "Haskell",
              "Java",
              "JavaScript",
              "Lisp",
              "Perl",
              "PHP",
              "Python",
              "Ruby",
              "Scala",
              "Scheme"
          ];
          $("#tags").autocomplete({
              source: availableTags
          });
      });
  </script>
    <link rel="manifest" href="/manifest.json">
    <script src="/runsw.js"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="user-scalable=no, initial-scale=1, maximum-scale=1, minimum-scale=1, width=device-width, height=device-height, target-densitydpi=device-dpi" />
    <!--
    <meta name="viewport" content="width=device-width, initial-scale=1", "user-scalable=no">--><!-- 
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no"> -->
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>SuM Manga</title>
    <meta name="theme-color" content="rgb(242,242,242)">
    <meta name="description" content="Shun Manga Shop">
    <link rel="apple-touch-icon" type="image/png" sizes="180x180" href="/assets/img/SuM-180.png?h=470ab06da498d6fc442f5928b61025aa">
    <link rel="icon" type="image/png" sizes="16x16" href="/assets/img/any_icon_x16.png?h=57b6f23874c6f0554f87db98b188162f">
    <link rel="icon" type="image/png" sizes="32x32" href="/assets/img/any_icon_x32.png?h=c6e95e86bee5c429ad96d74eb8a03d17">
    <link rel="icon" type="image/png" sizes="180x180" href="/assets/img/any_icon_x180.png?h=871c022ab54519fd72e751e1fb1e8b51">
    <link rel="icon" type="image/png" sizes="192x192" href="/assets/img/any_icon_x192.png?h=ce0f4944b0b251649d44e6c8399f6165">
    <link rel="icon" type="image/png" sizes="512x512" href="/assets/img/any_icon_x512.png?h=951d9a72d5c8436fe4694aec7383dc0a">
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css?h=9c9410dd08c3e2433b1961c2a8a68b39">
    <!-- <link rel="manifest" href="manifest.json?h=f7ca12cbff627266dac4280164023899" /> -->
    <meta name="google-site-verification" content="mp9Vewhm3_3ddQfuO0zmgnIvZpKaygdMO36zmFOgzos" />
    <meta name="google-site-verification" content="stq20Tq0dTHp54Sd5A1Y--jkDZ1foUxliw3UjUZs8Kc" />
    <!-- -->
    <style>
        @font-face {
            font-family: 'VarelaRound';
            src: url('/assets/VarelaRound.ttf');
        }
         * {
             -moz-user-select: none;
             -webkit-user-select: none;
             user-select: none;
         }
         text, h1, h2, h3, h4, h5, h6, p , b {
            pointer-events: none;
            font-family:VarelaRound !important;
            text-decoration:none;
         }
        text, a {
            text-decoration:none !important;
        }
        img {
            pointer-events:none;
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
</head>
<body id="page-top" style="overflow:hidden;height:100vh;width:100vw;">
    <style>
        div {
            box-shadow: 0px 0px #000000 !important;
            overflow-x: hidden !important;
            font-family:VarelaRound !important;
        }
        @media print {

            html, body {
                display: none; /* hide whole page */
            }
        }

        ::-webkit-scrollbar {
            display:none !important;
            /*margin-top:26px !important;
            width: 3px;*/
        }

/* Track */
        ::-webkit-scrollbar-track {
            display:none !important;/*
            margin-top:26px !important;
            background: #ffffff;*/
        }
 
/* Handle */
        ::-webkit-scrollbar-thumb {
            display:none !important;/*
            margin-top:26px !important;
            background: #8a61ff;
            border-radius: 1px;*/
        }

/* Handle on hover */
        ::-webkit-scrollbar-thumb:hover {
            display:none !important;/*
            margin-top:26px !important;
            background: #6840D9;
            border-radius: 1px;*/
        }
        .ForceMaxW {
            max-width:1200px !important;
            /*margin: 0 auto !important;*/
        }
        .PupShadow {/*
            box-shadow: 0px 0px 1px 160vw rgba(104, 64, 217, 0.25) !important;*/
        }
    </style>
    <form id="SuM" method="post" runat="server">
    <div id="wrapper" style="overflow:hidden;">
        <div class="d-flex flex-column" id="content-wrapper" style="overflow:hidden;">
            <div id="content">
                <style>
                    .FNM5455511 {
                        margin-top:0px !important;
                        margin-bottom:0px !important;
                        height:7vh !important;
                        /*background-color:rgb(240, 235, 255) !important;*/
                    }
                </style>
                <div style="width:100vw !important; height:93vh !important;max-height:93vh;margin-top:0px !important;overflow-y:auto;overflow-x:hidden;align-items:center !important;" id="SuMMainBlock" runat="server" class="container-fluid">
                    <div class="ForceMaxW" style="width:100vw !important; height:93vh !important;max-height:93vh !important;margin-left:-24px !important;background-color:#F8F9FD;" id="mc" runat="server">
                    <div class="ui-widget">
  <label for="tags">Tags: </label>
  <input id="tags">
</div>
                    </div><div style="height:36px !important;width:1px !important;"><p>PLaceHolder</p></div>
                </div>
            </div>
        </div>
        <style>
            .STBSUMBAR {
                position:fixed !important;
                bottom:0 !important;
                width:100% !important;
                text-align:center !important;
            }
            .WAHFH021 {
                display:inline !important;
                max-height:64px !important;
                max-height:7vh !important;
            }
        </style>
        <div class="STBSUMBAR bg-white shadow" style="border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;">
            <div class=" navbar-light navbar-expand bg-white shadow  topbar static-top" style="height:36px;width:100% !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;">
                <a href="/Explore.aspx" style="float:left !important;width:fit-content;">
                    <img src="/assets/img/SuM_TBrabd_x92.png" style="width:28px;height:28px;border-bottom-left-radius:6px;margin-left:14px !important;margin-top:4px !important;display:inline;" />
                    <p style="display:inline;color:#6840D9;margin-top:8px !important;">SuM </p><p id="mangacolor" runat="server" style="display:inline;color:#6840D9;margin-top:8px !important;">Manga</p>
                </a>
            <a class="" style="float:right !important;vertical-align:middle !important;width:fit-content;" href="/Search.aspx"><img src="/svg/Search.svg" style="width:28px;height:28px; float:right !important;margin-top:4px !important;margin-right:14px !important;" /></a>
        </div>
        <nav id="nav" runat="server" style="height:7vh;width:100% !important;max-height:64px !important;" class="navbar navbar-light navbar-expand bg-white mb-4 topbar static-top FNM5455511">
                    <div id="NavItems" runat="server" class="container-fluid" style="text-align:center !important;">
                                <div class="" style="display:inline !important;width:7vh !important;height:7vh !important;text-align:center !important;align-items:center;align-content:center;">
                                    <a href="/Explore.aspx" class="dropdown-toggle nav-link" data-bss-disabled-mobile="false" data-bss-hover-animate="pulse" style="text-align:center !important;">
                                        <img id="ExpIMG" runat="server" src="/svg/Explore.svg" style="width:4vh;height:4vh;display:block;position:relative;" />
                                        <b id="ExpText" runat="server" style="font-size:64%;color:#6840D9;height:2vh !important; text-align:center !important;display:block;position:relative;">Explore</b>
                                    </a>
                                </div>
                        <div class="" style="display:inline !important;width:7vh !important;height:7vh !important;text-align:center !important;align-items:center;align-content:center;">
                                    <a href="/Explore.aspx" class="dropdown-toggle nav-link" data-bss-disabled-mobile="false" data-bss-hover-animate="pulse" style="text-align:center !important;">
                                        <img src="/svg/MostSeenNA.svg" style="width:4vh;height:4vh;display:block;" />
                                        <b style="font-size:64%;color:#a3a3a3;height:2vh !important; text-align:center !important;display:block;">Top Hits</b>
                                    </a>
                                </div>
                        
                        <div class="" style="display:inline !important;width:7vh !important;height:7vh !important;text-align:center !important;align-items:center;align-content:center;">
                                    <a href="/Library.aspx" class="dropdown-toggle nav-link" data-bss-disabled-mobile="false" data-bss-hover-animate="pulse" style="text-align:center !important;">
                                        <img id="LibIMG" runat="server" src="/svg/bookmarks.svg" style="width:4vh;height:4vh;display:block;" />
                                        <b id="LibText" runat="server" style="font-size:64%;color:#6840D9;height:2vh !important; text-align:center !important;display:block;">Library</b>
                                    </a>
                                </div>
                        <div class="" style="display:inline !important;width:7vh !important;height:7vh !important;text-align:center !important;align-items:center;align-content:center;">
                                    <a href="/AccountETC/SuMSettings.aspx" class="dropdown-toggle nav-link" data-bss-disabled-mobile="false" data-bss-hover-animate="pulse" style="text-align:center !important;">
                                        <img id="SetIMG" runat="server" src="/svg/settings.svg" style="width:4vh;height:4vh;display:block;" />
                                        <b id="SetText" runat="server" style="font-size:64%;color:#6840D9;height:2vh !important; text-align:center !important;display:block;">Settings</b>
                                    </a>
                                </div>
                    </div>
                </nav>
            </div>
    </div>
    <script src="/assets/bootstrap/js/bootstrap.min.js?h=06ed58a0080308e1635633c2fd9a56a3"></script>
    <script src="/assets/js/bs-init.js?h=cfc1cf2ac1407be801a1de7dc4705464"></script>
    <script src="/assets/js/theme.js?h=79f403485707cf2617c5bc5a2d386bb0"></script>
        </form>
</body>
</html>