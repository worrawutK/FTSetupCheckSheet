Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient

Public Class SetupStep2
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
            ATesternoTextBox.Text = m_Data.TesterNoA
            BTesternoTextBox.Text = m_Data.TesterNoB
            CTesternoTextBox.Text = m_Data.TesterNoC
            DTesternoTextBox.Text = m_Data.TesterNoD
        End If

        ATesternoTextBox.Focus()
    End Sub

    Private Sub UpdateSessionData()
        m_Data.TesterNoA = ATesternoTextBox.Text
        m_Data.TesterNoB = BTesternoTextBox.Text
        m_Data.TesterNoC = CTesternoTextBox.Text
        m_Data.TesterNoD = DTesternoTextBox.Text
        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        If Not TesterNoIsDuplicated() Then
            UpdateSessionData()
            Response.Redirect("~/SetupStep3.aspx")
        End If
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        If Not TesterNoIsDuplicated() Then
            UpdateSessionData()
            Response.Redirect("~/SetupStep1.aspx")
        End If

    End Sub

    Protected Sub ATesternoTextBox_TextChanged(sender As Object, e As EventArgs) Handles ATesternoTextBox.TextChanged
        BTesternoTextBox.Focus()

        If Not String.IsNullOrEmpty(ATesternoTextBox.Text) Then

            Dim qrName As String = ATesternoTextBox.Text.ToUpper
            m_Data.TesterNoAQRcode = ATesternoTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoA = row("Name").ToString()
                Else
                    m_Data.TesterNoA = ""
                End If

                ATesternoTextBox.Text = m_Data.TesterNoA

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Protected Sub BTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles BTesternoTextBox.TextChanged
        CTesternoTextBox.Focus()

        If Not String.IsNullOrEmpty(BTesternoTextBox.Text) Then

            Dim qrName As String = BTesternoTextBox.Text.ToUpper
            m_Data.TesterNoBQRcode = BTesternoTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoB = row("Name").ToString()
                Else
                    m_Data.TesterNoB = ""
                End If

                BTesternoTextBox.Text = m_Data.TesterNoB

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
    End Sub

    Protected Sub CTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles CTesternoTextBox.TextChanged
        DTesternoTextBox.Focus()

        If Not String.IsNullOrEmpty(CTesternoTextBox.Text) Then

            Dim qrName As String = CTesternoTextBox.Text.ToUpper
            m_Data.TesterNoCQRcode = CTesternoTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoC = row("Name").ToString()
                Else
                    m_Data.TesterNoC = ""
                End If

                CTesternoTextBox.Text = m_Data.TesterNoC

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
    End Sub

    Protected Sub DTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles DTesternoTextBox.TextChanged

        If Not String.IsNullOrEmpty(DTesternoTextBox.Text) Then

            Dim qrName As String = DTesternoTextBox.Text.ToUpper
            m_Data.TesterNoDQRcode = DTesternoTextBox.Text

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoD = row("Name").ToString()
                Else
                    m_Data.TesterNoD = ""
                End If

                DTesternoTextBox.Text = m_Data.TesterNoD

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
    End Sub

    Private Function TesterNoIsDuplicated() As Boolean
        'Dim ret As Boolean = False
        'If m_Data.TesterNoA = m_Data.TesterNoB Then
        '    ErrorMessageLabel.Text = "Duplicated Tester No .."
        '    panelError.Style.Item("display") = "block"
        '    ret = True
        'Else
        '    ret = False
        '    panelError.Style.Item("display") = "none"
        'End If
        'Return ret
    End Function

End Class