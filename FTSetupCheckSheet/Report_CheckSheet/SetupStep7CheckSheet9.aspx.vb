Public Class SetupStep7CheckSheet9
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport
    Private m_OldData As FTSetupReportHistory

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)
        Dim tmp2 As Object = Session(SESSION_KEY_OLD_DATA)

        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
            m_OldData = CType(tmp2, FTSetupReportHistory)
        End If

        If Not IsPostBack Then
            selecCheckSheet.Value = m_Data.SetupStatus
            selecBge5s.Value = m_Data.Bge5S

            If m_Data.StatusOldEQP Then
                selecCheckSheet.Disabled = True
                selecBge5s.Disabled = True
            End If

        End If
    End Sub

    Public Sub UpdateSessionData()
        m_Data.Bge5S = selecBge5s.Value
        m_Data.SetupStatus = selecCheckSheet.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet8.aspx")
    End Sub

    Protected Sub Savebutton_Check_Click(sender As Object, e As EventArgs) Handles Savebutton_Check.Click

        m_Data.SetupEndDate = Now
        m_Data.LotNo = ""
        m_Data.PackageName = ""
        m_Data.DeviceName = ""
        m_Data.SetupConfirmDate = Nothing
        m_Data.Bge5S = selecBge5s.Value
        m_Data.SetupStatus = SETUP_STATUS_WAITING

        MatchOldandNewEQP()
        SetFTReport()

    End Sub

    Private Sub MatchOldandNewEQP()
        'not press old_eqp button and not same eqp
        If m_Data.StatusOldEQP = False And Not (m_Data.TesterNoA = m_OldData.TesterNoA AndAlso m_Data.TesterNoAQRcode = m_OldData.TesterNoAQRcode AndAlso
                                            m_Data.TesterNoB = m_OldData.TesterNoB AndAlso m_Data.TesterNoBQRcode = m_OldData.TesterNoBQRcode AndAlso
                                            m_Data.TesterNoC = m_OldData.TesterNoC AndAlso m_Data.TesterNoCQRcode = m_OldData.TesterNoCQRcode AndAlso
                                            m_Data.TesterNoD = m_OldData.TesterNoD AndAlso m_Data.TesterNoDQRcode = m_OldData.TesterNoDQRcode AndAlso
                                            m_Data.ChannelAFTB = m_OldData.ChannelAFTB AndAlso m_Data.ChannelAFTBQRcode = m_OldData.ChannelAFTBQRcode AndAlso
                                            m_Data.ChannelBFTB = m_OldData.ChannelBFTB AndAlso m_Data.ChannelBFTBQRcode = m_OldData.ChannelBFTBQRcode AndAlso
                                            m_Data.ChannelCFTB = m_OldData.ChannelCFTB AndAlso m_Data.ChannelCFTBQRcode = m_OldData.ChannelCFTBQRcode AndAlso
                                            m_Data.ChannelDFTB = m_OldData.ChannelDFTB AndAlso m_Data.ChannelDFTBQRcode = m_OldData.ChannelDFTBQRcode AndAlso
                                            m_Data.ChannelEFTB = m_OldData.ChannelEFTB AndAlso m_Data.ChannelEFTBQRcode = m_OldData.ChannelEFTBQRcode AndAlso
                                            m_Data.ChannelFFTB = m_OldData.ChannelFFTB AndAlso m_Data.ChannelFFTBQRcode = m_OldData.ChannelFFTBQRcode AndAlso
                                            m_Data.ChannelGFTB = m_OldData.ChannelGFTB AndAlso m_Data.ChannelGFTBQRcode = m_OldData.ChannelGFTBQRcode AndAlso
                                            m_Data.ChannelHFTB = m_OldData.ChannelHFTB AndAlso m_Data.ChannelHFTBQRcode = m_OldData.ChannelHFTBQRcode AndAlso
                                            m_Data.TestBoxA = m_OldData.TestBoxA AndAlso m_Data.TestBoxAQRcode = m_OldData.TestBoxAQRcode AndAlso
                                            m_Data.TestBoxB = m_OldData.TestBoxB AndAlso m_Data.TestBoxBQRcode = m_OldData.TestBoxBQRcode AndAlso
                                            m_Data.TestBoxC = m_OldData.TestBoxC AndAlso m_Data.TestBoxCQRcode = m_OldData.TestBoxCQRcode AndAlso
                                            m_Data.TestBoxD = m_OldData.TestBoxD AndAlso m_Data.TestBoxDQRcode = m_OldData.TestBoxDQRcode AndAlso
                                            m_Data.TestBoxE = m_OldData.TestBoxE AndAlso m_Data.TestBoxEQRcode = m_OldData.TestBoxEQRcode AndAlso
                                            m_Data.TestBoxF = m_OldData.TestBoxF AndAlso m_Data.TestBoxFQRcode = m_OldData.TestBoxFQRcode AndAlso
                                            m_Data.TestBoxG = m_OldData.TestBoxG AndAlso m_Data.TestBoxGQRcode = m_OldData.TestBoxGQRcode AndAlso
                                            m_Data.TestBoxH = m_OldData.TestBoxH AndAlso m_Data.TestBoxHQRcode = m_OldData.TestBoxHQRcode AndAlso
                                            m_Data.AdaptorA = m_OldData.AdaptorA AndAlso m_Data.AdaptorAQRcode = m_OldData.AdaptorAQRcode AndAlso
                                            m_Data.AdaptorB = m_OldData.AdaptorB AndAlso m_Data.AdaptorBQRcode = m_OldData.AdaptorBQRcode AndAlso
                                            m_Data.DutcardA = m_OldData.DutcardA AndAlso m_Data.DutcardAQRcode = m_OldData.DutcardAQRcode AndAlso
                                            m_Data.DutcardB = m_OldData.DutcardB AndAlso m_Data.DutcardBQRcode = m_OldData.DutcardBQRcode AndAlso
                                            m_Data.BridgecableA = m_OldData.BridgecableA AndAlso m_Data.BridgecableAQRcode = m_OldData.BridgecableAQRcode AndAlso
                                            m_Data.BridgecableB = m_OldData.BridgecableB AndAlso m_Data.BridgecableBQRcode = m_OldData.BridgecableBQRcode) Then

            m_Data.StatusShonoOP = "0"
            m_Data.ConfirmedShonoGL = ""
            m_Data.ConfirmedShonoOp = ""
            m_Data.ConfirmedShonoSection = ""
        Else
            m_Data.StatusShonoOP = m_OldData.StatusShonoOP
            m_Data.ConfirmedShonoGL = m_OldData.ConfirmedShonoGL
            m_Data.ConfirmedShonoOp = m_OldData.ConfirmedShonoOp
            m_Data.ConfirmedShonoSection = m_OldData.ConfirmedShonoSection
        End If
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
                                                                 m_Data.QfpTray,
                                                                 m_Data.SopStopper,
                                                                 m_Data.SopSocketDecision,
                                                                 m_Data.SopDecisionLeadPress,
                                                                 m_Data.ManualCheckTest,
                                                                 m_Data.ManualCheckTE,
                                                                 m_Data.ManualCheckRequestTE,
                                                                 m_Data.ManualCheckRequestTEConfirm,
                                                                 m_Data.PkgGood,
                                                                 m_Data.PkgNG,
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

            Response.Redirect("~/SetupMain.aspx")

        Catch ex As Exception
            ShowErrorMessage("Update Failed : " & HttpUtility.HtmlEncode(ex.Message & vbNewLine & ex.StackTrace))
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