Module ControlsExInterop
    Declare Auto Function SetWindowTheme Lib "uxtheme.dll" (hWnd As IntPtr, pszSubAppName As String, pszSubIdList As String) As Integer
    Private Declare Function EnableWindow Lib "user32.dll" (hWnd As IntPtr, enabled As Integer) As Integer

    <System.Runtime.CompilerServices.Extension>
    Sub SetNativeEnabled(window As Form, enabled As Boolean)
        EnableWindow(window.Handle, enabled)
    End Sub
End Module

Public Class TransparentPanel
    Inherits Panel

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params As CreateParams = MyBase.CreateParams
            params.ExStyle = params.ExStyle Or &H20 'WS_EX_TRANSPARENT
            Return params
        End Get
    End Property
End Class

Public Class TreeView
    Inherits System.Windows.Forms.TreeView

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        If Not DesignMode AndAlso Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6 Then
            SetWindowTheme(Me.Handle, "explorer", Nothing)
        End If
    End Sub

    Public Shadows Property SelectedNode As TreeNode
        Get
            If MyBase.Nodes.Count > 0 AndAlso MyBase.SelectedNode Is Nothing Then
                MyBase.SelectedNode = MyBase.Nodes(0)
                If MyBase.SelectedNode Is Nothing Then
                    Return MyBase.Nodes(0)
                End If
            End If
            Return MyBase.SelectedNode
        End Get
        Set(value As TreeNode)
            MyBase.SelectedNode = value
        End Set
    End Property
End Class

Public Class ListView
    Inherits System.Windows.Forms.ListView

    <System.ComponentModel.DesignOnly(True), System.ComponentModel.DefaultValue(True)>
    Public Property UseVisualStyles As Boolean = True
    <System.ComponentModel.DefaultValue(True)>
    Public Property HideHorziontalScrollbar As Boolean = True

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        If Not DesignMode AndAlso Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6 AndAlso UseVisualStyles Then
            SetWindowTheme(Me.Handle, "explorer", Nothing)
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Not DesignMode AndAlso HideHorziontalScrollbar Then
            ShowScrollBar(Me.Handle, SB_HORZ, 0)
        End If
    End Sub

    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        MyBase.OnLayout(levent)
        If Not DesignMode AndAlso HideHorziontalScrollbar Then
            ShowScrollBar(Me.Handle, SB_HORZ, 0)
        End If
    End Sub

    Private Declare Function ShowScrollBar Lib "user32" (hWnd As IntPtr, wBar As Integer, bShow As Integer) As Integer
    Private Const SB_HORZ = 0
    Private Const SB_VERT = 1
    Private Const SB_BOTH = 3
End Class
