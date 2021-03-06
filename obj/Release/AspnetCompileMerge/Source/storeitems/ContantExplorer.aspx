<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

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
    <script>

        document.addEventListener("DOMContentLoaded", function () {

            var fullnavscont = document.getElementById("fullnavscont");

            // Check if there is a local storage item with tbe name "animate"
            /*if (window.localStorage.getItem("animate") != null) {

                fullnavscont.style.display = "none";
                */
                // Remove the item
                /*window.localStorage.removeItem("animate");

                fullnavscont.classList.add("animated", "slideInUp");

                fullnavscont.style.display = null;

            }*/

            window.onclick = function (e) {

                console.log(e);

                // Check if this action was triggered by clicking an <a> element
                if (document.activeElement.tagName == "A" && document.activeElement.getAttribute("name") != "no-animation") {

                    // Get the element's href
                    var redirectLink = document.activeElement.getAttribute("href");

                    // Prevent the page from being redirected
                    e.preventDefault();

                    // Add the slide down animation
                    fullnavscont.classList.add("animated", "slideOutDown");

                    setTimeout(function () {

                        window.location.href = redirectLink;

                    }, 540);

                }

            };
        });
    </script>
    <div class="fadeIn animated">
    <div style="height:fit-content;width:100vw;overflow:hidden; background-color:#ffffff !important;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:fit-content;max-height:864px !important;">
    <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;">Blue Exorcist</h1>
    <p style="height:fit-content;min-height:60vw !important; width:96vw;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;" id="MdiscS" runat="server"></p>
        
</div>
</div>
            </div>
        <div class="animated fadeInUp" style="margin-top:-20px;background-color:#ffffff;border-top-left-radius:22px;border-top-right-radius:22px;">
        <div id="GernsTags" runat="server" style="border-top-right-radius:22px;border-top-left-radius:22px;width:100%;height:fit-content;background-color:transparent;align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(0,0,0,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
        <div style="background-color:aqua;margin:0 auto;" id="SVC" runat="server">
            <div class="animated pulse" id="MRSC" runat="server" style="margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;">
                <a id="MRSW" runat="server" href="#" style="color:#6840D9;"></a>
            </div>
        </div>
    <div style="display:inline-block;height:100vh !important;min-height:100% !important;background-color:rgba(1,65,54,0.544);" id="TheMangaPhotosF" runat="server">
        
     </div>
       </div>
</asp:Content>
