Module WinApi
    Public Declare Auto Function SetWindowTheme Lib "uxtheme.dll" (hWnd As IntPtr, pszSubAppName As String, pszSubIdList As String) As Integer
End Module

Public Class TreeView
    Inherits System.Windows.Forms.TreeView

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        If Not DesignMode AndAlso Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6 Then
            SetWindowTheme(Me.Handle, "explorer", Nothing)
        End If
    End Sub
End Class

Public Class ListView
    Inherits System.Windows.Forms.ListView

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        If Not DesignMode AndAlso Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6 Then
            SetWindowTheme(Me.Handle, "explorer", Nothing)
        End If
    End Sub
End Class
