Imports System.Runtime.InteropServices
Imports NTSTATUS = System.Int32
Module LsaInterop
    <StructLayout(LayoutKind.Sequential)>
    Structure LSA_REFERENCED_DOMAIN_LIST
        Public Entries As UInteger
        ''' <summary>
        ''' Pointer to LSA_TRUST_INFORMATION
        ''' </summary>
        ''' <remarks></remarks>
        Public Domains As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure LSA_TRUST_INFORMATION
        Public Name As LSA_UNICODE_STRING
        Public Sid As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure LSA_UNICODE_STRING
        Public Length, MaximumLength As UShort
        Public Buffer As IntPtr

        Public Overrides Function ToString() As String
            'The Length field is the length of the buffer, not the length of the string
            'Since it is a wide string, divide by 2
            Return Marshal.PtrToStringUni(Buffer, Length / 2)
        End Function
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure LSA_TRANSLATED_NAME
        Public Use As SID_NAME_USE,
        Name As LSA_UNICODE_STRING,
        DomainIndex As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure LSA_OBJECT_ATTRIBUTES
        Public Length As UInteger,
        RootDirectory As IntPtr,
        ObjectName As IntPtr,
        Attributes As UInteger,
        SecurityDescriptor As IntPtr,
        SecurityQualityOfService As IntPtr
    End Structure

    Enum SID_NAME_USE
        SidTypeUser = 1
        SidTypeGroup
        SidTypeDomain
        SidTypeAlia
        SidTypeWellKnownGroup
        SidTypeDeletedAccount
        SidTypeInvalid
        SidTypeUnknown
        SidTypeComputer
        SidTypeLabel
    End Enum

    <Flags>
    Enum ACCESS_MASK
        POLICY_ALL_ACCESS = 987135
        POLICY_READ = 131078
        POLICY_WRITE = 133112
        POLICY_EXECUTE = 133121

        POLICY_VIEW_LOCAL_INFORMATION = &H1
        POLICY_VIEW_AUDIT_INFORMATION = &H2
        POLICY_GET_PRIVATE_INFORMATION = &H4
        POLICY_TRUST_ADMIN = &H8
        POLICY_CREATE_ACCOUNT = &H10
        POLICY_CREATE_SECRET = &H20
        POLICY_CREATE_PRIVILEGE = &H40
        POLICY_SET_DEFAULT_QUOTA_LIMITS = &H80
        POLICY_SET_AUDIT_REQUIREMENTS = &H100
        POLICY_AUDIT_LOG_ADMIN = &H200
        POLICY_SERVER_ADMIN = &H400
        POLICY_LOOKUP_NAMES = &H800
        POLICY_NOTIFICATION = &H1000
    End Enum

    Private Declare Auto Function LsaLookupSids Lib "advapi32.dll" (PolicyHandle As IntPtr, Count As Integer, Sids As IntPtr, ByRef ReferencedDomains As IntPtr, ByRef Names As IntPtr) As NTSTATUS
    Private Declare Auto Function LsaOpenPolicy Lib "advapi32.dll" (ByRef SystemName As LSA_UNICODE_STRING, ByRef ObjectAttributes As LSA_OBJECT_ATTRIBUTES, DesiredAccess As ACCESS_MASK, ByRef PolicyHandle As IntPtr) As NTSTATUS
    Private Declare Auto Function LsaClose Lib "advapi32.dll" (ObjectHandle As IntPtr) As NTSTATUS
    Private Declare Auto Function LsaFreeMemory Lib "advapi32.dll" (buffer As IntPtr) As NTSTATUS
    Private Declare Auto Function LsaNtStatusToWinError Lib "advapi32.dll" (NTSTATUS As Integer) As NTSTATUS
    Private Declare Auto Function ConvertSidToStringSid Lib "advapi32.dll" (Sid As IntPtr, ByRef StringSid As IntPtr) As Integer
    Private Declare Auto Function LocalFree Lib "Kernel32.dll" (hMem As IntPtr) As IntPtr

    <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Function CreateWellKnownSid(WellKnownSidType As Integer, DomainSid As IntPtr, pSid As IntPtr, ByRef cbSid As Integer) As Integer
    End Function

    Const SECURITY_MAX_SID_SIZE As Integer = 68
    Const STATUS_SOME_NOT_MAPPED As NTSTATUS = &H107
    Const RPC_NT_CALL_FAILED As NTSTATUS = &HC002001B
    Const STATUS_SUCCESS As NTSTATUS = 0

    Function GetPolicyHandle(pSsystemName As String, parentWnd As IntPtr) As IntPtr
        Dim systemName As New LSA_UNICODE_STRING
        systemName.Buffer = Marshal.StringToHGlobalAuto(pSsystemName)
        systemName.Length = pSsystemName.Length * System.Text.UnicodeEncoding.CharSize
        systemName.MaximumLength = (pSsystemName.Length + 1) * System.Text.UnicodeEncoding.CharSize

        Dim PolicyHandle As IntPtr

        Dim result As NTSTATUS = LsaOpenPolicy(systemName, New LSA_OBJECT_ATTRIBUTES, ACCESS_MASK.POLICY_LOOKUP_NAMES, PolicyHandle)
        If result <> STATUS_SUCCESS Then
            Throw New System.ComponentModel.Win32Exception(LsaNtStatusToWinError(result))
        End If

        Marshal.FreeHGlobal(systemName.Buffer)

        Return PolicyHandle
    End Function

    Sub ClosePolicyHandle(pHandle As IntPtr, parentWnd As IntPtr)
        Dim result As NTSTATUS = LsaClose(pHandle)
        If result <> STATUS_SUCCESS AndAlso result <> RPC_NT_CALL_FAILED Then
            Debug.WriteLine("Function LsaClose failed. Error code: " & LsaNtStatusToWinError(result))
        End If
    End Sub

    Function LookupWellKnownSids(PolicyHandle As IntPtr, parentWnd As IntPtr, Sids As Integer()) As List(Of BuiltInPrincipal)
        Try
            Dim Principals As List(Of BuiltInPrincipal) = Nothing

            Dim pSidArray As IntPtr = Marshal.AllocHGlobal(SECURITY_MAX_SID_SIZE * Sids.Length)
            'This counts the number of failed SID creations
            Dim SidErrors As Integer = 0

            For i As Integer = 0 To Sids.Length - 1
                Dim sidSize As Integer = SECURITY_MAX_SID_SIZE

                If CreateWellKnownSid(Sids(i), IntPtr.Zero, IntPtr.Add(pSidArray, SECURITY_MAX_SID_SIZE * (i - SidErrors)), sidSize) = FAIL Then
                    SidErrors += 1
                End If
            Next

            'For the actual number of Sids in the array, the failed ones need to be subtracted
            Dim SidCount As Integer = Sids.Length - SidErrors

            'LsaLookupSids wants a pointer to an array of pointers, so copy the pointers into a seperate array, whose pointer is passed to LsaLookupSids.
            Dim pSidPointersArray As IntPtr = Marshal.AllocHGlobal(IntPtr.Size * SidCount)

            For i As Integer = 0 To SidCount - 1
                Marshal.WriteIntPtr(pSidPointersArray, IntPtr.Size * i, IntPtr.Add(pSidArray, SECURITY_MAX_SID_SIZE * i))
            Next

            Dim pReferencedDomains, pTranslatedNames As IntPtr

            Dim LookupResult As NTSTATUS = LsaLookupSids(PolicyHandle, SidCount, pSidPointersArray, pReferencedDomains, pTranslatedNames)
            If LookupResult <> STATUS_SOME_NOT_MAPPED AndAlso LookupResult <> STATUS_SUCCESS Then
                Throw New System.ComponentModel.Win32Exception(LsaNtStatusToWinError(LookupResult))
            Else
                'Read the pointer pointing to the beginning of the TranslatedNames array and store the elements in a managed array
                Dim TranslatedNames As LSA_TRANSLATED_NAME() = PtrToArray(Of LSA_TRANSLATED_NAME)(pTranslatedNames, SidCount)

                'Read the ReferencedDomains pointer and store the elements of the Domains pointer in an array
                Dim ReferencedDomains As LSA_REFERENCED_DOMAIN_LIST = Marshal.PtrToStructure(Of LSA_REFERENCED_DOMAIN_LIST)(pReferencedDomains)
                Dim Domains As LSA_TRUST_INFORMATION() = PtrToArray(Of LSA_TRUST_INFORMATION)(ReferencedDomains.Domains, ReferencedDomains.Entries)

                'Copy the unmanaged array to a managed array of Pointers (pointing to SIDs)
                Dim SidPointersArray As IntPtr() = New IntPtr(SidCount - 1) {}
                Marshal.Copy(pSidPointersArray, SidPointersArray, 0, SidCount)

                'Initialize the Principals array
                Principals = New List(Of BuiltInPrincipal)(SidCount - 1)

                For i As Integer = 0 To SidCount - 1

                    If TranslatedNames(i).Name.Length = 0 Then
                        Continue For
                    End If

                    Dim DomainIndex As Integer = TranslatedNames(i).DomainIndex
                    If DomainIndex = 4 Then
                        DomainIndex = 6
                    ElseIf DomainIndex = -1 Then
                        Continue For
                    End If
                    Dim Domain As LSA_TRUST_INFORMATION = Domains(DomainIndex)

                    Dim newP As New BuiltInPrincipal()

                    If Domain.Name.Length > 0 Then
                        newP.Name = Domain.Name.ToString() & "\"
                    End If

                    newP.Name &= TranslatedNames(i).Name.ToString()

                    Dim pStringSid As IntPtr
                    If ConvertSidToStringSid(SidPointersArray(i), pStringSid) = FAIL Then
                        newP.SID = "Error retrieving SID"
                    Else
                        newP.SID = Marshal.PtrToStringAuto(pStringSid)
                        If newP.SID.Split("-"c).Length < 4 Then
                            Continue For
                        End If
                        LocalFree(pStringSid)
                    End If

                    Principals.Add(newP)
                Next

                Principals.TrimExcess()
            End If

            LsaFreeMemory(pReferencedDomains)
            LsaFreeMemory(pTranslatedNames)
            Marshal.FreeHGlobal(pSidArray)
            Marshal.FreeHGlobal(pSidPointersArray)

            Return Principals
        Catch ex As COMException
            ShowCOMErr(ex.ErrorCode, parentWnd, ex.Message)
            Return New List(Of BuiltInPrincipal)(0)
        Catch ex As Exception
            ShowUnknownErr(parentWnd, ex.Message, "Issue occurred at: LookupWellKnownSids")
            Return New List(Of BuiltInPrincipal)(0)
        End Try
    End Function

    Function PtrToArray(Of T)(ptr As IntPtr, arrlength As Integer) As T()
        Dim mArr As T() = New T(arrlength - 1) {}

        For i As Integer = 0 To arrlength - 1
            mArr(i) = Marshal.PtrToStructure(Of T)(IntPtr.Add(ptr, Marshal.SizeOf(Of T)() * i))
        Next

        Return mArr
    End Function
End Module
