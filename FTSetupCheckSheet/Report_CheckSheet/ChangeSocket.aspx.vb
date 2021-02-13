Public Class ChangeSocket
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport
    Private m_OldData As FTSetupReportHistory
    Private m_Socket As List(Of Socket)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_DATA)
        Dim tmp2 As Object = Session(SESSION_KEY_OLD_DATA)
        Dim tmp3 As Object = Session(SESSION_SOCKET_DATA)

        If tmp Is Nothing Then
            m_Data = New FTSetupReport()
            Session(SESSION_KEY_DATA) = m_Data

            m_OldData = New FTSetupReportHistory()
            Session(SESSION_KEY_OLD_DATA) = m_OldData

            m_Socket = New List(Of Socket)()
            Session(SESSION_SOCKET_DATA) = m_Socket
        Else
            m_Data = CType(tmp, FTSetupReport)
            m_OldData = CType(tmp2, FTSetupReportHistory)
            m_Socket = CType(tmp3, List(Of Socket))
        End If

        If Not IsPostBack Then
            TextBoxMCNo.Text = m_Data.MCNo
            TextBoxSocketCH1.Text = m_Data.QRCodesocket1
            TextBoxSocketCH2.Text = m_Data.QRCodesocket2
            TextBoxSocketCH3.Text = m_Data.QRCodesocket3
            TextBoxSocketCH4.Text = m_Data.QRCodesocket4
            TextBoxSocketCH5.Text = m_Data.QRCodesocket5
            TextBoxSocketCH6.Text = m_Data.QRCodesocket6
            TextBoxSocketCH7.Text = m_Data.QRCodesocket7
            TextBoxSocketCH8.Text = m_Data.QRCodesocket8
            SetDefaultSocket()

            If m_Data.MCNo.StartsWith("FT") OrElse m_Data.MCNo.StartsWith("TP") Then
                panelSocket5.Style.Item("display") = "block"
                panelSocket6.Style.Item("display") = "block"
                panelSocket7.Style.Item("display") = "block"
                panelSocket8.Style.Item("display") = "block"
            End If
        End If

        QRcodeTextBox.Focus()
    End Sub

    Protected Sub SetDefaultSocket()

        If m_Socket.Count() = 0 Then
            Dim data As New Socket With {
                .SocketName = m_Data.QRCodesocket1,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel1,
                .Channel = 1
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket2,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel2,
                .Channel = 2
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket3,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel3,
                .Channel = 3
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket4,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel4,
                .Channel = 4
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket5,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel5,
                .Channel = 5
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket6,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel6,
                .Channel = 6
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket7,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel7,
                .Channel = 7
            }
            m_Socket.Add(data)

            data = New Socket With {
                .SocketName = m_Data.QRCodesocket8,
                .QRCodesocketChannel = m_Data.QRCodesocketChannel8,
                .Channel = 8
            }
            m_Socket.Add(data)
        End If

    End Sub

    Protected Sub QRcodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeTextBox.TextChanged

        If Not String.IsNullOrEmpty(QRcodeTextBox.Text) Then

            Dim qrMc As String = QRcodeTextBox.Text.Trim().ToUpper
            QRcodeTextBox.Text = ""

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrMc, EQUIPMENT_TYPE_ID_MACHINE)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    m_Data.MCNo = row("Name").ToString()

                    GetFTSetupReport()

                    TextBoxMCNo.Text = m_Data.MCNo
                    TextBoxSocketCH1.Text = m_Data.QRCodesocket1
                    TextBoxSocketCH2.Text = m_Data.QRCodesocket2
                    TextBoxSocketCH3.Text = m_Data.QRCodesocket3
                    TextBoxSocketCH4.Text = m_Data.QRCodesocket4
                    TextBoxSocketCH5.Text = m_Data.QRCodesocket5
                    TextBoxSocketCH6.Text = m_Data.QRCodesocket6
                    TextBoxSocketCH7.Text = m_Data.QRCodesocket7
                    TextBoxSocketCH8.Text = m_Data.QRCodesocket8
                    SetDefaultSocket()

                End If
            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH1.TextChanged
        TextBoxSocketCH2.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH1.Text) Then
            Dim qrCode As String = TextBoxSocketCH1.Text.ToUpper.Trim
            m_Socket(0).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(0).SocketName = data_SmallCode

                    Else
                        m_Socket(0).SocketName = ""
                    End If

                Else
                    m_Socket(0).SocketName = ""
                End If

                TextBoxSocketCH1.Text = m_Socket(0).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH2.TextChanged
        TextBoxSocketCH3.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH2.Text) Then
            Dim qrCode As String = TextBoxSocketCH2.Text.ToUpper.Trim
            m_Socket(1).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(1).SocketName = data_SmallCode

                    Else
                        m_Socket(1).SocketName = ""
                    End If

                Else
                    m_Socket(1).SocketName = ""
                End If

                TextBoxSocketCH2.Text = m_Socket(1).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH3.TextChanged
        TextBoxSocketCH4.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH3.Text) Then
            Dim qrCode As String = TextBoxSocketCH3.Text.ToUpper.Trim
            m_Socket(2).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(2).SocketName = data_SmallCode

                    Else
                        m_Socket(2).SocketName = ""
                    End If

                Else
                    m_Socket(2).SocketName = ""
                End If

                TextBoxSocketCH3.Text = m_Socket(2).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH4_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH4.TextChanged
        TextBoxSocketCH5.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH4.Text) Then
            Dim qrCode As String = TextBoxSocketCH4.Text.ToUpper.Trim
            m_Socket(3).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(3).SocketName = data_SmallCode

                    Else
                        m_Socket(3).SocketName = ""
                    End If

                Else
                    m_Socket(3).SocketName = ""
                End If

                TextBoxSocketCH4.Text = m_Socket(3).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH5_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH5.TextChanged
        TextBoxSocketCH6.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH5.Text) Then
            Dim qrCode As String = TextBoxSocketCH5.Text.ToUpper.Trim
            m_Socket(4).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(4).SocketName = data_SmallCode

                    Else
                        m_Socket(4).SocketName = ""
                    End If

                Else
                    m_Socket(4).SocketName = ""
                End If

                TextBoxSocketCH5.Text = m_Socket(4).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH6_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH6.TextChanged
        TextBoxSocketCH7.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH6.Text) Then
            Dim qrCode As String = TextBoxSocketCH6.Text.ToUpper.Trim
            m_Socket(5).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(5).SocketName = data_SmallCode

                    Else
                        m_Socket(5).SocketName = ""
                    End If

                Else
                    m_Socket(5).SocketName = ""
                End If

                TextBoxSocketCH6.Text = m_Socket(5).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH7_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH7.TextChanged
        TextBoxSocketCH8.Focus()

        If Not String.IsNullOrEmpty(TextBoxSocketCH7.Text) Then
            Dim qrCode As String = TextBoxSocketCH7.Text.ToUpper.Trim
            m_Socket(6).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(6).SocketName = data_SmallCode

                    Else
                        m_Socket(6).SocketName = ""
                    End If

                Else
                    m_Socket(6).SocketName = ""
                End If

                TextBoxSocketCH7.Text = m_Socket(6).SocketName

            End Using
        End If
    End Sub

    Protected Sub TextBoxSocketCH8_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSocketCH8.TextChanged

        If Not String.IsNullOrEmpty(TextBoxSocketCH8.Text) Then
            Dim qrCode As String = TextBoxSocketCH8.Text.ToUpper.Trim
            m_Socket(7).QRCodesocketChannel = qrCode

            Using dt As DataTable = DBAccess.GetOSPSocketSystem(qrCode)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    If row("Is_Pass").ToString().Equals("TRUE") Then

                        Dim data_SmallCode As String = row("SmallCode").ToString
                        m_Socket(7).SocketName = data_SmallCode

                    Else
                        m_Socket(7).SocketName = ""
                    End If

                Else
                    m_Socket(7).SocketName = ""
                End If

                TextBoxSocketCH8.Text = m_Socket(7).SocketName

            End Using
        End If
    End Sub

    Private Sub GetFTSetupReport()
        Using dt2 As DataTable = DBAccess.GetFTSetupReportByMCNo(m_Data.MCNo)
            If dt2.Rows.Count = 1 Then

                Dim row As DataRow = dt2.Rows(0)

                m_Data.LotNo = row("LotNo").ToString().ToUpper
                m_Data.DeviceName = row("DeviceName").ToString().ToUpper
                m_Data.TestFlow = row("TestFlow").ToString().ToUpper
                m_Data.TesterType = row("TesterType").ToString().ToUpper
                m_Data.OISRank = row("OISRank").ToString().ToUpper
                m_Data.OISDevice = row("OISDevice").ToString().ToUpper
                m_Data.SetupStatus = row("SetupStatus").ToString().ToUpper
                m_Data.StatusShonoOP = row("StatusShonoOP").ToString().ToUpper

                If m_Data.SetupStatus <> "CONFIRMED" AndAlso m_Data.SetupStatus <> "GOODNGTEST" Then
                    ShowErrorMessage("กรุณาทำ SetupCheckSheet ให้เสร็จสมบูรณ์ก่อน")
                Else
                    m_Data.PackageName = row("PackageName").ToString().ToUpper
                    m_Data.ProgramName = row("ProgramName").ToString().ToUpper
                    m_Data.QRCodesocket1 = row("QRCodesocket1").ToString().ToUpper
                    m_Data.QRCodesocket2 = row("QRCodesocket2").ToString().ToUpper
                    m_Data.QRCodesocket3 = row("QRCodesocket3").ToString().ToUpper
                    m_Data.QRCodesocket4 = row("QRCodesocket4").ToString().ToUpper
                    m_Data.QRCodesocketChannel1 = row("QRCodesocketChannel1").ToString().ToUpper
                    m_Data.QRCodesocketChannel2 = row("QRCodesocketChannel2").ToString().ToUpper
                    m_Data.QRCodesocketChannel3 = row("QRCodesocketChannel3").ToString().ToUpper
                    m_Data.QRCodesocketChannel4 = row("QRCodesocketChannel4").ToString().ToUpper
                    m_Data.QRCodesocket5 = row("QRCodesocket5").ToString().ToUpper
                    m_Data.QRCodesocket6 = row("QRCodesocket6").ToString().ToUpper
                    m_Data.QRCodesocket7 = row("QRCodesocket7").ToString().ToUpper
                    m_Data.QRCodesocket8 = row("QRCodesocket8").ToString().ToUpper
                    m_Data.QRCodesocketChannel5 = row("QRCodesocketChannel5").ToString().ToUpper
                    m_Data.QRCodesocketChannel6 = row("QRCodesocketChannel6").ToString().ToUpper
                    m_Data.QRCodesocketChannel7 = row("QRCodesocketChannel7").ToString().ToUpper
                    m_Data.QRCodesocketChannel8 = row("QRCodesocketChannel8").ToString().ToUpper
                    m_Data.TesterNoA = row("TesterNoA").ToString().ToUpper
                    m_Data.TesterNoAQRcode = row("TesterNoAQRcode").ToString().ToUpper
                    m_Data.TesterNoB = row("TesterNoB").ToString().ToUpper
                    m_Data.TesterNoBQRcode = row("TesterNoBQRcode").ToString().ToUpper
                    m_Data.TesterNoC = row("TesterNoC").ToString().ToUpper
                    m_Data.TesterNoCQRcode = row("TesterNoCQRcode").ToString().ToUpper
                    m_Data.TesterNoD = row("TesterNoD").ToString().ToUpper
                    m_Data.TesterNoDQRcode = row("TesterNoDQRcode").ToString().ToUpper
                    m_Data.ChannelAFTB = row("ChannelAFTB").ToString().ToUpper
                    m_Data.ChannelAFTBQRcode = row("ChannelAFTBQRcode").ToString().ToUpper
                    m_Data.ChannelBFTB = row("ChannelBFTB").ToString().ToUpper
                    m_Data.ChannelBFTBQRcode = row("ChannelBFTBQRcode").ToString().ToUpper
                    m_Data.ChannelCFTB = row("ChannelCFTB").ToString().ToUpper
                    m_Data.ChannelCFTBQRcode = row("ChannelCFTBQRcode").ToString().ToUpper
                    m_Data.ChannelDFTB = row("ChannelDFTB").ToString().ToUpper
                    m_Data.ChannelDFTBQRcode = row("ChannelDFTBQRcode").ToString().ToUpper
                    m_Data.ChannelEFTB = row("ChannelEFTB").ToString().ToUpper
                    m_Data.ChannelEFTBQRcode = row("ChannelEFTBQRcode").ToString().ToUpper
                    m_Data.ChannelFFTB = row("ChannelFFTB").ToString().ToUpper
                    m_Data.ChannelFFTBQRcode = row("ChannelFFTBQRcode").ToString().ToUpper
                    m_Data.ChannelGFTB = row("ChannelGFTB").ToString().ToUpper
                    m_Data.ChannelGFTBQRcode = row("ChannelGFTBQRcode").ToString().ToUpper
                    m_Data.ChannelHFTB = row("ChannelHFTB").ToString().ToUpper
                    m_Data.ChannelHFTBQRcode = row("ChannelHFTBQRcode").ToString().ToUpper
                    m_Data.TestBoxA = row("TestBoxA").ToString().ToUpper
                    m_Data.TestBoxAQRcode = row("TestBoxAQRcode").ToString().ToUpper
                    m_Data.TestBoxB = row("TestBoxB").ToString().ToUpper
                    m_Data.TestBoxBQRcode = row("TestBoxBQRcode").ToString().ToUpper
                    m_Data.TestBoxC = row("TestBoxC").ToString().ToUpper
                    m_Data.TestBoxCQRcode = row("TestBoxCQRcode").ToString().ToUpper
                    m_Data.TestBoxD = row("TestBoxD").ToString().ToUpper
                    m_Data.TestBoxDQRcode = row("TestBoxDQRcode").ToString().ToUpper
                    m_Data.TestBoxE = row("TestBoxE").ToString().ToUpper
                    m_Data.TestBoxEQRcode = row("TestBoxEQRcode").ToString().ToUpper
                    m_Data.TestBoxF = row("TestBoxF").ToString().ToUpper
                    m_Data.TestBoxFQRcode = row("TestBoxFQRcode").ToString().ToUpper
                    m_Data.TestBoxG = row("TestBoxG").ToString().ToUpper
                    m_Data.TestBoxGQRcode = row("TestBoxGQRcode").ToString().ToUpper
                    m_Data.TestBoxH = row("TestBoxH").ToString().ToUpper
                    m_Data.TestBoxHQRcode = row("TestBoxHQRcode").ToString().ToUpper
                    m_Data.AdaptorA = row("AdaptorA").ToString().ToUpper
                    m_Data.AdaptorAQRcode = row("AdaptorAQRcode").ToString().ToUpper
                    m_Data.AdaptorB = row("AdaptorB").ToString().ToUpper
                    m_Data.AdaptorBQRcode = row("AdaptorBQRcode").ToString().ToUpper
                    m_Data.DutcardA = row("DutcardA").ToString().ToUpper
                    m_Data.DutcardAQRcode = row("DutcardAQRcode").ToString().ToUpper
                    m_Data.DutcardB = row("DutcardB").ToString().ToUpper
                    m_Data.DutcardBQRcode = row("DutcardBQRcode").ToString().ToUpper
                    m_Data.BridgecableA = row("BridgecableA").ToString().ToUpper
                    m_Data.BridgecableAQRcode = row("BridgecableAQRcode").ToString().ToUpper
                    m_Data.BridgecableB = row("BridgecableB").ToString().ToUpper
                    m_Data.BridgecableBQRcode = row("BridgecableBQRcode").ToString().ToUpper
                    m_Data.TypeChangePackage = row("TypeChangePackage").ToString().ToUpper
                    m_Data.SetupStartDate = CDate(row("SetupStartDate"))
                    m_Data.SetupEndDate = CDate(row("SetupEndDate"))
                    m_Data.BoxTesterConnection = row("BoxTesterConnection").ToString().ToUpper
                    m_Data.OptionSetup = row("OptionSetup").ToString().ToUpper
                    m_Data.OptionConnection = row("OptionConnection").ToString().ToUpper
                    m_Data.OptionName1 = row("OptionName1").ToString().ToUpper
                    m_Data.OptionName2 = row("OptionName2").ToString().ToUpper
                    m_Data.OptionName3 = row("OptionName3").ToString().ToUpper
                    m_Data.OptionName4 = row("OptionName4").ToString().ToUpper
                    m_Data.OptionName5 = row("OptionName5").ToString().ToUpper
                    m_Data.OptionName6 = row("OptionName6").ToString().ToUpper
                    m_Data.OptionName7 = row("OptionName7").ToString().ToUpper
                    m_Data.OptionType1 = row("OptionType1").ToString().ToUpper
                    m_Data.OptionType1QRcode = row("OptionType1QRcode").ToString().ToUpper
                    m_Data.OptionType2 = row("OptionType2").ToString().ToUpper
                    m_Data.OptionType2QRcode = row("OptionType2QRcode").ToString().ToUpper
                    m_Data.OptionType3 = row("OptionType3").ToString().ToUpper
                    m_Data.OptionType3QRcode = row("OptionType3QRcode").ToString().ToUpper
                    m_Data.OptionType4 = row("OptionType4").ToString().ToUpper
                    m_Data.OptionType4QRcode = row("OptionType4QRcode").ToString().ToUpper
                    m_Data.OptionType5 = row("OptionType5").ToString().ToUpper
                    m_Data.OptionType5QRcode = row("OptionType5QRcode").ToString().ToUpper
                    m_Data.OptionType6 = row("OptionType6").ToString().ToUpper
                    m_Data.OptionType6QRcode = row("OptionType6QRcode").ToString().ToUpper
                    m_Data.OptionType7 = row("OptionType7").ToString().ToUpper
                    m_Data.OptionType7QRcode = row("OptionType7QRcode").ToString().ToUpper
                    m_Data.OptionSetting1 = row("OptionSetting1").ToString().ToUpper
                    m_Data.OptionSetting2 = row("OptionSetting2").ToString().ToUpper
                    m_Data.OptionSetting3 = row("OptionSetting3").ToString().ToUpper
                    m_Data.OptionSetting4 = row("OptionSetting4").ToString().ToUpper
                    m_Data.OptionSetting5 = row("OptionSetting5").ToString().ToUpper
                    m_Data.OptionSetting6 = row("OptionSetting6").ToString().ToUpper
                    m_Data.OptionSetting7 = row("OptionSetting7").ToString().ToUpper
                    m_Data.QfpVacuumPad = row("QfpVacuumPad").ToString().ToUpper
                    m_Data.QfpSocketSetup = row("QfpSocketSetup").ToString().ToUpper
                    m_Data.QfpSocketDecision = row("QfpSocketDecision").ToString().ToUpper
                    m_Data.QfpDecisionLeadPress = row("QfpDecisionLeadPress").ToString().ToUpper
                    m_Data.QfpTray = row("QfpTray").ToString().ToUpper
                    m_Data.SopStopper = row("SopStopper").ToString().ToUpper
                    m_Data.SopSocketDecision = row("SopSocketDecision").ToString().ToUpper
                    m_Data.SopDecisionLeadPress = row("SopDecisionLeadPress").ToString().ToUpper
                    m_Data.ManualCheckTest = Int32.Parse(row("ManualCheckTest").ToString())
                    m_Data.ManualCheckTE = row("ManualCheckTE").ToString().ToUpper
                    m_Data.ManualCheckRequestTE = Int32.Parse(row("ManualCheckRequestTE").ToString())
                    m_Data.ManualCheckRequestTEConfirm = row("ManualCheckRequestTEConfirm").ToString().ToUpper
                    m_Data.PkgGood = row("PkgGood").ToString().ToUpper
                    m_Data.PkgNG = row("PkgNG").ToString().ToUpper
                    m_Data.PkgGoodJudgement = row("PkgGoodJudgement").ToString().ToUpper
                    m_Data.PkgNGJudgement = row("PkgNGJudgement").ToString().ToUpper
                    m_Data.PkgNishikiCamara = row("PkgNishikiCamara").ToString().ToUpper
                    m_Data.PkgNishikiCamaraJudgement = row("PkgNishikiCamaraJudgement").ToString().ToUpper
                    m_Data.PkqBantLead = row("PkqBantLead").ToString().ToUpper
                    m_Data.PkqKakeHige = row("PkqKakeHige").ToString().ToUpper
                    m_Data.BgaSmallBall = row("BgaSmallBall").ToString().ToUpper
                    m_Data.BgaBentTape = row("BgaBentTape").ToString().ToUpper
                    m_Data.Bge5S = row("Bge5S").ToString().ToUpper
                    m_Data.ConfirmedCheckSheetOp = row("ConfirmedCheckSheetOp").ToString().ToUpper
                    m_Data.ConfirmedCheckSheetSection = row("ConfirmedCheckSheetSection").ToString().ToUpper
                    m_Data.ConfirmedCheckSheetGL = row("ConfirmedCheckSheetGL").ToString().ToUpper
                    m_Data.ConfirmedShonoSection = row("ConfirmedShonoSection").ToString().ToUpper
                    m_Data.ConfirmedShonoGL = row("ConfirmedShonoGL").ToString().ToUpper
                    m_Data.ConfirmedShonoOp = row("ConfirmedShonoOp").ToString().ToUpper
                End If

            Else
                ShowErrorMessage("ไม่พบการทำ SetupCheckSheet ของเครื่อง " + m_Data.MCNo)
            End If
        End Using
    End Sub

    Private Sub SetFTReport()
        Try
            Dim affRow As Integer = DBAccess.UpdateFTSetupReport(m_Data.MCNo,
                                                                 m_Data.LotNo,
                                                                 m_Data.PackageName,
                                                                 m_Data.DeviceName,
                                                                 m_Data.ProgramName,
                                                                 m_Data.TesterType,
                                                                 m_Data.TestFlow,
                                                                 m_Data.OISRank,
                                                                 m_Data.OISDevice,
                                                                 m_Data.QRCodesocket1,
                                                                 m_Data.QRCodesocket2,
                                                                 m_Data.QRCodesocket3,
                                                                 m_Data.QRCodesocket4,
                                                                 m_Data.QRCodesocket5,
                                                                 m_Data.QRCodesocket6,
                                                                 m_Data.QRCodesocket7,
                                                                 m_Data.QRCodesocket8,
                                                                 m_Data.QRCodesocketChannel1,
                                                                 m_Data.QRCodesocketChannel2,
                                                                 m_Data.QRCodesocketChannel3,
                                                                 m_Data.QRCodesocketChannel4,
                                                                 m_Data.QRCodesocketChannel5,
                                                                 m_Data.QRCodesocketChannel6,
                                                                 m_Data.QRCodesocketChannel7,
                                                                 m_Data.QRCodesocketChannel8,
                                                                 m_Data.SocketChange,
                                                                 m_Data.TesterNoA,
                                                                 m_Data.TesterNoAQRcode,
                                                                 m_Data.TesterNoB,
                                                                 m_Data.TesterNoBQRcode,
                                                                 m_Data.TesterNoC,
                                                                 m_Data.TesterNoCQRcode,
                                                                 m_Data.TesterNoD,
                                                                 m_Data.TesterNoDQRcode,
                                                                 m_Data.ChannelAFTB,
                                                                 m_Data.ChannelAFTBQRcode,
                                                                 m_Data.ChannelBFTB,
                                                                 m_Data.ChannelBFTBQRcode,
                                                                 m_Data.ChannelCFTB,
                                                                 m_Data.ChannelCFTBQRcode,
                                                                 m_Data.ChannelDFTB,
                                                                 m_Data.ChannelDFTBQRcode,
                                                                 m_Data.ChannelEFTB,
                                                                 m_Data.ChannelEFTBQRcode,
                                                                 m_Data.ChannelFFTB,
                                                                 m_Data.ChannelFFTBQRcode,
                                                                 m_Data.ChannelGFTB,
                                                                 m_Data.ChannelGFTBQRcode,
                                                                 m_Data.ChannelHFTB,
                                                                 m_Data.ChannelHFTBQRcode,
                                                                 m_Data.TestBoxA,
                                                                 m_Data.TestBoxAQRcode,
                                                                 m_Data.TestBoxB,
                                                                 m_Data.TestBoxBQRcode,
                                                                 m_Data.TestBoxC,
                                                                 m_Data.TestBoxCQRcode,
                                                                 m_Data.TestBoxD,
                                                                 m_Data.TestBoxDQRcode,
                                                                 m_Data.TestBoxE,
                                                                 m_Data.TestBoxEQRcode,
                                                                 m_Data.TestBoxF,
                                                                 m_Data.TestBoxFQRcode,
                                                                 m_Data.TestBoxG,
                                                                 m_Data.TestBoxGQRcode,
                                                                 m_Data.TestBoxH,
                                                                 m_Data.TestBoxHQRcode,
                                                                 m_Data.AdaptorA,
                                                                 m_Data.AdaptorAQRcode,
                                                                 m_Data.AdaptorB,
                                                                 m_Data.AdaptorBQRcode,
                                                                 m_Data.DutcardA,
                                                                 m_Data.DutcardAQRcode,
                                                                 m_Data.DutcardB,
                                                                 m_Data.DutcardBQRcode,
                                                                 m_Data.BridgecableA,
                                                                 m_Data.BridgecableAQRcode,
                                                                 m_Data.BridgecableB,
                                                                 m_Data.BridgecableBQRcode,
                                                                 m_Data.TypeChangePackage,
                                                                 m_Data.SetupStartDate,
                                                                 m_Data.SetupEndDate,
                                                                 m_Data.BoxTesterConnection,
                                                                 m_Data.OptionSetup,
                                                                 m_Data.OptionConnection,
                                                                 m_Data.OptionName1,
                                                                 m_Data.OptionName2,
                                                                 m_Data.OptionName3,
                                                                 m_Data.OptionName4,
                                                                 m_Data.OptionName5,
                                                                 m_Data.OptionName6,
                                                                 m_Data.OptionName7,
                                                                 m_Data.OptionType1,
                                                                 m_Data.OptionType1QRcode,
                                                                 m_Data.OptionType2,
                                                                 m_Data.OptionType2QRcode,
                                                                 m_Data.OptionType3,
                                                                 m_Data.OptionType3QRcode,
                                                                 m_Data.OptionType4,
                                                                 m_Data.OptionType4QRcode,
                                                                 m_Data.OptionType5,
                                                                 m_Data.OptionType5QRcode,
                                                                 m_Data.OptionType6,
                                                                 m_Data.OptionType6QRcode,
                                                                 m_Data.OptionType7,
                                                                 m_Data.OptionType7QRcode,
                                                                 m_Data.OptionSetting1,
                                                                 m_Data.OptionSetting2,
                                                                 m_Data.OptionSetting3,
                                                                 m_Data.OptionSetting4,
                                                                 m_Data.OptionSetting5,
                                                                 m_Data.OptionSetting6,
                                                                 m_Data.OptionSetting7,
                                                                 m_Data.QfpVacuumPad,
                                                                 m_Data.QfpSocketSetup,
                                                                 m_Data.QfpSocketDecision,
                                                                 m_Data.QfpDecisionLeadPress,
                                                                 m_Data.QfpTray, m_Data.SopStopper,
                                                                 m_Data.SopSocketDecision,
                                                                 m_Data.SopDecisionLeadPress,
                                                                 m_Data.ManualCheckTest,
                                                                 m_Data.ManualCheckTE,
                                                                 m_Data.ManualCheckRequestTE,
                                                                 m_Data.ManualCheckRequestTEConfirm,
                                                                 m_Data.PkgGood, m_Data.PkgNG,
                                                                 m_Data.PkgGoodJudgement,
                                                                 m_Data.PkgNGJudgement,
                                                                 m_Data.PkgNishikiCamara,
                                                                 m_Data.PkgNishikiCamaraJudgement,
                                                                 m_Data.PkqBantLead,
                                                                 m_Data.PkqKakeHige,
                                                                 m_Data.BgaSmallBall,
                                                                 m_Data.BgaBentTape,
                                                                 m_Data.Bge5S,
                                                                 m_Data.SetupStatus,
                                                                 m_Data.ConfirmedCheckSheetOp,
                                                                 m_Data.ConfirmedCheckSheetSection,
                                                                 m_Data.ConfirmedCheckSheetGL,
                                                                 m_Data.ConfirmedShonoSection,
                                                                 m_Data.ConfirmedShonoGL,
                                                                 m_Data.ConfirmedShonoOp,
                                                                 m_Data.StatusShonoOP,
                                                                 m_Data.SetupConfirmDate)

            Session(SESSION_KEY_DATA) = m_Data
            Session(SESSION_KEY_NEW_DATA_SETUP) = Nothing
            Session(SESSION_KEY_OLD_DATA) = m_OldData

            HideErrorMessage()

            Response.Redirect("~/SetupMain.aspx", False)
        Catch ex As Exception
            ShowErrorMessage("Update Failed : " & HttpUtility.HtmlEncode(ex.Message & vbNewLine & ex.StackTrace))
        End Try
    End Sub

    Private Sub SetSocket()
        Dim opNo As String = TextBoxOPNo.Text

        If m_Data.QRCodesocketChannel1.Equals(m_Socket(0).QRCodesocketChannel) Then

        End If

        Try

        Catch ex As Exception
            ShowErrorMessage("SetSocket Failed : " & HttpUtility.HtmlEncode(ex.Message & vbNewLine & ex.StackTrace))
        End Try

    End Sub

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click

        SetSocket()

        m_Data.SocketChange = 1
        SetFTReport()

        Response.Redirect("~/Default.aspx")
    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

End Class