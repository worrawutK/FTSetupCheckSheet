<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep2.aspx.vb" Inherits="Report_CheckSheet.SetupStep2" %>
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

        <div class="panel panel-info">
            <div class="panel-heading">(2.1) TESTER NO  (ﾃｽﾀｰ№) : A channel </div>
            <asp:TextBox ID="TesternoATextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>

        <div class="panel panel-info">
            <div class="panel-heading">(2.2) TESTER NO  (ﾃｽﾀｰ№) : B channel </div>
            <asp:TextBox ID="TesternoBTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>

        <div class="panel panel-info" runat="server" id="panelTesternoC">
            <div class="panel-heading">(2.3) TESTER NO  (ﾃｽﾀｰ№) : C channel </div>
            <asp:TextBox ID="TesternoCTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>

        <div class="panel panel-info" runat="server" id="panelTesternoD">
            <div class="panel-heading">(2.4) TESTER NO  (ﾃｽﾀｰ№) : D channel </div>
            <asp:TextBox ID="TesternoDTextBox" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
        </div>
     
        <div class="panel">
            <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" />
            <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" />
        </div><br />
  </div>
 </div>
</asp:Content>
