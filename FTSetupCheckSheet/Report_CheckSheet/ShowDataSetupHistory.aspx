<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ShowDataSetupHistory.aspx.vb" Inherits="Report_CheckSheet.ShowDataSetupHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-material-datetimepicker.js"></script>

       <style type="text/css">
        .style2
        {
            width: 10%;
            font-weight: bold;
            height: 42px;
        }
        .style6
        {
            width: 15%;
            height: 42px;
        }
        .style9
        {
            width: 10%;
            height: 42px;
        }
        .style10
        {
            width: 10%;
            height: 42px;
        }
        .auto-style3 {
            width: 16%;
            height: 43px;
        }
        .auto-style4 {
            width: 100%;
            margin-bottom: 0px;
        }
        .auto-style8 {
            font-weight: bold;
            height: 42px;
           }

           .auto-style9 {
               text-align: center;
           }

           .auto-style10 {
               display: block;
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

           .auto-style11 {
               width: 10%;
               font-weight: bold;
               height: 43px;
           }
           .auto-style12 {
               width: 15%;
               height: 43px;
           }

           .auto-style13 {
               margin-left: -15px;
               margin-right: -15px;
           }

         </style>

     <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
      </div>

      <ul class ="nav nav-pills nav-justified">
        <li ><a href ="PrintSetupFT.aspx">Upload Picture for Shoko</a></li>
        <li ><a href="ShowDataSetup.aspx">MONITORING</a></li>
        <li class ="active"><a href ="ShowDataSetupHistory.aspx">Search Data History</a></li>
      </ul><br />
      <hr />

     <div class ="row">
          <td colspan="2" align="center" class="auto-style33">
              <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">DATA HISTORY</h2>


          </td><br />
              <center><div class="well">
                  <div class="auto-style9">
                      <br />
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="From Date"></asp:Label>
                      &nbsp;&nbsp;&nbsp;
                      <asp:TextBox ID="datetimeStartTextBox" runat="server" BorderColor="Gray" BorderStyle="Ridge"></asp:TextBox>
                      <ajaxToolkit:CalendarExtender ID="datetimeStartTextBox_CalendarExtender" runat="server" TargetControlID="datetimeStartTextBox" Format="yyyy/MM/dd"/>
                      &nbsp;&nbsp;&nbsp;
                      <asp:Label ID="timeLabel" runat="server" Font-Bold="True" Text="To"></asp:Label>                 
                      &nbsp;&nbsp;                 
                      <asp:TextBox ID="datetimeEndTextBox" runat="server" BorderColor="Gray" BorderStyle="Ridge"></asp:TextBox>                  
                      <ajaxToolkit:CalendarExtender ID="datetimeEndTextBox_CalendarExtender" runat="server" 
                          BehaviorID="TextBox3_CalendarExtender" TargetControlID="datetimeEndTextBox" Format="yyyy/MM/dd"/><br /><br />
        <asp:Panel ID="Panel2" runat="server" BorderColor="#999999" BorderStyle="Solid" BackColor="#CCCCCC" BorderWidth="2px">
            <table class="auto-style4">
            <tr>
            <td align="right" class="auto-style11">
                <asp:Label ID="lblqrcode" runat="server" Font-Bold="True" Text="LOT NO."></asp:Label>
            </td>
            <td align="left" class="auto-style12">
                <asp:TextBox ID="LotNoTextBox" runat="server" CssClass="auto-style10" Width="122px" Height="16px"></asp:TextBox>       
            <td align="right" class="auto-style11">
                M/C No&nbsp; </td>
            <td align="left" class="auto-style12">
                <asp:DropDownList ID="MCNoDropDownList" runat="server" DataSourceID="MCNoSqlDataSource" DataTextField="MCNo" DataValueField="MCNo" Height="22px" Width="122px">
                    <asp:ListItem>ALL55</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="MCNoSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT DISTINCT MCNo FROM FTSetupReport"></asp:SqlDataSource>
            </td>
            <td align="right" class="auto-style11">
                &nbsp;Package&nbsp; </td>
            <td align="left" class="auto-style12">
                <asp:DropDownList ID="Package" runat="server" DataSourceID="PackageSqlDataSource" DataTextField="AssyName" DataValueField="AssyName">
                    <asp:ListItem Value="%">Package</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="PackageSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT AssyName FROM Package"></asp:SqlDataSource>
            </td>
            <td align="right" class="auto-style11">
                 Device</td>
            <td align="left" class="auto-style3">
                <asp:DropDownList ID="Device" runat="server" DataSourceID="DeviceSqlDataSource" DataTextField="Name" DataValueField="Name" Width="122px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="DeviceSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT Name FROM BOM.FTDevice"></asp:SqlDataSource>
           </td>
           </tr>            
           </table><br />
       </asp:Panel><br />
           </div>
                  <input id="Hidden1" type="hidden" />
           </div>
           </div>

     <div class ="auto-style13">
       <table class="auto-style4" __designer:mapid="1f">
            <tr __designer:mapid="20">
                <td align="center" class="auto-style8" __designer:mapid="21">
                <asp:Button ID="searchdata" runat="server" Text="Search" CssClass="btn btn-primary" Font-Bold="True" BackColor="Silver" ForeColor="Black" Width="93px" />
                <asp:Button ID="ExporttoExcelButton" runat="server" Text="Export " CssClass="btn btn-primary" Font-Bold="True" Width="93px" />
               </td>
            </tr>            
        </table>&nbsp;<br /><br />

        <center><asp:GridView ID="SearchDataGridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#666699" BorderStyle="Inset" BorderWidth="3px" CellPadding="4" DataSourceID="SearchDataSqlDataSource" ForeColor="Black" GridLines="Vertical" DataKeyNames="MCNo">
             <AlternatingRowStyle BackColor="White" />
             <Columns>
                     <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:Label ID="labelNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'/>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:BoundField DataField="MCNo" HeaderText="MCNo" SortExpression="MCNo" ReadOnly="True" />
                     <asp:BoundField DataField="LotNo" HeaderText="LotNo" SortExpression="LotNo" />
                     <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" />
                     <asp:BoundField DataField="DeviceName" HeaderText="DeviceName" SortExpression="DeviceName" />
                     <asp:BoundField DataField="TesterType" HeaderText="TesterType" SortExpression="TesterType" />
                     <asp:BoundField DataField="SetupStartDate" HeaderText="SetupStartDate" SortExpression="SetupStartDate" />
                     <asp:BoundField DataField="SetupEndDate" HeaderText="SetupEndDate" SortExpression="SetupEndDate" />                                
                     <asp:BoundField DataField="MTTR" HeaderText="MTTR" SortExpression="MTTR" ReadOnly="True" />                
                      <asp:BoundField DataField="SetupStatus" HeaderText="SetupStatus" SortExpression="SetupStatus" />
                      <asp:BoundField DataField="ProgramName" HeaderText="ProgramName" SortExpression="ProgramName" />
                      <asp:BoundField DataField="TestFlow" HeaderText="TestFlow" SortExpression="TestFlow" />
             </Columns>

                     <FooterStyle BackColor="#CCCC99" />
                     <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                     <RowStyle BackColor="#F7F7DE" />
                     <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#FBFBF2" />
                     <SortedAscendingHeaderStyle BackColor="#848384" />
                     <SortedDescendingCellStyle BackColor="#EAEAD3" />
                     <SortedDescendingHeaderStyle BackColor="#575357" />
              </asp:GridView></center>

        <td align="center" class="auto-style8" __designer:mapid="21">

              <asp:SqlDataSource ID="SearchDataSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" 
                  SelectCommand="SELECT MCNo, LotNo, PackageName, DeviceName, TesterType, SetupStartDate, SetupEndDate, DATEDIFF(MINUTE, SetupStartDate, SetupEndDate) AS MTTR,SetupStatus, ProgramName, TestFlow 
FROM FTSetupReportHistory WHERE (LotNo LIKE '%' + @LotNo + '%') AND (PackageName LIKE '%' + @PackageName + '%') AND (MCNo LIKE '%' + @MCNo + '%') AND 
(SetupStartDate BETWEEN @Date1 AND @Date2) ORDER BY SetupStartDate">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="datetimeStartTextBox" DefaultValue="" Name="Date1" PropertyName="Text" />
                      <asp:ControlParameter ControlID="datetimeEndTextBox" Name="Date2" PropertyName="Text" />
                      <asp:ControlParameter ControlID="LotNoTextBox" DefaultValue="%" Name="LotNo" PropertyName="Text" />
                      <asp:ControlParameter ControlID="Package" DefaultValue="%" Name="PackageName" PropertyName="SelectedValue" />
                      <asp:ControlParameter ControlID="MCNoDropDownList" DefaultValue="%" Name="MCNo" PropertyName="SelectedValue" />
                  </SelectParameters>
         </asp:SqlDataSource>
         <br /> <center>
             <br />
             <br />
             <br />
         </center>
             <br />
             &nbsp;<br />      
     </div>
     <script type="text/javascript">
              $(function() {
                $('#datetimepicker1').datetimepicker({
                  language: 'pt-BR'
                });
              });
      </script>
</asp:Content>
