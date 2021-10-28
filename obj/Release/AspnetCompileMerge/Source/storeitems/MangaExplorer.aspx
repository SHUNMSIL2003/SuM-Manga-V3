<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
    </style>
    <div class="card shadow">
         <div class="card-header py-3">
          <p style="color:#6840D9;" id="MainCardT" runat="server" class="text-primary m-0 fw-bold forcecolor">SuM - About Us</p>
           </div>
              <div class="card-body"><br />
    <div class=" jumbotron nospace" style="width:auto; text-align:center;" id="TheMangaPhotos" runat="server"><!-- The Story Content NA -->
         </div>
        <div id="NextChapter" style="float:right;" runat="server" >
            <a class="btn btn-primary btn-sm" href="#"></a>
        </div>
</div>
   </div>
</asp:Content>