Imports System
Imports System.IO
Imports System.Web
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Web.UI
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Data.SqlClient

Public Class SetupConfirm
    Inherits System.Web.UI.Page

    Private m_Data As FTSetupReport

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_DATA)
        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
            Exit Sub
        Else
            m_Data = CType(tmp, FTSetupReport)
        End If

        If IsPostBack AndAlso m_Data.SetupStatus = "CONFIRMED" Then
            Response.Redirect("~/SetupMain.aspx")
            Exit Sub
        Else
            lotnoTextbox.Text = m_Data.LotNo
            PackagenameTextBox.Text = m_Data.PackageName
            DeviceNameTextBox.Text = m_Data.DeviceName
        End If

        QRcodeTextBox.Focus()
    End Sub

    Protected Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        Response.Redirect("~/SetupMain.aspx")
    End Sub

    'Input Working Slip
    Protected Sub QRcodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles QRcodeTextBox.TextChanged

        If QRcodeTextBox.Text.Length = 252 Then
            Dim qrTest As String = QRcodeTextBox.Text
            m_Data.LotNo = qrTest.Substring(30, 10).ToUpper().Trim()
            m_Data.PackageName = QRcodeTextBox.Text.Substring(0, 10).ToUpper().Trim()
            m_Data.DeviceName = QRcodeTextBox.Text.Substring(232, 20).ToUpper().Trim()

            DeviceNameTextBox.Text = m_Data.DeviceName
            PackagenameTextBox.Text = m_Data.PackageName
            lotnoTextbox.Text = m_Data.LotNo

            Session(SESSION_KEY_DATA) = m_Data

        End If
        QRcodeTextBox.Text = ""

    End Sub

#Region "Private class"

    Private Class OptionSummary

        Private m_OptionType As String
        Public Property OptionType() As String
            Get
                Return m_OptionType
            End Get
            Set(ByVal value As String)
                m_OptionType = value
            End Set
        End Property

        Private m_Quantity As Integer
        Public Property Quantity() As Integer
            Get
                Return m_Quantity
            End Get
            Set(ByVal value As Integer)
                m_Quantity = value
            End Set
        End Property

        Public Shared Function GetOptionSummaryList(data As FTSetupReport) As Dictionary(Of String, OptionSummary)

            Dim dic As Dictionary(Of String, OptionSummary) = New Dictionary(Of String, OptionSummary)
            Dim dummy As OptionSummary

            If Not String.IsNullOrEmpty(data.OptionType1) Then
                If dic.ContainsKey(data.OptionType1) Then
                    dummy = dic(data.OptionType1)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType1
                    dic.Add(data.OptionType1, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType2) Then
                If dic.ContainsKey(data.OptionType2) Then
                    dummy = dic(data.OptionType2)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType2
                    dic.Add(data.OptionType2, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType3) Then
                If dic.ContainsKey(data.OptionType3) Then
                    dummy = dic(data.OptionType3)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType3
                    dic.Add(data.OptionType3, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType4) Then
                If dic.ContainsKey(data.OptionType4) Then
                    dummy = dic(data.OptionType4)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType4
                    dic.Add(data.OptionType4, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType5) Then
                If dic.ContainsKey(data.OptionType5) Then
                    dummy = dic(data.OptionType5)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType5
                    dic.Add(data.OptionType5, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType6) Then
                If dic.ContainsKey(data.OptionType6) Then
                    dummy = dic(data.OptionType6)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType6
                    dic.Add(data.OptionType6, dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType7) Then
                If dic.ContainsKey(data.OptionType7) Then
                    dummy = dic(data.OptionType7)
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType7
                    dic.Add(data.OptionType7, dummy)
                End If
                dummy.Quantity += 1
            End If

            Return dic
        End Function

    End Class

    Private Class EquipmentSummary

        Private m_Name As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Private m_TypeID As Integer
        Public Property TypeID() As Integer
            Get
                Return m_TypeID
            End Get
            Set(ByVal value As Integer)
                m_TypeID = value
            End Set
        End Property

        Public Shared Function GetEquipmentSummaryDictionary(data As FTSetupReport) As Dictionary(Of String, EquipmentSummary)
            Dim dic As Dictionary(Of String, EquipmentSummary) = New Dictionary(Of String, EquipmentSummary)
            Dim dummy As EquipmentSummary

            If Not String.IsNullOrEmpty(data.AdaptorA) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.AdaptorA
                dummy.TypeID = EQUIPMENT_TYPE_ID_ADAPTOR
                dic.Add(data.AdaptorA, dummy)
            End If

            If Not String.IsNullOrEmpty(data.AdaptorB) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.AdaptorB
                dummy.TypeID = EQUIPMENT_TYPE_ID_ADAPTOR
                dic.Add(data.AdaptorB, dummy)
            End If

            If Not String.IsNullOrEmpty(data.BridgecableA) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.BridgecableA
                dummy.TypeID = EQUIPMENT_TYPE_ID_BRIDGE_CABLE
                dic.Add(data.BridgecableA, dummy)
            End If

            If Not String.IsNullOrEmpty(data.BridgecableB) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.BridgecableB
                dummy.TypeID = EQUIPMENT_TYPE_ID_BRIDGE_CABLE
                dic.Add(data.BridgecableB, dummy)
            End If

            If Not String.IsNullOrEmpty(data.DutcardA) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.DutcardA
                dummy.TypeID = EQUIPMENT_TYPE_ID_DUTCARD
                dic.Add(data.DutcardA, dummy)
            End If

            If Not String.IsNullOrEmpty(data.DutcardB) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.DutcardB
                dummy.TypeID = EQUIPMENT_TYPE_ID_DUTCARD
                dic.Add(data.DutcardB, dummy)
            End If

            If Not String.IsNullOrEmpty(data.TestBoxA) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.TestBoxA
                dummy.TypeID = EQUIPMENT_TYPE_ID_BOX
                dic.Add(data.TestBoxA, dummy)
            End If

            If Not String.IsNullOrEmpty(data.TestBoxB) Then
                dummy = New EquipmentSummary()
                dummy.Name = data.TestBoxB
                dummy.TypeID = EQUIPMENT_TYPE_ID_BOX
                dic.Add(data.TestBoxB, dummy)
            End If

            Return dic
        End Function
    End Class

#End Region


    Protected Sub Confirmbutton_Click(sender As Object, e As EventArgs) Handles Confirmbutton_Check.Click

#Region "BOM"

        'get PCMain
        Dim pcMain As String = DBAccess.GetPCMain(m_Data.MCNo)

        If String.IsNullOrEmpty(pcMain) Then
            ShowErrorMessage("Could not find PCMain of MCNo:" & m_Data.MCNo)
            Exit Sub
        End If

        'get BOM's main record without machine
        Dim bomTbl As DataTable
        Try
            bomTbl = DBAccess.GetBOM(m_Data.DeviceName, m_Data.PackageName, m_Data.TestFlow, m_Data.TesterType, pcMain)
        Catch ex As Exception
            ShowErrorMessage("Failed to get BOM :" & ex.Message)
            Exit Sub
        End Try

        If bomTbl.Rows.Count = 0 Then
            'show error message
            ShowErrorMessage(String.Format("BOM not found <br/> Device:={0}<br/> Package:={1}<br/> TestFlow:={2}<br/> TesterType:={3}<br/> PCMain:={4}",
                m_Data.DeviceName, m_Data.PackageName, m_Data.TestFlow, m_Data.TesterType, pcMain))
            Exit Sub
        End If

        Dim bomId As Integer = -1
        Dim bomPcMachineType As String = ""
        Dim bomTesterType As String = ""

        Dim bomRow As DataRow = bomTbl.Rows(0)

        bomId = CType(bomRow("ID"), Integer)

        'for store all message at once
        Dim errorMessageList As List(Of String) = New List(Of String)

        Dim bomOptionTbl As DataTable
        Dim bomTestEqiupmentTbl As DataTable

#Region "Check BOMOption"

        'in some case, there is no option
        bomOptionTbl = DBAccess.GetBOMOption(bomId)
        If bomOptionTbl.Rows.Count > 0 Then

            Dim sumDic As Dictionary(Of String, OptionSummary) = OptionSummary.GetOptionSummaryList(m_Data)

            Dim matchCount As Integer = 0
            Dim expectedMatchCount As Integer = bomOptionTbl.Rows.Count
            Dim dummyOptionName As String
            Dim dummyOptionQty As Integer

            Dim dummyOtionSum As OptionSummary

            For Each row As DataRow In bomOptionTbl.Rows

                dummyOptionName = row("Name").ToString()
                dummyOptionQty = CType(row("Quantity"), Integer)

                If sumDic.ContainsKey(dummyOptionName) Then
                    dummyOtionSum = sumDic(dummyOptionName)
                    If dummyOtionSum.Quantity = dummyOptionQty Then
                        matchCount += 1
                    End If
                End If

            Next

            If matchCount <> expectedMatchCount Then
                errorMessageList.Add("Option is Not match with BOM")
            End If

        End If
#End Region

#Region "Check BOMTestEquipment"
        'must have atlease 1
        bomTestEqiupmentTbl = DBAccess.GetBOMTestEquipment(bomId)
        If bomTestEqiupmentTbl.Rows.Count > 0 Then

            Dim dicEq As Dictionary(Of String, EquipmentSummary) = EquipmentSummary.GetEquipmentSummaryDictionary(m_Data)

            Dim dummyName As String
            Dim dummyTypeName As String
            Dim dummyIsAdaptor As Boolean
            Dim dummyIsLoadBoard As Boolean

            Dim matchCount As Integer = 0
            Dim expectedMatchCount As Integer = dicEq.Count

            For Each row As DataRow In bomTestEqiupmentTbl.Rows

                dummyName = row("Name").ToString()
                dummyTypeName = row("TypeName").ToString()
                dummyIsAdaptor = CBool(row("IsAdaptor"))
                dummyIsLoadBoard = CBool(row("IsLoadboard"))

                If dicEq.ContainsKey(dummyName) Then
                    matchCount += 1
                    dicEq.Remove(dummyName) 'in case of use 2 unit of same box
                End If

            Next

            If matchCount <> expectedMatchCount Then
                errorMessageList.Add("Test Equipment is not match with BOM")
            End If

        End If
#End Region

        If errorMessageList.Count > 0 Then
            ShowErrorMessage(String.Join("<br/>", errorMessageList.ToArray()))
            Exit Sub
        End If

#End Region

        Try
            DBAccess.ConfirmFTReport(m_Data.MCNo, m_Data.LotNo, m_Data.PackageName, m_Data.DeviceName)

            m_Data.SetupStatus = SETUP_STATUS_CONFIRMED

            HideErrorMessage()

            Response.Redirect("~/Default.aspx")

        Catch ex As Exception
            ShowErrorMessage("Confirmation is failed : " & ex.Message)
        End Try

    End Sub

    Private Sub ShowErrorMessage(errMessage As String)
        ErrorMessageLabel.Text = errMessage
        panelError.Style.Item("display") = "block"
    End Sub

    Private Sub HideErrorMessage()
        panelError.Style.Item("display") = "none"
    End Sub
End Class