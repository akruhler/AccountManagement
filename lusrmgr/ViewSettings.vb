Public Class ViewSettings
    Private mForma As Form1

    Public Overloads Sub Show(mainForm As Form1)
        mForma = mainForm

        QS.SelectedIndex = cfgInt("QuickSearchVisible")

        If mainForm.MenuStrip1.Dock = DockStyle.Top Then
            mTop.Checked = True
        Else
            mBottom.Checked = True
        End If

        showcommandbar.Checked = mainForm.ToolStrip1.Visible
        showstausbar.Checked = mainForm.StatusStrip1.Visible

        ShowDialog()
        Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QS.SelectedIndexChanged
        mForma.QSMenu.Clear()
        mForma.QSearch.Clear()

        Select Case QS.SelectedIndex
            Case 0
                
                mForma.QSBar.Hide()
                mForma.QSMenu.Visible = True
                mForma.QSLabel.Visible = True

                Config.SetVal("QuickSearchVisible", 0, Handle)
            Case 1

                mForma.QSBar.Show()
                mForma.QSMenu.Visible = False
                mForma.QSLabel.Visible = False

                Config.SetVal("QuickSearchVisible", 1, Handle)

            Case 2

                mForma.QSMenu.Visible = False
                mForma.QSLabel.Visible = False
                mForma.QSBar.Hide()

                Config.SetVal("QuickSearchVisible", 2, Handle)
        End Select
    End Sub

    Private Sub mBottom_CheckedChanged(sender As Object, e As EventArgs) Handles mBottom.CheckedChanged, mTop.CheckedChanged
        If mTop.Checked Then
            mForma.MenuStrip1.Dock = DockStyle.Top
            Config.SetVal("MenuBar", 0, Handle)
        Else
            mForma.MenuStrip1.Dock = DockStyle.Bottom
            Config.SetVal("MenuBar", 2, Handle)
        End If
    End Sub

    Private Sub showcommandbar_CheckedChanged(sender As Object, e As EventArgs) Handles showcommandbar.CheckedChanged
        If Not showcommandbar.Checked Then
            mForma.ToolStrip1.Hide()
            Config.SetVal("ShowCommands", 0, Handle)
        Else
            mForma.ToolStrip1.Show()
            Config.SetVal("ShowCommands", 1, Handle)
        End If
    End Sub

    Private Sub showstausbar_CheckedChanged(sender As Object, e As EventArgs) Handles showstausbar.CheckedChanged
        If Not showstausbar.Checked Then
            mForma.StatusStrip1.Hide()
            Config.SetVal("ShowStatusBar", 0, Handle)
        Else
            mForma.StatusStrip1.Show()
            Config.SetVal("ShowStatusBar", 1, Handle)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mTop.Checked = True
        showcommandbar.Checked = True
        showstausbar.Checked = True

        QS.SelectedIndex = 0
    End Sub
End Class