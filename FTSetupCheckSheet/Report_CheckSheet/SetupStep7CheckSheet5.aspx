﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep7CheckSheet5.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
     </div>

     <div class="container">  
         <div class="panel-group">

             <div class="panel panel-primary">
              <div class="panel-heading"> มาตราการร่วมของทุก  PKG (共通項目) </div>
        </div><br />

        <div class="panel panel-danger">
              <div class="panel-heading"> (16) Good Sample (良品) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecPkgGood">
                        <option>   </option>
                        <option value ="1">1</option>
                        <option value ="2">2</option>
                        <option value ="3">3</option>
                        <option value ="4">4</option>
                        <option value ="5">5</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-danger">
              <div class="panel-heading"> (17) NG Sample (不良品) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecPkgNG">
                        <option>   </option>
                        <option value ="1">1</option>
                        <option value ="2">2</option>
                        <option value ="3">3</option>
                        <option value ="4">4</option>
                        <option value ="5">5</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-danger">
              <div class="panel-heading"> (18) การใช้ Nishiki camara หรือไม่ ? (認識ｶﾒﾗ) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecPkgNishikiCamara">
                        <option>   </option>
                        <option value ="1">1</option>
                        <option value ="2">2</option>
                        <option value ="3">3</option>
                        <option value ="4">4</option>
                        <option value ="5">5</option>
                      </select>
              </div>
        </div><br />

    <div class="panel"">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" style="height: 38px" />
    </div>
         </div> 
     </div>

</asp:Content>
