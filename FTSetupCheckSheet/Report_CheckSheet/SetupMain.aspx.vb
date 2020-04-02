
Public Class SetupMain
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Private Const BUTTON_TEXT_SETUP As String = "SET-UP"
    Private Const BUTTON_TEXT_CANCEL As String = "CANCEL"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_DATA)
        If tmp Is Nothing Then
            m_Data = New FTSetupReport()
            Session(SESSION_KEY_DATA) = m_Data
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If

        If Not IsPostBack Then
            TextBoxMCNo.Text = m_Data.MCNo
            Devicetext.Text = m_Data.DeviceName
            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypeTextBox.Text = m_Data.TesterType
            TextBoxSetupStatus.Text = m_Data.SetupStatus
            SetStatusColor(TextBoxSetupStatus.Text)
        End If

        'If Not IsPostBack Then
        '    m_Data = New FTSetupReport()
        '    Session(SESSION_KEY_DATA) = m_Data

        '    TextBoxMCNo.Text = m_Data.MCNo
        '    Devicetext.Text = m_Data.DeviceName
        '    TestflowTextBox.Text = m_Data.TestFlow
        '    TesterTypeTextBox.Text = m_Data.TesterType
        '    TextBoxSetupStatus.Text = m_Data.SetupStatus
        '    SetStatusColor(TextBoxSetupStatus.Text)
        'Else
        '    Dim tmp As Object = Session(SESSION_KEY_DATA)
        '    If tmp Is Nothing Then
        '        m_Data = New FTSetupReport()
        '        Session(SESSION_KEY_DATA) = m_Data
        '    Else
        '        m_Data = CType(tmp, FTSetupReport)
        '    End If
        'End If

        QRcodeTextBox.Focus()
    End Sub

    Protected Sub ButtonSetup_Click(sender As Object, e As EventArgs) Handles ButtonSetup.Click

        If m_Data Is Nothing OrElse String.IsNullOrEmpty(m_Data.MCNo) Then
            Exit Sub
        End If

        Select Case ButtonSetup.Text
            Case BUTTON_TEXT_CANCEL
                '1. save to database with status = 'CANCELED' before clear all data
                Try
                    Dim affRow As Integer = DBAccess.UpdateFTSetupReport(m_Data.MCNo, m_Data.LotNo, m_Data.PackageName, m_Data.DeviceName,
                                         m_Data.ProgramName, m_Data.TesterType, m_Data.TestFlow, m_Data.QRCodesocket1,
                                         m_Data.QRCodesocket2, m_Data.QRCodesocket3, m_Data.QRCodesocket4, m_Data.QRCodesocketChannel1,
                                         m_Data.QRCodesocketChannel2, m_Data.QRCodesocketChannel3, m_Data.QRCodesocketChannel4,
                                         m_Data.TesterNoA, m_Data.TesterNoAQRcode, m_Data.TesterNoB, m_Data.TesterNoBQRcode,
                                         m_Data.ChannelAFTB, m_Data.ChannelAFTBQRcode, m_Data.ChannelBFTB, m_Data.ChannelBFTBQRcode, m_Data.TestBoxA,
                                         m_Data.TestBoxAQRcode, m_Data.TestBoxB, m_Data.TestBoxBQRcode, m_Data.AdaptorA,
                                         m_Data.AdaptorAQRcode, m_Data.AdaptorB, m_Data.AdaptorBQRcode, m_Data.DutcardA,
                                         m_Data.DutcardAQRcode, m_Data.DutcardB, m_Data.DutcardBQRcode, m_Data.BridgecableA,
                                         m_Data.BridgecableAQRcode, m_Data.BridgecableB, m_Data.BridgecableBQRcode,
                                         m_Data.TypeChangePackage, m_Data.SetupStartDate, m_Data.SetupEndDate,
                                         m_Data.BoxTesterConnection, m_Data.OptionSetup, m_Data.OptionConnection,
                                         m_Data.OptionName1, m_Data.OptionName2, m_Data.OptionName3, m_Data.OptionName4,
                                         m_Data.OptionName5, m_Data.OptionName6, m_Data.OptionName7, m_Data.OptionType1, m_Data.OptionType1QRcode,
                                         m_Data.OptionType2, m_Data.OptionType2QRcode, m_Data.OptionType3, m_Data.OptionType3QRcode,
                                         m_Data.OptionType4, m_Data.OptionType4QRcode, m_Data.OptionType5, m_Data.OptionType5QRcode,
                                         m_Data.OptionType6, m_Data.OptionType6QRcode, m_Data.OptionType7, m_Data.OptionType7QRcode,
                                         m_Data.OptionSetting1, m_Data.OptionSetting2, m_Data.OptionSetting3, m_Data.OptionSetting4,
                                         m_Data.OptionSetting5, m_Data.OptionSetting6, m_Data.OptionSetting7, m_Data.QfpVacuumPad, m_Data.QfpSocketSetup,
                                         m_Data.QfpSocketDecision, m_Data.QfpDecisionLeadPress, m_Data.QfpTray, m_Data.SopStopper,
                                         m_Data.SopSocketDecision, m_Data.SopDecisionLeadPress, m_Data.ManualCheckTest,
                                         m_Data.ManualCheckTE, m_Data.ManualCheckRequestTE, m_Data.ManualCheckRequestTEConfirm,
                                         m_Data.PkgGood, m_Data.PkgNG, m_Data.PkgGoodJudgement, m_Data.PkgNGJudgement,
                                         m_Data.PkgNishikiCamara, m_Data.PkgNishikiCamaraJudgement,
                                         m_Data.PkqBantLead, m_Data.PkqKakeHige, m_Data.BgaSmallBall,
                                         m_Data.BgaBentTape, m_Data.Bge5S, SETUP_STATUS_WAITING, m_Data.ConfirmedCheckSheetOp,
                                         m_Data.ConfirmedCheckSheetSection, m_Data.ConfirmedCheckSheetGL,
                                         m_Data.ConfirmedShonoSection, m_Data.ConfirmedShonoGL, m_Data.ConfirmedShonoOp, m_Data.StatusShonoOP, m_Data.SetupConfirmDate)

                    '2. do cancel no need reson
                    Dim mcNo As String = m_Data.MCNo
                    m_Data = New FTSetupReport()
                    m_Data.MCNo = mcNo
                    m_Data.SetupStatus = SETUP_STATUS_CANCELED

                    TextBoxMCNo.Text = m_Data.MCNo
                    Devicetext.Text = m_Data.DeviceName
                    TestflowTextBox.Text = m_Data.TestFlow
                    TesterTypeTextBox.Text = m_Data.TesterType
                    TextBoxSetupStatus.Text = m_Data.SetupStatus
                    SetStatusColor(TextBoxSetupStatus.Text)

                    Session(SESSION_KEY_DATA) = m_Data

                Catch ex As Exception
                    ShowErrorMessage("Update Filed : " & ex.Message)
                End Try

            Case BUTTON_TEXT_SETUP
                Dim newData As FTSetupReport = CType(Session(SESSION_KEY_NEW_DATA_SETUP), FTSetupReport)

                If newData Is Nothing OrElse newData.MCNo <> m_Data.MCNo Then
                    newData = New FTSetupReport()
                    newData.MCNo = m_Data.MCNo
                    newData.SetupStartDate = Now
                    Session(SESSION_KEY_NEW_DATA_SETUP) = newData
                End If

                Response.Redirect("~/SetupStep1.aspx")
        End Select
    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

    Protected Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        Response.Redirect("~/SetupConfirm.aspx")
    End Sub

    Protected Sub QRcodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeTextBox.TextChanged

        If Not String.IsNullOrEmpty(QRcodeTextBox.Text) Then

            Dim qrMc As String = QRcodeTextBox.Text.Trim().ToUpper
            QRcodeTextBox.Text = ""

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrMc, EQUIPMENT_TYPE_ID_MACHINE)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    m_Data.MCNo = row("Name").ToString()

                    Using dt2 As DataTable = DBAccess.GetFTSetupReportByMCNo(m_Data.MCNo)

                        If dt2.Rows.Count = 1 Then

                            row = dt2.Rows(0)

                            'm_Data.DeviceName = row("DeviceName").ToString().ToUpper
                            'm_Data.TestFlow = row("TestFlow").ToString().ToUpper
                            'm_Data.TesterType = row("TesterType").ToString().ToUpper
                            'm_Data.SetupStatus = row("SetupStatus").ToString().ToUpper

                            m_Data.LotNo = row("LotNo").ToString().ToUpper
                            m_Data.PackageName = row("PackageName").ToString().ToUpper
                            m_Data.DeviceName = row("DeviceName").ToString().ToUpper
                            m_Data.ProgramName = row("ProgramName").ToString().ToUpper
                            m_Data.TesterType = row("TesterType").ToString().ToUpper
                            m_Data.TestFlow = row("TestFlow").ToString().ToUpper
                            m_Data.QRCodesocket1 = row("QRCodesocket1").ToString().ToUpper
                            m_Data.QRCodesocket2 = row("QRCodesocket2").ToString().ToUpper
                            m_Data.QRCodesocket3 = row("QRCodesocket3").ToString().ToUpper
                            m_Data.QRCodesocket4 = row("QRCodesocket4").ToString().ToUpper
                            m_Data.QRCodesocketChannel1 = row("QRCodesocketChannel1").ToString().ToUpper
                            m_Data.QRCodesocketChannel2 = row("QRCodesocketChannel2").ToString().ToUpper
                            m_Data.QRCodesocketChannel3 = row("QRCodesocketChannel3").ToString().ToUpper
                            m_Data.QRCodesocketChannel4 = row("QRCodesocketChannel4").ToString().ToUpper
                            m_Data.TesterNoA = row("TesterNoA").ToString().ToUpper
                            m_Data.TesterNoAQRcode = row("TesterNoAQRcode").ToString().ToUpper
                            m_Data.TesterNoB = row("TesterNoB").ToString().ToUpper
                            m_Data.TesterNoBQRcode = row("TesterNoBQRcode").ToString().ToUpper
                            m_Data.ChannelAFTB = row("ChannelAFTB").ToString().ToUpper
                            m_Data.ChannelAFTBQRcode = row("ChannelAFTBQRcode").ToString().ToUpper
                            m_Data.ChannelBFTB = row("ChannelBFTB").ToString().ToUpper
                            m_Data.ChannelBFTBQRcode = row("ChannelBFTBQRcode").ToString().ToUpper
                            m_Data.TestBoxA = row("TestBoxA").ToString().ToUpper
                            m_Data.TestBoxAQRcode = row("TestBoxAQRcode").ToString().ToUpper
                            m_Data.TestBoxB = row("TestBoxB").ToString().ToUpper
                            m_Data.TestBoxBQRcode = row("TestBoxBQRcode").ToString().ToUpper
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
                            m_Data.ManualCheckTE = row("ManualCheckTE").ToString().ToUpper
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
                            m_Data.SetupStatus = row("SetupStatus").ToString().ToUpper
                            m_Data.ConfirmedCheckSheetOp = row("ConfirmedCheckSheetOp").ToString().ToUpper
                            m_Data.ConfirmedCheckSheetSection = row("ConfirmedCheckSheetSection").ToString().ToUpper
                            m_Data.ConfirmedCheckSheetGL = row("ConfirmedCheckSheetGL").ToString().ToUpper
                            m_Data.ConfirmedShonoSection = row("ConfirmedShonoSection").ToString().ToUpper
                            m_Data.ConfirmedShonoGL = row("ConfirmedShonoGL").ToString().ToUpper
                            m_Data.ConfirmedShonoOp = row("ConfirmedShonoOp").ToString().ToUpper
                            m_Data.StatusShonoOP = row("StatusShonoOP").ToString().ToUpper

                        Else
                            'first time of MC

                            m_Data.DeviceName = ""
                            m_Data.TestFlow = ""
                            m_Data.TesterType = ""
                            m_Data.SetupStatus = ""

                            DBAccess.CreateBlankFTSetupRecord(m_Data.MCNo)

                        End If
                    End Using

                    TextBoxMCNo.Text = m_Data.MCNo
                    Devicetext.Text = m_Data.DeviceName
                    TestflowTextBox.Text = m_Data.TestFlow
                    TesterTypeTextBox.Text = m_Data.TesterType
                    TextBoxSetupStatus.Text = m_Data.SetupStatus
                    SetStatusColor(TextBoxSetupStatus.Text)

                    Session(SESSION_KEY_DATA) = m_Data

                End If
            End Using
        End If
    End Sub

    Private Sub SetStatusColor(statusText As String)
        Select Case statusText
            Case SETUP_STATUS_WAITING
                TextBoxSetupStatus.ForeColor = Drawing.Color.Orange
                ButtonConfirm.Visible = True
                ButtonSetup.Text = BUTTON_TEXT_CANCEL
            Case SETUP_STATUS_GOODNGTEST
                TextBoxSetupStatus.ForeColor = Drawing.Color.Green
                ButtonConfirm.Visible = False
                ButtonSetup.Text = BUTTON_TEXT_SETUP
            Case SETUP_STATUS_CONFIRMED
                TextBoxSetupStatus.ForeColor = Drawing.Color.Green
                ButtonConfirm.Visible = False
                ButtonSetup.Text = BUTTON_TEXT_SETUP
            Case SETUP_STATUS_CANCELED
                TextBoxSetupStatus.ForeColor = Drawing.Color.Blue
                ButtonConfirm.Visible = False
                ButtonSetup.Text = BUTTON_TEXT_SETUP
            Case Else
                TextBoxSetupStatus.ForeColor = Drawing.Color.Black
                ButtonConfirm.Visible = False
                ButtonSetup.Text = BUTTON_TEXT_SETUP
        End Select
    End Sub

End Class