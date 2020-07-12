Public Class SetPw
    Dim userp As DirectoryServices.DirectoryEntry
    Dim AD As ActiveDirectory

    Shadows Function Show(user As DirectoryServices.DirectoryEntry, pAD As ActiveDirectory) As DialogResult
        Label1.Text = "Set password for " & user.Name
        userp = user
        AD = pAD
        Pw.Select()
        Return ShowDialog()
    End Function

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If Pw.Text = PwConfirm.Text Then
            Try
                userp.IADsU().SetPassword(Pw.Text)
                userp.CommitChanges()

                EditUser.PwLastChanged.Text = Now
            Catch ex As Runtime.InteropServices.COMException
                DialogResult = Windows.Forms.DialogResult.None

                If ShowCOMErr(ex.ErrorCode, Handle, ex.Message, userp.Name) = COMErrResult.REFRESH Then
                    DialogResult = Windows.Forms.DialogResult.Cancel
                    AD.RefreshDS()
                End If
                Return
            Catch ex As UnauthorizedAccessException
                DialogResult = Windows.Forms.DialogResult.None
                ShowPermissionDeniedErr(Handle)
                Return
            End Try

            TaskDialog(Handle, "Account password", "Password set", "The password for " & userp.Name & " has been successfully changed.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_INFORMATION_ICON, 0)
        Else
            DialogResult = Windows.Forms.DialogResult.None
            PwDoesentMatchTooltip.Show("The passwords do not match.", Pw, 3333)
        End If
    End Sub
End Class