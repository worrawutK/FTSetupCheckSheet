Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class OpenCheckSheet
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("LotNo") IsNot Nothing And Request.QueryString("MCNo") IsNot Nothing Then
            OpenReport.Src = "OpenShonokoshi.aspx?LotNo=" & Request.QueryString("LotNo") & "&MCNo=" & Request.QueryString("MCNo")
        End If
    End Sub
End Class

