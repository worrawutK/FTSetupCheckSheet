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
            TesterTypetext.Text = m_Data.TesterType
            TesternoATextBox.Text = m_Data.TesterNoA
            TesternoBTextBox.Text = m_Data.TesterNoB
            TesternoCTextBox.Text = m_Data.TesterNoC
            TesternoDTextBox.Text = m_Data.TesterNoD

            If m_Data.MCNo.StartsWith("FT") OrElse m_Data.MCNo.StartsWith("TP") Then
                panelTesternoC.Style.Item("display") = "none"
                panelTesternoD.Style.Item("display") = "none"
            End If

            If m_Data.StatusOldEQP Then
                TesternoATextBox.ReadOnly = True
                TesternoBTextBox.ReadOnly = True
                TesternoCTextBox.ReadOnly = True
                TesternoDTextBox.ReadOnly = True
            End If
        End If

        TesternoATextBox.Focus()
    End Sub

    Protected Sub ATesternoTextBox_TextChanged(sender As Object, e As EventArgs) Handles TesternoATextBox.TextChanged

        TesternoBTextBox.Focus()

        If Not String.IsNullOrEmpty(TesternoATextBox.Text) Then

            Dim qrName As String = TesternoATextBox.Text.ToUpper
            m_Data.TesterNoAQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoA = row("Name").ToString()
                Else
                    m_Data.TesterNoA = ""
                    m_Data.TesterNoAQRcode = ""
                End If

                TesternoATextBox.Text = m_Data.TesterNoA
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
        UpdateSessionData()
    End Sub

    Protected Sub BTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles TesternoBTextBox.TextChanged

        TesternoCTextBox.Focus()

        If Not String.IsNullOrEmpty(TesternoBTextBox.Text) Then

            Dim qrName As String = TesternoBTextBox.Text.ToUpper
            m_Data.TesterNoBQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoB = row("Name").ToString()
                Else
                    m_Data.TesterNoB = ""
                    m_Data.TesterNoBQRcode = ""
                End If

                TesternoBTextBox.Text = m_Data.TesterNoB
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
        UpdateSessionData()
    End Sub

    Protected Sub CTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles TesternoCTextBox.TextChanged

        TesternoDTextBox.Focus()

        If Not String.IsNullOrEmpty(TesternoCTextBox.Text) Then

            Dim qrName As String = TesternoCTextBox.Text.ToUpper
            m_Data.TesterNoCQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoC = row("Name").ToString()
                Else
                    m_Data.TesterNoC = ""
                    m_Data.TesterNoCQRcode = ""
                End If

                TesternoCTextBox.Text = m_Data.TesterNoC
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
        UpdateSessionData()
    End Sub

    Protected Sub DTestnoTextBox_TextChanged(sender As Object, e As EventArgs) Handles TesternoDTextBox.TextChanged

        If Not String.IsNullOrEmpty(TesternoDTextBox.Text) Then

            Dim qrName As String = TesternoDTextBox.Text.ToUpper
            m_Data.TesterNoDQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_TESTER)

                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TesterNoD = row("Name").ToString()
                Else
                    m_Data.TesterNoD = ""
                    m_Data.TesterNoDQRcode = ""
                End If

                TesternoDTextBox.Text = m_Data.TesterNoD
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using

        End If
        UpdateSessionData()
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        If UpdateSessionData() Then
            If Not String.IsNullOrWhiteSpace(TesterTypetext.Text) Then
                Response.Redirect("~/SetupStep3.aspx")
            Else
                ShowErrorMessage("TesterType = '" + TesterTypetext.Text + "' กรุณาแสกน Tester No ใหม่อีกครั้ง")
            End If
        End If

        'If Not TesterNoIsDuplicated() Then
        '    UpdateSessionData()
        '    Response.Redirect("~/SetupStep3.aspx")
        'End If
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        If UpdateSessionData() Then
            Response.Redirect("~/SetupStep1.aspx")
        End If

        'If Not TesterNoIsDuplicated() Then
        '    UpdateSessionData()
        '    Response.Redirect("~/SetupStep1.aspx")
        'End If
    End Sub

    Private Function UpdateSessionData() As Boolean

        Dim ret As Boolean = True
        Dim lstTester As New List(Of String)
        Dim lstTesterType As New List(Of String)

        If TesternoATextBox.Text = "" Then 'Data = "" -> Clear Data

            m_Data.TesterNoA = ""
            m_Data.TesterNoAQRcode = ""

        ElseIf m_Data.TesterNoA <> TesternoATextBox.Text Then 'Not Same Data

            TesternoATextBox.BackColor = Drawing.ColorTranslator.FromHtml("#FF9999")
            lstTester.Add(" - Tester No : A")
            ret = False

        End If 'Same Data

        If TesternoBTextBox.Text = "" Then 'Data = "" -> Clear Data

            m_Data.TesterNoB = ""
            m_Data.TesterNoBQRcode = ""

        ElseIf m_Data.TesterNoB <> TesternoBTextBox.Text Then 'Not Same Data

            TesternoBTextBox.BackColor = Drawing.ColorTranslator.FromHtml("#FF9999")
            lstTester.Add(" - Tester No : B")
            ret = False

        End If 'Same Data

        If TesternoCTextBox.Text = "" Then 'Data = "" -> Clear Data

            m_Data.TesterNoC = ""
            m_Data.TesterNoCQRcode = ""

        ElseIf m_Data.TesterNoC <> TesternoCTextBox.Text Then 'Not Same Data

            TesternoCTextBox.BackColor = Drawing.ColorTranslator.FromHtml("#FF9999")
            lstTester.Add(" - Tester No : C")
            ret = False

        End If 'Same Data

        If TesternoDTextBox.Text = "" Then 'Data = "" -> Clear Data

            m_Data.TesterNoD = ""
            m_Data.TesterNoDQRcode = ""

        ElseIf m_Data.TesterNoD <> TesternoDTextBox.Text Then 'Not Same Data

            TesternoDTextBox.BackColor = Drawing.ColorTranslator.FromHtml("#FF9999")
            lstTester.Add(" - Tester No : D")
            ret = False

        End If 'Same Data        

        If ret = False Then
            Dim a As String = ">>> ค่าไม่ถูกต้อง กรุณาแสกนใหม่ <<< <br/>"

            For Each str As String In lstTester
                a = a & str & "<br/>"
            Next

            ShowErrorMessage(a)
            Return ret
        End If

        TesternoATextBox.BackColor = Drawing.Color.White
        TesternoBTextBox.BackColor = Drawing.Color.White
        TesternoCTextBox.BackColor = Drawing.Color.White
        TesternoDTextBox.BackColor = Drawing.Color.White
        HideErrorMessage()

        Dim testerType() As String = {"", "", "", ""}
        Dim int As Integer = 0
        Dim tester As String = ""

        If Not String.IsNullOrWhiteSpace(m_Data.TesterNoAQRcode) Then
            Dim dt As DataTable = DBAccess.GetTesterTypebyQRCode(m_Data.TesterNoAQRcode)
            If dt.Rows.Count = 1 Then
                Dim row As DataRow = dt.Rows(0)
                testerType(0) = row("TesterType").ToString()
            End If
        End If

        If Not String.IsNullOrWhiteSpace(m_Data.TesterNoBQRcode) Then
            Dim dt As DataTable = DBAccess.GetTesterTypebyQRCode(m_Data.TesterNoBQRcode)
            If dt.Rows.Count = 1 Then
                Dim row As DataRow = dt.Rows(0)
                testerType(1) = row("TesterType").ToString()
            End If
        End If

        If Not String.IsNullOrWhiteSpace(m_Data.TesterNoCQRcode) Then
            Dim dt As DataTable = DBAccess.GetTesterTypebyQRCode(m_Data.TesterNoCQRcode)
            If dt.Rows.Count = 1 Then
                Dim row As DataRow = dt.Rows(0)
                testerType(2) = row("TesterType").ToString()
            End If
        End If

        If Not String.IsNullOrWhiteSpace(m_Data.TesterNoDQRcode) Then
            Dim dt As DataTable = DBAccess.GetTesterTypebyQRCode(m_Data.TesterNoDQRcode)
            If dt.Rows.Count = 1 Then
                Dim row As DataRow = dt.Rows(0)
                testerType(3) = row("TesterType").ToString()
            End If
        End If

        If testerType(0) = "" And testerType(1) = "" And testerType(2) = "" And testerType(3) = "" Then
            ret = False
            TesterTypetext.Text = ""
            ShowErrorMessage("ไม่พบ TesterType กรุณาแสกนใหม่อีกครั้ง")
            Return ret
        End If

        For i = 0 To testerType.Length - 1
            If testerType(i) = "" Then
                testerType(i) = "%"
            Else
                tester = testerType(i)
                int += 1
            End If
        Next

        If int = 1 Then
            m_Data.TesterType = tester
        Else
            Dim testerCommon As DataTable
            Try
                testerCommon = DBAccess.GetTesterTypeCommon(testerType(0), testerType(1), testerType(2), testerType(3))

                If testerCommon.Rows.Count = 0 Then

                    m_Data.TesterType = ""

                    If m_Data.MCNo.StartsWith("FT") OrElse m_Data.MCNo.StartsWith("TP") Then
                        ShowErrorMessage(String.Format("TesterTypeCommon not found <br/> TesterType A:={0}<br/> TesterType B:={1}<br/>", testerType(0), testerType(1)))
                    Else
                        ShowErrorMessage(String.Format("TesterTypeCommon not found <br/> TesterType A:={0}<br/> TesterType B:={1}<br/> TesterType C:={2}<br/> TesterType D:={3}<br/>",
                                                                                         testerType(0), testerType(1), testerType(2), testerType(3)))
                    End If

                    ret = False
                ElseIf testerCommon.Rows.Count = 1 Then
                    m_Data.TesterType = testerCommon.Rows(0)("BomTesterType").ToString()

                Else
                    m_Data.TesterType = ""

                    Dim a As String = ">>> พบ TesterTypeCommon " + testerCommon.Rows.Count.ToString() + " rows กรุณาติดต่อ SYSTEM <<< <br/>"

                    For i = 0 To testerCommon.Rows.Count - 1
                        a = a & testerCommon.Rows(i)("BomTesterType").ToString() & "<br/>"
                    Next

                    ret = False
                End If

            Catch ex As Exception
                ShowErrorMessage("Failed to get testerTypeCommon[SetupStep2] :" & ex.Message)
            End Try

        End If

        TesterTypetext.Text = m_Data.TesterType

        Return ret

    End Function

    'Private Function TesterNoIsDuplicated() As Boolean
    '    'Dim ret As Boolean = False
    '    'If m_Data.TesterNoA = m_Data.TesterNoB Then
    '    '    ErrorMessageLabel.Text = "Duplicated Tester No .."
    '    '    panelError.Style.Item("display") = "block"
    '    '    ret = True
    '    'Else
    '    '    ret = False
    '    '    panelError.Style.Item("display") = "none"
    '    'End If
    '    'Return ret
    'End Function

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

End Class