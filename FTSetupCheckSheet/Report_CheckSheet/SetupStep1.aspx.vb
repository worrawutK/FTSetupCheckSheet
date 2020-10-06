Imports System.IO
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class SetupStep1
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OISTextBox.Focus()
        ButtonSkip.Enabled = False

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)
        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If
        If Not IsPostBack Then
            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypetext.Text = m_Data.TesterType
        End If
    End Sub

    Protected Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        Response.Redirect("~/SetupMain.aspx")
    End Sub

    Protected Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        Response.Redirect("~/SetupStep2.aspx")
    End Sub

    Protected Sub ButtonSkip_Click(sender As Object, e As EventArgs) Handles ButtonSkip.Click

        Using dt2 As DataTable = DBAccess.GetFTSetupReportByMCNo(m_Data.MCNo)

            If dt2.Rows.Count = 1 Then

                Dim row As DataRow = dt2.Rows(0)

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
                Response.Redirect("~/SetupMain.aspx")
            End If
        End Using

        Session(SESSION_KEY_DATA) = m_Data
        Response.Redirect("~/SetupStep7CheckSheet1.aspx")
    End Sub

    Protected Sub OISTextBox_TextChanged(sender As Object, e As EventArgs) Handles OISTextBox.TextChanged

        If Not String.IsNullOrEmpty(OISTextBox.Text) Then

            '0  1         2   3     4        5       6          7
            'QC,BD62012FS,/-S,AUTO1,SSOP-A24,ICT2000,F2 BD62012,FD62012B
            Dim data As String() = OISTextBox.Text.Split(","c)

            OISTextBox.Text = ""

            If data.Length <> 8 Then
                Exit Sub
            End If

            m_Data.TestFlow = data(3).ToUpper().Trim()
            m_Data.TesterType = data(5).ToUpper().Trim()
            m_Data.SetupStartDate = Now
            m_Data.ProgramName = data(7).ToUpper().Trim()

            TestflowTextBox.Text = m_Data.TestFlow
            TesterTypetext.Text = m_Data.TesterType

            ButtonSkip.Enabled = True

            Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data

        End If

    End Sub
End Class