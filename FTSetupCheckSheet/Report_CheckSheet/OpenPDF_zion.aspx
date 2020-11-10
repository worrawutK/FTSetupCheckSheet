<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="OpenPDF_zion.aspx.vb" Inherits="Report_CheckSheet.OpenPDF_zion" %>
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
        </div>
    </div>

</asp:Content>
