Imports System.Security.Permissions
Public Class Connecting
    Private stage As Int32 = 0
    Private ow As MainForm
    Private isCloseCalled As Boolean
    Public isCancelled As Boolean

    Public Shadows Sub Close()
        isCloseCalled = True
        MyBase.Close()
    End Sub

    Public Shadows Sub Hide()
        If Focused Then ow.TopMost = True
        MyBase.Hide()
        ow.TopMost = False
    End Sub

    Public Sub SetText(text As String)
        Label4.Text = text

        For i As Int32 = 0 To stage - 1
            Label4.Text &= " ."
        Next
    End Sub

    Public Sub New(owner As MainForm)
        InitializeComponent()
        startLoop()
        Show(owner)
        owner.SetNativeEnabled(False)
        ow = owner
    End Sub

    Private Async Sub startLoop()
        While Not isCloseCalled
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
        If Not isCloseCalled Then
            e.Cancel = True

            If ControlBox Then
                SetText("Aborting")
                isCancelled = True
            End If
        Else
            ow.SetNativeEnabled(True)
            Dispose()
        End If
    End Sub
End Class