Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices
Imports DsEntry = System.DirectoryServices.DirectoryEntry

Module DsEntryEx
    <Extension> Sub ExpirePasswd(dsUserEx As DsEntry)
        dsUserEx.Properties("PasswordExpired").Value = 1
    End Sub

    <Extension> Sub RefreshExpiredPasswd(dsUserEx As DsEntry)
        dsUserEx.Properties("PasswordExpired").Value = 0
    End Sub

    ''' <summary>
    ''' Returns a native IADs COM object from a DirectoryEntry user object.
    ''' Be sure you are dealing with a compatible DirectoryEntry user object, otherwise an exception will be thrown.
    ''' </summary>
    ''' <param name="u"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension>
    Function IADsU(u As DsEntry) As ActiveDs.IADsUser
        Return u.NativeObject
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
        Return g.NativeObject
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

    <Extension>
    Function SID(obj As ActiveDs.IADs) As String
        Return PtrToSID(obj.Get("objectSID"))
    End Function

    Private Declare Auto Function ConvertSidToStringSid Lib "advapi32.dll" (pSID() As Byte, ByRef ptrSid As IntPtr) As Boolean

    Function PtrToSID(SID As Byte()) As String
        Dim pSID As IntPtr

        If ConvertSidToStringSid(SID, pSID) Then
            Try
                Return Marshal.PtrToStringAuto(pSID)
            Catch ex As Exception
                Return "ERR"
            Finally
                free(pSID)
            End Try
        Else
            Return "ERR"
        End If
    End Function
End Module