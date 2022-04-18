<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="ExploreGetByGarn.aspx.cs" Inherits="SuM_Manga_V3.ExploreGetByGarn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="UPDATERESESNTS" runat="server" OnClick="Page_Load" style="display:none !important;visibility:hidden;" />
    <asp:UpdatePanel ID="RESENTSUPATEPANLE" runat="server" UpdateMode="Conditional" style="width:fit-content;height:fit-content;">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UPDATERESESNTS" EventName="Click" />
        </Triggers>
            <ContentTemplate>
                <asp:Panel runat="server" style="width:100vw !important;height:100vh !important;">
                    <div style="height:100vh !important;max-height:100vh !important;width:100vw !important;overflow:hidden;display:block !important;padding:0px;border-radius:0px !important;">
                        <div id="GR" runat="server" style="scroll-snap-type:x mandatory;padding-left:0px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100% !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;margin-top:-22px !important;padding-left:28px !important;"></div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        document.getElementById('<%= UPDATERESESNTS.ClientID %>').click();
    </script>
</asp:Content>