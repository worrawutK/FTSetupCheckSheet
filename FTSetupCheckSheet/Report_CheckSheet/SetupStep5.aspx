<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep5.aspx.vb" Inherits="Report_CheckSheet.SetupStep5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>
<div class="container"> 
  <div class="panel-group"> 
    <div class="panel panel-warning">
       <div class="panel-heading">(5.1) Option 1 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType1TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.2) Option 2 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType2TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.3) Option 3 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType3TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.4) Option 4 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType4TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.5) Option 5 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType5TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.6) Option 6 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType6TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-warning">
       <div class="panel-heading">(5.7) Option 7 (ｵﾌﾟｼｮﾝ名) </div>
       <asp:TextBox ID="OptionType7TextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
    </div><br />
   </div>
  </div>
</asp:Content>
