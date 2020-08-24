Module ModuleGlobal

    Public Const SETUP_STATUS_WAITING As String = "WAITING"
    Public Const SETUP_STATUS_GOODNGTEST As String = "GOODNGTEST"
    Public Const SETUP_STATUS_CONFIRMED As String = "CONFIRMED"
    Public Const SETUP_STATUS_CANCELED As String = "CANCELED"

    Public Const SESSION_KEY_DATA As String = "DATA"
    Public Const SESSION_KEY_NEW_DATA_SETUP As String = "NEW_SETUP_DATA"
    Public Const SESSION_KEY_OLD_DATA As String = "OLD_DATA"

    'reference to EQP.EquipmentType on 2016-11-01

    Public Const EQUIPMENT_TYPE_ID_BOX As Integer = 1
    Public Const EQUIPMENT_TYPE_ID_BOARD As Integer = 2
    Public Const EQUIPMENT_TYPE_ID_CARD_SET As Integer = 3
    Public Const EQUIPMENT_TYPE_ID_PROBE As Integer = 4
    Public Const EQUIPMENT_TYPE_ID_ADAPTOR As Integer = 5
    Public Const EQUIPMENT_TYPE_ID_BRIDGE_CABLE As Integer = 6
    Public Const EQUIPMENT_TYPE_ID_TESTER As Integer = 7
    Public Const EQUIPMENT_TYPE_ID_MACHINE As Integer = 8
    Public Const EQUIPMENT_TYPE_ID_OPTION As Integer = 9
    Public Const EQUIPMENT_TYPE_ID_MEASUREMENT As Integer = 10
    Public Const EQUIPMENT_TYPE_ID_TESTCARD As Integer = 11
    Public Const EQUIPMENT_TYPE_ID_KANAGATA As Integer = 12
    Public Const EQUIPMENT_TYPE_ID_DUTCARD As Integer = 13
    Public Const EQUIPMENT_TYPE_ID_OTHER As Integer = 14



    Public Sub MyAlert(ByVal xControl As System.Web.UI.Control, ByVal alertMessage As String)
        Dim scriptString As String

        scriptString = "alert('"
        scriptString &= alertMessage
        scriptString &= "');"

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(xControl, GetType(Page), "Script", scriptString, True)
    End Sub

End Module
