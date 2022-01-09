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
            <div class="nospace ContantDivSuM" style="height:fit-content;width:100vw !important;margin-left:0px !important;margin-right:0px !important;margin:0;" id="TheMangaPhotos" runat="server"><!-- The Story Content NA -->
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" EnablePageMethods="true">
       </asp:ScriptManager>
        <div id="CommentsSecCont" runat="server" class="animated slideDown" style="border:4px rgba(225,225,225,0.75) solid;border-top:4px rgba(0,0,0,0) solid;max-height:90%;border-top-right-radius: 22px;border-top-left-radius:22px;background-color:rgba(255,255,255,0.74);display:none;margin-top:6px;width:100vw;height:fit-content;position:absolute;bottom:28px;padding-bottom:26px;z-index:998;">
                <h5 style="color:#fff;padding-top:8px;padding-left:8px;padding-bottom:4px;font-size:96%;">Comments section</h5>
                <div id="SendCommentAria" style="border-radius:12px;width:100%;height:fit-content;margin:0 auto;padding:6px;margin-top:8px;margin-bottom:6px;display:block;">
                    <!--<a style="display:inline;color:#141414;">add a comment...</a>-->
                    <asp:TextBox CssClass="form-control form-control-user" runat="server" ID="UserComment" BackColor="Transparent" BorderColor="Transparent" ForeColor="#ffffff" style="display:inline;width:84%;height:74px;" placeholder="add a comment..."></asp:TextBox>
                    <asp:ImageButton OnClick="SendComment" ID="SendBTN" style="background-color:#fff;border-radius:4px;width:38px;height:32px;margin:4px;" ImageAlign="AbsMiddle" ImageUrl="/svg/send.svg" runat="server" />
                </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SendBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="Comments" style="width:100%;" runat="server">
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <div class="animated fadeIn" id="NextChapter" style="display:block;position:absolute;top:0;margin-left:calc(92vw - 60px);margin-top:4px;" runat="server" >
                <a style="" class="btn btn-primary btn-sm animated fadeInUp" href="#"></a>
            </div>
        <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>-->
        <script>
            //document.getElementById('MainContent_NextChapter').style.bottom = (document.getElementById('X').offsetHeight + 6) + "px";
            /*var myDiv = document.getElementById("MainContent_TheMangaPhotos");
            myDiv.scrollTop = myDiv.scrollHeight;

            window.addEventListener("scroll", () => {
                var offset = element.getBoundingClientRect().top - element.offsetParent.getBoundingClientRect().top;
                const top = window.pageYOffset + window.innerHeight - offset;

                if (top === element.scrollHeight) {
                    document.getElementById('MainContent_NextChapter').style.display = 'block';
                }
            }, { passive: false });*/


            /*jQuery(function ($) {
                $('.ContantDivSuM').on('scroll', function () {
                    if ($(this).scrollTop() +
                        $(this).innerHeight() >=
                        $(this)[0].scrollHeight) {

                        document.getElementById('MainContent_NextChapter').style.display = "block";
                    }
                });
            });*/

            /*if (document.getElementById('MainContent_TheMangaPhotos').scrollTop === (document.getElementById('MainContent_TheMangaPhotos').scrollHeight - document.getElementById('MainContent_TheMangaPhotos').offsetHeight)) {
                document.getElementById('MainContent_NextChapter').style.display = 'block';
            }*/
        </script>
    </div>
</asp:Content>