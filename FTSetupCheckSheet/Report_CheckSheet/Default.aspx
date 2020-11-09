<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Report_CheckSheet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



  <style type="text/css" >

          .container1 {
            background-color:black;
            color:#808080;
            height:35px;
             -webkit-border-radius:10px;
             -moz-border-radius:10px;
             border-radius:5.5px;
           text-align: center;

        }
             .container1:hover {
                 background-color:#E6E6FA;
                 color:#000000;
                 height: 35px;
                 text-align: center;
                   -webkit-border-radius:10px;
                   -moz-border-radius:10px;
                   border-radius:5.5px;
             }
     </style>

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
         <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >Release Date: 2020/11/09</h2>
    </div>

    <div class="row">
        <div class="col-md-12">
            <a href="pulpitrock.jpg" class="thumbnail">
            <img src="image5.JPG" class="img-rounded" alt="Cinque Terre"  style="width:350px;height:255px"/>
            </a> 
        </div>
   </div><br />

   <div class="row">
        <div class="col-md-4 col-md-offset-1 text-center">
          <div class="container1">
             <asp:HyperLink NavigateUrl="~/SetupMain.aspx" runat="server" style="width: 350px; height: 100px; font-family: 'Waffle Regular';font-weight: bold;" Font-Size="15pt" ForeColor="#999999">SCAN QRCODE</asp:HyperLink>
          </div>
        </div>

       <%--<div class="col-md-4 text-center">
          <div class="container1">
             <asp:HyperLink NavigateUrl="~/SetupStep7CheckSheet1.aspx" runat="server" style="width: 350px; height: 100px; font-family: 'Waffle Regular';font-weight: bold;" Font-Size="15pt" ForeColor="#999999">CHECK SHEET</asp:HyperLink>
          </div>
        </div>--%>

       <div class="col-md-4 col-md-offset-2 text-center">
          <div class="container1">
             <asp:HyperLink NavigateUrl="~/ShowDataSetup.aspx" runat="server" style="width: 350px; height: 100px; font-family: 'Waffle Regular';font-weight: bold;" Font-Size="15pt" ForeColor="#999999">DATA SET-UP</asp:HyperLink>
          </div>
        </div>
     </div><br /><br />
  
</asp:Content>
