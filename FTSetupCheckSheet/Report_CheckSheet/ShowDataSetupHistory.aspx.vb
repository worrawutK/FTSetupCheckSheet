Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Drawing
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports System.Collections.Generic

Public Class ShowDataSetupHistory
    Inherits System.Web.UI.Page
    Dim statusG As String

    Private Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles SearchDataGridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            statusG = CStr(DataBinder.Eval(e.Row.DataItem, "SetupStatus"))
            If statusG = "CONFIRMED" Then
                e.Row.BackColor = Color.LightSeaGreen
            ElseIf statusG = "WAITING" Then
                e.Row.BackColor = Color.LightGray
            ElseIf statusG = "CANCELED"
                e.Row.BackColor = Color.Red
            End If
        End If

        'If e.Row.RowIndex >= 0 Then

        '    Dim StartDate As DateTime
        '    Dim EndDate As DateTime

        '    Dim lbSetupStartDate As Label = DirectCast(e.Row.FindControl("lbSetupStartDate"), Label)
        '    Dim lbSetupEndDate As Label = DirectCast(e.Row.FindControl("lbSetupEndDate"), Label)
        '    Dim lbMTTR As Label = DirectCast(e.Row.FindControl("lbMTTR"), Label)

        '    If (lbSetupStartDate.Text.Trim() <> "") Then
        '        StartDate = DateTime.Parse(lbSetupStartDate.Text.Trim())
        '    End If
        '    If (lbSetupEndDate.Text.Trim() <> "") Then
        '        EndDate = DateTime.Parse(lbSetupEndDate.Text.Trim())
        '    End If

        '    Dim MTTR As Integer = (EndDate - StartDate).Minutes
        '    lbMTTR.Text = MTTR.ToString()
        'End If

    End Sub

    Private Sub MCNoDropDownList_DataBound(sender As Object, e As EventArgs) Handles MCNoDropDownList.DataBound
        MCNoDropDownList.Items.Insert(0, New ListItem("ALL", "%"))
    End Sub

    Private Sub Device_DataBound(sender As Object, e As EventArgs) Handles Device.DataBound
        Device.Items.Insert(0, New ListItem("ALL", "%"))
    End Sub

    Private Sub Package_DataBound(sender As Object, e As EventArgs) Handles Package.DataBound
        Package.Items.Insert(0, New ListItem("ALL", "%"))
    End Sub

    Protected Sub LotNoTextBox_TextChanged(sender As Object, e As EventArgs) Handles LotNoTextBox.TextChanged

        If LotNoTextBox.Text.Length = 252 Then
            Dim textQR As String = LotNoTextBox.Text.Substring(21, 30)

        ElseIf LotNoTextBox.Text.Length = 11
            LotNoTextBox.Text.Trim()
        End If
    End Sub

    Protected Sub ExporttoExcelButton_Click(sender As Object, e As EventArgs) Handles ExporttoExcelButton.Click

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=CheckSheetData.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        SearchDataGridView1.AllowPaging = False
        SearchDataGridView1.DataBind()

        'Check datagridview having data or not
        If ((SearchDataGridView1.Columns.Count = 0) Or (SearchDataGridView1.Rows.Count = 0)) Then
            Exit Sub
        End If

        Dim sb As New StringBuilder()
        For k As Integer = 0 To SearchDataGridView1.Columns.Count - 1
            'add separator
            sb.Append(SearchDataGridView1.Columns(k).HeaderText + ","c)
        Next

        'append new line
        sb.Append(vbNewLine)
        For i As Integer = 0 To SearchDataGridView1.Rows.Count - 1
            For k As Integer = 0 To SearchDataGridView1.Columns.Count - 1
                'add separator
                Dim str As String = HttpUtility.HtmlDecode(SearchDataGridView1.Rows(i).Cells(k).Text) + ","c
                sb.Append(str)
            Next
            'append new line
            sb.AppendLine()

        Next

        Response.Output.Write(sb.ToString())
        Response.Flush()
        Response.End()

    End Sub


    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Class



