Public Class ViewSettings
    Private mainF As MainForm

    Shadows Sub Show(mainForm As MainForm)
        mainF = mainForm

        QS.SelectedIndex = cfgInt("QuickSearchVisible")

        If mainForm.MenuStrip1.Dock = DockStyle.Top Then
            mTop.Checked = True
        Else
            mBottom.Checked = True
        End If

        showcommandbar.Checked = mainForm.MainToolStrip.Visible
        showstausbar.Checked = mainForm.BottomStatusStrip.Visible

        ShowDialog()
        Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QS.SelectedIndexChanged
        mainF.QSMenu.Clear()
        mainF.QSearch.Clear()

        Select Case QS.SelectedIndex
            Case 0
                mainF.QSBar.Hide()
                mainF.QSMenu.Visible = True
                mainF.QSLabel.Visible = True

                Config.SetVal("QuickSearchVisible", 0, Handle)
            Case 1
                mainF.QSBar.Show()
                mainF.QSMenu.Visible = False
                mainF.QSLabel.Visible = False

                Config.SetVal("QuickSearchVisible", 1, Handle)

            Case 2
                mainF.QSMenu.Visible = False
                mainF.QSLabel.Visible = False
                mainF.QSBar.Hide()

                Config.SetVal("QuickSearchVisible", 2, Handle)
        End Select
    End Sub

    Private Sub mBottom_CheckedChanged(sender As Object, e As EventArgs) Handles mBottom.CheckedChanged, mTop.CheckedChanged
        If mTop.Checked Then
            mainF.MenuStrip1.Dock = DockStyle.Top
            Config.SetVal("MenuBar", 0, Handle)
        Else
            mainF.MenuStrip1.Dock = DockStyle.Bottom
            Config.SetVal("MenuBar", 2, Handle)
        End If
    End Sub

    Private Sub showcommandbar_CheckedChanged(sender As Object, e As EventArgs) Handles showcommandbar.CheckedChanged
        If Not showcommandbar.Checked Then
            mainF.MainToolStrip.Hide()
            Config.SetVal("ShowCommands", 0, Handle)
        Else
            mainF.MainToolStrip.Show()
            Config.SetVal("ShowCommands", 1, Handle)
        End If
    End Sub

    Private Sub showstausbar_CheckedChanged(sender As Object, e As EventArgs) Handles showstausbar.CheckedChanged
        If Not showstausbar.Checked Then
            mainF.BottomStatusStrip.Hide()
            Config.SetVal("ShowStatusBar", 0, Handle)
        Else
            mainF.BottomStatusStrip.Show()
            Config.SetVal("ShowStatusBar", 1, Handle)
        End If
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        mTop.Checked = True
        showcommandbar.Checked = False
        showstausbar.Checked = True

        QS.SelectedIndex = 0
    End Sub
End Class