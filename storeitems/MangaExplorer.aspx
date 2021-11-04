<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

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
    <div class="card shadow" style="max-width:806px;">
         <div class="card-header py-3">
          <p style="color:#6840D9;" id="MainCardT" runat="server" class="text-primary m-0 fw-bold forcecolor">SuM - About Us</p>
           </div>
              <div class="card-body" style="text-align:center;"><br />
    <div class="nospace" style="width:100%;" id="TheMangaPhotos" runat="server"><!-- The Story Content NA -->
         </div>
                  <br style="float:right;" />
        <div id="NextChapter" style="float:right;" runat="server" >
            <a style="" class="btn btn-primary btn-sm" href="#"></a>
        </div>
</div>
   </div>
</asp:Content>