<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="ExploreMainCard.aspx.cs" Inherits="SuM_Manga_V3.ExploreMainCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ScriptInjectorA000" style="display:none !important;visibility:hidden !important;" runat="server">
        <script>
            androidAPIs.ShowSuMToastsOverview('welcome UserName!');
        </script>
    </div>
    <style>
        * {box-sizing: border-box;}
.mySlides {display: none;}
img {vertical-align: middle;}

/* Slideshow container */
        .slideshow-container {
            max-width: 1000px;
            position: relative;
            margin: auto;
            /*background-color:transparent !important;*/
        }

/* Caption text */
        .text {
            color: var(--SuMDGray);
            font-size: 16px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
            font-family: VarelaRound !important;
        }

/* Number text (1/3 etc) */
.numbertext {
  color: var(--SuMDGray);
  font-size: 12px;
  padding: 8px 12px;
  position: absolute;
  top: 0;
}

/* The dots/bullets/indicators */
.dot {
  height: 6px;
  width: 6px;
  margin: 0 2px;
  background-color: var(--SuMDWhiteOP32);
  border-radius: 50%;
  display: inline-block;
  transition: background-color 0.6s ease;
}

.active {
  background-color: var(--SuMDWhiteOP94);
}

/* Fading animation */
.fade {
  -webkit-animation-name: fade;
  -webkit-animation-duration: 4s;
  animation-name: fade;
  animation-duration: 4s;
}

@-webkit-keyframes fade {
  from {opacity: .99} 
  to {opacity: 1}
}

@keyframes fade {
  from {opacity: .99} 
  to {opacity: 1}
}

/* On smaller screens, decrease text size */
@media only screen and (max-width: 300px) {
  .text {font-size: 16px}
}
/*ClickEFFECT*/
.ClickEffect:active {
    width: 70px;
    height: 74px;
}
    </style>
<div style="background-color:transparent !important;width:100% !important;height:100% !important;margin:0 auto !important">
<div class="slideshow-container" id="cardscontain" runat="server" style="border:0.5px var(--SuMDBroderC) solid !important;scroll-margin-top:38px; border-radius:20px;width:calc(100% - 24px) !important;height:100% !important;overflow:hidden !important;margin-top:12px;margin-left:12px;display:block;background-color:var(--SuMDBlackOP74) !important;transition: background-color 0.32s ease !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;">
    <div id="ThisPageTopBarFixer" style="background-color:transparent !important;width:100% !important;height:fit-content !important;display:block;margin-bottom:-16px;padding-top:8px !important;">
        <img id="ThisPageSBarFixUpPropElm0" style="display:inline;margin-left:16px;margin-top:8px;float:left;" width="38" height="38" src="/svg/awesomeTW.svg" />
        <p id="ThisPageSBarFixUpPropElm1" style="color:rgba(255,255,255,0.92) !important;font-size:128%;margin-top:12px;margin-left:6px;display:inline;float:left;">The latest of manga !</p>
    </div>
    <div style="background-color:transparent !important;width:100%;height:fit-content;">
    <div id="cardstoshow" runat="server" style="margin:0 auto !important;border-radius:18px !important;margin-top:12px !important;width:fit-content;height:fit-content;overflow:hidden !important;width:calc(100% - 24px) !important;overflow:hidden !important;margin:12px;margin-bottom:2px !important;">
<div class="mySlides fade" style="overflow: hidden; background-image:linear-gradient(var(--SuMDBlackOP527),var(--SuMDBlackOP30)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;padding:12px;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:var(--SuMDWhite);font-size:160%;display:block;">Blue Exorcist</h1>
    <p style="color:var(--SuMDGray)"></p>
    </a>
    <div style="background-color:rgba(145, 114, 227, 0.58);width:94px;height:42px;border-top-right-radius:16px;float:right;margin-bottom:0px;margin-right:0px;">
        <a href="#">Read Now</a>
    </div>
</div>
        <div class="mySlides fade" style="overflow:hidden; background-image:linear-gradient(var(--SuMDBlackOP527),var(--SuMDBlackOP30)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:var(--SuMDWhite);font-size:160%;">Blue Exorcist</h1>
    <p style="text-align:center;vertical-align:middle;"></p>
    </a>
</div>
        <div class="mySlides fade" style="overflow: hidden; background-image:linear-gradient(var(--SuMDBlackOP527),var(--SuMDBlackOP30)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:82vw !important;">
    <a style="width:100%;height:100%;" href="#">
    <h1 style="float:left;margin-top:8px;margin-left:8px;color:var(--SuMDWhite);font-size:160%;">Blue Exorcist</h1>
    <p></p>
    </a>
</div>
     </div>
        </div>
    <div id="cardsdots" runat="server" style="text-align:center;background-color:transparent !important;width:100%;height:fit-content;margin-top:-6px !important;border-bottom-right-radius:18px;border-bottom-left-radius:18px;">
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span> 
</div>
</div>
<script>
    var SlideShowCardElm = document.getElementById('<%= cardscontain.ClientID %>');
    var slideIndex = 0;
    showSlides();
    function showSlides() {
        var i;
        var slides = document.getElementsByClassName("mySlides");
        var dots = document.getElementsByClassName("dot");
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slideIndex++;
        if (slideIndex > slides.length) { slideIndex = 1 }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";
        SlideShowCardElm.style.backgroundColor = document.getElementById('CardNuM' + (slideIndex) + 'Theme').innerText.replace('0.74', '1');
        setTimeout(showSlides, 3360); // Change image every 2 seconds
    }
</script>
</div>
</asp:Content>