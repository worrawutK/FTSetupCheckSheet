﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep7CheckSheet9.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
     </div>

     <div class="container">  
         <div class="panel-group">
            <div class="panel panel-primary">
              <div class="panel-heading"> กรณีที่มี NG (NGの場合) ให้ทำการตรวจสอบอีกครั้ง (再確認) </div>
            </div><br />    
             <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
               <div class="panel-heading">ERROR !!</div>
                 <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" CssClass="form-control" ForeColor="Red" Font-Size="Large"></asp:Label>
             </div>
            <div class="panel panel-success">
                <div class="panel-heading"> (26)  สภาพการ 5s </div>
                    <div class="form-group">
                        <select runat="server" class="form-control" id="selecBge5s">
                        <option>    </option>
                        <option value="OK">OK</option>
                        <option value="NG">NG</option>
                        </select>
                </div>
            </div> 
            <div class="panel panel-success">
                <div class="panel-heading"> (27)  Setup ผ่านหรือไม่ผ่าน ? </div>
                    <div class="form-group">
                        <select runat="server" class="form-control" id="selecCheckSheet">
                        <option>    </option>
                        <option value="YES">YES</option>
                        <option value="NO">NO</option>
                        </select>
                </div>
            </div>            
        
        <div class="panel">
            <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
            <asp:Button ID="Savebutton_Check" runat="server" Text="SAVE" CssClass="btn btn-primary pull-right" Font-Bold="True" /><br />
        </div>

        </div>
    </div>
</asp:Content>
