Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Partial Public Class SetupStep7CheckSheet2
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
            selecQfpDecisionLeadPress.Value = m_Data.QfpDecisionLeadPress
            selecQfpSocketDecision.Value = m_Data.QfpSocketDecision
            selecQfpTray.Value = m_Data.QfpTray
            selecQfpVacuumPad.Value = m_Data.QfpVacuumPad
            selectQfpSetupSocket.Value = m_Data.QfpSocketSetup
        End If
    End Sub

    Public Sub UpdateSessionData()
        m_Data.QfpDecisionLeadPress = selecQfpDecisionLeadPress.Value
        m_Data.QfpSocketDecision = selecQfpSocketDecision.Value
        m_Data.QfpTray = selecQfpTray.Value
        m_Data.QfpVacuumPad = selecQfpVacuumPad.Value
        m_Data.QfpSocketSetup = selectQfpSetupSocket.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

    Protected Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet1.aspx")
    End Sub

    Protected Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet3.aspx")
    End Sub

End Class
