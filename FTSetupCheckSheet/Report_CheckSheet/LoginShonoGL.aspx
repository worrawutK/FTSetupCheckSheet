<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="LoginShonoGL.aspx.vb" Inherits="Report_CheckSheet.LoginShonoGL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css" >

         body{   
	/*background-color: #444;*/
    background: url(images/image_gallery1.png) no-repeat center center fixed;    
      -webkit-background-size: auto auto;
      -moz-background-size: auto auto;
      -o-background-size: auto auto;
      background-size: auto auto;
}

.vertical-offset-100{
    padding-top:60px;
}

         .auto-style1 {
             display: block;
             width: 100%;
             height: 34px;
             font-size: 14px;
             line-height: 1.428571429;
             color: #555555;
             vertical-align: middle;
             border-radius: 4px;
             -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
             box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
             -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
             transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
             border: 1px solid #cccccc;
             padding: 6px 12px;
             background-color: #ffffff;
         }

     </style>

   <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>
  
   <div class="container">
    <div class="row vertical-offset-100">
    	<div class="col-md-4 col-md-offset-4" style="left: 0px; top: 20px">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title">( GL ) Please Log in&nbsp; :&nbsp;
                        <asp:Label ID="dateLabel" runat="server" Text="__________"></asp:Label>
                    </h3>
			 	</div>
                <div class="panel-group">             
                    <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
                        <div class="panel-heading">ERROR !!</div>
                        <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                </div>
			  	<div class="panel-body">
			    	  	<div class="form-group">
                              <asp:TextBox ID="usernameTextBox" runat="server" CssClass="auto-style1"></asp:TextBox>                         
			    		</div>
                        <asp:Button ID="Submit" runat="server" Text= "Login" CssClass="btn btn-lg btn-success btn-block"/>
			    </div>
			</div>
		</div>
	</div>
</div>
     <br /><br />
     <br /><br /><br />


</asp:Content>
