<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" Async="true" CodeBehind="MangaExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorer" %>

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
        textarea:focus,
        textarea.form-control:focus,
        input.form-control:focus,
        input[type=text]:focus,
        input[type=password]:focus,
        input[type=email]:focus,
        input[type=number]:focus,
        [type=text].form-control:focus,
        [type=password].form-control:focus,
        [type=email].form-control:focus,
        [type=tel].form-control:focus,
        [contenteditable].form-control:focus {
            box-shadow: inset 0 0px 0 #000 !important;
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
        <div id="CommentsSecCont" runat="server" class="animated slideDown" style="border:4px rgba(225,225,225,0.75) solid;border-top:4px rgba(0,0,0,0) solid;max-height:90%;border-top-right-radius: 22px;border-top-left-radius:22px;background-color:rgba(255,255,255,0.74);display:none;margin-top:30vh;width:100vw;height:fit-content;position:absolute;top:0 !important;padding-top:100vh;z-index:998;">
            <a id="CommentsSecTopPartColor" runat="server" style="margin-top:0px !important;margin:0 auto !important;width:100vw !important;height:fit-content !important;background:rgba(0,0,0,0);padding:0px !important;">
                <h5 class="animated fadeIn" style="color:#fff;padding-top:26px;padding-left:22px;padding-bottom:4px;font-size:96%;margin-top:calc(12px - 100vh);">Comments section</h5>
                <div class="animated fadeIn" id="SendCommentAria" style="border-radius:12px;width:100%;height:fit-content;margin:0 auto;padding:6px;margin-top:8px;margin-bottom:6px;display:block;">
                    <!--<a style="display:inline;color:#141414;">add a comment...</a>-->
                    <asp:TextBox CssClass="form-control form-control-user" runat="server" ID="UserComment" BackColor="Transparent" BorderColor="Transparent" ForeColor="#ffffff" style="display:inline;width:84%;height:74px;" placeholder="add a comment..."></asp:TextBox>
                    <asp:ImageButton OnClick="SendComment" ID="SendBTN" style="background-color:#fff;border-radius:4px;width:38px;height:32px;margin:4px;" ImageAlign="AbsMiddle" ImageUrl="/svg/send.svg" runat="server" />
                </div>
            </a>
            <style>
                .HiddenASPBTN {
                    display:none !important;
                    visibility:hidden !important;
                }
            </style>
            <asp:Button ID="CommentsSecOpenBTN" runat="server" OnClick="LoadCommentsSection" CssClass="HiddenASPBTN" />
            <script type="text/javascript">
                var CommentsSecIsloaded = false;
                var CommentsSecFirstLoad = true;
                var elm = document.getElementById("MainContent_CommentsSecCont");
                elm.style.marginTop = (elm.style.marginTop - document.getElementById('subnavscont2').offsetHeight) + 'px';
                function FuncLoadCommentsSec() {
                    if (CommentsSecIsloaded == false) {
                        if (CommentsSecFirstLoad == true) {
                            setTimeout(() => {
                                document.getElementById('<%= CommentsSecOpenBTN.ClientID %>').click();
                                CommentsSecFirstLoad = false;
                            }, 1800);
                        }
                        CommentsSecIsloaded = true;
                        setTimeout(() => {
                            elm.classList.remove('slideDown');
                            elm.classList.add('slideInUp');
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = "block";
                        }, 10);
                    }
                    else {
                        document.getElementById('<%= CommentsSecCont.ClientID %>').style.display = 'none';
                        CommentsSecIsloaded = false;
                        setTimeout(() => {
                            elm.classList.remove('slideInUp');
                            document.getElementById('MainContent_Comments').classList.remove('fadeIn');
                            elm.style.display = 'none';
                            elm.classList.add('slideDown');
                            elm.style.display = 'block';
                        }, 10);
                        setTimeout(() => {
                            elm.style.display = 'none';
                            document.getElementById('MainContent_Comments').classList.add('fadeIn');
                        }, 800);
                    }
                };
            </script>
            <asp:UpdatePanel ID="CommentsSecUpdatePanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SendBTN" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CommentsSecOpenBTN" EventName="Click" />
                    </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div class="animated fadeIn" id="Comments" style="width:calc(100vw - 20px) !important;max-height:calc(70vh - 208px) !important;height:calc(70vh - 208px) !important;overflow-x:hidden;overflow-y:scroll;background-color:#ffffff !important;border-radius:18px;padding-left:12px;padding-right:12px;padding-top:18px;padding-bottom:18px;margin-left:10px;margin-right:10px;margin-top:10px;" runat="server">
                            <div class="animated fadeIn" style="width:100%;height:fit-content;margin-top:calc(35vh - 128px) !important;text-align:center !important;">
                                <a id="dot1" runat="server" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000066;margin-right:12px;"></a>
                                <a id="dot2" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;margin-right:6px;"></a>
                                <a id="dot3" style="transition: background-color 0.6s ease !important;width:16px;height:16px;border-radius:8px;overflow:hidden;display:inline-block;background-color:#00000029;margin-left:6px;"></a>
                            </div>
                            <script>
                                var dot1 = document.getElementById('MainContent_dot1');
                                var dot2 = document.getElementById('dot2');
                                var dot3 = document.getElementById('dot3');
                                var DotsThemeColor = dot1.style.backgroundColor;
                                var Deafultcolor = '#00000029';
                                function AnimationDots123() {
                                    setTimeout(() => {
                                        dot2.style.backgroundColor = DotsThemeColor;
                                        dot1.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 600);
                                    setTimeout(() => {
                                        dot3.style.backgroundColor = DotsThemeColor;
                                        dot2.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1200);
                                    setTimeout(() => {
                                        dot1.style.backgroundColor = DotsThemeColor;
                                        dot3.style.backgroundColor = Deafultcolor;
                                        document.getElementById('MainContent_Comments').classList.add('fadeIn');
                                    }, 1800);

                                    setTimeout(AnimationDots123, 1900);
                                }
                                AnimationDots123();
                            </script>
                        </div>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        <div class="animated fadeIn" id="NextChapter" style="display:block;position:absolute;top:0;margin-left:calc(92vw - 60px);margin-top:4px;" runat="server" >
                <a style="" class="btn btn-primary btn-sm animated fadeInUp" href="#"></a>
            </div>
    </div>
</asp:Content>