Public Class SetupStep7CheckSheet1
    Inherits Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)

        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If

        If Not IsPostBack Then
            selectBoxTesterConnection.Value = m_Data.BoxTesterConnection
            selecOptionSetup.Value = m_Data.OptionSetup
            selecOptionConnection.Value = m_Data.OptionConnection
        End If
    End Sub

    Public Sub UpdateSessionData()
        m_Data.BoxTesterConnection = selectBoxTesterConnection.Value
        m_Data.OptionSetup = selecOptionSetup.Value
        m_Data.OptionConnection = selecOptionConnection.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet2.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep6.aspx")
    End Sub

End Class