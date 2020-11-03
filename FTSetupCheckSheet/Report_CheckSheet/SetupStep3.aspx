<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep3.aspx.vb" Inherits="Report_CheckSheet.SetupStep3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>
<div class="container"> 
    <div class="panel-group"> 
        <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
            <div class="panel-heading">ERROR !!</div>
            <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" ForeColor="Red" Font-Size="Large"></asp:Label>
        </div>

        <div class="panel panel-danger">
             <div class="panel-heading">(3.1) BOX OR BOARD :  A channel </div>
             <asp:TextBox ID="TestBoxATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger">
             <div class="panel-heading">(3.2) BOX OR BOARD :  B channel </div>
             <asp:TextBox ID="TestBoxBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxC">
             <div class="panel-heading">(3.3) BOX OR BOARD :  C channel </div>
             <asp:TextBox ID="TestBoxCTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxD">
             <div class="panel-heading">(3.4) BOX OR BOARD :  D channel </div>
             <asp:TextBox ID="TestBoxDTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxE">
             <div class="panel-heading">(3.5) BOX OR BOARD :  E channel </div>
             <asp:TextBox ID="TestBoxETextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxF">
           <div class="panel-heading">(3.6) BOX OR BOARD :  F channel </div>
           <asp:TextBox ID="TestBoxFTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxG">
           <div class="panel-heading">(3.7) BOX OR BOARD :  G channel </div>
           <asp:TextBox ID="TestBoxGTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
        
        <div class="panel panel-danger" runat="server" id="panelTestBoxH">
           <div class="panel-heading">(3.8) BOX OR BOARD :  H channel </div>
           <asp:TextBox ID="TestBoxHTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>     
        
        <div class="panel">
            <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
            <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
        </div><br />
   </div>
  </div>
</asp:Content>
