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
Imports System.Collections.Generic

Public Class SetupStep6
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
            ProgramNameTextBox.Text = m_Data.ProgramName
            TypechangepackageTextBox.Text = m_Data.TypeChangePackage
            QRcodeSocket1TextBox.Text = m_Data.QRCodesocket1
            QRcodeSocket2TextBox.Text = m_Data.QRCodesocket2
            QRcodeSocket3TextBox.Text = m_Data.QRCodesocket3
            QRcodeSocket4TextBox.Text = m_Data.QRCodesocket4

            If m_Data.MCNo.StartsWith("FT") Then
                panelSocket5.Style.Item("display") = "block"
                panelSocket6.Style.Item("display") = "block"
                panelSocket7.Style.Item("display") = "block"
                panelSocket8.Style.Item("display") = "block"
            End If

            If m_Data.StatusOldEQP Then
                TypechangepackageTextBox.ReadOnly = True
                QRcodeSocket1TextBox.ReadOnly = True
                QRcodeSocket2TextBox.ReadOnly = True
                QRcodeSocket3TextBox.ReadOnly = True
                QRcodeSocket4TextBox.ReadOnly = True
                QRcodeSocket5TextBox.ReadOnly = True
                QRcodeSocket6TextBox.ReadOnly = True
                QRcodeSocket7TextBox.ReadOnly = True
                QRcodeSocket8TextBox.ReadOnly = True
            End If

        End If

        TypechangepackageTextBox.Focus()

    End Sub

    Protected Sub ChangepackageTextBox_TextChanged(sender As Object, e As EventArgs) Handles TypechangepackageTextBox.TextChanged

        QRcodeSocket1TextBox.Focus()

        If TypechangepackageTextBox.Text.Length = 252 Then
            Dim changePackage As String = TypechangepackageTextBox.Text.Substring(0, 10)
            m_Data.TypeChangePackage = changePackage.ToUpper
            TypechangepackageTextBox.Text = changePackage.ToUpper
            Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
        End If

    End Sub

    Protected Sub QRSocketTextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket1TextBox.TextChanged

        QRcodeSocket2TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket1TextBox.Text) Then
            Dim qrCode As String = QRcodeSocket1TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel1 = QRcodeSocket1TextBox.Text.ToUpper

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)
                If dt.Rows.Count = 1 Then
                    Dim row As DataRow = dt.Rows(0)
                    Dim data_SmallCode1 As String = row.ItemArray(2).ToString

                    m_Data.QRCodesocket1 = data_SmallCode1
                Else
                    m_Data.QRCodesocket1 = ""
                End If

                QRcodeSocket1TextBox.Text = m_Data.QRCodesocket1
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket2TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket2TextBox.TextChanged

        QRcodeSocket3TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket2TextBox.Text) Then
            Dim qrCodeSocket2 As String = QRcodeSocket2TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel2 = QRcodeSocket2TextBox.Text

            Using at As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket2)
                If at.Rows.Count = 1 Then
                    Dim row1 As DataRow = at.Rows(0)
                    Dim data_SmallCode2 As String = row1.ItemArray(2).ToString

                    m_Data.QRCodesocket2 = data_SmallCode2
                Else
                    m_Data.QRCodesocket2 = ""
                End If
                QRcodeSocket2TextBox.Text = m_Data.QRCodesocket2
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket3TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket3TextBox.TextChanged

        QRcodeSocket4TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket3TextBox.Text) Then
            Dim qrCodeSocket3 As String = QRcodeSocket3TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel3 = QRcodeSocket3TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket3)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode3 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket3 = data_SmallCode3
                Else
                    m_Data.QRCodesocket3 = ""
                End If
                QRcodeSocket3TextBox.Text = m_Data.QRCodesocket3
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket4TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket4TextBox.TextChanged

        QRcodeSocket5TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket4TextBox.Text) Then
            Dim qrCodeSocket4 As String = QRcodeSocket4TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel4 = QRcodeSocket4TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket4)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode4 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket4 = data_SmallCode4
                Else
                    m_Data.QRCodesocket4 = ""
                End If
                QRcodeSocket4TextBox.Text = m_Data.QRCodesocket4
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket5TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket5TextBox.TextChanged

        QRcodeSocket6TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket5TextBox.Text) Then
            Dim qrCodeSocket5 As String = QRcodeSocket5TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel5 = QRcodeSocket5TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket5)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode5 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket5 = data_SmallCode5
                Else
                    m_Data.QRCodesocket5 = ""
                End If
                QRcodeSocket5TextBox.Text = m_Data.QRCodesocket5
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket6TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket6TextBox.TextChanged

        QRcodeSocket7TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket6TextBox.Text) Then
            Dim qrCodeSocket6 As String = QRcodeSocket6TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel6 = QRcodeSocket6TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket6)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode6 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket6 = data_SmallCode6
                Else
                    m_Data.QRCodesocket6 = ""
                End If
                QRcodeSocket6TextBox.Text = m_Data.QRCodesocket6
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket7TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket7TextBox.TextChanged

        QRcodeSocket8TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket7TextBox.Text) Then
            Dim qrCodeSocket7 As String = QRcodeSocket7TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel7 = QRcodeSocket7TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket7)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode7 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket7 = data_SmallCode7
                Else
                    m_Data.QRCodesocket7 = ""
                End If
                QRcodeSocket7TextBox.Text = m_Data.QRCodesocket7
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Protected Sub QRcodeSocket8TextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeSocket8TextBox.TextChanged

        'QRcodeSocket8TextBox.Focus()

        If Not String.IsNullOrEmpty(QRcodeSocket8TextBox.Text) Then
            Dim qrCodeSocket8 As String = QRcodeSocket8TextBox.Text.ToUpper
            m_Data.QRCodesocketChannel8 = QRcodeSocket8TextBox.Text

            Using ot As DataTable = DBAccess.GetOSPSocketSystem(qrCodeSocket8)
                If ot.Rows.Count = 1 Then
                    Dim row2 As DataRow = ot.Rows(0)
                    Dim data_SmallCode8 As String = row2.ItemArray(2).ToString

                    m_Data.QRCodesocket8 = data_SmallCode8
                Else
                    m_Data.QRCodesocket8 = ""
                End If
                QRcodeSocket7TextBox.Text = m_Data.QRCodesocket8
                Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
            End Using
        End If
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet1.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep5.aspx")
    End Sub

    Private Sub UpdateSessionData()
        m_Data.TypeChangePackage = TypechangepackageTextBox.Text
        m_Data.QRCodesocket1 = QRcodeSocket1TextBox.Text
        m_Data.QRCodesocket2 = QRcodeSocket2TextBox.Text
        m_Data.QRCodesocket3 = QRcodeSocket3TextBox.Text
        m_Data.QRCodesocket4 = QRcodeSocket4TextBox.Text
        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

End Class