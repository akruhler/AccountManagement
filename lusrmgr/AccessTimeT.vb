Public Class PermittedLogonTimes
    Public Shared Function GetByteMask(ByVal logonTimes As List(Of LogonTime)) As Byte()
        Dim hours = InitializeTimeArray()

        For Each time In logonTimes
            Dim dayOffset = CInt(time.DayOfWeek) * 24
            MarkHours(hours, time)
        Next

        Return ConvertToAD(hours)
    End Function

    Public Shared Function GetLogonTimes(ByVal byteMask As Byte()) As List(Of LogonTime)
        Return GetLogonTimes(byteMask, TimeZoneInfo.Local)
    End Function

    Public Shared Function GetLogonTimes(ByVal byteMask As Byte(), ByVal timeZone As TimeZoneInfo) As List(Of LogonTime)
        Dim hours = MarkHours(byteMask)
        Return ConvertToLogonTime(hours, (timeZone.BaseUtcOffset.Hours))
    End Function

    Public Shared Function GetBoolArr(bytes As Byte()) As Boolean()
        Return MarkHours(bytes)
    End Function

    Private Shared Function InitializeTimeArray() As Boolean()
        Dim array = New Boolean(167) {}

        For i = 0 To array.Count() - 1
            array(i) = False
        Next

        Return array
    End Function

    Private Shared Sub MarkHours(ByVal hours As Boolean(), ByVal logonTime As LogonTime)
        Dim snr As Int32 = logonTime.EndTime.Hour

        If (snr = 0) Then
            snr = 24
        End If

        Dim offset = logonTime.TimeZoneOffSet
        Dim dayOffset = CInt(logonTime.DayOfWeek) * 24

        For i As Integer = 0 To 24 - 1

            If logonTime.BeginTime.Hour <= i AndAlso i < snr Then
                Dim index = dayOffset + i + offset

                If index < 0 Then
                    index = hours.Count() + index
                ElseIf index > hours.Count() Then
                    index = index - hours.Count()
                End If

                hours(index) = True
            End If
        Next
    End Sub

    Public Shared Function ConvertToAD(ByVal hours As Boolean()) As Byte()
        Dim permittedHours = New Byte(20) {}
        Dim index = 0
        Dim index2 = 0

        While index < hours.Length
            Dim result = ConvertBlockToAD(hours.Skip(index).Take(24).ToArray())
            permittedHours(index2) = result(0)
            permittedHours(index2 + 1) = result(1)
            permittedHours(index2 + 2) = result(2)
            index += 24
            index2 += 3
        End While

        Return permittedHours
    End Function

    Private Shared Function ConvertBlockToAD(ByVal hours As Boolean()) As Byte()
        Dim [set] = New Integer(2) {}

        For i = 0 To 24 - 1

            If hours(i) Then
                Dim index = CInt(Math.Floor(CDec((i)) / 8))
                [set](index) += CalculateLocationValue(i)
            End If
        Next

        Return New Byte(2) {Convert.ToByte([set](0)), Convert.ToByte([set](1)), Convert.ToByte([set](2))}
    End Function

    Private Shared Function CalculateLocationValue(ByVal location As Integer) As Integer
        location = location Mod 8

        Select Case location
            Case 0
                Return 1
            Case 1
                Return 2
            Case 2
                Return 4
            Case 3
                Return 8
            Case 4
                Return 16
            Case 5
                Return 32
            Case 6
                Return 64
            Case 7
                Return 128
        End Select

        Return 0
    End Function

    Private Shared Function MarkHours(ByVal byteMask As Byte()) As Boolean()
        Dim hours = InitializeTimeArray()

        For i = 0 To byteMask.Length - 1
            ParseBlock(byteMask(i), hours, i * 8)
        Next

        Return hours
    End Function

    Private Shared Sub ParseBlock(ByVal block As Byte, ByVal hours As Boolean(), ByVal index As Integer)
        Dim value = CInt(block)

        If value >= 128 Then
            hours(index + 7) = True
            value -= 128
        End If

        If value >= 64 Then
            hours(index + 6) = True
            value -= 64
        End If

        If value >= 32 Then
            hours(index + 5) = True
            value -= 32
        End If

        If value >= 16 Then
            hours(index + 4) = True
            value -= 16
        End If

        If value >= 8 Then
            hours(index + 3) = True
            value -= 8
        End If

        If value >= 4 Then
            hours(index + 2) = True
            value -= 4
        End If

        If value >= 2 Then
            hours(index + 1) = True
            value -= 2
        End If

        If value >= 1 Then
            hours(index) = True
            value -= 1
        End If
    End Sub

    Private Shared Function ConvertToLogonTime(ByVal hours As Boolean(), ByVal offset As Integer) As List(Of LogonTime)
        Dim ltimes = New List(Of LogonTime)()
        Dim begin As Integer? = Nothing, [end] As Integer? = Nothing

        For i = 0 To hours.Length - 1
            Dim index = i + (-1) * offset

            If index < 0 Then
                index = hours.Length + index
            ElseIf index >= hours.Length Then
                index = index - hours.Length
            End If

            If Not begin.HasValue AndAlso hours(index) Then
                begin = CalculateHour(index, offset)
            ElseIf begin.HasValue AndAlso Not hours(index) Then
                [end] = CalculateHour(index, offset)
                ltimes.Add(New LogonTime(CalculateDay(index, offset), New DateTime(Today.Year, 1, 1, begin.Value, 0, 0), New DateTime(Today.Year, 1, 1, [end].Value, 0, 0)))
                begin = Nothing
                [end] = Nothing
            End If
        Next
        Return ltimes
    End Function

    Private Shared Function CalculateHour(ByVal index As Integer, ByVal offset As Integer) As Integer
        Dim hour = index + offset
        hour = hour Mod 24
        Return hour
    End Function

    Private Shared Function CalculateDay(ByVal index As Integer, ByVal offset As Integer) As DayOfWeek
        Dim day = Math.Floor(CDec((index + offset)) / 24)
        Return CType(day, DayOfWeek)

    End Function
End Class

Public Class LogonTime
    Public Property DayOfWeek As DayOfWeek
    Public Property BeginTime As DateTime
    Public Property EndTime As DateTime
    Public Property TimeZoneOffSet As Integer

    Public Sub New(ByVal tDayOfWeek As DayOfWeek, ByVal tbeginTime As DateTime, ByVal tendTime As DateTime)
        DayOfWeek = tDayOfWeek
        BeginTime = tbeginTime
        EndTime = tendTime
        SetOffset(TimeZoneInfo.Local)
        ValidateTimes()
    End Sub

    Public Sub New(ByVal tDayOfWeek As DayOfWeek, ByVal tbegin As TimeSpan, ByVal [end] As TimeSpan)
        DayOfWeek = tDayOfWeek
        BeginTime = New DateTime(tbegin.Ticks)
        EndTime = New DateTime([end].Ticks)
        SetOffset(TimeZoneInfo.Local)
        ValidateTimes()
    End Sub

    Public Sub New(ByVal tDayOfWeek As DayOfWeek, ByVal tbeginTime As DateTime, ByVal tendTime As DateTime, ByVal TimeZone As TimeZoneInfo)
        DayOfWeek = tDayOfWeek
        BeginTime = tbeginTime
        EndTime = tendTime
        SetOffset(timeZone)
        ValidateTimes()
    End Sub

    Public Sub New(ByVal tDayOfWeek As DayOfWeek, ByVal tbegin As TimeSpan, ByVal [end] As TimeSpan, ByVal TimeZone As TimeZoneInfo)
        DayOfWeek = tDayOfWeek
        BeginTime = New DateTime(tbegin.Ticks)
        EndTime = New DateTime([end].Ticks)
        SetOffset(TimeZone)
        ValidateTimes()
    End Sub

    Private Sub SetOffset(ByVal timeZone As TimeZoneInfo)
        TimeZoneOffSet = (-1) * (timeZone.BaseUtcOffset.Hours)
    End Sub

    Private Sub ValidateTimes()
        'If EndTime.Hour < BeginTime.Hour Then
        '    'Throw New ArgumentException("Begin time cannot be after End time.")
        'End If
    End Sub
End Class
