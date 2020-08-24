﻿Imports System.Data.SqlClient

Public Class SetupStep3
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)
        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If
        If Not IsPostBack Then
            TestBoxATextBox.Text = m_Data.TestBoxA
            TestBoxBTextBox.Text = m_Data.TestBoxB
            TestBoxCTextBox.Text = m_Data.TestBoxC
            TestBoxDTextBox.Text = m_Data.TestBoxD
            TestBoxETextBox.Text = m_Data.TestBoxE
            TestBoxFTextBox.Text = m_Data.TestBoxF
            TestBoxGTextBox.Text = m_Data.TestBoxG
            TestBoxHTextBox.Text = m_Data.TestBoxH
        End If
        TestBoxATextBox.Focus()
    End Sub

    Private Sub UpdateSessionData()
        m_Data.TestBoxA = TestBoxATextBox.Text
        m_Data.TestBoxB = TestBoxBTextBox.Text
        m_Data.TestBoxC = TestBoxCTextBox.Text
        m_Data.TestBoxD = TestBoxDTextBox.Text
        m_Data.TestBoxE = TestBoxETextBox.Text
        m_Data.TestBoxF = TestBoxFTextBox.Text
        m_Data.TestBoxG = TestBoxGTextBox.Text
        m_Data.TestBoxH = TestBoxHTextBox.Text
        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep4.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep2.aspx")
    End Sub

    Protected Sub AboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxATextBox.TextChanged

        TestBoxBTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxATextBox.Text) Then

            Dim qrName As String = TestBoxATextBox.Text.ToUpper
            m_Data.TestBoxAQRcode = TestBoxATextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxA = row("SubType").ToString().ToUpper
                    m_Data.ChannelAFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxA = ""
                    m_Data.ChannelAFTB = ""
                End If

                TestBoxATextBox.Text = m_Data.TestBoxA
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Protected Sub BboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxBTextBox.TextChanged

        TestBoxCTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxBTextBox.Text) Then

            Dim qrName As String = TestBoxBTextBox.Text.ToUpper
            m_Data.TestBoxBQRcode = TestBoxBTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxB = row("SubType").ToString().ToUpper
                    m_Data.ChannelBFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxB = ""
                    m_Data.ChannelBFTB = ""
                End If

                TestBoxBTextBox.Text = m_Data.TestBoxB

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Protected Sub CboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxCTextBox.TextChanged

        TestBoxDTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxCTextBox.Text) Then

            Dim qrName As String = TestBoxCTextBox.Text.ToUpper
            m_Data.TestBoxCQRcode = TestBoxCTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxC = row("SubType").ToString().ToUpper
                    m_Data.ChannelCFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxC = ""
                    m_Data.ChannelCFTB = ""
                End If

                TestBoxCTextBox.Text = m_Data.TestBoxC
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Protected Sub DboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxDTextBox.TextChanged

        If Not String.IsNullOrEmpty(TestBoxDTextBox.Text) Then

            Dim qrName As String = TestBoxDTextBox.Text.ToUpper
            m_Data.TestBoxDQRcode = TestBoxDTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxD = row("SubType").ToString().ToUpper
                    m_Data.ChannelDFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxD = ""
                    m_Data.ChannelDFTB = ""
                End If

                TestBoxDTextBox.Text = m_Data.TestBoxD

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

End Class