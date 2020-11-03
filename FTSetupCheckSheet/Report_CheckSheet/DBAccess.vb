Imports System.Data.SqlClient

Public Class DBAccess
    Private Sub New()
    End Sub

    Public Shared Function CreateBlankFTSetupRecord(mcNo As String) As Integer
        'After Scan Machine QRCode 1 (First Time Machine)
        Dim ret As Integer = 0

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_set_setupchecksheet_createblankftsetuprecord]"
                cmd.Parameters.Add("@MCNo", SqlDbType.VarChar, 15).Value = mcNo

                ret = cmd.ExecuteNonQuery()

                connection.Close()
            End Using
        End Using

        Return ret

    End Function

    Friend Shared Function GetPCMain(fullMCNo As String) As String
        'ConfirmedReport Working Slip 1
        Dim tbl = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getpcmain]"
                cmd.Parameters.Add("@FullMCNo", SqlDbType.VarChar, 15).Value = fullMCNo

                tbl.Load(cmd.ExecuteReader())

                If tbl.Rows.Count > 0 Then
                    Return tbl.Rows(0)("PCMain").ToString()
                Else
                    Return ""
                End If

                connection.Close()
            End Using
        End Using
    End Function

    Public Shared Function GetEquipmentByQRName(qrName As String, ParamArray quipmentTypeIdArray As Integer()) As DataTable
        'Everytime after scan QRCode
        Dim dt As DataTable = New DataTable()

        If quipmentTypeIdArray Is Nothing OrElse quipmentTypeIdArray.Length = 0 Then
            Throw New Exception("EquipmentTypeIdArray must not be Nothing or 0-length")
        End If

        Dim strINCondition As String = Nothing

        For Each eqtId As Integer In quipmentTypeIdArray
            If String.IsNullOrEmpty(strINCondition) Then
                strINCondition = eqtId.ToString()
            Else
                strINCondition &= "," & eqtId.ToString()
            End If
        Next

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getequipmentbyqrcode]"
                cmd.Parameters.Add("@QRName", SqlDbType.VarChar, 9).Value = qrName
                cmd.Parameters.Add("@strINCondition", SqlDbType.VarChar, 15).Value = strINCondition

                dt.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return dt

    End Function

    Public Shared Function GetFTSetupReportByMCNo(mcNo As String) As DataTable
        'After Scan Machine QRCode 1 (Not First Time Machine)
        Dim dt As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getftsetupreportbymcno]"
                cmd.Parameters.Add("@MCNo", SqlDbType.VarChar, 15).Value = mcNo

                dt.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return dt

    End Function

    Public Shared Function GetFTSetupReportHistoryByMCNo(mcNo As String) As DataTable
        Dim dt As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getlastconfirmed]"
                cmd.Parameters.Add("@MCNo", SqlDbType.VarChar, 15).Value = mcNo

                dt.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return dt

    End Function

    Public Shared Function GetOSPSocketSystem(QRcode As String) As DataTable
        Dim dt As DataTable = New DataTable()

        Using con As SqlConnection = New SqlConnection(My.Settings.DBxConnectionString)
            con.Open()

            Using cmd As SqlCommand = con.CreateCommand()

                cmd.CommandText = "Select JIG.TempData.ID, JIG.TempData.QRCode, JIG.TempData.SmallCode,
                                   JIG.TempType.LSIProcessID FROM JIG.TempData INNER Join
                                   JIG.TempSubType ON JIG.TempData.SubTypeID = JIG.TempSubType.ID INNER Join
                                   JIG.TempType ON JIG.TempSubType.TypeID = JIG.TempType.ID
                                   Where (JIG.TempType.LSIProcessID = '9') AND (JIG.TempData.QRCode = @QRcode)"

                cmd.Parameters.Add("@QRcode", SqlDbType.VarChar, 50).Value = QRcode
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        Return dt

    End Function


    Public Shared Function GetBOM(customerDeviceName As String, assyPackageName As String, testFlowName As String, testerType As String, pcMain As String) As DataTable
        'ConfirmedReport Working Slip 2
        Dim tbl As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getbom]"
                cmd.Parameters.Add("@CustomerDeviceName", SqlDbType.VarChar, 20).Value = customerDeviceName
                cmd.Parameters.Add("@PackageName", SqlDbType.VarChar, 10).Value = assyPackageName
                cmd.Parameters.Add("@TestFlowName", SqlDbType.VarChar, 20).Value = testFlowName
                cmd.Parameters.Add("@TesterTypeName", SqlDbType.VarChar, 50).Value = testerType
                cmd.Parameters.Add("@PCMain", SqlDbType.VarChar, 50).Value = pcMain

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Public Shared Function GetBOMOption(bomId As Integer) As DataTable
        'ConfirmedReport Working Slip 3
        Dim tbl As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getbomoption]"
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomId

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Public Shared Function GetBOMTestEquipment(bomId As Integer) As DataTable
        'ConfirmedReport Working Slip 4
        Dim tbl As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getbomtestequipment]"
                cmd.Parameters.Add("@FTBomID", SqlDbType.Int).Value = bomId

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Public Shared Function GetFTMachine(eqpName As String) As DataTable
        'Isn't called yet.
        Dim tbl As DataTable = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_get_setupchecksheet_getftmachine]"
                cmd.Parameters.Add("@EquipmentName", SqlDbType.VarChar, 15).Value = eqpName

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Friend Shared Function GetCurrentTransLots(lotNo As String) As DataTable

        Dim tbl = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[cellcon].[sp_get_current_trans_lots]"
                cmd.Parameters.Add("@lot_no", SqlDbType.VarChar, 10).Value = lotNo

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Friend Shared Function GetTransLotsFlows(lotId As Int32) As DataTable

        Dim tbl = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[atom].[sp_get_trans_lot_flows]"
                cmd.Parameters.Add("@lot_id", SqlDbType.Int).Value = lotId

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    Friend Shared Function GetWorkingSlipQRCode(lotNo As String) As DataTable

        Dim tbl = New DataTable()

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[cellcon].[sp_get_denpyo]"
                cmd.Parameters.Add("@lotNo", SqlDbType.VarChar, 10).Value = lotNo

                tbl.Load(cmd.ExecuteReader())

                connection.Close()
            End Using
        End Using

        Return tbl

    End Function

    'Public Shared Function ConfirmFTReport(mcNo As String, lotNo As String, PackageName As String, deviceName As String, SetupStatus As String) As Integer
    '    'ConfirmedReport Working Slip 5
    '    Dim ret As Integer

    '    Using connection As New SqlConnection(My.Settings.SPConnectionString)
    '        connection.Open()

    '        Using cmd As New SqlCommand
    '            cmd.Connection = connection
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.CommandText = "[dbo].[sp_set_setupchecksheet_confirmftreport]"
    '            cmd.Parameters.Add("@MCNo", SqlDbType.VarChar, 15).Value = mcNo
    '            cmd.Parameters.Add("@LotNo", SqlDbType.VarChar, 10).Value = lotNo
    '            cmd.Parameters.Add("@PackageName", SqlDbType.VarChar, 10).Value = PackageName
    '            cmd.Parameters.Add("@DeviceName", SqlDbType.VarChar, 20).Value = deviceName
    '            cmd.Parameters.Add("@SetupStatus", SqlDbType.VarChar, 10).Value = SetupStatus
    '            cmd.Parameters.Add("@SetupConfirmDate", SqlDbType.DateTime).Value = Now

    '            ret = cmd.ExecuteNonQuery()

    '            connection.Close()
    '        End Using
    '    End Using

    '    Return ret

    'End Function

    Public Shared Function SetSpecialFlow(lotId As Int32, stepNo As Int32, backStepNo As Int32, userId As Int32, flowPatternId As Int32, isSpecialFlow As Int32) As Integer
        'After SaveBtn is pressed (From SetupStep7CheckSheet9)
        Dim row As Integer

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[atom].[sp_set_trans_special_flow]"

                cmd.Parameters.Add("@lot_id", SqlDbType.Int).Value = lotId
                cmd.Parameters.Add("@step_no", SqlDbType.Int).Value = stepNo
                cmd.Parameters.Add("@back_step_no", SqlDbType.Int).Value = backStepNo
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = userId
                cmd.Parameters.Add("@flow_pattern_id", SqlDbType.Int).Value = flowPatternId
                cmd.Parameters.Add("@is_special_flow", SqlDbType.Int).Value = isSpecialFlow

                row = cmd.ExecuteNonQuery()

                connection.Close()
            End Using
        End Using

        Return row

    End Function

    Public Shared Function ClearSpecialFlow(lotId As Int32, specialflowId As Int32) As Integer
        'After CancelBtn is pressed (From SetupMain)
        Dim row As Integer

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[atom].[sp_set_clear_special_flow]"

                cmd.Parameters.Add("@lot_id", SqlDbType.Int).Value = lotId
                cmd.Parameters.Add("@special_id", SqlDbType.Int).Value = specialflowId

                row = cmd.ExecuteNonQuery()

                connection.Close()
            End Using
        End Using

        Return row

    End Function

    Public Shared Function SetNextLot(mcNo As String, lotNo As String) As Integer
        'After SaveBtn is pressed (From SetupStep7CheckSheet9)
        Dim row As Integer

        Using connection As New SqlConnection(My.Settings.APCsUserSPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[cellcon].[sp_set_nextlot]"

                cmd.Parameters.Add("@mc_name", SqlDbType.VarChar, 30).Value = mcNo
                cmd.Parameters.Add("@lot_no", SqlDbType.VarChar, 10).Value = lotNo

                row = cmd.ExecuteNonQuery()

                connection.Close()
            End Using
        End Using

        Return row

    End Function

    Public Shared Function UpdateFTSetupReport(mcno As String, lotNo As String, PackageName As String, deviceName As String,
            programName As String, testerType As String, testFlow As String, oisRank As String, oisDevice As String,
            qRCodesocket1 As String, qrCodesocket2 As String, qrCodesocket3 As String, qrCodesocket4 As String,
            QRCodesocketChannel1 As String, QRCodesocketChannel2 As String, QRCodesocketChannel3 As String, QRCodesocketChannel4 As String,
            qRCodesocket5 As String, qrCodesocket6 As String, qrCodesocket7 As String, qrCodesocket8 As String,
            QRCodesocketChannel5 As String, QRCodesocketChannel6 As String, QRCodesocketChannel7 As String, QRCodesocketChannel8 As String,
            testerNoA As String, testerNoAQRcode As String, testerNoB As String, testerNoBQRcode As String, testerNoC As String, testerNoCQRcode As String, testerNoD As String, testerNoDQRcode As String,
            channelAFTB As String, ChannelAFTBQRcode As String, channelBFTB As String, ChannelBFTBQRcode As String, channelCFTB As String, ChannelCFTBQRcode As String, channelDFTB As String, ChannelDFTBQRcode As String,
            channelEFTB As String, ChannelEFTBQRcode As String, channelFFTB As String, ChannelFFTBQRcode As String, channelGFTB As String, ChannelGFTBQRcode As String, channelHFTB As String, ChannelHFTBQRcode As String,
            testBoxA As String, testBoxAQRcode As String, testBoxB As String, testBoxBQRcode As String, testBoxC As String, testBoxCQRcode As String, testBoxD As String, testBoxDQRcode As String,
            testBoxE As String, testBoxEQRcode As String, testBoxF As String, testBoxFQRcode As String, testBoxG As String, testBoxGQRcode As String, testBoxH As String, testBoxHQRcode As String,
            adaptorA As String, adaptorAQRcode As String, adaptorB As String, adaptorBQRcode As String,
            dutcardA As String, dutcardAQRcode As String, dutcardB As String, dutcardBQRcode As String,
            bridgecableA As String, bridgecableAQRcode As String, bridgecableB As String, bridgecableBQRcode As String,
            typeChangePackage As String, setupStartDate As System.Nullable(Of DateTime), setupEndDate As System.Nullable(Of DateTime),
            BoxTesterConnection As String, optionSetup As String, optionConnection As String,
            optionName1 As String, optionName2 As String, optionName3 As String, optionName4 As String, optionName5 As String, optionName6 As String, optionName7 As String,
            optionType1 As String, optionType1QRcode As String, optionType2 As String, optionType2QRcode As String, optionType3 As String, optionType3QRcode As String,
            optionType4 As String, optionType4QRcode As String, optionType5 As String, optionType5QRcode As String, optionType6 As String, optionType6QRcode As String, optionType7 As String, optionType7QRcode As String,
            optionSetting1 As String, optionSetting2 As String, optionSetting3 As String, optionSetting4 As String, optionSetting5 As String, optionSetting6 As String, optionSetting7 As String,
            qfpVacuumPad As String, qfpSocketSetup As String, qfpSocketDecision As String, qfpDecisionLeadPress As String, qfpTray As String,
            sopStopper As String, sopSocketDecision As String, sopDecisionLeadPress As String,
            manualCheckTest As System.Nullable(Of Integer), manualCheckTE As String, manualCheckRequestTE As System.Nullable(Of Integer), ManualCheckRequestTEConfirm As String,
            pkgGood As String, pkgNG As String, PkgGoodJudgement As String, PkgNGJudgement As String, pkgNishikiCamara As String, PkgNishikiCamaraJudgement As String, pkqBantLead As String,
            pkqKakeHige As String, bgaSmallBall As String, bgaBentTape As String, bge5S As String,
            setupStatus As String, ConfirmedCheckSheetOp As String, ConfirmedCheckSheetSection As String, ConfirmedCheckSheetGL As String, ConfirmedShonoSection As String, ConfirmedShonoGL As String, ConfirmedShonoOp As String,
            StatusShonoOP As String, setupConfirmDate As System.Nullable(Of DateTime)) As Integer
        'After SaveBtn is pressed (From SetupStep7CheckSheet9)
        Dim row As Integer

        Using connection As New SqlConnection(My.Settings.SPConnectionString)
            connection.Open()

            Using cmd As New SqlCommand
                cmd.Connection = connection
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "[dbo].[sp_set_setupchecksheet_updateftsetupreport]"

                cmd.Parameters.Add("@MCNo", SqlDbType.VarChar, 15).Value = mcno
                cmd.Parameters.Add("@LotNo", SqlDbType.VarChar, 10).Value = lotNo
                cmd.Parameters.Add("@PackageName", SqlDbType.VarChar, 10).Value = PackageName
                cmd.Parameters.Add("@DeviceName", SqlDbType.VarChar, 20).Value = deviceName
                cmd.Parameters.Add("@ProgramName", SqlDbType.VarChar, 30).Value = programName
                cmd.Parameters.Add("@TesterType", SqlDbType.VarChar, 30).Value = testerType
                cmd.Parameters.Add("@TestFlow", SqlDbType.VarChar, 30).Value = testFlow
                cmd.Parameters.Add("@OISRank", SqlDbType.VarChar, 30).Value = oisRank
                cmd.Parameters.Add("@OISDevice", SqlDbType.VarChar, 30).Value = oisDevice
                cmd.Parameters.Add("@QRCodesocket1", SqlDbType.VarChar, 30).Value = qRCodesocket1
                cmd.Parameters.Add("@QRCodesocket2", SqlDbType.VarChar, 30).Value = qrCodesocket2
                cmd.Parameters.Add("@QRCodesocket3", SqlDbType.VarChar, 30).Value = qrCodesocket3
                cmd.Parameters.Add("@QRCodesocket4", SqlDbType.VarChar, 30).Value = qrCodesocket4
                cmd.Parameters.Add("@QRCodesocketChannel1", SqlDbType.VarChar, 30).Value = QRCodesocketChannel1
                cmd.Parameters.Add("@QRCodesocketChannel2", SqlDbType.VarChar, 30).Value = QRCodesocketChannel2
                cmd.Parameters.Add("@QRCodesocketChannel3", SqlDbType.VarChar, 30).Value = QRCodesocketChannel3
                cmd.Parameters.Add("@QRCodesocketChannel4", SqlDbType.VarChar, 30).Value = QRCodesocketChannel4
                cmd.Parameters.Add("@TesterNoA", SqlDbType.VarChar, 30).Value = testerNoA
                cmd.Parameters.Add("@TesterNoAQRcode", SqlDbType.VarChar, 30).Value = testerNoAQRcode
                cmd.Parameters.Add("@TesterNoB", SqlDbType.VarChar, 30).Value = testerNoB
                cmd.Parameters.Add("@TesterNoBQRcode", SqlDbType.VarChar, 30).Value = testerNoBQRcode
                cmd.Parameters.Add("@TesterNoC", SqlDbType.VarChar, 30).Value = testerNoC
                cmd.Parameters.Add("@TesterNoCQRcode", SqlDbType.VarChar, 30).Value = testerNoCQRcode
                cmd.Parameters.Add("@TesterNoD", SqlDbType.VarChar, 30).Value = testerNoD
                cmd.Parameters.Add("@TesterNoDQRcode", SqlDbType.VarChar, 30).Value = testerNoDQRcode
                cmd.Parameters.Add("@ChannelAFTB", SqlDbType.VarChar, 30).Value = channelAFTB
                cmd.Parameters.Add("@ChannelAFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelAFTBQRcode
                cmd.Parameters.Add("@ChannelBFTB", SqlDbType.VarChar, 30).Value = channelBFTB
                cmd.Parameters.Add("@ChannelBFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelBFTBQRcode
                cmd.Parameters.Add("@ChannelCFTB", SqlDbType.VarChar, 30).Value = channelCFTB
                cmd.Parameters.Add("@ChannelCFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelCFTBQRcode
                cmd.Parameters.Add("@ChannelDFTB", SqlDbType.VarChar, 30).Value = channelDFTB
                cmd.Parameters.Add("@ChannelDFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelDFTBQRcode
                cmd.Parameters.Add("@ChannelEFTB", SqlDbType.VarChar, 30).Value = channelEFTB
                cmd.Parameters.Add("@ChannelEFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelEFTBQRcode
                cmd.Parameters.Add("@ChannelFFTB", SqlDbType.VarChar, 30).Value = channelFFTB
                cmd.Parameters.Add("@ChannelFFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelFFTBQRcode
                cmd.Parameters.Add("@ChannelGFTB", SqlDbType.VarChar, 30).Value = channelGFTB
                cmd.Parameters.Add("@ChannelGFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelGFTBQRcode
                cmd.Parameters.Add("@ChannelHFTB", SqlDbType.VarChar, 30).Value = channelHFTB
                cmd.Parameters.Add("@ChannelHFTBQRcode", SqlDbType.VarChar, 30).Value = ChannelHFTBQRcode
                cmd.Parameters.Add("@TestBoxA", SqlDbType.VarChar, 30).Value = testBoxA
                cmd.Parameters.Add("@TestBoxAQRcode", SqlDbType.VarChar, 30).Value = testBoxAQRcode
                cmd.Parameters.Add("@TestBoxB", SqlDbType.VarChar, 30).Value = testBoxB
                cmd.Parameters.Add("@TestBoxBQRcode", SqlDbType.VarChar, 30).Value = testBoxBQRcode
                cmd.Parameters.Add("@TestBoxC", SqlDbType.VarChar, 30).Value = testBoxC
                cmd.Parameters.Add("@TestBoxCQRcode", SqlDbType.VarChar, 30).Value = testBoxCQRcode
                cmd.Parameters.Add("@TestBoxD", SqlDbType.VarChar, 30).Value = testBoxD
                cmd.Parameters.Add("@TestBoxDQRcode", SqlDbType.VarChar, 30).Value = testBoxDQRcode
                cmd.Parameters.Add("@TestBoxE", SqlDbType.VarChar, 30).Value = testBoxE
                cmd.Parameters.Add("@TestBoxEQRcode", SqlDbType.VarChar, 30).Value = testBoxEQRcode
                cmd.Parameters.Add("@TestBoxF", SqlDbType.VarChar, 30).Value = testBoxF
                cmd.Parameters.Add("@TestBoxFQRcode", SqlDbType.VarChar, 30).Value = testBoxFQRcode
                cmd.Parameters.Add("@TestBoxG", SqlDbType.VarChar, 30).Value = testBoxG
                cmd.Parameters.Add("@TestBoxGQRcode", SqlDbType.VarChar, 30).Value = testBoxGQRcode
                cmd.Parameters.Add("@TestBoxH", SqlDbType.VarChar, 30).Value = testBoxH
                cmd.Parameters.Add("@TestBoxHQRcode", SqlDbType.VarChar, 30).Value = testBoxHQRcode
                cmd.Parameters.Add("@AdaptorA", SqlDbType.VarChar, 30).Value = adaptorA
                cmd.Parameters.Add("@AdaptorAQRcode", SqlDbType.VarChar, 30).Value = adaptorAQRcode
                cmd.Parameters.Add("@AdaptorB", SqlDbType.VarChar, 30).Value = adaptorB
                cmd.Parameters.Add("@AdaptorBQRcode", SqlDbType.VarChar, 30).Value = adaptorBQRcode
                cmd.Parameters.Add("@DutcardA", SqlDbType.VarChar, 30).Value = dutcardA
                cmd.Parameters.Add("@DutcardAQRcode", SqlDbType.VarChar, 30).Value = dutcardAQRcode
                cmd.Parameters.Add("@DutcardB", SqlDbType.VarChar, 30).Value = dutcardB
                cmd.Parameters.Add("@DutcardBQRcode", SqlDbType.VarChar, 30).Value = dutcardBQRcode
                cmd.Parameters.Add("@BridgecableA", SqlDbType.VarChar, 30).Value = bridgecableA
                cmd.Parameters.Add("@BridgecableAQRcode", SqlDbType.VarChar, 30).Value = bridgecableAQRcode
                cmd.Parameters.Add("@BridgecableB", SqlDbType.VarChar, 30).Value = bridgecableB
                cmd.Parameters.Add("@BridgecableBQRcode", SqlDbType.VarChar, 30).Value = bridgecableBQRcode
                cmd.Parameters.Add("@TypeChangePackage", SqlDbType.VarChar, 30).Value = typeChangePackage

                If setupStartDate.HasValue Then
                    cmd.Parameters.Add("@SetupStartDate", SqlDbType.DateTime).Value = setupStartDate.Value
                Else
                    cmd.Parameters.Add("@SetupStartDate", SqlDbType.DateTime).Value = DBNull.Value
                End If

                If setupEndDate.HasValue Then
                    cmd.Parameters.Add("@SetupEndDate", SqlDbType.DateTime).Value = setupEndDate.Value
                Else
                    cmd.Parameters.Add("@SetupEndDate", SqlDbType.DateTime).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@BoxTesterConnection", SqlDbType.VarChar, 10).Value = BoxTesterConnection
                cmd.Parameters.Add("@OptionSetup", SqlDbType.VarChar, 10).Value = optionSetup
                cmd.Parameters.Add("@OptionConnection", SqlDbType.VarChar, 10).Value = optionConnection
                cmd.Parameters.Add("@OptionName1", SqlDbType.VarChar, 30).Value = optionName1
                cmd.Parameters.Add("@OptionName2", SqlDbType.VarChar, 30).Value = optionName2
                cmd.Parameters.Add("@OptionName3", SqlDbType.VarChar, 30).Value = optionName3
                cmd.Parameters.Add("@OptionName4", SqlDbType.VarChar, 30).Value = optionName4
                cmd.Parameters.Add("@OptionName5", SqlDbType.VarChar, 30).Value = optionName5
                cmd.Parameters.Add("@OptionName6", SqlDbType.VarChar, 30).Value = optionName6
                cmd.Parameters.Add("@OptionName7", SqlDbType.VarChar, 30).Value = optionName7
                cmd.Parameters.Add("@OptionType1", SqlDbType.VarChar, 30).Value = optionType1
                cmd.Parameters.Add("@OptionType1QRcode", SqlDbType.VarChar, 30).Value = optionType1QRcode
                cmd.Parameters.Add("@OptionType2", SqlDbType.VarChar, 30).Value = optionType2
                cmd.Parameters.Add("@OptionType2QRcode", SqlDbType.VarChar, 30).Value = optionType2QRcode
                cmd.Parameters.Add("@OptionType3", SqlDbType.VarChar, 30).Value = optionType3
                cmd.Parameters.Add("@OptionType3QRcode", SqlDbType.VarChar, 30).Value = optionType3QRcode
                cmd.Parameters.Add("@OptionType4", SqlDbType.VarChar, 30).Value = optionType4
                cmd.Parameters.Add("@OptionType4QRcode", SqlDbType.VarChar, 30).Value = optionType4QRcode
                cmd.Parameters.Add("@OptionType5", SqlDbType.VarChar, 30).Value = optionType5
                cmd.Parameters.Add("@OptionType5QRcode", SqlDbType.VarChar, 30).Value = optionType5QRcode
                cmd.Parameters.Add("@OptionType6", SqlDbType.VarChar, 30).Value = optionType6
                cmd.Parameters.Add("@OptionType6QRcode", SqlDbType.VarChar, 30).Value = optionType6QRcode
                cmd.Parameters.Add("@OptionType7", SqlDbType.VarChar, 30).Value = optionType7
                cmd.Parameters.Add("@OptionType7QRcode", SqlDbType.VarChar, 30).Value = optionType7QRcode
                cmd.Parameters.Add("@OptionSetting1", SqlDbType.VarChar, 30).Value = optionSetting1
                cmd.Parameters.Add("@OptionSetting2", SqlDbType.VarChar, 30).Value = optionSetting2
                cmd.Parameters.Add("@OptionSetting3", SqlDbType.VarChar, 30).Value = optionSetting3
                cmd.Parameters.Add("@OptionSetting4", SqlDbType.VarChar, 30).Value = optionSetting4
                cmd.Parameters.Add("@OptionSetting5", SqlDbType.VarChar, 30).Value = optionSetting5
                cmd.Parameters.Add("@OptionSetting6", SqlDbType.VarChar, 30).Value = optionSetting6
                cmd.Parameters.Add("@OptionSetting7", SqlDbType.VarChar, 30).Value = optionSetting7
                cmd.Parameters.Add("@QfpVacuumPad", SqlDbType.VarChar, 10).Value = qfpVacuumPad
                cmd.Parameters.Add("@QfpSocketSetup", SqlDbType.VarChar, 10).Value = qfpSocketSetup
                cmd.Parameters.Add("@QfpSocketDecision", SqlDbType.VarChar, 10).Value = qfpSocketDecision
                cmd.Parameters.Add("@QfpDecisionLeadPress", SqlDbType.VarChar, 10).Value = qfpDecisionLeadPress
                cmd.Parameters.Add("@QfpTray", SqlDbType.VarChar, 10).Value = qfpTray
                cmd.Parameters.Add("@SopStopper", SqlDbType.VarChar, 10).Value = sopStopper
                cmd.Parameters.Add("@SopSocketDecision", SqlDbType.VarChar, 10).Value = sopSocketDecision
                cmd.Parameters.Add("@SopDecisionLeadPress", SqlDbType.VarChar, 10).Value = sopDecisionLeadPress

                If manualCheckTest.HasValue Then
                    cmd.Parameters.Add("@ManualCheckTest", SqlDbType.Int).Value = manualCheckTest.Value
                Else
                    cmd.Parameters.Add("@ManualCheckTest", SqlDbType.Int).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@ManualCheckTE", SqlDbType.VarChar, 10).Value = manualCheckTE

                If manualCheckRequestTE.HasValue Then
                    cmd.Parameters.Add("@ManualCheckRequestTE", SqlDbType.Int).Value = manualCheckRequestTE.Value
                Else
                    cmd.Parameters.Add("@ManualCheckRequestTE", SqlDbType.Int).Value = DBNull.Value
                End If

                cmd.Parameters.Add("@ManualCheckRequestTEConfirm", SqlDbType.VarChar, 10).Value = ManualCheckRequestTEConfirm
                cmd.Parameters.Add("@PkgGood", SqlDbType.VarChar, 10).Value = pkgGood
                cmd.Parameters.Add("@PkgNG", SqlDbType.VarChar, 10).Value = pkgNG
                cmd.Parameters.Add("@PkgGoodJudgement", SqlDbType.VarChar, 10).Value = PkgGoodJudgement
                cmd.Parameters.Add("@PkgNGJudgement", SqlDbType.VarChar, 10).Value = PkgNGJudgement
                cmd.Parameters.Add("@PkgNishikiCamara", SqlDbType.VarChar, 10).Value = pkgNishikiCamara
                cmd.Parameters.Add("@PkgNishikiCamaraJudgement", SqlDbType.VarChar, 10).Value = PkgNishikiCamaraJudgement
                cmd.Parameters.Add("@PkqBantLead", SqlDbType.VarChar, 10).Value = pkqBantLead
                cmd.Parameters.Add("@PkqKakeHige", SqlDbType.VarChar, 10).Value = pkqKakeHige
                cmd.Parameters.Add("@BgaSmallBall", SqlDbType.VarChar, 10).Value = bgaSmallBall
                cmd.Parameters.Add("@BgaBentTape", SqlDbType.VarChar, 10).Value = bgaBentTape
                cmd.Parameters.Add("@Bge5S", SqlDbType.VarChar, 10).Value = bge5S
                cmd.Parameters.Add("@SetupStatus", SqlDbType.VarChar, 10).Value = setupStatus
                cmd.Parameters.Add("@ConfirmedCheckSheetOp", SqlDbType.VarChar, 15).Value = ConfirmedCheckSheetOp
                cmd.Parameters.Add("@ConfirmedCheckSheetSection", SqlDbType.VarChar, 15).Value = ConfirmedCheckSheetSection
                cmd.Parameters.Add("@ConfirmedCheckSheetGL", SqlDbType.VarChar, 15).Value = ConfirmedCheckSheetGL
                cmd.Parameters.Add("@ConfirmedShonoSection", SqlDbType.VarChar, 15).Value = ConfirmedShonoSection
                cmd.Parameters.Add("@ConfirmedShonoGL", SqlDbType.VarChar, 15).Value = ConfirmedShonoGL
                cmd.Parameters.Add("@ConfirmedShonoOp", SqlDbType.VarChar, 15).Value = ConfirmedShonoOp
                cmd.Parameters.Add("@StatusShonoOP", SqlDbType.VarChar, 5).Value = StatusShonoOP

                If setupConfirmDate.HasValue Then
                    cmd.Parameters.Add("@SetupConfirmDate", SqlDbType.DateTime).Value = setupConfirmDate.Value
                Else
                    cmd.Parameters.Add("@SetupConfirmDate", SqlDbType.DateTime).Value = DBNull.Value
                End If

                row = cmd.ExecuteNonQuery()

                connection.Close()
            End Using
        End Using

        Return row

    End Function
End Class
