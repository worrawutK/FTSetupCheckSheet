<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ChangeSocket.aspx.vb" Inherits="Report_CheckSheet.ChangeSocket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">SET-UP  CHECK  SHEET</h1>
        <h2 class="text-center login-title" style="font-family : 'Waffle Regular'; font-weight: bold;" >ｾｯﾄｱｯﾌﾟﾁｪｯｸｼｰﾄ</h2>
    </div>

    <div class="container">  
      <div class="panel-group">
         <div class="panel panel-success">
            <div class="panel-heading" style="font-style: inherit; font-weight: bold; color: #FFFFFF; background-color:black;text-align:center"> (1)&nbsp;&nbsp;&nbsp; INPUT&nbsp; QRCODE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <asp:TextBox ID="QRcodeTextBox" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox><br />

                <div class="panel panel-danger" id="panelError" runat="server" style="display:none">
                    <div class="panel-heading">ERROR !!</div>
                    <asp:Label ID="ErrorMessageLabel" runat="server" Text="THERE IS ERROR MESSAGE !!!!" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div><br />

                <div class="form-group form-group-lg">
                    <label class="col-sm-2 control-label" for="lg">MACHINE</label>
                    <asp:TextBox ID="TextBoxMCNo" runat="server" CssClass="form-control" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                </div><br />

                <div class="form-group form-group-lg">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH1</label>
                    <asp:TextBox ID="TextBoxSocketCH1" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete1" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />

                <div class="form-group form-group-lg">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH2</label>
                    <asp:TextBox ID="TextBoxSocketCH2" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete2" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />
      
                <div class="form-group form-group-lg">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH3</label>
                    <asp:TextBox ID="TextBoxSocketCH3" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete3" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />

                <div class="form-group form-group-lg">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH4</label>
                    <asp:TextBox ID="TextBoxSocketCH4" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete4" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />

                <div class="form-group form-group-lg" runat="server" id="panelSocket5" style="display:block">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH5</label>
                    <asp:TextBox ID="TextBoxSocketCH5" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete5" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />

                <div class="form-group form-group-lg" runat="server" id="panelSocket6" style="display:block">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH6</label>
                    <asp:TextBox ID="TextBoxSocketCH6" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete6" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />
      
                <div class="form-group form-group-lg" runat="server" id="panelSocket7" style="display:block">
                    <label class="col-sm-2" for="lg">SOCKET CH7</label>
                    <asp:TextBox ID="TextBoxSocketCH7" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete7" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br />

                <div class="form-group form-group-lg" runat="server" id="panelSocket8" style="display:block">
                    <label class="col-sm-2 control-label" for="lg">SOCKET CH8</label>
                    <asp:TextBox ID="TextBoxSocketCH8" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:TextBox>
                    <asp:Button ID="ButtonDelete8" CssClass="btn btn-default pull-right " runat="server" Text="DELETE" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />
                </div><br /><br />

                <div class="form-group form-group-lg" runat="server" id="Div1" style="display:block">
                    <label class="col-sm-1 control-label" for="lg">OP NO*</label>
                    <asp:requiredfieldvalidator id="rfvValidator" runat="server" Enabled="True" ControlToValidate="TextBoxOPNo" ForeColor="Red" ErrorMessage="*Required Field!" />
                    <asp:TextBox ID="TextBoxOPNo" runat="server" CssClass="form-control" Height="30px" AutoPostBack="True" ></asp:TextBox>                    
                    <asp:Button ID="ButtonConfirm" CssClass="btn btn-default pull-right" runat="server" Text="CONFIRM" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" /><br /><br />
                </div><br /><br />                
            </div>
        </div>
    </div>
</asp:Content>
