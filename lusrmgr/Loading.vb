Imports System.Security.Permissions
Public Class Loading
    Dim stage As Int32 = 0
    Dim ow As Form1
    Public isClosing, isBackground As Boolean

    Public Shadows Sub Close()
        isClosing = True
        MyBase.Close()
    End Sub

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

            If Not Visible Then
                Return
            End If
        End While
    End Sub

    Private Sub Connecting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not isClosing Then
            e.Cancel = True
            isBackground = True
        Else
            ow.Enabled = True
            Dispose()
        End If
    End Sub

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        BringToFront()
    End Sub
End Class