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
    Private m_OldData As FTSetupReportHistory

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tmp As Object = Session(SESSION_KEY_DATA)
        Dim tmp2 As Object = Session(SESSION_KEY_OLD_DATA)

        If tmp Is Nothing Then
            Response.Redirect("~/SetupMain.aspx")
            Exit Sub
        Else
            m_Data = CType(tmp, FTSetupReport)
            m_OldData = CType(tmp2, FTSetupReportHistory)
        End If

        If IsPostBack AndAlso (m_Data.SetupStatus = "CONFIRMED" OrElse m_Data.SetupStatus = "GOODNGTEST") Then
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

        Dim qrTest As String = QRcodeTextBox.Text

        If qrTest.Length = 252 OrElse qrTest.Length = 332 OrElse qrTest.Length = 50 Then
            m_Data.LotNo = qrTest.Substring(30, 10).ToUpper().Trim()
            'm_Data.PackageName = QRcodeTextBox.Text.Substring(0, 10).ToUpper().Trim()
            'm_Data.DeviceName = QRcodeTextBox.Text.Substring(232, 20).ToUpper().Trim()

        ElseIf qrTest.Length = 10 Then
            m_Data.LotNo = qrTest
        Else
            QRcodeTextBox.Text = ""
            Exit Sub
        End If

        Dim apcsdbDenpyoTbl As DataTable

        Try
            apcsdbDenpyoTbl = DBAccess.GetWorkingSlipQRCode(m_Data.LotNo)
        Catch ex As Exception
            QRcodeTextBox.Text = ""
            ShowErrorMessage("Failed to get ApcsdbDenpyo :" & ex.Message)
            Exit Sub
        End Try

        If apcsdbDenpyoTbl.Rows.Count = 0 Then
            QRcodeTextBox.Text = ""
            ShowErrorMessage(String.Format("ไม่พบ Lot No : " + m_Data.LotNo + " กรุณาลองอีกครั้ง : [cellcon].[sp_get_denpyo] <br/>"))
            Exit Sub
        ElseIf apcsdbDenpyoTbl.Rows.Count > 1 Then
            QRcodeTextBox.Text = ""
            ShowErrorMessage(String.Format("พบ Lot No : " + apcsdbDenpyoTbl.Rows.Count.ToString() + " rows โปรดแจ้ง SYSTEM : [cellcon].[sp_get_denpyo] <br/>"))
            Exit Sub
        End If

        Dim apcsdbDenpyoRow As DataRow = apcsdbDenpyoTbl.Rows(0)

        m_Data.PackageName = apcsdbDenpyoRow("PackageName").ToString()
        m_Data.DeviceName = apcsdbDenpyoRow("DeviceName").ToString()

        DeviceNameTextBox.Text = m_Data.DeviceName
        PackagenameTextBox.Text = m_Data.PackageName
        lotnoTextbox.Text = m_Data.LotNo

        Session(SESSION_KEY_DATA) = m_Data
        QRcodeTextBox.Text = ""
    End Sub

#Region "Matching EQP and Option class"

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
                lstdummy.Add(Trim(data.AdaptorA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.AdaptorA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_ADAPTOR
                'dic.Add("ADAPTOR", trim(data.AdaptorA))
            End If

            If Not String.IsNullOrEmpty(data.AdaptorB) And (Trim(data.AdaptorA) <> Trim(data.AdaptorB)) Then    'If (AdapterA Name == AdaptorB Name) Then Error cause SAME Key
                lstdummy.Add(Trim(data.AdaptorB))

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
                lstdummy.Add(Trim(data.BridgecableA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.BridgecableA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BRIDGE_CABLE
                'dic.Add("BRIDGE CABLE", trim(data.BridgecableA))
            End If

            If Not String.IsNullOrEmpty(data.BridgecableB) And (Trim(data.BridgecableA) <> Trim(data.BridgecableB)) Then
                lstdummy.Add(Trim(data.BridgecableB))

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
                lstdummy.Add(Trim(data.DutcardA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.DutcardA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_DUTCARD
                'dic.Add("DUTCARD", trim(data.DutcardA))
            End If

            If Not String.IsNullOrEmpty(data.DutcardB) And (Trim(data.DutcardA) <> Trim(data.DutcardB)) Then
                lstdummy.Add(Trim(data.DutcardB))

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
                lstdummy.Add(Trim(data.TestBoxA))

                'dummy = New EquipmentSummary()
                'dummy.Name = data.TestBoxA
                'dummy.TypeID = EQUIPMENT_TYPE_ID_BOX
                'dic.Add("BOARD", trim(data.TestBoxA))
            End If

            If Not String.IsNullOrEmpty(data.TestBoxB) And (Trim(data.TestBoxA) <> Trim(data.TestBoxB)) Then
                lstdummy.Add(Trim(data.TestBoxB))

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

#Region "Check Option"

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

#Region "Check TestEquipment"
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

#Region "Read Text File & Check Lot & Add Spe GO/NG Sample"
        Try
            Dim currentTransLotsTbl As DataTable

            Try
                currentTransLotsTbl = DBAccess.GetCurrentTransLots(m_Data.LotNo)
            Catch ex As Exception
                ShowErrorMessage("Failed to get CurrentTransLots :" & ex.Message)
                Exit Sub
            End Try

            If currentTransLotsTbl.Rows.Count = 0 Then
                ShowErrorMessage(String.Format("ไม่พบ Lot No : " + m_Data.LotNo + " โปรดตรวจสอบที่ ATOM : [cellcon].[sp_get_current_trans_lots] <br/>"))
                Exit Sub
            ElseIf currentTransLotsTbl.Rows.Count > 1 Then
                ShowErrorMessage(String.Format("พบ Lot No : " + currentTransLotsTbl.Rows.Count.ToString() + " rows โปรดแจ้ง SYSTEM : [cellcon].[sp_get_current_trans_lots] <br/>"))
                Exit Sub
            End If

            Dim currentTransLotsRow As DataRow = currentTransLotsTbl.Rows(0)

            Dim lotId As Int32 = Int32.Parse(currentTransLotsRow("LotId").ToString())
            Dim backStepNo As Int32 = Int32.Parse(currentTransLotsRow("StepNo").ToString())
            Dim flowName As String = currentTransLotsRow("FlowName").ToString()
            Dim wipState As String = currentTransLotsRow("WipState").ToString()
            Dim processState As String = currentTransLotsRow("ProcessState").ToString()
            Dim qualityState As String = currentTransLotsRow("QualityState").ToString()
            Dim isSpecialFlow As Int32 = Int32.Parse(currentTransLotsRow("IsSpecialFlow").ToString())
            Dim processCategory As Int32 = Int32.Parse(currentTransLotsRow("ProductionCategory").ToString())
            Dim lotOISRank As String = currentTransLotsRow("LotOISRank").ToString()
            Dim SetupStatus As String

            'Now is Special Flow then Is it GO/NG Sample Judge
            If (String.IsNullOrEmpty(flowName)) Then
                ShowErrorMessage("ไม่พบ Flow โปรดตรวจสอบที่ ATOM : [cellcon].[sp_get_current_trans_lots] <br/>")
                Exit Sub
            End If

            'Split Device from Rank ex. BD450M2FP3-CE2 to (0) = BD450M2FP3, (1) = CE2
            Dim splitNewDeviceName As String() = m_Data.DeviceName.Split("-"c)

            If m_Data.OISDevice <> splitNewDeviceName(0) Then
                ShowErrorMessage("Lot Device = '" + splitNewDeviceName(0) + "' not match with OIS Device = '" + m_Data.OISDevice + "' โปรดตรวจสอบ Device ของ Lot และ OIS <br/>")
                Exit Sub
            End If

            'OIS Rank = -/C/M 'WS Rank = "","C"
            Dim wordsRank As String() = m_Data.OISRank.Split("/"c)
            Dim rankChecked As Boolean = False

            If lotOISRank = "" Then
                lotOISRank = "-"
            End If

            For index = 0 To wordsRank.Length - 1
                If wordsRank(index).Equals(lotOISRank) Then
                    rankChecked = True
                    Exit For
                End If
            Next

            If rankChecked = False Then
                ShowErrorMessage("Lot Rank = '" + lotOISRank + "' not match with OIS Rank = '" + m_Data.OISRank + "' โปรดตรวจสอบ Rank ของ Lot และ OIS <br/>")
                Exit Sub
            End If

            Dim fileReaderMC As String = My.Computer.FileSystem.ReadAllText("\\10.28.33.113\www\FTSetupCheckSheet\_backup\MCNo.txt")
            'm_Data.TestFlow = AUTO2ASISAMPLE | flowName = AUTO(2)ASISAMPLE
            Dim fileReaderFlow As String = My.Computer.FileSystem.ReadAllText("\\10.28.33.113\www\FTSetupCheckSheet\_backup\Flow.txt")

            'Split by new line " & vbCrLf & "
            Dim wordsFlow As String() = fileReaderFlow.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            Dim flowChecked As Boolean = True

            'wordsFlow(0) = AUTO2ASISAMPLE
            'wordsFlow(1) = AUTO3ASI
            'is(wordsFlow(0,1,..) == AUTO2)?
            For index = 0 To wordsFlow.Length - 1
                If wordsFlow(index).Equals(m_Data.TestFlow) Then
                    flowChecked = False
                    Exit For
                End If
            Next

            'M/C No in control, Not E Lot(processCategory = 30), Not AUTO2ASISAMPLE Flow
            If fileReaderMC.Contains(m_Data.MCNo) And (processCategory <> 30) And flowChecked Then

                'Split Device from Rank ex. BD450M2FP3-CE2 to (0) = BD450M2FP3, (1) = CE2
                Dim splitOldDeviceName As String() = m_OldData.DeviceName.Split("-"c)

                '(ProgramName CHANGED or (ProgramName NOT CHANGED but DeviceName CHANGED))
                If (m_OldData.SetupStatus = "GOODNGTEST") OrElse
                   (m_Data.ProgramName <> m_OldData.ProgramName) OrElse
                   (m_Data.ProgramName = m_OldData.ProgramName And splitNewDeviceName(0) <> splitOldDeviceName(0)) Then
                    SetupStatus = SETUP_STATUS_GOODNGTEST
                Else
                    SetupStatus = SETUP_STATUS_CONFIRMED
                End If
            Else
                SetupStatus = SETUP_STATUS_CONFIRMED
            End If

            If flowName.Contains("AUTO(") Then
                Dim splitFlowName As String() = flowName.Split(CType("(", Char()))

                Dim comparableFlowName As String
                comparableFlowName = splitFlowName(0)
                splitFlowName = splitFlowName(1).Split(CType(")", Char()))
                comparableFlowName += splitFlowName(0)

                If splitFlowName.Count > 1 Then
                    For index = 1 To splitFlowName.Count - 1
                        comparableFlowName += splitFlowName(index)
                    Next
                End If

                'Check is Now Flow is matching with OIS
                If (comparableFlowName = m_Data.TestFlow) Then

                    If (wipState = "WIP" OrElse wipState = "Already Input") Then

                        If (processState = "Wait" OrElse processState = "Abnormal WIP") Then

                            If (isSpecialFlow = 1 And qualityState = "Special Flow") Then 'Skip for now wait multi add specialFlow

                                If SetupStatus = "GOODNGTEST" Then
                                    ShowErrorMessage("Lot เป็น Special Flow ไม่สามารถนำมา Confirm กับเครื่องที่เข้าเงื่อนไขที่ต้องรัน GO/NG Sample ได้ กรุณาเปลี่ยน Lot <br/>")
                                    Exit Sub
                                End If

                                ConfirmReport(SETUP_STATUS_CONFIRMED)
                                Exit Sub

                            ElseIf (isSpecialFlow = 0 And qualityState = "Normal") Then

                                'Add Special Flow at GO/NGSampleJudge only
                                If SetupStatus = SETUP_STATUS_GOODNGTEST Then

                                    Dim flowPatternId As Int32 = 1689
                                    Dim userId As Int32 = 1289

                                    Dim transLotsFlowsTbl As DataTable

                                    Try
                                        transLotsFlowsTbl = DBAccess.GetTransLotsFlows(lotId)
                                    Catch ex As Exception
                                        ShowErrorMessage("Failed to get TransLotsFlows :" & ex.Message)
                                        Exit Sub
                                    End Try

                                    If transLotsFlowsTbl.Rows.Count > 0 Then

                                        Dim stepNo As Integer = 0 'stepNo = 100, backStepNo = 200 In Stored will add 101 then flow end gonna go to 200

                                        For index = transLotsFlowsTbl.Rows.Count - 1 To 0 Step -1
                                            If transLotsFlowsTbl.Rows(index)("job_name").ToString() = flowName Then
                                                If index = 0 Then
                                                    stepNo = 0
                                                    Exit For
                                                    'ShowErrorMessage(">>> No Flow Before '" + flowName.Trim() + " Please contact SYSTEM <<< <br/>")
                                                    'Exit Sub
                                                End If

                                                For index2 = index - 1 To 0 Step -1
                                                    If Int32.Parse(transLotsFlowsTbl.Rows(index2)("is_skipped").ToString()) = 0 And
                                                           transLotsFlowsTbl.Rows(index2)("job_name").ToString() <> transLotsFlowsTbl.Rows(index)("job_name").ToString() Then
                                                        stepNo = Int32.Parse(transLotsFlowsTbl.Rows(index2)("step_no").ToString())
                                                        Exit For
                                                    End If
                                                Next

                                                If stepNo <> 0 Then
                                                    Exit For
                                                End If
                                            End If
                                        Next

                                        SetSpecialFlowHere(lotId, stepNo, backStepNo, userId, flowPatternId)

                                    Else
                                        ShowErrorMessage("ไม่พบ Lot Details โปรดตรวจสอบที่ ATOM : [atom].[sp_get_trans_lot_flows] <br/>")
                                        Exit Sub
                                    End If

                                Else
                                    ConfirmReport(SETUP_STATUS_CONFIRMED)
                                End If
                            Else
                                ShowErrorMessage(">>> isSpecialFlow is '" + isSpecialFlow.ToString() + "' And qualityState Is '" + qualityState.Trim() + "' โปรดติดต่อ SYSTEM <<< <br/>")
                                Exit Sub
                            End If
                        Else
                            ShowErrorMessage(">>> processState is '" + processState.Trim() + "' โปรดติดต่อ SYSTEM <<< <br/>")
                            Exit Sub
                        End If
                    Else
                        ShowErrorMessage(">>> wipState is '" + wipState.Trim() + "' โปรดติดต่อ SYSTEM <<< <br/>")
                        Exit Sub
                    End If
                Else
                    ShowErrorMessage(">>> ATOM Flow is '" + flowName.Trim() + "' not match with OIS Flow is '" + m_Data.TestFlow.Trim() + "' โปรดติดต่อ SYSTEM <<< <br/>")
                    Exit Sub
                End If
            Else
                ShowErrorMessage("Flow is " + flowName.Trim() + "ไม่สามารถนำมา Setup ได้ กรุณาเปลี่ยน Lot")
                Exit Sub
            End If

        Catch ex As Exception
            ShowErrorMessage("Confirmation is failed : " & ex.Message)
        End Try
#End Region

    End Sub

    Private Sub ConfirmReport(setupStatus As String)

        SetNextLotHere(m_Data.MCNo, m_Data.LotNo)

        m_Data.SetupStatus = setupStatus

        SetFTReport()

    End Sub

    Private Sub SetSpecialFlowHere(lotId As Int32, stepNo As Int32, backStepNo As Int32, userId As Int32, flowPatternId As Int32)
        'Set Special Flow here
        Try
            DBAccess.SetSpecialFlow(lotId, stepNo, backStepNo, userId, flowPatternId, 1)
            ConfirmReport(SETUP_STATUS_GOODNGTEST)
        Catch ex As Exception
            ShowErrorMessage("Failed to Add Special Flows :" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub SetNextLotHere(mcNo As String, lotNo As String)
        'Set Next Lot here
        Try
            DBAccess.SetNextLot(mcNo, lotNo)
        Catch ex As Exception
            ShowErrorMessage("Failed to Add Next Lots :" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub SetFTReport()
        Try
            Dim affRow As Integer = DBAccess.UpdateFTSetupReport(m_Data.MCNo,
                                                                 m_Data.LotNo,
                                                                 m_Data.PackageName,
                                                                 m_Data.DeviceName,
                                                                 m_Data.ProgramName,
                                                                 m_Data.TesterType,
                                                                 m_Data.TestFlow,
                                                                 m_Data.OISRank,
                                                                 m_Data.OISDevice,
                                                                 m_Data.QRCodesocket1,
                                                                 m_Data.QRCodesocket2,
                                                                 m_Data.QRCodesocket3,
                                                                 m_Data.QRCodesocket4,
                                                                 m_Data.QRCodesocketChannel1,
                                                                 m_Data.QRCodesocketChannel2,
                                                                 m_Data.QRCodesocketChannel3,
                                                                 m_Data.QRCodesocketChannel4,
                                                                 m_Data.QRCodesocket5,
                                                                 m_Data.QRCodesocket6,
                                                                 m_Data.QRCodesocket7,
                                                                 m_Data.QRCodesocket8,
                                                                 m_Data.QRCodesocketChannel5,
                                                                 m_Data.QRCodesocketChannel6,
                                                                 m_Data.QRCodesocketChannel7,
                                                                 m_Data.QRCodesocketChannel8,
                                                                 m_Data.TesterNoA,
                                                                 m_Data.TesterNoAQRcode,
                                                                 m_Data.TesterNoB,
                                                                 m_Data.TesterNoBQRcode,
                                                                 m_Data.TesterNoC,
                                                                 m_Data.TesterNoCQRcode,
                                                                 m_Data.TesterNoD,
                                                                 m_Data.TesterNoDQRcode,
                                                                 m_Data.ChannelAFTB,
                                                                 m_Data.ChannelAFTBQRcode,
                                                                 m_Data.ChannelBFTB,
                                                                 m_Data.ChannelBFTBQRcode,
                                                                 m_Data.ChannelCFTB,
                                                                 m_Data.ChannelCFTBQRcode,
                                                                 m_Data.ChannelDFTB,
                                                                 m_Data.ChannelDFTBQRcode,
                                                                 m_Data.ChannelEFTB,
                                                                 m_Data.ChannelEFTBQRcode,
                                                                 m_Data.ChannelFFTB,
                                                                 m_Data.ChannelFFTBQRcode,
                                                                 m_Data.ChannelGFTB,
                                                                 m_Data.ChannelGFTBQRcode,
                                                                 m_Data.ChannelHFTB,
                                                                 m_Data.ChannelHFTBQRcode,
                                                                 m_Data.TestBoxA,
                                                                 m_Data.TestBoxAQRcode,
                                                                 m_Data.TestBoxB,
                                                                 m_Data.TestBoxBQRcode,
                                                                 m_Data.TestBoxC,
                                                                 m_Data.TestBoxCQRcode,
                                                                 m_Data.TestBoxD,
                                                                 m_Data.TestBoxDQRcode,
                                                                 m_Data.TestBoxE,
                                                                 m_Data.TestBoxEQRcode,
                                                                 m_Data.TestBoxF,
                                                                 m_Data.TestBoxFQRcode,
                                                                 m_Data.TestBoxG,
                                                                 m_Data.TestBoxGQRcode,
                                                                 m_Data.TestBoxH,
                                                                 m_Data.TestBoxHQRcode,
                                                                 m_Data.AdaptorA,
                                                                 m_Data.AdaptorAQRcode,
                                                                 m_Data.AdaptorB,
                                                                 m_Data.AdaptorBQRcode,
                                                                 m_Data.DutcardA,
                                                                 m_Data.DutcardAQRcode,
                                                                 m_Data.DutcardB,
                                                                 m_Data.DutcardBQRcode,
                                                                 m_Data.BridgecableA,
                                                                 m_Data.BridgecableAQRcode,
                                                                 m_Data.BridgecableB,
                                                                 m_Data.BridgecableBQRcode,
                                                                 m_Data.TypeChangePackage,
                                                                 m_Data.SetupStartDate,
                                                                 m_Data.SetupEndDate,
                                                                 m_Data.BoxTesterConnection,
                                                                 m_Data.OptionSetup,
                                                                 m_Data.OptionConnection,
                                                                 m_Data.OptionName1,
                                                                 m_Data.OptionName2,
                                                                 m_Data.OptionName3,
                                                                 m_Data.OptionName4,
                                                                 m_Data.OptionName5,
                                                                 m_Data.OptionName6,
                                                                 m_Data.OptionName7,
                                                                 m_Data.OptionType1,
                                                                 m_Data.OptionType1QRcode,
                                                                 m_Data.OptionType2,
                                                                 m_Data.OptionType2QRcode,
                                                                 m_Data.OptionType3,
                                                                 m_Data.OptionType3QRcode,
                                                                 m_Data.OptionType4,
                                                                 m_Data.OptionType4QRcode,
                                                                 m_Data.OptionType5,
                                                                 m_Data.OptionType5QRcode,
                                                                 m_Data.OptionType6,
                                                                 m_Data.OptionType6QRcode,
                                                                 m_Data.OptionType7,
                                                                 m_Data.OptionType7QRcode,
                                                                 m_Data.OptionSetting1,
                                                                 m_Data.OptionSetting2,
                                                                 m_Data.OptionSetting3,
                                                                 m_Data.OptionSetting4,
                                                                 m_Data.OptionSetting5,
                                                                 m_Data.OptionSetting6,
                                                                 m_Data.OptionSetting7,
                                                                 m_Data.QfpVacuumPad,
                                                                 m_Data.QfpSocketSetup,
                                                                 m_Data.QfpSocketDecision,
                                                                 m_Data.QfpDecisionLeadPress,
                                                                 m_Data.QfpTray, m_Data.SopStopper,
                                                                 m_Data.SopSocketDecision,
                                                                 m_Data.SopDecisionLeadPress,
                                                                 m_Data.ManualCheckTest,
                                                                 m_Data.ManualCheckTE,
                                                                 m_Data.ManualCheckRequestTE,
                                                                 m_Data.ManualCheckRequestTEConfirm,
                                                                 m_Data.PkgGood, m_Data.PkgNG,
                                                                 m_Data.PkgGoodJudgement,
                                                                 m_Data.PkgNGJudgement,
                                                                 m_Data.PkgNishikiCamara,
                                                                 m_Data.PkgNishikiCamaraJudgement,
                                                                 m_Data.PkqBantLead,
                                                                 m_Data.PkqKakeHige,
                                                                 m_Data.BgaSmallBall,
                                                                 m_Data.BgaBentTape,
                                                                 m_Data.Bge5S,
                                                                 m_Data.SetupStatus,
                                                                 m_Data.ConfirmedCheckSheetOp,
                                                                 m_Data.ConfirmedCheckSheetSection,
                                                                 m_Data.ConfirmedCheckSheetGL,
                                                                 m_Data.ConfirmedShonoSection,
                                                                 m_Data.ConfirmedShonoGL,
                                                                 m_Data.ConfirmedShonoOp,
                                                                 m_Data.StatusShonoOP,
                                                                 m_Data.SetupConfirmDate)

            Session(SESSION_KEY_DATA) = m_Data
            Session(SESSION_KEY_NEW_DATA_SETUP) = Nothing
            Session(SESSION_KEY_OLD_DATA) = m_OldData

            HideErrorMessage()

            Response.Redirect("~/SetupMain.aspx", False)
        Catch ex As Exception
            ShowErrorMessage("Update Failed : " & HttpUtility.HtmlEncode(ex.Message & vbNewLine & ex.StackTrace))
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