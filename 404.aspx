<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SuM_Manga_V3._404" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
    </script>
    <style>
        body {
            overflow: hidden; /* Hide scrollbars */
        }
        /* Hide scrollbar for Chrome, Safari and Opera */
        ::-webkit-scrollbar {
            display: none;
        }

        /* Hide scrollbar for IE, Edge and Firefox */
        body {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }
        img {
            pointer-events: none;
        }
    </style>
    <script>
        if ("androidAPIs" in window) {
            androidAPIs.SemiTranStatusBar();
        }
        else {
            location.href = '/SuMMangaInstallAPP.aspx';
        }
    </script>
                     <div class="text-center mt-5 animated fadeIn" style="text-align:center;position:relative;vertical-align:middle;margin-top:24vh !important;">
                             <div class=" animated pulse" >
                                 <svg xmlns="http://www.w3.org/2000/svg" style="margin:0 auto !important;display:block !important;" height="142px" viewBox="0 0 24 24" width="142px" fill="var(--SuMThemeColor)"><path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 11c-.55 0-1-.45-1-1V8c0-.55.45-1 1-1s1 .45 1 1v4c0 .55-.45 1-1 1zm1 4h-2v-2h2v2z"/></svg>
                             </div>
                             <p class="text-dark mb-5 lead animated pulse" style="color:var(--SuMThemeColor) !important;font-size:180%;margin-top:6px;">something went wrong!</p>
                             <p class="text-black-50 mb-0" style="font-size:110%;margin-top:-48px;color:#000000;"><b>The Server might be down or you may have found a glitch...</b></p>
                         <!-- <a id="A1" onclick="if (!navigator.onLine) { fetch('/Explore.aspx', { method: 'GET' }).then(res => { location.href = '/Explore.aspx'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/Explore.aspx'; }" href="#" style="color: var(--SuMThemeColor);border-color: var(--SuMThemeColor);" runat="server">← Back to Main Page</a> -->
                    </div>
</asp:Content>