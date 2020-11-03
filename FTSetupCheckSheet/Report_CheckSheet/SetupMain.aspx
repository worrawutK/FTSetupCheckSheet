<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupMain.aspx.vb" Inherits="Report_CheckSheet.SetupMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
     </div>

 <div class="container">  
      <div class="panel-group">
         <div class="panel panel-success">
            <div class="panel-heading" style="font-style: inherit; font-weight: bold; color: #FFFFFF; background-color:black;text-align:center"> (1)&nbsp;&nbsp;&nbsp; INPUT&nbsp; QRCODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <asp:TextBox ID="QRcodeTextBox" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox><br />

            <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
                <div class="panel-heading">ERROR !!</div>
                <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" ForeColor="Red" Font-Size="Large"></asp:Label>
            </div><br />

        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">MACHINE</label>
              <asp:TextBox ID="TextBoxMCNo" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />

        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">DEVICE</label>
              <asp:TextBox ID="Devicetext" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />

        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">TEST FLOW</label>
              <asp:TextBox ID="TestflowTextBox" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />
      
        <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">TESTER TYPE</label>
              <asp:TextBox ID="TesterTypeTextBox" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
       </div><br />

       <div class="form-group form-group-lg">
              <label class="col-sm-2 control-label" for="lg">STATUS</label>
              <asp:TextBox ID="TextBoxSetupStatus" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
        </div><br />

              <asp:Button ID="ButtonSetup" CssClass="btn btn-default pull-left " runat="server" Text="SET-UP" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
              <asp:Button ID="ButtonConfirm" CssClass="btn btn-default pull-right" runat="server" Text="CONFIRM" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" /><br /><br />
        </div>
      </div>
   </div>
</asp:Content>
