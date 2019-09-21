﻿Imports System.IO
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class SetupStep1
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OISTextBox.Focus()

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)
        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If
        If Not IsPostBack Then
            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypetext.Text = m_Data.TesterType
        End If
    End Sub

    Protected Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        Response.Redirect("~/SetupMain.aspx")
    End Sub

    Protected Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        Response.Redirect("~/SetupStep2.aspx")
    End Sub

    Protected Sub OISTextBox_TextChanged(sender As Object, e As EventArgs) Handles OISTextBox.TextChanged

        If Not String.IsNullOrEmpty(OISTextBox.Text) Then

            '0  1         2   3     4        5       6          7
            'QC,BD62012FS,/-S,AUTO1,SSOP-A24,ICT2000,F2 BD62012,FD62012B
            Dim data As String() = OISTextBox.Text.Split(","c)

            OISTextBox.Text = ""

            If data.Length <> 8 Then
                Exit Sub
            End If

            m_Data.TestFlow = data(3).ToUpper().Trim()
            m_Data.TesterType = data(5).ToUpper().Trim()
            m_Data.SetupStartDate = Now
            m_Data.ProgramName = data(7).ToUpper().Trim()

            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypetext.Text = m_Data.TesterType

            Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

        End If

    End Sub
End Class