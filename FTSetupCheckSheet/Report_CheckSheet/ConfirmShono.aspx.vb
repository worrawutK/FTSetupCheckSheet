Imports System
Imports System.IO
Imports System.Web
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient


Public Class ConfirmShono
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim s_MCNo As String
        Dim s_LotNo As String
        Dim s_PackageName As String
        Dim s_DeviceName As String
        Dim s_TesterNoA As String
        Dim s_SetupStatus As String
        Dim s_ConfirmedShonoSection As String
        Dim s_ConfirmedShonoGL As String
        Dim s_ConfirmedShonoOp As String

        Using con As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
            con.Open()
            Dim sqlFtSetup As String = "Select ID, MCNo, LotNo, PackageName, DeviceName, ProgramName, TesterType, TestFlow, QRCodesocket1, QRCodesocket2, QRCodesocket3, 
                                      QRCodesocket4, QRCodesocketChannel1, QRCodesocketChannel2, QRCodesocketChannel3, QRCodesocketChannel4, TesterNoA, 
                                      TesterNoAQRcode, TesterNoB, TesterNoBQRcode, ChannelAFTB, ChannelAFTBQRcode, ChannelBFTB, ChannelBFTBQRcode, TestBoxA, 
                                      TestBoxAQRcode, TestBoxB, TestBoxBQRcode, AdaptorA, AdaptorAQRcode, AdaptorB, AdaptorBQRcode, DutcardA, DutcardAQRcode, DutcardB, 
                                      DutcardBQRcode, BridgecableA, BridgecableAQRcode, BridgecableB, BridgecableBQRcode, TypeChangePackage, SetupStartDate, SetupEndDate, 
                                      BoxTesterConnection, OptionSetup, OptionConnection, OptionName1, OptionName2,  OptionName3, 
                                      OptionName4, OptionName5, OptionName6, OptionName7, OptionType1, OptionType1QRcode, OptionType2,
                                      OptionType2QRcode, OptionType3, OptionType3QRcode, OptionType4, OptionType4QRcode, OptionType5,
                                      OptionType5QRcode, OptionType6, OptionType6QRcode, OptionType7, OptionType7QRcode, OptionSetting1, 
                                       OptionSetting2, OptionSetting3, OptionSetting4,OptionSetting5, OptionSetting6, OptionSetting7,QfpVacuumPad, 
                                      QfpSocketSetup, QfpSocketDecision, QfpDecisionLeadPress, QfpTray, SopStopper, SopSocketDecision, SopDecisionLeadPress, ManualCheckTest, 
                                      ManualCheckTE, ManualCheckRequestTE, ManualCheckRequestTEConfirm, PkgGood, PkgNG, PkgGoodJudgement, PkgNGJudgement, PkgNishikiCamara, 
                                      PkgNishikiCamaraJudgement, PkqBantLead, PkqKakeHige, BgaSmallBall, BgaBentTape, Bge5S, SetupStatus, SetupConfirmDate, ConfirmedCheckSheetOp,
                                      ConfirmedCheckSheetSection, ConfirmedCheckSheetGL,ConfirmedShonoOp, ConfirmedShonoSection, ConfirmedShonoGL , StatusShonoOP
                                      FROM DBx.dbo.FTSetupReportHistory WHERE LotNo ='" & Request.QueryString("LotNo") & "'AND MCNo ='" & Request.QueryString("MCNo") & "'"

            Using cmd As New SqlCommand(sqlFtSetup, con)
                Using d As SqlDataReader = cmd.ExecuteReader()
                    If d.Read Then
                        s_MCNo = d("MCNo").ToString()
                        s_LotNo = d("LotNo").ToString()
                        s_PackageName = d("PackageName").ToString()
                        s_DeviceName = d("DeviceName").ToString()
                        s_TesterNoA = d("TesterNoA").ToString()
                        s_SetupStatus = d("SetupStatus").ToString()
                        s_ConfirmedShonoSection = d("ConfirmedShonoSection").ToString()
                        s_ConfirmedShonoGL = d("ConfirmedShonoGL").ToString()
                        s_ConfirmedShonoOp = d("ConfirmedShonoOp").ToString()

                    End If
                End Using
            End Using
        End Using

        Dim pdffile1 As New Document(PageSize.A4)
        Dim dt As New MemoryStream()
        Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdffile1, dt)
        Dim pdfReader As PdfReader = New PdfReader("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" + s_LotNo + "_" + s_MCNo + ".pdf")
        Dim pdfimportopen As PdfImportedPage = pdfWriter.GetImportedPage(pdfReader, 1)

        pdffile1.Open()

        Dim testWriter = pdfWriter.DirectContent
        testWriter.AddTemplate(pdfimportopen, 0, 0)

        pdffile1.Close()
        pdfReader.Close()

        Response.ClearContent()
        Response.ClearHeaders()
        Response.AddHeader("Content-Disposition", "inline;filename=" + s_LotNo + "_" + s_MCNo + ".pdf")
        Response.ContentType = "application/pdf"
        Response.OutputStream.Write(dt.GetBuffer(), 0, dt.GetBuffer().Length)
        Response.Flush()
        Response.Clear()


        'Dim pdffile1 As New Document(PageSize.A4, 1, 1, 1, 1)
        ''Dim dt As New MemoryStream()



        'Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdffile1, New FileStream("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" + s_LotNo + "_" + s_MCNo + ".pdf", FileMode.Create))
        'Dim rt As FileStream = New FileStream("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" + s_LotNo + "_" + s_MCNo + ".pdf", FileMode.Create)
        'Dim pdfReader As PdfReader = New PdfReader(System.IO.File.ReadAllBytes("\\172.16.0.100\FTCheckSheet\ShonokoshiPDF\" + s_LotNo + "_" + s_MCNo + ".pdf"))

        'Dim pdfimportopen As PdfImportedPage = pdfWriter.GetImportedPage(pdfReader, 1)

        'pdffile1.Open()

        'Dim cb = pdfWriter.DirectContent
        'cb.AddTemplate(pdfimportopen, 0, 0)

        ''Op !!!
        'cb.BeginText()
        'Dim c8 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c8.BaseFont, 9)
        'cb.SetTextMatrix(362, 763)
        'cb.ShowText(s_ConfirmedShonoOp)
        'cb.EndText()

        ''Gl!!!
        'cb.BeginText()
        'Dim c9 As iTextSharp.text.Font = FontFactory.GetFont("c: \\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c9.BaseFont, 9)
        'cb.SetTextMatrix(435, 763)
        'cb.ShowText(s_ConfirmedShonoGL)
        'cb.EndText()

        ''Section!!!
        'cb.BeginText()
        'Dim c10 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c10.BaseFont, 9)
        'cb.SetTextMatrix(507, 763)
        'cb.ShowText(s_ConfirmedShonoSection)
        'cb.EndText()


        'pdffile1.Close()
        'pdfReader.Close()


    End Sub
End Class