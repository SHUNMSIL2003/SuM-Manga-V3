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
    <div id="ThisPageSBarFixUpPropElm" class="STBSUMBAR2 bg-white shadow slideInDown animated" style="padding-top:6px !important;position:fixed !important;top:0 !important;z-index:994 !important;height:fit-content !important;">
        <nav style="width:100% !important;height:fit-content !important;" class="navbar navbar-light navbar-expand bg-white mb-4 FNM5455511">
                    <div class="container-fluid" style="text-align:center !important;height:fit-content !important;">
                                <div class="" style="display:inline-block !important;width:100vw !important;height:fit-content !important;text-align:center !important;align-items:center;align-content:center;padding-top:8px;padding-bottom:-8px;height:fit-content !important;">
                                    <div class="me-auto navbar-search w-100" style="vertical-align:middle !important;max-width:720px !important;margin:0 auto;height:fit-content !important;">
                                        <div style="width:100% !important;height:24px !important;display:block !important;margin:0 auto !important;height:fit-content !important;"></div>
                                        <div class="input-group" style="vertical-align:middle !important;">
                                            <a style="margin-top:2px;width:38px;height:7vh;display:inline-block !important;float:right;vertical-align:middle !important;" href='javascript:history.go(-1)'><img src="/svg/arrowback.svg" style="height:5vh;width:5vh;max-height:32px;max-width:32px;display:inline-block !important;margin-top:12px !important;margin-bottom:12px !important;" /></a>
                                            <asp:TextBox AutoPostBack="true" OnTextChanged="ShowResults" onkeyup="this.onchange();" ID="TextBoxForSuM" runat="server" CssClass="bg-light form-control border-0 small" style="background-color:#ffffff !important;border:solid 0px #ffffff !important;height:7vh !important;width:calc(90% - 84px) !important;display:inline !important;float:right;max-height:62px !important;" AutoCompleteType="Search" TextMode="Search" placeholder="Search for..."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </nav>
            </div>
        <div id="FUEF6CS" style="width:fit-content;height:fit-content;padding-top:12px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TextBoxForSuM" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="ShowSuMResults" style="margin:0 auto;height:fit-content !important;width:100vw !important;overflow-y:scroll;margin-top:6px !important;max-width:720px !important;padding-bottom:182px;" runat="server">
                        </div>
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    <script>
        document.getElementById('FUEF6CS').style.paddingTop = (document.getElementById('ThisPageSBarFixUpPropElm').getBoundingClientRect().height + 12) + 'px';
    </script>
</asp:Content>