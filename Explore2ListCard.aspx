<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="Explore2ListCard.aspx.cs" Inherits="SuM_Manga_V3.Explore2ListCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="RecentsCont" runat="server" style="scroll-snap-align:start !important;scroll-snap-stop: always !important;background-color:transparent !important;" class="">
        <asp:Button ID="UPDATERESESNTS" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
                        <asp:UpdatePanel ID="RESENTSUPATEPANLE" runat="server" UpdateMode="Conditional" style="width:fit-content;height:fit-content;">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="UPDATERESESNTS" EventName="Click" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Panel runat="server" style="width:fit-content;height:fit-content;">
                                                <div class=" " id="Recent" runat="server" style="padding-left:-8px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:calc(100% + 15px) !important;height:100%;display:flex !important;width:fit-content !important;overflow-x:scroll !important;overflow-y:hidden !important;">
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
            <script>
                setTimeout(() => {
                    document.getElementById('<%= UPDATERESESNTS.ClientID %>').click();
                    setTimeout(() => {
                        var RecentF0CSElm = document.getElementById('RecentScrollContS');
                        var RescentBodyF0CSElm = document.getElementById('RescentBody');
                        var currLeftID = Math.round(RecentF0CSElm.scrollLeft / 112) + 1;
                        var currRecentItemThemeColor = document.getElementById('RecentItem' + currLeftID).style.backgroundColor;
                        if (currRecentItemThemeColor != null) {
                            RescentBodyF0CSElm.style.backgroundColor = currRecentItemThemeColor;
                        }
                        setTimeout(() => {
                            var RecentF0CSElm = document.getElementById('RecentScrollContS');
                            var RescentBodyF0CSElm = document.getElementById('RescentBody');
                            var currLeftID = Math.round(RecentF0CSElm.scrollLeft / 112) + 1;
                            var currRecentItemThemeColor = document.getElementById('RecentItem' + currLeftID).style.backgroundColor;
                            if (currRecentItemThemeColor != null) {
                                RescentBodyF0CSElm.style.backgroundColor = currRecentItemThemeColor;
                            }
                        }, 360);
                    }, 180);
                }, 10);
                setTimeout(() => {
                    var RecentF0CSElm = document.getElementById('RecentScrollContS');
                    var RescentBodyF0CSElm = document.getElementById('RescentBody');
                    var currLeftID = Math.round(RecentF0CSElm.scrollLeft / 112) + 1;
                    var currRecentItemThemeColor = document.getElementById('RecentItem' + currLeftID).style.backgroundColor;
                    if (currRecentItemThemeColor != null) {
                        RescentBodyF0CSElm.style.backgroundColor = currRecentItemThemeColor;
                    }
                }, 540);
            </script>
</div>
</asp:Content>