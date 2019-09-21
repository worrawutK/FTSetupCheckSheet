Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class ShowDataSetup
    Inherits System.Web.UI.Page

    Private Sub dataCheckSheetGridView_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dataCheckSheetGridView.RowDataBound
        If e.Row.RowIndex >= 0 Then
            Dim rv As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim row As DataRow = rv.Row
            Dim img2 As WebControls.Image = DirectCast(e.Row.FindControl("Image2"), WebControls.Image)
            Dim img3 As WebControls.Image = DirectCast(e.Row.FindControl("Image3"), WebControls.Image)
            Dim img4 As WebControls.Image = DirectCast(e.Row.FindControl("Image4"), WebControls.Image)
            Dim img5 As WebControls.Image = DirectCast(e.Row.FindControl("Image5"), WebControls.Image)


            Dim link1 As HyperLink = DirectCast(e.Row.FindControl("linkReport"), HyperLink)

            Dim lbSetupStartDate As Label = DirectCast(e.Row.FindControl("lbSetupStartDate"), Label)
            Dim lbSetupEndDate As Label = DirectCast(e.Row.FindControl("lbSetupEndDate"), Label)
            Dim lbMTTR As Label = DirectCast(e.Row.FindControl("lbMTTR"), Label)



            Dim linkConfirmed As HyperLink = DirectCast(e.Row.FindControl("linkConfirmed"), HyperLink)
            'linkConfirmed.NavigateUrl = "ConfirmedReport.aspx"

            If row("StatusShonoOP").ToString = "1" Then
                img4.ImageUrl = "~/images/user_valid-512.png"
                linkConfirmed.NavigateUrl = "ConfirmedReport.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("StatusShonoOP").ToString <> "" Then
                img4.ImageUrl = "~/images/confirm-approve-certificate-document-rules-booklet-manual-512.png"
                img4.CssClass = "animationStatus"

            ElseIf row("StatusShonoOP").ToString = ""
                img4.ImageUrl = "~/images/confirm-approve-certificate-document-rules-booklet-manual-512.png"
                img4.CssClass = "animationStatus"
            End If



            Dim link As HyperLink = DirectCast(e.Row.FindControl("link"), HyperLink)

            If row("SetupStatus").ToString = "CANCELED" Then
                img2.ImageUrl = "~/images/icon_Canceled.png"
                img2.CssClass = "animationStatus"

            ElseIf row("SetupStatus").ToString = "WAITING" Then
                img2.ImageUrl = "~/images/icon_Waiting1.png"
                img2.CssClass = "animationStatus"
                link.NavigateUrl = "SetupConfirm.aspx"

            ElseIf row("SetupStatus").ToString = "CONFIRMED"
                img2.ImageUrl = "~/images/icon_.png"
                link.NavigateUrl = "OpenCheckSheet.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString
            End If



            Dim linkReport As HyperLink = DirectCast(e.Row.FindControl("linkReport"), HyperLink)

            If row("StatusShonoOP").ToString = "1" Then
                img3.ImageUrl = "~/images/icon_Shono.png"
                linkReport.NavigateUrl = "OpenPDF_zion.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("StatusShonoOP").ToString <> "" Then
                img3.ImageUrl = "~/images/iconWaitingReport.png"
                img3.CssClass = "animationStatus"
                linkReport.NavigateUrl = "PrintSetupFT.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString

            ElseIf row("StatusShonoOP").ToString = ""
                img3.ImageUrl = "~/images/iconWaitingReport.png"
                img3.CssClass = "animationStatus"
                linkReport.NavigateUrl = "PrintSetupFT.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString
            End If


            Dim StartDate As DateTime = DateTime.Now
            Dim EndDate As DateTime = DateTime.Now
                If (lbSetupStartDate.Text.Trim() <> "") Then
                    StartDate = DateTime.Parse(lbSetupStartDate.Text.Trim())
                End If
                If (lbSetupEndDate.Text.Trim() <> "") Then
                    EndDate = DateTime.Parse(lbSetupEndDate.Text.Trim())
                End If

            Dim MTTR As Integer = (EndDate - StartDate).Minutes
            lbMTTR.Text = MTTR.ToString()

        End If
    End Sub

    Protected Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        Response.Redirect("~/ShowDataSetup2.aspx")
    End Sub

    Protected Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        Response.Redirect("~/ShowDataSetup3.aspx")
    End Sub

    'If My.Computer.FileSystem.FileExists("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" & row("LotNo").ToString & "_" & row("MCNo").ToString & ".pdf") = True Then
    '    'Process.Start("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" & Request.QueryString("LotNo") & "_" & Request.QueryString("MCNo") & ".pdf")

    '    linkReport.NavigateUrl = "OpenPDFfile.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString
    '    img3.ImageUrl = "~/images/icon_Shono.png"
    'Else
    '    linkReport.NavigateUrl = "PrintSetupFT.aspx?LotNo=" + row("LotNo").ToString + "&MCNo=" + row("MCNo").ToString
    '    img3.ImageUrl = "~/images/iconWaitingReport.png"
    'End If

End Class