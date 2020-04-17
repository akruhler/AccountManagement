Public Class ChangePw
    Dim userp As DirectoryServices.DirectoryEntry
    Dim mForm As Form1

    Overloads Function Show(user As DirectoryServices.DirectoryEntry, mForma As Form1) As DialogResult
        Label1.Text = "Change password for " & user.Name
        userp = user
        mForm = mForma
        TextBox1.Select()
        Return ShowDialog()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = TextBox2.Text Then
            Try
                userp.IADsU().SetPassword(TextBox1.Text)
                userp.CommitChanges()

                EditUser.lastpwchanged.Text = Now
            Catch ex As Runtime.InteropServices.COMException
                DialogResult = Windows.Forms.DialogResult.None

                Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, userp.Name)
                    Case COMErrResult.REFRESH
                        DialogResult = Windows.Forms.DialogResult.Cancel
                        mForm.currentAD().RefreshDS()
                        mForm.refreshItemCount()
                End Select
                Return
            Catch ex As UnauthorizedAccessException
                DialogResult = Windows.Forms.DialogResult.None
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return
            End Try

            Dim l As Integer = TextBox1.TextLength

            TextBox1.Clear()
            TextBox1.ClearUndo()
            TextBox2.Clear()
            TextBox2.ClearUndo()

            For i As Integer = 1 To l
                TextBox1.Text &= " "c
                TextBox2.Text &= " "c
            Next

            TASKDIALOG.TaskDialog(Handle, nullptr, "Account password", "Password changed", "The password for " & userp.Name & " has been successfully changed.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_INFORMATION_ICON, 0)
        Else
            DialogResult = Windows.Forms.DialogResult.None
            ToolTip2.Show("The passwords do not match each other.", TextBox1, 3333)
        End If
    End Sub
End Class