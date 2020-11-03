Imports System.Data.SqlClient

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

            If m_Data.MCNo.StartsWith("FT") Then
                panelTestBoxC.Style.Item("display") = "none"
                panelTestBoxD.Style.Item("display") = "none"
                panelTestBoxE.Style.Item("display") = "none"
                panelTestBoxF.Style.Item("display") = "none"
                panelTestBoxG.Style.Item("display") = "none"
                panelTestBoxH.Style.Item("display") = "none"
            End If

            If m_Data.StatusOldEQP Then
                TestBoxATextBox.ReadOnly = True
                TestBoxBTextBox.ReadOnly = True
                TestBoxCTextBox.ReadOnly = True
                TestBoxDTextBox.ReadOnly = True
                TestBoxETextBox.ReadOnly = True
                TestBoxFTextBox.ReadOnly = True
                TestBoxGTextBox.ReadOnly = True
                TestBoxHTextBox.ReadOnly = True
            End If
        End If

        TestBoxATextBox.Focus()
    End Sub

    Protected Sub AboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxATextBox.TextChanged

        TestBoxBTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxATextBox.Text) Then

            Dim qrName As String = TestBoxATextBox.Text.ToUpper
            m_Data.TestBoxAQRcode = qrName

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
            m_Data.TestBoxBQRcode = qrName

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
            m_Data.TestBoxCQRcode = qrName

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

        TestBoxETextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxDTextBox.Text) Then

            Dim qrName As String = TestBoxDTextBox.Text.ToUpper
            m_Data.TestBoxDQRcode = qrName

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

    Protected Sub EboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxETextBox.TextChanged

        TestBoxFTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxETextBox.Text) Then

            Dim qrName As String = TestBoxETextBox.Text.ToUpper
            m_Data.TestBoxEQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxE = row("SubType").ToString().ToUpper
                    m_Data.ChannelEFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxE = ""
                    m_Data.ChannelEFTB = ""
                End If

                TestBoxETextBox.Text = m_Data.TestBoxE

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Protected Sub FboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxFTextBox.TextChanged

        TestBoxGTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxFTextBox.Text) Then

            Dim qrName As String = TestBoxFTextBox.Text.ToUpper
            m_Data.TestBoxFQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxF = row("SubType").ToString().ToUpper
                    m_Data.ChannelFFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxF = ""
                    m_Data.ChannelFFTB = ""
                End If

                TestBoxFTextBox.Text = m_Data.TestBoxF

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Protected Sub GboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxGTextBox.TextChanged

        TestBoxHTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxGTextBox.Text) Then

            Dim qrName As String = TestBoxGTextBox.Text.ToUpper
            m_Data.TestBoxGQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxG = row("SubType").ToString().ToUpper
                    m_Data.ChannelGFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxG = ""
                    m_Data.ChannelGFTB = ""
                End If

                TestBoxGTextBox.Text = m_Data.TestBoxG

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Protected Sub HboxTextBox_TextChanged(sender As Object, e As EventArgs) Handles TestBoxHTextBox.TextChanged

        'TestBoxHTextBox.Focus()

        If Not String.IsNullOrEmpty(TestBoxHTextBox.Text) Then

            Dim qrName As String = TestBoxHTextBox.Text.ToUpper
            m_Data.TestBoxHQRcode = qrName

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrName, EQUIPMENT_TYPE_ID_BOX, EQUIPMENT_TYPE_ID_BOARD)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    m_Data.TestBoxH = row("SubType").ToString().ToUpper
                    m_Data.ChannelHFTB = row("Name").ToString().ToUpper
                Else
                    m_Data.TestBoxH = ""
                    m_Data.ChannelHFTB = ""
                End If

                TestBoxHTextBox.Text = m_Data.TestBoxH

                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If

    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep4.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep2.aspx")
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

End Class