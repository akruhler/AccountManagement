Public Class Times
    Private grid As Dictionary(Of Point, Label)
    Private indeterminateLabels As List(Of Label)
    Private noUser, isRemoteAD As Boolean
    Private userp As DirectoryServices.DirectoryEntry
    Private bArr As BitArray

    Private Const Checked As String = ChrW(27) & "$CH",
                Unchecked As String = ChrW(27) & "$UC"
    Private ReadOnly CheckedColor As Color = Color.FromArgb(0, 120, 215),
                UncheckedColor As Color = Color.FromArgb(255, 255, 255)

    Public Sub New()
        InitializeComponent()

        grid = New Dictionary(Of Point, Label)(168)
        indeterminateLabels = New List(Of Label)(168)
    End Sub

    Function GetTimes(defTimes As Byte()) As Byte()
        noUser = True

        bArr = New BitArray(defTimes)
        DrawGrid(TimeZoneInfo.Local.BaseUtcOffset.Hours)

        ShowDialog()
        Return GetByteArray()
    End Function

    Function EditTimes(user As DirectoryServices.DirectoryEntry, pIsRemoteAD As Boolean) As DialogResult
        userp = user
        isRemoteAD = pIsRemoteAD

        bArr = New BitArray(CType(user.IADsU().LoginHours, Byte()))
        DrawGrid(TimeZoneInfo.Local.BaseUtcOffset.Hours)

        Return ShowDialog()
    End Function

#Region "Selection event handlers"

    Private origin As Point, blockFields, useRectSelect As Boolean

    Private Sub TimeSelector_MouseDown(sender As Object, e As MouseEventArgs)
        If Not e.Button = Windows.Forms.MouseButtons.Left Then Return

        Dim c As Label = DirectCast(sender, Label)
        c.Capture = False
        origin = c.Tag
        indeterminateLabels.Clear()

        If c.Name = Unchecked Then
            c.Name = Checked
            c.BackColor = CheckedColor
            indeterminateLabels.Add(c)
            blockFields = True
        Else
            c.Name = Unchecked
            c.BackColor = UncheckedColor
            blockFields = False
        End If

        If (ModifierKeys And Keys.Alt) = Keys.Alt Then
            useRectSelect = False
        Else
            useRectSelect = True
        End If
    End Sub

    Private Sub TimeSelector_MouseEnter(sender As Object, e As EventArgs)
        If Not MouseButtons.HasFlag(MouseButtons.Left) Then
            Return
        End If

        Dim c As Label = DirectCast(sender, Label)

        If useRectSelect Then
            Dim gridPos As Point = c.Tag

            'Clear indeterminate labels
            indeterminateLabels.ForEach(Sub(l As Label)
                                            If blockFields Then
                                                l.Name = Unchecked
                                                l.BackColor = UncheckedColor
                                            End If
                                        End Sub)
            indeterminateLabels.Clear()

            If blockFields Then
                ForEachInGrid(origin, gridPos, Sub(label As Label)
                                                   label.Name = Checked
                                                   label.BackColor = CheckedColor
                                                   indeterminateLabels.Add(label)
                                               End Sub)
            Else
                ForEachInGrid(origin, gridPos, Sub(label As Label)
                                                   label.Name = Unchecked
                                                   label.BackColor = UncheckedColor
                                               End Sub)
            End If
        Else
            If blockFields Then
                c.Name = Checked
                c.BackColor = CheckedColor
                indeterminateLabels.Add(c)
            Else
                c.Name = Unchecked
                c.BackColor = UncheckedColor
            End If
        End If
    End Sub
#End Region

#Region "Helper functions"

    Private Sub ForEachInGrid(pStart As Point, pEnd As Point, pFunction As Action(Of Label))
        Dim xfrom, xto,
            yfrom, yto As Integer

        If pStart.X < pEnd.X Then
            xfrom = pStart.X
            xto = pEnd.X
        Else
            xfrom = pEnd.X
            xto = pStart.X
        End If

        If pStart.Y < pEnd.Y Then
            yfrom = pStart.Y
            yto = pEnd.Y
        Else
            yfrom = pEnd.Y
            yto = pStart.Y
        End If

        For x As Integer = xfrom To xto
            For y As Integer = yfrom To yto
                pFunction(grid(New Point(x, y)))
            Next
        Next
    End Sub

    Private Function GetByteArray() As Byte()
        Dim newArray As Byte() = New Byte(20) {}
        bArr.CopyTo(newArray, 0)
        Return newArray
    End Function

    Private Function HandleOffsetOverlapping(n As Integer, offset As Integer)
        n -= offset
        If (n < 0) Then
            n += 168
        ElseIf (n >= 167) Then
            n -= 167
        End If

        Return n
    End Function
#End Region

    Private Sub DrawGrid(offset As Integer)
        Dim dTop As Integer = 35
        Dim dLeft As Integer = 80
        Dim count As Integer = 0

        'Iterate through all week days
        For i As Integer = 0 To 6

            Dim weekL As New Label()
            weekL.TextAlign = ContentAlignment.MiddleRight
            weekL.AutoSize = False
            weekL.Size = New Size(dLeft, 25)
            weekL.Top = 25 * (i + 1) + 10
            weekL.Text = WeekdayName(i + 1, False, FirstDayOfWeek.Sunday) & " "
            weekL.Font = New Font("Segoe UI", 9)

            Controls.Add(weekL)

            'Iterate through all hours
            For j As Integer = 0 To 23

                If (i = 0) Then
                    Dim hourL As New Label()
                    hourL.TextAlign = ContentAlignment.BottomCenter
                    hourL.AutoSize = False
                    hourL.Size = New Size(20, 25)
                    hourL.Top = dTop - 27
                    hourL.Left = (dLeft - 10)
                    hourL.Text = j
                    hourL.Font = New Font("Segoe UI", 9)

                    If j = 23 Then
                        hourL.Width = 45
                        hourL.Text &= "    24"
                    End If

                    Controls.Add(hourL)
                End If

                Dim timeSelector As New Label()
                timeSelector.AutoSize = False
                timeSelector.BorderStyle = BorderStyle.FixedSingle
                timeSelector.Size = New Size(25, 25)
                timeSelector.Top = dTop
                timeSelector.Left = dLeft

                If bArr(HandleOffsetOverlapping(count, offset)) Then
                    timeSelector.BackColor = SystemColors.Window
                    timeSelector.Name = Unchecked
                Else
                    timeSelector.BackColor = SystemColors.Highlight
                    timeSelector.Name = Checked
                End If

                AddHandler timeSelector.MouseDown, AddressOf TimeSelector_MouseDown
                AddHandler timeSelector.MouseEnter, AddressOf TimeSelector_MouseEnter

                timeSelector.Tag = New Point(j, i)

                Controls.Add(timeSelector)
                grid.Add(New Point(j, i), timeSelector)

                dLeft += 25
                count += 1
            Next
            dTop += 25
            dLeft = 80
        Next
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Dim count As Integer = 0
        Dim offset As Int32 = TimeZoneInfo.Local.BaseUtcOffset.Hours

        For Each c As Control In Controls
            If c.Name = Unchecked Then
                bArr(HandleOffsetOverlapping(count, offset)) = True
                count += 1
            ElseIf c.Name = Checked Then
                bArr(HandleOffsetOverlapping(count, offset)) = False
                count += 1
            End If
        Next

        If Not noUser Then
            Dim Iusr As ActiveDs.IADsUser = userp.IADsU()
            Dim backup As Object = Iusr.LoginHours

            Iusr.LoginHours = GetByteArray()

            Try
                userp.CommitChanges()
            Catch ex As UnauthorizedAccessException
                DialogResult = Windows.Forms.DialogResult.None
                ShowPermissionDeniedErr(Handle, isRemoteAD)
                Iusr.LoginHours = backup
                Return
            Catch ex As Runtime.InteropServices.COMException
                Iusr.LoginHours = backup

                Select Case ShowCOMErr(ex.ErrorCode, Handle, ex.Message, userp.Name)
                    Case COMErrResult.REFRESH
                        DialogResult = Windows.Forms.DialogResult.Retry
                    Case Else
                        DialogResult = Windows.Forms.DialogResult.Cancel
                End Select
                Return
            Catch ex As Exception
                Iusr.LoginHours = backup
                ShowUnknownErr(Handle, ex.Message)
                Return
            End Try
        End If

        If cfgBool("HideWarningTime") = True Then Return

        Dim tdc As New TASKDIALOGCONFIG()
        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)
        tdc.hwndParent = Handle

        tdc.cxWidth = 220

        tdc.pszWindowTitle = "Access times warning"
        tdc.pszMainInstruction = "Access time restrictions may not be enforced correctly"
        tdc.pszContent = "The defined access times will prevent the user from logging on," & vbCrLf & "but they may not log off the user as they exceed the limit." & vbCrLf & "You may have to install additional software in order to achieve that."

        tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON
        tdc.pszVerificationText = "Do not show this warning again"
        tdc.pszMainIcon = TD_WARNING_ICON

        Dim verif As Boolean

        TaskDialogIndirect(tdc, 0, 0, verif)

        If verif Then
            Config.SetVal("HideWarningTime", 1, Handle)
        End If
    End Sub
End Class