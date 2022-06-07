<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="CreatorChapterPanel.aspx.cs" Async="true" Inherits="SuM_Manga_V3.SuMCreator.CreatorChapterPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .ForceMaxW {
            max-width:1600px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:var(--SuMThemeColor) !important;
        }
        .form-control :focus {
            outline: none !important;
        }
        #SearchText :focus {
            outline: none !important;
        }
        input:focus {
            outline: none;
        }
        .form-control:focus {
            border-color: var(--SuMDWhite) !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }
        input[type=text]::-ms-clear {
            border: 2px solid var(--SuMThemeColor) !important;
            color:var(--SuMThemeColor) !important;
            background-color:transparent !important;
        }
    </style>
    <div style="width:100%;height:100%;padding-bottom:280px !important;background-color:var(--SuMThemeColorOP92);padding:16px;padding-top:0px !important" class="animated fadeIn" id="CreateProfileDiv" runat="server">
        <div style="background-color:var(--SuMDWhite);margin:0 auto;width:100%;height:fit-content;border-radius:20px;">
           <div style="width:fit-content;max-width:100%;height:fit-content;margin:0 auto;margin-top:12px;margin-bottom:12px;padding:12px;">
               <p id="sumchapterinfo" runat="server" style="padding-left:18px;display:inline;font-size:128%;color:var(--SuMThemeColorOP92);" >Manga name: Chapter X</p>
           </div>
           <div style="background-color:var(--SuMThemeColorOP14);border-radius:18px;width:calc(100% - 24px);height:fit-content;margin:12px;">
               <div style="width:100%;display:block;padding:8px;height:fit-content;position:relative;padding-top:18px;">
                   <p style="padding-left:18px;display:inline;font-size:120%;color:var(--SuMThemeColorOP92);float:left;" >Chapter Cover : </p>
                   <a id="DocUploadIcon" style="display:inline-block;margin-left:8px;width:fit-content;height:fit-content;" onclick="document.getElementById('<%= MangaPicUP.ClientID %>').click();">
                       <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="32px" viewBox="0 0 24 24" width="32px" fill="var(--SuMThemeColorOP92)"><g><rect fill="none" height="24" width="24"/></g><g><path d="M19.41,7.41l-4.83-4.83C14.21,2.21,13.7,2,13.17,2H6C4.9,2,4.01,2.9,4.01,4L4,20c0,1.1,0.89,2,1.99,2H18c1.1,0,2-0.9,2-2 V8.83C20,8.3,19.79,7.79,19.41,7.41z M14.8,15H13v3c0,0.55-0.45,1-1,1s-1-0.45-1-1v-3H9.21c-0.45,0-0.67-0.54-0.35-0.85l2.8-2.79 c0.2-0.19,0.51-0.19,0.71,0l2.79,2.79C15.46,14.46,15.24,15,14.8,15z M14,9c-0.55,0-1-0.45-1-1V3.5L18.5,9H14z"/></g></svg>
                   </a>
                   <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" style="display:none;visibility:hidden;" ID="MangaPicUP" runat="server" HiddenField="true" />
                   <img src="/FakeIMG/FI.png" class="animated fadeIn" onerror="this.style.display='none';return false;" id="MangaImagePrevie" runat="server" style="width:calc(100% - 24px);max-width:420px !important;margin:0 auto;height:auto;border-radius:18px;border:2px solid var(--SuMDWhiteOP32);pointer-events:all !important;" onclick="UploadHiddenBTNHelpterF6C0.click();" />
                   <script>
                       function SuMUploadPic() {
                           var SuMDocUploader = document.getElementById('<%= MangaPicUP.ClientID %>');
                           DocUploader.click();
                       };
                       var UploadHiddenBTNHelpterF6C0 = document.getElementById('<%= MangaPicUP.ClientID %>');
                       var loadFile = function (event) {
                           var image = document.getElementById('<%= MangaImagePrevie.ClientID %>');
                           image.src = URL.createObjectURL(event.target.files[0]);
                           image.style.display = 'block';
                           document.getElementById('DocUploadIcon').style.display = 'none';
                       };
                   </script>
               </div>
               <div style="width:100%;display:block;padding:8px;height:fit-content;position:relative;">
                   <asp:FileUpload onchange="loadFiles2(event)" CssClass="hide" accept="image/*" AllowMultiple="true" style="display:none;visibility:hidden;" ID="ChaptersUP" runat="server" HiddenField="true" />
                   <p id="UploadChaptersPELM" style="padding-left:18px;display:inline;font-size:120%;color:var(--SuMThemeColorOP92);float:left;" >Upload Chapters: </p>
                   <a id="DocUploadChapters" style="display:inline-block;margin-left:8px;width:fit-content;height:fit-content;" onclick="document.getElementById('<%= ChaptersUP.ClientID %>').click();">
                       <svg xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 24 24" height="32px" viewBox="0 0 24 24" width="32px" fill="var(--SuMThemeColorOP92)"><g><rect fill="none" height="24" width="24"/></g><g><path d="M19.41,7.41l-4.83-4.83C14.21,2.21,13.7,2,13.17,2H6C4.9,2,4.01,2.9,4.01,4L4,20c0,1.1,0.89,2,1.99,2H18c1.1,0,2-0.9,2-2 V8.83C20,8.3,19.79,7.79,19.41,7.41z M14.8,15H13v3c0,0.55-0.45,1-1,1s-1-0.45-1-1v-3H9.21c-0.45,0-0.67-0.54-0.35-0.85l2.8-2.79 c0.2-0.19,0.51-0.19,0.71,0l2.79,2.79C15.46,14.46,15.24,15,14.8,15z M14,9c-0.55,0-1-0.45-1-1V3.5L18.5,9H14z"/></g></svg>
                   </a>
                   <script>
                       var loadFiles2 = function (event) {
                           var inp = document.getElementById('<%= ChaptersUP.ClientID %>');
                           if (inp.files.length > 0) {
                               document.getElementById('DocUploadChapters').style.display = 'none';
                               document.getElementById('UploadChaptersPELM').innerText = "Uploaded Chapters " + inp.files.length;
                           } else {
                               document.getElementById('DocUploadChapters').style.display = 'block';
                               document.getElementById('UploadChaptersPELM').innerText = "Upload Chapters: ";
                           }
                       };
                   </script>
               </div>
           </div>
            <asp:Button style="display:none !important;visibility:hidden !important;" OnClick="CreateSUMXMLProfile" ID="SendItBTN" runat="server" />
            <a style="width:48px;height:48px;background-color:transparent;float:right;margin-right:18px;padding:6px;margin:6px;border-radius:21px;" onclick="SendTheProfile();">
                <svg xmlns="http://www.w3.org/2000/svg" height="36px" viewBox="0 0 24 24" width="36px" fill="var(--SuMThemeColorOP92)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M3.4 20.4l17.45-7.48c.81-.35.81-1.49 0-1.84L3.4 3.6c-.66-.29-1.39.2-1.39.91L2 9.12c0 .5.37.93.87.99L17 12 2.87 13.88c-.5.07-.87.5-.87 1l.01 4.61c0 .71.73 1.2 1.39.91z"/></svg>
            </a>
        </div>
         <script type="text/javascript">
             var MangaPicUPElm = document.getElementById('<%= MangaPicUP.ClientID %>');
             var MangaPicUPElm2 = document.getElementById('<%= ChaptersUP.ClientID %>');
             function SendTheProfile() {
                 var SuMValid = false;
                 if (MangaPicUPElm.files.length > 0 && MangaPicUPElm2.files.length > 0) {
                     SuMValid = true;
                 }
                 if (SuMValid == true) {
                     document.getElementById('<%= SendItBTN.ClientID %>').click();
                 }
             };
         </script>
    </div>
</asp:Content>
