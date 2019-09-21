﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep3.aspx.vb" Inherits="Report_CheckSheet.SetupStep3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>
<div class="container"> 
  <div class="panel-group"> 
    <div class="panel panel-danger">
       <div class="panel-heading">(4) BOX OR BOARD :  A channel </div>
       <asp:TextBox ID="TestBoxATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

    <div class="panel panel-danger">
       <div class="panel-heading">(5) BOX OR BOARD :  B channel </div>
       <asp:TextBox ID="TestBoxBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
    </div>

     <div class="panel panel-danger">
       <div class="panel-heading">(6) Adaptor (アダプタ) :  A channel </div>
       <asp:TextBox ID="AdaptorATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
     </div>

     <div class="panel panel-danger">
       <div class="panel-heading">(7) Adaptor (アダプタ) :  B channel </div>
       <asp:TextBox ID="AdaptorBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
     </div>

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
    </div><br />
   </div>
  </div>
</asp:Content>
