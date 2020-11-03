<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep4.aspx.vb" Inherits="Report_CheckSheet.SetupStep4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>
<div class="container"> 
  <div class="panel-group"> 
    <div class="panel panel-success">
       <div class="panel-heading">(4.1) Adaptor (アダプタ) :  A channel </div>
       <asp:TextBox ID="AdaptorATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
     </div>

     <div class="panel panel-success" runat="server" id="panelAdaptorB" style="display:none">
       <div class="panel-heading">(4.2) Adaptor (アダプタ) :  B channel </div>
       <asp:TextBox ID="AdaptorBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
     </div>

     <div class="panel panel-success">
       <div class="panel-heading">(4.3) Dutcard (ダットｶｰﾄﾞ) :  A channel </div>
       <asp:TextBox ID="DutcardATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
     </div>

    <div class="panel panel-success" runat="server" id="panelDutcardB" style="display:none">
       <div class="panel-heading">(4.4) Dutcard (ダットｶｰﾄﾞ) :  B channel </div>
       <asp:TextBox ID="DutcardBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel panel-success">
       <div class="panel-heading">(4.5) Bridge cable (ブリッジケーブル) :  A channel </div>
       <asp:TextBox ID="BridgecableATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel panel-success" runat="server" id="panelBridgecableB" style="display:none">
       <div class="panel-heading">(4.6) Bridge cable (ブリッジケーブル) :  B channel </div>
       <asp:TextBox ID="BridgecableBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
    </div><br />
   </div>
 </div>
</asp:Content>
