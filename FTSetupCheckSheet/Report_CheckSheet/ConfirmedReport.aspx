<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConfirmedReport.aspx.vb" Inherits="Report_CheckSheet.ConfirmedReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <style>
        .animationStatus {
            animation-name: rotate;
            animation-duration: 5s;
            animation-iteration-count: infinite;
        }

        @keyframes rotate {
            0% {
                transform: rotateY(0deg);
            }

            100% {
                transform: rotateY(360deg);
            }
        }
      
         .auto-style1 {
             text-align: left;
         }   
         .auto-style2 {
             border-radius: 4px;
             -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
             box-shadow: 0 1px 1px rgba(0, 0, 0, 0.05);
             text-align: center;
             border: 1px solid transparent;
             margin-bottom: 20px;
             background-color: #ffffff;
         }
    </style>


      <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
      </div>

      <div class ="row">
          <h1 style="font-family: 'Waffle Regular'; font-weight: bold; color: #0094ff;" class="auto-style1">Check Confirmed Report&nbsp;
          <asp:ImageButton ID="ImageButton1" runat="server" Height="34px" ImageUrl="~/images/user_valid-512.png" Width="38px" />
          </h1>
     <hr />
          <br />          
      </div>

          <table style="text-align: center" class="auto-style5" align="center">
            <tr>
                <td>
                    <asp:Image class="animationStatus" ID="Image2" runat="server" Height="35px" ImageUrl="~/images/icon_Shono.png" Width="40px" />&nbsp;&nbsp;
                   <asp:Label ID="LabelConfirmed" runat="server" Text="  CONFIRMED FINISH" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    &nbsp;&nbsp;
                   </td>
                <td>
                    <asp:Image class="auto-style3" ID="Image3" runat="server" Height="36px" ImageUrl="~/images/camera-icon.png" Width="37px" />&nbsp;&nbsp;
                   <asp:Label ID="LabelCanceled" runat="server" Text="NOT CONFIRMED" Font-Bold="True"></asp:Label>
                </td>
            </tr>        
         </table>
    <hr />
     <br />

          <div style="text-align: center">
              <asp:GridView ID="ConfirmedReportGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#140F12" BorderWidth="2px" CellPadding="3" DataSourceID="ConfirmedReportSqlDataSource" GridLines="Vertical" BorderStyle="Solid" ForeColor="Black">
                  <AlternatingRowStyle BackColor="#e6c5df" />
                  <Columns>
                      <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:Label ID="labelNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'/>&nbsp;
                         </ItemTemplate>
                      </asp:TemplateField>

                      <asp:BoundField DataField="MCNo" HeaderText="MCNo" SortExpression="MCNo" />
                      <asp:BoundField DataField="LotNo" HeaderText="LotNo" SortExpression="LotNo" />  

                    

                      <asp:BoundField DataField="DeviceName" HeaderText="DeviceName" SortExpression="DeviceName" />

                      <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" />
                      <asp:BoundField DataField="TestFlow" HeaderText="TestFlow" SortExpression="TestFlow" />

                    

                      <asp:BoundField DataField="SetupStatus" HeaderText="SetupStatus" SortExpression="SetupStatus" Visible="False" />
                      <asp:BoundField DataField="SetupStartDate" HeaderText="SetupStartDate" SortExpression="SetupStartDate" />  
                      <asp:BoundField DataField="SetupEndDate" HeaderText="SetupEndDate" SortExpression="SetupEndDate"/>
                      <asp:BoundField DataField="ConfirmedCheckSheetOp" HeaderText="ConfirmedCheckSheetOp" SortExpression="ConfirmedCheckSheetOp" Visible="False"/>

                      <asp:BoundField DataField="ConfirmedCheckSheetSection" HeaderText="ConfirmedCheckSheetSection" SortExpression="ConfirmedCheckSheetSection" Visible="False" />
                      <asp:BoundField DataField="ConfirmedCheckSheetGL" HeaderText="ConfirmedCheckSheetGL" SortExpression="ConfirmedCheckSheetGL" Visible="False" />
                      <asp:BoundField DataField="StatusShonoOP" HeaderText="StatusShonoOP" SortExpression="StatusShonoOP" Visible="False" />
                      <asp:BoundField DataField="ConfirmedShonoOp" HeaderText="ConfirmedShonoOp" SortExpression="ConfirmedShonoOp" Visible="False" />
                      <asp:BoundField DataField="ConfirmedShonoSection" HeaderText="ConfirmedShonoSection" SortExpression="ConfirmedShonoSection" Visible="False" />
                      <asp:BoundField DataField="ConfirmedShonoGL" HeaderText="ConfirmedShonoGL" SortExpression="ConfirmedShonoGL" Visible="False" />

                      <asp:TemplateField HeaderText="CS_OP" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkConfirmedOP" runat="server">
                                <asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="CS_GL" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkConfirmedGL" runat="server">
                                <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>
                
                      <asp:TemplateField HeaderText="CS_Sec" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkConfirmedSection" runat="server">
                                <asp:Image ID="Image3" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="ShoOP" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkShonoOp" runat="server">
                                <asp:Image ID="Image4" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="ShoGL" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkSnonoGl" runat="server">
                                <asp:Image ID="Image5" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>            

                      <asp:TemplateField HeaderText="ShoSec" >
                         <ItemTemplate>
                            <asp:HyperLink ID="linkShonoSection" runat="server">
                                <asp:Image ID="Image6" runat="server" Height="30px" ImageUrl="" Width="30px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="SetUp" >
                         <ItemTemplate>
                            <asp:HyperLink ID="linkSetup" runat="server">
                                <asp:Image ID="Image7" runat="server" Height="30px" ImageUrl="" Width="33px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Shono" >
                         <ItemTemplate>
                            <asp:HyperLink ID="linkShono" runat="server">
                                <asp:Image ID="Image8" runat="server" Height="30px" ImageUrl="" Width="33px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                      </asp:TemplateField>

                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView>
              .</div>
          <asp:SqlDataSource ID="ConfirmedReportSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Report_CheckSheet.My.MySettings.DBxConnectionString %>" SelectCommand="SELECT MCNo, LotNo, PackageName, SetupStatus, SetupStartDate, SetupEndDate, ConfirmedCheckSheetOp, ConfirmedCheckSheetSection, ConfirmedCheckSheetGL, StatusShonoOP, ConfirmedShonoOp, ConfirmedShonoSection, ConfirmedShonoGL, TestFlow, DeviceName FROM FTSetupReportHistory WHERE (LotNo LIKE @LotNo) AND (SetupStatus = 'CONFIRMED') AND (MCNo LIKE @MCNo) ORDER BY SetupEndDate DESC">
              <SelectParameters>
                  <asp:QueryStringParameter DefaultValue="%" Name="LotNo" QueryStringField="LotNo" />
                  <asp:QueryStringParameter DefaultValue="%" Name="MCNo" QueryStringField="MCNo" />
              </SelectParameters>
     </asp:SqlDataSource>

        
    
        <div class="auto-style2">
            
            <asp:TextBox ID="MCNoTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Font-Bold="True" ForeColor="#CC6699" Text="Search" />
            
        </div>

</asp:Content>
