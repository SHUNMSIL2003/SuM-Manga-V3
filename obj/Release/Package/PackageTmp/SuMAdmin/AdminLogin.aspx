<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SuMManga.Admin.Master" CodeBehind="AdminLogin.aspx.cs" Inherits="SuM_Manga_V3.SuMAdmin.AdminLogin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100vw;height:100vh;text-align:center !important;overflow:scroll;padding:12px;background-color:rgba(0,0,0,0.74);">
        <div style="width:fit-content;height:fit-content;background-color:white;text-align:center !important;margin:auto !important;border-radius:12px;padding:46px;">
            <p style="font-size:118%;color:black;text-align:center;margin:0 auto;">LOGIN TO SUM ADMIN</p>
            <p id="SuMAdminMSG" runat="server" style="margin:0 auto;width:fit-content;height:24px;margin-top:24px;margin-bottom:24px;color:red;"></p>
            <asp:TextBox runat="server" placeholder="administration key" ID="SuMAdminKEY" autocomplete="off" TextMode="Password" BackColor="Transparent" Width="164px" BorderColor="Transparent" style="border-radius:6px;display:block;margin:0 auto;text-align:center;font-size:108%;height:fit-content;color:rgba(0,0,0,0.86);" />
            <asp:TextBox runat="server" placeholder="confirmation code" ID="SuMAdminCC" autocomplete="off" TextMode="Password" BackColor="Transparent" Width="164px" BorderColor="Transparent" style="border-radius:6px;display:block;margin:0 auto;text-align:center;font-size:108%;height:fit-content;color:rgba(0,0,0,0.86);margin-top:18px;" />
            <asp:Button runat="server" OnClick="LoginToSuM" BackColor="Transparent" BorderColor="Transparent" ForeColor="Black" Text="LOGIN" style="font-size:106%;text-align:center;margin-top:32px;" />
        </div>
    </div>
</asp:Content>