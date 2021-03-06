﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep7CheckSheet4.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

     <div class="container">  
         <div class="panel-group">

              <div class="panel panel-primary">
              <div class="panel-heading"> Manual Check (ﾏﾆｭｱﾙ確認) </div>
        </div>

        <div class="panel panel-Default">
              <div class="panel-heading"> (12) ทำการ Test ซ้ำไปมา (繰り返し精度) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecManualCheckTest" style="vertical-align:middle">
                        <option value ="0">0</option>
                        <option value ="1">1</option>
                        <option value ="2">2</option>
                        <option value ="3">3</option>
                        <option value ="4">4</option>
                        <option value ="5">5</option>
                        <option value ="6">6</option>
                        <option value ="7">7</option>
                        <option value ="8">8</option>
                        <option value ="9">9</option>
                        <option value ="10">10</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-Default">
              <div class="panel-heading"> (13) มีการ Request Test Engineer หรือไม่ ? (計測対応後再確認) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecManualCheckTE">
                        <option>   </option>
                        <option value ="OK">OK</option>
                        <option value ="NG">NG</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-Default">
              <div class="panel-heading"> (14) ทำการยืนยันหลังการ Request TE (計測対応後再確認) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selectManualCheckRequestTE" style="vertical-align:middle">
                        <option value ="0">0</option>
                        <option value ="1">1</option>
                        <option value ="2">2</option>
                        <option value ="3">3</option>
                        <option value ="4">4</option>
                        <option value ="5">5</option>
                      </select>
              </div>
        </div>

       <div class="panel panel-Default">
              <div class="panel-heading"> (15) ทำการยืนยันหลังการ Request TE Confirm (計測対応後再確認) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selectManualCheckRequestTEConfirm">
                        <option>   </option>
                        <option value ="OK">OK</option>
                        <option value ="NG">NG</option>
                      </select>
              </div>
        </div>

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" style="height: 38px" />
    </div>

         </div> 
     </div>

</asp:Content>
