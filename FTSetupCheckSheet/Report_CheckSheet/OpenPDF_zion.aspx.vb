Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class OpenPDF_zion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        Dim pdfReader As PdfReader

        Try
            pdfReader = New PdfReader(My.Settings.ShonokokoshiPDFPath + s_LotNo + "_" + s_MCNo + ".pdf")
        Catch ex As Exception
            Dim str As String() = ex.Message.Split("'"c)
            Dim str2 As String() = str(1).Split("\"c)
            Dim errMessage As List(Of String) = New List(Of String)

            errMessage.Add("ไม่พบ File Shoko ที่ \\" + str2(2) + "\" + str2(3) + "\" + str2(4))
            errMessage.Add(str2(5))
            ShowErrorMessage(String.Join("<br/>", errMessage.ToArray()))
            Exit Sub
        End Try

        Dim pdfimportopen As PdfImportedPage = pdfWriter.GetImportedPage(PdfReader, 1)

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
    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

End Class