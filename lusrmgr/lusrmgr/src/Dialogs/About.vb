Public Class About

    Public Sub New()
        InitializeComponent()
        CopyContextMenu.Renderer = New clsMenuRenderer()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If e.Button = Windows.Forms.MouseButtons.Right Then Return
        Process.Start("mailto:akruhler@gmail.com")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Clipboard.SetText("akruhler@gmail.com")
    End Sub
End Class