<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="BTNTesting.aspx.cs" Inherits="SuM_Manga_V3.BTNTesting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <a onclick="let timer; this.onpointerdown = function () { timer = setTimeout(alert, 1000, 'you held me down for 1 second'); } this.onpointerup = function () { clearTimeout(timer); }" style="background-color:#f2f2f2;width:fit-content;height:fit-content;">Click Me</a>
    <script>
        //const b = document.getElementById("hold-me");
        let timer;
        this.onpointerdown = function () {
            timer = setTimeout(alert, 1000, "you held me down for 1 second");
        }
        this.onpointerup = function () {
            clearTimeout(timer);
        }
    </script> -->
    <div id="SuMUltraInfoCard" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:100%;height:fit-content;background-color:#ffffff;margin:0 auto;border-top-right-radius:22px;border-top-left-radius:22px;position:fixed;z-index:995;bottom:108px;display:none;" class="animated slideInUp shadow-sm">
        <div id="SuMUltraBGColor" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:100%;height:fit-content;background-color:rgba(135,56,65,0.74);margin:0 auto;padding:20px;padding-top:0px;">
            <div style="width:100%;height:fit-content;padding-top:16px;padding-right:0px;">
                <a style="width:fit-content;height:fit-content;padding:3px;background-color:rgba(255,255,255,0.18);border-radius:50%;margin-left:calc(100% - 30px);display:block;">
                    <svg xmlns="http://www.w3.org/2000/svg" height="22px" viewBox="0 0 24 24" width="24px" fill="rgba(255,255,255,0.86)"><path d="M0 0h24v24H0V0z" fill="none"></path><path d="M18.3 5.71c-.39-.39-1.02-.39-1.41 0L12 10.59 7.11 5.7c-.39-.39-1.02-.39-1.41 0-.39.39-.39 1.02 0 1.41L10.59 12 5.7 16.89c-.39.39-.39 1.02 0 1.41.39.39 1.02.39 1.41 0L12 13.41l4.89 4.89c.39.39 1.02.39 1.41 0 .39-.39.39-1.02 0-1.41L13.41 12l4.89-4.89c.38-.38.38-1.02 0-1.4z"></path></svg>
                </a>
            </div>
            <div class="animated fadeIn;" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:100%;height:fit-content;">
                <div style="width:132px;height:fit-content;display:inline-block;display:table-cell;padding-right:12px;">
                    <img id="SuMUltraCover" style="width:100%;height:auto;margin:0 auto;border-radius:16px;" src="/storeitems/Hanako-Kun/Hanako-Kun.jpg" />
                </div>
                <div style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:calc(70% - 20px);height:fit-content;display:inline-block;display:table-cell;vertical-align:middle;">
                    <h2 id="SuMUltarTitle" style="color:#ffffff;height:fit-content;width:100%;margin-bottom:-2px;">#T</h2>
                    <div style="width:100%;height:fit-content;">
                        <p id="SuMUltarProdYear" style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.64);display:inline;margin-right:6px;font-size:86%;">#Y</p>
                        <p id="SuMUltraAgeRating" style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.64);display:inline;font-size:86%;">#A</p>
                        <p id="SuMUltarChptersNum" style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.64);display:inline;margin-left:6px;font-size:86%;">#CN</p>
                    </div>
                    <p id="SuMUltraMDisc" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:100%;height:fit-content;color:rgba(255,255,255,0.86);padding:2px;font-size:74%;">#DSC</p>
                </div>
            </div>
            <hr class="animated fadeIn" style="margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:86%;opacity:0.12;margin:0px;margin-block:0px;margin-top:2px !important;margin-bottom:12px !important;">
            <div class="animated fadeIn" style="width:100%;height:fit-content;text-align:center !important;display:flex;align-items:center;justify-content:center;padding-bottom:8px;">
                <a style="display:inline-block !important;width:fit-content;height:fit-content;flex:1 1 auto;">
                    <div id="SuMUltraStartReadingFuncClick" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:fit-content;height:fit-content;padding:9px;border-radius:50%;background-color:#ffffff;margin:0 auto;">
                        <svg id="SuMUltraCurrReadingSVG" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="28px" viewBox="0 0 24 24" width="28px" fill="rgba(135,56,65,0.74)"><g><rect fill="none" height="24" width="24"></rect><rect fill="none" height="24" width="24"></rect></g><g><path d="M17.5,4.5c-1.95,0-4.05,0.4-5.5,1.5c-1.45-1.1-3.55-1.5-5.5-1.5c-1.45,0-2.99,0.22-4.28,0.79C1.49,5.62,1,6.33,1,7.14 l0,11.28c0,1.3,1.22,2.26,2.48,1.94C4.46,20.11,5.5,20,6.5,20c1.56,0,3.22,0.26,4.56,0.92c0.6,0.3,1.28,0.3,1.87,0 c1.34-0.67,3-0.92,4.56-0.92c1,0,2.04,0.11,3.02,0.36c1.26,0.33,2.48-0.63,2.48-1.94l0-11.28c0-0.81-0.49-1.52-1.22-1.85 C20.49,4.72,18.95,4.5,17.5,4.5z M21,17.23c0,0.63-0.58,1.09-1.2,0.98c-0.75-0.14-1.53-0.2-2.3-0.2c-1.7,0-4.15,0.65-5.5,1.5V8 c1.35-0.85,3.8-1.5,5.5-1.5c0.92,0,1.83,0.09,2.7,0.28c0.46,0.1,0.8,0.51,0.8,0.98V17.23z"></path><g></g><path d="M13.98,11.01c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.54-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,10.99,14.05,11.01,13.98,11.01z"></path><path d="M13.98,13.67c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,13.66,14.05,13.67,13.98,13.67z"></path><path d="M13.98,16.33c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.7-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,16.32,14.05,16.33,13.98,16.33z"></path></g></svg>
                    </div>
                    <p id="SuMUltraCurrReadingTXT" style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.92);margin:0 auto;font-size:86%;">Loading</p>
                </a>
                <a style="display:inline-block !important;width:fit-content;height:fit-content;flex:1 1 auto;">
                    <div id="SuMUltraWannaListClick" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;width:fit-content;height:fit-content;padding:6px;border-radius:50%;background-color:#ffffff;margin:0 auto;">
                        <svg id="SuMUltraWannaSVG" xmlns="http://www.w3.org/2000/svg" height="34px" viewBox="0 0 24 24" width="34px" fill="rgba(135,56,65,0.74)"><path d="M0 0h24v24H0V0z" fill="none"></path><path d="M18 13h-5v5c0 .55-.45 1-1 1s-1-.45-1-1v-5H6c-.55 0-1-.45-1-1s.45-1 1-1h5V6c0-.55.45-1 1-1s1 .45 1 1v5h5c.55 0 1 .45 1 1s-.45 1-1 1z"></path></svg>
                    </div>
                    <p style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.92);margin:0 auto;font-size:86%;">Wanna</p>
                </a>
                <a style="display:inline-block !important;width:fit-content;height:fit-content;flex:1 1 auto;">
                    <div id="SuMUltraFavListClick" style="-webkit-transition: all 0.18s; -moz-transition: all 0.18s; -ms-transition: all 0.18s; -o-transition: all 0.18s; transition: all 0.18s;opacity:1;width:fit-content;height:fit-content;padding:7px;padding-top:9px;padding-bottom:5px;border-radius:50%;background-color:#ffffff;margin:0 auto;">
                        <svg id="SuMUltraFavSVG" xmlns="http://www.w3.org/2000/svg" height="32px" viewBox="0 0 24 24" width="32px" fill="rgba(135,56,65,0.74)"><path d="M0 0h24v24H0V0z" fill="none"></path><path d="M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z"></path></svg>
                    </div>
                    <p style="width:fit-content;height:fit-content;color:rgba(255,255,255,0.92);margin:0 auto;font-size:86%;">Fav</p>
                </a>
            </div>
            <hr class="animated fadeIn" style="margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:86%;opacity:0.12;margin:0px;margin-block:0px;margin-top:0px !important;margin-bottom:12px !important;">
            <div class="animated fadeIn" style="width:100%;height:fit-content;margin:0 auto;padding:8px;padding-bottom:8px;">
                <a id="SuMUltraHerfFuncLTE" onclick="return false;" style="width:fit-content;height:fit-content;margin:0 auto;text-align:center !important;display:block;margin:0 auto;padding:12px;">
                    <p id="UltraExploreOrLogIn" style="color:rgba(255,255,255,0.96);font-size:98%;display:inline-block;width:fit-content;margin-left:12px;">manga explorer</p>
                    <img src="/svg/arrowforward.svg" style="width:22px;height:22px;display:inline-block;margin-top:-2px;margin-left:-2px;">
                </a>
            </div>
        </div>
    </div>
    <script>
        function SuMUltraCloseCard() {
            var UltraAbsConClElm = document.getElementById('SuMUltraInfoCard');
            UltraAbsConClElm.classList.remove('slideInUp');
            UltraAbsConClElm.classList.add('slideOutDown');
            setTimeout(() => {
                UltraAbsConClElm.style.display = 'none';
            }, 180);
            document.getElementById('SuMUltraMDisc').innerText = 'loading';
            document.getElementById('SuMUltarProdYear').innerText = 'loading';
            document.getElementById('SuMUltarChptersNum').innerText = 'loading';
            document.getElementById('SuMUltraFavListClick').style.opacity = '0.32';
            document.getElementById('SuMUltraCurrReadingTXT').innerText = 'loading';
            document.getElementById('SuMUltraWannaListClick').style.opacity = '0.32';
            document.getElementById('SuMUltraStartReadingFuncClick').style.opacity = '0.32';
        };
        var SuMUltraIsLoading = false;
        function SuMApplyInfoToUltraCard(UltraID, UltraCover, UltraTitle, UltraMELink, IMGID, HerfInfo, HerfThemeColor) {
            if (SuMUltraIsLoading == false) {
                SuMUltraIsLoading = true;
                var UltraAbsConElm = document.getElementById('SuMUltraInfoCard');
                document.getElementById('SuMUltraCurrReadingSVG').setAttribute('fill', HerfThemeColor);
                document.getElementById('SuMUltraWannaSVG').setAttribute('fill', HerfThemeColor);
                document.getElementById('SuMUltraFavSVG').setAttribute('fill', HerfThemeColor);
                if (UltraAbsConElm.classList.contains('slideOutDown') == true) {
                    UltraAbsConElm.classList.remove('slideOutDown');
                }
                if (UltraAbsConElm.classList.contains('slideInUp') == false) {
                    UltraAbsConElm.classList.add('slideInUp');
                }
                //LoadContant
                document.getElementById('SuMUltraBGColor').style.backgroundColor = HerfThemeColor;
                document.getElementById('SuMUltarTitle').innerText = UltraTitle;
                document.getElementById('SuMUltraCover').src = UltraCover;
                UltraAbsConElm.style.display = 'block';
                var UltraUCookie = getCookie('SuMCurrentUser');
                if (UltraUCookie != null) {
                    document.getElementById('UltraExploreOrLogIn').innerText = 'manga explorer';
                    document.getElementById('SuMUltraHerfFuncLTE').setAttribute('onclick', "SuMGoToThis('" + UltraMELink + "', '" + HerfThemeColor + "', '" + HerfInfo + "', '" + IMGID + "');");
                } else {
                    document.getElementById('UltraExploreOrLogIn').innerText = 'login to sum manga';
                    document.getElementById('SuMUltraHerfFuncLTE').setAttribute('onclick', "location.href = '/AccountETC/LoginETC.aspx';");
                }
                SuMGetMDisc(UltraID);
                SuMGetMYear(UltraID);
                SuMGetMChaptersNum(UltraID);
                SuMGetMAgeRating(UltraID);
                SuMGetMFavState(UltraID);
                SuMGetMWannaState(UltraID);
                SuMGetMCurrState(UltraID);
                SuMUltraIsLoading = false;
            }
        };
        function SuMGetMDisc(RMID) {
            document.getElementById('SuMUltraMDisc').innerText = 'loading';
            $.ajax({
                dataType: "json",
                method: 'post',
                url: '<%= ResolveUrl("BTNTesting.aspx/GetMDiscFSQL") %>',
                data: JSON.stringify({ MID: RMID }),
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    $("#SuMUltraMDisc").append(msg.d);
                },
                error: function (e) {
                    //$("#SuMUltraMDisc").append(msg.d);
                    $("#SuMUltraMDisc").append('Failed to load!');
                }
            });
        };
        function SuMGetMYear(RMID) {
            document.getElementById('SuMUltarProdYear').innerText = 'loading';
            $.ajax({
                dataType: "json",
                method: 'post',
                url: '<%= ResolveUrl("BTNTesting.aspx/GetMYearFSQL") %>',
                data: JSON.stringify({ MID: RMID }),
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    $("#SuMUltarProdYear").append(msg.d);
                },
                error: function (e) {
                    //$("#SuMUltraMDisc").append(msg.d);
                    $("#SuMUltarProdYear").append('0000!');
                }
            });
        };
        function SuMGetMChaptersNum(RMID) {
            document.getElementById('SuMUltarChptersNum').innerText = 'loading';
            $.ajax({
                dataType: "json",
                method: 'post',
                url: '<%= ResolveUrl("BTNTesting.aspx/GetMChapterNumFSQL") %>',
                data: JSON.stringify({ MID: RMID }),
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    $("#SuMUltarChptersNum").append(msg.d + ' chapters');
                },
                error: function (e) {
                    //$("#SuMUltraMDisc").append(msg.d);
                    $("#SuMUltarChptersNum").append('Failed to load!');
                }
            });
        };
        function SuMGetMAgeRating(RMID) {
            document.getElementById('SuMUltraAgeRating').innerText = 'loading';
            $.ajax({
                dataType: "json",
                method: 'post',
                url: '<%= ResolveUrl("BTNTesting.aspx/GetMAgeRatingFSQL") %>',
                data: JSON.stringify({ MID: RMID }),
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    $("#SuMUltraAgeRating").append(msg.d);
                },
                error: function (e) {
                    //$("#SuMUltraMDisc").append(msg.d);
                    $("#SuMUltraAgeRating").append('Failed to load!');
                }
            });
        };
        function SuMGetMFavState(RMID) {
            document.getElementById('SuMUltraFavListClick').style.opacity = '0.32';
            var FCSRSIsFav = false;
            var CTALICA = getCookie('SuMCurrentUser');
            if (CTALICA != null && CTALICA != '') {
                var UIDFrJSC = getUIDFrUserCo();
                $.ajax({
                    dataType: "json",
                    method: 'post',
                    url: '<%= ResolveUrl("BTNTesting.aspx/GetMIsFavFSQL") %>',
                    data: JSON.stringify({ MID: RMID, UID: UIDFrJSC }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        FCSRSIsFav = msg.d;
                        if (FCSRSIsFav == true) {
                            document.getElementById('SuMUltraFavSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"/><path d="M13.35 20.13c-.76.69-1.93.69-2.69-.01l-.11-.1C5.3 15.27 1.87 12.16 2 8.28c.06-1.7.93-3.33 2.34-4.29 2.64-1.8 5.9-.96 7.66 1.1 1.76-2.06 5.02-2.91 7.66-1.1 1.41.96 2.28 2.59 2.34 4.29.14 3.88-3.3 6.99-8.55 11.76l-.1.09z"/>';
                        }
                        else {
                            document.getElementById('SuMUltraFavSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"></path><path d="M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z"></path>';
                        }
                        document.getElementById('SuMUltraFavListClick').style.opacity = null;
                    },
                    error: function (e) {
                        //FCSRSIsFav = null;
                        document.getElementById('SuMUltraFavListClick').opacity = '0.32';
                        document.getElementById('SuMUltraFavSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"></path><path d="M19.66 3.99c-2.64-1.8-5.9-.96-7.66 1.1-1.76-2.06-5.02-2.91-7.66-1.1-1.4.96-2.28 2.58-2.34 4.29-.14 3.88 3.3 6.99 8.55 11.76l.1.09c.76.69 1.93.69 2.69-.01l.11-.1c5.25-4.76 8.68-7.87 8.55-11.75-.06-1.7-.94-3.32-2.34-4.28zM12.1 18.55l-.1.1-.1-.1C7.14 14.24 4 11.39 4 8.5 4 6.5 5.5 5 7.5 5c1.54 0 3.04.99 3.57 2.36h1.87C13.46 5.99 14.96 5 16.5 5c2 0 3.5 1.5 3.5 3.5 0 2.89-3.14 5.74-7.9 10.05z"></path>';
                    }
                });
            }
        };
        function SuMGetMWannaState(RMID) {
            document.getElementById('SuMUltraWannaListClick').style.opacity = '0.32';
            var FCSRSIsWanna = false;
            var CTALICA = getCookie('SuMCurrentUser');
            if (CTALICA != null && CTALICA != '') {
                var UIDFrJSC = getUIDFrUserCo();
                $.ajax({
                    dataType: "json",
                    method: 'post',
                    url: '<%= ResolveUrl("BTNTesting.aspx/GetMIsWannaFSQL") %>',
                    data: JSON.stringify({ MID: RMID, UID: UIDFrJSC }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        FCSRSIsWanna = msg.d;
                        if (FCSRSIsWanna == true) {
                            document.getElementById('SuMUltraWannaSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"/><path d="M9 16.17L5.53 12.7c-.39-.39-1.02-.39-1.41 0-.39.39-.39 1.02 0 1.41l4.18 4.18c.39.39 1.02.39 1.41 0L20.29 7.71c.39-.39.39-1.02 0-1.41-.39-.39-1.02-.39-1.41 0L9 16.17z"/>';
                        }
                        else {
                            document.getElementById('SuMUltraWannaSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"></path><path d="M18 13h-5v5c0 .55-.45 1-1 1s-1-.45-1-1v-5H6c-.55 0-1-.45-1-1s.45-1 1-1h5V6c0-.55.45-1 1-1s1 .45 1 1v5h5c.55 0 1 .45 1 1s-.45 1-1 1z"></path>';
                        }
                        document.getElementById('SuMUltraWannaListClick').style.opacity = null;
                    },
                    error: function (e) {
                        //FCSRSIsFav = null;
                        document.getElementById('SuMUltraWannaListClick').opacity = '0.32';
                        document.getElementById('SuMUltraWannaSVG').innerHTML = '<path d="M0 0h24v24H0V0z" fill="none"></path><path d="M18 13h-5v5c0 .55-.45 1-1 1s-1-.45-1-1v-5H6c-.55 0-1-.45-1-1s.45-1 1-1h5V6c0-.55.45-1 1-1s1 .45 1 1v5h5c.55 0 1 .45 1 1s-.45 1-1 1z"></path>';
                    }
                });
            }
        };
        function SuMGetMCurrState(RMID) {
            document.getElementById('SuMUltraStartReadingFuncClick').style.opacity = '0.32';
            var FCSRSIsCurr = false;
            var CTALICA = getCookie('SuMCurrentUser');
            if (CTALICA != null && CTALICA != '') {
                var UIDFrJSC = getUIDFrUserCo();
                $.ajax({
                    dataType: "json",
                    method: 'post',
                    url: '<%= ResolveUrl("BTNTesting.aspx/GetMIsCurrFSQL") %>',
                    data: JSON.stringify({ MID: RMID, UID: UIDFrJSC }),
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        FCSRSIsCurr = msg.d;
                        if (FCSRSIsCurr > 0) {
                            document.getElementById('SuMUltraCurrReadingTXT').innerText = 'Ch ' + FCSRSIsCurr;
                        }
                        else {
                            document.getElementById('SuMUltraCurrReadingTXT').innerText = 'Start Reading';
                        }
                        document.getElementById('SuMUltraStartReadingFuncClick').style.opacity = null;
                    },
                    error: function (e) {
                        //FCSRSIsFav = null;
                        document.getElementById('SuMUltraCurrReadingTXT').innerText = 'Failed!';
                        document.getElementById('SuMUltraStartReadingFuncClick').opacity = '0.32';
                    }
                });
            }
        };
        function getCookie(cname) {
            let name = cname + "=";
            let decodedCookie = document.cookie; //decodeURIComponent(document.cookie);
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
        function getUIDFrUserCo() {
            var SUC = getCookie('SuMCurrentUser');
            var SUCPross = SUC.split('&');
            for (var iii = 0; iii < SUCPross.length; iii++) {
                if (SUCPross[iii].includes('ID=') == true && SUCPross[iii][0] == 'I' && SUCPross[iii][1] == 'D' && SUCPross[iii][2] == '=') {
                    return SUCPross[iii].replace('ID=', '');
                }
            }
        };
    </script>
</asp:Content>