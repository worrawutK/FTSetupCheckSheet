Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class LoginShonoSection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd")

        If Not IsPostBack Then
            Me.usernameTextBox.Focus()
        End If
    End Sub

    Protected Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        If usernameTextBox.Text.Length = 6 Then

            usernameTextBox.Text.Trim().ToUpper()

            Dim constr As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)

            constr.Open()

            Dim sdqData As String = "SELECT [Group].ID,  MyUser.ID AS OpNo, MyUser.FirstName +'  '+ SUBSTRING ( MyUser.LastName,1,1)+'.'as Name
                                          FROM  [Group] INNER JOIN GroupMember ON [Group].ID = GroupMember.GroupID 
                                          INNER JOIN  MyUser ON GroupMember.MemberID = MyUser.ID
                                          WHERE [Group].ID ='373' AND MyUser.ID = '" & Me.usernameTextBox.Text & "'"

            Using cmd As New SqlCommand(sdqData, constr)
                Using d As SqlDataReader = cmd.ExecuteReader()
                    If d.Read Then
                        usernameTextBox.Text = d("Name").ToString()
                        dateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd")
                    Else
                        usernameTextBox.Text = ""
                        MyAlert(Page, "!!! Please Input User Section !!!")
                        Exit Sub
                    End If
                End Using
            End Using
        End If

        Dim ConfirmedShonoSection As String = usernameTextBox.Text

        'Dim strSql As String = "UPDATE [dbo].[FTSetupReportHistory] Set [ConfirmedShonoSection] = @ConfirmedShonoSection WHERE LotNo  = '" & Request.QueryString("LotNo") & "' AND MCNo = '" & Request.QueryString("MCNo") & "'"
        'Dim ret As Integer
        'Using con As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
        '    Using cmd As SqlCommand = con.CreateCommand()

        '        cmd.CommandText = strSql
        '        cmd.Parameters.Add("@ConfirmedShonoSection", SqlDbType.VarChar, 15).Value = ConfirmedShonoSection

        '        con.Open()

        '        ret = cmd.ExecuteNonQuery()

        '    End Using
        'End Using

        Dim strSql1 As String = "UPDATE [dbo].[FTSetupReport] Set [ConfirmedShonoSection] = @ConfirmedShonoSection WHERE LotNo  = '" & Request.QueryString("LotNo") & "' AND MCNo = '" & Request.QueryString("MCNo") & "'"
        Dim ret1 As Integer
        Using con1 As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
            Using cmd1 As SqlCommand = con1.CreateCommand()

                cmd1.CommandText = strSql1
                cmd1.Parameters.Add("@ConfirmedShonoSection", SqlDbType.VarChar, 15).Value = ConfirmedShonoSection

                con1.Open()

                ret1 = cmd1.ExecuteNonQuery()

            End Using
        End Using

        Dim pdffile1 As New Document(PageSize.A4)
        Dim pdfReader As PdfReader

        Try
            pdfReader = New PdfReader(System.IO.File.ReadAllBytes(My.Settings.ShonokokoshiPDFPath & Request.QueryString("LotNo") & "_" & Request.QueryString("MCNo") & ".pdf"))
        Catch ex As Exception
            Dim str As String() = ex.Message.Split("'"c)
            Dim str2 As String() = str(1).Split("\"c)
            Dim errMessage As List(Of String) = New List(Of String)

            errMessage.Add("ไม่พบ File Shoko ที่ \\" + str2(2) + "\" + str2(3) + "\" + str2(4))
            errMessage.Add(str2(5))
            ShowErrorMessage(String.Join("<br/>", errMessage.ToArray()))
            Exit Sub
        End Try

        Dim dt As New FileStream(My.Settings.ShonokokoshiPDFPath & Request.QueryString("LotNo") & "_" & Request.QueryString("MCNo") & ".pdf", FileMode.Create)

        Dim pdfWriter As PdfWriter = PdfWriter.GetInstance(pdffile1, dt)

        Dim pdfimportopen As PdfImportedPage = pdfWriter.GetImportedPage(pdfReader, 1)

        pdffile1.Open()

        Dim testWriter = pdfWriter.DirectContent
        testWriter.AddTemplate(pdfimportopen, 0, 0)

        'Section !!!
        testWriter.BeginText()
        Dim c8 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        testWriter.SetColorFill(GrayColor.BLACK)
        testWriter.SetFontAndSize(c8.BaseFont, 9)
        testWriter.SetTextMatrix(507, 763)
        testWriter.ShowText(usernameTextBox.Text)
        testWriter.EndText()

        'Section dateTime 
        testWriter.BeginText()
        Dim c12 As iTextSharp.text.Font = FontFactory.GetFont("c:\\windows\\fonts\\Tahoma.ttf", "Identity-H", 3)
        testWriter.SetColorFill(GrayColor.BLACK)
        testWriter.SetFontAndSize(c12.BaseFont, 9)
        testWriter.SetTextMatrix(507, 740)
        testWriter.ShowText(dateLabel.Text)
        testWriter.EndText()

        pdffile1.Close()
        pdfReader.Close()

        Response.Redirect(String.Format("~/ConfirmedReport.aspx?LotNo={0}&MCNo={1}",
                                        Request.QueryString("LotNo"), Request.QueryString("MCNo")))
    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub

End Class