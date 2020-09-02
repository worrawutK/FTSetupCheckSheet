<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep1.aspx.vb" Inherits="Report_CheckSheet.SetupStep1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
     </div>
    
<div class="container">  
     <div class="panel-group">
       <div class="panel panel-success">
          <div class="panel-heading" style="font-style: inherit; font-weight: bold; color:#ffffff; background-color:lightseagreen; text-align:center"> (2)&nbsp;&nbsp; INPUT QRCODE OIS</div>
          <asp:TextBox ID="OISTextBox" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
       </div><br />

        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">TEST FLOW</label>
              <asp:TextBox ID="TestflowTextBox" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />

        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">TESTER TYPE</label>
              <asp:TextBox ID="TesterTypetext" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />

          <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
          <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
		  <asp:Button ID="ButtonSkip" CssClass="btn btn-default pull-right" runat="server" Text="Old Equipment" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" /><br />

         </div>
     </div><br />
</asp:Content>
