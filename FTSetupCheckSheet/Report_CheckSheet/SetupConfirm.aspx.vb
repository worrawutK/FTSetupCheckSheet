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
                If dic.ContainsKey(data.OptionType1.ToUpper()) Then
                    dummy = dic(data.OptionType1.ToUpper())
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType1.ToUpper()
                    dic.Add(data.OptionType1.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType2) Then
                If dic.ContainsKey(data.OptionType2.ToUpper()) Then
                    dummy = dic(data.OptionType2.ToUpper())
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType2.ToUpper()
                    dic.Add(data.OptionType2.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType3) Then
                If dic.ContainsKey(data.OptionType3.ToUpper()) Then
                    dummy = dic(data.OptionType3.ToUpper())
                Else
                    dummy = New OptionSummary()
                    data.OptionType3.ToUpper()
                    dummy.OptionType = data.OptionType3.ToUpper()
                    dic.Add(data.OptionType3.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType4) Then
                If dic.ContainsKey(data.OptionType4.ToUpper()) Then
                    dummy = dic(data.OptionType4.ToUpper())
                Else
                    dummy = New OptionSummary()
                    data.OptionType4.ToUpper()
                    dummy.OptionType = data.OptionType4.ToUpper()
                    dic.Add(data.OptionType4.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType5) Then
                If dic.ContainsKey(data.OptionType5.ToUpper()) Then
                    dummy = dic(data.OptionType5.ToUpper())
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType5.ToUpper()
                    dic.Add(data.OptionType5.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType6) Then
                If dic.ContainsKey(data.OptionType6.ToUpper()) Then
                    dummy = dic(data.OptionType6.ToUpper())
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType6.ToUpper()
                    dic.Add(data.OptionType6.ToUpper(), dummy)
                End If
                dummy.Quantity += 1
            End If

            If Not String.IsNullOrEmpty(data.OptionType7) Then
                If dic.ContainsKey(data.OptionType7.ToUpper()) Then
                    dummy = dic(data.OptionType7.ToUpper())
                Else
                    dummy = New OptionSummary()
                    dummy.OptionType = data.OptionType7.ToUpper()
                    dic.Add(data.OptionType7.ToUpper(), dummy)
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

        Public Shared Function GetEquipmentSummaryDictionary(data As FTSetupReport) As Dictionary(Of String, List(Of String))
            Dim dic As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
            Dim lstdummy As New List(Of String)
            'Dim dummy As EquipmentSummary

            If Not String.IsNullOrEmpty(data.AdaptorA) Then
                lstdummy.Add(trim(data.AdaptorA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.AdaptorA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_ADAPTOR
                'dic.Add("ADAPTOR", trim(data.AdaptorA))
            End If

            If Not String.IsNullOrEmpty(data.AdaptorB) And (trim(data.AdaptorA) <> trim(data.AdaptorB)) Then    'If (AdapterA Name == AdaptorB Name) Then Error cause SAME Key
                lstdummy.Add(trim(data.AdaptorB))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.AdaptorB
                'dummy.TypeID = EQUIPMENT_TYPE_ID_ADAPTOR
                'dic.Add("ADAPTOR", trim(data.AdaptorB))
            End If

            If lstdummy.Count > 0 Then
                dic.Add("ADAPTOR", lstdummy)
                lstdummy = New List(Of String)
            End If

            If Not String.IsNullOrEmpty(data.BridgecableA) Then
                lstdummy.Add(trim(data.BridgecableA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.BridgecableA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BRIDGE_CABLE
                'dic.Add("BRIDGE CABLE", trim(data.BridgecableA))
            End If

            If Not String.IsNullOrEmpty(data.BridgecableB) And (trim(data.BridgecableA) <> trim(data.BridgecableB)) Then
                lstdummy.Add(trim(data.BridgecableB))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.BridgecableB
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BRIDGE_CABLE
                'dic.Add("BRIDGE CABLE", trim(data.BridgecableB))
            End If

            If lstdummy.Count > 0 Then
                dic.Add("BRIDGE CABLE", lstdummy)
                lstdummy = New List(Of String)
            End If

            If Not String.IsNullOrEmpty(data.DutcardA) Then
                lstdummy.Add(trim(data.DutcardA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.DutcardA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_DUTCARD
                'dic.Add("DUTCARD", trim(data.DutcardA))
            End If

            If Not String.IsNullOrEmpty(data.DutcardB) And (trim(data.DutcardA) <> trim(data.DutcardB)) Then
                lstdummy.Add(trim(data.DutcardB))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.DutcardB
                'dummy.TypeID = EQUIPMENT_TYPE_ID_DUTCARD
                'dic.Add("DUTCARD", trim(data.DutcardB))
            End If

            If lstdummy.Count > 0 Then
                dic.Add("DUTCARD", lstdummy)
                lstdummy = New List(Of String)
            End If

            If Not String.IsNullOrEmpty(data.TestBoxA) Then
                lstdummy.Add(trim(data.TestBoxA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.TestBoxA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BOX
                'dic.Add("BOARD", trim(data.TestBoxA))
            End If

            If Not String.IsNullOrEmpty(data.TestBoxB) And (trim(data.TestBoxA) <> trim(data.TestBoxB)) Then
                lstdummy.Add(trim(data.TestBoxB))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.TestBoxB
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BOX
                'dic.Add("BOARD", trim(data.TestBoxB))
            End If

            If lstdummy.Count > 0 Then
                dic.Add("BOX", lstdummy)
                dic.Add("BOARD", lstdummy)
                lstdummy = New List(Of String)
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
        bomOptionTbl = DBAccess.GetBOMOption(bomId) 'From DB
        If bomOptionTbl.Rows.Count > 0 Then

            Dim sumDic As Dictionary(Of String, OptionSummary) = OptionSummary.GetOptionSummaryList(m_Data) 'From Input

            Dim matchCount As Integer = 0
            Dim specialCount As Integer = 0
            Dim leftCount As Integer = 0
            Dim expectedMatchCount As Integer = bomOptionTbl.Rows.Count
            Dim expectedSpecialCount As Integer = 0
            Dim dummyOptionName As String
            Dim dummyOptionQty As Integer
            Dim dummyOptionCategory As String

            Dim dummyOtionSum As OptionSummary
            Dim lstOption As New List(Of String)

            For Each row As DataRow In bomOptionTbl.Rows

                dummyOptionName = row("Name").ToString().ToUpper()
                dummyOptionQty = CType(row("Quantity"), Integer)
                dummyOptionCategory = row("OptionCategory").ToString()

                If dummyOptionCategory = "SIGNAL_G" Then 'Count Signal_G that com from BOM
                    expectedSpecialCount += 1
                End If

                If String.IsNullOrEmpty(dummyOptionCategory) Then 'NOT SPECIAL CATEGORY
                    If sumDic.ContainsKey(dummyOptionName) Then
                        dummyOtionSum = sumDic(dummyOptionName)

                        If dummyOtionSum.Quantity >= dummyOptionQty Then
                            matchCount += 1
                            sumDic.Remove(dummyOptionName) 'Remove Key for check LEFT Key
                        Else
                            lstOption.Add(" - " & dummyOptionName & " จาก BOM มี " & dummyOptionQty & " ตัว ไม่เท่ากับ ที่ Input มา " & dummyOtionSum.Quantity & " ตัว")
                        End If
                    Else
                        lstOption.Add(" - " & dummyOptionName & " ยังไม่ถูกสแกน")
                    End If

                ElseIf dummyOptionCategory = "SIGNAL_G" Then 'SPECIAL CASE
                    If sumDic.ContainsKey(dummyOptionName) And specialCount = 0 Then 'First Signal_G only
                        dummyOtionSum = sumDic(dummyOptionName)

                        If dummyOtionSum.Quantity >= dummyOptionQty Then
                            matchCount += 1
                            specialCount += 1
                            sumDic.Remove(dummyOptionName) 'Remove Key for check LEFT Key
                        Else 'Found Match Option but NOT Equal of Quantity
                            specialCount += 1
                            lstOption.Add(" - " & dummyOptionName & " จาก BOM มี " & dummyOptionQty & " ตัว ไม่เท่ากับ ที่ Input มา " & dummyOtionSum.Quantity & " ตัว")
                        End If
                    Else
                        expectedMatchCount -= 1
                        expectedSpecialCount -= 1
                    End If
                End If
            Next

            'If sumDic.Count > 0 Then
            '    For Each item In sumDic.Keys
            '        leftCount += 1

            '        lstOption.Add(" - Device นี้ไม่ใช้ " & item & " โปรตรวจสอบใน BOM")
            '        sumDic.Remove(item)
            '        If sumDic.Count = 0 Then
            '            Exit For
            '        End If
            '    Next
            'End If

            If specialCount <> expectedSpecialCount Then
                lstOption.Add(" - Signal Generator ยังไม่ถูกแสกน")
            End If

            If matchCount <> expectedMatchCount Or leftCount > 0 Then
                Dim a As String = ">>> Option is Not match with BOM <<< <br/>"

                For Each str As String In lstOption
                    a = a & str & "<br/>"
                Next
                'errorMessageList.Add(String.Format("Option is Not match with BOM <br/> {0}:={1}<br/>", lstOption(0), lstOption(1)))
                errorMessageList.Add(a)
            End If

        End If
#End Region

#Region "Check BOMTestEquipment"
        'must have atleast 1
        bomTestEqiupmentTbl = DBAccess.GetBOMTestEquipment(bomId)
        If bomTestEqiupmentTbl.Rows.Count > 0 Then

            Dim dicEq As Dictionary(Of String, List(Of String)) = EquipmentSummary.GetEquipmentSummaryDictionary(m_Data)

            Dim dummyName As String
            Dim dummyTypeName As String
            Dim dummyIsAdaptor As Boolean
            Dim dummyIsLoadBoard As Boolean

            Dim getDic As List(Of String) = New List(Of String)
            Dim removeINList As List(Of String) = New List(Of String)
            Dim removeBOMList As List(Of DataRow) = New List(Of DataRow)

            Dim lstEquipment As New List(Of String)

            For Each row As DataRow In bomTestEqiupmentTbl.Rows

                dummyName = row("Name").ToString()
                dummyTypeName = row("TypeName").ToString()
                dummyIsAdaptor = CBool(row("IsAdaptor"))
                dummyIsLoadBoard = CBool(row("IsLoadboard"))

                If dicEq.ContainsKey(dummyTypeName) Then 'SAME TYPE

                    For Each item In dicEq.Item(dummyTypeName)

                        If Not getDic.Contains(item) Then
                            getDic.Add(item)
                        End If

                        If dummyName = item Then 'SAME TYPE, SAME NAME
                            'matchCount += 1

                            'Add WANTED Input to Remove List
                            removeINList.Add(item)

                            'Add WANTED BOM to Remove List
                            removeBOMList.Add(row)
                        End If
                    Next
                End If
            Next

            For Each removeData In removeINList
                getDic.Remove(removeData)
            Next

            For Each removeData In removeBOMList
                bomTestEqiupmentTbl.Rows.Remove(removeData)
            Next

            If bomTestEqiupmentTbl.Rows.Count > 0 Then
                lstEquipment.Add("อุปกรณ์ที่ยังไม่ได้แสกน")

                For Each row As DataRow In bomTestEqiupmentTbl.Rows
                    Dim errorBOM As String = row("Name").ToString()

                    lstEquipment.Add(" - " & errorBOM)
                Next
            End If

            If getDic.Count > 0 Then
                lstEquipment.Add("อุปกรณ์ที่ไม่จำเป็นต้องแสกน")

                For Each errorIN In getDic
                    lstEquipment.Add(" - " & errorIN)
                Next
            End If

            If lstEquipment.Count > 0 Then
                Dim a As String = ">>> Test Equipment is not match with BOM <<< <br/>"

                For Each str As String In lstEquipment
                    a = a & str & "<br/>"
                Next

                errorMessageList.Add(a)
            End If

        End If
#End Region

        If errorMessageList.Count > 0 Then
            ShowErrorMessage(String.Join("<br/>", errorMessageList.ToArray()))
            Exit Sub
        End If

#End Region

        Try
            Dim fileReader As String
            Dim SetupStatus As String
            fileReader = My.Computer.FileSystem.ReadAllText("\\10.28.33.113\www\FTSetupCheckSheet\_backup\MCNo.txt")

            If fileReader.Contains(m_Data.MCNo) Then
                SetupStatus = SETUP_STATUS_GOODNGTEST
            Else
                SetupStatus = SETUP_STATUS_CONFIRMED
            End If

            DBAccess.ConfirmFTReport(m_Data.MCNo, m_Data.LotNo, m_Data.PackageName, m_Data.DeviceName, SetupStatus)

            m_Data.SetupStatus = SetupStatus

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