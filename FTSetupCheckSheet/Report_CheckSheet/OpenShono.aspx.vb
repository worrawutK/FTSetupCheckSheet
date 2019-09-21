Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class OpenShono
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'dateTimesetupLabel.Text = DateTime.Now.ToString("yyyy/MM/dd")

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
                                      PkqBantLead, PkqKakeHige, BgaSmallBall, BgaBentTape, Bge5S, SetupStatus,ConfirmedCheckSheetOp, 
                                      ConfirmedCheckSheetSection, ConfirmedCheckSheetGL, ConfirmedShonoSection, ConfirmedShonoGL, ConfirmedShonoOp,StatusShonoOP,SetupConfirmDate,RecordTime
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

        'Create File PDF
        Dim pdf As New Document(PageSize.A4, 1, 1, 1, 1)
        Dim rt As New MemoryStream()

        Dim pdfWriter As PdfWriter = Nothing
        pdfWriter = PdfWriter.GetInstance(pdf, rt)

        pdf.Open()

        'Writer text

        Dim cb As PdfContentByte = pdfWriter.DirectContent
        cb.SetColorFill(GrayColor.BLUE)
        cb.Rectangle(20, 20, 555, 802)
        cb.Stroke()

        'เส้นวงกลม
        cb.SetCMYKColorFill(255, 255, 255, 255)
        cb.Ellipse(540, 70, 55, 570)
        cb.Stroke()

        'RIST
        cb.BeginText()
        Dim c1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD)
        cb.SetColorFill(GrayColor.DARK_GRAY)
        cb.SetFontAndSize(c1.BaseFont, 30)
        cb.SetTextMatrix(490, 35)
        cb.ShowText("RIST")
        cb.EndText()

        'SET UP CHECK SHEET
        cb.BeginText()
        Dim c2 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 29)
        cb.SetTextMatrix(39, 760)
        cb.ShowText("SET UP CHECK SHEET")
        cb.EndText()

        'OP.SET UP 
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(35, 35) '(xPos,yPos)
        cb.ShowText("- OP. SET UP ต้องทำการถ่ายรูปปัญหาที่พบทุก CASE ที่เจอปัญหา")
        cb.EndText()

        'ANDON
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(35, 50) '(xPos,yPos)
        cb.ShowText("- เมื่อพบปัญหาที่ต้องกด ANDON ทุกครั้ง")
        cb.EndText()

        'Table
        Dim Stampimages1 As Image = iTextSharp.text.Image.GetInstance(Server.MapPath("images") + "/op_set.png")
        Stampimages1.ScalePercent(64)
        Stampimages1.SetAbsolutePosition(350, 736)
        pdf.Add(Stampimages1)

        'Package
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 700)
        cb.ShowText("PACKAGE")


        Dim f_pn3_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn3_1.BaseFont, 10)
        cb.SetTextMatrix(192, 704)
        cb.ShowText(s_PackageName)
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 700)
        cb.ShowText("......................................................")
        cb.EndText()

        'Device
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 680)
        cb.ShowText("DEVICE  ")

        Dim f_pn4_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn3_1.BaseFont, 10)
        cb.SetTextMatrix(192, 684)
        cb.ShowText(s_DeviceName)
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 680)
        cb.ShowText("......................................................")
        cb.EndText()

        'Lot No
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 660)
        cb.ShowText("LOT NO.")


        Dim f_pn5_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn3_1.BaseFont, 10)
        cb.SetTextMatrix(192, 664)
        cb.ShowText(s_LotNo)
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 660)
        cb.ShowText("......................................................")
        cb.EndText()

        'M/C No
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 640)
        cb.ShowText("M/C NO.")


        Dim f_pn6_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn6_1.BaseFont, 10)
        cb.SetTextMatrix(192, 644)
        cb.ShowText(s_MCNo)
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 640)
        cb.ShowText("......................................................")
        cb.EndText()

        'Tester No.
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 620)
        cb.ShowText("TESTER NO.")

        Dim f_pn7_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn7_1.BaseFont, 10)
        cb.SetTextMatrix(192, 624)
        cb.ShowText(s_TesterNoA)
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 620)
        cb.ShowText("......................................................")
        cb.EndText()

        'Date
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(110, 600)
        cb.ShowText("Date Time")

        Dim f_pn8_1 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 10, iTextSharp.text.Font.BOLD)
        cb.SetFontAndSize(f_pn8_1.BaseFont, 10)
        cb.SetTextMatrix(192, 604)
        cb.ShowText(CStr(Format(DateTime.Now.ToString("dd/MM/yyyy"))))
        cb.EndText()

        'ขีดเส้น
        cb.BeginText()
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c2.BaseFont, 9)
        cb.SetTextMatrix(181, 600)
        cb.ShowText("......................................................")
        cb.EndText()

        '1
        cb.Rectangle(235, 400, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c3 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c3.BaseFont, 9)
        cb.SetTextMatrix(246, 525)
        cb.ShowText("FRONT MOLD CHIP CHECK")
        cb.EndText()

        cb.BeginText()
        cb.SetFontAndSize(c3.BaseFont, 9)
        cb.SetTextMatrix(242, 510)
        cb.ShowText("(ตรวจสอบด้านหน้า mold chip)")
        cb.EndText()

        '--------------------------------------

        '2
        cb.Rectangle(80, 260, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c4 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c4.BaseFont, 9)
        cb.SetTextMatrix(95, 385)
        cb.ShowText("BACK MOLD CHIP CHECK")
        cb.EndText()

        cb.BeginText()
        cb.SetFontAndSize(c3.BaseFont, 9)
        cb.SetTextMatrix(91, 370)
        cb.ShowText("(ตรวจสอบด้านหลัง mold chip)")
        cb.EndText()

        '--------------------------------------

        '3
        cb.Rectangle(235, 260, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c5 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c5.BaseFont, 9)
        cb.SetTextMatrix(275, 385)
        cb.ShowText("LEAD CHECK")
        cb.EndText()

        cb.BeginText()
        cb.SetFontAndSize(c3.BaseFont, 9)
        cb.SetTextMatrix(238.5, 370)
        cb.ShowText("(ตรวจสอบความผิดปกติของขางาน)")
        cb.EndText()

        '--------------------------------------

        '4
        cb.Rectangle(385, 260, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c6 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c5.BaseFont, 9)
        cb.SetTextMatrix(393, 370)
        cb.ShowText("CHECK LEAD SIDE SCRATCH")
        cb.EndText()

        '-------------------------------------

        '5
        cb.Rectangle(235, 120, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c7 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c7.BaseFont, 9)
        cb.SetTextMatrix(255, 230)
        cb.ShowText("CHECK CENTER LEAD")
        cb.EndText()

        '-------------------------------------

        '6
        cb.Rectangle(385, 604, 130, 100)
        cb.Stroke()

        cb.BeginText()
        Dim c11 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c11.BaseFont, 9)
        cb.SetTextMatrix(430, 710)
        cb.ShowText("SOCKET")
        cb.EndText()

        '-------------------------------------

        'Op !!!
        cb.BeginText()
        Dim c8 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c8.BaseFont, 9)
        cb.SetTextMatrix(362, 763)
        cb.ShowText(s_ConfirmedShonoOp)
        cb.EndText()

        ''Op dateTime 
        'cb.BeginText()
        'Dim c12 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c12.BaseFont, 9)
        'cb.SetTextMatrix(362, 740)
        'cb.ShowText(Oplabel.Text)
        'cb.EndText()

        'Gl!!!
        cb.BeginText()
        Dim c9 As iTextSharp.text.Font = FontFactory.GetFont("c: \\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c9.BaseFont, 9)
        cb.SetTextMatrix(435, 763)
        cb.ShowText(s_ConfirmedShonoGL)
        cb.EndText()

        ''Gl dateTime 
        'cb.BeginText()
        'Dim c13 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c13.BaseFont, 9)
        'cb.SetTextMatrix(435, 740)
        'cb.ShowText(Oplabel.Text)
        'cb.EndText()

        'Section!!!
        cb.BeginText()
        Dim c10 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        cb.SetColorFill(GrayColor.BLACK)
        cb.SetFontAndSize(c10.BaseFont, 9)
        cb.SetTextMatrix(507, 763)
        cb.ShowText(s_ConfirmedShonoSection)
        cb.EndText()

        ''Section dateTime 
        'cb.BeginText()
        'Dim c14 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        'cb.SetColorFill(GrayColor.BLACK)
        'cb.SetFontAndSize(c14.BaseFont, 9)
        'cb.SetTextMatrix(507, 740)
        'cb.ShowText(Oplabel.Text)
        'cb.EndText()

        '-------------------------------------

        pdf.Close()

        Response.ClearContent()
        Response.ClearHeaders()
        Response.AddHeader("Content-Disposition", "inline;filename=" + s_LotNo + "_" + s_MCNo + ".pdf")
        Response.ContentType = "application/pdf"
        Response.OutputStream.Write(rt.GetBuffer, 0, rt.GetBuffer.Length)
        Response.Flush()
        Response.Clear()

    End Sub
End Class