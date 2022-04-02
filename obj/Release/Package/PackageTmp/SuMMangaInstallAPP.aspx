<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuMMangaInstallAPP.aspx.cs" Inherits="SuM_Manga_V3.SuMMangaInstallAPP" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
        <title>Install is required - SuM Manga</title>
        <meta name="theme-color" content="var(--SuMDGray)"><meta name="description" content="Shun Manga Shop">
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
    <link rel="apple-touch-icon" sizes="180x180" href="/apple-touch-icon.png"><link rel="icon" type="image/png" sizes="32x32" href="/favicon-32x32.png"><link rel="icon" type="image/png" sizes="16x16" href="/favicon-16x16.png"><link rel="manifest" href="/manifest.webmanifest" crossorigin="use-credentials"><link rel="mask-icon" href="/safari-pinned-tab.svg" color="#6840d9"><link rel="shortcut icon" href="/favicon.ico"><meta name="apple-mobile-web-app-title" content="SuM Manga"><meta name="application-name" content="SuM Manga"><meta name="msapplication-TileColor" content="var(--SuMDGray)"><meta name="msapplication-TileImage" content="/mstile-144x144.png"><meta name="theme-color" content="var(--SuMDGray)"><meta name="msapplication-TileColor" content="var(--SuMDGray)"><meta name="msapplication-TileImage" content="/mstile-144x144.png"><meta name="apple-mobile-web-app-capable" content="yes"><meta name="apple-mobile-web-app-status-bar-style" content="default"><link rel="apple-touch-icon" href="/assets/img/any_icon_x180.png"><link rel="apple-touch-icon" sizes="152x152" href="/ios/152.png"><link rel="apple-touch-icon" sizes="167x167" href="/ios/167.png"><link rel="apple-touch-icon" sizes="100x100" href="/ios/100.png"><link rel="apple-touch-icon" sizes="1024x1024" href="/ios/1024.png"><link rel="apple-touch-icon" sizes="114x114" href="/ios/114.png"><link rel="apple-touch-icon" sizes="120x120" href="/ios/120.png"><link rel="apple-touch-icon" sizes="128x128" href="/ios/128.png"><link rel="apple-touch-icon" sizes="144x144" href="/ios/144.png"><link rel="apple-touch-icon" sizes="16x16" href="/ios/16.png"><link rel="apple-touch-icon" sizes="192x192" href="/ios/192.png"><link rel="apple-touch-icon" sizes="20x20" href="/ios/20.png"><link rel="apple-touch-icon" sizes="256x256" href="/ios/256.png"><link rel="apple-touch-icon" sizes="29x29" href="/ios/29.png"><link rel="apple-touch-icon" sizes="32x32" href="/ios/32.png"><link rel="apple-touch-icon" sizes="40x40" href="/ios/40.png"><link rel="apple-touch-icon" sizes="50x50" href="/ios/50.png"><link rel="apple-touch-icon" sizes="512x512" href="/ios/512.png"><link rel="apple-touch-icon" sizes="57x57" href="/ios/57.png"><link rel="apple-touch-icon" sizes="58x58" href="/ios/58.png"><link rel="apple-touch-icon" sizes="60x60" href="/ios/60.png"><link rel="apple-touch-icon" sizes="64x64" href="/ios/64.png"><link rel="apple-touch-icon" sizes="72x72" href="/ios/72.png"><link rel="apple-touch-icon" sizes="76x76" href="/ios/76.png"><link rel="apple-touch-icon" sizes="80x80" href="/ios/80.png"><link rel="apple-touch-icon" sizes="87x87" href="/ios/87.png"><link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphone5_splash.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphone6_splash.png" media="(device-width: 375px) and (device-height: 667px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphoneplus_splash.png" media="(device-width: 621px) and (device-height: 1104px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonex_splash.png" media="(device-width: 375px) and (device-height: 812px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonexr_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/iphonexsmax_splash.png" media="(device-width: 414px) and (device-height: 896px) and (-webkit-device-pixel-ratio: 3)" rel="apple-touch-startup-image"><link href="/splashscreens/ipad_splash.png" media="(device-width: 768px) and (device-height: 1024px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro1_splash.png" media="(device-width: 834px) and (device-height: 1112px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro3_splash.png" media="(device-width: 834px) and (device-height: 1194px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image"><link href="/splashscreens/ipadpro2_splash.png" media="(device-width: 1024px) and (device-height: 1366px) and (-webkit-device-pixel-ratio: 2)" rel="apple-touch-startup-image">
    <!--  VALID PWA END  -->

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
    <div style="visibility:hidden !important;display:none !important;" id="SuMDarkModeControleThemeDiv">
        <style>
            :root {
                --SuMBack: rgb(0,0,0);
                --SuMCardBack: rgb(56,56,56);
                --SuMThemeColorSec: rgb(144,144,144);
                --SuMDWhite: rgb(56,56,56);
                --SuMDWhiteOP100: rgba(56,56,56,0.1000);
                --SuMDWhiteOP98: rgba(56,56,56,0.980);
                --SuMDWhiteOP94: rgba(56,56,56,0.940);
                --SuMDWhiteOP96: rgba(56,56,56,0.960);
                --SuMDWhiteOP92: rgba(56,56,56,0.920);
                --SuMDWhiteOP86: rgba(56,56,56,0.860);
                --SuMDWhiteOP84: rgba(56,56,56,0.840);
                --SuMDWhiteOP82: rgba(56,56,56,0.820);
                --SuMDWhiteOP80: rgba(56,56,56,0.800);
                --SuMDWhiteOP74: rgba(56,56,56,0.740);
                --SuMDWhiteOP70: rgba(56,56,56,0.700);
                --SuMDWhiteOP68: rgba(56,56,56,0.680);
                --SuMDWhiteOP64: rgba(56,56,56,0.640);
                --SuMDWhiteOP60: rgba(56,56,56,0.600);
                --SuMDWhiteOP55: rgba(56,56,56,0.550);
                --SuMDWhiteOP32: rgba(56,56,56,0.320);
                --SuMDWhiteOP24: rgba(56,56,56,0.240);
                --SuMDWhiteOP18: rgba(56,56,56,0.180);
                --SuMDWhiteOP15: rgba(56,56,56,0.150);
                --SuMDGray: rgb(0,0,0);
                --SuMDGrayOP100: rgba(0,0,0,0.1000);
                --SuMDGrayOP82: rgba(0,0,0,0.820);
                --SuMDGrayOP74: rgba(0,0,0,0.740);
                --SuMDGrayOP60: rgba(0,0,0,0.600);
                --SuMDBlack: rgb(255,255,255);
                --SuMDBlackOP100: rgba(255,255,255,0.1000);
                --SuMDBlackOP94: rgba(255,255,255,0.940);
                --SuMDBlackOP92: rgba(255,255,255,0.920);
                --SuMDBlackOP82: rgba(255,255,255,0.820);
                --SuMDBlackOP74: rgba(255,255,255,0.740);
                --SuMDBlackOP70: rgba(255,255,255,0.700);
                --SuMDBlackOP64: rgba(255,255,255,0.640);
                --SuMDBlackOP60: rgba(255,255,255,0.600);
                --SuMDBlackOP54: rgba(255,255,255,0.540);
                --SuMDBlackOP527: rgba(255,255,255,0.5270);
                --SuMDBlackOP50: rgba(255,255,255,0.500);
                --SuMDBlackOP48: rgba(255,255,255,0.480);
                --SuMDBlackOP40: rgba(255,255,255,0.400);
                --SuMDBlackOP36: rgba(255,255,255,0.360);
                --SuMDBlackOP32: rgba(255,255,255,0.320);
                --SuMDBlackOP30: rgba(255,255,255,0.300);
                --SuMDBlackOP25: rgba(255,255,255,0.250);
                --SuMDBlackOP20: rgba(255,255,255,0.200);
                --SuMDBlackOP16: rgba(255,255,255,0.160);
                --SuMDBlackOP10: rgba(255,255,255,0.100);
                --SuMDBlackOP00: rgba(255,255,255,0.000);
                --SuMDBroderC: rgb(60,60,60);
                --SuMDSubTextC: rgba(255,255,255,0.74);
            }
        </style>
    </div>
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
    <script>
        function getCookie(cname) {
            let name = cname + "=";
            let decodedCookie = document.cookie;
            let ca = decodedCookie.split(';');
            for (let i = 0; i < ca.length; i++) {
                let c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        };
        function MixTwoRGBsWStaticOpacityAndR(SuMColor1, SuMColor2, R1, R2) {
            SuMColor1 = SuMColor1.replace('rgb', '').replace('a', '').replace('(', '').replace(')', '').replace(' ', '');
            SuMColor2 = SuMColor2.replace('rgb', '').replace('a', '').replace('(', '').replace(')', '').replace(' ', '');
            var c1 = SuMColor1.split(',');
            var c2 = SuMColor2.split(',');
            var SuMRSColor = (((c1[0] * R1) + (c2[0] * R2)) / (R1 + R2)) + ',' + (((c1[1] * R1) + (c2[1] * R2)) / (R1 + R2)) + ',' + (((c1[2] * R1) + (c2[2] * R2)) / (R1 + R2));
            return SuMRSColor;
        };
        var SuMLightModeBackUp;
        var SuMDarkModeBackUp;
        var SuMThemeColorControleDiv = document.getElementById('SuMUserThemeColorCSSDiv');//-sumcolor
        var SuMDarkModeControleDiv = document.getElementById('SuMDarkModeControleThemeDiv');//-sumdark
        var SuMLightModeControleDiv = document.getElementById('SuMLightModeControleThemeDiv');//-sumlight
        var SuMThemeColorRoot = getCookie('SuMUserThemeColor');
        if (SuMThemeColorRoot != '' && SuMThemeColorRoot != null && SuMThemeColorRoot != ' ') {
            SuMThemeColorRoot = SuMThemeColorRoot.replace('RGBRoot=', '').replace(' ', '');
        }
        else {
            SuMThemeColorRoot = '104,64,217';
        }
        var SuMThemeStateBit = getCookie('SuMUserThemeState').replace(' ', '');
        function ApplySuMThemeStyleForm(SuMThemeRootF0CF0) {
            var ThemeFormRSF0CF0 = "<style> :root { --SuMThemeColor: rgb(" + SuMThemeRootF0CF0 + "); --SuMThemeColorOP94: rgba(" + SuMThemeRootF0CF0 + ",0.940); --SuMThemeColorOP92: rgba(" + SuMThemeRootF0CF0 + ",0.920); --SuMThemeColorOP86: rgba(" + SuMThemeRootF0CF0 + ",0.860); --SuMThemeColorOP84: rgba(" + SuMThemeRootF0CF0 + ",0.840); --SuMThemeColorOP74: rgba(" + SuMThemeRootF0CF0 + ",0.740); --SuMThemeColorOP64: rgba(" + SuMThemeRootF0CF0 + ",0.640); --SuMThemeColorOP62: rgba(" + SuMThemeRootF0CF0 + ",0.620); --SuMThemeColorOP54: rgba(" + SuMThemeRootF0CF0 + ",0.540); --SuMThemeColorOP32: rgba(" + SuMThemeRootF0CF0 + ",0.320); --SuMThemeColorOP14: rgba(" + SuMThemeRootF0CF0 + ",0.140); --SuMThemeColorOP08: rgba(" + SuMThemeRootF0CF0 + ",0.080); --SuMThemeColorOP00: rgba(" + SuMThemeRootF0CF0 + ",0.000); } </style>";
            return ThemeFormRSF0CF0;
        };
        function SuMCurrPageThemeColorGen(SuMStateBit) {
            var DetectedThemeColorF0CC = null;
            location.search.substring(1).split("&").forEach(function (val) {

                var currValF0CS = val.split("=");
                if (currValF0CS[0] == "TC") {

                    DetectedThemeColorF0CC = decodeURI(currValF0CS[1]).replace(' ', '');

                }

            });
            if (DetectedThemeColorF0CC != null) {
                if (DetectedThemeColorF0CC.includes('255,255,255') == true || DetectedThemeColorF0CC.includes('rgb') == false) {
                    DetectedThemeColorF0CC = '104,64,217';
                }
                else {
                    DetectedThemeColorF0CC = DetectedThemeColorF0CC.replace('(', '').replace(')', '').replace('rgb', '').replace('a', '');
                }
            }
            else {
                DetectedThemeColorF0CC = '104,64,217';
            }
            var BestColorRoot;
            if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == '' || SuMStateBit == ' ' || SuMStateBit == null) {
                BestColorRoot = MixTwoRGBsWStaticOpacityAndR(DetectedThemeColorF0CC, '0,0,0', 6, 1);
            }
            if (SuMStateBit == 1 || SuMStateBit == '1') {
                BestColorRoot = MixTwoRGBsWStaticOpacityAndR(DetectedThemeColorF0CC, '255,255,255', 2, 1);
            }
            document.getElementById('SecThemeColorInsertDiv').innerHTML = '<style> :root { --SuMThemeColorThisPage:rgb(#TC#); --SuMThemeColorThisPageOP01: rgba(#TC#,0.01); --SuMThemeColorThisPageOP02: rgba(#TC#,0.02); --SuMThemeColorThisPageOP03: rgba(#TC#,0.03); --SuMThemeColorThisPageOP04: rgba(#TC#,0.04); --SuMThemeColorThisPageOP05: rgba(#TC#,0.05); --SuMThemeColorThisPageOP06: rgba(#TC#,0.06); --SuMThemeColorThisPageOP07: rgba(#TC#,0.07); --SuMThemeColorThisPageOP08: rgba(#TC#,0.08); --SuMThemeColorThisPageOP09: rgba(#TC#,0.09); --SuMThemeColorThisPageOP10: rgba(#TC#,0.10); --SuMThemeColorThisPageOP11: rgba(#TC#,0.11); --SuMThemeColorThisPageOP12: rgba(#TC#,0.12); --SuMThemeColorThisPageOP13: rgba(#TC#,0.13); --SuMThemeColorThisPageOP14: rgba(#TC#,0.14); --SuMThemeColorThisPageOP15: rgba(#TC#,0.15); --SuMThemeColorThisPageOP16: rgba(#TC#,0.16); --SuMThemeColorThisPageOP17: rgba(#TC#,0.17); --SuMThemeColorThisPageOP18: rgba(#TC#,0.18); --SuMThemeColorThisPageOP19: rgba(#TC#,0.19); --SuMThemeColorThisPageOP20: rgba(#TC#,0.20); --SuMThemeColorThisPageOP21: rgba(#TC#,0.21); --SuMThemeColorThisPageOP22: rgba(#TC#,0.22); --SuMThemeColorThisPageOP23: rgba(#TC#,0.23); --SuMThemeColorThisPageOP24: rgba(#TC#,0.24); --SuMThemeColorThisPageOP25: rgba(#TC#,0.25); --SuMThemeColorThisPageOP26: rgba(#TC#,0.26); --SuMThemeColorThisPageOP27: rgba(#TC#,0.27); --SuMThemeColorThisPageOP28: rgba(#TC#,0.28); --SuMThemeColorThisPageOP29: rgba(#TC#,0.29); --SuMThemeColorThisPageOP30: rgba(#TC#,0.30); --SuMThemeColorThisPageOP31: rgba(#TC#,0.31); --SuMThemeColorThisPageOP32: rgba(#TC#,0.32); --SuMThemeColorThisPageOP33: rgba(#TC#,0.33); --SuMThemeColorThisPageOP34: rgba(#TC#,0.34); --SuMThemeColorThisPageOP35: rgba(#TC#,0.35); --SuMThemeColorThisPageOP36: rgba(#TC#,0.36); --SuMThemeColorThisPageOP37: rgba(#TC#,0.37); --SuMThemeColorThisPageOP38: rgba(#TC#,0.38); --SuMThemeColorThisPageOP39: rgba(#TC#,0.39); --SuMThemeColorThisPageOP40: rgba(#TC#,0.40); --SuMThemeColorThisPageOP41: rgba(#TC#,0.41); --SuMThemeColorThisPageOP42: rgba(#TC#,0.42); --SuMThemeColorThisPageOP43: rgba(#TC#,0.43); --SuMThemeColorThisPageOP44: rgba(#TC#,0.44); --SuMThemeColorThisPageOP45: rgba(#TC#,0.45); --SuMThemeColorThisPageOP46: rgba(#TC#,0.46); --SuMThemeColorThisPageOP47: rgba(#TC#,0.47); --SuMThemeColorThisPageOP48: rgba(#TC#,0.48); --SuMThemeColorThisPageOP49: rgba(#TC#,0.49); --SuMThemeColorThisPageOP50: rgba(#TC#,0.50); --SuMThemeColorThisPageOP51: rgba(#TC#,0.51); --SuMThemeColorThisPageOP52: rgba(#TC#,0.52); --SuMThemeColorThisPageOP53: rgba(#TC#,0.53); --SuMThemeColorThisPageOP54: rgba(#TC#,0.54); --SuMThemeColorThisPageOP55: rgba(#TC#,0.55); --SuMThemeColorThisPageOP56: rgba(#TC#,0.56); --SuMThemeColorThisPageOP57: rgba(#TC#,0.57); --SuMThemeColorThisPageOP58: rgba(#TC#,0.58); --SuMThemeColorThisPageOP59: rgba(#TC#,0.59); --SuMThemeColorThisPageOP60: rgba(#TC#,0.60); --SuMThemeColorThisPageOP61: rgba(#TC#,0.61); --SuMThemeColorThisPageOP62: rgba(#TC#,0.62); --SuMThemeColorThisPageOP63: rgba(#TC#,0.63); --SuMThemeColorThisPageOP64: rgba(#TC#,0.64); --SuMThemeColorThisPageOP65: rgba(#TC#,0.65); --SuMThemeColorThisPageOP66: rgba(#TC#,0.66); --SuMThemeColorThisPageOP67: rgba(#TC#,0.67); --SuMThemeColorThisPageOP68: rgba(#TC#,0.68); --SuMThemeColorThisPageOP69: rgba(#TC#,0.69); --SuMThemeColorThisPageOP70: rgba(#TC#,0.70); --SuMThemeColorThisPageOP71: rgba(#TC#,0.71); --SuMThemeColorThisPageOP72: rgba(#TC#,0.72); --SuMThemeColorThisPageOP73: rgba(#TC#,0.73); --SuMThemeColorThisPageOP74: rgba(#TC#,0.74); --SuMThemeColorThisPageOP75: rgba(#TC#,0.75); --SuMThemeColorThisPageOP76: rgba(#TC#,0.76); --SuMThemeColorThisPageOP77: rgba(#TC#,0.77); --SuMThemeColorThisPageOP78: rgba(#TC#,0.78); --SuMThemeColorThisPageOP79: rgba(#TC#,0.79); --SuMThemeColorThisPageOP80: rgba(#TC#,0.80); --SuMThemeColorThisPageOP81: rgba(#TC#,0.81); --SuMThemeColorThisPageOP82: rgba(#TC#,0.82); --SuMThemeColorThisPageOP83: rgba(#TC#,0.83); --SuMThemeColorThisPageOP84: rgba(#TC#,0.84); --SuMThemeColorThisPageOP85: rgba(#TC#,0.85); --SuMThemeColorThisPageOP86: rgba(#TC#,0.86); --SuMThemeColorThisPageOP87: rgba(#TC#,0.87); --SuMThemeColorThisPageOP88: rgba(#TC#,0.88); --SuMThemeColorThisPageOP89: rgba(#TC#,0.89); --SuMThemeColorThisPageOP90: rgba(#TC#,0.90); --SuMThemeColorThisPageOP91: rgba(#TC#,0.91); --SuMThemeColorThisPageOP92: rgba(#TC#,0.92); --SuMThemeColorThisPageOP93: rgba(#TC#,0.93); --SuMThemeColorThisPageOP94: rgba(#TC#,0.94); --SuMThemeColorThisPageOP95: rgba(#TC#,0.95); --SuMThemeColorThisPageOP96: rgba(#TC#,0.96); --SuMThemeColorThisPageOP97: rgba(#TC#,0.97); --SuMThemeColorThisPageOP98: rgba(#TC#,0.98); --SuMThemeColorThisPageOP99: rgba(#TC#,0.99); }</style>'.replace('#TC#', BestColorRoot);
        };
        function SuMSetThemeState(SuMStateBit) {
            //Saves all Theme States avalibe 
            if (SuMLightModeControleDiv.innerHTML != '0') {
                SuMLightModeBackUp = SuMLightModeControleDiv.innerHTML;
            }
            if (SuMDarkModeControleDiv.innerHTML != '0') {
                SuMDarkModeBackUp = SuMDarkModeControleDiv.innerHTML;
            }
            //Deafult -lightmode
            if (SuMStateBit == 0 || SuMStateBit == '0' || SuMStateBit == null || SuMStateBit == ' ' || SuMStateBit == '') {
                SuMDarkModeControleDiv.innerHTML = '0';
                SuMLightModeControleDiv.innerHTML = SuMLightModeBackUp;
                SuMThemeColorControleDiv.innerHTML = ApplySuMThemeStyleForm(MixTwoRGBsWStaticOpacityAndR(SuMThemeColorRoot, '0,0,0', 2, 1));
            }
            //UserSelected --darkmode
            if (SuMStateBit == 1 || SuMStateBit == '1') {
                SuMLightModeControleDiv.innerHTML = '0';
                SuMDarkModeControleDiv.innerHTML = SuMDarkModeBackUp;
                SuMThemeColorControleDiv.innerHTML = ApplySuMThemeStyleForm(MixTwoRGBsWStaticOpacityAndR(SuMThemeColorRoot, '255,255,255', 2, 1));
            }
            SuMCurrPageThemeColorGen(SuMStateBit);
        };
        SuMSetThemeState(SuMThemeStateBit);

    </script>
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
                                        <h4 class="text-dark mb-4" style="color:var(--SuMThemeColorOP92) !important;"><b>Installing our App is required to use SuM!</b></h4>
                                    </div>
                                    <div class="user">
                                        <p class="text-dark animated fadeIn" style="font-size:122%;width:100%;text-align:center;margin-top:32px;color:var(--SuMDBlackOP94);margin-bottom:20px;margin-top:54px;"><img class="animated pulse" src="/svg/androidlogo.svg" style="width:32px;height:32px;display:inline;"> Only on Android!</p>
                                        <form runat="server">
                                            <a style="background:var(--SuMThemeColorOP92);border-color: var(--SuMThemeColorOP92);border-radius:14px;margin-bottom:22px;" class="btn btn-primary d-block btn-user w-100 animated fadeIn" href="SuM-Manga-401.apk">Download</a>
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
        <div id="Offline" class="STBSUMBAR bg-white shadow animated slideInUp" style="display:none;overflow:clip;border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;overflow:hidden !important;background-color:var(--SuMThemeColor) !important;bottom:0 !important;">
            <div class=" navbar-light navbar-expand bg-white shadow  topbar static-top" style="height:fit-content;width:100vw !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;border-top:solid 0.4px var(--SuMThemeColor) !important;bottom:0 !important;overflow:clip;background-color:var(--SuMThemeColor) !important;">
                 <div style="text-align:center;" class="text-center">
                    <p class="lead animated fadeIn" style="margin-top:6px;font-size:140%;color:var(--SuMDWhite) !important;">You are offline!</p>
                    <p class="lead animated fadeIn" style="margin-top:-18px;font-size:80%;color:var(--SuMDWhiteOP64) !important;"><b>Login is not avalibe ...</b></p>
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
