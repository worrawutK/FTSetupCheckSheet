Public Class SetupStep7CheckSheet9
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
            selecCheckSheet.Value = m_Data.SetupStatus
            selecBge5s.Value = m_Data.Bge5S
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
                                         m_Data.PkgNishikiCamara, m_Data.PkgNishikiCamaraJudgement, m_Data.PkqBantLead, m_Data.PkqKakeHige, m_Data.BgaSmallBall,
                                         m_Data.BgaBentTape, m_Data.Bge5S, SETUP_STATUS_WAITING, m_Data.ConfirmedCheckSheetOp, m_Data.ConfirmedCheckSheetSection,
                                         m_Data.ConfirmedCheckSheetGL, m_Data.ConfirmedShonoSection, m_Data.ConfirmedShonoGL,
                                         m_Data.ConfirmedShonoOp, m_Data.StatusShonoOP, m_Data.SetupConfirmDate)

            m_Data.SetupStatus = SETUP_STATUS_WAITING

            Session(SESSION_KEY_DATA) = m_Data
            Session(SESSION_KEY_NEW_DATA_SETUP) = Nothing

            Response.Redirect("~/SetupMain.aspx")

        Catch ex As Exception
            ShowErrorMessage("Update Filed : " & HttpUtility.HtmlEncode(ex.Message & vbNewLine & ex.StackTrace))
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