<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep1.aspx.vb" Inherits="Report_CheckSheet.SetupStep1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>  
    
<div class="container">  
    <div class="panel-group">
        <div class="panel panel-success">
            <div class="panel-heading" style="font-style: inherit; font-weight: bold; color:#ffffff; background-color:lightseagreen; text-align:center"> (2)&nbsp;&nbsp; INPUT WORKING SLIP</div>
            <asp:TextBox ID="QRcodeTextBox" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
        </div><br />

        <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
           <div class="panel-heading">ERROR !!</div>
           <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" ForeColor="Red" Font-Size="Large"></asp:Label>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading"> LOT NO</div>
            <asp:TextBox ID="LotnoTextbox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading"> PACKAGE NAME</div>
            <asp:TextBox ID="PackagenameTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
    
        <div class="panel panel-primary">
            <div class="panel-heading"> DEVICE NAME</div>
            <asp:TextBox ID="DeviceNameTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">TEST FLOW</div>
            <asp:TextBox ID="TestflowTextBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div><br />        

        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonSkip" CssClass="btn btn-default pull-right" runat="server" Text="Old Equipment" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" /><br />

        </div>
    </div><br />
</asp:Content>
