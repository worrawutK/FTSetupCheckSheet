<%@ Page Title="SetupStep7CheckSheet2" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="SetupStep7CheckSheet2.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

     <div class="container">  
           <div class="panel-group">
              <div class="panel panel-primary">
              <div class="panel-heading"> เฉพาะงาน QFP ( IFTN 10 ) : (ＱＦＰのみ) </div>
        </div><br />
    
        <div class="panel panel-success">
              <div class="panel-heading"> (4) ตรวจสอบ Vacuum Pad (吸着ｺﾚｯﾄ交換) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecQfpVacuumPad">
                        <option>    </option>
                        <option value ="NULL">NULL</option>
                        <option value ="YES">YES</option>
                        <option value ="NO">NO</option>
                      </select>
              </div>
         </div>

        <div class="panel panel-success">
              <div class="panel-heading"> (5) ตำแหน่งการติดตั้ง Socket (ｿｹｯﾄ位置決め) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selectQfpSetupSocket">
                        <option>   </option>
                        <option value ="OK">OK</option>
                        <option value ="NG">NG</option>
                      </select>
              </div>
        </div>


        <div class="panel panel-success">
              <div class="panel-heading"> (6) การตัดสินสภาพ  Socket (ｿｹｯﾄ確認) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecQfpSocketDecision">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-success">
              <div class="panel-heading"> (7) การตัดสินสภาพ Lead Clamper (ﾘｰﾄﾞ押え) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecQfpDecisionLeadPress">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div>

        <div class="panel panel-success">
              <div class="panel-heading"> (8) มีการเปลี่ยนประเภทของ Tray หรือไม่ ? (ﾄﾚｲは) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecQfpTray">
                        <option>    </option>
                        <option value ="YES">YES</option>
                        <option value ="NO">NO</option>
                      </select>
              </div>
        </div><br />

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderStyle="Groove" BorderColor="Black" BorderWidth="2" />
        </div> <br />
     </div> 
    </div>
</asp:Content>
