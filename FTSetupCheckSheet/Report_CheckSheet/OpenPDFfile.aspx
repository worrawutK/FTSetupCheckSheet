<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OpenPDFfile.aspx.vb" Inherits="Report_CheckSheet.OpenPDFfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

      <div class ="row" style ="margin-top :10px">
        <div class ="col-md-12 " style ="width :100%;height:1000px; left: 0px; top: 5px;">
            <iframe id="OpenReport" runat ="server" style ="width :100%;height :60%"></iframe>
        </div>
    </div>

</asp:Content>
