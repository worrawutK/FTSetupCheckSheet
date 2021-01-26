<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SetupStep7CheckSheet7.aspx.vb" Inherits="Report_CheckSheet.SetupStep7CheckSheet7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

     <div class="container">  
         <div class="panel-group">
             <div class="panel panel-primary">
              <div class="panel-heading"> มาตราการร่วมของทุก  PKG (共通項目) </div>
        </div><br />

           <div class="panel panel-danger">
              <div class="panel-heading"> (22) Bent Lead (足曲りは) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecPkgBentLead">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div>

     <div class="panel panel-danger">
              <div class="panel-heading"> (23) KAKE・HIGE・การเป็นรอยของขางาน　(ｶｹ・ヒゲ・ｷｽﾞは) </div>
                  <div class="form-group">
                      <select runat="server" class="form-control" id="selecPkgKakeHige">
                        <option>   </option>
                        <option value ="A">A</option>
                        <option value ="B">B</option>
                        <option value ="C">C</option>
                      </select>
              </div>
        </div><br />

    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
    </div>
  </div>
</div>

</asp:Content>
