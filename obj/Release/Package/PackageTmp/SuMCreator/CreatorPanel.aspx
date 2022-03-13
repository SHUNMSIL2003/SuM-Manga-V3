<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="CreatorPanel.aspx.cs" Inherits="SuM_Manga_V3.SuMCreator.CreatorPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        if ("androidAPIs" in window) {
            androidAPIs.SemiTranStatusBar();
              
            setTimeout(() => {
                  
            }, 630);
        }
    </script>
    <div id="SuMLoadingPIndHandler" class="" style="overflow:hidden !important;border-radius:0px;display:block;position:fixed !important;top:0 !important;z-index:998 !important;background-color:var(--SuMDWhite);width:100%;height:100%;margin-top:0px;margin-left:0px;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;">
        <div id="SuMLoadingFHandBG" runat="server" style="overflow:hidden !important;width:100%;height:100%;background-color:var(--SuMThemeColorOP74);margin:0 auto;">
            <div id="SuMLoadingHandDivConF0C0" style="transition:all 0.18s !important;display: block; height: fit-content; width: 280px; background-color: var(--SuMDWhite); border-radius: 18px; margin-right: auto; margin-bottom: 0px; padding: 38px 32px 32px; margin-left: calc(50vw - 140px); position: fixed !important; top: 0px !important; z-index: 1999 !important; margin-top: calc(50vh - 120px) !important; text-align: center !important;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;" class="shadow-sm">
                <svg id="SuMLoadingSVGPreviewHandler" style="display:inline !important;margin-left:12px !important;margin-top:-6px;" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="36px" viewBox="0 0 24 24" width="36px" fill="var(--SuMThemeColorOP92)"><rect fill="none" height="20" width="20"/><path d="M15.35,8.83l0.71-0.71c0.59-0.59,0.59-1.54,0-2.12L15,4.94c-0.59-0.59-1.54-0.59-2.12,0l-0.71,0.71L15.35,8.83z M11.11,6.71 l-6.96,6.96C4.05,13.77,4,13.89,4,14.03v2.47C4,16.78,4.22,17,4.5,17h2.47c0.13,0,0.26-0.05,0.35-0.15l6.96-6.96L11.11,6.71z M4.51,11.18C3.59,10.76,3,10.16,3,9.25c0-1.31,1.39-1.99,2.61-2.59C6.45,6.24,7.5,5.73,7.5,5.25C7.5,4.91,6.83,4.5,6,4.5 c-0.94,0-1.36,0.46-1.38,0.48C4.35,5.29,3.88,5.33,3.57,5.07C3.26,4.81,3.21,4.35,3.46,4.03C3.55,3.93,4.34,3,6,3 c1.47,0,3,0.84,3,2.25C9,6.66,7.55,7.37,6.27,8C5.56,8.35,4.5,8.87,4.5,9.25c0,0.3,0.48,0.56,1.17,0.78L4.51,11.18z M14.14,12.16 c0.83,0.48,1.36,1.14,1.36,2.09c0,1.94-2.44,2.75-3.75,2.75C11.34,17,11,16.66,11,16.25s0.34-0.75,0.75-0.75 c0.77,0,2.25-0.49,2.25-1.25c0-0.39-0.38-0.71-0.97-0.97L14.14,12.16z"/></svg>
                <p id="SuMLoadingHandlerTXT" runat="server" style="display: inline-block; margin-left: 4px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; font-size: 132%; color: var(--SuMThemeColorOP92); margin-bottom: -8px; text-align: left; width: calc(100% - 64px) !important;">Creator panel</p>
                <p id="SuMLoadingHandlerComTXT" class="animated fadeIn" style="font-size: 26px; width: 100%; display: block; text-align: center; height: 26px;margin-top: 10px;margin-bottom:6px; color: var(--SuMThemeColorOP64);">loading complete</p>
                <script>
                    var LoadDetThemeColor = document.getElementById('<%= SuMLoadingHandlerTXT.ClientID %>').style.color;
                    document.getElementById('SuMLoadingSVGPreviewHandler').setAttribute('fill', LoadDetThemeColor);
                    document.getElementById('SuMLoadingHandlerComTXT').style.color = LoadDetThemeColor.replace('0.92', '0.64');
                </script>
            </div>
        </div>
    </div>
    <script>
        var SuMLoadingPIndHandlerElm = document.getElementById('SuMLoadingPIndHandler');
        var SuMLoadingHandDivConF0C0Elm = document.getElementById('SuMLoadingHandDivConF0C0');
        setTimeout(() => {
            //FixAnimations While Caching
            SuMLoadingPIndHandlerElm.style.height = '100%';
            SuMLoadingPIndHandlerElm.style.width = '100%';
            SuMLoadingPIndHandlerElm.style.marginTop = '0';
            SuMLoadingPIndHandlerElm.style.marginLeft = '0';
            SuMLoadingPIndHandlerElm.classList.remove('fadeOut');
            SuMLoadingHandDivConF0C0Elm.classList.remove('fadeOut');
            SuMLoadingPIndHandlerElm.style.display = 'block';
            SuMLoadingPIndHandlerElm.style.visibility = null;
            SuMLoadingPIndHandlerElm.style.borderRadius = null;
            SuMLoadingHandDivConF0C0Elm.style.display = 'block';
            SuMLoadingHandDivConF0C0Elm.style.visibility = null;
            SuMLoadingHandDivConF0C0Elm.classList.remove('animated');
            SuMLoadingPIndHandlerElm.classList.remove('animated');
            SuMLoadingHandDivConF0C0Elm.style.marginLeft = 'calc(50vw - 140px)';
            //SuMLoadingPIndHandlerElm.style.transition = 'all 0.6s !important';
            //Animation Start from here
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.style.height = '360px';
                SuMLoadingPIndHandlerElm.style.width = '360px';
                SuMLoadingPIndHandlerElm.style.marginTop = 'calc(50vh - 200px)';
                SuMLoadingPIndHandlerElm.style.marginLeft = 'calc(50vw - 180px)';
                SuMLoadingPIndHandlerElm.style.borderRadius = '180px';
                SuMLoadingHandDivConF0C0Elm.style.marginLeft = 'calc(50% - 140px) !important';
                //SuMLoadingHandDivConF0C0Elm.style.margin = '0 auto !important';
            }, 80);
            setTimeout(() => {
                SuMLoadingHandDivConF0C0Elm.classList.add('animated');
                SuMLoadingHandDivConF0C0Elm.classList.add('fadeOut');
            }, 280);
            setTimeout(() => {
                SuMLoadingHandDivConF0C0Elm.style.display = 'none';
                SuMLoadingHandDivConF0C0Elm.style.visibility = 'hidden';
                SuMLoadingHandDivConF0C0Elm.style.margin = null;
            }, 360);
            setTimeout(() => {
                //SuMLoadingPIndHandlerElm.style.transition = 'all 1s !important';
                SuMLoadingPIndHandlerElm.style.height = '0px';
                SuMLoadingPIndHandlerElm.style.width = '0px';
                SuMLoadingPIndHandlerElm.style.marginTop = '50vh';
                SuMLoadingPIndHandlerElm.style.marginLeft = '50vw';
                SuMLoadingPIndHandlerElm.style.borderRadius = '12px';
            }, 560);
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.classList.add('animated');
                SuMLoadingPIndHandlerElm.classList.add('fadeOut');
            }, 540);
            setTimeout(() => {
                SuMLoadingPIndHandlerElm.style.display = 'none';
                SuMLoadingPIndHandlerElm.style.visibility = 'hidden';
            }, 820);
        }, 960);
    </script>
    <div id="CreatorInfoCard" class="animated fadeInDown shadow-sm" style="width:100%;height:fit-content;background-color:var(--SuMDWhite);position:fixed !important;top:0 !important;z-index:998 !important;border-bottom-left-radius:20px;border-bottom-right-radius:20px;">
        <div style="display:block;width:100%;margin:0 auto;height:0px;" id="StatusBarHeightFixUp"></div>
        <script>
            if ("androidAPIs" in window) {
                var StatusBarHeightFixUpElm = document.getElementById('StatusBarHeightFixUp');
                var StatusBarHeightValueF4C0 = androidAPIs.getStatusBarHeight();
                StatusBarHeightFixUpElm.style.height = (StatusBarHeightValueF4C0 + 6) + 'px !important';
            }
        </script>
        <img id="PFPElm" runat="server" src="/AccountETC/DeafultPFP/1.jpg" width="86" height="86" style="display:inline-block;border-radius:50%;margin:0 auto;margin-bottom:12px;margin-left:12px;float:left;margin-top:26px;" />
        <div style="width:calc(100% - 120px) !important;height:fit-content;min-height:86px;display:inline-block;padding:12px;margin:0 auto;padding-top:32px;">
            <p style="font-size:130%;color:var(--SuMDBlackOP82);" id="CreatorNameElm" runat="server">Creator Name</p>
            <p style="font-size:98%;color:var(--SuMDBlackOP74);" id="CreatorEmailElm" runat="server">Creator Email</p>
        </div>
    </div>
    <asp:Button style="display:none !important;visibility:hidden !important;" ID="UpdateContantETN" runat="server" OnClick="Page_Load" />
    <div id="CreatorContantContaner" class="animated fadeIn" style="height:100%;width:100%;padding:0px;padding-top:120px;background-color:var(--SuMThemeColorOP92);margin:0 auto !important;">
        <div id="CreatorContantSubContaner" class="animated fadeInDown" runat="server" style="transition-delay:0.54s !important;height:100% !important;width:100%;max-width:740px;margin:0 auto !important;padding:12px;padding-bottom:164px;padding-top:30px;">
            <asp:UpdatePanel ID="CreatorPanelContant" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="UpdateContantETN" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server" CssClass="animated fadeIn">
                        <div style="width:100%;height:100%;margin:0 auto;padding:0;" id="ShowContantDiv" runat="server">
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script>
        setTimeout(() => {
            document.getElementById('<%= UpdateContantETN.ClientID %>').click();
        }, 180);
    </script>
    <div id="SuMCreatorAddBTNContaner" style="position:fixed;height:fit-content;width:100%;z-index:997;bottom:142px;padding-bottom:0px;padding-right:12px;">
        <a onclick="SuMGoToThis('/SuMCreator/CreatorMangaPanel.aspx','var(--SuMThemeColorOP74)','add a manga','Creator');" style="width:fit-content;height:fit-content;padding:12px;background-color:var(--SuMDWhite);color:var(--SuMDWhite);border-radius:50%;width:54px;height:48px;padding:6px;padding-left:9px;padding-right:9px;float:right;margin-bottom:4px;" class="shadow-sm animated fadeInUp">
            <img src="/svg/addTTC.svg" height="36" width="36" />
        </a>
    </div>
    <script>
        var CreatorInfoCardElm = document.getElementById('CreatorInfoCard');
        var CreatorContantContanerElm = document.getElementById('CreatorContantContaner');
        var SuMCreatorAddBTNContanerElm = document.getElementById('SuMCreatorAddBTNContaner');
        CreatorContantContanerElm.style.paddingTop = (CreatorInfoCardElm.offsetHeight + 32) + 'px !important';
        var NavBarHeightValueF4C0 = 0;
        if ("androidAPIs" in window) {
            NavBarHeightValueF4C0 = androidAPIs.SuMGetNavigationBarHeight();
        }
        if (NavBarHeightValueF4C0 == null) {
            NavBarHeightValueF4C0 = 12;
        }
        SuMCreatorAddBTNContaner.style.paddingBottom = (NavBarHeightValueF4C0 + 142) + "px !important";
    </script>
</asp:Content>