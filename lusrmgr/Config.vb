Imports Microsoft.Win32
Imports System.Runtime.CompilerServices
Module Config
    Function SetVal(setting As String, val As Object, errWindow As IntPtr) As Boolean
        Try
            Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\lusrmgr", setting, val)
        Catch ex As UnauthorizedAccessException
            TASKDIALOG.TaskDialog(errWindow, nullptr, "Configuration error", "Access to registry denied", "The configuration values could not be modified, the access was denied." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, Nothing)
            Return False
        Catch ex As Exception
            TASKDIALOG.TaskDialog(errWindow, nullptr, "An unkown error ocurred", "A value could not be written to the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return False
        End Try
        Return True
    End Function

    <Extension>
    Function cfgBool(parentWnd As Form, setting As String, Optional def As Boolean = False) As Boolean
        Try
            Return Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\lusrmgr", setting, def)
        Catch ex As Exception
            TASKDIALOG.TaskDialog(parentWnd.Handle, nullptr, "An unkown error ocurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return False
        End Try
    End Function

    <Extension>
    Function cfgInt(parentWnd As Form, setting As String, Optional def As Int32 = 0) As Int32
        Try
            Return Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\lusrmgr", setting, def)
        Catch ex As Exception
            TASKDIALOG.TaskDialog(parentWnd.Handle, nullptr, "An unkown error ocurred", "A value could not be read from the registry", ex.Message & vbCrLf & "Please report this issue to the developer.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
            Return 0
        End Try
    End Function
End Module