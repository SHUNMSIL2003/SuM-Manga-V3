<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" Async="true" CodeBehind="TagView.aspx.cs" Inherits="SuM_Manga_V3.storeitems.TagView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br style="height:4px !important;width:100vw !important; margin:0 auto !important;" />
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
        <div style="height:fit-content;max-height:80vh !important; width:100vw;overflow:scroll; background-color:var(--SuMDWhite) !important;" id="CategoryX" runat="server">
            <h2 id="TagType" runat="server" style="color:var(--SuMDBlack);margin-left:8px;margin-bottom:-18px;">#</h2>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TextBoxForSuM" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="TypeContant" runat="server" style="padding-left:6px;overflow-y:hidden !important;overflow-x:scroll !important;white-space:nowrap !important; width:100vw !important;max-width:100vw; height:276px;max-height:276px !important;display:flex !important;" >
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>