<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.MainCard.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button style="display:none !important;visibility:hidden !important;" ID="UpdatePageContant" runat="server" OnClick="Page_Load" />
    <div style="margin:0 auto !important;margin-top:0 !important; overflow-x: clip; border-radius: 22px;padding:0px; padding-left: 0px; padding-right: 0px; animation-duration: 0.96s !important; background-color: transparent !important;overflow-y: scroll !important;height:100vh !important; max-width: 720px !important; position: relative !important;width:calc(100% - 24px);margin-left:12px;border:none !important;" >
    <asp:UpdatePanel ID="UpdateCOntant990" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="UpdatePageContant" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server" style="width:100vh !important;height:100vh !important;overflow-x:hidden;overflow-y:scroll !important; padding-bottom: 18px !important; padding-top: 18px !important; ">
                        <div id="ShowReqContant" runat="server" style="width:100%;height:fit-content;">
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
    <script>
        document.getElementById('<%= UpdatePageContant.ClientID %>').click();
    </script>
    </div>
</asp:Content>