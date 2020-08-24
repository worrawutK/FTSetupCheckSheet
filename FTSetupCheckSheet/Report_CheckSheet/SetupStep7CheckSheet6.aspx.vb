Public Class SetupStep7CheckSheet6
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
            selecPkgGoodjudgement.Value = m_Data.PkgGoodJudgement
            selecPkgNGjudgement.Value = m_Data.PkgNGJudgement
            SelectPKgNishikijudgement.Value = m_Data.PkgNishikiCamaraJudgement
        End If
    End Sub

    Public Sub UpdateSessionData()
        m_Data.PkgGoodJudgement = selecPkgGoodjudgement.Value
        m_Data.PkgNGJudgement = selecPkgNGjudgement.Value
        m_Data.PkgNishikiCamaraJudgement = SelectPKgNishikijudgement.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet7.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet5.aspx")
    End Sub

End Class