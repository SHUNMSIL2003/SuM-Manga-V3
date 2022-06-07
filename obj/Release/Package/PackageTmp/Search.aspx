<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.MainCard.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Async="true" Inherits="SuM_Manga_V3.Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SuMBTActTopNBottom();
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
              
        }
        setTimeout(() => {
              
        }, 420);
    </script>
    <style>
                    .FNM5455511 {
                        margin-top:0px !important;
                        /*background-color:rgb(240, 235, 255) !important;*/
                    }
        .form-control :focus {
            outline: none !important;
        }
        #SearchText :focus {
            outline: none !important;
        }
                </style>
    <style>
            .STBSUMBAR2 {
                /*position:fixed !important;*/
                top:0 !important;
                width:100% !important;
                text-align:center !important;
            }
            .WAHFH021 {
                display:inline !important;
                max-width:7vh !important;
                max-height:7vh !important;
            }
        input:focus {
            outline: none;
        }
        .form-control:focus {
            border-color: var(--SuMDWhite) !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }
        input[type=text]::-ms-clear {
            border: 2px solid var(--SuMThemeColor) !important;
            color:var(--SuMThemeColor) !important;
            background-color:transparent !important;
        }
        </style>
    <script>/*
        Sys.Browser.WebKit = {};
        if (navigator.userAgent.indexOf('WebKit/') > -1) {
            Sys.Browser.agent = Sys.Browser.WebKit;
            Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
            Sys.Browser.name = 'WebKit';
        }*/
    </script>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= TextBoxForSuM.ClientID %>', '');
            <%ShowResults(TextBoxForSuM.ClientID, EventArgs.Empty);%>
        };
    </script>
    <script>
        setTimeout(function () {
            var viewheight = $(window).height();
            var viewwidth = $(window).width();
            var viewport = $("meta[name=viewport]");
            viewport.attr("content", "height=" + viewheight + "px, width=" +
                viewwidth + "px, user-scalable=no, initial-scale=1, maximum-scale=1, minimum-scale=1, target-densitydpi=device-dpi");
        }, 300);
    </script>
    <div style="width:100%;height:100vh !important;background-color:var(--SuMBack) !important;">
    <div id="ThisPageSBarFixUpPropElm" class="STBSUMBAR2   shadow slideInDown animated" style="padding-top:0px !important;position:fixed !important;top:0 !important;z-index:994 !important;height:fit-content !important;background-color:var(--SuMDWhite) !important;border-radius:22px !important;width:calc(100vw - 24px) !important;margin-left:12px;">
        <nav style="width:100% !important;height:fit-content !important;" class="navbar navbar-light navbar-expand   mb-4 FNM5455511">
                    <div class="container-fluid" style="text-align:center !important;height:fit-content !important;">
                                <div class="" style="display:inline-block !important;width:100vw !important;height:fit-content !important;text-align:center !important;align-items:center;align-content:center;padding-top:4px;padding-bottom:-8px;height:fit-content !important;">
                                    <div class="me-auto navbar-search w-100" style="vertical-align:middle !important;max-width:720px !important;margin:0 auto;height:fit-content !important;">
                                        <div style="width:100% !important;height:24px !important;display:block !important;margin:0 auto !important;height:fit-content !important;"></div>
                                        <div class="input-group" style="vertical-align:middle !important;">
                                            <a style="margin-top:2px;width:38px;height:7vh;display:inline-block !important;float:right;vertical-align:middle !important;" href='javascript:androidAPIs.GoBack();'>
                                                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" style="height:5vh;width:5vh;max-height:32px;max-width:32px;display:inline-block !important;margin-top:12px !important;margin-bottom:12px !important;" fill="var(--SuMThemeColor)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M19 11H7.83l4.88-4.88c.39-.39.39-1.03 0-1.42-.39-.39-1.02-.39-1.41 0l-6.59 6.59c-.39.39-.39 1.02 0 1.41l6.59 6.59c.39.39 1.02.39 1.41 0 .39-.39.39-1.02 0-1.41L7.83 13H19c.55 0 1-.45 1-1s-.45-1-1-1z"/></svg>
                                            </a>
                                            <asp:TextBox AutoPostBack="true" OnTextChanged="ShowResults" onkeyup="this.onchange();" ID="TextBoxForSuM" runat="server" CssClass="bg-light form-control border-0 small" style="background-color:var(--SuMDWhite) !important;border:solid 0px var(--SuMDWhite) !important;height:7vh !important;width:calc(90% - 84px) !important;display:inline !important;float:right;max-height:62px !important;" AutoCompleteType="Search" TextMode="Search" placeholder="Search for..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </nav>
            </div>
        <div id="FUEF6CS" class="animated fadeIn" style="width:100vw;height:fit-content;padding-top:12px;">
            <div class="" style="display:block;margin-left:12px !important;background-color:var(--SuMDWhiteOP86) !important;border-radius:20px !important;animation-duration:0.08s !important; margin:0 auto;height:calc(100vh - 228px) !important;width:calc(100vw - 24px) !important;overflow-y:scroll;margin-top:6px !important;max-width:720px !important;padding:12px;padding-bottom:12px;margin:0 auto !important;max-height:calc(100vh - 228px) !important;max-width:100%;overflow-x:hidden !important;overflow-y:scroll !important;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TextBoxForSuM" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="ShowSuMResults" style="display:block;width:100% !important;height:fit-content !important;" runat="server">
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    <script>
        document.getElementById('FUEF6CS').style.paddingTop = (document.getElementById('ThisPageSBarFixUpPropElm').getBoundingClientRect().height + 12) + 'px';
    </script>
    </div>
</asp:Content>