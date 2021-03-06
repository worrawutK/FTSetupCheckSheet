﻿Public Class SetupStep7CheckSheet3
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
            selecSopDecisionLeadClamper.Value = m_Data.SopDecisionLeadPress
            selecSopSocketDecision.Value = m_Data.SopSocketDecision
            selectStopper.Value = m_Data.SopStopper

            If m_Data.StatusOldEQP Then
                selecSopDecisionLeadClamper.Disabled = True
                selecSopSocketDecision.Disabled = True
                selectStopper.Disabled = True
            End If

        End If
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet4.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet2.aspx")
    End Sub

    Public Sub UpdateSessionData()
        m_Data.SopDecisionLeadPress = selecSopDecisionLeadClamper.Value
        m_Data.SopSocketDecision = selecSopSocketDecision.Value
        m_Data.SopStopper = selectStopper.Value

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

End Class