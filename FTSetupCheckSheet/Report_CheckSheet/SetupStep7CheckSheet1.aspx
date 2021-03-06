﻿<%@ Page Title="CheckSEtupFT" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetupStep7CheckSheet1.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

 <div class="container">  
     <div class="panel-group">
        <div class="panel panel-primary">
              <div class="panel-heading "> ก่อนการปฏิบัติงาน (前作業) </div>
        </div><br />

        <div class="panel panel-info">
              <div class="panel-heading"> (1) Box มีการเชื่อมต่อกับ Tester หรือไม่ ? (BOXの接続は)</div>
                <div class="form-group">
                    <select runat="server" class="form-control" id="selectBoxTesterConnection">
                    <option ></option>
                    <option value ="NULL">NULL</option>
                    <option value ="OK">OK</option>
                    <option value ="NG">NG</option>
                    </select>
              </div>
        </div>

        <div class="panel panel-info">
              <div class="panel-heading"> (2) มีการใช้ Option หรือไม่ ? (ｵﾌﾟｼｮﾝは) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecOptionSetup">
                        <option></option>
                        <option value ="YES">YES</option>
                        <option value ="NO">NO</option>
                      </select>
              </div>
         </div>         

        <div class="panel panel-info">
              <div class="panel-heading"> (3) มีการเชื่อมต่อกับ Option หรือไม่ ? (ｵﾌﾟｼｮﾝの接続) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecOptionConnection">
                        <option></option>
                        <option value ="OK">OK</option>
                        <option value ="NG">NG</option>
                      </select>
                      </div>
        </div>

        <div class="panel">
            <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
            <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        </div><br />
     </div> 
   </div>

</asp:Content>
