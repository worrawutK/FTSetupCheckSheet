
Public Class SetupMain
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport
    Private m_OldData As FTSetupReportHistory

    Private Const BUTTON_TEXT_SETUP As String = "SET-UP"
    Private Const BUTTON_TEXT_CANCEL As String = "CANCEL"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_DATA)
        Dim tmp2 As Object = Session(SESSION_KEY_OLD_DATA)

        If tmp Is Nothing Then
            m_Data = New FTSetupReport()
            Session(SESSION_KEY_DATA) = m_Data

            m_OldData = New FTSetupReportHistory()
            Session(SESSION_KEY_OLD_DATA) = m_OldData
        Else
            m_Data = CType(tmp, FTSetupReport)
            m_OldData = CType(tmp2, FTSetupReportHistory)
        End If

        If Not IsPostBack Then
            TextBoxMCNo.Text = m_Data.MCNo
            Devicetext.Text = m_Data.DeviceName
            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypeTextBox.Text = m_Data.TesterType
            TextBoxSetupStatus.Text = m_Data.SetupStatus
            SetStatusColor(TextBoxSetupStatus.Text)
        End If

        QRcodeTextBox.Focus()
    End Sub

    Protected Sub QRcodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeTextBox.TextChanged

        If Not String.IsNullOrEmpty(QRcodeTextBox.Text) Then

            Dim qrMc As String = QRcodeTextBox.Text.Trim().ToUpper
            QRcodeTextBox.Text = ""

            Using dt As DataTable = DBAccess.GetEquipmentByQRName(qrMc, EQUIPMENT_TYPE_ID_MACHINE)

                If dt.Rows.Count = 1 Then

                    Dim row As DataRow = dt.Rows(0)

                    m_Data.MCNo = row("Name").ToString()

                    GetFTSetupReport(row)
                    GetFTSetupReportHistory()

                    TextBoxMCNo.Text = m_Data.MCNo
                    Devicetext.Text = m_Data.DeviceName
                    TestflowTextBox.Text = m_Data.TestFlow
                    TesterTypeTextBox.Text = m_Data.TesterType
                    TextBoxSetupStatus.Text = m_Data.SetupStatus
                    SetStatusColor(TextBoxSetupStatus.Text)

                End If
            End Using
        End If
    End Sub

    Protected Sub ButtonSetup_Click(sender As Object, e As EventArgs) Handles ButtonSetup.Click

        If m_Data Is Nothing OrElse String.IsNullOrEmpty(m_Data.MCNo) Then
            Exit Sub
        End If

        Select Case ButtonSetup.Text
            Case BUTTON_TEXT_CANCEL

                GetFTSetupReportHistory()

                Dim mcNo As String = m_Data.MCNo

                '009363 clear special flow old goodngtest lot
                If m_OldData.LotNo <> "" And m_OldData.SetupStatus = "GOODNGTEST" Then
                    Dim currentTransLotsTbl As DataTable

                    Try
                        currentTransLotsTbl = DBAccess.GetCurrentTransLots(m_OldData.LotNo)
                    Catch ex As Exception
                        ShowErrorMessage("Failed to get CurrentTransLots :" & ex.Message)
                        Exit Sub
                    End Try

                    If currentTransLotsTbl.Rows.Count = 0 Then
                        ShowErrorMessage(String.Format("ไม่พบ Lot No ที่จะนำไปลบ flow GO/NG Sample Judge โปรดตรวจสอบที่ ATOM : [cellcon].[sp_get_current_trans_lots] <br/>"))
                        Exit Sub
                    ElseIf currentTransLotsTbl.Rows.Count > 1 Then
                        ShowErrorMessage(String.Format("พบ Lot No : " + currentTransLotsTbl.Rows.Count.ToString() + " rows โปรดแจ้ง SYSTEM : [cellcon].[sp_get_current_trans_lots] <br/>"))
                        Exit Sub
                    End If

                    Dim currentTransLotsRow As DataRow = currentTransLotsTbl.Rows(0)

                    Dim lotId As Int32 = Int32.Parse(currentTransLotsRow("LotId").ToString())
                    Dim specialflowId As Int32 = Int32.Parse(currentTransLotsRow("SpecialFlowId").ToString())
                    Dim flowId As Int32 = Int32.Parse(currentTransLotsRow("FlowId").ToString())

                    'Any SpecialflowId but flowId = 366 (GO/NG Sample Judge)
                    If specialflowId <> 0 AndAlso flowId = 366 Then
                        RemoveSpecialFlow(lotId, specialflowId, flowId)
                    End If

                    'Clear Next Lot 
                    SetNextLotHere(mcNo, "")

                End If

                '009363 clear all data before save to database
                m_Data = New FTSetupReport()
                m_Data.MCNo = mcNo
                m_Data.SetupStartDate = Now
                m_Data.SetupEndDate = Now
                m_Data.SetupStatus = SETUP_STATUS_CANCELED

                SetFTReport()

                TextBoxMCNo.Text = m_Data.MCNo
                Devicetext.Text = m_Data.DeviceName
                TestflowTextBox.Text = m_Data.TestFlow
                TesterTypeTextBox.Text = m_Data.TesterType
                TextBoxSetupStatus.Text = m_Data.SetupStatus
                SetStatusColor(TextBoxSetupStatus.Text)

            Case BUTTON_TEXT_SETUP
                Dim newData As FTSetupReport = CType(Session(SESSION_KEY_NEW_DATA_SETUP), FTSetupReport)

                If newData Is Nothing OrElse newData.MCNo <> m_Data.MCNo OrElse newData.SetupStatus = "CANCELED" Then
                    newData = New FTSetupReport()
                    newData.MCNo = m_Data.MCNo
                    newData.SetupStartDate = Now
                    Session(SESSION_KEY_NEW_DATA_SETUP) = newData
                End If

                Response.Redirect("~/SetupStep1.aspx")
        End Select
    End Sub

    Protected Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        Response.Redirect("~/SetupConfirm.aspx")
    End Sub

    Private Sub SetStatusColor(statusText As String)

        Dim lstErr As New List(Of String)

        HideErrorMessage()

        Select Case statusText
            Case SETUP_STATUS_WAITING
                TextBoxSetupStatus.ForeColor = Drawing.Color.Orange
                ButtonConfirm.Visible = True
                ButtonSetup.Text = BUTTON_TEXT_CANCEL
            Case SETUP_STATUS_GOODNGTEST
                TextBoxSetupStatus.ForeColor = Drawing.Color.Green
                ButtonConfirm.Visible = False
                ButtonSetup.Text = BUTTON_TEXT_CANCEL

                lstErr.Add(">>> M/C Status = " + m_Data.SetupStatus + " ด้วย LotNo = " + m_Data.LotNo + " <<< <br/>")
                lstErr.Add("- กรุณาทำ GO/NG Sample Judge")

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

        If m_Data.StatusShonoOP = "0" Then
            lstErr.Add("- กรุณาถ่ายรูปทำ Shoko")
        End If

        If (lstErr.Count() > 0) And (statusText = SETUP_STATUS_GOODNGTEST OrElse statusText = SETUP_STATUS_CONFIRMED) Then
            ShowErrorMessage(String.Join("<br/>", lstErr))
        End If

    End Sub

    'For Matching EQP when Save at SetupStep7CheckSheet9
    Private Sub GetFTSetupReportHistory()
        Dim row As DataRow
        Using dt3 As DataTable = DBAccess.GetFTSetupReportHistoryByMCNo(m_Data.MCNo)

            If dt3.Rows.Count = 1 Then

                row = dt3.Rows(0)

                m_OldData.LotNo = row("LotNo").ToString().ToUpper
                m_OldData.DeviceName = row("DeviceName").ToString().ToUpper
                m_OldData.ProgramName = row("ProgramName").ToString().ToUpper
                m_OldData.SetupStatus = row("SetupStatus").ToString().ToUpper

                'EQP
                m_OldData.TesterNoA = row("TesterNoA").ToString().ToUpper
                m_OldData.TesterNoAQRcode = row("TesterNoAQRcode").ToString().ToUpper
                m_OldData.TesterNoB = row("TesterNoB").ToString().ToUpper
                m_OldData.TesterNoBQRcode = row("TesterNoBQRcode").ToString().ToUpper
                m_OldData.TesterNoC = row("TesterNoC").ToString().ToUpper
                m_OldData.TesterNoCQRcode = row("TesterNoCQRcode").ToString().ToUpper
                m_OldData.TesterNoD = row("TesterNoD").ToString().ToUpper
                m_OldData.TesterNoDQRcode = row("TesterNoDQRcode").ToString().ToUpper
                m_OldData.ChannelAFTB = row("ChannelAFTB").ToString().ToUpper
                m_OldData.ChannelAFTBQRcode = row("ChannelAFTBQRcode").ToString().ToUpper
                m_OldData.ChannelBFTB = row("ChannelBFTB").ToString().ToUpper
                m_OldData.ChannelBFTBQRcode = row("ChannelBFTBQRcode").ToString().ToUpper
                m_OldData.ChannelCFTB = row("ChannelCFTB").ToString().ToUpper
                m_OldData.ChannelCFTBQRcode = row("ChannelCFTBQRcode").ToString().ToUpper
                m_OldData.ChannelDFTB = row("ChannelDFTB").ToString().ToUpper
                m_OldData.ChannelDFTBQRcode = row("ChannelDFTBQRcode").ToString().ToUpper
                m_OldData.ChannelEFTB = row("ChannelEFTB").ToString().ToUpper
                m_OldData.ChannelEFTBQRcode = row("ChannelEFTBQRcode").ToString().ToUpper
                m_OldData.ChannelFFTB = row("ChannelFFTB").ToString().ToUpper
                m_OldData.ChannelFFTBQRcode = row("ChannelFFTBQRcode").ToString().ToUpper
                m_OldData.ChannelGFTB = row("ChannelGFTB").ToString().ToUpper
                m_OldData.ChannelGFTBQRcode = row("ChannelGFTBQRcode").ToString().ToUpper
                m_OldData.ChannelHFTB = row("ChannelHFTB").ToString().ToUpper
                m_OldData.ChannelHFTBQRcode = row("ChannelHFTBQRcode").ToString().ToUpper
                m_OldData.TestBoxA = row("TestBoxA").ToString().ToUpper
                m_OldData.TestBoxAQRcode = row("TestBoxAQRcode").ToString().ToUpper
                m_OldData.TestBoxB = row("TestBoxB").ToString().ToUpper
                m_OldData.TestBoxBQRcode = row("TestBoxBQRcode").ToString().ToUpper
                m_OldData.TestBoxC = row("TestBoxC").ToString().ToUpper
                m_OldData.TestBoxCQRcode = row("TestBoxCQRcode").ToString().ToUpper
                m_OldData.TestBoxD = row("TestBoxD").ToString().ToUpper
                m_OldData.TestBoxDQRcode = row("TestBoxDQRcode").ToString().ToUpper
                m_OldData.TestBoxE = row("TestBoxE").ToString().ToUpper
                m_OldData.TestBoxEQRcode = row("TestBoxEQRcode").ToString().ToUpper
                m_OldData.TestBoxF = row("TestBoxF").ToString().ToUpper
                m_OldData.TestBoxFQRcode = row("TestBoxFQRcode").ToString().ToUpper
                m_OldData.TestBoxG = row("TestBoxG").ToString().ToUpper
                m_OldData.TestBoxGQRcode = row("TestBoxGQRcode").ToString().ToUpper
                m_OldData.TestBoxH = row("TestBoxH").ToString().ToUpper
                m_OldData.TestBoxHQRcode = row("TestBoxHQRcode").ToString().ToUpper
                m_OldData.AdaptorA = row("AdaptorA").ToString().ToUpper
                m_OldData.AdaptorAQRcode = row("AdaptorAQRcode").ToString().ToUpper
                m_OldData.AdaptorB = row("AdaptorB").ToString().ToUpper
                m_OldData.AdaptorBQRcode = row("AdaptorBQRcode").ToString().ToUpper
                m_OldData.DutcardA = row("DutcardA").ToString().ToUpper
                m_OldData.DutcardAQRcode = row("DutcardAQRcode").ToString().ToUpper
                m_OldData.DutcardB = row("DutcardB").ToString().ToUpper
                m_OldData.DutcardBQRcode = row("DutcardBQRcode").ToString().ToUpper
                m_OldData.BridgecableA = row("BridgecableA").ToString().ToUpper
                m_OldData.BridgecableAQRcode = row("BridgecableAQRcode").ToString().ToUpper
                m_OldData.BridgecableB = row("BridgecableB").ToString().ToUpper
                m_OldData.BridgecableBQRcode = row("BridgecableBQRcode").ToString().ToUpper
                'Option
                m_OldData.OptionName1 = row("OptionName1").ToString().ToUpper
                m_OldData.OptionName2 = row("OptionName2").ToString().ToUpper
                m_OldData.OptionName3 = row("OptionName3").ToString().ToUpper
                m_OldData.OptionName4 = row("OptionName4").ToString().ToUpper
                m_OldData.OptionName5 = row("OptionName5").ToString().ToUpper
                m_OldData.OptionName6 = row("OptionName6").ToString().ToUpper
                m_OldData.OptionName7 = row("OptionName7").ToString().ToUpper
                m_OldData.OptionType1 = row("OptionType1").ToString().ToUpper
                m_OldData.OptionType1QRcode = row("OptionType1QRcode").ToString().ToUpper
                m_OldData.OptionType2 = row("OptionType2").ToString().ToUpper
                m_OldData.OptionType2QRcode = row("OptionType2QRcode").ToString().ToUpper
                m_OldData.OptionType3 = row("OptionType3").ToString().ToUpper
                m_OldData.OptionType3QRcode = row("OptionType3QRcode").ToString().ToUpper
                m_OldData.OptionType4 = row("OptionType4").ToString().ToUpper
                m_OldData.OptionType4QRcode = row("OptionType4QRcode").ToString().ToUpper
                m_OldData.OptionType5 = row("OptionType5").ToString().ToUpper
                m_OldData.OptionType5QRcode = row("OptionType5QRcode").ToString().ToUpper
                m_OldData.OptionType6 = row("OptionType6").ToString().ToUpper
                m_OldData.OptionType6QRcode = row("OptionType6QRcode").ToString().ToUpper
                m_OldData.OptionType7 = row("OptionType7").ToString().ToUpper
                m_OldData.OptionType7QRcode = row("OptionType7QRcode").ToString().ToUpper
                m_OldData.OptionSetting1 = row("OptionSetting1").ToString().ToUpper
                m_OldData.OptionSetting2 = row("OptionSetting2").ToString().ToUpper
                m_OldData.OptionSetting3 = row("OptionSetting3").ToString().ToUpper
                m_OldData.OptionSetting4 = row("OptionSetting4").ToString().ToUpper
                m_OldData.OptionSetting5 = row("OptionSetting5").ToString().ToUpper
                m_OldData.OptionSetting6 = row("OptionSetting6").ToString().ToUpper
                m_OldData.OptionSetting7 = row("OptionSetting7").ToString().ToUpper
                'Socket
                m_OldData.QRCodesocket1 = row("QRCodesocket1").ToString().ToUpper
                m_OldData.QRCodesocket2 = row("QRCodesocket2").ToString().ToUpper
                m_OldData.QRCodesocket3 = row("QRCodesocket3").ToString().ToUpper
                m_OldData.QRCodesocket4 = row("QRCodesocket4").ToString().ToUpper
                m_OldData.QRCodesocketChannel1 = row("QRCodesocketChannel1").ToString().ToUpper
                m_OldData.QRCodesocketChannel2 = row("QRCodesocketChannel2").ToString().ToUpper
                m_OldData.QRCodesocketChannel3 = row("QRCodesocketChannel3").ToString().ToUpper
                m_OldData.QRCodesocketChannel4 = row("QRCodesocketChannel4").ToString().ToUpper
                m_OldData.QRCodesocket5 = row("QRCodesocket5").ToString().ToUpper
                m_OldData.QRCodesocket6 = row("QRCodesocket6").ToString().ToUpper
                m_OldData.QRCodesocket7 = row("QRCodesocket7").ToString().ToUpper
                m_OldData.QRCodesocket8 = row("QRCodesocket8").ToString().ToUpper
                m_OldData.QRCodesocketChannel5 = row("QRCodesocketChannel5").ToString().ToUpper
                m_OldData.QRCodesocketChannel6 = row("QRCodesocketChannel6").ToString().ToUpper
                m_OldData.QRCodesocketChannel7 = row("QRCodesocketChannel7").ToString().ToUpper
                m_OldData.QRCodesocketChannel8 = row("QRCodesocketChannel8").ToString().ToUpper
                'Shoko
                m_OldData.ConfirmedShonoSection = row("ConfirmedShonoSection").ToString().ToUpper
                m_OldData.ConfirmedShonoGL = row("ConfirmedShonoGL").ToString().ToUpper
                m_OldData.ConfirmedShonoOp = row("ConfirmedShonoOp").ToString().ToUpper
                m_OldData.StatusShonoOP = row("StatusShonoOP").ToString().ToUpper

            Else
                'first time of MC
                m_OldData.LotNo = ""
                m_OldData.DeviceName = ""
                m_OldData.ProgramName = ""
                m_OldData.SetupStatus = ""

                'EQP
                m_OldData.TesterNoA = ""
                m_OldData.TesterNoAQRcode = ""
                m_OldData.TesterNoB = ""
                m_OldData.TesterNoBQRcode = ""
                m_OldData.TesterNoC = ""
                m_OldData.TesterNoCQRcode = ""
                m_OldData.TesterNoD = ""
                m_OldData.TesterNoDQRcode = ""
                m_OldData.ChannelAFTB = ""
                m_OldData.ChannelAFTBQRcode = ""
                m_OldData.ChannelBFTB = ""
                m_OldData.ChannelBFTBQRcode = ""
                m_OldData.ChannelCFTB = ""
                m_OldData.ChannelCFTBQRcode = ""
                m_OldData.ChannelDFTB = ""
                m_OldData.ChannelDFTBQRcode = ""
                m_OldData.ChannelEFTB = ""
                m_OldData.ChannelEFTBQRcode = ""
                m_OldData.ChannelFFTB = ""
                m_OldData.ChannelFFTBQRcode = ""
                m_OldData.ChannelGFTB = ""
                m_OldData.ChannelGFTBQRcode = ""
                m_OldData.ChannelHFTB = ""
                m_OldData.ChannelHFTBQRcode = ""
                m_OldData.TestBoxA = ""
                m_OldData.TestBoxAQRcode = ""
                m_OldData.TestBoxB = ""
                m_OldData.TestBoxBQRcode = ""
                m_OldData.TestBoxC = ""
                m_OldData.TestBoxCQRcode = ""
                m_OldData.TestBoxD = ""
                m_OldData.TestBoxDQRcode = ""
                m_OldData.TestBoxE = ""
                m_OldData.TestBoxEQRcode = ""
                m_OldData.TestBoxF = ""
                m_OldData.TestBoxFQRcode = ""
                m_OldData.TestBoxG = ""
                m_OldData.TestBoxGQRcode = ""
                m_OldData.TestBoxH = ""
                m_OldData.TestBoxHQRcode = ""
                m_OldData.AdaptorA = ""
                m_OldData.AdaptorAQRcode = ""
                m_OldData.AdaptorB = ""
                m_OldData.AdaptorBQRcode = ""
                m_OldData.DutcardA = ""
                m_OldData.DutcardAQRcode = ""
                m_OldData.DutcardB = ""
                m_OldData.DutcardBQRcode = ""
                m_OldData.BridgecableA = ""
                m_OldData.BridgecableAQRcode = ""
                m_OldData.BridgecableB = ""
                m_OldData.BridgecableBQRcode = ""
                'Option
                m_OldData.OptionName1 = ""
                m_OldData.OptionName2 = ""
                m_OldData.OptionName3 = ""
                m_OldData.OptionName4 = ""
                m_OldData.OptionName5 = ""
                m_OldData.OptionName6 = ""
                m_OldData.OptionName7 = ""
                m_OldData.OptionType1 = ""
                m_OldData.OptionType1QRcode = ""
                m_OldData.OptionType2 = ""
                m_OldData.OptionType2QRcode = ""
                m_OldData.OptionType3 = ""
                m_OldData.OptionType3QRcode = ""
                m_OldData.OptionType4 = ""
                m_OldData.OptionType4QRcode = ""
                m_OldData.OptionType5 = ""
                m_OldData.OptionType5QRcode = ""
                m_OldData.OptionType6 = ""
                m_OldData.OptionType6QRcode = ""
                m_OldData.OptionType7 = ""
                m_OldData.OptionType7QRcode = ""
                m_OldData.OptionSetting1 = ""
                m_OldData.OptionSetting2 = ""
                m_OldData.OptionSetting3 = ""
                m_OldData.OptionSetting4 = ""
                m_OldData.OptionSetting5 = ""
                m_OldData.OptionSetting6 = ""
                m_OldData.OptionSetting7 = ""
                'Socket
                m_OldData.QRCodesocket1 = ""
                m_OldData.QRCodesocket2 = ""
                m_OldData.QRCodesocket3 = ""
                m_OldData.QRCodesocket4 = ""
                m_OldData.QRCodesocketChannel1 = ""
                m_OldData.QRCodesocketChannel2 = ""
                m_OldData.QRCodesocketChannel3 = ""
                m_OldData.QRCodesocketChannel4 = ""
                m_OldData.QRCodesocket5 = ""
                m_OldData.QRCodesocket6 = ""
                m_OldData.QRCodesocket7 = ""
                m_OldData.QRCodesocket8 = ""
                m_OldData.QRCodesocketChannel5 = ""
                m_OldData.QRCodesocketChannel6 = ""
                m_OldData.QRCodesocketChannel7 = ""
                m_OldData.QRCodesocketChannel8 = ""
                'Shoko
                m_OldData.ConfirmedShonoSection = ""
                m_OldData.ConfirmedShonoGL = ""
                m_OldData.ConfirmedShonoOp = ""
                m_OldData.StatusShonoOP = ""
            End If
        End Using
        Session(SESSION_KEY_OLD_DATA) = m_OldData
    End Sub

    Private Sub GetFTSetupReport(row As DataRow)
        Using dt2 As DataTable = DBAccess.GetFTSetupReportByMCNo(m_Data.MCNo)
            Dim datetime As DateTime
            If dt2.Rows.Count = 1 Then

                row = dt2.Rows(0)

                m_Data.LotNo = row("LotNo").ToString().ToUpper
                m_Data.DeviceName = row("DeviceName").ToString().ToUpper
                m_Data.TestFlow = row("TestFlow").ToString().ToUpper
                m_Data.TesterType = row("TesterType").ToString().ToUpper
                m_Data.OISRank = row("OISRank").ToString().ToUpper
                m_Data.OISDevice = row("OISDevice").ToString().ToUpper
                m_Data.SetupStatus = row("SetupStatus").ToString().ToUpper
                m_Data.StatusShonoOP = row("StatusShonoOP").ToString().ToUpper

                If m_Data.SetupStatus = "WAITING" Then 'For Confirm Data immediately
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
                'first time of MC
                m_Data.DeviceName = ""
                m_Data.TestFlow = ""
                m_Data.TesterType = ""
                m_Data.OISRank = ""
                m_Data.OISDevice = ""
                m_Data.SetupStatus = ""

                DBAccess.CreateBlankFTSetupRecord(m_Data.MCNo)

            End If
        End Using
    End Sub

    Private Sub RemoveSpecialFlow(lotId As Int32, specialflowId As Int32, flowId As Int32)
        'Clear Special Flow here
        Try
            Dim result As Integer = DBAccess.ClearSpecialFlow(lotId, specialflowId, flowId)

            If result = 1 Then
                ShowErrorMessage("ไม่สามารถลบ Flows GO/NG Sample Judge ได้ Lot เป็น Multi-Special Flows")
                Exit Sub
            ElseIf result = 2 Then
                ShowErrorMessage("ไม่สามารถลบ Flows GO/NG Sample Judge ได้ Lot เป็น Processing")
                Exit Sub
            End If
        Catch ex As Exception
            ShowErrorMessage("Failed to clear special flow : " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub SetNextLotHere(mcNo As String, lotNo As String)
        'Set Next Lot here
        Try
            DBAccess.SetNextLot(mcNo, lotNo)
        Catch ex As Exception
            ShowErrorMessage("Failed to Add Next Lots :" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub SetFTReport()
        '1. save to database with status = 'CANCELED' before clear all data 
        Try
            '2. do cancel no need reson
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
                                                                 m_Data.QRCodesocketChannel1,
                                                                 m_Data.QRCodesocketChannel2,
                                                                 m_Data.QRCodesocketChannel3,
                                                                 m_Data.QRCodesocketChannel4,
                                                                 m_Data.QRCodesocket5,
                                                                 m_Data.QRCodesocket6,
                                                                 m_Data.QRCodesocket7,
                                                                 m_Data.QRCodesocket8,
                                                                 m_Data.QRCodesocketChannel5,
                                                                 m_Data.QRCodesocketChannel6,
                                                                 m_Data.QRCodesocketChannel7,
                                                                 m_Data.QRCodesocketChannel8,
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

        Catch ex As Exception
            ShowErrorMessage("Update Failed : " & ex.Message)
        End Try
    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

End Class