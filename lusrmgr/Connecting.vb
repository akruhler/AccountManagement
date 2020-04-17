Imports System.Security.Permissions
Public Class Connecting
    Dim stage As Int32 = 0
    'Delegate Sub dCloseWindow()
    'Public closeWindow As New dCloseWindow(AddressOf Close)
    Dim ow As Form1
    Public Cancel, isClosing As Boolean

    Public Shadows Sub Close()
        isClosing = True
        MyBase.Close()
    End Sub

    Public Sub SetText(text As String, Optional addr As Boolean = False)
        If addr Then
            Label4.Text = "Establishing connection with " & text
        Else
            Label4.Text = text
        End If

        For i As Int32 = 0 To stage - 1
            Label4.Text &= " ."
        Next
    End Sub

    'Private Const WM_SYSCOMMAND As Integer = &H112
    'Private Const SC_MINIMIZE As Integer = &HF020

    '<SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    If m.Msg = WM_SYSCOMMAND Then
    '        Dim command As Integer = m.WParam.ToInt32() And &HFFF0
    '        If command = SC_MINIMIZE Then
    '            isBackground = True
    '            Return
    '        End If
    '    End If
    '    MyBase.WndProc(m)
    'End Sub

    Public Sub New(owner As Form1)
        InitializeComponent()
        startLoop()
        Show(owner)
        owner.Enabled = False
        ow = owner
    End Sub

    Private Async Sub startLoop()
        While Not isClosing
            Select Case stage
                Case Is < 3
                    stage += 1
                    Label4.Text &= " ."
                Case 3
                    stage = 0
                    Label4.Text = Label4.Text.Remove(Label4.Text.Length - 6)
            End Select
            Await Task.Delay(600)
        End While
    End Sub

    Private Sub Connecting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isClosing Then
            e.Cancel = True

            SetText("Aborting")
            Cancel = True
        Else
            ow.Enabled = True
            Dispose()
        End If
    End Sub
End Class