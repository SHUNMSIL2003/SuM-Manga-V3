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
        ::placeholder { /* Chrome, Firefox, Opera, Safari 10.1+ */
            color: #ffffff !important;
            opacity: 0.8 !important; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: rgba(255,255,255,0.8) !important;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: rgba(255,255,255,0.8) !important;
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
        <div id="CommentsSecCont" runat="server" class="animated slideDown" style="border:4px rgba(225,225,225,0.75) solid;border-top:4px rgba(0,0,0,0) solid;max-height:90%;backdrop-filter:blur(1px);border-top-right-radius: 22px;border-top-left-radius:22px;background-color:rgba(255,255,255,0.74);display:none;margin-top:6px;width:100vw;height:fit-content;position:absolute;bottom:28px;padding-bottom:26px;">
                <h5 style="color:#fff;padding-top:8px;padding-left:8px;padding-bottom:4px;font-size:96%;">Comments section</h5>
                <div style="border-radius:12px;width:100%;height:fit-content;margin:0 auto;padding:6px;margin-top:8px;margin-bottom:6px;">
                    <!--<a style="display:inline;color:#141414;">add a comment...</a>-->
                    <asp:TextBox CssClass="form-control form-control-user" runat="server" ID="UserComment" BackColor="Transparent" BorderColor="Transparent" ForeColor="#ffffff" style="display:inline;width:84%;height:74px;" placeholder="add a comment..."></asp:TextBox>
                    <asp:ImageButton OnClick="SendComment" ID="SendBTN" style="background-color:#fff;border-radius:4px;width:38px;height:32px;margin:4px;" ImageAlign="AbsMiddle" ImageUrl="/svg/send.svg" runat="server" />
                </div>
                <div id="Comments" runat="server">
                    <!--<div style="background-color:rgb(255,255,255);border-radius:12px;padding:6px;margin:4px;">
                        <img style="display:inline;border-radius:50%;width:48px;height:48px;" src="/AccountETC/DeafultPFP.jpg" />
                        <a style="display:inline;">
                            <p style="font-size:84%;display:inline;">User Name</p>
                            <p style="font-size:100%;margin-top:6px;">OMG what a great chapter!!!!</p>
                        </a>
                    </div>-->
                </div>
            </div>
    </div>
</asp:Content>