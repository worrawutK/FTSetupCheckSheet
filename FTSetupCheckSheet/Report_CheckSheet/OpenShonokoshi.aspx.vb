﻿Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class OpenShonokoshi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim s_MCNo As String
        Dim s_LotNo As String
        Dim s_PackageName As String
        Dim s_DeviceName As String
        Dim s_ProgramName As String
        Dim s_TesterType As String
        Dim s_TestFlow As String
        Dim s_QRCodesocket1 As String
        Dim s_QRCodesocket2 As String
        Dim s_QRCodesocket3 As String
        Dim s_QRCodesocket4 As String
        Dim s_TesterNoA As String
        Dim s_TesterNoB As String
        Dim s_ChannelAFTB As String
        Dim s_ChannelBFTB As String
        Dim s_TestBoxA As String
        Dim s_TestBoxB As String
        Dim s_AdaptorA As String
        Dim s_AdaptorB As String
        Dim s_DutcardA As String
        Dim s_DutcardB As String
        Dim s_BridgecableA As String
        Dim s_BridgecableB As String
        Dim s_TypeChangePackage As String
        Dim s_SetupStartDate As String
        Dim s_SetupEndDate As String
        Dim s_BoxTesterConnection As String
        Dim s_OptionSetup As String
        Dim s_OptionConnection As String
        Dim s_OptionName1 As String
        Dim s_OptionName2 As String
        Dim s_OptionName3 As String
        Dim s_OptionName4 As String
        Dim s_OptionName5 As String
        Dim s_OptionName6 As String
        Dim s_OptionName7 As String
        Dim s_OptionType1 As String
        Dim s_OptionType2 As String
        Dim s_OptionType3 As String
        Dim s_OptionType4 As String
        Dim s_OptionType5 As String
        Dim s_OptionType6 As String
        Dim s_OptionType7 As String
        Dim s_OptionSetting1 As String
        Dim s_OptionSetting2 As String
        Dim s_Optionsetting3 As String
        Dim s_Optionsetting4 As String
        Dim s_Optionsetting5 As String
        Dim s_Optionsetting6 As String
        Dim s_Optionsetting7 As String
        Dim s_QfpVacuumPad As String
        Dim s_QfpSocketSetup As String
        Dim s_QfpSocketDecision As String
        Dim s_QfpDecisionLeadPress As String
        Dim s_QfpTray As String
        Dim s_SopStopper As String
        Dim s_SopSocketDecision As String
        Dim s_SopDecisionLeadPress As String
        Dim s_ManualCheckTest As String
        Dim s_ManualCheckTE As String
        Dim s_ManualCheckRequestTE As String
        Dim s_ManualCheckRequestTEConfirm As String
        Dim s_PkgGood As String
        Dim s_PkgNG As String
        Dim s_PkgGoodJudgement As String
        Dim s_PkgNGJudgement As String
        Dim s_PkgNishikiCamara As String
        Dim s_PkgNishikiCamaraJudgement As String
        Dim s_PkgBantLead As String
        Dim s_PkgKakeHige As String
        Dim s_BgaSmallBall As String
        Dim s_BgeBentTape As String
        Dim s_Bge5s As String
        Dim s_SetupStatus As String
        Dim s_SetupConfirmDate As String
        Dim s_ConfirmedCheckSheetSection As String
        Dim s_ConfirmedCheckSheetGL As String
        Dim s_ConfirmedCheckSheetOp As String
        Dim s_ConfirmedShonoSection As String
        Dim s_ConfirmedShonoGL As String
        Dim s_ConfirmedShonoOp As String
        Dim s_DateSetup As DateTime
        Dim s_DateEndSetup As DateTime
        Dim s_DateConfirmed1 As DateTime


        Using con As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
            con.Open()
            Dim sqlFtSetup As String = "SELECT MCNo, LotNo, PackageName, DeviceName, ProgramName, TesterType, TestFlow, QRCodesocket1, QRCodesocket2, QRCodesocket3, 
                                      QRCodesocket4, QRCodesocketChannel1, QRCodesocketChannel2, QRCodesocketChannel3, QRCodesocketChannel4, TesterNoA, 
                                      TesterNoAQRcode, TesterNoB, TesterNoBQRcode, ChannelAFTB, ChannelAFTBQRcode, ChannelBFTB, ChannelBFTBQRcode, TestBoxA, 
                                      TestBoxAQRcode, TestBoxB, TestBoxBQRcode, AdaptorA, AdaptorAQRcode, AdaptorB, AdaptorBQRcode, DutcardA, DutcardAQRcode, DutcardB, 
                                      DutcardBQRcode, BridgecableA, BridgecableAQRcode, BridgecableB, BridgecableBQRcode, TypeChangePackage, SetupStartDate, SetupEndDate, 
                                      BoxTesterConnection, OptionSetup, OptionConnection, OptionName1, OptionName2, OptionName3, OptionName4, OptionName5, OptionName6, 
                                      OptionName7, OptionType1, OptionType1QRcode, OptionType2, OptionType2QRcode, OptionType3, OptionType3QRcode, OptionType4, 
                                      OptionType4QRcode, OptionType5, OptionType5QRcode, OptionType6, OptionType6QRcode, OptionType7, OptionType7QRcode, OptionSetting1, 
                                      OptionSetting2, OptionSetting3, OptionSetting4, OptionSetting5, OptionSetting6, OptionSetting7, QfpVacuumPad, QfpSocketSetup, QfpSocketDecision, 
                                      QfpDecisionLeadPress, QfpTray, SopStopper, SopSocketDecision, SopDecisionLeadPress, ManualCheckTest, ManualCheckTE, ManualCheckRequestTE, 
                                      ManualCheckRequestTEConfirm, PkgGood, PkgNG, PkgGoodJudgement, PkgNGJudgement, PkgNishikiCamara, PkgNishikiCamaraJudgement, 
                                      PkqBantLead, PkqKakeHige, BgaSmallBall, BgaBentTape, Bge5S, SetupStatus, SetupConfirmDate, ConfirmedCheckSheetOp, 
                                      ConfirmedCheckSheetSection, ConfirmedCheckSheetGL, ConfirmedShonoSection, ConfirmedShonoGL, ConfirmedShonoOp, StatusShonoOP, RecordTime
                                      FROM DBx.dbo.FTSetupReportHistory WHERE LotNo ='" & Request.QueryString("LotNo") & "' AND MCNo = '" & Request.QueryString("MCNo") & "' Order by SetupConfirmDate desc"


            Using cmd As New SqlCommand(sqlFtSetup, con)
                Using d As SqlDataReader = cmd.ExecuteReader()
                    If d.Read Then
                        s_MCNo = d("MCNo").ToString()
                        s_LotNo = d("LotNo").ToString()
                        s_PackageName = d("PackageName").ToString()
                        s_DeviceName = d("DeviceName").ToString()
                        s_ProgramName = d("ProgramName").ToString()
                        s_TesterType = d("TesterType").ToString()
                        s_TestFlow = d("TestFlow").ToString()
                        s_QRCodesocket1 = d("QRCodesocket1").ToString()
                        s_QRCodesocket2 = d("QRCodesocket2").ToString()
                        s_QRCodesocket3 = d("QRCodesocket3").ToString()
                        s_QRCodesocket4 = d("QRCodesocket4").ToString()
                        s_TesterNoA = d("TesterNoA").ToString()
                        s_TesterNoB = d("TesterNoB").ToString()
                        s_ChannelAFTB = d("ChannelAFTB").ToString()
                        s_ChannelBFTB = d("ChannelBFTB").ToString()
                        s_TestBoxA = d("TestBoxA").ToString()
                        s_TestBoxB = d("TestBoxB").ToString()
                        s_AdaptorA = d("AdaptorA").ToString()
                        s_AdaptorB = d("AdaptorB").ToString()
                        s_DutcardA = d("DutcardA").ToString()
                        s_DutcardB = d("DutcardB").ToString()
                        s_BridgecableA = d("BridgecableA").ToString()
                        s_BridgecableB = d("BridgecableB").ToString()
                        s_TypeChangePackage = d("TypeChangePackage").ToString()
                        s_SetupStartDate = d("SetupStartDate").ToString()
                        s_SetupEndDate = d("SetupEndDate").ToString()
                        s_BoxTesterConnection = d("BoxTesterConnection").ToString()
                        s_OptionSetup = d("OptionSetup").ToString()
                        s_OptionConnection = d("OptionConnection").ToString()
                        s_OptionName1 = d("OptionName1").ToString()
                        s_OptionName2 = d("OptionName2").ToString()
                        s_OptionName3 = d("OptionName3").ToString()
                        s_OptionName4 = d("OptionName4").ToString()
                        s_OptionName5 = d("OptionName5").ToString()
                        s_OptionName6 = d("OptionName6").ToString()
                        s_OptionName7 = d("OptionName7").ToString()
                        s_OptionType1 = d("OptionType1").ToString()
                        s_OptionType2 = d("OptionType2").ToString()
                        s_OptionType3 = d("OptionType3").ToString()
                        s_OptionType4 = d("OptionType4").ToString()
                        s_OptionType5 = d("OptionType5").ToString()
                        s_OptionType6 = d("OptionType6").ToString()
                        s_OptionType7 = d("OptionType7").ToString()
                        s_OptionSetting1 = d("OptionSetting1").ToString()
                        s_OptionSetting2 = d("OptionSetting2").ToString()
                        s_Optionsetting3 = d("OptionSetting3").ToString()
                        s_Optionsetting4 = d("OptionSetting4").ToString()
                        s_Optionsetting5 = d("OptionSetting5").ToString()
                        s_Optionsetting6 = d("OptionSetting6").ToString()
                        s_Optionsetting7 = d("OptionSetting7").ToString()
                        s_QfpVacuumPad = d("QfpVacuumPad").ToString()
                        s_QfpSocketSetup = d("QfpSocketSetup").ToString()
                        s_QfpSocketDecision = d("QfpSocketDecision").ToString()
                        s_QfpDecisionLeadPress = d("QfpDecisionLeadPress").ToString()
                        s_QfpTray = d("QfpTray").ToString()
                        s_SopStopper = d("SopStopper").ToString()
                        s_SopSocketDecision = d("SopSocketDecision").ToString()
                        s_SopDecisionLeadPress = d("SopDecisionLeadPress").ToString()
                        s_ManualCheckTest = d("ManualCheckTest").ToString()
                        s_ManualCheckTE = d("ManualCheckTE").ToString()
                        s_ManualCheckRequestTE = d("ManualCheckRequestTE").ToString()
                        s_ManualCheckRequestTEConfirm = d("ManualCheckRequestTEConfirm").ToString()
                        s_PkgGood = d("PkgGood").ToString()
                        s_PkgNG = d("PkgNG").ToString()
                        s_PkgGoodJudgement = d("PkgGoodJudgement").ToString()
                        s_PkgNGJudgement = d("PkgNGJudgement").ToString()
                        s_PkgNishikiCamara = d("PkgNishikiCamara").ToString()
                        s_PkgNishikiCamaraJudgement = d("PkgNishikiCamaraJudgement").ToString()
                        s_PkgBantLead = d("PkqBantLead").ToString()
                        s_PkgKakeHige = d("PkqKakeHige").ToString()
                        s_BgaSmallBall = d("BgaSmallBall").ToString()
                        s_BgeBentTape = d("BgaBentTape").ToString()
                        s_Bge5s = d("Bge5S").ToString()
                        s_SetupStatus = d("SetupStatus").ToString()
                        s_SetupConfirmDate = d("SetupConfirmDate").ToString()
                        s_ConfirmedCheckSheetSection = d("ConfirmedCheckSheetSection").ToString()
                        s_ConfirmedCheckSheetGL = d("ConfirmedCheckSheetGL").ToString()
                        s_ConfirmedCheckSheetOp = d("ConfirmedCheckSheetOp").ToString()
                        s_ConfirmedShonoSection = d("ConfirmedShonoSection").ToString()
                        s_ConfirmedShonoGL = d("ConfirmedShonoGL").ToString()
                        s_ConfirmedShonoGL = d("ConfirmedShonoOp").ToString()
                        s_DateSetup = CDate(d("SetupStartDate").ToString)
                        s_DateEndSetup = CDate(d("SetupEndDate").ToString)
                        s_DateConfirmed1 = CDate(d("SetupConfirmDate").ToString)

                    End If
                End Using
            End Using
        End Using

        'Create File PDF
        Dim pdf As New Document(PageSize.A4, 1, 1, 1, 1)
        Dim rt As New MemoryStream()

        Dim pdfWriter As PdfWriter = Nothing
        pdfWriter = PdfWriter.GetInstance(pdf, rt)

        pdf.Open()

        'Pictures writer to PDF Report
        Dim Stampimages As Image = iTextSharp.text.Image.GetInstance(Server.MapPath("images") + "/Setup5.jpg")
        Stampimages.ScalePercent(12.5)
        Stampimages.SetAbsolutePosition(15, 20)
        pdf.Add(Stampimages)

        'Writer text
        Dim G_PGN As PdfContentByte = pdfWriter.DirectContent

        G_PGN.BeginText()
        Dim f_pn1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn1.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 716)
        G_PGN.ShowText(s_PackageName)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn2 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn2.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 705)
        G_PGN.ShowText(s_DeviceName)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn3 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn3.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 693)
        G_PGN.ShowText(s_LotNo)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn4 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn4.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 681)
        G_PGN.ShowText(s_MCNo)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn5 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn5.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 669)
        G_PGN.ShowText(s_TesterNoA)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn6 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn6.BaseFont, 5)
        G_PGN.SetTextMatrix(502, 669)
        G_PGN.ShowText(s_TesterNoB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn7 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn7.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 655)
        G_PGN.ShowText(s_ChannelAFTB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn8 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn8.BaseFont, 5)
        G_PGN.SetTextMatrix(502, 655)
        G_PGN.ShowText(s_ChannelBFTB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn9 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn9.BaseFont, 5)
        G_PGN.SetTextMatrix(431, 642.5)
        G_PGN.ShowText(s_TestBoxA)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn10 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn10.BaseFont, 5)
        G_PGN.SetTextMatrix(488, 642.5)
        G_PGN.ShowText(s_TestBoxB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn11 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn11.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 477)
        G_PGN.ShowText(s_ProgramName)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn12 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn12.BaseFont, 5)
        G_PGN.SetTextMatrix(431, 630.5)
        G_PGN.ShowText(s_AdaptorA)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn13 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn13.BaseFont, 5)
        G_PGN.SetTextMatrix(488, 630.5)
        G_PGN.ShowText(s_AdaptorB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn14 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn14.BaseFont, 5)
        G_PGN.SetTextMatrix(431, 618.5)
        G_PGN.ShowText(s_DutcardA)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn15 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn15.BaseFont, 5)
        G_PGN.SetTextMatrix(488, 618.5)
        G_PGN.ShowText(s_DutcardB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn16 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn16.BaseFont, 5)
        G_PGN.SetTextMatrix(431, 607)
        G_PGN.ShowText(s_BridgecableA)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn17 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn17.BaseFont, 5)
        G_PGN.SetTextMatrix(488, 607)
        G_PGN.ShowText(s_BridgecableB)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn18 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn18.BaseFont, 5)
        G_PGN.SetTextMatrix(448, 463)
        G_PGN.ShowText(s_PackageName)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn19 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn19.BaseFont, 5)
        G_PGN.SetTextMatrix(500, 463)
        G_PGN.ShowText(s_TypeChangePackage)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn20 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn20.BaseFont, 5)
        G_PGN.SetTextMatrix(512, 392)
        G_PGN.ShowText(s_QRCodesocket1)
        G_PGN.EndText()

        'OptionName 1-7
        G_PGN.BeginText()
        Dim f_pn21 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn21.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 549)
        G_PGN.ShowText(s_OptionName1)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn22 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn22.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 540)
        G_PGN.ShowText(s_OptionName2)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn23 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn23.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 531)
        G_PGN.ShowText(s_OptionName3)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn24 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn24.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 521)
        G_PGN.ShowText(s_OptionName4)

        Dim f_pn25 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn25.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 511)
        G_PGN.ShowText(s_OptionName5)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn26 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn26.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 501)
        G_PGN.ShowText(s_OptionName6)
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn27 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn27.BaseFont, 5)
        G_PGN.SetTextMatrix(410, 491)
        G_PGN.ShowText(s_OptionName7)
        G_PGN.EndText()

        'OptionSetting 1-7
        G_PGN.BeginText()
        Dim f_pn28 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn28.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 549)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn29 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn29.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 540)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn30 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn30.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 531)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn31 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn31.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 521)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn32 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn32.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 511)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn33 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn33.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 501)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        G_PGN.BeginText()
        Dim f_pn34 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetFontAndSize(f_pn34.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 491)
        G_PGN.ShowText("---")
        G_PGN.EndText()

        'Manual Check 1-10
        G_PGN.BeginText()
        Dim f_pn35 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn35.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 273.5)
        G_PGN.ShowText(s_ManualCheckTest)
        G_PGN.EndText()

        'ManualCheckRequestTE 1-10
        G_PGN.BeginText()
        Dim f_pn36 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn36.BaseFont, 5)
        G_PGN.SetTextMatrix(510, 236.5)
        G_PGN.ShowText(s_ManualCheckRequestTE)
        G_PGN.EndText()

        'PKG_Good 1-5
        G_PGN.BeginText()
        Dim f_pn37 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn37.BaseFont, 5)
        G_PGN.SetTextMatrix(512, 210)
        G_PGN.ShowText(s_PkgGood)
        G_PGN.EndText()

        'PkgNG
        G_PGN.BeginText()
        Dim f_pn38 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn38.BaseFont, 5)
        G_PGN.SetTextMatrix(512, 198)
        G_PGN.ShowText(s_PkgNG)
        G_PGN.EndText()

        'PkgNishikiCamara
        G_PGN.BeginText()
        Dim f_pn39 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn39.BaseFont, 5)
        G_PGN.SetTextMatrix(512, 186)
        G_PGN.ShowText(s_PkgNishikiCamara)
        G_PGN.EndText()

        'วัน/ เดือน / ปี   DAY
        G_PGN.BeginText()
        Dim f_pn40 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn40.BaseFont, 5)
        G_PGN.SetTextMatrix(64, 765)
        G_PGN.ShowText(CStr(s_DateSetup.Day))
        G_PGN.EndText()

        'วัน/ เดือน / ปี   Month  SetupStartDate
        G_PGN.BeginText()
        Dim f_pn41 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn40.BaseFont, 5)
        G_PGN.SetTextMatrix(170, 765)
        G_PGN.ShowText(CStr(s_DateSetup.Month))
        G_PGN.EndText()

        'วัน/ เดือน / ปี   Year  SetupStartDate
        G_PGN.BeginText()
        Dim f_pn42 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn42.BaseFont, 5)
        G_PGN.SetTextMatrix(258, 765)
        G_PGN.ShowText(CStr(s_DateSetup.Year))
        G_PGN.EndText()

        'วัน/ เดือน / ปี   SetupStartDate
        G_PGN.BeginText()
        Dim f_pn43 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 6.5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn43.BaseFont, 6.5)
        G_PGN.SetTextMatrix(491, 733)
        G_PGN.ShowText(CStr(Format(s_DateSetup, "HH  :  mm")))
        G_PGN.EndText()

        'วัน/ เดือน / ปี   SetupEndDate
        G_PGN.BeginText()
        Dim f_pn44 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 6.5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn44.BaseFont, 6.5)
        G_PGN.SetTextMatrix(535, 257.5)
        G_PGN.ShowText(CStr(Format(s_DateEndSetup, "HH  :  mm")))
        G_PGN.EndText()

        'วัน/ เดือน / ปี   Confirmed
        G_PGN.BeginText()
        Dim f_pn45 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 6.5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn45.BaseFont, 6.5)
        G_PGN.SetTextMatrix(516.5, 53)
        G_PGN.ShowText(CStr(Format(s_DateConfirmed1, "HH  :  mm")))

        '-----------------------------------------------

        'วัน/ เดือน / ปี   SetupStartDate -  SetupEndDate
        'diff = StartDate_Setup - EndDate_Setup

        '-----------------------------------------------

        Dim diff As TimeSpan
        diff = s_DateEndSetup.Subtract(s_DateSetup).Duration()

        'Dim StartDate_Setup As TimeSpan
        'Dim EndDate_Setup As TimeSpan
        'Dim diff As TimeSpan
        'Dim timeStart As Date
        'timeStart = s_DateSetup
        'EndDate_Setup = New TimeSpan(Now.Hour, Now.Minute, Now.Second)
        'StartDate_Setup = New TimeSpan(timeStart.Hour, timeStart.Minute, timeStart.Second)

        '---------------------------------------------------------------------------------

        Dim f_pn46 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 6.5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn46.BaseFont, 6.5)
        G_PGN.SetTextMatrix(398, 53)
        G_PGN.ShowText(diff.TotalMinutes.ToString("00"))
        G_PGN.EndText()

        'ConfirmedChecksheetOp
        G_PGN.BeginText()
        Dim f_pn47 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn47.BaseFont, 5)
        G_PGN.SetTextMatrix(443, 780)
        G_PGN.ShowText(s_ConfirmedCheckSheetOp)
        G_PGN.EndText()

        'ConfirmedCheckSheetGL
        G_PGN.BeginText()
        Dim f_pn48 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn48.BaseFont, 5)
        G_PGN.SetTextMatrix(494, 780)
        G_PGN.ShowText(s_ConfirmedCheckSheetGL)
        G_PGN.EndText()

        'ConfirmedCheckSheetSection
        G_PGN.BeginText()
        Dim f_pn49 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        G_PGN.SetColorFill(GrayColor.BLUE)
        G_PGN.SetFontAndSize(f_pn48.BaseFont, 5)
        G_PGN.SetTextMatrix(543, 780)
        G_PGN.ShowText(s_ConfirmedCheckSheetSection)
        G_PGN.EndText()

        ''Gl dateTime 
        'G_PGN.BeginText()
        'Dim f_pn49 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        'G_PGN.SetColorFill(GrayColor.BLUE)
        'G_PGN.SetFontAndSize(f_pn48.BaseFont, 5)
        'G_PGN.SetTextMatrix(543, 780)
        'G_PGN.ShowText(s_ConfirmedCheckSheetSection)
        'G_PGN.EndText()

        'cb.BeginText()
        'Dim c13 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c13.BaseFont, 9)
        'cb.SetTextMatrix(435, 740)
        'cb.ShowText(Oplabel.Text)
        'cb.EndText()


        'สร้างเส้นวงกลม 
        If s_BoxTesterConnection = "OK" Then
            G_PGN.Circle(501, 597, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_BoxTesterConnection = "NG" Then
            G_PGN.Circle(524.5, 597, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '-----------------------------------
        If s_OptionSetup = "YES" Then
            G_PGN.Circle(500, 586, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_OptionSetup = "NO" Then
            G_PGN.Circle(535, 586, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '-----------------------------------
        If s_OptionConnection = "OK" Then
            G_PGN.Circle(501, 573, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_OptionConnection = "NG" Then
            G_PGN.Circle(524.5, 573, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '----------------------------------
        If s_OptionConnection = "OK" Then
            G_PGN.Circle(501, 573, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_OptionConnection = "NG" Then
            G_PGN.Circle(524.5, 573, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '----------------------------------
        If s_QfpVacuumPad = "YES" Then
            G_PGN.Circle(503, 432, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_QfpVacuumPad = "NO" Then
            G_PGN.Circle(541, 432, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_QfpSocketSetup = "OK" Then
            G_PGN.Circle(527, 404, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)

        ElseIf s_QfpSocketSetup = "NG" Then
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_QfpSocketDecision = "A" Then
            G_PGN.Circle(515.5, 380, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_QfpSocketDecision = "B" Then
            G_PGN.Circle(532, 380, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_QfpSocketDecision = "C" Then
            G_PGN.Circle(548.5, 380, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_QfpDecisionLeadPress = "A" Then
            G_PGN.Circle(515.5, 367.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_QfpDecisionLeadPress = "B" Then
            G_PGN.Circle(532, 367.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_QfpDecisionLeadPress = "C" Then
            G_PGN.Circle(548.5, 367.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_QfpTray = "YES" Then
            G_PGN.Circle(500.5, 356, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_QfpTray = "NO" Then
            G_PGN.Circle(543, 356, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_SopStopper = "OK" Then
            G_PGN.Circle(527, 328, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SopStopper = "NG" Then
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_SopSocketDecision = "A" Then
            G_PGN.Circle(515.5, 316, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SopSocketDecision = "B" Then
            G_PGN.Circle(532, 316, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SopSocketDecision = "C" Then
            G_PGN.Circle(548.5, 316, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_SopDecisionLeadPress = "A" Then
            G_PGN.Circle(515.5, 304.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SopDecisionLeadPress = "B" Then
            G_PGN.Circle(532, 304.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SopDecisionLeadPress = "C" Then
            G_PGN.Circle(548.5, 304.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_ManualCheckTE = "OK" Then
            G_PGN.Circle(548, 275, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_ManualCheckTE = "NG" Then
            G_PGN.Circle(561, 275, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_ManualCheckTE = "OK" Then
            G_PGN.Circle(548, 275, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_ManualCheckTE = "NG" Then
            G_PGN.Circle(561, 275, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_ManualCheckRequestTEConfirm = "OK" Then
            G_PGN.Circle(549, 236.8, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_ManualCheckRequestTEConfirm = "NG" Then
            G_PGN.Circle(567, 236.8, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_PkgGoodJudgement = "OK" Then
            G_PGN.Circle(546.5, 211.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgGoodJudgement = "NG" Then
            G_PGN.Circle(570, 211.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_PkgNGJudgement = "OK" Then
            G_PGN.Circle(546.5, 199, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgNGJudgement = "NG" Then
            G_PGN.Circle(570, 199, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '--------------------------------
        If s_PkgNishikiCamaraJudgement = "OK" Then
            G_PGN.Circle(546.5, 186.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgNishikiCamaraJudgement = "NG" Then
            G_PGN.Circle(570, 186.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_PkgBantLead = "A" Then
            G_PGN.Circle(515.5, 175.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgBantLead = "B" Then
            G_PGN.Circle(532, 175.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgBantLead = "C" Then
            G_PGN.Circle(548.5, 175.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_PkgKakeHige = "A" Then
            G_PGN.Circle(515.5, 163, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgKakeHige = "B" Then
            G_PGN.Circle(532, 163, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_PkgKakeHige = "C" Then
            G_PGN.Circle(548.5, 163, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_BgaSmallBall = "A" Then
            G_PGN.Circle(515.5, 134.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_BgaSmallBall = "B" Then
            G_PGN.Circle(532, 134.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_BgaSmallBall = "C" Then
            G_PGN.Circle(548.5, 134.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_BgeBentTape = "A" Then
            G_PGN.Circle(515.5, 122.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_BgeBentTape = "B" Then
            G_PGN.Circle(532, 122.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_BgeBentTape = "C" Then
            G_PGN.Circle(548.5, 122.5, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_Bge5s = "OK" Then
            G_PGN.Circle(408, 72, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_Bge5s = "NG" Then
            G_PGN.Circle(428, 72, 4.5)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '---------------------------------
        If s_SetupStatus = "CONFIRMED" Then
            G_PGN.Circle(410, 40.5, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        ElseIf s_SetupStatus = "" Then
            G_PGN.Circle(475, 40.5, 8)
            G_PGN.SetColorStroke(GrayColor.BLUE)
        End If
        G_PGN.Stroke()
        '-------------------------------------
        pdf.Close()
        Response.ClearContent()
        Response.ClearHeaders()
        Response.AddHeader("Content-Disposition", "inline;filename=" + s_LotNo + "_" + s_SetupEndDate + ".pdf")
        Response.ContentType = "application/pdf"
        Response.OutputStream.Write(rt.GetBuffer(), 0, rt.GetBuffer().Length)
        Response.Flush()
        Response.Clear()
    End Sub
End Class