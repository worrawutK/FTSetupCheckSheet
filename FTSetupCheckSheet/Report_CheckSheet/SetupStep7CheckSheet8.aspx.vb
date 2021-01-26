Public Class SetupStep7CheckSheet8
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
            selecBgaSmallBall.Value = m_Data.BgaSmallBall
            selelBgaBentTape.Value = m_Data.BgaBentTape

            If m_Data.StatusOldEQP Then
                selecBgaSmallBall.Disabled = True
                selelBgaBentTape.Disabled = True
            End If

        End If
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet9.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet7.aspx")
    End Sub

    Public Sub UpdateSessionData()
        m_Data.BgaSmallBall = selecBgaSmallBall.Value
        m_Data.BgaBentTape = selelBgaBentTape.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

End Class