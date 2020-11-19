Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Text
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Data.SqlClient

Public Class LoginGL
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
                                          WHERE [Group].ID ='374' AND MyUser.ID = '" & Me.usernameTextBox.Text & "'"

            Using cmd As New SqlCommand(sdqData, constr)
                Using d As SqlDataReader = cmd.ExecuteReader()
                    If d.Read Then
                        usernameTextBox.Text = d("Name").ToString()
                        dateLabel.Text = DateTime.Now.ToString("yyyy/MM/dd")
                    Else
                        usernameTextBox.Text = ""
                        MyAlert(Page, "!!! Please Input User GL. !!!")
                        Exit Sub
                    End If
                End Using
            End Using
        Else
            usernameTextBox.Text = ""
            MyAlert(Page, "!!! Please Input User GL. 6 Digits !!!")
            Exit Sub
        End If

        Dim ConfirmedCheckSheetGL As String = usernameTextBox.Text

        'Dim strSql As String = "UPDATE [dbo].[FTSetupReportHistory] Set [ConfirmedCheckSheetGL] = @ConfirmedCheckSheetGL WHERE LotNo  = '" & Request.QueryString("LotNo") & "' AND MCNo = '" & Request.QueryString("MCNo") & "'"
        'Dim ret As Integer
        'Using con As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
        '    Using cmd As SqlCommand = con.CreateCommand()

        '        cmd.CommandText = strSql
        '        cmd.Parameters.Add("@ConfirmedCheckSheetGL", SqlDbType.VarChar, 15).Value = ConfirmedCheckSheetGL

        '        con.Open()

        '        ret = cmd.ExecuteNonQuery()

        '    End Using
        'End Using

        Dim strSql1 As String = "UPDATE [dbo].[FTSetupReport] Set [ConfirmedCheckSheetGL] = @ConfirmedCheckSheetGL WHERE LotNo  = '" & Request.QueryString("LotNo") & "' AND MCNo = '" & Request.QueryString("MCNo") & "'"
        Dim ret1 As Integer
        Using con1 As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
            Using cmd1 As SqlCommand = con1.CreateCommand()

                cmd1.CommandText = strSql1
                cmd1.Parameters.Add("@ConfirmedCheckSheetGL", SqlDbType.VarChar, 15).Value = ConfirmedCheckSheetGL

                con1.Open()

                ret1 = cmd1.ExecuteNonQuery()

            End Using
        End Using

        Response.Redirect(String.Format("~/ConfirmedReport.aspx?LotNo={0}&MCNo={1}",
                                        Request.QueryString("LotNo"), Request.QueryString("MCNo")))
    End Sub
End Class