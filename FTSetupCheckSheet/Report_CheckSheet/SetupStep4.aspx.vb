﻿Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient

Public Class SetupStep4
    Inherits System.Web.UI.Page

    Protected Sub Dutcard1TextBox_TextChanged(sender As Object, e As EventArgs) Handles DutcardATextBox.TextChanged
        DutcardBTextBox.Focus()

        If Not String.IsNullOrEmpty(DutcardATextBox.Text) Then
            Dim qrName As String = DutcardATextBox.Text.ToUpper
            m_Data.DutcardAQRcode = DutcardATextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_DUTCARD)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.DutcardA = row("SubType").ToString().ToUpper
                Else
                    m_Data.DutcardA = ""
                End If

                DutcardATextBox.Text = m_Data.DutcardA

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Protected Sub Dutcard2TextBox_TextChanged(sender As Object, e As EventArgs) Handles DutcardBTextBox.TextChanged
        BridgecableATextBox.Focus()

        If Not String.IsNullOrEmpty(DutcardBTextBox.Text) Then
            Dim qrName As String = DutcardBTextBox.Text.ToUpper
            m_Data.DutcardBQRcode = DutcardBTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_DUTCARD)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.DutcardB = row("SubType").ToString().ToUpper
                Else
                    m_Data.DutcardB = ""
                End If

                DutcardBTextBox.Text = m_Data.DutcardB

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Protected Sub Bridge1TextBox_TextChanged(sender As Object, e As EventArgs) Handles BridgecableATextBox.TextChanged
        BridgecableBTextBox.Focus()

        If Not String.IsNullOrEmpty(BridgecableATextBox.Text) Then
            Dim qrName As String = BridgecableATextBox.Text.ToUpper
            m_Data.BridgecableAQRcode = BridgecableATextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BRIDGE_CABLE)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.BridgecableA = row("SubType").ToString().ToUpper
                Else
                    m_Data.BridgecableA = ""
                End If

                BridgecableATextBox.Text = m_Data.BridgecableA
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)
        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If

        If Not IsPostBack Then
            DutcardATextBox.Text = m_Data.DutcardA
            DutcardBTextBox.Text = m_Data.DutcardB
            BridgecableATextBox.Text = m_Data.BridgecableA
            BridgecableBTextBox.Text = m_Data.BridgecableB
        End If
        DutcardATextBox.Focus()
    End Sub

    Protected Sub Bridge2TextBox_TextChanged(sender As Object, e As EventArgs) Handles BridgecableBTextBox.TextChanged

        If Not String.IsNullOrEmpty(BridgecableBTextBox.Text) Then
            Dim qrName As String = BridgecableBTextBox.Text.ToUpper
            m_Data.BridgecableBQRcode = BridgecableBTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BRIDGE_CABLE)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.BridgecableB = row("SubType").ToString().ToUpper
                Else
                    m_Data.BridgecableB = ""
                End If

                BridgecableBTextBox.Text = m_Data.BridgecableB

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub


    Private Sub UpdateSessionData()
        m_Data.DutcardA = DutcardATextBox.Text
        m_Data.DutcardB = DutcardBTextBox.Text
        m_Data.BridgecableA = BridgecableATextBox.Text
        m_Data.BridgecableB = BridgecableBTextBox.Text

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep5.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep3.aspx")
    End Sub
End Class