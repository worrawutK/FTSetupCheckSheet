<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ShowDataSetup.aspx.vb" Inherits="Report_CheckSheet.ShowDataSetup" %>

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

        .auto-style2 {
            height: 22px;
            text-align: center;
        }

        .auto-style3 {
            animation-name: rotate;
            animation-duration: 10s;
            animation-iteration-count: infinite;
            text-align: center;
        }

        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 100%;
        }
        </style>


    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>

    <ul class="nav nav-pills nav-justified">
        <li><a href="PrintSetupFT.aspx">Upload Picture for Shoko</a></li>
        <li class="active"><a href="ShowDataSetup.aspx">MONITORING</a></li>
        <li><a href="ShowDataSetupHistory.aspx">Search Data History</a></li>
    </ul>
    <br />
    <hr />
    <br />

    <div class="form-group ">
        <h1 class="login-title" style="font-family: 'Waffle Regular'; border: solid; border-radius: 10px; font-weight: bold; text-align: center;" aria-hidden="False">&nbsp;FT PROCESS &quot; MONITORING &quot;</h1>
        <%--<hr />--%>
        <br />
        <br />
        <table style="text-align: center" class="auto-style5">
            <tr>
                <td>
                    <asp:Image class="auto-style2" ID="Image2" runat="server" Height="30px" ImageUrl="~/images/icon_.png" Width="36px" />&nbsp;&nbsp;
                   <asp:Label ID="LabelConfirmed" runat="server" Text="  CONFIRMED" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Image class="auto-style3" ID="Image1" runat="server" Height="30px" ImageUrl="~/images/icon_Waiting1.png" Width="36px" />&nbsp;&nbsp;
                   <asp:Label ID="LabelWaiting" runat="server" Text="  WAITING" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Image class="auto-style3" ID="Image3" runat="server" Height="30px" ImageUrl="~/images/icon_Canceled.png" Width="36px" />&nbsp;&nbsp;
                   <asp:Label ID="LabelCanceled" runat="server" Text="  CANCELED" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />

        <div class="auto-style4">

            <div>
            <asp:GridView ID="dataCheckSheetGridView" runat="server" AutoGenerateColumns="False"
                DataSourceID="dataFtsetupchecksheetSqlDataSource" BackColor="White" BorderColor="#666666" BorderStyle="Inset"
                BorderWidth="3px" CellPadding="3" ForeColor="Black" AllowPaging="True" Font-Names="Verdana" GridLines="Vertical" DataKeyNames="MCNo" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>

                     <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:Label ID="labelNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'/>&nbsp;
                         </ItemTemplate>
                    </asp:TemplateField>
   
                    <asp:BoundField DataField="MCNo" HeaderText="MCNo" SortExpression="MCNo" />
                    <asp:BoundField DataField="LotNo" HeaderText="LotNo" SortExpression="LotNo" />
                    <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" />
                    <asp:BoundField DataField="DeviceName" HeaderText="DeviceName" SortExpression="DeviceName" />
                    <asp:BoundField DataField="ProgramName" HeaderText="ProgramName" SortExpression="ProgramName" />
                    <asp:BoundField DataField="TesterType" HeaderText="TesterType" SortExpression="TesterType" />
                    <asp:BoundField DataField="TestFlow" HeaderText="TestFlow" SortExpression="TestFlow" />

                    <asp:BoundField DataField="StatusShokoOP" HeaderText="StatusShokoOP" SortExpression="StatusShonoOP" Visible="False"  />

                    <asp:BoundField DataField="SetupStatus" HeaderText="SetupStatus" SortExpression="SetupStatus"  Visible="False" />

                    <asp:BoundField DataField="SetupStartDate" HeaderText="SetupStartDate" SortExpression="SetupStartDate" />
                    <asp:BoundField DataField="SetupEndDate" HeaderText="SetupEndDate" SortExpression="SetupEndDate" />
                    
                    <asp:TemplateField HeaderText="SetupStartDate" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbSetupStartDate" runat="server" Text='<%# Eval("SetupStartDate")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SetupEndDate" Visible="False">
                        <ItemTemplate>
                           <asp:Label ID="lbSetupEndDate" runat="server" Text='<%# Eval("SetupEndDate")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="SetupStatus" HeaderText="SetupStatus" SortExpression="SetupStatus" Visible="False" />

                    <asp:TemplateField HeaderText="MTTR">
                        <ItemTemplate>
                           <asp:Label ID="lbMTTR" runat="server" Text="" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Report">
                        <ItemTemplate>
                            <asp:HyperLink ID="link" runat="server">
                                <asp:Image ID="Image2" runat="server" Height="35px" ImageUrl="" Width="36px" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Shoko">
                        <ItemTemplate>
                            <asp:HyperLink ID="linkReport" runat="server">
                                <asp:Image ID="Image3" runat="server" Height="35px" ImageUrl="" Width="36px" />                           
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Confirmed" >
                        <ItemTemplate>
                            <asp:HyperLink ID="linkConfirmed" runat="server">
                                <asp:Image ID="Image4" runat="server" Height="35px" ImageUrl="" Width="36px" />
                            </asp:HyperLink>
                        </ItemTemplate>            
                    </asp:TemplateField>

                </Columns>

                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </div>
            <asp:SqlDataSource ID="dataFtsetupchecksheetSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Report_CheckSheet.My.MySettings.DBxConnectionString %>" SelectCommand="SELECT MCNo, LotNo, PackageName, DeviceName, ProgramName, TesterType, TestFlow, StatusShonoOP, SetupStatus, SetupStartDate, SetupEndDate FROM FTSetupReport  WHERE (LotNo &lt;&gt; '') AND (SetupStatus = 'CONFIRMED') AND MCNo Like @MCNo ORDER BY SetupStartDate DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="MCNoTextBox" DefaultValue="%" Name="MCNo" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
      
        <div class="auto-style2">       
            <asp:TextBox ID="MCNoTextBox" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Font-Bold="True" ForeColor="#009933" Text="Search" />      
        </div>
      </div>
    </div>
    <div class="panel">
        <asp:Button ID="ButtonPrevious" CssClass="btn btn-default pull-left" runat="server" Text="Previous" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
        <asp:Button ID="ButtonNext" CssClass="btn btn-default pull-right" runat="server" Text="Next" BorderStyle="Groove" BorderColor="Black" BorderWidth="2" />
        </div> <br />
     </div> 
    </div>

</asp:Content>


