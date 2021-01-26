﻿<%@ Page Title="SetupStep7CheckSheet3" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep7CheckSheet3.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

     <div class="container">  
         <div class="panel-group">

                 <div class="panel panel-primary">
              <div class="panel-heading"> เฉพาะงาน SOP (SOPのみ) </div>
        </div><br />

        <div class="panel panel-warning">
              <div class="panel-heading"> (9) ตรวจเช็คปรับตั้งชุด Stopper (分離部[ｽﾄｯﾊﾟｰ]の調整ﾁｪｯｸ) </div>
                   <div class="form-group">
                      <select runat="server" class="form-control" id="selectStopper">
                        <option>   </option>
                        <option value ="OK">OK</option>
                        <option value ="NG">NG</option>
                      </select>
              </div>
        </div>
   
        <div class="panel panel-warning">
              <div class="panel-heading"> (10) การตัดสินสภาพ  Socket (ｿｹｯﾄ確認) </div>
                   <div class="form-group">
                      <select runat="server" class="form-control" id="selecSopSocketDecision">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-warning">
              <div class="panel-heading"> (11) การตัดสินสภาพ Lead Clamper (ﾘｰﾄﾞ押え) </div>
                   <div class="form-group">
                      <select runat="server" class="form-control" id="selecSopDecisionLeadClamper">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div><br />

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left " runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
    </div>

         </div>  
     </div>

</asp:Content>
