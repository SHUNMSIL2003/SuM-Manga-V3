<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="SuM_Manga_V3.Library" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        if ("androidAPIs" in window) {
            androidAPIs.SemiTranStatusBar();
        }
</script>
    <style>
        img {
  border-radius: 10px;
}
.box {
	border-top-left-radius: 10px;
	border-bottom-right-radius: 10px;
    border-radius: 10px;
}
.txtmaxw {
  max-width: 175px;
}
img {
            pointer-events: none;
        }
            .floutright {
                float:right !important;
                display:inline !important;
                /*text-align: right !important ;*/
            }
            h3 {
                max-width:160px !important;
            }
            .backgroundforjim {
            background-color:#f0edf7 !important;
            border: 2px solid #6840D9 !important;
            margin: -2px;
        }
        .ForceMaxW {
            max-width:960px !important;
            margin: 0 auto;
        }
        body {
            overflow: hidden; /* Hide scrollbars */
        }
        /* Hide scrollbar for Chrome, Safari and Opera */
        ::-webkit-scrollbar {
            display: none;
        }

        /* Hide scrollbar for IE, Edge and Firefox */
        body {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }
    </style>
                    <div class="animated fadeIn ForceMaxW" style="width:100%;height:100vh;padding-bottom:132px;overflow:scroll;">
                        <div class="card-body">
                            <div id="MangasAvalibleDiv" runat="server" style="text-align:center;align-items:center; width:fit-content; margin:0 auto !important;margin-top:26px !important;">
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="width:fit-content;height:fit-content;margin:0 auto !important;">
                                    <nav style="" class="d-lg-flex justify-content-lg-end dataTables_paginate paging_simple_numbers">
                                        <ul style="float:right !important;border-radius:32px !important;overflow:hidden;" class="pagination">
                                            <li style="float:right !important;" id="PPS" runat="server" class="page-item disabled"><a id="PrePageG" runat="server" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true">« Prev page</span></a></li>
                                            <li style="float:right !important;" class="page-item active"><a id="CurrPageNum" runat="server" class="page-link" style="pointer-events:none;-moz-user-select: none; -webkit-user-select:none; user-select: none;border-radius:12px;">1</a></li>
                                            <li style="float:right !important;" id="NPS" runat="server" class="page-item"><a id="NextPageG" runat="server" class="page-link" href="#" aria-label="Next"><span aria-hidden="true">Next page »</span></a></li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>