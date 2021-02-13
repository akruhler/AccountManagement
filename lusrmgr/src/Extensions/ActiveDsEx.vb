Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports DsEntry = System.DirectoryServices.DirectoryEntry

Module DsEntryEx
    Public Const strErr As String = ChrW(7) & "$ERR"

    <Extension> Sub ExpirePasswd(dsUserEx As DsEntry)
        dsUserEx.Properties("PasswordExpired").Value = 1
    End Sub

    <Extension> Sub RefreshExpiredPasswd(dsUserEx As DsEntry)
        dsUserEx.Properties("PasswordExpired").Value = 0
    End Sub

    <Extension> Function PasswordExpired(dsUserEx As DsEntry) As Boolean
        Return Convert.ToBoolean(dsUserEx.Properties("PasswordExpired").Value)
    End Function

    ''' <summary>
    ''' Returns a native IADs COM object from a DirectoryEntry user object.
    ''' Be sure you are dealing with a compatible DirectoryEntry user object, otherwise an exception will be thrown.
    ''' </summary>
    ''' <param name="u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension>
    Function IADsU(u As DsEntry) As ActiveDs.IADsUser
        If u IsNot Nothing Then
            Return u.NativeObject
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Returns a native IADs COM object from a DirectoryEntry group object.
    ''' Be sure you are dealing with a compatible DirectoryEntry group object, otherwise an exception will be thrown.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension>
    Function IADsG(g As DsEntry) As ActiveDs.IADsGroup
        If g IsNot Nothing Then
            Return g.NativeObject
        Else
            Return Nothing
        End If
    End Function

    <Extension>
    Function GetUserFlag(user As DsEntry, flag As ActiveDs.ADS_USER_FLAG) As Boolean
        If (user.Properties("userFlags").Value And flag) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    <Extension>
    Sub SetUserFlag(user As DsEntry, flag As ActiveDs.ADS_USER_FLAG, value As Boolean)
        If value Then
            user.Properties("UserFlags").Value = user.Properties("UserFlags").Value Or flag
        Else
            user.Properties("UserFlags").Value = user.Properties("UserFlags").Value And Not flag
        End If
    End Sub

    Sub SetUserFlag(ByRef flags As Integer, flag As ActiveDs.ADS_USER_FLAG, value As Boolean)
        If value Then
            flags = flags Or flag
        Else
            flags = flags And Not flag
        End If
    End Sub

    Function isDisallowed(c As Char) As Boolean
        Return {"/"c, "\"c, "["c, "]"c, """"c, ":"c, ";"c, "|"c, "<"c, ">"c, "+"c, "="c, ","c, "?"c, "*"c, "%"c, "@"c}.Contains(c)
    End Function

    <Extension>
    Function GetSID(obj As ActiveDs.IADs) As String
        Return PtrToSID(obj.Get("objectSID"))
    End Function

    Private Declare Auto Function ConvertSidToStringSid Lib "advapi32.dll" (pSID() As Byte, ByRef ptrSid As IntPtr) As Boolean

    Function PtrToSID(SID As Byte()) As String
        Dim pSID As IntPtr
        Dim strSID As String

        If ConvertSidToStringSid(SID, pSID) Then
            strSID = Marshal.PtrToStringAuto(pSID)
            Marshal.FreeHGlobal(pSID)
            Return strSID
        Else
            TaskDialog(IntPtr.Zero, "An unknown error occurred", "Error whilst processing SID", "An error occurred whilst converting a SID to a String object.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, Nothing)
            Return strErr
        End If
    End Function
End Module