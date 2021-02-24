<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep6.aspx.vb" Inherits="Report_CheckSheet.SetupStep6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

<div class="container"> 
  <div class="panel-group">    
    <div class="panel panel-default">
       <div class="panel-heading">(6.1) TYPE CHANGE PACKAGE  (ﾀｲﾌﾟ交換)</div>
       <asp:TextBox ID="TypechangepackageTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-default">
       <div class="panel-heading">(6.2) QR CODE SOCKET : Channel 1 (QRコードｿｹｯﾄ)</div>
       <asp:TextBox ID="QRcodeSocket1TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>
    
      <div class="panel panel-default">
        <div class="panel-heading">(6.3) QR CODE SOCKET : Channel 2 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket2TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-default">
        <div class="panel-heading">(6.4) QR CODE SOCKET : Channel 3 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket3TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

      <div class="panel panel-default">
        <div class="panel-heading">(6.5) QR CODE SOCKET : Channel 4 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket4TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

      <div class="panel panel-default" runat="server" id="panelSocket5" style="display:none">
       <div class="panel-heading">(6.6) QR CODE SOCKET : Channel 5 (QRコードｿｹｯﾄ)</div>
       <asp:TextBox ID="QRcodeSocket5TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>
    
      <div class="panel panel-default" runat="server" id="panelSocket6" style="display:none">
        <div class="panel-heading">(6.7) QR CODE SOCKET : Channel 6 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket6TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-default" runat="server" id="panelSocket7" style="display:none">
        <div class="panel-heading">(6.8) QR CODE SOCKET : Channel 7 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket7TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

      <div class="panel panel-default" runat="server" id="panelSocket8" style="display:none">
        <div class="panel-heading">(6.9) QR CODE SOCKET : Channel 8 (QRコードｿｹｯﾄ) </div>
        <asp:TextBox ID="QRcodeSocket8TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
    </div><br />
   </div>
  </div>
</asp:Content>
