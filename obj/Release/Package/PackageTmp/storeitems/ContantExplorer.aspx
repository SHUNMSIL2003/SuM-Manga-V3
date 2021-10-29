<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .ForceMaxW {
            max-width:1200px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }
    </style>
    <div class="card shadow ForceMaxW">
         <div class="card-header py-3">
          <p style="color:#6840D9;" id="MainCardT" runat="server" class="text-primary m-0 fw-bold forcecolor">SuM - About Us</p>
           </div>
              <div class="card-body"><br />

                  <div class="row" style="display:inline;width:100%;">
    <!-- <div style="float:left;display:inline;text-align:left;" id="mangacoverinpage" runat="server"></div>  -->
    <div class="damfw scrollforce nospace left" style="width:100%;height:fit-content;"><!-- The Story Content NA -->
        <div style="width:100%;height:182px;">
            <img id="cover" runat="server" style="width:auto;height:180px;display:inline;" loading="lazy" src="#" />
            <div style="width:calc(100%-132);height:fit-content;display:block;">
                <h4 style="color:#6840D9;float:left;padding-left:8px;" id="MangaViewsAndChapters" runat="server"></h4>
                <h5 style="color:#1a171c;float:left;padding-left:8px;" id="MangaDis" runat="server"></h5>
            </div>
        </div>
        <div style="direction: ltr;" id="TheMangaPhotos" runat="server"></div>
    </div>
        </div>

     </div>
   </div>
</asp:Content>