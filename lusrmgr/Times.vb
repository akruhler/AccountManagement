Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class Times
    Dim week As Dictionary(Of Integer, String)
    Dim blocked, noUser As Boolean
    Dim userp As DirectoryServices.DirectoryEntry
    Public uArr As Byte()

    Public Sub New()
        InitializeComponent()

        week = New Dictionary(Of Integer, String)()
        week.Add(0, "Sunday")
        week.Add(1, "Monday")
        week.Add(2, "Tuesday")
        week.Add(3, "Wednesday")
        week.Add(4, "Thursday")
        week.Add(5, "Friday")
        week.Add(6, "Saturday")
    End Sub

    Private Sub l_down(sender As Object, e As MouseEventArgs)
        If Not e.Button = Windows.Forms.MouseButtons.Left Then Return

        Dim c As Label = sender
        c.BorderStyle = BorderStyle.Fixed3D

        If c.Name.ToCharArray()(0) = "f"c Then
            c.Name = "t" + c.Name.Substring(1)
            c.BackColor = SystemColors.Highlight
            blocked = True
        Else
            c.Name = "f" + c.Name.Substring(1)
            c.BackColor = SystemColors.Window
            blocked = False
        End If
    End Sub

    Private Sub l_up(sender As Object, e As MouseEventArgs)
        Dim c As Label = sender
        c.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub l_out(sender As Object, e As EventArgs)
        Dim c As Label = sender
        c.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub l_in(sender As Object, e As EventArgs)
        If Not MouseButtons.HasFlag(MouseButtons.Left) Then
            Return
        End If

        Dim c As Label = sender

        If blocked Then
            c.Name = "t" + c.Name.Substring(1)
            c.BackColor = SystemColors.Highlight
        Else
            c.Name = "f" + c.Name.Substring(1)
            c.BackColor = SystemColors.Window
        End If
    End Sub

    Overloads Sub Show(ByRef uArr_ As Byte())
        uArr = uArr_
        noUser = True

        Dim bArr As Boolean() = PermittedLogonTimes.GetBoolArr(uArr_)
        draw(bArr, TimeZoneInfo.Local.BaseUtcOffset.Hours)

        ShowDialog()
    End Sub

    Overloads Function Show(user As DirectoryServices.DirectoryEntry) As DialogResult
        userp = user

        Dim bArr As Boolean() = PermittedLogonTimes.GetBoolArr(user.IADsU().LoginHours)
        draw(bArr, TimeZoneInfo.Local.BaseUtcOffset.Hours)

        Return ShowDialog()
    End Function

    Private Sub draw(bArr As Boolean(), offset As Integer)
        Dim t As Integer = 35
        Dim l As Integer = 80
        Dim count As Integer = 0

        For i As Integer = 0 To 6

            Dim w As New Label()
            w.TextAlign = ContentAlignment.MiddleRight
            w.AutoSize = False
            w.Size = New Size(l, 25)
            w.Top = 25 * (i + 1) + 10
            w.Text = week(i) & " "
            w.Font = New Font("Segoe UI", 9)

            Controls.Add(w)

            For j As Integer = 0 To 23

                If (i = 0) Then
                    Dim h As New Label()
                    h.TextAlign = ContentAlignment.BottomCenter
                    h.AutoSize = False
                    h.Size = New Size(20, 25)
                    h.Top = t - 27
                    h.Left = (l - 10)
                    h.Text = j
                    h.Font = New Font("Segoe UI", 9)

                    If j = 23 Then
                        h.Width = 45
                        h.Text &= "    24"
                    End If

                    Controls.Add(h)
                End If

                Dim tl As New Label()
                tl.AutoSize = False
                tl.BorderStyle = BorderStyle.FixedSingle
                tl.Size = New Size(25, 25)
                tl.Top = t
                tl.Left = l

                If bArr(acsbArr(count, offset)) Then
                    tl.BackColor = SystemColors.Window
                    tl.Name = "f" & i & j & "S123"
                Else
                    tl.BackColor = SystemColors.Highlight
                    tl.Name = "t" & i & j & "S123"
                End If

                AddHandler tl.MouseDown, AddressOf l_down
                AddHandler tl.MouseUp, AddressOf l_up
                AddHandler tl.MouseEnter, AddressOf l_in
                AddHandler tl.MouseLeave, AddressOf l_out

                Controls.Add(tl)

                l += 25

                count += 1
            Next
            t += 25
            l = 80
        Next
    End Sub

    Private Function acsbArr(n As Integer, off As Integer)
        n -= off
        If (n < 0) Then
            n += 168
        ElseIf (n >= 167) Then
            n -= 167
        End If

        Return n
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim bArr(167) As Boolean

        Dim count As Integer = 0
        Dim offset As Int32 = TimeZoneInfo.Local.BaseUtcOffset.Hours

        For Each c As Control In Controls
            If (c.Name.EndsWith("S123")) Then
                If (c.Name.StartsWith("f")) Then
                    bArr(acsbArr(count, offset)) = True
                Else
                    bArr(acsbArr(count, offset)) = False
                End If

                count += 1
            End If
        Next

        If noUser Then
            uArr = PermittedLogonTimes.ConvertToAD(bArr)
        Else
            Dim Iusr As ActiveDs.IADsUser = userp.IADsU()
            Dim old As Object = Iusr.LoginHours

            Iusr.LoginHours = PermittedLogonTimes.ConvertToAD(bArr)

            Try
                userp.CommitChanges()
            Catch ex As UnauthorizedAccessException
                DialogResult = Windows.Forms.DialogResult.None
                TASKDIALOG.TaskDialog(Handle, nullptr, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Iusr.LoginHours = old
                Return
            Catch ex As Runtime.InteropServices.COMException
                Iusr.LoginHours = old

                Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, userp.Name)
                    Case COMErrResult.REFRESH
                        DialogResult = Windows.Forms.DialogResult.Retry
                    Case Else
                        DialogResult = Windows.Forms.DialogResult.Cancel
                End Select
                Return
            Catch ex As Exception
                Iusr.LoginHours = old
                ShowUnknownErr(Handle, ex.Message)
                Return
            End Try
        End If

        If cfgBool("HideWarningTime") = True Then Return

        Dim tdc As New TASKDIALOGCONFIG()
        tdc.cbSize = sizeof(tdc)
        tdc.hwndParent = Handle

        tdc.cxWidth = 220

        tdc.pszWindowTitle = "Warning - Local users and groups"
        tdc.pszMainInstruction = "Access time restrictions may not be enforced correctly"
        tdc.pszContent = "The defined access times will prevent the user from logging on," & vbCrLf & "but they may not log off the user as they exceed the limit." & vbCrLf & "You may have to install additional software in order to achieve that."

        tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
        tdc.pszVerificationText = "Do not show this warning again"
        tdc.pszMainIcon = TD_WARNING

        Dim verif As Boolean

        TaskDialogIndirect(tdc, 0, 0, verif)

        If verif Then
            Config.SetVal("HideWarningTime", 1, Handle)
        End If
    End Sub
End Class