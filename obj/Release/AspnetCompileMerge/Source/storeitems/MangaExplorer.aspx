<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
        .imagefix2241 {
            margin-left:0px !important;
            margin-right:0px !important;
        }
        .ForceChMaxW {
            max-width:806px !important;
        }
    </style>
    <script>


        //function goBackWithAnim() {

            // Save a local storage item to detect the need to animate the bottom bar
            //window.localStorage.setItem("animate", "");

            // Go back
            //window.history.back();

        //}

    </script>
    <div id="pfc" runat="server" style="background-color:#6840D9;">
        <div class="slideInRight animated">
            <div class="nospace" style="height:fit-content;width:100vw !important;margin-left:0px !important;margin-right:0px !important;" id="TheMangaPhotos" runat="server"><!-- The Story Content NA -->
            </div>
                <br style="float:right;" />
            <div id="NextChapter" style="float:right;" runat="server" >
                <a style="" class="btn btn-primary btn-sm" href="#"></a>
            </div>
        <br /><br /><br /><br />
        </div>
    </div>
</asp:Content>