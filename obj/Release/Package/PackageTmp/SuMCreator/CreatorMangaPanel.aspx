<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="CreatorMangaPanel.aspx.cs" Async="true" Inherits="SuM_Manga_V3.SuMCreator.CreatorMangaPanel" %>

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
    <div style="width:100%;height:100%;padding-bottom:280px !important;background-color:var(--SuMThemeColorOP92);padding:16px;padding-top:0px !important;" class="animated fadeIn" id="CreateProfileDiv" runat="server">
        <div style="background-color:var(--SuMDWhite);margin:0 auto;width:100%;height:fit-content;border-radius:20px;">
           <div style="background-color:var(--SuMThemeColorOP14);border-radius:18px;width:calc(100% - 24px);height:fit-content;margin:12px;">
                <div style="width:100%;display:block;padding:8px;padding-left:18px;margin-bottom:-12px;">
                    <p style="display:inline;font-size:120%;color:var(--SuMThemeColorOP92);" >Title: </p>
                    <asp:TextBox CssClass="text-black-50" ID="MangaNameTXT" runat="server" TextMode="SingleLine" BackColor="Transparent" BorderColor="Transparent" style="display:inline !important;width:calc(100% - 80px);font-size:118%;" />
                </div>
               <div style="width:100%;padding:16px;">
                   <p style="display:inline;font-size:120%;color:var(--SuMThemeColorOP92);" >Age rating: </p>
                   <style>
                       option:hover {
                           background-color:var(--SuMThemeColorOP32) !important;
                       }
                       option:focus {
                           background-color:var(--SuMThemeColorOP32) !important;
                       }
                       option::selection {
                           background-color:var(--SuMThemeColorOP32) !important;
                       }
                   </style>
                   <asp:DropDownList runat="server" Width="98" Height="38" style="text-align:center;display:inline-block;background-color:var(--SuMDWhiteOP60);color:var(--SuMThemeColorOP92);border-radius:19px;border:2px solid var(--SuMThemeColorOP32) !important;" ID="AgeRatingDDL" CssClass="dropdown-list form-control" > 
                       <asp:ListItem>Everyone</asp:ListItem>
                       <asp:ListItem>12+</asp:ListItem>
                       <asp:ListItem>13+</asp:ListItem>
                       <asp:ListItem>14+</asp:ListItem>
                       <asp:ListItem>15+</asp:ListItem>
                       <asp:ListItem>16+</asp:ListItem>
                       <asp:ListItem>17+</asp:ListItem>
                       <asp:ListItem>18+</asp:ListItem>
                   </asp:DropDownList>
               </div>
               <div style="width:100%;display:block;padding:8px;height:fit-content;position:relative;">
                   <p style="padding-left:18px;display:inline;font-size:120%;color:var(--SuMThemeColorOP92);float:left;" >Cover : </p>
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
               <!-- <div style="width:100%;display:block;padding:8px;padding-left:18px;height:fit-content;position:relative;">
                   <p style="display:inline;font-size:120%;color:var(--SuMThemeColorOP92);float:left;" >Theme color : </p>
               </div> -->
               <div style="width:100%;display:block;padding:8px;padding-left:18px;height:fit-content;position:relative;">
                    <p style="display:inline;font-size:120%;color:var(--SuMThemeColorOP92);float:left;" >Description: </p>
                    <asp:TextBox CssClass="text-black-50 form-control" ID="MangaInfoTXT" runat="server" TextMode="MultiLine" BackColor="Transparent" BorderColor="Transparent" style="display:inline !important;width:100%;font-size:118%;height:228px;float:right;border:none !important;border-color:transparent !important;" />
                </div>
           </div>
           <div style="width:100%;display:block;padding:8px;padding-left:18px;padding-right:18px;height:fit-content;position:relative;text-align:center;">
               <!--  SciFi Sport Supernatural SliceofLife Mystery Drama GL BL Romance Comedy Fantasy Action  -->
               <a id="ActionSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Action');">Action</a>
               <asp:CheckBox AutoPostBack="false" ID="Action" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="FantasySDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Fantasy');">Fantasy</a>
               <asp:CheckBox AutoPostBack="false" ID="Fantasy" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="SliceofLifeSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('SliceofLife');">Slice of Life</a>
               <asp:CheckBox AutoPostBack="false" ID="SliceofLife" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="ComedySDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Comedy');">Comedy</a>
               <asp:CheckBox AutoPostBack="false" ID="Comedy" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="RomanceSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Romance');">Romance</a>
               <asp:CheckBox AutoPostBack="false" ID="Romance" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="DramaSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Drama');">Drama</a>
               <asp:CheckBox AutoPostBack="false" ID="Drama" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="MysterySDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Mystery');">Mystery</a>
               <asp:CheckBox AutoPostBack="false" ID="Mystery" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="SportSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Sport');">Sport</a>
               <asp:CheckBox AutoPostBack="false" ID="Sport" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="SupernaturalSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('Supernatural');">Supernatural</a>
               <asp:CheckBox AutoPostBack="false" ID="Supernatural" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
               <a id="SciFiSDiv" runat="server" SUMSELECTED="0" style="border-radius:20px;color:var(--SuMThemeColorOP54);background-color:var(--SuMThemeColorOP08);width:fit-content;height:fit-content;padding:8px;padding-left:16px;padding-right:16px;display:inline-block;margin-bottom: 5px;" onclick="SuMClickGernXAuto('SciFi');">Sci-Fi</a>
               <asp:CheckBox AutoPostBack="false" ID="SciFi" runat="server" Checked="false" style="display:none !important;visibility:hidden !important;" />
           </div>
            <asp:Button style="display:none !important;visibility:hidden !important;" OnClick="CreateSUMXMLProfile" ID="SendItBTN" runat="server" />
            <a style="width:48px;height:48px;background-color:transparent;float:right;margin-right:18px;padding:6px;margin:6px;border-radius:21px;" onclick="SendTheProfile();">
                <svg xmlns="http://www.w3.org/2000/svg" height="36px" viewBox="0 0 24 24" width="36px" fill="var(--SuMThemeColorOP92)"><path d="M0 0h24v24H0V0z" fill="none"/><path d="M3.4 20.4l17.45-7.48c.81-.35.81-1.49 0-1.84L3.4 3.6c-.66-.29-1.39.2-1.39.91L2 9.12c0 .5.37.93.87.99L17 12 2.87 13.88c-.5.07-.87.5-.87 1l.01 4.61c0 .71.73 1.2 1.39.91z"/></svg>
            </a>
        </div>
         <script type="text/javascript">
             function SuMClickGernXAuto(GernID) {
                 var AutoGernHiddenCB = document.getElementById('MainContent_' + GernID);
                 var AutoGernSDivElm = document.getElementById('MainContent_' + GernID + 'SDiv');
                 if (AutoGernSDivElm.getAttribute('SUMSELECTED') == '0') {
                     AutoGernSDivElm.style.color = 'var(--SuMThemeColorOP92)';
                     AutoGernSDivElm.style.backgroundColor = 'var(--SuMThemeColorOP14)';
                     AutoGernSDivElm.setAttribute('SUMSELECTED', '1');
                     AutoGernHiddenCB.click();
                 }
                 else {
                     AutoGernSDivElm.style.color = 'var(--SuMThemeColorOP54)';
                     AutoGernSDivElm.style.backgroundColor = 'var(--SuMThemeColorOP08)';
                     AutoGernSDivElm.setAttribute('SUMSELECTED', '0');
                     AutoGernHiddenCB.click();
                 }
             };
             var GActionELM = document.getElementById('<%= Action.ClientID %>');
             var GFantasyELM = document.getElementById('<%= Fantasy.ClientID %>');
             var GSliceofLifeELM = document.getElementById('<%= SliceofLife.ClientID %>');
             var GComedyELM = document.getElementById('<%= Comedy.ClientID %>');
             var GRomanceELM = document.getElementById('<%= Romance.ClientID %>');
             var GDramaELM = document.getElementById('<%= Drama.ClientID %>');
             var GMysteryELM = document.getElementById('<%= Mystery.ClientID %>');
             var GSportELM = document.getElementById('<%= Sport.ClientID %>');
             var GSupernaturalELM = document.getElementById('<%= Supernatural.ClientID %>');
             var GSciFiELM = document.getElementById('<%= SciFi.ClientID %>');
             function AGernsIsSelected() {
                 var SuMAtleastOneIsSelected = false;
                 if (GSciFiELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GSupernaturalELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GSportELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GMysteryELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GDramaELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GRomanceELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GComedyELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GSliceofLifeELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GFantasyELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 if (GActionELM.checked == true) {
                     SuMAtleastOneIsSelected = true;
                 }
                 return SuMAtleastOneIsSelected;
             };
             var MangaNameTXTElm = document.getElementById('<%= MangaNameTXT.ClientID %>');
             var MangaPicUPElm = document.getElementById('<%= MangaPicUP.ClientID %>');
             var MangaInfoTXTElm = document.getElementById('<%= MangaInfoTXT.ClientID %>');
             function SendTheProfile() {
                 var SuMValid = false;
                 var SuMGernsStatus = AGernsIsSelected();
                 if (SuMGernsStatus == true && MangaInfoTXTElm.value.replace(' ', '') != '' && MangaNameTXTElm.value.replace(' ', '') != '' && MangaPicUPElm.files.length > 0) {
                     SuMValid = true;
                 }
                 if (SuMValid == true) {
                     document.getElementById('<%= SendItBTN.ClientID %>').click();
                 }
             };
         </script>
    </div>
</asp:Content>
