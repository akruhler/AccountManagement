Imports Microsoft.Win32
Imports System.Runtime.CompilerServices
Module Config
    Private configKey As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\lusrmgr")

    Enum UACBehaviour
        PromptUAC = 501
        LaunchWithoutPrivileges = 502
        AskEveryTime = 503
    End Enum

    Sub closeConfigKey()
        If configKey Is Nothing Then Return
        configKey.Close()
        configKey.Dispose()
    End Sub

    Sub initStaticFields()
        AddUser.showAdvanced = GetVal("ShowAdvanced", False)
    End Sub

    Function SetVal(setting As String, val As Object, errWindow As IntPtr) As Boolean
        Try
            configKey.SetValue(setting, val)
        Catch ex As UnauthorizedAccessException
            TaskDialog(errWindow, "Configuration error", "Access to registry denied", "The configuration values could not be modified, the access was denied." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, Nothing)
            Return False
        Catch ex As Exception
            TaskDialog(errWindow, "An unkown error occurred", "A value could not be written to the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return False
        End Try
        Return True
    End Function

    Function GetVal(Of T)(setting As String, def As T) As T
        Try
            Return configKey.GetValue(setting, def)
        Catch ex As Exception
            TaskDialog(IntPtr.Zero, "An unkown error occurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return Nothing
        End Try
    End Function

    <Extension>
    Function cfgBool(parentWnd As Form, setting As String, Optional def As Boolean = False) As Boolean
        Try
            Return configKey.GetValue(setting, def)
        Catch ex As Exception
            TaskDialog(parentWnd.Handle, "An unkown error occurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return False
        End Try
    End Function

    <Extension>
    Function cfgInt(parentWnd As Form, setting As String, Optional def As Int32 = 0) As Int32
        Try
            Return configKey.GetValue(setting, def)
        Catch ex As Exception
            TaskDialog(parentWnd.Handle, "An unkown error occurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return 0
        End Try
    End Function

    Function cfgIntMain(setting As String, Optional def As Int32 = 0) As Int32
        Try
            Return configKey.GetValue(setting, def)
        Catch ex As Exception
            TaskDialog(IntPtr.Zero, "An unkown error occurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return 0
        End Try
    End Function
End Module