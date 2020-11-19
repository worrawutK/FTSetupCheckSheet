Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class ConfirmedReport
    Inherits System.Web.UI.Page

    Private Sub ConfirmedReportGridView_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles ConfirmedReportGridView.RowDataBound

        If e.Row.RowIndex >= 0 Then
            Dim rv As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim row As DataRow = rv.Row
            Dim img1 As WebControls.Image = DirectCast(e.Row.FindControl("Image1"), WebControls.Image)
            Dim img2 As WebControls.Image = DirectCast(e.Row.FindControl("Image2"), WebControls.Image)
            Dim img3 As WebControls.Image = DirectCast(e.Row.FindControl("Image3"), WebControls.Image)
            Dim img4 As WebControls.Image = DirectCast(e.Row.FindControl("Image4"), WebControls.Image)
            Dim img5 As WebControls.Image = DirectCast(e.Row.FindControl("Image5"), WebControls.Image)
            Dim img6 As WebControls.Image = DirectCast(e.Row.FindControl("Image6"), WebControls.Image)
            Dim img7 As WebControls.Image = DirectCast(e.Row.FindControl("Image7"), WebControls.Image)
            Dim img8 As WebControls.Image = DirectCast(e.Row.FindControl("Image8"), WebControls.Image)

            Dim linkConfirmedOP As HyperLink = DirectCast(e.Row.FindControl("linkConfirmedOP"), HyperLink)
            Dim linkConfirmedGL As HyperLink = DirectCast(e.Row.FindControl("linkConfirmedGL"), HyperLink)
            Dim linkConfirmedSection As HyperLink = DirectCast(e.Row.FindControl("linkConfirmedSection"), HyperLink)
            Dim linkShonoOp As HyperLink = DirectCast(e.Row.FindControl("linkShonoOp"), HyperLink)
            Dim linkSnonoGl As HyperLink = DirectCast(e.Row.FindControl("linkSnonoGl"), HyperLink)
            Dim linkShonoSection As HyperLink = DirectCast(e.Row.FindControl("linkShonoSection"), HyperLink)
            Dim linkReportCheckSheet As HyperLink = DirectCast(e.Row.FindControl("linkSetup"), HyperLink)
            Dim linkReportShono As HyperLink = DirectCast(e.Row.FindControl("linkShono"), HyperLink)


            If row("ConfirmedCheckSheetOp").ToString = "" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedOP.NavigateUrl = "Login.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetOp").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedOP.NavigateUrl = "Login.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetOp").ToString <> "" Then
                img1.ImageUrl = "~/images/icon_Shono.png"
                img1.CssClass = "animationStatus"
            End If

            '------------------------------------------------------------------------

            If row("ConfirmedCheckSheetGL").ToString = "" Then
                img2.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedGL.NavigateUrl = "LoginGL.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetGL").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedGL.NavigateUrl = "LoginGL.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetGL").ToString <> "" Then
                img2.ImageUrl = "~/images/icon_Shono.png"
                img2.CssClass = "animationStatus"
            End If

            '------------------------------------------------------------------------

            If row("ConfirmedCheckSheetSection").ToString = "" Then
                img3.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedSection.NavigateUrl = "LoginSection.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetSection").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkConfirmedSection.NavigateUrl = "LoginSection.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedCheckSheetSection").ToString <> "" Then
                img3.ImageUrl = "~/images/icon_Shono.png"
                img3.CssClass = "animationStatus"
            End If

            '------------------------------------------------------------------------

            If row("ConfirmedShonoOp").ToString = "" Then
                img4.ImageUrl = "~/images/camera-icon.png"
                linkShonoOp.NavigateUrl = "LoginShono.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoOp").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkShonoOp.NavigateUrl = "LoginShono.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoOp").ToString <> "" Then
                img4.ImageUrl = "~/images/icon_Shono.png"
                img4.CssClass = "animationStatus"
            End If

            '------------------------------------------------------------------------

            If row("ConfirmedShonoGL").ToString = "" Then
                img5.ImageUrl = "~/images/camera-icon.png"
                linkSnonoGl.NavigateUrl = "LoginShonoGL.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoGL").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkSnonoGl.NavigateUrl = "LoginShonoGL.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoGL").ToString <> "" Then
                img5.ImageUrl = "~/images/icon_Shono.png"
                img5.CssClass = "animationStatus"

            End If

            '------------------------------------------------------------------------

            If row("ConfirmedShonoSection").ToString = "" Then
                img6.ImageUrl = "~/images/camera-icon.png"
                linkShonoSection.NavigateUrl = "LoginShonoSection.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoSection").ToString = "NULL" Then
                img1.ImageUrl = "~/images/camera-icon.png"
                linkShonoSection.NavigateUrl = "LoginShonoSection.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("ConfirmedShonoSection").ToString <> "" Then
                img6.ImageUrl = "~/images/icon_Shono.png"
                img6.CssClass = "animationStatus"
            End If

            '------------------------------------------------------------------------

            linkReportCheckSheet.NavigateUrl = "OpenCheckSheet.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString
            img7.ImageUrl = "~/images/icon_.png"
            img7.CssClass = "animationStatus"

            If row("StatusShonoOP").ToString = "1" Then
                img8.ImageUrl = "~/images/icon_Shono.png"
                img8.CssClass = "animationStatus"
                linkReportShono.NavigateUrl = "OpenPDF_zion.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("StatusShonoOP").ToString = "" Then
                img8.ImageUrl = "~/images/iconWaitingReport.png"
                linkReportShono.NavigateUrl = "PrintSetupFT.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("StatusShonoOP").ToString <> ""
                img8.ImageUrl = "~/images/iconWaitingReport.png"
                linkReportShono.NavigateUrl = "PrintSetupFT.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            End If

            '------------------------------------------------------------------------

        End If
    End Sub

    'Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)
    '    Response.Redirect("ShowDataSetup.aspx")
    'End Sub

    Private Sub ConfirmedReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Request.QueryString("MCNo")) Then
            MCNoTextBox.Text = Request.QueryString("MCNo")
            ConfirmedReportSqlDataSource.DataBind()
        End If
    End Sub
End Class

