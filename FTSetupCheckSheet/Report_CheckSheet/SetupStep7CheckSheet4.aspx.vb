Public Class SetupStep7CheckSheet4
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport
    Public Property TEselectManualCheckRequestTE As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_NEW_DATA_SETUP)

        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If

        If Not IsPostBack Then
            selecManualCheckTest.Value = m_Data.ManualCheckTest.ToString()
            selecManualCheckTE.Value = m_Data.ManualCheckTE
            selectManualCheckRequestTE.Value = m_Data.ManualCheckRequestTE.ToString()
            selectManualCheckRequestTEConfirm.Value = m_Data.ManualCheckRequestTEConfirm

            If m_Data.StatusOldEQP Then
                selecManualCheckTest.Disabled = True
                selecManualCheckTE.Disabled = True
                selectManualCheckRequestTE.Disabled = True
                selectManualCheckRequestTEConfirm.Disabled = True
            End If

        End If
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet5.aspx")
    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        UpdateSessionData()
        Response.Redirect("~/SetupStep7CheckSheet3.aspx")
    End Sub

    Public Sub UpdateSessionData()

        m_Data.ManualCheckTE = selecManualCheckTE.Value
        m_Data.ManualCheckRequestTEConfirm = selectManualCheckRequestTEConfirm.Value

        Dim tmpTE As Integer = 0

        If Integer.TryParse(selectManualCheckRequestTE.Value, tmpTE) Then
            m_Data.ManualCheckRequestTE = tmpTE
        Else
            m_Data.ManualCheckRequestTE = 0
        End If

        Dim tmp As Integer = 0
        If Integer.TryParse(selecManualCheckTest.Value, tmp) Then
            m_Data.ManualCheckTest = tmp
        Else
            m_Data.ManualCheckTest = 0
        End If

        Session(SESSION_KEY_NEW_DATA_SETUP) = m_Data
    End Sub

End Class