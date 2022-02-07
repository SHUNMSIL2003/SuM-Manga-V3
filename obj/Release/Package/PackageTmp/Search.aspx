<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Async="true" Inherits="SuM_Manga_V3.Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        androidAPIs.SetLightStatusBarColor();
        var IsFullScreen = androidAPIs.SuMIsFullScreen();
        if (IsFullScreen == true) {
            androidAPIs.DeactivateFullScreenMode();
        }
        setTimeout(() => {
            androidAPIs.SetLightStatusBarColor();
        }, 420);
    </script>
    <style>
                    .FNM5455511 {
                        margin-top:0px !important;
                        margin-bottom:0px !important;
                        height:7vh !important;
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
            border-color: #ffffff !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }
        input[type=text]::-ms-clear {
            border: 2px solid #6840D9 !important;
            color:#6840D9 !important;
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
                viewwidth + "px, initial-scale=1.0");
        }, 300);
    </script>
    <div id="ThisPageSBarFixUpPropElm" class="STBSUMBAR2 bg-white shadow slideInDown animated" style="padding-top:6px !important;">
        <nav style="height:64px;width:100% !important;" class="navbar navbar-light navbar-expand bg-white mb-4 FNM5455511">
                    <div class="container-fluid" style="text-align:center !important;">
                                <div class="" style="display:inline !important;width:100vw !important;height:7vh !important;max-height:62px !important; min-height:56px !important; text-align:center !important;align-items:center;align-content:center;">
                                    <div class="me-auto navbar-search w-100" style="vertical-align:middle !important;max-width:720px !important;margin:0 auto;">
                                        <div class="input-group" style="vertical-align:middle !important;">
                                            <a style="margin-top:2px;width:38px;height:7vh;display:inline-block !important;float:right;vertical-align:middle !important;" href='javascript:history.go(-1)'><img src="/svg/arrowback.svg" style="height:5vh;width:5vh;max-height:32px;max-width:32px;display:inline-block !important;margin-top:1vh !important;margin-bottom:1vh !important;" /></a>
                                            <asp:TextBox AutoPostBack="true" OnTextChanged="ShowResults" onkeyup="this.onchange();" ID="TextBoxForSuM" runat="server" CssClass="bg-light form-control border-0 small" style="background-color:#ffffff !important;border:solid 0px #ffffff !important;height:7vh !important;width:calc(90% - 84px) !important;display:inline !important;float:right;max-height:62px !important;" AutoCompleteType="Search" TextMode="Search" placeholder="Search for..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </nav>
            </div>
    <script>
        var ThisPageSBarFixUpPropElmVar = document.getElementById('ThisPageSBarFixUpPropElm');
        var StatusBarHeightValue = androidAPIs.getStatusBarHeight();
        ThisPageSBarFixUpPropElmVar.style.marginTop = (6 + StatusBarHeightValue) + 'px !important';
    </script>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TextBoxForSuM" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="ShowSuMResults" style="margin:0 auto;height:fit-content !important;width:100vw !important;overflow-y:scroll;margin-top:6px !important;max-width:720px !important;" runat="server">
                        </div>
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>