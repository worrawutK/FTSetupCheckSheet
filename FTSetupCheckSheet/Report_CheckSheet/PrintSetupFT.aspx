<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PrintSetupFT.aspx.vb" Inherits="Report_CheckSheet.PrintSetupFT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <div class="jumbotron">        
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 10px;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold; margin-top: 0px; margin-bottom: 0px;">FL-FT-TP PROCESS</h2>
    </div>

    <ul class ="nav nav-pills nav-justified">
        <li class ="active"><a href ="PrintSetupFT.aspx">Upload Picture for Shoko</a></li> 
        <li ><a href="ShowDataSetup.aspx">MONITORING</a></li>
        <li ><a href ="ShowDataSetupHistory.aspx">Search Data History</a></li>
    </ul>
    <div class="container"> 
        <div class="panel-group"> 
            <div class="form-group has-success has-feedback" style="text-align: center"><br /><hr />
                <center><br /><asp:Label ID="dateTimesetupLabel" runat="server" Text="dateTimesetup"></asp:Label><br /></center>

                <br />
                <br />
      <asp:Panel ID="Panel2" runat="server" BorderColor="#6699FF" BorderStyle="Groove"><br />
          <table style="width:100%;">
             <tr>
                  <td style="height: 23px; width: 423px">
                      &nbsp;</td>
                  <td style="height: 23px; width: 369px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#0099FF" Width="300px" />
                  </td>
                  <td style="height: 23px; text-align: left;vertical-align:bottom">
                      FRONT MOLD CHIP CHECK</td>
              </tr>
              <tr>
                  <td style="width: 423px; height: 44px">
                      &nbsp;</td>
                  <td style="width: 369px; height: 44px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      <asp:FileUpload ID="FileUpload2" runat="server" BorderColor="#0099FF" Width="297px" />
                  </td>
                  <td style="height: 44px; text-align: left;vertical-align:bottom">
                      BACK MOLD CHIP CHECK</td>
              </tr>
              <tr>
                  <td style="width: 423px">
                      &nbsp;</td>
                  <td style="width: 369px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                      <asp:FileUpload ID="FileUpload3" runat="server" BorderColor="#0099FF" Width="297px" />
                  </td>
                  <td style="text-align: left ;vertical-align:bottom">
                      LEAD CHECK</td>
              </tr>
          </table>
          <table style="width:100%;">
              <tr>
                  <td style="height: 23px; width: 423px">&nbsp;</td>
                  <td style="height: 23px; width: 369px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:FileUpload ID="FileUpload4" runat="server" BorderColor="#0099FF" Width="300px" />
                  </td>
                  <td style="height: 23px; text-align: left;vertical-align:bottom">CHECK LEAD SIDE SCRATCH</td>
              </tr>
              <tr>
                  <td style="width: 423px">&nbsp;</td>
                  <td style="width: 369px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:FileUpload ID="FileUpload5" runat="server" BorderColor="#0099FF" Width="297px" />
                  </td>
                  <td style="text-align: left;vertical-align:bottom">CHECK CENTER LEAD</td>
              </tr>
              <tr>
                  <td style="width: 423px">&nbsp;</td>
                  <td style="width: 369px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                  <td>&nbsp;&nbsp; </td>
              </tr>
          </table>
          <table style="width:100%;">
              <tr>
                  <td style="height: 23px; width: 423px">&nbsp;</td>
                  <td style="height: 23px; width: 369px; text-align: center;">
                    <%--  <asp:DropDownList ID="MCnoDropDownList" runat="server" DataSourceID="McnoSqlDataSource" DataTextField="MCNo" DataValueField="MCNo" Font-Bold="True">
                      </asp:DropDownList>--%>
                      <asp:FileUpload ID="FileUpload6" runat="server" BorderColor="#0099FF" Width="297px" />
                  </td>
                  <td style="height: 23px; text-align: left;">SOCKET</td>
              </tr>
          </table>
          <table style="width:100%;">
              <tr>
                  <td style="height: 23px; width: 423px">&nbsp;</td>
                  <td style="height: 23px; width: 369px; text-align: center;"><%--  <asp:DropDownList ID="MCnoDropDownList" runat="server" DataSourceID="McnoSqlDataSource" DataTextField="MCNo" DataValueField="MCNo" Font-Bold="True">
                      </asp:DropDownList>--%></td>
                  <td style="height: 23px">&nbsp;</td>
              </tr>
          </table>
          <br />
      </asp:Panel><br /> <br />

       <center><asp:Button ID="Export_Check0" runat="server" Text="Export To PDF" CssClass="btn btn-primary" Font-Bold="True" style="height: 36px" /></center> <br />     
      </div>
    </div>
   </div>
</asp:Content>
