<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.MainCard.Master" AutoEventWireup="true" CodeBehind="CreatorPanel.aspx.cs" Inherits="SuM_Manga_V3.SuMCreator.CreatorPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>